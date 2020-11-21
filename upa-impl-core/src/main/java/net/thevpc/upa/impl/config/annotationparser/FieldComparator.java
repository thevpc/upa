package net.thevpc.upa.impl.config.annotationparser;

import java.lang.reflect.Field;
import java.util.Comparator;

import net.thevpc.upa.config.Decoration;
import net.thevpc.upa.impl.config.decorations.DecorationRepository;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/7/13 2:32 AM
*/
class FieldComparator implements Comparator<Field> {
    DecorationRepository repo;

    public FieldComparator(DecorationRepository repo) {
        this.repo = repo;
    }
    
    public int compare(Field o1, Field o2) {
        Decoration f1 = repo.getFieldDecoration(o1, net.thevpc.upa.config.Field.class);
        Decoration f2 = repo.getFieldDecoration(o2, net.thevpc.upa.config.Field.class);
        if (f1 == null && f2 == null) {
            return 0;
        }
        if (f1 == null) {
            return -1;
        }
        if (f2 == null) {
            return 1;
        }
        return Integer.compare(f1.getConfig().getOrder(), f2.getConfig().getOrder());
    }
}
