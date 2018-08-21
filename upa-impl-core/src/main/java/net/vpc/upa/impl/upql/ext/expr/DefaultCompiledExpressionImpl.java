package net.vpc.upa.impl.upql.ext.expr;

import net.vpc.upa.Properties;
import net.vpc.upa.exceptions.IllegalUPAArgumentException;
import net.vpc.upa.expressions.CompiledExpression;
import net.vpc.upa.impl.upql.*;
import net.vpc.upa.impl.DefaultProperties;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.types.DataTypeTransform;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;

public abstract class DefaultCompiledExpressionImpl implements CompiledExpressionExt {

    private static final long serialVersionUID = 1L;
    public static CompiledExpressionExt[] EMPTY_ERRAY = new DefaultCompiledExpressionImpl[0];
    private String description;
    private Properties clientParameters;
    private DataTypeTransform dataTypeTransform;
    private CompiledExpressionExt parent;
    private List<ExpressionDeclaration> exportedDeclarations;

    protected DefaultCompiledExpressionImpl() {
    }

    public CompiledExpressionExt getParentExpression() {
        return parent;
    }

    public void setParentExpression(CompiledExpressionExt parent) {
        if (parent != null) {
            CompiledExpressionExt x = parent;
            while (x != null) {
                if (x == this) {
                    throw new IllegalUPAArgumentException("Recursive Tree");
                }
                x = x.getParentExpression();
            }
        }
        if (this.parent != null && parent != null && this.parent!=parent) {
            throw new IllegalUPAArgumentException("Unexpected changing parent of "+this+" from "+this.parent+" to "+parent);
        }
        this.parent = parent;
    }

    public boolean isValid() {
        return true;
    }

    public abstract CompiledExpressionExt[] getSubExpressions();

    @Override
    public abstract void setSubExpression(int index, CompiledExpressionExt expression);
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
    public final CompiledExpressionExt setDescription(String newDesc) {
        description = newDesc;
        return this;
    }

    public DataTypeTransform getTypeTransform() {
        return this.dataTypeTransform;
    }

    public void setTypeTransform(DataTypeTransform type) {
        this.dataTypeTransform = type;
    }

    public Properties getClientParameters() {
        if (clientParameters == null) {
            clientParameters = new DefaultProperties();
        }
        return clientParameters;
    }

