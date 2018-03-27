package net.vpc.upa;

import org.springframework.stereotype.Component;

import java.util.HashMap;
import java.util.Map;


public class SpringPersistenceUnitProvider implements PersistenceUnitProvider{
    Map<String,String> groupToPu=new HashMap<>();
    @Override
    public String getPersistenceUnitName(PersistenceGroup persistenceGroup) {
        return groupToPu.get(persistenceGroup.getName());
    }

    @Override
    public void setPersistenceUnitName(PersistenceGroup persistenceGroup, String current) {
        groupToPu.put(persistenceGroup.getName(),current);
    }
}
