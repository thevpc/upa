package net.vpc.upa;

import java.util.ArrayList;
import java.util.List;

public class PersistenceContextInfo {
    private List<PersistenceGroupInfo> groups=new ArrayList<>();

    public List<PersistenceGroupInfo> getGroups() {
        return groups;
    }

    public void setGroups(List<PersistenceGroupInfo> groups) {
        this.groups = groups;
    }
}
