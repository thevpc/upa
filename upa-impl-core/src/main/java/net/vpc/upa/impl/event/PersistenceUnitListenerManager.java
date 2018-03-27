package net.vpc.upa.impl.event;

import net.vpc.upa.*;
import net.vpc.upa.Package;
import net.vpc.upa.callbacks.*;
import net.vpc.upa.config.Init;
import net.vpc.upa.exceptions.EntityAlreadyExistsException;
import net.vpc.upa.exceptions.UPAIllegalArgumentException;
import net.vpc.upa.exceptions.NoSuchEntityException;
import net.vpc.upa.exceptions.ObjectAlreadyExistsException;
import net.vpc.upa.expressions.Select;
import net.vpc.upa.impl.ObjectRegistrationModel;
import net.vpc.upa.impl.SerializableOrManyToOneType;
import net.vpc.upa.impl.config.annotationparser.FieldSerializableOrEntityProcessor;
import net.vpc.upa.impl.config.annotationparser.RelationshipDescriptorProcessor;
import net.vpc.upa.impl.config.decorations.DecorationRepository;
import net.vpc.upa.impl.util.CallbackManager;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.impl.util.StringUtils;
import net.vpc.upa.types.DataType;
import net.vpc.upa.types.ManyToOneType;

import java.lang.reflect.Method;
import java.util.*;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 11/27/12 9:07 PM
 */
public class PersistenceUnitListenerManager implements UPAObjectListener {

    private static final Logger log = Logger.getLogger(PersistenceUnitListenerManager.class.getName());

    public ListenerSupport<FieldDefinitionListener> fields = new ListenerSupport<FieldDefinitionListener>();
    public ListenerSupport<SectionDefinitionListener> sections = new ListenerSupport<SectionDefinitionListener>();
    public ListenerSupport<EntityDefinitionListener> entities = new ListenerSupport<EntityDefinitionListener>();
    public ListenerSupport<IndexDefinitionListener> indexes = new ListenerSupport<IndexDefinitionListener>();
    public ListenerSupport<RelationshipDefinitionListener> relationships = new ListenerSupport<RelationshipDefinitionListener>();
    public ListenerSupport<TriggerDefinitionListener> entityTriggers = new ListenerSupport<TriggerDefinitionListener>();
    public List<PackageDefinitionListener> packages = new ArrayList<PackageDefinitionListener>();
    public final List<PersistenceUnitListener> persistenceUnitListeners = new ArrayList<PersistenceUnitListener>();
    //    List<PersistenceUnitTriggerDefinitionListener> persistenceUnitTriggers = new ArrayList<PersistenceUnitTriggerDefinitionListener>();
    private ObjectRegistrationModel model;
    private DecorationRepository decorationRepository;
    private PersistenceUnit persistenceUnit;
    private CallbackManager callbackManager = new CallbackManager();
    public static boolean DEFAULT_SYSTEM = false;

    public PersistenceUnitListenerManager(PersistenceUnit persistenceUnit, ObjectRegistrationModel model, DecorationRepository decorationRepository) {
        this.persistenceUnit = persistenceUnit;
        this.model = model;
        this.decorationRepository = decorationRepository;
    }

    public void itemRenamed(UPAObject object, String oldName, String newName,EventPhase phase) {
        if (object instanceof Entity) {
            if(StringUtils.isNullOrEmpty(newName)){
                throw new UPAIllegalArgumentException("Empty New Name for "+oldName);
            }
            model.renameEntity(oldName,newName);
            return;
        }
        throw new UPAIllegalArgumentException("Renaming "+object+" is not yet Supported");
    }

