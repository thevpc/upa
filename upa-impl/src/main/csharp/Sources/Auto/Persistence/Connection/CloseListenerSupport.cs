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



using System.Linq;
namespace Net.Vpc.Upa.Impl.Persistence.Connection
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/24/12 8:43 AM
     */
    public class CloseListenerSupport {

        private System.Collections.Generic.IList<Net.Vpc.Upa.CloseListener> closeListeners;

        public virtual void AddCloseListener(Net.Vpc.Upa.CloseListener closeListener) {
            if (closeListeners == null) {
                closeListeners = new System.Collections.Generic.List<Net.Vpc.Upa.CloseListener>();
            }
            closeListeners.Add(closeListener);
        }

        public virtual void RemoveCloseListener(Net.Vpc.Upa.CloseListener closeListener) {
            if (closeListeners != null) {
                closeListeners.Remove(closeListener);
            }
        }

        public virtual void BeforeClose(object source) {
            System.Collections.Generic.IList<Net.Vpc.Upa.CloseListener> all = closeListeners;
            if (all != null) {
                foreach (Net.Vpc.Upa.CloseListener closeListener in all.ToArray()) {
                    closeListener.BeforeClose(source);
                }
            }
        }

        public virtual void AfterClose(object source) {
            System.Collections.Generic.IList<Net.Vpc.Upa.CloseListener> all = closeListeners;
            if (all != null) {
                foreach (Net.Vpc.Upa.CloseListener closeListener in all.ToArray()) {
                    closeListener.AfterClose(source);
                }
            }
        }
    }
}
