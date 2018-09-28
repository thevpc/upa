package net.vpc.upa.impl;

import net.vpc.upa.*;
import net.vpc.upa.Package;
import net.vpc.upa.exceptions.NoSuchPackageException;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.exceptions.IllegalUPAArgumentException;
import net.vpc.upa.impl.util.ListUtils;

import java.util.ArrayList;
import java.util.List;

public class DefaultPackage extends AbstractUPAObject implements Package {

    private Package parent;
    private List<PersistenceUnitItem> items;
    private boolean closed;

    public DefaultPackage() {
        this.parent = null;
        this.items = new ArrayList<PersistenceUnitItem>(3);
    }

    @Override
    public String getAbsoluteName() {
        PersistenceUnitItem parentPersistenceUnitItem = getParent();
        if (parentPersistenceUnitItem == null) {
            return getName();
        }
        return parentPersistenceUnitItem.getAbsoluteName() + "/" + getName();
    }

    public void addItem(PersistenceUnitItem child) {
        ListUtils.add(items, child, this, this, new DefaultPackagePrivateAddPartInterceptor(this));
    }

    public void removeItemAt(int index) {
        ListUtils.remove(items, index, this, new DefaultPackagePrivateRemovePartInterceptor());
    }

    public void moveItem(String itemName, int newIndex) {
        moveItem(indexOfItem(itemName), newIndex);
    }

    public void moveItem(int index, int newIndex) {
        ListUtils.moveTo(items, index, newIndex, this, null);
    }

    public List<PersistenceUnitItem> getItems() {
        return new ArrayList<PersistenceUnitItem>(items);
    }

    public List<Entity> getEntities() {
        List<Entity> all = new ArrayList<Entity>();
        for (PersistenceUnitItem item : items) {
            if (item instanceof Entity) {
                all.add((Entity) item);
            }
        }
        return all;
    }

    @Override
    public List<Entity> getEntities(boolean includeSubPackages) {
        List<Entity> all = new ArrayList<Entity>();
        for (PersistenceUnitItem item : items) {
            if (item instanceof Entity) {
                all.add((Entity) item);
            } else if (includeSubPackages) {
                if (item instanceof net.vpc.upa.Package) {
                    all.addAll(((net.vpc.upa.Package) item).getEntities(includeSubPackages));
                }
            }
        }
        return all;
    }

    @Override
    public List<Package> getPackages(boolean includeSubPackages) {
        List<Package> all = new ArrayList<Package>();
        for (PersistenceUnitItem item : items) {
            if (item instanceof Package) {
                all.add((Package) item);
            } else if (includeSubPackages) {
                if (item instanceof net.vpc.upa.Package) {
                    all.addAll(((net.vpc.upa.Package) item).getPackages(includeSubPackages));
                }
            }
        }
        return all;
    }

    public List<Package> getPackages() {
        List<Package> all = new ArrayList<Package>();
        for (PersistenceUnitItem item : items) {
            if (item instanceof Package) {
                all.add((Package) item);
            }
        }
        return all;
    }

    public int indexOfItem(PersistenceUnitItem child) {
        return items.indexOf(child);
    }

    public int indexOfItem(String childName) {
        int index = 0;
        for (PersistenceUnitItem child : items) {
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

    public Package getItem(String name) {
        for (PersistenceUnitItem persistenceUnitItem : items) {
            if (persistenceUnitItem instanceof Package) {
                Package m = (Package) persistenceUnitItem;
                if (m.getName().equals(name)) {
                    return m;
                }
            }
        }
        throw new NoSuchPackageException(name, null);
    }

    @Override
    public int getItemsCount() {
        return items.size();
    }

    @Override
    public void close() throws UPAException {
        for (PersistenceUnitItem child : items) {
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
            throw new IllegalUPAArgumentException("Empty name");
        }
        //s=="" is accepted for default package
        if (!s.trim().equals(s)) {
            throw new IllegalUPAArgumentException(s);
        }

        // Select lf from LigneFacture lf where lf.facture.date=:dte
        char[] c = s.toCharArray();
        for (int i = 1; i < c.length; i++) {
            if (c[i] == '/') {
                throw new IllegalUPAArgumentException("Invalid name char '" + c[i] + "' in name " + s);
            }
        }
    }

    @Override
    public PackageInfo getInfo() {
        PackageInfo i = new PackageInfo();
        fillObjectInfo(i);
        List<PersistenceUnitPartInfo> parts = new ArrayList<>();
        for (PersistenceUnitItem part : this.items) {
            if (part instanceof Entity) {
                parts.add(((Entity) part).getInfo());
            } else if (part instanceof Package) {
                parts.add(((Package) part).getInfo());
            }
        }
        i.setChildren(parts);
        return i;
    }
}
