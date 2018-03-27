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



namespace Net.Vpc.Upa.Impl.Uql.Compiledexpression
{


    public abstract class CompiledUnaryOperator : Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpressionImpl {



        private string @operator;

        private Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression;

        public CompiledUnaryOperator(string @operator, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            this.@operator = @operator;
            this.expression = expression;
            PrepareChildren(expression);
        }

        public virtual int Size() {
            return 1;
        }


        public override Net.Vpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            return expression.GetTypeTransform();
        }


        public override bool IsValid() {
            return expression.IsValid();
        }


        public override void SetSubExpression(int index, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            if (index == 0) {
                this.expression = expression;
                PrepareChildren(expression);
            } else {
                throw new System.ArgumentException ("Invalid Index");
            }
        }


        public override Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] GetSubExpressions() {
            return new Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] { expression };
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetExpression() {
            return expression;
        }

        public virtual string GetOperator() {
            return @operator;
        }
    }
}
