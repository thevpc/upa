/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.web;

import java.util.HashMap;
import java.util.Map;
import javax.servlet.ServletContext;
import net.thevpc.upa.PersistenceGroup;
import net.thevpc.upa.PersistenceUnitProvider;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class WebServletContextPersistenceUnitProvider implements PersistenceUnitProvider {
    public String getPersistenceUnitName(PersistenceGroup persistenceGroup) {
        return getMap().get(persistenceGroup.getName());
    }

    public void setPersistenceUnitName(PersistenceGroup persistenceGroup, String persistenceUnit) {
        String k = persistenceGroup.getName();
        if(persistenceUnit==null){
            getMap().remove(k);
        }else{
            getMap().put(k, persistenceUnit);
        }
    }

    private static Map<String,String> getMap(){
        ServletContext servletContext = WebUPAContext.getSafeWebUPAContext().getServletContext();
        Map<String, String> v = (Map<String, String>)servletContext.getAttribute(WebServletContextPersistenceUnitProvider.class.getName());
        if(v==null){
            v=new HashMap<String, String>(3);
            servletContext.setAttribute(WebServletContextPersistenceUnitProvider.class.getName(),v);
        }
        return v;
    }
    
}