    public void itemAdded(UPAObject object, int position, UPAObject parent, EventPhase phase) {
        if (object instanceof Entity) {
            Entity entity = (Entity) object;
            Package parentModule = (Package) parent;
            if (phase == EventPhase.BEFORE) {
                if (model.containsEntity(entity, parentModule)) {
                    Entity registered = model.getEntity(entity.getName());
                    Object s1 = entity.getEntityDescriptor().getSource();
                    if (s1 != null && s1 instanceof Object[]) {
                        s1 = Arrays.toString((Object[]) s1);
                    }
                    Object s2 = registered.getEntityDescriptor().getSource();
                    if (s2 != null && s2 instanceof Object[]) {
                        s2 = Arrays.toString((Object[]) s2);
                    }
                    throw new EntityAlreadyExistsException(entity.getName(), s1, s2);
                }
                addHandlers(object);
                fireOnCreateEntity(entity, position, phase);
            } else {
                model.registerEntity(entity, parentModule);
                fireOnCreateEntity(entity, position, phase);

                EntityDescriptor entityInfo = entity.getEntityDescriptor();

                String orderByString = entityInfo.getListOrder();
                if (!StringUtils.isNullOrEmpty(orderByString)) {
                    Select s = (Select) persistenceUnit.getExpressionManager().parseExpression("Select a from " + entity.getName() + " order by " + orderByString);
                    entity.setListOrder(s.getOrder());
                }
                orderByString = entityInfo.getArchivingOrder();
                if (!StringUtils.isNullOrEmpty(orderByString)) {
                    Select s = (Select) persistenceUnit.getExpressionManager().parseExpression("Select a from " + entity.getName() + " order by " + orderByString);
                    entity.setArchivingOrder(s.getOrder());
                }
                List<FieldDescriptor> fieldDescriptors = entityInfo.getFieldDescriptors();
                if (fieldDescriptors != null) {
                    for (FieldDescriptor field : fieldDescriptors) {
                        entity.addField(field);
                    }
                }
                List<IndexDescriptor> indexDescriptors = entityInfo.getIndexDescriptors();
                if (indexDescriptors != null) {
                    for (IndexDescriptor index : indexDescriptors) {
                        entity.addIndex(index.getName(), index.isUnique(), index.getFieldNames());
                    }
                }
                List<RelationshipDescriptor> relationshipDescriptors = entityInfo.getRelationshipDescriptors();
                if (relationshipDescriptors != null) {
                    for (final RelationshipDescriptor relationDescriptor : relationshipDescriptors) {
                        entity.getPersistenceUnit().addRelationship(relationDescriptor);
                    }
                }
                fireOnPrepareEntity(entity, position, EventPhase.BEFORE);

                //some fields may be added as ManyToOne without explicit definition of RelationshipDescriptor
                // must process them accordingly
                //will first retrieve ManyToOne fields than will add relations for
                //ones without relation!
                HashSet<String> initialManyToOneFields = new HashSet<String>();
                List<Relationship> existing = entity.getPersistenceUnit().getRelationshipsBySource(entity);
                for (Relationship relationship : existing) {
                    if (relationship.getSourceRole().getEntityField() != null) {
                        initialManyToOneFields.add(relationship.getSourceRole().getEntityField().getName());
                    }
                }
                for (PersistenceUnitListener persistenceUnitListener : entity.getPersistenceUnit().getPersistenceUnitListeners()) {
                    if (persistenceUnitListener instanceof RelationshipDescriptorProcessor) {
                        RelationshipDescriptorProcessor r = (RelationshipDescriptorProcessor) persistenceUnitListener;
                        RelationshipDescriptor d = r.getRelationDescriptor();
                        if (d.getSourceEntity() != null) {
                            if (d.getSourceEntity().equals(entity.getName())) {
                                if (d.getBaseField() != null) {
                                    initialManyToOneFields.add(d.getBaseField());
                                }
                            }
                        } else if (d.getSourceEntityType().equals(entity.getEntityType())) {
                            if (d.getBaseField() != null) {
                                initialManyToOneFields.add(d.getBaseField());
                            }
                        }
                    }
                }
                for (Field field : entity.getFields()) {
                    DataType dt = field.getDataType();

                    //check if relationship not already defined
                    if (dt instanceof ManyToOneType
                            && ((ManyToOneType) dt).getRelationship() == null) {
                        if (!initialManyToOneFields.contains(field.getName())) {

                            //no relationship defined!
                            entity.getPersistenceUnit().addRelationship(
                                    new DefaultRelationshipDescriptor()
                                            .setBaseField(field.getName())
                                            .setNullable(dt.isNullable())
                                            .setSourceEntity(entity.getName())
                                            .setSourceEntityType(entity.getEntityType())
                                            .setTargetEntity(((ManyToOneType) dt).getTargetEntityName())
                                            .setTargetEntityType(((ManyToOneType) dt).getPlatformType())
                                            .setSourceFields(new String[]{field.getName()})
                            );
                        }
                    }
                }
                if (entityInfo.getSource() != null && entityInfo.getSource() != entityInfo) {
                    Class c = entityInfo.getSource().getClass();
                    List<Method> methods = new ArrayList<Method>();
                    while (c != null) {
                        for (Method m : c.getDeclaredMethods()) {
                            if (decorationRepository.getMethodDecoration(m, Init.class) != null
                                    || decorationRepository.getMethodDecoration(m, "javax.annotation.PostConstruct") != null) {
                                m.setAccessible(true);
                                methods.add(m);
                            }
                        }
                        c = c.getSuperclass();
                    }
                    //reverse execution (must call super attach before instance attach
                    Collections.reverse(methods);
                    for (Method m : methods) {
                        Class<?>[] parameterTypes = m.getParameterTypes();
                        Object[] params = new Object[parameterTypes.length];
                        for (int i = 0; i < params.length; i++) {
                            if (PersistenceUnit.class.equals(parameterTypes[i])) {
                                params[i] = entity.getPersistenceUnit();
                            } else if (Entity.class.equals(parameterTypes[i])) {
                                params[i] = entity;
                            } else {
                                throw new UPAIllegalArgumentException("Unexpected parameter " + (i + 1) + " for " + m);
                            }
                        }
                        try {
                            m.invoke(entityInfo.getSource(), params);
                        } catch (Exception ex) {
                            log.log(Level.SEVERE, null, ex);
                        }
                    }
                }
                fireOnPrepareEntity(entity, position, EventPhase.AFTER);

            }
        } else if (object instanceof Field) {
            Field field = (Field) object;
            if (phase == EventPhase.BEFORE) {
                Entity entity = field.getEntity();
                Package module = entity.getParent();
                String s = (module == null ? "/" : module.getPath() + "/") + entity.getName() + "/" + field.getName();
                if (model.containsField(field)) {
                    throw new ObjectAlreadyExistsException("Field already exists", s);
                }
                addHandlers(object);
                fireFieldAdded(field, position, phase);
            } else {
                model.registerField(field);
                if (field.getDataType() instanceof SerializableOrManyToOneType) {
                    FieldSerializableOrEntityProcessor p = new FieldSerializableOrEntityProcessor(field.getPersistenceUnit(), field);
                    p.process();
                }
                fireFieldAdded(field, position, phase);
            }
        } else if (object instanceof Index) {
            Index index = (Index) object;
            Entity parentEntity = (Entity) parent;
            if (phase == EventPhase.BEFORE) {
                String s = index.getName();
                if (model.containsIndex(index, parentEntity)) {
                    throw new ObjectAlreadyExistsException("Index already exists", s);
                }
                addHandlers(object);
                fireOnCreateIndex(index, position, phase);
            } else {
                model.registerIndex(index, parentEntity);
                fireOnCreateIndex(index, position, phase);
            }
        } else if (object instanceof Section) {
            Section section = (Section) object;
            if (phase == EventPhase.BEFORE) {
                Entity entity = section.getEntity();
                Package module = entity.getParent();
                String s = (module == null ? "/" : module.getPath() + "/") + entity.getName() + "/" + section.getPath();
                if (model.containsSection(section)) {
                    throw new ObjectAlreadyExistsException("Section already exists", s);
                }
                addHandlers(object);
                fireOnCreateSection(section, position, phase);
            } else {
                model.registerSection(section);
                fireOnCreateSection(section, position, phase);
            }
        } else if (object instanceof Package) {
            Package module = (Package) object;
            Package parentModule = (Package) parent;
            if (phase == EventPhase.BEFORE) {
                String s = null;
                if (parent == null) {
                    s = "/" + module.getName();
                } else {
                    s = parentModule.getPath() + "/" + module.getName();
                }
                if (model.containsPackage(module, parentModule)) {
                    throw new ObjectAlreadyExistsException("Package already exists", s);
                }
                addHandlers(object);
                fireOnCreatePackage(module, parentModule, position, phase);
            } else {
                model.registerPackage(module, parentModule);
                fireOnCreatePackage(module, parentModule, position, phase);
            }
        } else if (object instanceof Relationship) {
            Relationship relation = (Relationship) object;
            if (phase == EventPhase.BEFORE) {
                String s = relation.getName();
                if (model.containsRelationship(relation)) {
                    throw new ObjectAlreadyExistsException("Relationship already exists", s);
                }
                addHandlers(object);
                fireOnCreateRelationship(relation, position, phase);
            } else {
                model.registerRelationship(relation);
                fireOnCreateRelationship(relation, position, phase);
            }
        } else {
            throw new UPAIllegalArgumentException("No supported");
        }
    }

    public void itemRemoved(UPAObject object, int position, EventPhase phase) {
        if (object instanceof Entity) {
            Entity entity = (Entity) object;
            if (phase == EventPhase.BEFORE) {
                if (!model.containsEntity(entity, entity.getParent())) {
                    throw new NoSuchEntityException(entity.getName(), null);
                }
                fireOnDropEntity(entity, position, phase);
            } else {
                removeHandlers(object);
                model.unregisterEntity(entity);
                fireOnDropEntity(entity, position, phase);
            }
        } else if (object instanceof Field) {
            Field field = (Field) object;
            if (phase == EventPhase.BEFORE) {
                if (!model.containsField(field)) {
                    throw new net.vpc.upa.exceptions.NoSuchFieldException(field.getEntity()==null?null:field.getEntity().getName(), field.getAbsoluteName(),field.getName(),null);
                }
                fireFieldRemoved(field, position, phase);
            } else {
                removeHandlers(object);
                model.unregisterField(field);
                fireFieldRemoved(field, position, phase);
            }
        } else if (object instanceof Index) {
            Index index = (Index) object;
            if (phase == EventPhase.BEFORE) {
                if (!model.containsIndex(index, index.getEntity())) {
                    throw new net.vpc.upa.exceptions.NoSuchIndexException(index.getEntity().getName(), index.getName(), null);
                }
                fireOnDropIndex(index, position, phase);
            } else {
                removeHandlers(object);
                model.unregisterIndex(index);
                fireOnDropIndex(index, position, phase);
            }
        } else if (object instanceof Section) {
            Section section = (Section) object;
            if (phase == EventPhase.BEFORE) {
                if (!model.containsSection(section)) {
                    throw new net.vpc.upa.exceptions.NoSuchSectionException(section.getAbsoluteName(), null);
                }
                fireOnDropSection(section, position, phase);
            } else {
                removeHandlers(object);
                model.unregisterSection(section);
                fireOnDropSection(section, position, phase);
            }
        } else if (object instanceof Package) {
            Package module = (Package) object;
            if (phase == EventPhase.BEFORE) {
                if (!model.containsPackage(module, module.getParent())) {
                    throw new net.vpc.upa.exceptions.NoSuchPackageException(module.getAbsoluteName(), null);
                }
                fireOnDropPackage(module, position, phase);
            } else {
                removeHandlers(object);
                model.unregisterPackage(module);
                fireOnDropPackage(module, position, phase);
            }
        } else if (object instanceof Relationship) {
            Relationship relation = (Relationship) object;
            if (phase == EventPhase.BEFORE) {
                if (!model.containsRelationship(relation)) {
                    throw new net.vpc.upa.exceptions.NoSuchRelationshipException(relation.getAbsoluteName(), null);
                }
                fireOnDropRelationship(relation, position, phase);
            } else {
                removeHandlers(object);
                model.unregisterRelation(relation);
                fireOnDropRelationship(relation, position, phase);
            }
        } else {
            throw new UPAIllegalArgumentException("No supported");
        }
    }

