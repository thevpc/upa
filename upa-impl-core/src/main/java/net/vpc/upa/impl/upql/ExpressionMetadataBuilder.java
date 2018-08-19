package net.vpc.upa.impl.upql;

import net.vpc.upa.*;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.*;
import net.vpc.upa.filters.FieldFilter;
import net.vpc.upa.impl.persistence.DefaultResultField;
import net.vpc.upa.impl.persistence.DefaultResultMetaData;
import net.vpc.upa.impl.upql.util.UPQLUtils;
import net.vpc.upa.impl.util.StringUtils;
import net.vpc.upa.persistence.ResultField;
import net.vpc.upa.persistence.ResultMetaData;
import net.vpc.upa.types.TypesFactory;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

/**
 * Created by vpc on 6/28/16.
 */
public class ExpressionMetadataBuilder {
    ExpressionManager expressionManager;
    PersistenceUnit pu;

    public ExpressionMetadataBuilder(ExpressionManager expressionManager, PersistenceUnit pu) {
        this.expressionManager = expressionManager;
        this.pu = pu;
    }

    //    @Override
    public ResultMetaData createResultMetaData(Expression baseExpression,FieldFilter fieldFilter) {
        return createResultMetaData(baseExpression,fieldFilter,new ArrayList<QueryStatement>());
    }

    public ResultMetaData createResultMetaData(Expression baseExpression,FieldFilter fieldFilter,List<QueryStatement> context) {
        baseExpression= UPQLUtils.parseUserExpressions(baseExpression, pu);
        DefaultResultMetaData m=new DefaultResultMetaData();
        if(baseExpression instanceof NonQueryStatement){
            m.setStatement((EntityStatement) baseExpression);
            m.addField(
                    new DefaultResultField(
                            null,
                            "result",
                            TypesFactory.INT,
                            null,null
                    )
            );
            return m;
        }else {
            QueryStatement q = (QueryStatement) baseExpression;
            if (q instanceof Select) {
                Select qs = (Select) q;
                if(qs.getFields().size()==0){
                    if(!StringUtils.isNullOrEmpty(qs.getEntityAlias())) {
                        qs.field(new Var(qs.getEntityAlias()));
                    }else if(qs.getEntityName()!=null){
                        qs.field(new Var(qs.getEntityName()));
                    }else{
                        throw new UPAException("MissingAlias");
                    }
                    for (JoinCriteria joinCriteria : qs.getJoins()) {
                        if(!StringUtils.isNullOrEmpty(joinCriteria.getEntityAlias())) {
                            qs.field(new Var(joinCriteria.getEntityAlias()));
                        }else if(joinCriteria.getEntityName()!=null){
                            qs.field(new Var(joinCriteria.getEntityName()));
                        }else{
                            throw new UPAException("MissingAlias");
                        }
                    }
                }
                List<QueryField> oldFields=new ArrayList<QueryField>(q.getFields());
                List<QueryField> newFields=new ArrayList<QueryField>();
                List<ResultField> newResults=new ArrayList<ResultField>();
                List<QueryStatement> context2=new ArrayList<QueryStatement>();
                context2.addAll(context);
                context2.add(q);
                for (QueryField f : oldFields) {
                    Expression expression = f.getExpression();
                    String oldAlias = f.getAlias();
                    List<ResultField> newVal = createResultFields(expression, oldAlias, fieldFilter, context2);
                    newResults.addAll(newVal);
                    if(newVal.size()==0){
                        //why?
                    }else if(newVal.size()==1){
                        f.setExpression(newVal.get(0).getExpression());
                        f.setAlias(StringUtils.isNullOrEmpty(oldAlias)?oldAlias:newVal.get(0).getAlias());
                        newFields.add(f);
                    }else{
                        for (ResultField nf : newVal) {
                            QueryField f2=new QueryField(StringUtils.isNullOrEmpty(oldAlias)?oldAlias:nf.getAlias(),nf.getExpression());
                            newFields.add(f2);
                        }
                    }
                }
                qs.clearFields();
                for (QueryField newField : newFields) {
                    qs.field(newField);
                }
                m.setStatement(qs);
                for (ResultField newResult : newResults) {
                    m.addField(newResult);
                }
            } else if (q instanceof Union) {
                List<QueryStatement> context2=new ArrayList<QueryStatement>();
                context2.addAll(context);
                context2.add(q);

                Union u0 = (Union) q;
                Union u = new Union();
                ResultField[] fields = null;
                for (QueryStatement qs : u0.getQueryStatements()) {
                    ResultMetaData resultMetaData = createResultMetaData(qs, fieldFilter,context2);
                    u.add((QueryStatement) resultMetaData.getStatement());
                    List<ResultField> f = resultMetaData.getResultFields();
                    if (fields == null) {
                        fields = f.toArray(new ResultField[f.size()]);
                    } else {
                        if (fields.length != f.size()) {
                            throw new UPAException("InvalidUnion");
                        }
                        for (int i = 0; i < fields.length; i++) {
                            fields[i] = merge(fields[i], f.get(i));
                        }
                    }
                }
                m.setStatement(u);
                if(fields!=null) {
                    for (ResultField field : fields) {
                        m.addField(field);
                    }
                }
            } else {
                throw new UnsupportedOperationException();
            }
        }
        return m;

    }

