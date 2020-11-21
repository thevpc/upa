/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.context;

import net.thevpc.upa.UPAContext;
import net.thevpc.upa.UPAContextProvider;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class DefaultUPAContextProvider implements UPAContextProvider {

    private static UPAContext instance;

    public UPAContext getContext() {
        return instance;
    }

    public void setContext(UPAContext newInstance) {
        instance = newInstance;
    }

    @Override
    public void close() {
        if (instance != null) {
            instance.close();
            DefaultUPAContextProvider.instance = null;
        }
    }

}
