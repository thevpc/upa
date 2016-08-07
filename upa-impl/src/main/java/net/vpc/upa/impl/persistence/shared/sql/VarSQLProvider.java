package net.vpc.upa.impl.persistence.shared.sql;

import net.vpc.upa.Entity;
import net.vpc.upa.Field;
import net.vpc.upa.impl.persistence.shared.sql.AbstractSQLProvider;
import net.vpc.upa.persistence.PersistenceNameType;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.persistence.SQLManager;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.compiledexpression.CompiledVar;
import net.vpc.upa.persistence.EntityExecutionContext;
import net.vpc.upa.persistence.PersistenceStore;

/**
 * Created with IntelliJ IDEA. User: vpc Date: 8/15/12 Time: 11:46 PM To change
 * this template use File | Settings | File Templates.
 */
public class VarSQLProvider extends AbstractSQLProvider {


    public VarSQLProvider() {
        super(CompiledVar.class);
    }


    @Override
    public String getSQL(Object oo, EntityExecutionContext qlContext, SQLManager sqlManager, ExpressionDeclarationList declarations) throws UPAException {
        CompiledVar o = (CompiledVar) oo;
        PersistenceStore persistenceStore = qlContext.getPersistenceStore();
        
        Object referrer = o.getReferrer();
        StringBuilder sb = new StringBuilder();
        if (referrer instanceof Field) {
            Field field = (Field) referrer;
            String name = persistenceStore.getPersistenceName(field);
            sb.append(persistenceStore.getValidIdentifier(name));
        } else if (referrer instanceof Entity) {
            Entity entity = (Entity) referrer;
//            if ("this".equals(o.getName())) {
//                throw new IllegalArgumentException("Unexpected this alias");
//                //this must be resolved to the ancestor alias
//                ExpressionDeclarationList declarationList = o.getDeclarationList();
//                name = persistenceManager.getPersistenceName(declarationList.getValue(null).getName(), PersistenceNameStrategyNames.ALIAS);
//            } else {
                String name = persistenceStore.getPersistenceName(o.getName(), PersistenceNameType.ALIAS);
                sb.append(persistenceStore.getValidIdentifier(name));
//            }
        } else {
            String name = persistenceStore.getPersistenceName(o.getName(), PersistenceNameType.ALIAS);
            sb.append(persistenceStore.getValidIdentifier(name));
        }
        if (o.getChild() != null) {
            String cc = getSQL(o.getChild(), qlContext, sqlManager, declarations);
            sb.append(".").append(cc);
        }
        return sb.toString();
    }
}
