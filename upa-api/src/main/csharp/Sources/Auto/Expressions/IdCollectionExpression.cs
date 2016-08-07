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
     * Created by IntelliJ IDEA.
     * User: vpc
     * Date: 22 janv. 2006
     * Time: 09:17:10
     * To change this template use File | Settings | File Templates.
     */
    public class IdCollectionExpression : Net.Vpc.Upa.Expressions.InCollection {



        public IdCollectionExpression(Net.Vpc.Upa.Expressions.Expression left)  : base(left){

        }

        public IdCollectionExpression(Net.Vpc.Upa.Expressions.Expression left, System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.Expression> collection)  : base(left, collection){

        }

        public IdCollectionExpression(Net.Vpc.Upa.Expressions.Expression left, Net.Vpc.Upa.Expressions.Expression[] collection)  : base(left, collection){

        }

        public IdCollectionExpression(Net.Vpc.Upa.Expressions.Expression[] left)  : base(left){

        }

        public IdCollectionExpression(Net.Vpc.Upa.Expressions.Expression[] left, System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.Expression> collection)  : base(left, collection){

        }


        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Expressions.IdCollectionExpression o = new Net.Vpc.Upa.Expressions.IdCollectionExpression(GetLeft().Copy());
            foreach (Net.Vpc.Upa.Expressions.Expression expression in right) {
                o.Add(expression);
            }
            return o;
        }
    }
}
