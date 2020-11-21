package net.thevpc.upa.impl.persistence.shared.sql;

import net.thevpc.upa.Entity;
import net.thevpc.upa.Field;
import net.thevpc.upa.config.PersistenceNameType;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.impl.persistence.SQLManager;
import net.thevpc.upa.impl.upql.ExpressionDeclarationList;
import net.thevpc.upa.impl.upql.ext.expr.CompiledVar;
import net.thevpc.upa.persistence.EntityExecutionContext;
import net.thevpc.upa.persistence.PersistenceStore;

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
//            if (UPQLUtils.THIS.equals(o.getName())) {
//                throw new UPAIllegalArgumentException("Unexpected this alias");
//                //this must be resolved to the ancestor alias
//                ExpressionDeclarationList declarationList = o.getDeclarationList();
//                name = persistenceManager.getPersistenceName(declarationList.getValue(null).getName(), PersistenceNameStrategyNames.ALIAS);
//            } else {
                if(o.getName().equals("$("+entity.getName()+")")){
                    //it is intended to be the very table name
                    String name = persistenceStore.getValidIdentifier(persistenceStore.getPersistenceName(entity));
                    sb.append(persistenceStore.getValidIdentifier(name));
                }else {
                    String name = persistenceStore.getPersistenceName(o.getName(), PersistenceNameType.ALIAS);
                    sb.append(persistenceStore.getValidIdentifier(name));
                }
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
