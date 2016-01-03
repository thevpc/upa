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


    public abstract class DefaultCompiledEntityStatement : Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpressionImpl, Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityStatement {



        public DefaultCompiledEntityStatement() {
        }


        public override Net.Vpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            return new Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform(Net.Vpc.Upa.Types.TypesFactory.VOID);
        }

        protected internal abstract System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNamedExpression> FindEntityDefinitions();

        public virtual System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect> FindEntityDefinitions(System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect> inherited) {
            System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect> m = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect>();
            if (inherited != null) {
                Net.Vpc.Upa.Impl.FwkConvertUtils.PutAllMap<string,Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect>(m,inherited);
            }
            System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNamedExpression> list = FindEntityDefinitions();
            if (list != null) {
                foreach (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNamedExpression objects in list) {
                    Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect entity = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect) objects.GetExpression();
                    string entityAlias = objects.GetName();
                    if (entity != null) {
                        if (entityAlias == null) {
                            if (entity is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) {
                                entityAlias = ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) entity).GetName();
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
        public override abstract Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] GetSubExpressions();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public override abstract void SetSubExpression(int arg1, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression arg2);
    }
}
