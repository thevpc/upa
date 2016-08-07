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



namespace Net.Vpc.Upa.Impl.Persistence
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/6/12 12:31 AM
     */
    public class DefaultSQLManager : Net.Vpc.Upa.Impl.Persistence.SQLManager {

        private Net.Vpc.Upa.Impl.Util.ClassMap<Net.Vpc.Upa.Impl.Persistence.SQLProvider> sqlProviders = new Net.Vpc.Upa.Impl.Util.ClassMap<Net.Vpc.Upa.Impl.Persistence.SQLProvider>();

        private Net.Vpc.Upa.Impl.Persistence.MarshallManager marshallManager;

        public DefaultSQLManager(Net.Vpc.Upa.Impl.Persistence.MarshallManager marshallManager) {
            this.marshallManager = marshallManager;
            Register0(new Net.Vpc.Upa.Impl.Persistence.Shared.BinaryOperatorExpressionSQLProvider());
            Register0(new Net.Vpc.Upa.Impl.Persistence.Shared.PlusExpressionSQLProvider());
            Register0(new Net.Vpc.Upa.Impl.Persistence.Shared.VarSQLProvider());
            Register0(new Net.Vpc.Upa.Impl.Persistence.Shared.UnaryOperatorSQLProvider());
            Register0(new Net.Vpc.Upa.Impl.Persistence.Shared.BinaryExpressionSQLProvider());
            Register0(new Net.Vpc.Upa.Impl.Persistence.Shared.LiteralSQLProvider());
            Register0(new Net.Vpc.Upa.Impl.Persistence.Shared.AverageSQLProvider());
            Register0(new Net.Vpc.Upa.Impl.Persistence.Shared.BetweenSQLProvider());
            Register0(new Net.Vpc.Upa.Impl.Persistence.Shared.EntityNameSQLProvider());
            Register0(new Net.Vpc.Upa.Impl.Persistence.Shared.SelectSQLProvider());
            Register0(new Net.Vpc.Upa.Impl.Persistence.Shared.DeleteSQLProvider());
            Register0(new Net.Vpc.Upa.Impl.Persistence.Shared.UpdateSQLProvider());
            Register0(new Net.Vpc.Upa.Impl.Persistence.Shared.InsertSQLProvider());
            Register0(new Net.Vpc.Upa.Impl.Persistence.Shared.InCollectionSQLProvider());
            Register0(new Net.Vpc.Upa.Impl.Persistence.Shared.InSelectionSQLProvider());
            Register0(new Net.Vpc.Upa.Impl.Persistence.Shared.ParamSQLProvider());
            Register0(new Net.Vpc.Upa.Impl.Persistence.Shared.UpletSQLProvider());
            Register0(new Net.Vpc.Upa.Impl.Persistence.Shared.ValueSQLProvider());
            Register0(new Net.Vpc.Upa.Impl.Persistence.Shared.CountANSISQLProvider());
            Register0(new Net.Vpc.Upa.Impl.Persistence.Shared.MaxANSISQLProvider());
            Register0(new Net.Vpc.Upa.Impl.Persistence.Shared.MinANSISQLProvider());
            Register0(new Net.Vpc.Upa.Impl.Persistence.Shared.SumANSISQLProvider());
            Register0(new Net.Vpc.Upa.Impl.Persistence.Shared.AvgANSISQLProvider());
            Register0(new Net.Vpc.Upa.Impl.Persistence.Shared.TypeNameSQLProvider());
            Register0(new Net.Vpc.Upa.Impl.Persistence.Shared.CurrentUserSQLProvider());
            Register0(new Net.Vpc.Upa.Impl.Persistence.Shared.CompiledQLFunctionExpressionSQLProvider());
            Register0(new Net.Vpc.Upa.Impl.Persistence.Shared.KeyEnumerationExpressionSQLProvider());
        }

        public virtual void Register(Net.Vpc.Upa.Impl.Persistence.SQLProvider provider) {
            Register0(provider);
        }

        private void Register0(Net.Vpc.Upa.Impl.Persistence.SQLProvider provider) {
            sqlProviders.Put(provider.GetExpressionType(), provider);
        }

        public virtual string GetSQL(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression, Net.Vpc.Upa.Persistence.EntityExecutionContext context, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            //        if (context == null) {
            //            context = createContext(ContextOperation.FIND);
            //        }
            if (expression != null) {
                Net.Vpc.Upa.Impl.Persistence.SQLProvider p = sqlProviders.Get(expression.GetType());
                if (p != null) {
                    return p.GetSQL(expression, context, this, declarations);
                }
            }
            throw new System.Exception(System.Convert.ToString(expression));
        }


        public virtual Net.Vpc.Upa.Impl.Persistence.MarshallManager GetMarshallManager() {
            return marshallManager;
        }
    }
}
