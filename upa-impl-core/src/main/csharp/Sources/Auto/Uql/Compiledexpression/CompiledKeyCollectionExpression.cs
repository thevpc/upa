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


    /**
     * Created by IntelliJ IDEA.
     * User: vpc
     * Date: 22 janv. 2006
     * Time: 09:17:10
     * To change this template use File | Settings | File Templates.
     */
    public class CompiledKeyCollectionExpression : Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledInCollection {



        public CompiledKeyCollectionExpression(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression left)  : base(left){

        }

        public CompiledKeyCollectionExpression(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression left, System.Collections.Generic.ICollection<object> collection)  : base(left, collection){

        }

        public CompiledKeyCollectionExpression(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression left, object[] collection)  : base(left, collection){

        }

        public CompiledKeyCollectionExpression(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] left)  : base(left){

        }

        public CompiledKeyCollectionExpression(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] left, System.Collections.Generic.ICollection<object> collection)  : base(left, collection){

        }


        public override Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledKeyCollectionExpression o = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledKeyCollectionExpression(GetLeft().Copy());
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
            foreach (Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression in right) {
                o.Add(expression);
            }
            return o;
        }
    }
}
