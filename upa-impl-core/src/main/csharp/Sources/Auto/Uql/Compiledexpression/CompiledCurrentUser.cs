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



namespace Net.TheVpc.Upa.Impl.Uql.Compiledexpression
{


    /**
     * Created by IntelliJ IDEA.
     * User: root
     * Date: 22 mai 2003
     * Time: 17:00:10
     * To change this template use Options | File Templates.
     */
    public class CompiledCurrentUser : Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledFunction {



        public CompiledCurrentUser()  : base("CurrentUser"){

        }


        public override Net.TheVpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            return Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform.DATE;
        }


        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledCurrentUser o = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledCurrentUser();
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
            return o;
        }
    }
}
