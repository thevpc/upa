/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.web;

import java.util.HashMap;
import java.util.Map;
import javax.servlet.ServletContext;
import net.vpc.upa.PersistenceGroup;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.PersistenceUnitProvider;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class WebServletContextPersistenceUnitProvider implements PersistenceUnitProvider {
    public PersistenceUnit getPersistenceUnit(PersistenceGroup persistenceGroup) {
        String p = getMap().get(String.valueOf(System.identityHashCode(persistenceGroup)));
        return p==null?null:persistenceGroup.getPersistenceUnit(p);
    }

    public void setPersistenceUnit(PersistenceGroup persistenceGroup, PersistenceUnit persistenceUnit) {
        String k = String.valueOf(System.identityHashCode(persistenceGroup));
        if(persistenceUnit==null){
            getMap().remove(k);
        }else{
            getMap().put(k, persistenceUnit.getName());
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
