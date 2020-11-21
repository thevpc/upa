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
     * Created with IntelliJ IDEA. User: vpc Date: 8/16/12 Time: 10:12 PM To change
     * this template use File | Settings | File Templates.
     */
    public class CompiledEntityName : Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpressionImpl, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect {

        private string name;

        private bool isUseView;

        public CompiledEntityName(string name, bool isUseView) {
            this.name = name;
            this.isUseView = isUseView;
        }

        public CompiledEntityName(string name) {
            this.name = name;
        }

        public virtual string GetName() {
            return name;
        }


        public override bool IsValid() {
            return true;
        }


        public override Net.TheVpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            return Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform.VOID;
        }

        public virtual bool IsUseView() {
            return isUseView;
        }

        public virtual void SetUseView(bool useView) {
            isUseView = useView;
        }


        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName o = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName(name);
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
            o.SetUseView(isUseView);
            return o;
        }


        public override string ToString() {
            return System.Convert.ToString(name);
        }


        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] GetSubExpressions() {
            return null;
        }


        public override void SetSubExpression(int index, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            throw new System.Exception("Not supported.");
        }
    }
}
