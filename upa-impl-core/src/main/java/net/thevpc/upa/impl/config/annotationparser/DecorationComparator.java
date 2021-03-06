package net.thevpc.upa.impl.config.annotationparser;

import net.thevpc.upa.config.Decoration;

import java.util.Comparator;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/7/13 2:27 AM
 */
public class DecorationComparator implements Comparator<Decoration> {
    public static final DecorationComparator INSTANCE=new DecorationComparator();
    public int compare(Decoration o1, Decoration o2) {
        return Integer.compare(o1.getConfig().getOrder(), o2.getConfig().getOrder());
    }
}
