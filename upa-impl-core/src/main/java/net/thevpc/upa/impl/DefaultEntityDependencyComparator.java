package net.thevpc.upa.impl;

import net.thevpc.upa.Entity;
import net.thevpc.upa.Field;
import net.thevpc.upa.FieldModifier;
import net.thevpc.upa.Relationship;

import java.util.Comparator;
import java.util.HashSet;
import java.util.Set;

/**
 * @author taha.bensalah@gmail.com on 7/6/16.
 */
class DefaultEntityDependencyComparator implements Comparator<Entity> {
    public static final Comparator<Entity> INSTANCE=new DefaultEntityDependencyComparator();
    @Override
    public int compare(Entity o1, Entity o2) {
        Set<String> s1 = findEntityDependencies(o1);
        Set<String> s2 = findEntityDependencies(o2);
        if (s1.contains(o2.getName()) && s2.contains(o1.getName())) {
            return o1.getName().compareTo(o2.getName());
        } else if (s1.contains(o2.getName())) {
            return -1;
        } else if (s2.contains(o1.getName())) {
            return 1;
        } else {
            return o1.getName().compareTo(o2.getName());
        }
    }

    private Set<String> findEntityDependencies(Entity o1) {
        Set<String> all = new HashSet<String>();
        for (Field field : o1.getFields()) {
            if (!field.getModifiers().contains(FieldModifier.TRANSIENT)) {
                Relationship manyToOneRelationship= field.getManyToOneRelationship();
                if (manyToOneRelationship!=null) {
                    all.add(manyToOneRelationship.getTargetEntity().getName());
                }
            }
        }
        return all;
    }
}
