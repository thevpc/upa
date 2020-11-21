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
    public class DecoratedMethodScan {

        private Net.TheVpc.Upa.Config.Decoration decoration;

        private System.Reflection.MethodInfo method;

        public DecoratedMethodScan(Net.TheVpc.Upa.Config.Decoration decoration, System.Reflection.MethodInfo method) {
            this.decoration = decoration;
            this.method = method;
        }

        public virtual Net.TheVpc.Upa.Config.Decoration GetDecoration() {
            return decoration;
        }

        public virtual System.Reflection.MethodInfo GetMethod() {
            return method;
        }
    }
}
