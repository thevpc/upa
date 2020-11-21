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
    public class SecurityManagerEntityConfigurator : Net.TheVpc.Upa.Impl.Config.EntityConfigurator {

        private Net.TheVpc.Upa.EntitySecurityManager s;

        public SecurityManagerEntityConfigurator(Net.TheVpc.Upa.EntitySecurityManager s) {
            this.s = s;
        }

        public virtual void Install(Net.TheVpc.Upa.Entity e) {
            e.SetEntitySecurityManager(s);
        }

        public virtual void Uninstall(Net.TheVpc.Upa.Entity e) {
        }
    }
}
