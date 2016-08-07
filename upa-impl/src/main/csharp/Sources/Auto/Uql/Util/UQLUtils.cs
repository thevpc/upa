/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE AS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.Vpc.Upa.Impl.Uql.Util
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public class UQLUtils {

        public static Net.Vpc.Upa.Expressions.Expression ParseUserExpressions(Net.Vpc.Upa.Expressions.Expression expression, Net.Vpc.Upa.PersistenceUnit pu) {
            if (expression is Net.Vpc.Upa.Expressions.UserExpression) {
                return pu.GetExpressionManager().ParseExpression((Net.Vpc.Upa.Expressions.UserExpression) expression);
            }
            Net.Vpc.Upa.Impl.Uql.Util.UserExpressionParserVisitor v = new Net.Vpc.Upa.Impl.Uql.Util.UserExpressionParserVisitor(pu.GetExpressionManager());
            expression.Visit(v);
            return expression;
        }

        public static void ReplaceThisVar(Net.Vpc.Upa.Expressions.Expression expression, string newName, Net.Vpc.Upa.PersistenceUnit pu) {
            ReplaceThisVar(expression, newName, pu.GetExpressionManager());
        }

        public static void ReplaceThisVar(Net.Vpc.Upa.Expressions.Expression expression, string newName, Net.Vpc.Upa.ExpressionManager expressionManager) {
            Net.Vpc.Upa.Expressions.ExpressionVisitor expressionVisitor = new Net.Vpc.Upa.Impl.Uql.Util.ThisRenamerVisitor(expressionManager, newName);
            expression.Visit(expressionVisitor);
        }

        public static string[] ResolveEntityAndAlias(Net.Vpc.Upa.Expressions.Select select) {
            string e = select.GetEntityName();
            if (e != null) {
                return new string[] { e, select.GetEntityAlias() };
            }
            return null;
        }

        public static string[] ResolveEntityAndAlias(Net.Vpc.Upa.Expressions.QueryStatement select) {
            if (select is Net.Vpc.Upa.Expressions.Select) {
                return ResolveEntityAndAlias((Net.Vpc.Upa.Expressions.Select) select);
            }
            if (select is Net.Vpc.Upa.Expressions.Union) {
                Net.Vpc.Upa.Expressions.Union u = (Net.Vpc.Upa.Expressions.Union) select;
                string[] last = null;
                foreach (Net.Vpc.Upa.Expressions.QueryStatement queryStatement in u.GetQueryStatements()) {
                    string[] s = ResolveEntityAndAlias(queryStatement);
                    if (s == null) {
                        return null;
                    } else if (last == null) {
                        last = s;
                    } else {
                        if (!Net.Vpc.Upa.Impl.FwkConvertUtils.ArraysEquals<string>(last,s)) {
                            return null;
                        }
                    }
                }
                return last;
            }
            return null;
        }

        public static Net.Vpc.Upa.Expressions.Expression CreateUnaryExpr(Net.Vpc.Upa.Expressions.UnaryOperator op, Net.Vpc.Upa.Expressions.Expression a) {
            switch(op) {
                case Net.Vpc.Upa.Expressions.UnaryOperator.COMPLEMENT:
                    {
                        return new Net.Vpc.Upa.Expressions.Complement(a);
                    }
                case Net.Vpc.Upa.Expressions.UnaryOperator.NEGATIVE:
                    {
                        return new Net.Vpc.Upa.Expressions.Negative(a);
                    }
                case Net.Vpc.Upa.Expressions.UnaryOperator.POSITIVE:
                    {
                        return new Net.Vpc.Upa.Expressions.Positive(a);
                    }
            }
            throw new System.Exception("Unsupported");
        }

        public static Net.Vpc.Upa.Expressions.Expression CreateBinaryExpr(Net.Vpc.Upa.Expressions.BinaryOperator op, Net.Vpc.Upa.Expressions.Expression r, Net.Vpc.Upa.Expressions.Expression n) {
            switch(op) {
                case Net.Vpc.Upa.Expressions.BinaryOperator.EQ:
                    {
                        return new Net.Vpc.Upa.Expressions.Equals(r, n);
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.DIFF:
                    {
                        return new Net.Vpc.Upa.Expressions.Different(r, n);
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.LT:
                    {
                        return new Net.Vpc.Upa.Expressions.LessThan(r, n);
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.LE:
                    {
                        return new Net.Vpc.Upa.Expressions.LessEqualThan(r, n);
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.GT:
                    {
                        return new Net.Vpc.Upa.Expressions.GreaterThan(r, n);
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.GE:
                    {
                        return new Net.Vpc.Upa.Expressions.GreaterEqualThan(r, n);
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.LIKE:
                    {
                        return new Net.Vpc.Upa.Expressions.Like(r, n);
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.AND:
                    {
                        return new Net.Vpc.Upa.Expressions.And(r, n);
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.OR:
                    {
                        return new Net.Vpc.Upa.Expressions.Or(r, n);
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.XOR:
                    {
                        return new Net.Vpc.Upa.Expressions.XOr(r, n);
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.BIT_AND:
                    {
                        return new Net.Vpc.Upa.Expressions.BitAnd(r, n);
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.BIT_OR:
                    {
                        return new Net.Vpc.Upa.Expressions.BitOr(r, n);
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.LSHIFT:
                    {
                        return new Net.Vpc.Upa.Expressions.LShift(r, n);
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.RSHIFT:
                    {
                        return new Net.Vpc.Upa.Expressions.RShift(r, n);
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.URSHIFT:
                    {
                        return new Net.Vpc.Upa.Expressions.URShift(r, n);
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.MINUS:
                    {
                        return new Net.Vpc.Upa.Expressions.Minus(r, n);
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.PLUS:
                    {
                        return new Net.Vpc.Upa.Expressions.Plus(r, n);
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.MUL:
                    {
                        return new Net.Vpc.Upa.Expressions.Mul(r, n);
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.DIV:
                    {
                        return new Net.Vpc.Upa.Expressions.Div(r, n);
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.REM:
                    {
                        return new Net.Vpc.Upa.Expressions.Reminder(r, n);
                    }
            }
            throw new System.Exception("Unsupported");
        }
    }
}
