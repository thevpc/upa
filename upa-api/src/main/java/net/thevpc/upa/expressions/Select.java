/**
 * ====================================================================
 * UPA (Unstructured Persistence API)
 * Yet another ORM Framework
 * ++++++++++++++++++++++++++++++++++
 * Unstructured Persistence API, referred to as UPA, is a genuine effort
 * to raise programming language frameworks managing relational data in
 * applications using Java Platform, Standard Edition and Java Platform,
 * Enterprise Edition and Dot Net Framework equally to the next level of
 * handling ORM for mutable data structures. UPA is intended to provide
 * a solid reflection mechanisms to the mapped data structures while
 * affording to make changes at runtime of those data structures.
 * Besides, UPA has learned considerably of the leading ORM
 * (JPA, Hibernate/NHibernate, MyBatis and Entity Framework to name a few)
 * failures to satisfy very common even known to be trivial requirement in
 * enterprise applications.
 * <p>
 * Copyright (C) 2014-2015 Taha BEN SALAH
 * <p>
 * This program is free software; you can redistribute it and/or modify it under
 * the terms of the GNU General Public License as published by the Free Software
 * Foundation; either version 2 of the License, or (at your option) any later
 * version.
 * <p>
 * This program is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
 * FOR A PARTICULAR PURPOSE. See the GNU General Public License for more
 * details.
 * <p>
 * You should have received a copy of the GNU General Public License along with
 * this program; if not, write to the Free Software Foundation, Inc., 51
 * Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
 * ====================================================================
 */
package net.thevpc.upa.expressions;

