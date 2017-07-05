package net.vpc.upa.impl.uql.compiledexpression;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/8/13 12:27 AM
*/
public class ReplacementPosition {

    private DefaultCompiledExpression parent;
    private DefaultCompiledExpression child;
    private int pos;

    public ReplacementPosition(DefaultCompiledExpression parent, DefaultCompiledExpression child, int pos) {
        this.setParent(parent);
        this.setChild(child);
        this.setPos(pos);
    }

    public DefaultCompiledExpression getParent() {
        return parent;
    }

    public void setParent(DefaultCompiledExpression parent) {
        this.parent = parent;
    }

    public DefaultCompiledExpression getChild() {
        return child;
    }

    public void setChild(DefaultCompiledExpression child) {
        this.child = child;
    }

    public int getPos() {
        return pos;
    }

    public void setPos(int pos) {
        this.pos = pos;
    }
}
