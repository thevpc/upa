package net.vpc.upa.impl;

import net.vpc.upa.*;
import net.vpc.upa.Package;
import net.vpc.upa.exceptions.NoSuchPackageException;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.exceptions.UPAIllegalArgumentException;
import net.vpc.upa.impl.util.ListUtils;

import java.util.ArrayList;
import java.util.List;

public class DefaultPackage extends AbstractUPAObject implements Package {

    private Package parent;
    private List<PersistenceUnitPart> parts;
    private boolean closed;

    public DefaultPackage() {
        this.parent = null;
        this.parts = new ArrayList<PersistenceUnitPart>(3);
    }

    @Override
    public String getAbsoluteName() {
        PersistenceUnitPart parentPersistenceUnitItem = getParent();
        if (parentPersistenceUnitItem == null) {
            return getName();
        }
        return parentPersistenceUnitItem.getAbsoluteName() + "/" + getName();
    }

    public void addPart(PersistenceUnitPart child) {
        addPart(child, getPartsCount());
    }

    public void addPart(PersistenceUnitPart part, int index) {
        if (index < 0) {
            index = getPartsCount() + index + 1;
        }
        if (index < 0) {
            throw new ArrayIndexOutOfBoundsException(index);
        }
        if (index > parts.size()) {
            throw new ArrayIndexOutOfBoundsException(index);
        }
        ListUtils.add(parts, part, index, this, this, new DefaultPackagePrivateAddPartInterceptor(this),true);
    }

    public void removePartAt(int index) {
        ListUtils.remove(parts, index, this, new DefaultPackagePrivateRemovePartInterceptor());
    }

    public void movePart(String itemName, int newIndex) {
        movePart(indexOfPart(itemName), newIndex);
    }

    public void movePart(int index, int newIndex) {
        ListUtils.moveTo(parts, index, newIndex, this, null);
    }

    public List<PersistenceUnitPart> getParts() {
        return new ArrayList<PersistenceUnitPart>(parts);
    }

    public List<Entity> getEntities() {
        List<Entity> all = new ArrayList<Entity>();
        for (PersistenceUnitPart item : parts) {
            if (item instanceof Entity) {
                all.add((Entity) item);
            }
        }
        return all;
    }

    @Override
    public List<Entity> getEntities(boolean includeSubPackages) {
        List<Entity> all = new ArrayList<Entity>();
        for (PersistenceUnitPart item : parts) {
            if (item instanceof Entity) {
                all.add((Entity) item);
            }else if(includeSubPackages){
                if(item instanceof net.vpc.upa.Package){
                    all.addAll(((net.vpc.upa.Package)item).getEntities(includeSubPackages));
                }
            }
        }
        return all;
    }
    

    public List<Package> getPackages() {
        List<Package> all = new ArrayList<Package>();
        for (PersistenceUnitPart item : parts) {
            if (item instanceof Package) {
                all.add((Package) item);
            }
        }
        return all;
    }

    public int indexOfPart(PersistenceUnitPart child) {
        return parts.indexOf(child);
    }

    public int indexOfPart(String childName) {
        int index = 0;
        for (PersistenceUnitPart child : parts) {
            if (childName.equals(child.getName())) {
                return index;
            }
            index++;
        }
        return -1;
    }

    public Package getParent() {
        return parent;
    }

    public void setParent(Package parent) {
        this.parent = parent;
    }

    public String getPath() {
        String p = parent == null ? "/" : parent.getPath();
        if (!p.endsWith("/")) {
            p = p + "/";
        }
        return p + getName();
    }

    public Package getPart(String name) {
        for (PersistenceUnitPart persistenceUnitItem : parts) {
            if (persistenceUnitItem instanceof Package) {
                Package m = (Package) persistenceUnitItem;
                if (m.getName().equals(name)) {
                    return m;
                }
            }
        }
        throw new NoSuchPackageException(name,null);
    }

    @Override
    public int getPartsCount() {
        return parts.size();
    }

    @Override
    public void close() throws UPAException {
        for (PersistenceUnitPart child : parts) {
            child.close();
        }
        this.closed = true;
    }

    public boolean isClosed() {
        return closed;
    }

    @Override
    public String toString() {
        return getPath();
    }

    @Override
    public void checkValidIdentifier(String s) {
        // an empty or null string cannot be a valid identifier
        if (s == null) {
            throw new UPAIllegalArgumentException("Empty name");
        }
        //s=="" is accepted for default package
        if (!s.trim().equals(s)) {
            throw new UPAIllegalArgumentException(s);
        }

        // Select lf from LigneFacture lf where lf.facture.date=:dte
        char[] c = s.toCharArray();
        for (int i = 1; i < c.length; i++) {
            if (c[i] == '/') {
                throw new UPAIllegalArgumentException("Invalid name char '" + c[i] + "' in name " + s);
            }
        }
    }

    @Override
    public PackageInfo getInfo() {
        PackageInfo i=new PackageInfo();
        fillObjectInfo(i);
        List<PersistenceUnitPartInfo> parts=new ArrayList<>();
        for (PersistenceUnitPart part : this.parts) {
            if(part instanceof Entity){
                parts.add(((Entity) part).getInfo());
            }else if(part instanceof Package){
                parts.add(((Package) part).getInfo());
            }
        }
        i.setChildren(parts);
        return i;
    }
}
