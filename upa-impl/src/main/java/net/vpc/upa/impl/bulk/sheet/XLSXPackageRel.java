/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.bulk.sheet;

import net.vpc.upa.PortabilityHint;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@PortabilityHint(target = "C#",name = "suppress")
public class XLSXPackageRel {

    String id;
    String path;
    String itemType;
    XLSXPackagePart part;

    public XLSXPackageRel(String id, String itemType, String path) {
        this.id = id;
        this.path = path;
        this.itemType = itemType;
    }

    public String getId() {
        return id;
    }

    public String getPath() {
        return path;
    }

    public String getItemType() {
        return itemType;
    }

    public XLSXPackagePart getPart() {
        return part;
    }

    @Override
    public String toString() {
        return "XLSXPackageRel{" + "id=" + id + ", path=" + path + ", type=" + itemType + ", part=" + part + '}';
    }
    
}
