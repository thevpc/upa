package net.vpc.upa.impl;

import net.vpc.upa.Entity;
import net.vpc.upa.impl.util.UPAUtils;

import java.util.Comparator;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/5/13 3:41 PM
*/
public class EntityChildComparator implements Comparator<String> {
    private Entity defaultEntity;

    public EntityChildComparator(Entity defaultEntity) {
        this.defaultEntity = defaultEntity;
    }

    public int compare(String o1, String o2) {
        String s1 = o1;
        String s2 = o2;
        int i1 = defaultEntity.indexOfPart(s1, false, true, true, true);
        int i2 = defaultEntity.indexOfPart(s2, false, true, true, true);
        return UPAUtils.compare(i1, i2);
    }
}
