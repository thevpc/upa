/**
 * ====================================================================
 * UPA (Unstructured Persistence API)
 *    Yet another ORM Framework
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
 *
 * Copyright (C) 2014-2015 Taha BEN SALAH
 *
 * This program is free software; you can redistribute it and/or modify it under
 * the terms of the GNU General Public License as published by the Free Software
 * Foundation; either version 2 of the License, or (at your option) any later
 * version.
 *
 * This program is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
 * FOR A PARTICULAR PURPOSE. See the GNU General Public License for more
 * details.
 *
 * You should have received a copy of the GNU General Public License along with
 * this program; if not, write to the Free Software Foundation, Inc., 51
 * Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
 * ====================================================================
 */
package net.vpc.upa.expressions;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class InCollection extends DefaultExpression
        implements Cloneable {

    private static final long serialVersionUID = 1L;
    private static final DefaultTag LEFT = new DefaultTag("LEFT");

    private Expression left;
    protected List<Expression> right;

    public InCollection(Expression left) {
        this(left, (List<Expression>) null);
    }

    public InCollection(Expression[] left) {
        this(new Uplet(left), (List<Expression>) null);
    }

//    public InCollection(String left,DataPrimitiveType type,Collection collection) {
//        this(new Var(left,type),collection);
//    }
//    public InCollection(String left,DataPrimitiveType type,Object[] collection) {
//        this(new Var(left,type),collection!=null ? Arrays.asList(collection) : null);
//    }
    public InCollection(Expression[] left, List<Expression> collection) {
        this(new Uplet(left), collection);
    }

    public InCollection(Expression left, Expression[] collection) {
        this(left, collection != null ? Arrays.asList(collection) : null);
    }

    public InCollection(Expression left, List<Expression> collection) {
        this.left = left;
        right = new ArrayList<Expression>(1);
        if (collection != null) {
            for (Object aCollection : collection) {
                add(aCollection);
            }
        }
    }

    @Override
    public List<TaggedExpression> getChildren() {
        List<TaggedExpression> list = new ArrayList<TaggedExpression>();
        if (left != null) {
            list.add(new TaggedExpression(left, LEFT));
        }
        for (int i = 0; i < right.size(); i++) {
            Expression r = right.get(i);
            list.add(new TaggedExpression(r, new IndexedTag("RIGTH", i)));
        }
        return list;
    }

    @Override
    public void setChild(Expression e, ExpressionTag tag) {
        if (tag.equals(LEFT)) {
            this.left = e;
        } else {
            right.set(((IndexedTag) tag).getIndex(), e);
        }
    }

//    public int size() {
//        return 2;
//    }
    public Expression getLeft() {
        return left;
    }

    public void add(Object e) {
        right.add(ExpressionFactory.toExpression(e, Literal.class));
    }

    public void add(Expression e) {
        right.add(e);
    }

    public void add(Expression[] e) {
        right.add(new Uplet(e));
    }

//    public synchronized String toSQL(boolean integrated, PersistenceUnit database) {
//        StringBuffer sb = new StringBuffer();
//        int mySize=right.size();
//        if ( mySize== 0) {
//            sb.append("1 <> 1");
//        }else {
//            if (mySize == 1) {
//                sb.append(left.toSQL(database));
//                Expression e = (Expression) right.get(0);
//                if (e == null || (e instanceof Literal && ((Literal)e).getValue()==null)) {
//                    sb.append(" IS NULL");
//                } else {
//                    sb.append(" = ");
//                    sb.append(e.toSQL(true, database));
//                }
//            } else {
//                sb.append(left.toSQL(database));
//                sb.append(" IN (");
//                for (int i = 0; i < mySize; i++) {
//                    if (i > 0)
//                        sb.append(",");
//                    Expression e = (Expression) right.get(i);
//                    if(e==null){
//                        sb.append("NULL");
//                    }else{
//                        sb.append(e.toSQL(true, database));
//                    }
//                }
//
//                sb.append(")");
//            }
//        }
//        return integrated ? '(' + sb.toString() + ')' : sb.toString();
//    }
    public int getRightSize() {
        return right.size();
    }

    public Expression getRight(int i) {
        return right.get(i);
    }

    public Expression[] getRight() {
        return right.toArray(new Expression[right.size()]);
    }

    @Override
    public Expression copy() {
        InCollection o = new InCollection(left.copy());
        for (Expression expression : right) {
            o.add(expression);
        }
        return o;
    }

}
