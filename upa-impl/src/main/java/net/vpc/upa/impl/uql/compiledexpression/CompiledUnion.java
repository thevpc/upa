package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.types.TypesFactory;

import java.util.ArrayList;
import java.util.List;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.types.DataTypeTransform;

/**
 * Created with IntelliJ IDEA.
 * User: vpc
 * Date: 8/19/12
 * Time: 12:34 AM
 * To change this template use File | Settings | File Templates.
 */
public class CompiledUnion extends DefaultCompiledEntityStatement implements CompiledQueryStatement {
    private List<CompiledQueryStatement> queryStatements=new ArrayList<CompiledQueryStatement>();
    public void add(CompiledQueryStatement s){
        queryStatements.add(s);
        bindChildren(s);
    }

    public List<CompiledQueryStatement> getQueryStatements() {
        return new ArrayList<CompiledQueryStatement>(queryStatements);
    }

//    @Override
//    public String toSQL(boolean integrated, PersistenceUnitFilter database) {
//        throw new IllegalArgumentException("Unsupported");
//    }


    @Override
    public String getEntityName() {
        return null;
    }

    @Override
    public String getEntityAlias() {
        return null;
    }

    @Override
    public DataTypeTransform getTypeTransform() {
        if(queryStatements.isEmpty()){
            return new IdentityDataTypeTransform(TypesFactory.VOID);
        }
        return queryStatements.get(0).getTypeTransform();
    }

    @Override
    public int countFields() {
        return queryStatements.get(0).countFields();
    }

    public List<CompiledQueryField> getFields() {
        return queryStatements.get(0).getFields();
    }

    
    @Override
    public CompiledQueryField getField(int i) {
        return queryStatements.get(0).getField(i);
    }

    @Override
    public DefaultCompiledExpression[] getSubExpressions() {
        return queryStatements.toArray(new DefaultCompiledExpression[queryStatements.size()]);
    }

    @Override
    public boolean isValid() {
        if(queryStatements.isEmpty()){
            return false;
        }
        for (CompiledQueryStatement queryStatement : queryStatements) {
            if(!queryStatement.isValid()){
               return false;
            }
        }
        return true;
    }



    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        CompiledUnion union = (CompiledUnion) o;

        if (queryStatements != null ? !queryStatements.equals(union.queryStatements) : union.queryStatements != null)
            return false;

        return true;
    }

    @Override
    public int hashCode() {
        return queryStatements != null ? queryStatements.hashCode() : 0;
    }

    @Override
    public DefaultCompiledExpression copy() {
        CompiledUnion o=new CompiledUnion();
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        for (CompiledQueryStatement queryStatement : queryStatements) {
            o.add((CompiledQueryStatement) queryStatement.copy());
        }
        return o;
    }

    @Override
    public void setSubExpression(int index, DefaultCompiledExpression expression) {
        unbindChildren(this.queryStatements.get(index));
        queryStatements.set(index, (CompiledQueryStatement) expression);
        bindChildren(expression);
    }

    @Override
    protected List<CompiledNamedExpression> findEntityDefinitions() {
        return PlatformUtils.emptyList();
    }
    
    
}