    public void itemMoved(UPAObject object, int position, int toPosition, EventPhase phase) {
        if (object instanceof Entity) {
            Entity entity = (Entity) object;
            EntityEvent event = new EntityEvent(entity, entity.getPersistenceUnit(), entity.getParent(), position, null, toPosition, phase);
            String entityTypeListenerId = getEntityTypeListenerId(entity.getEntityType());
            boolean system = entity.getUserModifiers().contains(EntityModifier.SYSTEM);
            List<EntityDefinitionListener> interceptorList = entities.getAllListeners(system, entity.getName(), entityTypeListenerId);
            if (phase == EventPhase.BEFORE) {
                for (EntityDefinitionListener listener : interceptorList) {
                    listener.onPreMoveEntity(event);
                }
                for (Callback invoker : getPreCallbacks(CallbackType.ON_MOVE, ObjectType.ENTITY, entity.getName(), entity.isSystem())) {
                    invoker.invoke(event);
                }
                for (PreparedCallback callback : getPostPreparedCallbacks(CallbackType.ON_MOVE, ObjectType.ENTITY, entity.getName(), entity.isSystem())) {
                    callback.prepare(event);
                }
            } else {
                for (EntityDefinitionListener listener : interceptorList) {
                    listener.onMoveEntity(event);
                }
                for (Callback invoker : getPostCallbacks(CallbackType.ON_MOVE, ObjectType.ENTITY, entity.getName(), entity.isSystem())) {
                    invoker.invoke(event);
                }
            }
        } else if (object instanceof Field) {
            Field field = (Field) object;
            final Entity entity = field.getEntity();
            String entityTypeListenerId = getEntityTypeListenerId(entity.getEntityType());
            boolean system = entity.getUserModifiers().contains(EntityModifier.SYSTEM);
            FieldEvent event = new FieldEvent(field, field.getPersistenceUnit(), entity, field.getParent(), position, null, toPosition, phase);
            List<FieldDefinitionListener> interceptorList = fields.getAllListeners(system, entity.getName(), entityTypeListenerId);
            if (phase == EventPhase.BEFORE) {
                for (FieldDefinitionListener listener : interceptorList) {
                    listener.onPreMoveField(event);
                }
                for (Callback invoker : getPreCallbacks(CallbackType.ON_MOVE, ObjectType.FIELD, entity.getName(), entity.isSystem())) {
                    invoker.invoke(event);
                }
                for (PreparedCallback callback : getPostPreparedCallbacks(CallbackType.ON_MOVE, ObjectType.FIELD, entity.getName(), entity.isSystem())) {
                    callback.prepare(event);
                }
            } else {
                for (FieldDefinitionListener listener : interceptorList) {
                    listener.onMoveField(event);
                }
                for (Callback invoker : getPostCallbacks(CallbackType.ON_MOVE, ObjectType.FIELD, entity.getName(), entity.isSystem())) {
                    invoker.invoke(event);
                }
            }
        } else if (object instanceof Section) {
            Section section = (Section) object;
            Entity entity = section.getEntity();
            SectionEvent event = new SectionEvent(section, section.getPersistenceUnit(), entity, (Section) section.getParent(), position, null, toPosition, phase);
            String entityTypeListenerId = getEntityTypeListenerId(entity.getEntityType());
            boolean system = entity.getUserModifiers().contains(EntityModifier.SYSTEM);
            List<SectionDefinitionListener> interceptorList = sections.getAllListeners(system, section.getName(), entityTypeListenerId);
            if (phase == EventPhase.BEFORE) {
                for (SectionDefinitionListener listener : interceptorList) {
                    listener.onPreMoveSection(event);
                }
                for (Callback invoker : getPreCallbacks(CallbackType.ON_MOVE, ObjectType.SECTION, entity.getName(), entity.isSystem())) {
                    invoker.invoke(event);
                }
                for (PreparedCallback callback : getPostPreparedCallbacks(CallbackType.ON_MOVE, ObjectType.SECTION, entity.getName(), entity.isSystem())) {
                    callback.prepare(event);
                }
            } else {
                for (SectionDefinitionListener listener : interceptorList) {
                    listener.onMoveSection(event);
                }
                for (Callback invoker : getPostCallbacks(CallbackType.ON_MOVE, ObjectType.SECTION, entity.getName(), entity.isSystem())) {
                    invoker.invoke(event);
                }
            }
        } else if (object instanceof Package) {
            Package module = (Package) object;
            PackageEvent event = new PackageEvent(module, module.getPersistenceUnit(), module.getParent(), position, null, toPosition, phase);
            List<PackageDefinitionListener> interceptorList = packages;
            if (phase == EventPhase.BEFORE) {
                for (PackageDefinitionListener listener : interceptorList) {
                    listener.onPreMovePackage(event);
                }
                for (Callback invoker : getPreCallbacks(CallbackType.ON_MOVE, ObjectType.PACKAGE, persistenceUnit.getName(), DEFAULT_SYSTEM)) {
                    invoker.invoke(event);
                }
                for (PreparedCallback callback : getPostPreparedCallbacks(CallbackType.ON_MOVE, ObjectType.PACKAGE, persistenceUnit.getName(), DEFAULT_SYSTEM)) {
                    callback.prepare(event);
                }
            } else {
                for (PackageDefinitionListener listener : interceptorList) {
                    listener.onMovePackage(event);
                }
                for (Callback invoker : getPostCallbacks(CallbackType.ON_MOVE, ObjectType.PACKAGE, persistenceUnit.getName(), DEFAULT_SYSTEM)) {
                    invoker.invoke(event);
                }
            }
        }
    }

    public void fireOnCreateTrigger(Trigger trigger, EventPhase phase) {
        TriggerEvent evt = new TriggerEvent(trigger, trigger.getEntity(), phase);
        if (phase == EventPhase.BEFORE) {
            for (TriggerDefinitionListener li : entityTriggers.getAllListeners(false, trigger.getEntity().getName())) {
                li.onPreCreateTrigger(evt);
            }
            for (Callback callback : getPreCallbacks(CallbackType.ON_CREATE, ObjectType.TRIGGER, trigger.getEntity().getName(), trigger.getEntity().isSystem())) {
                callback.invoke(evt);
            }
            for (PreparedCallback callback : getPostPreparedCallbacks(CallbackType.ON_CREATE, ObjectType.TRIGGER, trigger.getEntity().getName(), trigger.getEntity().isSystem())) {
                callback.invoke(evt);
            }
        } else {
            for (TriggerDefinitionListener li : entityTriggers.getAllListeners(false, trigger.getEntity().getName())) {
                li.onCreateTrigger(evt);
            }
            for (Callback callback : getPostCallbacks(CallbackType.ON_CREATE, ObjectType.TRIGGER, trigger.getEntity().getName(), trigger.getEntity().isSystem())) {
                callback.invoke(evt);
            }
        }
    }