    protected ResultField merge(ResultField first,ResultField second){
        throw new UPAException("NoSupportedYet");
    }

    protected List<ResultField> createResultFields(Expression expression, String alias, FieldFilter fieldFilter, List<QueryStatement> context){
        expression = expressionManager.parseExpression(expression);
        List<ResultField> results=new ArrayList<ResultField>();
        if(expression instanceof Var){
            Var v=(Var) expression;
            Expression parent = v.getApplier();
            if(parent !=null){
                List<ResultField> parentResults = createResultFields(parent, null, fieldFilter, context);
                int size = parentResults.size();
                for (ResultField p : parentResults) {
                    if(size>1){
                        v=(Var) v.copy();
                    }
                    if(p.getExpression()!=parent){
                        //change parent
                        v.setApplier((Var) p.getExpression());
                    }
                    if(p.getEntity()!=null){
                        if(v.getName().equals("*")){
                            for (Field field : p.getEntity().getFields(fieldFilter)) {
                                results.add(new DefaultResultField(v, alias, field.getDataType(), field, null));
                            }
                        }else {
                            Field field = p.getEntity().getField(v.getName());
                            results.add(new DefaultResultField(v, alias, field.getDataType(), field, null));
                        }
                    }else if(p.getField()!=null){
                        Relationship manyToOneRelationship= p.getField().getManyToOneRelationship();
                        if(manyToOneRelationship!=null){
                            Entity entity = manyToOneRelationship.getTargetEntity();
                            if(v.getName().equals("*")){
                                for (Field field : entity.getFields(fieldFilter)) {
                                    results.add(new DefaultResultField(v, alias, field.getDataType(), field, null));
                                }
                            }else {
                                Field field = entity.getField(v.getName());
                                results.add(new DefaultResultField(v, alias, field.getDataType(), field, null));
                            }
                        }else{
                            results.add(new DefaultResultField(v,alias,TypesFactory.OBJECT, null,null));
                        }
                    }else{
                        results.add(new DefaultResultField(v,alias,TypesFactory.OBJECT, null,null));
                    }
                }
            }else{
                String name = v.getName();
                Map<String, NameOrQuery> declarations = findDeclarations(context);
                NameOrQuery r = declarations.get(name);
                if(r!=null){
                    if(r instanceof EntityName){
                        Entity entity = pu.getEntity(((EntityName) r).getName());
                        results.add(new DefaultResultField(v,alias,entity.getDataType(), null,entity));
                    }else{
                        results.add(new DefaultResultField(v,alias,TypesFactory.OBJECT, null,null));
                    }
                }else{
                    if("*".equals(name)){
                        for (Map.Entry<String, NameOrQuery> entry : declarations.entrySet()) {
                            r = entry.getValue();
                            if (r instanceof EntityName) {
                                Entity entity = pu.getEntity(((EntityName) r).getName());
                                Field field = entity.findField(name);
                                results.add(new DefaultResultField(v, alias, field.getDataType(), field, null));
                                break;
                            }
                        }
                    }else {
                        Field field = null;
                        for (Map.Entry<String, NameOrQuery> entry : declarations.entrySet()) {
                            r = entry.getValue();
                            if (r instanceof EntityName) {
                                Entity entity = pu.getEntity(((EntityName) r).getName());
                                field = entity.findField(name);
                                break;
                            }
                        }
                        if (field != null) {
                            results.add(new DefaultResultField(v, alias, field.getDataType(), field, null));
                        } else {
                            results.add(new DefaultResultField(v, alias, TypesFactory.OBJECT, null, null));
                        }
                    }
                }
            }
            return results;
        }
        results.add(new DefaultResultField(expression, alias, TypesFactory.OBJECT, null, null));
        return results;
    }

    private Map<String,NameOrQuery> findDeclarations(List<QueryStatement> queryStatements){
        Map<String,NameOrQuery> names=new HashMap<String, NameOrQuery>();
        for (int i = 0; i < queryStatements.size(); i++) {
            names.putAll(findDeclarations(queryStatements.get(0)));
        }
        return names;
    }

    private Map<String,NameOrQuery> findDeclarations(QueryStatement queryStatement){
        Map<String,NameOrQuery> names=new HashMap<String, NameOrQuery>();
        if(queryStatement instanceof Select){
           Select s=(Select) queryStatement;
            if(!StringUtils.isNullOrEmpty(s.getEntityAlias()) ){
                names.put(s.getEntityAlias(),s.getEntity());
            }else{
                String t = s.getEntityName();
                if(!StringUtils.isNullOrEmpty(t)){
                    names.put(s.getEntityAlias(),s.getEntity());
                }
            }
            for (JoinCriteria j : s.getJoins()) {
                if(!StringUtils.isNullOrEmpty(j.getEntityAlias()) ){
                    names.put(j.getEntityAlias(),j.getEntity());
                }else{
                    String t = j.getEntityName();
                    if(!StringUtils.isNullOrEmpty(t)){
                        names.put(j.getEntityAlias(),j.getEntity());
                    }
                }
            }
        }else if(queryStatement instanceof Union){
            // do nothing
        }
        return names;
    }
}
