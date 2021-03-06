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



namespace Net.TheVpc.Upa.Impl.Uql.Compiledexpression
{


    public class CompiledBetween : Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpressionImpl {



        private Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression left;

        private Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression min;

        private Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression max;

        private CompiledBetween() {
        }

        public CompiledBetween(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression, object min, object max)  : this(expression, Net.TheVpc.Upa.Impl.Uql.CompiledExpressionFactory.ToLiteral(min), Net.TheVpc.Upa.Impl.Uql.CompiledExpressionFactory.ToLiteral(max)){

        }


        public override Net.TheVpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            return Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform.BOOLEAN;
        }

        public CompiledBetween(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression min, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression max) {
            this.left = expression;
            this.min = min;
            this.max = max;
            PrepareChildren(left, min, max);
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetLeft() {
            return left;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetMin() {
            return min;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetMax() {
            return max;
        }


        public override bool IsValid() {
            return (left != null && left.IsValid()) && (min != null && min.IsValid()) && (max != null && max.IsValid());
        }


        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] GetSubExpressions() {
            return new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] { left, min, max };
        }


        public override void SetSubExpression(int index, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            switch(index) {
                case 0:
                    {
                        left = expression;
                        PrepareChildren(expression);
                        break;
                    }
                case 1:
                    {
                        min = expression;
                        PrepareChildren(expression);
                        break;
                    }
                case 2:
                    {
                        max = expression;
                        PrepareChildren(expression);
                        break;
                    }
                default:
                    {
                        throw new System.ArgumentException ("Invalid index");
                    }
            }
        }

        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledBetween o = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledBetween();
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
            o.left = left.Copy();
            o.min = min.Copy();
            o.max = max.Copy();
            return o;
        }
    }
}
