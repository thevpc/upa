package net.vpc.upa.impl;

import net.vpc.upa.*;
import net.vpc.upa.exceptions.NoSuchSectionException;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.exceptions.UPAIllegalArgumentException;
import net.vpc.upa.filters.FieldFilter;
import net.vpc.upa.impl.util.ListUtils;

import java.util.ArrayList;
import java.util.List;

import net.vpc.upa.exceptions.NoSuchEntityItemException;
import net.vpc.upa.exceptions.UnexpectedException;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.impl.util.DefaultBeanAdapter;
import net.vpc.upa.impl.util.UPAUtils;

public class DefaultSection extends AbstractUPAObject implements Section {

    private Entity entity;
    private EntityItem parent;
    private List<EntityItem> items;
//    private Map<String, EntityItem> childrenMap;
    private boolean closed;

    public DefaultSection() {
        super();
        this.parent = null;
        this.items = new ArrayList<EntityItem>(3);
//        childrenMap = new HashMap<String, EntityItem>();
    }

    @Override
    public void commitModelChanges() {
        this.items = PlatformUtils.trimToSize(this.items);
        for (EntityItem item : items) {
            item.commitModelChanges();
        }
    }

    @Override
    public String getAbsoluteName() {
        EntityItem parentSchemaItem = getParent();
        if (parentSchemaItem == null) {
            return getEntity().getAbsoluteName() + "." + getName();
        }
        return parentSchemaItem.getAbsoluteName() + "/" + getName();
    }

    public void setEntity(Entity entity) {
        Entity old = this.entity;
        Entity recent = entity;
        beforePropertyChangeSupport.firePropertyChange("entity", old, recent);
        this.entity = entity;
        afterPropertyChangeSupport.firePropertyChange("entity", old, recent);
    }

    public void addItem(EntityItem child) throws UPAException {
        DefaultSection.this.addItem(child, -1);
    }

    @Override
    public void addItem(EntityItem child, int index) throws UPAException {
        ListUtils.add(items, child, index, this, this, new DefaultSectionPrivateAddItemInterceptor(this), true);
    }

    public EntityItem removeItem(String name) throws UPAException {
        int i = DefaultSection.this.indexOfItem(name);
        if (i >= 0) {
            return removeItemAt(i);
        }
        EntityItem p = getItemAt(i);
        if (p instanceof Field) {
            throw new net.vpc.upa.exceptions.NoSuchFieldException(getEntity().getName(), null, name);
        }
        if (p instanceof Section) {
            throw new net.vpc.upa.exceptions.NoSuchSectionException(getEntity().getName(), null, name);
        }
        throw new UnexpectedException();
    }

    public EntityItem getItemAt(int index) throws UPAException {
        return items.get(index);
    }

    public EntityItem getItem(String name) throws UPAException {
        int i = DefaultSection.this.indexOfItem(name);
        if (i >= 0) {
            return getItemAt(i);
        }
        throw new net.vpc.upa.exceptions.NoSuchFieldException(getEntity().getName(), getAbsoluteName(), name);
    }

    public EntityItem removeItemAt(int index) throws UPAException {
        EntityItem child = ListUtils.remove(items, index, this, new DefaultSectionPrivateRemoveItemInterceptor());
        return child;
    }

    public void moveItem(String itemName, int newIndex) throws UPAException {
        moveItem(DefaultSection.this.indexOfItem(itemName), newIndex);
    }

    public void moveItem(int index, int newIndex) throws UPAException {
        ListUtils.moveTo(items, index, newIndex, this, null);
    }

    public Section getSection(String path, MissingStrategy missingStrategy) throws UPAException {
        if (path == null) {
            throw new NullPointerException();
        }

        String[] canonicalPathArray = UPAUtils.getCanonicalPathArray(path);
        if (canonicalPathArray.length == 0) {
            throw new UPAIllegalArgumentException("invalid module path " + path);
        }
        Section module = null;
        for (String n : canonicalPathArray) {
            Section next = null;
            if (module == null) {
                for (EntityItem schemaItem : items) {
                    if (schemaItem instanceof Section) {
                        if (schemaItem.getName().equals(n)) {
                            next = (Section) schemaItem;
                            break;
                        }
                    }
                }
                if (next == null) {
                    switch (missingStrategy) {
                        case ERROR: {
                            throw new NoSuchSectionException(getEntity().getName(), null, path);
                        }
                        case CREATE: {
                            next = addSection(n);
                            break;
                        }
                        case NULL: {
                            return null;
                        }
                        default: {
                            throw new UnsupportedOperationException();
                        }
                    }
                }
            } else {
                try {
                    next = module.getSection(n);
                } catch (NoSuchSectionException e) {
                    switch (missingStrategy) {
                        case ERROR: {
                            throw new NoSuchSectionException(getEntity().getName(), null, path);
                        }
                        case CREATE: {
                            next = addSection(module.getPath() + "/" + n);
                            break;
                        }
                        case NULL: {
                            return null;
                        }
                        default: {
                            throw new UnsupportedOperationException();
                        }
                    }
                }
            }
            module = next;
        }
        return module;
    }

    public Section getSection(String name) {
        return getSection(name, MissingStrategy.ERROR);
    }

    public Section findSection(String path) throws UPAException {
        return getSection(path, MissingStrategy.NULL);
    }

    public List<EntityItem> getItems() {
        return PlatformUtils.unmodifiableList(items);
    }

    public int indexOfItem(EntityItem child) {
        return items.indexOf(child);
    }

    public int indexOfItem(String childName) {
        int index = 0;
        for (EntityItem child : items) {
            if (childName.equals(child.getName())) {
                return index;
            }
            index++;
        }
        return -1;
    }

