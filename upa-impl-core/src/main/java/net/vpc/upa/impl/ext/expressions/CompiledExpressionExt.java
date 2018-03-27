package net.vpc.upa.impl.ext.expressions;

import net.vpc.upa.Properties;
import net.vpc.upa.expressions.CompiledExpression;
import net.vpc.upa.impl.uql.*;
import net.vpc.upa.types.DataTypeTransform;

import java.util.List;
import java.util.Map;

public interface CompiledExpressionExt extends Cloneable, java.io.Serializable, net.vpc.upa.expressions.CompiledExpression {

    //    public static CompiledExpression[] EMPTY_ERRAY = new CompiledExpression[0];
    boolean isValid();

    CompiledExpressionExt[] getSubExpressions();

    CompiledExpressionExt getParentExpression();

    void setParentExpression(CompiledExpressionExt parent);

    void setSubExpression(int index, CompiledExpressionExt expression);

    //    public abstract String toSQL(boolean integrated, PersistenceUnitFilter database);
//    public String toSQL(PersistenceUnitFilter database) ;
    CompiledExpressionExt copy();

    String getDescription();

    //    public String getDescriptionOrSQL(Resources resources) ;
    CompiledExpressionExt setDescription(String newDesc);

    DataTypeTransform getTypeTransform();

    void setTypeTransform(DataTypeTransform type);

    DataTypeTransform getEffectiveDataType();

    CompiledExpressionExt setClientProperty(String name, Object value);

    Properties getClientParameters();

    Object getClientProperty(String name);

    CompiledExpressionExt replaceExpressions(CompiledExpressionFilter filter, CompiledExpressionReplacer replacer);

    ReplaceResult replaceExpressions(CompiledExpressionFilteredReplacer replacer, Map<String, Object> updateContext);

    <T extends CompiledExpression> List<T> findExpressionsList(CompiledExpressionFilter filter);

    <T extends CompiledExpression> T findFirstExpression(CompiledExpressionFilter filter);

//    public void setDeclarationList(ExpressionDeclarationList declarationList);

    /**
     * @param visitor
     * @return true if should continue visiting false otherwise
     */
    boolean visit(CompiledExpressionVisitor visitor);

    List<ExpressionDeclaration> getExportedDeclarations();

    void exportDeclaration(String name, DecObjectType type, Object referrerName, Object referrerParentId);

    List<ExpressionDeclaration> getDeclarations(String alias);

    ExpressionDeclaration getDeclaration(String name);

    void unsetParent();

    void validate();

    void removeSubExpression(int pos);
}
