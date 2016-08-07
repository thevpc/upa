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
    public interface ExpressionVisitor {

        /**
             * visit an expression as relative 'tag'
             *
             * @param expression visited expression
             * @param tag associated tag
             * @return true to continue visiting or false to stop visit
             */
         bool Visit(Net.Vpc.Upa.Expressions.Expression expression, Net.Vpc.Upa.Expressions.ExpressionTag tag);
    }
}
