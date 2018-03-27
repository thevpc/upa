package net.vpc.upa.impl.persistence;

import net.vpc.upa.Entity;
import net.vpc.upa.Index;
import net.vpc.upa.PrimitiveField;
import net.vpc.upa.Relationship;

import java.util.Comparator;
import java.util.HashMap;
import java.util.Map;

import net.vpc.upa.exceptions.UPAIllegalArgumentException;
import net.vpc.upa.persistence.PersistenceNameType;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/8/13 1:53 AM
*/
class StructureCommitComparator implements Comparator<StructureCommit> {
    Map<ObjectAndType, Integer> pos = new HashMap<ObjectAndType, Integer>();

    StructureCommitComparator() {
        pos.put(new ObjectAndType(Entity.class, null), 100);
        pos.put(new ObjectAndType(PrimitiveField.class, null), 200);
        pos.put(new ObjectAndType(Entity.class, PersistenceNameType.PK_CONSTRAINT), 300);
        pos.put(new ObjectAndType(Index.class, null), 400);
        pos.put(new ObjectAndType(Relationship.class, null), 500);
        pos.put(new ObjectAndType(Entity.class, PersistenceNameType.IMPLICIT_VIEW), 800);
    }

    @Override
    public int compare(StructureCommit o1, StructureCommit o2) {
        if (o1 == o2) {
            return 0;
        }
        if (o1 == null) {
            return -1;
        }
        if (o2 == null) {
            return 1;
        }
        ObjectAndType oo1 = o1.typedObject;
        ObjectAndType oo2 = o2.typedObject;
        Integer p1 = pos.get(oo1);
        Integer p2 = pos.get(oo2);
        if(p1==null){
            throw new UPAIllegalArgumentException("Unknown order for "+oo1);
        }
        if(p2==null){
            throw new UPAIllegalArgumentException("Unknown order for "+oo2);
        }
        return p1 - p2;
    }
}
