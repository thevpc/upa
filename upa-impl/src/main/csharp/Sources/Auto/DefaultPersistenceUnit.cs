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
namespace Net.Vpc.Upa.Impl
{


    public class DefaultPersistenceUnit : Net.Vpc.Upa.PersistenceUnit {

        public const int STATUS_INITIALIZING = 0;

        private static readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.Vpc.Upa.Impl.DefaultPersistenceUnit)).FullName);

        public static readonly Net.Vpc.Upa.NamingStrategy CASE_SENSITIVE_COMPARATOR = new Net.Vpc.Upa.Impl.CaseSensitiveNamingStrategy();

        public static readonly Net.Vpc.Upa.NamingStrategy CASE_INSENSITIVE_COMPARATOR = new Net.Vpc.Upa.Impl.CaseInsensitiveNamingStrategy();

        public const int COMMIT_ORDER_ENTITY = 10;

        public const int COMMIT_ORDER_FIELD = 20;

        public const int COMMIT_ORDER_TRIGGER = 20;

        public const int COMMIT_ORDER_RELATION = 20;

        public const int COMMIT_ORDER_INDEX = 20;

        private Net.Vpc.Upa.Properties properties;

        private Net.Vpc.Upa.Properties systemParameters;

        private Net.Vpc.Upa.Persistence.ConnectionProfile connectionProfile;

        private System.Guid privateUUID = System.Guid.NewGuid();

        private Net.Vpc.Upa.Impl.Config.EntityDescriptorResolver entityDescriptorResolver;

        private bool triggersEnabled = true;

        private Net.Vpc.Upa.Types.I18NString title = new Net.Vpc.Upa.Types.I18NString("PersistenceUnitFilter.title");

        private Net.Vpc.Upa.NamingStrategy namingStrategy;

        private Net.Vpc.Upa.Persistence.PersistenceStore persistenceStore;

        private bool lastStartSucceeded;

        private bool readOnly;

        private string name;

        private bool initCalled;

        private string persistenceName;

        private Net.Vpc.Upa.PersistenceGroup persistenceGroup;

        private bool structureModification;

        private bool autoStart;

        private bool started;

        private bool starting;

        private bool closed;

        private bool autoScan = true;

        private Net.Vpc.Upa.PropertyChangeSupport propertyChangeSupport;

        private Net.Vpc.Upa.Impl.Event.PersistenceUnitListenerManager persistenceUnitListenerManager;

        private Net.Vpc.Upa.Impl.ObjectRegistrationModel registrationModel;

        private Net.Vpc.Upa.Persistence.DBConfigModel dbConfigModel;

        private int status = STATUS_INITIALIZING;

        private bool askOnCheckCreatedPersistenceUnit = true;

        private Net.Vpc.Upa.I18NStringStrategy i18NStringStrategy;

        private Net.Vpc.Upa.Persistence.PersistenceStoreFactory persistenceStoreFactory;

        private System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.QLParameterProcessor> parameterProcessors = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.QLParameterProcessor>();

        public System.Collections.Generic.IList<Net.Vpc.Upa.Impl.OnHoldCommitAction> commitModelActions = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.OnHoldCommitAction>();

        public System.Collections.Generic.IList<Net.Vpc.Upa.Impl.OnHoldCommitAction> commitStorageActions = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.OnHoldCommitAction>();

        private Net.Vpc.Upa.Persistence.TransactionManagerFactory transactionManagerFactory;

        private Net.Vpc.Upa.Types.DataTypeTransformFactory typeTransformFactory;

        private Net.Vpc.Upa.TransactionManager transactionManager;

        private Net.Vpc.Upa.Bulk.ImportExportManager importExportManager;

        private Net.Vpc.Upa.Persistence.PersistenceNameConfig persistenceNameConfig = new Net.Vpc.Upa.Persistence.PersistenceNameConfig(Net.Vpc.Upa.Persistence.UPAContextConfig.XML_ORDER);

        private System.Collections.Generic.IList<Net.Vpc.Upa.Config.ScanFilter> filters = new System.Collections.Generic.List<Net.Vpc.Upa.Config.ScanFilter>();

        private System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.ConnectionConfig> connectionConfigs = new System.Collections.Generic.List<Net.Vpc.Upa.Persistence.ConnectionConfig>();

        private System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.ConnectionConfig> rootConnectionConfigs = new System.Collections.Generic.List<Net.Vpc.Upa.Persistence.ConnectionConfig>();

        private Net.Vpc.Upa.Impl.Uql.DefaultExpressionManager expressionManager;

        private Net.Vpc.Upa.Package defaultPackage;

        private Net.Vpc.Upa.Impl.DefaultPersistenceUnit sessionAwarePU;

        private Net.Vpc.Upa.Impl.Config.Decorations.DecorationRepository decorationRepository;

        private int triggerAnonymousNameIndex = 1;

        private System.Collections.Generic.IDictionary<string , object> defaultHints;

        public DefaultPersistenceUnit() {
        }

        public virtual bool IsAutoScan() {
            return autoScan;
        }

        public virtual void SetAutoScan(bool autoScan) {
            this.autoScan = autoScan;
        }

        public virtual void Init(string name, Net.Vpc.Upa.PersistenceGroup persistenceGroup) {
            properties = new Net.Vpc.Upa.Impl.DefaultProperties(GetSystemParameters());
            if (initCalled) {
                throw new Net.Vpc.Upa.Exceptions.UPAException("PersistenceUnitAlreadyInitialized");
            } else {
                initCalled = true;
            }
            this.name = name;
            this.decorationRepository = new Net.Vpc.Upa.Impl.Config.Decorations.DefaultDecorationRepository(name + "-PURepo", true);
            this.persistenceGroup = persistenceGroup;
            this.persistenceStore = null;
            this.namingStrategy = CASE_INSENSITIVE_COMPARATOR;
            this.propertyChangeSupport = new Net.Vpc.Upa.PropertyChangeSupport(this);
            this.entityDescriptorResolver = new Net.Vpc.Upa.Impl.Config.EntityDescriptorResolver(this, decorationRepository);
            this.expressionManager = new Net.Vpc.Upa.Impl.Uql.DefaultExpressionManager(this);
            this.registrationModel = new Net.Vpc.Upa.Impl.DefaultPersistenceUnitRegistrationModel(this);
            this.persistenceUnitListenerManager = new Net.Vpc.Upa.Impl.Event.PersistenceUnitListenerManager(this, registrationModel, decorationRepository);
            this.typeTransformFactory = GetFactory().CreateObject<Net.Vpc.Upa.Types.DataTypeTransformFactory>(typeof(Net.Vpc.Upa.Types.DataTypeTransformFactory));
            PostponeCommit(new Net.Vpc.Upa.Impl.CreateStorageOnHoldCommitAction());
            AddDefinitionListener(new Net.Vpc.Upa.Impl.PostponeCommitHandler(), true);
            AddPersistenceUnitListener(new Net.Vpc.Upa.Impl.UPASystemEntitiesTrigger(this));
            //add default MD5 function
            GetExpressionManager().AddFunction("MD5", Net.Vpc.Upa.Types.StringType.UNLIMITED, new Net.Vpc.Upa.Impl.Eval.Functions.PasswordQLFunction(Net.Vpc.Upa.Impl.Transform.DefaultPasswordStrategy.MD5));
            GetExpressionManager().AddFunction("SHA1", Net.Vpc.Upa.Types.StringType.UNLIMITED, new Net.Vpc.Upa.Impl.Eval.Functions.PasswordQLFunction(Net.Vpc.Upa.Impl.Transform.DefaultPasswordStrategy.SHA1));
            GetExpressionManager().AddFunction("SHA256", Net.Vpc.Upa.Types.StringType.UNLIMITED, new Net.Vpc.Upa.Impl.Eval.Functions.PasswordQLFunction(Net.Vpc.Upa.Impl.Transform.DefaultPasswordStrategy.SHA256));
            GetExpressionManager().AddFunction("HASH", Net.Vpc.Upa.Types.StringType.UNLIMITED, new Net.Vpc.Upa.Impl.Eval.Functions.PasswordQLFunction(Net.Vpc.Upa.Impl.Transform.DefaultPasswordStrategy.MD5));
        }

        private void Invalidate() {
        }


        public virtual Net.Vpc.Upa.Package AddPackage(string name, string parentPath) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return AddPackage(name, parentPath, -1);
        }


        public virtual Net.Vpc.Upa.Package AddPackage(string name, string parentPath, int index) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (name == null) {
                throw new System.NullReferenceException();
            }
            if (name.Contains("/")) {
                throw new Net.Vpc.Upa.Exceptions.IllegalArgumentException("Name cannot contain '/'");
            }
            string[] canonicalPathArray = Net.Vpc.Upa.Impl.Util.UPAUtils.GetCanonicalPathArray(parentPath);
            Net.Vpc.Upa.Package parentModule = null;
            foreach (string n in canonicalPathArray) {
                Net.Vpc.Upa.Package next = null;
                if (parentModule == null) {
                    next = GetPackage(n);
                } else {
                    next = parentModule.GetPart(n);
                }
                parentModule = next;
            }
            Net.Vpc.Upa.Package currentModule = GetFactory().CreateObject<Net.Vpc.Upa.Package>(typeof(Net.Vpc.Upa.Package));
            Net.Vpc.Upa.Impl.Util.UPAUtils.PreparePreAdd(this, null, currentModule, name);
            if (parentModule == null) {
                GetPackage(null).AddPart(currentModule, index);
            } else {
                parentModule.AddPart(currentModule, index);
            }
            Invalidate();
            return currentModule;
        }


        public virtual Net.Vpc.Upa.Package AddPackage(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return AddPackage(name, null, -1);
        }


        public virtual Net.Vpc.Upa.Package AddPackage(string name, int index) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return AddPackage(name, null, index);
        }

        public virtual Net.Vpc.Upa.Package GetPackage(string path) {
            return GetPackage(path, Net.Vpc.Upa.MissingStrategy.ERROR);
        }

        public virtual Net.Vpc.Upa.Package GetDefaulPackage() {
            if (defaultPackage == null) {
                //should return default package
                Net.Vpc.Upa.Package currentModule = GetFactory().CreateObject<Net.Vpc.Upa.Package>(typeof(Net.Vpc.Upa.Package));
                Net.Vpc.Upa.Impl.Util.UPAUtils.Prepare(this, currentModule, "");
                persistenceUnitListenerManager.AddHandlers(currentModule);
                defaultPackage = currentModule;
            }
            return defaultPackage;
        }

        public virtual Net.Vpc.Upa.Package GetPackage(string path, Net.Vpc.Upa.MissingStrategy missingStrategy) {
            if (path == null) {
                return GetDefaulPackage();
            }
            string[] canonicalPathArray = Net.Vpc.Upa.Impl.Util.UPAUtils.GetCanonicalPathArray(path);
            if (canonicalPathArray.Length == 0) {
                return GetDefaulPackage();
            }
            Net.Vpc.Upa.Package module = null;
            foreach (string n in canonicalPathArray) {
                Net.Vpc.Upa.Package next = null;
                if (module == null) {
                    foreach (Net.Vpc.Upa.PersistenceUnitPart persistenceUnitItem in GetDefaulPackage().GetParts()) {
                        if (persistenceUnitItem is Net.Vpc.Upa.Package) {
                            if (persistenceUnitItem.GetName().Equals(n)) {
                                next = (Net.Vpc.Upa.Package) persistenceUnitItem;
                                break;
                            }
                        }
                    }
                    if (next == null) {
                        switch(missingStrategy) {
                            case Net.Vpc.Upa.MissingStrategy.ERROR:
                                {
                                    throw new Net.Vpc.Upa.Exceptions.NoSuchPackageException(path, null);
                                }
                            case Net.Vpc.Upa.MissingStrategy.CREATE:
                                {
                                    next = AddPackage(n, null);
                                    break;
                                }
                            case Net.Vpc.Upa.MissingStrategy.NULL:
                                {
                                    return null;
                                }
                            default:
                                {
                                    throw new System.Exception();
                                }
                        }
                    }
                } else {
                    try {
                        next = module.GetPart(n);
                    } catch (Net.Vpc.Upa.Exceptions.NoSuchPackageException e) {
                        switch(missingStrategy) {
                            case Net.Vpc.Upa.MissingStrategy.ERROR:
                                {
                                    throw new Net.Vpc.Upa.Exceptions.NoSuchPackageException(path, e);
                                }
                            case Net.Vpc.Upa.MissingStrategy.CREATE:
                                {
                                    next = AddPackage(n, module.GetPath());
                                    break;
                                }
                            case Net.Vpc.Upa.MissingStrategy.NULL:
                                {
                                    return null;
                                }
                            default:
                                {
                                    throw new System.Exception();
                                }
                        }
                    }
                }
                module = next;
            }
            return module;
        }


        public virtual bool IsReadOnly() {
            return readOnly;
        }


        public virtual void SetReadOnly(bool enable) {
            readOnly = enable;
            if (persistenceStore != null) {
                persistenceStore.SetReadOnly(enable);
            }
        }


        public virtual string GetName() {
            return name;
        }


        public virtual bool IsLastStartSucceeded() {
            return lastStartSucceeded;
        }


        public virtual void SetLastStartSucceeded(bool success) {
            this.lastStartSucceeded = success;
        }

        protected internal virtual void CommitModelChanges() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            persistenceUnitListenerManager.FireOnModelChanged(new Net.Vpc.Upa.Callbacks.PersistenceUnitEvent(this, persistenceGroup, Net.Vpc.Upa.EventPhase.BEFORE));
            foreach (Net.Vpc.Upa.Entity entity in GetEntities()) {
                entity.CommitModelChanges();
                System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.EntityExtension> extensionList = entity.GetExtensions();
                foreach (Net.Vpc.Upa.Persistence.EntityExtension entityExtension in extensionList) {
                    entityExtension.CommitModelChanges();
                }
            }
            foreach (Net.Vpc.Upa.Index index in GetIndexes()) {
                index.CommitModelChanges();
            }
            //        cache_relationsByName.clear();
            foreach (Net.Vpc.Upa.Relationship r in GetRelationships()) {
                r.CommitModelChanged();
            }
            //            cache_relationsByName.put(r.getName(), r);
            foreach (Net.Vpc.Upa.Entity entity in GetEntities()) {
                if (entity is Net.Vpc.Upa.Impl.DefaultEntity) {
                    ((Net.Vpc.Upa.Impl.DefaultEntity) entity).CommitExpressionModelChanges();
                }
            }
            System.Collections.Generic.IList<Net.Vpc.Upa.Impl.OnHoldCommitAction> model = commitModelActions;
            if ((model).Count > 0) {
                Net.Vpc.Upa.Impl.FwkConvertUtils.ListSort(model, null);
                foreach (Net.Vpc.Upa.Impl.OnHoldCommitAction next in model) {
                    next.CommitModel();
                    commitStorageActions.Add(next);
                }
                model.Clear();
                persistenceUnitListenerManager.FireOnModelChanged(new Net.Vpc.Upa.Callbacks.PersistenceUnitEvent(this, persistenceGroup, Net.Vpc.Upa.EventPhase.AFTER));
            }
        }


        public virtual bool IsRecurseDelete() {
            return true;
        }


        public virtual bool IsLockablePersistenceUnit() {
            return false;
        }


        public virtual void SetCaseSensitive(bool enable) {
            namingStrategy = enable ? CASE_SENSITIVE_COMPARATOR : CASE_INSENSITIVE_COMPARATOR;
        }


        public virtual bool IsCaseSensitive() {
            return namingStrategy == CASE_SENSITIVE_COMPARATOR;
        }


        public Net.Vpc.Upa.NamingStrategy GetNamingStrategy() {
            return namingStrategy;
        }

        public virtual Net.Vpc.Upa.Persistence.PersistenceStore GetPersistenceStore() {
            return persistenceStore;
        }

        /**
             * @param triggerName
             * @param interceptor
             * @return created Trigger or null if creation is postponed
             * @throws UPAException
             */

        public virtual void AddTrigger(string triggerName, Net.Vpc.Upa.Callbacks.EntityInterceptor interceptor, string entityNamePattern, bool system) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Impl.Config.EntityConfiguratorProcessor.ConfigureTracker(this, new Net.Vpc.Upa.Impl.Util.SimpleEntityFilter(Net.Vpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(entityNamePattern) ? null : new Net.Vpc.Upa.Impl.Util.EqualsStringFilter(entityNamePattern, false, false), system), new Net.Vpc.Upa.Impl.Config.EntityInterceptorEntityConfigurator(interceptor, triggerName));
        }


        public virtual void DropTrigger(string entityName, string triggerName) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Entity e = FindEntity(entityName);
            if (e != null) {
                e.RemoveTrigger(triggerName);
            } else {
                //should remove definition listener if found?
                foreach (Net.Vpc.Upa.Callbacks.TriggerDefinitionListener li in new System.Collections.Generic.List<Net.Vpc.Upa.Callbacks.TriggerDefinitionListener>(persistenceUnitListenerManager.entityTriggers.GetAllListeners(true, entityName))) {
                    persistenceUnitListenerManager.entityTriggers.Remove(entityName, li);
                }
            }
        }


        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Callbacks.Trigger> GetTriggers(string entityName) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetEntity(entityName).GetTriggers();
        }


        public virtual void Scan(Net.Vpc.Upa.Config.ScanSource source, Net.Vpc.Upa.ScanListener listener, bool configure) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("{0}/{1} : Configuring with strategy {2}",null,new object[] { GetPersistenceGroup().GetName(), GetPersistenceGroup().GetName(), source }));
            Net.Vpc.Upa.Impl.Config.URLAnnotationStrategySupport s = new Net.Vpc.Upa.Impl.Config.URLAnnotationStrategySupport();
            s.Scan(this, source, decorationRepository, configure ? ((Net.Vpc.Upa.ScanListener)(new Net.Vpc.Upa.Impl.Config.ConfigureScanListener(listener))) : listener);
        }


        public virtual Net.Vpc.Upa.Entity AddEntity(object source) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (/*IsLoggable=*/true) {
                string sourceLog = null;
                if (source == null) {
                    sourceLog = "null";
                } else if (source is System.Type[]) {
                    sourceLog = Net.Vpc.Upa.Impl.Util.PlatformUtils.ArrayToString((System.Type[]) source);
                } else {
                    sourceLog = source.ToString();
                }
                log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("{0}/{1} : Define Entity {2}",null,new object[] { GetPersistenceGroup().GetName(), GetPersistenceGroup().GetName(), sourceLog }));
            }
            Net.Vpc.Upa.EntityDescriptor desc = entityDescriptorResolver.Resolve(source);
            Net.Vpc.Upa.Entity t = GetFactory().CreateObject<Net.Vpc.Upa.Entity>(typeof(Net.Vpc.Upa.Entity));
            System.Collections.Generic.IList<Net.Vpc.Upa.Extensions.EntityExtensionDefinition> entitySpecs = desc.GetEntityExtensions();
            //look for incompatible specs
            if (entitySpecs != null) {
                foreach (Net.Vpc.Upa.Extensions.EntityExtensionDefinition extension in entitySpecs) {
                }
            }
            t.SetName(desc.GetName());
            t.SetShortName(desc.GetShortName());
            if (desc.GetProperties() != null) {
                foreach (System.Collections.Generic.KeyValuePair<string , object> e in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<string,object>>(desc.GetProperties())) {
                    t.GetProperties().SetObject((e).Key, (e).Value);
                }
            }
            //        t.setPersistenceState(PersistenceState.DIRTY);
            //        t.setEntityType((Class<R>) desc.getEntityType());
            Net.Vpc.Upa.Impl.Util.DefaultBeanAdapter adapter = Net.Vpc.Upa.Impl.Util.UPAUtils.Prepare(this, t, desc.GetName());
            adapter.SetProperty("idType", desc.GetIdType());
            adapter.SetProperty("entityType", desc.GetEntityType());
            adapter.SetProperty("entityDescriptor", desc);
            Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.EntityModifier> currentModifiers = t.GetUserModifiers();
            Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.EntityModifier> tempModifiers = desc.GetModifiers();
            if (tempModifiers != null) {
                currentModifiers = currentModifiers.AddAll(tempModifiers);
            }
            t.SetUserModifiers(currentModifiers);
            currentModifiers = t.GetUserExcludeModifiers();
            tempModifiers = desc.GetExcludeModifiers();
            if (tempModifiers != null) {
                currentModifiers = currentModifiers.AddAll(tempModifiers);
            }
            t.SetUserExcludeModifiers(currentModifiers);
            Net.Vpc.Upa.Package parent = (desc.GetPackagePath() == null || (desc.GetPackagePath()).Length == 0) ? null : GetPackage(desc.GetPackagePath(), Net.Vpc.Upa.MissingStrategy.CREATE);
            int pos = -1;
            if (desc.GetPosition() != 0) {
                pos = desc.GetPosition();
            }
            if (parent != null) {
                parent.AddPart(t, pos);
            } else {
                GetDefaulPackage().AddPart(t, pos);
            }
            if (entitySpecs != null) {
                foreach (Net.Vpc.Upa.Extensions.EntityExtensionDefinition s in entitySpecs) {
                    bool ok = false;
                    foreach (System.Type ext in new System.Collections.Generic.ICollection<System.Type>[] { typeof(Net.Vpc.Upa.Extensions.ViewEntityExtensionDefinition), typeof(Net.Vpc.Upa.Extensions.SingletonExtensionDefinition), typeof(Net.Vpc.Upa.Extensions.FilterEntityExtensionDefinition), typeof(Net.Vpc.Upa.Extensions.UnionEntityExtensionDefinition) }) {
                        if (ext.IsInstanceOfType(s)) {
                            ok = true;
                            t.AddExtensionDefinition(ext, s);
                        }
                    }
                    if (!ok) {
                        throw new Net.Vpc.Upa.Exceptions.UPAException("UnsupportedEntityExtension", s);
                    }
                }
            }
            //        t.revalidateStructure();
            //t.commitModelChanges();
            return t;
        }


        public virtual bool ContainsEntity(string entityName) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return FindEntity(entityName) != null;
        }


        public virtual bool ContainsField(string entityName, string keyName) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Entity t = GetEntity(entityName, false);
            if (t == null) {
                return false;
            } else {
                return t.ContainsField(keyName);
            }
        }


        public virtual Net.Vpc.Upa.Entity GetEntity(string entityName) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetEntity(entityName, true);
        }

        public virtual Net.Vpc.Upa.Entity FindEntity(System.Type entityType) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return registrationModel.FindEntity(entityType);
        }

        public virtual Net.Vpc.Upa.Entity FindEntity(string entityName) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return registrationModel.FindEntity(entityName);
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Entity> FindEntities(System.Type entityType) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return registrationModel.FindEntities(entityType);
        }

        public virtual Net.Vpc.Upa.Entity GetEntity(string entityName, bool check) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Entity e = registrationModel.FindEntity(entityName);
            if (e == null && check) {
                throw new Net.Vpc.Upa.Exceptions.NoSuchEntityException(entityName, null);
            }
            return e;
        }

        public virtual void AddRelationship(Net.Vpc.Upa.RelationshipDescriptor relationDescriptor) {
            Net.Vpc.Upa.Impl.Config.Annotationparser.RelationshipDescriptorProcessor p = new Net.Vpc.Upa.Impl.Config.Annotationparser.RelationshipDescriptorProcessor(this, relationDescriptor);
            p.Process();
        }

        public virtual Net.Vpc.Upa.Relationship AddRelationshipImmediate(Net.Vpc.Upa.RelationshipDescriptor relationDescriptor) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            string name = relationDescriptor.GetName();
            Net.Vpc.Upa.RelationshipType type = relationDescriptor.GetRelationshipType();
            string detailEntityName = relationDescriptor.GetSourceEntity();
            string masterEntityName = relationDescriptor.GetTargetEntity();
            if (detailEntityName == null || masterEntityName == null) {
                throw new System.NullReferenceException("Illegal Null values for Entities " + detailEntityName + " / " + masterEntityName);
            }
            Net.Vpc.Upa.Field manyToOneField = null;
            string detailEntityFieldName = null;
            //relationDescriptor.getBaseField() ==null == null ? null : manyToOneField.getName();
            Net.Vpc.Upa.RelationshipUpdateType detailUpdateType = Net.Vpc.Upa.RelationshipUpdateType.FLAT;
            if (relationDescriptor.GetBaseField() != null) {
                Net.Vpc.Upa.Field baseField = GetEntity(detailEntityName).GetField(relationDescriptor.GetBaseField());
                if (baseField.GetDataType() is Net.Vpc.Upa.Types.ManyToOneType) {
                    detailEntityFieldName = baseField.GetName();
                    manyToOneField = baseField;
                    detailUpdateType = Net.Vpc.Upa.RelationshipUpdateType.COMPOSED;
                } else if (relationDescriptor.GetMappedTo() != null && relationDescriptor.GetMappedTo().Length > 0) {
                    if (relationDescriptor.GetMappedTo().Length > 1) {
                        throw new Net.Vpc.Upa.Exceptions.IllegalArgumentException("mappedTo cannot only apply to single Entity Field");
                    }
                    detailEntityFieldName = GetEntity(detailEntityName).GetField(relationDescriptor.GetMappedTo()[0]).GetName();
                }
            } else {
                detailUpdateType = Net.Vpc.Upa.RelationshipUpdateType.FLAT;
                manyToOneField = null;
                detailEntityFieldName = relationDescriptor.GetSourceFields()[0];
            }
            string masterEntityFieldName = null;
            Net.Vpc.Upa.RelationshipUpdateType masterUpdateType = Net.Vpc.Upa.Impl.Util.PlatformUtils.GetUndefinedValue<Net.Vpc.Upa.RelationshipUpdateType>(typeof(Net.Vpc.Upa.RelationshipUpdateType));
            string[] detailFieldNames = relationDescriptor.GetSourceFields();
            bool nullable = true;
            foreach (string f in detailFieldNames) {
                if (!GetEntity(detailEntityName).GetField(f).GetDataType().IsNullable()) {
                    nullable = false;
                    break;
                }
            }
            Net.Vpc.Upa.Expressions.Expression filter = relationDescriptor.GetFilter();
            if (filter != null && filter is Net.Vpc.Upa.Expressions.UserExpression) {
                Net.Vpc.Upa.Expressions.UserExpression ff = (Net.Vpc.Upa.Expressions.UserExpression) filter;
                string expression = ff.GetExpression();
                if (Net.Vpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(expression)) {
                    filter = null;
                } else if ((ff.GetParameters().Count==0)) {
                    filter = GetExpressionManager().ParseExpression(expression);
                }
            }
            if (name == null) {
                if (detailEntityFieldName != null) {
                    name = detailEntityName + "_" + detailEntityFieldName;
                } else {
                    name = detailEntityName;
                    foreach (string fn in detailFieldNames) {
                        name = name + "_" + fn;
                    }
                }
            }
            if (!Net.Vpc.Upa.Impl.Util.PlatformUtils.IsUndefinedValue<Net.Vpc.Upa.RelationshipUpdateType>(typeof(Net.Vpc.Upa.RelationshipUpdateType), masterUpdateType)) {
                throw new Net.Vpc.Upa.Exceptions.UPAException("UnsupportedFeature", "MasterUpdateType");
            }
            if (masterEntityFieldName != null) {
                throw new Net.Vpc.Upa.Exceptions.UPAException("UnsupportedFeature", "MasterEntityFieldName");
            }
            if (detailEntityFieldName == null) {
                if (Net.Vpc.Upa.Impl.Util.PlatformUtils.IsUndefinedValue<Net.Vpc.Upa.RelationshipUpdateType>(typeof(Net.Vpc.Upa.RelationshipUpdateType), detailUpdateType) && detailUpdateType != Net.Vpc.Upa.RelationshipUpdateType.FLAT) {
                    throw new Net.Vpc.Upa.Exceptions.IllegalArgumentException("MissingDetailEntityFieldName");
                }
                if (Net.Vpc.Upa.Impl.Util.PlatformUtils.IsUndefinedValue<Net.Vpc.Upa.RelationshipUpdateType>(typeof(Net.Vpc.Upa.RelationshipUpdateType), detailUpdateType)) {
                    detailUpdateType = Net.Vpc.Upa.RelationshipUpdateType.FLAT;
                }
            } else if (Net.Vpc.Upa.Impl.Util.PlatformUtils.IsUndefinedValue<Net.Vpc.Upa.RelationshipUpdateType>(typeof(Net.Vpc.Upa.RelationshipUpdateType), detailUpdateType)) {
                detailUpdateType = Net.Vpc.Upa.RelationshipUpdateType.COMPOSED;
            }
            Net.Vpc.Upa.Relationship r = GetFactory().CreateObject<Net.Vpc.Upa.Relationship>(typeof(Net.Vpc.Upa.Relationship));
            Net.Vpc.Upa.Impl.Util.DefaultBeanAdapter adapter = Net.Vpc.Upa.Impl.Util.UPAUtils.PreparePreAdd(this, null, r, name);
            Net.Vpc.Upa.Entity detailEntity = GetEntity(detailEntityName);
            Net.Vpc.Upa.Entity masterEntity = GetEntity(masterEntityName);
            r.GetTargetRole().SetRelationshipUpdateType(masterUpdateType);
            r.GetTargetRole().SetEntity(masterEntity);
            r.GetSourceRole().SetRelationshipUpdateType(detailUpdateType);
            r.GetSourceRole().SetEntity(detailEntity);
            Net.Vpc.Upa.Field[] detailFields = new Net.Vpc.Upa.Field[detailFieldNames.Length];
            for (int i = 0; i < detailFields.Length; i++) {
                detailFields[i] = detailEntity.GetField(detailFieldNames[i]);
            }
            r.GetSourceRole().SetFields(detailFields);
            r.SetRelationshipType(type == default(Net.Vpc.Upa.RelationshipType) ? Net.Vpc.Upa.RelationshipType.DEFAULT : type);
            r.SetFilter(filter);
            r.SetNullable(nullable);
            if (detailEntityFieldName != null) {
                Net.Vpc.Upa.Field detailEntityField = detailEntity.GetField(detailEntityFieldName);
                r.GetSourceRole().SetEntityField(detailEntityField);
                Net.Vpc.Upa.Types.DataType dt = detailEntityField.GetDataType();
                if (dt is Net.Vpc.Upa.Types.ManyToOneType) {
                    Net.Vpc.Upa.Types.ManyToOneType edt = (Net.Vpc.Upa.Types.ManyToOneType) dt;
                    edt.SetRelationship(r);
                }
            }
            if (masterEntityFieldName != null) {
                Net.Vpc.Upa.Field masterEntityField = GetEntity(masterEntityName).GetField(masterEntityFieldName);
                r.GetTargetRole().SetEntityField(masterEntityField);
                Net.Vpc.Upa.Types.DataType dt = masterEntityField.GetDataType();
                if (dt is Net.Vpc.Upa.Types.ManyToOneType) {
                    Net.Vpc.Upa.Types.ManyToOneType edt = (Net.Vpc.Upa.Types.ManyToOneType) dt;
                    edt.SetRelationship(r);
                }
            }
            if (relationDescriptor.IsHierarchy()) {
                Net.Vpc.Upa.Impl.Extension.HierarchicalRelationshipSupport s = new Net.Vpc.Upa.Impl.Extension.HierarchicalRelationshipSupport(r);
                r.SetHierarchyExtension(s);
                string hierarchyPathField = relationDescriptor.GetHierarchyPathField();
                if (Net.Vpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(hierarchyPathField)) {
                    if (relationDescriptor.GetBaseField() == null) {
                        System.Text.StringBuilder n = new System.Text.StringBuilder();
                        foreach (Net.Vpc.Upa.Field detailField in detailFields) {
                            if ((n).Length > 0) {
                                n.Append("_");
                            }
                            n.Append(detailField.GetName());
                        }
                        hierarchyPathField = n.ToString();
                    } else {
                        hierarchyPathField = relationDescriptor.GetBaseField() + "IdPath";
                    }
                }
                s.SetHierarchyPathField(hierarchyPathField);
                string hierarchySeparator = relationDescriptor.GetHierarchyPathSeparator();
                if (Net.Vpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(hierarchySeparator)) {
                    hierarchySeparator = "/";
                }
                s.SetHierarchyPathSeparator(hierarchySeparator);
            }
            Net.Vpc.Upa.Impl.Util.UPAUtils.PreparePostAdd(this, r);
            persistenceUnitListenerManager.ItemAdded(r, -1, null, Net.Vpc.Upa.EventPhase.BEFORE);
            //        if (relationDescriptor.isHierarchy()) {
            //            detailEntity.addExtensionDefinition(
            //                    TreeEntityExtensionDefinition.class,
            //                    new DefaultTreeEntityExtensionDefinition(
            //                            manyToOneField != null ? manyToOneField.getName() : detailFieldNames[0],
            //                            name,
            //                            relationDescriptor.getHierarchyPathField(),
            //                            hierarchySeparator
            //                    ));
            //        }
            if (relationDescriptor.IsHierarchy()) {
                Net.Vpc.Upa.Extensions.HierarchyExtension s = r.GetHierarchyExtension();
                detailEntity.AddField(s.GetHierarchyPathField(), "system", Net.Vpc.Upa.FlagSets.Of<E>(Net.Vpc.Upa.UserFieldModifier.SYSTEM), null, null, new Net.Vpc.Upa.Types.StringType("PathFieldName", 0, 2048, true), -1);
                detailEntity.AddTrigger(detailEntity.GetName() + "_" + s.GetHierarchyPathField() + "_TRIGGER", new Net.Vpc.Upa.Impl.Extension.HierarchicalRelationshipDataInterceptor(r));
            }
            persistenceUnitListenerManager.ItemAdded(r, -1, null, Net.Vpc.Upa.EventPhase.AFTER);
            return r;
        }

        public virtual void AddDefinitionListener(Net.Vpc.Upa.Callbacks.DefinitionListener definitionListener, bool trackSystem) {
            persistenceUnitListenerManager.AddDefinitionListener((string) null, definitionListener, trackSystem);
        }

        public virtual void AddDefinitionListener(System.Type entityType, Net.Vpc.Upa.Callbacks.DefinitionListener definitionListener, bool trackSystem) {
            persistenceUnitListenerManager.AddDefinitionListener(entityType, definitionListener, trackSystem);
        }

        public virtual void AddDefinitionListener(string entityName, Net.Vpc.Upa.Callbacks.DefinitionListener definitionListener, bool trackSystem) {
            persistenceUnitListenerManager.AddDefinitionListener(entityName, definitionListener, trackSystem);
        }

        public virtual void AddDefinitionListener(Net.Vpc.Upa.Callbacks.DefinitionListener definitionListener) {
            AddDefinitionListener(definitionListener, false);
        }

        public virtual void AddDefinitionListener(string entityName, Net.Vpc.Upa.Callbacks.DefinitionListener definitionListener) {
            AddDefinitionListener(entityName, definitionListener, false);
        }

        public virtual void RemoveDefinitionListener(Net.Vpc.Upa.Callbacks.DefinitionListener definitionListener) {
            persistenceUnitListenerManager.RemoveDefinitionListener((string) null, definitionListener);
        }

        public virtual void RemoveDefinitionListener(System.Type entityType, Net.Vpc.Upa.Callbacks.DefinitionListener definitionListener) {
            persistenceUnitListenerManager.RemoveDefinitionListener(entityType, definitionListener);
        }

        public virtual void RemoveDefinitionListener(string entityName, Net.Vpc.Upa.Callbacks.DefinitionListener definitionListener) {
            persistenceUnitListenerManager.RemoveDefinitionListener(entityName, definitionListener);
        }

        protected internal virtual void PostponeCommit(Net.Vpc.Upa.Impl.OnHoldCommitAction modelCommit) {
            commitModelActions.Add(modelCommit);
        }


        public virtual void Reset() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Reset(defaultHints);
        }


        public virtual void Reset(System.Collections.Generic.IDictionary<string , object> hints) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            persistenceUnitListenerManager.FireOnReset(new Net.Vpc.Upa.Callbacks.PersistenceUnitEvent(this, GetPersistenceGroup(), Net.Vpc.Upa.EventPhase.BEFORE));
            System.Collections.Generic.IList<Net.Vpc.Upa.Entity> ops = GetEntities(new Net.Vpc.Upa.Filters.DefaultEntityFilter().SetAcceptClear(true));
            Clear();
            foreach (Net.Vpc.Upa.Entity entity in ops) {
                entity.Initialize(hints);
            }
            UpdateFormulas(null, hints);
            persistenceUnitListenerManager.FireOnReset(new Net.Vpc.Upa.Callbacks.PersistenceUnitEvent(this, GetPersistenceGroup(), Net.Vpc.Upa.EventPhase.AFTER));
        }

        public virtual void Clear() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Clear(null, defaultHints);
        }


        public virtual void Clear(Net.Vpc.Upa.Filters.EntityFilter entityFilter, System.Collections.Generic.IDictionary<string , object> hints) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (entityFilter == null) {
                entityFilter = new Net.Vpc.Upa.Filters.DefaultEntityFilter().SetAcceptClear(true);
            }
            System.Collections.Generic.IList<Net.Vpc.Upa.Entity> ops = GetEntities(entityFilter);
            GetPersistenceStore().SetNativeConstraintsEnabled(this, false);
            Net.Vpc.Upa.Persistence.EntityExecutionContext context = CreateContext(Net.Vpc.Upa.Persistence.ContextOperation.CLEAR, hints);
            persistenceUnitListenerManager.FireOnClear(new Net.Vpc.Upa.Callbacks.PersistenceUnitEvent(this, GetPersistenceGroup(), Net.Vpc.Upa.EventPhase.BEFORE));
            foreach (Net.Vpc.Upa.Entity entity in ops) {
                entity.ClearCore(context);
            }
            GetPersistenceStore().SetNativeConstraintsEnabled(this, true);
            persistenceUnitListenerManager.FireOnClear(new Net.Vpc.Upa.Callbacks.PersistenceUnitEvent(this, GetPersistenceGroup(), Net.Vpc.Upa.EventPhase.AFTER));
        }


        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Entity> GetEntities() {
            return registrationModel.GetEntities();
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Package> GetPackages() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return registrationModel.GetPackages();
        }


        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Entity> GetEntities(Net.Vpc.Upa.Filters.EntityFilter entityFilter) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.Vpc.Upa.Entity> all = GetEntities();
            if (entityFilter == null) {
                return all;
            } else {
                int max = (all).Count;
                System.Collections.Generic.List<Net.Vpc.Upa.Entity> v = new System.Collections.Generic.List<Net.Vpc.Upa.Entity>(max);
                foreach (Net.Vpc.Upa.Entity tab in all) {
                    if (entityFilter.Accept(tab)) {
                        v.Add(tab);
                    }
                }
                return v;
            }
        }


        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Relationship> GetRelationships() {
            return registrationModel.GetRelationships();
        }


        public virtual Net.Vpc.Upa.Relationship GetRelationship(string name) {
            return registrationModel.GetRelationship(name);
        }


        public virtual bool ContainsRelationship(string relationName) {
            try {
                return registrationModel.GetRelationship(name) != null;
            } catch (Net.Vpc.Upa.Exceptions.NoSuchRelationshipException e) {
                return false;
            }
        }


        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Relationship> GetRelationshipsByTarget(Net.Vpc.Upa.Entity entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.Vpc.Upa.Relationship> v = new System.Collections.Generic.List<Net.Vpc.Upa.Relationship>();
            foreach (Net.Vpc.Upa.Relationship r in GetRelationships()) {
                if (r.GetTargetRole().GetEntity().Equals(entity)) {
                    v.Add(r);
                }
            }
            return v;
        }


        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Relationship> GetRelationshipsBySource(Net.Vpc.Upa.Entity entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.Vpc.Upa.Relationship> v = new System.Collections.Generic.List<Net.Vpc.Upa.Relationship>();
            foreach (Net.Vpc.Upa.Relationship r in GetRelationships()) {
                if (r.GetSourceRole().GetEntity().Equals(entity)) {
                    v.Add(r);
                }
            }
            return v;
        }


        public virtual void UpdateFormulas() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            UpdateFormulas(new Net.Vpc.Upa.Filters.DefaultEntityFilter().SetAcceptValidatable(true), defaultHints);
        }


        public virtual void UpdateFormulas(Net.Vpc.Upa.Filters.EntityFilter entityFilter, System.Collections.Generic.IDictionary<string , object> hints) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (entityFilter == null) {
                entityFilter = new Net.Vpc.Upa.Filters.DefaultEntityFilter().SetAcceptValidatable(true);
            }
            persistenceUnitListenerManager.FireOnUpdateFormulas(new Net.Vpc.Upa.Callbacks.PersistenceUnitEvent(this, persistenceGroup, Net.Vpc.Upa.EventPhase.BEFORE));
            //        Log.method();
            //        if (monitor != null) {
            //            monitor.setMax(entities.length);
            //            TaskMonitor child = monitor.getChild();
            //            for (int i = 0; i < entities.length; i++) {
            //                if (monitor.isStopped()) {
            //                    return;
            //                }
            //                Entity tab = entities[i];
            //                monitor.progress(tab.getName(), tab.getTitle(), i, null);
            //                tab.updateFormulas(child);
            //            }
            //        } else {
            foreach (Net.Vpc.Upa.Entity tab in GetEntities(entityFilter)) {
                tab.CreateUpdateQuery().ValidateAll().SetHints(hints).Execute();
            }
            //        }
            persistenceUnitListenerManager.FireOnUpdateFormulas(new Net.Vpc.Upa.Callbacks.PersistenceUnitEvent(this, persistenceGroup, Net.Vpc.Upa.EventPhase.AFTER));
        }


        public virtual void InstallDemoData() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
        }

        protected internal virtual Net.Vpc.Upa.Session OpenSystemSession() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Session currentSession = null;
            try {
                currentSession = GetCurrentSession();
            } catch (Net.Vpc.Upa.Exceptions.CurrentSessionNotFoundException ignore) {
            }
            //
            if (currentSession != null) {
                Net.Vpc.Upa.Session session = currentSession;
                currentSession = new Net.Vpc.Upa.Impl.StackedSession(session);
            } else {
                currentSession = GetPersistenceGroup().OpenSession();
            }
            currentSession.SetParam(this, Net.Vpc.Upa.Impl.SessionParams.SYSTEM, privateUUID.ToString());
            return currentSession;
        }

        public virtual bool IsSystemSession(Net.Vpc.Upa.Session s) {
            return privateUUID.ToString().Equals(s.GetParam<T>(this, typeof(string), Net.Vpc.Upa.Impl.SessionParams.SYSTEM, null));
        }


        public virtual void Start() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (started || starting) {
                throw new Net.Vpc.Upa.Exceptions.PersistenceUnitException(new Net.Vpc.Upa.Types.I18NString("SchemaAlreadyStartedException"));
            }
            starting = true;
            log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("{0}/{1} : Start",null,new object[] { GetPersistenceGroup().GetName(), GetName() }));
            SetLastStartSucceeded(false);
            Net.Vpc.Upa.Session session = null;
            session = OpenSystemSession();
            persistenceStoreFactory = GetPersistenceGroup().GetFactory().CreateObject<Net.Vpc.Upa.Persistence.PersistenceStoreFactory>(typeof(Net.Vpc.Upa.Persistence.PersistenceStoreFactory));
            Net.Vpc.Upa.Persistence.PersistenceStore validPersistenceStore = null;
            System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.ConnectionProfile> validConnectionProfiles = GetValidConnectionProfiles(false);
            System.Collections.Generic.IList<object[]> errors = new System.Collections.Generic.List<object[]>();
            foreach (Net.Vpc.Upa.Persistence.ConnectionProfile p in validConnectionProfiles) {
                Net.Vpc.Upa.Persistence.PersistenceStore pm0 = persistenceStoreFactory.CreatePersistenceStore(p, GetPersistenceGroup().GetFactory(), GetProperties());
                try {
                    pm0.CheckAccessible(p);
                    connectionProfile = p;
                    validPersistenceStore = pm0;
                    break;
                } catch (System.Exception t) {
                    log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Ignore Profile {0}",null,new object[] { p }));
                    errors.Add(new object[] { p, t });
                }
            }
            if (GetConnectionProfile() == null || validPersistenceStore == null) {
                if ((validConnectionProfiles.Count==0)) {
                    log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Unable to create Store because no valid ConnectionProfile was found",null));
                } else {
                    log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Unable to create Store because all ConnectionProfiles failed to be accessible",null));
                    foreach (object[] objects in errors) {
                        log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Profile " + objects[0] + " failed because of " + ((System.Exception) objects[1]).ToString(),null,((System.Exception) objects[1])));
                    }
                }
                throw new Net.Vpc.Upa.Exceptions.UPAException("UnableToCreatePersistenceStore", this);
            }
            this.persistenceStore = validPersistenceStore;
            this.persistenceStore.Init(this, IsReadOnly(), connectionProfile, GetPersistenceNameConfig());
            //        this.persistenceStore.setResources(getResources());
            //        for (PersistenceUnitListener schemaDataListener : getPersistenceUnitListeners()) {
            //            schemaDataListener.persistenceStoreChanged(this, old, persistenceStore);
            //        }
            //            Map<String, String> m = new HashMap<String, String>();
            //            for (Map.Entry<String, Object> ee : getParameters().toMap().entrySet()) {
            //                String k = ee.getKey();
            //                String v = ee.getValue() == null ? "" : ee.getValue().toString();
            //                m.put(k, v);
            //            }
            CommitModelChanges();
            if (GetTransactionManagerFactory() == null) {
                SetTransactionManagerFactory(GetFactory().CreateObject<Net.Vpc.Upa.Persistence.TransactionManagerFactory>(typeof(Net.Vpc.Upa.Persistence.TransactionManagerFactory)));
            }
            if (GetTransactionManager() == null) {
                SetTransactionManager(GetTransactionManagerFactory().CreateTransactionManager(GetConnectionProfile(), GetPersistenceGroup().GetFactory(), GetProperties()));
            }
            BeginTransaction(Net.Vpc.Upa.TransactionType.REQUIRED);
            try {
                persistenceUnitListenerManager.FireOnStart(new Net.Vpc.Upa.Callbacks.PersistenceUnitEvent(this, persistenceGroup, Net.Vpc.Upa.EventPhase.BEFORE));
                CommitStructureModification();
                persistenceUnitListenerManager.FireOnStart(new Net.Vpc.Upa.Callbacks.PersistenceUnitEvent(this, persistenceGroup, Net.Vpc.Upa.EventPhase.AFTER));
                CommitTransaction();
                SetLastStartSucceeded(true);
            } catch (System.Exception ex) {
                SetLastStartSucceeded(false);
                RollbackTransaction();
                throw ex;
            } finally {
                if (session != null) {
                    session.Close();
                }
            }
            started = true;
            starting = false;
        }

        private System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.ConnectionProfile> GetValidConnectionProfiles(bool root) {
            Net.Vpc.Upa.Impl.Persistence.Connection.ConnectionProfileParser connectionProfileParser = new Net.Vpc.Upa.Impl.Persistence.Connection.ConnectionProfileParser();
            Net.Vpc.Upa.Impl.DefaultProperties p2 = new Net.Vpc.Upa.Impl.DefaultProperties(GetProperties());
            return connectionProfileParser.ParseEnabled(p2, GetConnectionConfigs(), (root ? Net.Vpc.Upa.UPA.ROOT_CONNECTION_STRING : Net.Vpc.Upa.UPA.CONNECTION_STRING));
        }


        public virtual string GetPersistenceName() {
            return persistenceName;
        }


        public virtual void SetPersistenceName(string persistenceName) {
            this.persistenceName = persistenceName;
        }

        public virtual void DropStorage(Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
        }


        public virtual bool IsValidPersistenceUnit() {
            //TODO
            foreach (Net.Vpc.Upa.Entity t in GetEntities()) {
                try {
                    //                ConnectionProfile p = getPersistenceStore().getConnectionProfile();
                    //                StructureStrategy oldOption = p.getStructureStrategy();
                    //                p.setStructureStrategy(StructureStrategy.MANDATORY);
                    //                try {
                    //                    openDefaultConnection();
                    //                } finally {
                    //                    p.setStructureStrategy(oldOption);
                    //                }
                    return t.GetEntityCount() >= 0;
                } catch (Net.Vpc.Upa.Exceptions.UPAException e) {
                    return false;
                }
            }
            return true;
        }


        public virtual Net.Vpc.Upa.Persistence.DBConfigModel GetDBConfigModel() {
            if (dbConfigModel == null) {
                dbConfigModel = new Net.Vpc.Upa.Impl.Persistence.DefaultDBConfigModel();
            }
            return dbConfigModel;
        }


        public virtual void SetDBConfigModel(Net.Vpc.Upa.Persistence.DBConfigModel dbConfigModel) {
            this.dbConfigModel = dbConfigModel;
        }

        /**
             * use PersistenceUnitListener
             *
             * @param propertyName
             * @param listener
             * @deprecated
             */


        public virtual void AddPropertyChangeListener(string propertyName, Net.Vpc.Upa.PropertyChangeListener listener) {
            propertyChangeSupport.AddPropertyChangeListener(propertyName, listener);
        }



        public virtual void AddPropertyChangeListener(Net.Vpc.Upa.PropertyChangeListener listener) {
            propertyChangeSupport.AddPropertyChangeListener(listener);
        }



        public virtual void RemovePropertyChangeListener(string propertyName, Net.Vpc.Upa.PropertyChangeListener listener) {
            propertyChangeSupport.RemovePropertyChangeListener(propertyName, listener);
        }



        public virtual void RemovePropertyChangeListener(Net.Vpc.Upa.PropertyChangeListener listener) {
            propertyChangeSupport.RemovePropertyChangeListener(listener);
        }


        public virtual Net.Vpc.Upa.PropertyChangeListener[] GetPropertyChangeListeners() {
            return propertyChangeSupport.GetPropertyChangeListeners();
        }


        public virtual Net.Vpc.Upa.PropertyChangeListener[] GetPropertyChangeListeners(string propertyName) {
            return propertyChangeSupport.GetPropertyChangeListeners(propertyName);
        }


        public virtual int GetStatus() {
            return status;
        }


        public virtual void SetStatus(int status) {
            this.status = status;
        }

        public virtual Net.Vpc.Upa.ExpressionManager GetExpressionManager() {
            return expressionManager;
        }


        public virtual Net.Vpc.Upa.Properties GetProperties() {
            return properties;
        }


        public virtual bool IsTriggersEnabled() {
            return triggersEnabled;
        }


        public virtual void SetTriggersEnabled(bool triggersEnabled) {
            this.triggersEnabled = triggersEnabled;
        }


        public virtual bool IsAskOnCheckCreatedPersistenceUnit() {
            return askOnCheckCreatedPersistenceUnit;
        }


        public virtual void SetAskOnCheckCreatedPersistenceUnit(bool askOnCheckCreatedPersistenceUnit) {
            this.askOnCheckCreatedPersistenceUnit = askOnCheckCreatedPersistenceUnit;
        }


        public virtual void AddPersistenceUnitListener(Net.Vpc.Upa.Callbacks.PersistenceUnitListener listener) {
            persistenceUnitListenerManager.persistenceUnitListeners.Add(listener);
        }


        public virtual void RemovePersistenceUnitListener(Net.Vpc.Upa.Callbacks.PersistenceUnitListener listener) {
            persistenceUnitListenerManager.persistenceUnitListeners.Remove(listener);
        }


        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Callbacks.PersistenceUnitListener> GetPersistenceUnitListeners() {
            return new System.Collections.Generic.List<Net.Vpc.Upa.Callbacks.PersistenceUnitListener>(persistenceUnitListenerManager.persistenceUnitListeners);
        }


        public virtual Net.Vpc.Upa.Persistence.PersistenceStoreFactory GetPersistenceStoreFactory() {
            return persistenceStoreFactory;
        }


        public virtual void AddSQLParameterProcessor(Net.Vpc.Upa.Expressions.QLParameterProcessor p) {
            parameterProcessors.Add(p);
        }


        public virtual void RemoveSQLParameterProcessor(Net.Vpc.Upa.Expressions.QLParameterProcessor p) {
            parameterProcessors.Remove(p);
        }

        public virtual System.Collections.Generic.IDictionary<string , Net.Vpc.Upa.Expressions.Expression> ProcessSQLParameters(System.Collections.Generic.IList<Net.Vpc.Upa.QLParameter> parameters, string message) {
            System.Collections.Generic.IDictionary<string , Net.Vpc.Upa.Expressions.Expression> output = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Expressions.Expression>();
            foreach (Net.Vpc.Upa.Expressions.QLParameterProcessor parameterProcessor in parameterProcessors) {
                parameterProcessor.ProcessSQLParameters(parameters, output, message);
            }
            return output;
        }


        public virtual Net.Vpc.Upa.I18NStringStrategy GetI18NStringStrategy() {
            if (i18NStringStrategy == null) {
                i18NStringStrategy = GetFactory().CreateObject<Net.Vpc.Upa.I18NStringStrategy>(typeof(Net.Vpc.Upa.I18NStringStrategy));
            }
            return i18NStringStrategy;
        }

        public virtual Net.Vpc.Upa.Entity GetLockInfoEntity() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Entity entity = GetEntity(Net.Vpc.Upa.Impl.LockInfoDesc.LOCK_INFO_ENTITY_NAME);
            return entity;
        }

        protected internal virtual void AddLockingSupport(Net.Vpc.Upa.Entity entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            entity.AddField(new Net.Vpc.Upa.DefaultFieldDescriptor().SetName("lockId").SetFieldPath("Lock").SetUserFieldModifiers(Net.Vpc.Upa.FlagSets.Of<E>(Net.Vpc.Upa.UserFieldModifier.SYSTEM)).SetUserExcludeModifiers(Net.Vpc.Upa.FlagSets.Of<E>(Net.Vpc.Upa.UserFieldModifier.UPDATE)).SetDataType(new Net.Vpc.Upa.Types.StringType("lockId", 0, 64, true)).SetAccessLevel(Net.Vpc.Upa.AccessLevel.PRIVATE));
            entity.AddField(new Net.Vpc.Upa.DefaultFieldDescriptor().SetName("lockTime").SetFieldPath("Lock").SetUserFieldModifiers(Net.Vpc.Upa.FlagSets.Of<E>(Net.Vpc.Upa.UserFieldModifier.SYSTEM)).SetUserExcludeModifiers(Net.Vpc.Upa.FlagSets.Of<E>(Net.Vpc.Upa.UserFieldModifier.UPDATE)).SetDataType(new Net.Vpc.Upa.Types.DateType("lockTime", typeof(Net.Vpc.Upa.Types.Timestamp), true)).SetAccessLevel(Net.Vpc.Upa.AccessLevel.PRIVATE));
        }

        public virtual void LockEntities(Net.Vpc.Upa.Entity entity, Net.Vpc.Upa.Expressions.Expression expression, string id) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (entity.GetEntityCount(new Net.Vpc.Upa.Expressions.And(expression, new Net.Vpc.Upa.Expressions.Different(new Net.Vpc.Upa.Expressions.Var("lockId"), null))) > 0) {
                throw new Net.Vpc.Upa.Exceptions.AlreadyLockedPersistenceUnitException("Some Records already locked");
            }
            System.Collections.Generic.IList<object> keys = entity.CreateQueryBuilder().ByExpression(expression).GetIdList<K>();
            foreach (object key in keys) {
                Net.Vpc.Upa.Record r = entity.GetBuilder().CreateRecord();
                r.SetObject("lockId", id);
                long i = entity.CreateUpdateQuery().SetValues(r).ByExpression(new Net.Vpc.Upa.Expressions.And(entity.GetBuilder().IdToExpression(key, null), new Net.Vpc.Upa.Expressions.Equals(new Net.Vpc.Upa.Expressions.Var("lockId"), null))).Execute();
                if (i != 1) {
                    throw new Net.Vpc.Upa.Exceptions.AlreadyLockedPersistenceUnitException("Already Locked Record");
                }
            }
        }

        public virtual void UnlockEntities(Net.Vpc.Upa.Entity entity, Net.Vpc.Upa.Expressions.Expression expression, string lockId) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (entity.GetEntityCount(new Net.Vpc.Upa.Expressions.And(expression, new Net.Vpc.Upa.Expressions.Or(new Net.Vpc.Upa.Expressions.Equals(new Net.Vpc.Upa.Expressions.Var("lockId"), null), new Net.Vpc.Upa.Expressions.Different(new Net.Vpc.Upa.Expressions.Var("lockId"), lockId)))) > 0) {
                throw new Net.Vpc.Upa.Exceptions.AlreadyLockedPersistenceUnitException("Some Records are not locked or are locked by another user");
            }
            System.Collections.Generic.IList<object> keys = entity.CreateQueryBuilder().ByExpression(expression).GetIdList<K>();
            foreach (object key in keys) {
                Net.Vpc.Upa.Record r = entity.GetBuilder().CreateRecord();
                r.SetObject("lockId", null);
                r.SetObject("lockTime", null);
                long i = entity.CreateUpdateQuery().SetValues(r).ByExpression(new Net.Vpc.Upa.Expressions.And(entity.GetBuilder().IdToExpression(key, null), new Net.Vpc.Upa.Expressions.Equals(new Net.Vpc.Upa.Expressions.Var("lockId"), lockId))).Execute();
                if (i != 1) {
                    throw new Net.Vpc.Upa.Exceptions.AlreadyLockedPersistenceUnitException("Record no Locked or is locked by another person");
                }
            }
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.LockInfo> GetLockingInfo(Net.Vpc.Upa.Entity entity, Net.Vpc.Upa.Expressions.Expression expression) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.List<Net.Vpc.Upa.LockInfo> vector = new System.Collections.Generic.List<Net.Vpc.Upa.LockInfo>();
            Net.Vpc.Upa.Filters.FieldFilter filter = Net.Vpc.Upa.Filters.Fields.Id().Or(Net.Vpc.Upa.Filters.Fields.ByName("lockId", "lockTime"));
            System.Collections.Generic.IList<Net.Vpc.Upa.Record> list = entity.CreateQueryBuilder().ByExpression(new Net.Vpc.Upa.Expressions.And(new Net.Vpc.Upa.Expressions.Different(new Net.Vpc.Upa.Expressions.Var("lockId"), null), expression)).SetFieldFilter(filter).GetRecordList();
            foreach (Net.Vpc.Upa.Record record in list) {
                string id = record.GetString("lockId");
                Net.Vpc.Upa.Types.Temporal date = record.GetDate("lockTime");
                record.Remove("lockId");
                record.Remove("lockTime");
                vector.Add(new Net.Vpc.Upa.LockInfo(record, date, id));
            }
            return vector;
        }

        public virtual void LockPersistenceUnit(string id) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            _lockEntity("*", id);
        }

        public virtual void UnlockPersistenceUnit(string id) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            _unlock("*", id);
        }

        public virtual Net.Vpc.Upa.LockInfo GetPersistenceUnitLockingInfo() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.LockInfo info = _getLockInfo("*");
            if (info == null) {
                return null;
            }
            return new Net.Vpc.Upa.LockInfo(this, info.GetDate(), info.GetUser());
        }

        public virtual void LockEntityManager(Net.Vpc.Upa.Entity entityManager, string id) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            _lockEntity(entityManager.GetName(), id);
        }

        public virtual void UnlockEntityManager(Net.Vpc.Upa.Entity entityManager, string id) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            _unlock(entityManager.GetName(), id);
        }

        public virtual Net.Vpc.Upa.LockInfo GetLockingInfo(Net.Vpc.Upa.Entity entityManager) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.LockInfo info = _getLockInfo(entityManager.GetName());
            if (info == null) {
                return null;
            }
            return new Net.Vpc.Upa.LockInfo(entityManager, info.GetDate(), info.GetUser());
        }

        public virtual bool IsLockedDatabase(string id) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return _isLocked("*", id);
        }

        public virtual bool IsLockedDatabase() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return _isLocked("*");
        }

        public virtual bool IsLockedEntity(Net.Vpc.Upa.Entity entity, string id) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return _isLocked(entity.GetName(), id);
        }

        public virtual bool IsLockedEntity(Net.Vpc.Upa.Entity entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return _isLocked(entity.GetName());
        }

        private void EnsureLockDef(string entityName) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Entity lockInfoEntity = GetLockInfoEntity();
            if (lockInfoEntity.GetEntityCount(lockInfoEntity.GetBuilder().IdToExpression(lockInfoEntity.CreateId(entityName), null)) == 0) {
                Net.Vpc.Upa.Record r = lockInfoEntity.GetBuilder().CreateRecord();
                r.SetString("lockedEntity", entityName);
                lockInfoEntity.Persist(r);
            }
        }

        private void _lockEntity(string entityName, string lockId) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Entity lockInfoEntity = GetLockInfoEntity();
            Net.Vpc.Upa.Record r = lockInfoEntity.GetBuilder().CreateRecord();
            r.SetObject("lockId", lockId);
            r.SetObject("lockTime", new Net.Vpc.Upa.Types.DateTime());
            long ret = 0;
            try {
                EnsureLockDef(entityName);
                Net.Vpc.Upa.Expressions.And notLocked = new Net.Vpc.Upa.Expressions.And(new Net.Vpc.Upa.Expressions.Equals(new Net.Vpc.Upa.Expressions.Var("lockedEntity"), new Net.Vpc.Upa.Expressions.Literal(entityName)), new Net.Vpc.Upa.Expressions.Equals(new Net.Vpc.Upa.Expressions.Var("lockId"), null));
                //getEntity(entityName)
                ret = lockInfoEntity.CreateUpdateQuery().SetValues(r).ByExpression(notLocked).Execute();
            } catch (Net.Vpc.Upa.Exceptions.UPAException e) {
                throw new Net.Vpc.Upa.Exceptions.AlreadyLockedPersistenceUnitException("entity.lockingException", GetEntity(entityName).GetI18NString());
            }
            if (ret == 1) {
            } else {
                Net.Vpc.Upa.Record locked = null;
                try {
                    locked = lockInfoEntity.CreateQueryBuilder().ByExpression(new Net.Vpc.Upa.Expressions.Equals(new Net.Vpc.Upa.Expressions.Var("lockedEntity"), new Net.Vpc.Upa.Expressions.Literal(entityName))).SetFieldFilter(Net.Vpc.Upa.Filters.Fields.ByName("lockId", "lockTime")).GetRecord();
                } catch (Net.Vpc.Upa.Exceptions.UPAException e) {
                    throw new Net.Vpc.Upa.Exceptions.AlreadyLockedPersistenceUnitException("entity.lockingException", GetEntity(entityName).GetI18NString());
                }
                throw new Net.Vpc.Upa.Exceptions.AlreadyLockedPersistenceUnitException("entity.alreadyLocked", GetEntity(entityName).GetI18NString(), locked.GetString("lockId"), locked.GetDate("lockTime"));
            }
        }

        private bool _isLocked(string entityName) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Entity entity = GetLockInfoEntity();
            return entity.GetEntityCount(new Net.Vpc.Upa.Expressions.And(new Net.Vpc.Upa.Expressions.Equals(new Net.Vpc.Upa.Expressions.Var("lockedEntity"), new Net.Vpc.Upa.Expressions.Literal(entityName)), new Net.Vpc.Upa.Expressions.Different(new Net.Vpc.Upa.Expressions.Var("lockId"), null))) > 0;
        }

        private bool _isLocked(string entityName, string id) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Entity entity = GetLockInfoEntity();
            return entity.GetEntityCount(new Net.Vpc.Upa.Expressions.And(new Net.Vpc.Upa.Expressions.Equals(new Net.Vpc.Upa.Expressions.Var("lockedEntity"), new Net.Vpc.Upa.Expressions.Literal(entityName)), new Net.Vpc.Upa.Expressions.Equals(new Net.Vpc.Upa.Expressions.Var("lockId"), id))) > 0;
        }

        private Net.Vpc.Upa.LockInfo _getLockInfo(string entityName) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Record rec = GetEntity(entityName).CreateQueryBuilder().ByExpression(new Net.Vpc.Upa.Expressions.Equals(new Net.Vpc.Upa.Expressions.Var("lockedEntity"), new Net.Vpc.Upa.Expressions.Literal(entityName))).SetFieldFilter(Net.Vpc.Upa.Filters.Fields.ByName("lockId", "lockTime")).GetRecord();
            if (rec == null) {
                return null;
            }
            return new Net.Vpc.Upa.LockInfo(entityName, rec.GetDate("lockTime"), rec.GetString("lockId"));
        }

        private void _unlock(string entityName, string id) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Entity entity = GetLockInfoEntity();
            Net.Vpc.Upa.Record r = entity.GetBuilder().CreateRecord();
            r.SetObject("lockId", null);
            r.SetObject("lockTime", null);
            Net.Vpc.Upa.Expressions.And locked = new Net.Vpc.Upa.Expressions.And(new Net.Vpc.Upa.Expressions.Equals(new Net.Vpc.Upa.Expressions.Var("lockedEntity"), new Net.Vpc.Upa.Expressions.Literal(entityName)), new Net.Vpc.Upa.Expressions.Equals(new Net.Vpc.Upa.Expressions.Var("lockId"), new Net.Vpc.Upa.Expressions.Param(id)));
            long ret = entity.CreateUpdateQuery().SetValues(r).ByExpression(locked).Execute();
            if (ret == 1) {
            } else {
                Net.Vpc.Upa.Record rlocked = entity.CreateQueryBuilder().ByExpression(new Net.Vpc.Upa.Expressions.Equals(new Net.Vpc.Upa.Expressions.Var("lockedEntity"), new Net.Vpc.Upa.Expressions.Literal(entityName))).SetFieldFilter(Net.Vpc.Upa.Filters.Fields.ByName("lockId", "lockTime")).GetRecord();
                if (rlocked == null) {
                    rlocked = entity.GetBuilder().CreateRecord();
                }
                throw new Net.Vpc.Upa.Exceptions.AlreadyLockedPersistenceUnitException("entity.neverLocked", GetEntity(entityName).GetI18NString(), rlocked.GetString("lockId"), rlocked.GetDate("lockTime"));
            }
        }


        public virtual Net.Vpc.Upa.Types.I18NString GetTitle() {
            return title;
        }

        public virtual void SetTitle(Net.Vpc.Upa.Types.I18NString title) {
            this.title = title;
        }


        public virtual Net.Vpc.Upa.UPASecurityManager GetSecurityManager() {
            return GetPersistenceGroup().GetSecurityManager();
        }


        public virtual System.Type GetEntityExtensionSupportType(System.Type entityExtensionDefinitionType) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (typeof(Net.Vpc.Upa.Extensions.UnionEntityExtensionDefinition).Equals(entityExtensionDefinitionType)) {
                return typeof(Net.Vpc.Upa.Persistence.UnionEntityExtension);
            }
            if (typeof(Net.Vpc.Upa.Extensions.ViewEntityExtensionDefinition).Equals(entityExtensionDefinitionType)) {
                return typeof(Net.Vpc.Upa.Persistence.ViewEntityExtension);
            }
            if (typeof(Net.Vpc.Upa.Extensions.FilterEntityExtensionDefinition).Equals(entityExtensionDefinitionType)) {
                return typeof(Net.Vpc.Upa.Persistence.FilterEntityExtension);
            }
            if (typeof(Net.Vpc.Upa.Extensions.SingletonExtensionDefinition).Equals(entityExtensionDefinitionType)) {
                return typeof(Net.Vpc.Upa.Persistence.SingletonExtension);
            }
            throw new Net.Vpc.Upa.Exceptions.IllegalArgumentException("Unsupported extension definition " + entityExtensionDefinitionType);
        }

        public virtual void SetName(string name) {
            this.name = name;
        }

        public virtual void SetPersistenceGroup(Net.Vpc.Upa.PersistenceGroup persistenceGroup) {
            this.persistenceGroup = persistenceGroup;
        }


        public virtual Net.Vpc.Upa.PersistenceGroup GetPersistenceGroup() {
            return persistenceGroup;
        }

        public virtual Net.Vpc.Upa.Properties GetSystemParameters() {
            if (systemParameters == null) {
                Net.Vpc.Upa.Properties p = new Net.Vpc.Upa.Impl.DefaultProperties();
                System.Collections.Generic.IDictionary<string , string> properties = Net.Vpc.Upa.Impl.Util.PlatformUtils.GetSystemProperties();
                foreach (System.Collections.Generic.KeyValuePair<string , string> entry in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<string,string>>(properties)) {
                    string k = (string) (entry).Key;
                    string v = (string) (entry).Value;
                    if (k.StartsWith("upa.")) {
                        p.SetString(k, v);
                    }
                }
                systemParameters = p;
            }
            return systemParameters;
        }

        public virtual Net.Vpc.Upa.Persistence.ConnectionProfile GetConnectionProfile() {
            return connectionProfile;
        }


        public virtual Net.Vpc.Upa.ObjectFactory GetFactory() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceGroup().GetFactory();
        }

        public virtual Net.Vpc.Upa.Persistence.TransactionManagerFactory GetTransactionManagerFactory() {
            return transactionManagerFactory;
        }

        public virtual void SetTransactionManagerFactory(Net.Vpc.Upa.Persistence.TransactionManagerFactory transactionManagerFactory) {
            this.transactionManagerFactory = transactionManagerFactory;
        }

        public virtual Net.Vpc.Upa.TransactionManager GetTransactionManager() {
            return transactionManager;
        }

        public virtual void SetTransactionManager(Net.Vpc.Upa.TransactionManager transactionManager) {
            this.transactionManager = transactionManager;
        }

        public virtual Net.Vpc.Upa.Entity GetEntityByIdType(System.Type idType) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return registrationModel.GetEntityByIdType(idType);
        }

        public virtual bool ContainsEntity(System.Type entityType) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return registrationModel.ContainsEntity(entityType);
        }

        public virtual Net.Vpc.Upa.Entity GetEntity(object entityType) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (entityType is string) {
                return GetEntity((string) entityType);
            }
            if (entityType is Net.Vpc.Upa.QualifiedRecord) {
                return ((Net.Vpc.Upa.QualifiedRecord) entityType).GetEntity();
            }
            if (entityType is System.Type) {
                return GetEntity((System.Type) entityType);
            }
            if (entityType is Net.Vpc.Upa.Record) {
                throw new Net.Vpc.Upa.Exceptions.UPAException("UnableToResolveEntityFromRecord");
            }
            return GetEntity(entityType.GetType());
        }

        public virtual Net.Vpc.Upa.Entity GetEntity(System.Type entityType) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return registrationModel.GetEntity(entityType);
        }


        public virtual Net.Vpc.Upa.Session OpenSession() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Session s = GetPersistenceGroup().OpenSession();
            s.SetParam(this, Net.Vpc.Upa.Impl.SessionParams.USER_PRINCIPAL, GetSecurityManager().GetUserPrincipal());
            return s;
        }

        private bool CheckSession() {
            if (!GetPersistenceGroup().CurrentSessionExists()) {
                if (sessionAwarePU == null) {
                    sessionAwarePU = GetPersistenceGroup().GetContext().MakeSessionAware<Net.Vpc.Upa.Impl.DefaultPersistenceUnit>(this);
                }
                return false;
            }
            return true;
        }


        public virtual void Persist(string entity, object objectOrRecord, System.Collections.Generic.IDictionary<string , object> hints) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (!CheckSession()) {
                sessionAwarePU.Persist(entity, objectOrRecord, hints);
                return;
            }
            Net.Vpc.Upa.Entity entityManager = GetEntity(entity);
            entityManager.Persist(objectOrRecord, hints);
        }


        public virtual void Persist(string entity, object objectOrRecord) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (!CheckSession()) {
                sessionAwarePU.Persist(objectOrRecord);
                return;
            }
            Net.Vpc.Upa.Entity entityManager = GetEntity(entity);
            entityManager.Persist(objectOrRecord);
        }


        public virtual void Persist(object objectOrRecord) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (!CheckSession()) {
                sessionAwarePU.Persist(objectOrRecord);
                return;
            }
            Net.Vpc.Upa.Entity entityManager = GetEntity(objectOrRecord);
            entityManager.Persist(objectOrRecord);
        }

        /**
             *
             * @param objectOrRecord
             * @throws UPAException
             */

        public virtual void Merge(object objectOrRecord) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (!CheckSession()) {
                sessionAwarePU.Merge(objectOrRecord);
                return;
            }
            Net.Vpc.Upa.Entity entityManager = GetEntity(objectOrRecord);
            entityManager.Merge(objectOrRecord);
        }


        public virtual void Merge(string entityName, object objectOrRecord) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (!CheckSession()) {
                sessionAwarePU.Merge(entityName, objectOrRecord);
                return;
            }
            Net.Vpc.Upa.Entity entityManager = GetEntity(entityName);
            entityManager.Merge(objectOrRecord);
        }


        public virtual Net.Vpc.Upa.UpdateQuery CreateUpdateQuery(string entityName) {
            Net.Vpc.Upa.Entity entityManager = GetEntity(entityName);
            return entityManager.CreateUpdateQuery();
        }


        public virtual Net.Vpc.Upa.UpdateQuery CreateUpdateQuery(System.Type entityType) {
            Net.Vpc.Upa.Entity entityManager = GetEntity(entityType);
            return entityManager.CreateUpdateQuery();
        }


        public virtual Net.Vpc.Upa.UpdateQuery CreateUpdateQuery(object @object) {
            Net.Vpc.Upa.Entity entityManager = GetEntity(@object);
            return entityManager.CreateUpdateQuery().SetValues(@object);
        }


        public virtual Net.Vpc.Upa.RemoveTrace Remove(object objectOrRecord) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (!CheckSession()) {
                return sessionAwarePU.Remove(objectOrRecord);
            }
            Net.Vpc.Upa.Entity entityManager = GetEntity(objectOrRecord);
            return entityManager.Remove(objectOrRecord);
        }


        public virtual bool Save(object objectOrRecord) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (!CheckSession()) {
                return sessionAwarePU.Save(objectOrRecord);
            }
            Net.Vpc.Upa.Entity entityManager = GetEntity(objectOrRecord);
            return entityManager.Save(objectOrRecord);
        }


        public virtual bool Save(string entityName, object objectOrRecord) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (!CheckSession()) {
                return sessionAwarePU.Save(entityName, objectOrRecord);
            }
            return GetEntity(entityName).Save(objectOrRecord);
        }


        public virtual void Update(object objectOrRecord) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (!CheckSession()) {
                sessionAwarePU.Update(objectOrRecord);
                return;
            }
            GetEntity(objectOrRecord).Update(objectOrRecord);
        }


        public virtual void Update(string entityName, object objectOrRecord) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            GetEntity(entityName).Update(objectOrRecord);
        }


        public virtual Net.Vpc.Upa.RemoveTrace Remove(System.Type entityType, object @object) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (!CheckSession()) {
                return sessionAwarePU.Remove(entityType, @object);
            }
            return GetEntity(entityType).Remove(@object);
        }


        public virtual Net.Vpc.Upa.RemoveTrace Remove(string entityName, object @object) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (!CheckSession()) {
                return sessionAwarePU.Remove(entityName, @object);
            }
            return GetEntity(entityName).Remove(@object);
        }


        public virtual Net.Vpc.Upa.RemoveTrace Remove(System.Type entityType, Net.Vpc.Upa.RemoveOptions @object) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (!CheckSession()) {
                return sessionAwarePU.Remove(entityType, @object);
            }
            return GetEntity(entityType).Remove(@object);
        }


        public virtual Net.Vpc.Upa.RemoveTrace Remove(string entityName, Net.Vpc.Upa.RemoveOptions @object) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (!CheckSession()) {
                return sessionAwarePU.Remove(entityName, @object);
            }
            return GetEntity(entityName).Remove(@object);
        }


        public virtual Net.Vpc.Upa.Query CreateQuery(string query) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return CreateQuery((Net.Vpc.Upa.Expressions.EntityStatement) GetExpressionManager().ParseExpression(query));
        }


        public virtual Net.Vpc.Upa.Query CreateQuery(Net.Vpc.Upa.Expressions.EntityStatement query) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            string entityName = query.GetEntityName();
            if (entityName != null) {
                return GetEntity(entityName).CreateQuery(query);
            }
            return GetPersistenceStore().CreateQuery(query, CreateContext(Net.Vpc.Upa.Persistence.ContextOperation.FIND, defaultHints));
        }


        public virtual Net.Vpc.Upa.QueryBuilder CreateQueryBuilder(System.Type entityType) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Entity entity = GetEntity(entityType);
            return entity.CreateQueryBuilder();
        }


        public virtual Net.Vpc.Upa.QueryBuilder CreateQueryBuilder(string entityName) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Entity entity = GetEntity(entityName);
            return entity.CreateQueryBuilder();
        }

        public virtual  T FindByMainField<T>(System.Type entityType, object mainFieldValue) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return FindByMainField<T>(GetEntity(entityType).GetName(), mainFieldValue);
        }

        public virtual  T FindByMainField<T>(string entityName, object mainFieldValue) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Entity e = GetEntity(entityName);
            Net.Vpc.Upa.Field mainField = e.GetMainField();
            mainField.Check(mainFieldValue);
            return CreateQueryBuilder(entityName).ByExpression(new Net.Vpc.Upa.Expressions.Equals(new Net.Vpc.Upa.Expressions.Var(new Net.Vpc.Upa.Expressions.Var(e.GetName()), mainField.GetName()), new Net.Vpc.Upa.Expressions.Param("main", mainFieldValue))).GetSingleEntityOrNull<R>();
        }

        public virtual  T FindByField<T>(System.Type entityType, string fieldName, object mainFieldValue) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Entity e = GetEntity(entityType);
            return CreateQueryBuilder(entityType).ByExpression(new Net.Vpc.Upa.Expressions.Equals(new Net.Vpc.Upa.Expressions.Var(new Net.Vpc.Upa.Expressions.Var(e.GetName()), fieldName), new Net.Vpc.Upa.Expressions.Param("main", mainFieldValue))).GetSingleEntityOrNull<R>();
        }

        public virtual  T FindByField<T>(string entityName, string fieldName, object mainFieldValue) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Entity e = GetEntity(entityName);
            return CreateQueryBuilder(entityName).ByExpression(new Net.Vpc.Upa.Expressions.Equals(new Net.Vpc.Upa.Expressions.Var(new Net.Vpc.Upa.Expressions.Var(e.GetName()), fieldName), new Net.Vpc.Upa.Expressions.Param("main", mainFieldValue))).GetSingleEntityOrNull<R>();
        }

        public virtual  System.Collections.Generic.IList<T> FindAll<T>(System.Type entityType) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return CreateQueryBuilder(entityType).OrderBy(GetEntity(entityType).GetListOrder()).GetEntityList<R>();
        }

        public virtual  System.Collections.Generic.IList<T> FindAll<T>(string entityName) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return CreateQueryBuilder(entityName).OrderBy(GetEntity(entityName).GetListOrder()).GetEntityList<R>();
        }


        public virtual  System.Collections.Generic.IList<T> FindAllIds<T>(string entityName) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return CreateQueryBuilder(entityName).GetIdList<K>();
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Record> FindAllRecords(System.Type entityType) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return CreateQueryBuilder(entityType).OrderBy(GetEntity(entityType).GetListOrder()).GetRecordList();
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Record> FindAllRecords(string entityName) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return CreateQueryBuilder(entityName).OrderBy(GetEntity(entityName).GetListOrder()).GetRecordList();
        }


        public virtual  T FindById<T>(System.Type entityType, object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return CreateQueryBuilder(entityType).ById(id).GetEntity<R>();
        }


        public virtual  T FindById<T>(string entityType, object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return CreateQueryBuilder(entityType).ById(id).GetEntity<R>();
        }


        public virtual bool ExistsById(string entityName, object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return (CreateQueryBuilder(entityName).ById(id).GetIdList<K>()).Count > 0;
        }


        public virtual Net.Vpc.Upa.Record FindRecordById(System.Type entityType, object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return CreateQueryBuilder(entityType).ById(id).GetRecord();
        }


        public virtual Net.Vpc.Upa.Record FindRecordById(string entityName, object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return CreateQueryBuilder(entityName).ById(id).GetRecord();
        }


        public virtual bool BeginTransaction(Net.Vpc.Upa.TransactionType transactionType) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            CheckStart();
            Net.Vpc.Upa.Session currentSession = GetCurrentSession();
            currentSession.PushContext();
            if (transactionType == default(Net.Vpc.Upa.TransactionType)) {
                transactionType = Net.Vpc.Upa.TransactionType.SUPPORTS;
            }
            currentSession.SetParam(this, Net.Vpc.Upa.Impl.SessionParams.TRANSACTION_TYPE, transactionType);
            Net.Vpc.Upa.Transaction currentTransaction = currentSession.GetParam<T>(this, typeof(Net.Vpc.Upa.Transaction), Net.Vpc.Upa.Impl.SessionParams.TRANSACTION, null);
            switch(transactionType) {
                case Net.Vpc.Upa.TransactionType.MANDATORY:
                    {
                        if (currentTransaction == null) {
                            throw new Net.Vpc.Upa.Exceptions.TransactionException(new Net.Vpc.Upa.Types.I18NString("TransactionMandatoryException"));
                        }
                        return false;
                    }
                case Net.Vpc.Upa.TransactionType.SUPPORTS:
                    {
                        return false;
                    }
                case Net.Vpc.Upa.TransactionType.REQUIRED:
                    {
                        if (currentTransaction == null) {
                            Net.Vpc.Upa.Transaction transaction = transactionManager.CreateTransaction(GetConnection(), this, persistenceStore);
                            transaction.Begin();
                            currentSession.SetParam(this, Net.Vpc.Upa.Impl.SessionParams.TRANSACTION, transaction);
                            return true;
                        }
                        return false;
                    }
            }
            throw new Net.Vpc.Upa.Exceptions.UPAException(new Net.Vpc.Upa.Types.I18NString("Unexpected"));
        }


        public virtual Net.Vpc.Upa.Session GetCurrentSession() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceGroup().GetCurrentSession();
        }


        public virtual void CommitTransaction() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Session currentSession = GetCurrentSession();
            Net.Vpc.Upa.TransactionType tt = currentSession.GetParam<Net.Vpc.Upa.TransactionType>(this, typeof(Net.Vpc.Upa.TransactionType), Net.Vpc.Upa.Impl.SessionParams.TRANSACTION_TYPE, Net.Vpc.Upa.Impl.Util.PlatformUtils.GetUndefinedValue<Net.Vpc.Upa.TransactionType>(typeof(Net.Vpc.Upa.TransactionType)));
            Net.Vpc.Upa.Transaction it = currentSession.GetImmediateParam<T>(this, typeof(Net.Vpc.Upa.Transaction), Net.Vpc.Upa.Impl.SessionParams.TRANSACTION, null);
            Net.Vpc.Upa.Transaction t = currentSession.GetParam<T>(this, typeof(Net.Vpc.Upa.Transaction), Net.Vpc.Upa.Impl.SessionParams.TRANSACTION, null);
            switch(tt) {
                case Net.Vpc.Upa.TransactionType.SUPPORTS:
                    {
                        //do nothing
                        break;
                    }
                case Net.Vpc.Upa.TransactionType.REQUIRED:
                case Net.Vpc.Upa.TransactionType.MANDATORY:
                    {
                        if (it == null) {
                            if (t == null) {
                                throw new Net.Vpc.Upa.Exceptions.UPAException(new Net.Vpc.Upa.Types.I18NString("TransactionContextMissing"));
                            } else {
                                //
                                t.Commit();
                            }
                        } else {
                            it.Commit();
                        }
                        break;
                    }
            }
            if (it != null) {
                it.Close();
            }
            currentSession.PopContext();
        }


        public virtual void RollbackTransaction() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Session currentSession = GetCurrentSession();
            Net.Vpc.Upa.TransactionType tt = currentSession.GetParam<Net.Vpc.Upa.TransactionType>(this, typeof(Net.Vpc.Upa.TransactionType), Net.Vpc.Upa.Impl.SessionParams.TRANSACTION_TYPE, Net.Vpc.Upa.Impl.Util.PlatformUtils.GetUndefinedValue<Net.Vpc.Upa.TransactionType>(typeof(Net.Vpc.Upa.TransactionType)));
            Net.Vpc.Upa.Transaction it = currentSession.GetImmediateParam<T>(this, typeof(Net.Vpc.Upa.Transaction), Net.Vpc.Upa.Impl.SessionParams.TRANSACTION, null);
            Net.Vpc.Upa.Transaction t = currentSession.GetParam<T>(this, typeof(Net.Vpc.Upa.Transaction), Net.Vpc.Upa.Impl.SessionParams.TRANSACTION, null);
            switch(tt) {
                case Net.Vpc.Upa.TransactionType.SUPPORTS:
                    {
                        //do nothing
                        break;
                    }
                case Net.Vpc.Upa.TransactionType.REQUIRED:
                case Net.Vpc.Upa.TransactionType.MANDATORY:
                    {
                        if (it == null) {
                            if (t == null) {
                                throw new Net.Vpc.Upa.Exceptions.UPAException(new Net.Vpc.Upa.Types.I18NString("TransactionContextMissing"));
                            } else {
                                //
                                t.Rollback();
                            }
                        } else {
                            it.Rollback();
                        }
                        break;
                    }
            }
            if (it != null) {
                it.Close();
            }
            currentSession.PopContext();
        }

        private void CheckStart() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (!started && !starting) {
                throw new Net.Vpc.Upa.Exceptions.UPAException("PersistenceUnitNotStartedException");
            }
        }

        public virtual bool IsStarted() {
            return started;
        }

        public virtual bool IsValidStructureModificationContext() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return !IsStarted() || IsStructureModification();
        }


        public virtual bool IsStructureModification() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return structureModification;
        }


        public virtual void BeginStructureModification() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (structureModification) {
                throw new Net.Vpc.Upa.Exceptions.UPAException(new Net.Vpc.Upa.Types.I18NString("StructureEditionPending"));
            }
            this.structureModification = true;
        }


        public virtual void CommitStructureModification() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            CommitModelChanges();
            GetPersistenceStore().RevalidateModel();
            bool someCommit = false;
            Net.Vpc.Upa.Persistence.EntityExecutionContext context = CreateContext(Net.Vpc.Upa.Persistence.ContextOperation.CREATE_PERSISTENCE_NAME, defaultHints);
            persistenceUnitListenerManager.FireOnStorageChanged(new Net.Vpc.Upa.Callbacks.PersistenceUnitEvent(this, persistenceGroup, Net.Vpc.Upa.EventPhase.BEFORE));
            System.Collections.Generic.IList<Net.Vpc.Upa.Impl.OnHoldCommitAction> model = commitStorageActions;
            Net.Vpc.Upa.Impl.FwkConvertUtils.ListSort(model, new Net.Vpc.Upa.Impl.OnHoldCommitActionComparator());
            foreach (Net.Vpc.Upa.Impl.OnHoldCommitAction next in model) {
                next.CommitStorage(context);
                someCommit = true;
            }
            model.Clear();
            if (persistenceStore.CommitStorage()) {
                someCommit = true;
            }
            System.Collections.Generic.IList<Net.Vpc.Upa.Entity> initializables = new System.Collections.Generic.List<Net.Vpc.Upa.Entity>();
            foreach (Net.Vpc.Upa.Entity entity in GetEntities()) {
                string persistenceAction = entity.GetProperties().GetString("persistence.PersistenceAction");
                entity.GetProperties().Remove("persistence.PersistenceAction");
                if ("ADD".Equals(persistenceAction)) {
                    initializables.Add(entity);
                }
                entity.CommitStructureModification(persistenceStore);
            }
            foreach (Net.Vpc.Upa.Entity entity in initializables) {
                entity.Initialize();
            }
            persistenceUnitListenerManager.FireOnStorageChanged(new Net.Vpc.Upa.Callbacks.PersistenceUnitEvent(this, persistenceGroup, Net.Vpc.Upa.EventPhase.AFTER));
            this.structureModification = false;
        }


        public virtual void Close() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Persistence.EntityExecutionContext context = CreateContext(Net.Vpc.Upa.Persistence.ContextOperation.CLOSE, defaultHints);
            persistenceUnitListenerManager.FireOnClose(new Net.Vpc.Upa.Callbacks.PersistenceUnitEvent(this, persistenceGroup, Net.Vpc.Upa.EventPhase.BEFORE));
            GetDefaulPackage().Close();
            closed = true;
            persistenceUnitListenerManager.FireOnClose(new Net.Vpc.Upa.Callbacks.PersistenceUnitEvent(this, persistenceGroup, Net.Vpc.Upa.EventPhase.AFTER));
        }


        public override string ToString() {
            return persistenceGroup + "." + name;
        }

        public virtual bool IsClosed() {
            return closed;
        }


        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Index> GetIndexes() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return registrationModel.GetIndexes();
        }


        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Index> GetIndexes(string entityName) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return registrationModel.GetIndexes(entityName);
        }


        public virtual Net.Vpc.Upa.Bulk.ImportExportManager GetImportExportManager() {
            if (importExportManager == null) {
                Net.Vpc.Upa.Bulk.ImportExportManager m = GetFactory().CreateObject<Net.Vpc.Upa.Bulk.ImportExportManager>(typeof(Net.Vpc.Upa.Bulk.ImportExportManager));
                Net.Vpc.Upa.Impl.Util.DefaultBeanAdapter a = new Net.Vpc.Upa.Impl.Util.DefaultBeanAdapter(m);
                a.SetProperty("persistenceUnit", this);
                importExportManager = m;
            }
            return importExportManager;
        }

        public virtual Net.Vpc.Upa.Types.DataTypeTransformFactory GetTypeTransformFactory() {
            return typeTransformFactory;
        }


        public virtual void SetTypeTransformFactory(Net.Vpc.Upa.Types.DataTypeTransformFactory typeTransformFactory) {
            this.typeTransformFactory = typeTransformFactory;
        }


        public virtual void SetPersistenceNameConfig(Net.Vpc.Upa.Persistence.PersistenceNameConfig nameStrategyModel) {
            if (IsStarted()) {
                throw new Net.Vpc.Upa.Exceptions.UPAException("PersisteneUnitAreadyStarted");
            }
            this.persistenceNameConfig = nameStrategyModel == null ? new Net.Vpc.Upa.Persistence.PersistenceNameConfig(Net.Vpc.Upa.Persistence.UPAContextConfig.XML_ORDER) : nameStrategyModel;
        }


        public virtual Net.Vpc.Upa.Persistence.PersistenceNameConfig GetPersistenceNameConfig() {
            return persistenceNameConfig;
        }


        public virtual bool IsAutoStart() {
            return autoStart;
        }


        public virtual void SetAutoStart(bool @value) {
            if (IsStarted()) {
                throw new Net.Vpc.Upa.Exceptions.UPAException("AlreadyStarted");
            }
            this.autoStart = @value;
        }


        public virtual void AddContextAnnotationStrategyFilter(Net.Vpc.Upa.Config.ScanFilter filter) {
            filters.Add(filter);
        }


        public virtual void RemoveContextAnnotationStrategyFilter(Net.Vpc.Upa.Config.ScanFilter filter) {
            filters.Remove(filter);
        }


        public virtual Net.Vpc.Upa.Config.ScanFilter[] GetContextAnnotationStrategyFilters() {
            return filters.ToArray();
        }


        public virtual Net.Vpc.Upa.Persistence.ConnectionConfig[] GetConnectionConfigs() {
            return connectionConfigs.ToArray();
        }


        public virtual Net.Vpc.Upa.Persistence.ConnectionConfig[] GetRootConnectionConfigs() {
            return rootConnectionConfigs.ToArray();
        }


        public virtual void AddConnectionConfig(Net.Vpc.Upa.Persistence.ConnectionConfig connectionConfig) {
            connectionConfigs.Add(connectionConfig);
        }


        public virtual void RemoveConnectionConfig(int index) {
            connectionConfigs.RemoveAt(index);
        }


        public virtual void AddRootConnectionConfig(Net.Vpc.Upa.Persistence.ConnectionConfig connectionConfig) {
            rootConnectionConfigs.Add(connectionConfig);
        }


        public virtual void RemoveRootConnectionConfig(int index) {
            rootConnectionConfigs.RemoveAt(index);
        }

        public virtual Net.Vpc.Upa.Impl.Config.Decorations.DecorationRepository GetDecorationRepository() {
            return decorationRepository;
        }

        public virtual Net.Vpc.Upa.Impl.Config.EntityDescriptorResolver GetEntityDescriptorResolver() {
            return entityDescriptorResolver;
        }

        public virtual Net.Vpc.Upa.Impl.Event.PersistenceUnitListenerManager GetPersistenceUnitListenerManager() {
            return persistenceUnitListenerManager;
        }


        public virtual Net.Vpc.Upa.UserPrincipal GetUserPrincipal() {
            return GetUserPrincipal(GetCurrentSession());
        }

        public virtual Net.Vpc.Upa.UserPrincipal GetUserPrincipal(Net.Vpc.Upa.Session currentSession) {
            if (currentSession == null) {
                return null;
            }
            return currentSession.GetParam<T>(this, typeof(Net.Vpc.Upa.UserPrincipal), Net.Vpc.Upa.Impl.SessionParams.USER_PRINCIPAL, null);
        }


        public virtual void Login(string login, string credentials) {
            Net.Vpc.Upa.Session currentSession = GetCurrentSession();
            Net.Vpc.Upa.UserPrincipal p = GetSecurityManager().Login(login, credentials);
            currentSession.PushContext();
            currentSession.SetParam(this, Net.Vpc.Upa.Impl.SessionParams.USER_PRINCIPAL, p);
        }


        public virtual void LoginPrivileged(string login) {
            Net.Vpc.Upa.Session currentSession = GetCurrentSession();
            Net.Vpc.Upa.UserPrincipal p = GetSecurityManager().LoginPrivileged(login);
            currentSession.PushContext();
            currentSession.SetParam(this, Net.Vpc.Upa.Impl.SessionParams.USER_PRINCIPAL, p);
            if (login == null || login.Equals("")) {
                currentSession.SetParam(this, Net.Vpc.Upa.Impl.SessionParams.SYSTEM, privateUUID.ToString());
            }
        }


        public virtual void Logout() {
            Net.Vpc.Upa.Session currentSession = GetCurrentSession();
            Net.Vpc.Upa.UserPrincipal user = currentSession.GetImmediateParam<T>(this, typeof(Net.Vpc.Upa.UserPrincipal), Net.Vpc.Upa.Impl.SessionParams.USER_PRINCIPAL, null);
            if (user != null) {
                currentSession.PopContext();
            } else {
                user = currentSession.GetParam<T>(this, typeof(Net.Vpc.Upa.UserPrincipal), Net.Vpc.Upa.Impl.SessionParams.USER_PRINCIPAL, null);
                if (user != null) {
                    while (true) {
                        currentSession.PopContext();
                        user = currentSession.GetImmediateParam<T>(this, typeof(Net.Vpc.Upa.UserPrincipal), Net.Vpc.Upa.Impl.SessionParams.USER_PRINCIPAL, null);
                        if (user != null) {
                            break;
                        }
                    }
                    return;
                }
                throw new System.Exception("Invalid Logout");
            }
        }


        public virtual bool CurrentSessionExists() {
            return GetPersistenceGroup().CurrentSessionExists();
        }


        public virtual Net.Vpc.Upa.Key CreateKey(params object [] keyValues) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return keyValues == null ? null : new Net.Vpc.Upa.Impl.DefaultKey(keyValues);
        }


        public virtual Net.Vpc.Upa.Callback AddCallback(Net.Vpc.Upa.CallbackConfig callbackConfig) {
            Net.Vpc.Upa.Callback c = GetPersistenceGroup().GetContext().CreateCallback(callbackConfig);
            AddCallback(c);
            return c;
        }


        public virtual void AddCallback(Net.Vpc.Upa.Callback callback) {
            Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback b = (Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback) callback;
            System.Collections.Generic.IDictionary<string , object> c = b.GetConfiguration();
            if (callback.GetCallbackType() == Net.Vpc.Upa.CallbackType.ON_EVAL) {
                string functionName = c == null ? null : (string) Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(c,"functionName");
                if (Net.Vpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(functionName)) {
                    throw new Net.Vpc.Upa.Exceptions.UPAException("MissingCallbackFunctionName");
                }
                Net.Vpc.Upa.Types.DataType returnType = (Net.Vpc.Upa.Types.DataType) Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(c,"returnType");
                if (returnType == null) {
                    throw new Net.Vpc.Upa.Exceptions.UPAException("MissingCallbackReturnType");
                }
                GetExpressionManager().AddFunction(functionName, returnType, new Net.Vpc.Upa.Impl.Eval.Functions.FunctionCallback(b));
            } else {
                persistenceUnitListenerManager.AddCallback(callback);
            }
        }


        public virtual void RemoveCallback(Net.Vpc.Upa.Callback callback) {
            Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback b = (Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback) callback;
            System.Collections.Generic.IDictionary<string , object> c = b.GetConfiguration();
            if (callback.GetCallbackType() == Net.Vpc.Upa.CallbackType.ON_EVAL) {
                string functionName = c == null ? null : (string) Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(c,"functionName");
                if (Net.Vpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(functionName)) {
                    throw new Net.Vpc.Upa.Exceptions.UPAException("MissingCallbackFunctionName");
                }
                GetExpressionManager().RemoveFunction(functionName);
            }
            persistenceUnitListenerManager.RemoveCallback(callback);
        }


        public virtual Net.Vpc.Upa.Callback[] GetCallbacks(Net.Vpc.Upa.CallbackType callbackType, Net.Vpc.Upa.ObjectType objectType, string name, bool system, bool preparedOnly, Net.Vpc.Upa.EventPhase phase) {
            if (callbackType == Net.Vpc.Upa.CallbackType.ON_EVAL) {
                System.Collections.Generic.List<Net.Vpc.Upa.Callback> all = new System.Collections.Generic.List<Net.Vpc.Upa.Callback>();
                foreach (Net.Vpc.Upa.FunctionDefinition function in GetExpressionManager().GetFunctions()) {
                    if (function.GetFunction() is Net.Vpc.Upa.Impl.Eval.Functions.FunctionCallback) {
                        all.Add(((Net.Vpc.Upa.Impl.Eval.Functions.FunctionCallback) function.GetFunction()).GetCallback());
                    }
                }
                return all.ToArray();
            }
            return persistenceUnitListenerManager.GetCurrentCallbacks(callbackType, objectType, name, system, preparedOnly, phase);
        }


        public virtual Net.Vpc.Upa.Persistence.UConnection GetConnection() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Session session = GetCurrentSession();
            Net.Vpc.Upa.Persistence.UConnection connection = session.GetParam<T>(this, typeof(Net.Vpc.Upa.Persistence.UConnection), Net.Vpc.Upa.Impl.SessionParams.CONNECTION, null);
            if (connection == null) {
                connection = GetPersistenceStore().CreateConnection();
                session.SetParam(this, Net.Vpc.Upa.Impl.SessionParams.CONNECTION, connection);
                session.AddSessionListener(new Net.Vpc.Upa.Impl.Persistence.CloseOnContextPopSessionListener(this, connection));
            }
            return connection;
        }


        public virtual void SetIdentityConstraintsEnabled(Net.Vpc.Upa.Entity entity, bool enable) {
            Net.Vpc.Upa.Persistence.EntityExecutionContext context = CreateContext(Net.Vpc.Upa.Persistence.ContextOperation.COMMIT_STORAGE, defaultHints);
            GetPersistenceStore().SetIdentityConstraintsEnabled(entity, enable, context);
        }

        public virtual Net.Vpc.Upa.Persistence.UConnection GetMetadataConnection() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Session session = GetCurrentSession();
            Net.Vpc.Upa.Persistence.UConnection connection = session.GetParam<T>(this, typeof(Net.Vpc.Upa.Persistence.UConnection), Net.Vpc.Upa.Impl.SessionParams.METADATA_CONNECTION, null);
            if (connection == null) {
                connection = session.GetParam<T>(this, typeof(Net.Vpc.Upa.Persistence.UConnection), Net.Vpc.Upa.Impl.SessionParams.CONNECTION, null);
            }
            if (connection == null) {
                connection = GetPersistenceStore().CreateConnection();
                session.SetParam(this, Net.Vpc.Upa.Impl.SessionParams.CONNECTION, connection);
                session.AddSessionListener(new Net.Vpc.Upa.Impl.Persistence.CloseOnContextPopSessionListener(this, connection));
            }
            return connection;
        }

        public virtual Net.Vpc.Upa.Persistence.EntityExecutionContext CreateContext(Net.Vpc.Upa.Persistence.ContextOperation operation, System.Collections.Generic.IDictionary<string , object> hints) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            //        Session currentSession = persistenceUnit.getPersistenceGroup().getCurrentSession();
            Net.Vpc.Upa.Persistence.EntityExecutionContext context = null;
            //        if (currentSession != null) {
            //            context = currentSession.getParam(persistenceUnit, ExecutionContext.class, SessionParams.EXECUTION_CONTEXT, null);
            //            if (context
            //                    == null) {
            //                context = persistenceUnit.getFactory().createObject(ExecutionContext.class, null);
            //                currentSession.setParam(persistenceUnit, SessionParams.EXECUTION_CONTEXT, context);
            //            }
            //        } else {
            //            context = persistenceUnit.getFactory().createObject(ExecutionContext.class, null);
            //        }
            context = GetFactory().CreateObject<Net.Vpc.Upa.Persistence.EntityExecutionContext>(typeof(Net.Vpc.Upa.Persistence.EntityExecutionContext));
            context.InitPersistenceUnit(this, GetPersistenceStore(), operation);
            context.SetHints(hints);
            return context;
        }

        protected internal virtual Net.Vpc.Upa.InvokeContext PrepareInvokeContext(Net.Vpc.Upa.InvokeContext c) {
            if (c == null) {
                c = new Net.Vpc.Upa.InvokeContext();
            } else {
                c = c.Copy();
            }
            c.SetPersistenceGroup(GetPersistenceGroup());
            c.SetPersistenceUnit(this);
            return c;
        }


        public virtual  T Invoke<T>(Net.Vpc.Upa.Action<T> action, Net.Vpc.Upa.InvokeContext invokeContext) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceGroup().GetContext().Invoke<T>(action, PrepareInvokeContext(invokeContext));
        }


        public virtual  T InvokePrivileged<T>(Net.Vpc.Upa.Action<T> action, Net.Vpc.Upa.InvokeContext invokeContext) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceGroup().GetContext().Invoke<T>(action, PrepareInvokeContext(invokeContext));
        }


        public virtual void Invoke(Net.Vpc.Upa.VoidAction action, Net.Vpc.Upa.InvokeContext invokeContext) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            GetPersistenceGroup().GetContext().Invoke(action, PrepareInvokeContext(invokeContext));
        }


        public virtual void InvokePrivileged(Net.Vpc.Upa.VoidAction action, Net.Vpc.Upa.InvokeContext invokeContext) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            GetPersistenceGroup().GetContext().InvokePrivileged(action, PrepareInvokeContext(invokeContext));
        }


        public virtual  T Invoke<T>(Net.Vpc.Upa.Action<T> action) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceGroup().GetContext().Invoke<T>(action, PrepareInvokeContext(null));
        }


        public virtual  T InvokePrivileged<T>(Net.Vpc.Upa.Action<T> action) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceGroup().GetContext().InvokePrivileged<T>(action, PrepareInvokeContext(null));
        }


        public virtual void Invoke(Net.Vpc.Upa.VoidAction action) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            GetPersistenceGroup().GetContext().Invoke(action, PrepareInvokeContext(null));
        }


        public virtual void InvokePrivileged(Net.Vpc.Upa.VoidAction action) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            GetPersistenceGroup().GetContext().InvokePrivileged(action, PrepareInvokeContext(null));
        }


        public virtual System.Collections.Generic.IComparer<Net.Vpc.Upa.Entity> GetDependencyComparator() {
            return Net.Vpc.Upa.Impl.DefaultEntityDependencyComparator.INSTANCE;
        }


        public virtual  T CopyObject<T>(T r) {
            if (System.Collections.Generic.EqualityComparer<T>.Default.Equals(r,default(T))) {
                return default(T);
            }
            return GetEntity(r).GetBuilder().CopyObject<T>(r);
        }


        public virtual  T CopyObject<T>(string entityName, T r) {
            if (System.Collections.Generic.EqualityComparer<T>.Default.Equals(r,default(T))) {
                return default(T);
            }
            return GetEntity(r).GetBuilder().CopyObject<T>(r);
        }


        public virtual  T CopyObject<T>(System.Type entityType, T r) {
            if (System.Collections.Generic.EqualityComparer<T>.Default.Equals(r,default(T))) {
                return default(T);
            }
            return GetEntity(r).GetBuilder().CopyObject<T>(r);
        }


        public virtual bool IsEmpty(string entityName) {
            return GetEntity(entityName).IsEmpty();
        }


        public virtual bool IsEmpty(System.Type entityType) {
            return GetEntity(entityType).IsEmpty();
        }


        public virtual long GetEntityCount(string entityName) {
            return GetEntity(entityName).GetEntityCount();
        }


        public virtual long GetEntityCount(System.Type entityType) {
            return GetEntity(entityType).GetEntityCount();
        }
    }
}
