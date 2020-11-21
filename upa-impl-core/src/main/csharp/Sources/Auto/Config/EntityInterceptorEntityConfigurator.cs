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
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class EntityInterceptorEntityConfigurator : Net.TheVpc.Upa.Impl.Config.EntityConfigurator {

        private Net.TheVpc.Upa.Callbacks.EntityInterceptor dataInterceptor;

        private string callbackName;

        private System.Collections.Generic.IList<Net.TheVpc.Upa.Callbacks.Trigger> addedTriggers = new System.Collections.Generic.List<Net.TheVpc.Upa.Callbacks.Trigger>();

        public EntityInterceptorEntityConfigurator(Net.TheVpc.Upa.Callbacks.EntityInterceptor dataInterceptor, string callbackName) {
            this.dataInterceptor = dataInterceptor;
            this.callbackName = callbackName;
        }

        public virtual void Install(Net.TheVpc.Upa.Entity e) {
            string cname = callbackName;
            if (Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.IsEmptyString(cname)) {
                cname = (dataInterceptor.GetType()).Name;
            }
            addedTriggers.Add(e.AddTrigger(cname, dataInterceptor));
        }

        public virtual void Uninstall(Net.TheVpc.Upa.Entity e) {
            foreach (Net.TheVpc.Upa.Callbacks.Trigger t in new System.Collections.Generic.List<Net.TheVpc.Upa.Callbacks.Trigger>(addedTriggers)) {
                foreach (Net.TheVpc.Upa.Callbacks.Trigger t2 in new System.Collections.Generic.List<Net.TheVpc.Upa.Callbacks.Trigger>(e.GetTriggers())) {
                    if (t.Equals(t2)) {
                        e.RemoveTrigger(t.GetName());
                        addedTriggers.Remove(t);
                        break;
                    }
                }
            }
        }
    }
}
