package net.vpc.upa.impl.persistence.shared.sql;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.persistence.SQLManager;
import net.vpc.upa.impl.upql.ExpressionDeclarationList;
import net.vpc.upa.impl.upql.ext.expr.CompiledEntityStatement;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.upql.ext.expr.CompiledInCollection;
import net.vpc.upa.impl.upql.ext.expr.CompiledLiteral;
import net.vpc.upa.persistence.EntityExecutionContext;
import net.vpc.upa.persistence.PersistenceStore;

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
