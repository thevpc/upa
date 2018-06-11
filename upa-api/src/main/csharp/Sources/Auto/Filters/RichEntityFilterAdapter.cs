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
     * @author taha.bensalah@gmail.com on 7/31/16.
     */
    internal class RichEntityFilterAdapter : Net.Vpc.Upa.Filters.AbstractRichEntityFilter {

        private Net.Vpc.Upa.Filters.EntityFilter other;

        public RichEntityFilterAdapter(Net.Vpc.Upa.Filters.EntityFilter other) {
            if (other == null) {
                throw new System.NullReferenceException();
            }
            this.other = other;
        }


        public override bool Accept(Net.Vpc.Upa.Entity entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return other.Accept(entity);
        }
    }
}
