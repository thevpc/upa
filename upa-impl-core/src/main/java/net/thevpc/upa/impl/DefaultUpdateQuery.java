package net.thevpc.upa.impl;

import net.thevpc.upa.Document;
import net.thevpc.upa.Key;
import net.thevpc.upa.UpdateQuery;
import net.thevpc.upa.impl.ext.EntityExt;
import net.thevpc.upa.impl.persistence.CriteriaBuilder;
import net.thevpc.upa.impl.util.filters.FieldFilters2;

import net.thevpc.upa.expressions.Expression;
import net.thevpc.upa.filters.FieldFilter;
import net.thevpc.upa.filters.FieldOrFilter;
import net.thevpc.upa.filters.FieldFilters;

import java.util.*;

/**
 * Created by vpc on 6/12/16.
 */
public class DefaultUpdateQuery implements UpdateQuery {
    private EntityExt entity;
    private CriteriaBuilder criteriaBuilder;
//    private ConditionType updateConditionType = ConditionType.EXPRESSION;
//    private Object updateCondition;
    private Object updatesValue;
    private boolean ignoreUnspecified;
    private Set<String> partialUpdateFields;
    private FieldFilter formulaFieldsFilter;
    private Map<String,Object> hints;

    public DefaultUpdateQuery(EntityExt entity) {
        this.entity = entity;
        criteriaBuilder=new CriteriaBuilder(entity);
    }

    public UpdateQuery setNone() {
        return setUpdates(null);
    }

    public UpdateQuery setValues(Document document) {
        return setUpdates(document);
    }

    @Override
    public UpdateQuery byIdList(List<Object> expr) {
        criteriaBuilder.byIdList(expr);
        return this;
    }

//    @Override
//    public UpdateQuery byObject(Object expr) {
//        return setCondition(ConditionType.OBJECT, expr);
//    }

//    @Override
//    public UpdateQuery byPrototype(Object expr) {
//        if (expr instanceof Document) {
//            return setCondition(ConditionType.DOCUMENT_PROTOTYPE, expr);
//        } else {
//            return setCondition(ConditionType.PROTOTYPE, expr);
//        }
//    }

//    @Override
//    public UpdateQuery byExpression(Expression expr) {
//        return setCondition(ConditionType.EXPRESSION, expr);
//    }
//
//    @Override
//    public UpdateQuery byAll() {
//        return setCondition(ConditionType.EXPRESSION, null);
//    }

    private UpdateQuery setUpdates(Object updatesValue) {
        this.updatesValue=updatesValue;
        return this;
    }

//    private UpdateQuery setCondition(ConditionType updateConditionType, Object updateCondition) {
//        this.updateConditionType = updateConditionType;
//        this.updateCondition = updateCondition;
//        return this;
//    }

    public UpdateQuery byField(String field, Object value) {
        criteriaBuilder.byField(field,value);
        return this;
    }


//    @Override
//    public ConditionType getUpdateConditionType() {
//        return updateConditionType;
//    }
//
//    @Override
//    public Object getUpdateCondition() {
//        return updateCondition;
//    }
//
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
    public UpdateQuery updateFormulas(FieldFilter formulaFields) {
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
    public UpdateQuery updateFormulas(Collection<String> formulaFields) {
        return updateFormulas(FieldFilters.byName(formulaFields));
    }


    @Override
    public UpdateQuery updateAllFormulas() {
        return updateFormulas(FieldFilters2.UPDATE_FORMULA);
    }
    @Override
    public UpdateQuery updateNoFormulas() {
        this.formulaFieldsFilter=null;
        return this;
    }

    @Override
    public UpdateQuery updateFormulas(String formulaField) {
        if(formulaField!=null) {
            return updateFormulas(Arrays.asList(formulaField));
        }
        return this;
    }

    @Override
    public UpdateQuery updateFormulas(String... formulaFields) {
        return updateFormulas(Arrays.asList(formulaFields));
    }

    @Override
    public UpdateQuery byId(Object id) {
        criteriaBuilder.byId(id);
        return this;
    }

    public UpdateQuery byExpression(Expression expression) {
        criteriaBuilder.byExpression(expression);
        return this;
    }

//    @Override
//    public UpdateQuery byExpression(Expression expression, boolean applyAndOp) {
//        criteriaBuilder.byExpression(expression,applyAndOp);
//        return this;
//    }

    @Override
    public UpdateQuery byKey(Key key) {
        criteriaBuilder.byKey(key);
        return this;
    }

    @Override
    public UpdateQuery byPrototype(Object prototype) {
        criteriaBuilder.byPrototype(prototype);
        return this;
    }

    @Override
    public UpdateQuery byDocumentPrototype(Document prototype) {
        criteriaBuilder.byDocumentPrototype(prototype);
        return this;
    }

    public Expression getUpdateExpression() {
        return criteriaBuilder.createExpression();
    }

    //    @Override
    public Expression getExpression() {
        return criteriaBuilder.getExpression();
    }

//    @Override
    public Object getId() {
        return criteriaBuilder.getId();
    }

//    @Override
    public Key getKey() {
        return criteriaBuilder.getKey();
    }

//    @Override
    public Object getPrototype() {
        return criteriaBuilder.getPrototype();
    }

    public Document getDocumentPrototype() {
        return criteriaBuilder.getDocumentPrototype();
    }

    @Override
    public UpdateQuery byKeyList(List<Key> expr) {
        criteriaBuilder.byKeyList(expr);
        return this;
    }

    @Override
    public UpdateQuery byExpressionList(List<Expression> expr) {
        criteriaBuilder.byExpressionList(expr);
        return this;
    }
}
