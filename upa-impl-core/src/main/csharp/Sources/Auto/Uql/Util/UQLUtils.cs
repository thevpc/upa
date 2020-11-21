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



namespace Net.TheVpc.Upa.Impl.Uql.Util
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public class UQLUtils {

        public static Net.TheVpc.Upa.Expressions.Expression ParseUserExpressions(Net.TheVpc.Upa.Expressions.Expression expression, Net.TheVpc.Upa.PersistenceUnit pu) {
            if (expression is Net.TheVpc.Upa.Expressions.UserExpression) {
                return pu.GetExpressionManager().ParseExpression((Net.TheVpc.Upa.Expressions.UserExpression) expression);
            }
            Net.TheVpc.Upa.Impl.Uql.Util.UserExpressionParserVisitor v = new Net.TheVpc.Upa.Impl.Uql.Util.UserExpressionParserVisitor(pu.GetExpressionManager());
            expression.Visit(v);
            return expression;
        }

        public static void ReplaceThisVar(Net.TheVpc.Upa.Expressions.Expression expression, string newName, Net.TheVpc.Upa.PersistenceUnit pu) {
            ReplaceThisVar(expression, newName, pu.GetExpressionManager());
        }

        public static void ReplaceThisVar(Net.TheVpc.Upa.Expressions.Expression expression, string newName, Net.TheVpc.Upa.ExpressionManager expressionManager) {
            Net.TheVpc.Upa.Expressions.ExpressionVisitor expressionVisitor = new Net.TheVpc.Upa.Impl.Uql.Util.ThisRenamerVisitor(expressionManager, newName);
            expression.Visit(expressionVisitor);
        }

        public static string[] ResolveEntityAndAlias(Net.TheVpc.Upa.Expressions.Select select) {
            string e = select.GetEntityName();
            if (e != null) {
                return new string[] { e, select.GetEntityAlias() };
            }
            return null;
        }

        public static string[] ResolveEntityAndAlias(Net.TheVpc.Upa.Expressions.QueryStatement select) {
            if (select is Net.TheVpc.Upa.Expressions.Select) {
                return ResolveEntityAndAlias((Net.TheVpc.Upa.Expressions.Select) select);
            }
            if (select is Net.TheVpc.Upa.Expressions.Union) {
                Net.TheVpc.Upa.Expressions.Union u = (Net.TheVpc.Upa.Expressions.Union) select;
                string[] last = null;
                foreach (Net.TheVpc.Upa.Expressions.QueryStatement queryStatement in u.GetQueryStatements()) {
                    string[] s = ResolveEntityAndAlias(queryStatement);
                    if (s == null) {
                        return null;
                    } else if (last == null) {
                        last = s;
                    } else {
                        if (!Net.TheVpc.Upa.Impl.FwkConvertUtils.ArraysEquals<string>(last,s)) {
                            return null;
                        }
                    }
                }
                return last;
            }
            return null;
        }

        public static Net.TheVpc.Upa.Expressions.Expression CreateUnaryExpr(Net.TheVpc.Upa.Expressions.UnaryOperator op, Net.TheVpc.Upa.Expressions.Expression a) {
            switch(op) {
                case Net.TheVpc.Upa.Expressions.UnaryOperator.COMPLEMENT:
                    {
                        return new Net.TheVpc.Upa.Expressions.Complement(a);
                    }
                case Net.TheVpc.Upa.Expressions.UnaryOperator.NEGATIVE:
                    {
                        return new Net.TheVpc.Upa.Expressions.Negative(a);
                    }
                case Net.TheVpc.Upa.Expressions.UnaryOperator.POSITIVE:
                    {
                        return new Net.TheVpc.Upa.Expressions.Positive(a);
                    }
            }
            throw new System.Exception("Unsupported");
        }

        public static Net.TheVpc.Upa.Expressions.Expression CreateBinaryExpr(Net.TheVpc.Upa.Expressions.BinaryOperator op, Net.TheVpc.Upa.Expressions.Expression r, Net.TheVpc.Upa.Expressions.Expression n) {
            switch(op) {
                case Net.TheVpc.Upa.Expressions.BinaryOperator.EQ:
                    {
                        return new Net.TheVpc.Upa.Expressions.Equals(r, n);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.DIFF:
                    {
                        return new Net.TheVpc.Upa.Expressions.Different(r, n);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.LT:
                    {
                        return new Net.TheVpc.Upa.Expressions.LessThan(r, n);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.LE:
                    {
                        return new Net.TheVpc.Upa.Expressions.LessEqualThan(r, n);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.GT:
                    {
                        return new Net.TheVpc.Upa.Expressions.GreaterThan(r, n);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.GE:
                    {
                        return new Net.TheVpc.Upa.Expressions.GreaterEqualThan(r, n);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.LIKE:
                    {
                        return new Net.TheVpc.Upa.Expressions.Like(r, n);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.AND:
                    {
                        return new Net.TheVpc.Upa.Expressions.And(r, n);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.OR:
                    {
                        return new Net.TheVpc.Upa.Expressions.Or(r, n);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.XOR:
                    {
                        return new Net.TheVpc.Upa.Expressions.XOr(r, n);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.BIT_AND:
                    {
                        return new Net.TheVpc.Upa.Expressions.BitAnd(r, n);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.BIT_OR:
                    {
                        return new Net.TheVpc.Upa.Expressions.BitOr(r, n);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.LSHIFT:
                    {
                        return new Net.TheVpc.Upa.Expressions.LShift(r, n);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.RSHIFT:
                    {
                        return new Net.TheVpc.Upa.Expressions.RShift(r, n);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.URSHIFT:
                    {
                        return new Net.TheVpc.Upa.Expressions.URShift(r, n);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.MINUS:
                    {
                        return new Net.TheVpc.Upa.Expressions.Minus(r, n);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.PLUS:
                    {
                        return new Net.TheVpc.Upa.Expressions.Plus(r, n);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.MUL:
                    {
                        return new Net.TheVpc.Upa.Expressions.Mul(r, n);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.DIV:
                    {
                        return new Net.TheVpc.Upa.Expressions.Div(r, n);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.REM:
                    {
                        return new Net.TheVpc.Upa.Expressions.Reminder(r, n);
                    }
            }
            throw new System.Exception("Unsupported");
        }
    }
}
