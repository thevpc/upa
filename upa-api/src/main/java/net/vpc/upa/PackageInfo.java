package net.vpc.upa;

import java.util.List;

public class PackageInfo extends PersistenceUnitPartInfo{
    private List<PersistenceUnitPartInfo> children;

    public PackageInfo() {
        super("package");
    }

    public List<PersistenceUnitPartInfo> getChildren() {
        return children;
    }

    public void setChildren(List<PersistenceUnitPartInfo> children) {
        this.children = children;
    }
}
