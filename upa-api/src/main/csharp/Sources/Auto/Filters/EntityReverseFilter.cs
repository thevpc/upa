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



namespace Net.Vpc.Upa.Filters
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class EntityReverseFilter : Net.Vpc.Upa.Filters.AbstractRichEntityFilter {

        private Net.Vpc.Upa.Filters.EntityFilter @base;

        public EntityReverseFilter(Net.Vpc.Upa.Filters.EntityFilter @base) {
            this.@base = @base;
        }

        public override bool Accept(Net.Vpc.Upa.Entity entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return !@base.Accept(entity);
        }
    }
}
