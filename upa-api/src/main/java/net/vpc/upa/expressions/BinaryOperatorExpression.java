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

public abstract class BinaryOperatorExpression extends DefaultExpression implements Cloneable {
    private static final long serialVersionUID = 1L;
    protected Expression left;
    protected Expression right;
    protected BinaryOperator operator;

    public BinaryOperatorExpression(BinaryOperator operator, Expression left, Object right) {
        this(operator, left, ExpressionFactory.toLiteral(right));
    }

    public BinaryOperatorExpression(BinaryOperator operator, Expression left, Expression right) {
        this.left = left;
        this.right = right;
        this.operator = operator;
    }

    public Expression getLeft() {
        return left;
    }

    public Expression getRight() {
        return right;
    }

    @Override
    public boolean isValid() {
        return (left == null || left.isValid()) && (right == null || right.isValid());
    }

    public BinaryOperator getOperator() {
        return operator;
    }

    private String getOperatorString() {
        switch (getOperator()) {
            case AND: {
                return "And";
            }
            case OR: {
                return "Or";
            }
            case BIT_AND: {
                return "&";
            }
            case LSHIFT: {
                return "<<";
            }
            case BIT_OR: {
                return "|";
            }
            case RSHIFT: {
                return ">>";
            }
            case URSHIFT: {
                return ">>>";
            }
            case XOR: {
                return "^";
            }
            case DIFF: {
                return "!=";
            }
            case EQ: {
                return "=";
            }
            case GT: {
                return ">";
            }
            case GE: {
                return ">=";
            }
            case LT: {
                return "<";
            }
            case LE: {
                return "<=";
            }
            case PLUS: {
                return "+";
            }
            case MINUS: {
                return "-";
            }
            case MUL: {
                return "*";
            }
            case DIV: {
                return "/";
            }
            case LIKE: {
                return "Like";
            }
            default: {
                throw new IllegalArgumentException("Not Supported Yet");
            }
        }
    }


    @Override
    public String toString() {
        String leftValue = "(" + String.valueOf(getLeft()) + ")";
        String rightValue = "(" + String.valueOf(getRight()) + ")";
        String s = leftValue + " " + getOperatorString() + " " + rightValue;
        return s;
    }

    public Expression copy() {
        BinaryOperatorExpression o = create(getOperator(), getLeft().copy(), getRight().copy());
        return o;
    }

    public static BinaryOperatorExpression create(BinaryOperator operator, Expression left, Expression right) {
        switch (operator) {
            case AND: {
                return new And(left, right);
            }
            case OR: {
                return new Or(left, right);
            }
            case BIT_AND: {
                return new BitAnd(left, right);
            }
            case BIT_OR: {
                return new BitOr(left, right);
            }
            case LSHIFT: {
                return new LShift(left, right);
            }
            case RSHIFT: {
                return new RShift(left, right);
            }
            case URSHIFT: {
                return new URShift(left, right);
            }
            case XOR: {
                return new XOr(left, right);
            }
            case DIFF: {
                return new Different(left, right);
            }
            case EQ: {
                return new Equals(left, right);
            }
            case GT: {
                return new GreaterThan(left, right);
            }
            case GE: {
                return new GreaterEqualThan(left, right);
            }
            case LT: {
                return new LessThan(left, right);
            }
            case LE: {
                return new LessEqualThan(left, right);
            }
            case PLUS: {
                return new Plus(left, right);
            }
            case MINUS: {
                return new Minus(left, right);
            }
            case MUL: {
                return new Mul(left, right);
            }
            case DIV: {
                return new Div(left, right);
            }
            case LIKE: {
                return new Like(left, right);
            }
            default: {
                throw new IllegalArgumentException("Not Supported Yet");
            }
        }
    }


}
