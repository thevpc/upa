/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.config.annotationparser;

import net.vpc.upa.config.Entity;
import net.vpc.upa.config.Partial;
import net.vpc.upa.config.Decoration;
import net.vpc.upa.impl.config.decorations.DecorationRepository;
import net.vpc.upa.impl.util.IndexedComparator;

/**
 *
 * @author vpc
 */
class ClassIndexedComparator implements IndexedComparator<Class> {
    private DecorationRepository repo;

    public ClassIndexedComparator(DecorationRepository repo) {
        this.repo = repo;
    }

    @Override
    public int compare(Class o1, Class o2, int i1, int i2) {
        Decoration e1 = (Decoration) repo.getTypeDecoration(o1, Entity.class);
        Decoration e2 = (Decoration) repo.getTypeDecoration(o1, Entity.class);
        int x = e1.getDecoration("config").getInt("order") - e2.getDecoration("config").getInt("order");
        if (x != 0) {
            return x;
        }
        Decoration p1 = (Decoration) repo.getTypeDecoration(o1, Partial.class);
        Decoration p2 = (Decoration) repo.getTypeDecoration(o1, Partial.class);
        if (p1 != null && p2 == null) {
            return 1;
        }
        if (p2 != null && p1 == null) {
            return -1;
        }
        if (p1 != null && p2 != null) {
            if (p1.getType("value").equals(o2)) {
                return -1;
            }
            if (p2.getType("value").equals(o1)) {
                return 1;
            }
        }
        return i1 - i2;
    }
    
}
