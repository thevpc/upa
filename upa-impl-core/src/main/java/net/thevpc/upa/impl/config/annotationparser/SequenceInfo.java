package net.thevpc.upa.impl.config.annotationparser;

import net.thevpc.upa.config.Decoration;
import net.thevpc.upa.impl.config.decorations.DecorationRepository;
import net.thevpc.upa.SequenceStrategy;
import net.thevpc.upa.config.Sequence;
import net.thevpc.upa.SequenceType;

import java.lang.reflect.Field;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 11/15/12 11:47 AM
 */
class SequenceInfo {

    SequenceStrategy strategy;
    SequenceType sequenceType = SequenceType.DEFAULT;
    Integer initialValue;
    Integer allocationSize;
    Integer formulaOrder;
    String format;
    String name;
    String group;
    int configOrder = Integer.MIN_VALUE;
    boolean specified = false;
    DecorationRepository repo;

    public SequenceInfo(DecorationRepository repo) {
        this.repo = repo;
    }

    public void parse(List<Field> fields) {
        List<Decoration> persistSequenceFields = new ArrayList<Decoration>();
        for (Field javaField : fields) {
            Decoration gid = repo.getFieldDecoration(javaField, Sequence.class);
            if (gid != null) {
                persistSequenceFields.add(gid);
            }
        }
        if (persistSequenceFields.size() > 1) {
            Collections.sort(persistSequenceFields, DecorationComparator.INSTANCE);
        }
        for (Decoration gid : persistSequenceFields) {
            mergeSequence(gid);
        }

    }

    public void mergeSequence(/*Sequence*/Decoration gid) {
        specified = true;
        if (gid.getConfig().getOrder() >= configOrder) {
            specified = true;
            if (gid.getInt("allocationSize") != Integer.MIN_VALUE) {
                allocationSize = gid.getInt("allocationSize");
            }
            if (gid.getInt("initialValue") != Integer.MIN_VALUE) {
                initialValue = gid.getInt("initialValue");
            }
            if (gid.getString("format").length() > 0) {
                format = gid.getString("format");
            }
            if (gid.getString("group").length() > 0) {
                group = gid.getString("group");
            }
            if (gid.getEnum("sequenceType", SequenceType.class) != SequenceType.DEFAULT) {
                sequenceType = gid.getEnum("sequenceType", SequenceType.class);
            }
            if (gid.getString("name").length() > 0) {
                name = gid.getString("name");
            }
            if (gid.getEnum("strategy", SequenceStrategy.class) != SequenceStrategy.DEFAULT) {
                strategy = gid.getEnum("strategy", SequenceStrategy.class);
            }
            if (gid.getInt("formulaOrder") != Integer.MIN_VALUE) {
                formulaOrder = gid.getInt("formulaOrder");
            }
            if (gid.getConfig().getOrder() > configOrder) {
                configOrder = gid.getConfig().getOrder();
            }
        }
    }
}
