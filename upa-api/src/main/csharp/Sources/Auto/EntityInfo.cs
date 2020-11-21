/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE HAS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.TheVpc.Upa
{


    public class EntityInfo : Net.TheVpc.Upa.PersistenceUnitPartInfo {

        private System.Collections.Generic.IList<Net.TheVpc.Upa.EntityPartInfo> children;

        private Net.TheVpc.Upa.EntityModifier[] modifiers;

        private bool hierarchical;

        private bool hasAssociatedView;

        private bool system;

        private bool singleton;

        private bool union;

        private bool view;

        private string[] manyToOneRelationships;

        private string[] oneToManyRelationships;

        private System.Collections.Generic.IList<Net.TheVpc.Upa.IndexInfo> indexes;

        private string compositionRelationship;

        private string parentEntity;

        public EntityInfo()  : base("entity"){

        }

        public virtual bool IsSingleton() {
            return singleton;
        }

        public virtual void SetSingleton(bool singleton) {
            this.singleton = singleton;
        }

        public virtual bool IsUnion() {
            return union;
        }

        public virtual void SetUnion(bool union) {
            this.union = union;
        }

        public virtual bool IsView() {
            return view;
        }

        public virtual void SetView(bool view) {
            this.view = view;
        }

        public virtual Net.TheVpc.Upa.EntityModifier[] GetModifiers() {
            return modifiers;
        }

        public virtual void SetModifiers(Net.TheVpc.Upa.EntityModifier[] modifiers) {
            this.modifiers = modifiers;
        }

        public virtual bool IsHierarchical() {
            return hierarchical;
        }

        public virtual void SetHierarchical(bool hierarchical) {
            this.hierarchical = hierarchical;
        }

        public virtual bool IsHasAssociatedView() {
            return hasAssociatedView;
        }

        public virtual void SetHasAssociatedView(bool hasAssociatedView) {
            this.hasAssociatedView = hasAssociatedView;
        }

        public virtual bool IsSystem() {
            return system;
        }

        public virtual void SetSystem(bool system) {
            this.system = system;
        }

        public virtual string[] GetManyToOneRelationships() {
            return manyToOneRelationships;
        }

        public virtual void SetManyToOneRelationships(string[] manyToOneRelationships) {
            this.manyToOneRelationships = manyToOneRelationships;
        }

        public virtual string[] GetOneToManyRelationships() {
            return oneToManyRelationships;
        }

        public virtual void SetOneToManyRelationships(string[] oneToManyRelationships) {
            this.oneToManyRelationships = oneToManyRelationships;
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.IndexInfo> GetIndexes() {
            return indexes;
        }

        public virtual void SetIndexes(System.Collections.Generic.IList<Net.TheVpc.Upa.IndexInfo> indexes) {
            this.indexes = indexes;
        }

        public virtual string GetCompositionRelationship() {
            return compositionRelationship;
        }

        public virtual void SetCompositionRelationship(string compositionRelationship) {
            this.compositionRelationship = compositionRelationship;
        }

        public virtual string GetParentEntity() {
            return parentEntity;
        }

        public virtual void SetParentEntity(string parentEntity) {
            this.parentEntity = parentEntity;
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.EntityPartInfo> GetChildren() {
            return children;
        }

        public virtual void SetChildren(System.Collections.Generic.IList<Net.TheVpc.Upa.EntityPartInfo> children) {
            this.children = children;
        }
    }
}
