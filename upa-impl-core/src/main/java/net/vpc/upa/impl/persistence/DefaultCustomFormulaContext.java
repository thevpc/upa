package net.vpc.upa.impl.persistence;

import net.vpc.upa.CustomFormulaContext;
import net.vpc.upa.Document;
import net.vpc.upa.Field;
import net.vpc.upa.impl.eval.AbstractBaseFormulaContext;
import net.vpc.upa.persistence.EntityExecutionContext;

public class DefaultCustomFormulaContext extends AbstractBaseFormulaContext implements CustomFormulaContext {

    private final Field field;
    private final Object id;

    public DefaultCustomFormulaContext(Field field, Object id, EntityExecutionContext executionContext) {
        super(executionContext);
        this.field = field;
        this.id = id;
    }

    @Override
    public Field getField() {
        return field;
    }

    public Object getObjectId() {
        return id;
    }

    @Override
    public Document reloadUpdateDocument() {
        return getPersistenceUnit().findDocumentById(getEntity().getName(), getObjectId());
    }

    @Override
    public Object reloadUpdateObject() {
        return getPersistenceUnit().findById(getEntity().getName(), getObjectId());
    }

}