    public void fireOnDropTrigger(Trigger trigger, EventPhase phase) {
        TriggerEvent evt = new TriggerEvent(trigger, trigger.getEntity(), phase);
        boolean system = trigger.getEntity().getUserModifiers().contains(EntityModifier.SYSTEM);
        if (phase == EventPhase.BEFORE) {
            for (TriggerDefinitionListener li : entityTriggers.getAllListeners(false, trigger.getEntity().getName())) {
                li.onPreDropTrigger(evt);
            }
            for (Callback callback : getPreCallbacks(CallbackType.ON_DROP, ObjectType.TRIGGER, trigger.getEntity().getName(), system)) {
                callback.invoke(evt);
            }
            for (PreparedCallback callback : getPostPreparedCallbacks(CallbackType.ON_DROP, ObjectType.TRIGGER, trigger.getEntity().getName(), system)) {
                callback.prepare(evt);
            }
        } else {
            for (TriggerDefinitionListener li : entityTriggers.getAllListeners(false, trigger.getEntity().getName())) {
                li.onDropTrigger(evt);
            }
            for (Callback callback : getPostCallbacks(CallbackType.ON_DROP, ObjectType.TRIGGER, trigger.getEntity().getName(), system)) {
                callback.invoke(evt);
            }
        }
    }

    protected void fireOnCreateEntity(Entity entity, int position, EventPhase phase) {
        EntityEvent evt = new EntityEvent(entity, entity.getPersistenceUnit(), entity.getParent(), position, null, -1, phase);
        String entityTypeListenerId = getEntityTypeListenerId(entity.getEntityType());
        boolean system = entity.getUserModifiers().contains(EntityModifier.SYSTEM);
        if (phase == EventPhase.BEFORE) {
            for (EntityDefinitionListener listener : entities.getAllListeners(system, entity.getName(), entityTypeListenerId)) {
                listener.onPreCreateEntity(evt);
            }
            for (Callback callback : getPreCallbacks(CallbackType.ON_CREATE, ObjectType.ENTITY, entity.getName(), system)) {
                callback.invoke(evt);
            }
            for (PreparedCallback callback : getPostPreparedCallbacks(CallbackType.ON_CREATE, ObjectType.ENTITY, entity.getName(), system)) {
                callback.prepare(evt);
            }
        } else {
            for (EntityDefinitionListener listener : entities.getAllListeners(system, entity.getName(), entityTypeListenerId)) {
                listener.onCreateEntity(evt);
            }
            for (Callback callback : getPostCallbacks(CallbackType.ON_CREATE, ObjectType.ENTITY, entity.getName(), system)) {
                callback.invoke(evt);
            }
        }
    }

//    protected void fireOnInitEntity(Entity entity, int position, EventPhase phase) {
//        EntityEvent evt = new EntityEvent(entity, entity.getPersistenceUnit(), entity.getParent(), position, null, -1, phase);
//        String entityTypeListenerId = getEntityTypeListenerId(entity.getEntityType());
//        boolean system = entity.getUserModifiers().contains(EntityModifier.SYSTEM);
//        if (phase == EventPhase.BEFORE) {
//            for (EntityDefinitionListener listener : entities.getAllListeners(system, entity.getName(), entityTypeListenerId)) {
//                listener.onPrePrepareEntity(evt);
//            }
//            for (Callback callback : getPreCallbacks(CallbackType.ON_INIT, ObjectType.ENTITY, entity.getName(), system)) {
//                callback.invoke(evt);
//            }
//            for (PreparedCallback callback : getPostPreparedCallbacks(CallbackType.ON_INIT, ObjectType.ENTITY, entity.getName(), system)) {
//                callback.prepare(evt);
//            }
//        } else {
//            for (EntityDefinitionListener listener : entities.getAllListeners(system, entity.getName(), entityTypeListenerId)) {
//                listener.onPrepareEntity(evt);
//            }
//            for (Callback callback : getPostCallbacks(CallbackType.ON_INIT, ObjectType.ENTITY, entity.getName(), system)) {
//                callback.invoke(evt);
//            }
//        }
//    }

    protected void fireOnPrepareEntity(Entity entity, int position, EventPhase phase) {
        EntityEvent evt = new EntityEvent(entity, entity.getPersistenceUnit(), entity.getParent(), position, null, -1, phase);
        String entityTypeListenerId = getEntityTypeListenerId(entity.getEntityType());
        boolean system = entity.getUserModifiers().contains(EntityModifier.SYSTEM);
        if (phase == EventPhase.BEFORE) {
            for (EntityDefinitionListener listener : entities.getAllListeners(system, entity.getName(), entityTypeListenerId)) {
                listener.onPrePrepareEntity(evt);
            }
            for (Callback callback : getPreCallbacks(CallbackType.ON_PREPARE, ObjectType.ENTITY, entity.getName(), system)) {
                callback.invoke(evt);
            }
            for (PreparedCallback callback : getPostPreparedCallbacks(CallbackType.ON_PREPARE, ObjectType.ENTITY, entity.getName(), system)) {
                callback.prepare(evt);
            }
        } else {
            for (EntityDefinitionListener listener : entities.getAllListeners(system, entity.getName(), entityTypeListenerId)) {
                listener.onPrepareEntity(evt);
            }
            for (Callback callback : getPostCallbacks(CallbackType.ON_PREPARE, ObjectType.ENTITY, entity.getName(), system)) {
                callback.invoke(evt);
            }
        }
    }

    protected void fireFieldAdded(Field field, int position, EventPhase phase) {
        final Entity entity = field.getEntity();
        FieldEvent evt = new FieldEvent(field, field.getPersistenceUnit(), entity, field.getParent(), position, null, -1, phase);

        String entityTypeListenerId = getEntityTypeListenerId(entity.getEntityType());
        boolean system = entity.getUserModifiers().contains(EntityModifier.SYSTEM);
        if (phase == EventPhase.BEFORE) {
            for (FieldDefinitionListener listener : fields.getAllListeners(system, entity.getName(), entityTypeListenerId)) {
                listener.onPreCreateField(evt);
            }
            for (Callback callback : getPreCallbacks(CallbackType.ON_CREATE, ObjectType.FIELD, entity.getName(), system)) {
                callback.invoke(evt);
            }
            for (PreparedCallback callback : getPostPreparedCallbacks(CallbackType.ON_CREATE, ObjectType.FIELD, entity.getName(), system)) {
                callback.prepare(evt);
            }
        } else {
            for (FieldDefinitionListener listener : fields.getAllListeners(system, entity.getName(), entityTypeListenerId)) {
                listener.onCreateField(evt);
            }
            for (Callback callback : getPostCallbacks(CallbackType.ON_CREATE, ObjectType.FIELD, entity.getName(), system)) {
                callback.invoke(evt);
            }
        }
    }

