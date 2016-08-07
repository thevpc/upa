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



namespace Net.Vpc.Upa.Impl.Persistence.Shared
{


    /**
     * Created with IntelliJ IDEA. User: vpc Date: 8/17/12 Time: 12:52 AM To change
     * this template use File | Settings | File Templates.
     */
    public class UpdateSQLProvider : Net.Vpc.Upa.Impl.Persistence.Shared.AbstractSQLProvider {

        public UpdateSQLProvider()  : base(typeof(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledUpdate)){

        }


        public override string GetSQL(object oo, Net.Vpc.Upa.Persistence.EntityExecutionContext context, Net.Vpc.Upa.Impl.Persistence.SQLManager sqlManager, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledUpdate o = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledUpdate) oo;
            Net.Vpc.Upa.Persistence.PersistenceStore persistenceStore = context.GetPersistenceStore();
            Net.Vpc.Upa.PersistenceUnit pu = context.GetPersistenceUnit();
            Net.Vpc.Upa.Entity entity = pu.GetEntity(o.GetEntity().GetName());
            //        String persistenceName = persistenceStore.getPersistenceName(entity);
            System.Text.StringBuilder sb = new System.Text.StringBuilder("Update " + sqlManager.GetSQL(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName(entity.GetName()), context, declarations));
            string tableAlias = o.GetEntityAlias();
            if (tableAlias != null) {
                sb.Append(" ");
                sb.Append(sqlManager.GetSQL(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar(tableAlias), context, declarations));
            }
            sb.Append(" Set ");
            bool isFirst = true;
            int max = o.CountFields();
            for (int i = 0; i < max; i++) {
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar vv = o.GetField(i);
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar ev = null;
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar fv = null;
                if (vv.GetChild() == null) {
                    ev = null;
                    fv = vv;
                } else {
                    ev = vv;
                    fv = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) vv.GetChild();
                }
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression fieldValue = o.GetFieldValue(i);
                //            Object referrer = vv.getReferrer();
                Net.Vpc.Upa.Field f = ((Net.Vpc.Upa.Field) fv.GetReferrer());
                Net.Vpc.Upa.Entity entityManager = f.GetEntity();
                System.Collections.Generic.IList<Net.Vpc.Upa.PrimitiveField> primFields = entityManager.ToPrimitiveFields<Net.Vpc.Upa.EntityPart>(new System.Collections.Generic.List<Net.Vpc.Upa.EntityPart>(new[]{(Net.Vpc.Upa.EntityPart) f}));
                foreach (Net.Vpc.Upa.PrimitiveField primField in primFields) {
                    if (isFirst) {
                        isFirst = false;
                    } else {
                        sb.Append(", ");
                    }
                    if (ev != null) {
                        sb.Append(sqlManager.GetSQL(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar(ev.GetName()), context, declarations)).Append(".");
                    }
                    sb.Append(sqlManager.GetSQL(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar(primField), context, declarations));
                    sb.Append("=").Append("(").Append(sqlManager.GetSQL(fieldValue, context, declarations)).Append(")");
                }
            }
            if (o.GetCondition() != null && o.GetCondition().IsValid()) {
                sb.Append(" Where ").Append(sqlManager.GetSQL(o.GetCondition(), context, declarations));
            }
            if (persistenceStore.IsViewSupported() && entity.NeedsView() && o.GetEntity().IsUseView()) {
                string implicitTableAlias = persistenceStore.GetPersistenceName("IT_" + entity.GetName(), Net.Vpc.Upa.Persistence.PersistenceNameType.ALIAS);
                sb.Append(" ");
                sb.Append(sqlManager.GetSQL(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName(entity.GetName()), context, declarations)).Append(" ").Append(implicitTableAlias).Append(",").Append(sqlManager.GetSQL(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName(entity.GetName(), true), context, declarations)).Append(" ").Append(sqlManager.GetSQL(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar(tableAlias), context, declarations));
            }
            //            if (extraFrom != null)
            return sb.ToString();
        }
    }
}
