package net.vpc.upa;

import java.util.List;

public class CompoundFieldInfo extends FieldInfo {
    private List<PrimitiveFieldInfo> children;

    public CompoundFieldInfo() {
        super("compound");
    }

    public List<PrimitiveFieldInfo> getChildren() {
        return children;
    }

    public void setChildren(List<PrimitiveFieldInfo> children) {
        this.children = children;
    }
}
