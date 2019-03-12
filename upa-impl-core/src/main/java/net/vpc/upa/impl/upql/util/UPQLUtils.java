/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.upql.util;

import net.vpc.upa.*;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.exceptions.IllegalUPAArgumentException;
import net.vpc.upa.expressions.*;
import net.vpc.upa.impl.util.StringUtils;

import java.util.Arrays;
import java.util.List;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.upql.ext.expr.CompiledAnd;
import net.vpc.upa.impl.upql.ext.expr.CompiledEquals;
import net.vpc.upa.impl.upql.ext.expr.CompiledLiteral;
import net.vpc.upa.impl.upql.ext.expr.CompiledOr;
import net.vpc.upa.impl.upql.ext.expr.CompiledVar;
import net.vpc.upa.impl.upql.ext.expr.CompiledVarOrMethod;

/**
 * @author taha.bensalah@gmail.com
 */
public class UPQLUtils {

    public static final String THIS = "this";

    public static Expression parseUserExpressions(Expression expression, PersistenceUnit pu) {
        if (expression instanceof UserExpression) {
            return pu.getExpressionManager().parseExpression((UserExpression) expression);
        }
        UserExpressionParserVisitor v = new UserExpressionParserVisitor(pu.getExpressionManager());
        expression.visit(v);
        return expression;
    }

    public static void replaceThisVar(Expression expression, String newName, PersistenceUnit pu) {
        replaceThisVar(expression, newName, pu.getExpressionManager());
    }

    public static void visit(Expression expression, ExpressionVisitor visitor) {
        if (expression == null) {
            return;
        }
        expression.visit(visitor);
    }

    public static boolean containsThisVar(Expression expression, ExpressionManager expressionManager) {
        if (expression == null) {
            return false;
        }
        ThisSearchVisitor v = new ThisSearchVisitor(expressionManager);
        visit(expression, v);
        return v.isFound();
    }

    public static void replaceThisVar(Expression expression, String newName, ExpressionManager expressionManager) {
        if (expression == null || UPQLUtils.THIS.equals(newName)) {
            return;
        }
        ExpressionVisitor expressionVisitor = new ThisRenamerVisitor(expressionManager, newName);
        expression.visit(expressionVisitor);
    }

    public static void replaceVar(Expression expression, String oldName, String newName, ExpressionManager expressionManager) {
        if (expression == null || oldName.equals(newName)) {
            return;
        }
        ExpressionVisitor expressionVisitor = new VarRenamerVisitor(expressionManager, oldName, newName);
        expression.visit(expressionVisitor);
    }

    public static String[] resolveEntityAndAlias(Select select) {
        String e = select.getEntityName();
        if (e != null) {
            return new String[]{e, select.getEntityAlias()};
        }
        return null;
    }

    public static String[] resolveEntityAndAlias(QueryStatement select) {
        if (select instanceof Select) {
            return resolveEntityAndAlias((Select) select);
        }
        if (select instanceof Union) {
            Union u = (Union) select;
            String[] last = null;
            for (QueryStatement queryStatement : u.getQueryStatements()) {
                String[] s = resolveEntityAndAlias(queryStatement);
                if (s == null) {
                    return null;
                } else if (last == null) {
                    last = s;
                } else {
                    if (!Arrays.equals(last, s)) {
                        return null;
                    }
                }
            }
            return last;
        }
        return null;
    }

    public static Expression createUnaryExpr(UnaryOperator op, Expression a) {
        switch (op) {
            case COMPLEMENT: {
                return new Complement(a);
            }
            case NEGATIVE: {
                return new Negative(a);
            }
            case POSITIVE: {
                return new Positive(a);
            }
        }
        throw new RuntimeException("Unsupported");
    }

    public static Expression createBinaryExpr(BinaryOperator op, Expression r, Expression n) {
        switch (op) {
            case EQ: {
                return new Equals(r, n);
            }
            case DIFF: {
                return new Different(r, n);
            }
            case LT: {
                return new LessThan(r, n);
            }
            case LE: {
                return new LessEqualThan(r, n);
            }
            case GT: {
                return new GreaterThan(r, n);
            }
            case GE: {
                return new GreaterEqualThan(r, n);
            }
            case LIKE: {
                return new Like(r, n);
            }

            case AND: {
                return new And(r, n);
            }
            case OR: {
                return new Or(r, n);
            }
            case XOR: {
                return new XOr(r, n);
            }

            case BIT_AND: {
                return new BitAnd(r, n);
            }
            case BIT_OR: {
                return new BitOr(r, n);
            }
            case LSHIFT: {
                return new LShift(r, n);
            }
            case RSHIFT: {
                return new RShift(r, n);
            }
            case URSHIFT: {
                return new URShift(r, n);
            }

            case MINUS: {
                return new Minus(r, n);
            }
            case PLUS: {
                return new Plus(r, n);
            }
            case MUL: {
                return new Mul(r, n);
            }
            case DIV: {
                return new Div(r, n);
            }
            case REM: {
                return new Reminder(r, n);
            }
        }
        throw new RuntimeException("Unsupported");
    }

