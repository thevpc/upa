package net.thevpc.upa.impl.persistence;

import net.thevpc.upa.Entity;
import net.thevpc.upa.Field;
import net.thevpc.upa.expressions.Expression;
import net.thevpc.upa.expressions.Var;
import net.thevpc.upa.persistence.ResultField;
import net.thevpc.upa.types.DataType;

/**
 * Created by vpc on 6/27/16.
 */
public class DefaultResultField implements ResultField {
    public Expression expression ;

    public String alias ;

    public DataType dataType;

    public Field field ;

    public Entity entity ;

    public DefaultResultField(Expression expression, String alias, DataType dataType, Field field, Entity entity) {
        this.expression = expression;
        if(alias==null){
            if(expression instanceof Var){
                alias=((Var) expression).getName();
            }else{
                alias=expression.toString();
            }
        }
        this.alias = alias;
        this.dataType = dataType;
        this.field = field;
        this.entity = entity;
    }

    @Override
    public Expression getExpression() {
        return expression;
    }

    @Override
    public String getAlias() {
        return alias;
    }

    @Override
    public DataType getDataType() {
        return dataType;
    }

    @Override
    public Field getField() {
        return field;
    }

    @Override
    public Entity getEntity() {
        return entity;
    }
}