    public Entity getEntity() {
        return entity;
    }

    public EntityItem getParent() {
        return parent;
    }

    public void setParent(EntityItem item) {
        EntityItem old = this.parent;
        EntityItem recent = item;
        afterPropertyChangeSupport.firePropertyChange("parent", old, recent);
        this.parent = item;
        afterPropertyChangeSupport.firePropertyChange("parent", old, recent);
    }

    // -------------------------- PATH SUPPORT
    public String getPath() {
        EntityItem parent = getParent();
        return parent == null ? ("/" + getName()) : (parent.getPath() + "/" + getName());
    }

    @Override
    public int getItemsCount() {
        return items.size();
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) {
            return true;
        }
        if (o == null || getClass() != o.getClass()) {
            return false;
        }

        DefaultSection that = (DefaultSection) o;

        if (getName() != null ? !getName().equals(that.getName()) : that.getName() != null) {
            return false;
        }
        if (parent != null ? !parent.equals(that.parent) : that.parent != null) {
            return false;
        }
        if (entity != null ? !entity.equals(that.entity) : that.entity != null) {
            return false;
        }

        return true;
    }

    @Override
    public int hashCode() {
        int result = super.hashCode();
        result = 31 * result + (parent != null ? parent.hashCode() : 0);
        return result;
    }

    @Override
    public void close() throws UPAException {
        boolean old = this.closed;
        if (!old) {
            for (EntityItem child : items) {
                child.close();
            }
            boolean recent = true;
            this.closed = true;
            afterPropertyChangeSupport.firePropertyChange("closed", old, recent);
        }
    }

    public boolean isClosed() {
        return closed;
    }

    @Override
    public Field addField(FieldBuilder fieldBuilder) throws UPAException {
        return addField(fieldBuilder.build());
    }

    @Override
    public Field addField(FieldDescriptor fieldDescriptor) throws UPAException {
        DefaultFieldDescriptor f = new DefaultFieldDescriptor();
        f.setFieldDescriptor(fieldDescriptor);
        String p = f.getPath();
        f.setPath(p == null ? getPath() : getPath() + "/" + p);
        return getEntity().addField(f);
    }

    public List<Field> getFields() {
        List<Field> fields = new ArrayList<Field>();
        for (EntityItem item : getItems()) {
            if (item instanceof Field) {
                fields.add((Field) item);
            } else if (item instanceof Section) {
                fields.addAll(((Section) item).getFields());
            }
        }
        return fields;
    }

    @Override
    public List<Field> getFields(FieldFilter fieldFilter) throws UPAException {
        List<Field> fields = new ArrayList<Field>();
        for (EntityItem item : getItems()) {
            if (item instanceof Field) {
                Field field = (Field) item;
                if (fieldFilter == null || fieldFilter.accept(field)) {
                    fields.add(field);
                }
            } else if (item instanceof Section) {
                fields.addAll(((Section) item).getFields(fieldFilter));
            }
        }
        return fields;
    }

    @Override
    public List<Field> getImmediateFields(FieldFilter fieldFilter) {
        List<Field> fields = new ArrayList<Field>();
        for (EntityItem item : getItems()) {
            if (item instanceof Field) {
                Field field = (Field) item;
                if (fieldFilter == null || fieldFilter.accept(field)) {
                    fields.add(field);
                }
            }
        }
        return fields;
    }

    public List<Field> getImmediateFields() {
        List<Field> fields = new ArrayList<Field>();
        for (EntityItem item : getItems()) {
            if (item instanceof Field) {
                fields.add((Field) item);
            }
        }
        return fields;
    }

    public List<Section> getSections() {
        List<Section> sections = new ArrayList<Section>();
        for (EntityItem item : getItems()) {
            if (item instanceof Section) {
                sections.add((Section) item);
            }
        }
        return sections;
    }

    @Override
    public Section addSection(String path, int index) throws UPAException {
        if (path == null) {
            throw new NullPointerException();
        }
        String[] canonicalPathArray = UPAUtils.getCanonicalPathArray(path);
        if (canonicalPathArray.length == 0) {
            throw new UPAIllegalArgumentException("Empty Name");
        }
        Section parentModule = null;
        for (int i = 0, canonicalPathArrayLength = canonicalPathArray.length; i < canonicalPathArrayLength - 1; i++) {
            String n = canonicalPathArray[i];
            Section next = null;
            if (parentModule == null) {
                next = getSection(n);
            } else {
                next = parentModule.getSection(n);
            }
            parentModule = next;
        }

        Section currentModule = getPersistenceUnit().getFactory().createObject(Section.class);
        DefaultBeanAdapter a = UPAUtils.prepare(getPersistenceUnit(), this, currentModule, canonicalPathArray[canonicalPathArray.length - 1]);

        if (parentModule == null) {
            DefaultSection.this.addItem(currentModule, index);
        } else {
            parentModule.addItem(currentModule, index);
        }
        //invalidateStructureCache();
        return currentModule;
    }

    public Section addSection(String path) throws UPAException {
        return addSection(path, -1);
    }

    @Override
    public SectionInfo getInfo() {
        SectionInfo i = new SectionInfo();
        fillObjectInfo(i);
        List<EntityItemInfo> list = new ArrayList<>();
        for (EntityItem item : items) {
            if (item instanceof Section) {
                list.add(((Section) item).getInfo());
            } else if (item instanceof CompoundField) {
                list.add(((CompoundField) item).getInfo());
            } else if (item instanceof DynamicField) {
                list.add(((DynamicField) item).getInfo());
            } else if (item instanceof PrimitiveField) {
                list.add(((PrimitiveField) item).getInfo());
            }
        }
        i.setChildren(list);
        return i;
    }
}
