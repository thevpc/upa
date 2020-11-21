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
    public interface ExpressionVisitor {

        /**
             * visit an expression as relative 'tag'
             *
             * @param expression visited expression
             * @param tag        associated tag
             * @return true to continue visiting or false to stop visit
             */
         bool Visit(Net.TheVpc.Upa.Expressions.Expression expression, Net.TheVpc.Upa.Expressions.ExpressionTag tag);
    }
}
