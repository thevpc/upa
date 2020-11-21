/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.web;

import net.thevpc.upa.UPAContext;
import net.thevpc.upa.UPAContextProvider;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class WebUPAContextProvider implements UPAContextProvider {

    public UPAContext getContext() {
        return (UPAContext) WebUPAContext.getApplicationAttribute(UPAContext.class.getName());
    }

    public void setContext(UPAContext newInstance) {
        WebUPAContext.setApplicationAttribute(UPAContext.class.getName(), newInstance);
    }

    @Override
    public void close() {
        UPAContext c=(UPAContext) WebUPAContext.getApplicationAttribute(UPAContext.class.getName());
        if(c!=null){
            c.close();
        }
        WebUPAContext.setApplicationAttribute(UPAContext.class.getName(), null);
    }
    

}
