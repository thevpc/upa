/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE HAS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.TheVpc.Upa.Types
{

    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public class CustomExpressionDataTypeTransform : Net.TheVpc.Upa.Types.DataTypeTransformConfig {

        private string expression;

        public CustomExpressionDataTypeTransform(string customType) {
            this.expression = customType;
        }

        public virtual string GetExpression() {
            return expression;
        }
    }
}
