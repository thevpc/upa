package net.vpc.upa.impl.persistence.shared.sql;

import net.vpc.upa.impl.upql.ext.expr.CompiledVar;
import net.vpc.upa.impl.upql.ext.expr.CompiledJoinCriteria;
import net.vpc.upa.impl.upql.ext.expr.CompiledUpdate;
import net.vpc.upa.impl.upql.ext.expr.CompiledEntityName;
import net.vpc.upa.Entity;
import net.vpc.upa.Field;
import net.vpc.upa.PrimitiveField;
import net.vpc.upa.config.PersistenceNameType;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.persistence.SQLManager;
import net.vpc.upa.impl.upql.ExpressionDeclarationList;
import net.vpc.upa.persistence.EntityExecutionContext;
import net.vpc.upa.persistence.PersistenceStore;

import java.util.Arrays;
import java.util.List;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.EntityItem;

/**
 * Created with IntelliJ IDEA. User: vpc Date: 8/17/12 Time: 12:52 AM To change
 * this template use File | Settings | File Templates.
 */
public class UpdateSQLProvider extends AbstractSQLProvider {

    public UpdateSQLProvider() {
        super(CompiledUpdate.class);
    }

    @Override
    public String getSQL(Object oo, EntityExecutionContext context, SQLManager sqlManager, ExpressionDeclarationList declarations) throws UPAException {
        CompiledUpdate o = (CompiledUpdate) oo;
        PersistenceStore persistenceStore = context.getPersistenceStore();
        PersistenceUnit pu = context.getPersistenceUnit();
        Entity entity = pu.getEntity(o.getEntity().getName());
//        String persistenceName = persistenceStore.getPersistenceName(entity);
        StringBuilder sb = new StringBuilder("Update " + sqlManager.getSQL(new CompiledEntityName(entity.getName()), context, declarations));
        String tableAlias = o.getEntityAlias();
        if (tableAlias != null) {
            sb.append(" ");
            sb.append(sqlManager.getSQL(new CompiledVar(tableAlias), context, declarations));
        }
        sb.append(" Set ");
        boolean isFirst = true;
        int max = o.countFields();
        for (int i = 0; i < max; i++) {
            CompiledVar vv = o.getField(i);
            CompiledVar ev = null;
            CompiledVar fv = null;
            if (vv.getChild() == null) {
                ev = null;
                fv = vv;
            } else {
                ev = vv;
                fv = (CompiledVar) vv.getChild();
            }

            CompiledExpressionExt fieldValue = o.getFieldValue(i);
//            Object referrer = vv.getReferrer();
            Field f = ((Field) fv.getReferrer());
            Entity entityManager = f.getEntity();
            List<PrimitiveField> primFields = entityManager.toPrimitiveFields(Arrays.asList((EntityItem) f));

            for (PrimitiveField primField : primFields) {
                if (isFirst) {
                    isFirst = false;
                } else {
                    sb.append(", ");
                }
                if (ev != null) {
                    sb.append(sqlManager.getSQL(new CompiledVar(ev.getName()), context, declarations)).append(".");
                }
                sb.append(sqlManager.getSQL(new CompiledVar(primField), context, declarations));
                sb.append("=").append("(").append(sqlManager.getSQL(fieldValue, context, declarations)).append(")");
            }
        }
        appendJoins(o, sb, context, sqlManager, declarations);
        if (o.getCondition()!=null && o.getCondition().isValid()) {
            sb.append(" Where ").append(sqlManager.getSQL(o.getCondition(), context, declarations));
        }

        if (persistenceStore.isViewSupported() && entity.hasAssociatedView() && o.getEntity().isUseView()) {
            String implicitTableAlias = persistenceStore.getPersistenceName("IT_" + entity.getName(), PersistenceNameType.ALIAS);
            sb.append(" ");
            sb.append(sqlManager.getSQL(new CompiledEntityName(entity.getName()), context, declarations)).append(" ")
                    .append(implicitTableAlias).append(",")
                    .append(sqlManager.getSQL(new CompiledEntityName(entity.getName(),true), context, declarations))
                    .append(" ").append(sqlManager.getSQL(new CompiledVar(tableAlias), context, declarations));
        }
//            if (extraFrom != null)
        return sb.toString();
    }

    protected void appendJoins(CompiledUpdate o, StringBuilder sb, EntityExecutionContext context, SQLManager sqlManager, ExpressionDeclarationList declarations) {
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

}
