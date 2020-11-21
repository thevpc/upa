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



namespace Net.TheVpc.Upa.Impl.Persistence.Shared
{


    /**
     * Created with IntelliJ IDEA. User: vpc Date: 8/15/12 Time: 11:46 PM To change
     * this template use File | Settings | File Templates.
     */
    public class BinaryOperatorExpressionSQLProvider : Net.TheVpc.Upa.Impl.Persistence.Shared.AbstractSQLProvider {

        public BinaryOperatorExpressionSQLProvider()  : base(typeof(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledBinaryOperatorExpression)){

        }


        public override string GetSQL(object oo, Net.TheVpc.Upa.Persistence.EntityExecutionContext qlContext, Net.TheVpc.Upa.Impl.Persistence.SQLManager sqlManager, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledBinaryOperatorExpression o = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledBinaryOperatorExpression) oo;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append('(');
            sb.Append(sqlManager.GetSQL(o.GetLeft(), qlContext, declarations));
            sb.Append(GetOperatorString(o));
            sb.Append(sqlManager.GetSQL(o.GetRight(), qlContext, declarations));
            sb.Append(')');
            return sb.ToString();
        }

        private string GetOperatorString(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledBinaryOperatorExpression expression) {
            switch(expression.GetOperator()) {
                case Net.TheVpc.Upa.Expressions.BinaryOperator.AND:
                    {
                        return "And";
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.OR:
                    {
                        return "Or";
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.BIT_AND:
                    {
                        return "&";
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.LSHIFT:
                    {
                        return "<<";
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.BIT_OR:
                    {
                        return "|";
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.RSHIFT:
                    {
                        return ">>";
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.URSHIFT:
                    {
                        return ">>>";
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.XOR:
                    {
                        return "^";
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.DIFF:
                    {
                        return "!=";
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.EQ:
                    {
                        return "=";
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.GT:
                    {
                        return ">";
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.GE:
                    {
                        return ">=";
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.LT:
                    {
                        return "<";
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.LE:
                    {
                        return "<=";
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.PLUS:
                    {
                        return "+";
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.MINUS:
                    {
                        return "-";
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.MUL:
                    {
                        return "*";
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.DIV:
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
