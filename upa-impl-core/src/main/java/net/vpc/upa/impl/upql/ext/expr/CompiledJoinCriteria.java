/*
 * Created by IntelliJ IDEA.
 * User: taha
 * Date: 7 janv. 03
 * Time: 00:20:54
 * To change template for new class use 
 * Code Style | Class Templates options (Tools | IDE Options).
 */
package net.vpc.upa.impl.upql.ext.expr;

import net.vpc.upa.exceptions.IllegalUPAArgumentException;
import net.vpc.upa.expressions.JoinType;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;

import java.io.Serializable;
import java.util.ArrayList;

public class CompiledJoinCriteria extends DefaultCompiledExpressionImpl implements Serializable, Cloneable {

    private JoinType joinType;
    private CompiledNameOrSelect entity;
    private String alias;
    private CompiledExpressionExt condition;

    public CompiledJoinCriteria(JoinType joinType, CompiledNameOrSelect entity, String alias, CompiledExpressionExt condition) {
        this.joinType = joinType;
        this.entity = entity;
        this.alias = alias;
        setCondition(joinType.equals(JoinType.CROSS_JOIN)?null:condition);
    }

    public JoinType getJoinType() {
        return joinType;
    }

    public CompiledNameOrSelect getEntity() {
        return entity;
    }

    public String getEntityName() {
        if(entity!=null && entity instanceof CompiledEntityName){
            CompiledEntityName s=(CompiledEntityName)entity;
            return s.getName();
        }
        return null;
    }

    public String getEntityAlias() {
        return alias;
    }

    public void setEntityAlias(String alias) {
        this.alias=alias;
    }


    public CompiledExpressionExt getCondition() {
        return condition;
    }

    public void addCondition(CompiledExpressionExt condition) {
        if (condition != null) {
            if (this.condition == null) {
                setCondition(condition);
            } else {
                this.condition.unsetParent();
                setCondition(new CompiledAnd(this.condition, condition));
            }
        }
    }

    @Override
    public CompiledExpressionExt[] getSubExpressions() {
        ArrayList<CompiledExpressionExt> all = new ArrayList<CompiledExpressionExt>();
        all.add(entity);
        if (condition != null) {
            all.add(condition);
        }
        return all.toArray(new CompiledExpressionExt[all.size()]);
    }

    public void setEntity(CompiledNameOrSelect expression) {
        unbindChildren(this.entity);
        this.entity = expression;
        bindChildren(expression);
    }

    public final void setCondition(CompiledExpressionExt expression) {
        unbindChildren(condition);
        this.condition = expression;
        bindChildren(expression);
    }

    @Override
    public void setSubExpression(int index, CompiledExpressionExt expression) {
        switch (index) {
            case 0: {
                setEntity((CompiledNameOrSelect) expression);
                return;
            }
            case 1: {
                setCondition(expression);
                return;
            }
        }
        throw new IllegalUPAArgumentException("Invalid index");
    }

    public CompiledExpressionExt copy() {
       return new CompiledJoinCriteria(joinType, (CompiledNameOrSelect)(entity==null?null:entity.copy()), alias, condition==null?null:condition.copy());
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        String valueString = String.valueOf(entity);
        String aliasString = getEntityAlias();
        String joinKey = "INNER JOIN";
        switch (getJoinType()) {
            case INNER_JOIN: // '\0'
                joinKey = "INNER JOIN";
                break;

            case FULL_JOIN: // '\001'
                joinKey = "FULL JOIN";
                break;

            case LEFT_JOIN: // '\002'
                joinKey = "LEFT JOIN";
                break;

            case RIGHT_JOIN: // '\003'
                joinKey = "RIGHT JOIN";
                break;

            case CROSS_JOIN: // '\003'
                joinKey = "CROSS JOIN";
                break;
        }
        sb.append(joinKey).append(" ").append(valueString);
        if (aliasString != null && !valueString.equals(aliasString)) {
            sb.append(" ").append(aliasString);
        }
        if (condition != null && condition.isValid()) {
            sb.append(" ON ").append(condition);
        }
        return sb.toString();
    }
}
