package net.vpc.upa.impl.ext;

import net.vpc.upa.*;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.persistence.EntityExecutionContext;

public interface EntityExt extends Entity {
    void setModifiers(FlagSet<EntityModifier> modifiers);

    long update(UpdateQuery updateQuery) throws UPAException;

    void beforePartAdded(EntityPart parent, EntityPart part, int index) throws UPAException;

    void afterPartAdded(EntityPart parent, EntityPart item, int index) throws UPAException;

    void setCompositionRelationship(Relationship compositionRelation) throws UPAException;

    void commitExpressionModelChanges() throws UPAException;

    void registerField(Field field) throws UPAException;
    //////////////////////////////////////////////////////////
    //
    //    CORE
    //
    //////////////////////////////////////////////////////////
    int updateCore(Document updates, Expression condition, EntityExecutionContext executionContext);

    void persistCore(Document values, EntityExecutionContext executionContext);

    int removeCore(Expression condition, boolean recurse, RemoveTrace deleteInfo, EntityExecutionContext executionContext);

    int clearCore(EntityExecutionContext executionContext);

//    long updateFormulasCore(FieldFilter filter, Expression expr, EntityExecutionContext context) ;

    int initializeCore(EntityExecutionContext executionContext);

}
