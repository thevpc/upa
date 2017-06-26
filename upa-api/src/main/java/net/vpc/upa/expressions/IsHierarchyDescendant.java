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
package net.vpc.upa.expressions;

//            Expression, Select
public final class IsHierarchyDescendant extends FunctionExpression
        implements Cloneable {

    private static final long serialVersionUID = 1L;
    private EntityName entityName;
    private Expression ancestorExpression;
    private Expression childExpression;

    public IsHierarchyDescendant(Expression[] expressions) {
        checkArgCount(getName(), expressions, 3);
        init(expressions[0], expressions[1], expressions[2]);
    }

    public IsHierarchyDescendant(Expression ancestorExpression,
                                 Expression childExpression,
                                 Expression entityName) {
        init(ancestorExpression, childExpression, entityName);
    }

    private void init(Expression ancestorExpression, Expression childExpression, Expression entityName) {
        if (entityName != null) {
            if (entityName instanceof EntityName) {
                this.entityName = (EntityName) entityName;
            } else if (entityName instanceof Var) {
                Var v = (Var) entityName;
                if (v.getApplier() != null) {
                    throw new net.vpc.upa.exceptions.IllegalArgumentException("Invalid EntityName");
                }
                this.entityName = new EntityName(v.getName());
            } else if (entityName instanceof Literal) {
                Literal v = (Literal) entityName;
                if (v.getValue() == null) {
                    this.entityName = new EntityName((String) v.getValue());
                } else if ((v.getValue() instanceof String)) {
                    this.entityName = new EntityName((String) v.getValue());
                } else {
                    throw new net.vpc.upa.exceptions.IllegalArgumentException("Invalid EntityName");
                }
            } else {
                throw new net.vpc.upa.exceptions.IllegalArgumentException("Invalid EntityName");
            }
        } else {
            this.entityName = new EntityName("");
        }
        this.ancestorExpression = ancestorExpression;
        this.childExpression = childExpression;
    }

    public int size() {
        return 1;
    }

    public boolean isValid() {
        return entityName.isValid() && ancestorExpression.isValid() && childExpression.isValid();
    }
//    public synchronized String toSQL(boolean integrated, PersistenceUnit database) {
//        return "Exists(" + query.toSQL(database) + ")";
//    }

    @Override
    public String getName() {
        return "TreeAncestor";
    }

    @Override
    public int getArgumentsCount() {
        return 3;
    }

    @Override
    public Expression getArgument(int index) {
        switch (index) {
            case 0: {
                return ancestorExpression;
            }
            case 1: {
                return childExpression;
            }
            case 2: {
                return entityName;
            }
        }
        throw new ArrayIndexOutOfBoundsException();
    }

    @Override
    public void setArgument(int index, Expression e) {
        switch (index) {
            case 0: {
                this.ancestorExpression = e;
                break;
            }
            case 1: {
                this.childExpression = e;
                break;
            }
            case 2: {
                this.entityName = (EntityName) e;
                break;
            }
        }
        throw new ArrayIndexOutOfBoundsException();
    }

    public EntityName getEntityName() {
        return entityName;
    }

    public void setEntityName(EntityName entityName) {
        this.entityName = entityName;
    }

    public Expression getAncestorExpression() {
        return ancestorExpression;
    }

    public void setAncestorExpression(Expression ancestorExpression) {
        this.ancestorExpression = ancestorExpression;
    }

    public Expression getChildExpression() {
        return childExpression;
    }

    public void setChildExpression(Expression childExpression) {
        this.childExpression = childExpression;
    }

    @Override
    public Expression copy() {
        IsHierarchyDescendant o = new IsHierarchyDescendant(ancestorExpression.copy(), childExpression.copy(), (EntityName) entityName.copy());
        return o;
    }
}
