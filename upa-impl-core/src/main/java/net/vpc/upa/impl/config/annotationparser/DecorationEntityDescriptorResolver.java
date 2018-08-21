package net.vpc.upa.impl.config.annotationparser;

import net.vpc.upa.*;
import net.vpc.upa.Property;
import net.vpc.upa.config.*;
import net.vpc.upa.config.Entity;
import net.vpc.upa.config.Properties;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.exceptions.IllegalUPAArgumentException;
import net.vpc.upa.extensions.*;
import net.vpc.upa.impl.config.decorations.DecorationPrimitiveValue;
import net.vpc.upa.impl.config.decorations.DecorationRepository;
import net.vpc.upa.impl.util.CompareUtils;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.impl.util.UPAUtils;

import java.beans.Transient;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.logging.Logger;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 11/15/12 12:03 PM
 */
public class DecorationEntityDescriptorResolver {

    protected static Logger log = Logger.getLogger(DecorationEntityDescriptorResolver.class.getName());
    private DecorationRepository repo;
    private ObjectFactory factory;

    public DecorationEntityDescriptorResolver(DecorationRepository decorationRepository, ObjectFactory factory) {
        this.repo = decorationRepository;
        this.factory = factory;
    }

    public EntityDescriptor resolve(Class[] classes) throws UPAException {
        if (classes.length == 0) {
            throw new IllegalUPAArgumentException("Empty Class Array");
        } else {
            if (classes.length > 1) {
                CompareUtils.sort(classes, new ClassIndexedComparator(repo));
            }

            DecorationEntityDescriptor entityInfo = new DecorationEntityDescriptor(repo, factory);

            entityInfo.source = classes;
            List<Property> parameterInfos = new ArrayList<Property>();
            for (Class descriptorType : classes) {
                Decoration ue = (Decoration) repo.getTypeDecoration(descriptorType, Entity.class);
                int configOrder = 0;
                boolean isEntityClass = true;
                if (ue != null) {
                    configOrder = ue.getConfig().getOrder();
                    isEntityClass = ue.getType("entityType").equals(void.class);
                }

                if (!isEntityClass) {
                    //ue.entityType() is never null
                    entityInfo.entityType.setBetterValue(ue.getType("entityType"), configOrder);
                    if (entityInfo.entityType.specified && !Document.class.equals(entityInfo.entityType.value)) {
                        parseEntityType(entityInfo, entityInfo.entityType.value, ue.getBoolean("useEntityTypeFields"), ue.getBoolean("useEntityTypeModifiers"), ue.getBoolean("useEntityTypeExtensions"), factory);
                    }
                    parseEntityType(entityInfo, descriptorType, true, true, true, factory);
                } else {
                    entityInfo.entityType.setBetterValue(descriptorType, configOrder);
                    parseEntityType(entityInfo, descriptorType, true, true, true, factory);
                }

                for (Decoration decoration : repo.getTypeRepeatableDecorations(descriptorType, net.vpc.upa.config.Property.class, Properties.class)) {
                    parameterInfos.add(UPAUtils.createProperty(decoration));
                }
                Decoration pathDeco = repo.getTypeDecoration(descriptorType, net.vpc.upa.config.Path.class);
                if (pathDeco != null) {
                    AnnotationParserUtils.validStr(pathDeco.getString("value"), entityInfo.path, pathDeco.getConfig().getOrder());
                }

            }
            entityInfo.name=UPAUtils.resolveEntityNameAndType(classes[0], repo).getName();
            for (Property parameterInfo : parameterInfos) {
                entityInfo.getProperties().put(parameterInfo.getName(), UPAUtils.createValue(parameterInfo));
            }
            return build(entityInfo);

        }
    }

