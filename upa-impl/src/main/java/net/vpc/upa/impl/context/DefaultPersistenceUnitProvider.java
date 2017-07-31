package net.vpc.upa.impl.context;

import net.vpc.upa.PersistenceGroup;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.PersistenceUnitProvider;

import java.util.HashMap;
import java.util.Map;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/12/12 12:14 AM
 */
public class DefaultPersistenceUnitProvider implements PersistenceUnitProvider {
    private static ThreadLocal<Map<String,String>> current=new ThreadLocal<Map<String, String>>();

    @Override
    public String getPersistenceUnitName(PersistenceGroup persistenceGroup) {
        return getMap().get(persistenceGroup.getName());
    }

    @Override
    public void setPersistenceUnitName(PersistenceGroup persistenceGroup, String persistenceUnit) {
        String k = String.valueOf(persistenceGroup.getName());
        if(persistenceUnit==null){
            getMap().remove(k);
        }else{
            getMap().put(k, persistenceUnit);
        }
    }

    private static Map<String,String> getMap(){
        Map<String, String> v = current.get();
        if(v==null){
            v=new HashMap<String, String>(3);
            current.set(v);
        }
        return v;
    }
}
