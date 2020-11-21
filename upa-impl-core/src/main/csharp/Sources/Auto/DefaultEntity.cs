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
namespace Net.TheVpc.Upa.Impl
{


    public class DefaultEntity : Net.TheVpc.Upa.Impl.AbstractUPAObject, Net.TheVpc.Upa.Entity {

        public const string PERSIST_USED_FIELDS = "PERSIST_USED_FIELDS";

        public const string PERSIST_DEPENDENT_FIELDS = "PERSIST_DEPENDENT_FIELDS";

        public const string UPDATE_DEPENDENT_FIELDS = "UPDATE_DEPENDENT_FIELDS";

        private static readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.TheVpc.Upa.Impl.DefaultEntity)).FullName);

        private static readonly Net.TheVpc.Upa.Filters.FieldFilter FIELD_FILTER_PERSIST_NON_NULLABLE = new Net.TheVpc.Upa.Impl.Util.Filters.PersistNonNullableFieldFilter();

        private static readonly Net.TheVpc.Upa.Filters.FieldFilter FIELD_FILTER_PERSIST_WITH_DEFAULT_VALUE = new Net.TheVpc.Upa.Impl.Util.Filters.PersistWithDefaultValueFieldFilter();

        public static bool VALIDATE_IF_CHANGED = false;

        public static int MAX_CACHE_SIZE = 20;

        internal Net.TheVpc.Upa.Impl.DefaultEntityPrivateListener objListener;

        private string shortName;

        private Net.TheVpc.Upa.Impl.Util.RecordListenerSupport recordListenerSupport;

        private System.Type idType;

        private System.Type entityType;

        private Net.TheVpc.Upa.Impl.DefaultEntityBuilder entityBuilder;

        private System.Collections.Generic.IList<Net.TheVpc.Upa.EntityPart> items = new System.Collections.Generic.List<Net.TheVpc.Upa.EntityPart>();

        private System.Collections.Generic.IDictionary<string , Net.TheVpc.Upa.EntityPart> itemsByName = new System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.EntityPart>();

        private System.Collections.Generic.IDictionary<string , Net.TheVpc.Upa.Callbacks.Trigger> triggers = new System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Callbacks.Trigger>();

        internal System.Collections.Generic.IDictionary<string , Net.TheVpc.Upa.Field> fieldsMap = new System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Field>();

        private Net.TheVpc.Upa.Field mainRendererField;

        private bool closed;

        private Net.TheVpc.Upa.Impl.Util.CacheMap<Net.TheVpc.Upa.Filters.FieldFilter , System.Collections.Generic.IList<Net.TheVpc.Upa.Field>> fieldsByFilter = new Net.TheVpc.Upa.Impl.Util.CacheMap<Net.TheVpc.Upa.Filters.FieldFilter , System.Collections.Generic.IList<Net.TheVpc.Upa.Field>>(MAX_CACHE_SIZE);

        private System.Collections.Generic.ISet<string> dependsOnTables = new System.Collections.Generic.SortedSet<string>();

        private string parentSecurityAction;

        private Net.TheVpc.Upa.Relationship compositionRelation;

        private Net.TheVpc.Upa.Package parent;

        private Net.TheVpc.Upa.EntityDescriptor entityDescriptor;

        private Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.EntityModifier> userIncludeModifiers;

        private Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.EntityModifier> userExcludeModifiers;

        private Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.EntityModifier> effectiveModifiers;

        /**
             * name in the rdbms
             */
        private Net.TheVpc.Upa.Expressions.Order listOrder;

        private Net.TheVpc.Upa.EntityNavigator navigator;

        private System.Collections.Generic.List<Net.TheVpc.Upa.Index> indexes;

        private Net.TheVpc.Upa.Types.DataType dataType;

        private int tuningMaxInline = -1;

        private Net.TheVpc.Upa.Impl.DefaultEntityExtensionManager extensionManager;

        private Net.TheVpc.Upa.Persistence.EntityOperationManager entityOperationManager;

        private int triggerAnonymousNameIndex = 1;

        private Net.TheVpc.Upa.EntityShield shield;

        private Net.TheVpc.Upa.Impl.Persistence.FieldListPersistenceInfo fieldListPersistenceInfo = new Net.TheVpc.Upa.Impl.Persistence.FieldListPersistenceInfo();

        private System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Expressions.Expression> objectfilters = new System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Expressions.Expression>();

        private Net.TheVpc.Upa.EntitySecurityManager entitySecurityManager;

        private Net.TheVpc.Upa.BeanType beanType;

        private Net.TheVpc.Upa.Impl.DefaultEntityCache cache = new Net.TheVpc.Upa.Impl.DefaultEntityCache();

        private System.Collections.Generic.IDictionary<string , object> defaultHints;

        public DefaultEntity()  : base(){

            objListener = new Net.TheVpc.Upa.Impl.DefaultEntityPrivateListener(this);
            userIncludeModifiers = Net.TheVpc.Upa.FlagSets.NoneOf<Net.TheVpc.Upa.EntityModifier>();
            userExcludeModifiers = Net.TheVpc.Upa.FlagSets.NoneOf<Net.TheVpc.Upa.EntityModifier>();
            effectiveModifiers = Net.TheVpc.Upa.FlagSets.NoneOf<Net.TheVpc.Upa.EntityModifier>();
            entityBuilder = new Net.TheVpc.Upa.Impl.DefaultEntityBuilder(this);
            indexes = new System.Collections.Generic.List<Net.TheVpc.Upa.Index>();
        }

        private static Net.TheVpc.Upa.Expressions.Expression GetFieldExpression(Net.TheVpc.Upa.Field field, bool forPersist) {
            if (forPersist) {
                return (field.GetPersistFormula() is Net.TheVpc.Upa.ExpressionFormula) ? ((Net.TheVpc.Upa.ExpressionFormula) field.GetPersistFormula()).GetExpression() : null;
            } else {
                return (field.GetUpdateFormula() is Net.TheVpc.Upa.ExpressionFormula) ? ((Net.TheVpc.Upa.ExpressionFormula) field.GetUpdateFormula()).GetExpression() : null;
            }
        }

        public static string[] GetTableNames(Net.TheVpc.Upa.Impl.DefaultEntity[] tables) {
            string[] names = new string[tables.Length];
            for (int i = 0; i < tables.Length; i++) {
                names[i] = tables[i].GetName();
            }
            return names;
        }

        public virtual Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.EntityModifier> GetUserModifiers() {
            return userIncludeModifiers;
        }

        public virtual void SetUserModifiers(Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.EntityModifier> modifiers) {
            this.userIncludeModifiers = modifiers;
        }

        public virtual Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.EntityModifier> GetUserExcludeModifiers() {
            return userExcludeModifiers;
        }

        public virtual void SetUserExcludeModifiers(Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.EntityModifier> modifiers) {
            this.userExcludeModifiers = modifiers;
        }

        public virtual Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.EntityModifier> GetModifiers() {
            return effectiveModifiers;
        }


        public virtual void SetModifiers(Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.EntityModifier> effectiveModifiers) {
            this.effectiveModifiers = effectiveModifiers;
        }


        public override string GetAbsoluteName() {
            return GetName();
        }


        public override void SetPersistenceUnit(Net.TheVpc.Upa.PersistenceUnit persistenceUnit) {
            base.SetPersistenceUnit(persistenceUnit);
            Net.TheVpc.Upa.ObjectFactory factory = GetPersistenceUnit().GetFactory();
            SetShield(factory.CreateObject<Net.TheVpc.Upa.EntityShield>(typeof(Net.TheVpc.Upa.EntityShield), null));
            extensionManager = factory.CreateObject<Net.TheVpc.Upa.Impl.DefaultEntityExtensionManager>(typeof(Net.TheVpc.Upa.Impl.DefaultEntityExtensionManager));
            tuningMaxInline = GetPersistenceUnit().GetProperties().GetInt((typeof(Net.TheVpc.Upa.Relationship)).FullName + ".maxInline", 10);
            entityOperationManager = factory.CreateObject<Net.TheVpc.Upa.Persistence.EntityOperationManager>(typeof(Net.TheVpc.Upa.Persistence.EntityOperationManager));
            recordListenerSupport = new Net.TheVpc.Upa.Impl.Util.RecordListenerSupport(this, ((Net.TheVpc.Upa.Impl.DefaultPersistenceUnit) persistenceUnit).GetPersistenceUnitListenerManager());
            AddTrigger(null, cache.cache_isEmpty_Listener);
        }

        public virtual void CommitStructureModification(Net.TheVpc.Upa.Persistence.PersistenceStore persistenceStore) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.ObjectFactory factory = GetPersistenceUnit().GetFactory();
            ((Net.TheVpc.Upa.Impl.Persistence.DefaultEntityOperationManager) entityOperationManager).Init(this, persistenceStore);
            fieldListPersistenceInfo.entity = this;
            fieldListPersistenceInfo.persistenceStore = persistenceStore;
            foreach (Net.TheVpc.Upa.Field field in GetFields()) {
                ValidateField(field);
            }
            fieldListPersistenceInfo.Update();
            beanType = null;
        }

        public virtual bool Exists() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            try {
                GetEntityCount();
                return true;
            } catch (Net.TheVpc.Upa.Exceptions.UPAException e) {
                return false;
            }
        }

        public virtual Net.TheVpc.Upa.Entity GetParentEntity() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return compositionRelation == null ? null : compositionRelation.GetTargetRole().GetEntity();
        }

        public virtual Net.TheVpc.Upa.Relationship GetCompositionRelation() {
            return this.compositionRelation;
        }

        /**
             * called by PersistenceUnitFilter
             */
        public virtual void SetCompositionRelationship(Net.TheVpc.Upa.Relationship compositionRelation) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (compositionRelation == null) {
                this.compositionRelation = null;
            } else {
                if (compositionRelation.GetRelationshipType() != Net.TheVpc.Upa.RelationshipType.COMPOSITION) {
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

        public virtual Net.TheVpc.Upa.Index AddIndex(string indexName, bool unique, params string [] fields) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (fields == null || fields.Length == 0) {
                throw new System.ArgumentException ("Index Fields Count == 0");
            }
            System.Collections.Generic.IList<string> fieldList = new System.Collections.Generic.List<string>(new System.Collections.Generic.HashSet<string>(new System.Collections.Generic.List<string>(fields)));
            Net.TheVpc.Upa.Index index = GetPersistenceUnit().GetFactory().CreateObject<Net.TheVpc.Upa.Index>(typeof(Net.TheVpc.Upa.Index));
            if (Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(indexName)) {
                System.Text.StringBuilder b = new System.Text.StringBuilder("IX").Append(GetName());
                foreach (string f in fieldList) {
                    b.Append("_").Append(f);
                }
                indexName = b.ToString();
            }
            index.SetName(indexName);
            Net.TheVpc.Upa.Impl.Util.DefaultBeanAdapter adapter = Net.TheVpc.Upa.Impl.Util.UPAUtils.Prepare(GetPersistenceUnit(), index, indexName);
            adapter.Inject("unique", unique);
            adapter.Inject("entity", this);
            adapter.Inject("fieldNames", fieldList.ToArray());
            //List<T> items, T child, int index, UPAObject newParent, UPAObject propertyChangeSupport, ItemInterceptor<T> interceptor
            Net.TheVpc.Upa.Impl.Util.ListUtils.Add<T>(indexes, index, -1, this, this, null);
            InvalidateStructureCache();
            return index;
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Index> GetIndexes(bool? unique) {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Index> allIndexes = GetPersistenceUnit().GetIndexes(GetName());
            if (unique == null) {
                return allIndexes;
            } else {
                bool x = (unique).Value;
                System.Collections.Generic.IList<Net.TheVpc.Upa.Index> uniqueIndexes = new System.Collections.Generic.List<Net.TheVpc.Upa.Index>();
                foreach (Net.TheVpc.Upa.Index index in allIndexes) {
                    if (index.IsUnique() == x) {
                        uniqueIndexes.Add(index);
                    }
                }
                return uniqueIndexes;
            }
        }

        public virtual  System.Collections.Generic.IList<Net.TheVpc.Upa.PrimitiveField> ToPrimitiveFields<T>(System.Collections.Generic.IList<T> parts) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  where  T : Net.TheVpc.Upa.EntityPart {
            System.Collections.Generic.List<Net.TheVpc.Upa.PrimitiveField> v = new System.Collections.Generic.List<Net.TheVpc.Upa.PrimitiveField>((parts).Count);
            FillPrimitiveFields<T>(parts, v);
            return v;
        }


        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Field> GetFields(System.Collections.Generic.IList<Net.TheVpc.Upa.EntityPart> parts) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.List<Net.TheVpc.Upa.Field> v = new System.Collections.Generic.List<Net.TheVpc.Upa.Field>((parts).Count);
            FillFields(parts, v);
            return v;
        }

        private void FillFields(System.Collections.Generic.IList<Net.TheVpc.Upa.EntityPart> parts, System.Collections.Generic.IList<Net.TheVpc.Upa.Field> c) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            foreach (Net.TheVpc.Upa.EntityPart part in parts) {
                if (part is Net.TheVpc.Upa.Field) {
                    c.Add((Net.TheVpc.Upa.Field) part);
                } else if (part is Net.TheVpc.Upa.Section) {
                    FillFields(((Net.TheVpc.Upa.Section) part).GetParts(), c);
                }
            }
        }

        private  void FillPrimitiveFields<T>(System.Collections.Generic.IList<T> parts, System.Collections.Generic.IList<Net.TheVpc.Upa.PrimitiveField> c) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  where  T : Net.TheVpc.Upa.EntityPart {
            foreach (Net.TheVpc.Upa.EntityPart part in parts) {
                if (part is Net.TheVpc.Upa.PrimitiveField) {
                    c.Add((Net.TheVpc.Upa.PrimitiveField) part);
                } else if (part is Net.TheVpc.Upa.CompoundField) {
                    System.Collections.Generic.IList<Net.TheVpc.Upa.PrimitiveField> primitiveFields = ((Net.TheVpc.Upa.CompoundField) part).GetFields();
                    foreach (Net.TheVpc.Upa.PrimitiveField f in primitiveFields) {
                        c.Add(f);
                    }
                } else if (part is Net.TheVpc.Upa.Section) {
                    FillPrimitiveFields<Net.TheVpc.Upa.EntityPart>(((Net.TheVpc.Upa.Section) part).GetParts(), c);
                }
            }
        }

        private void AddPart(Net.TheVpc.Upa.EntityPart item, int index) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Impl.Util.ListUtils.Add<Net.TheVpc.Upa.EntityPart>(items, item, index, this, this, new Net.TheVpc.Upa.Impl.DefaultEntityPrivateAddItemInterceptor(this));
            itemsByName[item.GetName()]=item;
            InvalidateStructureCache();
        }

        public virtual void RemovePart(int index) {
            Net.TheVpc.Upa.EntityPart item = Net.TheVpc.Upa.Impl.Util.ListUtils.Remove<Net.TheVpc.Upa.EntityPart>(items, index, this, new Net.TheVpc.Upa.Impl.DefaultEntityPrivateRemoveItemInterceptor());
            itemsByName.Remove(item.GetName());
        }

        public virtual void MovePart(int index, int newIndex) {
            Net.TheVpc.Upa.Impl.Util.ListUtils.MoveTo<T>(items, index, newIndex, this, null);
            InvalidateStructureCache();
        }

        public virtual void MovePart(string partName, int newIndex) {
            MovePart(IndexOfPart(partName), newIndex);
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.EntityPart> GetParts() {
            return items;
        }


        public virtual int IndexOfField(string field) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<string> strings = new System.Collections.Generic.List<string>(new System.Collections.Generic.HashSet<string>(fieldsMap.Keys));
            return strings.IndexOf(field);
        }

        public virtual int IndexOfPart(Net.TheVpc.Upa.EntityPart child) {
            return items.IndexOf(child);
        }

        public virtual int IndexOfPart(string childName) {
            int index = 0;
            foreach (Net.TheVpc.Upa.EntityPart part in items) {
                if (childName.Equals(part.GetName())) {
                    return index;
                }
                index++;
            }
            return -1;
        }

        public virtual int IndexOfPart(string childName, bool countSections, bool countCompoundFields, bool countFieldsInCompoundFields, bool countFieldsInSections) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            int index = 0;
            System.Collections.Generic.Stack<Net.TheVpc.Upa.EntityPart> stack = new System.Collections.Generic.Stack<Net.TheVpc.Upa.EntityPart>();
            int partSize = (items).Count;
            for (int i = partSize - 1; i >= 0; i--) {
                stack.Push(items[i]);
            }
            while (!(stack.Count==0)) {
                Net.TheVpc.Upa.EntityPart entityPart = stack.Pop();
                if (childName.Equals(entityPart.GetName())) {
                    return index;
                } else if (entityPart is Net.TheVpc.Upa.Section) {
                    System.Collections.Generic.IList<Net.TheVpc.Upa.EntityPart> p = ((Net.TheVpc.Upa.Section) entityPart).GetParts();
                    for (int i = 0; i < (p).Count; i++) {
                        stack.Push(p[(p).Count - 1 - i]);
                    }
                    if (countSections) {
                        index++;
                    }
                } else if (entityPart is Net.TheVpc.Upa.CompoundField) {
                    System.Collections.Generic.IList<Net.TheVpc.Upa.PrimitiveField> p = ((Net.TheVpc.Upa.CompoundField) entityPart).GetFields();
                    for (int i = 0; i < (p).Count; i++) {
                        stack.Push(p[(p).Count - 1 - i]);
                    }
                    if (countCompoundFields) {
                        index++;
                    }
                } else {
                    if (!countFieldsInCompoundFields && entityPart.GetParent() is Net.TheVpc.Upa.CompoundField) {
                    } else if (!countFieldsInSections && entityPart.GetParent() is Net.TheVpc.Upa.Section) {
                    } else {
                        index++;
                    }
                }
            }
            return -1;
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Callbacks.Trigger> GetTriggers() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return new System.Collections.Generic.List<Net.TheVpc.Upa.Callbacks.Trigger>((triggers).Values);
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Callbacks.Trigger> GetSoftTriggers() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return new System.Collections.Generic.List<Net.TheVpc.Upa.Callbacks.Trigger>((triggers).Values);
        }


        public virtual Net.TheVpc.Upa.Section AddSection(string name, string parentPath, int index) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (name == null) {
                throw new System.NullReferenceException();
            }
            if (name.Contains("/")) {
                throw new System.ArgumentException ("Name cannot contain '/'");
            }
            string[] canonicalPathArray = Net.TheVpc.Upa.Impl.Util.UPAUtils.GetCanonicalPathArray(parentPath);
            Net.TheVpc.Upa.Section parentModule = null;
            foreach (string n in canonicalPathArray) {
                Net.TheVpc.Upa.Section next = null;
                if (parentModule == null) {
                    next = GetSection(n);
                } else {
                    next = parentModule.GetSection(n);
                }
                parentModule = next;
            }
            Net.TheVpc.Upa.Section currentModule = GetPersistenceUnit().GetFactory().CreateObject<Net.TheVpc.Upa.Section>(typeof(Net.TheVpc.Upa.Section));
            Net.TheVpc.Upa.Impl.Util.DefaultBeanAdapter a = Net.TheVpc.Upa.Impl.Util.UPAUtils.Prepare(GetPersistenceUnit(), currentModule, name);
            if (parentModule == null) {
                AddPart(currentModule, index);
            } else {
                parentModule.AddPart(currentModule, index);
            }
            InvalidateStructureCache();
            return currentModule;
        }

        public virtual Net.TheVpc.Upa.Section GetSection(string path) {
            return GetSection(path, Net.TheVpc.Upa.MissingStrategy.ERROR);
        }

        public virtual Net.TheVpc.Upa.Section FindSection(string path) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetSection(path, Net.TheVpc.Upa.MissingStrategy.NULL);
        }

        public virtual Net.TheVpc.Upa.Section GetSection(string path, Net.TheVpc.Upa.MissingStrategy missingStrategy) {
            if (path == null) {
                throw new System.NullReferenceException();
            }
            string[] canonicalPathArray = Net.TheVpc.Upa.Impl.Util.UPAUtils.GetCanonicalPathArray(path);
            if (canonicalPathArray.Length == 0) {
                throw new System.ArgumentException ("invalid module path " + path);
            }
            Net.TheVpc.Upa.Section module = null;
            foreach (string n in canonicalPathArray) {
                Net.TheVpc.Upa.Section next = null;
                if (module == null) {
                    foreach (Net.TheVpc.Upa.EntityPart schemaItem in items) {
                        if (schemaItem is Net.TheVpc.Upa.Section) {
                            if (schemaItem.GetName().Equals(n)) {
                                next = (Net.TheVpc.Upa.Section) schemaItem;
                                break;
                            }
                        }
                    }
                    if (next == null) {
                        switch(missingStrategy) {
                            case Net.TheVpc.Upa.MissingStrategy.ERROR:
                                {
                                    throw new Net.TheVpc.Upa.Exceptions.NoSuchSectionException(path);
                                }
                            case Net.TheVpc.Upa.MissingStrategy.CREATE:
                                {
                                    next = AddSection(n, null);
                                    break;
                                }
                            case Net.TheVpc.Upa.MissingStrategy.NULL:
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
                    } catch (Net.TheVpc.Upa.Exceptions.NoSuchSectionException e) {
                        switch(missingStrategy) {
                            case Net.TheVpc.Upa.MissingStrategy.ERROR:
                                {
                                    throw new Net.TheVpc.Upa.Exceptions.NoSuchSectionException(path);
                                }
                            case Net.TheVpc.Upa.MissingStrategy.CREATE:
                                {
                                    next = AddSection(n, module.GetPath());
                                    break;
                                }
                            case Net.TheVpc.Upa.MissingStrategy.NULL:
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


        public virtual Net.TheVpc.Upa.Section AddSection(string name, string parentPath) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return AddSection(name, parentPath, -1);
        }

        public virtual Net.TheVpc.Upa.Section AddSection(string name) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return AddSection(name, null, -1);
        }

        public virtual Net.TheVpc.Upa.Section AddSection(string name, int index) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return AddSection(name, null, index);
        }

        public virtual void InvalidateStructureCache() {
            cache.needsRevalidateCache = true;
            if (fieldsByFilter != null) {
                fieldsByFilter.Clear();
            }
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        public virtual void RevalidateStructure() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (cache.needsRevalidateCache) {
                cache.needsRevalidateCache = false;
            }
        }

        public virtual bool NeedsView() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return !(GetFields(Net.TheVpc.Upa.Impl.Util.Filters.Fields2.VIEW).Count==0);
        }

        public virtual Net.TheVpc.Upa.Types.DataType GetDataType() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (dataType == null) {
                dataType = new Net.TheVpc.Upa.KeyType(this);
            }
            return dataType;
        }

        public virtual void SetDataType(Net.TheVpc.Upa.Types.DataType newDataType) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (dataType != newDataType) {
                dataType = newDataType;
            }
        }

        protected internal virtual void ValidateField(Net.TheVpc.Upa.Field field) {
            //        final Formula formula = field.getFormula();
            Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.FieldModifier> _effectiveModifiers = field.GetModifiers();
            Net.TheVpc.Upa.Persistence.EntityOperationManager epm = GetEntityOperationManager();
            if (epm != null) {
                Net.TheVpc.Upa.Persistence.PersistenceStore store = epm.GetPersistenceStore();
                if (store != null) {
                    if (!store.IsViewSupported() && (_effectiveModifiers.Contains(Net.TheVpc.Upa.FieldModifier.SELECT_STORED))) {
                        _effectiveModifiers = _effectiveModifiers.Remove(Net.TheVpc.Upa.FieldModifier.SELECT_STORED);
                        _effectiveModifiers = _effectiveModifiers.Add(Net.TheVpc.Upa.FieldModifier.SELECT_DEFAULT);
                        log.TraceEvent(System.Diagnostics.TraceEventType.Warning,90,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("View is not supported, View Field forced to be persisted {0}",null,field));
                    }
                    //effectiveModifiers = effectiveModifiers.add(UserFieldModifier.STORED_FORMULA);
                    if (!store.IsComplexSelectSupported() && (_effectiveModifiers.Contains(Net.TheVpc.Upa.FieldModifier.SELECT_LIVE) || _effectiveModifiers.Contains(Net.TheVpc.Upa.FieldModifier.SELECT_STORED))) {
                        //check if complex formula
                        bool complexFormula = false;
                        Net.TheVpc.Upa.Formula selectFormula = field.GetSelectFormula();
                        if (selectFormula is Net.TheVpc.Upa.ExpressionFormula) {
                            Net.TheVpc.Upa.ExpressionFormula ef = (Net.TheVpc.Upa.ExpressionFormula) selectFormula;
                            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression compiledExpression = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) Compile(ef.GetExpression());
                            complexFormula = compiledExpression.FindFirstExpression<T>(Net.TheVpc.Upa.Impl.Uql.Compiledfilters.CompiledExpressionHelper.SELECT_FILTER) != default(T);
                        } else {
                            complexFormula = true;
                        }
                        if (complexFormula) {
                            _effectiveModifiers = _effectiveModifiers.Remove(Net.TheVpc.Upa.FieldModifier.SELECT_LIVE);
                            _effectiveModifiers = _effectiveModifiers.Remove(Net.TheVpc.Upa.FieldModifier.SELECT_STORED);
                            _effectiveModifiers = _effectiveModifiers.Add(Net.TheVpc.Upa.FieldModifier.PERSIST_FORMULA);
                            _effectiveModifiers = _effectiveModifiers.Add(Net.TheVpc.Upa.FieldModifier.UPDATE_FORMULA);
                            if (field.GetUpdateFormula() == null) {
                                field.SetUpdateFormula(field.GetSelectFormula());
                            }
                            if (field.GetPersistFormula() == null) {
                                field.SetPersistFormula(field.GetSelectFormula());
                            }
                            log.TraceEvent(System.Diagnostics.TraceEventType.Warning,90,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Complex fields in SelectFormula are not supported, Field forced to be persisted {0}",null,field));
                        }
                    }
                }
            }
            //effectiveModifiers = effectiveModifiers.add(UserFieldModifier.STORED_FORMULA);
            ((Net.TheVpc.Upa.Impl.AbstractField) field).SetEffectiveModifiers(_effectiveModifiers);
        }

        private void CommitFieldModelChanges(Net.TheVpc.Upa.Field f) {
            Net.TheVpc.Upa.Impl.FieldModifierHelper fmc = new Net.TheVpc.Upa.Impl.FieldModifierHelper(f.GetUserModifiers(), f.GetUserExcludeModifiers());
            if (!fmc.Contains(Net.TheVpc.Upa.UserFieldModifier.TRANSIENT)) {
                Net.TheVpc.Upa.Formula persistFormula = f.GetPersistFormula();
                Net.TheVpc.Upa.Formula updateFormula = f.GetUpdateFormula();
                Net.TheVpc.Upa.Formula selectFormula = f.GetSelectFormula();
                if (fmc.Contains(Net.TheVpc.Upa.UserFieldModifier.ID)) {
                    fmc.Add(Net.TheVpc.Upa.FieldModifier.ID);
                }
                //system flags
                if (fmc.Contains(Net.TheVpc.Upa.UserFieldModifier.SYSTEM)) {
                    fmc.Add(Net.TheVpc.Upa.FieldModifier.SYSTEM);
                }
                if (fmc.Contains(Net.TheVpc.Upa.UserFieldModifier.MAIN)) {
                    fmc.Add(Net.TheVpc.Upa.FieldModifier.MAIN);
                }
                if (fmc.Contains(Net.TheVpc.Upa.UserFieldModifier.SUMMARY)) {
                    fmc.Add(Net.TheVpc.Upa.FieldModifier.SUMMARY);
                }
                if (!fmc.Rejects(Net.TheVpc.Upa.UserFieldModifier.SELECT)) {
                    fmc.Add(Net.TheVpc.Upa.FieldModifier.SELECT);
                    if (selectFormula == null) {
                        fmc.Add(Net.TheVpc.Upa.FieldModifier.SELECT_DEFAULT);
                    } else if (selectFormula is Net.TheVpc.Upa.ExpressionFormula) {
                        if (fmc.Contains(Net.TheVpc.Upa.UserFieldModifier.LIVE)) {
                            fmc.Add(Net.TheVpc.Upa.FieldModifier.SELECT_LIVE);
                        } else if (fmc.Contains(Net.TheVpc.Upa.UserFieldModifier.COMPILED)) {
                            fmc.Add(Net.TheVpc.Upa.FieldModifier.SELECT_STORED);
                        } else {
                            fmc.Add(Net.TheVpc.Upa.FieldModifier.SELECT_DEFAULT);
                        }
                    } else if (selectFormula is Net.TheVpc.Upa.Sequence) {
                        if (fmc.Contains(Net.TheVpc.Upa.UserFieldModifier.LIVE) || fmc.Contains(Net.TheVpc.Upa.UserFieldModifier.COMPILED)) {
                            throw new System.ArgumentException ("LIVE and COMPILED elector are supported solely for ExpressionFormula");
                        }
                        fmc.Add(Net.TheVpc.Upa.FieldModifier.SELECT_DEFAULT);
                    } else {
                        if (fmc.Contains(Net.TheVpc.Upa.UserFieldModifier.LIVE) || fmc.Contains(Net.TheVpc.Upa.UserFieldModifier.COMPILED)) {
                            throw new System.ArgumentException ("LIVE and COMPILED elector are supported solely for ExpressionFormula");
                        }
                        if (f.GetDataType() is Net.TheVpc.Upa.Types.ManyToOneType) {
                            fmc.Add(Net.TheVpc.Upa.FieldModifier.SELECT_DEFAULT);
                        } else {
                            fmc.Add(Net.TheVpc.Upa.FieldModifier.SELECT_CUSTOM);
                        }
                    }
                }
                if (!fmc.Rejects(Net.TheVpc.Upa.UserFieldModifier.PERSIST) && !fmc.GetEffective().Contains(Net.TheVpc.Upa.FieldModifier.SELECT_LIVE) && !fmc.GetEffective().Contains(Net.TheVpc.Upa.FieldModifier.SELECT_STORED)) {
                    if (persistFormula == null) {
                        fmc.Add(Net.TheVpc.Upa.FieldModifier.PERSIST);
                        fmc.Add(Net.TheVpc.Upa.FieldModifier.PERSIST_DEFAULT);
                    } else {
                        fmc.Add(Net.TheVpc.Upa.FieldModifier.PERSIST);
                        fmc.Add(Net.TheVpc.Upa.FieldModifier.PERSIST_FORMULA);
                        if (persistFormula is Net.TheVpc.Upa.Sequence) {
                            fmc.Add(Net.TheVpc.Upa.FieldModifier.PERSIST_SEQUENCE);
                        }
                    }
                }
                if (!fmc.Rejects(Net.TheVpc.Upa.UserFieldModifier.UPDATE) && !fmc.GetEffective().Contains(Net.TheVpc.Upa.FieldModifier.ID) && !fmc.GetEffective().Contains(Net.TheVpc.Upa.FieldModifier.SELECT_LIVE) && !fmc.GetEffective().Contains(Net.TheVpc.Upa.FieldModifier.SELECT_STORED)) {
                    if (updateFormula == null) {
                        fmc.Add(Net.TheVpc.Upa.FieldModifier.UPDATE);
                        fmc.Add(Net.TheVpc.Upa.FieldModifier.UPDATE_DEFAULT);
                    } else {
                        fmc.Add(Net.TheVpc.Upa.FieldModifier.UPDATE);
                        fmc.Add(Net.TheVpc.Upa.FieldModifier.UPDATE_FORMULA);
                        if (updateFormula is Net.TheVpc.Upa.Sequence) {
                            fmc.Add(Net.TheVpc.Upa.FieldModifier.UPDATE_SEQUENCE);
                        }
                    }
                }
                // check constraints
                if (selectFormula is Net.TheVpc.Upa.Sequence) {
                    throw new System.ArgumentException ("Select Formula could not be a sequence");
                }
                if (((f.GetPersistAccessLevel() == Net.TheVpc.Upa.AccessLevel.PRIVATE) || (f.GetPersistAccessLevel() == Net.TheVpc.Upa.AccessLevel.PRIVATE) || (f.GetPersistAccessLevel() == Net.TheVpc.Upa.AccessLevel.PRIVATE)) && fmc.GetEffective().Contains(Net.TheVpc.Upa.FieldModifier.MAIN)) {
                    throw new System.ArgumentException ("Field " + GetAbsoluteName() + " could not be define Main and PRIVATE");
                }
                //
                if (fmc.Contains(Net.TheVpc.Upa.UserFieldModifier.INDEX)) {
                    bool found = false;
                    foreach (Net.TheVpc.Upa.Index index in GetIndexes(null)) {
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
                if (fmc.Contains(Net.TheVpc.Upa.UserFieldModifier.UNIQUE)) {
                    bool found = false;
                    foreach (Net.TheVpc.Upa.Index index in GetIndexes(true)) {
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
                fmc.Add(Net.TheVpc.Upa.FieldModifier.TRANSIENT);
            }
            ((Net.TheVpc.Upa.Impl.AbstractField) f).SetEffectiveModifiers(fmc.GetEffective());
            if (f.GetModifiers().Contains(Net.TheVpc.Upa.FieldModifier.PERSIST) && !f.GetModifiers().Contains(Net.TheVpc.Upa.FieldModifier.ID)) {
                Net.TheVpc.Upa.Types.DataType dt = f.GetDataType();
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

        private void CommitFieldExpressionModelChanges(Net.TheVpc.Upa.Field f) {
            Net.TheVpc.Upa.Impl.FieldModifierHelper fmc = new Net.TheVpc.Upa.Impl.FieldModifierHelper(f.GetUserModifiers(), f.GetUserExcludeModifiers());
            if (!fmc.Contains(Net.TheVpc.Upa.UserFieldModifier.TRANSIENT)) {
                Net.TheVpc.Upa.Formula persistFormula = f.GetPersistFormula();
                Net.TheVpc.Upa.Formula updateFormula = f.GetUpdateFormula();
                //            Formula selectFormula = f.getSelectFormula();
                if (persistFormula != null) {
                    System.Collections.Generic.ISet<Net.TheVpc.Upa.Field> usedFields = null;
                    try {
                        usedFields = FindUsedFields(persistFormula);
                    } catch (Net.TheVpc.Upa.Impl.Uql.Parser.Syntax.ParseException e) {
                        throw new Net.TheVpc.Upa.Exceptions.UPAException("InvalidFormulaExpression", f.GetAbsoluteName(), "PersistFormula", persistFormula);
                    }
                    foreach (Net.TheVpc.Upa.Field field in usedFields) {
                        System.Collections.Generic.ISet<Net.TheVpc.Upa.Field> c = (System.Collections.Generic.ISet<Net.TheVpc.Upa.Field>) field.GetProperties().GetObject<T>(PERSIST_DEPENDENT_FIELDS);
                        if (c == null) {
                            c = new System.Collections.Generic.HashSet<Net.TheVpc.Upa.Field>();
                            field.GetProperties().SetObject(PERSIST_DEPENDENT_FIELDS, c);
                        }
                        c.Add(f);
                    }
                    f.GetProperties().SetObject(PERSIST_USED_FIELDS, usedFields);
                }
                if (updateFormula != null) {
                    System.Collections.Generic.ISet<Net.TheVpc.Upa.Field> usedFields = null;
                    try {
                        usedFields = FindUsedFields(updateFormula);
                    } catch (Net.TheVpc.Upa.Impl.Uql.Parser.Syntax.ParseException e) {
                        throw new Net.TheVpc.Upa.Exceptions.UPAException("InvalidFormulaExpression", f.GetAbsoluteName(), "UpdateFormula", persistFormula);
                    }
                    foreach (Net.TheVpc.Upa.Field field in usedFields) {
                        System.Collections.Generic.ISet<Net.TheVpc.Upa.Field> c = (System.Collections.Generic.ISet<Net.TheVpc.Upa.Field>) field.GetProperties().GetObject<T>(UPDATE_DEPENDENT_FIELDS);
                        if (c == null) {
                            c = new System.Collections.Generic.HashSet<Net.TheVpc.Upa.Field>();
                            field.GetProperties().SetObject(UPDATE_DEPENDENT_FIELDS, c);
                        }
                        c.Add(f);
                    }
                    f.GetProperties().SetObject(PERSIST_USED_FIELDS, usedFields);
                }
            }
        }

        public virtual void CommitExpressionModelChanges() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> fs = GetFields();
            foreach (Net.TheVpc.Upa.Field f in fs) {
                CommitFieldExpressionModelChanges(f);
            }
        }

        public virtual void CommitModelChanges() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            InvalidateStructureCache();
            RevalidateStructure();
            Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.EntityModifier> includedModifiers = GetUserModifiers();
            Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.EntityModifier> excludedModifiers = GetUserExcludeModifiers();
            Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.EntityModifier> _effectiveModifiers = Net.TheVpc.Upa.FlagSets.NoneOf<Net.TheVpc.Upa.EntityModifier>();
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> fs = GetFields();
            foreach (Net.TheVpc.Upa.Field f in fs) {
                CommitFieldModelChanges(f);
                Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.FieldModifier> fm = f.GetModifiers();
                if (fm.Contains(Net.TheVpc.Upa.FieldModifier.PERSIST_FORMULA) && !fm.Contains(Net.TheVpc.Upa.FieldModifier.TRANSIENT) && !fm.Contains(Net.TheVpc.Upa.FieldModifier.PERSIST_SEQUENCE)) {
                    _effectiveModifiers = _effectiveModifiers.Add(Net.TheVpc.Upa.EntityModifier.VALIDATE_PERSIST);
                }
                if (fm.Contains(Net.TheVpc.Upa.FieldModifier.UPDATE_FORMULA) && !fm.Contains(Net.TheVpc.Upa.FieldModifier.TRANSIENT) && !fm.Contains(Net.TheVpc.Upa.FieldModifier.UPDATE_SEQUENCE)) {
                    _effectiveModifiers = _effectiveModifiers.Add(Net.TheVpc.Upa.EntityModifier.VALIDATE_UPDATE);
                }
            }
            foreach (Net.TheVpc.Upa.EntityModifier entityModifier in new Net.TheVpc.Upa.EntityModifier[] { Net.TheVpc.Upa.EntityModifier.TRANSIENT, Net.TheVpc.Upa.EntityModifier.LOCK, Net.TheVpc.Upa.EntityModifier.CLEAR, Net.TheVpc.Upa.EntityModifier.PRIVATE, Net.TheVpc.Upa.EntityModifier.SYSTEM }) {
                if (includedModifiers.Contains(entityModifier)) {
                    _effectiveModifiers = _effectiveModifiers.Add(entityModifier);
                }
            }
            foreach (Net.TheVpc.Upa.EntityModifier entityModifier in new Net.TheVpc.Upa.EntityModifier[] { Net.TheVpc.Upa.EntityModifier.PERSIST, Net.TheVpc.Upa.EntityModifier.UPDATE, Net.TheVpc.Upa.EntityModifier.REMOVE, Net.TheVpc.Upa.EntityModifier.CLONE, Net.TheVpc.Upa.EntityModifier.RENAME, Net.TheVpc.Upa.EntityModifier.NAVIGATE }) {
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
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> primaries = GetPrimaryFields();
            if ((primaries).Count == 0) {
                if (_effectiveModifiers.Contains(Net.TheVpc.Upa.EntityModifier.NAVIGATE)) {
                    if (includedModifiers.Contains(Net.TheVpc.Upa.EntityModifier.NAVIGATE)) {
                        log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("NAVIGATE modifier ignored for " + GetName() + " as no primary field was found.",null));
                    }
                    _effectiveModifiers = _effectiveModifiers.Remove(Net.TheVpc.Upa.EntityModifier.NAVIGATE);
                }
            }
            if (mainRendererField == null) {
                System.Collections.Generic.IList<Net.TheVpc.Upa.Field> test = new System.Collections.Generic.List<Net.TheVpc.Upa.Field>();
                //test primaries first
                Net.TheVpc.Upa.Impl.FwkConvertUtils.ListAddRange(test, primaries);
                Net.TheVpc.Upa.Impl.FwkConvertUtils.ListAddRange(test, fs);
                foreach (Net.TheVpc.Upa.Field field in test) {
                    Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.FieldModifier> efm = field.GetModifiers();
                    if (efm.Contains(Net.TheVpc.Upa.FieldModifier.MAIN) && field.GetPersistAccessLevel() != Net.TheVpc.Upa.AccessLevel.PRIVATE && field.GetUpdateAccessLevel() != Net.TheVpc.Upa.AccessLevel.PRIVATE && field.GetReadAccessLevel() != Net.TheVpc.Upa.AccessLevel.PRIVATE && !efm.Contains(Net.TheVpc.Upa.FieldModifier.SYSTEM)) {
                        mainRendererField = field;
                        break;
                    }
                }
                if (mainRendererField == null) {
                    foreach (Net.TheVpc.Upa.Field field in test) {
                        Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.FieldModifier> efm = field.GetModifiers();
                        if (field.GetPersistAccessLevel() != Net.TheVpc.Upa.AccessLevel.PRIVATE && field.GetUpdateAccessLevel() != Net.TheVpc.Upa.AccessLevel.PRIVATE && field.GetReadAccessLevel() != Net.TheVpc.Upa.AccessLevel.PRIVATE && !efm.Contains(Net.TheVpc.Upa.FieldModifier.SYSTEM)) {
                            efm.Add(Net.TheVpc.Upa.FieldModifier.MAIN);
                            mainRendererField = field;
                            break;
                        }
                    }
                }
            }
            bool _KeyEditionSupported = false;
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> primaryFields = GetPrimaryFields();
            foreach (Net.TheVpc.Upa.Field f in primaryFields) {
                Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.FieldModifier> fm = f.GetModifiers();
                if (!fm.Contains(Net.TheVpc.Upa.FieldModifier.PERSIST_FORMULA)) {
                    _KeyEditionSupported = true;
                    break;
                }
            }
            if (includedModifiers.Contains(Net.TheVpc.Upa.EntityModifier.USER_ID) || (!excludedModifiers.Contains(Net.TheVpc.Upa.EntityModifier.USER_ID) && _KeyEditionSupported)) {
                _effectiveModifiers = _effectiveModifiers.Add(Net.TheVpc.Upa.EntityModifier.USER_ID);
            }
            SetModifiers(_effectiveModifiers);
            //if (!Utils.getBoolean(PersistenceUnitFilter.class, "productionMode", false)) {
            CheckIntegrity();
        }

        protected internal virtual void CheckIntegrity() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            // check for fields
            Net.TheVpc.Upa.Impl.DefaultEntityPrivateChecker checker = new Net.TheVpc.Upa.Impl.DefaultEntityPrivateChecker(this);
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> fs = GetFields();
            if ((fs.Count==0)) {
                checker.AddError("Entity " + GetName() + " does not declare any field");
            }
            // check for primary fields
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> primaries = GetPrimaryFields();
            if ((primaries.Count==0)) {
                checker.AddWarning("Entity " + GetName() + " has no primary fields");
            }
            // check for duplicate field declaration
            System.Collections.Generic.ISet<string> hashSet = new System.Collections.Generic.HashSet<string>();
            foreach (Net.TheVpc.Upa.Field f in fs) {
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

        public virtual Net.TheVpc.Upa.Callbacks.Trigger AddTrigger(Net.TheVpc.Upa.Callbacks.EntityInterceptor trigger) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return AddTrigger(null, trigger);
        }

        public virtual Net.TheVpc.Upa.Callbacks.Trigger AddTrigger(string triggerName, Net.TheVpc.Upa.Callbacks.EntityInterceptor trigger) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Impl.DefaultPersistenceUnit pu = (Net.TheVpc.Upa.Impl.DefaultPersistenceUnit) GetPersistenceUnit();
            if (Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(triggerName)) {
                while (true) {
                    string n = "anonymous" + triggerAnonymousNameIndex;
                    if (!triggers.ContainsKey(n)) {
                        triggerName = n;
                        break;
                    }
                    triggerAnonymousNameIndex++;
                }
            } else if (triggers.ContainsKey(triggerName)) {
                throw new Net.TheVpc.Upa.Exceptions.ObjectAlreadyExistsException(null, "Entity Trigger " + triggerName);
            }
            //            if (pu.getAllTriggers().containsKey(triggerName)) {
            //                throw new ObjectAlreadyExistsException(null, "Entity Trigger " + triggerName);
            //            }
            Net.TheVpc.Upa.Impl.DefaultTrigger triggerObject = new Net.TheVpc.Upa.Impl.DefaultTrigger();
            triggerObject.SetEntity(this);
            triggerObject.SetName(triggerName);
            Net.TheVpc.Upa.Callbacks.EntityListener listener = ConvertInterceptorToListener(trigger);
            triggerObject.SetInterceptor(trigger);
            triggerObject.SetListener(listener);
            triggerObject.SetPersistenceState(Net.TheVpc.Upa.PersistenceState.DIRTY);
            pu.GetPersistenceUnitListenerManager().FireOnCreateTrigger(triggerObject, Net.TheVpc.Upa.EventPhase.BEFORE);
            triggers[triggerName]=triggerObject;
            //        pu.getAllTriggers().put(triggerName, triggerObject);
            pu.GetPersistenceUnitListenerManager().FireOnCreateTrigger(triggerObject, Net.TheVpc.Upa.EventPhase.AFTER);
            return triggerObject;
        }

        protected internal virtual Net.TheVpc.Upa.Callbacks.EntityListener ConvertInterceptorToListener(Net.TheVpc.Upa.Callbacks.EntityInterceptor trigger) {
            if (trigger is Net.TheVpc.Upa.Callbacks.EntityListener) {
                return (Net.TheVpc.Upa.Callbacks.EntityListener) trigger;
            } else if (trigger is Net.TheVpc.Upa.Callbacks.SingleEntityListener) {
                return (new Net.TheVpc.Upa.Impl.Event.SingleDataInterceptorSupport((Net.TheVpc.Upa.Callbacks.SingleEntityListener) trigger));
            } else if (trigger is Net.TheVpc.Upa.Callbacks.UpdateRelationshipTargetFormulaInterceptor) {
                return (new Net.TheVpc.Upa.Impl.Event.RelationshipTargetFormulaUpdaterInterceptorSupport((Net.TheVpc.Upa.Callbacks.UpdateRelationshipTargetFormulaInterceptor) trigger));
            } else if (trigger is Net.TheVpc.Upa.Callbacks.UpdateRelationshipSourceFormulaInterceptor) {
                return (new Net.TheVpc.Upa.Impl.Event.RelationshipSourceFormulaUpdaterInterceptorSupport((Net.TheVpc.Upa.Callbacks.UpdateRelationshipSourceFormulaInterceptor) trigger));
            } else if (trigger is Net.TheVpc.Upa.Callbacks.UpdateFormulaInterceptor) {
                return (new Net.TheVpc.Upa.Impl.Event.FormulaUpdaterInterceptorSupport((Net.TheVpc.Upa.Callbacks.UpdateFormulaInterceptor) trigger));
            } else {
                throw new System.ArgumentException ("Unsupported Entity Trigger Type " + trigger.GetType());
            }
        }

        public virtual void RemoveTrigger(string triggerName) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Impl.DefaultPersistenceUnit pu = (Net.TheVpc.Upa.Impl.DefaultPersistenceUnit) GetPersistenceUnit();
            Net.TheVpc.Upa.Callbacks.Trigger tr = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.TheVpc.Upa.Callbacks.Trigger>(triggers,triggerName);
            if (tr == null) {
                throw new System.ArgumentException ("Trigger Not found " + triggerName);
            }
            pu.GetPersistenceUnitListenerManager().FireOnDropTrigger(tr, Net.TheVpc.Upa.EventPhase.BEFORE);
            triggers.Remove(triggerName);
            //        pu.getAllTriggers().remove(triggerName);
            pu.GetPersistenceUnitListenerManager().FireOnDropTrigger(tr, Net.TheVpc.Upa.EventPhase.AFTER);
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

        public virtual void UpdateFormulas() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            CreateUpdateQuery().ValidateAll().Execute();
        }

        public virtual Net.TheVpc.Upa.Field BindField(Net.TheVpc.Upa.Field field, string sectionPath) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return BindField(field, sectionPath, -1);
        }

        public virtual Net.TheVpc.Upa.Field BindField(Net.TheVpc.Upa.Field field, string sectionPath, int index) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(field.GetName())) {
                throw new System.ArgumentException ("Field name is Null or Empty");
            }
            if (field.GetDataType() == null) {
            } else if (field.GetUserModifiers().Contains(Net.TheVpc.Upa.UserFieldModifier.ID) && field.GetDataType().IsNullable()) {
                log.TraceEvent(System.Diagnostics.TraceEventType.Warning,90,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Field {0}.{1} is ID but has nullable Type. Forced to non nullable (type reference changed).",null,new object[] { GetName(), field.GetName() }));
                Net.TheVpc.Upa.Types.DataType t = (Net.TheVpc.Upa.Types.DataType) field.GetDataType().Copy();
                t.SetNullable(false);
                field.SetDataType(t);
            }
            if (field.GetPersistFormula() != null && !(field.GetPersistFormula() is Net.TheVpc.Upa.Sequence) && field.GetDataType() != null && !field.GetDataType().IsNullable()) {
                throw new System.ArgumentException ("Field " + GetName() + "." + field.GetName() + " is a FORMULA field. Thus it must be nullable");
            }
            Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> modifiersCopy = Copy(field.GetUserModifiers());
            Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> excludedModifiersCopy = Copy(field.GetUserExcludeModifiers());
            modifiersCopy.RemoveAll(excludedModifiersCopy);
            field.SetUserModifiers(modifiersCopy);
            field.SetUserExcludeModifiers(excludedModifiersCopy);
            //Workaround
            Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.FieldModifier> tt = Net.TheVpc.Upa.FlagSets.NoneOf<Net.TheVpc.Upa.FieldModifier>();
            if (modifiersCopy.Contains(Net.TheVpc.Upa.UserFieldModifier.ID)) {
                tt = tt.Add(Net.TheVpc.Upa.FieldModifier.ID);
            }
            if (modifiersCopy.Contains(Net.TheVpc.Upa.UserFieldModifier.TRANSIENT)) {
                tt = tt.Add(Net.TheVpc.Upa.FieldModifier.TRANSIENT);
            }
            if (modifiersCopy.Contains(Net.TheVpc.Upa.UserFieldModifier.SYSTEM)) {
                tt = tt.Add(Net.TheVpc.Upa.FieldModifier.SYSTEM);
            }
            ((Net.TheVpc.Upa.Impl.AbstractField) field).SetEffectiveModifiers(tt);
            if (sectionPath == null || (sectionPath).Length == 0) {
                Net.TheVpc.Upa.Impl.Util.DefaultBeanAdapter adapter = Net.TheVpc.Upa.Impl.Util.UPAUtils.Prepare(GetPersistenceUnit(), this, field, field.GetName());
                AddPart(field, index);
            } else {
                Net.TheVpc.Upa.Impl.Util.DefaultBeanAdapter adapter = Net.TheVpc.Upa.Impl.Util.UPAUtils.Prepare(GetPersistenceUnit(), this, field, field.GetName());
                GetSection(sectionPath, Net.TheVpc.Upa.MissingStrategy.CREATE).AddPart(field, index);
            }
            InvalidateStructureCache();
            return field;
        }

        protected internal virtual void BeforePartAdded(Net.TheVpc.Upa.EntityPart parent, Net.TheVpc.Upa.EntityPart part, int index) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (part is Net.TheVpc.Upa.Field) {
                if (part.GetName() == null || (part.GetName()).Length == 0) {
                    throw new Net.TheVpc.Upa.Exceptions.UPAException(new Net.TheVpc.Upa.Types.I18NString("InvalidNameException"), "Field with no name for " + GetName());
                }
                Net.TheVpc.Upa.Field field = (Net.TheVpc.Upa.Field) part;
                if (field.GetPersistFormula() != null && !(field.GetPersistFormula() is Net.TheVpc.Upa.Sequence) && (field.GetDefaultObject() == null || field.GetDefaultObject() is Net.TheVpc.Upa.CustomDefaultObject) && !field.GetUserModifiers().Contains(Net.TheVpc.Upa.UserFieldModifier.TRANSIENT) && !(field.GetUserModifiers().Contains(Net.TheVpc.Upa.UserFieldModifier.ID)) && field.GetDataType() != null && !field.GetDataType().IsNullable()) {
                    //change type
                    Net.TheVpc.Upa.Types.DataType t = (Net.TheVpc.Upa.Types.DataType) field.GetDataType().Copy();
                    t.SetNullable(true);
                    field.SetDataType(t);
                    log.TraceEvent(System.Diagnostics.TraceEventType.Warning,90,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter(GetName() + "." + field.GetName() + " is a formula but is not nullable. Forced to nullable (type reference changed)",null));
                }
                //throw new UPAException(new I18NString("NoNullableFormulaException", field.getName(), getName()));
                if (fieldsMap.ContainsKey(GetPersistenceUnit().GetNamingStrategy().GetUniformValue(field.GetName()))) {
                    throw new Net.TheVpc.Upa.Exceptions.ObjectAlreadyExistsException("EntityItemAlreadyExists", field.GetName());
                }
            } else if (part is Net.TheVpc.Upa.Section) {
                if (part.GetName() == null || (part.GetName()).Length == 0) {
                    throw new Net.TheVpc.Upa.Exceptions.UPAException(new Net.TheVpc.Upa.Types.I18NString("InvalidNameException"), "Section for " + GetName());
                }
            }
            if (parent == null) {
                Net.TheVpc.Upa.EntityPart found = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.TheVpc.Upa.EntityPart>(itemsByName,part.GetName());
                if (found != null) {
                    throw new Net.TheVpc.Upa.Exceptions.ObjectAlreadyExistsException("EntityItemAlreadyExists", part.GetName());
                }
            } else if (parent is Net.TheVpc.Upa.Section) {
                Net.TheVpc.Upa.Section s = (Net.TheVpc.Upa.Section) parent;
                bool found = false;
                try {
                    s.GetPart(part.GetName());
                    found = true;
                } catch (System.Exception e) {
                }
                //
                if (found) {
                    throw new Net.TheVpc.Upa.Exceptions.ObjectAlreadyExistsException("EntityItemAlreadyExists", parent.GetName());
                }
            } else if (parent is Net.TheVpc.Upa.CompoundField) {
                Net.TheVpc.Upa.CompoundField s = (Net.TheVpc.Upa.CompoundField) parent;
                bool found = false;
                try {
                    s.GetField(part.GetName());
                    found = true;
                } catch (System.Exception e) {
                }
                //
                if (found) {
                    throw new Net.TheVpc.Upa.Exceptions.ObjectAlreadyExistsException("EntityItemAlreadyExists", parent.GetName());
                }
            }
        }

        public virtual void AfterPartAdded(Net.TheVpc.Upa.EntityPart parent, Net.TheVpc.Upa.EntityPart item, int index) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (item is Net.TheVpc.Upa.Field) {
                Net.TheVpc.Upa.Field field = (Net.TheVpc.Upa.Field) item;
                field.AddObjectListener(objListener);
            } else if (item is Net.TheVpc.Upa.Section) {
                Net.TheVpc.Upa.Section section = (Net.TheVpc.Upa.Section) item;
                section.AddObjectListener(objListener);
            }
            //reset fieldsByFilter
            fieldsByFilter.Clear();
        }


        public virtual Net.TheVpc.Upa.Field GetMainField() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return mainRendererField;
        }


        public virtual string GetMainFieldValue(object o) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Field mf = GetMainField();
            if (mf == null) {
                return null;
            }
            object v = GetBuilder().ObjectToRecord(o, false).GetObject<T>(mf.GetName());
            if (v == null) {
                return null;
            }
            return System.Convert.ToString(v);
        }


        public virtual Net.TheVpc.Upa.EntityNavigator GetNavigator() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (navigator == null) {
                navigator = CreateNavigator();
            }
            return navigator;
        }

        public virtual void SetNavigator(Net.TheVpc.Upa.EntityNavigator newNavigator) {
            this.navigator = newNavigator;
        }

        protected internal virtual Net.TheVpc.Upa.EntityNavigator CreateNavigator() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> pf = GetPrimaryFields();
            if ((pf).Count == 1) {
                Net.TheVpc.Upa.Field field = pf[0];
                System.Type idClass = field.GetDataType().GetPlatformType();
                if (typeof(string).Equals(idClass)) {
                    string sn = this.GetShortName();
                    if (sn == null) {
                        sn = GetName();
                    }
                    if (field.GetPersistFormula() is Net.TheVpc.Upa.Sequence) {
                        Net.TheVpc.Upa.Sequence a = (Net.TheVpc.Upa.Sequence) field.GetPersistFormula();
                        string format = a.GetFormat();
                        if (format == null) {
                            format = sn + "{#}";
                        }
                        string name = a.GetName();
                        if (name == null) {
                            name = field.GetEntity().GetName() + "." + field.GetName();
                        }
                        return Net.TheVpc.Upa.Impl.Navigator.EntityNavigatorFactory.CreateStringSequenceNavigator(this, name, format, a.GetGroup(), a.GetInitialValue(), a.GetAllocationSize());
                    } else {
                        string format = sn + "{#}";
                        return Net.TheVpc.Upa.Impl.Navigator.EntityNavigatorFactory.CreateStringSequenceNavigator(this, this.GetName(), format, null, 1, 1);
                    }
                } else if (Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsInt32(idClass)) {
                    return Net.TheVpc.Upa.Impl.Navigator.EntityNavigatorFactory.CreateIntegerNavigator(this);
                } else if (Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsInt64(idClass)) {
                    return Net.TheVpc.Upa.Impl.Navigator.EntityNavigatorFactory.CreateLongNavigator(this);
                } else {
                    return Net.TheVpc.Upa.Impl.Navigator.EntityNavigatorFactory.CreateDefaultNavigator(this);
                }
            } else {
                return Net.TheVpc.Upa.Impl.Navigator.EntityNavigatorFactory.CreateDefaultNavigator(this);
            }
        }

        private Net.TheVpc.Upa.Field CreateField(Net.TheVpc.Upa.FieldDescriptor fieldDescriptor) {
            Net.TheVpc.Upa.Field f = null;
            if (fieldDescriptor.GetDataType() is Net.TheVpc.Upa.CompoundDataType) {
                f = new Net.TheVpc.Upa.Impl.DefaultCompoundField();
            } else {
                f = new Net.TheVpc.Upa.Impl.DefaultPrimitiveField();
            }
            f.SetName(fieldDescriptor.GetName());
            f.SetDefaultObject(fieldDescriptor.GetDefaultObject());
            f.SetDataType(fieldDescriptor.GetDataType());
            f.SetUserModifiers(fieldDescriptor.GetUserFieldModifiers());
            f.SetUserExcludeModifiers(fieldDescriptor.GetUserExcludeModifiers());
            Net.TheVpc.Upa.PropertyAccessType propertyAccessType = fieldDescriptor.GetPropertyAccessType();
            if (Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsUndefinedValue<Net.TheVpc.Upa.PropertyAccessType>(typeof(Net.TheVpc.Upa.PropertyAccessType), propertyAccessType)) {
                propertyAccessType = Net.TheVpc.Upa.PropertyAccessType.PROPERTY;
            }
            f.SetPropertyAccessType(propertyAccessType);
            if (fieldDescriptor.GetFieldParams() != null) {
                foreach (System.Collections.Generic.KeyValuePair<string , object> e in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<string,object>>(fieldDescriptor.GetFieldParams())) {
                    f.GetProperties().SetObject((e).Key, (e).Value);
                }
            }
            Net.TheVpc.Upa.Types.DataTypeTransform t = GetPersistenceUnit().GetTypeTransformFactory().CreateTypeTransform(GetPersistenceUnit(), fieldDescriptor.GetDataType(), fieldDescriptor.GetTypeTransform());
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
            if (f is Net.TheVpc.Upa.Impl.DefaultCompoundField) {
                Net.TheVpc.Upa.Impl.DefaultCompoundField cf = (Net.TheVpc.Upa.Impl.DefaultCompoundField) f;
                Net.TheVpc.Upa.CompoundDataType d = (Net.TheVpc.Upa.CompoundDataType) GetDataType();
                Net.TheVpc.Upa.FieldDescriptor[] composingFields = d.GetComposingFields(fieldDescriptor);
                foreach (Net.TheVpc.Upa.FieldDescriptor composingField in composingFields) {
                    Net.TheVpc.Upa.Field field = CreateField(composingField);
                    cf.AddField((Net.TheVpc.Upa.PrimitiveField) field);
                }
            }
            return f;
        }

        public virtual Net.TheVpc.Upa.Field AddField(Net.TheVpc.Upa.FieldDescriptor fieldDescriptor) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Field f = CreateField(fieldDescriptor);
            BindField(f, fieldDescriptor.GetFieldPath(), fieldDescriptor.GetPosition() == 0 ? -1 : fieldDescriptor.GetPosition());
            return f;
        }

        public virtual Net.TheVpc.Upa.Field AddField(string name, string sectionPath, Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> modifiers, object defaultValue, Net.TheVpc.Upa.Types.DataType type) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return AddField(new Net.TheVpc.Upa.DefaultFieldDescriptor().SetName(name).SetFieldPath(sectionPath).SetUserFieldModifiers(modifiers).SetDefaultObject(defaultValue).SetDataType(type));
        }

        public virtual Net.TheVpc.Upa.Field AddField(string name, string sectionPath, Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> modifiers, Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> excludeModifiers, object defaultValue, Net.TheVpc.Upa.Types.DataType type, int index) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return AddField(new Net.TheVpc.Upa.DefaultFieldDescriptor().SetName(name).SetFieldPath(sectionPath).SetUserFieldModifiers(modifiers).SetUserExcludeModifiers(excludeModifiers).SetDefaultObject(defaultValue).SetDataType(type).SetPosition(index));
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
            if (other == null || !(other is Net.TheVpc.Upa.Impl.DefaultEntity)) {
                return false;
            } else {
                Net.TheVpc.Upa.Impl.DefaultEntity o = (Net.TheVpc.Upa.Impl.DefaultEntity) other;
                return GetPersistenceUnit().GetNamingStrategy().Equals(GetName(), o.GetName());
            }
        }

        public virtual bool ContainsField(string key) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return fieldsMap.ContainsKey(GetPersistenceUnit().GetNamingStrategy().GetUniformValue(key));
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.DynamicField> GetDynamicFields() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return Net.TheVpc.Upa.Impl.Util.PlatformUtils.EmptyList<T>();
        }

        public virtual Net.TheVpc.Upa.PrimitiveField GetPrimitiveField(string fieldName) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return (Net.TheVpc.Upa.PrimitiveField) GetField(fieldName);
        }

        public virtual Net.TheVpc.Upa.PrimitiveField FindPrimitiveField(string fieldName) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return (Net.TheVpc.Upa.PrimitiveField) FindField(fieldName);
        }

        public virtual Net.TheVpc.Upa.Field GetField(int index) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            int i = 0;
            foreach (Net.TheVpc.Upa.Field @value in (fieldsMap).Values) {
                if (i == index) {
                    return @value;
                }
                i++;
            }
            throw new System.IndexOutOfRangeException("Invalid Index "+(index));
        }

        public virtual Net.TheVpc.Upa.Field GetField(string fieldName) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            RevalidateStructure();
            Net.TheVpc.Upa.Field f = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.TheVpc.Upa.Field>(fieldsMap,GetPersistenceUnit().GetNamingStrategy().GetUniformValue(fieldName));
            if (f != null) {
                return f;
            }
            //            ExtendedField p = (ExtendedField) mappedCompoundFields.get(getPersistenceUnit().getNamesComparator().getUniformValue(fieldName));
            //            if (p == null) {
            //            Log.dev_warning(getName() + " : ExtendedField : " + "Neither Field nor compound field " + fieldName + " was found in Entity " + getName());
            throw new System.Exception("Neither Field nor compound field " + fieldName + " was found in Entity " + GetName());
        }

        public virtual Net.TheVpc.Upa.Field FindField(string fieldName) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            RevalidateStructure();
            return Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.TheVpc.Upa.Field>(fieldsMap,GetPersistenceUnit().GetNamingStrategy().GetUniformValue(fieldName));
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Field> GetPrimaryFields() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetFields(Net.TheVpc.Upa.Filters.Fields.Id());
        }

        public virtual System.Collections.Generic.IList<string> GetFieldNames(Net.TheVpc.Upa.Filters.FieldFilter fieldFilter) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> f = GetFields(fieldFilter);
            System.Collections.Generic.IList<string> s = new System.Collections.Generic.List<string>((f).Count);
            foreach (Net.TheVpc.Upa.Field field in f) {
                s.Add(field.GetName());
            }
            return s;
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Field> GetFields(Net.TheVpc.Upa.Filters.FieldFilter fieldFilter) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            RevalidateStructure();
            if (fieldFilter == null) {
                return GetFields();
            }
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> c = fieldsByFilter.Get(fieldFilter);
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> e = new System.Collections.Generic.List<Net.TheVpc.Upa.Field>((fieldsMap).Count);
            if (c == null) {
                foreach (Net.TheVpc.Upa.Field field in (fieldsMap).Values) {
                    if (fieldFilter.Accept(field)) {
                        e.Add(field);
                    }
                }
                c = new System.Collections.Generic.List<Net.TheVpc.Upa.Field>(e);
                fieldsByFilter.Put(fieldFilter, c);
                if (fieldFilter.AcceptDynamic()) {
                    foreach (Net.TheVpc.Upa.DynamicField df in GetDynamicFields()) {
                        if (fieldFilter.Accept(df)) {
                            e.Add(df);
                        }
                    }
                    c = e;
                }
            } else if (fieldFilter.AcceptDynamic()) {
                e = new System.Collections.Generic.List<Net.TheVpc.Upa.Field>(c);
                foreach (Net.TheVpc.Upa.DynamicField df in GetDynamicFields()) {
                    if (fieldFilter.Accept(df)) {
                        e.Add(df);
                    }
                }
                c = e;
            }
            return c;
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.PrimitiveField> GetPrimitiveFields(Net.TheVpc.Upa.Filters.FieldFilter fieldFilter) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.List<Net.TheVpc.Upa.PrimitiveField> primitiveFields = new System.Collections.Generic.List<Net.TheVpc.Upa.PrimitiveField>();
            foreach (Net.TheVpc.Upa.Field f in GetFields(Net.TheVpc.Upa.Filters.Fields.Primitive().And(fieldFilter))) {
                primitiveFields.Add((Net.TheVpc.Upa.PrimitiveField) f);
            }
            return primitiveFields;
        }

        public virtual object CloneRecord(object oldId, object newId) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (IsCheckSecurity()) {
                GetShield().CheckClone(oldId, newId);
            }
            object o = CreateQueryBuilder().ById(oldId).SetFieldFilter(Net.TheVpc.Upa.Impl.Util.Filters.Fields2.COPY_ON_CLONE).GetEntity<R>();
            GetBuilder().SetObjectId(o, newId);
            Persist(o);
            return o;
        }

        protected internal virtual bool IsCheckSecurity() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Session currentSession = GetPersistenceUnit().GetCurrentSession();
            return (currentSession == null) || !GetPersistenceUnit().IsSystemSession(currentSession);
        }

        public virtual object Rename(object oldId, object newId) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return Rename(oldId, newId, defaultHints);
        }

        public virtual object Rename(object oldId, object newId, System.Collections.Generic.IDictionary<string , object> hints) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (IsCheckSecurity()) {
                GetShield().CheckRename(oldId, newId);
            }
            Net.TheVpc.Upa.Persistence.EntityExecutionContext context = CreateContext(Net.TheVpc.Upa.Persistence.ContextOperation.RENAME, hints);
            //        Object tranasction = getPersistenceUnit().getPersistenceStore().getConnection().tryBeginTransaction();
            //        boolean transactionSucceeded = false;
            //        try {
            object o = CreateQueryBuilder().ById(oldId).SetFieldFilter(Net.TheVpc.Upa.Impl.Util.Filters.Fields2.COPY_ON_RENAME).GetEntity<R>();
            Net.TheVpc.Upa.Record ur = GetBuilder().ObjectToRecord(o, false);
            GetBuilder().SetRecordId(ur, newId);
            // insert(o, false);
            object[] newIdValues = GetBuilder().IdToKey(newId).GetValue();
            object[] oldIdValues = GetBuilder().IdToKey(oldId).GetValue();
            PersistCore(ur, context);
            foreach (Net.TheVpc.Upa.Relationship r in GetPersistenceUnit().GetRelationshipsByTarget(this)) {
                if (!r.GetSourceRole().GetEntity().Equals(r.GetTargetRole().GetEntity()) && !r.IsTransient()) {
                    Net.TheVpc.Upa.Record updates = r.GetSourceRole().GetEntity().GetBuilder().CreateRecord();
                    Net.TheVpc.Upa.Expressions.Expression condition = null;
                    System.Collections.Generic.IList<Net.TheVpc.Upa.Field> lfields = r.GetSourceRole().GetFields();
                    for (int j = 0; j < (lfields).Count; j++) {
                        Net.TheVpc.Upa.Field lf = lfields[j];
                        updates.SetObject(lf.GetName(), newIdValues[j]);
                        Net.TheVpc.Upa.Expressions.Expression e = new Net.TheVpc.Upa.Expressions.Equals(new Net.TheVpc.Upa.Expressions.Var(lf.GetName()), new Net.TheVpc.Upa.Expressions.Literal(oldIdValues[j], lf.GetDataType()));
                        condition = condition == null ? ((Net.TheVpc.Upa.Expressions.Expression)(e)) : new Net.TheVpc.Upa.Expressions.And(condition, e);
                    }
                    try {
                        // r.getDetailsTable().updateAllRecords(updates,
                        // condition, check);
                        r.GetSourceRole().GetEntity().UpdateCore(updates, condition, context);
                    } catch (Net.TheVpc.Upa.Exceptions.UpdateRecordKeyNotFoundException e) {
                    }
                }
            }
            // if no updates no matter
            // remove(toExpression(oldId, null),
            // getPersistenceUnit().isRecurseDelete(), false, new RemoveTrace());
            RemoveCore(GetBuilder().IdToExpression(oldId, null), GetPersistenceUnit().IsRecurseDelete(), new Net.TheVpc.Upa.Impl.DefaultRemoveTrace(), context);
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

        public virtual object GetNextId(object id) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return (object) GetNavigator().GetNextKey(id);
        }

        public virtual object GetFirstId() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return (object) GetNavigator().GetFirstKey();
        }

        public virtual object GetLastId() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return (object) GetNavigator().GetLastKey();
        }

        public virtual object GetPreviousId(object id) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return (object) GetNavigator().GetPreviousKey(id);
        }

        public virtual bool HasNext(object id) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetNextId(id) != null;
        }

        public virtual bool HasPrevious(object id) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetPreviousId(id) != null;
        }

        public virtual bool IsEmpty() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            bool b = false;
            if (cache.isEmpty == null) {
                b = GetFirstId() == null;
                cache.isEmpty = b;
            }
            return b;
        }

        public virtual long GetEntityCount() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Record record = CreateQuery(new Net.TheVpc.Upa.Expressions.Select().Field(new Net.TheVpc.Upa.Expressions.Count(Net.TheVpc.Upa.Expressions.Literal.IONE))).GetRecord();
            return record.GetLong();
        }

        public virtual long GetEntityCount(Net.TheVpc.Upa.Expressions.Expression booleanExpression) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            object n = CreateQuery((new Net.TheVpc.Upa.Expressions.Select()).From(GetName()).Field(new Net.TheVpc.Upa.Expressions.Count(new Net.TheVpc.Upa.Expressions.Literal(1))).Where(booleanExpression)).GetNumber();
            return n == null ? -1L : System.Convert.ToInt32(n);
        }

        public virtual  K NextId<K>() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return (K) GetNavigator().GetNewKey();
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression ParentToChildExpression(Net.TheVpc.Upa.Expressions.Expression parentExpression) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (parentExpression == null) {
                return null;
            }
            Net.TheVpc.Upa.Relationship r = GetCompositionRelation();
            Net.TheVpc.Upa.Expressions.Select s = new Net.TheVpc.Upa.Expressions.Select().From(r.GetTargetRole().GetEntity().GetName()).Where(parentExpression);
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> df = r.GetSourceRole().GetFields();
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> mf = r.GetTargetRole().GetFields();
            if ((df).Count == 1) {
                s.Field(new Net.TheVpc.Upa.Expressions.Var(mf[0].GetName()));
                return new Net.TheVpc.Upa.Expressions.InSelection(new Net.TheVpc.Upa.Expressions.Var(df[0].GetName()), s);
            } else {
                Net.TheVpc.Upa.Expressions.Var[] mv = new Net.TheVpc.Upa.Expressions.Var[(mf).Count];
                for (int i = 0; i < (mf).Count; i++) {
                    mv[i] = new Net.TheVpc.Upa.Expressions.Var(mf[i].GetName());
                }
                Net.TheVpc.Upa.Expressions.Var[] dv = new Net.TheVpc.Upa.Expressions.Var[(df).Count];
                for (int i = 0; i < (df).Count; i++) {
                    dv[i] = new Net.TheVpc.Upa.Expressions.Var(df[i].GetName());
                }
                s.Field(new Net.TheVpc.Upa.Expressions.Uplet(dv));
                return new Net.TheVpc.Upa.Expressions.InSelection(new Net.TheVpc.Upa.Expressions.Uplet(mv), s);
            }
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression ChildToParentExpression(Net.TheVpc.Upa.Expressions.Expression childExpression) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (childExpression == null) {
                return null;
            }
            Net.TheVpc.Upa.Expressions.Select s = new Net.TheVpc.Upa.Expressions.Select().From(GetName()).Where(childExpression);
            Net.TheVpc.Upa.Relationship r = GetCompositionRelation();
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> df = r.GetSourceRole().GetFields();
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> mf = r.GetTargetRole().GetFields();
            if ((df).Count == 1) {
                s.Field(new Net.TheVpc.Upa.Expressions.Var(df[0].GetName()));
                return new Net.TheVpc.Upa.Expressions.InSelection(new Net.TheVpc.Upa.Expressions.Var(mf[0].GetName()), s);
            } else {
                Net.TheVpc.Upa.Expressions.Var[] dv = new Net.TheVpc.Upa.Expressions.Var[(df).Count];
                for (int i = 0; i < (df).Count; i++) {
                    dv[i] = new Net.TheVpc.Upa.Expressions.Var(df[i].GetName());
                }
                Net.TheVpc.Upa.Expressions.Var[] mv = new Net.TheVpc.Upa.Expressions.Var[(mf).Count];
                for (int i = 0; i < (mf).Count; i++) {
                    mv[i] = new Net.TheVpc.Upa.Expressions.Var(mf[i].GetName());
                }
                s.Field(new Net.TheVpc.Upa.Expressions.Uplet(mv));
                return new Net.TheVpc.Upa.Expressions.InSelection(new Net.TheVpc.Upa.Expressions.Uplet(dv), s);
            }
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression ChildToParentExpression(Net.TheVpc.Upa.Record child) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Relationship r = GetCompositionRelation();
            Net.TheVpc.Upa.Field sf = r.GetSourceRole().GetEntityField();
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> df = r.GetSourceRole().GetFields();
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> mf = r.GetTargetRole().GetFields();
            if (sf != null) {
                Net.TheVpc.Upa.EntityBuilder tb = r.GetTargetEntity().GetBuilder();
                object @object = child.GetObject<T>(sf.GetName());
                if (@object == null) {
                    return null;
                }
                return tb.IdToExpression(tb.ObjectToId(@object), null);
            } else if ((df).Count == 1) {
                return new Net.TheVpc.Upa.Expressions.Equals(new Net.TheVpc.Upa.Expressions.Var(mf[0].GetName()), child.GetObject<T>(df[0].GetName()));
            } else {
                Net.TheVpc.Upa.Expressions.Expression a = null;
                for (int i = 0; i < (df).Count; i++) {
                    Net.TheVpc.Upa.Expressions.Expression e = new Net.TheVpc.Upa.Expressions.Equals(new Net.TheVpc.Upa.Expressions.Var(mf[i].GetName()), child.GetObject<T>(df[i].GetName()));
                    a = a == null ? ((Net.TheVpc.Upa.Expressions.Expression)(e)) : new Net.TheVpc.Upa.Expressions.And(a, e);
                }
                return a;
            }
        }


        public virtual Net.TheVpc.Upa.RemoveTrace Remove(Net.TheVpc.Upa.RemoveOptions options) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Expressions.Expression expression = ObjToExpression(options.GetConditionType(), options.GetRemoveCondition());
            bool recurse = options.IsFollowLinks();
            bool simulate = options.IsSimulate();
            Net.TheVpc.Upa.RemoveTrace removeInfo = options.GetRemoveTrace();
            if (removeInfo == null) {
                removeInfo = new Net.TheVpc.Upa.Impl.DefaultRemoveTrace();
                options.SetRemoveTrace(removeInfo);
            }
            Net.TheVpc.Upa.Relationship relation = options.GetFollowRelationship();
            expression = ToIdListExpression(expression);
            if (IsCheckSecurity()) {
                GetShield().CheckRemove(expression, recurse);
            }
            Net.TheVpc.Upa.Persistence.EntityExecutionContext removeExecContext = CreateContext(simulate ? Net.TheVpc.Upa.Persistence.ContextOperation.REMOVE_SIMULATION : Net.TheVpc.Upa.Persistence.ContextOperation.REMOVE, options.GetHints());
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
                Net.TheVpc.Upa.Impl.Util.CacheFile cache = new Net.TheVpc.Upa.Impl.Util.CacheFile();
                if (recurse && actualReturnCount > 0) {
                    foreach (Net.TheVpc.Upa.Relationship r in GetPersistenceUnit().GetRelationshipsByTarget(this)) {
                        if (r.IsTransient()) {
                            continue;
                        }
                        Net.TheVpc.Upa.Field masterField = r.GetTargetRole().GetField(0);
                        if (r.GetRelationshipType() == Net.TheVpc.Upa.RelationshipType.SHADOW_ASSOCIATION) {
                            if (!simulate) {
                                Net.TheVpc.Upa.Record updates = GetBuilder().CreateRecord();
                                System.Collections.Generic.IList<Net.TheVpc.Upa.Field> fls = r.GetSourceRole().GetFields();
                                foreach (Net.TheVpc.Upa.Field fl in fls) {
                                    updates.SetObject(fl.GetName(), fl.GetDefaultValue());
                                }
                                Net.TheVpc.Upa.Expressions.Expression rightCondition = null;
                                if (r.Size() == 1) {
                                    Net.TheVpc.Upa.Field ff = r.GetSourceRole().GetField(0);
                                    rightCondition = new Net.TheVpc.Upa.Expressions.InSelection(new Net.TheVpc.Upa.Expressions.Var(ff.GetName()), (new Net.TheVpc.Upa.Expressions.Select()).From(r.GetTargetRole().GetEntity().GetName()).Field(new Net.TheVpc.Upa.Expressions.Var(masterField.GetName())).Where(expression));
                                } else {
                                    Net.TheVpc.Upa.Expressions.Var[] lvars = new Net.TheVpc.Upa.Expressions.Var[r.Size()];
                                    Net.TheVpc.Upa.Expressions.Var[] rvars = new Net.TheVpc.Upa.Expressions.Var[r.Size()];
                                    for (int x = 0; x < lvars.Length; x++) {
                                        lvars[x] = new Net.TheVpc.Upa.Expressions.Var(r.GetSourceRole().GetField(x).GetName());
                                        lvars[x] = new Net.TheVpc.Upa.Expressions.Var(r.GetTargetRole().GetField(x).GetName());
                                    }
                                    rightCondition = new Net.TheVpc.Upa.Expressions.InSelection(lvars, (new Net.TheVpc.Upa.Expressions.Select()).From(r.GetTargetRole().GetEntity().GetName()).Uplet(rvars).Where(expression));
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
                            r.GetSourceRole().GetEntity().Remove(Net.TheVpc.Upa.RemoveOptions.ForExpression(((new Net.TheVpc.Upa.Expressions.InSelection(new Net.TheVpc.Upa.Expressions.Var(r.GetSourceRole().GetField(0).GetName()), (new Net.TheVpc.Upa.Expressions.Select()).From(r.GetTargetRole().GetEntity().GetName()).Field(new Net.TheVpc.Upa.Expressions.Var(masterField.GetName())).Where(expression))))).SetFollowLinks(true).SetSimulate(simulate).SetRemoveTrace(removeInfo).SetFollowRelationship(r));
                        }
                    }
                }
                cache.Close();
                if (!simulate) {
                    actualReturnCount = RemoveCore(expression, recurse, removeInfo, removeExecContext);
                }
                removeInfo.Add(relation != null ? relation.GetRelationshipType() : Net.TheVpc.Upa.RelationshipType.SHADOW_ASSOCIATION, this, actualReturnCount);
                while (cache.HasNext()) {
                    Net.TheVpc.Upa.Relationship rel = GetPersistenceUnit().GetRelationship((string) cache.Read());
                    object[] keys = (object[]) cache.Read();
                    Net.TheVpc.Upa.Expressions.Var[] lvars = new Net.TheVpc.Upa.Expressions.Var[rel.Size()];
                    for (int x = 0; x < lvars.Length; x++) {
                        lvars[x] = new Net.TheVpc.Upa.Expressions.Var(rel.GetSourceRole().GetField(x).GetName());
                    }
                    Net.TheVpc.Upa.Expressions.IdCollectionExpression inCollection = new Net.TheVpc.Upa.Expressions.IdCollectionExpression(lvars);
                    foreach (object key in keys) {
                        inCollection.Add(((object) (GetBuilder().IdToKey(key).GetValue())));
                    }
                    if (rel.Size() == 1) {
                        Net.TheVpc.Upa.Expressions.InCollection inColl = new Net.TheVpc.Upa.Expressions.InCollection(new Net.TheVpc.Upa.Expressions.Param(null, rel.GetSourceRole().GetField(0)));
                        foreach (object key in keys) {
                            inColl.Add(new Net.TheVpc.Upa.Expressions.Literal(GetBuilder().IdToKey(key).GetObjectAt(0), rel.GetSourceRole().GetField(0).GetDataType()));
                        }
                        rel.GetSourceRole().GetEntity().CreateUpdateQuery().Validate(Net.TheVpc.Upa.Filters.Fields.Regular().And(Net.TheVpc.Upa.Filters.Fields.ByList(rel.GetSourceRole().GetFields()))).ByExpression(inColl).Execute();
                    } else {
                        Net.TheVpc.Upa.Expressions.Expression[] fuplet = new Net.TheVpc.Upa.Expressions.Expression[rel.Size()];
                        for (int y = 0; y < rel.Size(); y++) {
                            Net.TheVpc.Upa.Field f = rel.GetSourceRole().GetField(y);
                            fuplet[y] = new Net.TheVpc.Upa.Expressions.Var(f.GetName());
                        }
                        Net.TheVpc.Upa.Expressions.InCollection inColl = new Net.TheVpc.Upa.Expressions.InCollection(new Net.TheVpc.Upa.Expressions.Uplet(fuplet));
                        for (int x = 0; x < keys.Length; x++) {
                            Net.TheVpc.Upa.Expressions.Expression[] vuplet = new Net.TheVpc.Upa.Expressions.Expression[rel.Size()];
                            for (int y = 0; y < rel.Size(); y++) {
                                object key = keys[x];
                                vuplet[x] = ((new Net.TheVpc.Upa.Expressions.Literal(GetBuilder().IdToKey(key).GetValue()[y], rel.GetSourceRole().GetField(y).GetDataType())));
                            }
                            inColl.Add(new Net.TheVpc.Upa.Expressions.Uplet(vuplet));
                        }
                        rel.GetSourceRole().GetEntity().CreateUpdateQuery().Validate(Net.TheVpc.Upa.Filters.Fields.Regular().And(Net.TheVpc.Upa.Filters.Fields.ByList(rel.GetSourceRole().GetFields()))).ByExpression(inColl).Execute();
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

        public virtual int RemoveCore(Net.TheVpc.Upa.Expressions.Expression condition, bool recurse, Net.TheVpc.Upa.RemoveTrace removeInfo, Net.TheVpc.Upa.Persistence.EntityExecutionContext executionContext) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Persistence.EntityRemoveOperation a = GetEntityOperationManager().GetRemoveOperation();
            if (a != null) {
                return a.Delete(this, CreateContext(Net.TheVpc.Upa.Persistence.ContextOperation.REMOVE, executionContext.GetHints()), condition, recurse, removeInfo);
            }
            return 0;
        }

        public virtual bool Save(object objectOrRecord) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return Save(objectOrRecord, defaultHints);
        }

        public virtual bool Save(object objectOrRecord, System.Collections.Generic.IDictionary<string , object> hints) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.EntityBuilder builder = GetBuilder();
            Net.TheVpc.Upa.Record rec = builder.ObjectToRecord(objectOrRecord);
            object entityToId = builder.RecordToId(rec);
            if (entityToId == null || GetEntityCount(builder.IdToExpression(entityToId, null)) == 0) {
                Persist(objectOrRecord, hints);
                return true;
            } else {
                CreateUpdateQuery().SetValues(objectOrRecord).SetHints(hints).Execute();
                return false;
            }
        }

        public virtual void Persist(object objectOrRecord) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Persist(objectOrRecord, defaultHints);
        }

        public virtual void Persist(object objectOrRecord, System.Collections.Generic.IDictionary<string , object> hints) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Record record = GetBuilder().ObjectToRecord(objectOrRecord, true);
            if (IsCheckSecurity()) {
                GetShield().CheckPersist(record);
            }
            Net.TheVpc.Upa.Persistence.EntityExecutionContext context = CreateContext(Net.TheVpc.Upa.Persistence.ContextOperation.PERSIST, hints);
            object prePersistId = GetBuilder().RecordToId(record);
            recordListenerSupport.FireBeforePersist(prePersistId, record, context);
            PersistCore(record, context);
            object postPersistId = GetBuilder().RecordToId(record);
            if (GetShield().IsUpdateFormulaOnPersistSupported()) {
                Net.TheVpc.Upa.Expressions.Expression expr = GetBuilder().IdToExpression(postPersistId, null);
                //            expr.setClientProperty(EXPRESSION_SURELY_EXISTS, true);
                UpdateFormulasCore(Net.TheVpc.Upa.Impl.Util.Filters.Fields2.PERSIST_FORMULA, expr, context);
                Net.TheVpc.Upa.Record formulaValues = CreateQueryBuilder().ByExpression(expr).SetFieldFilter(Net.TheVpc.Upa.Impl.Util.Filters.Fields2.PERSIST_FORMULA).GetRecord();
                record.SetAll(formulaValues);
            }
            recordListenerSupport.FireAfterPersist(postPersistId, record, context);
        }


        public virtual void Initialize() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Initialize(defaultHints);
        }


        public virtual void Initialize(System.Collections.Generic.IDictionary<string , object> hints) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (IsCheckSecurity()) {
                GetShield().CheckInitialize();
            }
            Net.TheVpc.Upa.Persistence.EntityExecutionContext context = CreateContext(Net.TheVpc.Upa.Persistence.ContextOperation.INITIALIZE, hints);
            recordListenerSupport.FireBeforeInitialize(context);
            InitializeCore(context);
            recordListenerSupport.FireAfterInitialize(context);
        }


        public virtual void Clear() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Clear(defaultHints);
        }


        public virtual void Clear(System.Collections.Generic.IDictionary<string , object> hints) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (IsCheckSecurity()) {
                GetShield().CheckClear();
            }
            Net.TheVpc.Upa.Persistence.EntityExecutionContext context = CreateContext(Net.TheVpc.Upa.Persistence.ContextOperation.CLEAR, hints);
            recordListenerSupport.FireBeforeClear(context);
            ClearCore(context);
            recordListenerSupport.FireAfterClear(context);
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression GetUnicityExpressionForPersist(object entity) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            object key = GetBuilder().ObjectToId(entity);
            Net.TheVpc.Upa.Record urecord = GetBuilder().ObjectToRecord(entity, false);
            System.Collections.Generic.IList<Net.TheVpc.Upa.Index> uniqueIndexes = GetIndexes(true);
            if ((uniqueIndexes.Count==0)) {
                return GetBuilder().IdToExpression(key, null);
            }
            Net.TheVpc.Upa.Expressions.Expression or = GetBuilder().IdToExpression(key, null);
            foreach (Net.TheVpc.Upa.Index index in uniqueIndexes) {
                Net.TheVpc.Upa.Field[] f = index.GetFields();
                Net.TheVpc.Upa.Expressions.Expression e1 = null;
                if (f.Length == 1) {
                    e1 = new Net.TheVpc.Upa.Expressions.Equals(new Net.TheVpc.Upa.Expressions.Var(f[0].GetName()), Net.TheVpc.Upa.Expressions.ExpressionFactory.ToLiteral(urecord.GetObject<T>(f[0].GetName())));
                } else {
                    Net.TheVpc.Upa.Expressions.Expression a = null;
                    foreach (Net.TheVpc.Upa.Field aF in f) {
                        Net.TheVpc.Upa.Expressions.Expression e = (new Net.TheVpc.Upa.Expressions.Equals(new Net.TheVpc.Upa.Expressions.Var(aF.GetName()), Net.TheVpc.Upa.Expressions.ExpressionFactory.ToLiteral(urecord.GetObject<T>(aF.GetName()))));
                        a = a == null ? ((Net.TheVpc.Upa.Expressions.Expression)(e)) : new Net.TheVpc.Upa.Expressions.And(a, e);
                    }
                    e1 = a;
                }
                or = or == null ? ((Net.TheVpc.Upa.Expressions.Expression)(e1)) : new Net.TheVpc.Upa.Expressions.Or(or, e1);
            }
            return or;
        }

        public virtual bool ContainsCompoundFields() {
            foreach (Net.TheVpc.Upa.Field extendedField in (fieldsMap).Values) {
                if (extendedField is Net.TheVpc.Upa.CompoundField) {
                    return true;
                }
            }
            return false;
        }

        public virtual void PersistCore(Net.TheVpc.Upa.Record record, Net.TheVpc.Upa.Persistence.EntityExecutionContext executionContext) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            foreach (Net.TheVpc.Upa.Impl.Persistence.FieldPersistenceInfo gen in fieldListPersistenceInfo.persistSequenceGeneratorFields) {
                gen.persistFieldPersister.BeforePersist(record, executionContext);
            }
            System.Collections.Generic.HashSet<Net.TheVpc.Upa.Field> persistNonNullable = new System.Collections.Generic.HashSet<Net.TheVpc.Upa.Field>(GetFields(FIELD_FILTER_PERSIST_NON_NULLABLE));
            System.Collections.Generic.HashSet<Net.TheVpc.Upa.Field> persistWithDefaultValue = new System.Collections.Generic.HashSet<Net.TheVpc.Upa.Field>(GetFields(FIELD_FILTER_PERSIST_WITH_DEFAULT_VALUE));
            System.Collections.Generic.HashSet<Net.TheVpc.Upa.Field> emptySet = new System.Collections.Generic.HashSet<Net.TheVpc.Upa.Field>();
            Net.TheVpc.Upa.Impl.DefaultRecord persistentRecord = new Net.TheVpc.Upa.Impl.DefaultRecord();
            foreach (System.Collections.Generic.KeyValuePair<string , object> entry in record.EntrySet()) {
                object @value = (entry).Value;
                string key = (entry).Key;
                //check if the field exists in the entity
                Net.TheVpc.Upa.Field field = FindField(key);
                if (field != null) {
                    //make handled
                    persistNonNullable.Remove(field);
                    persistWithDefaultValue.Remove(field);
                    bool accepted = Net.TheVpc.Upa.Impl.Util.Filters.Fields2.PERSIST.Accept(field);
                    if (accepted) {
                        ((Net.TheVpc.Upa.Impl.AbstractField) field).GetFieldPersister().PrepareFieldForPersist(field, @value, record, persistentRecord, executionContext, persistNonNullable, persistWithDefaultValue);
                    }
                }
            }
            //add default values
            foreach (Net.TheVpc.Upa.Field field in persistWithDefaultValue) {
                object @value = field.GetDefaultValue();
                if (@value == null) {
                    if (!field.GetDataType().IsNullable()) {
                        @value = field.GetDataType().GetDefaultNonNullValue();
                    }
                }
                record.SetObject(field.GetName(), @value);
                ((Net.TheVpc.Upa.Impl.AbstractField) field).GetFieldPersister().PrepareFieldForPersist(field, @value, record, persistentRecord, executionContext, persistNonNullable, emptySet);
            }
            GetEntityOperationManager().GetPersistOperation().Insert(this, record, persistentRecord, executionContext);
            foreach (Net.TheVpc.Upa.Impl.Persistence.FieldPersistenceInfo gen in fieldListPersistenceInfo.persistSequenceGeneratorFields) {
                gen.persistFieldPersister.AfterPersist(record, executionContext);
            }
        }

        public virtual void Update(object objectOrRecord) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            CreateUpdateQuery().SetValues(objectOrRecord).Execute();
        }

        public virtual void Merge(object objectOrRecord) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            CreateUpdateQuery().SetValues(objectOrRecord).Execute();
        }

        private Net.TheVpc.Upa.Expressions.Expression ObjToExpression(Net.TheVpc.Upa.ConditionType conditionType, object condition) {
            Net.TheVpc.Upa.Expressions.Expression expr = null;
            Net.TheVpc.Upa.EntityBuilder builder = GetBuilder();
            switch(conditionType) {
                case Net.TheVpc.Upa.ConditionType.EXPRESSION:
                    {
                        expr = ((Net.TheVpc.Upa.Expressions.Expression) condition);
                        break;
                    }
                case Net.TheVpc.Upa.ConditionType.EXPRESSION_LIST:
                    {
                        Net.TheVpc.Upa.Expressions.Expression ll = null;
                        foreach (Net.TheVpc.Upa.Expressions.Expression t in ((System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.Expression>) condition)) {
                            if (ll == null) {
                                ll = t;
                            } else {
                                ll = new Net.TheVpc.Upa.Expressions.Or(ll, t);
                            }
                        }
                        expr = ll;
                        break;
                    }
                case Net.TheVpc.Upa.ConditionType.ID:
                    {
                        expr = builder.IdToExpression(condition, null);
                        break;
                    }
                case Net.TheVpc.Upa.ConditionType.KEY:
                    {
                        expr = builder.KeyToExpression((Net.TheVpc.Upa.Key) condition, null);
                        break;
                    }
                case Net.TheVpc.Upa.ConditionType.OBJECT:
                    {
                        expr = builder.IdToExpression(builder.ObjectToId(condition), null);
                        break;
                    }
                case Net.TheVpc.Upa.ConditionType.RECORD:
                    {
                        Net.TheVpc.Upa.Record r = (Net.TheVpc.Upa.Record) condition;
                        expr = builder.IdToExpression(builder.RecordToId(r), null);
                        break;
                    }
                case Net.TheVpc.Upa.ConditionType.PROTOTYPE:
                    {
                        expr = builder.ObjectToExpression(condition, true, null);
                        break;
                    }
                case Net.TheVpc.Upa.ConditionType.RECORD_PROTOTYPE:
                    {
                        expr = builder.RecordToExpression((Net.TheVpc.Upa.Record) condition, null);
                        break;
                    }
                case Net.TheVpc.Upa.ConditionType.ID_LIST:
                    {
                        System.Collections.Generic.IList<object> objectList = Net.TheVpc.Upa.Impl.Util.PlatformUtils.AnyObjectToObjectList(condition);
                        expr = builder.IdListToExpression<object>(objectList, null);
                        break;
                    }
                case Net.TheVpc.Upa.ConditionType.KEY_LIST:
                    {
                        System.Collections.Generic.IList<Net.TheVpc.Upa.Key> anyList = (System.Collections.Generic.IList<Net.TheVpc.Upa.Key>) condition;
                        expr = builder.KeyListToExpression(anyList, null);
                        break;
                    }
            }
            return expr;
        }


        public virtual Net.TheVpc.Upa.RemoveTrace Remove(object @object) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (@object == null) {
                throw new Net.TheVpc.Upa.Exceptions.UPAException("ObjectNotFoundException");
            } else if (@object is Net.TheVpc.Upa.RemoveOptions) {
                return Remove((Net.TheVpc.Upa.RemoveOptions) @object);
            } else {
                return Remove(Net.TheVpc.Upa.RemoveOptions.ForObject(@object));
            }
        }


        public virtual Net.TheVpc.Upa.Field[] ToFieldArray(string[] s) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Field[] f = new Net.TheVpc.Upa.Field[s.Length];
            for (int i = 0; i < s.Length; i++) {
                f[i] = GetField(s[i]);
                if (f[i] == null) {
                    log.TraceEvent(System.Diagnostics.TraceEventType.Warning,90,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("field " + s[i] + " not found in " + GetName() + "; all fields are : " + (fieldsMap).Values,null));
                }
            }
            return f;
        }


        public virtual bool Contains(object key) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return key != null && GetEntityCount(GetBuilder().IdToExpression(key, GetName())) > 0;
        }

        public virtual int UpdateRecords(Net.TheVpc.Upa.Record updates, Net.TheVpc.Upa.Expressions.Expression condition) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return UpdateRecords(updates, condition, defaultHints);
        }

        public virtual int UpdateRecords(Net.TheVpc.Upa.Record updates, Net.TheVpc.Upa.Expressions.Expression condition, System.Collections.Generic.IDictionary<string , object> hints) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> fields = (GetShield().IsUpdateFormulaOnUpdateSupported()) ? GetFields(Net.TheVpc.Upa.Impl.Util.Filters.Fields2.UPDATE_FORMULA) : null;
            return UpdateRecords(updates, fields, condition, hints);
        }

        public virtual int UpdateCore(Net.TheVpc.Upa.Record updates, Net.TheVpc.Upa.Expressions.Expression condition, Net.TheVpc.Upa.Persistence.EntityExecutionContext executionContext) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetEntityOperationManager().GetUpdateOperation().Update(this, CreateContext(Net.TheVpc.Upa.Persistence.ContextOperation.UPDATE, executionContext.GetHints()), updates, condition);
        }


        public virtual string GetIdName(object id) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (id == null) {
                return null;
            }
            object[] ukey = GetBuilder().IdToKey(id).GetValue();
            Net.TheVpc.Upa.Field f = GetMainField();
            if (ukey.Length == 1 && f.IsId()) {
                return System.Convert.ToString(ukey[0]);
            }
            object n = CreateQueryBuilder().ById(id).SetFieldFilter(Net.TheVpc.Upa.Filters.Fields.Regular().And(Net.TheVpc.Upa.Filters.Fields.ByList(f))).GetSingleValue();
            if (n != null) {
                foreach (Net.TheVpc.Upa.Relationship r in f.GetManyToOneRelationships()) {
                    if (r.Size() == 1) {
                        Net.TheVpc.Upa.Entity entity = r.GetTargetRole().GetEntity();
                        return entity.GetIdName(entity.CreateId(n));
                    }
                }
                return System.Convert.ToString(n);
            }
            return null;
        }

        public virtual Net.TheVpc.Upa.Persistence.EntityExecutionContext CreateContext(Net.TheVpc.Upa.Persistence.ContextOperation contextOperation, System.Collections.Generic.IDictionary<string , object> hints) {
            Net.TheVpc.Upa.Persistence.EntityExecutionContext context = ((Net.TheVpc.Upa.Impl.DefaultPersistenceUnit) GetPersistenceUnit()).CreateContext(contextOperation, hints);
            context.InitEntity(this, entityOperationManager);
            context.SetHints(hints);
            return context;
        }

        public virtual Net.TheVpc.Upa.QueryBuilder CreateQueryBuilder() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Impl.Persistence.DefaultQueryBuilder q = new Net.TheVpc.Upa.Impl.Persistence.DefaultQueryBuilder(this);
            bool lazyListLoadingEnabled = GetPersistenceUnit().GetProperties().GetBoolean("Query.LazyListLoadingEnabled", true);
            q.SetLazyListLoadingEnabled(lazyListLoadingEnabled);
            return q;
        }


        public virtual Net.TheVpc.Upa.Query CreateQuery(Net.TheVpc.Upa.Expressions.EntityStatement query) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (query is Net.TheVpc.Upa.Expressions.Select) {
                Net.TheVpc.Upa.Expressions.Select s = (Net.TheVpc.Upa.Expressions.Select) query;
                Net.TheVpc.Upa.Expressions.NameOrQuery entityName = s.GetEntity();
                if (entityName == null) {
                    s.From(GetName());
                }
            }
            System.Collections.Generic.IDictionary<string , object> hints = null;
            //no need for hints, could be customizer later in Query
            if (query is Net.TheVpc.Upa.Expressions.QueryStatement) {
                return GetEntityOperationManager().GetFindOperation().CreateQuery(this, (Net.TheVpc.Upa.Expressions.QueryStatement) query, CreateContext(Net.TheVpc.Upa.Persistence.ContextOperation.FIND, hints));
            }
            if (query is Net.TheVpc.Upa.Expressions.Insert) {
                return GetEntityOperationManager().GetPersistOperation().CreateQuery(this, (Net.TheVpc.Upa.Expressions.Insert) query, CreateContext(Net.TheVpc.Upa.Persistence.ContextOperation.PERSIST, hints));
            }
            if (query is Net.TheVpc.Upa.Expressions.Update) {
                return GetEntityOperationManager().GetUpdateOperation().CreateQuery(this, (Net.TheVpc.Upa.Expressions.Update) query, CreateContext(Net.TheVpc.Upa.Persistence.ContextOperation.UPDATE, hints));
            }
            if (query is Net.TheVpc.Upa.Expressions.Delete) {
                return GetEntityOperationManager().GetRemoveOperation().CreateQuery(this, (Net.TheVpc.Upa.Expressions.Delete) query, CreateContext(Net.TheVpc.Upa.Persistence.ContextOperation.REMOVE, hints));
            }
            throw new System.Exception("Not supported statement type " + query);
        }


        public virtual Net.TheVpc.Upa.Query CreateQuery(string query) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Expressions.Expression e = GetPersistenceUnit().GetExpressionManager().ParseExpression(query);
            if (!(e is Net.TheVpc.Upa.Expressions.QueryStatement)) {
                Net.TheVpc.Upa.Expressions.Select s = new Net.TheVpc.Upa.Expressions.Select();
                s.SetWhere(e);
                e = s;
            }
            return CreateQuery((Net.TheVpc.Upa.Expressions.QueryStatement) e);
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.PrimitiveField> GetPrimitiveFields(params string [] fieldNames) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (fieldNames == null) {
                return null;
            }
            if (fieldNames.Length == 0) {
                return ToPrimitiveFields<Net.TheVpc.Upa.EntityPart>(GetParts());
            }
            if (ContainsCompoundFields()) {
                System.Collections.Generic.IList<Net.TheVpc.Upa.PrimitiveField> v = new System.Collections.Generic.List<Net.TheVpc.Upa.PrimitiveField>(fieldNames.Length);
                foreach (string fieldName in fieldNames) {
                    Net.TheVpc.Upa.EntityPart entityPart = GetField(fieldName);
                    if (entityPart is Net.TheVpc.Upa.PrimitiveField) {
                        v.Add((Net.TheVpc.Upa.PrimitiveField) entityPart);
                    } else {
                        Net.TheVpc.Upa.CompoundField compoundField = (Net.TheVpc.Upa.CompoundField) entityPart;
                        System.Collections.Generic.IList<Net.TheVpc.Upa.PrimitiveField> fds = compoundField.GetFields();
                        foreach (Net.TheVpc.Upa.PrimitiveField fd in fds) {
                            v.Add(fd);
                        }
                    }
                }
                return v;
            } else {
                System.Collections.Generic.IList<Net.TheVpc.Upa.PrimitiveField> v = new System.Collections.Generic.List<Net.TheVpc.Upa.PrimitiveField>(fieldNames.Length);
                foreach (string fieldName in fieldNames) {
                    v.Add(GetPrimitiveField(fieldName));
                }
                return v;
            }
        }


        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Field> GetValidFields(params string [] fieldNames) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.List<Net.TheVpc.Upa.Field> found = new System.Collections.Generic.List<Net.TheVpc.Upa.Field>();
            foreach (string field in fieldNames) {
                Net.TheVpc.Upa.Field f = FindField(field);
                if (f != null) {
                    found.Add(f);
                }
            }
            return found;
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Field> GetFields(params string [] fieldNames) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (fieldNames == null) {
                return null;
            }
            if (fieldNames.Length == 0) {
                return GetFields(GetParts());
            }
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> flds = new System.Collections.Generic.List<Net.TheVpc.Upa.Field>(fieldNames.Length);
            foreach (string fieldName in fieldNames) {
                flds.Add(GetField(fieldName));
            }
            return flds;
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Field> GetFields() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetFields(GetParts());
        }


        public virtual Net.TheVpc.Upa.UpdateQuery CreateUpdateQuery() {
            return new Net.TheVpc.Upa.Impl.DefaultUpdateQuery(this);
        }

        public virtual long Update(Net.TheVpc.Upa.UpdateQuery updateQuery) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            bool updateSingleObject = false;
            System.Collections.Generic.IDictionary<string , object> hints = updateQuery.GetHints();
            //        UpdateConditionType updateConditionType = options.getUpdateConditionType();
            //        if(updateConditionType ==null /*|| updateConditionType==UpdateConditionType.DEFAULT*/){
            //            updateConditionType =
            //        }
            object updateCondition = updateQuery.GetUpdateCondition();
            object updatesValue = updateQuery.GetValues();
            Net.TheVpc.Upa.Filters.FieldFilter formulaFields = updateQuery.GetFormulaFields();
            Net.TheVpc.Upa.Expressions.Expression whereExpression = ObjToExpression(updateQuery.GetUpdateConditionType(), updateCondition);
            object idToUpdate = GetBuilder().ObjectToId(updatesValue);
            Net.TheVpc.Upa.Expressions.Expression idExpression = null;
            if (idToUpdate != null) {
                idExpression = GetBuilder().IdToExpression(idToUpdate, null);
                updateSingleObject = true;
            }
            if (updateQuery.GetUpdateConditionType() == default(Net.TheVpc.Upa.ConditionType)) {
                throw new Net.TheVpc.Upa.Exceptions.UPAException("MissingConditionType");
            }
            if (!updateSingleObject) {
                switch(updateQuery.GetUpdateConditionType()) {
                    case Net.TheVpc.Upa.ConditionType.ID:
                    case Net.TheVpc.Upa.ConditionType.KEY:
                        {
                            updateSingleObject = true;
                        }
                        break;
                    case Net.TheVpc.Upa.ConditionType.OBJECT:
                        {
                            object i2 = GetBuilder().ObjectToId(updateCondition);
                            updateSingleObject = i2 != null;
                        }
                        break;
                    case Net.TheVpc.Upa.ConditionType.RECORD:
                        {
                            object i2 = GetBuilder().RecordToId((Net.TheVpc.Upa.Record) updateCondition);
                            updateSingleObject = i2 != null;
                        }
                        break;
                    case Net.TheVpc.Upa.ConditionType.EXPRESSION:
                        {
                            if (updateCondition is Net.TheVpc.Upa.Expressions.IdExpression) {
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
                whereExpression = new Net.TheVpc.Upa.Expressions.And(idExpression, whereExpression);
            }
            if (updatesValue == null) {
                Net.TheVpc.Upa.Persistence.EntityExecutionContext executionContext = CreateContext(Net.TheVpc.Upa.Persistence.ContextOperation.VALIDATE, hints);
                //check if the is some formulas
                if (formulaFields == null) {
                    throw new Net.TheVpc.Upa.Exceptions.UPAException("NothingToUpdate");
                }
                return UpdateFormulasCore(formulaFields, whereExpression, executionContext);
            } else {
                Net.TheVpc.Upa.Persistence.EntityExecutionContext executionContext = CreateContext(Net.TheVpc.Upa.Persistence.ContextOperation.UPDATE, hints);
                Net.TheVpc.Upa.Record updates = null;
                if (updateQuery.GetUpdatedFields() != null && (updateQuery.GetUpdatedFields()).Count > 0) {
                    updates = GetBuilder().ObjectToRecord(updatesValue, updateQuery.GetUpdatedFields(), updateQuery.IsIgnoreUnspecified(), true);
                } else {
                    updates = GetBuilder().ObjectToRecord(updatesValue, updateQuery.IsIgnoreUnspecified());
                }
                if (formulaFields == null) {
                    formulaFields = (GetShield().IsUpdateFormulaOnUpdateSupported()) ? Net.TheVpc.Upa.Impl.Util.Filters.Fields2.UPDATE_FORMULA : null;
                }
                //if updates contain primary fields add them to condition
                //because primary fields are not updatable
                //one may use rename instead
                System.Collections.Generic.IList<Net.TheVpc.Upa.Field> extraConditions = new System.Collections.Generic.List<Net.TheVpc.Upa.Field>();
                System.Collections.Generic.IList<Net.TheVpc.Upa.Field> primaryFields = GetPrimaryFields();
                System.Collections.Generic.ISet<string> primaryFieldNames = new System.Collections.Generic.HashSet<string>();
                foreach (Net.TheVpc.Upa.Field field in primaryFields) {
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
                    Net.TheVpc.Upa.Record fieldNamesToUpdateMap = GetBuilder().CreateRecord();
                    System.Collections.Generic.ISet<string> cancelUpdates = new System.Collections.Generic.HashSet<string>();
                    //copy all but primary fields
                    foreach (System.Collections.Generic.KeyValuePair<string , object> ee in updates.EntrySet()) {
                        string fieldName = (ee).Key;
                        if (!primaryFieldNames.Contains(fieldName)) {
                            object @value = (ee).Value;
                            Net.TheVpc.Upa.Field field = GetField(fieldName);
                            ((Net.TheVpc.Upa.Impl.AbstractField) field).GetFieldPersister().PrepareFieldForUpdate(field, @value, updates, fieldNamesToUpdateMap, executionContext);
                        }
                    }
                    System.Collections.Generic.IList<Net.TheVpc.Upa.Field> storedFieldsToValidate = GetFields(formulaFields);
                    foreach (string f in cancelUpdates) {
                        fieldNamesToUpdateMap.Remove(f);
                    }
                    foreach (Net.TheVpc.Upa.Field field in storedFieldsToValidate) {
                        Net.TheVpc.Upa.Expressions.Expression expression = GetFieldExpression(field, false);
                        fieldNamesToUpdateMap.SetObject(field.GetName(), expression);
                    }
                    if (!fieldNamesToUpdateMap.IsEmpty()) {
                        recordListenerSupport.FireBeforeUpdate(fieldNamesToUpdateMap, whereExpression, executionContext);
                        r = UpdateCore(fieldNamesToUpdateMap, whereExpression, executionContext);
                        if (r > 0) {
                            Net.TheVpc.Upa.Impl.Persistence.FormulaUpdateProcessor p = new Net.TheVpc.Upa.Impl.Persistence.FormulaUpdateProcessor(false, storedFieldsToValidate, whereExpression, executionContext, this, GetEntityOperationManager());
                            p.UpdateFormulasCore();
                        }
                        recordListenerSupport.FireAfterUpdate(fieldNamesToUpdateMap, whereExpression, executionContext);
                    }
                } else {
                    Net.TheVpc.Upa.Record fieldNamesToUpdateMap = GetBuilder().CreateRecord();
                    foreach (System.Collections.Generic.KeyValuePair<string , object> ee in updates.EntrySet()) {
                        string fieldName = (ee).Key;
                        if (!primaryFieldNames.Contains(fieldName)) {
                            object @value = (ee).Value;
                            Net.TheVpc.Upa.Field field = GetField(fieldName);
                            ((Net.TheVpc.Upa.Impl.AbstractField) field).GetFieldPersister().PrepareFieldForUpdate(field, @value, updates, fieldNamesToUpdateMap, executionContext);
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
                    System.Collections.Generic.IList<Net.TheVpc.Upa.Field> fields = GetFields(Net.TheVpc.Upa.Impl.Util.Filters.Fields2.UPDATE_FORMULA);
                    if (fields != null && (fields).Count > 0) {
                        Net.TheVpc.Upa.Record generatedFormulas = CreateQueryBuilder().SetFieldFilter(Net.TheVpc.Upa.Filters.Fields.Regular().And(Net.TheVpc.Upa.Filters.Fields.ByList(fields))).GetRecord();
                        if (generatedFormulas != null) {
                            updates.SetAll(generatedFormulas);
                        }
                    }
                }
                return r;
            }
        }

        protected internal virtual int UpdateRecords(Net.TheVpc.Upa.Record updates, System.Collections.Generic.IList<Net.TheVpc.Upa.Field> storedFieldsToValidate, Net.TheVpc.Upa.Expressions.Expression updateCondition, System.Collections.Generic.IDictionary<string , object> hints) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            //if updates contain primary fields add them to condition
            //because primary fields are not updatable
            //one may use rename instead
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> extraConditions = new System.Collections.Generic.List<Net.TheVpc.Upa.Field>();
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> primaryFields = GetPrimaryFields();
            System.Collections.Generic.ISet<string> primaryFieldNames = new System.Collections.Generic.HashSet<string>();
            foreach (Net.TheVpc.Upa.Field field in primaryFields) {
                if (updates.IsSet(field.GetName())) {
                    extraConditions.Add(field);
                }
                primaryFieldNames.Add(field.GetName());
            }
            if ((extraConditions).Count == (primaryFields).Count) {
                //all primary are defined
                Net.TheVpc.Upa.Expressions.Expression expression = GetBuilder().IdToExpression(GetBuilder().RecordToId(updates), GetName());
                if (updateCondition == null || !updateCondition.IsValid()) {
                    updateCondition = expression;
                } else if (!expression.Equals(updateCondition)) {
                    updateCondition = new Net.TheVpc.Upa.Expressions.And(updateCondition, expression);
                }
            }
            updateCondition = ToIdListExpression(updateCondition);
            if (IsCheckSecurity()) {
                GetShield().CheckUpdate(updates, updateCondition);
            }
            //        Object transaction = getPersistenceUnit().getPersistenceStore().getConnection().tryBeginTransaction();
            //        boolean transactionSucceeded = false;
            //        try {
            Net.TheVpc.Upa.Persistence.EntityExecutionContext executionContext = CreateContext(Net.TheVpc.Upa.Persistence.ContextOperation.UPDATE, hints);
            int r = -1;
            if (storedFieldsToValidate != null) {
                Net.TheVpc.Upa.Record fieldNamesToUpdateMap = GetBuilder().CreateRecord();
                System.Collections.Generic.ISet<string> cancelUpdates = new System.Collections.Generic.HashSet<string>();
                //copy all but primary fields
                foreach (System.Collections.Generic.KeyValuePair<string , object> ee in updates.EntrySet()) {
                    string fieldName = (ee).Key;
                    if (!primaryFieldNames.Contains(fieldName)) {
                        object @value = (ee).Value;
                        Net.TheVpc.Upa.Field field = GetField(fieldName);
                        ((Net.TheVpc.Upa.Impl.AbstractField) field).GetFieldPersister().PrepareFieldForUpdate(field, @value, updates, fieldNamesToUpdateMap, executionContext);
                    }
                }
                foreach (string f in cancelUpdates) {
                    fieldNamesToUpdateMap.Remove(f);
                }
                foreach (Net.TheVpc.Upa.Field field in storedFieldsToValidate) {
                    Net.TheVpc.Upa.Expressions.Expression expression = GetFieldExpression(field, false);
                    fieldNamesToUpdateMap.SetObject(field.GetName(), expression);
                }
                if (!fieldNamesToUpdateMap.IsEmpty()) {
                    recordListenerSupport.FireBeforeUpdate(fieldNamesToUpdateMap, updateCondition, executionContext);
                    r = UpdateCore(fieldNamesToUpdateMap, updateCondition, executionContext);
                    if (r > 0) {
                        Net.TheVpc.Upa.Impl.Persistence.FormulaUpdateProcessor p = new Net.TheVpc.Upa.Impl.Persistence.FormulaUpdateProcessor(false, storedFieldsToValidate, updateCondition, executionContext, this, GetEntityOperationManager());
                        p.UpdateFormulasCore();
                    }
                    recordListenerSupport.FireAfterUpdate(fieldNamesToUpdateMap, updateCondition, executionContext);
                }
            } else {
                Net.TheVpc.Upa.Record fieldNamesToUpdateMap = GetBuilder().CreateRecord();
                foreach (System.Collections.Generic.KeyValuePair<string , object> ee in updates.EntrySet()) {
                    string fieldName = (ee).Key;
                    if (!primaryFieldNames.Contains(fieldName)) {
                        object @value = (ee).Value;
                        Net.TheVpc.Upa.Field field = GetField(fieldName);
                        ((Net.TheVpc.Upa.Impl.AbstractField) field).GetFieldPersister().PrepareFieldForUpdate(field, @value, updates, fieldNamesToUpdateMap, executionContext);
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

        protected internal virtual long UpdateFormulasCore(Net.TheVpc.Upa.Filters.FieldFilter fieldFilter, Net.TheVpc.Upa.Expressions.Expression expr, Net.TheVpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> noFields = Net.TheVpc.Upa.Impl.Util.PlatformUtils.EmptyList<T>();
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> fieldsToUpdate = fieldFilter != null ? (System.Collections.Generic.IList<Net.TheVpc.Upa.Field>) GetFields(fieldFilter) : noFields;
            bool persistContext = Net.TheVpc.Upa.Persistence.ContextOperation.PERSIST.Equals(context.GetOperation());
            //TODO this is a work around, those fields must be removed
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> fieldsToUpdate2 = new System.Collections.Generic.List<Net.TheVpc.Upa.Field>();
            foreach (Net.TheVpc.Upa.Field f in fieldsToUpdate) {
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
                fieldsToUpdate = GetFields(Net.TheVpc.Upa.Impl.Util.Filters.Fields2.UPDATE_FORMULA);
            }
            if ((fieldsToUpdate).Count > 0) {
                // System.out.println(getName()+".updateFormulas("+Arrays.asList(fieldsToUpdate)+","+expr+"){");
                // check ???
                bool doValidation = true;
                if (VALIDATE_IF_CHANGED) {
                    doValidation = false;
                    Net.TheVpc.Upa.Expressions.Expression newFieldsValuesExpression = null;
                    for (int i = 0; !doValidation && i < (fieldsToUpdate).Count; i++) {
                        Net.TheVpc.Upa.Field field = fieldsToUpdate[i];
                        Net.TheVpc.Upa.Formula f = persistContext ? field.GetPersistFormula() : field.GetUpdateFormula();
                        if ((f is Net.TheVpc.Upa.CustomUpdaterFormula) || (f is Net.TheVpc.Upa.CustomUpdaterFormula)) {
                            doValidation = true;
                            break;
                        }
                        Net.TheVpc.Upa.Expressions.Expression formExpr = GetFieldExpression(field, persistContext);
                        if (formExpr != null) {
                            // newFieldsValuesExpression.or(new
                            // Different(fieldsToUpdate.get(i).getName(),new
                            // UserExpression(fieldsToUpdate.get(i).getExpression())));
                            Net.TheVpc.Upa.Expressions.Expression e = new Net.TheVpc.Upa.Expressions.Not(new Net.TheVpc.Upa.Expressions.Or(new Net.TheVpc.Upa.Expressions.And(new Net.TheVpc.Upa.Expressions.Equals(new Net.TheVpc.Upa.Expressions.Var(field.GetName()), null), new Net.TheVpc.Upa.Expressions.Equals(formExpr, null)), new Net.TheVpc.Upa.Expressions.And(new Net.TheVpc.Upa.Expressions.Different(new Net.TheVpc.Upa.Expressions.Var(field.GetName()), null), new Net.TheVpc.Upa.Expressions.And(new Net.TheVpc.Upa.Expressions.Different(formExpr, null), new Net.TheVpc.Upa.Expressions.Equals(new Net.TheVpc.Upa.Expressions.Var(field.GetName()), formExpr)))));
                            newFieldsValuesExpression = newFieldsValuesExpression == null ? ((Net.TheVpc.Upa.Expressions.Expression)(e)) : new Net.TheVpc.Upa.Expressions.Or(newFieldsValuesExpression, e);
                        }
                    }
                    if (!doValidation) {
                        Net.TheVpc.Upa.Expressions.Expression exp2 = new Net.TheVpc.Upa.Expressions.And(expr, newFieldsValuesExpression);
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
                    Net.TheVpc.Upa.Record fieldNamesToUpdateMap = GetBuilder().CreateRecord();
                    foreach (Net.TheVpc.Upa.Field aFieldsToUpdate in fieldsToUpdate) {
                        Net.TheVpc.Upa.Formula formula = persistContext ? aFieldsToUpdate.GetPersistFormula() : aFieldsToUpdate.GetUpdateFormula();
                        Net.TheVpc.Upa.Expressions.Expression ee = null;
                        if (formula is Net.TheVpc.Upa.ExpressionFormula) {
                            ee = ((Net.TheVpc.Upa.ExpressionFormula) formula).GetExpression();
                        }
                        fieldNamesToUpdateMap.SetObject(aFieldsToUpdate.GetName(), ee);
                    }
                    // System.out.println(">>");
                    recordListenerSupport.FireBeforeFormulasUpdate(fieldNamesToUpdateMap, expr, context);
                    if (!persistContext) {
                        recordListenerSupport.FireBeforeUpdate(fieldNamesToUpdateMap, expr, context);
                    }
                    Net.TheVpc.Upa.Impl.Persistence.FormulaUpdateProcessor p = new Net.TheVpc.Upa.Impl.Persistence.FormulaUpdateProcessor(persistContext, fieldsToUpdate, expr, context, this, GetEntityOperationManager());
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

        public virtual Net.TheVpc.Upa.Expressions.Order GetUpdateFormulasOrder() {
            return null;
        }

        public virtual Net.TheVpc.Upa.Expressions.Order GetArchivingOrder() {
            //TODO fix me
            return null;
        }

        public virtual void SetArchivingOrder(Net.TheVpc.Upa.Expressions.Order order) {
        }

        public virtual Net.TheVpc.Upa.Field GetLeadingPrimaryField() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetPrimaryFields()[0];
        }

        public virtual System.Collections.Generic.IList<string> GetOrderedFields(string[] fields) {
            System.Collections.Generic.IComparer<string> c = new Net.TheVpc.Upa.Impl.EntityChildComparator(this);
            System.Collections.Generic.List<string> ts = new System.Collections.Generic.List<string>();
            Net.TheVpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(ts, new System.Collections.Generic.List<string>(fields));
            Net.TheVpc.Upa.Impl.FwkConvertUtils.ListSort(ts, c);
            return ts;
        }

        public virtual Net.TheVpc.Upa.Package GetParent() {
            return parent;
        }

        public virtual void SetParent(Net.TheVpc.Upa.Package parent) {
            this.parent = parent;
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression ToIdListExpression(Net.TheVpc.Upa.Expressions.Expression e) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (tuningMaxInline <= 0 || e == null || (e is Net.TheVpc.Upa.Expressions.IdExpression) || (e is Net.TheVpc.Upa.Expressions.IdCollectionExpression) || (e is Net.TheVpc.Upa.Expressions.IdEnumerationExpression)) {
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

        public virtual Net.TheVpc.Upa.Expressions.Order GetListOrder() {
            return listOrder;
        }

        public virtual void SetListOrder(Net.TheVpc.Upa.Expressions.Order listDefaultOrder) {
            this.listOrder = listDefaultOrder;
        }

        public virtual System.Type GetEntityType() {
            return entityType;
        }

        public virtual void SetEntityType(System.Type entityType) {
            this.entityType = entityType;
            if (typeof(Net.TheVpc.Upa.Record).IsAssignableFrom(entityType)) {
                entityBuilder.SetEntityFactory(new Net.TheVpc.Upa.Impl.EntitySubclassUnstructuredFactory(entityType, GetPersistenceUnit().GetFactory(), this));
            } else {
                entityBuilder.SetEntityFactory(new Net.TheVpc.Upa.Impl.EntityBeanFactory(this, GetPersistenceUnit().GetFactory()));
            }
        }

        public virtual Net.TheVpc.Upa.Impl.Config.Decorations.DecorationRepository GetDecorationRepository() {
            Net.TheVpc.Upa.Impl.DefaultPersistenceUnit persistenceUnit = (Net.TheVpc.Upa.Impl.DefaultPersistenceUnit) GetPersistenceUnit();
            return persistenceUnit.GetDecorationRepository();
        }

        public virtual System.Type GetIdType() {
            return idType;
        }

        public virtual void SetIdType(System.Type idType) {
            this.idType = idType;
            if (typeof(Net.TheVpc.Upa.Key).Equals(idType)) {
                entityBuilder.SetKeyFactory((Net.TheVpc.Upa.Impl.KeyFactory) new Net.TheVpc.Upa.Impl.KeyUnstructuredFactory(this));
            } else if (typeof(Net.TheVpc.Upa.Key).IsAssignableFrom(idType)) {
                entityBuilder.SetKeyFactory(new Net.TheVpc.Upa.Impl.KeySubclassUnstructuredFactory(Net.TheVpc.Upa.Impl.Util.PlatformBeanTypeRepository.GetInstance().GetBeanType(idType)));
            } else if ((Net.TheVpc.Upa.Impl.KeyTypeFactory.ACCEPTED_TYPES.Contains(idType))) {
                entityBuilder.SetKeyFactory(new Net.TheVpc.Upa.Impl.KeyTypeFactory(idType));
            } else {
                entityBuilder.SetKeyFactory(new Net.TheVpc.Upa.Impl.KeyBeanFactory(idType, this));
            }
        }


        public virtual Net.TheVpc.Upa.EntityBuilder GetBuilder() {
            return entityBuilder;
        }


        public virtual void AddExtensionDefinition(System.Type extensionType, Net.TheVpc.Upa.Extensions.EntityExtensionDefinition extensionObject) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Type entityExtensionSupportType = GetPersistenceUnit().GetEntityExtensionSupportType(extensionType);
            Net.TheVpc.Upa.Persistence.EntityExtension ess = (Net.TheVpc.Upa.Persistence.EntityExtension) GetPersistenceUnit().GetFactory().CreateObject<Net.TheVpc.Upa.Persistence.EntityExtension>(entityExtensionSupportType);
            ess.Install(this, entityOperationManager, extensionObject);
            extensionManager.AddEntityExtension(extensionType, entityExtensionSupportType, extensionObject, ess);
        }


        public virtual void RemoveExtensionDefinition(System.Type extensionType, Net.TheVpc.Upa.Extensions.EntityExtensionDefinition extensionObject) {
            extensionManager.RemoveEntityExtension(extensionType, extensionObject);
        }


        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Extensions.EntityExtensionDefinition> GetExtensionDefinitions() {
            return extensionManager.GetEntityExtensions();
        }


        public virtual  System.Collections.Generic.IList<S> GetExtensionDefinitions<S>(System.Type type) where  S : Net.TheVpc.Upa.Extensions.EntityExtensionDefinition {
            return extensionManager.GetEntityExtensions<S>(type);
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Persistence.EntityExtension> GetExtensions() {
            return extensionManager.GetEntityExtensionSupports();
        }

        public virtual  System.Collections.Generic.IList<S> GetExtensions<S>(System.Type type) where  S : Net.TheVpc.Upa.Persistence.EntityExtension {
            return extensionManager.GetEntityExtensionSupports<S>(type);
        }

        public virtual  S GetExtension<S>(System.Type type) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  where  S : Net.TheVpc.Upa.Persistence.EntityExtension {
            System.Collections.Generic.IList<S> list = GetExtensions<S>(type);
            if ((list.Count==0)) {
                throw new Net.TheVpc.Upa.Exceptions.UPAException("No such EntityExtensionSupport found " + type);
            }
            if ((list).Count != 1) {
                throw new Net.TheVpc.Upa.Exceptions.UPAException("Too Many EntitySpecSupports found " + type);
            }
            return list[0];
        }

        public virtual Net.TheVpc.Upa.Persistence.EntityOperationManager GetEntityOperationManager() {
            return entityOperationManager;
        }

        public virtual Net.TheVpc.Upa.EntityShield GetShield() {
            return shield;
        }

        public virtual void SetShield(Net.TheVpc.Upa.EntityShield shield) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            this.shield = shield;
            shield.Init(this);
        }


        public virtual Net.TheVpc.Upa.Key CreateKey(params object [] keyValues) {
            return GetBuilder().CreateKey(keyValues);
        }


        public virtual object CreateId(params object [] keyValues) {
            return GetBuilder().CreateId(keyValues);
        }


        public virtual Net.TheVpc.Upa.Record CreateRecord() {
            return GetBuilder().CreateRecord();
        }


        public virtual  R CreateObject<R>() {
            return GetBuilder().CreateObject<R>();
        }


        public virtual void AddDefinitionListener(Net.TheVpc.Upa.Callbacks.DefinitionListener interceptor) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            GetPersistenceUnit().AddDefinitionListener(GetName(), interceptor);
        }


        public virtual void RemoveDefinitionListener(Net.TheVpc.Upa.Callbacks.DefinitionListener interceptor) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            GetPersistenceUnit().RemoveDefinitionListener(GetName(), interceptor);
        }


        public virtual Net.TheVpc.Upa.EntityDescriptor GetEntityDescriptor() {
            return entityDescriptor;
        }

        public virtual void SetEntityDescriptor(Net.TheVpc.Upa.EntityDescriptor entityDescriptor) {
            this.entityDescriptor = entityDescriptor;
        }

        public virtual int ClearCore(Net.TheVpc.Upa.Persistence.EntityExecutionContext executionContext) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Persistence.EntityOperationManager pm = GetEntityOperationManager();
            Net.TheVpc.Upa.Persistence.EntityClearOperation a = pm.GetClearOperation();
            if (a != null) {
                return a.Clear(this, executionContext);
            }
            return 0;
        }


        public virtual int InitializeCore(Net.TheVpc.Upa.Persistence.EntityExecutionContext executionContext) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Persistence.EntityOperationManager pm = GetEntityOperationManager();
            Net.TheVpc.Upa.Persistence.EntityInitializeOperation a = pm.GetInitializeOperation();
            if (a != null) {
                return a.Initialize(this, executionContext);
            }
            return 0;
        }


        public override void Close() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            foreach (Net.TheVpc.Upa.EntityPart item in items) {
                item.Close();
            }
            this.closed = true;
        }

        public virtual bool IsClosed() {
            return closed;
        }

        private Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> Copy(Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> e, params Net.TheVpc.Upa.UserFieldModifier [] others) {
            if (e == null) {
                e = Net.TheVpc.Upa.FlagSets.NoneOf<Net.TheVpc.Upa.UserFieldModifier>();
            }
            e = e.AddAll(new System.Collections.Generic.List<Net.TheVpc.Upa.UserFieldModifier>(others));
            return e;
        }

        public virtual object Compile(Net.TheVpc.Upa.Expressions.Expression expression) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Persistence.ExpressionCompilerConfig config = new Net.TheVpc.Upa.Persistence.ExpressionCompilerConfig();
            config.SetThisAlias("upathis");
            config.SetExpandEntityFilter(false);
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect compiledSelect = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect) GetPersistenceUnit().GetExpressionManager().CompileExpression(new Net.TheVpc.Upa.Expressions.Select().From(GetName(), "upathis").Field(expression), config);
            return compiledSelect.GetField(0).GetExpression();
        }

        private System.Collections.Generic.ISet<Net.TheVpc.Upa.Field> FindUsedFields(Net.TheVpc.Upa.Formula f) {
            System.Collections.Generic.ISet<Net.TheVpc.Upa.Field> usedFields = new System.Collections.Generic.HashSet<Net.TheVpc.Upa.Field>();
            if (f is Net.TheVpc.Upa.ExpressionFormula) {
                Net.TheVpc.Upa.ExpressionFormula expressionFormula = (Net.TheVpc.Upa.ExpressionFormula) f;
                Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression compiledExpression = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) Compile(expressionFormula.GetExpression());
                compiledExpression.Visit(new Net.TheVpc.Upa.Impl.FieldCollectorCompiledExpressionVisitor(usedFields));
            }
            return usedFields;
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Relationship> GetRelationships() {
            System.Collections.Generic.HashSet<Net.TheVpc.Upa.Relationship> relations = new System.Collections.Generic.HashSet<Net.TheVpc.Upa.Relationship>();
            foreach (Net.TheVpc.Upa.Relationship r in GetPersistenceUnit().GetRelationshipsBySource(this)) {
                relations.Add(r);
            }
            foreach (Net.TheVpc.Upa.Relationship r in GetPersistenceUnit().GetRelationshipsByTarget(this)) {
                relations.Add(r);
            }
            return new System.Collections.Generic.List<Net.TheVpc.Upa.Relationship>(relations);
        }


        public virtual void AddFilter(string name, Net.TheVpc.Upa.Expressions.Expression expression) {
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


        public virtual Net.TheVpc.Upa.Expressions.Expression GetFilter(string name) {
            Net.TheVpc.Upa.Expressions.Expression expression = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.TheVpc.Upa.Expressions.Expression>(objectfilters,name);
            if (expression == null) {
                throw new System.ArgumentException ("Object Filter Not Found " + name);
            }
            return expression;
        }


        public virtual void AddFilter(string name, string expression) {
            AddFilter(name, expression == null ? null : GetPersistenceUnit().GetExpressionManager().ParseExpression(expression));
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Section> GetSections() {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Section> sections = new System.Collections.Generic.List<Net.TheVpc.Upa.Section>();
            foreach (Net.TheVpc.Upa.EntityPart part in GetParts()) {
                if (part is Net.TheVpc.Upa.Section) {
                    sections.Add((Net.TheVpc.Upa.Section) part);
                }
            }
            return sections;
        }

        public virtual bool IsSystem() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetModifiers().Contains(Net.TheVpc.Upa.EntityModifier.SYSTEM);
        }

        public virtual  T FindById<T>(object id) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceUnit().FindById<T>(GetName(), id);
        }


        public virtual bool ExistsById(object id) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceUnit().ExistsById(GetName(), id);
        }

        public virtual  System.Collections.Generic.IList<T> FindAll<T>() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceUnit().FindAll<T>(GetName());
        }


        public virtual  System.Collections.Generic.IList<T> FindAllIds<T>() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceUnit().FindAllIds<T>(GetName());
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Record> FindAllRecords(object id) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceUnit().FindAllRecords(GetName());
        }

        public virtual  T FindByMainField<T>(object mainFieldValue) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceUnit().FindByMainField<T>(GetName(), mainFieldValue);
        }

        public virtual  T FindByField<T>(string fieldName, object mainFieldValue) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceUnit().FindByField<T>(GetName(), fieldName, mainFieldValue);
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Record> FindAllRecords() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceUnit().FindAllRecords(GetName());
        }

        public virtual Net.TheVpc.Upa.EntitySecurityManager GetEntitySecurityManager() {
            return entitySecurityManager;
        }

        public virtual void SetEntitySecurityManager(Net.TheVpc.Upa.EntitySecurityManager entitySecurityManager) {
            this.entitySecurityManager = entitySecurityManager;
        }


        public virtual Net.TheVpc.Upa.BeanType GetBeanType() {
            if (beanType == null) {
                if (typeof(Net.TheVpc.Upa.Record).Equals(GetEntityType())) {
                    beanType = new Net.TheVpc.Upa.Impl.Util.RecordBeanType(this);
                } else if (typeof(Net.TheVpc.Upa.Record).IsAssignableFrom(GetEntityType())) {
                    beanType = new Net.TheVpc.Upa.Impl.Util.CustomRecordBeanType(this, GetEntityType());
                } else {
                    beanType = new Net.TheVpc.Upa.Impl.Util.EntityBeanType(this);
                }
            }
            return beanType;
        }
    }
}
