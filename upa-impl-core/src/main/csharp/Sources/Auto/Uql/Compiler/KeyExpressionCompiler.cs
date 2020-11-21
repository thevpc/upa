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



namespace Net.TheVpc.Upa.Impl.Uql.Compiler
{


    /**
     * Created with IntelliJ IDEA. User: vpc Date: 8/15/12 Time: 11:46 PM To change
     * this template use File | Settings | File Templates.
     */
    public class KeyExpressionCompiler : Net.TheVpc.Upa.Impl.Uql.ExpressionTranslator {


        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression TranslateExpression(object x, Net.TheVpc.Upa.Impl.Uql.ExpressionTranslationManager manager, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Expressions.IdExpression o = (Net.TheVpc.Upa.Expressions.IdExpression) x;
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression ret = null;
            Net.TheVpc.Upa.Entity entity = null;
            if (o.GetEntity() != null) {
                entity = o.GetEntity();
            }
            Net.TheVpc.Upa.PersistenceUnit persistenceUnit = manager.GetPersistenceUnit();
            if (entity == null && o.GetEntityName() != null) {
                entity = persistenceUnit.GetEntity(o.GetEntityName());
            }
            if (entity == null && o.GetAlias() != null) {
                //check if alias
                System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Uql.ExpressionDeclaration> dvalues = declarations.GetDeclarations(null);
                if (dvalues != null) {
                    foreach (Net.TheVpc.Upa.Impl.Uql.ExpressionDeclaration @ref in dvalues) {
                        switch(@ref.GetReferrerType()) {
                            case Net.TheVpc.Upa.Impl.Uql.DecObjectType.ENTITY:
                                {
                                    entity = persistenceUnit.GetEntity((string) @ref.GetReferrerName());
                                    break;
                                }
                        }
                    }
                }
            }
            if (entity == null && o.GetAlias() != null) {
                //check if entity
                if (persistenceUnit.ContainsEntity(o.GetAlias())) {
                    entity = persistenceUnit.GetEntity(o.GetAlias());
                }
            }
            if (entity == null) {
                throw new System.ArgumentException ("Key enumeration must by associated to and entity");
            }
            Net.TheVpc.Upa.Key key = entity.GetBuilder().IdToKey(o.GetId());
            object[] values = key == null ? null : key.GetValue();
            Net.TheVpc.Upa.Entity entity1 = o.GetEntity();
            System.Collections.Generic.IList<Net.TheVpc.Upa.PrimitiveField> f = entity1.ToPrimitiveFields<Net.TheVpc.Upa.Field>(entity1.GetPrimaryFields());
            for (int i = 0; i < (f).Count; i++) {
                Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar ppp = o.GetAlias() == null ? null : new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar(o.GetAlias());
                if (ppp == null) {
                    ppp = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar(f[i].GetName());
                } else {
                    ppp.SetChild(new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar(f[i].GetName()));
                }
                Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEquals e = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEquals(ppp, new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral(values == null ? null : values[i], Net.TheVpc.Upa.Impl.Util.UPAUtils.GetTypeTransformOrIdentity(f[i])));
                ret = (ret == null) ? ((Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression)(e)) : new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledAnd(ret, e);
            }
            if (ret == null) {
                ret = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEquals(new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral(1), new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral(1));
            }
            return ret;
        }
    }
}
