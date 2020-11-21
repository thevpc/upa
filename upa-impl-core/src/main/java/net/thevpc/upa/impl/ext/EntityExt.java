package net.thevpc.upa.impl.ext;

import net.thevpc.upa.*;

import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.expressions.Expression;
import net.thevpc.upa.persistence.EntityExecutionContext;

public interface EntityExt extends Entity {

    void setModifiers(FlagSet<EntityModifier> modifiers);

    long update(UpdateQuery updateQuery) throws UPAException;

    void beforeItemAdded(EntityItem parent, EntityItem part, int index) throws UPAException;

    void afterItemAdded(EntityItem parent, EntityItem item, int index) throws UPAException;

    void setCompositionRelationship(Relationship compositionRelation) throws UPAException;

    void commitExpressionModelChanges() throws UPAException;

    void registerField(Field field) throws UPAException;

    int updateCore(Document updates, Expression condition, EntityExecutionContext executionContext);

    void persistCore(Document values, EntityExecutionContext executionContext);

    int removeCore(Expression condition, boolean recurse, RemoveTrace deleteInfo, EntityExecutionContext executionContext);

    int clearCore(EntityExecutionContext executionContext);

    int initializeCore(EntityExecutionContext executionContext);

}