    private EntityDescriptor build(DecorationEntityDescriptor entityInfo) throws UPAException {
        try {

            HashMap<String, Object> ctx = new HashMap<String, Object>();
            for (DecorationFieldDescriptor fieldInfo : new ArrayList<DecorationFieldDescriptor>(entityInfo.fieldsMap.values())) {
                if (fieldInfo.valid) {
                    try {
                        fieldInfo.prepare(ctx, entityInfo.name);
                    } catch (UPAException ex) {
                        throw new IllegalUPAArgumentException("UnableToPrepareField " + fieldInfo.getEntityInfo().getName() + "." + fieldInfo.getName(), ex);
                    }
                }
            }
            //build after all fields has been prepared
            for (DecorationFieldDescriptor fieldInfo : new ArrayList<DecorationFieldDescriptor>(entityInfo.fieldsMap.values())) {
                if (fieldInfo.valid) {
                    try {
                        fieldInfo.build(ctx, entityInfo.name);
                    } catch (UPAException ex) {
                        throw new IllegalUPAArgumentException("UnableToBuildField " + fieldInfo.getEntityInfo().getName() + "." + fieldInfo.getName(), ex);
                    }
                }
            }
            //remove invalid
            for (DecorationFieldDescriptor fieldInfo : new ArrayList<DecorationFieldDescriptor>(entityInfo.fieldsMap.values())) {
                if (!fieldInfo.valid) {
                    entityInfo.fieldsMap.remove(fieldInfo.name);
                }
            }
            //handle cross dependencies
            if (entityInfo.idType == null) {
                DecorationFieldDescriptor pk = null;
                int pkCount = 0;
                for (DecorationFieldDescriptor fieldInfo : entityInfo.fieldsMap.values()) {
                    if (fieldInfo.modifiers.contains(UserFieldModifier.ID)) {
                        if (pk == null) {
                            pk = fieldInfo;
                        }
                        pkCount++;
                    }
                }
                if (pkCount == 1) {
                    entityInfo.idType = pk.dataType.getPlatformType();
                } else {
                    entityInfo.idType = Key.class;
                }
            }
            entityInfo.fieldsList = new ArrayList<DecorationFieldDescriptor>();
            for (DecorationFieldDescriptor allField : entityInfo.fieldsMap.values()) {
                entityInfo.fieldsList.add(allField);
            }
//            SequenceInfo generatedId = entityInfo.generatedIdInfo;
//            if (generatedId != null) {
//                entityInfo.generatedId = new Sequence(
//                        (generatedId.strategy == null || generatedId.strategy == SequenceStrategy.UNSPECIFIED) ? SequenceStrategy.AUTO : generatedId.strategy,
//                        generatedId.initialValue == null ? 1 : generatedId.initialValue,
//                        generatedId.allocationSize == null ? 50 : generatedId.allocationSize,
//                        generatedId.name,
//                        generatedId.format);
//            }
            return entityInfo;
        } catch (Exception e) {
            throw new IllegalUPAArgumentException("UnableToBuildEntity " + entityInfo.getName(), e);
        }
    }

