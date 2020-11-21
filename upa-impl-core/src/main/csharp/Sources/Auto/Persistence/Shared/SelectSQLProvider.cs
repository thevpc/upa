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
     * Created with IntelliJ IDEA. User: vpc Date: 8/17/12 Time: 12:52 AM To change
     * this template use File | Settings | File Templates.
     */
    public class SelectSQLProvider : Net.TheVpc.Upa.Impl.Persistence.Shared.AbstractSQLProvider {

        public SelectSQLProvider()  : base(typeof(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect)){

        }


        public override string GetSQL(object oo, Net.TheVpc.Upa.Persistence.EntityExecutionContext context, Net.TheVpc.Upa.Impl.Persistence.SQLManager sqlManager, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect o = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect) oo;
            System.Text.StringBuilder sb = new System.Text.StringBuilder("Select ");
            AppendDistinct(o, sb, context, sqlManager, declarations);
            AppendFields(o, sb, context, sqlManager, declarations);
            AppendFrom(o, sb, context, sqlManager, declarations);
            AppendJoins(o, sb, context, sqlManager, declarations);
            AppendWhere(o, sb, context, sqlManager, declarations);
            AppendGroupBy(o, sb, context, sqlManager, declarations);
            AppendHaving(o, sb, context, sqlManager, declarations);
            AppendOrderBy(o, sb, context, sqlManager, declarations);
            return sb.ToString();
        }

        protected internal virtual void AppendFrom(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect o, System.Text.StringBuilder sb, Net.TheVpc.Upa.Persistence.EntityExecutionContext context, Net.TheVpc.Upa.Impl.Persistence.SQLManager sqlManager, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect entity = o.GetEntity();
            if (entity == null) {
                string fns = GetFromNullString();
                if (fns != null) {
                    sb.Append(" ");
                    sb.Append(fns);
                }
            } else {
                sb.Append(" From ");
                if (entity is Net.TheVpc.Upa.Expressions.Select) {
                    sb.Append(sqlManager.GetSQL(entity, context, declarations));
                } else {
                    Net.TheVpc.Upa.Persistence.PersistenceStore persistenceStore = context.GetPersistenceStore();
                    Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName entityName = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) entity;
                    Net.TheVpc.Upa.Entity e = context.GetPersistenceUnit().GetEntity(entityName.GetName());
                    if (entityName.IsUseView() && e.NeedsView() && persistenceStore.IsViewSupported()) {
                        Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName v = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName(e.GetName(), true);
                        sb.Append(sqlManager.GetSQL(v, context, declarations));
                    } else {
                        sb.Append(sqlManager.GetSQL(entityName, context, declarations));
                    }
                }
            }
            if (o.GetEntityAlias() != null) {
                Net.TheVpc.Upa.Persistence.PersistenceStore store = context.GetPersistenceStore();
                sb.Append(" ").Append(sqlManager.GetSQL(new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar(o.GetEntityAlias()), context, declarations));
            }
        }

        protected internal virtual void AppendJoins(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect o, System.Text.StringBuilder sb, Net.TheVpc.Upa.Persistence.EntityExecutionContext context, Net.TheVpc.Upa.Impl.Persistence.SQLManager sqlManager, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            for (int i = 0; i < o.CountJoins(); i++) {
                Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledJoinCriteria e = o.GetJoin(i);
                //            String _valueString = sqlManager.getSQL(e.getEntity(), context, declarations);
                string _aliasString = e.GetEntityAlias();
                string _joinKey = "Inner Join";
                switch(e.GetJoinType()) {
                    case Net.TheVpc.Upa.Expressions.JoinType.INNER_JOIN:
                        _joinKey = "Inner Join";
                        break;
                    case Net.TheVpc.Upa.Expressions.JoinType.FULL_JOIN:
                        _joinKey = "Full Join";
                        break;
                    case Net.TheVpc.Upa.Expressions.JoinType.LEFT_JOIN:
                        _joinKey = "Left Join";
                        break;
                    case Net.TheVpc.Upa.Expressions.JoinType.RIGHT_JOIN:
                        _joinKey = "Right Join";
                        break;
                    case Net.TheVpc.Upa.Expressions.JoinType.CROSS_JOIN:
                        _joinKey = "Cross Join";
                        break;
                }
                sb.Append(" ").Append(_joinKey).Append(" ").Append(sqlManager.GetSQL(e.GetEntity(), context, declarations));
                if (_aliasString != null) {
                    Net.TheVpc.Upa.Persistence.PersistenceStore store = context.GetPersistenceStore();
                    //                String goodAlias = store.getPersistenceName(, PersistenceNameType.ALIAS);
                    sb.Append(" ").Append(sqlManager.GetSQL(new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar(_aliasString), context, declarations));
                }
                if (e.GetCondition() != null && e.GetCondition().IsValid()) {
                    sb.Append(" On ").Append(sqlManager.GetSQL(e.GetCondition(), context, declarations));
                }
            }
        }

        protected internal virtual void AppendDistinct(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect o, System.Text.StringBuilder sb, Net.TheVpc.Upa.Persistence.EntityExecutionContext context, Net.TheVpc.Upa.Impl.Persistence.SQLManager sqlManager, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            if (o.IsDistinct()) {
                sb.Append(" DISTINCT");
            }
        }

        protected internal virtual void AppendFields(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect o, System.Text.StringBuilder sb, Net.TheVpc.Upa.Persistence.EntityExecutionContext context, Net.TheVpc.Upa.Impl.Persistence.SQLManager sqlManager, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            sb.Append(" ");
            string aliasString = null;
            string valueString = null;
            bool started = false;
            if (o.CountFields() == 0) {
                sb.Append("...");
            } else {
                //            PersistenceStore persistenceStore = context.getPersistenceStore();
                for (int i = 0; i < o.CountFields(); i++) {
                    Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField fi = o.GetField(i);
                    Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression e = fi.GetExpression();
                    bool fieldIsSelect = e is Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect;
                    valueString = sqlManager.GetSQL(e, context, declarations);
                    if (fieldIsSelect) {
                        valueString = "(" + valueString + ")";
                    }
                    aliasString = fi.GetAlias();
                    if (started) {
                        sb.Append(",");
                    } else {
                        started = true;
                    }
                    if (aliasString == null) {
                        sb.Append(valueString);
                    } else {
                        sb.Append(valueString);
                        sb.Append(" ");
                        sb.Append(sqlManager.GetSQL(new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar(aliasString), context, declarations));
                    }
                }
            }
        }

        protected internal virtual void AppendGroupBy(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect o, System.Text.StringBuilder sb, Net.TheVpc.Upa.Persistence.EntityExecutionContext context, Net.TheVpc.Upa.Impl.Persistence.SQLManager sqlManager, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            if (o.CountGroupByItems() > 0) {
                sb.Append(" ");
                int max = o.CountGroupByItems();
                sb.Append("Group By ");
                for (int i = 0; i < max; i++) {
                    if (i > 0) {
                        sb.Append(", ");
                    }
                    sb.Append(sqlManager.GetSQL(o.GetGroupBy(i), context, declarations));
                }
            }
        }

        protected internal virtual void AppendWhere(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression cond, System.Text.StringBuilder sb, Net.TheVpc.Upa.Persistence.EntityExecutionContext context, Net.TheVpc.Upa.Impl.Persistence.SQLManager sqlManager, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            if (cond != null && cond.IsValid()) {
                sb.Append(" Where ").Append(sqlManager.GetSQL(cond, context, declarations));
            }
        }

        protected internal virtual void AppendWhere(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect o, System.Text.StringBuilder sb, Net.TheVpc.Upa.Persistence.EntityExecutionContext context, Net.TheVpc.Upa.Impl.Persistence.SQLManager sqlManager, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            AppendWhere(o.GetWhere(), sb, context, sqlManager, declarations);
        }

        protected internal virtual void AppendHaving(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect o, System.Text.StringBuilder sb, Net.TheVpc.Upa.Persistence.EntityExecutionContext context, Net.TheVpc.Upa.Impl.Persistence.SQLManager sqlManager, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression hav = o.GetHaving();
            if (hav != null && hav.IsValid()) {
                sb.Append(" Having ").Append(sqlManager.GetSQL(hav, context, declarations));
            }
        }

        protected internal virtual void AppendOrderBy(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect o, System.Text.StringBuilder sb, Net.TheVpc.Upa.Persistence.EntityExecutionContext context, Net.TheVpc.Upa.Impl.Persistence.SQLManager sqlManager, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            int max = o.CountOrderByItems();
            if (max > 0) {
                sb.Append(" ");
                sb.Append("Order By ");
                for (int i = 0; i < max; i++) {
                    if (i > 0) {
                        sb.Append(", ");
                    }
                    sb.Append(sqlManager.GetSQL(o.GetOrderBy(i), context, declarations));
                    if (o.IsOrderAscending(i)) {
                        sb.Append(" Asc ");
                    } else {
                        sb.Append(" Desc ");
                    }
                }
            }
        }

        public virtual string GetFromNullString() {
            return null;
        }
    }
}
