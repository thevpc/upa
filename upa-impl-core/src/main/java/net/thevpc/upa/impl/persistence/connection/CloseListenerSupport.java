package net.thevpc.upa.impl.persistence.connection;

import net.thevpc.upa.CloseListener;

import java.util.ArrayList;
import java.util.List;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 11/24/12 8:43 AM
 */
public class CloseListenerSupport {
    private List<CloseListener> closeListeners;
    public void addCloseListener(CloseListener closeListener){
        if(closeListeners ==null){
            closeListeners =new ArrayList<CloseListener>();
        }
        closeListeners.add(closeListener);
    }

    public void removeCloseListener(CloseListener closeListener){
        if(closeListeners !=null){
            closeListeners.remove(closeListener);
        }
    }

    public void beforeClose(Object source){
        List<CloseListener> all = closeListeners;
        if(all!=null){
            for (CloseListener closeListener : all.toArray(new CloseListener[all.size()])) {
                closeListener.beforeClose(source);
            }
        }
    }

    public void afterClose(Object source){
        List<CloseListener> all = closeListeners;
        if(all!=null){
            for (CloseListener closeListener : all.toArray(new CloseListener[all.size()])) {
                closeListener.afterClose(source);
            }
        }
    }
}
