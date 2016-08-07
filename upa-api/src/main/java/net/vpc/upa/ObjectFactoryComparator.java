/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa;

import java.util.Comparator;

/**
 *
 * @author taha.bensalah@gmaol.com
 */
class ObjectFactoryComparator implements Comparator<ObjectFactory> {
    private static final Comparator<ObjectFactory> instance=new ObjectFactoryComparator();

    public static Comparator<ObjectFactory> getInstance() {
        return instance;
    }
    
    private ObjectFactoryComparator() {
    }

    public int compare(ObjectFactory o1, ObjectFactory o2) {
        if (o1 == o2) {
            return 0;
        }
        if (o1 == null) {
            return -1;
        }
        if (o2 == null) {
            return 1;
        }
        if (o1.equals(o2)) {
            return 0;
        }
        return Integer.compare(o1.getContextSupportLevel(), o2.getContextSupportLevel());
    }
    
}
