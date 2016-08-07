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


    public class DefaultEntity : Net.Vpc.Upa.Impl.AbstractUPAObject, Net.Vpc.Upa.Entity {

        public const string PERSIST_USED_FIELDS = "PERSIST_USED_FIELDS";

        public const string PERSIST_DEPENDENT_FIELDS = "PERSIST_DEPENDENT_FIELDS";

        public const string UPDATE_DEPENDENT_FIELDS = "UPDATE_DEPENDENT_FIELDS";

        private static readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.Vpc.Upa.Impl.DefaultEntity)).FullName);

        private static readonly Net.Vpc.Upa.Filters.FieldFilter FIELD_FILTER_PERSIST_NON_NULLABLE = new Net.Vpc.Upa.Impl.Util.Filters.PersistNonNullableFieldFilter();

        private static readonly Net.Vpc.Upa.Filters.FieldFilter FIELD_FILTER_PERSIST_WITH_DEFAULT_VALUE = new Net.Vpc.Upa.Impl.Util.Filters.PersistWithDefaultValueFieldFilter();

        public static bool VALIDATE_IF_CHANGED = false;

        public static int MAX_CACHE_SIZE = 20;

        internal Net.Vpc.Upa.Impl.DefaultEntityPrivateListener objListener;

        private string shortName;

        private Net.Vpc.Upa.Impl.Util.RecordListenerSupport recordListenerSupport;

        private System.Type idType;

        private System.Type entityType;

        private Net.Vpc.Upa.Impl.DefaultEntityBuilder entityBuilder;

        private System.Collections.Generic.IList<Net.Vpc.Upa.EntityPart> items = new System.Collections.Generic.List<Net.Vpc.Upa.EntityPart>();

        private System.Collections.Generic.IDictionary<string , Net.Vpc.Upa.EntityPart> itemsByName = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.EntityPart>();

        private System.Collections.Generic.IDictionary<string , Net.Vpc.Upa.Callbacks.Trigger> triggers = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Callbacks.Trigger>();

        internal System.Collections.Generic.IDictionary<string , Net.Vpc.Upa.Field> fieldsMap = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Field>();

        private Net.Vpc.Upa.Field mainRendererField;

        private bool closed;

        private Net.Vpc.Upa.Impl.Util.CacheMap<Net.Vpc.Upa.Filters.FieldFilter , System.Collections.Generic.IList<Net.Vpc.Upa.Field>> fieldsByFilter = new Net.Vpc.Upa.Impl.Util.CacheMap<Net.Vpc.Upa.Filters.FieldFilter , System.Collections.Generic.IList<Net.Vpc.Upa.Field>>(MAX_CACHE_SIZE);

        private System.Collections.Generic.ISet<string> dependsOnTables = new System.Collections.Generic.SortedSet<string>();

        private string parentSecurityAction;

        private Net.Vpc.Upa.Relationship compositionRelation;

        private Net.Vpc.Upa.Package parent;

        private Net.Vpc.Upa.EntityDescriptor entityDescriptor;

        private Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.EntityModifier> userIncludeModifiers;

        private Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.EntityModifier> userExcludeModifiers;

        private Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.EntityModifier> effectiveModifiers;

        /**
             * name in the rdbms
             */
        private Net.Vpc.Upa.Expressions.Order listOrder;

        private Net.Vpc.Upa.EntityNavigator navigator;

        private System.Collections.Generic.List<Net.Vpc.Upa.Index> indexes;

        private Net.Vpc.Upa.Types.DataType dataType;

        private int tuningMaxInline = -1;

        private Net.Vpc.Upa.Impl.DefaultEntityExtensionManager extensionManager;

        private Net.Vpc.Upa.Persistence.EntityOperationManager entityOperationManager;

        private int triggerAnonymousNameIndex = 1;

        private Net.Vpc.Upa.EntityShield shield;

        private Net.Vpc.Upa.Impl.Persistence.FieldListPersistenceInfo fieldListPersistenceInfo = new Net.Vpc.Upa.Impl.Persistence.FieldListPersistenceInfo();

        private System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Expressions.Expression> objectfilters = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Expressions.Expression>();

        private Net.Vpc.Upa.EntitySecurityManager entitySecurityManager;

        private Net.Vpc.Upa.BeanType beanType;

        private Net.Vpc.Upa.Impl.DefaultEntityCache cache = new Net.Vpc.Upa.Impl.DefaultEntityCache();

        private System.Collections.Generic.IDictionary<string , object> defaultHints;

        public DefaultEntity()  : base(){

            objListener = new Net.Vpc.Upa.Impl.DefaultEntityPrivateListener(this);
            userIncludeModifiers = Net.Vpc.Upa.FlagSets.NoneOf<Net.Vpc.Upa.EntityModifier>();
            userExcludeModifiers = Net.Vpc.Upa.FlagSets.NoneOf<Net.Vpc.Upa.EntityModifier>();
            effectiveModifiers = Net.Vpc.Upa.FlagSets.NoneOf<Net.Vpc.Upa.EntityModifier>();
            entityBuilder = new Net.Vpc.Upa.Impl.DefaultEntityBuilder(this);
            indexes = new System.Collections.Generic.List<Net.Vpc.Upa.Index>();
        }

        private static Net.Vpc.Upa.Expressions.Expression GetFieldExpression(Net.Vpc.Upa.Field field, bool forPersist) {
            if (forPersist) {
                return (field.GetPersistFormula() is Net.Vpc.Upa.ExpressionFormula) ? ((Net.Vpc.Upa.ExpressionFormula) field.GetPersistFormula()).GetExpression() : null;
            } else {
                return (field.GetUpdateFormula() is Net.Vpc.Upa.ExpressionFormula) ? ((Net.Vpc.Upa.ExpressionFormula) field.GetUpdateFormula()).GetExpression() : null;
            }
        }

        public static string[] GetTableNames(Net.Vpc.Upa.Impl.DefaultEntity[] tables) {
            string[] names = new string[tables.Length];
            for (int i = 0; i < tables.Length; i++) {
                names[i] = tables[i].GetName();
            }
            return names;
        }

        public virtual Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.EntityModifier> GetUserModifiers() {
            return userIncludeModifiers;
        }

        public virtual void SetUserModifiers(Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.EntityModifier> modifiers) {
            this.userIncludeModifiers = modifiers;
        }

        public virtual Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.EntityModifier> GetUserExcludeModifiers() {
            return userExcludeModifiers;
        }

        public virtual void SetUserExcludeModifiers(Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.EntityModifier> modifiers) {
            this.userExcludeModifiers = modifiers;
        }

        public virtual Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.EntityModifier> GetModifiers() {
            return effectiveModifiers;
        }


        public virtual void SetModifiers(Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.EntityModifier> effectiveModifiers) {
            this.effectiveModifiers = effectiveModifiers;
        }


        public override string GetAbsoluteName() {
            return GetName();
        }


        public override void SetPersistenceUnit(Net.Vpc.Upa.PersistenceUnit persistenceUnit) {
            base.SetPersistenceUnit(persistenceUnit);
            Net.Vpc.Upa.ObjectFactory factory = GetPersistenceUnit().GetFactory();
            SetShield(factory.CreateObject<Net.Vpc.Upa.EntityShield>(typeof(Net.Vpc.Upa.EntityShield), null));
            extensionManager = factory.CreateObject<Net.Vpc.Upa.Impl.DefaultEntityExtensionManager>(typeof(Net.Vpc.Upa.Impl.DefaultEntityExtensionManager));
            tuningMaxInline = GetPersistenceUnit().GetProperties().GetInt((typeof(Net.Vpc.Upa.Relationship)).FullName + ".maxInline", 10);
            entityOperationManager = factory.CreateObject<Net.Vpc.Upa.Persistence.EntityOperationManager>(typeof(Net.Vpc.Upa.Persistence.EntityOperationManager));
            recordListenerSupport = new Net.Vpc.Upa.Impl.Util.RecordListenerSupport(this, ((Net.Vpc.Upa.Impl.DefaultPersistenceUnit) persistenceUnit).GetPersistenceUnitListenerManager());
            AddTrigger(null, cache.cache_isEmpty_Listener);
        }

        public virtual void CommitStructureModification(Net.Vpc.Upa.Persistence.PersistenceStore persistenceStore) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.ObjectFactory factory = GetPersistenceUnit().GetFactory();
            ((Net.Vpc.Upa.Impl.Persistence.DefaultEntityOperationManager) entityOperationManager).Init(this, persistenceStore);
            fieldListPersistenceInfo.entity = this;
            fieldListPersistenceInfo.persistenceStore = persistenceStore;
            foreach (Net.Vpc.Upa.Field field in GetFields()) {
                ValidateField(field);
            }
            fieldListPersistenceInfo.Update();
            beanType = null;
        }

        public virtual bool Exists() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            try {
                GetEntityCount();
                return true;
            } catch (Net.Vpc.Upa.Exceptions.UPAException e) {
                return false;
            }
        }

        public virtual Net.Vpc.Upa.Entity GetParentEntity() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return compositionRelation == null ? null : compositionRelation.GetTargetRole().GetEntity();
        }

        public virtual Net.Vpc.Upa.Relationship GetCompositionRelation() {
            return this.compositionRelation;
        }

        /**
             * called by PersistenceUnitFilter
             */
        public virtual void SetCompositionRelationship(Net.Vpc.Upa.Relationship compositionRelation) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (compositionRelation == null) {
                this.compositionRelation = null;
            } else {
                if (compositionRelation.GetRelationshipType() != Net.Vpc.Upa.RelationshipType.COMPOSITION) {
                    throw new System.ArgumentException ("Invalid Relationship type " + compositionRelation);
                }
                //            if (this.compositionRelation != null) {
                //                throw new IllegalArgumentException("Entity " + getName()
                //                        + " is already composing " + getParentEntity() + " via "
                //                        + this.compositionRelation
                //                        + ". It could not accept new Composition via "
                //                        + compositionRelation);
                //            }
                this.compositionRelation = compositionRelation;
            }
        }

        public virtual string GetParentSecurityAction() {
            return parentSecurityAction == null ? GetParentEntity() == null ? null : GetParentEntity().GetName() : parentSecurityAction;
        }

        public virtual void SetParentSecurityAction(string parentSecurityAction) {
            this.parentSecurityAction = parentSecurityAction;
        }

        public virtual Net.Vpc.Upa.Index AddIndex(string indexName, bool unique, params string [] fields) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (fields == null || fields.Length == 0) {
                throw new System.ArgumentException ("Index Fields Count == 0");
            }
            System.Collections.Generic.IList<string> fieldList = new System.Collections.Generic.List<string>(new System.Collections.Generic.HashSet<string>(new System.Collections.Generic.List<string>(fields)));
            Net.Vpc.Upa.Index index = GetPersistenceUnit().GetFactory().CreateObject<Net.Vpc.Upa.Index>(typeof(Net.Vpc.Upa.Index));
            if (Net.Vpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(indexName)) {
                System.Text.StringBuilder b = new System.Text.StringBuilder("IX").Append(GetName());
                foreach (string f in fieldList) {
                    b.Append("_").Append(f);
                }
                indexName = b.ToString();
            }
            index.SetName(indexName);
            Net.Vpc.Upa.Impl.Util.DefaultBeanAdapter adapter = Net.Vpc.Upa.Impl.Util.UPAUtils.Prepare(GetPersistenceUnit(), index, indexName);
            adapter.Inject("unique", unique);
            adapter.Inject("entity", this);
            adapter.Inject("fieldNames", fieldList.ToArray());
            //List<T> items, T child, int index, UPAObject newParent, UPAObject propertyChangeSupport, ItemInterceptor<T> interceptor
            Net.Vpc.Upa.Impl.Util.ListUtils.Add<T>(indexes, index, -1, this, this, null);
            InvalidateStructureCache();
            return index;
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Index> GetIndexes(bool? unique) {
            System.Collections.Generic.IList<Net.Vpc.Upa.Index> allIndexes = GetPersistenceUnit().GetIndexes(GetName());
            if (unique == null) {
                return allIndexes;
            } else {
                bool x = (unique).Value;
                System.Collections.Generic.IList<Net.Vpc.Upa.Index> uniqueIndexes = new System.Collections.Generic.List<Net.Vpc.Upa.Index>();
                foreach (Net.Vpc.Upa.Index index in allIndexes) {
                    if (index.IsUnique() == x) {
                        uniqueIndexes.Add(index);
                    }
                }
                return uniqueIndexes;
            }
        }

        public virtual  System.Collections.Generic.IList<Net.Vpc.Upa.PrimitiveField> ToPrimitiveFields<T>(System.Collections.Generic.IList<T> parts) /* throws Net.Vpc.Upa.Exceptions.UPAException */  where  T : Net.Vpc.Upa.EntityPart {
            System.Collections.Generic.List<Net.Vpc.Upa.PrimitiveField> v = new System.Collections.Generic.List<Net.Vpc.Upa.PrimitiveField>((parts).Count);
            FillPrimitiveFields<T>(parts, v);
            return v;
        }


        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Field> GetFields(System.Collections.Generic.IList<Net.Vpc.Upa.EntityPart> parts) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.List<Net.Vpc.Upa.Field> v = new System.Collections.Generic.List<Net.Vpc.Upa.Field>((parts).Count);
            FillFields(parts, v);
            return v;
        }

        private void FillFields(System.Collections.Generic.IList<Net.Vpc.Upa.EntityPart> parts, System.Collections.Generic.IList<Net.Vpc.Upa.Field> c) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            foreach (Net.Vpc.Upa.EntityPart part in parts) {
                if (part is Net.Vpc.Upa.Field) {
                    c.Add((Net.Vpc.Upa.Field) part);
                } else if (part is Net.Vpc.Upa.Section) {
                    FillFields(((Net.Vpc.Upa.Section) part).GetParts(), c);
                }
            }
        }

        private  void FillPrimitiveFields<T>(System.Collections.Generic.IList<T> parts, System.Collections.Generic.IList<Net.Vpc.Upa.PrimitiveField> c) /* throws Net.Vpc.Upa.Exceptions.UPAException */  where  T : Net.Vpc.Upa.EntityPart {
            foreach (Net.Vpc.Upa.EntityPart part in parts) {
                if (part is Net.Vpc.Upa.PrimitiveField) {
                    c.Add((Net.Vpc.Upa.PrimitiveField) part);
                } else if (part is Net.Vpc.Upa.CompoundField) {
                    System.Collections.Generic.IList<Net.Vpc.Upa.PrimitiveField> primitiveFields = ((Net.Vpc.Upa.CompoundField) part).GetFields();
                    foreach (Net.Vpc.Upa.PrimitiveField f in primitiveFields) {
                        c.Add(f);
                    }
                } else if (part is Net.Vpc.Upa.Section) {
                    FillPrimitiveFields<Net.Vpc.Upa.EntityPart>(((Net.Vpc.Upa.Section) part).GetParts(), c);
                }
            }
        }

        private void AddPart(Net.Vpc.Upa.EntityPart item, int index) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Impl.Util.ListUtils.Add<Net.Vpc.Upa.EntityPart>(items, item, index, this, this, new Net.Vpc.Upa.Impl.DefaultEntityPrivateAddItemInterceptor(this));
            itemsByName[item.GetName()]=item;
            InvalidateStructureCache();
        }

        public virtual void RemovePart(int index) {
            Net.Vpc.Upa.EntityPart item = Net.Vpc.Upa.Impl.Util.ListUtils.Remove<Net.Vpc.Upa.EntityPart>(items, index, this, new Net.Vpc.Upa.Impl.DefaultEntityPrivateRemoveItemInterceptor());
            itemsByName.Remove(item.GetName());
        }

        public virtual void MovePart(int index, int newIndex) {
            Net.Vpc.Upa.Impl.Util.ListUtils.MoveTo<T>(items, index, newIndex, this, null);
            InvalidateStructureCache();
        }

        public virtual void MovePart(string partName, int newIndex) {
            MovePart(IndexOfPart(partName), newIndex);
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.EntityPart> GetParts() {
            return items;
        }


        public virtual int IndexOfField(string field) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<string> strings = new System.Collections.Generic.List<string>(new System.Collections.Generic.HashSet<string>(fieldsMap.Keys));
            return strings.IndexOf(field);
        }

        public virtual int IndexOfPart(Net.Vpc.Upa.EntityPart child) {
            return items.IndexOf(child);
        }

        public virtual int IndexOfPart(string childName) {
            int index = 0;
            foreach (Net.Vpc.Upa.EntityPart part in items) {
                if (childName.Equals(part.GetName())) {
                    return index;
                }
                index++;
            }
            return -1;
        }

        public virtual int IndexOfPart(string childName, bool countSections, bool countCompoundFields, bool countFieldsInCompoundFields, bool countFieldsInSections) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            int index = 0;
            System.Collections.Generic.Stack<Net.Vpc.Upa.EntityPart> stack = new System.Collections.Generic.Stack<Net.Vpc.Upa.EntityPart>();
            int partSize = (items).Count;
            for (int i = partSize - 1; i >= 0; i--) {
                stack.Push(items[i]);
            }
            while (!(stack.Count==0)) {
                Net.Vpc.Upa.EntityPart entityPart = stack.Pop();
                if (childName.Equals(entityPart.GetName())) {
                    return index;
                } else if (entityPart is Net.Vpc.Upa.Section) {
                    System.Collections.Generic.IList<Net.Vpc.Upa.EntityPart> p = ((Net.Vpc.Upa.Section) entityPart).GetParts();
                    for (int i = 0; i < (p).Count; i++) {
                        stack.Push(p[(p).Count - 1 - i]);
                    }
                    if (countSections) {
                        index++;
                    }
                } else if (entityPart is Net.Vpc.Upa.CompoundField) {
                    System.Collections.Generic.IList<Net.Vpc.Upa.PrimitiveField> p = ((Net.Vpc.Upa.CompoundField) entityPart).GetFields();
                    for (int i = 0; i < (p).Count; i++) {
                        stack.Push(p[(p).Count - 1 - i]);
                    }
                    if (countCompoundFields) {
                        index++;
                    }
                } else {
                    if (!countFieldsInCompoundFields && entityPart.GetParent() is Net.Vpc.Upa.CompoundField) {
                    } else if (!countFieldsInSections && entityPart.GetParent() is Net.Vpc.Upa.Section) {
                    } else {
                        index++;
                    }
                }
            }
            return -1;
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Callbacks.Trigger> GetTriggers() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return new System.Collections.Generic.List<Net.Vpc.Upa.Callbacks.Trigger>((triggers).Values);
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Callbacks.Trigger> GetSoftTriggers() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return new System.Collections.Generic.List<Net.Vpc.Upa.Callbacks.Trigger>((triggers).Values);
        }


        public virtual Net.Vpc.Upa.Section AddSection(string name, string parentPath, int index) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (name == null) {
                throw new System.NullReferenceException();
            }
            if (name.Contains("/")) {
                throw new System.ArgumentException ("Name cannot contain '/'");
            }
            string[] canonicalPathArray = Net.Vpc.Upa.Impl.Util.UPAUtils.GetCanonicalPathArray(parentPath);
            Net.Vpc.Upa.Section parentModule = null;
            foreach (string n in canonicalPathArray) {
                Net.Vpc.Upa.Section next = null;
                if (parentModule == null) {
                    next = GetSection(n);
                } else {
                    next = parentModule.GetSection(n);
                }
                parentModule = next;
            }
            Net.Vpc.Upa.Section currentModule = GetPersistenceUnit().GetFactory().CreateObject<Net.Vpc.Upa.Section>(typeof(Net.Vpc.Upa.Section));
            Net.Vpc.Upa.Impl.Util.DefaultBeanAdapter a = Net.Vpc.Upa.Impl.Util.UPAUtils.Prepare(GetPersistenceUnit(), currentModule, name);
            if (parentModule == null) {
                AddPart(currentModule, index);
            } else {
                parentModule.AddPart(currentModule, index);
            }
            InvalidateStructureCache();
            return currentModule;
        }

        public virtual Net.Vpc.Upa.Section GetSection(string path) {
            return GetSection(path, Net.Vpc.Upa.MissingStrategy.ERROR);
        }

        public virtual Net.Vpc.Upa.Section FindSection(string path) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetSection(path, Net.Vpc.Upa.MissingStrategy.NULL);
        }

        public virtual Net.Vpc.Upa.Section GetSection(string path, Net.Vpc.Upa.MissingStrategy missingStrategy) {
            if (path == null) {
                throw new System.NullReferenceException();
            }
            string[] canonicalPathArray = Net.Vpc.Upa.Impl.Util.UPAUtils.GetCanonicalPathArray(path);
            if (canonicalPathArray.Length == 0) {
                throw new System.ArgumentException ("invalid module path " + path);
            }
            Net.Vpc.Upa.Section module = null;
            foreach (string n in canonicalPathArray) {
                Net.Vpc.Upa.Section next = null;
                if (module == null) {
                    foreach (Net.Vpc.Upa.EntityPart schemaItem in items) {
                        if (schemaItem is Net.Vpc.Upa.Section) {
                            if (schemaItem.GetName().Equals(n)) {
                                next = (Net.Vpc.Upa.Section) schemaItem;
                                break;
                            }
                        }
                    }
                    if (next == null) {
                        switch(missingStrategy) {
                            case Net.Vpc.Upa.MissingStrategy.ERROR:
                                {
                                    throw new Net.Vpc.Upa.Exceptions.NoSuchSectionException(path);
                                }
                            case Net.Vpc.Upa.MissingStrategy.CREATE:
                                {
                                    next = AddSection(n, null);
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
                        next = module.GetSection(n);
                    } catch (Net.Vpc.Upa.Exceptions.NoSuchSectionException e) {
                        switch(missingStrategy) {
                            case Net.Vpc.Upa.MissingStrategy.ERROR:
                                {
                                    throw new Net.Vpc.Upa.Exceptions.NoSuchSectionException(path);
                                }
                            case Net.Vpc.Upa.MissingStrategy.CREATE:
                                {
                                    next = AddSection(n, module.GetPath());
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


        public virtual Net.Vpc.Upa.Section AddSection(string name, string parentPath) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return AddSection(name, parentPath, -1);
        }

        public virtual Net.Vpc.Upa.Section AddSection(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return AddSection(name, null, -1);
        }

        public virtual Net.Vpc.Upa.Section AddSection(string name, int index) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return AddSection(name, null, index);
        }

        public virtual void InvalidateStructureCache() {
            cache.needsRevalidateCache = true;
            if (fieldsByFilter != null) {
                fieldsByFilter.Clear();
            }
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        public virtual void RevalidateStructure() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (cache.needsRevalidateCache) {
                cache.needsRevalidateCache = false;
            }
        }

        public virtual bool NeedsView() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return !(GetFields(Net.Vpc.Upa.Impl.Util.Filters.Fields2.VIEW).Count==0);
        }

        public virtual Net.Vpc.Upa.Types.DataType GetDataType() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (dataType == null) {
                dataType = new Net.Vpc.Upa.KeyType(this);
            }
            return dataType;
        }

        public virtual void SetDataType(Net.Vpc.Upa.Types.DataType newDataType) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (dataType != newDataType) {
                dataType = newDataType;
            }
        }

        protected internal virtual void ValidateField(Net.Vpc.Upa.Field field) {
            //        final Formula formula = field.getFormula();
            Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.FieldModifier> _effectiveModifiers = field.GetModifiers();
            Net.Vpc.Upa.Persistence.EntityOperationManager epm = GetEntityOperationManager();
            if (epm != null) {
                Net.Vpc.Upa.Persistence.PersistenceStore store = epm.GetPersistenceStore();
                if (store != null) {
                    if (!store.IsViewSupported() && (_effectiveModifiers.Contains(Net.Vpc.Upa.FieldModifier.SELECT_STORED))) {
                        _effectiveModifiers = _effectiveModifiers.Remove(Net.Vpc.Upa.FieldModifier.SELECT_STORED);
                        _effectiveModifiers = _effectiveModifiers.Add(Net.Vpc.Upa.FieldModifier.SELECT_DEFAULT);
                        log.TraceEvent(System.Diagnostics.TraceEventType.Warning,90,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("View is not supported, View Field forced to be persisted {0}",null,field));
                    }
                    //effectiveModifiers = effectiveModifiers.add(UserFieldModifier.STORED_FORMULA);
                    if (!store.IsComplexSelectSupported() && (_effectiveModifiers.Contains(Net.Vpc.Upa.FieldModifier.SELECT_LIVE) || _effectiveModifiers.Contains(Net.Vpc.Upa.FieldModifier.SELECT_STORED))) {
                        //check if complex formula
                        bool complexFormula = false;
                        Net.Vpc.Upa.Formula selectFormula = field.GetSelectFormula();
                        if (selectFormula is Net.Vpc.Upa.ExpressionFormula) {
                            Net.Vpc.Upa.ExpressionFormula ef = (Net.Vpc.Upa.ExpressionFormula) selectFormula;
                            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression compiledExpression = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) Compile(ef.GetExpression());
                            complexFormula = compiledExpression.FindFirstExpression<T>(Net.Vpc.Upa.Impl.Uql.Compiledfilters.CompiledExpressionHelper.SELECT_FILTER) != default(T);
                        } else {
                            complexFormula = true;
                        }
                        if (complexFormula) {
                            _effectiveModifiers = _effectiveModifiers.Remove(Net.Vpc.Upa.FieldModifier.SELECT_LIVE);
                            _effectiveModifiers = _effectiveModifiers.Remove(Net.Vpc.Upa.FieldModifier.SELECT_STORED);
                            _effectiveModifiers = _effectiveModifiers.Add(Net.Vpc.Upa.FieldModifier.PERSIST_FORMULA);
                            _effectiveModifiers = _effectiveModifiers.Add(Net.Vpc.Upa.FieldModifier.UPDATE_FORMULA);
                            if (field.GetUpdateFormula() == null) {
                                field.SetUpdateFormula(field.GetSelectFormula());
                            }
                            if (field.GetPersistFormula() == null) {
                                field.SetPersistFormula(field.GetSelectFormula());
                            }
                            log.TraceEvent(System.Diagnostics.TraceEventType.Warning,90,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Complex fields in SelectFormula are not supported, Field forced to be persisted {0}",null,field));
                        }
                    }
                }
            }
            //effectiveModifiers = effectiveModifiers.add(UserFieldModifier.STORED_FORMULA);
            ((Net.Vpc.Upa.Impl.AbstractField) field).SetEffectiveModifiers(_effectiveModifiers);
        }

        private void CommitFieldModelChanges(Net.Vpc.Upa.Field f) {
            Net.Vpc.Upa.Impl.FieldModifierHelper fmc = new Net.Vpc.Upa.Impl.FieldModifierHelper(f.GetUserModifiers(), f.GetUserExcludeModifiers());
            if (!fmc.Contains(Net.Vpc.Upa.UserFieldModifier.TRANSIENT)) {
                Net.Vpc.Upa.Formula persistFormula = f.GetPersistFormula();
                Net.Vpc.Upa.Formula updateFormula = f.GetUpdateFormula();
                Net.Vpc.Upa.Formula selectFormula = f.GetSelectFormula();
                if (fmc.Contains(Net.Vpc.Upa.UserFieldModifier.ID)) {
                    fmc.Add(Net.Vpc.Upa.FieldModifier.ID);
                }
                //system flags
                if (fmc.Contains(Net.Vpc.Upa.UserFieldModifier.SYSTEM)) {
                    fmc.Add(Net.Vpc.Upa.FieldModifier.SYSTEM);
                }
                if (fmc.Contains(Net.Vpc.Upa.UserFieldModifier.MAIN)) {
                    fmc.Add(Net.Vpc.Upa.FieldModifier.MAIN);
                }
                if (fmc.Contains(Net.Vpc.Upa.UserFieldModifier.SUMMARY)) {
                    fmc.Add(Net.Vpc.Upa.FieldModifier.SUMMARY);
                }
                if (!fmc.Rejects(Net.Vpc.Upa.UserFieldModifier.SELECT)) {
                    fmc.Add(Net.Vpc.Upa.FieldModifier.SELECT);
                    if (selectFormula == null) {
                        fmc.Add(Net.Vpc.Upa.FieldModifier.SELECT_DEFAULT);
                    } else if (selectFormula is Net.Vpc.Upa.ExpressionFormula) {
                        if (fmc.Contains(Net.Vpc.Upa.UserFieldModifier.LIVE)) {
                            fmc.Add(Net.Vpc.Upa.FieldModifier.SELECT_LIVE);
                        } else if (fmc.Contains(Net.Vpc.Upa.UserFieldModifier.COMPILED)) {
                            fmc.Add(Net.Vpc.Upa.FieldModifier.SELECT_STORED);
                        } else {
                            fmc.Add(Net.Vpc.Upa.FieldModifier.SELECT_DEFAULT);
                        }
                    } else if (selectFormula is Net.Vpc.Upa.Sequence) {
                        if (fmc.Contains(Net.Vpc.Upa.UserFieldModifier.LIVE) || fmc.Contains(Net.Vpc.Upa.UserFieldModifier.COMPILED)) {
                            throw new System.ArgumentException ("LIVE and COMPILED elector are supported solely for ExpressionFormula");
                        }
                        fmc.Add(Net.Vpc.Upa.FieldModifier.SELECT_DEFAULT);
                    } else {
                        if (fmc.Contains(Net.Vpc.Upa.UserFieldModifier.LIVE) || fmc.Contains(Net.Vpc.Upa.UserFieldModifier.COMPILED)) {
                            throw new System.ArgumentException ("LIVE and COMPILED elector are supported solely for ExpressionFormula");
                        }
                        if (f.GetDataType() is Net.Vpc.Upa.Types.ManyToOneType) {
                            fmc.Add(Net.Vpc.Upa.FieldModifier.SELECT_DEFAULT);
                        } else {
                            fmc.Add(Net.Vpc.Upa.FieldModifier.SELECT_CUSTOM);
                        }
                    }
                }
                if (!fmc.Rejects(Net.Vpc.Upa.UserFieldModifier.PERSIST) && !fmc.GetEffective().Contains(Net.Vpc.Upa.FieldModifier.SELECT_LIVE) && !fmc.GetEffective().Contains(Net.Vpc.Upa.FieldModifier.SELECT_STORED)) {
                    if (persistFormula == null) {
                        fmc.Add(Net.Vpc.Upa.FieldModifier.PERSIST);
                        fmc.Add(Net.Vpc.Upa.FieldModifier.PERSIST_DEFAULT);
                    } else {
                        fmc.Add(Net.Vpc.Upa.FieldModifier.PERSIST);
                        fmc.Add(Net.Vpc.Upa.FieldModifier.PERSIST_FORMULA);
                        if (persistFormula is Net.Vpc.Upa.Sequence) {
                            fmc.Add(Net.Vpc.Upa.FieldModifier.PERSIST_SEQUENCE);
                        }
                    }
                }
                if (!fmc.Rejects(Net.Vpc.Upa.UserFieldModifier.UPDATE) && !fmc.GetEffective().Contains(Net.Vpc.Upa.FieldModifier.ID) && !fmc.GetEffective().Contains(Net.Vpc.Upa.FieldModifier.SELECT_LIVE) && !fmc.GetEffective().Contains(Net.Vpc.Upa.FieldModifier.SELECT_STORED)) {
                    if (updateFormula == null) {
                        fmc.Add(Net.Vpc.Upa.FieldModifier.UPDATE);
                        fmc.Add(Net.Vpc.Upa.FieldModifier.UPDATE_DEFAULT);
                    } else {
                        fmc.Add(Net.Vpc.Upa.FieldModifier.UPDATE);
                        fmc.Add(Net.Vpc.Upa.FieldModifier.UPDATE_FORMULA);
                        if (updateFormula is Net.Vpc.Upa.Sequence) {
                            fmc.Add(Net.Vpc.Upa.FieldModifier.UPDATE_SEQUENCE);
                        }
                    }
                }
                // check constraints
                if (selectFormula is Net.Vpc.Upa.Sequence) {
                    throw new System.ArgumentException ("Select Formula could not be a sequence");
                }
                if (((f.GetPersistAccessLevel() == Net.Vpc.Upa.AccessLevel.PRIVATE) || (f.GetPersistAccessLevel() == Net.Vpc.Upa.AccessLevel.PRIVATE) || (f.GetPersistAccessLevel() == Net.Vpc.Upa.AccessLevel.PRIVATE)) && fmc.GetEffective().Contains(Net.Vpc.Upa.FieldModifier.MAIN)) {
                    throw new System.ArgumentException ("Field " + GetAbsoluteName() + " could not be define Main and PRIVATE");
                }
                //
                if (fmc.Contains(Net.Vpc.Upa.UserFieldModifier.INDEX)) {
                    bool found = false;
                    foreach (Net.Vpc.Upa.Index index in GetIndexes(null)) {
                        string[] fields = index.GetFieldNames();
                        if (fields.Length == 1 && fields[0].Equals(f.GetName())) {
                            found = true;
                            break;
                        }
                    }
                    if (!found) {
                        AddIndex(null, false, (f.GetName()));
                    }
                }
                if (fmc.Contains(Net.Vpc.Upa.UserFieldModifier.UNIQUE)) {
                    bool found = false;
                    foreach (Net.Vpc.Upa.Index index in GetIndexes(true)) {
                        string[] fields = index.GetFieldNames();
                        if (index.IsUnique() && fields.Length == 1 && fields[0].Equals(f.GetName())) {
                            found = true;
                            break;
                        }
                    }
                    if (!found) {
                        AddIndex(null, true, (f.GetName()));
                    }
                }
            } else {
                fmc.Add(Net.Vpc.Upa.FieldModifier.TRANSIENT);
            }
            ((Net.Vpc.Upa.Impl.AbstractField) f).SetEffectiveModifiers(fmc.GetEffective());
            if (f.GetModifiers().Contains(Net.Vpc.Upa.FieldModifier.PERSIST) && !f.GetModifiers().Contains(Net.Vpc.Upa.FieldModifier.ID)) {
                Net.Vpc.Upa.Types.DataType dt = f.GetDataType();
                if (!dt.IsNullable()) {
                    object defaultValue = f.GetDefaultObject();
                    if (defaultValue == null) {
                        object defaultNonNullValue = dt.GetDefaultNonNullValue();
                        if (defaultNonNullValue == null) {
                            throw new System.ArgumentException ("Field " + f + " is not nullable but could not resolve a valid default value to use");
                        }
                    }
                }
            }
        }

        private void CommitFieldExpressionModelChanges(Net.Vpc.Upa.Field f) {
            Net.Vpc.Upa.Impl.FieldModifierHelper fmc = new Net.Vpc.Upa.Impl.FieldModifierHelper(f.GetUserModifiers(), f.GetUserExcludeModifiers());
            if (!fmc.Contains(Net.Vpc.Upa.UserFieldModifier.TRANSIENT)) {
                Net.Vpc.Upa.Formula persistFormula = f.GetPersistFormula();
                Net.Vpc.Upa.Formula updateFormula = f.GetUpdateFormula();
                //            Formula selectFormula = f.getSelectFormula();
                if (persistFormula != null) {
                    System.Collections.Generic.ISet<Net.Vpc.Upa.Field> usedFields = null;
                    try {
                        usedFields = FindUsedFields(persistFormula);
                    } catch (Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException e) {
                        throw new Net.Vpc.Upa.Exceptions.UPAException("InvalidFormulaExpression", f.GetAbsoluteName(), "PersistFormula", persistFormula);
                    }
                    foreach (Net.Vpc.Upa.Field field in usedFields) {
                        System.Collections.Generic.ISet<Net.Vpc.Upa.Field> c = (System.Collections.Generic.ISet<Net.Vpc.Upa.Field>) field.GetProperties().GetObject<T>(PERSIST_DEPENDENT_FIELDS);
                        if (c == null) {
                            c = new System.Collections.Generic.HashSet<Net.Vpc.Upa.Field>();
                            field.GetProperties().SetObject(PERSIST_DEPENDENT_FIELDS, c);
                        }
                        c.Add(f);
                    }
                    f.GetProperties().SetObject(PERSIST_USED_FIELDS, usedFields);
                }
                if (updateFormula != null) {
                    System.Collections.Generic.ISet<Net.Vpc.Upa.Field> usedFields = null;
                    try {
                        usedFields = FindUsedFields(updateFormula);
                    } catch (Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException e) {
                        throw new Net.Vpc.Upa.Exceptions.UPAException("InvalidFormulaExpression", f.GetAbsoluteName(), "UpdateFormula", persistFormula);
                    }
                    foreach (Net.Vpc.Upa.Field field in usedFields) {
                        System.Collections.Generic.ISet<Net.Vpc.Upa.Field> c = (System.Collections.Generic.ISet<Net.Vpc.Upa.Field>) field.GetProperties().GetObject<T>(UPDATE_DEPENDENT_FIELDS);
                        if (c == null) {
                            c = new System.Collections.Generic.HashSet<Net.Vpc.Upa.Field>();
                            field.GetProperties().SetObject(UPDATE_DEPENDENT_FIELDS, c);
                        }
                        c.Add(f);
                    }
                    f.GetProperties().SetObject(PERSIST_USED_FIELDS, usedFields);
                }
            }
        }

        public virtual void CommitExpressionModelChanges() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> fs = GetFields();
            foreach (Net.Vpc.Upa.Field f in fs) {
                CommitFieldExpressionModelChanges(f);
            }
        }

        public virtual void CommitModelChanges() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            InvalidateStructureCache();
            RevalidateStructure();
            Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.EntityModifier> includedModifiers = GetUserModifiers();
            Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.EntityModifier> excludedModifiers = GetUserExcludeModifiers();
            Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.EntityModifier> _effectiveModifiers = Net.Vpc.Upa.FlagSets.NoneOf<Net.Vpc.Upa.EntityModifier>();
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> fs = GetFields();
            foreach (Net.Vpc.Upa.Field f in fs) {
                CommitFieldModelChanges(f);
                Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.FieldModifier> fm = f.GetModifiers();
                if (fm.Contains(Net.Vpc.Upa.FieldModifier.PERSIST_FORMULA) && !fm.Contains(Net.Vpc.Upa.FieldModifier.TRANSIENT) && !fm.Contains(Net.Vpc.Upa.FieldModifier.PERSIST_SEQUENCE)) {
                    _effectiveModifiers = _effectiveModifiers.Add(Net.Vpc.Upa.EntityModifier.VALIDATE_PERSIST);
                }
                if (fm.Contains(Net.Vpc.Upa.FieldModifier.UPDATE_FORMULA) && !fm.Contains(Net.Vpc.Upa.FieldModifier.TRANSIENT) && !fm.Contains(Net.Vpc.Upa.FieldModifier.UPDATE_SEQUENCE)) {
                    _effectiveModifiers = _effectiveModifiers.Add(Net.Vpc.Upa.EntityModifier.VALIDATE_UPDATE);
                }
            }
            foreach (Net.Vpc.Upa.EntityModifier entityModifier in new Net.Vpc.Upa.EntityModifier[] { Net.Vpc.Upa.EntityModifier.TRANSIENT, Net.Vpc.Upa.EntityModifier.LOCK, Net.Vpc.Upa.EntityModifier.CLEAR, Net.Vpc.Upa.EntityModifier.PRIVATE, Net.Vpc.Upa.EntityModifier.SYSTEM }) {
                if (includedModifiers.Contains(entityModifier)) {
                    _effectiveModifiers = _effectiveModifiers.Add(entityModifier);
                }
            }
            foreach (Net.Vpc.Upa.EntityModifier entityModifier in new Net.Vpc.Upa.EntityModifier[] { Net.Vpc.Upa.EntityModifier.PERSIST, Net.Vpc.Upa.EntityModifier.UPDATE, Net.Vpc.Upa.EntityModifier.REMOVE, Net.Vpc.Upa.EntityModifier.CLONE, Net.Vpc.Upa.EntityModifier.RENAME, Net.Vpc.Upa.EntityModifier.NAVIGATE }) {
                if (includedModifiers.Contains(entityModifier) || !excludedModifiers.Contains(entityModifier)) {
                    _effectiveModifiers = _effectiveModifiers.Add(entityModifier);
                }
            }
            //        if (m.contains(EntityModifier.GENERATED_ID) && !m.contains(EntityModifier.NO_GENERATED_ID)) {
            //            effectiveModifiers = effectiveModifiers.add(EntityModifier.GENERATED_ID);
            //        }
            //        if (includedModifiers.contains(EntityModifier.RESET)) {
            //            _effectiveModifiers = _effectiveModifiers.add(EntityModifier.RESET);
            //        }
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> primaries = GetPrimaryFields();
            if ((primaries).Count == 0) {
                if (_effectiveModifiers.Contains(Net.Vpc.Upa.EntityModifier.NAVIGATE)) {
                    if (includedModifiers.Contains(Net.Vpc.Upa.EntityModifier.NAVIGATE)) {
                        log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("NAVIGATE modifier ignored for " + GetName() + " as no primary field was found.",null));
                    }
                    _effectiveModifiers = _effectiveModifiers.Remove(Net.Vpc.Upa.EntityModifier.NAVIGATE);
                }
            }
            if (mainRendererField == null) {
                System.Collections.Generic.IList<Net.Vpc.Upa.Field> test = new System.Collections.Generic.List<Net.Vpc.Upa.Field>();
                //test primaries first
                Net.Vpc.Upa.Impl.FwkConvertUtils.ListAddRange(test, primaries);
                Net.Vpc.Upa.Impl.FwkConvertUtils.ListAddRange(test, fs);
                foreach (Net.Vpc.Upa.Field field in test) {
                    Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.FieldModifier> efm = field.GetModifiers();
                    if (efm.Contains(Net.Vpc.Upa.FieldModifier.MAIN) && field.GetPersistAccessLevel() != Net.Vpc.Upa.AccessLevel.PRIVATE && field.GetUpdateAccessLevel() != Net.Vpc.Upa.AccessLevel.PRIVATE && field.GetReadAccessLevel() != Net.Vpc.Upa.AccessLevel.PRIVATE && !efm.Contains(Net.Vpc.Upa.FieldModifier.SYSTEM)) {
                        mainRendererField = field;
                        break;
                    }
                }
                if (mainRendererField == null) {
                    foreach (Net.Vpc.Upa.Field field in test) {
                        Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.FieldModifier> efm = field.GetModifiers();
                        if (field.GetPersistAccessLevel() != Net.Vpc.Upa.AccessLevel.PRIVATE && field.GetUpdateAccessLevel() != Net.Vpc.Upa.AccessLevel.PRIVATE && field.GetReadAccessLevel() != Net.Vpc.Upa.AccessLevel.PRIVATE && !efm.Contains(Net.Vpc.Upa.FieldModifier.SYSTEM)) {
                            efm.Add(Net.Vpc.Upa.FieldModifier.MAIN);
                            mainRendererField = field;
                            break;
                        }
                    }
                }
            }
            bool _KeyEditionSupported = false;
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> primaryFields = GetPrimaryFields();
            foreach (Net.Vpc.Upa.Field f in primaryFields) {
                Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.FieldModifier> fm = f.GetModifiers();
                if (!fm.Contains(Net.Vpc.Upa.FieldModifier.PERSIST_FORMULA)) {
                    _KeyEditionSupported = true;
                    break;
                }
            }
            if (includedModifiers.Contains(Net.Vpc.Upa.EntityModifier.USER_ID) || (!excludedModifiers.Contains(Net.Vpc.Upa.EntityModifier.USER_ID) && _KeyEditionSupported)) {
                _effectiveModifiers = _effectiveModifiers.Add(Net.Vpc.Upa.EntityModifier.USER_ID);
            }
            SetModifiers(_effectiveModifiers);
            //if (!Utils.getBoolean(PersistenceUnitFilter.class, "productionMode", false)) {
            CheckIntegrity();
        }

        protected internal virtual void CheckIntegrity() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            // check for fields
            Net.Vpc.Upa.Impl.DefaultEntityPrivateChecker checker = new Net.Vpc.Upa.Impl.DefaultEntityPrivateChecker(this);
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> fs = GetFields();
            if ((fs.Count==0)) {
                checker.AddError("Entity " + GetName() + " does not declare any field");
            }
            // check for primary fields
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> primaries = GetPrimaryFields();
            if ((primaries.Count==0)) {
                checker.AddWarning("Entity " + GetName() + " has no primary fields");
            }
            // check for duplicate field declaration
            System.Collections.Generic.ISet<string> hashSet = new System.Collections.Generic.HashSet<string>();
            foreach (Net.Vpc.Upa.Field f in fs) {
                if (hashSet.Contains(f.GetName())) {
                    checker.AddError("Field " + f.GetAbsoluteName() + " is declared twice");
                }
                hashSet.Add(f.GetName());
            }
            // check for incorrect formula pass usage
            //        for (Field f : fs) {
            //            Formula formula = f.getFormula();
            //            int formulaOrder = f.getFormulaOrder();
            //            if (formula != null && formula instanceof ExpressionFormula) {
            //                ExpressionFormula expressionFormula = (ExpressionFormula) formula;
            //                CompiledExpression compiledExpression = (CompiledExpression) compile(expressionFormula.getExpression());
            //                final Set<Field> usedFields = new HashSet<Field>();
            //                compiledExpression.visit(new CompiledExpressionVisitor() {
            //                    @Override
            //                    public boolean visit(CompiledExpression e) {
            //                        if (e instanceof CompiledVar) {
            //                            CompiledVar v = (CompiledVar) e;
            //                            if (v.getReferrer() instanceof Field) {
            //                                usedFields.add((Field) v.getReferrer());
            //                            }
            //                        }
            //                        return true;
            //                    }
            //                });
            //                for (Field v : usedFields) {
            //                    int p2 = -1;
            //                    try {
            //                        p2 = hashSet.get(v.getName());
            //                    } catch (NullPointerException e) {
            //                        checker.addError("Formula Error : Field "
            //                                + f.getName() + " (" + pass1
            //                                + " pass) in Table " + getName()
            //                                + " uses un unknown field named " + v);
            //                    }
            //                    String pass2 = (p2 < 0) ? "initial" : p2 == 0 ? "1st"
            //                            : p2 == 1 ? "2nd" : p2 == 2 ? "3rd" : (p2 + 1)
            //                            + "th";
            //                    if (p2 >= p1) {
            //                        if (f.equals(v)) {
            //                            checker.addWarning("Formula Warning : Cross reference reached for Field "
            //                                    + f.getName()
            //                                    + "("
            //                                    + pass1
            //                                    + " pass) in Table " + getName());
            //                        } else {
            //                            checker.addError("Formula Error : Field "
            //                                    + f.getName() + " (" + pass1
            //                                    + " pass) in Table " + getName()
            //                                    + " uses Field " + v + " (" + pass2
            //                                    + " pass)");
            //                        }
            //                    }
            //                }
            //                if (formula == null) {
            //                    hashSet.put(f.getName(), -1);
            //                } else {
            //                    int p = formulaOrder;
            //                    hashSet.put(f.getName(), p);
            //                }
            //            }
            //        }
            checker.Check();
        }

        public virtual Net.Vpc.Upa.Callbacks.Trigger AddTrigger(Net.Vpc.Upa.Callbacks.EntityInterceptor trigger) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return AddTrigger(null, trigger);
        }

        public virtual Net.Vpc.Upa.Callbacks.Trigger AddTrigger(string triggerName, Net.Vpc.Upa.Callbacks.EntityInterceptor trigger) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Impl.DefaultPersistenceUnit pu = (Net.Vpc.Upa.Impl.DefaultPersistenceUnit) GetPersistenceUnit();
            if (Net.Vpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(triggerName)) {
                while (true) {
                    string n = "anonymous" + triggerAnonymousNameIndex;
                    if (!triggers.ContainsKey(n)) {
                        triggerName = n;
                        break;
                    }
                    triggerAnonymousNameIndex++;
                }
            } else if (triggers.ContainsKey(triggerName)) {
                throw new Net.Vpc.Upa.Exceptions.ObjectAlreadyExistsException(null, "Entity Trigger " + triggerName);
            }
            //            if (pu.getAllTriggers().containsKey(triggerName)) {
            //                throw new ObjectAlreadyExistsException(null, "Entity Trigger " + triggerName);
            //            }
            Net.Vpc.Upa.Impl.DefaultTrigger triggerObject = new Net.Vpc.Upa.Impl.DefaultTrigger();
            triggerObject.SetEntity(this);
            triggerObject.SetName(triggerName);
            Net.Vpc.Upa.Callbacks.EntityListener listener = ConvertInterceptorToListener(trigger);
            triggerObject.SetInterceptor(trigger);
            triggerObject.SetListener(listener);
            triggerObject.SetPersistenceState(Net.Vpc.Upa.PersistenceState.DIRTY);
            pu.GetPersistenceUnitListenerManager().FireOnCreateTrigger(triggerObject, Net.Vpc.Upa.EventPhase.BEFORE);
            triggers[triggerName]=triggerObject;
            //        pu.getAllTriggers().put(triggerName, triggerObject);
            pu.GetPersistenceUnitListenerManager().FireOnCreateTrigger(triggerObject, Net.Vpc.Upa.EventPhase.AFTER);
            return triggerObject;
        }

        protected internal virtual Net.Vpc.Upa.Callbacks.EntityListener ConvertInterceptorToListener(Net.Vpc.Upa.Callbacks.EntityInterceptor trigger) {
            if (trigger is Net.Vpc.Upa.Callbacks.EntityListener) {
                return (Net.Vpc.Upa.Callbacks.EntityListener) trigger;
            } else if (trigger is Net.Vpc.Upa.Callbacks.SingleEntityListener) {
                return (new Net.Vpc.Upa.Impl.Event.SingleDataInterceptorSupport((Net.Vpc.Upa.Callbacks.SingleEntityListener) trigger));
            } else if (trigger is Net.Vpc.Upa.Callbacks.UpdateRelationshipTargetFormulaInterceptor) {
                return (new Net.Vpc.Upa.Impl.Event.RelationshipTargetFormulaUpdaterInterceptorSupport((Net.Vpc.Upa.Callbacks.UpdateRelationshipTargetFormulaInterceptor) trigger));
            } else if (trigger is Net.Vpc.Upa.Callbacks.UpdateRelationshipSourceFormulaInterceptor) {
                return (new Net.Vpc.Upa.Impl.Event.RelationshipSourceFormulaUpdaterInterceptorSupport((Net.Vpc.Upa.Callbacks.UpdateRelationshipSourceFormulaInterceptor) trigger));
            } else if (trigger is Net.Vpc.Upa.Callbacks.UpdateFormulaInterceptor) {
                return (new Net.Vpc.Upa.Impl.Event.FormulaUpdaterInterceptorSupport((Net.Vpc.Upa.Callbacks.UpdateFormulaInterceptor) trigger));
            } else {
                throw new System.ArgumentException ("Unsupported Entity Trigger Type " + trigger.GetType());
            }
        }

        public virtual void RemoveTrigger(string triggerName) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Impl.DefaultPersistenceUnit pu = (Net.Vpc.Upa.Impl.DefaultPersistenceUnit) GetPersistenceUnit();
            Net.Vpc.Upa.Callbacks.Trigger tr = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.Vpc.Upa.Callbacks.Trigger>(triggers,triggerName);
            if (tr == null) {
                throw new System.ArgumentException ("Trigger Not found " + triggerName);
            }
            pu.GetPersistenceUnitListenerManager().FireOnDropTrigger(tr, Net.Vpc.Upa.EventPhase.BEFORE);
            triggers.Remove(triggerName);
            //        pu.getAllTriggers().remove(triggerName);
            pu.GetPersistenceUnitListenerManager().FireOnDropTrigger(tr, Net.Vpc.Upa.EventPhase.AFTER);
        }

        public virtual void AddDependencyOnEntity(string entityName) {
            dependsOnTables.Add(entityName);
        }

        public virtual bool IsDependentOnEntity(string entityName) {
            return dependsOnTables.Contains(entityName);
        }

        public virtual System.Collections.Generic.ISet<string> GetDependencyEntities() {
            return dependsOnTables;
        }

        public virtual void UpdateFormulas() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            CreateUpdateQuery().ValidateAll().Execute();
        }

        public virtual Net.Vpc.Upa.Field BindField(Net.Vpc.Upa.Field field, string sectionPath) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return BindField(field, sectionPath, -1);
        }

        public virtual Net.Vpc.Upa.Field BindField(Net.Vpc.Upa.Field field, string sectionPath, int index) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (Net.Vpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(field.GetName())) {
                throw new System.ArgumentException ("Field name is Null or Empty");
            }
            if (field.GetDataType() == null) {
            } else if (field.GetUserModifiers().Contains(Net.Vpc.Upa.UserFieldModifier.ID) && field.GetDataType().IsNullable()) {
                log.TraceEvent(System.Diagnostics.TraceEventType.Warning,90,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Field {0}.{1} is ID but has nullable Type. Forced to non nullable (type reference changed).",null,new object[] { GetName(), field.GetName() }));
                Net.Vpc.Upa.Types.DataType t = (Net.Vpc.Upa.Types.DataType) field.GetDataType().Copy();
                t.SetNullable(false);
                field.SetDataType(t);
            }
            if (field.GetPersistFormula() != null && !(field.GetPersistFormula() is Net.Vpc.Upa.Sequence) && field.GetDataType() != null && !field.GetDataType().IsNullable()) {
                throw new System.ArgumentException ("Field " + GetName() + "." + field.GetName() + " is a FORMULA field. Thus it must be nullable");
            }
            Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> modifiersCopy = Copy(field.GetUserModifiers());
            Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> excludedModifiersCopy = Copy(field.GetUserExcludeModifiers());
            modifiersCopy.RemoveAll(excludedModifiersCopy);
            field.SetUserModifiers(modifiersCopy);
            field.SetUserExcludeModifiers(excludedModifiersCopy);
            //Workaround
            Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.FieldModifier> tt = Net.Vpc.Upa.FlagSets.NoneOf<Net.Vpc.Upa.FieldModifier>();
            if (modifiersCopy.Contains(Net.Vpc.Upa.UserFieldModifier.ID)) {
                tt = tt.Add(Net.Vpc.Upa.FieldModifier.ID);
            }
            if (modifiersCopy.Contains(Net.Vpc.Upa.UserFieldModifier.TRANSIENT)) {
                tt = tt.Add(Net.Vpc.Upa.FieldModifier.TRANSIENT);
            }
            if (modifiersCopy.Contains(Net.Vpc.Upa.UserFieldModifier.SYSTEM)) {
                tt = tt.Add(Net.Vpc.Upa.FieldModifier.SYSTEM);
            }
            ((Net.Vpc.Upa.Impl.AbstractField) field).SetEffectiveModifiers(tt);
            if (sectionPath == null || (sectionPath).Length == 0) {
                Net.Vpc.Upa.Impl.Util.DefaultBeanAdapter adapter = Net.Vpc.Upa.Impl.Util.UPAUtils.Prepare(GetPersistenceUnit(), this, field, field.GetName());
                AddPart(field, index);
            } else {
                Net.Vpc.Upa.Impl.Util.DefaultBeanAdapter adapter = Net.Vpc.Upa.Impl.Util.UPAUtils.Prepare(GetPersistenceUnit(), this, field, field.GetName());
                GetSection(sectionPath, Net.Vpc.Upa.MissingStrategy.CREATE).AddPart(field, index);
            }
            InvalidateStructureCache();
            return field;
        }

        protected internal virtual void BeforePartAdded(Net.Vpc.Upa.EntityPart parent, Net.Vpc.Upa.EntityPart part, int index) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (part is Net.Vpc.Upa.Field) {
                if (part.GetName() == null || (part.GetName()).Length == 0) {
                    throw new Net.Vpc.Upa.Exceptions.UPAException(new Net.Vpc.Upa.Types.I18NString("InvalidNameException"), "Field with no name for " + GetName());
                }
                Net.Vpc.Upa.Field field = (Net.Vpc.Upa.Field) part;
                if (field.GetPersistFormula() != null && !(field.GetPersistFormula() is Net.Vpc.Upa.Sequence) && (field.GetDefaultObject() == null || field.GetDefaultObject() is Net.Vpc.Upa.CustomDefaultObject) && !field.GetUserModifiers().Contains(Net.Vpc.Upa.UserFieldModifier.TRANSIENT) && !(field.GetUserModifiers().Contains(Net.Vpc.Upa.UserFieldModifier.ID)) && field.GetDataType() != null && !field.GetDataType().IsNullable()) {
                    //change type
                    Net.Vpc.Upa.Types.DataType t = (Net.Vpc.Upa.Types.DataType) field.GetDataType().Copy();
                    t.SetNullable(true);
                    field.SetDataType(t);
                    log.TraceEvent(System.Diagnostics.TraceEventType.Warning,90,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter(GetName() + "." + field.GetName() + " is a formula but is not nullable. Forced to nullable (type reference changed)",null));
                }
                //throw new UPAException(new I18NString("NoNullableFormulaException", field.getName(), getName()));
                if (fieldsMap.ContainsKey(GetPersistenceUnit().GetNamingStrategy().GetUniformValue(field.GetName()))) {
                    throw new Net.Vpc.Upa.Exceptions.ObjectAlreadyExistsException("EntityItemAlreadyExists", field.GetName());
                }
            } else if (part is Net.Vpc.Upa.Section) {
                if (part.GetName() == null || (part.GetName()).Length == 0) {
                    throw new Net.Vpc.Upa.Exceptions.UPAException(new Net.Vpc.Upa.Types.I18NString("InvalidNameException"), "Section for " + GetName());
                }
            }
            if (parent == null) {
                Net.Vpc.Upa.EntityPart found = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.Vpc.Upa.EntityPart>(itemsByName,part.GetName());
                if (found != null) {
                    throw new Net.Vpc.Upa.Exceptions.ObjectAlreadyExistsException("EntityItemAlreadyExists", part.GetName());
                }
            } else if (parent is Net.Vpc.Upa.Section) {
                Net.Vpc.Upa.Section s = (Net.Vpc.Upa.Section) parent;
                bool found = false;
                try {
                    s.GetPart(part.GetName());
                    found = true;
                } catch (System.Exception e) {
                }
                //
                if (found) {
                    throw new Net.Vpc.Upa.Exceptions.ObjectAlreadyExistsException("EntityItemAlreadyExists", parent.GetName());
                }
            } else if (parent is Net.Vpc.Upa.CompoundField) {
                Net.Vpc.Upa.CompoundField s = (Net.Vpc.Upa.CompoundField) parent;
                bool found = false;
                try {
                    s.GetField(part.GetName());
                    found = true;
                } catch (System.Exception e) {
                }
                //
                if (found) {
                    throw new Net.Vpc.Upa.Exceptions.ObjectAlreadyExistsException("EntityItemAlreadyExists", parent.GetName());
                }
            }
        }

        public virtual void AfterPartAdded(Net.Vpc.Upa.EntityPart parent, Net.Vpc.Upa.EntityPart item, int index) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (item is Net.Vpc.Upa.Field) {
                Net.Vpc.Upa.Field field = (Net.Vpc.Upa.Field) item;
                field.AddObjectListener(objListener);
            } else if (item is Net.Vpc.Upa.Section) {
                Net.Vpc.Upa.Section section = (Net.Vpc.Upa.Section) item;
                section.AddObjectListener(objListener);
            }
            //reset fieldsByFilter
            fieldsByFilter.Clear();
        }


        public virtual Net.Vpc.Upa.Field GetMainField() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return mainRendererField;
        }


        public virtual string GetMainFieldValue(object o) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Field mf = GetMainField();
            if (mf == null) {
                return null;
            }
            object v = GetBuilder().ObjectToRecord(o, false).GetObject<T>(mf.GetName());
            if (v == null) {
                return null;
            }
            return System.Convert.ToString(v);
        }


        public virtual Net.Vpc.Upa.EntityNavigator GetNavigator() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (navigator == null) {
                navigator = CreateNavigator();
            }
            return navigator;
        }

        public virtual void SetNavigator(Net.Vpc.Upa.EntityNavigator newNavigator) {
            this.navigator = newNavigator;
        }

        protected internal virtual Net.Vpc.Upa.EntityNavigator CreateNavigator() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> pf = GetPrimaryFields();
            if ((pf).Count == 1) {
                Net.Vpc.Upa.Field field = pf[0];
                System.Type idClass = field.GetDataType().GetPlatformType();
                if (typeof(string).Equals(idClass)) {
                    string sn = this.GetShortName();
                    if (sn == null) {
                        sn = GetName();
                    }
                    if (field.GetPersistFormula() is Net.Vpc.Upa.Sequence) {
                        Net.Vpc.Upa.Sequence a = (Net.Vpc.Upa.Sequence) field.GetPersistFormula();
                        string format = a.GetFormat();
                        if (format == null) {
                            format = sn + "{#}";
                        }
                        string name = a.GetName();
                        if (name == null) {
                            name = field.GetEntity().GetName() + "." + field.GetName();
                        }
                        return Net.Vpc.Upa.Impl.Navigator.EntityNavigatorFactory.CreateStringSequenceNavigator(this, name, format, a.GetGroup(), a.GetInitialValue(), a.GetAllocationSize());
                    } else {
                        string format = sn + "{#}";
                        return Net.Vpc.Upa.Impl.Navigator.EntityNavigatorFactory.CreateStringSequenceNavigator(this, this.GetName(), format, null, 1, 1);
                    }
                } else if (Net.Vpc.Upa.Impl.Util.PlatformUtils.IsInt32(idClass)) {
                    return Net.Vpc.Upa.Impl.Navigator.EntityNavigatorFactory.CreateIntegerNavigator(this);
                } else if (Net.Vpc.Upa.Impl.Util.PlatformUtils.IsInt64(idClass)) {
                    return Net.Vpc.Upa.Impl.Navigator.EntityNavigatorFactory.CreateLongNavigator(this);
                } else {
                    return Net.Vpc.Upa.Impl.Navigator.EntityNavigatorFactory.CreateDefaultNavigator(this);
                }
            } else {
                return Net.Vpc.Upa.Impl.Navigator.EntityNavigatorFactory.CreateDefaultNavigator(this);
            }
        }

        private Net.Vpc.Upa.Field CreateField(Net.Vpc.Upa.FieldDescriptor fieldDescriptor) {
            Net.Vpc.Upa.Field f = null;
            if (fieldDescriptor.GetDataType() is Net.Vpc.Upa.CompoundDataType) {
                f = new Net.Vpc.Upa.Impl.DefaultCompoundField();
            } else {
                f = new Net.Vpc.Upa.Impl.DefaultPrimitiveField();
            }
            f.SetName(fieldDescriptor.GetName());
            f.SetDefaultObject(fieldDescriptor.GetDefaultObject());
            f.SetDataType(fieldDescriptor.GetDataType());
            f.SetUserModifiers(fieldDescriptor.GetUserFieldModifiers());
            f.SetUserExcludeModifiers(fieldDescriptor.GetUserExcludeModifiers());
            Net.Vpc.Upa.PropertyAccessType propertyAccessType = fieldDescriptor.GetPropertyAccessType();
            if (Net.Vpc.Upa.Impl.Util.PlatformUtils.IsUndefinedValue<Net.Vpc.Upa.PropertyAccessType>(typeof(Net.Vpc.Upa.PropertyAccessType), propertyAccessType)) {
                propertyAccessType = Net.Vpc.Upa.PropertyAccessType.PROPERTY;
            }
            f.SetPropertyAccessType(propertyAccessType);
            if (fieldDescriptor.GetFieldParams() != null) {
                foreach (System.Collections.Generic.KeyValuePair<string , object> e in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<string,object>>(fieldDescriptor.GetFieldParams())) {
                    f.GetProperties().SetObject((e).Key, (e).Value);
                }
            }
            Net.Vpc.Upa.Types.DataTypeTransform t = GetPersistenceUnit().GetTypeTransformFactory().CreateTypeTransform(GetPersistenceUnit(), fieldDescriptor.GetDataType(), fieldDescriptor.GetTypeTransform());
            //        if (t == null) {
            //            t = new IdentityDataTypeTransform(fieldDescriptor.getDataType());
            //        }
            f.SetTypeTransform(t);
            f.SetPersistFormula(fieldDescriptor.GetPersistFormula());
            f.SetPersistFormulaOrder(fieldDescriptor.GetPersistFormulaOrder());
            f.SetUpdateFormula(fieldDescriptor.GetUpdateFormula());
            f.SetUpdateFormulaOrder(fieldDescriptor.GetUpdateFormulaOrder());
            f.SetSelectFormula(fieldDescriptor.GetSelectFormula());
            f.SetPersistAccessLevel(fieldDescriptor.GetPersistAccessLevel());
            f.SetUpdateAccessLevel(fieldDescriptor.GetUpdateAccessLevel());
            f.SetReadAccessLevel(fieldDescriptor.GetReadAccessLevel());
            if (f is Net.Vpc.Upa.Impl.DefaultCompoundField) {
                Net.Vpc.Upa.Impl.DefaultCompoundField cf = (Net.Vpc.Upa.Impl.DefaultCompoundField) f;
                Net.Vpc.Upa.CompoundDataType d = (Net.Vpc.Upa.CompoundDataType) GetDataType();
                Net.Vpc.Upa.FieldDescriptor[] composingFields = d.GetComposingFields(fieldDescriptor);
                foreach (Net.Vpc.Upa.FieldDescriptor composingField in composingFields) {
                    Net.Vpc.Upa.Field field = CreateField(composingField);
                    cf.AddField((Net.Vpc.Upa.PrimitiveField) field);
                }
            }
            return f;
        }

        public virtual Net.Vpc.Upa.Field AddField(Net.Vpc.Upa.FieldDescriptor fieldDescriptor) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Field f = CreateField(fieldDescriptor);
            BindField(f, fieldDescriptor.GetFieldPath(), fieldDescriptor.GetPosition() == 0 ? -1 : fieldDescriptor.GetPosition());
            return f;
        }

        public virtual Net.Vpc.Upa.Field AddField(string name, string sectionPath, Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> modifiers, object defaultValue, Net.Vpc.Upa.Types.DataType type) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return AddField(new Net.Vpc.Upa.DefaultFieldDescriptor().SetName(name).SetFieldPath(sectionPath).SetUserFieldModifiers(modifiers).SetDefaultObject(defaultValue).SetDataType(type));
        }

        public virtual Net.Vpc.Upa.Field AddField(string name, string sectionPath, Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> modifiers, Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> excludeModifiers, object defaultValue, Net.Vpc.Upa.Types.DataType type, int index) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return AddField(new Net.Vpc.Upa.DefaultFieldDescriptor().SetName(name).SetFieldPath(sectionPath).SetUserFieldModifiers(modifiers).SetUserExcludeModifiers(excludeModifiers).SetDefaultObject(defaultValue).SetDataType(type).SetPosition(index));
        }

        public virtual int GetItemsCount() {
            return (items).Count;
        }

        public virtual int GetFieldsCount() {
            return (fieldsMap).Count;
        }


        public override string ToString() {
            return GetName();
        }


        public override bool Equals(object other) {
            if (other == null || !(other is Net.Vpc.Upa.Impl.DefaultEntity)) {
                return false;
            } else {
                Net.Vpc.Upa.Impl.DefaultEntity o = (Net.Vpc.Upa.Impl.DefaultEntity) other;
                return GetPersistenceUnit().GetNamingStrategy().Equals(GetName(), o.GetName());
            }
        }

        public virtual bool ContainsField(string key) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return fieldsMap.ContainsKey(GetPersistenceUnit().GetNamingStrategy().GetUniformValue(key));
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.DynamicField> GetDynamicFields() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Net.Vpc.Upa.Impl.Util.PlatformUtils.EmptyList<T>();
        }

        public virtual Net.Vpc.Upa.PrimitiveField GetPrimitiveField(string fieldName) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return (Net.Vpc.Upa.PrimitiveField) GetField(fieldName);
        }

        public virtual Net.Vpc.Upa.PrimitiveField FindPrimitiveField(string fieldName) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return (Net.Vpc.Upa.PrimitiveField) FindField(fieldName);
        }

        public virtual Net.Vpc.Upa.Field GetField(int index) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            int i = 0;
            foreach (Net.Vpc.Upa.Field @value in (fieldsMap).Values) {
                if (i == index) {
                    return @value;
                }
                i++;
            }
            throw new System.IndexOutOfRangeException("Invalid Index "+(index));
        }

        public virtual Net.Vpc.Upa.Field GetField(string fieldName) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            RevalidateStructure();
            Net.Vpc.Upa.Field f = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.Vpc.Upa.Field>(fieldsMap,GetPersistenceUnit().GetNamingStrategy().GetUniformValue(fieldName));
            if (f != null) {
                return f;
            }
            //            ExtendedField p = (ExtendedField) mappedCompoundFields.get(getPersistenceUnit().getNamesComparator().getUniformValue(fieldName));
            //            if (p == null) {
            //            Log.dev_warning(getName() + " : ExtendedField : " + "Neither Field nor compound field " + fieldName + " was found in Entity " + getName());
            throw new System.Exception("Neither Field nor compound field " + fieldName + " was found in Entity " + GetName());
        }

        public virtual Net.Vpc.Upa.Field FindField(string fieldName) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            RevalidateStructure();
            return Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.Vpc.Upa.Field>(fieldsMap,GetPersistenceUnit().GetNamingStrategy().GetUniformValue(fieldName));
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Field> GetPrimaryFields() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetFields(Net.Vpc.Upa.Filters.Fields.Id());
        }

        public virtual System.Collections.Generic.IList<string> GetFieldNames(Net.Vpc.Upa.Filters.FieldFilter fieldFilter) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> f = GetFields(fieldFilter);
            System.Collections.Generic.IList<string> s = new System.Collections.Generic.List<string>((f).Count);
            foreach (Net.Vpc.Upa.Field field in f) {
                s.Add(field.GetName());
            }
            return s;
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Field> GetFields(Net.Vpc.Upa.Filters.FieldFilter fieldFilter) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            RevalidateStructure();
            if (fieldFilter == null) {
                return GetFields();
            }
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> c = fieldsByFilter.Get(fieldFilter);
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> e = new System.Collections.Generic.List<Net.Vpc.Upa.Field>((fieldsMap).Count);
            if (c == null) {
                foreach (Net.Vpc.Upa.Field field in (fieldsMap).Values) {
                    if (fieldFilter.Accept(field)) {
                        e.Add(field);
                    }
                }
                c = new System.Collections.Generic.List<Net.Vpc.Upa.Field>(e);
                fieldsByFilter.Put(fieldFilter, c);
                if (fieldFilter.AcceptDynamic()) {
                    foreach (Net.Vpc.Upa.DynamicField df in GetDynamicFields()) {
                        if (fieldFilter.Accept(df)) {
                            e.Add(df);
                        }
                    }
                    c = e;
                }
            } else if (fieldFilter.AcceptDynamic()) {
                e = new System.Collections.Generic.List<Net.Vpc.Upa.Field>(c);
                foreach (Net.Vpc.Upa.DynamicField df in GetDynamicFields()) {
                    if (fieldFilter.Accept(df)) {
                        e.Add(df);
                    }
                }
                c = e;
            }
            return c;
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.PrimitiveField> GetPrimitiveFields(Net.Vpc.Upa.Filters.FieldFilter fieldFilter) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.List<Net.Vpc.Upa.PrimitiveField> primitiveFields = new System.Collections.Generic.List<Net.Vpc.Upa.PrimitiveField>();
            foreach (Net.Vpc.Upa.Field f in GetFields(Net.Vpc.Upa.Filters.Fields.Primitive().And(fieldFilter))) {
                primitiveFields.Add((Net.Vpc.Upa.PrimitiveField) f);
            }
            return primitiveFields;
        }

        public virtual object CloneRecord(object oldId, object newId) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (IsCheckSecurity()) {
                GetShield().CheckClone(oldId, newId);
            }
            object o = CreateQueryBuilder().ById(oldId).SetFieldFilter(Net.Vpc.Upa.Impl.Util.Filters.Fields2.COPY_ON_CLONE).GetEntity<R>();
            GetBuilder().SetObjectId(o, newId);
            Persist(o);
            return o;
        }

        protected internal virtual bool IsCheckSecurity() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Session currentSession = GetPersistenceUnit().GetCurrentSession();
            return (currentSession == null) || !GetPersistenceUnit().IsSystemSession(currentSession);
        }

        public virtual object Rename(object oldId, object newId) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Rename(oldId, newId, defaultHints);
        }

        public virtual object Rename(object oldId, object newId, System.Collections.Generic.IDictionary<string , object> hints) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (IsCheckSecurity()) {
                GetShield().CheckRename(oldId, newId);
            }
            Net.Vpc.Upa.Persistence.EntityExecutionContext context = CreateContext(Net.Vpc.Upa.Persistence.ContextOperation.RENAME, hints);
            //        Object tranasction = getPersistenceUnit().getPersistenceStore().getConnection().tryBeginTransaction();
            //        boolean transactionSucceeded = false;
            //        try {
            object o = CreateQueryBuilder().ById(oldId).SetFieldFilter(Net.Vpc.Upa.Impl.Util.Filters.Fields2.COPY_ON_RENAME).GetEntity<R>();
            Net.Vpc.Upa.Record ur = GetBuilder().ObjectToRecord(o, false);
            GetBuilder().SetRecordId(ur, newId);
            // insert(o, false);
            object[] newIdValues = GetBuilder().IdToKey(newId).GetValue();
            object[] oldIdValues = GetBuilder().IdToKey(oldId).GetValue();
            PersistCore(ur, context);
            foreach (Net.Vpc.Upa.Relationship r in GetPersistenceUnit().GetRelationshipsByTarget(this)) {
                if (!r.GetSourceRole().GetEntity().Equals(r.GetTargetRole().GetEntity()) && !r.IsTransient()) {
                    Net.Vpc.Upa.Record updates = r.GetSourceRole().GetEntity().GetBuilder().CreateRecord();
                    Net.Vpc.Upa.Expressions.Expression condition = null;
                    System.Collections.Generic.IList<Net.Vpc.Upa.Field> lfields = r.GetSourceRole().GetFields();
                    for (int j = 0; j < (lfields).Count; j++) {
                        Net.Vpc.Upa.Field lf = lfields[j];
                        updates.SetObject(lf.GetName(), newIdValues[j]);
                        Net.Vpc.Upa.Expressions.Expression e = new Net.Vpc.Upa.Expressions.Equals(new Net.Vpc.Upa.Expressions.Var(lf.GetName()), new Net.Vpc.Upa.Expressions.Literal(oldIdValues[j], lf.GetDataType()));
                        condition = condition == null ? ((Net.Vpc.Upa.Expressions.Expression)(e)) : new Net.Vpc.Upa.Expressions.And(condition, e);
                    }
                    try {
                        // r.getDetailsTable().updateAllRecords(updates,
                        // condition, check);
                        r.GetSourceRole().GetEntity().UpdateCore(updates, condition, context);
                    } catch (Net.Vpc.Upa.Exceptions.UpdateRecordKeyNotFoundException e) {
                    }
                }
            }
            // if no updates no matter
            // remove(toExpression(oldId, null),
            // getPersistenceUnit().isRecurseDelete(), false, new RemoveTrace());
            RemoveCore(GetBuilder().IdToExpression(oldId, null), GetPersistenceUnit().IsRecurseDelete(), new Net.Vpc.Upa.Impl.DefaultRemoveTrace(), context);
            //        transactionSucceeded = true;
            //        return o;
            //    }
            //
            //    finally
            //
            //    {
            //        getPersistenceUnit().getPersistenceStore().getConnection().tryFinalizeTransaction(
            //                transactionSucceeded, tranasction);
            //    }
            return o;
        }

        public virtual object GetNextId(object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return (object) GetNavigator().GetNextKey(id);
        }

        public virtual object GetFirstId() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return (object) GetNavigator().GetFirstKey();
        }

        public virtual object GetLastId() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return (object) GetNavigator().GetLastKey();
        }

        public virtual object GetPreviousId(object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return (object) GetNavigator().GetPreviousKey(id);
        }

        public virtual bool HasNext(object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetNextId(id) != null;
        }

        public virtual bool HasPrevious(object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetPreviousId(id) != null;
        }

        public virtual bool IsEmpty() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            bool b = false;
            if (cache.isEmpty == null) {
                b = GetFirstId() == null;
                cache.isEmpty = b;
            }
            return b;
        }

        public virtual long GetEntityCount() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Record record = CreateQuery(new Net.Vpc.Upa.Expressions.Select().Field(new Net.Vpc.Upa.Expressions.Count(Net.Vpc.Upa.Expressions.Literal.IONE))).GetRecord();
            return record.GetLong();
        }

        public virtual long GetEntityCount(Net.Vpc.Upa.Expressions.Expression booleanExpression) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            object n = CreateQuery((new Net.Vpc.Upa.Expressions.Select()).From(GetName()).Field(new Net.Vpc.Upa.Expressions.Count(new Net.Vpc.Upa.Expressions.Literal(1))).Where(booleanExpression)).GetNumber();
            return n == null ? -1L : System.Convert.ToInt32(n);
        }

        public virtual  K NextId<K>() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return (K) GetNavigator().GetNewKey();
        }

        public virtual Net.Vpc.Upa.Expressions.Expression ParentToChildExpression(Net.Vpc.Upa.Expressions.Expression parentExpression) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (parentExpression == null) {
                return null;
            }
            Net.Vpc.Upa.Relationship r = GetCompositionRelation();
            Net.Vpc.Upa.Expressions.Select s = new Net.Vpc.Upa.Expressions.Select().From(r.GetTargetRole().GetEntity().GetName()).Where(parentExpression);
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> df = r.GetSourceRole().GetFields();
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> mf = r.GetTargetRole().GetFields();
            if ((df).Count == 1) {
                s.Field(new Net.Vpc.Upa.Expressions.Var(mf[0].GetName()));
                return new Net.Vpc.Upa.Expressions.InSelection(new Net.Vpc.Upa.Expressions.Var(df[0].GetName()), s);
            } else {
                Net.Vpc.Upa.Expressions.Var[] mv = new Net.Vpc.Upa.Expressions.Var[(mf).Count];
                for (int i = 0; i < (mf).Count; i++) {
                    mv[i] = new Net.Vpc.Upa.Expressions.Var(mf[i].GetName());
                }
                Net.Vpc.Upa.Expressions.Var[] dv = new Net.Vpc.Upa.Expressions.Var[(df).Count];
                for (int i = 0; i < (df).Count; i++) {
                    dv[i] = new Net.Vpc.Upa.Expressions.Var(df[i].GetName());
                }
                s.Field(new Net.Vpc.Upa.Expressions.Uplet(dv));
                return new Net.Vpc.Upa.Expressions.InSelection(new Net.Vpc.Upa.Expressions.Uplet(mv), s);
            }
        }

        public virtual Net.Vpc.Upa.Expressions.Expression ChildToParentExpression(Net.Vpc.Upa.Expressions.Expression childExpression) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (childExpression == null) {
                return null;
            }
            Net.Vpc.Upa.Expressions.Select s = new Net.Vpc.Upa.Expressions.Select().From(GetName()).Where(childExpression);
            Net.Vpc.Upa.Relationship r = GetCompositionRelation();
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> df = r.GetSourceRole().GetFields();
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> mf = r.GetTargetRole().GetFields();
            if ((df).Count == 1) {
                s.Field(new Net.Vpc.Upa.Expressions.Var(df[0].GetName()));
                return new Net.Vpc.Upa.Expressions.InSelection(new Net.Vpc.Upa.Expressions.Var(mf[0].GetName()), s);
            } else {
                Net.Vpc.Upa.Expressions.Var[] dv = new Net.Vpc.Upa.Expressions.Var[(df).Count];
                for (int i = 0; i < (df).Count; i++) {
                    dv[i] = new Net.Vpc.Upa.Expressions.Var(df[i].GetName());
                }
                Net.Vpc.Upa.Expressions.Var[] mv = new Net.Vpc.Upa.Expressions.Var[(mf).Count];
                for (int i = 0; i < (mf).Count; i++) {
                    mv[i] = new Net.Vpc.Upa.Expressions.Var(mf[i].GetName());
                }
                s.Field(new Net.Vpc.Upa.Expressions.Uplet(mv));
                return new Net.Vpc.Upa.Expressions.InSelection(new Net.Vpc.Upa.Expressions.Uplet(dv), s);
            }
        }

        public virtual Net.Vpc.Upa.Expressions.Expression ChildToParentExpression(Net.Vpc.Upa.Record child) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Relationship r = GetCompositionRelation();
            Net.Vpc.Upa.Field sf = r.GetSourceRole().GetEntityField();
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> df = r.GetSourceRole().GetFields();
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> mf = r.GetTargetRole().GetFields();
            if (sf != null) {
                Net.Vpc.Upa.EntityBuilder tb = r.GetTargetEntity().GetBuilder();
                object @object = child.GetObject<T>(sf.GetName());
                if (@object == null) {
                    return null;
                }
                return tb.IdToExpression(tb.ObjectToId(@object), null);
            } else if ((df).Count == 1) {
                return new Net.Vpc.Upa.Expressions.Equals(new Net.Vpc.Upa.Expressions.Var(mf[0].GetName()), child.GetObject<T>(df[0].GetName()));
            } else {
                Net.Vpc.Upa.Expressions.Expression a = null;
                for (int i = 0; i < (df).Count; i++) {
                    Net.Vpc.Upa.Expressions.Expression e = new Net.Vpc.Upa.Expressions.Equals(new Net.Vpc.Upa.Expressions.Var(mf[i].GetName()), child.GetObject<T>(df[i].GetName()));
                    a = a == null ? ((Net.Vpc.Upa.Expressions.Expression)(e)) : new Net.Vpc.Upa.Expressions.And(a, e);
                }
                return a;
            }
        }


        public virtual Net.Vpc.Upa.RemoveTrace Remove(Net.Vpc.Upa.RemoveOptions options) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Expressions.Expression expression = ObjToExpression(options.GetConditionType(), options.GetRemoveCondition());
            bool recurse = options.IsFollowLinks();
            bool simulate = options.IsSimulate();
            Net.Vpc.Upa.RemoveTrace removeInfo = options.GetRemoveTrace();
            if (removeInfo == null) {
                removeInfo = new Net.Vpc.Upa.Impl.DefaultRemoveTrace();
                options.SetRemoveTrace(removeInfo);
            }
            Net.Vpc.Upa.Relationship relation = options.GetFollowRelationship();
            expression = ToIdListExpression(expression);
            if (IsCheckSecurity()) {
                GetShield().CheckRemove(expression, recurse);
            }
            Net.Vpc.Upa.Persistence.EntityExecutionContext removeExecContext = CreateContext(simulate ? Net.Vpc.Upa.Persistence.ContextOperation.REMOVE_SIMULATION : Net.Vpc.Upa.Persistence.ContextOperation.REMOVE, options.GetHints());
            //        Object tranasction = null;
            //        boolean transactionSucceeded = false;
            if (!simulate) {
                //            tranasction = getPersistenceUnit().getPersistenceStore().getConnection().tryBeginTransaction();
                recordListenerSupport.FireBeforeRemove(expression, removeExecContext);
            }
            try {
                string trace = "remove(" + GetName() + "," + expression + "), simulate=" + simulate + ",recurse=" + recurse + ",relation=" + relation;
                // System.out.println(trace);
                removeInfo.AddTrace(trace);
                long actualReturnCount = GetEntityCount(expression);
                Net.Vpc.Upa.Impl.Util.CacheFile cache = new Net.Vpc.Upa.Impl.Util.CacheFile();
                if (recurse && actualReturnCount > 0) {
                    foreach (Net.Vpc.Upa.Relationship r in GetPersistenceUnit().GetRelationshipsByTarget(this)) {
                        if (r.IsTransient()) {
                            continue;
                        }
                        Net.Vpc.Upa.Field masterField = r.GetTargetRole().GetField(0);
                        if (r.GetRelationshipType() == Net.Vpc.Upa.RelationshipType.SHADOW_ASSOCIATION) {
                            if (!simulate) {
                                Net.Vpc.Upa.Record updates = GetBuilder().CreateRecord();
                                System.Collections.Generic.IList<Net.Vpc.Upa.Field> fls = r.GetSourceRole().GetFields();
                                foreach (Net.Vpc.Upa.Field fl in fls) {
                                    updates.SetObject(fl.GetName(), fl.GetDefaultValue());
                                }
                                Net.Vpc.Upa.Expressions.Expression rightCondition = null;
                                if (r.Size() == 1) {
                                    Net.Vpc.Upa.Field ff = r.GetSourceRole().GetField(0);
                                    rightCondition = new Net.Vpc.Upa.Expressions.InSelection(new Net.Vpc.Upa.Expressions.Var(ff.GetName()), (new Net.Vpc.Upa.Expressions.Select()).From(r.GetTargetRole().GetEntity().GetName()).Field(new Net.Vpc.Upa.Expressions.Var(masterField.GetName())).Where(expression));
                                } else {
                                    Net.Vpc.Upa.Expressions.Var[] lvars = new Net.Vpc.Upa.Expressions.Var[r.Size()];
                                    Net.Vpc.Upa.Expressions.Var[] rvars = new Net.Vpc.Upa.Expressions.Var[r.Size()];
                                    for (int x = 0; x < lvars.Length; x++) {
                                        lvars[x] = new Net.Vpc.Upa.Expressions.Var(r.GetSourceRole().GetField(x).GetName());
                                        lvars[x] = new Net.Vpc.Upa.Expressions.Var(r.GetTargetRole().GetField(x).GetName());
                                    }
                                    rightCondition = new Net.Vpc.Upa.Expressions.InSelection(lvars, (new Net.Vpc.Upa.Expressions.Select()).From(r.GetTargetRole().GetEntity().GetName()).Uplet(rvars).Where(expression));
                                }
                                long updatedRecords = r.GetSourceRole().GetEntity().CreateUpdateQuery().SetValues(updates).ByExpression(rightCondition).Execute();
                                // no check !!
                                if (updatedRecords > 0) {
                                    System.Collections.Generic.IList<object> loadedKeys = r.GetSourceRole().GetEntity().CreateQueryBuilder().ByExpression(rightCondition).OrderBy(GetUpdateFormulasOrder()).GetIdList<K>();
                                    if (r.GetSourceRole().GetField(0).GetUpdateFormula() != null && (loadedKeys).Count > 0) {
                                        cache.Write(r.GetName());
                                        cache.Write(loadedKeys);
                                    }
                                }
                            }
                        } else {
                            trace = "To remove " + GetName() + " use first relation " + r;
                            // System.out.println(trace);
                            removeInfo.AddTrace(trace);
                            r.GetSourceRole().GetEntity().Remove(Net.Vpc.Upa.RemoveOptions.ForExpression(((new Net.Vpc.Upa.Expressions.InSelection(new Net.Vpc.Upa.Expressions.Var(r.GetSourceRole().GetField(0).GetName()), (new Net.Vpc.Upa.Expressions.Select()).From(r.GetTargetRole().GetEntity().GetName()).Field(new Net.Vpc.Upa.Expressions.Var(masterField.GetName())).Where(expression))))).SetFollowLinks(true).SetSimulate(simulate).SetRemoveTrace(removeInfo).SetFollowRelationship(r));
                        }
                    }
                }
                cache.Close();
                if (!simulate) {
                    actualReturnCount = RemoveCore(expression, recurse, removeInfo, removeExecContext);
                }
                removeInfo.Add(relation != null ? relation.GetRelationshipType() : Net.Vpc.Upa.RelationshipType.SHADOW_ASSOCIATION, this, actualReturnCount);
                while (cache.HasNext()) {
                    Net.Vpc.Upa.Relationship rel = GetPersistenceUnit().GetRelationship((string) cache.Read());
                    object[] keys = (object[]) cache.Read();
                    Net.Vpc.Upa.Expressions.Var[] lvars = new Net.Vpc.Upa.Expressions.Var[rel.Size()];
                    for (int x = 0; x < lvars.Length; x++) {
                        lvars[x] = new Net.Vpc.Upa.Expressions.Var(rel.GetSourceRole().GetField(x).GetName());
                    }
                    Net.Vpc.Upa.Expressions.IdCollectionExpression inCollection = new Net.Vpc.Upa.Expressions.IdCollectionExpression(lvars);
                    foreach (object key in keys) {
                        inCollection.Add(((object) (GetBuilder().IdToKey(key).GetValue())));
                    }
                    if (rel.Size() == 1) {
                        Net.Vpc.Upa.Expressions.InCollection inColl = new Net.Vpc.Upa.Expressions.InCollection(new Net.Vpc.Upa.Expressions.Param(null, rel.GetSourceRole().GetField(0)));
                        foreach (object key in keys) {
                            inColl.Add(new Net.Vpc.Upa.Expressions.Literal(GetBuilder().IdToKey(key).GetObjectAt(0), rel.GetSourceRole().GetField(0).GetDataType()));
                        }
                        rel.GetSourceRole().GetEntity().CreateUpdateQuery().Validate(Net.Vpc.Upa.Filters.Fields.Regular().And(Net.Vpc.Upa.Filters.Fields.ByList(rel.GetSourceRole().GetFields()))).ByExpression(inColl).Execute();
                    } else {
                        Net.Vpc.Upa.Expressions.Expression[] fuplet = new Net.Vpc.Upa.Expressions.Expression[rel.Size()];
                        for (int y = 0; y < rel.Size(); y++) {
                            Net.Vpc.Upa.Field f = rel.GetSourceRole().GetField(y);
                            fuplet[y] = new Net.Vpc.Upa.Expressions.Var(f.GetName());
                        }
                        Net.Vpc.Upa.Expressions.InCollection inColl = new Net.Vpc.Upa.Expressions.InCollection(new Net.Vpc.Upa.Expressions.Uplet(fuplet));
                        for (int x = 0; x < keys.Length; x++) {
                            Net.Vpc.Upa.Expressions.Expression[] vuplet = new Net.Vpc.Upa.Expressions.Expression[rel.Size()];
                            for (int y = 0; y < rel.Size(); y++) {
                                object key = keys[x];
                                vuplet[x] = ((new Net.Vpc.Upa.Expressions.Literal(GetBuilder().IdToKey(key).GetValue()[y], rel.GetSourceRole().GetField(y).GetDataType())));
                            }
                            inColl.Add(new Net.Vpc.Upa.Expressions.Uplet(vuplet));
                        }
                        rel.GetSourceRole().GetEntity().CreateUpdateQuery().Validate(Net.Vpc.Upa.Filters.Fields.Regular().And(Net.Vpc.Upa.Filters.Fields.ByList(rel.GetSourceRole().GetFields()))).ByExpression(inColl).Execute();
                    }
                }
                cache.Close();
                if (!simulate) {
                    recordListenerSupport.FireAfterRemove(expression, removeExecContext);
                }
                cache = null;
                //            transactionSucceeded = true;
                return removeInfo;
            } finally {
                if (!simulate) {
                }
            }
        }

        public virtual int RemoveCore(Net.Vpc.Upa.Expressions.Expression condition, bool recurse, Net.Vpc.Upa.RemoveTrace removeInfo, Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Persistence.EntityRemoveOperation a = GetEntityOperationManager().GetRemoveOperation();
            if (a != null) {
                return a.Delete(this, CreateContext(Net.Vpc.Upa.Persistence.ContextOperation.REMOVE, executionContext.GetHints()), condition, recurse, removeInfo);
            }
            return 0;
        }

        public virtual bool Save(object objectOrRecord) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Save(objectOrRecord, defaultHints);
        }

        public virtual bool Save(object objectOrRecord, System.Collections.Generic.IDictionary<string , object> hints) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.EntityBuilder builder = GetBuilder();
            Net.Vpc.Upa.Record rec = builder.ObjectToRecord(objectOrRecord);
            object entityToId = builder.RecordToId(rec);
            if (entityToId == null || GetEntityCount(builder.IdToExpression(entityToId, null)) == 0) {
                Persist(objectOrRecord, hints);
                return true;
            } else {
                CreateUpdateQuery().SetValues(objectOrRecord).SetHints(hints).Execute();
                return false;
            }
        }

        public virtual void Persist(object objectOrRecord) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Persist(objectOrRecord, defaultHints);
        }

        public virtual void Persist(object objectOrRecord, System.Collections.Generic.IDictionary<string , object> hints) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Record record = GetBuilder().ObjectToRecord(objectOrRecord, true);
            if (IsCheckSecurity()) {
                GetShield().CheckPersist(record);
            }
            Net.Vpc.Upa.Persistence.EntityExecutionContext context = CreateContext(Net.Vpc.Upa.Persistence.ContextOperation.PERSIST, hints);
            object prePersistId = GetBuilder().RecordToId(record);
            recordListenerSupport.FireBeforePersist(prePersistId, record, context);
            PersistCore(record, context);
            object postPersistId = GetBuilder().RecordToId(record);
            if (GetShield().IsUpdateFormulaOnPersistSupported()) {
                Net.Vpc.Upa.Expressions.Expression expr = GetBuilder().IdToExpression(postPersistId, null);
                //            expr.setClientProperty(EXPRESSION_SURELY_EXISTS, true);
                UpdateFormulasCore(Net.Vpc.Upa.Impl.Util.Filters.Fields2.PERSIST_FORMULA, expr, context);
                Net.Vpc.Upa.Record formulaValues = CreateQueryBuilder().ByExpression(expr).SetFieldFilter(Net.Vpc.Upa.Impl.Util.Filters.Fields2.PERSIST_FORMULA).GetRecord();
                record.SetAll(formulaValues);
            }
            recordListenerSupport.FireAfterPersist(postPersistId, record, context);
        }


        public virtual void Initialize() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Initialize(defaultHints);
        }


        public virtual void Initialize(System.Collections.Generic.IDictionary<string , object> hints) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (IsCheckSecurity()) {
                GetShield().CheckInitialize();
            }
            Net.Vpc.Upa.Persistence.EntityExecutionContext context = CreateContext(Net.Vpc.Upa.Persistence.ContextOperation.INITIALIZE, hints);
            recordListenerSupport.FireBeforeInitialize(context);
            InitializeCore(context);
            recordListenerSupport.FireAfterInitialize(context);
        }


        public virtual void Clear() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Clear(defaultHints);
        }


        public virtual void Clear(System.Collections.Generic.IDictionary<string , object> hints) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (IsCheckSecurity()) {
                GetShield().CheckClear();
            }
            Net.Vpc.Upa.Persistence.EntityExecutionContext context = CreateContext(Net.Vpc.Upa.Persistence.ContextOperation.CLEAR, hints);
            recordListenerSupport.FireBeforeClear(context);
            ClearCore(context);
            recordListenerSupport.FireAfterClear(context);
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetUnicityExpressionForPersist(object entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            object key = GetBuilder().ObjectToId(entity);
            Net.Vpc.Upa.Record urecord = GetBuilder().ObjectToRecord(entity, false);
            System.Collections.Generic.IList<Net.Vpc.Upa.Index> uniqueIndexes = GetIndexes(true);
            if ((uniqueIndexes.Count==0)) {
                return GetBuilder().IdToExpression(key, null);
            }
            Net.Vpc.Upa.Expressions.Expression or = GetBuilder().IdToExpression(key, null);
            foreach (Net.Vpc.Upa.Index index in uniqueIndexes) {
                Net.Vpc.Upa.Field[] f = index.GetFields();
                Net.Vpc.Upa.Expressions.Expression e1 = null;
                if (f.Length == 1) {
                    e1 = new Net.Vpc.Upa.Expressions.Equals(new Net.Vpc.Upa.Expressions.Var(f[0].GetName()), Net.Vpc.Upa.Expressions.ExpressionFactory.ToLiteral(urecord.GetObject<T>(f[0].GetName())));
                } else {
                    Net.Vpc.Upa.Expressions.Expression a = null;
                    foreach (Net.Vpc.Upa.Field aF in f) {
                        Net.Vpc.Upa.Expressions.Expression e = (new Net.Vpc.Upa.Expressions.Equals(new Net.Vpc.Upa.Expressions.Var(aF.GetName()), Net.Vpc.Upa.Expressions.ExpressionFactory.ToLiteral(urecord.GetObject<T>(aF.GetName()))));
                        a = a == null ? ((Net.Vpc.Upa.Expressions.Expression)(e)) : new Net.Vpc.Upa.Expressions.And(a, e);
                    }
                    e1 = a;
                }
                or = or == null ? ((Net.Vpc.Upa.Expressions.Expression)(e1)) : new Net.Vpc.Upa.Expressions.Or(or, e1);
            }
            return or;
        }

        public virtual bool ContainsCompoundFields() {
            foreach (Net.Vpc.Upa.Field extendedField in (fieldsMap).Values) {
                if (extendedField is Net.Vpc.Upa.CompoundField) {
                    return true;
                }
            }
            return false;
        }

        public virtual void PersistCore(Net.Vpc.Upa.Record record, Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            foreach (Net.Vpc.Upa.Impl.Persistence.FieldPersistenceInfo gen in fieldListPersistenceInfo.persistSequenceGeneratorFields) {
                gen.persistFieldPersister.BeforePersist(record, executionContext);
            }
            System.Collections.Generic.HashSet<Net.Vpc.Upa.Field> persistNonNullable = new System.Collections.Generic.HashSet<Net.Vpc.Upa.Field>(GetFields(FIELD_FILTER_PERSIST_NON_NULLABLE));
            System.Collections.Generic.HashSet<Net.Vpc.Upa.Field> persistWithDefaultValue = new System.Collections.Generic.HashSet<Net.Vpc.Upa.Field>(GetFields(FIELD_FILTER_PERSIST_WITH_DEFAULT_VALUE));
            System.Collections.Generic.HashSet<Net.Vpc.Upa.Field> emptySet = new System.Collections.Generic.HashSet<Net.Vpc.Upa.Field>();
            Net.Vpc.Upa.Impl.DefaultRecord persistentRecord = new Net.Vpc.Upa.Impl.DefaultRecord();
            foreach (System.Collections.Generic.KeyValuePair<string , object> entry in record.EntrySet()) {
                object @value = (entry).Value;
                string key = (entry).Key;
                //check if the field exists in the entity
                Net.Vpc.Upa.Field field = FindField(key);
                if (field != null) {
                    //make handled
                    persistNonNullable.Remove(field);
                    persistWithDefaultValue.Remove(field);
                    bool accepted = Net.Vpc.Upa.Impl.Util.Filters.Fields2.PERSIST.Accept(field);
                    if (accepted) {
                        ((Net.Vpc.Upa.Impl.AbstractField) field).GetFieldPersister().PrepareFieldForPersist(field, @value, record, persistentRecord, executionContext, persistNonNullable, persistWithDefaultValue);
                    }
                }
            }
            //add default values
            foreach (Net.Vpc.Upa.Field field in persistWithDefaultValue) {
                object @value = field.GetDefaultValue();
                if (@value == null) {
                    if (!field.GetDataType().IsNullable()) {
                        @value = field.GetDataType().GetDefaultNonNullValue();
                    }
                }
                record.SetObject(field.GetName(), @value);
                ((Net.Vpc.Upa.Impl.AbstractField) field).GetFieldPersister().PrepareFieldForPersist(field, @value, record, persistentRecord, executionContext, persistNonNullable, emptySet);
            }
            GetEntityOperationManager().GetPersistOperation().Insert(this, record, persistentRecord, executionContext);
            foreach (Net.Vpc.Upa.Impl.Persistence.FieldPersistenceInfo gen in fieldListPersistenceInfo.persistSequenceGeneratorFields) {
                gen.persistFieldPersister.AfterPersist(record, executionContext);
            }
        }

        public virtual void Update(object objectOrRecord) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            CreateUpdateQuery().SetValues(objectOrRecord).Execute();
        }

        public virtual void Merge(object objectOrRecord) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            CreateUpdateQuery().SetValues(objectOrRecord).Execute();
        }

        private Net.Vpc.Upa.Expressions.Expression ObjToExpression(Net.Vpc.Upa.ConditionType conditionType, object condition) {
            Net.Vpc.Upa.Expressions.Expression expr = null;
            Net.Vpc.Upa.EntityBuilder builder = GetBuilder();
            switch(conditionType) {
                case Net.Vpc.Upa.ConditionType.EXPRESSION:
                    {
                        expr = ((Net.Vpc.Upa.Expressions.Expression) condition);
                        break;
                    }
                case Net.Vpc.Upa.ConditionType.EXPRESSION_LIST:
                    {
                        Net.Vpc.Upa.Expressions.Expression ll = null;
                        foreach (Net.Vpc.Upa.Expressions.Expression t in ((System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.Expression>) condition)) {
                            if (ll == null) {
                                ll = t;
                            } else {
                                ll = new Net.Vpc.Upa.Expressions.Or(ll, t);
                            }
                        }
                        expr = ll;
                        break;
                    }
                case Net.Vpc.Upa.ConditionType.ID:
                    {
                        expr = builder.IdToExpression(condition, null);
                        break;
                    }
                case Net.Vpc.Upa.ConditionType.KEY:
                    {
                        expr = builder.KeyToExpression((Net.Vpc.Upa.Key) condition, null);
                        break;
                    }
                case Net.Vpc.Upa.ConditionType.OBJECT:
                    {
                        expr = builder.IdToExpression(builder.ObjectToId(condition), null);
                        break;
                    }
                case Net.Vpc.Upa.ConditionType.RECORD:
                    {
                        Net.Vpc.Upa.Record r = (Net.Vpc.Upa.Record) condition;
                        expr = builder.IdToExpression(builder.RecordToId(r), null);
                        break;
                    }
                case Net.Vpc.Upa.ConditionType.PROTOTYPE:
                    {
                        expr = builder.ObjectToExpression(condition, true, null);
                        break;
                    }
                case Net.Vpc.Upa.ConditionType.RECORD_PROTOTYPE:
                    {
                        expr = builder.RecordToExpression((Net.Vpc.Upa.Record) condition, null);
                        break;
                    }
                case Net.Vpc.Upa.ConditionType.ID_LIST:
                    {
                        System.Collections.Generic.IList<object> objectList = Net.Vpc.Upa.Impl.Util.PlatformUtils.AnyObjectToObjectList(condition);
                        expr = builder.IdListToExpression<object>(objectList, null);
                        break;
                    }
                case Net.Vpc.Upa.ConditionType.KEY_LIST:
                    {
                        System.Collections.Generic.IList<Net.Vpc.Upa.Key> anyList = (System.Collections.Generic.IList<Net.Vpc.Upa.Key>) condition;
                        expr = builder.KeyListToExpression(anyList, null);
                        break;
                    }
            }
            return expr;
        }


        public virtual Net.Vpc.Upa.RemoveTrace Remove(object @object) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (@object == null) {
                throw new Net.Vpc.Upa.Exceptions.UPAException("ObjectNotFoundException");
            } else if (@object is Net.Vpc.Upa.RemoveOptions) {
                return Remove((Net.Vpc.Upa.RemoveOptions) @object);
            } else {
                return Remove(Net.Vpc.Upa.RemoveOptions.ForObject(@object));
            }
        }


        public virtual Net.Vpc.Upa.Field[] ToFieldArray(string[] s) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Field[] f = new Net.Vpc.Upa.Field[s.Length];
            for (int i = 0; i < s.Length; i++) {
                f[i] = GetField(s[i]);
                if (f[i] == null) {
                    log.TraceEvent(System.Diagnostics.TraceEventType.Warning,90,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("field " + s[i] + " not found in " + GetName() + "; all fields are : " + (fieldsMap).Values,null));
                }
            }
            return f;
        }


        public virtual bool Contains(object key) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return key != null && GetEntityCount(GetBuilder().IdToExpression(key, GetName())) > 0;
        }

        public virtual int UpdateRecords(Net.Vpc.Upa.Record updates, Net.Vpc.Upa.Expressions.Expression condition) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return UpdateRecords(updates, condition, defaultHints);
        }

        public virtual int UpdateRecords(Net.Vpc.Upa.Record updates, Net.Vpc.Upa.Expressions.Expression condition, System.Collections.Generic.IDictionary<string , object> hints) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> fields = (GetShield().IsUpdateFormulaOnUpdateSupported()) ? GetFields(Net.Vpc.Upa.Impl.Util.Filters.Fields2.UPDATE_FORMULA) : null;
            return UpdateRecords(updates, fields, condition, hints);
        }

        public virtual int UpdateCore(Net.Vpc.Upa.Record updates, Net.Vpc.Upa.Expressions.Expression condition, Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetEntityOperationManager().GetUpdateOperation().Update(this, CreateContext(Net.Vpc.Upa.Persistence.ContextOperation.UPDATE, executionContext.GetHints()), updates, condition);
        }


        public virtual string GetIdName(object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (id == null) {
                return null;
            }
            object[] ukey = GetBuilder().IdToKey(id).GetValue();
            Net.Vpc.Upa.Field f = GetMainField();
            if (ukey.Length == 1 && f.IsId()) {
                return System.Convert.ToString(ukey[0]);
            }
            object n = CreateQueryBuilder().ById(id).SetFieldFilter(Net.Vpc.Upa.Filters.Fields.Regular().And(Net.Vpc.Upa.Filters.Fields.ByList(f))).GetSingleValue();
            if (n != null) {
                foreach (Net.Vpc.Upa.Relationship r in f.GetManyToOneRelationships()) {
                    if (r.Size() == 1) {
                        Net.Vpc.Upa.Entity entity = r.GetTargetRole().GetEntity();
                        return entity.GetIdName(entity.CreateId(n));
                    }
                }
                return System.Convert.ToString(n);
            }
            return null;
        }

        public virtual Net.Vpc.Upa.Persistence.EntityExecutionContext CreateContext(Net.Vpc.Upa.Persistence.ContextOperation contextOperation, System.Collections.Generic.IDictionary<string , object> hints) {
            Net.Vpc.Upa.Persistence.EntityExecutionContext context = ((Net.Vpc.Upa.Impl.DefaultPersistenceUnit) GetPersistenceUnit()).CreateContext(contextOperation, hints);
            context.InitEntity(this, entityOperationManager);
            context.SetHints(hints);
            return context;
        }

        public virtual Net.Vpc.Upa.QueryBuilder CreateQueryBuilder() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Impl.Persistence.DefaultQueryBuilder q = new Net.Vpc.Upa.Impl.Persistence.DefaultQueryBuilder(this);
            bool lazyListLoadingEnabled = GetPersistenceUnit().GetProperties().GetBoolean("Query.LazyListLoadingEnabled", true);
            q.SetLazyListLoadingEnabled(lazyListLoadingEnabled);
            return q;
        }


        public virtual Net.Vpc.Upa.Query CreateQuery(Net.Vpc.Upa.Expressions.EntityStatement query) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (query is Net.Vpc.Upa.Expressions.Select) {
                Net.Vpc.Upa.Expressions.Select s = (Net.Vpc.Upa.Expressions.Select) query;
                Net.Vpc.Upa.Expressions.NameOrQuery entityName = s.GetEntity();
                if (entityName == null) {
                    s.From(GetName());
                }
            }
            System.Collections.Generic.IDictionary<string , object> hints = null;
            //no need for hints, could be customizer later in Query
            if (query is Net.Vpc.Upa.Expressions.QueryStatement) {
                return GetEntityOperationManager().GetFindOperation().CreateQuery(this, (Net.Vpc.Upa.Expressions.QueryStatement) query, CreateContext(Net.Vpc.Upa.Persistence.ContextOperation.FIND, hints));
            }
            if (query is Net.Vpc.Upa.Expressions.Insert) {
                return GetEntityOperationManager().GetPersistOperation().CreateQuery(this, (Net.Vpc.Upa.Expressions.Insert) query, CreateContext(Net.Vpc.Upa.Persistence.ContextOperation.PERSIST, hints));
            }
            if (query is Net.Vpc.Upa.Expressions.Update) {
                return GetEntityOperationManager().GetUpdateOperation().CreateQuery(this, (Net.Vpc.Upa.Expressions.Update) query, CreateContext(Net.Vpc.Upa.Persistence.ContextOperation.UPDATE, hints));
            }
            if (query is Net.Vpc.Upa.Expressions.Delete) {
                return GetEntityOperationManager().GetRemoveOperation().CreateQuery(this, (Net.Vpc.Upa.Expressions.Delete) query, CreateContext(Net.Vpc.Upa.Persistence.ContextOperation.REMOVE, hints));
            }
            throw new System.Exception("Not supported statement type " + query);
        }


        public virtual Net.Vpc.Upa.Query CreateQuery(string query) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Expressions.Expression e = GetPersistenceUnit().GetExpressionManager().ParseExpression(query);
            if (!(e is Net.Vpc.Upa.Expressions.QueryStatement)) {
                Net.Vpc.Upa.Expressions.Select s = new Net.Vpc.Upa.Expressions.Select();
                s.SetWhere(e);
                e = s;
            }
            return CreateQuery((Net.Vpc.Upa.Expressions.QueryStatement) e);
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.PrimitiveField> GetPrimitiveFields(params string [] fieldNames) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (fieldNames == null) {
                return null;
            }
            if (fieldNames.Length == 0) {
                return ToPrimitiveFields<Net.Vpc.Upa.EntityPart>(GetParts());
            }
            if (ContainsCompoundFields()) {
                System.Collections.Generic.IList<Net.Vpc.Upa.PrimitiveField> v = new System.Collections.Generic.List<Net.Vpc.Upa.PrimitiveField>(fieldNames.Length);
                foreach (string fieldName in fieldNames) {
                    Net.Vpc.Upa.EntityPart entityPart = GetField(fieldName);
                    if (entityPart is Net.Vpc.Upa.PrimitiveField) {
                        v.Add((Net.Vpc.Upa.PrimitiveField) entityPart);
                    } else {
                        Net.Vpc.Upa.CompoundField compoundField = (Net.Vpc.Upa.CompoundField) entityPart;
                        System.Collections.Generic.IList<Net.Vpc.Upa.PrimitiveField> fds = compoundField.GetFields();
                        foreach (Net.Vpc.Upa.PrimitiveField fd in fds) {
                            v.Add(fd);
                        }
                    }
                }
                return v;
            } else {
                System.Collections.Generic.IList<Net.Vpc.Upa.PrimitiveField> v = new System.Collections.Generic.List<Net.Vpc.Upa.PrimitiveField>(fieldNames.Length);
                foreach (string fieldName in fieldNames) {
                    v.Add(GetPrimitiveField(fieldName));
                }
                return v;
            }
        }


        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Field> GetValidFields(params string [] fieldNames) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.List<Net.Vpc.Upa.Field> found = new System.Collections.Generic.List<Net.Vpc.Upa.Field>();
            foreach (string field in fieldNames) {
                Net.Vpc.Upa.Field f = FindField(field);
                if (f != null) {
                    found.Add(f);
                }
            }
            return found;
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Field> GetFields(params string [] fieldNames) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (fieldNames == null) {
                return null;
            }
            if (fieldNames.Length == 0) {
                return GetFields(GetParts());
            }
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> flds = new System.Collections.Generic.List<Net.Vpc.Upa.Field>(fieldNames.Length);
            foreach (string fieldName in fieldNames) {
                flds.Add(GetField(fieldName));
            }
            return flds;
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Field> GetFields() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetFields(GetParts());
        }


        public virtual Net.Vpc.Upa.UpdateQuery CreateUpdateQuery() {
            return new Net.Vpc.Upa.Impl.DefaultUpdateQuery(this);
        }

        public virtual long Update(Net.Vpc.Upa.UpdateQuery updateQuery) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            bool updateSingleObject = false;
            System.Collections.Generic.IDictionary<string , object> hints = updateQuery.GetHints();
            //        UpdateConditionType updateConditionType = options.getUpdateConditionType();
            //        if(updateConditionType ==null /*|| updateConditionType==UpdateConditionType.DEFAULT*/){
            //            updateConditionType =
            //        }
            object updateCondition = updateQuery.GetUpdateCondition();
            object updatesValue = updateQuery.GetValues();
            Net.Vpc.Upa.Filters.FieldFilter formulaFields = updateQuery.GetFormulaFields();
            Net.Vpc.Upa.Expressions.Expression whereExpression = ObjToExpression(updateQuery.GetUpdateConditionType(), updateCondition);
            object idToUpdate = GetBuilder().ObjectToId(updatesValue);
            Net.Vpc.Upa.Expressions.Expression idExpression = null;
            if (idToUpdate != null) {
                idExpression = GetBuilder().IdToExpression(idToUpdate, null);
                updateSingleObject = true;
            }
            if (updateQuery.GetUpdateConditionType() == default(Net.Vpc.Upa.ConditionType)) {
                throw new Net.Vpc.Upa.Exceptions.UPAException("MissingConditionType");
            }
            if (!updateSingleObject) {
                switch(updateQuery.GetUpdateConditionType()) {
                    case Net.Vpc.Upa.ConditionType.ID:
                    case Net.Vpc.Upa.ConditionType.KEY:
                        {
                            updateSingleObject = true;
                        }
                        break;
                    case Net.Vpc.Upa.ConditionType.OBJECT:
                        {
                            object i2 = GetBuilder().ObjectToId(updateCondition);
                            updateSingleObject = i2 != null;
                        }
                        break;
                    case Net.Vpc.Upa.ConditionType.RECORD:
                        {
                            object i2 = GetBuilder().RecordToId((Net.Vpc.Upa.Record) updateCondition);
                            updateSingleObject = i2 != null;
                        }
                        break;
                    case Net.Vpc.Upa.ConditionType.EXPRESSION:
                        {
                            if (updateCondition is Net.Vpc.Upa.Expressions.IdExpression) {
                                //Object id = ((IdExpression) updateCondition1).getId();
                                updateSingleObject = true;
                            }
                        }
                        break;
                }
            }
            if (whereExpression == null) {
                whereExpression = idExpression;
            } else if (idExpression != null) {
                whereExpression = new Net.Vpc.Upa.Expressions.And(idExpression, whereExpression);
            }
            if (updatesValue == null) {
                Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext = CreateContext(Net.Vpc.Upa.Persistence.ContextOperation.VALIDATE, hints);
                //check if the is some formulas
                if (formulaFields == null) {
                    throw new Net.Vpc.Upa.Exceptions.UPAException("NothingToUpdate");
                }
                return UpdateFormulasCore(formulaFields, whereExpression, executionContext);
            } else {
                Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext = CreateContext(Net.Vpc.Upa.Persistence.ContextOperation.UPDATE, hints);
                Net.Vpc.Upa.Record updates = null;
                if (updateQuery.GetUpdatedFields() != null && (updateQuery.GetUpdatedFields()).Count > 0) {
                    updates = GetBuilder().ObjectToRecord(updatesValue, updateQuery.GetUpdatedFields(), updateQuery.IsIgnoreUnspecified(), true);
                } else {
                    updates = GetBuilder().ObjectToRecord(updatesValue, updateQuery.IsIgnoreUnspecified());
                }
                if (formulaFields == null) {
                    formulaFields = (GetShield().IsUpdateFormulaOnUpdateSupported()) ? Net.Vpc.Upa.Impl.Util.Filters.Fields2.UPDATE_FORMULA : null;
                }
                //if updates contain primary fields add them to condition
                //because primary fields are not updatable
                //one may use rename instead
                System.Collections.Generic.IList<Net.Vpc.Upa.Field> extraConditions = new System.Collections.Generic.List<Net.Vpc.Upa.Field>();
                System.Collections.Generic.IList<Net.Vpc.Upa.Field> primaryFields = GetPrimaryFields();
                System.Collections.Generic.ISet<string> primaryFieldNames = new System.Collections.Generic.HashSet<string>();
                foreach (Net.Vpc.Upa.Field field in primaryFields) {
                    //                if (updates.isSet(field.getName())) {
                    //                    extraConditions.add(field);
                    //                }
                    primaryFieldNames.Add(field.GetName());
                }
                //            if (extraConditions.size() == primaryFields.size()) {
                //                //all primary are defined
                //                Expression expression = getBuilder().idToExpression(getBuilder().recordToId(updates), getName());
                //                if (whereExpression == null || !whereExpression.isValid()) {
                //                    whereExpression = expression;
                //                } else if (!expression.equals(whereExpression)) {
                //                    whereExpression = new And(whereExpression, expression);
                //                }
                //            }
                whereExpression = ToIdListExpression(whereExpression);
                if (IsCheckSecurity()) {
                    GetShield().CheckUpdate(updates, whereExpression);
                }
                //        Object transaction = getPersistenceUnit().getPersistenceStore().getConnection().tryBeginTransaction();
                //        boolean transactionSucceeded = false;
                //        try {
                int r = -1;
                if (formulaFields != null) {
                    Net.Vpc.Upa.Record fieldNamesToUpdateMap = GetBuilder().CreateRecord();
                    System.Collections.Generic.ISet<string> cancelUpdates = new System.Collections.Generic.HashSet<string>();
                    //copy all but primary fields
                    foreach (System.Collections.Generic.KeyValuePair<string , object> ee in updates.EntrySet()) {
                        string fieldName = (ee).Key;
                        if (!primaryFieldNames.Contains(fieldName)) {
                            object @value = (ee).Value;
                            Net.Vpc.Upa.Field field = GetField(fieldName);
                            ((Net.Vpc.Upa.Impl.AbstractField) field).GetFieldPersister().PrepareFieldForUpdate(field, @value, updates, fieldNamesToUpdateMap, executionContext);
                        }
                    }
                    System.Collections.Generic.IList<Net.Vpc.Upa.Field> storedFieldsToValidate = GetFields(formulaFields);
                    foreach (string f in cancelUpdates) {
                        fieldNamesToUpdateMap.Remove(f);
                    }
                    foreach (Net.Vpc.Upa.Field field in storedFieldsToValidate) {
                        Net.Vpc.Upa.Expressions.Expression expression = GetFieldExpression(field, false);
                        fieldNamesToUpdateMap.SetObject(field.GetName(), expression);
                    }
                    if (!fieldNamesToUpdateMap.IsEmpty()) {
                        recordListenerSupport.FireBeforeUpdate(fieldNamesToUpdateMap, whereExpression, executionContext);
                        r = UpdateCore(fieldNamesToUpdateMap, whereExpression, executionContext);
                        if (r > 0) {
                            Net.Vpc.Upa.Impl.Persistence.FormulaUpdateProcessor p = new Net.Vpc.Upa.Impl.Persistence.FormulaUpdateProcessor(false, storedFieldsToValidate, whereExpression, executionContext, this, GetEntityOperationManager());
                            p.UpdateFormulasCore();
                        }
                        recordListenerSupport.FireAfterUpdate(fieldNamesToUpdateMap, whereExpression, executionContext);
                    }
                } else {
                    Net.Vpc.Upa.Record fieldNamesToUpdateMap = GetBuilder().CreateRecord();
                    foreach (System.Collections.Generic.KeyValuePair<string , object> ee in updates.EntrySet()) {
                        string fieldName = (ee).Key;
                        if (!primaryFieldNames.Contains(fieldName)) {
                            object @value = (ee).Value;
                            Net.Vpc.Upa.Field field = GetField(fieldName);
                            ((Net.Vpc.Upa.Impl.AbstractField) field).GetFieldPersister().PrepareFieldForUpdate(field, @value, updates, fieldNamesToUpdateMap, executionContext);
                        }
                    }
                    if (!fieldNamesToUpdateMap.IsEmpty()) {
                        recordListenerSupport.FireBeforeUpdate(fieldNamesToUpdateMap, whereExpression, executionContext);
                        r = UpdateCore(fieldNamesToUpdateMap, whereExpression, executionContext);
                        recordListenerSupport.FireAfterUpdate(fieldNamesToUpdateMap, whereExpression, executionContext);
                    }
                }
                //            transactionSucceeded = true;
                if (updateSingleObject && GetShield().IsUpdateFormulaOnUpdateSupported()) {
                    //need reload formua fields
                    System.Collections.Generic.IList<Net.Vpc.Upa.Field> fields = GetFields(Net.Vpc.Upa.Impl.Util.Filters.Fields2.UPDATE_FORMULA);
                    if (fields != null && (fields).Count > 0) {
                        Net.Vpc.Upa.Record generatedFormulas = CreateQueryBuilder().SetFieldFilter(Net.Vpc.Upa.Filters.Fields.Regular().And(Net.Vpc.Upa.Filters.Fields.ByList(fields))).GetRecord();
                        if (generatedFormulas != null) {
                            updates.SetAll(generatedFormulas);
                        }
                    }
                }
                return r;
            }
        }

        protected internal virtual int UpdateRecords(Net.Vpc.Upa.Record updates, System.Collections.Generic.IList<Net.Vpc.Upa.Field> storedFieldsToValidate, Net.Vpc.Upa.Expressions.Expression updateCondition, System.Collections.Generic.IDictionary<string , object> hints) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            //if updates contain primary fields add them to condition
            //because primary fields are not updatable
            //one may use rename instead
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> extraConditions = new System.Collections.Generic.List<Net.Vpc.Upa.Field>();
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> primaryFields = GetPrimaryFields();
            System.Collections.Generic.ISet<string> primaryFieldNames = new System.Collections.Generic.HashSet<string>();
            foreach (Net.Vpc.Upa.Field field in primaryFields) {
                if (updates.IsSet(field.GetName())) {
                    extraConditions.Add(field);
                }
                primaryFieldNames.Add(field.GetName());
            }
            if ((extraConditions).Count == (primaryFields).Count) {
                //all primary are defined
                Net.Vpc.Upa.Expressions.Expression expression = GetBuilder().IdToExpression(GetBuilder().RecordToId(updates), GetName());
                if (updateCondition == null || !updateCondition.IsValid()) {
                    updateCondition = expression;
                } else if (!expression.Equals(updateCondition)) {
                    updateCondition = new Net.Vpc.Upa.Expressions.And(updateCondition, expression);
                }
            }
            updateCondition = ToIdListExpression(updateCondition);
            if (IsCheckSecurity()) {
                GetShield().CheckUpdate(updates, updateCondition);
            }
            //        Object transaction = getPersistenceUnit().getPersistenceStore().getConnection().tryBeginTransaction();
            //        boolean transactionSucceeded = false;
            //        try {
            Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext = CreateContext(Net.Vpc.Upa.Persistence.ContextOperation.UPDATE, hints);
            int r = -1;
            if (storedFieldsToValidate != null) {
                Net.Vpc.Upa.Record fieldNamesToUpdateMap = GetBuilder().CreateRecord();
                System.Collections.Generic.ISet<string> cancelUpdates = new System.Collections.Generic.HashSet<string>();
                //copy all but primary fields
                foreach (System.Collections.Generic.KeyValuePair<string , object> ee in updates.EntrySet()) {
                    string fieldName = (ee).Key;
                    if (!primaryFieldNames.Contains(fieldName)) {
                        object @value = (ee).Value;
                        Net.Vpc.Upa.Field field = GetField(fieldName);
                        ((Net.Vpc.Upa.Impl.AbstractField) field).GetFieldPersister().PrepareFieldForUpdate(field, @value, updates, fieldNamesToUpdateMap, executionContext);
                    }
                }
                foreach (string f in cancelUpdates) {
                    fieldNamesToUpdateMap.Remove(f);
                }
                foreach (Net.Vpc.Upa.Field field in storedFieldsToValidate) {
                    Net.Vpc.Upa.Expressions.Expression expression = GetFieldExpression(field, false);
                    fieldNamesToUpdateMap.SetObject(field.GetName(), expression);
                }
                if (!fieldNamesToUpdateMap.IsEmpty()) {
                    recordListenerSupport.FireBeforeUpdate(fieldNamesToUpdateMap, updateCondition, executionContext);
                    r = UpdateCore(fieldNamesToUpdateMap, updateCondition, executionContext);
                    if (r > 0) {
                        Net.Vpc.Upa.Impl.Persistence.FormulaUpdateProcessor p = new Net.Vpc.Upa.Impl.Persistence.FormulaUpdateProcessor(false, storedFieldsToValidate, updateCondition, executionContext, this, GetEntityOperationManager());
                        p.UpdateFormulasCore();
                    }
                    recordListenerSupport.FireAfterUpdate(fieldNamesToUpdateMap, updateCondition, executionContext);
                }
            } else {
                Net.Vpc.Upa.Record fieldNamesToUpdateMap = GetBuilder().CreateRecord();
                foreach (System.Collections.Generic.KeyValuePair<string , object> ee in updates.EntrySet()) {
                    string fieldName = (ee).Key;
                    if (!primaryFieldNames.Contains(fieldName)) {
                        object @value = (ee).Value;
                        Net.Vpc.Upa.Field field = GetField(fieldName);
                        ((Net.Vpc.Upa.Impl.AbstractField) field).GetFieldPersister().PrepareFieldForUpdate(field, @value, updates, fieldNamesToUpdateMap, executionContext);
                    }
                }
                if (!fieldNamesToUpdateMap.IsEmpty()) {
                    recordListenerSupport.FireBeforeUpdate(fieldNamesToUpdateMap, updateCondition, executionContext);
                    r = UpdateCore(fieldNamesToUpdateMap, updateCondition, executionContext);
                    recordListenerSupport.FireAfterUpdate(fieldNamesToUpdateMap, updateCondition, executionContext);
                }
            }
            //            transactionSucceeded = true;
            return r;
        }

        protected internal virtual long UpdateFormulasCore(Net.Vpc.Upa.Filters.FieldFilter fieldFilter, Net.Vpc.Upa.Expressions.Expression expr, Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> noFields = Net.Vpc.Upa.Impl.Util.PlatformUtils.EmptyList<T>();
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> fieldsToUpdate = fieldFilter != null ? (System.Collections.Generic.IList<Net.Vpc.Upa.Field>) GetFields(fieldFilter) : noFields;
            bool persistContext = Net.Vpc.Upa.Persistence.ContextOperation.PERSIST.Equals(context.GetOperation());
            //TODO this is a work around, those fields must be removed
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> fieldsToUpdate2 = new System.Collections.Generic.List<Net.Vpc.Upa.Field>();
            foreach (Net.Vpc.Upa.Field f in fieldsToUpdate) {
                //TODO why should i remove postInsertFormula and postUpdateFormula formulas?
                //please be more specific
                //            FieldPersistenceInfo nfo = fieldListPersistenceInfo.fields.get(f.getName());
                //            if ((insertContext && nfo.postInsertFormula) || (!insertContext && nfo.postUpdateFormula)) {
                fieldsToUpdate2.Add(f);
            }
            //            }
            if ((fieldsToUpdate2.Count==0)) {
                return 0;
            }
            fieldsToUpdate = fieldsToUpdate2;
            //        Object methodExecId = new Double(Math.random());
            //        final String exprSQL = expr == null ? null : expr.toSQL(getPersistenceUnit());
            //        Log.log(EditorConstants.Logs.VALIDATE, getName() + " validating " + Arrays2.arrayToString(fieldsToUpdate) + " For expression " + exprSQL);
            //        Log.method_enter(methodExecId, getName(), fieldsToUpdate, exprSQL);
            expr = ToIdListExpression(expr);
            if (fieldsToUpdate == null || (fieldsToUpdate.Count==0)) {
                fieldsToUpdate = GetFields(Net.Vpc.Upa.Impl.Util.Filters.Fields2.UPDATE_FORMULA);
            }
            if ((fieldsToUpdate).Count > 0) {
                // System.out.println(getName()+".updateFormulas("+Arrays.asList(fieldsToUpdate)+","+expr+"){");
                // check ???
                bool doValidation = true;
                if (VALIDATE_IF_CHANGED) {
                    doValidation = false;
                    Net.Vpc.Upa.Expressions.Expression newFieldsValuesExpression = null;
                    for (int i = 0; !doValidation && i < (fieldsToUpdate).Count; i++) {
                        Net.Vpc.Upa.Field field = fieldsToUpdate[i];
                        Net.Vpc.Upa.Formula f = persistContext ? field.GetPersistFormula() : field.GetUpdateFormula();
                        if ((f is Net.Vpc.Upa.CustomUpdaterFormula) || (f is Net.Vpc.Upa.CustomUpdaterFormula)) {
                            doValidation = true;
                            break;
                        }
                        Net.Vpc.Upa.Expressions.Expression formExpr = GetFieldExpression(field, persistContext);
                        if (formExpr != null) {
                            // newFieldsValuesExpression.or(new
                            // Different(fieldsToUpdate.get(i).getName(),new
                            // UserExpression(fieldsToUpdate.get(i).getExpression())));
                            Net.Vpc.Upa.Expressions.Expression e = new Net.Vpc.Upa.Expressions.Not(new Net.Vpc.Upa.Expressions.Or(new Net.Vpc.Upa.Expressions.And(new Net.Vpc.Upa.Expressions.Equals(new Net.Vpc.Upa.Expressions.Var(field.GetName()), null), new Net.Vpc.Upa.Expressions.Equals(formExpr, null)), new Net.Vpc.Upa.Expressions.And(new Net.Vpc.Upa.Expressions.Different(new Net.Vpc.Upa.Expressions.Var(field.GetName()), null), new Net.Vpc.Upa.Expressions.And(new Net.Vpc.Upa.Expressions.Different(formExpr, null), new Net.Vpc.Upa.Expressions.Equals(new Net.Vpc.Upa.Expressions.Var(field.GetName()), formExpr)))));
                            newFieldsValuesExpression = newFieldsValuesExpression == null ? ((Net.Vpc.Upa.Expressions.Expression)(e)) : new Net.Vpc.Upa.Expressions.Or(newFieldsValuesExpression, e);
                        }
                    }
                    if (!doValidation) {
                        Net.Vpc.Upa.Expressions.Expression exp2 = new Net.Vpc.Upa.Expressions.And(expr, newFieldsValuesExpression);
                        long recordsCount = GetEntityCount(exp2.IsValid() ? exp2 : null);
                        doValidation = recordsCount > 0;
                    } else {
                        long recordsCount = GetEntityCount(expr);
                        doValidation = recordsCount > 0;
                    }
                } else {
                    // if KeyExpression dont call getEntityCount(expr)
                    //Boolean b = expr == null ? Boolean.valueOf((!isEmpty())) : (Boolean) expr.getClientProperty(EXPRESSION_SURELY_EXISTS);
                    bool? b = System.Convert.ToBoolean((!IsEmpty()));
                    // doValidation = b != null ? b.booleanValue() : (expr
                    // instanceof KeyExpression || (expr instanceof
                    // KeyCollectionExpression &&
                    // ((KeyCollectionExpression)expr).size()>0) ||
                    // (getEntityCount(expr) > 0)) ;
                    doValidation = b != null ? ((bool)(b)) : ((GetEntityCount(expr) > 0));
                }
                long count = 0;
                if (doValidation) {
                    Net.Vpc.Upa.Record fieldNamesToUpdateMap = GetBuilder().CreateRecord();
                    foreach (Net.Vpc.Upa.Field aFieldsToUpdate in fieldsToUpdate) {
                        Net.Vpc.Upa.Formula formula = persistContext ? aFieldsToUpdate.GetPersistFormula() : aFieldsToUpdate.GetUpdateFormula();
                        Net.Vpc.Upa.Expressions.Expression ee = null;
                        if (formula is Net.Vpc.Upa.ExpressionFormula) {
                            ee = ((Net.Vpc.Upa.ExpressionFormula) formula).GetExpression();
                        }
                        fieldNamesToUpdateMap.SetObject(aFieldsToUpdate.GetName(), ee);
                    }
                    // System.out.println(">>");
                    recordListenerSupport.FireBeforeFormulasUpdate(fieldNamesToUpdateMap, expr, context);
                    if (!persistContext) {
                        recordListenerSupport.FireBeforeUpdate(fieldNamesToUpdateMap, expr, context);
                    }
                    Net.Vpc.Upa.Impl.Persistence.FormulaUpdateProcessor p = new Net.Vpc.Upa.Impl.Persistence.FormulaUpdateProcessor(persistContext, fieldsToUpdate, expr, context, this, GetEntityOperationManager());
                    count = p.UpdateFormulasCore();
                    if (!persistContext) {
                        recordListenerSupport.FireAfterUpdate(fieldNamesToUpdateMap, expr, context);
                    }
                    recordListenerSupport.FireAfterFormulasUpdate(fieldNamesToUpdateMap, expr, context);
                }
                return count;
            }
            // System.out.println("}");
            return 0;
        }

        public virtual Net.Vpc.Upa.Expressions.Order GetUpdateFormulasOrder() {
            return null;
        }

        public virtual Net.Vpc.Upa.Expressions.Order GetArchivingOrder() {
            //TODO fix me
            return null;
        }

        public virtual void SetArchivingOrder(Net.Vpc.Upa.Expressions.Order order) {
        }

        public virtual Net.Vpc.Upa.Field GetLeadingPrimaryField() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetPrimaryFields()[0];
        }

        public virtual System.Collections.Generic.IList<string> GetOrderedFields(string[] fields) {
            System.Collections.Generic.IComparer<string> c = new Net.Vpc.Upa.Impl.EntityChildComparator(this);
            System.Collections.Generic.List<string> ts = new System.Collections.Generic.List<string>();
            Net.Vpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(ts, new System.Collections.Generic.List<string>(fields));
            Net.Vpc.Upa.Impl.FwkConvertUtils.ListSort(ts, c);
            return ts;
        }

        public virtual Net.Vpc.Upa.Package GetParent() {
            return parent;
        }

        public virtual void SetParent(Net.Vpc.Upa.Package parent) {
            this.parent = parent;
        }

        public virtual Net.Vpc.Upa.Expressions.Expression ToIdListExpression(Net.Vpc.Upa.Expressions.Expression e) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (tuningMaxInline <= 0 || e == null || (e is Net.Vpc.Upa.Expressions.IdExpression) || (e is Net.Vpc.Upa.Expressions.IdCollectionExpression) || (e is Net.Vpc.Upa.Expressions.IdEnumerationExpression)) {
                return e;
            } else {
                System.Collections.Generic.IList<object> keys = CreateQueryBuilder().ByExpression(e).GetIdList<K>();
                if ((keys).Count > tuningMaxInline) {
                    return e;
                }
                return GetBuilder().IdListToExpression<object>(keys, null);
            }
        }

        public virtual string GetShortName() {
            return shortName;
        }

        public virtual void SetShortName(string shortName) {
            this.shortName = shortName;
        }

        public virtual string GetShortNameOrName() {
            return shortName == null ? GetName() : shortName;
        }

        public virtual Net.Vpc.Upa.Expressions.Order GetListOrder() {
            return listOrder;
        }

        public virtual void SetListOrder(Net.Vpc.Upa.Expressions.Order listDefaultOrder) {
            this.listOrder = listDefaultOrder;
        }

        public virtual System.Type GetEntityType() {
            return entityType;
        }

        public virtual void SetEntityType(System.Type entityType) {
            this.entityType = entityType;
            if (typeof(Net.Vpc.Upa.Record).IsAssignableFrom(entityType)) {
                entityBuilder.SetEntityFactory(new Net.Vpc.Upa.Impl.EntitySubclassUnstructuredFactory(entityType, GetPersistenceUnit().GetFactory(), this));
            } else {
                entityBuilder.SetEntityFactory(new Net.Vpc.Upa.Impl.EntityBeanFactory(this, GetPersistenceUnit().GetFactory()));
            }
        }

        public virtual Net.Vpc.Upa.Impl.Config.Decorations.DecorationRepository GetDecorationRepository() {
            Net.Vpc.Upa.Impl.DefaultPersistenceUnit persistenceUnit = (Net.Vpc.Upa.Impl.DefaultPersistenceUnit) GetPersistenceUnit();
            return persistenceUnit.GetDecorationRepository();
        }

        public virtual System.Type GetIdType() {
            return idType;
        }

        public virtual void SetIdType(System.Type idType) {
            this.idType = idType;
            if (typeof(Net.Vpc.Upa.Key).Equals(idType)) {
                entityBuilder.SetKeyFactory((Net.Vpc.Upa.Impl.KeyFactory) new Net.Vpc.Upa.Impl.KeyUnstructuredFactory(this));
            } else if (typeof(Net.Vpc.Upa.Key).IsAssignableFrom(idType)) {
                entityBuilder.SetKeyFactory(new Net.Vpc.Upa.Impl.KeySubclassUnstructuredFactory(Net.Vpc.Upa.Impl.Util.PlatformBeanTypeRepository.GetInstance().GetBeanType(idType)));
            } else if ((Net.Vpc.Upa.Impl.KeyTypeFactory.ACCEPTED_TYPES.Contains(idType))) {
                entityBuilder.SetKeyFactory(new Net.Vpc.Upa.Impl.KeyTypeFactory(idType));
            } else {
                entityBuilder.SetKeyFactory(new Net.Vpc.Upa.Impl.KeyBeanFactory(idType, this));
            }
        }


        public virtual Net.Vpc.Upa.EntityBuilder GetBuilder() {
            return entityBuilder;
        }


        public virtual void AddExtensionDefinition(System.Type extensionType, Net.Vpc.Upa.Extensions.EntityExtensionDefinition extensionObject) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Type entityExtensionSupportType = GetPersistenceUnit().GetEntityExtensionSupportType(extensionType);
            Net.Vpc.Upa.Persistence.EntityExtension ess = (Net.Vpc.Upa.Persistence.EntityExtension) GetPersistenceUnit().GetFactory().CreateObject<Net.Vpc.Upa.Persistence.EntityExtension>(entityExtensionSupportType);
            ess.Install(this, entityOperationManager, extensionObject);
            extensionManager.AddEntityExtension(extensionType, entityExtensionSupportType, extensionObject, ess);
        }


        public virtual void RemoveExtensionDefinition(System.Type extensionType, Net.Vpc.Upa.Extensions.EntityExtensionDefinition extensionObject) {
            extensionManager.RemoveEntityExtension(extensionType, extensionObject);
        }


        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Extensions.EntityExtensionDefinition> GetExtensionDefinitions() {
            return extensionManager.GetEntityExtensions();
        }


        public virtual  System.Collections.Generic.IList<S> GetExtensionDefinitions<S>(System.Type type) where  S : Net.Vpc.Upa.Extensions.EntityExtensionDefinition {
            return extensionManager.GetEntityExtensions<S>(type);
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.EntityExtension> GetExtensions() {
            return extensionManager.GetEntityExtensionSupports();
        }

        public virtual  System.Collections.Generic.IList<S> GetExtensions<S>(System.Type type) where  S : Net.Vpc.Upa.Persistence.EntityExtension {
            return extensionManager.GetEntityExtensionSupports<S>(type);
        }

        public virtual  S GetExtension<S>(System.Type type) /* throws Net.Vpc.Upa.Exceptions.UPAException */  where  S : Net.Vpc.Upa.Persistence.EntityExtension {
            System.Collections.Generic.IList<S> list = GetExtensions<S>(type);
            if ((list.Count==0)) {
                throw new Net.Vpc.Upa.Exceptions.UPAException("No such EntityExtensionSupport found " + type);
            }
            if ((list).Count != 1) {
                throw new Net.Vpc.Upa.Exceptions.UPAException("Too Many EntitySpecSupports found " + type);
            }
            return list[0];
        }

        public virtual Net.Vpc.Upa.Persistence.EntityOperationManager GetEntityOperationManager() {
            return entityOperationManager;
        }

        public virtual Net.Vpc.Upa.EntityShield GetShield() {
            return shield;
        }

        public virtual void SetShield(Net.Vpc.Upa.EntityShield shield) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            this.shield = shield;
            shield.Init(this);
        }


        public virtual Net.Vpc.Upa.Key CreateKey(params object [] keyValues) {
            return GetBuilder().CreateKey(keyValues);
        }


        public virtual object CreateId(params object [] keyValues) {
            return GetBuilder().CreateId(keyValues);
        }


        public virtual Net.Vpc.Upa.Record CreateRecord() {
            return GetBuilder().CreateRecord();
        }


        public virtual  R CreateObject<R>() {
            return GetBuilder().CreateObject<R>();
        }


        public virtual void AddDefinitionListener(Net.Vpc.Upa.Callbacks.DefinitionListener interceptor) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            GetPersistenceUnit().AddDefinitionListener(GetName(), interceptor);
        }


        public virtual void RemoveDefinitionListener(Net.Vpc.Upa.Callbacks.DefinitionListener interceptor) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            GetPersistenceUnit().RemoveDefinitionListener(GetName(), interceptor);
        }


        public virtual Net.Vpc.Upa.EntityDescriptor GetEntityDescriptor() {
            return entityDescriptor;
        }

        public virtual void SetEntityDescriptor(Net.Vpc.Upa.EntityDescriptor entityDescriptor) {
            this.entityDescriptor = entityDescriptor;
        }

        public virtual int ClearCore(Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Persistence.EntityOperationManager pm = GetEntityOperationManager();
            Net.Vpc.Upa.Persistence.EntityClearOperation a = pm.GetClearOperation();
            if (a != null) {
                return a.Clear(this, executionContext);
            }
            return 0;
        }


        public virtual int InitializeCore(Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Persistence.EntityOperationManager pm = GetEntityOperationManager();
            Net.Vpc.Upa.Persistence.EntityInitializeOperation a = pm.GetInitializeOperation();
            if (a != null) {
                return a.Initialize(this, executionContext);
            }
            return 0;
        }


        public override void Close() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            foreach (Net.Vpc.Upa.EntityPart item in items) {
                item.Close();
            }
            this.closed = true;
        }

        public virtual bool IsClosed() {
            return closed;
        }

        private Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> Copy(Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> e, params Net.Vpc.Upa.UserFieldModifier [] others) {
            if (e == null) {
                e = Net.Vpc.Upa.FlagSets.NoneOf<Net.Vpc.Upa.UserFieldModifier>();
            }
            e = e.AddAll(new System.Collections.Generic.List<Net.Vpc.Upa.UserFieldModifier>(others));
            return e;
        }

        public virtual object Compile(Net.Vpc.Upa.Expressions.Expression expression) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Persistence.ExpressionCompilerConfig config = new Net.Vpc.Upa.Persistence.ExpressionCompilerConfig();
            config.SetThisAlias("upathis");
            config.SetExpandEntityFilter(false);
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect compiledSelect = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect) GetPersistenceUnit().GetExpressionManager().CompileExpression(new Net.Vpc.Upa.Expressions.Select().From(GetName(), "upathis").Field(expression), config);
            return compiledSelect.GetField(0).GetExpression();
        }

        private System.Collections.Generic.ISet<Net.Vpc.Upa.Field> FindUsedFields(Net.Vpc.Upa.Formula f) {
            System.Collections.Generic.ISet<Net.Vpc.Upa.Field> usedFields = new System.Collections.Generic.HashSet<Net.Vpc.Upa.Field>();
            if (f is Net.Vpc.Upa.ExpressionFormula) {
                Net.Vpc.Upa.ExpressionFormula expressionFormula = (Net.Vpc.Upa.ExpressionFormula) f;
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression compiledExpression = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) Compile(expressionFormula.GetExpression());
                compiledExpression.Visit(new Net.Vpc.Upa.Impl.FieldCollectorCompiledExpressionVisitor(usedFields));
            }
            return usedFields;
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Relationship> GetRelationships() {
            System.Collections.Generic.HashSet<Net.Vpc.Upa.Relationship> relations = new System.Collections.Generic.HashSet<Net.Vpc.Upa.Relationship>();
            foreach (Net.Vpc.Upa.Relationship r in GetPersistenceUnit().GetRelationshipsBySource(this)) {
                relations.Add(r);
            }
            foreach (Net.Vpc.Upa.Relationship r in GetPersistenceUnit().GetRelationshipsByTarget(this)) {
                relations.Add(r);
            }
            return new System.Collections.Generic.List<Net.Vpc.Upa.Relationship>(relations);
        }


        public virtual void AddFilter(string name, Net.Vpc.Upa.Expressions.Expression expression) {
            if (name == null || expression == null) {
                throw new System.NullReferenceException("Object Filter Null");
            }
            if (objectfilters.ContainsKey(name)) {
                throw new System.ArgumentException ("Object Filter Already Exists " + name);
            }
            objectfilters[name]=expression;
        }


        public virtual void RemoveFilter(string name) {
            if (name == null) {
                throw new System.NullReferenceException("Object Filter Null");
            }
            objectfilters.Remove(name);
        }


        public virtual System.Collections.Generic.ISet<string> GetFilterNames() {
            return new System.Collections.Generic.HashSet<string>(new System.Collections.Generic.HashSet<string>(objectfilters.Keys));
        }


        public virtual Net.Vpc.Upa.Expressions.Expression GetFilter(string name) {
            Net.Vpc.Upa.Expressions.Expression expression = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.Vpc.Upa.Expressions.Expression>(objectfilters,name);
            if (expression == null) {
                throw new System.ArgumentException ("Object Filter Not Found " + name);
            }
            return expression;
        }


        public virtual void AddFilter(string name, string expression) {
            AddFilter(name, expression == null ? null : GetPersistenceUnit().GetExpressionManager().ParseExpression(expression));
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Section> GetSections() {
            System.Collections.Generic.IList<Net.Vpc.Upa.Section> sections = new System.Collections.Generic.List<Net.Vpc.Upa.Section>();
            foreach (Net.Vpc.Upa.EntityPart part in GetParts()) {
                if (part is Net.Vpc.Upa.Section) {
                    sections.Add((Net.Vpc.Upa.Section) part);
                }
            }
            return sections;
        }

        public virtual bool IsSystem() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetModifiers().Contains(Net.Vpc.Upa.EntityModifier.SYSTEM);
        }

        public virtual  T FindById<T>(object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceUnit().FindById<T>(GetName(), id);
        }


        public virtual bool ExistsById(object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceUnit().ExistsById(GetName(), id);
        }

        public virtual  System.Collections.Generic.IList<T> FindAll<T>() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceUnit().FindAll<T>(GetName());
        }


        public virtual  System.Collections.Generic.IList<T> FindAllIds<T>() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceUnit().FindAllIds<T>(GetName());
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Record> FindAllRecords(object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceUnit().FindAllRecords(GetName());
        }

        public virtual  T FindByMainField<T>(object mainFieldValue) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceUnit().FindByMainField<T>(GetName(), mainFieldValue);
        }

        public virtual  T FindByField<T>(string fieldName, object mainFieldValue) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceUnit().FindByField<T>(GetName(), fieldName, mainFieldValue);
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Record> FindAllRecords() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceUnit().FindAllRecords(GetName());
        }

        public virtual Net.Vpc.Upa.EntitySecurityManager GetEntitySecurityManager() {
            return entitySecurityManager;
        }

        public virtual void SetEntitySecurityManager(Net.Vpc.Upa.EntitySecurityManager entitySecurityManager) {
            this.entitySecurityManager = entitySecurityManager;
        }


        public virtual Net.Vpc.Upa.BeanType GetBeanType() {
            if (beanType == null) {
                if (typeof(Net.Vpc.Upa.Record).Equals(GetEntityType())) {
                    beanType = new Net.Vpc.Upa.Impl.Util.RecordBeanType(this);
                } else if (typeof(Net.Vpc.Upa.Record).IsAssignableFrom(GetEntityType())) {
                    beanType = new Net.Vpc.Upa.Impl.Util.CustomRecordBeanType(this, GetEntityType());
                } else {
                    beanType = new Net.Vpc.Upa.Impl.Util.EntityBeanType(this);
                }
            }
            return beanType;
        }
    }
}