    protected void fireOnCreateIndex(Index index, int position, EventPhase phase) {
        IndexEvent event = new IndexEvent(index, index.getPersistenceUnit(), phase);
        Entity entity = index.getEntity();
        String entityTypeListenerId = getEntityTypeListenerId(index.getEntity().getEntityType());
        boolean system = entity.getUserModifiers().contains(EntityModifier.SYSTEM);
        if (phase == EventPhase.BEFORE) {
            for (IndexDefinitionListener listener : indexes.getAllListeners(system, index.getEntity().getName(), entityTypeListenerId)) {
                listener.onPreCreateIndex(event);
            }
            for (Callback callback : getPreCallbacks(CallbackType.ON_CREATE, ObjectType.INDEX, entity.getName(), system)) {
                callback.invoke(event);
            }
            for (PreparedCallback callback : getPostPreparedCallbacks(CallbackType.ON_CREATE, ObjectType.INDEX, entity.getName(), system)) {
                callback.prepare(event);
            }
        } else {
            for (IndexDefinitionListener listener : indexes.getAllListeners(system, index.getEntity().getName(), entityTypeListenerId)) {
                listener.onCreateIndex(event);
            }
            for (Callback callback : getPostCallbacks(CallbackType.ON_CREATE, ObjectType.INDEX, entity.getName(), system)) {
                callback.invoke(event);
            }
        }
    }

    protected void fireOnCreateSection(Section section, int position, EventPhase phase) {
        Entity entity = section.getEntity();
        String entityName = section.getEntity().getName();
        String entityTypeId = getEntityTypeListenerId(section.getEntity().getEntityType());
        SectionEvent event = new SectionEvent(section, section.getPersistenceUnit(), entity, (Section) section.getParent(), position, null, -1, phase);
        boolean system = entity.getUserModifiers().contains(EntityModifier.SYSTEM);
        if (phase == EventPhase.BEFORE) {
            for (SectionDefinitionListener listener : sections.getAllListeners(system, entityName, entityTypeId)) {
                listener.onPreCreateSection(event);
            }
            for (Callback callback : getPreCallbacks(CallbackType.ON_CREATE, ObjectType.SECTION, entity.getName(), system)) {
                callback.invoke(event);
            }
            for (PreparedCallback callback : getPostPreparedCallbacks(CallbackType.ON_CREATE, ObjectType.SECTION, entity.getName(), system)) {
                callback.prepare(event);
            }
        } else {
            for (SectionDefinitionListener listener : sections.getAllListeners(system, entityName, entityTypeId)) {
                listener.onCreateSection(event);
            }
            for (Callback callback : getPostCallbacks(CallbackType.ON_CREATE, ObjectType.SECTION, entity.getName(), system)) {
                callback.invoke(event);
            }
        }
    }


    protected void fireOnCreatePackage(Package module, Package parent, int position, EventPhase phase) {
        PackageEvent evt = null;
        List<PackageDefinitionListener> interceptorList = packages;
        if (phase == EventPhase.BEFORE) {
            if (!interceptorList.isEmpty()) {
                evt = new PackageEvent(module, module.getPersistenceUnit(), parent, position, null, -1, phase);
                for (PackageDefinitionListener listener : interceptorList) {
                    listener.onPreCreatePackage(evt);
                }
            }
            List<Callback> callbackInvokers = getPreCallbacks(CallbackType.ON_CREATE, ObjectType.PACKAGE, persistenceUnit.getName(), DEFAULT_SYSTEM);
            if (!callbackInvokers.isEmpty()) {
                if (evt == null) {
                    evt = new PackageEvent(module, module.getPersistenceUnit(), parent, position, null, -1, phase);
                }
                for (Callback callback : callbackInvokers) {
                    callback.invoke(evt);
                }
            }
            for (PreparedCallback callback : getPostPreparedCallbacks(CallbackType.ON_CREATE, ObjectType.PACKAGE, persistenceUnit.getName(), DEFAULT_SYSTEM)) {
                if (evt == null) {
                    evt = new PackageEvent(module, module.getPersistenceUnit(), parent, position, null, -1, phase);
                }
                callback.prepare(evt);
            }

        } else {
            if (!interceptorList.isEmpty()) {
                evt = new PackageEvent(module, module.getPersistenceUnit(), parent, position, null, -1, phase);
                for (PackageDefinitionListener listener : interceptorList) {
                    listener.onCreatePackage(evt);
                }
            }
            List<Callback> callbackInvokers = getPostCallbacks(CallbackType.ON_CREATE, ObjectType.PACKAGE, persistenceUnit.getName(), DEFAULT_SYSTEM);
            if (!callbackInvokers.isEmpty()) {
                if (evt == null) {
                    evt = new PackageEvent(module, module.getPersistenceUnit(), parent, position, null, -1, phase);
                }
                for (Callback callback : callbackInvokers) {
                    callback.invoke(evt);
                }
            }
        }
    }

    protected void fireOnCreateRelationship(Relationship relation, int position, EventPhase phase) {
        if (phase == EventPhase.BEFORE) {
            RelationshipEvent evt = new RelationshipEvent(relation, relation.getPersistenceUnit(), phase);
            List<RelationshipDefinitionListener> interceptorList = getRelationshipListeners(relation.getSourceRole().getEntity().getName(), relation.getTargetRole().getEntity().getName());
            for (RelationshipDefinitionListener listener : interceptorList) {
                listener.onPreCreateRelationship(evt);
            }
            for (Callback callback : getPreCallbacks(CallbackType.ON_CREATE, ObjectType.RELATIONSHIP, relation.getSourceEntity().getName(), false)) {
                callback.invoke(evt);
            }
            for (PreparedCallback callback : getPostPreparedCallbacks(CallbackType.ON_CREATE, ObjectType.RELATIONSHIP, relation.getSourceEntity().getName(), false)) {
                callback.prepare(evt);
            }
        } else {
            RelationshipEvent evt = new RelationshipEvent(relation, relation.getPersistenceUnit(), phase);
            List<RelationshipDefinitionListener> interceptorList = getRelationshipListeners(relation.getSourceRole().getEntity().getName(), relation.getTargetRole().getEntity().getName());
            for (RelationshipDefinitionListener listener : interceptorList) {
                listener.onCreateRelationship(evt);
            }
            for (Callback callback : getPostCallbacks(CallbackType.ON_CREATE, ObjectType.RELATIONSHIP, relation.getSourceEntity().getName(), false)) {
                callback.invoke(evt);
            }
        }
    }

    protected void fireOnDropEntity(Entity entity, int position, EventPhase phase) {
        EntityEvent evt = new EntityEvent(entity, entity.getPersistenceUnit(), entity.getParent(), position, null, -1, phase);
        String entityTypeListenerId = getEntityTypeListenerId(entity.getEntityType());
        boolean system = entity.getUserModifiers().contains(EntityModifier.SYSTEM);
        if (phase == EventPhase.BEFORE) {
            for (EntityDefinitionListener listener : entities.getAllListeners(system, entity.getName(), entityTypeListenerId)) {
                listener.onPreDropEntity(evt);
            }
            for (Callback callback : getPreCallbacks(CallbackType.ON_DROP, ObjectType.ENTITY, entity.getName(), system)) {
                callback.invoke(evt);
            }
            for (PreparedCallback callback : getPostPreparedCallbacks(CallbackType.ON_DROP, ObjectType.ENTITY, entity.getName(), system)) {
                callback.prepare(evt);
            }
        } else {
            for (EntityDefinitionListener listener : entities.getAllListeners(system, entity.getName(), entityTypeListenerId)) {
                listener.onDropEntity(evt);
            }
            for (Callback callback : getPostCallbacks(CallbackType.ON_DROP, ObjectType.ENTITY, entity.getName(), system)) {
                callback.invoke(evt);
            }
        }
    }

