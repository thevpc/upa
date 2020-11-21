package net.thevpc.upa.impl;

import net.thevpc.upa.impl.util.UPAUtils;
import net.thevpc.upa.Entity;

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
        int i1 = defaultEntity.indexOfItem(s1, false, true, true, true);
        int i2 = defaultEntity.indexOfItem(s2, false, true, true, true);
        return UPAUtils.compare(i1, i2);
    }
}
