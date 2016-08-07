package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.impl.DefaultProperties;
import net.vpc.upa.Properties;
import net.vpc.upa.impl.uql.CompiledExpressionFilter;
import net.vpc.upa.impl.uql.CompiledExpressionReplacer;
import net.vpc.upa.impl.uql.CompiledExpressionVisitor;

import java.util.ArrayList;
import java.util.List;
import net.vpc.upa.expressions.CompiledExpression;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.impl.uql.DecObjectType;
import net.vpc.upa.impl.uql.ExpressionDeclaration;
import net.vpc.upa.types.DataTypeTransform;

public abstract class DefaultCompiledExpressionImpl implements DefaultCompiledExpression {

    private static final long serialVersionUID = 1L;
    public static DefaultCompiledExpression[] EMPTY_ERRAY = new DefaultCompiledExpressionImpl[0];
    private String description;
    private Properties clientParameters;
    private DataTypeTransform type;
    private DefaultCompiledExpression parent;
    private List<ExpressionDeclaration> exportedDeclarations;

    protected DefaultCompiledExpressionImpl() {
    }

    public DefaultCompiledExpression getParentExpression() {
        return parent;
    }

    public void setParentExpression(DefaultCompiledExpression parent) {
        if (parent != null) {
            DefaultCompiledExpression x = parent;
            while (x != null) {
                if (x == this) {
                    throw new IllegalArgumentException("Recursive Tree");
                }
                x = x.getParentExpression();
            }
        }
        if (this.parent != null && parent != null) {
            throw new IllegalArgumentException("Unexpected");
        }
        this.parent = parent;
    }

    public boolean isValid() {
        return true;
    }

    public abstract DefaultCompiledExpression[] getSubExpressions();

    @Override
    public abstract void setSubExpression(int index, DefaultCompiledExpression expression);
    //    public abstract String toSQL(boolean integrated, PersistenceUnitFilter database);

//    public final String toSQL(PersistenceUnitFilter database) {
//        return toSQL(false, database);
//    }
//    public String toString() {
//        return toSQL(DatabaseManager.getInstance().getPersistenceUnit());
//    }
    public String getDescription() {
        return description;
    }

//    public String getDescriptionOrSQL(Resources resources) {
//        String d = getDescription();
//        return d != null ? d : toString();
//    }
    public final DefaultCompiledExpression setDescription(String newDesc) {
        description = newDesc;
        return this;
    }

    public DataTypeTransform getTypeTransform() {
        return this.type;
    }

    public void setTypeTransform(DataTypeTransform type) {
        this.type = type;
    }

    public Properties getClientParameters() {
        if (clientParameters == null) {
            clientParameters = new DefaultProperties();
        }
        return clientParameters;
    }

    public DefaultCompiledExpression setClientProperty(String name, Object value) {
        if (value != null) {
            getClientParameters().setObject(name, value);
        } else {
            getClientParameters().remove(name);
        }
        return this;
    }

    public Object getClientProperty(String name) {
        return clientParameters == null ? null : clientParameters.getObject(name);
    }

    public boolean visit(CompiledExpressionVisitor visitor) {
        if (!visitor.visit(this)) {
            return false;
        }
        DefaultCompiledExpression[] subExpressions = getSubExpressions();
        if (subExpressions != null) {
            for (DefaultCompiledExpression subExpression : subExpressions) {
                if (subExpression != null) {
                    if (!subExpression.visit(visitor)) {
                        return false;
                    }
                }
            }
        }
        return true;
    }

    public <T extends CompiledExpression> List<T> findExpressionsList(CompiledExpressionFilter filter) {
        List<T> list = new ArrayList<T>();
        findExpressionsList(filter, list);
        return list;
    }

    private <T extends CompiledExpression> void findExpressionsList(CompiledExpressionFilter filter, List<T> list) {
        if (filter.accept(this)) {
            //this double casting is needed in C#
            list.add((T) (Object) this);
        }
        DefaultCompiledExpression[] subExpressions = getSubExpressions();
        if (subExpressions != null) {
            for (DefaultCompiledExpression subExpression : subExpressions) {
                if (subExpression != null) {
                    ((DefaultCompiledExpressionImpl) subExpression).findExpressionsList(filter, list);
                }
            }
        }
    }

    @Override
    public <T extends CompiledExpression> T findFirstExpression(CompiledExpressionFilter filter) {
        if (filter.accept(this)) {
            //this double casting is needed in C#
            return ((T) (Object) this);
        }
        DefaultCompiledExpression[] subExpressions = getSubExpressions();
        if (subExpressions != null) {
            for (DefaultCompiledExpression subExpression : subExpressions) {
                if (subExpression != null) {
                    CompiledExpression e = ((DefaultCompiledExpressionImpl) subExpression).findFirstExpression(filter);
                    if(e!=null){
                        return (T)e;
                    }
                }
            }
        }    
        return null;
    }
    

