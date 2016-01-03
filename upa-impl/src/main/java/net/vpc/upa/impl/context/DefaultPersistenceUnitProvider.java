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
    private static ThreadLocal<Map<String,PersistenceUnit>> current=new ThreadLocal<Map<String, PersistenceUnit>>();

    @Override
    public PersistenceUnit getPersistenceUnit(PersistenceGroup persistenceGroup) {
        return getMap().get(String.valueOf(System.identityHashCode(persistenceGroup)));
    }

    @Override
    public void setPersistenceUnit(PersistenceGroup persistenceGroup, PersistenceUnit persistenceUnit) {
        String k = String.valueOf(System.identityHashCode(persistenceGroup));
        if(persistenceUnit==null){
            getMap().remove(k);
        }else{
            getMap().put(k, persistenceUnit);
        }
    }

    private static Map<String,PersistenceUnit> getMap(){
        Map<String, PersistenceUnit> v = current.get();
        if(v==null){
            v=new HashMap<String, PersistenceUnit>(3);
            current.set(v);
        }
        return v;
    }
}
