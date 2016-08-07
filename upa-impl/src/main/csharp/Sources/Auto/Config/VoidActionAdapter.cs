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



namespace Net.Vpc.Upa.Impl.Config
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public class VoidActionAdapter : Net.Vpc.Upa.Action<object> {

        private Net.Vpc.Upa.VoidAction action;

        public VoidActionAdapter(Net.Vpc.Upa.VoidAction action) {
            this.action = action;
        }


        public virtual object Run() {
            action.Run();
            return null;
        }
    }
}