    protected void fireFieldRemoved(Field field, int position, EventPhase phase) {
        final Entity entity = field.getEntity();
        FieldEvent evt = new FieldEvent(field, field.getPersistenceUnit(), entity, field.getParent(), position, null, -1, phase);
        String entityName = entity.getName();
        String entityTypeId = getEntityTypeListenerId(entity.getEntityType());
        boolean system = entity.getUserModifiers().contains(EntityModifier.SYSTEM);
        if (phase == EventPhase.BEFORE) {
            for (FieldDefinitionListener listener : fields.getAllListeners(system, entityName, entityTypeId)) {
                listener.onPreDropField(evt);
            }
            for (Callback callback : getPreCallbacks(CallbackType.ON_DROP, ObjectType.FIELD, entity.getName(), system)) {
                callback.invoke(evt);
            }
            for (PreparedCallback callback : getPostPreparedCallbacks(CallbackType.ON_DROP, ObjectType.FIELD, entity.getName(), system)) {
                callback.prepare(evt);
            }
        } else {
            for (FieldDefinitionListener listener : fields.getAllListeners(system, entityName, entityTypeId)) {
                listener.onDropField(evt);
            }
            for (Callback callback : getPostCallbacks(CallbackType.ON_DROP, ObjectType.FIELD, entity.getName(), system)) {
                callback.invoke(evt);
            }
        }
    }

    protected void fireOnDropIndex(Index index, int position, EventPhase phase) {
        IndexEvent evt = new IndexEvent(index, index.getPersistenceUnit(), phase);
        Entity entity = index.getEntity();
        String entityName = index.getEntity().getName();
        String entityTypeId = getEntityTypeListenerId(index.getEntity().getEntityType());
        boolean system = entity.getUserModifiers().contains(EntityModifier.SYSTEM);
        if (phase == EventPhase.BEFORE) {
            for (IndexDefinitionListener listener : indexes.getAllListeners(system, entityName, entityTypeId)) {
                listener.onPreDropIndex(evt);
            }
            for (Callback callback : getPreCallbacks(CallbackType.ON_DROP, ObjectType.INDEX, entity.getName(), system)) {
                callback.invoke(evt);
            }
            for (PreparedCallback callback : getPostPreparedCallbacks(CallbackType.ON_DROP, ObjectType.INDEX, entity.getName(), system)) {
                callback.prepare(evt);
            }
        } else {
            for (IndexDefinitionListener listener : indexes.getAllListeners(system, entityName, entityTypeId)) {
                listener.onDropIndex(evt);
            }
            for (Callback callback : getPostCallbacks(CallbackType.ON_DROP, ObjectType.INDEX, entity.getName(), system)) {
                callback.invoke(evt);
            }
        }
    }

    protected void fireOnDropSection(Section section, int position, EventPhase phase) {
        Entity entity = section.getEntity();
        SectionEvent evt = new SectionEvent(section, section.getPersistenceUnit(), entity, (Section) section.getParent(), position, null, -1, phase);
        String entityName = section.getEntity().getName();
        String entityTypeId = getEntityTypeListenerId(section.getEntity().getEntityType());
        boolean system = entity.getUserModifiers().contains(EntityModifier.SYSTEM);
        if (phase == EventPhase.BEFORE) {
            for (SectionDefinitionListener listener : sections.getAllListeners(system, entityName, entityTypeId)) {
                listener.onPreDropSection(evt);
            }
            for (Callback callback : getPreCallbacks(CallbackType.ON_DROP, ObjectType.SECTION, entity.getName(), system)) {
                callback.invoke(evt);
            }
            for (PreparedCallback callback : getPostPreparedCallbacks(CallbackType.ON_DROP, ObjectType.SECTION, entity.getName(), system)) {
                callback.prepare(evt);
            }
        } else {
            for (SectionDefinitionListener listener : sections.getAllListeners(system, entityName, entityTypeId)) {
                listener.onDropSection(evt);
            }
            for (Callback callback : getPostCallbacks(CallbackType.ON_DROP, ObjectType.SECTION, entity.getName(), system)) {
                callback.invoke(evt);
            }
        }
    }

    protected void fireOnDropPackage(Package module, int position, EventPhase phase) {
        PackageEvent evt = new PackageEvent(module, module.getPersistenceUnit(), module.getParent(), position, null, -1, phase);
        List<PackageDefinitionListener> interceptorList = packages;
        if (phase == EventPhase.BEFORE) {
            for (PackageDefinitionListener listener : interceptorList) {
                listener.onPreDropPackage(evt);
            }
            for (Callback callback : getPreCallbacks(CallbackType.ON_DROP, ObjectType.PACKAGE, module.getPersistenceUnit().getName(), DEFAULT_SYSTEM)) {
                callback.invoke(evt);
            }
            for (PreparedCallback callback : getPostPreparedCallbacks(CallbackType.ON_DROP, ObjectType.PACKAGE, module.getPersistenceUnit().getName(), DEFAULT_SYSTEM)) {
                callback.prepare(evt);
            }
        } else {
            for (PackageDefinitionListener listener : interceptorList) {
                listener.onDropPackage(evt);
            }
            for (Callback callback : getPostCallbacks(CallbackType.ON_DROP, ObjectType.PACKAGE, module.getPersistenceUnit().getName(), DEFAULT_SYSTEM)) {
                callback.invoke(evt);
            }
        }
    }

    protected void fireOnDropRelationship(Relationship relation, int position, EventPhase phase) {
        RelationshipEvent evt = new RelationshipEvent(relation, relation.getPersistenceUnit(), phase);
        if (phase == EventPhase.BEFORE) {
            for (RelationshipDefinitionListener listener : getRelationshipListeners(relation.getSourceRole().getEntity().getName(), relation.getTargetRole().getEntity().getName())) {
                listener.onPreDropRelationship(evt);
            }
            for (Callback callback : getPreCallbacks(CallbackType.ON_DROP, ObjectType.RELATIONSHIP, relation.getSourceRole().getEntity().getName(), relation.getSourceRole().getEntity().isSystem())) {
                callback.invoke(evt);
            }
            for (PreparedCallback callback : getPostPreparedCallbacks(CallbackType.ON_DROP, ObjectType.RELATIONSHIP, relation.getSourceRole().getEntity().getName(), relation.getSourceRole().getEntity().isSystem())) {
                callback.prepare(evt);
            }
        } else {
            for (RelationshipDefinitionListener listener : getRelationshipListeners(relation.getSourceRole().getEntity().getName(), relation.getTargetRole().getEntity().getName())) {
                listener.onDropRelationship(evt);
            }
            for (Callback callback : getPostCallbacks(CallbackType.ON_DROP, ObjectType.RELATIONSHIP, relation.getSourceRole().getEntity().getName(), relation.getSourceRole().getEntity().isSystem())) {
                callback.invoke(evt);
            }
        }
    }

