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



namespace Net.TheVpc.Upa.Expressions
{

    /**
     * @author taha.bensalah@gmail.com
     */
    public interface ExpressionTransformer {

        /**
             * visit an expression as relative 'tag'
             *
             * @param expression visited expression
             * @return transformation result
             */
         Net.TheVpc.Upa.Expressions.ExpressionTransformerResult Transform(Net.TheVpc.Upa.Expressions.Expression expression);
    }
}
