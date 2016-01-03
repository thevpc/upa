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



namespace Net.Vpc.Upa.Impl
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class DefaultI18NStringStrategy : Net.Vpc.Upa.I18NStringStrategy {

        private Net.Vpc.Upa.Types.I18NString Key(string s) {
            return s == null ? new Net.Vpc.Upa.Types.I18NString("*") : new Net.Vpc.Upa.Types.I18NString(s, "*");
        }

        public virtual Net.Vpc.Upa.Types.I18NString GetPackageString(Net.Vpc.Upa.Package module) {
            return new Net.Vpc.Upa.Types.I18NString("Package").Append(Key(module == null ? null : module.GetPath()));
        }

        public virtual Net.Vpc.Upa.Types.I18NString GetSectionString(Net.Vpc.Upa.Entity entity, string section) {
            return GetEntityString(entity).Append("Section").Append(Key(section));
        }

        public virtual Net.Vpc.Upa.Types.I18NString GetRelationshipRoleString(Net.Vpc.Upa.RelationshipRole role) {
            switch(role.GetRelationshipRoleType()) {
                case Net.Vpc.Upa.RelationshipRoleType.TARGET:
                    {
                        return GetRelationshipString(role.GetRelationship()).Append("Target");
                    }
                case Net.Vpc.Upa.RelationshipRoleType.SOURCE:
                    {
                        return GetRelationshipString(role.GetRelationship()).Append("Source");
                    }
            }
            return GetRelationshipString(role.GetRelationship()).Append(Key(null));
        }

        public virtual Net.Vpc.Upa.Types.I18NString GetRelationshipString(Net.Vpc.Upa.Relationship relation) {
            Net.Vpc.Upa.Types.I18NString r = new Net.Vpc.Upa.Types.I18NString("Relationship");
            r = r.Append(Key(relation.GetName()));
            r = r.Append(Key(relation.GetSourceEntity().GetName()));
            r = r.Append(Key(relation.GetTargetEntity().GetName()));
            return r;
        }

        public virtual Net.Vpc.Upa.Types.I18NString GetEntityString(Net.Vpc.Upa.Entity entity) {
            return new Net.Vpc.Upa.Types.I18NString("Entity").Append(Key(entity == null ? null : entity.GetName()));
        }

        public virtual Net.Vpc.Upa.Types.I18NString GetFieldListString(Net.Vpc.Upa.Entity entity) {
            return GetEntityString(entity).Append("Field");
        }

        public virtual Net.Vpc.Upa.Types.I18NString GetFieldString(Net.Vpc.Upa.Field field) {
            Net.Vpc.Upa.Entity entityName = (field != null) ? (field.GetEntity() != null) ? field.GetEntity() : field.GetEntity() : null;
            string fieldName = (field != null) ? field.GetName() : null;
            return GetFieldListString(entityName).Append(Key(fieldName));
        }
    }
}
