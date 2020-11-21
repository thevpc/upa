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



namespace Net.TheVpc.Upa.Impl.Util
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public class SimpleEntityFilter : Net.TheVpc.Upa.Filters.EntityFilter {

        private Net.TheVpc.Upa.Filters.ObjectFilter<string> name;

        private bool includeSystem;

        public SimpleEntityFilter(Net.TheVpc.Upa.Filters.ObjectFilter<string> name, bool includeSystem) {
            this.name = name;
            this.includeSystem = includeSystem;
        }

        public virtual bool Accept(Net.TheVpc.Upa.Entity s) {
            if (s.GetModifiers().Contains(Net.TheVpc.Upa.EntityModifier.SYSTEM)) {
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
