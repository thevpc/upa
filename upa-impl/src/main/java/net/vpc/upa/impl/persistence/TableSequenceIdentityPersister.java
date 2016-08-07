/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.persistence;

import net.vpc.upa.*;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.EntitySequenceManager;
import net.vpc.upa.impl.SequenceManager;
import net.vpc.upa.impl.PrivateSequence;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.impl.util.StringUtils;
import net.vpc.upa.persistence.EntityExecutionContext;
import net.vpc.upa.persistence.FieldPersister;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public abstract class TableSequenceIdentityPersister implements FieldPersister {

    private int initialValue = 1;
    private int allocationSize = 50;
    private String format;
    private String group;
    private String name;
    private Field field;

    public TableSequenceIdentityPersister(Field field, Sequence sequence) {
        this.initialValue = sequence == null ? 1 : sequence.getInitialValue();
        this.allocationSize = (sequence == null) ? 50 : sequence.getAllocationSize();
        this.name = (sequence == null) ? null : sequence.getName();
        this.group = (sequence == null) ? null : sequence.getGroup();
        this.format = (sequence == null) ? null : sequence.getFormat();
        this.field = field;
        if (this.format == null) {
            this.format = "{#}";
        }
        if (this.group == null) {
            this.group = format;
        }
        if (this.name == null) {
            this.name = field.getEntity().getName() + "." + field.getName();
        }
    }

    public int getInitialValue() {
        return initialValue;
    }

    public int getAllocationSize() {
        return allocationSize;
    }

    public String getFormat() {
        return format;
    }

    public String getGroup() {
        return group;
    }

    public String getName() {
        return name;
    }

    public Field getField() {
        return field;
    }

    public void beforePersist(Record record, EntityExecutionContext context) throws UPAException {
        record.remove(field.getName());
        record.setObject(field.getName(), getNewValue(field, record, context));
    }

    public void afterPersist(Record record, EntityExecutionContext context) {
    }

    protected Object getNewValue(Field field, Record record, EntityExecutionContext executionContext) throws UPAException {
        Entity entity = field.getEntity();
        Entity seq = entity.getPersistenceUnit().getEntity(PrivateSequence.ENTITY_NAME);

        SequenceManager sm = new EntitySequenceManager(seq);
        final String groupString = eval(this.group, "{#}", record);
//        String fieldName = field.getName();
//        while (true) {
        final Object nextValue = getNewValue(sm, groupString, record);
//            long count = entity.getEntityCount(new Equals(new Var(fieldName), nextValue));
//            if (count == 0) {
        return nextValue;
//            }
//        }
    }

    protected abstract Object getNewValue(SequenceManager sm, String group, Record record) throws UPAException;

    protected String eval(String pattern, final Object replacement, final Record record) {
        return StringUtils.replaceNoDollarVars(pattern, new SequencePatternEvaluator(field, replacement, record));
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) {
            return true;
        }
        if (!(o instanceof TableSequenceIdentityPersister)) {
            return false;
        }

        TableSequenceIdentityPersister that = (TableSequenceIdentityPersister) o;

        if (allocationSize != that.allocationSize) {
            return false;
        }
        if (initialValue != that.initialValue) {
            return false;
        }
        if (field != null ? !field.equals(that.field) : that.field != null) {
            return false;
        }
        if (format != null ? !format.equals(that.format) : that.format != null) {
            return false;
        }
        if (group != null ? !group.equals(that.group) : that.group != null) {
            return false;
        }
        if (name != null ? !name.equals(that.name) : that.name != null) {
            return false;
        }

        return true;
    }

    @Override
    public int hashCode() {
        int result = initialValue;
        result = 31 * result + allocationSize;
        result = 31 * result + (format != null ? format.hashCode() : 0);
        result = 31 * result + (group != null ? group.hashCode() : 0);
        result = 31 * result + (name != null ? name.hashCode() : 0);
        result = 31 * result + (field != null ? field.hashCode() : 0);
        return result;
    }
}
