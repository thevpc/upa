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


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class DefaultPersistenceUnitRegistrationModel : Net.Vpc.Upa.Impl.ObjectRegistrationModel {

        private System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Entity> entities = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Entity>();

        private System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Package> packages = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Package>();

        private System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Relationship> relations = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Relationship>();

        private System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Index> indexes = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Index>();

        private System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Field> fields = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Field>();

        private System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Section> sections = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Section>();

        private Net.Vpc.Upa.Impl.DefaultPersistenceUnit unit;

        private System.Collections.Generic.HashSet<System.Type> entityManagerByEntityTypeAmbiguity = new System.Collections.Generic.HashSet<System.Type>();

        private System.Collections.Generic.Dictionary<System.Type , Net.Vpc.Upa.Entity> entityManagerByEntityType = new System.Collections.Generic.Dictionary<System.Type , Net.Vpc.Upa.Entity>();

        private System.Collections.Generic.HashSet<System.Type> entityManagerByIdTypeAmbiguity = new System.Collections.Generic.HashSet<System.Type>();

        private System.Collections.Generic.Dictionary<System.Type , Net.Vpc.Upa.Entity> entityManagerByIdType = new System.Collections.Generic.Dictionary<System.Type , Net.Vpc.Upa.Entity>();

        private System.Collections.Generic.IDictionary<string , System.Collections.Generic.IList<Net.Vpc.Upa.Index>> indexesByEntity = new System.Collections.Generic.Dictionary<string , System.Collections.Generic.IList<Net.Vpc.Upa.Index>>();

        public DefaultPersistenceUnitRegistrationModel(Net.Vpc.Upa.Impl.DefaultPersistenceUnit unit) {
            this.unit = unit;
        }

        public virtual void RegisterPackage(Net.Vpc.Upa.Package item, Net.Vpc.Upa.Package parent) {
            string s = null;
            if (parent == null) {
                s = "/" + item.GetName();
            } else {
                s = parent.GetPath() + "/" + item.GetName();
            }
            packages[s]=item;
        }

        public virtual bool ContainsPackage(Net.Vpc.Upa.Package item, Net.Vpc.Upa.Package parent) {
            string s = null;
            if (parent == null) {
                s = "/" + item.GetName();
            } else {
                s = parent.GetPath() + "/" + item.GetName();
            }
            return (packages.ContainsKey(s));
        }

        public virtual void UnregisterPackage(Net.Vpc.Upa.Package item) {
            string s = item.GetPath();
            packages.Remove(s);
        }

        public virtual bool ContainsEntity(Net.Vpc.Upa.Entity item, Net.Vpc.Upa.Package parent) {
            Net.Vpc.Upa.NamingStrategy namingStrategy = unit.GetNamingStrategy();
            string s = item.GetName();
            s = namingStrategy.GetUniformValue(s);
            return (entities.ContainsKey(s));
        }

        public virtual void RegisterEntity(Net.Vpc.Upa.Entity item, Net.Vpc.Upa.Package parent) {
            Net.Vpc.Upa.NamingStrategy namingStrategy = unit.GetNamingStrategy();
            string s = item.GetName();
            s = namingStrategy.GetUniformValue(s);
            Net.Vpc.Upa.Entity entity = (Net.Vpc.Upa.Entity) item;
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
            System.Type idType = Net.Vpc.Upa.Impl.Util.PlatformUtils.ToRefType(entity.GetIdType());
            if (!entityManagerByIdTypeAmbiguity.Contains(idType)) {
                if (entityManagerByIdType.ContainsKey(idType)) {
                    entityManagerByIdType.Remove(idType);
                    entityManagerByIdTypeAmbiguity.Add(idType);
                } else {
                    entityManagerByIdType[idType]=entity;
                }
            }
        }

        public virtual void UnregisterEntity(Net.Vpc.Upa.Entity item) {
            string s = item.GetName();
            s = unit.GetNamingStrategy().GetUniformValue(s);
            entities.Remove(s);
        }

        public virtual void RegisterSection(Net.Vpc.Upa.Section item) {
            Net.Vpc.Upa.Entity entity = item.GetEntity();
            Net.Vpc.Upa.Package module = entity.GetParent();
            string s = (module == null ? "/" : module.GetPath() + "/") + entity.GetName() + "/" + item.GetPath();
            sections[s]=item;
        }

        public virtual bool ContainsSection(Net.Vpc.Upa.Section item) {
            Net.Vpc.Upa.Entity entity = item.GetEntity();
            Net.Vpc.Upa.Package module = entity.GetParent();
            string s = (module == null ? "/" : module.GetPath() + "/") + entity.GetName() + "/" + item.GetPath();
            return (sections.ContainsKey(s));
        }

        public virtual void UnregisterSection(Net.Vpc.Upa.Section item) {
            Net.Vpc.Upa.Entity entity = item.GetEntity();
            Net.Vpc.Upa.Package module = entity.GetParent();
            string s = (module == null ? "/" : module.GetPath() + "/") + entity.GetName() + "/" + item.GetPath();
            sections.Remove(s);
        }

        public virtual void RegisterField(Net.Vpc.Upa.Field item) {
            Net.Vpc.Upa.Impl.DefaultEntity entity = (Net.Vpc.Upa.Impl.DefaultEntity) item.GetEntity();
            Net.Vpc.Upa.Package module = entity.GetParent();
            string s = (module == null ? "/" : module.GetPath() + "/") + entity.GetName() + "/" + item.GetName();
            fields[s]=item;
            entity.fieldsMap[entity.GetPersistenceUnit().GetNamingStrategy().GetUniformValue(item.GetName())]=(Net.Vpc.Upa.Field) item;
        }

        public virtual void UnregisterField(Net.Vpc.Upa.Field item) {
            Net.Vpc.Upa.Entity entity = item.GetEntity();
            Net.Vpc.Upa.Package module = entity.GetParent();
            string s = (module == null ? "/" : module.GetPath() + "/") + entity.GetName() + "/" + item.GetName();
            fields.Remove(s);
        }

        public virtual void RegisterIndex(Net.Vpc.Upa.Index item, Net.Vpc.Upa.Entity entity) {
            string s = item.GetName();
            indexes[s]=item;
            System.Collections.Generic.IList<Net.Vpc.Upa.Index> indexesByEnt = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,System.Collections.Generic.IList<Net.Vpc.Upa.Index>>(indexesByEntity,item.GetEntity().GetName());
            if (indexesByEnt == null) {
                indexesByEnt = new System.Collections.Generic.List<Net.Vpc.Upa.Index>();
                indexesByEntity[item.GetEntity().GetName()]=indexesByEnt;
            }
            indexesByEnt.Add(item);
        }

        public virtual void UnregisterIndex(Net.Vpc.Upa.Index item) {
            string s = item.GetName();
            indexes.Remove(s);
            System.Collections.Generic.IList<Net.Vpc.Upa.Index> indexesByEnt = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,System.Collections.Generic.IList<Net.Vpc.Upa.Index>>(indexesByEntity,item.GetEntity().GetName());
            indexesByEnt.Remove(item);
        }

        public virtual void RegisterRelationship(Net.Vpc.Upa.Relationship item) {
            string s = item.GetName();
            relations[s]=item;
        }

        public virtual bool ContainsRelationship(Net.Vpc.Upa.Relationship item) {
            string s = item.GetName();
            return (relations.ContainsKey(s));
        }

        public virtual void UnregisterRelation(Net.Vpc.Upa.Relationship item) {
            string s = item.GetName();
            relations.Remove(s);
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Entity> GetEntities() {
            return new System.Collections.Generic.List<Net.Vpc.Upa.Entity>((entities).Values);
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Index> GetIndexes() {
            return new System.Collections.Generic.List<Net.Vpc.Upa.Index>((indexes).Values);
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Package> GetPackages() {
            return new System.Collections.Generic.List<Net.Vpc.Upa.Package>((packages).Values);
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Relationship> GetRelationships() {
            return new System.Collections.Generic.List<Net.Vpc.Upa.Relationship>((relations).Values);
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Field> GetFields() {
            return new System.Collections.Generic.List<Net.Vpc.Upa.Field>((fields).Values);
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Index> GetIndexes(string entityName) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.Vpc.Upa.Index> a = new System.Collections.Generic.List<Net.Vpc.Upa.Index>();
            System.Collections.Generic.IList<Net.Vpc.Upa.Index> currIndexes = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,System.Collections.Generic.IList<Net.Vpc.Upa.Index>>(indexesByEntity,entityName);
            if (currIndexes != null) {
                foreach (Net.Vpc.Upa.Index index in currIndexes) {
                    a.Add(index);
                }
            }
            return a;
        }

        public virtual Net.Vpc.Upa.Index GetIndex(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Index item = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.Vpc.Upa.Index>(indexes,name);
            if (item == null) {
                throw new Net.Vpc.Upa.Exceptions.NoSuchIndexException(null, name, null);
            }
            return item;
        }

        public virtual Net.Vpc.Upa.Entity GetEntity(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.NamingStrategy namingStrategy = unit.GetNamingStrategy();
            string s = name;
            name = namingStrategy.GetUniformValue(s);
            Net.Vpc.Upa.Entity item = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.Vpc.Upa.Entity>(entities,name);
            if (item == null) {
                throw new Net.Vpc.Upa.Exceptions.NoSuchEntityException(s, null);
            }
            return item;
        }

        public virtual Net.Vpc.Upa.Entity FindEntity(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.NamingStrategy namingStrategy = unit.GetNamingStrategy();
            string s = name;
            name = namingStrategy.GetUniformValue(s);
            return Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.Vpc.Upa.Entity>(entities,name);
        }

        public virtual Net.Vpc.Upa.Relationship FindRelationship(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.Vpc.Upa.Relationship>(relations,name);
        }

        public virtual Net.Vpc.Upa.Relationship GetRelationship(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Relationship item = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.Vpc.Upa.Relationship>(relations,name);
            if (item == null) {
                throw new Net.Vpc.Upa.Exceptions.NoSuchRelationshipException(name, null);
            }
            return item;
        }

        public virtual Net.Vpc.Upa.Entity GetEntityByIdType(System.Type idType) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            idType = Net.Vpc.Upa.Impl.Util.PlatformUtils.ToRefType(idType);
            Net.Vpc.Upa.Entity entity = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,Net.Vpc.Upa.Entity>(entityManagerByIdType,idType);
            if (entity != null) {
                return entity;
            }
            if (entityManagerByIdTypeAmbiguity.Contains(idType)) {
                throw new Net.Vpc.Upa.Exceptions.MultipleEntityMatchForTypeException(entityManagerByIdTypeAmbiguity.ToArray()[0], new string[0]);
            }
            throw new Net.Vpc.Upa.Exceptions.NoSuchEntityException((idType).FullName, null);
        }

        public virtual bool ContainsField(Net.Vpc.Upa.Field item) {
            Net.Vpc.Upa.Entity entity = item.GetEntity();
            Net.Vpc.Upa.Package module = entity.GetParent();
            string s = (module == null ? "/" : module.GetPath() + "/") + entity.GetName() + "/" + item.GetName();
            return (fields.ContainsKey(s));
        }

        public virtual bool ContainsEntity(string entityName) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entities.ContainsKey(entityName);
        }

        public virtual bool ContainsEntity(System.Type entityType) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Entity entityManager = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,Net.Vpc.Upa.Entity>(entityManagerByEntityType,entityType);
            if (entityManager != null) {
                return true;
            }
            if (entityManagerByEntityTypeAmbiguity.Contains(entityType)) {
                System.Collections.Generic.HashSet<string> entityNamesSet = new System.Collections.Generic.HashSet<string>();
                foreach (Net.Vpc.Upa.Entity entity in GetEntities()) {
                    if (entity.GetEntityType().Equals(entityType)) {
                        entityNamesSet.Add(entity.GetName());
                    }
                }
                return true;
            }
            return false;
        }

        public virtual bool ContainsIndex(Net.Vpc.Upa.Index item, Net.Vpc.Upa.Entity parent) {
            return indexes.ContainsKey(item.GetName());
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Entity> FindEntities(System.Type entityType) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.Vpc.Upa.Entity> all = new System.Collections.Generic.List<Net.Vpc.Upa.Entity>();
            if (entityType == null) {
                return all;
            }
            Net.Vpc.Upa.Entity entityManager = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,Net.Vpc.Upa.Entity>(entityManagerByEntityType,entityType);
            if (entityManager != null) {
                all.Add(entityManager);
            }
            if (entityManagerByEntityTypeAmbiguity.Contains(entityType)) {
                foreach (Net.Vpc.Upa.Entity entity in GetEntities()) {
                    if (entity.GetEntityType().Equals(entityType) && (entityManager == null || !entity.GetName().Equals(entityManager.GetName()))) {
                        all.Add(entity);
                    }
                }
            }
            return all;
        }

        public virtual Net.Vpc.Upa.Entity FindEntity(System.Type entityType) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (entityType == null) {
                return null;
            }
            Net.Vpc.Upa.Entity entityManager = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,Net.Vpc.Upa.Entity>(entityManagerByEntityType,entityType);
            if (entityManager != null) {
                return entityManager;
            }
            if (entityManagerByEntityTypeAmbiguity.Contains(entityType)) {
                System.Collections.Generic.HashSet<string> entityNames = new System.Collections.Generic.HashSet<string>();
                foreach (Net.Vpc.Upa.Entity entity in GetEntities()) {
                    if (entity.GetEntityType().Equals(entityType)) {
                        entityNames.Add(entity.GetName());
                    }
                }
                throw new Net.Vpc.Upa.Exceptions.MultipleEntityMatchForTypeException(entityType, entityNames.ToArray());
            }
            return null;
        }

        public virtual Net.Vpc.Upa.Entity GetEntity(System.Type entityType) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Entity e = FindEntity(entityType);
            if (e == null) {
                throw new Net.Vpc.Upa.Exceptions.NoSuchEntityException(entityType == null ? "<null>" : (entityType).FullName, null);
            }
            return e;
        }
    }
}