    protected List<RelationshipDefinitionListener> getRelationshipListeners(String entityName1, String entityName2) {
        ArrayList<RelationshipDefinitionListener> all = new ArrayList<RelationshipDefinitionListener>();
        PlatformUtils.addAll(all, relationships.toArrayConstrainted(false, null, new RelationshipDefinitionListener[0]));
        if (entityName1 != null) {
            PlatformUtils.addAll(all, relationships.toArrayConstrainted(false, entityName1, new RelationshipDefinitionListener[0]));
        }
        if (entityName2 != null) {
            if (!entityName2.equals(entityName1)) {
                PlatformUtils.addAll(all, relationships.toArrayConstrainted(false, entityName2, new RelationshipDefinitionListener[0]));
            }
        }
        return all;
    }

    private String getEntityTypeListenerId(Class entityType) {
        return entityType == null ? null : "private:" + entityType.getName();
    }

    public void addDefinitionListener(Class entityType, DefinitionListener definitionListener, boolean trackSystem) {
        addDefinitionListener(getEntityTypeListenerId(entityType), definitionListener, trackSystem);
    }

    public void addDefinitionListener(String entityName, DefinitionListener definitionListener, boolean trackSystem) {
        boolean supported = false;
        if (definitionListener instanceof FieldDefinitionListener) {
            supported = true;
            fields.add(trackSystem, entityName, (FieldDefinitionListener) definitionListener);
        }
        if (definitionListener instanceof SectionDefinitionListener) {
            supported = true;
            sections.add(trackSystem, entityName, (SectionDefinitionListener) definitionListener);
        }
        if (definitionListener instanceof EntityDefinitionListener) {
            supported = true;
            entities.add(trackSystem, entityName, (EntityDefinitionListener) definitionListener);
        }
        if (definitionListener instanceof IndexDefinitionListener) {
            supported = true;
            indexes.add(trackSystem, entityName, (IndexDefinitionListener) definitionListener);
        }
        if (definitionListener instanceof RelationshipDefinitionListener) {
            supported = true;
            relationships.add(false, entityName, (RelationshipDefinitionListener) definitionListener);
        }
        if (definitionListener instanceof TriggerDefinitionListener) {
            supported = true;
            entityTriggers.add(trackSystem, entityName, (TriggerDefinitionListener) definitionListener);
        }
        if (definitionListener instanceof PackageDefinitionListener) {
            supported = true;
            packages.add((PackageDefinitionListener) definitionListener);
        }
        if (!supported) {
            throw new UPAIllegalArgumentException("Unsupported DefinitionListener. See Documentation for detailed information.");
        }
    }

    public void removeDefinitionListener(Class entityType, DefinitionListener definitionListener) {
        removeDefinitionListener(getEntityTypeListenerId(entityType), definitionListener);
    }

    public void removeDefinitionListener(String entityName, DefinitionListener definitionListener) {
        boolean supported = false;
        if (definitionListener instanceof FieldDefinitionListener) {
            supported = true;
            fields.remove(entityName, (FieldDefinitionListener) definitionListener);
        }
        if (definitionListener instanceof SectionDefinitionListener) {
            supported = true;
            sections.remove(entityName, (SectionDefinitionListener) definitionListener);
        }
        if (definitionListener instanceof EntityDefinitionListener) {
            supported = true;
            entities.remove(entityName, (EntityDefinitionListener) definitionListener);
        }
        if (definitionListener instanceof IndexDefinitionListener) {
            supported = true;
            indexes.remove(entityName, (IndexDefinitionListener) definitionListener);
        }
        if (definitionListener instanceof RelationshipDefinitionListener) {
            supported = true;
            relationships.remove(entityName, (RelationshipDefinitionListener) definitionListener);
        }
        if (definitionListener instanceof PackageDefinitionListener) {
            supported = true;
            packages.remove((PackageDefinitionListener) definitionListener);
        }
        if (!supported) {
            throw new UPAIllegalArgumentException("Unsupported DefinitionListener. See Documentation for detailed information.");
        }
    }

    public void addHandlers(UPAObject object) {
        object.addObjectListener(this);
    }

    protected void removeHandlers(UPAObject object) {
        object.removeObjectListener(this);
    }

    public void fireOnModelChanged(PersistenceUnitEvent event) {
        EventPhase phase = event.getPhase();
        if (phase == EventPhase.BEFORE) {
            for (PersistenceUnitListener listener : persistenceUnitListeners) {
                listener.onPreModelChanged(event);
            }
            for (Callback invoker : getPreCallbacks(CallbackType.ON_MODEL_CHANGED, ObjectType.PERSISTENCE_UNIT, event.getPersistenceUnit().getName(), DEFAULT_SYSTEM)) {
                invoker.invoke(event);
            }
            for (PreparedCallback callback : getPostPreparedCallbacks(CallbackType.ON_MODEL_CHANGED, ObjectType.PERSISTENCE_UNIT, event.getPersistenceUnit().getName(), DEFAULT_SYSTEM)) {
                callback.prepare(event);
            }
        } else {
            for (PersistenceUnitListener listener : persistenceUnitListeners) {
                listener.onModelChanged(event);
            }
            for (Callback invoker : getPostCallbacks(CallbackType.ON_MODEL_CHANGED, ObjectType.PERSISTENCE_UNIT, event.getPersistenceUnit().getName(), DEFAULT_SYSTEM)) {
                invoker.invoke(event);
            }
        }
    }

    public void fireOnStorageChanged(PersistenceUnitEvent event) {
        EventPhase phase = event.getPhase();
        if (phase == EventPhase.BEFORE) {
            for (PersistenceUnitListener listener : persistenceUnitListeners) {
                listener.onPreStorageChanged(event);
            }
            for (PreparedCallback callback : getPostPreparedCallbacks(CallbackType.ON_STORAGE_CHANGED, ObjectType.PERSISTENCE_UNIT, event.getPersistenceUnit().getName(), DEFAULT_SYSTEM)) {
                callback.prepare(event);
            }
        } else {
            for (PersistenceUnitListener listener : persistenceUnitListeners) {
                listener.onStorageChanged(event);
            }
            for (Callback invoker : getPostCallbacks(CallbackType.ON_STORAGE_CHANGED, ObjectType.PERSISTENCE_UNIT, event.getPersistenceUnit().getName(), DEFAULT_SYSTEM)) {
                invoker.invoke(event);
            }
        }
    }

    public void fireOnClear(PersistenceUnitEvent event) {
        EventPhase phase = event.getPhase();
        if (phase == EventPhase.BEFORE) {
            for (PersistenceUnitListener listener : persistenceUnitListeners) {
                listener.onPreClear(event);
            }
            for (Callback invoker : getPreCallbacks(CallbackType.ON_CLEAR, ObjectType.PERSISTENCE_UNIT, event.getPersistenceUnit().getName(), DEFAULT_SYSTEM)) {
                invoker.invoke(event);
            }
            for (PreparedCallback callback : getPostPreparedCallbacks(CallbackType.ON_CLEAR, ObjectType.PERSISTENCE_UNIT, event.getPersistenceUnit().getName(), DEFAULT_SYSTEM)) {
                callback.prepare(event);
            }
        } else {
            for (PersistenceUnitListener listener : persistenceUnitListeners) {
                listener.onClear(event);
            }
            for (Callback invoker : getPostCallbacks(CallbackType.ON_CLEAR, ObjectType.PERSISTENCE_UNIT, event.getPersistenceUnit().getName(), DEFAULT_SYSTEM)) {
                invoker.invoke(event);
            }
        }
    }

