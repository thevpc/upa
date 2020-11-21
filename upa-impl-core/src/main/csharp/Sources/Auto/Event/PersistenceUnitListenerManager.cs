/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE AS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



using System.Linq;
namespace Net.TheVpc.Upa.Impl.Event
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/27/12 9:07 PM
     */
    public class PersistenceUnitListenerManager : Net.TheVpc.Upa.UPAObjectListener {

        private static readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.TheVpc.Upa.Impl.Event.PersistenceUnitListenerManager)).FullName);

        public Net.TheVpc.Upa.Impl.Event.ListenerSupport<Net.TheVpc.Upa.Callbacks.FieldDefinitionListener> fields = new Net.TheVpc.Upa.Impl.Event.ListenerSupport<Net.TheVpc.Upa.Callbacks.FieldDefinitionListener>();

        public Net.TheVpc.Upa.Impl.Event.ListenerSupport<Net.TheVpc.Upa.Callbacks.SectionDefinitionListener> sections = new Net.TheVpc.Upa.Impl.Event.ListenerSupport<Net.TheVpc.Upa.Callbacks.SectionDefinitionListener>();

        public Net.TheVpc.Upa.Impl.Event.ListenerSupport<Net.TheVpc.Upa.Callbacks.EntityDefinitionListener> entities = new Net.TheVpc.Upa.Impl.Event.ListenerSupport<Net.TheVpc.Upa.Callbacks.EntityDefinitionListener>();

        public Net.TheVpc.Upa.Impl.Event.ListenerSupport<Net.TheVpc.Upa.Callbacks.IndexDefinitionListener> indexes = new Net.TheVpc.Upa.Impl.Event.ListenerSupport<Net.TheVpc.Upa.Callbacks.IndexDefinitionListener>();

        public Net.TheVpc.Upa.Impl.Event.ListenerSupport<Net.TheVpc.Upa.Callbacks.RelationshipDefinitionListener> relationships = new Net.TheVpc.Upa.Impl.Event.ListenerSupport<Net.TheVpc.Upa.Callbacks.RelationshipDefinitionListener>();

        public Net.TheVpc.Upa.Impl.Event.ListenerSupport<Net.TheVpc.Upa.Callbacks.TriggerDefinitionListener> entityTriggers = new Net.TheVpc.Upa.Impl.Event.ListenerSupport<Net.TheVpc.Upa.Callbacks.TriggerDefinitionListener>();

        public System.Collections.Generic.IList<Net.TheVpc.Upa.Callbacks.PackageDefinitionListener> packages = new System.Collections.Generic.List<Net.TheVpc.Upa.Callbacks.PackageDefinitionListener>();

        public readonly System.Collections.Generic.IList<Net.TheVpc.Upa.Callbacks.PersistenceUnitListener> persistenceUnitListeners = new System.Collections.Generic.List<Net.TheVpc.Upa.Callbacks.PersistenceUnitListener>();

        private Net.TheVpc.Upa.Impl.ObjectRegistrationModel model;

        private Net.TheVpc.Upa.Impl.Config.Decorations.DecorationRepository decorationRepository;

        private Net.TheVpc.Upa.PersistenceUnit persistenceUnit;

        private Net.TheVpc.Upa.Impl.Util.CallbackManager callbackManager = new Net.TheVpc.Upa.Impl.Util.CallbackManager();

        public static bool DEFAULT_SYSTEM = false;

        public PersistenceUnitListenerManager(Net.TheVpc.Upa.PersistenceUnit persistenceUnit, Net.TheVpc.Upa.Impl.ObjectRegistrationModel model, Net.TheVpc.Upa.Impl.Config.Decorations.DecorationRepository decorationRepository) {
            this.persistenceUnit = persistenceUnit;
            this.model = model;
            this.decorationRepository = decorationRepository;
        }

        public virtual void ItemAdded(Net.TheVpc.Upa.UPAObject @object, int position, Net.TheVpc.Upa.UPAObject parent, Net.TheVpc.Upa.EventPhase phase) {
            if (@object is Net.TheVpc.Upa.Entity) {
                Net.TheVpc.Upa.Entity entity = (Net.TheVpc.Upa.Entity) @object;
                Net.TheVpc.Upa.Package parentModule = (Net.TheVpc.Upa.Package) parent;
                if (phase == Net.TheVpc.Upa.EventPhase.BEFORE) {
                    if (model.ContainsEntity(entity, parentModule)) {
                        Net.TheVpc.Upa.Entity registered = model.GetEntity(entity.GetName());
                        object s1 = entity.GetEntityDescriptor().GetSource();
                        if (s1 != null && s1 is object[]) {
                            s1 = System.Convert.ToString((object[]) s1);
                        }
                        object s2 = registered.GetEntityDescriptor().GetSource();
                        if (s2 != null && s2 is object[]) {
                            s2 = System.Convert.ToString((object[]) s2);
                        }
                        throw new Net.TheVpc.Upa.Exceptions.EntityAlreadyExistsException(entity.GetName(), s1, s2);
                    }
                    AddHandlers(@object);
                    FireOnCreateEntity(entity, position, phase);
                } else {
                    model.RegisterEntity(entity, parentModule);
                    FireOnCreateEntity(entity, position, phase);
                    Net.TheVpc.Upa.EntityDescriptor entityInfo = entity.GetEntityDescriptor();
                    string orderByString = entityInfo.GetListOrder();
                    if (!Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(orderByString)) {
                        Net.TheVpc.Upa.Expressions.Select s = (Net.TheVpc.Upa.Expressions.Select) persistenceUnit.GetExpressionManager().ParseExpression("Select a from " + entity.GetName() + " order by " + orderByString);
                        entity.SetListOrder(s.GetOrder());
                    }
                    orderByString = entityInfo.GetArchivingOrder();
                    if (!Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(orderByString)) {
                        Net.TheVpc.Upa.Expressions.Select s = (Net.TheVpc.Upa.Expressions.Select) persistenceUnit.GetExpressionManager().ParseExpression("Select a from " + entity.GetName() + " order by " + orderByString);
                        entity.SetArchivingOrder(s.GetOrder());
                    }
                    System.Collections.Generic.IList<Net.TheVpc.Upa.FieldDescriptor> fieldDescriptors = entityInfo.GetFieldDescriptors();
                    if (fieldDescriptors != null) {
                        foreach (Net.TheVpc.Upa.FieldDescriptor field in fieldDescriptors) {
                            entity.AddField(field);
                        }
                    }
                    System.Collections.Generic.IList<Net.TheVpc.Upa.IndexDescriptor> indexDescriptors = entityInfo.GetIndexDescriptors();
                    if (indexDescriptors != null) {
                        foreach (Net.TheVpc.Upa.IndexDescriptor index in indexDescriptors) {
                            entity.AddIndex(index.GetName(), index.IsUnique(), index.GetFieldNames());
                        }
                    }
                    System.Collections.Generic.IList<Net.TheVpc.Upa.RelationshipDescriptor> relationshipDescriptors = entityInfo.GetRelationshipDescriptors();
                    if (relationshipDescriptors != null) {
                        foreach (Net.TheVpc.Upa.RelationshipDescriptor relationDescriptor in relationshipDescriptors) {
                            entity.GetPersistenceUnit().AddRelationship(relationDescriptor);
                        }
                    }
                    FireOnInitEntity(entity, position, Net.TheVpc.Upa.EventPhase.BEFORE);
                    //some fields may be added as ManyToOne without explicit definition of RelationshipDescriptor
                    // must process them accordingly
                    //will first retrieve ManyToOne fields than will add relations for
                    //ones without relation!
                    System.Collections.Generic.HashSet<string> initialManyToOneFields = new System.Collections.Generic.HashSet<string>();
                    System.Collections.Generic.IList<Net.TheVpc.Upa.Relationship> existing = entity.GetPersistenceUnit().GetRelationshipsBySource(entity);
                    foreach (Net.TheVpc.Upa.Relationship relationship in existing) {
                        if (relationship.GetSourceRole().GetEntityField() != null) {
                            initialManyToOneFields.Add(relationship.GetSourceRole().GetEntityField().GetName());
                        }
                    }
                    foreach (Net.TheVpc.Upa.Callbacks.PersistenceUnitListener persistenceUnitListener in entity.GetPersistenceUnit().GetPersistenceUnitListeners()) {
                        if (persistenceUnitListener is Net.TheVpc.Upa.Impl.Config.Annotationparser.RelationshipDescriptorProcessor) {
                            Net.TheVpc.Upa.Impl.Config.Annotationparser.RelationshipDescriptorProcessor r = (Net.TheVpc.Upa.Impl.Config.Annotationparser.RelationshipDescriptorProcessor) persistenceUnitListener;
                            Net.TheVpc.Upa.RelationshipDescriptor d = r.GetRelationDescriptor();
                            if (d.GetSourceEntity() != null) {
                                if (d.GetSourceEntity().Equals(entity.GetName())) {
                                    if (d.GetBaseField() != null) {
                                        initialManyToOneFields.Add(d.GetBaseField());
                                    }
                                }
                            } else if (d.GetSourceEntityType().Equals(entity.GetEntityType())) {
                                if (d.GetBaseField() != null) {
                                    initialManyToOneFields.Add(d.GetBaseField());
                                }
                            }
                        }
                    }
                    foreach (Net.TheVpc.Upa.Field field in entity.GetFields()) {
                        Net.TheVpc.Upa.Types.DataType dt = field.GetDataType();
                        //check if relationship not already defined
                        if (dt is Net.TheVpc.Upa.Types.ManyToOneType && ((Net.TheVpc.Upa.Types.ManyToOneType) dt).GetRelationship() == null) {
                            if (!initialManyToOneFields.Contains(field.GetName())) {
                                //no relationship defined!
                                entity.GetPersistenceUnit().AddRelationship(new Net.TheVpc.Upa.DefaultRelationshipDescriptor().SetBaseField(field.GetName()).SetNullable(dt.IsNullable()).SetSourceEntity(entity.GetName()).SetSourceEntityType(entity.GetEntityType()).SetTargetEntity(((Net.TheVpc.Upa.Types.ManyToOneType) dt).GetTargetEntityName()).SetTargetEntityType(((Net.TheVpc.Upa.Types.ManyToOneType) dt).GetPlatformType()).SetSourceFields(new string[] { field.GetName() }));
                            }
                        }
                    }
                    if (entityInfo.GetSource() != null && entityInfo.GetSource() != entityInfo) {
                        System.Type c = entityInfo.GetSource().GetType();
                        System.Collections.Generic.IList<System.Reflection.MethodInfo> methods = new System.Collections.Generic.List<System.Reflection.MethodInfo>();
                        while (c != null) {
                            foreach (System.Reflection.MethodInfo m in c.GetMethods(System.Reflection.BindingFlags.Default)) {
                                if (decorationRepository.GetMethodDecoration(m, typeof(Net.TheVpc.Upa.Config.Init)) != null || decorationRepository.GetMethodDecoration(m, "javax.annotation.PostConstruct") != null) {
                                    //m.SetAccessible(true);
                                    methods.Add(m);
                                }
                            }
                            c = (c).BaseType;
                        }
                        //reverse execution (must call super attach before instance attach
                        methods.Reverse();
                        foreach (System.Reflection.MethodInfo m in methods) {
                            System.Type[] parameterTypes = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMethodParameterTypes(m);
                            object[] @params = new object[parameterTypes.Length];
                            for (int i = 0; i < @params.Length; i++) {
                                if (typeof(Net.TheVpc.Upa.PersistenceUnit).Equals(parameterTypes[i])) {
                                    @params[i] = entity.GetPersistenceUnit();
                                } else if (typeof(Net.TheVpc.Upa.Entity).Equals(parameterTypes[i])) {
                                    @params[i] = entity;
                                } else {
                                    throw new System.ArgumentException ("Unexpected parameter " + (i + 1) + " for " + m);
                                }
                            }
                            try {
                                m.Invoke(entityInfo.GetSource(), @params);
                            } catch (System.Exception ex) {
                                log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter(null,ex));
                            }
                        }
                    }
                    FireOnInitEntity(entity, position, Net.TheVpc.Upa.EventPhase.AFTER);
                }
            } else if (@object is Net.TheVpc.Upa.Field) {
                Net.TheVpc.Upa.Field field = (Net.TheVpc.Upa.Field) @object;
                if (phase == Net.TheVpc.Upa.EventPhase.BEFORE) {
                    Net.TheVpc.Upa.Entity entity = field.GetEntity();
                    Net.TheVpc.Upa.Package module = entity.GetParent();
                    string s = (module == null ? "/" : module.GetPath() + "/") + entity.GetName() + "/" + field.GetName();
                    if (model.ContainsField(field)) {
                        throw new Net.TheVpc.Upa.Exceptions.ObjectAlreadyExistsException("Field already exists", s);
                    }
                    AddHandlers(@object);
                    FireFieldAdded(field, position, phase);
                } else {
                    model.RegisterField(field);
                    if (field.GetDataType() is Net.TheVpc.Upa.Impl.SerializableOrManyToOneType) {
                        Net.TheVpc.Upa.Impl.Config.Annotationparser.FieldSerializableOrEntityProcessor p = new Net.TheVpc.Upa.Impl.Config.Annotationparser.FieldSerializableOrEntityProcessor(field.GetPersistenceUnit(), field);
                        p.Process();
                    }
                    FireFieldAdded(field, position, phase);
                }
            } else if (@object is Net.TheVpc.Upa.Index) {
                Net.TheVpc.Upa.Index index = (Net.TheVpc.Upa.Index) @object;
                Net.TheVpc.Upa.Entity parentEntity = (Net.TheVpc.Upa.Entity) parent;
                if (phase == Net.TheVpc.Upa.EventPhase.BEFORE) {
                    string s = index.GetName();
                    if (model.ContainsIndex(index, parentEntity)) {
                        throw new Net.TheVpc.Upa.Exceptions.ObjectAlreadyExistsException("Index already exists", s);
                    }
                    AddHandlers(@object);
                    FireOnCreateIndex(index, position, phase);
                } else {
                    model.RegisterIndex(index, parentEntity);
                    FireOnCreateIndex(index, position, phase);
                }
            } else if (@object is Net.TheVpc.Upa.Section) {
                Net.TheVpc.Upa.Section section = (Net.TheVpc.Upa.Section) @object;
                if (phase == Net.TheVpc.Upa.EventPhase.BEFORE) {
                    Net.TheVpc.Upa.Entity entity = section.GetEntity();
                    Net.TheVpc.Upa.Package module = entity.GetParent();
                    string s = (module == null ? "/" : module.GetPath() + "/") + entity.GetName() + "/" + section.GetPath();
                    if (model.ContainsSection(section)) {
                        throw new Net.TheVpc.Upa.Exceptions.ObjectAlreadyExistsException("Section already exists", s);
                    }
                    AddHandlers(@object);
                    FireOnCreateSection(section, position, phase);
                } else {
                    model.RegisterSection(section);
                    FireOnCreateSection(section, position, phase);
                }
            } else if (@object is Net.TheVpc.Upa.Package) {
                Net.TheVpc.Upa.Package module = (Net.TheVpc.Upa.Package) @object;
                Net.TheVpc.Upa.Package parentModule = (Net.TheVpc.Upa.Package) parent;
                if (phase == Net.TheVpc.Upa.EventPhase.BEFORE) {
                    string s = null;
                    if (parent == null) {
                        s = "/" + module.GetName();
                    } else {
                        s = parentModule.GetPath() + "/" + module.GetName();
                    }
                    if (model.ContainsPackage(module, parentModule)) {
                        throw new Net.TheVpc.Upa.Exceptions.ObjectAlreadyExistsException("Package already exists", s);
                    }
                    AddHandlers(@object);
                    FireOnCreatePackage(module, parentModule, position, phase);
                } else {
                    model.RegisterPackage(module, parentModule);
                    FireOnCreatePackage(module, parentModule, position, phase);
                }
            } else if (@object is Net.TheVpc.Upa.Relationship) {
                Net.TheVpc.Upa.Relationship relation = (Net.TheVpc.Upa.Relationship) @object;
                if (phase == Net.TheVpc.Upa.EventPhase.BEFORE) {
                    string s = relation.GetName();
                    if (model.ContainsRelationship(relation)) {
                        throw new Net.TheVpc.Upa.Exceptions.ObjectAlreadyExistsException("Relationship already exists", s);
                    }
                    AddHandlers(@object);
                    FireOnCreateRelationship(relation, position, phase);
                } else {
                    model.RegisterRelationship(relation);
                    FireOnCreateRelationship(relation, position, phase);
                }
            } else {
                throw new System.ArgumentException ("No supported");
            }
        }

        public virtual void ItemRemoved(Net.TheVpc.Upa.UPAObject @object, int position, Net.TheVpc.Upa.EventPhase phase) {
            if (@object is Net.TheVpc.Upa.Entity) {
                Net.TheVpc.Upa.Entity entity = (Net.TheVpc.Upa.Entity) @object;
                if (phase == Net.TheVpc.Upa.EventPhase.BEFORE) {
                    if (!model.ContainsEntity(entity, entity.GetParent())) {
                        throw new Net.TheVpc.Upa.Exceptions.NoSuchEntityException(entity.GetName(), null);
                    }
                    FireOnDropEntity(entity, position, phase);
                } else {
                    RemoveHandlers(@object);
                    model.UnregisterEntity(entity);
                    FireOnDropEntity(entity, position, phase);
                }
            } else if (@object is Net.TheVpc.Upa.Field) {
                Net.TheVpc.Upa.Field field = (Net.TheVpc.Upa.Field) @object;
                if (phase == Net.TheVpc.Upa.EventPhase.BEFORE) {
                    if (!model.ContainsField(field)) {
                        throw new Net.TheVpc.Upa.Exceptions.NoSuchFieldException(field.GetAbsoluteName());
                    }
                    FireFieldRemoved(field, position, phase);
                } else {
                    RemoveHandlers(@object);
                    model.UnregisterField(field);
                    FireFieldRemoved(field, position, phase);
                }
            } else if (@object is Net.TheVpc.Upa.Index) {
                Net.TheVpc.Upa.Index index = (Net.TheVpc.Upa.Index) @object;
                if (phase == Net.TheVpc.Upa.EventPhase.BEFORE) {
                    if (!model.ContainsIndex(index, index.GetEntity())) {
                        throw new Net.TheVpc.Upa.Exceptions.NoSuchIndexException(index.GetEntity().GetName(), index.GetName(), null);
                    }
                    FireOnDropIndex(index, position, phase);
                } else {
                    RemoveHandlers(@object);
                    model.UnregisterIndex(index);
                    FireOnDropIndex(index, position, phase);
                }
            } else if (@object is Net.TheVpc.Upa.Section) {
                Net.TheVpc.Upa.Section section = (Net.TheVpc.Upa.Section) @object;
                if (phase == Net.TheVpc.Upa.EventPhase.BEFORE) {
                    if (!model.ContainsSection(section)) {
                        throw new Net.TheVpc.Upa.Exceptions.NoSuchSectionException(section.GetAbsoluteName(), null);
                    }
                    FireOnDropSection(section, position, phase);
                } else {
                    RemoveHandlers(@object);
                    model.UnregisterSection(section);
                    FireOnDropSection(section, position, phase);
                }
            } else if (@object is Net.TheVpc.Upa.Package) {
                Net.TheVpc.Upa.Package module = (Net.TheVpc.Upa.Package) @object;
                if (phase == Net.TheVpc.Upa.EventPhase.BEFORE) {
                    if (!model.ContainsPackage(module, module.GetParent())) {
                        throw new Net.TheVpc.Upa.Exceptions.NoSuchPackageException(module.GetAbsoluteName(), null);
                    }
                    FireOnDropPackage(module, position, phase);
                } else {
                    RemoveHandlers(@object);
                    model.UnregisterPackage(module);
                    FireOnDropPackage(module, position, phase);
                }
            } else if (@object is Net.TheVpc.Upa.Relationship) {
                Net.TheVpc.Upa.Relationship relation = (Net.TheVpc.Upa.Relationship) @object;
                if (phase == Net.TheVpc.Upa.EventPhase.BEFORE) {
                    if (!model.ContainsRelationship(relation)) {
                        throw new Net.TheVpc.Upa.Exceptions.NoSuchRelationshipException(relation.GetAbsoluteName(), null);
                    }
                    FireOnDropRelationship(relation, position, phase);
                } else {
                    RemoveHandlers(@object);
                    model.UnregisterRelation(relation);
                    FireOnDropRelationship(relation, position, phase);
                }
            } else {
                throw new System.ArgumentException ("No supported");
            }
        }

        public virtual void ItemMoved(Net.TheVpc.Upa.UPAObject @object, int position, int toPosition, Net.TheVpc.Upa.EventPhase phase) {
            if (@object is Net.TheVpc.Upa.Entity) {
                Net.TheVpc.Upa.Entity entity = (Net.TheVpc.Upa.Entity) @object;
                Net.TheVpc.Upa.Callbacks.EntityEvent @event = new Net.TheVpc.Upa.Callbacks.EntityEvent(entity, entity.GetPersistenceUnit(), entity.GetParent(), position, null, toPosition, phase);
                string entityTypeListenerId = GetEntityTypeListenerId(entity.GetEntityType());
                bool system = entity.GetUserModifiers().Contains(Net.TheVpc.Upa.EntityModifier.SYSTEM);
                System.Collections.Generic.IList<Net.TheVpc.Upa.Callbacks.EntityDefinitionListener> interceptorList = entities.GetAllListeners(system, entity.GetName(), entityTypeListenerId);
                if (phase == Net.TheVpc.Upa.EventPhase.BEFORE) {
                    foreach (Net.TheVpc.Upa.Callbacks.EntityDefinitionListener listener in interceptorList) {
                        listener.OnPreMoveEntity(@event);
                    }
                    foreach (Net.TheVpc.Upa.Callback invoker in GetPreCallbacks(Net.TheVpc.Upa.CallbackType.ON_MOVE, Net.TheVpc.Upa.ObjectType.ENTITY, entity.GetName(), entity.IsSystem())) {
                        invoker.Invoke(@event);
                    }
                    foreach (Net.TheVpc.Upa.PreparedCallback callback in GetPostPreparedCallbacks(Net.TheVpc.Upa.CallbackType.ON_MOVE, Net.TheVpc.Upa.ObjectType.ENTITY, entity.GetName(), entity.IsSystem())) {
                        callback.Prepare(@event);
                    }
                } else {
                    foreach (Net.TheVpc.Upa.Callbacks.EntityDefinitionListener listener in interceptorList) {
                        listener.OnMoveEntity(@event);
                    }
                    foreach (Net.TheVpc.Upa.Callback invoker in GetPostCallbacks(Net.TheVpc.Upa.CallbackType.ON_MOVE, Net.TheVpc.Upa.ObjectType.ENTITY, entity.GetName(), entity.IsSystem())) {
                        invoker.Invoke(@event);
                    }
                }
            } else if (@object is Net.TheVpc.Upa.Field) {
                Net.TheVpc.Upa.Field field = (Net.TheVpc.Upa.Field) @object;
                Net.TheVpc.Upa.Entity entity = field.GetEntity();
                string entityTypeListenerId = GetEntityTypeListenerId(entity.GetEntityType());
                bool system = entity.GetUserModifiers().Contains(Net.TheVpc.Upa.EntityModifier.SYSTEM);
                Net.TheVpc.Upa.Callbacks.FieldEvent @event = new Net.TheVpc.Upa.Callbacks.FieldEvent(field, field.GetPersistenceUnit(), entity, field.GetParent(), position, null, toPosition, phase);
                System.Collections.Generic.IList<Net.TheVpc.Upa.Callbacks.FieldDefinitionListener> interceptorList = fields.GetAllListeners(system, entity.GetName(), entityTypeListenerId);
                if (phase == Net.TheVpc.Upa.EventPhase.BEFORE) {
                    foreach (Net.TheVpc.Upa.Callbacks.FieldDefinitionListener listener in interceptorList) {
                        listener.OnPreMoveField(@event);
                    }
                    foreach (Net.TheVpc.Upa.Callback invoker in GetPreCallbacks(Net.TheVpc.Upa.CallbackType.ON_MOVE, Net.TheVpc.Upa.ObjectType.FIELD, entity.GetName(), entity.IsSystem())) {
                        invoker.Invoke(@event);
                    }
                    foreach (Net.TheVpc.Upa.PreparedCallback callback in GetPostPreparedCallbacks(Net.TheVpc.Upa.CallbackType.ON_MOVE, Net.TheVpc.Upa.ObjectType.FIELD, entity.GetName(), entity.IsSystem())) {
                        callback.Prepare(@event);
                    }
                } else {
                    foreach (Net.TheVpc.Upa.Callbacks.FieldDefinitionListener listener in interceptorList) {
                        listener.OnMoveField(@event);
                    }
                    foreach (Net.TheVpc.Upa.Callback invoker in GetPostCallbacks(Net.TheVpc.Upa.CallbackType.ON_MOVE, Net.TheVpc.Upa.ObjectType.FIELD, entity.GetName(), entity.IsSystem())) {
                        invoker.Invoke(@event);
                    }
                }
            } else if (@object is Net.TheVpc.Upa.Section) {
                Net.TheVpc.Upa.Section section = (Net.TheVpc.Upa.Section) @object;
                Net.TheVpc.Upa.Entity entity = section.GetEntity();
                Net.TheVpc.Upa.Callbacks.SectionEvent @event = new Net.TheVpc.Upa.Callbacks.SectionEvent(section, section.GetPersistenceUnit(), entity, (Net.TheVpc.Upa.Section) section.GetParent(), position, null, toPosition, phase);
                string entityTypeListenerId = GetEntityTypeListenerId(entity.GetEntityType());
                bool system = entity.GetUserModifiers().Contains(Net.TheVpc.Upa.EntityModifier.SYSTEM);
                System.Collections.Generic.IList<Net.TheVpc.Upa.Callbacks.SectionDefinitionListener> interceptorList = sections.GetAllListeners(system, section.GetName(), entityTypeListenerId);
                if (phase == Net.TheVpc.Upa.EventPhase.BEFORE) {
                    foreach (Net.TheVpc.Upa.Callbacks.SectionDefinitionListener listener in interceptorList) {
                        listener.OnPreMoveSection(@event);
                    }
                    foreach (Net.TheVpc.Upa.Callback invoker in GetPreCallbacks(Net.TheVpc.Upa.CallbackType.ON_MOVE, Net.TheVpc.Upa.ObjectType.SECTION, entity.GetName(), entity.IsSystem())) {
                        invoker.Invoke(@event);
                    }
                    foreach (Net.TheVpc.Upa.PreparedCallback callback in GetPostPreparedCallbacks(Net.TheVpc.Upa.CallbackType.ON_MOVE, Net.TheVpc.Upa.ObjectType.SECTION, entity.GetName(), entity.IsSystem())) {
                        callback.Prepare(@event);
                    }
                } else {
                    foreach (Net.TheVpc.Upa.Callbacks.SectionDefinitionListener listener in interceptorList) {
                        listener.OnMoveSection(@event);
                    }
                    foreach (Net.TheVpc.Upa.Callback invoker in GetPostCallbacks(Net.TheVpc.Upa.CallbackType.ON_MOVE, Net.TheVpc.Upa.ObjectType.SECTION, entity.GetName(), entity.IsSystem())) {
                        invoker.Invoke(@event);
                    }
                }
            } else if (@object is Net.TheVpc.Upa.Package) {
                Net.TheVpc.Upa.Package module = (Net.TheVpc.Upa.Package) @object;
                Net.TheVpc.Upa.Callbacks.PackageEvent @event = new Net.TheVpc.Upa.Callbacks.PackageEvent(module, module.GetPersistenceUnit(), module.GetParent(), position, null, toPosition, phase);
                System.Collections.Generic.IList<Net.TheVpc.Upa.Callbacks.PackageDefinitionListener> interceptorList = packages;
                if (phase == Net.TheVpc.Upa.EventPhase.BEFORE) {
                    foreach (Net.TheVpc.Upa.Callbacks.PackageDefinitionListener listener in interceptorList) {
                        listener.OnPreMovePackage(@event);
                    }
                    foreach (Net.TheVpc.Upa.Callback invoker in GetPreCallbacks(Net.TheVpc.Upa.CallbackType.ON_MOVE, Net.TheVpc.Upa.ObjectType.PACKAGE, persistenceUnit.GetName(), DEFAULT_SYSTEM)) {
                        invoker.Invoke(@event);
                    }
                    foreach (Net.TheVpc.Upa.PreparedCallback callback in GetPostPreparedCallbacks(Net.TheVpc.Upa.CallbackType.ON_MOVE, Net.TheVpc.Upa.ObjectType.PACKAGE, persistenceUnit.GetName(), DEFAULT_SYSTEM)) {
                        callback.Prepare(@event);
                    }
                } else {
                    foreach (Net.TheVpc.Upa.Callbacks.PackageDefinitionListener listener in interceptorList) {
                        listener.OnMovePackage(@event);
                    }
                    foreach (Net.TheVpc.Upa.Callback invoker in GetPostCallbacks(Net.TheVpc.Upa.CallbackType.ON_MOVE, Net.TheVpc.Upa.ObjectType.PACKAGE, persistenceUnit.GetName(), DEFAULT_SYSTEM)) {
                        invoker.Invoke(@event);
                    }
                }
            }
        }

        public virtual void FireOnCreateTrigger(Net.TheVpc.Upa.Callbacks.Trigger trigger, Net.TheVpc.Upa.EventPhase phase) {
            Net.TheVpc.Upa.Callbacks.TriggerEvent evt = new Net.TheVpc.Upa.Callbacks.TriggerEvent(trigger, trigger.GetEntity(), phase);
            if (phase == Net.TheVpc.Upa.EventPhase.BEFORE) {
                foreach (Net.TheVpc.Upa.Callbacks.TriggerDefinitionListener li in entityTriggers.GetAllListeners(false, trigger.GetEntity().GetName())) {
                    li.OnPreCreateTrigger(evt);
                }
                foreach (Net.TheVpc.Upa.Callback callback in GetPreCallbacks(Net.TheVpc.Upa.CallbackType.ON_CREATE, Net.TheVpc.Upa.ObjectType.TRIGGER, trigger.GetEntity().GetName(), trigger.GetEntity().IsSystem())) {
                    callback.Invoke(evt);
                }
                foreach (Net.TheVpc.Upa.PreparedCallback callback in GetPostPreparedCallbacks(Net.TheVpc.Upa.CallbackType.ON_CREATE, Net.TheVpc.Upa.ObjectType.TRIGGER, trigger.GetEntity().GetName(), trigger.GetEntity().IsSystem())) {
                    callback.Invoke(evt);
                }
            } else {
                foreach (Net.TheVpc.Upa.Callbacks.TriggerDefinitionListener li in entityTriggers.GetAllListeners(false, trigger.GetEntity().GetName())) {
                    li.OnCreateTrigger(evt);
                }
                foreach (Net.TheVpc.Upa.Callback callback in GetPostCallbacks(Net.TheVpc.Upa.CallbackType.ON_CREATE, Net.TheVpc.Upa.ObjectType.TRIGGER, trigger.GetEntity().GetName(), trigger.GetEntity().IsSystem())) {
                    callback.Invoke(evt);
                }
            }
        }

        public virtual void FireOnDropTrigger(Net.TheVpc.Upa.Callbacks.Trigger trigger, Net.TheVpc.Upa.EventPhase phase) {
            Net.TheVpc.Upa.Callbacks.TriggerEvent evt = new Net.TheVpc.Upa.Callbacks.TriggerEvent(trigger, trigger.GetEntity(), phase);
            bool system = trigger.GetEntity().GetUserModifiers().Contains(Net.TheVpc.Upa.EntityModifier.SYSTEM);
            if (phase == Net.TheVpc.Upa.EventPhase.BEFORE) {
                foreach (Net.TheVpc.Upa.Callbacks.TriggerDefinitionListener li in entityTriggers.GetAllListeners(false, trigger.GetEntity().GetName())) {
                    li.OnPreDropTrigger(evt);
                }
                foreach (Net.TheVpc.Upa.Callback callback in GetPreCallbacks(Net.TheVpc.Upa.CallbackType.ON_DROP, Net.TheVpc.Upa.ObjectType.TRIGGER, trigger.GetEntity().GetName(), system)) {
                    callback.Invoke(evt);
                }
                foreach (Net.TheVpc.Upa.PreparedCallback callback in GetPostPreparedCallbacks(Net.TheVpc.Upa.CallbackType.ON_DROP, Net.TheVpc.Upa.ObjectType.TRIGGER, trigger.GetEntity().GetName(), system)) {
                    callback.Prepare(evt);
                }
            } else {
                foreach (Net.TheVpc.Upa.Callbacks.TriggerDefinitionListener li in entityTriggers.GetAllListeners(false, trigger.GetEntity().GetName())) {
                    li.OnDropTrigger(evt);
                }
                foreach (Net.TheVpc.Upa.Callback callback in GetPostCallbacks(Net.TheVpc.Upa.CallbackType.ON_DROP, Net.TheVpc.Upa.ObjectType.TRIGGER, trigger.GetEntity().GetName(), system)) {
                    callback.Invoke(evt);
                }
            }
        }

        protected internal virtual void FireOnCreateEntity(Net.TheVpc.Upa.Entity entity, int position, Net.TheVpc.Upa.EventPhase phase) {
            Net.TheVpc.Upa.Callbacks.EntityEvent evt = new Net.TheVpc.Upa.Callbacks.EntityEvent(entity, entity.GetPersistenceUnit(), entity.GetParent(), position, null, -1, phase);
            string entityTypeListenerId = GetEntityTypeListenerId(entity.GetEntityType());
            bool system = entity.GetUserModifiers().Contains(Net.TheVpc.Upa.EntityModifier.SYSTEM);
            if (phase == Net.TheVpc.Upa.EventPhase.BEFORE) {
                foreach (Net.TheVpc.Upa.Callbacks.EntityDefinitionListener listener in entities.GetAllListeners(system, entity.GetName(), entityTypeListenerId)) {
                    listener.OnPreCreateEntity(evt);
                }
                foreach (Net.TheVpc.Upa.Callback callback in GetPreCallbacks(Net.TheVpc.Upa.CallbackType.ON_CREATE, Net.TheVpc.Upa.ObjectType.ENTITY, entity.GetName(), system)) {
                    callback.Invoke(evt);
                }
                foreach (Net.TheVpc.Upa.PreparedCallback callback in GetPostPreparedCallbacks(Net.TheVpc.Upa.CallbackType.ON_CREATE, Net.TheVpc.Upa.ObjectType.ENTITY, entity.GetName(), system)) {
                    callback.Prepare(evt);
                }
            } else {
                foreach (Net.TheVpc.Upa.Callbacks.EntityDefinitionListener listener in entities.GetAllListeners(system, entity.GetName(), entityTypeListenerId)) {
                    listener.OnCreateEntity(evt);
                }
                foreach (Net.TheVpc.Upa.Callback callback in GetPostCallbacks(Net.TheVpc.Upa.CallbackType.ON_CREATE, Net.TheVpc.Upa.ObjectType.ENTITY, entity.GetName(), system)) {
                    callback.Invoke(evt);
                }
            }
        }

        protected internal virtual void FireOnInitEntity(Net.TheVpc.Upa.Entity entity, int position, Net.TheVpc.Upa.EventPhase phase) {
            Net.TheVpc.Upa.Callbacks.EntityEvent evt = new Net.TheVpc.Upa.Callbacks.EntityEvent(entity, entity.GetPersistenceUnit(), entity.GetParent(), position, null, -1, phase);
            string entityTypeListenerId = GetEntityTypeListenerId(entity.GetEntityType());
            bool system = entity.GetUserModifiers().Contains(Net.TheVpc.Upa.EntityModifier.SYSTEM);
            if (phase == Net.TheVpc.Upa.EventPhase.BEFORE) {
                foreach (Net.TheVpc.Upa.Callbacks.EntityDefinitionListener listener in entities.GetAllListeners(system, entity.GetName(), entityTypeListenerId)) {
                    listener.OnPreInitEntity(evt);
                }
                foreach (Net.TheVpc.Upa.Callback callback in GetPreCallbacks(Net.TheVpc.Upa.CallbackType.ON_INITIALIZE, Net.TheVpc.Upa.ObjectType.ENTITY, entity.GetName(), system)) {
                    callback.Invoke(evt);
                }
                foreach (Net.TheVpc.Upa.PreparedCallback callback in GetPostPreparedCallbacks(Net.TheVpc.Upa.CallbackType.ON_INITIALIZE, Net.TheVpc.Upa.ObjectType.ENTITY, entity.GetName(), system)) {
                    callback.Prepare(evt);
                }
            } else {
                foreach (Net.TheVpc.Upa.Callbacks.EntityDefinitionListener listener in entities.GetAllListeners(system, entity.GetName(), entityTypeListenerId)) {
                    listener.OnInitEntity(evt);
                }
                foreach (Net.TheVpc.Upa.Callback callback in GetPostCallbacks(Net.TheVpc.Upa.CallbackType.ON_INITIALIZE, Net.TheVpc.Upa.ObjectType.ENTITY, entity.GetName(), system)) {
                    callback.Invoke(evt);
                }
            }
        }

        protected internal virtual void FireFieldAdded(Net.TheVpc.Upa.Field field, int position, Net.TheVpc.Upa.EventPhase phase) {
            Net.TheVpc.Upa.Entity entity = field.GetEntity();
            Net.TheVpc.Upa.Callbacks.FieldEvent evt = new Net.TheVpc.Upa.Callbacks.FieldEvent(field, field.GetPersistenceUnit(), entity, field.GetParent(), position, null, -1, phase);
            string entityTypeListenerId = GetEntityTypeListenerId(entity.GetEntityType());
            bool system = entity.GetUserModifiers().Contains(Net.TheVpc.Upa.EntityModifier.SYSTEM);
            if (phase == Net.TheVpc.Upa.EventPhase.BEFORE) {
                foreach (Net.TheVpc.Upa.Callbacks.FieldDefinitionListener listener in fields.GetAllListeners(system, entity.GetName(), entityTypeListenerId)) {
                    listener.OnPreCreateField(evt);
                }
                foreach (Net.TheVpc.Upa.Callback callback in GetPreCallbacks(Net.TheVpc.Upa.CallbackType.ON_CREATE, Net.TheVpc.Upa.ObjectType.FIELD, entity.GetName(), system)) {
                    callback.Invoke(evt);
                }
                foreach (Net.TheVpc.Upa.PreparedCallback callback in GetPostPreparedCallbacks(Net.TheVpc.Upa.CallbackType.ON_CREATE, Net.TheVpc.Upa.ObjectType.FIELD, entity.GetName(), system)) {
                    callback.Prepare(evt);
                }
            } else {
                foreach (Net.TheVpc.Upa.Callbacks.FieldDefinitionListener listener in fields.GetAllListeners(system, entity.GetName(), entityTypeListenerId)) {
                    listener.OnCreateField(evt);
                }
                foreach (Net.TheVpc.Upa.Callback callback in GetPostCallbacks(Net.TheVpc.Upa.CallbackType.ON_CREATE, Net.TheVpc.Upa.ObjectType.FIELD, entity.GetName(), system)) {
                    callback.Invoke(evt);
                }
            }
        }

        protected internal virtual void FireOnCreateIndex(Net.TheVpc.Upa.Index index, int position, Net.TheVpc.Upa.EventPhase phase) {
            Net.TheVpc.Upa.Callbacks.IndexEvent @event = new Net.TheVpc.Upa.Callbacks.IndexEvent(index, index.GetPersistenceUnit(), phase);
            Net.TheVpc.Upa.Entity entity = index.GetEntity();
            string entityTypeListenerId = GetEntityTypeListenerId(index.GetEntity().GetEntityType());
            bool system = entity.GetUserModifiers().Contains(Net.TheVpc.Upa.EntityModifier.SYSTEM);
            if (phase == Net.TheVpc.Upa.EventPhase.BEFORE) {
                foreach (Net.TheVpc.Upa.Callbacks.IndexDefinitionListener listener in indexes.GetAllListeners(system, index.GetEntity().GetName(), entityTypeListenerId)) {
                    listener.OnPreCreateIndex(@event);
                }
                foreach (Net.TheVpc.Upa.Callback callback in GetPreCallbacks(Net.TheVpc.Upa.CallbackType.ON_CREATE, Net.TheVpc.Upa.ObjectType.INDEX, entity.GetName(), system)) {
                    callback.Invoke(@event);
                }
                foreach (Net.TheVpc.Upa.PreparedCallback callback in GetPostPreparedCallbacks(Net.TheVpc.Upa.CallbackType.ON_CREATE, Net.TheVpc.Upa.ObjectType.INDEX, entity.GetName(), system)) {
                    callback.Prepare(@event);
                }
            } else {
                foreach (Net.TheVpc.Upa.Callbacks.IndexDefinitionListener listener in indexes.GetAllListeners(system, index.GetEntity().GetName(), entityTypeListenerId)) {
                    listener.OnCreateIndex(@event);
                }
                foreach (Net.TheVpc.Upa.Callback callback in GetPostCallbacks(Net.TheVpc.Upa.CallbackType.ON_CREATE, Net.TheVpc.Upa.ObjectType.INDEX, entity.GetName(), system)) {
                    callback.Invoke(@event);
                }
            }
        }

        protected internal virtual void FireOnCreateSection(Net.TheVpc.Upa.Section section, int position, Net.TheVpc.Upa.EventPhase phase) {
            Net.TheVpc.Upa.Entity entity = section.GetEntity();
            string entityName = section.GetEntity().GetName();
            string entityTypeId = GetEntityTypeListenerId(section.GetEntity().GetEntityType());
            Net.TheVpc.Upa.Callbacks.SectionEvent @event = new Net.TheVpc.Upa.Callbacks.SectionEvent(section, section.GetPersistenceUnit(), entity, (Net.TheVpc.Upa.Section) section.GetParent(), position, null, -1, phase);
            bool system = entity.GetUserModifiers().Contains(Net.TheVpc.Upa.EntityModifier.SYSTEM);
            if (phase == Net.TheVpc.Upa.EventPhase.BEFORE) {
                foreach (Net.TheVpc.Upa.Callbacks.SectionDefinitionListener listener in sections.GetAllListeners(system, entityName, entityTypeId)) {
                    listener.OnPreCreateSection(@event);
                }
                foreach (Net.TheVpc.Upa.Callback callback in GetPreCallbacks(Net.TheVpc.Upa.CallbackType.ON_CREATE, Net.TheVpc.Upa.ObjectType.SECTION, entity.GetName(), system)) {
                    callback.Invoke(@event);
                }
                foreach (Net.TheVpc.Upa.PreparedCallback callback in GetPostPreparedCallbacks(Net.TheVpc.Upa.CallbackType.ON_CREATE, Net.TheVpc.Upa.ObjectType.SECTION, entity.GetName(), system)) {
                    callback.Prepare(@event);
                }
            } else {
                foreach (Net.TheVpc.Upa.Callbacks.SectionDefinitionListener listener in sections.GetAllListeners(system, entityName, entityTypeId)) {
                    listener.OnCreateSection(@event);
                }
                foreach (Net.TheVpc.Upa.Callback callback in GetPostCallbacks(Net.TheVpc.Upa.CallbackType.ON_CREATE, Net.TheVpc.Upa.ObjectType.SECTION, entity.GetName(), system)) {
                    callback.Invoke(@event);
                }
            }
        }

        protected internal virtual void FireOnCreatePackage(Net.TheVpc.Upa.Package module, Net.TheVpc.Upa.Package parent, int position, Net.TheVpc.Upa.EventPhase phase) {
            Net.TheVpc.Upa.Callbacks.PackageEvent evt = null;
            System.Collections.Generic.IList<Net.TheVpc.Upa.Callbacks.PackageDefinitionListener> interceptorList = packages;
            if (phase == Net.TheVpc.Upa.EventPhase.BEFORE) {
                if (!(interceptorList.Count==0)) {
                    evt = new Net.TheVpc.Upa.Callbacks.PackageEvent(module, module.GetPersistenceUnit(), parent, position, null, -1, phase);
                    foreach (Net.TheVpc.Upa.Callbacks.PackageDefinitionListener listener in interceptorList) {
                        listener.OnPreCreatePackage(evt);
                    }
                }
                System.Collections.Generic.IList<Net.TheVpc.Upa.Callback> callbackInvokers = GetPreCallbacks(Net.TheVpc.Upa.CallbackType.ON_CREATE, Net.TheVpc.Upa.ObjectType.PACKAGE, persistenceUnit.GetName(), DEFAULT_SYSTEM);
                if (!(callbackInvokers.Count==0)) {
                    if (evt == null) {
                        evt = new Net.TheVpc.Upa.Callbacks.PackageEvent(module, module.GetPersistenceUnit(), parent, position, null, -1, phase);
                    }
                    foreach (Net.TheVpc.Upa.Callback callback in callbackInvokers) {
                        callback.Invoke(evt);
                    }
                }
                foreach (Net.TheVpc.Upa.PreparedCallback callback in GetPostPreparedCallbacks(Net.TheVpc.Upa.CallbackType.ON_CREATE, Net.TheVpc.Upa.ObjectType.PACKAGE, persistenceUnit.GetName(), DEFAULT_SYSTEM)) {
                    if (evt == null) {
                        evt = new Net.TheVpc.Upa.Callbacks.PackageEvent(module, module.GetPersistenceUnit(), parent, position, null, -1, phase);
                    }
                    callback.Prepare(evt);
                }
            } else {
                if (!(interceptorList.Count==0)) {
                    evt = new Net.TheVpc.Upa.Callbacks.PackageEvent(module, module.GetPersistenceUnit(), parent, position, null, -1, phase);
                    foreach (Net.TheVpc.Upa.Callbacks.PackageDefinitionListener listener in interceptorList) {
                        listener.OnCreatePackage(evt);
                    }
                }
                System.Collections.Generic.IList<Net.TheVpc.Upa.Callback> callbackInvokers = GetPostCallbacks(Net.TheVpc.Upa.CallbackType.ON_CREATE, Net.TheVpc.Upa.ObjectType.PACKAGE, persistenceUnit.GetName(), DEFAULT_SYSTEM);
                if (!(callbackInvokers.Count==0)) {
                    if (evt == null) {
                        evt = new Net.TheVpc.Upa.Callbacks.PackageEvent(module, module.GetPersistenceUnit(), parent, position, null, -1, phase);
                    }
                    foreach (Net.TheVpc.Upa.Callback callback in callbackInvokers) {
                        callback.Invoke(evt);
                    }
                }
            }
        }

        protected internal virtual void FireOnCreateRelationship(Net.TheVpc.Upa.Relationship relation, int position, Net.TheVpc.Upa.EventPhase phase) {
            if (phase == Net.TheVpc.Upa.EventPhase.BEFORE) {
                Net.TheVpc.Upa.Callbacks.RelationshipEvent evt = new Net.TheVpc.Upa.Callbacks.RelationshipEvent(relation, relation.GetPersistenceUnit(), phase);
                System.Collections.Generic.IList<Net.TheVpc.Upa.Callbacks.RelationshipDefinitionListener> interceptorList = GetRelationshipListeners(relation.GetSourceRole().GetEntity().GetName(), relation.GetTargetRole().GetEntity().GetName());
                foreach (Net.TheVpc.Upa.Callbacks.RelationshipDefinitionListener listener in interceptorList) {
                    listener.OnPreCreateRelationship(evt);
                }
                foreach (Net.TheVpc.Upa.Callback callback in GetPreCallbacks(Net.TheVpc.Upa.CallbackType.ON_CREATE, Net.TheVpc.Upa.ObjectType.RELATIONSHIP, relation.GetSourceEntity().GetName(), false)) {
                    callback.Invoke(evt);
                }
                foreach (Net.TheVpc.Upa.PreparedCallback callback in GetPostPreparedCallbacks(Net.TheVpc.Upa.CallbackType.ON_CREATE, Net.TheVpc.Upa.ObjectType.RELATIONSHIP, relation.GetSourceEntity().GetName(), false)) {
                    callback.Prepare(evt);
                }
            } else {
                Net.TheVpc.Upa.Callbacks.RelationshipEvent evt = new Net.TheVpc.Upa.Callbacks.RelationshipEvent(relation, relation.GetPersistenceUnit(), phase);
                System.Collections.Generic.IList<Net.TheVpc.Upa.Callbacks.RelationshipDefinitionListener> interceptorList = GetRelationshipListeners(relation.GetSourceRole().GetEntity().GetName(), relation.GetTargetRole().GetEntity().GetName());
                foreach (Net.TheVpc.Upa.Callbacks.RelationshipDefinitionListener listener in interceptorList) {
                    listener.OnCreateRelationship(evt);
                }
                foreach (Net.TheVpc.Upa.Callback callback in GetPostCallbacks(Net.TheVpc.Upa.CallbackType.ON_CREATE, Net.TheVpc.Upa.ObjectType.RELATIONSHIP, relation.GetSourceEntity().GetName(), false)) {
                    callback.Invoke(evt);
                }
            }
        }

        protected internal virtual void FireOnDropEntity(Net.TheVpc.Upa.Entity entity, int position, Net.TheVpc.Upa.EventPhase phase) {
            Net.TheVpc.Upa.Callbacks.EntityEvent evt = new Net.TheVpc.Upa.Callbacks.EntityEvent(entity, entity.GetPersistenceUnit(), entity.GetParent(), position, null, -1, phase);
            string entityTypeListenerId = GetEntityTypeListenerId(entity.GetEntityType());
            bool system = entity.GetUserModifiers().Contains(Net.TheVpc.Upa.EntityModifier.SYSTEM);
            if (phase == Net.TheVpc.Upa.EventPhase.BEFORE) {
                foreach (Net.TheVpc.Upa.Callbacks.EntityDefinitionListener listener in entities.GetAllListeners(system, entity.GetName(), entityTypeListenerId)) {
                    listener.OnPreDropEntity(evt);
                }
                foreach (Net.TheVpc.Upa.Callback callback in GetPreCallbacks(Net.TheVpc.Upa.CallbackType.ON_DROP, Net.TheVpc.Upa.ObjectType.ENTITY, entity.GetName(), system)) {
                    callback.Invoke(evt);
                }
                foreach (Net.TheVpc.Upa.PreparedCallback callback in GetPostPreparedCallbacks(Net.TheVpc.Upa.CallbackType.ON_DROP, Net.TheVpc.Upa.ObjectType.ENTITY, entity.GetName(), system)) {
                    callback.Prepare(evt);
                }
            } else {
                foreach (Net.TheVpc.Upa.Callbacks.EntityDefinitionListener listener in entities.GetAllListeners(system, entity.GetName(), entityTypeListenerId)) {
                    listener.OnDropEntity(evt);
                }
                foreach (Net.TheVpc.Upa.Callback callback in GetPostCallbacks(Net.TheVpc.Upa.CallbackType.ON_DROP, Net.TheVpc.Upa.ObjectType.ENTITY, entity.GetName(), system)) {
                    callback.Invoke(evt);
                }
            }
        }

        protected internal virtual void FireFieldRemoved(Net.TheVpc.Upa.Field field, int position, Net.TheVpc.Upa.EventPhase phase) {
            Net.TheVpc.Upa.Entity entity = field.GetEntity();
            Net.TheVpc.Upa.Callbacks.FieldEvent evt = new Net.TheVpc.Upa.Callbacks.FieldEvent(field, field.GetPersistenceUnit(), entity, field.GetParent(), position, null, -1, phase);
            string entityName = entity.GetName();
            string entityTypeId = GetEntityTypeListenerId(entity.GetEntityType());
            bool system = entity.GetUserModifiers().Contains(Net.TheVpc.Upa.EntityModifier.SYSTEM);
            if (phase == Net.TheVpc.Upa.EventPhase.BEFORE) {
                foreach (Net.TheVpc.Upa.Callbacks.FieldDefinitionListener listener in fields.GetAllListeners(system, entityName, entityTypeId)) {
                    listener.OnPreDropField(evt);
                }
                foreach (Net.TheVpc.Upa.Callback callback in GetPreCallbacks(Net.TheVpc.Upa.CallbackType.ON_DROP, Net.TheVpc.Upa.ObjectType.FIELD, entity.GetName(), system)) {
                    callback.Invoke(evt);
                }
                foreach (Net.TheVpc.Upa.PreparedCallback callback in GetPostPreparedCallbacks(Net.TheVpc.Upa.CallbackType.ON_DROP, Net.TheVpc.Upa.ObjectType.FIELD, entity.GetName(), system)) {
                    callback.Prepare(evt);
                }
            } else {
                foreach (Net.TheVpc.Upa.Callbacks.FieldDefinitionListener listener in fields.GetAllListeners(system, entityName, entityTypeId)) {
                    listener.OnDropField(evt);
                }
                foreach (Net.TheVpc.Upa.Callback callback in GetPostCallbacks(Net.TheVpc.Upa.CallbackType.ON_DROP, Net.TheVpc.Upa.ObjectType.FIELD, entity.GetName(), system)) {
                    callback.Invoke(evt);
                }
            }
        }

        protected internal virtual void FireOnDropIndex(Net.TheVpc.Upa.Index index, int position, Net.TheVpc.Upa.EventPhase phase) {
            Net.TheVpc.Upa.Callbacks.IndexEvent evt = new Net.TheVpc.Upa.Callbacks.IndexEvent(index, index.GetPersistenceUnit(), phase);
            Net.TheVpc.Upa.Entity entity = index.GetEntity();
            string entityName = index.GetEntity().GetName();
            string entityTypeId = GetEntityTypeListenerId(index.GetEntity().GetEntityType());
            bool system = entity.GetUserModifiers().Contains(Net.TheVpc.Upa.EntityModifier.SYSTEM);
            if (phase == Net.TheVpc.Upa.EventPhase.BEFORE) {
                foreach (Net.TheVpc.Upa.Callbacks.IndexDefinitionListener listener in indexes.GetAllListeners(system, entityName, entityTypeId)) {
                    listener.OnPreDropIndex(evt);
                }
                foreach (Net.TheVpc.Upa.Callback callback in GetPreCallbacks(Net.TheVpc.Upa.CallbackType.ON_DROP, Net.TheVpc.Upa.ObjectType.INDEX, entity.GetName(), system)) {
                    callback.Invoke(evt);
                }
                foreach (Net.TheVpc.Upa.PreparedCallback callback in GetPostPreparedCallbacks(Net.TheVpc.Upa.CallbackType.ON_DROP, Net.TheVpc.Upa.ObjectType.INDEX, entity.GetName(), system)) {
                    callback.Prepare(evt);
                }
            } else {
                foreach (Net.TheVpc.Upa.Callbacks.IndexDefinitionListener listener in indexes.GetAllListeners(system, entityName, entityTypeId)) {
                    listener.OnDropIndex(evt);
                }
                foreach (Net.TheVpc.Upa.Callback callback in GetPostCallbacks(Net.TheVpc.Upa.CallbackType.ON_DROP, Net.TheVpc.Upa.ObjectType.INDEX, entity.GetName(), system)) {
                    callback.Invoke(evt);
                }
            }
        }

        protected internal virtual void FireOnDropSection(Net.TheVpc.Upa.Section section, int position, Net.TheVpc.Upa.EventPhase phase) {
            Net.TheVpc.Upa.Entity entity = section.GetEntity();
            Net.TheVpc.Upa.Callbacks.SectionEvent evt = new Net.TheVpc.Upa.Callbacks.SectionEvent(section, section.GetPersistenceUnit(), entity, (Net.TheVpc.Upa.Section) section.GetParent(), position, null, -1, phase);
            string entityName = section.GetEntity().GetName();
            string entityTypeId = GetEntityTypeListenerId(section.GetEntity().GetEntityType());
            bool system = entity.GetUserModifiers().Contains(Net.TheVpc.Upa.EntityModifier.SYSTEM);
            if (phase == Net.TheVpc.Upa.EventPhase.BEFORE) {
                foreach (Net.TheVpc.Upa.Callbacks.SectionDefinitionListener listener in sections.GetAllListeners(system, entityName, entityTypeId)) {
                    listener.OnPreDropSection(evt);
                }
                foreach (Net.TheVpc.Upa.Callback callback in GetPreCallbacks(Net.TheVpc.Upa.CallbackType.ON_DROP, Net.TheVpc.Upa.ObjectType.SECTION, entity.GetName(), system)) {
                    callback.Invoke(evt);
                }
                foreach (Net.TheVpc.Upa.PreparedCallback callback in GetPostPreparedCallbacks(Net.TheVpc.Upa.CallbackType.ON_DROP, Net.TheVpc.Upa.ObjectType.SECTION, entity.GetName(), system)) {
                    callback.Prepare(evt);
                }
            } else {
                foreach (Net.TheVpc.Upa.Callbacks.SectionDefinitionListener listener in sections.GetAllListeners(system, entityName, entityTypeId)) {
                    listener.OnDropSection(evt);
                }
                foreach (Net.TheVpc.Upa.Callback callback in GetPostCallbacks(Net.TheVpc.Upa.CallbackType.ON_DROP, Net.TheVpc.Upa.ObjectType.SECTION, entity.GetName(), system)) {
                    callback.Invoke(evt);
                }
            }
        }

        protected internal virtual void FireOnDropPackage(Net.TheVpc.Upa.Package module, int position, Net.TheVpc.Upa.EventPhase phase) {
            Net.TheVpc.Upa.Callbacks.PackageEvent evt = new Net.TheVpc.Upa.Callbacks.PackageEvent(module, module.GetPersistenceUnit(), module.GetParent(), position, null, -1, phase);
            System.Collections.Generic.IList<Net.TheVpc.Upa.Callbacks.PackageDefinitionListener> interceptorList = packages;
            if (phase == Net.TheVpc.Upa.EventPhase.BEFORE) {
                foreach (Net.TheVpc.Upa.Callbacks.PackageDefinitionListener listener in interceptorList) {
                    listener.OnPreDropPackage(evt);
                }
                foreach (Net.TheVpc.Upa.Callback callback in GetPreCallbacks(Net.TheVpc.Upa.CallbackType.ON_DROP, Net.TheVpc.Upa.ObjectType.PACKAGE, module.GetPersistenceUnit().GetName(), DEFAULT_SYSTEM)) {
                    callback.Invoke(evt);
                }
                foreach (Net.TheVpc.Upa.PreparedCallback callback in GetPostPreparedCallbacks(Net.TheVpc.Upa.CallbackType.ON_DROP, Net.TheVpc.Upa.ObjectType.PACKAGE, module.GetPersistenceUnit().GetName(), DEFAULT_SYSTEM)) {
                    callback.Prepare(evt);
                }
            } else {
                foreach (Net.TheVpc.Upa.Callbacks.PackageDefinitionListener listener in interceptorList) {
                    listener.OnDropPackage(evt);
                }
                foreach (Net.TheVpc.Upa.Callback callback in GetPostCallbacks(Net.TheVpc.Upa.CallbackType.ON_DROP, Net.TheVpc.Upa.ObjectType.PACKAGE, module.GetPersistenceUnit().GetName(), DEFAULT_SYSTEM)) {
                    callback.Invoke(evt);
                }
            }
        }

        protected internal virtual void FireOnDropRelationship(Net.TheVpc.Upa.Relationship relation, int position, Net.TheVpc.Upa.EventPhase phase) {
            Net.TheVpc.Upa.Callbacks.RelationshipEvent evt = new Net.TheVpc.Upa.Callbacks.RelationshipEvent(relation, relation.GetPersistenceUnit(), phase);
            if (phase == Net.TheVpc.Upa.EventPhase.BEFORE) {
                foreach (Net.TheVpc.Upa.Callbacks.RelationshipDefinitionListener listener in GetRelationshipListeners(relation.GetSourceRole().GetEntity().GetName(), relation.GetTargetRole().GetEntity().GetName())) {
                    listener.OnPreDropRelationship(evt);
                }
                foreach (Net.TheVpc.Upa.Callback callback in GetPreCallbacks(Net.TheVpc.Upa.CallbackType.ON_DROP, Net.TheVpc.Upa.ObjectType.RELATIONSHIP, relation.GetSourceRole().GetEntity().GetName(), relation.GetSourceRole().GetEntity().IsSystem())) {
                    callback.Invoke(evt);
                }
                foreach (Net.TheVpc.Upa.PreparedCallback callback in GetPostPreparedCallbacks(Net.TheVpc.Upa.CallbackType.ON_DROP, Net.TheVpc.Upa.ObjectType.RELATIONSHIP, relation.GetSourceRole().GetEntity().GetName(), relation.GetSourceRole().GetEntity().IsSystem())) {
                    callback.Prepare(evt);
                }
            } else {
                foreach (Net.TheVpc.Upa.Callbacks.RelationshipDefinitionListener listener in GetRelationshipListeners(relation.GetSourceRole().GetEntity().GetName(), relation.GetTargetRole().GetEntity().GetName())) {
                    listener.OnDropRelationship(evt);
                }
                foreach (Net.TheVpc.Upa.Callback callback in GetPostCallbacks(Net.TheVpc.Upa.CallbackType.ON_DROP, Net.TheVpc.Upa.ObjectType.RELATIONSHIP, relation.GetSourceRole().GetEntity().GetName(), relation.GetSourceRole().GetEntity().IsSystem())) {
                    callback.Invoke(evt);
                }
            }
        }

        protected internal virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Callbacks.RelationshipDefinitionListener> GetRelationshipListeners(string entityName1, string entityName2) {
            System.Collections.Generic.List<Net.TheVpc.Upa.Callbacks.RelationshipDefinitionListener> all = new System.Collections.Generic.List<Net.TheVpc.Upa.Callbacks.RelationshipDefinitionListener>();
            Net.TheVpc.Upa.Impl.Util.PlatformUtils.AddAll<Net.TheVpc.Upa.Callbacks.RelationshipDefinitionListener>(all, relationships.ToArrayConstrainted(false, null, new Net.TheVpc.Upa.Callbacks.RelationshipDefinitionListener[0]));
            if (entityName1 != null) {
                Net.TheVpc.Upa.Impl.Util.PlatformUtils.AddAll<Net.TheVpc.Upa.Callbacks.RelationshipDefinitionListener>(all, relationships.ToArrayConstrainted(false, entityName1, new Net.TheVpc.Upa.Callbacks.RelationshipDefinitionListener[0]));
            }
            if (entityName2 != null) {
                if (!entityName2.Equals(entityName1)) {
                    Net.TheVpc.Upa.Impl.Util.PlatformUtils.AddAll<Net.TheVpc.Upa.Callbacks.RelationshipDefinitionListener>(all, relationships.ToArrayConstrainted(false, entityName2, new Net.TheVpc.Upa.Callbacks.RelationshipDefinitionListener[0]));
                }
            }
            return all;
        }

        private string GetEntityTypeListenerId(System.Type entityType) {
            return entityType == null ? null : "private:" + (entityType).FullName;
        }

        public virtual void AddDefinitionListener(System.Type entityType, Net.TheVpc.Upa.Callbacks.DefinitionListener definitionListener, bool trackSystem) {
            AddDefinitionListener(GetEntityTypeListenerId(entityType), definitionListener, trackSystem);
        }

        public virtual void AddDefinitionListener(string entityName, Net.TheVpc.Upa.Callbacks.DefinitionListener definitionListener, bool trackSystem) {
            bool supported = false;
            if (definitionListener is Net.TheVpc.Upa.Callbacks.FieldDefinitionListener) {
                supported = true;
                fields.Add(trackSystem, entityName, (Net.TheVpc.Upa.Callbacks.FieldDefinitionListener) definitionListener);
            }
            if (definitionListener is Net.TheVpc.Upa.Callbacks.SectionDefinitionListener) {
                supported = true;
                sections.Add(trackSystem, entityName, (Net.TheVpc.Upa.Callbacks.SectionDefinitionListener) definitionListener);
            }
            if (definitionListener is Net.TheVpc.Upa.Callbacks.EntityDefinitionListener) {
                supported = true;
                entities.Add(trackSystem, entityName, (Net.TheVpc.Upa.Callbacks.EntityDefinitionListener) definitionListener);
            }
            if (definitionListener is Net.TheVpc.Upa.Callbacks.IndexDefinitionListener) {
                supported = true;
                indexes.Add(trackSystem, entityName, (Net.TheVpc.Upa.Callbacks.IndexDefinitionListener) definitionListener);
            }
            if (definitionListener is Net.TheVpc.Upa.Callbacks.RelationshipDefinitionListener) {
                supported = true;
                relationships.Add(false, entityName, (Net.TheVpc.Upa.Callbacks.RelationshipDefinitionListener) definitionListener);
            }
            if (definitionListener is Net.TheVpc.Upa.Callbacks.TriggerDefinitionListener) {
                supported = true;
                entityTriggers.Add(trackSystem, entityName, (Net.TheVpc.Upa.Callbacks.TriggerDefinitionListener) definitionListener);
            }
            if (definitionListener is Net.TheVpc.Upa.Callbacks.PackageDefinitionListener) {
                supported = true;
                packages.Add((Net.TheVpc.Upa.Callbacks.PackageDefinitionListener) definitionListener);
            }
            if (!supported) {
                throw new System.ArgumentException ("Unsupported DefinitionListener. See Documentation for detailed information.");
            }
        }

        public virtual void RemoveDefinitionListener(System.Type entityType, Net.TheVpc.Upa.Callbacks.DefinitionListener definitionListener) {
            RemoveDefinitionListener(GetEntityTypeListenerId(entityType), definitionListener);
        }

        public virtual void RemoveDefinitionListener(string entityName, Net.TheVpc.Upa.Callbacks.DefinitionListener definitionListener) {
            bool supported = false;
            if (definitionListener is Net.TheVpc.Upa.Callbacks.FieldDefinitionListener) {
                supported = true;
                fields.Remove(entityName, (Net.TheVpc.Upa.Callbacks.FieldDefinitionListener) definitionListener);
            }
            if (definitionListener is Net.TheVpc.Upa.Callbacks.SectionDefinitionListener) {
                supported = true;
                sections.Remove(entityName, (Net.TheVpc.Upa.Callbacks.SectionDefinitionListener) definitionListener);
            }
            if (definitionListener is Net.TheVpc.Upa.Callbacks.EntityDefinitionListener) {
                supported = true;
                entities.Remove(entityName, (Net.TheVpc.Upa.Callbacks.EntityDefinitionListener) definitionListener);
            }
            if (definitionListener is Net.TheVpc.Upa.Callbacks.IndexDefinitionListener) {
                supported = true;
                indexes.Remove(entityName, (Net.TheVpc.Upa.Callbacks.IndexDefinitionListener) definitionListener);
            }
            if (definitionListener is Net.TheVpc.Upa.Callbacks.RelationshipDefinitionListener) {
                supported = true;
                relationships.Remove(entityName, (Net.TheVpc.Upa.Callbacks.RelationshipDefinitionListener) definitionListener);
            }
            if (definitionListener is Net.TheVpc.Upa.Callbacks.PackageDefinitionListener) {
                supported = true;
                packages.Remove((Net.TheVpc.Upa.Callbacks.PackageDefinitionListener) definitionListener);
            }
            if (!supported) {
                throw new System.ArgumentException ("Unsupported DefinitionListener. See Documentation for detailed information.");
            }
        }

        public virtual void AddHandlers(Net.TheVpc.Upa.UPAObject @object) {
            @object.AddObjectListener(this);
        }

        protected internal virtual void RemoveHandlers(Net.TheVpc.Upa.UPAObject @object) {
            @object.RemoveObjectListener(this);
        }

        public virtual void FireOnModelChanged(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event) {
            Net.TheVpc.Upa.EventPhase phase = @event.GetPhase();
            if (phase == Net.TheVpc.Upa.EventPhase.BEFORE) {
                foreach (Net.TheVpc.Upa.Callbacks.PersistenceUnitListener listener in persistenceUnitListeners) {
                    listener.OnPreModelChanged(@event);
                }
                foreach (Net.TheVpc.Upa.Callback invoker in GetPreCallbacks(Net.TheVpc.Upa.CallbackType.ON_MODEL_CHANGED, Net.TheVpc.Upa.ObjectType.PERSISTENCE_UNIT, @event.GetPersistenceUnit().GetName(), DEFAULT_SYSTEM)) {
                    invoker.Invoke(@event);
                }
                foreach (Net.TheVpc.Upa.PreparedCallback callback in GetPostPreparedCallbacks(Net.TheVpc.Upa.CallbackType.ON_MODEL_CHANGED, Net.TheVpc.Upa.ObjectType.PERSISTENCE_UNIT, @event.GetPersistenceUnit().GetName(), DEFAULT_SYSTEM)) {
                    callback.Prepare(@event);
                }
            } else {
                foreach (Net.TheVpc.Upa.Callbacks.PersistenceUnitListener listener in persistenceUnitListeners) {
                    listener.OnModelChanged(@event);
                }
                foreach (Net.TheVpc.Upa.Callback invoker in GetPostCallbacks(Net.TheVpc.Upa.CallbackType.ON_MODEL_CHANGED, Net.TheVpc.Upa.ObjectType.PERSISTENCE_UNIT, @event.GetPersistenceUnit().GetName(), DEFAULT_SYSTEM)) {
                    invoker.Invoke(@event);
                }
            }
        }

        public virtual void FireOnStorageChanged(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event) {
            Net.TheVpc.Upa.EventPhase phase = @event.GetPhase();
            if (phase == Net.TheVpc.Upa.EventPhase.BEFORE) {
                foreach (Net.TheVpc.Upa.Callbacks.PersistenceUnitListener listener in persistenceUnitListeners) {
                    listener.OnPreStorageChanged(@event);
                }
                foreach (Net.TheVpc.Upa.PreparedCallback callback in GetPostPreparedCallbacks(Net.TheVpc.Upa.CallbackType.ON_STORAGE_CHANGED, Net.TheVpc.Upa.ObjectType.PERSISTENCE_UNIT, @event.GetPersistenceUnit().GetName(), DEFAULT_SYSTEM)) {
                    callback.Prepare(@event);
                }
            } else {
                foreach (Net.TheVpc.Upa.Callbacks.PersistenceUnitListener listener in persistenceUnitListeners) {
                    listener.OnStorageChanged(@event);
                }
                foreach (Net.TheVpc.Upa.Callback invoker in GetPostCallbacks(Net.TheVpc.Upa.CallbackType.ON_STORAGE_CHANGED, Net.TheVpc.Upa.ObjectType.PERSISTENCE_UNIT, @event.GetPersistenceUnit().GetName(), DEFAULT_SYSTEM)) {
                    invoker.Invoke(@event);
                }
            }
        }

        public virtual void FireOnClear(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event) {
            Net.TheVpc.Upa.EventPhase phase = @event.GetPhase();
            if (phase == Net.TheVpc.Upa.EventPhase.BEFORE) {
                foreach (Net.TheVpc.Upa.Callbacks.PersistenceUnitListener listener in persistenceUnitListeners) {
                    listener.OnPreClear(@event);
                }
                foreach (Net.TheVpc.Upa.Callback invoker in GetPreCallbacks(Net.TheVpc.Upa.CallbackType.ON_CLEAR, Net.TheVpc.Upa.ObjectType.PERSISTENCE_UNIT, @event.GetPersistenceUnit().GetName(), DEFAULT_SYSTEM)) {
                    invoker.Invoke(@event);
                }
                foreach (Net.TheVpc.Upa.PreparedCallback callback in GetPostPreparedCallbacks(Net.TheVpc.Upa.CallbackType.ON_CLEAR, Net.TheVpc.Upa.ObjectType.PERSISTENCE_UNIT, @event.GetPersistenceUnit().GetName(), DEFAULT_SYSTEM)) {
                    callback.Prepare(@event);
                }
            } else {
                foreach (Net.TheVpc.Upa.Callbacks.PersistenceUnitListener listener in persistenceUnitListeners) {
                    listener.OnClear(@event);
                }
                foreach (Net.TheVpc.Upa.Callback invoker in GetPostCallbacks(Net.TheVpc.Upa.CallbackType.ON_CLEAR, Net.TheVpc.Upa.ObjectType.PERSISTENCE_UNIT, @event.GetPersistenceUnit().GetName(), DEFAULT_SYSTEM)) {
                    invoker.Invoke(@event);
                }
            }
        }

        public virtual void FireOnClose(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event) {
            Net.TheVpc.Upa.EventPhase phase = @event.GetPhase();
            if (phase == Net.TheVpc.Upa.EventPhase.BEFORE) {
                foreach (Net.TheVpc.Upa.Callbacks.PersistenceUnitListener listener in persistenceUnitListeners) {
                    listener.OnPreClose(@event);
                }
                foreach (Net.TheVpc.Upa.Callback invoker in GetPreCallbacks(Net.TheVpc.Upa.CallbackType.ON_CLOSE, Net.TheVpc.Upa.ObjectType.PERSISTENCE_UNIT, @event.GetPersistenceUnit().GetName(), DEFAULT_SYSTEM)) {
                    invoker.Invoke(@event);
                }
                foreach (Net.TheVpc.Upa.PreparedCallback callback in GetPostPreparedCallbacks(Net.TheVpc.Upa.CallbackType.ON_CLOSE, Net.TheVpc.Upa.ObjectType.PERSISTENCE_UNIT, @event.GetPersistenceUnit().GetName(), DEFAULT_SYSTEM)) {
                    callback.Prepare(@event);
                }
            } else {
                foreach (Net.TheVpc.Upa.Callbacks.PersistenceUnitListener listener in persistenceUnitListeners) {
                    listener.OnClose(@event);
                }
                foreach (Net.TheVpc.Upa.Callback invoker in GetPostCallbacks(Net.TheVpc.Upa.CallbackType.ON_CLOSE, Net.TheVpc.Upa.ObjectType.PERSISTENCE_UNIT, @event.GetPersistenceUnit().GetName(), DEFAULT_SYSTEM)) {
                    invoker.Invoke(@event);
                }
            }
        }

        public virtual void FireOnReset(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event) {
            Net.TheVpc.Upa.EventPhase phase = @event.GetPhase();
            if (phase == Net.TheVpc.Upa.EventPhase.BEFORE) {
                foreach (Net.TheVpc.Upa.Callbacks.PersistenceUnitListener listener in persistenceUnitListeners) {
                    listener.OnPreReset(@event);
                }
                foreach (Net.TheVpc.Upa.Callback invoker in GetPreCallbacks(Net.TheVpc.Upa.CallbackType.ON_RESET, Net.TheVpc.Upa.ObjectType.PERSISTENCE_UNIT, @event.GetPersistenceUnit().GetName(), DEFAULT_SYSTEM)) {
                    invoker.Invoke(@event);
                }
                foreach (Net.TheVpc.Upa.PreparedCallback callback in GetPostPreparedCallbacks(Net.TheVpc.Upa.CallbackType.ON_RESET, Net.TheVpc.Upa.ObjectType.PERSISTENCE_UNIT, @event.GetPersistenceUnit().GetName(), DEFAULT_SYSTEM)) {
                    callback.Prepare(@event);
                }
            } else {
                foreach (Net.TheVpc.Upa.Callbacks.PersistenceUnitListener listener in persistenceUnitListeners) {
                    listener.OnReset(@event);
                }
                foreach (Net.TheVpc.Upa.Callback invoker in GetPostCallbacks(Net.TheVpc.Upa.CallbackType.ON_RESET, Net.TheVpc.Upa.ObjectType.PERSISTENCE_UNIT, @event.GetPersistenceUnit().GetName(), DEFAULT_SYSTEM)) {
                    invoker.Invoke(@event);
                }
            }
        }

        public virtual void FireOnStart(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event) {
            Net.TheVpc.Upa.EventPhase phase = @event.GetPhase();
            if (phase == Net.TheVpc.Upa.EventPhase.BEFORE) {
                foreach (Net.TheVpc.Upa.Callbacks.PersistenceUnitListener listener in persistenceUnitListeners) {
                    listener.OnPreStart(@event);
                }
                foreach (Net.TheVpc.Upa.Callback callback in GetPreCallbacks(Net.TheVpc.Upa.CallbackType.ON_START, Net.TheVpc.Upa.ObjectType.PERSISTENCE_UNIT, @event.GetPersistenceUnit().GetName(), DEFAULT_SYSTEM)) {
                    callback.Invoke(@event);
                }
                foreach (Net.TheVpc.Upa.PreparedCallback callback in GetPostPreparedCallbacks(Net.TheVpc.Upa.CallbackType.ON_START, Net.TheVpc.Upa.ObjectType.PERSISTENCE_UNIT, @event.GetPersistenceUnit().GetName(), DEFAULT_SYSTEM)) {
                    callback.Prepare(@event);
                }
            } else {
                foreach (Net.TheVpc.Upa.Callbacks.PersistenceUnitListener listener in persistenceUnitListeners) {
                    listener.OnStart(@event);
                }
                foreach (Net.TheVpc.Upa.Callback invoker in GetPostCallbacks(Net.TheVpc.Upa.CallbackType.ON_START, Net.TheVpc.Upa.ObjectType.PERSISTENCE_UNIT, @event.GetPersistenceUnit().GetName(), DEFAULT_SYSTEM)) {
                    invoker.Invoke(@event);
                }
            }
        }

        public virtual Net.TheVpc.Upa.Impl.Util.CallbackManager GetCallbackManager() {
            return callbackManager;
        }

        public virtual void AddCallback(Net.TheVpc.Upa.Callback callback) {
            callbackManager.AddCallback(callback);
        }

        public virtual void RemoveCallback(Net.TheVpc.Upa.Callback callback) {
            callbackManager.RemoveCallback(callback);
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Callback> GetPreCallbacks(Net.TheVpc.Upa.CallbackType callbackType, Net.TheVpc.Upa.ObjectType objectType, string nameFilter, bool system) {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Callback> allCallbacks = callbackManager.GetCallbacks(callbackType, objectType, nameFilter, system, false, Net.TheVpc.Upa.EventPhase.BEFORE);
            Net.TheVpc.Upa.Impl.FwkConvertUtils.ListAddRange(allCallbacks, new System.Collections.Generic.List<Net.TheVpc.Upa.Callback>(persistenceUnit.GetPersistenceGroup().GetCallbacks(callbackType, objectType, nameFilter, system, false, Net.TheVpc.Upa.EventPhase.BEFORE)));
            Net.TheVpc.Upa.Impl.FwkConvertUtils.ListAddRange(allCallbacks, new System.Collections.Generic.List<Net.TheVpc.Upa.Callback>(persistenceUnit.GetPersistenceGroup().GetContext().GetCallbacks(callbackType, objectType, nameFilter, system, false, Net.TheVpc.Upa.EventPhase.BEFORE)));
            return allCallbacks;
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Callback> GetPostCallbacks(Net.TheVpc.Upa.CallbackType callbackType, Net.TheVpc.Upa.ObjectType objectType, string nameFilter, bool system) {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Callback> allCallbacks = callbackManager.GetCallbacks(callbackType, objectType, nameFilter, system, false, Net.TheVpc.Upa.EventPhase.AFTER);
            Net.TheVpc.Upa.Impl.FwkConvertUtils.ListAddRange(allCallbacks, new System.Collections.Generic.List<Net.TheVpc.Upa.Callback>(persistenceUnit.GetPersistenceGroup().GetCallbacks(callbackType, objectType, nameFilter, system, false, Net.TheVpc.Upa.EventPhase.AFTER)));
            Net.TheVpc.Upa.Impl.FwkConvertUtils.ListAddRange(allCallbacks, new System.Collections.Generic.List<Net.TheVpc.Upa.Callback>(persistenceUnit.GetPersistenceGroup().GetContext().GetCallbacks(callbackType, objectType, nameFilter, system, false, Net.TheVpc.Upa.EventPhase.AFTER)));
            return allCallbacks;
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.PreparedCallback> GetPostPreparedCallbacks(Net.TheVpc.Upa.CallbackType callbackType, Net.TheVpc.Upa.ObjectType objectType, string nameFilter, bool system) {
            System.Collections.Generic.IList<Net.TheVpc.Upa.PreparedCallback> callbacks = new System.Collections.Generic.List<Net.TheVpc.Upa.PreparedCallback>();
            foreach (Net.TheVpc.Upa.Callback callback in callbackManager.GetCallbacks(callbackType, objectType, nameFilter, system, true, Net.TheVpc.Upa.EventPhase.AFTER)) {
                callbacks.Add((Net.TheVpc.Upa.PreparedCallback) callback);
            }
            foreach (Net.TheVpc.Upa.Callback callback in persistenceUnit.GetPersistenceGroup().GetCallbacks(callbackType, objectType, nameFilter, system, false, Net.TheVpc.Upa.EventPhase.AFTER)) {
                callbacks.Add((Net.TheVpc.Upa.PreparedCallback) callback);
            }
            foreach (Net.TheVpc.Upa.Callback callback in persistenceUnit.GetPersistenceGroup().GetContext().GetCallbacks(callbackType, objectType, nameFilter, system, false, Net.TheVpc.Upa.EventPhase.AFTER)) {
                callbacks.Add((Net.TheVpc.Upa.PreparedCallback) callback);
            }
            return callbacks;
        }

        public virtual Net.TheVpc.Upa.Callback[] GetCurrentCallbacks(Net.TheVpc.Upa.CallbackType callbackType, Net.TheVpc.Upa.ObjectType objectType, string nameFilter, bool system, bool preparedOnly, Net.TheVpc.Upa.EventPhase phase) {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Callback> callbacks = callbackManager.GetCallbacks(callbackType, objectType, nameFilter, system, preparedOnly, phase);
            return callbacks.ToArray();
        }

        public virtual void FireOnUpdateFormulas(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event) {
            Net.TheVpc.Upa.EventPhase phase = @event.GetPhase();
            if (phase == Net.TheVpc.Upa.EventPhase.BEFORE) {
                foreach (Net.TheVpc.Upa.Callbacks.PersistenceUnitListener listener in persistenceUnitListeners) {
                    listener.OnPreUpdateFormulas(@event);
                }
                foreach (Net.TheVpc.Upa.Callback callback in GetPreCallbacks(Net.TheVpc.Upa.CallbackType.ON_UPDATE_FORMULAS, Net.TheVpc.Upa.ObjectType.PERSISTENCE_UNIT, @event.GetPersistenceUnit().GetName(), DEFAULT_SYSTEM)) {
                    callback.Invoke(@event);
                }
                foreach (Net.TheVpc.Upa.PreparedCallback callback in GetPostPreparedCallbacks(Net.TheVpc.Upa.CallbackType.ON_UPDATE_FORMULAS, Net.TheVpc.Upa.ObjectType.PERSISTENCE_UNIT, @event.GetPersistenceUnit().GetName(), DEFAULT_SYSTEM)) {
                    callback.Invoke(@event);
                }
            } else {
                foreach (Net.TheVpc.Upa.Callbacks.PersistenceUnitListener listener in persistenceUnitListeners) {
                    listener.OnUpdateFormulas(@event);
                }
                foreach (Net.TheVpc.Upa.Callback invoker in GetPostCallbacks(Net.TheVpc.Upa.CallbackType.ON_UPDATE_FORMULAS, Net.TheVpc.Upa.ObjectType.PERSISTENCE_UNIT, @event.GetPersistenceUnit().GetName(), DEFAULT_SYSTEM)) {
                    invoker.Invoke(@event);
                }
            }
        }
    }
}