    //    private void parseInstance(PrivateInfo entityInfo, EntityDescriptor edesc) {
//        entityInfo.idType = validClass(edesc.getIdType(), entityInfo.idType, Object.class);
//        entityInfo.entityType = validClass(edesc.getEntityType(), entityInfo.entityType, Object.class);
//        entityInfo.name = validStr(edesc.getName(), entityInfo.name);
//        entityInfo.shortName = validStr(edesc.getShortName(), entityInfo.shortName);
//        Map<Class<? extends EntityExtension>, List<EntityExtension>> ss = edesc.getEntityExtensions();
//        if (ss != null) {
//            for (Map.Entry<Class<? extends EntityExtension>, List<EntityExtension>> ee : ss.entrySet()) {
//                for (EntityExtension es : ee.getValue()) {
//                    entityInfo.specs.add(ee.getKey(), es);
//                }
//            }
//        }
//    }
    void parseEntityType(DecorationEntityDescriptor entityInfo, Class type, boolean parseFields, boolean parseModifiers, boolean parseExtensions, ObjectFactory factory) {
        Decoration ue = repo.getTypeDecoration(type, Entity.class);
        entityInfo.idType = AnnotationParserUtils.validClass(ue == null ? null : ue.getType("idType"), entityInfo.idType, Object.class);
        if (ue != null && !ue.getType("entityType").equals(void.class)) {
            entityInfo.entityType.setBetterValue(ue.getType("entityType"), ue.getConfig().getOrder());
        }
        entityInfo.name = AnnotationParserUtils.validStr(AnnotationParserUtils.validStr(ue == null ? null : ue.getString("name"), entityInfo.name), type.getSimpleName());
        entityInfo.shortName = AnnotationParserUtils.validStr(ue == null ? null : ue.getString("shortName"), entityInfo.shortName);
        if (parseModifiers && ue != null) {
            ArrayList<EntityModifier> all = new ArrayList<EntityModifier>();
            for (DecorationValue v : ue.getArray("modifiers")) {
                DecorationPrimitiveValue pv = (DecorationPrimitiveValue) v;
                all.add(PlatformUtils.convert(pv.getValue(), EntityModifier.class));
            }
            entityInfo.addModifiers(all);

            all = new ArrayList<EntityModifier>();
            for (DecorationValue v : ue.getArray("excludeModifiers")) {
                DecorationPrimitiveValue pv = (DecorationPrimitiveValue) v;
                all.add(PlatformUtils.convert(pv.getValue(), EntityModifier.class));
            }
            entityInfo.addExcludeModifiers(all);
        }

        if (ue != null && ue.getString("path") != null && ue.getString("path").length() > 0) {
            entityInfo.path.setBetterValue(ue.getString("path"), ue.getConfig().getOrder());
        }
        if (ue != null && ue.getString("listOrder") != null && ue.getString("listOrder").length() > 0) {
            entityInfo.listOrder.setBetterValue(ue.getString("listOrder"), ue.getConfig().getOrder());
        }
        if (ue != null && ue.getString("archivingOrder") != null && ue.getString("archivingOrder").length() > 0) {
            entityInfo.archivingOrder.setBetterValue(ue.getString("archivingOrder"), ue.getConfig().getOrder());
        }

        Decoration path = repo.getTypeDecoration(type, Path.class);
        if (path != null) {
            if (path.getString("value").length() > 0) {
                entityInfo.path.setBetterValue(path.getString("value"), path.getConfig().getOrder());
            }
            if (path.getInt("position") != Integer.MIN_VALUE) {
                entityInfo.pathPosition.setBetterValue(path.getInt("position"), path.getConfig().getOrder());
            }
        }

        for (Decoration indexAnn : repo.getTypeRepeatableDecorations(type, net.vpc.upa.config.Index.class, net.vpc.upa.config.Indexes.class)) {
            //net.vpc.upa.config.Index 
            List<String> rr = new ArrayList<String>();
            rr.addAll(Arrays.asList(indexAnn.getPrimitiveArray("fields", String.class)));
            entityInfo.addIndex(indexAnn.getString("name"), rr, indexAnn.getBoolean("unique"), indexAnn.getConfig().getOrder());
        }

        //        net.vpc.upa.config.Sequence gue = (net.vpc.upa.config.Sequence) dataType.getAnnotation(Sequence.class);
//        if (gue != null) {
//            if (privateInfo.generatedIdInfo == null) {
//                privateInfo.generatedIdInfo = new SequenceInfo();
//            }
//            privateInfo.generatedIdInfo.merge(gue);
//        }
        if (parseFields) {
            List<DecorationFieldDescriptor> fieldInfos = new ArrayList<DecorationFieldDescriptor>();
            if (!Document.class.isAssignableFrom(type)) {
                Class c = type;
                while (c != null) {
                    List<DecorationFieldDescriptor> cfields = new ArrayList<DecorationFieldDescriptor>();
                    for (java.lang.reflect.Field field : c.getDeclaredFields()) {
                        if (acceptField(field)) {
                            String fieldName = getFieldName(field);

                            Decoration ignored = repo.getFieldDecoration(field, Ignore.class);
                            if (ignored != null) {
                                DecorationFieldDescriptor oldValue = entityInfo.fieldsMap.get(fieldName);
                                if (oldValue != null) {
                                    oldValue.valid = false;
                                }
                            } else {
                                DecorationFieldDescriptor oldValue = entityInfo.fieldsMap.get(fieldName);
                                if (oldValue == null) {
                                    oldValue = new DecorationFieldDescriptor(fieldName, entityInfo, repo);
                                    cfields.add(oldValue);
                                }
                                oldValue.registerField(field);
                            }
                        }
                    }
                    fieldInfos.addAll(0, cfields);
                    c = c.getSuperclass();
                }
            }

            for (DecorationFieldDescriptor fieldInfo : fieldInfos) {
                String name = fieldInfo.name;
                DecorationFieldDescriptor old = entityInfo.fieldsMap.get(name);
                if (old != null) {
                    throw new IllegalUPAArgumentException("Should never happen");
                }
                entityInfo.fieldsMap.put(name, fieldInfo);
            }
        }

        if (parseExtensions) {

            Decoration unionEntity = repo.getTypeDecoration(type, UnionEntity.class);
            if (unionEntity != null) {
                if (unionEntity.getType("spec").equals(UnionEntityExtensionDefinition.class)) {
                    String discriminator = unionEntity.getString("discriminator");
//                    String[] fields = unionEntity.fields();
//                    UnionEntityEntry[] entities = unionEntity.entities();
                    DecorationValue[] entities = unionEntity.getArray("entities");

                    List<String> _entities = new ArrayList<String>();
                    List<String> _fields = new ArrayList<String>();
                    _fields.addAll(Arrays.asList(unionEntity.getPrimitiveArray("fields", String.class)));
                    String _entityFieldName = discriminator;
                    String[][] _mapping = new String[entities.length][_fields.size()];

                    int ientity = 0;
                    for (DecorationValue entity0 : entities) {
                        Decoration entity = (Decoration) entity0;//UnionEntityEntry
                        _entities.add(entity.getString("entity"));
                        int ifield = 0;
                        for (String field : _fields) {
                            String f = null;
                            String[] efields = entity.getPrimitiveArray("fields", String.class);
                            if (ifield < efields.length) {
                                f = efields[ifield];
                            }
                            if (f == null) {
                                f = field;
                            }
                            _mapping[ientity][ifield] = f;
                            ifield++;
                        }
                        ientity++;
                    }

                    entityInfo.specs.add(new DefaultUnionEntityExtensionDefinition(new UnionQueryInfo(_entities, _fields, _entityFieldName, _mapping)));
                } else {
                    entityInfo.specs.add((EntityExtensionDefinition) factory.createObject(unionEntity.getType("spec")));
                }
            }

            Decoration view = (Decoration) repo.getTypeDecoration(type, View.class);
            if (view != null) {
                Class<ViewEntityExtensionDefinition> spec = view.getType("spec");
                if (spec.equals(ViewEntityExtensionDefinition.class)) {
                    String query = view.getString("query");
                    entityInfo.specs.add(new SimpleViewEntityExtensionDefinition(query));
                } else {
                    entityInfo.specs.add(factory.createObject(spec));
                }
            }
        }
    }

    public String getFieldName(java.lang.reflect.Field javaField) {
        String name = null;
        if (acceptField(javaField)) {
            Decoration anno = repo.getFieldDecoration(javaField, net.vpc.upa.config.Field.class);
            if (anno != null) {
                name = anno.getString("name");
            }
            if (name == null || name.length() == 0) {
                name = javaField.getName();
            }
        }
        return name;
    }

    public boolean acceptField(java.lang.reflect.Field field) {
        if (field.getType().equals(FieldDesc.class)) {
            return true;
        }
        return !PlatformUtils.isStatic(field)
                && !PlatformUtils.isTransient(field)
                && repo.getFieldDecoration(field, Transient.class) == null;
    }


}
