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
namespace Net.Vpc.Upa.Impl.Event
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/27/12 9:07 PM
     */
    public class PersistenceUnitListenerManager : Net.Vpc.Upa.UPAObjectListener {

        private static readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.Vpc.Upa.Impl.Event.PersistenceUnitListenerManager)).FullName);

        public Net.Vpc.Upa.Impl.Event.ListenerSupport<Net.Vpc.Upa.Callbacks.FieldDefinitionListener> fields = new Net.Vpc.Upa.Impl.Event.ListenerSupport<Net.Vpc.Upa.Callbacks.FieldDefinitionListener>();

        public Net.Vpc.Upa.Impl.Event.ListenerSupport<Net.Vpc.Upa.Callbacks.SectionDefinitionListener> sections = new Net.Vpc.Upa.Impl.Event.ListenerSupport<Net.Vpc.Upa.Callbacks.SectionDefinitionListener>();

        public Net.Vpc.Upa.Impl.Event.ListenerSupport<Net.Vpc.Upa.Callbacks.EntityDefinitionListener> entities = new Net.Vpc.Upa.Impl.Event.ListenerSupport<Net.Vpc.Upa.Callbacks.EntityDefinitionListener>();

        public Net.Vpc.Upa.Impl.Event.ListenerSupport<Net.Vpc.Upa.Callbacks.IndexDefinitionListener> indexes = new Net.Vpc.Upa.Impl.Event.ListenerSupport<Net.Vpc.Upa.Callbacks.IndexDefinitionListener>();

        public Net.Vpc.Upa.Impl.Event.ListenerSupport<Net.Vpc.Upa.Callbacks.RelationshipDefinitionListener> relationships = new Net.Vpc.Upa.Impl.Event.ListenerSupport<Net.Vpc.Upa.Callbacks.RelationshipDefinitionListener>();

        public Net.Vpc.Upa.Impl.Event.ListenerSupport<Net.Vpc.Upa.Callbacks.TriggerDefinitionListener> entityTriggers = new Net.Vpc.Upa.Impl.Event.ListenerSupport<Net.Vpc.Upa.Callbacks.TriggerDefinitionListener>();

        public System.Collections.Generic.IList<Net.Vpc.Upa.Callbacks.PackageDefinitionListener> packages = new System.Collections.Generic.List<Net.Vpc.Upa.Callbacks.PackageDefinitionListener>();

        public readonly System.Collections.Generic.IList<Net.Vpc.Upa.Callbacks.PersistenceUnitListener> persistenceUnitListeners = new System.Collections.Generic.List<Net.Vpc.Upa.Callbacks.PersistenceUnitListener>();

        private Net.Vpc.Upa.Impl.ObjectRegistrationModel model;

        private Net.Vpc.Upa.Impl.Config.Decorations.DecorationRepository decorationRepository;

        private Net.Vpc.Upa.PersistenceUnit persistenceUnit;

        private Net.Vpc.Upa.Impl.Util.CallbackManager callbackManager = new Net.Vpc.Upa.Impl.Util.CallbackManager();

        private static bool DEFAULT_SYSTEM = false;

        public PersistenceUnitListenerManager(Net.Vpc.Upa.PersistenceUnit persistenceUnit, Net.Vpc.Upa.Impl.ObjectRegistrationModel model, Net.Vpc.Upa.Impl.Config.Decorations.DecorationRepository decorationRepository) {
            this.persistenceUnit = persistenceUnit;
            this.model = model;
            this.decorationRepository = decorationRepository;
        }

        public virtual void ItemAdded(Net.Vpc.Upa.UPAObject @object, int position, Net.Vpc.Upa.UPAObject parent, Net.Vpc.Upa.EventPhase phase) {
            if (@object is Net.Vpc.Upa.Entity) {
                Net.Vpc.Upa.Entity entity = (Net.Vpc.Upa.Entity) @object;
                Net.Vpc.Upa.Package parentModule = (Net.Vpc.Upa.Package) parent;
                if (phase == Net.Vpc.Upa.EventPhase.BEFORE) {
                    if (model.ContainsEntity(entity, parentModule)) {
                        Net.Vpc.Upa.Entity registered = model.GetEntity(entity.GetName());
                        object s1 = entity.GetEntityDescriptor().GetSource();
                        if (s1 != null && s1 is object[]) {
                            s1 = System.Convert.ToString((object[]) s1);
                        }
                        object s2 = registered.GetEntityDescriptor().GetSource();
                        if (s2 != null && s2 is object[]) {
                            s2 = System.Convert.ToString((object[]) s2);
                        }
                        throw new Net.Vpc.Upa.Exceptions.EntityAlreadyExistsException(entity.GetName(), s1, s2);
                    }
                    FireOnCreateEntity(entity, position, phase);
                } else {
                    model.RegisterEntity(entity, parentModule);
                    AddHandlers(@object);
                    FireOnCreateEntity(entity, position, phase);
                    Net.Vpc.Upa.EntityDescriptor entityInfo = entity.GetEntityDescriptor();
                    System.Collections.Generic.IList<Net.Vpc.Upa.FieldDescriptor> fieldDescriptors = entityInfo.GetFieldDescriptors();
                    if (fieldDescriptors != null) {
                        foreach (Net.Vpc.Upa.FieldDescriptor field in fieldDescriptors) {
                            entity.AddField(field);
                        }
                    }
                    System.Collections.Generic.IList<Net.Vpc.Upa.IndexDescriptor> indexDescriptors = entityInfo.GetIndexDescriptors();
                    if (indexDescriptors != null) {
                        foreach (Net.Vpc.Upa.IndexDescriptor index in indexDescriptors) {
                            entity.AddIndex(index.GetName(), index.IsUnique(), index.GetFieldNames());
                        }
                    }
                    System.Collections.Generic.IList<Net.Vpc.Upa.RelationshipDescriptor> relationshipDescriptors = entityInfo.GetRelationshipDescriptors();
                    if (relationshipDescriptors != null) {
                        foreach (Net.Vpc.Upa.RelationshipDescriptor relationDescriptor in relationshipDescriptors) {
                            entity.GetPersistenceUnit().AddRelationship(relationDescriptor);
                        }
                    }
                    if (entityInfo.GetSource() != null && entityInfo.GetSource() != entityInfo) {
                        System.Type c = entityInfo.GetSource().GetType();
                        System.Collections.Generic.IList<System.Reflection.MethodInfo> methods = new System.Collections.Generic.List<System.Reflection.MethodInfo>();
                        while (c != null) {
                            foreach (System.Reflection.MethodInfo m in c.GetMethods(System.Reflection.BindingFlags.Default)) {
                                if (decorationRepository.GetMethodDecoration(m, typeof(Net.Vpc.Upa.Config.Init)) != null || decorationRepository.GetMethodDecoration(m, "javax.annotation.PostConstruct") != null) {
                                    //m.SetAccessible(true);
                                    methods.Add(m);
                                }
                            }
                            c = (c).BaseType;
                        }
                        //reverse execution (must call super attach before instance attach
                        methods.Reverse();
                        foreach (System.Reflection.MethodInfo m in methods) {
                            System.Type[] parameterTypes = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMethodParameterTypes(m);
                            object[] @params = new object[parameterTypes.Length];
                            for (int i = 0; i < @params.Length; i++) {
                                if (typeof(Net.Vpc.Upa.PersistenceUnit).Equals(parameterTypes[i])) {
                                    @params[i] = entity.GetPersistenceUnit();
                                } else if (typeof(Net.Vpc.Upa.Entity).Equals(parameterTypes[i])) {
                                    @params[i] = entity;
                                } else {
                                    throw new System.ArgumentException ("Unexpected parameter " + (i + 1) + " for " + m);
                                }
                            }
                            try {
                                m.Invoke(entityInfo.GetSource(), @params);
                            } catch (System.Exception ex) {
                                log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter(null,ex));
                            }
                        }
                    }
                }
            } else if (@object is Net.Vpc.Upa.Field) {
                Net.Vpc.Upa.Field field = (Net.Vpc.Upa.Field) @object;
                if (phase == Net.Vpc.Upa.EventPhase.BEFORE) {
                    Net.Vpc.Upa.Entity entity = field.GetEntity();
                    Net.Vpc.Upa.Package module = entity.GetParent();
                    string s = (module == null ? "/" : module.GetPath() + "/") + entity.GetName() + "/" + field.GetName();
                    if (model.ContainsField(field)) {
                        throw new Net.Vpc.Upa.Exceptions.ObjectAlreadyExistsException("Field already exists", s);
                    }
                    FireFieldAdded(field, position, phase);
                } else {
                    model.RegisterField(field);
                    AddHandlers(@object);
                    if (field.GetDataType() is Net.Vpc.Upa.Impl.SerializableOrEntityType) {
                        Net.Vpc.Upa.Impl.Config.Annotationparser.FieldSerializableOrEntityProcessor p = new Net.Vpc.Upa.Impl.Config.Annotationparser.FieldSerializableOrEntityProcessor(field.GetPersistenceUnit(), field);
                        p.Process();
                    }
                    FireFieldAdded(field, position, phase);
                }
            } else if (@object is Net.Vpc.Upa.Index) {
                Net.Vpc.Upa.Index index = (Net.Vpc.Upa.Index) @object;
                Net.Vpc.Upa.Entity parentEntity = (Net.Vpc.Upa.Entity) parent;
                if (phase == Net.Vpc.Upa.EventPhase.BEFORE) {
                    string s = index.GetName();
                    if (model.ContainsIndex(index, parentEntity)) {
                        throw new Net.Vpc.Upa.Exceptions.ObjectAlreadyExistsException("Index already exists", s);
                    }
                    FireOnCreateIndex(index, position, phase);
                } else {
                    model.RegisterIndex(index, parentEntity);
                    AddHandlers(@object);
                    FireOnCreateIndex(index, position, phase);
                }
            } else if (@object is Net.Vpc.Upa.Section) {
                Net.Vpc.Upa.Section section = (Net.Vpc.Upa.Section) @object;
                if (phase == Net.Vpc.Upa.EventPhase.BEFORE) {
                    Net.Vpc.Upa.Entity entity = section.GetEntity();
                    Net.Vpc.Upa.Package module = entity.GetParent();
                    string s = (module == null ? "/" : module.GetPath() + "/") + entity.GetName() + "/" + section.GetPath();
                    if (model.ContainsSection(section)) {
                        throw new Net.Vpc.Upa.Exceptions.ObjectAlreadyExistsException("Section already exists", s);
                    }
                    FireOnCreateSection(section, position, phase);
                } else {
                    model.RegisterSection(section);
                    AddHandlers(@object);
                    FireOnCreateSection(section, position, phase);
                }
            } else if (@object is Net.Vpc.Upa.Package) {
                Net.Vpc.Upa.Package module = (Net.Vpc.Upa.Package) @object;
                Net.Vpc.Upa.Package parentModule = (Net.Vpc.Upa.Package) parent;
                if (phase == Net.Vpc.Upa.EventPhase.BEFORE) {
                    string s = null;
                    if (parent == null) {
                        s = "/" + module.GetName();
                    } else {
                        s = parentModule.GetPath() + "/" + module.GetName();
                    }
                    if (model.ContainsPackage(module, parentModule)) {
                        throw new Net.Vpc.Upa.Exceptions.ObjectAlreadyExistsException("Package already exists", s);
                    }
                    FireOnCreatePackage(module, parentModule, position, phase);
                } else {
                    model.RegisterPackage(module, parentModule);
                    AddHandlers(@object);
                    FireOnCreatePackage(module, parentModule, position, phase);
                }
            } else if (@object is Net.Vpc.Upa.Relationship) {
                Net.Vpc.Upa.Relationship relation = (Net.Vpc.Upa.Relationship) @object;
                if (phase == Net.Vpc.Upa.EventPhase.BEFORE) {
                    string s = relation.GetName();
                    if (model.ContainsRelationship(relation)) {
                        throw new Net.Vpc.Upa.Exceptions.ObjectAlreadyExistsException("Relationship already exists", s);
                    }
                    FireOnCreateRelationship(relation, position, phase);
                } else {
                    model.RegisterRelationship(relation);
                    AddHandlers(@object);
                    FireOnCreateRelationship(relation, position, phase);
                }
            } else {
                throw new System.ArgumentException ("No supported");
            }
        }

        public virtual void ItemRemoved(Net.Vpc.Upa.UPAObject @object, int position, Net.Vpc.Upa.EventPhase phase) {
            if (@object is Net.Vpc.Upa.Entity) {
                Net.Vpc.Upa.Entity entity = (Net.Vpc.Upa.Entity) @object;
                if (phase == Net.Vpc.Upa.EventPhase.BEFORE) {
                    if (!model.ContainsEntity(entity, entity.GetParent())) {
                        throw new Net.Vpc.Upa.Exceptions.NoSuchEntityException(entity.GetName(), null);
                    }
                    FireOnDropEntity(entity, position, phase);
                } else {
                    RemoveHandlers(@object);
                    model.UnregisterEntity(entity);
                    FireOnDropEntity(entity, position, phase);
                }
            } else if (@object is Net.Vpc.Upa.Field) {
                Net.Vpc.Upa.Field field = (Net.Vpc.Upa.Field) @object;
                if (phase == Net.Vpc.Upa.EventPhase.BEFORE) {
                    if (!model.ContainsField(field)) {
                        throw new Net.Vpc.Upa.Exceptions.NoSuchFieldException(field.GetAbsoluteName());
                    }
                    FireFieldRemoved(field, position, phase);
                } else {
                    RemoveHandlers(@object);
                    model.UnregisterField(field);
                    FireFieldRemoved(field, position, phase);
                }
            } else if (@object is Net.Vpc.Upa.Index) {
                Net.Vpc.Upa.Index index = (Net.Vpc.Upa.Index) @object;
                if (phase == Net.Vpc.Upa.EventPhase.BEFORE) {
                    if (!model.ContainsIndex(index, index.GetEntity())) {
                        throw new Net.Vpc.Upa.Exceptions.NoSuchIndexException(index.GetEntity().GetName(), index.GetName(), null);
                    }
                    FireOnDropIndex(index, position, phase);
                } else {
                    RemoveHandlers(@object);
                    model.UnregisterIndex(index);
                    FireOnDropIndex(index, position, phase);
                }
            } else if (@object is Net.Vpc.Upa.Section) {
                Net.Vpc.Upa.Section section = (Net.Vpc.Upa.Section) @object;
                if (phase == Net.Vpc.Upa.EventPhase.BEFORE) {
                    if (!model.ContainsSection(section)) {
                        throw new Net.Vpc.Upa.Exceptions.NoSuchSectionException(section.GetAbsoluteName(), null);
                    }
                    FireOnDropSection(section, position, phase);
                } else {
                    RemoveHandlers(@object);
                    model.UnregisterSection(section);
                    FireOnDropSection(section, position, phase);
                }
            } else if (@object is Net.Vpc.Upa.Package) {
                Net.Vpc.Upa.Package module = (Net.Vpc.Upa.Package) @object;
                if (phase == Net.Vpc.Upa.EventPhase.BEFORE) {
                    if (!model.ContainsPackage(module, module.GetParent())) {
                        throw new Net.Vpc.Upa.Exceptions.NoSuchPackageException(module.GetAbsoluteName(), null);
                    }
                    FireOnDropPackage(module, position, phase);
                } else {
                    RemoveHandlers(@object);
                    model.UnregisterPackage(module);
                    FireOnDropPackage(module, position, phase);
                }
            } else if (@object is Net.Vpc.Upa.Relationship) {
                Net.Vpc.Upa.Relationship relation = (Net.Vpc.Upa.Relationship) @object;
                if (phase == Net.Vpc.Upa.EventPhase.BEFORE) {
                    if (!model.ContainsRelationship(relation)) {
                        throw new Net.Vpc.Upa.Exceptions.NoSuchRelationshipException(relation.GetAbsoluteName(), null);
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

        public virtual void ItemMoved(Net.Vpc.Upa.UPAObject @object, int position, int toPosition, Net.Vpc.Upa.EventPhase phase) {
            if (@object is Net.Vpc.Upa.Entity) {
                Net.Vpc.Upa.Entity entity = (Net.Vpc.Upa.Entity) @object;
                Net.Vpc.Upa.Callbacks.EntityEvent @event = new Net.Vpc.Upa.Callbacks.EntityEvent(entity, entity.GetPersistenceUnit(), entity.GetParent(), position, null, toPosition);
                string entityTypeListenerId = GetEntityTypeListenerId(entity.GetEntityType());
                bool system = entity.GetUserModifiers().Contains(Net.Vpc.Upa.EntityModifier.SYSTEM);
                System.Collections.Generic.IList<Net.Vpc.Upa.Callbacks.EntityDefinitionListener> interceptorList = entities.GetAllListeners(system, entity.GetName(), entityTypeListenerId);
                if (phase == Net.Vpc.Upa.EventPhase.BEFORE) {
                    foreach (Net.Vpc.Upa.Callbacks.EntityDefinitionListener listener in interceptorList) {
                        listener.OnPreMoveEntity(@event);
                    }
                    foreach (Net.Vpc.Upa.Callback invoker in GetCallbackPreInvokers(Net.Vpc.Upa.CallbackType.ON_MOVE, Net.Vpc.Upa.ObjectType.ENTITY, entity.GetName(), entity.IsSystem())) {
                        invoker.Invoke(@event);
                    }
                } else {
                    foreach (Net.Vpc.Upa.Callbacks.EntityDefinitionListener listener in interceptorList) {
                        listener.OnMoveEntity(@event);
                    }
                    foreach (Net.Vpc.Upa.Callback invoker in GetCallbackPostInvokers(Net.Vpc.Upa.CallbackType.ON_MOVE, Net.Vpc.Upa.ObjectType.ENTITY, entity.GetName(), entity.IsSystem())) {
                        invoker.Invoke(@event);
                    }
                }
            } else if (@object is Net.Vpc.Upa.Field) {
                Net.Vpc.Upa.Field field = (Net.Vpc.Upa.Field) @object;
                Net.Vpc.Upa.Entity entity = field.GetEntity();
                string entityTypeListenerId = GetEntityTypeListenerId(entity.GetEntityType());
                bool system = entity.GetUserModifiers().Contains(Net.Vpc.Upa.EntityModifier.SYSTEM);
                Net.Vpc.Upa.Callbacks.FieldEvent @event = new Net.Vpc.Upa.Callbacks.FieldEvent(field, field.GetPersistenceUnit(), entity, field.GetParent(), position, null, toPosition);
                System.Collections.Generic.IList<Net.Vpc.Upa.Callbacks.FieldDefinitionListener> interceptorList = fields.GetAllListeners(system, entity.GetName(), entityTypeListenerId);
                if (phase == Net.Vpc.Upa.EventPhase.BEFORE) {
                    foreach (Net.Vpc.Upa.Callbacks.FieldDefinitionListener listener in interceptorList) {
                        listener.OnPreMoveField(@event);
                    }
                    foreach (Net.Vpc.Upa.Callback invoker in GetCallbackPreInvokers(Net.Vpc.Upa.CallbackType.ON_MOVE, Net.Vpc.Upa.ObjectType.FIELD, entity.GetName(), entity.IsSystem())) {
                        invoker.Invoke(@event);
                    }
                } else {
                    foreach (Net.Vpc.Upa.Callbacks.FieldDefinitionListener listener in interceptorList) {
                        listener.OnMoveField(@event);
                    }
                    foreach (Net.Vpc.Upa.Callback invoker in GetCallbackPostInvokers(Net.Vpc.Upa.CallbackType.ON_MOVE, Net.Vpc.Upa.ObjectType.FIELD, entity.GetName(), entity.IsSystem())) {
                        invoker.Invoke(@event);
                    }
                }
            } else if (@object is Net.Vpc.Upa.Section) {
                Net.Vpc.Upa.Section section = (Net.Vpc.Upa.Section) @object;
                Net.Vpc.Upa.Entity entity = section.GetEntity();
                Net.Vpc.Upa.Callbacks.SectionEvent @event = new Net.Vpc.Upa.Callbacks.SectionEvent(section, section.GetPersistenceUnit(), entity, (Net.Vpc.Upa.Section) section.GetParent(), position, null, toPosition);
                string entityTypeListenerId = GetEntityTypeListenerId(entity.GetEntityType());
                bool system = entity.GetUserModifiers().Contains(Net.Vpc.Upa.EntityModifier.SYSTEM);
                System.Collections.Generic.IList<Net.Vpc.Upa.Callbacks.SectionDefinitionListener> interceptorList = sections.GetAllListeners(system, section.GetName(), entityTypeListenerId);
                if (phase == Net.Vpc.Upa.EventPhase.BEFORE) {
                    foreach (Net.Vpc.Upa.Callbacks.SectionDefinitionListener listener in interceptorList) {
                        listener.OnPreMoveSection(@event);
                    }
                    foreach (Net.Vpc.Upa.Callback invoker in GetCallbackPreInvokers(Net.Vpc.Upa.CallbackType.ON_MOVE, Net.Vpc.Upa.ObjectType.SECTION, entity.GetName(), entity.IsSystem())) {
                        invoker.Invoke(@event);
                    }
                } else {
                    foreach (Net.Vpc.Upa.Callbacks.SectionDefinitionListener listener in interceptorList) {
                        listener.OnMoveSection(@event);
                    }
                    foreach (Net.Vpc.Upa.Callback invoker in GetCallbackPostInvokers(Net.Vpc.Upa.CallbackType.ON_MOVE, Net.Vpc.Upa.ObjectType.SECTION, entity.GetName(), entity.IsSystem())) {
                        invoker.Invoke(@event);
                    }
                }
            } else if (@object is Net.Vpc.Upa.Package) {
                Net.Vpc.Upa.Package module = (Net.Vpc.Upa.Package) @object;
                Net.Vpc.Upa.Callbacks.PackageEvent @event = new Net.Vpc.Upa.Callbacks.PackageEvent(module, module.GetPersistenceUnit(), module.GetParent(), position, null, toPosition);
                System.Collections.Generic.IList<Net.Vpc.Upa.Callbacks.PackageDefinitionListener> interceptorList = packages;
                if (phase == Net.Vpc.Upa.EventPhase.BEFORE) {
                    foreach (Net.Vpc.Upa.Callbacks.PackageDefinitionListener listener in interceptorList) {
                        listener.OnPreMovePackage(@event);
                    }
                    foreach (Net.Vpc.Upa.Callback invoker in GetCallbackPreInvokers(Net.Vpc.Upa.CallbackType.ON_MOVE, Net.Vpc.Upa.ObjectType.PACKAGE, persistenceUnit.GetName(), DEFAULT_SYSTEM)) {
                        invoker.Invoke(@event);
                    }
                } else {
                    foreach (Net.Vpc.Upa.Callbacks.PackageDefinitionListener listener in interceptorList) {
                        listener.OnMovePackage(@event);
                    }
                    foreach (Net.Vpc.Upa.Callback invoker in GetCallbackPostInvokers(Net.Vpc.Upa.CallbackType.ON_MOVE, Net.Vpc.Upa.ObjectType.PACKAGE, persistenceUnit.GetName(), DEFAULT_SYSTEM)) {
                        invoker.Invoke(@event);
                    }
                }
            }
        }

        public virtual void FireOnCreateTrigger(Net.Vpc.Upa.Callbacks.Trigger trigger, Net.Vpc.Upa.EventPhase phase) {
            Net.Vpc.Upa.Callbacks.TriggerEvent evt = new Net.Vpc.Upa.Callbacks.TriggerEvent(trigger, trigger.GetEntity());
            if (phase == Net.Vpc.Upa.EventPhase.BEFORE) {
                foreach (Net.Vpc.Upa.Callbacks.TriggerDefinitionListener li in entityTriggers.GetAllListeners(false, trigger.GetEntity().GetName())) {
                    li.OnPreCreateTrigger(evt);
                }
                foreach (Net.Vpc.Upa.Callback callback in GetCallbackPreInvokers(Net.Vpc.Upa.CallbackType.ON_CREATE, Net.Vpc.Upa.ObjectType.TRIGGER, trigger.GetEntity().GetName(), trigger.GetEntity().IsSystem())) {
                    callback.Invoke(evt);
                }
            } else {
                foreach (Net.Vpc.Upa.Callbacks.TriggerDefinitionListener li in entityTriggers.GetAllListeners(false, trigger.GetEntity().GetName())) {
                    li.OnCreateTrigger(evt);
                }
                foreach (Net.Vpc.Upa.Callback callback in GetCallbackPreInvokers(Net.Vpc.Upa.CallbackType.ON_CREATE, Net.Vpc.Upa.ObjectType.TRIGGER, trigger.GetEntity().GetName(), trigger.GetEntity().IsSystem())) {
                    callback.Invoke(evt);
                }
            }
        }

        public virtual void FireOnDropTrigger(Net.Vpc.Upa.Callbacks.Trigger trigger, Net.Vpc.Upa.EventPhase phase) {
            Net.Vpc.Upa.Callbacks.TriggerEvent evt = new Net.Vpc.Upa.Callbacks.TriggerEvent(trigger, trigger.GetEntity());
            bool system = trigger.GetEntity().GetUserModifiers().Contains(Net.Vpc.Upa.EntityModifier.SYSTEM);
            if (phase == Net.Vpc.Upa.EventPhase.BEFORE) {
                foreach (Net.Vpc.Upa.Callbacks.TriggerDefinitionListener li in entityTriggers.GetAllListeners(false, trigger.GetEntity().GetName())) {
                    li.OnPreDropTrigger(evt);
                }
                foreach (Net.Vpc.Upa.Callback callback in GetCallbackPreInvokers(Net.Vpc.Upa.CallbackType.ON_DROP, Net.Vpc.Upa.ObjectType.TRIGGER, trigger.GetEntity().GetName(), system)) {
                    callback.Invoke(evt);
                }
            } else {
                foreach (Net.Vpc.Upa.Callbacks.TriggerDefinitionListener li in entityTriggers.GetAllListeners(false, trigger.GetEntity().GetName())) {
                    li.OnDropTrigger(evt);
                }
                foreach (Net.Vpc.Upa.Callback callback in GetCallbackPostInvokers(Net.Vpc.Upa.CallbackType.ON_DROP, Net.Vpc.Upa.ObjectType.TRIGGER, trigger.GetEntity().GetName(), system)) {
                    callback.Invoke(evt);
                }
            }
        }

        protected internal virtual void FireOnCreateEntity(Net.Vpc.Upa.Entity entity, int position, Net.Vpc.Upa.EventPhase phase) {
            Net.Vpc.Upa.Callbacks.EntityEvent evt = new Net.Vpc.Upa.Callbacks.EntityEvent(entity, entity.GetPersistenceUnit(), entity.GetParent(), position, null, -1);
            string entityTypeListenerId = GetEntityTypeListenerId(entity.GetEntityType());
            bool system = entity.GetUserModifiers().Contains(Net.Vpc.Upa.EntityModifier.SYSTEM);
            if (phase == Net.Vpc.Upa.EventPhase.BEFORE) {
                foreach (Net.Vpc.Upa.Callbacks.EntityDefinitionListener listener in entities.GetAllListeners(system, entity.GetName(), entityTypeListenerId)) {
                    listener.OnPreCreateEntity(evt);
                }
                foreach (Net.Vpc.Upa.Callback callback in GetCallbackPreInvokers(Net.Vpc.Upa.CallbackType.ON_CREATE, Net.Vpc.Upa.ObjectType.ENTITY, entity.GetName(), system)) {
                    callback.Invoke(evt);
                }
            } else {
                foreach (Net.Vpc.Upa.Callbacks.EntityDefinitionListener listener in entities.GetAllListeners(system, entity.GetName(), entityTypeListenerId)) {
                    listener.OnCreateEntity(evt);
                }
                foreach (Net.Vpc.Upa.Callback callback in GetCallbackPostInvokers(Net.Vpc.Upa.CallbackType.ON_CREATE, Net.Vpc.Upa.ObjectType.ENTITY, entity.GetName(), system)) {
                    callback.Invoke(evt);
                }
            }
        }

        protected internal virtual void FireFieldAdded(Net.Vpc.Upa.Field field, int position, Net.Vpc.Upa.EventPhase phase) {
            Net.Vpc.Upa.Entity entity = field.GetEntity();
            Net.Vpc.Upa.Callbacks.FieldEvent evt = new Net.Vpc.Upa.Callbacks.FieldEvent(field, field.GetPersistenceUnit(), entity, field.GetParent(), position, null, -1);
            string entityTypeListenerId = GetEntityTypeListenerId(entity.GetEntityType());
            bool system = entity.GetUserModifiers().Contains(Net.Vpc.Upa.EntityModifier.SYSTEM);
            if (phase == Net.Vpc.Upa.EventPhase.BEFORE) {
                foreach (Net.Vpc.Upa.Callbacks.FieldDefinitionListener listener in fields.GetAllListeners(system, entity.GetName(), entityTypeListenerId)) {
                    listener.OnPreCreateField(evt);
                }
                foreach (Net.Vpc.Upa.Callback callback in GetCallbackPreInvokers(Net.Vpc.Upa.CallbackType.ON_CREATE, Net.Vpc.Upa.ObjectType.FIELD, entity.GetName(), system)) {
                    callback.Invoke(evt);
                }
            } else {
                foreach (Net.Vpc.Upa.Callbacks.FieldDefinitionListener listener in fields.GetAllListeners(system, entity.GetName(), entityTypeListenerId)) {
                    listener.OnCreateField(evt);
                }
                foreach (Net.Vpc.Upa.Callback callback in GetCallbackPostInvokers(Net.Vpc.Upa.CallbackType.ON_CREATE, Net.Vpc.Upa.ObjectType.FIELD, entity.GetName(), system)) {
                    callback.Invoke(evt);
                }
            }
        }

        protected internal virtual void FireOnCreateIndex(Net.Vpc.Upa.Index index, int position, Net.Vpc.Upa.EventPhase phase) {
            Net.Vpc.Upa.Callbacks.IndexEvent @event = new Net.Vpc.Upa.Callbacks.IndexEvent(index, index.GetPersistenceUnit());
            Net.Vpc.Upa.Entity entity = index.GetEntity();
            string entityTypeListenerId = GetEntityTypeListenerId(index.GetEntity().GetEntityType());
            bool system = entity.GetUserModifiers().Contains(Net.Vpc.Upa.EntityModifier.SYSTEM);
            if (phase == Net.Vpc.Upa.EventPhase.BEFORE) {
                foreach (Net.Vpc.Upa.Callbacks.IndexDefinitionListener listener in indexes.GetAllListeners(system, index.GetEntity().GetName(), entityTypeListenerId)) {
                    listener.OnPreCreateIndex(@event);
                }
                foreach (Net.Vpc.Upa.Callback callback in GetCallbackPreInvokers(Net.Vpc.Upa.CallbackType.ON_CREATE, Net.Vpc.Upa.ObjectType.INDEX, entity.GetName(), system)) {
                    callback.Invoke(@event);
                }
            } else {
                foreach (Net.Vpc.Upa.Callbacks.IndexDefinitionListener listener in indexes.GetAllListeners(system, index.GetEntity().GetName(), entityTypeListenerId)) {
                    listener.OnCreateIndex(@event);
                }
                foreach (Net.Vpc.Upa.Callback callback in GetCallbackPostInvokers(Net.Vpc.Upa.CallbackType.ON_CREATE, Net.Vpc.Upa.ObjectType.INDEX, entity.GetName(), system)) {
                    callback.Invoke(@event);
                }
            }
        }

        protected internal virtual void FireOnCreateSection(Net.Vpc.Upa.Section section, int position, Net.Vpc.Upa.EventPhase phase) {
            Net.Vpc.Upa.Entity entity = section.GetEntity();
            string entityName = section.GetEntity().GetName();
            string entityTypeId = GetEntityTypeListenerId(section.GetEntity().GetEntityType());
            Net.Vpc.Upa.Callbacks.SectionEvent @event = new Net.Vpc.Upa.Callbacks.SectionEvent(section, section.GetPersistenceUnit(), entity, (Net.Vpc.Upa.Section) section.GetParent(), position, null, -1);
            bool system = entity.GetUserModifiers().Contains(Net.Vpc.Upa.EntityModifier.SYSTEM);
            if (phase == Net.Vpc.Upa.EventPhase.BEFORE) {
                foreach (Net.Vpc.Upa.Callbacks.SectionDefinitionListener listener in sections.GetAllListeners(system, entityName, entityTypeId)) {
                    listener.OnPreCreateSection(@event);
                }
                foreach (Net.Vpc.Upa.Callback callback in GetCallbackPreInvokers(Net.Vpc.Upa.CallbackType.ON_CREATE, Net.Vpc.Upa.ObjectType.SECTION, entity.GetName(), system)) {
                    callback.Invoke(@event);
                }
            } else {
                foreach (Net.Vpc.Upa.Callbacks.SectionDefinitionListener listener in sections.GetAllListeners(system, entityName, entityTypeId)) {
                    listener.OnCreateSection(@event);
                }
                foreach (Net.Vpc.Upa.Callback callback in GetCallbackPostInvokers(Net.Vpc.Upa.CallbackType.ON_CREATE, Net.Vpc.Upa.ObjectType.SECTION, entity.GetName(), system)) {
                    callback.Invoke(@event);
                }
            }
        }

        protected internal virtual void FireOnCreatePackage(Net.Vpc.Upa.Package module, Net.Vpc.Upa.Package parent, int position, Net.Vpc.Upa.EventPhase phase) {
            Net.Vpc.Upa.Callbacks.PackageEvent evt = null;
            System.Collections.Generic.IList<Net.Vpc.Upa.Callbacks.PackageDefinitionListener> interceptorList = packages;
            if (phase == Net.Vpc.Upa.EventPhase.BEFORE) {
                if (!(interceptorList.Count==0)) {
                    evt = new Net.Vpc.Upa.Callbacks.PackageEvent(module, module.GetPersistenceUnit(), parent, position, null, -1);
                    foreach (Net.Vpc.Upa.Callbacks.PackageDefinitionListener listener in interceptorList) {
                        listener.OnPreCreatePackage(evt);
                    }
                }
                System.Collections.Generic.IList<Net.Vpc.Upa.Callback> callbackInvokers = GetCallbackPreInvokers(Net.Vpc.Upa.CallbackType.ON_CREATE, Net.Vpc.Upa.ObjectType.PACKAGE, persistenceUnit.GetName(), DEFAULT_SYSTEM);
                if (!(callbackInvokers.Count==0)) {
                    if (evt == null) {
                        evt = new Net.Vpc.Upa.Callbacks.PackageEvent(module, module.GetPersistenceUnit(), parent, position, null, -1);
                    }
                    foreach (Net.Vpc.Upa.Callback callback in callbackInvokers) {
                        callback.Invoke(evt);
                    }
                }
            } else {
                if (!(interceptorList.Count==0)) {
                    evt = new Net.Vpc.Upa.Callbacks.PackageEvent(module, module.GetPersistenceUnit(), parent, position, null, -1);
                    foreach (Net.Vpc.Upa.Callbacks.PackageDefinitionListener listener in interceptorList) {
                        listener.OnCreatePackage(evt);
                    }
                }
                System.Collections.Generic.IList<Net.Vpc.Upa.Callback> callbackInvokers = GetCallbackPostInvokers(Net.Vpc.Upa.CallbackType.ON_CREATE, Net.Vpc.Upa.ObjectType.PACKAGE, persistenceUnit.GetName(), DEFAULT_SYSTEM);
                if (!(callbackInvokers.Count==0)) {
                    if (evt == null) {
                        evt = new Net.Vpc.Upa.Callbacks.PackageEvent(module, module.GetPersistenceUnit(), parent, position, null, -1);
                    }
                    foreach (Net.Vpc.Upa.Callback callback in callbackInvokers) {
                        callback.Invoke(evt);
                    }
                }
            }
        }

        protected internal virtual void FireOnCreateRelationship(Net.Vpc.Upa.Relationship relation, int position, Net.Vpc.Upa.EventPhase phase) {
            if (phase == Net.Vpc.Upa.EventPhase.BEFORE) {
                Net.Vpc.Upa.Callbacks.RelationshipEvent evt = new Net.Vpc.Upa.Callbacks.RelationshipEvent(relation, relation.GetPersistenceUnit());
                System.Collections.Generic.IList<Net.Vpc.Upa.Callbacks.RelationshipDefinitionListener> interceptorList = GetRelationshipListeners(relation.GetSourceRole().GetEntity().GetName(), relation.GetTargetRole().GetEntity().GetName());
                foreach (Net.Vpc.Upa.Callbacks.RelationshipDefinitionListener listener in interceptorList) {
                    listener.OnPreCreateRelationship(evt);
                }
                foreach (Net.Vpc.Upa.Callback callback in GetCallbackPreInvokers(Net.Vpc.Upa.CallbackType.ON_CREATE, Net.Vpc.Upa.ObjectType.RELATIONSHIP, relation.GetSourceEntity().GetName(), false)) {
                    callback.Invoke(evt);
                }
            } else {
                Net.Vpc.Upa.Callbacks.RelationshipEvent evt = new Net.Vpc.Upa.Callbacks.RelationshipEvent(relation, relation.GetPersistenceUnit());
                System.Collections.Generic.IList<Net.Vpc.Upa.Callbacks.RelationshipDefinitionListener> interceptorList = GetRelationshipListeners(relation.GetSourceRole().GetEntity().GetName(), relation.GetTargetRole().GetEntity().GetName());
                foreach (Net.Vpc.Upa.Callbacks.RelationshipDefinitionListener listener in interceptorList) {
                    listener.OnCreateRelationship(evt);
                }
                foreach (Net.Vpc.Upa.Callback callback in GetCallbackPostInvokers(Net.Vpc.Upa.CallbackType.ON_CREATE, Net.Vpc.Upa.ObjectType.RELATIONSHIP, relation.GetSourceEntity().GetName(), false)) {
                    callback.Invoke(evt);
                }
            }
        }

        protected internal virtual void FireOnDropEntity(Net.Vpc.Upa.Entity entity, int position, Net.Vpc.Upa.EventPhase phase) {
            Net.Vpc.Upa.Callbacks.EntityEvent evt = new Net.Vpc.Upa.Callbacks.EntityEvent(entity, entity.GetPersistenceUnit(), entity.GetParent(), position, null, -1);
            string entityTypeListenerId = GetEntityTypeListenerId(entity.GetEntityType());
            bool system = entity.GetUserModifiers().Contains(Net.Vpc.Upa.EntityModifier.SYSTEM);
            if (phase == Net.Vpc.Upa.EventPhase.BEFORE) {
                foreach (Net.Vpc.Upa.Callbacks.EntityDefinitionListener listener in entities.GetAllListeners(system, entity.GetName(), entityTypeListenerId)) {
                    listener.OnPreDropEntity(evt);
                }
                foreach (Net.Vpc.Upa.Callback callback in GetCallbackPreInvokers(Net.Vpc.Upa.CallbackType.ON_DROP, Net.Vpc.Upa.ObjectType.ENTITY, entity.GetName(), system)) {
                    callback.Invoke(evt);
                }
            } else {
                foreach (Net.Vpc.Upa.Callbacks.EntityDefinitionListener listener in entities.GetAllListeners(system, entity.GetName(), entityTypeListenerId)) {
                    listener.OnDropEntity(evt);
                }
                foreach (Net.Vpc.Upa.Callback callback in GetCallbackPostInvokers(Net.Vpc.Upa.CallbackType.ON_DROP, Net.Vpc.Upa.ObjectType.ENTITY, entity.GetName(), system)) {
                    callback.Invoke(evt);
                }
            }
        }

        protected internal virtual void FireFieldRemoved(Net.Vpc.Upa.Field field, int position, Net.Vpc.Upa.EventPhase phase) {
            Net.Vpc.Upa.Entity entity = field.GetEntity();
            Net.Vpc.Upa.Callbacks.FieldEvent evt = new Net.Vpc.Upa.Callbacks.FieldEvent(field, field.GetPersistenceUnit(), entity, field.GetParent(), position, null, -1);
            string entityName = entity.GetName();
            string entityTypeId = GetEntityTypeListenerId(entity.GetEntityType());
            bool system = entity.GetUserModifiers().Contains(Net.Vpc.Upa.EntityModifier.SYSTEM);
            if (phase == Net.Vpc.Upa.EventPhase.BEFORE) {
                foreach (Net.Vpc.Upa.Callbacks.FieldDefinitionListener listener in fields.GetAllListeners(system, entityName, entityTypeId)) {
                    listener.OnPreDropField(evt);
                }
                foreach (Net.Vpc.Upa.Callback callback in GetCallbackPreInvokers(Net.Vpc.Upa.CallbackType.ON_DROP, Net.Vpc.Upa.ObjectType.FIELD, entity.GetName(), system)) {
                    callback.Invoke(evt);
                }
            } else {
                foreach (Net.Vpc.Upa.Callbacks.FieldDefinitionListener listener in fields.GetAllListeners(system, entityName, entityTypeId)) {
                    listener.OnDropField(evt);
                }
                foreach (Net.Vpc.Upa.Callback callback in GetCallbackPostInvokers(Net.Vpc.Upa.CallbackType.ON_DROP, Net.Vpc.Upa.ObjectType.FIELD, entity.GetName(), system)) {
                    callback.Invoke(evt);
                }
            }
        }

        protected internal virtual void FireOnDropIndex(Net.Vpc.Upa.Index index, int position, Net.Vpc.Upa.EventPhase phase) {
            Net.Vpc.Upa.Callbacks.IndexEvent evt = new Net.Vpc.Upa.Callbacks.IndexEvent(index, index.GetPersistenceUnit());
            Net.Vpc.Upa.Entity entity = index.GetEntity();
            string entityName = index.GetEntity().GetName();
            string entityTypeId = GetEntityTypeListenerId(index.GetEntity().GetEntityType());
            bool system = entity.GetUserModifiers().Contains(Net.Vpc.Upa.EntityModifier.SYSTEM);
            if (phase == Net.Vpc.Upa.EventPhase.BEFORE) {
                foreach (Net.Vpc.Upa.Callbacks.IndexDefinitionListener listener in indexes.GetAllListeners(system, entityName, entityTypeId)) {
                    listener.OnPreDropIndex(evt);
                }
                foreach (Net.Vpc.Upa.Callback callback in GetCallbackPreInvokers(Net.Vpc.Upa.CallbackType.ON_DROP, Net.Vpc.Upa.ObjectType.INDEX, entity.GetName(), system)) {
                    callback.Invoke(evt);
                }
            } else {
                foreach (Net.Vpc.Upa.Callbacks.IndexDefinitionListener listener in indexes.GetAllListeners(system, entityName, entityTypeId)) {
                    listener.OnDropIndex(evt);
                }
                foreach (Net.Vpc.Upa.Callback callback in GetCallbackPostInvokers(Net.Vpc.Upa.CallbackType.ON_DROP, Net.Vpc.Upa.ObjectType.INDEX, entity.GetName(), system)) {
                    callback.Invoke(evt);
                }
            }
        }

        protected internal virtual void FireOnDropSection(Net.Vpc.Upa.Section section, int position, Net.Vpc.Upa.EventPhase phase) {
            Net.Vpc.Upa.Entity entity = section.GetEntity();
            Net.Vpc.Upa.Callbacks.SectionEvent evt = new Net.Vpc.Upa.Callbacks.SectionEvent(section, section.GetPersistenceUnit(), entity, (Net.Vpc.Upa.Section) section.GetParent(), position, null, -1);
            string entityName = section.GetEntity().GetName();
            string entityTypeId = GetEntityTypeListenerId(section.GetEntity().GetEntityType());
            bool system = entity.GetUserModifiers().Contains(Net.Vpc.Upa.EntityModifier.SYSTEM);
            if (phase == Net.Vpc.Upa.EventPhase.BEFORE) {
                foreach (Net.Vpc.Upa.Callbacks.SectionDefinitionListener listener in sections.GetAllListeners(system, entityName, entityTypeId)) {
                    listener.OnPreDropSection(evt);
                }
                foreach (Net.Vpc.Upa.Callback callback in GetCallbackPreInvokers(Net.Vpc.Upa.CallbackType.ON_DROP, Net.Vpc.Upa.ObjectType.SECTION, entity.GetName(), system)) {
                    callback.Invoke(evt);
                }
            } else {
                foreach (Net.Vpc.Upa.Callbacks.SectionDefinitionListener listener in sections.GetAllListeners(system, entityName, entityTypeId)) {
                    listener.OnDropSection(evt);
                }
                foreach (Net.Vpc.Upa.Callback callback in GetCallbackPostInvokers(Net.Vpc.Upa.CallbackType.ON_DROP, Net.Vpc.Upa.ObjectType.SECTION, entity.GetName(), system)) {
                    callback.Invoke(evt);
                }
            }
        }

        protected internal virtual void FireOnDropPackage(Net.Vpc.Upa.Package module, int position, Net.Vpc.Upa.EventPhase phase) {
            Net.Vpc.Upa.Callbacks.PackageEvent evt = new Net.Vpc.Upa.Callbacks.PackageEvent(module, module.GetPersistenceUnit(), module.GetParent(), position, null, -1);
            System.Collections.Generic.IList<Net.Vpc.Upa.Callbacks.PackageDefinitionListener> interceptorList = packages;
            if (phase == Net.Vpc.Upa.EventPhase.BEFORE) {
                foreach (Net.Vpc.Upa.Callbacks.PackageDefinitionListener listener in interceptorList) {
                    listener.OnPreDropPackage(evt);
                }
                foreach (Net.Vpc.Upa.Callback callback in GetCallbackPreInvokers(Net.Vpc.Upa.CallbackType.ON_DROP, Net.Vpc.Upa.ObjectType.PACKAGE, module.GetPersistenceUnit().GetName(), DEFAULT_SYSTEM)) {
                    callback.Invoke(evt);
                }
            } else {
                foreach (Net.Vpc.Upa.Callbacks.PackageDefinitionListener listener in interceptorList) {
                    listener.OnDropPackage(evt);
                }
                foreach (Net.Vpc.Upa.Callback callback in GetCallbackPostInvokers(Net.Vpc.Upa.CallbackType.ON_DROP, Net.Vpc.Upa.ObjectType.PACKAGE, module.GetPersistenceUnit().GetName(), DEFAULT_SYSTEM)) {
                    callback.Invoke(evt);
                }
            }
        }

        protected internal virtual void FireOnDropRelationship(Net.Vpc.Upa.Relationship relation, int position, Net.Vpc.Upa.EventPhase phase) {
            Net.Vpc.Upa.Callbacks.RelationshipEvent evt = new Net.Vpc.Upa.Callbacks.RelationshipEvent(relation, relation.GetPersistenceUnit());
            if (phase == Net.Vpc.Upa.EventPhase.BEFORE) {
                foreach (Net.Vpc.Upa.Callbacks.RelationshipDefinitionListener listener in GetRelationshipListeners(relation.GetSourceRole().GetEntity().GetName(), relation.GetTargetRole().GetEntity().GetName())) {
                    listener.OnPreDropRelationship(evt);
                }
                foreach (Net.Vpc.Upa.Callback callback in GetCallbackPreInvokers(Net.Vpc.Upa.CallbackType.ON_DROP, Net.Vpc.Upa.ObjectType.RELATIONSHIP, relation.GetSourceRole().GetEntity().GetName(), relation.GetSourceRole().GetEntity().IsSystem())) {
                    callback.Invoke(evt);
                }
            } else {
                foreach (Net.Vpc.Upa.Callbacks.RelationshipDefinitionListener listener in GetRelationshipListeners(relation.GetSourceRole().GetEntity().GetName(), relation.GetTargetRole().GetEntity().GetName())) {
                    listener.OnDropRelationship(evt);
                }
                foreach (Net.Vpc.Upa.Callback callback in GetCallbackPostInvokers(Net.Vpc.Upa.CallbackType.ON_DROP, Net.Vpc.Upa.ObjectType.RELATIONSHIP, relation.GetSourceRole().GetEntity().GetName(), relation.GetSourceRole().GetEntity().IsSystem())) {
                    callback.Invoke(evt);
                }
            }
        }

        protected internal virtual System.Collections.Generic.IList<Net.Vpc.Upa.Callbacks.RelationshipDefinitionListener> GetRelationshipListeners(string entityName1, string entityName2) {
            System.Collections.Generic.List<Net.Vpc.Upa.Callbacks.RelationshipDefinitionListener> all = new System.Collections.Generic.List<Net.Vpc.Upa.Callbacks.RelationshipDefinitionListener>();
            Net.Vpc.Upa.Impl.Util.PlatformUtils.AddAll<Net.Vpc.Upa.Callbacks.RelationshipDefinitionListener>(all, relationships.ToArrayConstrainted(false, null, new Net.Vpc.Upa.Callbacks.RelationshipDefinitionListener[0]));
            if (entityName1 != null) {
                Net.Vpc.Upa.Impl.Util.PlatformUtils.AddAll<Net.Vpc.Upa.Callbacks.RelationshipDefinitionListener>(all, relationships.ToArrayConstrainted(false, entityName1, new Net.Vpc.Upa.Callbacks.RelationshipDefinitionListener[0]));
            }
            if (entityName2 != null) {
                if (!entityName2.Equals(entityName1)) {
                    Net.Vpc.Upa.Impl.Util.PlatformUtils.AddAll<Net.Vpc.Upa.Callbacks.RelationshipDefinitionListener>(all, relationships.ToArrayConstrainted(false, entityName2, new Net.Vpc.Upa.Callbacks.RelationshipDefinitionListener[0]));
                }
            }
            return all;
        }

        private string GetEntityTypeListenerId(System.Type entityType) {
            return entityType == null ? null : "private:" + (entityType).FullName;
        }

        public virtual void AddDefinitionListener(System.Type entityType, Net.Vpc.Upa.Callbacks.DefinitionListener definitionListener, bool trackSystem) {
            AddDefinitionListener(GetEntityTypeListenerId(entityType), definitionListener, trackSystem);
        }

        public virtual void AddDefinitionListener(string entityName, Net.Vpc.Upa.Callbacks.DefinitionListener definitionListener, bool trackSystem) {
            bool supported = false;
            if (definitionListener is Net.Vpc.Upa.Callbacks.FieldDefinitionListener) {
                supported = true;
                fields.Add(trackSystem, entityName, (Net.Vpc.Upa.Callbacks.FieldDefinitionListener) definitionListener);
            }
            if (definitionListener is Net.Vpc.Upa.Callbacks.SectionDefinitionListener) {
                supported = true;
                sections.Add(trackSystem, entityName, (Net.Vpc.Upa.Callbacks.SectionDefinitionListener) definitionListener);
            }
            if (definitionListener is Net.Vpc.Upa.Callbacks.EntityDefinitionListener) {
                supported = true;
                entities.Add(trackSystem, entityName, (Net.Vpc.Upa.Callbacks.EntityDefinitionListener) definitionListener);
            }
            if (definitionListener is Net.Vpc.Upa.Callbacks.IndexDefinitionListener) {
                supported = true;
                indexes.Add(trackSystem, entityName, (Net.Vpc.Upa.Callbacks.IndexDefinitionListener) definitionListener);
            }
            if (definitionListener is Net.Vpc.Upa.Callbacks.RelationshipDefinitionListener) {
                supported = true;
                relationships.Add(false, entityName, (Net.Vpc.Upa.Callbacks.RelationshipDefinitionListener) definitionListener);
            }
            if (definitionListener is Net.Vpc.Upa.Callbacks.TriggerDefinitionListener) {
                supported = true;
                entityTriggers.Add(trackSystem, entityName, (Net.Vpc.Upa.Callbacks.TriggerDefinitionListener) definitionListener);
            }
            if (definitionListener is Net.Vpc.Upa.Callbacks.PackageDefinitionListener) {
                supported = true;
                packages.Add((Net.Vpc.Upa.Callbacks.PackageDefinitionListener) definitionListener);
            }
            if (!supported) {
                throw new System.ArgumentException ("Unsupported DefinitionListener. See Documentation for detailed information.");
            }
        }

        public virtual void RemoveDefinitionListener(System.Type entityType, Net.Vpc.Upa.Callbacks.DefinitionListener definitionListener) {
            RemoveDefinitionListener(GetEntityTypeListenerId(entityType), definitionListener);
        }

        public virtual void RemoveDefinitionListener(string entityName, Net.Vpc.Upa.Callbacks.DefinitionListener definitionListener) {
            bool supported = false;
            if (definitionListener is Net.Vpc.Upa.Callbacks.FieldDefinitionListener) {
                supported = true;
                fields.Remove(entityName, (Net.Vpc.Upa.Callbacks.FieldDefinitionListener) definitionListener);
            }
            if (definitionListener is Net.Vpc.Upa.Callbacks.SectionDefinitionListener) {
                supported = true;
                sections.Remove(entityName, (Net.Vpc.Upa.Callbacks.SectionDefinitionListener) definitionListener);
            }
            if (definitionListener is Net.Vpc.Upa.Callbacks.EntityDefinitionListener) {
                supported = true;
                entities.Remove(entityName, (Net.Vpc.Upa.Callbacks.EntityDefinitionListener) definitionListener);
            }
            if (definitionListener is Net.Vpc.Upa.Callbacks.IndexDefinitionListener) {
                supported = true;
                indexes.Remove(entityName, (Net.Vpc.Upa.Callbacks.IndexDefinitionListener) definitionListener);
            }
            if (definitionListener is Net.Vpc.Upa.Callbacks.RelationshipDefinitionListener) {
                supported = true;
                relationships.Remove(entityName, (Net.Vpc.Upa.Callbacks.RelationshipDefinitionListener) definitionListener);
            }
            if (definitionListener is Net.Vpc.Upa.Callbacks.PackageDefinitionListener) {
                supported = true;
                packages.Remove((Net.Vpc.Upa.Callbacks.PackageDefinitionListener) definitionListener);
            }
            if (!supported) {
                throw new System.ArgumentException ("Unsupported DefinitionListener. See Documentation for detailed information.");
            }
        }

        public virtual void AddHandlers(Net.Vpc.Upa.UPAObject @object) {
            @object.AddObjectListener(this);
        }

        protected internal virtual void RemoveHandlers(Net.Vpc.Upa.UPAObject @object) {
            @object.RemoveObjectListener(this);
        }

        public virtual void FireOnModelChanged(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event, Net.Vpc.Upa.EventPhase phase) {
            if (phase == Net.Vpc.Upa.EventPhase.BEFORE) {
                foreach (Net.Vpc.Upa.Callbacks.PersistenceUnitListener listener in persistenceUnitListeners) {
                    listener.OnPreModelChanged(@event);
                }
                foreach (Net.Vpc.Upa.Callback invoker in GetCallbackPreInvokers(Net.Vpc.Upa.CallbackType.ON_MODEL_CHANGED, Net.Vpc.Upa.ObjectType.PERSISTENCE_UNIT, @event.GetPersistenceUnit().GetName(), DEFAULT_SYSTEM)) {
                    invoker.Invoke(@event);
                }
            } else {
                foreach (Net.Vpc.Upa.Callbacks.PersistenceUnitListener listener in persistenceUnitListeners) {
                    listener.OnModelChanged(@event);
                }
                foreach (Net.Vpc.Upa.Callback invoker in GetCallbackPreInvokers(Net.Vpc.Upa.CallbackType.ON_MODEL_CHANGED, Net.Vpc.Upa.ObjectType.PERSISTENCE_UNIT, @event.GetPersistenceUnit().GetName(), DEFAULT_SYSTEM)) {
                    invoker.Invoke(@event);
                }
            }
        }

        public virtual void FireOnStorageChanged(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event, Net.Vpc.Upa.EventPhase phase) {
            if (phase == Net.Vpc.Upa.EventPhase.BEFORE) {
                foreach (Net.Vpc.Upa.Callbacks.PersistenceUnitListener listener in persistenceUnitListeners) {
                    listener.OnPreStorageChanged(@event);
                }
                foreach (Net.Vpc.Upa.Callback invoker in GetCallbackPreInvokers(Net.Vpc.Upa.CallbackType.ON_STORAGE_CHANGED, Net.Vpc.Upa.ObjectType.PERSISTENCE_UNIT, @event.GetPersistenceUnit().GetName(), DEFAULT_SYSTEM)) {
                    invoker.Invoke(@event);
                }
            } else {
                foreach (Net.Vpc.Upa.Callbacks.PersistenceUnitListener listener in persistenceUnitListeners) {
                    listener.OnStorageChanged(@event);
                }
                foreach (Net.Vpc.Upa.Callback invoker in GetCallbackPreInvokers(Net.Vpc.Upa.CallbackType.ON_STORAGE_CHANGED, Net.Vpc.Upa.ObjectType.PERSISTENCE_UNIT, @event.GetPersistenceUnit().GetName(), DEFAULT_SYSTEM)) {
                    invoker.Invoke(@event);
                }
            }
        }

        public virtual void FireOnClear(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event, Net.Vpc.Upa.EventPhase phase) {
            if (phase == Net.Vpc.Upa.EventPhase.BEFORE) {
                foreach (Net.Vpc.Upa.Callbacks.PersistenceUnitListener listener in persistenceUnitListeners) {
                    listener.OnPreClear(@event);
                }
                foreach (Net.Vpc.Upa.Callback invoker in GetCallbackPreInvokers(Net.Vpc.Upa.CallbackType.ON_CLEAR, Net.Vpc.Upa.ObjectType.PERSISTENCE_UNIT, @event.GetPersistenceUnit().GetName(), DEFAULT_SYSTEM)) {
                    invoker.Invoke(@event);
                }
            } else {
                foreach (Net.Vpc.Upa.Callbacks.PersistenceUnitListener listener in persistenceUnitListeners) {
                    listener.OnClear(@event);
                }
                foreach (Net.Vpc.Upa.Callback invoker in GetCallbackPreInvokers(Net.Vpc.Upa.CallbackType.ON_CLEAR, Net.Vpc.Upa.ObjectType.PERSISTENCE_UNIT, @event.GetPersistenceUnit().GetName(), DEFAULT_SYSTEM)) {
                    invoker.Invoke(@event);
                }
            }
        }

        public virtual void FireOnClose(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event, Net.Vpc.Upa.EventPhase phase) {
            if (phase == Net.Vpc.Upa.EventPhase.BEFORE) {
                foreach (Net.Vpc.Upa.Callbacks.PersistenceUnitListener listener in persistenceUnitListeners) {
                    listener.OnPreClose(@event);
                }
                foreach (Net.Vpc.Upa.Callback invoker in GetCallbackPreInvokers(Net.Vpc.Upa.CallbackType.ON_CLOSE, Net.Vpc.Upa.ObjectType.PERSISTENCE_UNIT, @event.GetPersistenceUnit().GetName(), DEFAULT_SYSTEM)) {
                    invoker.Invoke(@event);
                }
            } else {
                foreach (Net.Vpc.Upa.Callbacks.PersistenceUnitListener listener in persistenceUnitListeners) {
                    listener.OnClose(@event);
                }
                foreach (Net.Vpc.Upa.Callback invoker in GetCallbackPreInvokers(Net.Vpc.Upa.CallbackType.ON_CLOSE, Net.Vpc.Upa.ObjectType.PERSISTENCE_UNIT, @event.GetPersistenceUnit().GetName(), DEFAULT_SYSTEM)) {
                    invoker.Invoke(@event);
                }
            }
        }

        public virtual void FireOnReset(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event, Net.Vpc.Upa.EventPhase phase) {
            if (phase == Net.Vpc.Upa.EventPhase.BEFORE) {
                foreach (Net.Vpc.Upa.Callbacks.PersistenceUnitListener listener in persistenceUnitListeners) {
                    listener.OnPreReset(@event);
                }
                foreach (Net.Vpc.Upa.Callback invoker in GetCallbackPreInvokers(Net.Vpc.Upa.CallbackType.ON_RESET, Net.Vpc.Upa.ObjectType.PERSISTENCE_UNIT, @event.GetPersistenceUnit().GetName(), DEFAULT_SYSTEM)) {
                    invoker.Invoke(@event);
                }
            } else {
                foreach (Net.Vpc.Upa.Callbacks.PersistenceUnitListener listener in persistenceUnitListeners) {
                    listener.OnReset(@event);
                }
                foreach (Net.Vpc.Upa.Callback invoker in GetCallbackPreInvokers(Net.Vpc.Upa.CallbackType.ON_RESET, Net.Vpc.Upa.ObjectType.PERSISTENCE_UNIT, @event.GetPersistenceUnit().GetName(), DEFAULT_SYSTEM)) {
                    invoker.Invoke(@event);
                }
            }
        }

        public virtual void FireOnStart(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event, Net.Vpc.Upa.EventPhase phase) {
            if (phase == Net.Vpc.Upa.EventPhase.BEFORE) {
                foreach (Net.Vpc.Upa.Callbacks.PersistenceUnitListener listener in persistenceUnitListeners) {
                    listener.OnPreStart(@event);
                }
                foreach (Net.Vpc.Upa.Callback invoker in GetCallbackPreInvokers(Net.Vpc.Upa.CallbackType.ON_START, Net.Vpc.Upa.ObjectType.PERSISTENCE_UNIT, @event.GetPersistenceUnit().GetName(), DEFAULT_SYSTEM)) {
                    invoker.Invoke(@event);
                }
            } else {
                foreach (Net.Vpc.Upa.Callbacks.PersistenceUnitListener listener in persistenceUnitListeners) {
                    listener.OnStart(@event);
                }
                foreach (Net.Vpc.Upa.Callback invoker in GetCallbackPreInvokers(Net.Vpc.Upa.CallbackType.ON_START, Net.Vpc.Upa.ObjectType.PERSISTENCE_UNIT, @event.GetPersistenceUnit().GetName(), DEFAULT_SYSTEM)) {
                    invoker.Invoke(@event);
                }
            }
        }

        public virtual Net.Vpc.Upa.Impl.Util.CallbackManager GetCallbackManager() {
            return callbackManager;
        }

        public virtual void AddCallback(Net.Vpc.Upa.Callback callback) {
            callbackManager.AddCallback(callback);
        }

        public virtual void RemoveCallback(Net.Vpc.Upa.Callback callback) {
            callbackManager.RemoveCallback(callback);
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Callback> GetCallbackPreInvokers(Net.Vpc.Upa.CallbackType callbackType, Net.Vpc.Upa.ObjectType objectType, string nameFilter, bool system) {
            System.Collections.Generic.IList<Net.Vpc.Upa.Callback> allCallbacks = callbackManager.GetCallbacks(callbackType, objectType, nameFilter, system, Net.Vpc.Upa.EventPhase.BEFORE);
            Net.Vpc.Upa.Impl.FwkConvertUtils.ListAddRange(allCallbacks, new System.Collections.Generic.List<Net.Vpc.Upa.Callback>(persistenceUnit.GetPersistenceGroup().GetCallbacks(callbackType, objectType, nameFilter, system, Net.Vpc.Upa.EventPhase.BEFORE)));
            Net.Vpc.Upa.Impl.FwkConvertUtils.ListAddRange(allCallbacks, new System.Collections.Generic.List<Net.Vpc.Upa.Callback>(persistenceUnit.GetPersistenceGroup().GetContext().GetCallbacks(callbackType, objectType, nameFilter, system, Net.Vpc.Upa.EventPhase.BEFORE)));
            return allCallbacks;
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Callback> GetCallbackPostInvokers(Net.Vpc.Upa.CallbackType callbackType, Net.Vpc.Upa.ObjectType objectType, string nameFilter, bool system) {
            System.Collections.Generic.IList<Net.Vpc.Upa.Callback> allCallbacks = callbackManager.GetCallbacks(callbackType, objectType, nameFilter, system, Net.Vpc.Upa.EventPhase.AFTER);
            Net.Vpc.Upa.Impl.FwkConvertUtils.ListAddRange(allCallbacks, new System.Collections.Generic.List<Net.Vpc.Upa.Callback>(persistenceUnit.GetPersistenceGroup().GetCallbacks(callbackType, objectType, nameFilter, system, Net.Vpc.Upa.EventPhase.AFTER)));
            Net.Vpc.Upa.Impl.FwkConvertUtils.ListAddRange(allCallbacks, new System.Collections.Generic.List<Net.Vpc.Upa.Callback>(persistenceUnit.GetPersistenceGroup().GetContext().GetCallbacks(callbackType, objectType, nameFilter, system, Net.Vpc.Upa.EventPhase.AFTER)));
            return allCallbacks;
        }

        public virtual Net.Vpc.Upa.Callback[] GetCurrentCallbacks(Net.Vpc.Upa.CallbackType callbackType, Net.Vpc.Upa.ObjectType objectType, string nameFilter, bool system, Net.Vpc.Upa.EventPhase phase) {
            System.Collections.Generic.IList<Net.Vpc.Upa.Callback> callbacks = callbackManager.GetCallbacks(callbackType, objectType, nameFilter, system, phase);
            return callbacks.ToArray();
        }
    }
}
