/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa;

import java.util.Comparator;

/**
 * @author taha.bensalah@gmaol.com
 */
class ObjectFactoryConfiguratorComparator implements Comparator<ObjectFactoryConfigurator> {
    private static final Comparator<ObjectFactoryConfigurator> instance = new ObjectFactoryConfiguratorComparator();

    public static Comparator<ObjectFactoryConfigurator> getInstance() {
        return instance;
    }

    private ObjectFactoryConfiguratorComparator() {
    }

    public int compare(ObjectFactoryConfigurator o1, ObjectFactoryConfigurator o2) {
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
