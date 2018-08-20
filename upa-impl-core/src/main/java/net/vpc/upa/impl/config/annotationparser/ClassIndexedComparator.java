/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.config.annotationparser;

import net.vpc.upa.config.Decoration;
import net.vpc.upa.impl.config.decorations.DecorationRepository;
import net.vpc.upa.impl.util.IndexedComparator;

/**
 *
 * @author taha.bensalah@gmail.com
 */
class ClassIndexedComparator implements IndexedComparator<Class> {

    private DecorationRepository repo;

    public ClassIndexedComparator(DecorationRepository repo) {
        this.repo = repo;
    }

    @Override
    public int compare(Class o1, Class o2, int i1, int i2) {
        int x = resolveOrder(o1) - resolveOrder(o2);
        if (x != 0) {
            return x;
        }
        return i1 - i2;
    }

    private int resolveOrder(Class o1) {
        int x = Integer.MIN_VALUE;
        for (Class configClass : new Class[]{
            net.vpc.upa.config.Entity.class,
             net.vpc.upa.config.View.class,
             net.vpc.upa.config.UnionEntity.class,
             net.vpc.upa.config.FilterEntity.class,
             net.vpc.upa.config.Singleton.class
        }) {
            Decoration e1 = (Decoration) repo.getTypeDecoration(o1, configClass);
            if (e1 != null) {
                int y = e1.getDecoration("config").getInt("order");
                if (y > x) {
                    x = y;
                }
            }
        }
        return x;
    }
}
