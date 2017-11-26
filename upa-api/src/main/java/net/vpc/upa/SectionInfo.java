package net.vpc.upa;

import java.util.List;

public class SectionInfo extends EntityPartInfo {
    private List<EntityPartInfo> children;

    public SectionInfo() {
        super("section");
    }

    public List<EntityPartInfo> getChildren() {
        return children;
    }

    public void setChildren(List<EntityPartInfo> children) {
        this.children = children;
    }
}
