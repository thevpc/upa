package net.vpc.upa.impl.persistence.shared.sql;

import net.vpc.upa.Entity;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.Select;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.persistence.SQLManager;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.compiledexpression.*;
import net.vpc.upa.persistence.EntityExecutionContext;
import net.vpc.upa.persistence.PersistenceStore;

/**
 * Created with IntelliJ IDEA. User: vpc Date: 8/17/12 Time: 12:52 AM To change
 * this template use File | Settings | File Templates.
 */
public class SelectSQLProvider extends AbstractSQLProvider {

    public SelectSQLProvider() {
        super(CompiledSelect.class);
    }

    @Override
    public String getSQL(Object oo, EntityExecutionContext context, SQLManager sqlManager, ExpressionDeclarationList declarations) throws UPAException {
        CompiledSelect o = (CompiledSelect) oo;
        StringBuilder sb = new StringBuilder("Select ");
        appendDistinct(o, sb, context, sqlManager, declarations);
        appendFields(o, sb, context, sqlManager, declarations);
        appendFrom(o, sb, context, sqlManager, declarations);
        appendJoins(o, sb, context, sqlManager, declarations);
        appendWhere(o, sb, context, sqlManager, declarations);
        appendGroupBy(o, sb, context, sqlManager, declarations);

        appendHaving(o, sb, context, sqlManager, declarations);
        appendOrderBy(o, sb, context, sqlManager, declarations);
        return sb.toString();
    }

    protected void appendFrom(CompiledSelect o, StringBuilder sb, EntityExecutionContext context, SQLManager sqlManager, ExpressionDeclarationList declarations) {
        CompiledNameOrSelect entity = o.getEntity();
        if (entity == null) {
            String fns = getFromNullString();
            if (fns != null) {
                sb.append(" ");
                sb.append(fns);
            }
        } else {
            sb.append(" From ");
            if (entity instanceof Select) {
                sb.append(sqlManager.getSQL(entity, context, declarations));
            } else {
                PersistenceStore persistenceStore = context.getPersistenceStore();
                CompiledEntityName entityName = (CompiledEntityName) entity;
                Entity e = context.getPersistenceUnit().getEntity(entityName.getName());
                if (entityName.isUseView() && e.hasAssociatedView() && persistenceStore.isViewSupported()) {
                    CompiledEntityName v = new CompiledEntityName(e.getName(),true);
                    sb.append(sqlManager.getSQL(v, context, declarations));
                } else {
                    sb.append(sqlManager.getSQL(entityName, context, declarations));
                }
            }
        }
        if (o.getEntityAlias() != null) {
            PersistenceStore store = context.getPersistenceStore();
            sb.append(" ").append(sqlManager.getSQL(new CompiledVar(o.getEntityAlias()), context, declarations));
        }
    }

    protected void appendJoins(CompiledSelect o, StringBuilder sb, EntityExecutionContext context, SQLManager sqlManager, ExpressionDeclarationList declarations) {
        for (int i = 0; i < o.countJoins(); i++) {
            CompiledJoinCriteria e = o.getJoin(i);

//            String _valueString = sqlManager.getSQL(e.getEntity(), context, declarations);
            String _aliasString = e.getEntityAlias();
            String _joinKey = "Inner Join";
            switch (e.getJoinType()) {
                case INNER_JOIN: // '\0'
                    _joinKey = "Inner Join";
                    break;

                case FULL_JOIN: // '\001'
                    _joinKey = "Full Join";
                    break;

                case LEFT_JOIN: // '\002'
                    _joinKey = "Left Join";
                    break;

                case RIGHT_JOIN: // '\003'
                    _joinKey = "Right Join";
                    break;

                case CROSS_JOIN: // '\003'
                    _joinKey = "Cross Join";
                    break;
            }
            sb.append(" ").append(_joinKey).append(" ").append(sqlManager.getSQL(e.getEntity(), context, declarations));
            if (_aliasString != null) {
                PersistenceStore store = context.getPersistenceStore();
//                String goodAlias = store.getPersistenceName(, PersistenceNameType.ALIAS);
                sb.append(" ").append(sqlManager.getSQL(new CompiledVar(_aliasString), context, declarations));
            }
            if (e.getCondition() != null && e.getCondition().isValid()) {
                sb.append(" On ").append(
                        sqlManager.getSQL(e.getCondition(), context, declarations)
                );
            }
        }

    }