    public static String generateID() {
        long l = System.currentTimeMillis();
        if (l < 0) {
            l = -l;//could it ever happen
        }
        return ("u" + ((int) (Math.random() * 10000)) + "" + l);
    }

    public static Expression expandIdExpression(String paramName, IdExpression o) throws UPAException {
        Expression ret = null;

        Entity entity = o.getEntity();
        if (entity == null) {
            throw new IllegalUPAArgumentException("Key enumeration must by associated to and entity");
        }

        Key key = entity.getBuilder().idToKey(o.getId());
        Object[] values = key == null ? null : key.getValue();
        Entity entity1 = o.getEntity();
        List<Field> idFields = entity1.getIdFields();
        for (int i = 0; i < idFields.size(); i++) {
            Field idField = idFields.get(i);
            Relationship manyToOneRelationship = idField.getManyToOneRelationship();
            if (manyToOneRelationship != null) {
                List<Field> fields = manyToOneRelationship.getSourceRole().getFields();
                Entity targetEntity = manyToOneRelationship.getTargetEntity();
                Object o2 = targetEntity.getBuilder().objectToId(values == null ? null : values[i]);
                Key key2 = entity.getBuilder().idToKey(o2);
                Object[] values2 = key2 == null ? null : key2.getValue();
                for (int j = 0; j < fields.size(); j++) {
                    Var ppp = o.getAlias() == null ? null : new Var(o.getAlias());
                    if (ppp == null) {
                        ppp = new Var(fields.get(j).getName());
                    } else {
                        Var var = new Var(fields.get(j).getName());
                        var.setApplier(ppp);
                        ppp = var;
                    }
                    Equals e = new Equals(ppp, new Param(paramName + "" + (j + 1), values2 == null ? null : values2[j]));
                    ret = (ret == null) ? e : new And(ret, e);
                }
            } else {
                Var ppp = o.getAlias() == null ? null : new Var(o.getAlias());
                if (ppp == null) {
                    ppp = new Var(idField.getName());
                } else {
                    Var var = new Var(idField.getName());
                    var.setApplier(ppp);
                    ppp = var;
                }
                Equals e = new Equals(ppp, new Param(paramName + "" + (i + 1), values == null ? null : values[i]));
                ret = (ret == null) ? e : new And(ret, e);
            }
        }
        if (ret == null) {
//            ret = new Equals(new Literal(1), new Literal(1));
            throw new IllegalUPAArgumentException("Unable to resolve Id from " + o);
        }
        return ret;
    }

    public static String resolveMainTableFromSQLQuery(String query) {
        if (query == null) {
            return "";
        }
        String s = StringUtils.extractWordAt(query, 0);
        if (s == null) {
            return "";
        }
        String q2 = StringUtils.removeSQLParsAndStrings(query);
        String slower = s.toLowerCase();
        if (slower.equals("select")) {
            String s2 = StringUtils.extractWordAfter("from", q2, 0, true);
            if (s2 == null) {
                s2 = "";
            }
            return s2;
        } else if (slower.equals("update")) {
            String s2 = StringUtils.extractWordAfter("update", q2, 0, true);
            if (s2 == null) {
                s2 = "";
            }
            return s2;
        } else if (slower.equals("delete")) {
            String s2 = StringUtils.extractWordAfter("from", q2, 0, true);
            if (s2 == null) {
                s2 = "";
            }
            return s2;
        } else if (slower.equals("insert")) {
            String s2 = StringUtils.extractWordAfter("into", q2, 0, true);
            if (s2 == null) {
                s2 = "";
            }
            return s2;
        } else if (slower.equals("create")) {
            String s2 = StringUtils.extractWordAfter("table", q2, 0, true);
            if (s2 == null) {
                s2 = "";
            }
            return s2;
        } else if (slower.equals("alter")) {
            String s2 = StringUtils.extractWordAfter("table", q2, 0, true);
            if (s2 == null) {
                s2 = "";
            }
            return s2;
        }
        return "";
    }

    public static CompiledExpressionExt and(CompiledExpressionExt a, CompiledExpressionExt b) {
        if (a == null) {
            return b;
        }
        if (b == null) {
            return a;
        }
        return new CompiledAnd(a, b);
    }

    public static CompiledExpressionExt or(CompiledExpressionExt a, CompiledExpressionExt b) {
        if (a == null) {
            return b;
        }
        if (b == null) {
            return a;
        }
        return new CompiledOr(a, b);
    }

    public static CompiledLiteral fieldLiteral(Object val, Field f) {
        return new CompiledLiteral(val, f.getEffectiveTypeTransform());
    }

    public static CompiledExpressionExt fieldEqLiteral(CompiledVarOrMethod compiledVar, Object literal, Field f) {
        return new CompiledEquals(
                UPQLUtils.fieldVar(compiledVar, f),
                UPQLUtils.fieldLiteral(literal, f)
        );
    }

    public static CompiledVarOrMethod fieldVar(CompiledVarOrMethod compiledVar, Field f) {
        CompiledVar rr = new CompiledVar(f);
        CompiledVarOrMethod p2 = compiledVar == null ? null : (CompiledVarOrMethod) compiledVar.copy();
        if (p2 == null) {
            p2 = rr;
        } else {
            p2.setChild(rr);
        }
        return p2;
    }

}
