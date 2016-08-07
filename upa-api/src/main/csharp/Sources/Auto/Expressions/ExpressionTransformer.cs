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



namespace Net.Vpc.Upa.Expressions
{

    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public interface ExpressionTransformer {

        /**
             * visit an expression as relative 'tag'
             *
             * @param expression visited expression
             * @return transformation result
             */
         Net.Vpc.Upa.Expressions.ExpressionTransformerResult Transform(Net.Vpc.Upa.Expressions.Expression expression);
    }
}
