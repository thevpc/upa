package net.vpc.upa.impl.persistence.specific.mysql;

import net.vpc.upa.*;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.persistence.SQLManager;
import net.vpc.upa.impl.persistence.shared.sql.UpdateSQLProvider;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.uql.compiledexpression.CompiledUpdate;
import net.vpc.upa.impl.uql.compiledexpression.CompiledVar;
import net.vpc.upa.persistence.EntityExecutionContext;
import net.vpc.upa.persistence.PersistenceStore;

import java.util.Arrays;
import java.util.List;

import net.vpc.upa.impl.uql.compiledexpression.CompiledEntityName;
import net.vpc.upa.persistence.PersistenceNameType;

/**
 * Created with IntelliJ IDEA. User: vpc Date: 8/17/12 Time: 12:52 AM To change
 * this template use File | Settings | File Templates.
 */
@PortabilityHint(target = "C#",name = "suppress")
public class MySQLUpdateSQLProvider extends UpdateSQLProvider {

    public MySQLUpdateSQLProvider() {
        super();
    }

    @Override
    public String getSQL(Object oo, EntityExecutionContext context, SQLManager sqlManager, ExpressionDeclarationList declarations) throws UPAException {
        CompiledUpdate o = (CompiledUpdate) oo;
        PersistenceStore persistenceStore = context.getPersistenceStore();
        PersistenceUnit pu = context.getPersistenceUnit();
        Entity entity = pu.getEntity(o.getEntity().getName());
//        String persistenceName = persistenceStore.getPersistenceName(entity);
        String tableNamePersisted = sqlManager.getSQL(new CompiledEntityName(entity.getName()), context, declarations);
        StringBuilder sb = new StringBuilder("Update " + tableNamePersisted);
        String tableAlias = o.getEntityAlias();
        String tableAliasPersisted = null;
        if (tableAlias != null) {
            sb.append(" ");
            sb.append(tableAliasPersisted=sqlManager.getSQL(new CompiledVar(tableAlias), context, declarations));
        }
        appendJoins(o, sb, context, sqlManager, declarations);
        boolean someJoins=o.countJoins()>0;
        String prefixAlias=null;
        if(someJoins){
            if(tableAliasPersisted!=null) {
                prefixAlias = tableAliasPersisted;
            }else{
                prefixAlias = tableNamePersisted;
            }
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
            List<PrimitiveField> primFields = entityManager.toPrimitiveFields(Arrays.asList((EntityPart) f));

            for (PrimitiveField primField : primFields) {
                if (isFirst) {
                    isFirst = false;
                } else {
                    sb.append(", ");
                }
                if (ev != null) {
                    sb.append(sqlManager.getSQL(new CompiledVar(ev.getName()), context, declarations)).append(".");
                }else if(prefixAlias!=null){
                    sb.append(prefixAlias).append(".");
                }
                sb.append(sqlManager.getSQL(new CompiledVar(primField), context, declarations));
                sb.append("=").append("(").append(sqlManager.getSQL(fieldValue, context, declarations)).append(")");
            }
        }
        if (o.getCondition()!=null && o.getCondition().isValid()) {
            sb.append(" Where ").append(sqlManager.getSQL(o.getCondition(), context, declarations));
        }

        if (persistenceStore.isViewSupported() && entity.hasAssociatedView() && o.getEntity().isUseView()) {
            String implicitTableAlias = persistenceStore.getPersistenceName("IT_" + entity.getName(), PersistenceNameType.ALIAS);
            sb.append(" ");
            sb.append(tableNamePersisted).append(" ")
                    .append(implicitTableAlias).append(",")
                    .append(sqlManager.getSQL(new CompiledEntityName(entity.getName(),true), context, declarations))
                    .append(" ").append(sqlManager.getSQL(new CompiledVar(tableAlias), context, declarations));
        }
//            if (extraFrom != null)
        return sb.toString();
    }
}
