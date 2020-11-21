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


    public abstract class DefaultCompiledEntityStatement : Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpressionImpl, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityStatement {



        public DefaultCompiledEntityStatement() {
        }


        public override Net.TheVpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            return new Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform(Net.TheVpc.Upa.Types.TypesFactory.VOID);
        }

        protected internal abstract System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledNamedExpression> FindEntityDefinitions();

        public virtual System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect> FindEntityDefinitions(System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect> inherited) {
            System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect> m = new System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect>();
            if (inherited != null) {
                Net.TheVpc.Upa.Impl.FwkConvertUtils.PutAllMap<string,Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect>(m,inherited);
            }
            System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledNamedExpression> list = FindEntityDefinitions();
            if (list != null) {
                foreach (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledNamedExpression objects in list) {
                    Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect entity = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect) objects.GetExpression();
                    string entityAlias = objects.GetName();
                    if (entity != null) {
                        if (entityAlias == null) {
                            if (entity is Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) {
                                entityAlias = ((Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) entity).GetName();
                            }
                        }
                        if (entityAlias != null) {
                            m[entityAlias]=entity;
                        }
                    }
                }
            }
            return m;
        }
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public override abstract Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] GetSubExpressions();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public override abstract void SetSubExpression(int arg1, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression arg2);
    }
}
