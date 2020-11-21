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


    public interface Expression : System.ICloneable {

         bool IsValid();

         Net.TheVpc.Upa.Expressions.Expression Copy();

         System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.TaggedExpression> GetChildren();

         void SetChild(Net.TheVpc.Upa.Expressions.Expression e, Net.TheVpc.Upa.Expressions.ExpressionTag tag);

         Net.TheVpc.Upa.Expressions.Expression FindOne(Net.TheVpc.Upa.Expressions.ExpressionFilter filter);

        /**
             * pre-order DFS traversal of expression
             * @param filter
             */
         void Visit(Net.TheVpc.Upa.Expressions.ExpressionVisitor filter);

        /**
             * post-order DFS traversal and transformation of expression
             * @param transformer transformer
             * @return result
             */
         Net.TheVpc.Upa.Expressions.ExpressionTransformerResult Transform(Net.TheVpc.Upa.Expressions.ExpressionTransformer transformer);

         System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.Expression> FindAll(Net.TheVpc.Upa.Expressions.ExpressionFilter filter);
    }
}