    public CompiledExpressionExt setClientProperty(String name, Object value) {
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
        CompiledExpressionExt[] subExpressions = getSubExpressions();
        if (subExpressions != null) {
            for (CompiledExpressionExt subExpression : subExpressions) {
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
        CompiledExpressionExt[] subExpressions = getSubExpressions();
        if (subExpressions != null) {
            for (CompiledExpressionExt subExpression : subExpressions) {
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
        CompiledExpressionExt[] subExpressions = getSubExpressions();
        if (subExpressions != null) {
            for (CompiledExpressionExt subExpression : subExpressions) {
                if (subExpression != null) {
                    CompiledExpression e = ((DefaultCompiledExpressionImpl) subExpression).findFirstExpression(filter);
                    if (e != null) {
                        return (T) e;
                    }
                }
            }
        }
        return null;
    }

    @Override
    public ReplaceResult replaceExpressions(CompiledExpressionFilteredReplacer replacer, Map<String, Object> updateContext) {
        if (replacer == null) {
            return ReplaceResult.NO_UPDATES_STOP;
        }
        if (replacer.isTopDown()) {
            ReplaceResult parentUpdate = replacer.update(this, updateContext);
            //if stop will not check children!
            if (parentUpdate.isStop()) {
                switch (parentUpdate.getReplaceResultType()) {
                    case NEW_INSTANCE: {
                        return ReplaceResult.stopWithNewObj(parentUpdate.getExpression());
                    }
                    case NO_UPDATES: {
                        return ReplaceResult.NO_UPDATES_CONTINUE;
                    }
                    case UPDATE: {
                        return ReplaceResult.UPDATE_AND_CONTINUE_CLEAN;
                    }
                    case REMOVE: {
                        return ReplaceResult.REMOVE_AND_STOP;
                    }
                }
                return parentUpdate;
            }
            CompiledExpressionExt newParent = this;
            switch (parentUpdate.getReplaceResultType()) {
                case NEW_INSTANCE: {
                    newParent = parentUpdate.getExpression();
                    break;
                }
                case REMOVE: {
                    return ReplaceResult.REMOVE_AND_STOP;
                }
            }

            List<ReplacementPosition> replacementPositions = new ArrayList<ReplacementPosition>();
            int i = 0;
            CompiledExpressionExt[] subExpressions = newParent.getSubExpressions();
            if (subExpressions == null) {
                subExpressions = new CompiledExpressionExt[0];
            }
            for (CompiledExpressionExt expression : subExpressions) {
                replacementPositions.add(new ReplacementPosition(this, expression, i));
                i++;
            }
            boolean someChildUpdates = false;
            List<ReplacementPosition> toRemove = new ArrayList<ReplacementPosition>();
            for (ReplacementPosition r : replacementPositions) {
                CompiledExpressionExt child = r.getChild();
                boolean again = true;
                while (again) {
                    again=false;
                    if (child == null) {
                        //System.out.println("Child is null?");
                    } else {
                        ReplaceResult c = child.replaceExpressions(replacer, updateContext);
                        switch (c.getReplaceResultType()) {
                            case NO_UPDATES: {
                                break;
                            }
                            case NEW_INSTANCE:{
                                someChildUpdates = true;
                                subExpressions[r.getPos()].unsetParent();
                                this.setSubExpression(r.getPos(), c.getExpression());
                                if(!c.isStop()) {
                                    child = c.getExpression();
                                    again = true;
                                }else {
                                    switch (parentUpdate.getReplaceResultType()) {
                                        case NEW_INSTANCE: {
                                            return ReplaceResult.stopWithNewObj(parentUpdate.getExpression());
                                        }
                                        default: {
                                            return ReplaceResult.NO_UPDATES_STOP;
                                        }
                                    }
                                }
                                break;
                            }
                            case UPDATE: {
                                someChildUpdates = true;
                                if (c.isStop()) {
                                    switch (parentUpdate.getReplaceResultType()) {
                                        case NEW_INSTANCE: {
                                            return ReplaceResult.stopWithNewObj(parentUpdate.getExpression());
                                        }
                                        default: {
                                            return ReplaceResult.NO_UPDATES_STOP;
                                        }
                                    }
                                }
                                break;
                            }
                            case REMOVE: {
                                toRemove.add(r);
                                break;
                            }
                        }
                    }
                }
            }

            if (toRemove.size() > 0) {
                for (int j = toRemove.size() - 1; j >= 0; j--) {
                    this.removeSubExpression(toRemove.get(j).getPos());
                }
            }
            if (someChildUpdates && parentUpdate.getReplaceResultType() == ReplaceResultType.NO_UPDATES) {
                return ReplaceResult.UPDATE_AND_CONTINUE_CLEAN;
            }
            return parentUpdate;
        } else {
            List<ReplacementPosition> replacementPositions = new ArrayList<ReplacementPosition>();
            int i = 0;
            CompiledExpressionExt[] subExpressions = getSubExpressions();
            if (subExpressions == null) {
                subExpressions = new CompiledExpressionExt[0];
            }
            for (CompiledExpressionExt expression : subExpressions) {
                replacementPositions.add(new ReplacementPosition(this, expression, i));
                i++;
            }
            boolean someChildUpdates = false;
            for (ReplacementPosition r : replacementPositions) {
                CompiledExpressionExt child = r.getChild();
                if (child == null) {
                    //System.out.println("Child is null?");
                } else {
                    ReplaceResult c = child.replaceExpressions(replacer, updateContext);
                    switch (c.getReplaceResultType()) {
                        case UPDATE: {
                            someChildUpdates = true;
                            if (c.isStop()) {
                                return ReplaceResult.UPDATE_AND_STOP;
                            }
                            break;
                        }
                        case NEW_INSTANCE: {
                            someChildUpdates = true;
                            int pos = r.getPos();
                            if (subExpressions[pos] != c.getExpression()) {
                                subExpressions[pos].unsetParent();
                                this.setSubExpression(pos, (CompiledExpressionExt) c.getExpression());
                            }
                            if (c.isStop()) {
                                return ReplaceResult.UPDATE_AND_STOP;
                            }
                            break;
                        }
                        case NO_UPDATES: {
                            if (c.isStop()) {
                                return ReplaceResult.NO_UPDATES_STOP;
                            }
                        }
                    }
                }
            }
            ReplaceResult update = replacer.update(this, updateContext);
            switch (update.getReplaceResultType()) {
                case NO_UPDATES: {
                    if (someChildUpdates) {
                        return update.isStop() ? ReplaceResult.UPDATE_AND_STOP : ReplaceResult.UPDATE_AND_CONTINUE_CLEAN;
                    }
                }
                default: {
                    return update;
                }
            }
        }
    }

    public CompiledExpressionExt replaceExpressions(CompiledExpressionFilter filter, CompiledExpressionReplacer replacer) {
        CompiledExpressionExt t = (CompiledExpressionExt) ((filter == null || filter.accept(this)) ? replacer.update(this) : null);
        boolean updated = false;
        if (t != null) {
            updated = true;
        } else {
            t = this;
        }
        if (!updated) {
            List<ReplacementPosition> replacementPositions = new ArrayList<ReplacementPosition>();
            int i = 0;
            CompiledExpressionExt[] subExpressions = t.getSubExpressions();
            if (subExpressions != null) {
                for (CompiledExpressionExt expression : subExpressions) {
                    replacementPositions.add(new ReplacementPosition(t, expression, i));
                    i++;
                }
            }
            for (ReplacementPosition r : replacementPositions) {
                if (r.getChild() == null) {
                    //System.out.println("Child is null?");
                } else {
                    CompiledExpressionExt c = r.getChild().replaceExpressions(filter, replacer);
                    if (c != null) {
                        int pos = r.getPos();
//                if (!updated) {
//                    t = t.copy();
//                }
                        if (subExpressions[pos] != c) {
                            subExpressions[pos].unsetParent();
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

    protected final void bindChildren(CompiledExpressionExt... children) {
        if (children != null) {
            for (CompiledExpressionExt e : children) {
                if (e != null) {
                    CompiledExpressionExt oldParent = e.getParentExpression();
                    if (oldParent != null && oldParent!=this) {
                        throw new IllegalUPAArgumentException("Expression already bound : "+e+" bound to "+oldParent+" <> "+this);
                    }
                    e.setParentExpression(this);
                }
            }
        }
    }

    protected final void unbindChildren(CompiledExpressionExt... children) {
        if (children != null) {
            for (CompiledExpressionExt e : children) {
                if (e != null) {
                    CompiledExpressionExt oldParent = e.getParentExpression();
                    if (oldParent != null && oldParent==this) {
                        e.unsetParent();
                    }
                }
            }
        }
    }

    protected final void bindChildren(List<CompiledExpressionExt> children) {
        if (children != null) {
            for (CompiledExpressionExt e : children) {
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
        CompiledExpressionExt[] subExpressions = getSubExpressions();
        if (subExpressions != null) {
            for (CompiledExpressionExt e : subExpressions) {
                if (e.getParentExpression() != this) {
                    throw new IllegalUPAArgumentException("Illegal Hierarchy");
                }
                e.validate();
            }
        }
    }

    public DataTypeTransform getEffectiveDataType() {
        return getTypeTransform();
    }

    public void removeSubExpression(int pos) {
        throw new IllegalUPAArgumentException("Not Implemented");
    }
}
