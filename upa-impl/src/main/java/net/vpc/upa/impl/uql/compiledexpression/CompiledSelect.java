package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.QLParameter;
import net.vpc.upa.expressions.*;

import java.util.*;

import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.impl.uql.DecObjectType;
import net.vpc.upa.types.DataTypeTransform;

public class CompiledSelect extends DefaultCompiledEntityStatement
        implements CompiledQueryStatement, Cloneable, CompiledNameOrSelect {

    private static final long serialVersionUID = 1L;
    //    public static final String SEPARATORS = " \n\t*+-/()[],;\\%";
    private int top = -1;
    private boolean distinct;
    private String query;
    private DefaultCompiledExpression where;
    private DefaultCompiledExpression having;
    private List<CompiledJoinCriteria> joinsTables;
    private List<CompiledQueryField> fields;
    //    private Vector groupByList;
    private List<DefaultCompiledExpression> groupByExpressions = new ArrayList<DefaultCompiledExpression>(1);
    private CompiledOrder order;
    private CompiledNameOrSelect queryEntity;
    private String queryEntityAlias;
    private String title;
    private boolean groupingEnabled;
    private ArrayList<QLParameter> parameters;

    @Override
    public DataTypeTransform getTypeTransform() {
        if (fields.size() == 1) {
            DataTypeTransform type = fields.get(0).getExpression().getTypeTransform();
            return type == null ? IdentityDataTypeTransform.VOID : type;
        }
        return IdentityDataTypeTransform.VOID;
    }

//    public void compile(PersistenceUnitFilter database) {
//        compiledSQL = SQLUtils.fillParameters(this, database);
//    }
    public CompiledSelect(CompiledSelect other) {
        this();
        addQuery(other);
    }

    public CompiledSelect() {
        query = null;
        joinsTables = new ArrayList<CompiledJoinCriteria>();
        fields = new ArrayList<CompiledQueryField>(1);
//        groupByList = new Vector(1);
        groupByExpressions = new ArrayList<DefaultCompiledExpression>();
        order = new CompiledOrder();
    }

    public CompiledSelect field(DefaultCompiledExpression expression) {
        return field(expression, null);
    }

    public CompiledSelect uplet(DefaultCompiledExpression[] expression, String alias) {
        if (expression.length == 1) {
            return field(expression[0], alias);
        } else {
            return field(new CompiledUplet(expression), alias);
        }
    }

    public CompiledSelect uplet(DefaultCompiledExpression... expression) {
        if (expression.length == 1) {
            return field(expression[0]);
        } else {
            return field(new CompiledUplet(expression));
        }
    }

    //    public Select field(Expression expression, String alias) {
//        return field(expression, alias/*, null*/);
//    }
    public CompiledQueryField addField(CompiledQueryField compiledQueryField) {
        invalidate();
        fields.add(compiledQueryField);
        return compiledQueryField;
    }

    public CompiledQueryField addField(DefaultCompiledExpression expression, String alias) {
        invalidate();
        CompiledQueryField f = new CompiledQueryField(alias, expression);
        fields.add(f);
        prepareChildren(f.getExpression());
        return f;
    }

    public CompiledQueryField addField(int index, DefaultCompiledExpression expression, String alias) {
        invalidate();
        CompiledQueryField field = new CompiledQueryField(alias, expression);
        fields.add(index, field);
        prepareChildren(field.getExpression());
        return field;
    }

    public CompiledSelect field(DefaultCompiledExpression expression, String alias) {
        addField(expression, alias);
        return this;
    }

    public CompiledSelect field(int index, DefaultCompiledExpression expression, String alias) {
        addField(index, expression, alias);
        return this;
    }

    public CompiledSelect removeField(int index) {
        invalidate();
        fields.remove(index);
        return this;
    }

    public CompiledSelect removeAllFields() {
        invalidate();
        fields.clear();
        return this;
    }

    public int countFields() {
        return fields.size();
    }

    public List<CompiledQueryField> getFields() {
        return PlatformUtils.unmodifiableList(fields);
    }

    public CompiledQueryField getField(int i) {
        return (CompiledQueryField) fields.get(i);
    }

    //    public Expression getField(int i) {
//        return getFieldInfo(i).expression;
//    }
//
//    public String getFieldAlias(int i) {
//        return (String) fields.getKey(i);
//    }
//    public FieldInfo getFieldInfo(String alias) {
//        return (FieldInfo) fields.get(alias);
//    }
//    public Expression getField(String alias) {
//        return getFieldInfo(alias).expression;
//    }
//    public Object getFieldRelative(String alias) {
//        return getFieldInfo(alias).relative;
//    }
//
//    public Object getFieldRelative(int index) {
//        return getFieldInfo(index).relative;
//    }
    public int indexOf(DefaultCompiledExpression field) {
        for (int i = 0; i < fields.size(); i++) {
            CompiledQueryField info = fields.get(i);
            if (field.equals(info.getExpression())) {
                return i;
            }
        }
        return -1;
    }

    //    public boolean containsField(Expression expression) {
//        return fields.containsValue(expression);
//    }
//
//    public boolean containsFieldAlias(String alias) {
//        return fields.containsKey(alias);
//    }
    public CompiledSelect from(CompiledNameOrSelect queryEntity, String entityAlias) {
        invalidate();
        //getContext().declare(alias, queryEntity);
        this.queryEntity = queryEntity;
        queryEntityAlias = entityAlias;
        prepareChildren(queryEntity);
        exportDeclaration(queryEntity, entityAlias);
        return this;
    }

    protected void exportDeclaration(CompiledNameOrSelect e, String entityAlias) {
        if (e instanceof CompiledEntityName) {
            exportDeclaration(entityAlias, DecObjectType.ENTITY, ((CompiledEntityName) e).getName(), null);
        } else {
            exportDeclaration(entityAlias, DecObjectType.SELECT, e, null);
        }
    }

    public CompiledSelect from(String entityName) {
        return from(new CompiledEntityName(entityName), null);
    }

    public CompiledSelect from(String entityName, String alias) {
        return from(new CompiledEntityName(entityName), alias);
    }

    public CompiledSelect from(CompiledSelect view) {
        return from(view, null);
    }

    public String getEntityName() {
        if (queryEntity != null && queryEntity instanceof CompiledEntityName) {
            CompiledEntityName s = (CompiledEntityName) queryEntity;
            return s.getName();
        }
        return null;
    }

    public CompiledNameOrSelect getEntity() {
        return queryEntity;
    }

    public String getEntityAlias() {
//        return entityAlias == null ? (entity instanceof String) ? (String) entity : null : entityAlias;
        return queryEntityAlias;
    }

    private CompiledSelect join(JoinType joinType, CompiledNameOrSelect entityName, String alias, DefaultCompiledExpression condition) {
        invalidate();
        join(new CompiledJoinCriteria(joinType, entityName, alias, condition));
        //getContext().declare(alias, entityName);
        return this;
    }

    public CompiledSelect join(CompiledJoinCriteria someJoin) {
        joinsTables.add(someJoin);
        prepareChildren(someJoin);
        exportDeclaration(someJoin.getEntity(), someJoin.getEntityAlias());
        return this;
    }

    public CompiledSelect join(String entityName, String alias, DefaultCompiledExpression condition) {
        return join(JoinType.INNER_JOIN, new CompiledEntityName(entityName), alias, condition);
    }

    public CompiledSelect join(CompiledSelect entityName, String alias, DefaultCompiledExpression condition) {
        return join(JoinType.INNER_JOIN, entityName, alias, condition);
    }

    public CompiledSelect innerJoin(String entityName, String alias, DefaultCompiledExpression condition) {
        return join(JoinType.INNER_JOIN, new CompiledEntityName(entityName), alias, condition);
    }

    public CompiledSelect innerJoin(CompiledSelect entityName, String alias, DefaultCompiledExpression condition) {
        return join(JoinType.INNER_JOIN, entityName, alias, condition);
    }

    public CompiledSelect leftJoin(String entityName, String alias, DefaultCompiledExpression condition) {
        return join(JoinType.LEFT_JOIN, new CompiledEntityName(entityName), alias, condition);
    }

    public CompiledSelect leftJoin(CompiledSelect entityName, String alias, DefaultCompiledExpression condition) {
        return join(JoinType.LEFT_JOIN, entityName, alias, condition);
    }

    public CompiledSelect rightJoin(String entityName, String alias, DefaultCompiledExpression condition) {
        return join(JoinType.RIGHT_JOIN, new CompiledEntityName(entityName), alias, condition);
    }

    public CompiledSelect rightJoin(CompiledSelect entityName, String alias, DefaultCompiledExpression condition) {
        return join(JoinType.RIGHT_JOIN, entityName, alias, condition);
    }

    public CompiledSelect fullJoin(String entityName, String alias, DefaultCompiledExpression condition) {
        return join(JoinType.FULL_JOIN, new CompiledEntityName(entityName), alias, condition);
    }

    public CompiledSelect fullJoin(CompiledSelect entityName, String alias, DefaultCompiledExpression condition) {
        return join(JoinType.FULL_JOIN, entityName, alias, condition);
    }

    public CompiledSelect crossJoin(String entityName) {
        return join(JoinType.CROSS_JOIN, new CompiledEntityName(entityName), null, null);
    }

    public CompiledSelect crossJoin(String entityName, String alias) {
        return join(JoinType.CROSS_JOIN, new CompiledEntityName(entityName), alias, null);
    }

    public CompiledSelect crossJoin(CompiledSelect entityName, String alias) {
        return join(JoinType.CROSS_JOIN, entityName, alias, null);
    }

    public int countJoins() {
        return joinsTables.size();
    }

    public CompiledJoinCriteria[] getJoins() {
        List<CompiledJoinCriteria> values = joinsTables;
        return values.toArray(new CompiledJoinCriteria[values.size()]);
    }

    public CompiledJoinCriteria getJoin(int i) {
        return joinsTables.get(i);
    }

//    public JoinCriteria getJoin(String alias) {
//        return (JoinCriteria) joinsTables.get(alias);
//    }
    public CompiledSelect orderBy(CompiledOrder order) {
        if (order != null) {
            invalidate();
            this.order.addOrder(order);
            for (int i = 0; i < order.size(); i++) {
                prepareChildren(order.getOrderAt(i));
            }
        }
        return this;
    }

    public CompiledSelect orderAscendentBy(DefaultCompiledExpression field) {
        invalidate();
        order.ascendent(field);
        prepareChildren(field);
        return this;
    }

    public CompiledSelect orderByDesc(DefaultCompiledExpression field) {
        invalidate();
        order.descendent(field);
        prepareChildren(field);
        return this;
    }

    public CompiledSelect orderBy(DefaultCompiledExpression field, boolean isAscending) {
        invalidate();
        order.addOrder(field, isAscending);
        prepareChildren(field);
        return this;
    }

    public CompiledSelect orderBy(int position, DefaultCompiledExpression field, boolean isAscending) {
        invalidate();
        order.insertOrder(position, field, isAscending);
        prepareChildren(field);
        return this;
    }

    //    public Select ascendent() {
//        invalidateStructureCache();
//        orderAsc = true;
//        return this;
//    }
//
//    public Select descendent() {
//        invalidateStructureCache();
//        orderAsc = false;
//        return this;
//    }
    public CompiledSelect noOrder() {
        invalidate();
//        orderAsc = true;
        order.noOrder();
        return this;
    }

    public CompiledSelect removeOrder(int index) {
        invalidate();
        order.removeOrder(index);
        return this;
    }

    public boolean isOrdered() {
        return order.size() != 0;
    }

    public boolean isOrderAscending(int index) {
        return order.isAscendentAt(index);
    }

    public DefaultCompiledExpression getOrderBy(int index) {
        return order.getOrderAt(index);
    }

    public int countOrderByItems() {
        return order.size();
    }

    public CompiledSelect groupBy(DefaultCompiledExpression field) {
        invalidate();
        groupByExpressions.add(field);
        prepareChildren(field);
        return this;
    }

    public boolean isGrouped() {
        return groupByExpressions.size() > 0;
    }

    public DefaultCompiledExpression getGroupBy(int i) {
        return groupByExpressions.get(i);
    }

    public int countGroupByItems() {
        return groupByExpressions.size();
    }

    public CompiledSelect where(DefaultCompiledExpression condition) {
        this.where = condition;
        prepareChildren(condition);
        return this;
    }

    public CompiledSelect having(DefaultCompiledExpression having) {
        this.having = having;
        prepareChildren(having);
        return this;
    }

    public DefaultCompiledExpression getWhere() {
        return where;
    }

    public DefaultCompiledExpression getHaving() {
        return having;
    }

    @Override
    public boolean isValid() {
        return queryEntity != null && fields.size() > 0;
    }

    public DefaultCompiledExpression copy() {
        CompiledSelect o = new CompiledSelect();
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        o.addQuery(this);
        return o;
    }

    public synchronized CompiledSelect addWhere(DefaultCompiledExpression condition) {
        if (condition != null) {
            if (this.where == null) {
                where(condition);
            } else {
                this.where.unsetParent();
                where(new CompiledAnd(this.where, condition));
            }
        }
        invalidate();
        return this;
    }

    public synchronized CompiledSelect addHaving(DefaultCompiledExpression condition) {
        if (condition != null) {
            if (this.where == null) {
                having(condition);
            } else {
                this.where.unsetParent();
                having(new CompiledAnd(this.where, condition));
            }
        }
        invalidate();
        return this;
    }

    public synchronized CompiledSelect addQuery(CompiledSelect other) {
        if (other == null) {
            return this;
        }

        if (other.queryEntity != null) {
            from((CompiledNameOrSelect) (other.queryEntity.copy()), other.queryEntityAlias);
        }
        for (int i = 0; i < other.joinsTables.size(); i++) {
            CompiledJoinCriteria j = other.getJoin(i);
            CompiledNameOrSelect ee = j.getEntity();
            DefaultCompiledExpression cc = j.getCondition();
            join(j.getJoinType(), ee == null ? null : (CompiledNameOrSelect) ee.copy(), j.getEntityAlias(), cc == null ? null : cc.copy());
        }
        for (CompiledQueryField field : other.fields) {
            DefaultCompiledExpression ee = field.getExpression();
            addField(ee == null ? null : ee.copy(), field.getAlias());
        }
        for (CompiledOrderItem compiledOrderItem : other.order.getItems()) {
            DefaultCompiledExpression ee = compiledOrderItem.getExpression();
            orderBy(ee == null ? null : ee.copy(), compiledOrderItem.isAsc());
        }
        for (DefaultCompiledExpression e : other.groupByExpressions) {
            groupBy(e == null ? null : e.copy());
        }
        addWhere(other.where == null ? null : other.where.copy());
        addHaving(other.having == null ? null : other.having.copy());
        invalidate();
        return this;
    }

    private void invalidate() {
        query = null;
    }

    public boolean isDistinct() {
        return distinct;
    }

    public void setDistinct(boolean distinct) {
        this.distinct = distinct;
    }

    public CompiledSelect distinct() {
        invalidate();
        setDistinct(true);
        return this;
    }

    public CompiledSelect all() {
        invalidate();
        setDistinct(false);
        return this;
    }

    public CompiledSelect selectTop(int count) {
        invalidate();
        top = count;
        return this;
    }

//    public String toSQLPattern(PersistenceUnitFilter database) {
//        return toSQLPattern(false, database);
//    }
    public String getMainTableName() {
        CompiledNameOrSelect t = getEntity();
        return ((getEntity() instanceof CompiledEntityName) ? ((CompiledEntityName) (getEntity())).getName() : null);
    }

    public String[] getColumnTitles() {
        return null;
    }

    public String getQueryTitle() {
        if (title != null) {
            return title;
        }
        String d = getQueryDescription();
        if (d == null || !d.toUpperCase().startsWith("<HTML>")) {
            return d;
        }
        return d;//HtmlUtils.htmlToPlainText(d);
    }

    public void setQueryTitle(String title) {
        this.title = title;
    }

    public String getQueryDescription() {
        return getDescription();
    }

    public void setQueryDescription(String desc) {
        setDescription(desc);
    }

    public boolean isGroupingEnabled() {
        return groupingEnabled;
    }

    public void setGroupingEnabled(boolean groupingEnabled) {
        this.groupingEnabled = groupingEnabled;
    }

    public ArrayList<QLParameter> getParameters() {
        return parameters;
    }

    public void setParameters(ArrayList<QLParameter> parameters) {
        this.parameters = parameters;
    }

    public void addParameter(QLParameter p) {
        if (parameters == null) {
            parameters = new ArrayList<QLParameter>();
        }
        parameters.add(p);
    }

//    public String toString() {
//        return toSQLPattern(false, DatabaseManager.getInstance().getPersistenceUnit());
//    }
    @Override
    public DefaultCompiledExpression[] getSubExpressions() {
        ArrayList<DefaultCompiledExpression> sub = new ArrayList<DefaultCompiledExpression>();

        if (fields != null) {
            for (CompiledQueryField field : fields) {
                sub.add(field.getExpression());
            }
        }
        if (queryEntity != null) {
            sub.add(queryEntity);
        }
        if (joinsTables != null) {
            for (CompiledJoinCriteria joinCriteria : joinsTables) {
                sub.add(joinCriteria);
            }
        }
        if (groupByExpressions != null) {
            int size = groupByExpressions.size();
            for (int i = 0; i < size; i++) {
                sub.add(groupByExpressions.get(i));
            }
        }
        if (order != null) {
            int size = order.size();
            for (int i = 0; i < size; i++) {
                sub.add(order.getOrderAt(i));
            }
        }
        if (where != null) {
            sub.add(where);
        }
        if (having != null) {
            sub.add(having);
        }
        return sub.toArray(new DefaultCompiledExpression[sub.size()]);
    }

    @Override
    public void setSubExpression(int index, DefaultCompiledExpression expression) {
        int i = 0;

        if (fields != null) {
            for (CompiledQueryField field : fields) {
                if (i == index) {
                    field.setExpression(expression);
                    if (expression != null) {
                        expression.setParentExpression(this);
                    }
                    return;
                }
                i++;
            }
        }
        if (queryEntity != null) {
            if (i == index) {
                queryEntity = (CompiledNameOrSelect) expression;
                if (expression != null) {
                    expression.setParentExpression(this);
                }
                return;
            }
            i++;
        }
        if (joinsTables != null) {
            for (int ii = 0; ii < joinsTables.size(); ii++) {
                if (i == index) {
                    joinsTables.set(ii, (CompiledJoinCriteria) expression);
                    if (expression != null) {
                        expression.setParentExpression(this);
                    }
                    return;
                }
                i++;
            }
        }
        if (groupByExpressions != null) {
            int size = groupByExpressions.size();
            for (int j = 0; j < size; j++) {
                if (i == index) {
                    groupByExpressions.set(j, expression);
                    if (expression != null) {
                        expression.setParentExpression(this);
                    }
                    return;
                }
                i++;
            }
        }
        if (order != null) {
            int size = order.size();
            for (int j = 0; j < size; j++) {
                if (i == index) {
                    order.setOrderAt(j, expression);
                    if (expression != null) {
                        expression.setParentExpression(this);
                    }
                    return;
                }
                i++;
            }
        }
        if (where != null) {
            if (i == index) {
                where = expression;
                if (expression != null) {
                    expression.setParentExpression(this);
                }
            }
            i++;
        }
        if (having != null) {
            if (i == index) {
                having = expression;
                if (expression != null) {
                    expression.setParentExpression(this);
                }
            }
            i++;
        }
    }

    public int getTop() {
        return top;
    }

    public void setTop(int top) {
        this.top = top;
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder("Select ");
        if (top > 0) {
            sb.append(" TOP ").append(top);
        }
        if (distinct) {
            sb.append(" DISTINCT");
        }
        sb.append(" ");
        String aliasString = null;
        String valueString = null;
        boolean started = false;
        if (countFields() == 0) {
            sb.append("...");
        } else {
            for (int i = 0; i < countFields(); i++) {
                CompiledQueryField fi = getField(i);
                DefaultCompiledExpression e = fi.getExpression();
                valueString = String.valueOf(e);
                if(!(e instanceof CompiledVar) && !(e instanceof CompiledParam) && !(e instanceof CompiledFunction) && !(e instanceof CompiledLiteral)){
                    valueString="("+valueString+")";
                }
                aliasString = fi.getAlias();
                if (started) {
                    sb.append(",");
                } else {
                    started = true;
                }
                if (aliasString == null/* || valueString.equals(aliasString)*/) {
                    sb.append(valueString);
                } else {
                    sb.append(valueString);
                    sb.append(" ");
                    sb.append(aliasString);
                }
            }

        }
        if (getEntity() == null) {
            //sb.append("...");
        } else {
            sb.append(" From ");
            if (getEntity() instanceof CompiledSelect) {
                sb.append(getEntity().toString());
            } else {
                CompiledEntityName entityName = (CompiledEntityName) getEntity();
                sb.append(entityName);
            }
        }
        if (getEntityAlias() != null) {
            sb.append(" ").append(getEntityAlias());
        }
        for (int i = 0; i < countJoins(); i++) {
            CompiledJoinCriteria e = getJoin(i);
            sb.append(" ").append(e);
        }
        final DefaultCompiledExpression c = getWhere();

        if (c != null && c.isValid()) {
            sb.append(" Where ").append(c);
        }
        if (countGroupByItems() > 0) {
            sb.append(" ");
            int maxGroups = countGroupByItems();
            sb.append("Group By ");
            for (int i = 0; i < maxGroups; i++) {
                if (i > 0) {
                    sb.append(", ");
                }
                sb.append(getGroupBy(i));
            }
        }
        int maxOrders = countOrderByItems();
        if (maxOrders > 0) {
            sb.append(" ");
            sb.append("Order By ");
            for (int i = 0; i < maxOrders; i++) {
                if (i > 0) {
                    sb.append(", ");
                }
                sb.append(getOrderBy(i));
                if (isOrderAscending(i)) {
                    sb.append(" Asc ");
                } else {
                    sb.append(" Desc ");
                }
            }
        }
        return sb.toString();
    }

    protected List<CompiledNamedExpression> findEntityDefinitions() {
        ArrayList<CompiledNamedExpression> list = new ArrayList<CompiledNamedExpression>();
        list.add(new CompiledNamedExpression(getEntityAlias(), getEntity()));
        for (CompiledJoinCriteria jc : getJoins()) {
            list.add(new CompiledNamedExpression(jc.getEntityAlias(), jc.getEntity()));
        }
        return list;
    }
}
