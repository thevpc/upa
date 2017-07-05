package net.vpc.upa.impl;

import net.vpc.upa.ConditionType;
import net.vpc.upa.Key;
import net.vpc.upa.Document;
import net.vpc.upa.UpdateQuery;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.filters.FieldFilter;
import net.vpc.upa.filters.FieldOrFilter;
import net.vpc.upa.filters.FieldFilters;
import net.vpc.upa.impl.util.filters.FieldFilters2;

import java.util.*;

/**
 * Created by vpc on 6/12/16.
 */
public class DefaultUpdateQuery implements UpdateQuery{
    private DefaultEntity entity;
    private ConditionType updateConditionType = ConditionType.EXPRESSION;
    private Object updateCondition;
    private Object updatesValue;
    private boolean ignoreUnspecified;
    private Set<String> partialUpdateFields;
    private FieldFilter formulaFieldsFilter;
    private Map<String,Object> hints;

    public DefaultUpdateQuery(DefaultEntity entity) {
        this.entity = entity;
    }

    public UpdateQuery setNone() {
        return setUpdates(null);
    }

    public UpdateQuery setValues(Document document) {
        return setUpdates(document);
    }

    @Override
    public UpdateQuery byId(Object expr) {
        return setCondition(ConditionType.ID, expr);
    }

    @Override
    public <T> UpdateQuery byIdList(List<T> expr) {
        return setCondition(ConditionType.ID_LIST, expr);
    }

    @Override
    public UpdateQuery byKey(Key expr) {
        return setCondition(ConditionType.KEY, expr);
    }

    @Override
    public UpdateQuery byObject(Object expr) {
        return setCondition(ConditionType.OBJECT, expr);
    }

    @Override
    public UpdateQuery byPrototype(Object expr) {
        if (expr instanceof Document) {
            return setCondition(ConditionType.DOCUMENT_PROTOTYPE, expr);
        } else {
            return setCondition(ConditionType.PROTOTYPE, expr);
        }
    }

    @Override
    public UpdateQuery byDocument(Document expr) {
        return setCondition(ConditionType.DOCUMENT, expr);
    }

    @Override
    public UpdateQuery byPrototype(Document expr) {
        return setCondition(ConditionType.DOCUMENT_PROTOTYPE, expr);
    }

    @Override
    public UpdateQuery byKeyList(List<Key> expr) {
        return setCondition(ConditionType.ID_LIST, expr);
    }

    @Override
    public UpdateQuery byExpressionList(List<Expression> expr) {
        return setCondition(ConditionType.EXPRESSION_LIST, expr);
    }

    @Override
    public UpdateQuery byExpression(Expression expr) {
        return setCondition(ConditionType.EXPRESSION, expr);
    }

    @Override
    public UpdateQuery byAll() {
        return setCondition(ConditionType.EXPRESSION, null);
    }

    private UpdateQuery setUpdates(Object updatesValue) {
        this.updatesValue=updatesValue;
        return this;
    }

    private UpdateQuery setCondition(ConditionType updateConditionType, Object updateCondition) {
        this.updateConditionType = updateConditionType;
        this.updateCondition = updateCondition;
        return this;
    }


    @Override
    public ConditionType getUpdateConditionType() {
        return updateConditionType;
    }

    @Override
    public Object getUpdateCondition() {
        return updateCondition;
    }

    @Override
    public Map<String, Object> getHints() {
        return hints;
    }

    @Override
    public Map<String, Object> getHints(boolean autoCreate) {
        if(hints==null && autoCreate){
            hints=new HashMap<String, Object>();
        }
        return hints;
    }

    @Override
    public UpdateQuery setHints(Map<String, Object> hints) {
        this.hints = hints;
        return this;
    }

    @Override
    public UpdateQuery setHint(String name, Object value){
        if(value==null){
            if(hints!=null){
                hints.remove(name);
            }
        }else{
            if(hints==null){
                hints=new HashMap<String, Object>();
            }
            hints.put(name,value);
        }
        return this;
    }

    @Override
    public Object getValues() {
        return updatesValue;
    }

    @Override
    public UpdateQuery setValues(Object updatesValue) {
        this.updatesValue = updatesValue;
        return this;
    }

