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
    public class SecurityManagerEntityConfigurator : Net.Vpc.Upa.Impl.Config.EntityConfigurator {

        private Net.Vpc.Upa.EntitySecurityManager s;

        public SecurityManagerEntityConfigurator(Net.Vpc.Upa.EntitySecurityManager s) {
            this.s = s;
        }

        public virtual void Install(Net.Vpc.Upa.Entity e) {
            e.SetEntitySecurityManager(s);
        }

        public virtual void Uninstall(Net.Vpc.Upa.Entity e) {
        }
    }
}
