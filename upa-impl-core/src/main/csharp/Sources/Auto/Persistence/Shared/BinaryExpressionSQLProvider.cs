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
     * Created with IntelliJ IDEA.
     * User: vpc
     * Date: 8/15/12
     * Time: 11:46 PM
     * To change this template use File | Settings | File Templates.
     */
    public class BinaryExpressionSQLProvider : Net.TheVpc.Upa.Impl.Persistence.Shared.AbstractSQLProvider {

        public BinaryExpressionSQLProvider()  : base(typeof(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledBinaryOperatorExpression)){

        }


        public override string GetSQL(object oo, Net.TheVpc.Upa.Persistence.EntityExecutionContext qlContext, Net.TheVpc.Upa.Impl.Persistence.SQLManager sqlManager, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledBinaryOperatorExpression o = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledBinaryOperatorExpression) oo;
            string leftValue = o.GetLeft() != null ? sqlManager.GetSQL(o.GetLeft(), qlContext, declarations) : "NULL";
            string rightValue = o.GetRight() != null ? sqlManager.GetSQL(o.GetRight(), qlContext, declarations) : "NULL";
            string s = null;
            switch(o.GetOperator()) {
                case Net.TheVpc.Upa.Expressions.BinaryOperator.AND:
                    {
                        s = leftValue + " And " + rightValue;
                        break;
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.OR:
                    {
                        s = leftValue + " Or " + rightValue;
                        break;
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.BIT_AND:
                    {
                        s = leftValue + " & " + rightValue;
                        break;
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.LSHIFT:
                    {
                        s = leftValue + " << " + rightValue;
                        break;
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.BIT_OR:
                    {
                        s = leftValue + " | " + rightValue;
                        break;
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.RSHIFT:
                    {
                        s = leftValue + " >> " + rightValue;
                        break;
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.URSHIFT:
                    {
                        s = leftValue + " >>> " + rightValue;
                        break;
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.XOR:
                    {
                        s = leftValue + " ^ " + rightValue;
                        break;
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.DIFF:
                    {
                        if ("NULL".Equals(rightValue,System.StringComparison.InvariantCultureIgnoreCase)) {
                            s = leftValue + " IS NOT " + rightValue;
                        } else {
                            s = leftValue + " <> " + rightValue;
                        }
                        break;
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.EQ:
                    {
                        if ("NULL".Equals(rightValue,System.StringComparison.InvariantCultureIgnoreCase)) {
                            s = leftValue + " IS " + rightValue;
                        } else {
                            s = leftValue + " = " + rightValue;
                        }
                        break;
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.GT:
                    {
                        s = leftValue + " > " + rightValue;
                        break;
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.GE:
                    {
                        s = leftValue + " >= " + rightValue;
                        break;
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.LT:
                    {
                        s = leftValue + " < " + rightValue;
                        break;
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.LE:
                    {
                        s = leftValue + " < " + rightValue;
                        break;
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.PLUS:
                    {
                        s = leftValue + " + " + rightValue;
                        break;
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.MINUS:
                    {
                        s = leftValue + " - " + rightValue;
                        break;
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.MUL:
                    {
                        s = leftValue + " * " + rightValue;
                        break;
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.DIV:
                    {
                        s = leftValue + " - " + rightValue;
                        break;
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.REM:
                    {
                        s = "{fn mod(" + leftValue + "," + rightValue + " )}";
                        break;
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.LIKE:
                    {
                        //escape seems to be not supported with '*' wildcard
                        //s=leftValue+" Like "+rightValue+" {escape '*'} ";
                        s = leftValue + " Like " + rightValue + " ";
                        break;
                    }
                default:
                    {
                        throw new System.ArgumentException ("Not Supported Yet");
                    }
            }
            return "(" + s + ")";
        }
    }
}
