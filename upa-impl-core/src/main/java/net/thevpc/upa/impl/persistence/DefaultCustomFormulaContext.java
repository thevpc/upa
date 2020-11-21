package net.thevpc.upa.impl.persistence;

import net.thevpc.upa.CustomFormulaContext;
import net.thevpc.upa.Document;
import net.thevpc.upa.Field;
import net.thevpc.upa.impl.eval.AbstractBaseFormulaContext;
import net.thevpc.upa.persistence.EntityExecutionContext;

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
