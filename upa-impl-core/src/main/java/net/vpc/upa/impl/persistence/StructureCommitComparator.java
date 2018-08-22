package net.vpc.upa.impl.persistence;


import java.util.Comparator;
import java.util.HashMap;
import java.util.Map;

import net.vpc.upa.config.PersistenceNameType;
import net.vpc.upa.exceptions.IllegalUPAArgumentException;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/8/13 1:53 AM
*/
class StructureCommitComparator implements Comparator<StructureCommitAction> {
    private final Map<PersistenceNameType, Integer> pos = new HashMap<PersistenceNameType, Integer>();
    StructureCommitComparator() {
        pos.put(PersistenceNameType.TABLE, 100);
        pos.put(PersistenceNameType.COLUMN, 200);
        pos.put(PersistenceNameType.PK_CONSTRAINT, 300);
        pos.put(PersistenceNameType.INDEX, 400);
        pos.put(PersistenceNameType.FK_CONSTRAINT, 500);
        pos.put(PersistenceNameType.IMPLICIT_VIEW, 800);
        pos.put(PersistenceNameType.VIEW, 900);
    }

    @Override
    public int compare(StructureCommitAction o1, StructureCommitAction o2) {
        if (o1 == o2) {
            return 0;
        }
        if (o1 == null) {
            return -1;
        }
        if (o2 == null) {
            return 1;
        }
        PersistenceNameType oo1 = o1.persistenceNameType;
        PersistenceNameType oo2 = o2.persistenceNameType;
        int p1 = get(oo1);
        int p2 = get(oo2);
        return p1 - p2;
    }
    
    public int get(PersistenceNameType o){
        Integer p1 = pos.get(o);
        if(p1==null){
            throw new IllegalUPAArgumentException("Unknown order for "+o);
        }
        return p1.intValue();
    }
}
