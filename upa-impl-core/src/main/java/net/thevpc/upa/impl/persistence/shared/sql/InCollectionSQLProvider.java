package net.thevpc.upa.impl.persistence.shared.sql;

import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.impl.persistence.SQLManager;
import net.thevpc.upa.impl.upql.ExpressionDeclarationList;
import net.thevpc.upa.impl.upql.ext.expr.CompiledEntityStatement;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.thevpc.upa.impl.upql.ext.expr.CompiledInCollection;
import net.thevpc.upa.impl.upql.ext.expr.CompiledLiteral;
import net.thevpc.upa.persistence.EntityExecutionContext;
import net.thevpc.upa.persistence.PersistenceStore;

/**
 * Created with IntelliJ IDEA.
 * User: vpc
 * Date: 8/15/12
 * Time: 11:46 PM
 * To change this template use File | Settings | File Templates.
 */
public class InCollectionSQLProvider extends AbstractSQLProvider {
    public InCollectionSQLProvider() {
        super(CompiledInCollection.class);
    }

    @Override
    public String getSQL(Object oo, EntityExecutionContext qlContext, SQLManager sqlManager, ExpressionDeclarationList declarations) throws UPAException{
        CompiledInCollection o=(CompiledInCollection) oo;
        PersistenceStore qlm = qlContext.getPersistenceStore();
        StringBuilder sb = new StringBuilder();
        int mySize=o.getRightSize();
        if ( mySize== 0) {
            sb.append("1 <> 1");
        }else {
            if (mySize == 1 && !(o.getRight(0) instanceof CompiledEntityStatement)) {
                sb.append(sqlManager.getSQL(o.getLeft(),qlContext, declarations));
                CompiledExpressionExt e = o.getRight(0);
                if (e == null || (e instanceof CompiledLiteral && ((CompiledLiteral)e).getValue()==null)) {
                    sb.append(" Is Null");
                } else {
                    sb.append(" = ");
                    sb.append(sqlManager.getSQL(e,qlContext, declarations));
                }
            } else {
                sb.append(sqlManager.getSQL(o.getLeft(),qlContext, declarations));
                sb.append(" In (");
                for (int i = 0; i < mySize; i++) {
                    if (i > 0) {
                        sb.append(",");
                    }
                    CompiledExpressionExt e = o.getRight(i);
                    if(e==null){
                        sb.append("Null");
                    }else{
                        sb.append(sqlManager.getSQL(e,qlContext, declarations));
                    }
                }

                sb.append(")");
            }
        }
        return '(' + sb.toString() + ')';
    }
}
