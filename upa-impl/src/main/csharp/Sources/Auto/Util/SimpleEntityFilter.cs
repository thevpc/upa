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



namespace Net.Vpc.Upa.Impl.Util
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public class SimpleEntityFilter : Net.Vpc.Upa.Filters.EntityFilter {

        private Net.Vpc.Upa.Filters.ObjectFilter<string> name;

        private bool includeSystem;

        public SimpleEntityFilter(Net.Vpc.Upa.Filters.ObjectFilter<string> name, bool includeSystem) {
            this.name = name;
            this.includeSystem = includeSystem;
        }

        public virtual bool Accept(Net.Vpc.Upa.Entity s) {
            if (s.GetModifiers().Contains(Net.Vpc.Upa.EntityModifier.SYSTEM)) {
                if (!includeSystem) {
                    return false;
                }
            }
            if (name != null) {
                if (!name.Accept(s.GetName())) {
                    return false;
                }
            }
            return true;
        }
    }
}
