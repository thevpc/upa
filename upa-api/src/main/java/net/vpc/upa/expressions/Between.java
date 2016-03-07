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

// Referenced classes of package net.vpc.lib.pheromone.ariana.database.sql:
import java.util.ArrayList;
import java.util.List;

//            Expression, Litteral
public class Between extends DefaultExpression
        implements Cloneable {

    private static final DefaultTag LEFT = new DefaultTag("Left");
    private static final DefaultTag MIN = new DefaultTag("Min");
    private static final DefaultTag MAX = new DefaultTag("Max");
    private static final long serialVersionUID = 1L;
    private Expression left;
    private Expression min;
    private Expression max;

    private Between() {

    }

    public Between(Expression expression, Object min, Object max) {
        this(expression, ExpressionFactory.toLiteral(min), ExpressionFactory.toLiteral(max));
    }

    public Between(Expression expression, Expression min, Expression max) {
        left = expression;
        this.min = min;
        this.max = max;
    }

    @Override
    public List<TaggedExpression> getChildren() {
        List<TaggedExpression> list = new ArrayList<TaggedExpression>();
        if (left != null) {
            list.add(new TaggedExpression(left, LEFT));
        }
        if (min != null) {
            list.add(new TaggedExpression(min, MIN));
        }
        if (max != null) {
            list.add(new TaggedExpression(max, MAX));
        }
        return list;
    }

    @Override
    public void setChild(Expression e, ExpressionTag tag) {
        if (tag.equals(LEFT)) {
            this.left = e;
        } else if (tag.equals(MIN)) {
            this.min = e;
        } else if (tag.equals(MAX)) {
            this.max = e;
        } else {
            throw new IllegalArgumentException("Insupported");
        }
    }

    public Expression getLeft() {
        return left;
    }

    public Expression getMin() {
        return min;
    }

    public Expression getMax() {
        return max;
    }

    public boolean isValid() {
        return (left != null && left.isValid()) && (min != null && min.isValid()) && (max != null && max.isValid());
    }

    public Expression copy() {
        Between o = new Between();
        o.left = left.copy();
        o.min = min.copy();
        o.max = max.copy();
        return o;
    }
}
