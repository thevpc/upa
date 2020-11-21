package net.thevpc.upa.impl.persistence.shared.sql;

import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.impl.persistence.SQLManager;
import net.thevpc.upa.impl.upql.ExpressionDeclarationList;
import net.thevpc.upa.impl.upql.ext.expr.CompiledConcat;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.thevpc.upa.impl.upql.ext.expr.CompiledLiteral;
import net.thevpc.upa.impl.upql.ext.expr.CompiledUplet;
import net.thevpc.upa.persistence.EntityExecutionContext;

/**
 * Created with IntelliJ IDEA.
 * User: vpc
 * Date: 8/15/12
 * Time: 11:46 PM
 * To change this template use File | Settings | File Templates.
 */
public class UpletSQLProvider extends AbstractSQLProvider {
    public UpletSQLProvider() {
        super(CompiledUplet.class);
    }

    @Override
    public String getSQL(Object oo, EntityExecutionContext qlContext, SQLManager sqlManager, ExpressionDeclarationList declarations) throws UPAException{
        CompiledUplet o=(CompiledUplet) oo;
//        PersistenceUnitManager queryLanguageManager = qlContext.getPersistenceUnitManager();
        CompiledExpressionExt sql;
        CompiledExpressionExt[] expressions = o.getExpressions();
        if(expressions.length>1){
            CompiledConcat concat=new CompiledConcat();
            for(int i=0;i<expressions.length;i++){
                if(i>0){
                    concat.add(new CompiledLiteral('~'));
                }
                concat.add(expressions[i]);
            }
            sql=concat;
        }else{
            sql=expressions[0];
        }
        return sqlManager.getSQL(sql, qlContext, declarations);
    }
}
