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



namespace Net.Vpc.Upa.Impl.Persistence.Shared
{


    /**
     * Created with IntelliJ IDEA. User: vpc Date: 8/15/12 Time: 11:46 PM To change
     * this template use File | Settings | File Templates.
     */
    public class BinaryOperatorExpressionSQLProvider : Net.Vpc.Upa.Impl.Persistence.Shared.AbstractSQLProvider {

        public BinaryOperatorExpressionSQLProvider()  : base(typeof(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledBinaryOperatorExpression)){

        }


        public override string GetSQL(object oo, Net.Vpc.Upa.Persistence.EntityExecutionContext qlContext, Net.Vpc.Upa.Impl.Persistence.SQLManager sqlManager, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledBinaryOperatorExpression o = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledBinaryOperatorExpression) oo;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append('(');
            sb.Append(sqlManager.GetSQL(o.GetLeft(), qlContext, declarations));
            sb.Append(GetOperatorString(o));
            sb.Append(sqlManager.GetSQL(o.GetRight(), qlContext, declarations));
            sb.Append(')');
            return sb.ToString();
        }

        private string GetOperatorString(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledBinaryOperatorExpression expression) {
            switch(expression.GetOperator()) {
                case Net.Vpc.Upa.Expressions.BinaryOperator.AND:
                    {
                        return "And";
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.OR:
                    {
                        return "Or";
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.BIT_AND:
                    {
                        return "&";
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.LSHIFT:
                    {
                        return "<<";
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.BIT_OR:
                    {
                        return "|";
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.RSHIFT:
                    {
                        return ">>";
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.URSHIFT:
                    {
                        return ">>>";
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.XOR:
                    {
                        return "^";
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.DIFF:
                    {
                        return "!=";
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.EQ:
                    {
                        return "=";
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.GT:
                    {
                        return ">";
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.GE:
                    {
                        return ">=";
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.LT:
                    {
                        return "<";
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.LE:
                    {
                        return "<=";
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.PLUS:
                    {
                        return "+";
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.MINUS:
                    {
                        return "-";
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.MUL:
                    {
                        return "*";
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.DIV:
                    {
                        return "/";
                    }
                default:
                    {
                        throw new System.ArgumentException ("Not Supported Yet");
                    }
            }
        }
    }
}
