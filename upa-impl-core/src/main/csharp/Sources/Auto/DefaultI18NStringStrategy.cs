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



namespace Net.TheVpc.Upa.Impl
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class DefaultI18NStringStrategy : Net.TheVpc.Upa.I18NStringStrategy {

        private Net.TheVpc.Upa.Types.I18NString Key(string s) {
            return s == null ? new Net.TheVpc.Upa.Types.I18NString("*") : new Net.TheVpc.Upa.Types.I18NString(s, "*");
        }

        public virtual Net.TheVpc.Upa.Types.I18NString GetPackageString(Net.TheVpc.Upa.Package module) {
            return new Net.TheVpc.Upa.Types.I18NString("Package").Append(Key(module == null ? null : module.GetPath()));
        }

        public virtual Net.TheVpc.Upa.Types.I18NString GetSectionString(Net.TheVpc.Upa.Entity entity, string section) {
            return GetEntityString(entity).Append("Section").Append(Key(section));
        }

        public virtual Net.TheVpc.Upa.Types.I18NString GetRelationshipRoleString(Net.TheVpc.Upa.RelationshipRole role) {
            switch(role.GetRelationshipRoleType()) {
                case Net.TheVpc.Upa.RelationshipRoleType.TARGET:
                    {
                        return GetRelationshipString(role.GetRelationship()).Append("Target");
                    }
                case Net.TheVpc.Upa.RelationshipRoleType.SOURCE:
                    {
                        return GetRelationshipString(role.GetRelationship()).Append("Source");
                    }
            }
            return GetRelationshipString(role.GetRelationship()).Append(Key(null));
        }

        public virtual Net.TheVpc.Upa.Types.I18NString GetRelationshipString(Net.TheVpc.Upa.Relationship relation) {
            Net.TheVpc.Upa.Types.I18NString r = new Net.TheVpc.Upa.Types.I18NString("Relationship");
            r = r.Append(Key(relation.GetName()));
            r = r.Append(Key(relation.GetSourceEntity().GetName()));
            r = r.Append(Key(relation.GetTargetEntity().GetName()));
            return r;
        }

        public virtual Net.TheVpc.Upa.Types.I18NString GetEntityString(Net.TheVpc.Upa.Entity entity) {
            return new Net.TheVpc.Upa.Types.I18NString("Entity").Append(Key(entity == null ? null : entity.GetName()));
        }

        public virtual Net.TheVpc.Upa.Types.I18NString GetFieldListString(Net.TheVpc.Upa.Entity entity) {
            return GetEntityString(entity).Append("Field");
        }

        public virtual Net.TheVpc.Upa.Types.I18NString GetFieldString(Net.TheVpc.Upa.Field field) {
            Net.TheVpc.Upa.Entity entityName = (field != null) ? (field.GetEntity() != null) ? field.GetEntity() : field.GetEntity() : null;
            string fieldName = (field != null) ? field.GetName() : null;
            return GetFieldListString(entityName).Append(Key(fieldName));
        }
    }
}
