package net.vpc.upa.spring;

import net.vpc.upa.PersistenceGroupProvider;

public class SpringPersistenceGroupProvider implements PersistenceGroupProvider {
    private String name;

    @Override
    public String getPersistenceGroup() {
        return name;
    }

    @Override
    public void setPersistenceGroup(String current) {
        this.name = current;
    }
}
