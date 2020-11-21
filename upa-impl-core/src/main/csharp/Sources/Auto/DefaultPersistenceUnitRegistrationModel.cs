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


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class DefaultPersistenceUnitRegistrationModel : Net.TheVpc.Upa.Impl.ObjectRegistrationModel {

        private System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Entity> entities = new System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Entity>();

        private System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Package> packages = new System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Package>();

        private System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Relationship> relations = new System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Relationship>();

        private System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Index> indexes = new System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Index>();

        private System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Field> fields = new System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Field>();

        private System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Section> sections = new System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Section>();

        private Net.TheVpc.Upa.Impl.DefaultPersistenceUnit unit;

        private System.Collections.Generic.HashSet<System.Type> entityManagerByEntityTypeAmbiguity = new System.Collections.Generic.HashSet<System.Type>();

        private System.Collections.Generic.Dictionary<System.Type , Net.TheVpc.Upa.Entity> entityManagerByEntityType = new System.Collections.Generic.Dictionary<System.Type , Net.TheVpc.Upa.Entity>();

        private System.Collections.Generic.HashSet<System.Type> entityManagerByIdTypeAmbiguity = new System.Collections.Generic.HashSet<System.Type>();

        private System.Collections.Generic.Dictionary<System.Type , Net.TheVpc.Upa.Entity> entityManagerByIdType = new System.Collections.Generic.Dictionary<System.Type , Net.TheVpc.Upa.Entity>();

        private System.Collections.Generic.IDictionary<string , System.Collections.Generic.IList<Net.TheVpc.Upa.Index>> indexesByEntity = new System.Collections.Generic.Dictionary<string , System.Collections.Generic.IList<Net.TheVpc.Upa.Index>>();

        public DefaultPersistenceUnitRegistrationModel(Net.TheVpc.Upa.Impl.DefaultPersistenceUnit unit) {
            this.unit = unit;
        }

        public virtual void RegisterPackage(Net.TheVpc.Upa.Package item, Net.TheVpc.Upa.Package parent) {
            string s = null;
            if (parent == null) {
                s = "/" + item.GetName();
            } else {
                s = parent.GetPath() + "/" + item.GetName();
            }
            packages[s]=item;
        }

        public virtual bool ContainsPackage(Net.TheVpc.Upa.Package item, Net.TheVpc.Upa.Package parent) {
            string s = null;
            if (parent == null) {
                s = "/" + item.GetName();
            } else {
                s = parent.GetPath() + "/" + item.GetName();
            }
            return (packages.ContainsKey(s));
        }

        public virtual void UnregisterPackage(Net.TheVpc.Upa.Package item) {
            string s = item.GetPath();
            packages.Remove(s);
        }

        public virtual bool ContainsEntity(Net.TheVpc.Upa.Entity item, Net.TheVpc.Upa.Package parent) {
            Net.TheVpc.Upa.NamingStrategy namingStrategy = unit.GetNamingStrategy();
            string s = item.GetName();
            s = namingStrategy.GetUniformValue(s);
            return (entities.ContainsKey(s));
        }

        public virtual void RegisterEntity(Net.TheVpc.Upa.Entity item, Net.TheVpc.Upa.Package parent) {
            Net.TheVpc.Upa.NamingStrategy namingStrategy = unit.GetNamingStrategy();
            string s = item.GetName();
            s = namingStrategy.GetUniformValue(s);
            Net.TheVpc.Upa.Entity entity = (Net.TheVpc.Upa.Entity) item;
            entities[s]=item;
            System.Type entityType = entity.GetEntityType();
            if (!entityManagerByEntityTypeAmbiguity.Contains(entityType)) {
                if (entityManagerByEntityType.ContainsKey(entityType)) {
                    entityManagerByEntityType.Remove(entityType);
                    entityManagerByEntityTypeAmbiguity.Add(entityType);
                } else {
                    entityManagerByEntityType[entityType]=entity;
                }
            }
            System.Type idType = Net.TheVpc.Upa.Impl.Util.PlatformUtils.ToRefType(entity.GetIdType());
            if (!entityManagerByIdTypeAmbiguity.Contains(idType)) {
                if (entityManagerByIdType.ContainsKey(idType)) {
                    entityManagerByIdType.Remove(idType);
                    entityManagerByIdTypeAmbiguity.Add(idType);
                } else {
                    entityManagerByIdType[idType]=entity;
                }
            }
        }

        public virtual void UnregisterEntity(Net.TheVpc.Upa.Entity item) {
            string s = item.GetName();
            s = unit.GetNamingStrategy().GetUniformValue(s);
            entities.Remove(s);
        }

        public virtual void RegisterSection(Net.TheVpc.Upa.Section item) {
            Net.TheVpc.Upa.Entity entity = item.GetEntity();
            Net.TheVpc.Upa.Package module = entity.GetParent();
            string s = (module == null ? "/" : module.GetPath() + "/") + entity.GetName() + "/" + item.GetPath();
            sections[s]=item;
        }

        public virtual bool ContainsSection(Net.TheVpc.Upa.Section item) {
            Net.TheVpc.Upa.Entity entity = item.GetEntity();
            Net.TheVpc.Upa.Package module = entity.GetParent();
            string s = (module == null ? "/" : module.GetPath() + "/") + entity.GetName() + "/" + item.GetPath();
            return (sections.ContainsKey(s));
        }

        public virtual void UnregisterSection(Net.TheVpc.Upa.Section item) {
            Net.TheVpc.Upa.Entity entity = item.GetEntity();
            Net.TheVpc.Upa.Package module = entity.GetParent();
            string s = (module == null ? "/" : module.GetPath() + "/") + entity.GetName() + "/" + item.GetPath();
            sections.Remove(s);
        }

        public virtual void RegisterField(Net.TheVpc.Upa.Field item) {
            Net.TheVpc.Upa.Impl.DefaultEntity entity = (Net.TheVpc.Upa.Impl.DefaultEntity) item.GetEntity();
            Net.TheVpc.Upa.Package module = entity.GetParent();
            string s = (module == null ? "/" : module.GetPath() + "/") + entity.GetName() + "/" + item.GetName();
            fields[s]=item;
            entity.fieldsMap[entity.GetPersistenceUnit().GetNamingStrategy().GetUniformValue(item.GetName())]=(Net.TheVpc.Upa.Field) item;
        }

        public virtual void UnregisterField(Net.TheVpc.Upa.Field item) {
            Net.TheVpc.Upa.Entity entity = item.GetEntity();
            Net.TheVpc.Upa.Package module = entity.GetParent();
            string s = (module == null ? "/" : module.GetPath() + "/") + entity.GetName() + "/" + item.GetName();
            fields.Remove(s);
        }

        public virtual void RegisterIndex(Net.TheVpc.Upa.Index item, Net.TheVpc.Upa.Entity entity) {
            string s = item.GetName();
            indexes[s]=item;
            System.Collections.Generic.IList<Net.TheVpc.Upa.Index> indexesByEnt = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,System.Collections.Generic.IList<Net.TheVpc.Upa.Index>>(indexesByEntity,item.GetEntity().GetName());
            if (indexesByEnt == null) {
                indexesByEnt = new System.Collections.Generic.List<Net.TheVpc.Upa.Index>();
                indexesByEntity[item.GetEntity().GetName()]=indexesByEnt;
            }
            indexesByEnt.Add(item);
        }

        public virtual void UnregisterIndex(Net.TheVpc.Upa.Index item) {
            string s = item.GetName();
            indexes.Remove(s);
            System.Collections.Generic.IList<Net.TheVpc.Upa.Index> indexesByEnt = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,System.Collections.Generic.IList<Net.TheVpc.Upa.Index>>(indexesByEntity,item.GetEntity().GetName());
            indexesByEnt.Remove(item);
        }

        public virtual void RegisterRelationship(Net.TheVpc.Upa.Relationship item) {
            string s = item.GetName();
            relations[s]=item;
        }

        public virtual bool ContainsRelationship(Net.TheVpc.Upa.Relationship item) {
            string s = item.GetName();
            return (relations.ContainsKey(s));
        }

        public virtual void UnregisterRelation(Net.TheVpc.Upa.Relationship item) {
            string s = item.GetName();
            relations.Remove(s);
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Entity> GetEntities() {
            return new System.Collections.Generic.List<Net.TheVpc.Upa.Entity>((entities).Values);
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Index> GetIndexes() {
            return new System.Collections.Generic.List<Net.TheVpc.Upa.Index>((indexes).Values);
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Package> GetPackages() {
            return new System.Collections.Generic.List<Net.TheVpc.Upa.Package>((packages).Values);
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Relationship> GetRelationships() {
            return new System.Collections.Generic.List<Net.TheVpc.Upa.Relationship>((relations).Values);
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Field> GetFields() {
            return new System.Collections.Generic.List<Net.TheVpc.Upa.Field>((fields).Values);
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Index> GetIndexes(string entityName) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Index> a = new System.Collections.Generic.List<Net.TheVpc.Upa.Index>();
            System.Collections.Generic.IList<Net.TheVpc.Upa.Index> currIndexes = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,System.Collections.Generic.IList<Net.TheVpc.Upa.Index>>(indexesByEntity,entityName);
            if (currIndexes != null) {
                foreach (Net.TheVpc.Upa.Index index in currIndexes) {
                    a.Add(index);
                }
            }
            return a;
        }

        public virtual Net.TheVpc.Upa.Index GetIndex(string name) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Index item = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.TheVpc.Upa.Index>(indexes,name);
            if (item == null) {
                throw new Net.TheVpc.Upa.Exceptions.NoSuchIndexException(null, name, null);
            }
            return item;
        }

        public virtual Net.TheVpc.Upa.Entity GetEntity(string name) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.NamingStrategy namingStrategy = unit.GetNamingStrategy();
            string s = name;
            name = namingStrategy.GetUniformValue(s);
            Net.TheVpc.Upa.Entity item = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.TheVpc.Upa.Entity>(entities,name);
            if (item == null) {
                throw new Net.TheVpc.Upa.Exceptions.NoSuchEntityException(s, null);
            }
            return item;
        }

        public virtual Net.TheVpc.Upa.Entity FindEntity(string name) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.NamingStrategy namingStrategy = unit.GetNamingStrategy();
            string s = name;
            name = namingStrategy.GetUniformValue(s);
            return Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.TheVpc.Upa.Entity>(entities,name);
        }

        public virtual Net.TheVpc.Upa.Relationship FindRelationship(string name) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.TheVpc.Upa.Relationship>(relations,name);
        }

        public virtual Net.TheVpc.Upa.Relationship GetRelationship(string name) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Relationship item = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.TheVpc.Upa.Relationship>(relations,name);
            if (item == null) {
                throw new Net.TheVpc.Upa.Exceptions.NoSuchRelationshipException(name, null);
            }
            return item;
        }

        public virtual Net.TheVpc.Upa.Entity GetEntityByIdType(System.Type idType) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            idType = Net.TheVpc.Upa.Impl.Util.PlatformUtils.ToRefType(idType);
            Net.TheVpc.Upa.Entity entity = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,Net.TheVpc.Upa.Entity>(entityManagerByIdType,idType);
            if (entity != null) {
                return entity;
            }
            if (entityManagerByIdTypeAmbiguity.Contains(idType)) {
                throw new Net.TheVpc.Upa.Exceptions.MultipleEntityMatchForTypeException(entityManagerByIdTypeAmbiguity.ToArray()[0], new string[0]);
            }
            throw new Net.TheVpc.Upa.Exceptions.NoSuchEntityException((idType).FullName, null);
        }

        public virtual bool ContainsField(Net.TheVpc.Upa.Field item) {
            Net.TheVpc.Upa.Entity entity = item.GetEntity();
            Net.TheVpc.Upa.Package module = entity.GetParent();
            string s = (module == null ? "/" : module.GetPath() + "/") + entity.GetName() + "/" + item.GetName();
            return (fields.ContainsKey(s));
        }

        public virtual bool ContainsEntity(string entityName) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return entities.ContainsKey(entityName);
        }

        public virtual bool ContainsEntity(System.Type entityType) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Entity entityManager = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,Net.TheVpc.Upa.Entity>(entityManagerByEntityType,entityType);
            if (entityManager != null) {
                return true;
            }
            if (entityManagerByEntityTypeAmbiguity.Contains(entityType)) {
                System.Collections.Generic.HashSet<string> entityNamesSet = new System.Collections.Generic.HashSet<string>();
                foreach (Net.TheVpc.Upa.Entity entity in GetEntities()) {
                    if (entity.GetEntityType().Equals(entityType)) {
                        entityNamesSet.Add(entity.GetName());
                    }
                }
                return true;
            }
            return false;
        }

        public virtual bool ContainsIndex(Net.TheVpc.Upa.Index item, Net.TheVpc.Upa.Entity parent) {
            return indexes.ContainsKey(item.GetName());
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Entity> FindEntities(System.Type entityType) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Entity> all = new System.Collections.Generic.List<Net.TheVpc.Upa.Entity>();
            if (entityType == null) {
                return all;
            }
            Net.TheVpc.Upa.Entity entityManager = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,Net.TheVpc.Upa.Entity>(entityManagerByEntityType,entityType);
            if (entityManager != null) {
                all.Add(entityManager);
            }
            if (entityManagerByEntityTypeAmbiguity.Contains(entityType)) {
                foreach (Net.TheVpc.Upa.Entity entity in GetEntities()) {
                    if (entity.GetEntityType().Equals(entityType) && (entityManager == null || !entity.GetName().Equals(entityManager.GetName()))) {
                        all.Add(entity);
                    }
                }
            }
            return all;
        }

        public virtual Net.TheVpc.Upa.Entity FindEntity(System.Type entityType) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (entityType == null) {
                return null;
            }
            Net.TheVpc.Upa.Entity entityManager = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,Net.TheVpc.Upa.Entity>(entityManagerByEntityType,entityType);
            if (entityManager != null) {
                return entityManager;
            }
            if (entityManagerByEntityTypeAmbiguity.Contains(entityType)) {
                System.Collections.Generic.HashSet<string> entityNames = new System.Collections.Generic.HashSet<string>();
                foreach (Net.TheVpc.Upa.Entity entity in GetEntities()) {
                    if (entity.GetEntityType().Equals(entityType)) {
                        entityNames.Add(entity.GetName());
                    }
                }
                throw new Net.TheVpc.Upa.Exceptions.MultipleEntityMatchForTypeException(entityType, entityNames.ToArray());
            }
            return null;
        }

        public virtual Net.TheVpc.Upa.Entity GetEntity(System.Type entityType) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Entity e = FindEntity(entityType);
            if (e == null) {
                throw new Net.TheVpc.Upa.Exceptions.NoSuchEntityException(entityType == null ? "<null>" : (entityType).FullName, null);
            }
            return e;
        }
    }
}
