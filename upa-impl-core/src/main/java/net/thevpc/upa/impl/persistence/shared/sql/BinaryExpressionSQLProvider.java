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
package net.thevpc.upa.impl.persistence.shared.sql;

import net.thevpc.upa.impl.upql.ext.expr.CompiledConcat;
import net.thevpc.upa.impl.upql.ext.expr.CompiledBinaryOperatorExpression;
import net.thevpc.upa.impl.upql.ext.expr.CompiledSelect;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.exceptions.IllegalUPAArgumentException;
import net.thevpc.upa.expressions.BinaryOperator;
import net.thevpc.upa.impl.persistence.SQLManager;
import net.thevpc.upa.impl.upql.ExpressionDeclarationList;
import net.thevpc.upa.impl.util.PlatformUtils;
import net.thevpc.upa.persistence.EntityExecutionContext;

/**
 * User: vpc Date: 8/15/12 Time: 11:46 PM To change
 */
public class BinaryExpressionSQLProvider extends AbstractSQLProvider {

    public BinaryExpressionSQLProvider() {
        super(CompiledBinaryOperatorExpression.class);
    }

    private String[] getLefAndRight(CompiledBinaryOperatorExpression o, EntityExecutionContext qlContext, SQLManager sqlManager, ExpressionDeclarationList declarations) {
        String leftValue = o.getLeft() != null ? sqlManager.getSQL(o.getLeft(), qlContext, declarations) : "NULL";
        if (o.getLeft() instanceof CompiledSelect) {
            leftValue = "(" + leftValue + ")";
        }
        String rightValue = "NULL";
        if (o.getRight() != null) {
            rightValue = sqlManager.getSQL(o.getRight(), qlContext, declarations);
        }
        if (o.getRight() instanceof CompiledSelect) {
            rightValue = "(" + rightValue + ")";
        }
        return new String[]{leftValue, rightValue};
    }

    @Override
    public String getSQL(Object oo, EntityExecutionContext qlContext, SQLManager sqlManager, ExpressionDeclarationList declarations) throws UPAException {
        CompiledBinaryOperatorExpression o = (CompiledBinaryOperatorExpression) oo;
        boolean forceRightISOrISNOT = false;
        String leftValue = null;
        String rightValue = null;
        if (o.getOperator() != BinaryOperator.PLUS) {
            String[] leftAndRight = getLefAndRight(o, qlContext, sqlManager, declarations);
            leftValue = leftAndRight[0];
            rightValue = leftAndRight[1];
        }
        String s = null;
        switch (o.getOperator()) {
            case AND: {
                s = leftValue + " And " + rightValue;
                break;
            }
            case OR: {
                s = leftValue + " Or " + rightValue;
                break;
            }
            case BIT_AND: {
                s = leftValue + " & " + rightValue;
                break;
            }
            case LSHIFT: {
                s = leftValue + " << " + rightValue;
                break;
            }
            case BIT_OR: {
                s = leftValue + " | " + rightValue;
                break;
            }
            case RSHIFT: {
                s = leftValue + " >> " + rightValue;
                break;
            }
            case URSHIFT: {
                s = leftValue + " >>> " + rightValue;
                break;
            }
            case XOR: {
                s = leftValue + " ^ " + rightValue;
                break;
            }
            case DIFF: {
                if (forceRightISOrISNOT || "NULL".equalsIgnoreCase(rightValue)) {
                    s = leftValue + " IS NOT " + rightValue;
                } else {
                    s = leftValue + " <> " + rightValue;
                }
                break;
            }
            case EQ: {
                if (forceRightISOrISNOT || "NULL".equalsIgnoreCase(rightValue)) {
                    s = leftValue + " IS " + rightValue;
                } else {
                    s = leftValue + " = " + rightValue;
                }
                break;
            }
            case GT: {
                s = leftValue + " > " + rightValue;
                break;
            }
            case GE: {
                s = leftValue + " >= " + rightValue;
                break;
            }
            case LT: {
                s = leftValue + " < " + rightValue;
                break;
            }
            case LE: {
                s = leftValue + " < " + rightValue;
                break;
            }
            case PLUS: {
                Class ltype = (o == null || o.getLeft() == null) ? null : (o.getLeft().getEffectiveDataType().getTargetType().getPlatformType());
                Class rtype = (o == null || o.getRight() == null) ? null : (o.getRight().getEffectiveDataType().getTargetType().getPlatformType());
                //string + nonstring
                if (ltype != null && rtype != null
                        && (PlatformUtils.isString(ltype) || PlatformUtils.isString(rtype))) {
                    s = sqlManager.getSQL(new CompiledConcat(o.getLeft().copy(), o.getRight().copy()), qlContext, declarations);
                } else {
                    String[] leftAndRight = getLefAndRight(o, qlContext, sqlManager, declarations);
                    leftValue = leftAndRight[0];
                    rightValue = leftAndRight[1];
                    s = leftValue + " + " + rightValue;
                }
                break;
            }
            case MINUS: {
                s = leftValue + " - " + rightValue;
                break;
            }
            case MUL: {
                s = leftValue + " * " + rightValue;
                break;
            }
            case DIV: {
                s = leftValue + " / " + rightValue;
                break;
            }
            case REM: {
                s = "{fn mod(" + leftValue + "," + rightValue + " )}";
                break;
            }
            case LIKE: {
                //escape seems to be not supported with '*' wildcard
                //s=leftValue+" Like "+rightValue+" {escape '*'} ";
                s = leftValue + " Like " + rightValue + " ";
                break;
            }
            default: {
                throw new IllegalUPAArgumentException("Not Supported Binay Operator " + o.getOperator());
            }
        }
        return "(" + s + ")";
    }
}