    public void fireOnClose(PersistenceUnitEvent event) {
        EventPhase phase = event.getPhase();
        if (phase == EventPhase.BEFORE) {
            for (PersistenceUnitListener listener : persistenceUnitListeners) {
                listener.onPreClose(event);
            }
            for (Callback invoker : getPreCallbacks(CallbackType.ON_CLOSE, ObjectType.PERSISTENCE_UNIT, event.getPersistenceUnit().getName(), DEFAULT_SYSTEM)) {
                invoker.invoke(event);
            }
            for (PreparedCallback callback : getPostPreparedCallbacks(CallbackType.ON_CLOSE, ObjectType.PERSISTENCE_UNIT, event.getPersistenceUnit().getName(), DEFAULT_SYSTEM)) {
                callback.prepare(event);
            }
        } else {
            for (PersistenceUnitListener listener : persistenceUnitListeners) {
                listener.onClose(event);
            }
            for (Callback invoker : getPostCallbacks(CallbackType.ON_CLOSE, ObjectType.PERSISTENCE_UNIT, event.getPersistenceUnit().getName(), DEFAULT_SYSTEM)) {
                invoker.invoke(event);
            }
        }
    }

    public void fireOnReset(PersistenceUnitEvent event) {
        EventPhase phase = event.getPhase();
        if (phase == EventPhase.BEFORE) {
            for (PersistenceUnitListener listener : persistenceUnitListeners) {
                listener.onPreReset(event);
            }
            for (Callback invoker : getPreCallbacks(CallbackType.ON_RESET, ObjectType.PERSISTENCE_UNIT, event.getPersistenceUnit().getName(), DEFAULT_SYSTEM)) {
                invoker.invoke(event);
            }
            for (PreparedCallback callback : getPostPreparedCallbacks(CallbackType.ON_RESET, ObjectType.PERSISTENCE_UNIT, event.getPersistenceUnit().getName(), DEFAULT_SYSTEM)) {
                callback.prepare(event);
            }
        } else {
            for (PersistenceUnitListener listener : persistenceUnitListeners) {
                listener.onReset(event);
            }
            for (Callback invoker : getPostCallbacks(CallbackType.ON_RESET, ObjectType.PERSISTENCE_UNIT, event.getPersistenceUnit().getName(), DEFAULT_SYSTEM)) {
                invoker.invoke(event);
            }
        }
    }

    public void fireOnStart(PersistenceUnitEvent event) {
        EventPhase phase = event.getPhase();
        if (phase == EventPhase.BEFORE) {
            for (PersistenceUnitListener listener : persistenceUnitListeners) {
                listener.onPreStart(event);
            }
            for (Callback callback : getPreCallbacks(CallbackType.ON_START, ObjectType.PERSISTENCE_UNIT, event.getPersistenceUnit().getName(), DEFAULT_SYSTEM)) {
                callback.invoke(event);
            }
            for (PreparedCallback callback : getPostPreparedCallbacks(CallbackType.ON_START, ObjectType.PERSISTENCE_UNIT, event.getPersistenceUnit().getName(), DEFAULT_SYSTEM)) {
                callback.prepare(event);
            }
        } else {
            for (PersistenceUnitListener listener : persistenceUnitListeners) {
                listener.onStart(event);
            }
            for (Callback invoker : getPostCallbacks(CallbackType.ON_START, ObjectType.PERSISTENCE_UNIT, event.getPersistenceUnit().getName(), DEFAULT_SYSTEM)) {
                invoker.invoke(event);
            }
        }
    }

    public CallbackManager getCallbackManager() {
        return callbackManager;
    }

    public void addCallback(Callback callback) {
        callbackManager.addCallback(callback);
    }

    public void removeCallback(Callback callback) {
        callbackManager.removeCallback(callback);
    }

    public List<Callback> getPreCallbacks(CallbackType callbackType, ObjectType objectType, String nameFilter, boolean system) {
        List<Callback> allCallbacks = callbackManager.getCallbacks(callbackType, objectType, nameFilter, system, false, EventPhase.BEFORE);
        allCallbacks.addAll(Arrays.asList(persistenceUnit.getPersistenceGroup().getCallbacks(callbackType, objectType, nameFilter, system, false, EventPhase.BEFORE)));
        allCallbacks.addAll(Arrays.asList(persistenceUnit.getPersistenceGroup().getContext().getCallbacks(callbackType, objectType, nameFilter, system, false, EventPhase.BEFORE)));
        return allCallbacks;
    }

    public List<Callback> getPostCallbacks(CallbackType callbackType, ObjectType objectType, String nameFilter, boolean system) {
        List<Callback> allCallbacks = callbackManager.getCallbacks(callbackType, objectType, nameFilter, system, false, EventPhase.AFTER);
        allCallbacks.addAll(Arrays.asList(persistenceUnit.getPersistenceGroup().getCallbacks(callbackType, objectType, nameFilter, system, false, EventPhase.AFTER)));
        allCallbacks.addAll(Arrays.asList(persistenceUnit.getPersistenceGroup().getContext().getCallbacks(callbackType, objectType, nameFilter, system, false, EventPhase.AFTER)));
        return allCallbacks;
    }

    public List<PreparedCallback> getPostPreparedCallbacks(CallbackType callbackType, ObjectType objectType, String nameFilter, boolean system) {
        List<PreparedCallback> callbacks = new ArrayList<PreparedCallback>();
        for (Callback callback : callbackManager.getCallbacks(callbackType, objectType, nameFilter, system, true, EventPhase.AFTER)) {
            callbacks.add((PreparedCallback) callback);
        }
        for (Callback callback : persistenceUnit.getPersistenceGroup().getCallbacks(callbackType, objectType, nameFilter, system, false, EventPhase.AFTER)) {
            callbacks.add((PreparedCallback) callback);
        }
        for (Callback callback : persistenceUnit.getPersistenceGroup().getContext().getCallbacks(callbackType, objectType, nameFilter, system, false, EventPhase.AFTER)) {
            callbacks.add((PreparedCallback) callback);
        }
        return callbacks;
    }

    public Callback[] getCurrentCallbacks(CallbackType callbackType, ObjectType objectType, String nameFilter, boolean system, boolean preparedOnly, EventPhase phase) {
        List<Callback> callbacks = callbackManager.getCallbacks(callbackType, objectType, nameFilter, system, preparedOnly, phase);
        return callbacks.toArray(new Callback[callbacks.size()]);
    }

    public void fireOnUpdateFormulas(PersistenceUnitEvent event) {
        EventPhase phase = event.getPhase();
        if (phase == EventPhase.BEFORE) {
            for (PersistenceUnitListener listener : persistenceUnitListeners) {
                listener.onPreUpdateFormulas(event);
            }
            for (Callback callback : getPreCallbacks(CallbackType.ON_UPDATE_FORMULAS, ObjectType.PERSISTENCE_UNIT, event.getPersistenceUnit().getName(), DEFAULT_SYSTEM)) {
                callback.invoke(event);
            }
            for (PreparedCallback callback : getPostPreparedCallbacks(CallbackType.ON_UPDATE_FORMULAS, ObjectType.PERSISTENCE_UNIT, event.getPersistenceUnit().getName(), DEFAULT_SYSTEM)) {
                callback.invoke(event);
            }
        } else {
            for (PersistenceUnitListener listener : persistenceUnitListeners) {
                listener.onUpdateFormulas(event);
            }
            for (Callback invoker : getPostCallbacks(CallbackType.ON_UPDATE_FORMULAS, ObjectType.PERSISTENCE_UNIT, event.getPersistenceUnit().getName(), DEFAULT_SYSTEM)) {
                invoker.invoke(event);
            }
        }
    }

}
