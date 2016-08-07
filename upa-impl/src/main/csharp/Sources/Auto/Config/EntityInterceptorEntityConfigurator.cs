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
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class EntityInterceptorEntityConfigurator : Net.Vpc.Upa.Impl.Config.EntityConfigurator {

        private Net.Vpc.Upa.Callbacks.EntityInterceptor dataInterceptor;

        private string callbackName;

        private System.Collections.Generic.IList<Net.Vpc.Upa.Callbacks.Trigger> addedTriggers = new System.Collections.Generic.List<Net.Vpc.Upa.Callbacks.Trigger>();

        public EntityInterceptorEntityConfigurator(Net.Vpc.Upa.Callbacks.EntityInterceptor dataInterceptor, string callbackName) {
            this.dataInterceptor = dataInterceptor;
            this.callbackName = callbackName;
        }

        public virtual void Install(Net.Vpc.Upa.Entity e) {
            string cname = callbackName;
            if (Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.IsEmptyString(cname)) {
                cname = (dataInterceptor.GetType()).Name;
            }
            addedTriggers.Add(e.AddTrigger(cname, dataInterceptor));
        }

        public virtual void Uninstall(Net.Vpc.Upa.Entity e) {
            foreach (Net.Vpc.Upa.Callbacks.Trigger t in new System.Collections.Generic.List<Net.Vpc.Upa.Callbacks.Trigger>(addedTriggers)) {
                foreach (Net.Vpc.Upa.Callbacks.Trigger t2 in new System.Collections.Generic.List<Net.Vpc.Upa.Callbacks.Trigger>(e.GetTriggers())) {
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
