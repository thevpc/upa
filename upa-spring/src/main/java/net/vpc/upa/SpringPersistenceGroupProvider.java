package net.vpc.upa;

import org.springframework.stereotype.Component;

public class SpringPersistenceGroupProvider implements PersistenceGroupProvider {
    private String name;

    @Override
    public String getPersistenceGroup() {
        return name;
    }

    @Override
    public void setPersistenceGroup(String current) {
        this.name = name;
    }
}
