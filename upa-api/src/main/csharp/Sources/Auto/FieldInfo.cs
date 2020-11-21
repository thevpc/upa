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

    public abstract class FieldInfo : Net.TheVpc.Upa.EntityPartInfo {

        private Net.TheVpc.Upa.DataTypeInfo dataType;

        private string kind;

        private Net.TheVpc.Upa.PropertyAccessType propertyAccessType;

        private Net.TheVpc.Upa.AccessLevel persistAccessLevel;

        private Net.TheVpc.Upa.AccessLevel updateAccessLevel;

        private Net.TheVpc.Upa.AccessLevel readAccessLevel;

        private Net.TheVpc.Upa.ProtectionLevel persistProtectionLevel;

        private Net.TheVpc.Upa.ProtectionLevel updateProtectionLevel;

        private Net.TheVpc.Upa.ProtectionLevel readProtectionLevel;

        private Net.TheVpc.Upa.AccessLevel effectivePersistAccessLevel;

        private Net.TheVpc.Upa.AccessLevel effectiveUpdateAccessLevel;

        private Net.TheVpc.Upa.AccessLevel effectiveReadAccessLevel;

        private Net.TheVpc.Upa.FieldModifier[] modifiers;

        private bool id;

        private bool main;

        private bool system;

        private bool summary;

        private bool manyToOne;

        private bool generatedId;

        private string manyToOneRelationship;

        public FieldInfo(string kind)  : base("field"){

            this.kind = kind;
        }

        public virtual string GetKind() {
            return kind;
        }

        public virtual void SetKind(string kind) {
        }

        public virtual Net.TheVpc.Upa.DataTypeInfo GetDataType() {
            return dataType;
        }

        public virtual void SetDataType(Net.TheVpc.Upa.DataTypeInfo dataType) {
            this.dataType = dataType;
        }

        public virtual Net.TheVpc.Upa.PropertyAccessType GetPropertyAccessType() {
            return propertyAccessType;
        }

        public virtual void SetPropertyAccessType(Net.TheVpc.Upa.PropertyAccessType propertyAccessType) {
            this.propertyAccessType = propertyAccessType;
        }

        public virtual Net.TheVpc.Upa.AccessLevel GetPersistAccessLevel() {
            return persistAccessLevel;
        }

        public virtual void SetPersistAccessLevel(Net.TheVpc.Upa.AccessLevel persistAccessLevel) {
            this.persistAccessLevel = persistAccessLevel;
        }

        public virtual Net.TheVpc.Upa.AccessLevel GetUpdateAccessLevel() {
            return updateAccessLevel;
        }

        public virtual void SetUpdateAccessLevel(Net.TheVpc.Upa.AccessLevel updateAccessLevel) {
            this.updateAccessLevel = updateAccessLevel;
        }

        public virtual Net.TheVpc.Upa.AccessLevel GetReadAccessLevel() {
            return readAccessLevel;
        }

        public virtual void SetReadAccessLevel(Net.TheVpc.Upa.AccessLevel readAccessLevel) {
            this.readAccessLevel = readAccessLevel;
        }

        public virtual Net.TheVpc.Upa.FieldModifier[] GetModifiers() {
            return modifiers;
        }

        public virtual void SetModifiers(Net.TheVpc.Upa.FieldModifier[] modifiers) {
            this.modifiers = modifiers;
        }

        public virtual bool IsId() {
            return id;
        }

        public virtual void SetId(bool id) {
            this.id = id;
        }

        public virtual bool IsMain() {
            return main;
        }

        public virtual void SetMain(bool main) {
            this.main = main;
        }

        public virtual bool IsSummary() {
            return summary;
        }

        public virtual void SetSummary(bool summary) {
            this.summary = summary;
        }

        public virtual bool IsManyToOne() {
            return manyToOne;
        }

        public virtual void SetManyToOne(bool manyToOne) {
            this.manyToOne = manyToOne;
        }

        public virtual bool IsGeneratedId() {
            return generatedId;
        }

        public virtual void SetGeneratedId(bool generatedId) {
            this.generatedId = generatedId;
        }

        public virtual string GetManyToOneRelationship() {
            return manyToOneRelationship;
        }

        public virtual void SetManyToOneRelationship(string manyToOneRelationship) {
            this.manyToOneRelationship = manyToOneRelationship;
        }

        public virtual Net.TheVpc.Upa.ProtectionLevel GetPersistProtectionLevel() {
            return persistProtectionLevel;
        }

        public virtual void SetPersistProtectionLevel(Net.TheVpc.Upa.ProtectionLevel persistProtectionLevel) {
            this.persistProtectionLevel = persistProtectionLevel;
        }

        public virtual Net.TheVpc.Upa.ProtectionLevel GetUpdateProtectionLevel() {
            return updateProtectionLevel;
        }

        public virtual void SetUpdateProtectionLevel(Net.TheVpc.Upa.ProtectionLevel updateProtectionLevel) {
            this.updateProtectionLevel = updateProtectionLevel;
        }

        public virtual Net.TheVpc.Upa.ProtectionLevel GetReadProtectionLevel() {
            return readProtectionLevel;
        }

        public virtual void SetReadProtectionLevel(Net.TheVpc.Upa.ProtectionLevel readProtectionLevel) {
            this.readProtectionLevel = readProtectionLevel;
        }

        public virtual Net.TheVpc.Upa.AccessLevel GetEffectivePersistAccessLevel() {
            return effectivePersistAccessLevel;
        }

        public virtual void SetEffectivePersistAccessLevel(Net.TheVpc.Upa.AccessLevel effectivePersistAccessLevel) {
            this.effectivePersistAccessLevel = effectivePersistAccessLevel;
        }

        public virtual Net.TheVpc.Upa.AccessLevel GetEffectiveUpdateAccessLevel() {
            return effectiveUpdateAccessLevel;
        }

        public virtual void SetEffectiveUpdateAccessLevel(Net.TheVpc.Upa.AccessLevel effectiveUpdateAccessLevel) {
            this.effectiveUpdateAccessLevel = effectiveUpdateAccessLevel;
        }

        public virtual Net.TheVpc.Upa.AccessLevel GetEffectiveReadAccessLevel() {
            return effectiveReadAccessLevel;
        }

        public virtual void SetEffectiveReadAccessLevel(Net.TheVpc.Upa.AccessLevel effectiveReadAccessLevel) {
            this.effectiveReadAccessLevel = effectiveReadAccessLevel;
        }

        public virtual bool IsSystem() {
            return system;
        }

        public virtual void SetSystem(bool system) {
            this.system = system;
        }
    }
}
