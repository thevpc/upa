package net.vpc.upa.impl;

import net.vpc.upa.*;
import net.vpc.upa.exceptions.NoSuchSectionException;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.util.ListUtils;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import net.vpc.upa.exceptions.NoSuchEntityItemException;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.impl.util.DefaultBeanAdapter;
import net.vpc.upa.impl.util.UPAUtils;
import net.vpc.upa.types.DataType;

public class DefaultSection extends AbstractUPAObject implements Section {

    private Entity entity;
    private EntityPart parent;
    private List<EntityPart> parts;
//    private Map<String, EntityPart> childrenMap;
    private boolean closed;

    public DefaultSection() {
        super();
        this.parent = null;
        this.parts = new ArrayList<EntityPart>(3);
//        childrenMap = new HashMap<String, EntityPart>();
    }

    @Override
    public void commitModelChanges() {
        this.parts=PlatformUtils.trimToSize(this.parts);
        for (EntityPart item : parts) {
            item.commitModelChanges();
        }
    }

    @Override
    public String getAbsoluteName() {
        EntityPart parentSchemaItem = getParent();
        if (parentSchemaItem == null) {
            return getEntity().getAbsoluteName() + "." + getName();
        }
        return parentSchemaItem.getAbsoluteName() + "/" + getName();
    }

    public void setEntity(Entity entity) {
        Entity old = this.entity;
        this.entity = entity;
        propertyChangeSupport.firePropertyChange("entity", old, entity);
    }

    public void addPart(EntityPart child) throws UPAException {
        addPart(child, -1);
    }

    @Override
    public void addPart(EntityPart child, int index) throws UPAException {
        ListUtils.add(parts, child, index, this, this, new DefaultSectionPrivateAddItemInterceptor(this));
    }

    public EntityPart removePart(String name) throws UPAException {
        int i = indexOfPart(name);
        if (i >= 0) {
            return removePartAt(i);
        }
        throw new NoSuchEntityItemException(name);
    }

    public EntityPart getPartAt(int index) throws UPAException {
        return parts.get(index);
    }

    public EntityPart getPart(String name) throws UPAException {
        int i = indexOfPart(name);
        if (i >= 0) {
            return getPartAt(i);
        }
        throw new NoSuchEntityItemException(name);
    }

    public EntityPart removePartAt(int index) throws UPAException {
        EntityPart child = ListUtils.remove(parts, index, this, new DefaultSectionPrivateRemoveItemInterceptor());
        return child;
    }

    public void movePart(String itemName, int newIndex) throws UPAException {
        movePart(indexOfPart(itemName), newIndex);
    }

    public void movePart(int index, int newIndex) throws UPAException {
        ListUtils.moveTo(parts, index, newIndex, this, null);
    }

    public Section getSection(String path, MissingStrategy missingStrategy) throws UPAException {
        if (path == null) {
            throw new NullPointerException();
        }

        String[] canonicalPathArray = UPAUtils.getCanonicalPathArray(path);
        if (canonicalPathArray.length == 0) {
            throw new IllegalArgumentException("invalid module path " + path);
        }
        Section module = null;
        for (String n : canonicalPathArray) {
            Section next = null;
            if (module == null) {
                for (EntityPart schemaItem : parts) {
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
                            throw new NoSuchSectionException(path);
                        }
                        case CREATE: {
                            next = addSection(n, null);
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
                            throw new NoSuchSectionException(path);
                        }
                        case CREATE: {
                            next = addSection(n, module.getPath());
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

    public Section findSection(String name) throws UPAException {
        return getSection(name, MissingStrategy.NULL);
    }

    public List<EntityPart> getParts() {
        return PlatformUtils.unmodifiableList(parts);
    }

    public int indexOfPart(EntityPart child) {
        return parts.indexOf(child);
    }

    public int indexOfPart(String childName) {
        int index = 0;
        for (EntityPart child : parts) {
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

    public EntityPart getParent() {
        return parent;
    }

    public void setParent(EntityPart item) {
        EntityPart old = this.parent;
        this.parent = item;
        propertyChangeSupport.firePropertyChange("parent", old, parent);
    }

    // -------------------------- PATH SUPPORT
    public String getPath() {
        EntityPart parent = getParent();
        return parent == null ? ("/" + getName()) : (parent.getPath() + "/" + getName());
    }

    @Override
    public int getPartsCount() {
        return parts.size();
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
            for (EntityPart child : parts) {
                child.close();
            }
            this.closed = true;
            propertyChangeSupport.firePropertyChange("closed", old, closed);
        }
    }

    public boolean isClosed() {
        return closed;
    }

    @Override
    public Field addField(String name, FlagSet<UserFieldModifier> modifiers, Object defaultValue, DataType type) throws UPAException {
        return getEntity().addField(name, getPath(), modifiers, defaultValue, type);
    }

    @Override
    public Field addField(String name, FlagSet<UserFieldModifier> modifiers, Object defaultValue, DataType type, int index) throws UPAException {
        return getEntity().addField(name, getPath(), modifiers, null, defaultValue, type, index);
    }

    public List<Field> getFields() {
        List<Field> fields = new ArrayList<Field>();
        for (EntityPart part : getParts()) {
            if (part instanceof Field) {
                fields.add((Field) part);
            }
        }
        return fields;
    }

    public List<Section> getSections() {
        List<Section> sections = new ArrayList<Section>();
        for (EntityPart part : getParts()) {
            if (part instanceof Section) {
                sections.add((Section) part);
            }
        }
        return sections;
    }

    @Override
    public Section addSection(String name, String parentPath, int index) throws UPAException {
        if (name == null) {
            throw new NullPointerException();
        }
        if (name.contains("/")) {
            throw new IllegalArgumentException("Name cannot contain '/'");
        }
        String[] canonicalPathArray = UPAUtils.getCanonicalPathArray(parentPath);
        Section parentModule = null;
        for (String n : canonicalPathArray) {
            Section next = null;
            if (parentModule == null) {
                next = getSection(n);
            } else {
                next = parentModule.getSection(n);
            }
            parentModule = next;
        }

        Section currentModule = getPersistenceUnit().getFactory().createObject(Section.class);
        DefaultBeanAdapter a = UPAUtils.prepare(getPersistenceUnit(), currentModule, name);

        if (parentModule == null) {
            addPart(currentModule, index);
        } else {
            parentModule.addPart(currentModule, index);
        }
        //invalidateStructureCache();
        return currentModule;
    }

    @Override
    public Section addSection(String name, String parentPath) throws UPAException {
        return addSection(name, parentPath, -1);
    }

    public Section addSection(String name) throws UPAException {
        return addSection(name, null, -1);
    }

    public Section addSection(String name, int index) throws UPAException {
        return addSection(name, null, index);
    }

}
