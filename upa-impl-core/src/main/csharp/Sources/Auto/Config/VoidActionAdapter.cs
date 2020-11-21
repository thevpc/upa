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



namespace Net.TheVpc.Upa.Impl.Config
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public class VoidActionAdapter : Net.TheVpc.Upa.Action<object> {

        private Net.TheVpc.Upa.VoidAction action;

        public VoidActionAdapter(Net.TheVpc.Upa.VoidAction action) {
            this.action = action;
        }


        public virtual object Run() {
            action.Run();
            return null;
        }
    }
}