    public DefaultCompiledExpression replaceExpressions(CompiledExpressionFilter filter, CompiledExpressionReplacer replacer) {
        DefaultCompiledExpression t = (DefaultCompiledExpression) ((filter == null || filter.accept(this)) ? replacer.update(this) : null);
        boolean updated = false;
        if (t != null) {
            updated = true;
        } else {
            t = this;
        }
        if (!updated) {
            List<ReplacementPosition> replacementPositions = new ArrayList<ReplacementPosition>();
            int i = 0;
            DefaultCompiledExpression[] subExpressions = t.getSubExpressions();
            if (subExpressions != null) {
                for (DefaultCompiledExpression expression : subExpressions) {
                    replacementPositions.add(new ReplacementPosition(t, expression, i));
                    i++;
                }
            }
            for (ReplacementPosition r : replacementPositions) {
                if (r.getChild() == null) {
                    //System.out.println("Child is null?");
                } else {
                    DefaultCompiledExpression c = r.getChild().replaceExpressions(filter, replacer);
                    if (c != null) {
                        int pos = r.getPos();
//                if (!updated) {
//                    t = t.copy();
//                }
                        if (subExpressions[pos] != c) {
                            subExpressions[pos].setParentExpression(null);
                            t.setSubExpression(pos, c);
                        }
                        updated = true;
                    }
                }
            }
        }
        if (updated) {
            return t;
        }
        return null;
    }

    protected final void prepareChildren(DefaultCompiledExpression... children) {
        if (children != null) {
            for (DefaultCompiledExpression e : children) {
                if (e != null) {
                    DefaultCompiledExpression oldParent = e.getParentExpression();
                    if (oldParent != null) {
                        throw new IllegalArgumentException("Expression already bound");
                    }
                    e.setParentExpression(this);
                }
            }
        }
    }

    protected final void prepareChildren(List<DefaultCompiledExpression> children) {
        if (children != null) {
            for (DefaultCompiledExpression e : children) {
                e.setParentExpression(this);
            }
        }
    }
//    public void setDeclarationList(ExpressionDeclarationList declarationList) {
//        this.declarationList = declarationList;
//    }

    public List<ExpressionDeclaration> getExportedDeclarations() {
        List<ExpressionDeclaration> emptyList = PlatformUtils.emptyList();
        return exportedDeclarations == null ? emptyList : exportedDeclarations;
    }

    public void exportDeclaration(String name, DecObjectType type, Object referrerName, Object referrerParentId) {
        if (exportedDeclarations == null) {
            exportedDeclarations = new ArrayList<ExpressionDeclaration>(3);
        }
        exportedDeclarations.add(new ExpressionDeclaration(name, type, referrerName, referrerParentId));
    }

    public List<ExpressionDeclaration> getDeclarations(String alias) {
        if (alias == null) {
            //check all
            ArrayList<ExpressionDeclaration> objects = new ArrayList<ExpressionDeclaration>();
            if (exportedDeclarations != null) {
                for (int i = exportedDeclarations.size() - 1; i >= 0; i--) {
                    ExpressionDeclaration d = exportedDeclarations.get(i);
                    objects.add(d);
                }
            }
            if (getParentExpression() != null) {
                objects.addAll(getParentExpression().getDeclarations(alias));
            }
            return objects;
        } else {
            ArrayList<ExpressionDeclaration> objects = new ArrayList<ExpressionDeclaration>();
            if (exportedDeclarations != null) {
                for (int i = exportedDeclarations.size() - 1; i >= 0; i--) {
                    ExpressionDeclaration d = exportedDeclarations.get(i);
                    if (alias.equals(d.getValidName())) {
                        objects.add(d);
                    }
                }
            }
            if (getParentExpression() != null) {
                objects.addAll(getParentExpression().getDeclarations(alias));
            }
            return objects;
        }
    }

    public ExpressionDeclaration getDeclaration(String name) {
        List<ExpressionDeclaration> values = getDeclarations(name);
        if (values.isEmpty()) {
            return null;
        }
        return values.get(0);
    }

    public void unsetParent() {
        setParentExpression(null);
    }

    public void validate() {
        DefaultCompiledExpression[] subExpressions = getSubExpressions();
        if (subExpressions != null) {
            for (DefaultCompiledExpression e : subExpressions) {
                if (e.getParentExpression() != this) {
                    throw new IllegalArgumentException("Illegal Hierarchy");
                }
                e.validate();
            }
        }
    }

    public DataTypeTransform getEffectiveDataType() {
        return getTypeTransform();
    }
}
