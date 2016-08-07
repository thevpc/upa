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



namespace Net.Vpc.Upa.Types
{

    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public class CustomExpressionDataTypeTransform : Net.Vpc.Upa.Types.DataTypeTransformConfig {

        private string expression;

        public CustomExpressionDataTypeTransform(string customType) {
            this.expression = customType;
        }

        public virtual string GetExpression() {
            return expression;
        }
    }
}
