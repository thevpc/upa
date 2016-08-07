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


    public interface Expression : System.ICloneable {

         bool IsValid();

         Net.Vpc.Upa.Expressions.Expression Copy();

         System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.TaggedExpression> GetChildren();

         void SetChild(Net.Vpc.Upa.Expressions.Expression e, Net.Vpc.Upa.Expressions.ExpressionTag tag);

         Net.Vpc.Upa.Expressions.Expression FindOne(Net.Vpc.Upa.Expressions.ExpressionFilter filter);

        /**
             * pre-order DFS traversal of expression
             * @param filter
             */
         void Visit(Net.Vpc.Upa.Expressions.ExpressionVisitor filter);

        /**
             * post-order DFS traversal and transformation of expression
             * @param transformer transformer
             * @return result
             */
         Net.Vpc.Upa.Expressions.ExpressionTransformerResult Transform(Net.Vpc.Upa.Expressions.ExpressionTransformer transformer);

         System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.Expression> FindAll(Net.Vpc.Upa.Expressions.ExpressionFilter filter);
    }
}
