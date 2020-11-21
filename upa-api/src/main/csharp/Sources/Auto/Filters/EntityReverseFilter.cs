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
    public class EntityReverseFilter : Net.TheVpc.Upa.Filters.AbstractRichEntityFilter {

        private Net.TheVpc.Upa.Filters.EntityFilter @base;

        public EntityReverseFilter(Net.TheVpc.Upa.Filters.EntityFilter @base) {
            this.@base = @base;
        }

        public override bool Accept(Net.TheVpc.Upa.Entity entity) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return !@base.Accept(entity);
        }
    }
}
