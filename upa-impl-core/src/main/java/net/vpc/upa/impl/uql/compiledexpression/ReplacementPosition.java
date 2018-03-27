package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/8/13 12:27 AM
*/
public class ReplacementPosition {

    private CompiledExpressionExt parent;
    private CompiledExpressionExt child;
    private int pos;

    public ReplacementPosition(CompiledExpressionExt parent, CompiledExpressionExt child, int pos) {
        this.setParent(parent);
        this.setChild(child);
        this.setPos(pos);
    }

    public CompiledExpressionExt getParent() {
        return parent;
    }

    public void setParent(CompiledExpressionExt parent) {
        this.parent = parent;
    }

    public CompiledExpressionExt getChild() {
        return child;
    }

    public void setChild(CompiledExpressionExt child) {
        this.child = child;
    }

    public int getPos() {
        return pos;
    }

    public void setPos(int pos) {
        this.pos = pos;
    }
}
