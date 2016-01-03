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
     * @author vpc
     */
    public class DecoratedMethodScan {

        private Net.Vpc.Upa.Config.Decoration decoration;

        private System.Reflection.MethodInfo method;

        public DecoratedMethodScan(Net.Vpc.Upa.Config.Decoration decoration, System.Reflection.MethodInfo method) {
            this.decoration = decoration;
            this.method = method;
        }

        public virtual Net.Vpc.Upa.Config.Decoration GetDecoration() {
            return decoration;
        }

        public virtual System.Reflection.MethodInfo GetMethod() {
            return method;
        }
    }
}
