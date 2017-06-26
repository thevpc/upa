package net.vpc.upa;

import net.vpc.upa.expressions.Expression;
import net.vpc.upa.filters.FieldFilter;

import java.util.Collection;
import java.util.List;
import java.util.Map;
import java.util.Set;

/**
 * Created by vpc on 6/12/16.
 */
public interface UpdateQuery {
    UpdateQuery setNone();

    UpdateQuery setValues(Object object);

    UpdateQuery setValues(Document document);

    Object getValues();

    UpdateQuery byId(Object expr);

    <T> UpdateQuery byIdList(List<T> expr);

    UpdateQuery byKey(Key expr);

    UpdateQuery byObject(Object expr);

    UpdateQuery byPrototype(Object expr);

    UpdateQuery byDocument(Document expr);

    UpdateQuery byPrototype(Document expr);

    UpdateQuery byKeyList(List<Key> expr);

    UpdateQuery byExpressionList(List<Expression> expr);

    UpdateQuery byExpression(Expression expr);

    UpdateQuery byAll();

    ConditionType getUpdateConditionType();

    Object getUpdateCondition();

    Map<String, Object> getHints();

    Map<String, Object> getHints(boolean autoCreate);

    UpdateQuery setHints(Map<String, Object> hints);

    UpdateQuery setHint(String name, Object value);


    UpdateQuery addUpdatableField(String name);

    UpdateQuery removeUpdatableField(String name);

    UpdateQuery addUpdatableFields(String... names);

    UpdateQuery removeUpdatableFields(String... names);

    UpdateQuery addUpdatableFields(Collection<String> names);

    UpdateQuery removeUpdatableFields(Collection<String> names);

    UpdateQuery updateAll();

    Set<String> getUpdatedFields();

    UpdateQuery setUpdatedFields(Collection<String> partialUpdateFields);

    UpdateQuery update(Collection<String> partialUpdateFields);

    UpdateQuery update(String... partialUpdateFields);

    UpdateQuery update(String partialUpdateFields);

    UpdateQuery removeUpdatedFields(Collection<String> partialUpdateFields);

    FieldFilter getFormulaFields();

    UpdateQuery validate(String formulaField);

    UpdateQuery validate(String... formulaFields);

    UpdateQuery validate(Collection<String> formulaFields);

    UpdateQuery validate(FieldFilter formulaFields);

    UpdateQuery validateAll();

    UpdateQuery validateNone();

    boolean isIgnoreUnspecified();

    UpdateQuery setIgnoreUnspecified(boolean ignoreUnspecified);

    long execute();
}
