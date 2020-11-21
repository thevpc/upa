package net.thevpc.upa.impl.ext.expressions;

import net.thevpc.upa.Properties;
import net.thevpc.upa.impl.upql.*;
import net.thevpc.upa.impl.upql.DecObjectType;
import net.thevpc.upa.impl.upql.ExpressionDeclaration;
import net.thevpc.upa.impl.upql.CompiledExpressionFilteredReplacer;
import net.thevpc.upa.impl.upql.ReplaceResult;
import net.thevpc.upa.impl.upql.CompiledExpressionVisitor;
import net.thevpc.upa.impl.upql.CompiledExpressionFilter;
import net.thevpc.upa.impl.upql.CompiledExpressionReplacer;
import net.thevpc.upa.expressions.CompiledExpression;
import net.thevpc.upa.types.DataTypeTransform;

import java.util.List;

public interface CompiledExpressionExt extends Cloneable, java.io.Serializable, CompiledExpression {

    boolean isValid();

    CompiledExpressionExt[] getSubExpressions();

    CompiledExpressionExt getParentExpression();

    void setParentExpression(CompiledExpressionExt parent);

    void setSubExpression(int index, CompiledExpressionExt expression);

    CompiledExpressionExt copy();

    String getDescription();

    CompiledExpressionExt setDescription(String newDesc);

    DataTypeTransform getTypeTransform();

    void setTypeTransform(DataTypeTransform type);

    DataTypeTransform getEffectiveDataType();

    CompiledExpressionExt setClientProperty(String name, Object value);

    Properties getClientParameters();

    Object getClientProperty(String name);

    CompiledExpressionExt replaceExpressions(CompiledExpressionFilter filter, CompiledExpressionReplacer replacer);

    ReplaceResult replaceExpressions(CompiledExpressionFilteredReplacer replacer, UpdateExpressionContext updateContext);

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
