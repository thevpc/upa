package net.thevpc.upa.impl.persistence;

import net.thevpc.upa.Document;
import net.thevpc.upa.Entity;
import net.thevpc.upa.Key;
import net.thevpc.upa.SearchOperator;
import net.thevpc.upa.expressions.*;

import net.thevpc.upa.exceptions.IllegalUPAArgumentException;
import net.thevpc.upa.expressions.*;
import net.thevpc.upa.impl.upql.util.UPQLUtils;

import java.util.List;

import net.thevpc.upa.impl.util.UPAUtils;

public class CriteriaBuilder {

    private final Entity entity;
    private Object id;
    private Key key;
    private Object prototype;
    private Document documentPrototype;
    private Expression expression;
    private List<Object> idList;

    public CriteriaBuilder(Entity entity) {
        this.entity = entity;
    }

    public CriteriaBuilder byIdList(List<Object> ids) {
        if (ids == null || ids.size() == 0) {
            return byId(null);
        }
        Object[] objects = ids.toArray(new Object[ids.size()]);
        if (ids.size() == 1) {
            return byId(UPAUtils.castId(entity, objects[0]));
        }
        if (entity == null) {
            throw new IllegalUPAArgumentException("Missing Entity");
        }
        return byExpression(entity.getBuilder().idListToExpression(ids, UPQLUtils.THIS));
    }

    public CriteriaBuilder byExpressionList(List<Expression> condition) {
        Expression ll = null;
        for (Expression t : condition) {
            //UQLUtils.replaceThisVar(t, alias, getPersistenceUnit());
            if (ll == null) {
                ll = t;
            } else {
                ll = new Or(ll, t);
            }
        }
        return byExpression(ll);
    }

    public CriteriaBuilder byKeyList(List<Key> ids) {
        if (ids == null || ids.size() == 0) {
            return byId(null);
        }
        Object[] objects = ids.toArray(new Object[ids.size()]);
        if (ids.size() == 1) {
            return byId(objects[0]);
        }
        if (entity == null) {
            throw new IllegalUPAArgumentException("Missing Entity");
        }
        return byExpression(entity.getBuilder().keyListToExpression(ids, UPQLUtils.THIS));
    }

    public CriteriaBuilder byField(String field, Object value) {
        return byExpression(
                new Equals(new Var(new Var(entity.getName()), entity.getField(field).getName()),
                        new Param(entity.getField(field).getName(), value))
        );
    }

    public CriteriaBuilder byField(String field, SearchOperator operator, Object value) {
        if (operator == null) {
            operator = SearchOperator.EQ;
        }
        if (operator == SearchOperator.DEFAULT) {
            operator = SearchOperator.EQ;
        }
        switch (operator) {
            case EQ:
                return byExpression(
                        new Equals(new Var(new Var(entity.getName()), entity.getField(field).getName()),
                                new Param(entity.getField(field).getName(), value))
                );
            case NE:
                return byExpression(
                        new Different(new Var(new Var(entity.getName()), entity.getField(field).getName()),
                                new Param(entity.getField(field).getName(), value))
                );
            case LT:
                return byExpression(
                        new LessThan(new Var(new Var(entity.getName()), entity.getField(field).getName()),
                                new Param(entity.getField(field).getName(), value))
                );
            case LTE:
                return byExpression(
                        new LessEqualThan(new Var(new Var(entity.getName()), entity.getField(field).getName()),
                                new Param(entity.getField(field).getName(), value))
                );
            case GT:
                return byExpression(
                        new GreaterThan(new Var(new Var(entity.getName()), entity.getField(field).getName()),
                                new Param(entity.getField(field).getName(), value))
                );
            case GTE:
                return byExpression(
                        new GreaterEqualThan(new Var(new Var(entity.getName()), entity.getField(field).getName()),
                                new Param(entity.getField(field).getName(), value))
                );
        }
        throw new IllegalUPAArgumentException("NotYeSupported",operator);
    }

    public Expression createExpression() {
        Expression criteria = null;
        if (getId() != null) {
            Expression e = entity.getBuilder().idToExpression(getId(), UPQLUtils.THIS);
            criteria = criteria == null ? e : new And(criteria, e);
        }
        if (getKey() != null) {
            Expression e = (entity.getBuilder().keyToExpression(getKey(), UPQLUtils.THIS));
            criteria = criteria == null ? e : new And(criteria, e);
        }
        if (getPrototype() != null) {
            Expression e = entity.getBuilder().objectToExpression(getPrototype(), true, UPQLUtils.THIS);
            criteria = criteria == null ? e : new And(criteria, e);
        }
        if (getDocumentPrototype() != null) {
            Expression e = (entity.getBuilder().documentToExpression(getDocumentPrototype(), UPQLUtils.THIS));
            criteria = criteria == null ? e : new And(criteria, e);
        }
        if (getExpression() != null) {
            Expression e = getExpression();
            criteria = criteria == null ? e : new And(criteria, e);
        }
        return criteria;
    }

    public List<Object> getIdList() {
        return idList;
    }

    public CriteriaBuilder byId(Object id) {
        if (id instanceof Key) {
            byKey((Key) id);
        } else {
            this.id = UPAUtils.castId(entity, id);
        }
        return this;
    }

    public CriteriaBuilder byExpression(Expression expression) {
        if (this.expression == null) {
            this.expression = expression;
        } else if (expression != null) {
            this.expression = new And(this.expression, expression);
        } else {
            this.expression = null;
        }
        return this;
    }

    public CriteriaBuilder byExpression(Expression expression, boolean applyAndOp) {
        if (!applyAndOp || this.expression == null) {
            this.expression = expression;
        } else {
            this.expression = new And(this.expression, expression);
        }
        return this;
    }

    public CriteriaBuilder setExpression(Expression expression) {
        this.expression = expression;
        return this;
    }

    public CriteriaBuilder byKey(Key key) {
        this.key = key;
        return this;
    }

    public CriteriaBuilder byPrototype(Object prototype) {
        this.prototype = prototype;
        return this;
    }

    public CriteriaBuilder byDocumentPrototype(Document prototype) {
        this.documentPrototype = prototype;
        return this;
    }

    public Expression getExpression() {
        return expression;
    }

    public Object getId() {
        return id;
    }

    public Key getKey() {
        return key;
    }

    public Object getPrototype() {
        return prototype;
    }

    public Document getDocumentPrototype() {
        return documentPrototype;
    }

}
