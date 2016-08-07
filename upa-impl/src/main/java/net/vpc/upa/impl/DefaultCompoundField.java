/*
 * Created by IntelliJ IDEA.
 * User: taha
 * Date: 27 mars 03
 * Time: 14:06:29
 * To change template for new class use 
 * Code Style | Class Templates options (Tools | IDE Options).
 */
package net.vpc.upa.impl;

import net.vpc.upa.*;
import net.vpc.upa.exceptions.NoSuchEntityItemException;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.event.AddPrimitiveFieldItemInterceptor;
import net.vpc.upa.impl.util.ListUtils;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class DefaultCompoundField extends AbstractField implements CompoundField {

    private List<PrimitiveField> fields;
    private Map<String, PrimitiveField> fieldsMap;

    public DefaultCompoundField() {
        super();
        fields = new ArrayList<PrimitiveField>(2);
        fieldsMap = new HashMap<String, PrimitiveField>(2);
    }

    public void addField(PrimitiveField child) throws UPAException {
        addField(child, -1);
    }

    public void addField(PrimitiveField child, int index) throws UPAException {
        ListUtils.add(fields, child, index, this, this, new AddPrimitiveFieldItemInterceptor(this));
        fieldsMap.put(child.getName(), child);
    }

    public PrimitiveField dropFieldAt(int index) {
        PrimitiveField child = ListUtils.remove(fields, index, this, new DropPrimitiveFieldItemInterceptor());
        fieldsMap.put(child.getName(), child);
        return child;
    }

    public PrimitiveField dropField(String name) throws UPAException {
        return dropFieldAt(indexOfField(name));
    }

    public void moveField(int index, int newIndex) {
        ListUtils.moveTo(fields, index, newIndex, this, null);
    }

    public List<PrimitiveField> getFields() {
        return new ArrayList<PrimitiveField>(fields);
    }

    public int indexOfField(PrimitiveField child) {
        return fields.indexOf(child);
    }

    public PrimitiveField getField(String name) throws UPAException {
        int index = indexOfField(name);
        if (index < 0) {
            throw new NoSuchEntityItemException(name);
        }
        return fields.get(index);
    }

    public int indexOfField(String fieldName) {
        int i = 0;
        for (PrimitiveField field : fields) {
            if (fieldName.equals(field.getName())) {
                return i;
            }
            i++;
        }
        return -1;
    }

    public PrimitiveField getLeadingField() {
        return fields.get(0);
    }

    @Override
    public void setUserModifiers(FlagSet<UserFieldModifier> modifiers) {
        super.setUserModifiers(modifiers);
        for (PrimitiveField field : fields) {
            field.setUserModifiers(modifiers);
        }
    }

    @Override
    public void setEffectiveModifiers(FlagSet<FieldModifier> modifiers) {
        super.setEffectiveModifiers(modifiers);
        for (PrimitiveField field : fields) {
            ((AbstractField) field).setEffectiveModifiers(modifiers);
        }
    }

    public int getFieldsCount() {
        return fields.size();
    }

    @Override
    public PrimitiveField getFieldAt(int index) {
        return fields.get(index);
    }

    @Override
    public void close() throws UPAException {
        for (PrimitiveField field : fields) {
            field.close();
        }
        super.close();
    }

    @Override
    public Object[] getPrimitiveValues(Object object) {
        return ((CompoundDataType) getDataType()).getPrimitiveValues(object);
    }

    @Override
    public Object getCompoundValue(Object[] values) {
        return ((CompoundDataType) getDataType()).getCompoundValue(values);
    }
}
