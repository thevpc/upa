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
     * @author taha.bensalah@gmail.com on 7/31/16.
     */
    internal class RichEntityFilterAdapter : Net.TheVpc.Upa.Filters.AbstractRichEntityFilter {

        private Net.TheVpc.Upa.Filters.EntityFilter other;

        public RichEntityFilterAdapter(Net.TheVpc.Upa.Filters.EntityFilter other) {
            if (other == null) {
                throw new System.NullReferenceException();
            }
            this.other = other;
        }


        public override bool Accept(Net.TheVpc.Upa.Entity entity) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return other.Accept(entity);
        }
    }
}