    protected void appendDistinct(CompiledSelect o, StringBuilder sb, EntityExecutionContext context, SQLManager sqlManager, ExpressionDeclarationList declarations) {
        if (o.isDistinct()) {
            sb.append(" DISTINCT");
        }
    }

    protected void appendFields(CompiledSelect o, StringBuilder sb, EntityExecutionContext context, SQLManager sqlManager, ExpressionDeclarationList declarations) {
        sb.append(" ");
        String aliasString = null;
        String valueString = null;
        boolean started = false;
        if (o.countFields() == 0) {
            sb.append("...");
        } else {
//            PersistenceStore persistenceStore = context.getPersistenceStore();
            for (int i = 0; i < o.countFields(); i++) {
                CompiledQueryField fi = o.getField(i);
                CompiledExpressionExt e = fi.getExpression();
                boolean fieldIsSelect=e instanceof CompiledSelect;
                valueString = sqlManager.getSQL(e, context, declarations);
                if(fieldIsSelect){
                    valueString="("+valueString+")";
                }
                aliasString = fi.getAlias();
                if (started) {
                    sb.append(",");
                } else {
                    started = true;
                }
                if (aliasString == null /*|| valueString.equals(aliasString)*/) {
                    sb.append(valueString);
                } else {
                    sb.append(valueString);
                    sb.append(" ");
                    sb.append(sqlManager.getSQL(new CompiledVar(aliasString), context, declarations));
                }
            }

        }
    }

    protected void appendGroupBy(CompiledSelect o, StringBuilder sb, EntityExecutionContext context, SQLManager sqlManager, ExpressionDeclarationList declarations) {
        if (o.countGroupByItems() > 0) {
            sb.append(" ");
            int max = o.countGroupByItems();
            sb.append("Group By ");
            for (int i = 0; i < max; i++) {
                if (i > 0) {
                    sb.append(", ");
                }
                sb.append(sqlManager.getSQL(o.getGroupBy(i), context, declarations));
            }
        }
    }

    protected void appendWhere(CompiledExpressionExt cond, StringBuilder sb, EntityExecutionContext context, SQLManager sqlManager, ExpressionDeclarationList declarations) {
        
        if (cond != null && cond.isValid()) {
            sb.append(" Where ").append(sqlManager.getSQL(cond, context, declarations));
        }
    }
    protected void appendWhere(CompiledSelect o, StringBuilder sb, EntityExecutionContext context, SQLManager sqlManager, ExpressionDeclarationList declarations) {
        appendWhere(o.getWhere(), sb, context, sqlManager, declarations);
    }

    protected void appendHaving(CompiledSelect o, StringBuilder sb, EntityExecutionContext context, SQLManager sqlManager, ExpressionDeclarationList declarations) {
        CompiledExpressionExt hav = o.getHaving();
        if (hav != null && hav.isValid()) {
            sb.append(" Having ").append(sqlManager.getSQL(hav, context, declarations));
        }
    }

    protected void appendOrderBy(CompiledSelect o, StringBuilder sb, EntityExecutionContext context, SQLManager sqlManager, ExpressionDeclarationList declarations) {
        int max = o.countOrderByItems();
        if (max > 0) {
            sb.append(" ");
            sb.append("Order By ");
            for (int i = 0; i < max; i++) {
                if (i > 0) {
                    sb.append(", ");
                }
                sb.append(sqlManager.getSQL(o.getOrderBy(i), context, declarations));
                if (o.isOrderAscending(i)) {
                    sb.append(" Asc ");
                } else {
                    sb.append(" Desc ");
                }
            }
        }
    }

    public String getFromNullString() {
        return null;
    }
}
