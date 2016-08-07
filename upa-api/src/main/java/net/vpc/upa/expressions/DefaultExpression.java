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
import java.util.List;
import java.util.Stack;

public abstract class DefaultExpression implements Expression {

    private static final long serialVersionUID = 1L;

    protected DefaultExpression() {
    }

    public boolean isValid() {
        return true;
    }

    @Override
    public Expression findOne(ExpressionFilter filter) {
        List<Expression> all = find(filter, true);
        return all.isEmpty() ? null : all.get(0);
    }

    @Override
    public List<Expression> findAll(ExpressionFilter filter) {
        return find(filter, false);
    }

    public void visit(ExpressionVisitor visitor) {
        Stack<TaggedExpression> stack = new Stack<TaggedExpression>();
        stack.push(new TaggedExpression(this, null));
        while (!stack.isEmpty()) {
            TaggedExpression e = stack.pop();
            Expression expr = e.getExpression();
            if (expr != null) {
                if (!visitor.visit(expr, e.getTag())) {
                    return;
                }
                List<TaggedExpression> c = expr.getChildren();
                if (c != null) {
                    for (TaggedExpression te : c) {
                        stack.push(te);
                    }
                }
            }
        }
    }

    public ExpressionTransformerResult transform(ExpressionTransformer transformer) {
        List<TaggedExpression> c = this.getChildren();
        boolean updated=false;
        ExpressionTransformerResult r;
        if (c != null) {
            for (TaggedExpression te : c) {
                r = te.getExpression().transform(transformer);
                if(r!=null) {
                    if (r.isChanged()) {
                        if (r.isUpdated()) {
                            updated = true;
                        }
                        if(r.isReplaced()){
                            setChild(r.getExpression(), te.getTag());
                        }
                    }
                }
            }
        }
        r = transformer.transform(this);
        if(r==null){
            return new ExpressionTransformerResult(
                    this,false,updated
            );
        }
        return new ExpressionTransformerResult(
                r.getExpression(),r.isReplaced(),
                r.isUpdated()||updated
        );
    }

    public List<Expression> find(ExpressionFilter filter, boolean firstResult) {
        ArrayList<Expression> found = new ArrayList<Expression>(firstResult?1:5);
        if (filter.accept(this)) {
            found.add(this);
            if (firstResult) {
                return found;
            }
        }
        for (TaggedExpression r : getChildren()) {
            if (firstResult) {
                Expression x = r.getExpression().findOne(filter);
                if (x != null) {
                    found.add(x);
                    return found;
                }
            } else {
                found.addAll(r.getExpression().findAll(filter));
            }
        }
        return found;
    }
}
