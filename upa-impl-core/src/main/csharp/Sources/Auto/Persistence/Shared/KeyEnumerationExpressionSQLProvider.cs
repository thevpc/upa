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



namespace Net.TheVpc.Upa.Impl.Persistence.Shared
{


    /**
     * Created with IntelliJ IDEA. User: vpc Date: 8/15/12 Time: 11:46 PM To change
     * this template use File | Settings | File Templates.
     */
    public class KeyEnumerationExpressionSQLProvider : Net.TheVpc.Upa.Impl.Persistence.Shared.AbstractSQLProvider {

        public KeyEnumerationExpressionSQLProvider()  : base(typeof(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledKeyEnumerationExpression)){

        }


        public override string GetSQL(object o, Net.TheVpc.Upa.Persistence.EntityExecutionContext qlContext, Net.TheVpc.Upa.Impl.Persistence.SQLManager sqlManager, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledKeyEnumerationExpression ee = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledKeyEnumerationExpression) o;
            Net.TheVpc.Upa.Entity entity = null;
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar compiledVar = null;
            if (ee.GetAlias() != null) {
                compiledVar = ee.GetAlias();
                entity = (compiledVar.GetReferrer() is Net.TheVpc.Upa.Entity) ? ((Net.TheVpc.Upa.Entity) compiledVar.GetReferrer()) : null;
            } else {
                //check if alias
                System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Uql.ExpressionDeclaration> dvalues = ee.GetDeclarations(null);
                if (dvalues != null) {
                    foreach (Net.TheVpc.Upa.Impl.Uql.ExpressionDeclaration @ref in dvalues) {
                        switch(@ref.GetReferrerType()) {
                            case Net.TheVpc.Upa.Impl.Uql.DecObjectType.ENTITY:
                                {
                                    entity = qlContext.GetPersistenceUnit().GetEntity((string) @ref.GetReferrerName());
                                    break;
                                }
                        }
                    }
                }
            }
            if (entity == null) {
                throw new System.ArgumentException ("Key enumeration must by associated to and entity");
            }
            if ((ee.GetKeys().Count==0)) {
                return sqlManager.GetSQL(new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEquals(new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral(1), new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral(2)), qlContext, declarations);
            }
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> pfs = entity.GetPrimaryFields();
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression o2 = null;
            foreach (object key in ee.GetKeys()) {
                Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression a = null;
                bool processed = false;
                if (entity.GetPersistenceUnit().ContainsEntity(entity.GetIdType())) {
                    if (!entity.GetIdType().IsInstanceOfType(key)) {
                        //primitive seen as entity?
                        // A's id is A.b where b is an entity
                        //TODO fix all cases!
                        if ((entity.GetPrimaryFields()).Count == 1) {
                            Net.TheVpc.Upa.Types.ManyToOneType et = (Net.TheVpc.Upa.Types.ManyToOneType) entity.GetPrimaryFields()[0].GetDataType();
                            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> ff = et.GetRelationship().GetSourceRole().GetFields();
                            Net.TheVpc.Upa.Key key2 = et.GetRelationship().GetTargetEntity().GetBuilder().IdToKey(key);
                            for (int j = 0; j < (ff).Count; j++) {
                                Net.TheVpc.Upa.Field f = ff[j];
                                Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar rr = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar(f);
                                Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar p2 = compiledVar == null ? null : (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) compiledVar.Copy();
                                if (p2 == null) {
                                    p2 = rr;
                                } else {
                                    p2.SetChild(rr);
                                }
                                Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEquals v = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEquals(p2, new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral(key2.GetObjectAt(j), Net.TheVpc.Upa.Impl.Util.UPAUtils.GetTypeTransformOrIdentity(f)));
                                if (a == null) {
                                    a = v;
                                } else {
                                    a = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledAnd(a, v);
                                }
                            }
                            if (o2 == null) {
                                o2 = a;
                            } else {
                                o2 = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledOr(o2, a);
                            }
                            processed = true;
                        }
                    }
                }
                if (!processed) {
                    Net.TheVpc.Upa.Key uKey = entity.GetBuilder().IdToKey(key);
                    for (int j = 0; j < (pfs).Count; j++) {
                        Net.TheVpc.Upa.Field f = pfs[j];
                        Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar rr = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar(f);
                        Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar p2 = compiledVar == null ? null : (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) compiledVar.Copy();
                        if (p2 == null) {
                            p2 = rr;
                        } else {
                            p2.SetChild(rr);
                        }
                        Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEquals v = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEquals(p2, new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral(uKey.GetObjectAt(j), Net.TheVpc.Upa.Impl.Util.UPAUtils.GetTypeTransformOrIdentity(f)));
                        if (a == null) {
                            a = v;
                        } else {
                            a = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledAnd(a, v);
                        }
                    }
                    if (o2 == null) {
                        o2 = a;
                    } else {
                        o2 = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledOr(o2, a);
                    }
                }
            }
            return sqlManager.GetSQL(o2, qlContext, declarations);
        }
    }
}
