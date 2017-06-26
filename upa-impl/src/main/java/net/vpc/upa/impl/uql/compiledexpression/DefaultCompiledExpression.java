package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.Properties;
import net.vpc.upa.expressions.CompiledExpression;
import net.vpc.upa.impl.uql.*;
import net.vpc.upa.types.DataTypeTransform;

import java.util.List;

public interface DefaultCompiledExpression extends Cloneable, java.io.Serializable, net.vpc.upa.expressions.CompiledExpression {

    //    public static CompiledExpression[] EMPTY_ERRAY = new CompiledExpression[0];
    public boolean isValid();

    public DefaultCompiledExpression[] getSubExpressions();

    public DefaultCompiledExpression getParentExpression();

    public void setParentExpression(DefaultCompiledExpression parent);

    public void setSubExpression(int index, DefaultCompiledExpression expression);

    //    public abstract String toSQL(boolean integrated, PersistenceUnitFilter database);
//    public String toSQL(PersistenceUnitFilter database) ;
    public DefaultCompiledExpression copy();

    public String getDescription();

    //    public String getDescriptionOrSQL(Resources resources) ;
    public DefaultCompiledExpression setDescription(String newDesc);

    public abstract DataTypeTransform getTypeTransform();

    public abstract void setTypeTransform(DataTypeTransform type);

    public abstract DataTypeTransform getEffectiveDataType();

    public DefaultCompiledExpression setClientProperty(String name, Object value);

    public Properties getClientParameters();

    public Object getClientProperty(String name);

    public DefaultCompiledExpression replaceExpressions(CompiledExpressionFilter filter, CompiledExpressionReplacer replacer);
    public DefaultCompiledExpression replaceExpressions(CompiledExpressionFilteredReplacer replacer);

    public <T extends CompiledExpression> List<T> findExpressionsList(CompiledExpressionFilter filter);

    public <T extends CompiledExpression> T findFirstExpression(CompiledExpressionFilter filter);

//    public void setDeclarationList(ExpressionDeclarationList declarationList);

    /**
     * @param visitor
     * @return true if should continue visiting false otherwise
     */
    public boolean visit(CompiledExpressionVisitor visitor);

    public List<ExpressionDeclaration> getExportedDeclarations();

    public void exportDeclaration(String name, DecObjectType type, Object referrerName, Object referrerParentId);

    public List<ExpressionDeclaration> getDeclarations(String alias);

    public ExpressionDeclaration getDeclaration(String name);

    public void unsetParent();

    public void validate();
}
