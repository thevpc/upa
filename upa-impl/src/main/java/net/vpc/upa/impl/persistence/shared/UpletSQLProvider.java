package net.vpc.upa.impl.persistence.shared;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.persistence.SQLManager;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.compiledexpression.CompiledConcat;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;
import net.vpc.upa.impl.uql.compiledexpression.CompiledLiteral;
import net.vpc.upa.impl.uql.compiledexpression.CompiledUplet;
import net.vpc.upa.persistence.EntityExecutionContext;
import net.vpc.upa.persistence.PersistenceStore;

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
        DefaultCompiledExpression sql;
        DefaultCompiledExpression[] expressions = o.getExpressions();
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