    @Override
    public UpdateQuery addUpdatableField(String name) {
        if(partialUpdateFields==null){
            partialUpdateFields=new HashSet<String>();
        }
        partialUpdateFields.add(name);
        return this;
    }

    @Override
    public UpdateQuery removeUpdatableField(String name) {
        if(partialUpdateFields!=null){
            partialUpdateFields.remove(name);
        }
        return this;
    }

    @Override
    public UpdateQuery addUpdatableFields(String... names) {
        return addUpdatableFields(Arrays.asList(names));
    }

    @Override
    public UpdateQuery removeUpdatableFields(String... names) {
        return removeUpdatableFields(Arrays.asList(names));
    }

    @Override
    public UpdateQuery addUpdatableFields(Collection<String> names) {
        if(partialUpdateFields==null){
            partialUpdateFields=new HashSet<String>();
        }
        partialUpdateFields.addAll(names);
        return this;
    }

    @Override
    public UpdateQuery removeUpdatableFields(Collection<String> names) {
        if(partialUpdateFields!=null){
            partialUpdateFields.removeAll(names);
        }
        return this;
    }

    @Override
    public UpdateQuery updateAll() {
        if(partialUpdateFields!=null){
            partialUpdateFields.clear();
        }
        return this;
    }

    @Override
    public Set<String> getUpdatedFields() {
        return partialUpdateFields;
    }

    @Override
    public UpdateQuery setUpdatedFields(Collection<String> partialUpdateFields) {
        this.partialUpdateFields = partialUpdateFields==null?null:new HashSet<String>(partialUpdateFields);
        return this;
    }

    @Override
    public UpdateQuery update(Collection<String> partialUpdateFields) {
        if(partialUpdateFields!=null){
            HashSet<String> s=new HashSet<String>(partialUpdateFields);
            if(this.partialUpdateFields!=null){
                s.addAll(this.partialUpdateFields);
            }
            this.partialUpdateFields=s;
        }
        return this;
    }

    @Override
    public UpdateQuery update(String... partialUpdateFields) {
        return update(Arrays.asList(partialUpdateFields));
    }

    @Override
    public UpdateQuery removeUpdatedFields(Collection<String> partialUpdateFields) {
        if(partialUpdateFields!=null) {
            if (this.partialUpdateFields != null) {
                this.partialUpdateFields.removeAll(partialUpdateFields);
            }
        }
        return null;
    }

    @Override
    public UpdateQuery update(String field) {
        if(field !=null){
            HashSet<String> s=new HashSet<String>();
            if(this.partialUpdateFields!=null){
                s.addAll(this.partialUpdateFields);
            }
            s.add(field);
            this.partialUpdateFields=s;
        }
        return this;
    }

    @Override
    public FieldFilter getFormulaFields() {
        return formulaFieldsFilter;
    }

    @Override
    public UpdateQuery validate(FieldFilter formulaFields) {
        if(formulaFields!=null) {
            if (this.formulaFieldsFilter == null) {
                this.formulaFieldsFilter = formulaFields;
            } else {
                this.formulaFieldsFilter = FieldOrFilter.or(this.formulaFieldsFilter, formulaFields);
            }
        }
        return this;
    }

    @Override
    public long execute() {
        return entity.update(this);
    }

    @Override
    public boolean isIgnoreUnspecified() {
        return ignoreUnspecified;
    }

    @Override
    public UpdateQuery setIgnoreUnspecified(boolean ignoreUnspecified) {
        this.ignoreUnspecified = ignoreUnspecified;
        return this;
    }

    @Override
    public UpdateQuery validate(Collection<String> formulaFields) {
        return validate(FieldFilters.byName(formulaFields));
    }


    @Override
    public UpdateQuery validateAll() {
        return validate(FieldFilters2.UPDATE_FORMULA);
    }
    @Override
    public UpdateQuery validateNone() {
        this.formulaFieldsFilter=null;
        return this;
    }

    @Override
    public UpdateQuery validate(String formulaField) {
        if(formulaField!=null) {
            return validate(Arrays.asList(formulaField));
        }
        return this;
    }

    @Override
    public UpdateQuery validate(String... formulaFields) {
        return validate(Arrays.asList(formulaFields));
    }
}