import net.thevpc.upa.QLParameter;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class Select extends DefaultEntityStatement
        implements QueryStatement, Cloneable {

    private static final DefaultTag ENTITY = new DefaultTag("ENTITY");
    private static final DefaultTag WEHRE = new DefaultTag("WEHRE");
    private static final DefaultTag HAVING = new DefaultTag("HAVING");
    private static final long serialVersionUID = 1L;
    //    public static final String SEPARATORS = " \n\t*+-/()[],;\\%";
    private int top = -1;
    private boolean distinct = false;

    private Expression where;
    private Expression having;
    private List<JoinCriteria> joinsEntities;
    private List<QueryField> fields;
    //    private Vector groupByList;
    private GroupCriteria group;
    private Order order;
    private NameOrQuery queryEntity;
    private String queryEntityAlias;
    private ArrayList<QLParameter> parameters;

    public Select(Select other) {
        this();
        addQuery(other);
    }

    @Override
    public List<QueryField> getFields() {
        return Collections.unmodifiableList(fields);
    }

    public Select() {
        joinsEntities = new ArrayList<JoinCriteria>(3);
        fields = new ArrayList<QueryField>(5);
//        groupByList = new Vector(1);
        group = new GroupCriteria();
        order = new Order();
        top = -1;
    }

    @Override
    public List<TaggedExpression> getChildren() {
        List<TaggedExpression> list = new ArrayList<TaggedExpression>(
                fields.size() + joinsEntities.size() + group.size() + order.size() + 3
        );

//    private Expression where;
//    private Expression having;
//    private Order order;
        if (queryEntity != null) {
            list.add(new TaggedExpression(queryEntity, ENTITY));
        }
        for (int i = 0; i < fields.size(); i++) {
            list.add(new TaggedExpression(fields.get(i).getExpression(), new IndexedTag("FIELD", i)));
        }
        for (int i = 0; i < joinsEntities.size(); i++) {
            JoinCriteria get = joinsEntities.get(i);
            list.add(new TaggedExpression(get.getEntity(), new IndexedTag("JOIN_ENTITY", i)));
            list.add(new TaggedExpression(get.getCondition(), new IndexedTag("JOIN_COND", i)));
        }
        if (where != null) {
            list.add(new TaggedExpression(where, WEHRE));
        }
        for (int i = 0; i < group.size(); i++) {
            Expression ee = group.getGroupAt(i);
            list.add(new TaggedExpression(ee, new IndexedTag("GROUP", i)));
        }
        if (having != null) {
            list.add(new TaggedExpression(having, HAVING));
        }
        for (int i = 0; i < order.size(); i++) {
            Expression ee = order.getOrderAt(i);
            list.add(new TaggedExpression(ee, new IndexedTag("ORDER", i)));
        }
        return list;
    }

    @Override
    public void setChild(Expression e, ExpressionTag tag) {
        if (ENTITY.equals(tag)) {
            this.queryEntity = (NameOrQuery) e;
        } else if (WEHRE.equals(tag)) {
            this.where = e;
        } else if (HAVING.equals(tag)) {
            this.having = e;
        } else {
            IndexedTag ii = (IndexedTag) tag;
            String en = ii.getName();
            if (en.equals("FIELD")) {
                fields.get(ii.getIndex()).setExpression(e);
            } else if (en.equals("JOIN_ENTITY")) {
                joinsEntities.get(ii.getIndex()).setEntity((NameOrQuery) e);
            } else if (en.equals("JOIN_COND")) {
                joinsEntities.get(ii.getIndex()).setCondition(e);
            } else if (en.equals("GROUP")) {
                group.setGroupAt(ii.getIndex(), e);
            } else if (en.equals("ORDER")) {
                order.setOrderAt(ii.getIndex(), e);
            }
        }
    }

    public Select field(Expression expression) {
        return field(expression, null);
    }

    public Select uplet(Expression[] expression, String alias) {
        if (expression.length == 1) {
            return field(expression[0], alias);
        } else {
            return field(new Uplet(expression), alias);
        }
    }

    public Select uplet(Expression... expression) {
        if (expression.length == 1) {
            return field(expression[0]);
        } else {
            return field(new Uplet(expression));
        }
    }

    //    public Select field(Expression expression, String alias) {
//        return field(expression, alias/*, null*/);
//    }
    public Select field(Expression expression, String alias) {
        field(new QueryField(alias, expression));
        return this;
    }

    public Select field(QueryField queryField) {
        fields.add(queryField);
        return this;
    }

    public Select field(String expression) {
        return field(expression, null);
    }

    public Select field(String expression, String alias) {
        fields.add(new QueryField(alias, new UserExpression(expression)));
        return this;
    }

    public Select field(int index, Expression expression, String alias) {
        fields.add(index, new QueryField(alias, expression));
        return this;
    }

    public Select clearFields() {
        fields.clear();
        return this;
    }

    public Select removeField(int index) {
        fields.remove(index);
        return this;
    }

    public int countFields() {
        return fields.size();
    }

    public QueryField getField(int i) {
        return (QueryField) fields.get(i);
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
    public int indexOf(Expression field) {
        for (int i = 0; i < fields.size(); i++) {
            QueryField info = fields.get(i);
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
    public Select from(NameOrQuery queryEntity, String alias) {
        //getContext().declare(alias, queryEntity);
        this.queryEntity = queryEntity;
        queryEntityAlias = alias;
        return this;
    }

    public Select from(String entityName) {
        return from(new EntityName(entityName), null);
    }

    public Select from(String entityName, String alias) {
        return from(new EntityName(entityName), alias);
    }

    public Select from(Select view) {
        return from(view, null);
    }

    public NameOrQuery getEntity() {
        return queryEntity;
    }

    public String getEntityName() {
        NameOrQuery e = getEntity();
        return (e != null && (e instanceof EntityName)) ? ((EntityName) e).getName() : null;
    }

    public String getEntityAlias() {
//        return entityAlias == null ? (entity instanceof String) ? (String) entity : null : entityAlias;
        return queryEntityAlias;
    }

    private Select join(JoinType joinType, NameOrQuery entity, String alias, Expression condition) {
        joinsEntities.add(new JoinCriteria(joinType, entity, alias, condition));
        return this;
    }

    public Select join(JoinCriteria someJoin) {
        join(someJoin.getJoinType(), someJoin.getEntity(), someJoin.getEntityAlias(), someJoin.getCondition());
        return this;
    }

    public Select join(String entity, String alias, Expression condition) {
        return join(JoinType.INNER_JOIN, new EntityName(entity), alias, condition);
    }

    public Select join(Select entity, String alias, Expression condition) {
        return join(JoinType.INNER_JOIN, entity, alias, condition);
    }

    public Select innerJoin(String entity, String alias, Expression condition) {
        return join(JoinType.INNER_JOIN, new EntityName(entity), alias, condition);
    }

    public Select innerJoin(Select entity, String alias, Expression condition) {
        return join(JoinType.INNER_JOIN, entity, alias, condition);
    }

    public Select leftJoin(String entity, String alias, Expression condition) {
        return join(JoinType.LEFT_JOIN, new EntityName(entity), alias, condition);
    }

    public Select leftJoin(Select entity, String alias, Expression condition) {
        return join(JoinType.LEFT_JOIN, entity, alias, condition);
    }

    public Select rightJoin(String entity, String alias, Expression condition) {
        return join(JoinType.RIGHT_JOIN, new EntityName(entity), alias, condition);
    }

    public Select rightJoin(Select entity, String alias, Expression condition) {
        return join(JoinType.RIGHT_JOIN, entity, alias, condition);
    }

    public Select fullJoin(String entity, String alias, Expression condition) {
        return join(JoinType.FULL_JOIN, new EntityName(entity), alias, condition);
    }

    public Select fullJoin(Select entity, String alias, Expression condition) {
        return join(JoinType.FULL_JOIN, entity, alias, condition);
    }

    public Select crossJoin(String entity) {
        return join(JoinType.CROSS_JOIN, new EntityName(entity), null, null);
    }

    public Select crossJoin(String entity, String alias) {
        return join(JoinType.CROSS_JOIN, new EntityName(entity), alias, null);
    }

    public Select crossJoin(Select entity, String alias) {
        return join(JoinType.CROSS_JOIN, entity, alias, null);
    }

    public int countJoins() {
        return joinsEntities.size();
    }

    public JoinCriteria[] getJoins() {
        List<JoinCriteria> values = joinsEntities;
        return (JoinCriteria[]) values.toArray(new JoinCriteria[values.size()]);
    }

    public JoinCriteria getJoin(int i) {
        return (JoinCriteria) joinsEntities.get(i);
    }

    //    public JoinCriteria getJoin(String alias) {
//        return (JoinCriteria) joinsEntities.get(alias);
//    }
    public Select orderBy(Order order) {
        if (order != null) {
            this.order.addOrder(order);
        }
        return this;
    }

    public Select orderAscendentBy(Expression field) {
        order.ascendant(field);
        return this;
    }

    public Select orderByDesc(Expression field) {
        order.descendant(field);
        return this;
    }

    public Select orderBy(Expression field, boolean isAscending) {
        order.addOrder(field, isAscending);
        return this;
    }

    public Select orderBy(int position, Expression field, boolean isAscending) {
        order.insertOrder(position, field, isAscending);
        return this;
    }

    //    public Select ascendant() {
//        invalidateStructureCache();
//        orderAsc = true;
//        return this;
//    }
//
//    public Select descendant() {
//        invalidateStructureCache();
//        orderAsc = false;
//        return this;
//    }
    public Select noOrder() {
//        orderAsc = true;
        order.noOrder();
        return this;
    }

    public Select removeOrder(int index) {
        order.removeOrder(index);
        return this;
    }

    public boolean isOrdered() {
        return order.size() != 0;
    }

    public boolean isOrderAscending(int index) {
        return order.isAscendentAt(index);
    }

    public Expression getOrderBy(int index) {
        return order.getOrderAt(index);
    }

    public int countOrderByItems() {
        return order.size();
    }

    public Order getOrder() {
        return order;
    }

    public Select groupBy(Expression field) {
        group.addGroup(field);
        return this;
    }

    public boolean isGrouped() {
        return group.size() > 0;
    }

    public Expression getGroupBy(int i) {
        return group.getGroupAt(i);
    }

    public int countGroupByItems() {
        return group.size();
    }

    /**
     * add where condition appending to existing condition using AND operator
     *
     * @param condition add where condition appending to existing condition
     * using AND operator
     * @return this Selection instance
     */
    public Select where(Expression condition) {
        if (condition != null) {
            Expression where = getWhere();
            if (where == null) {
                setWhere(condition);
            } else {
                setWhere(new And(where, condition));
            }
        }
        return this;
    }

    public Select updateWhere(Expression where) {
        setWhere(where);
        return this;
    }

    public void setWhere(Expression where) {
        this.where = where;
    }

    public Expression getWhere() {
        return where;
    }

    public Select having(Expression having) {
        if (having != null) {
            if (getHaving() == null) {
                setHaving(having);
            } else {
                setHaving(new And(getHaving(), having));
            }
        }
        return this;
    }

    public Select updateHaving(Expression having) {
        setHaving(having);
        return this;
    }

    public void setHaving(Expression having) {
        this.having = having;
    }

    public Expression getHaving() {
        return having;
    }

    @Override
    public boolean isValid() {
        return queryEntity != null && fields.size() > 0;
    }

    public Expression copy() {
        Select o = new Select();
        o.addQuery(this);
        return o;
    }

    public synchronized Select addQuery(Select other) {
        if (other == null) {
            return this;
        }

        if (other.queryEntity != null) {
            queryEntity = other.queryEntity;
        }
        if (other.queryEntityAlias != null) {
            queryEntityAlias = other.queryEntityAlias;
        }
        for (int i = 0; i < other.joinsEntities.size(); i++) {
            JoinCriteria j = other.getJoin(i);
            join(j.getJoinType(), j.getEntity(), j.getEntityAlias(), j.getCondition());
        }
        for (QueryField field : other.fields) {
            fields.add(new QueryField(field.getAlias(), field.getExpression().copy()));
        }
        order.addOrder(other.order.copy());
        group.addGroup(other.group.copy());

        this.where = (other.where != null) ? other.where.copy() : null;
        this.having = (other.having != null) ? other.having.copy() : null;
        return this;
    }

    public Select distinct() {
        distinct = true;
        return this;
    }

    public boolean isDistinct() {
        return distinct;
    }

    public Select updateDistinct(boolean distinct) {
        setDistinct(distinct);
        return this;
    }

    public void setDistinct(boolean distinct) {
        this.distinct = distinct;
    }

    //    public String toSQLPattern(PersistenceUnit database) {
//        return toSQLPattern(false, database);
//    }
    public String getMainEntityName() {
        NameOrQuery t = getEntity();
        return ((t instanceof EntityName) ? ((EntityName) t).getName() : null);
    }

    public ArrayList<QLParameter> getParameters() {
        return parameters;
    }

    public void setParameters(ArrayList<QLParameter> parameters) {
        this.parameters = parameters;
    }

    public void addParameter(QLParameter p) {
        if (parameters == null) {
            parameters = new ArrayList<QLParameter>(5);
        }
        parameters.add(p);
    }

    public int getTop() {
        return top;
    }

    public Select top(int top) {
        setTop(top);
        return this;
    }

    public void setTop(int top) {
        this.top = top <= 0 ? -1 : top;
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
                QueryField fi = getField(i);
                Expression e = fi.getExpression();
                valueString = String.valueOf(e);
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
                    sb.append(ExpressionHelper.escapeIdentifier(aliasString));
                }
            }

        }
        if (getEntity() == null) {
            //sb.append("...");
        } else {
            sb.append(" From ");
            if (getEntity() instanceof Select) {
                sb.append(getEntity().toString());
            } else {
                EntityName entityName = (EntityName) getEntity();
                sb.append(entityName);
            }
        }
        if (getEntityAlias() != null) {
            sb.append(" ").append(ExpressionHelper.escapeIdentifier(getEntityAlias()));
        }
        for (int i = 0; i < countJoins(); i++) {
            JoinCriteria e = getJoin(i);
            sb.append(" ").append(e);
        }
        final Expression c = getWhere();

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
}
