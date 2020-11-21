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



namespace Net.TheVpc.Upa.Filters
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class EntityNameFilter : Net.TheVpc.Upa.Filters.AbstractRichEntityFilter {

        private System.Collections.Generic.ISet<string> names;

        public EntityNameFilter(System.Collections.Generic.ICollection<string> names) {
            this.names = new System.Collections.Generic.HashSet<string>(names);
        }

        public override bool Accept(Net.TheVpc.Upa.Entity entity) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return names.Contains(entity.GetName());
        }
    }
}
