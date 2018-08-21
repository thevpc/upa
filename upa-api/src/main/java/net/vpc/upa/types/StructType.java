/**
 * ====================================================================
 * UPA (Unstructured Persistence API)
 * Yet another ORM Framework
 * ++++++++++++++++++++++++++++++++++
 * Unstructured Persistence API, referred to as UPA, is a genuine effort
 * to raise programming language frameworks managing relational data in
 * applications using Java Platform, Standard Edition and Java Platform,
 * Enterprise Edition and Dot Net Framework equally to the next level of
 * handling ORM for mutable data structures. UPA is intended to provide
 * a solid reflection mechanisms to the mapped data structures while
 * affording to make changes at runtime of those data structures.
 * Besides, UPA has learned considerably of the leading ORM
 * (JPA, Hibernate/NHibernate, MyBatis and Entity Framework to name a few)
 * failures to satisfy very common even known to be trivial requirement in
 * enterprise applications.
 * <p>
 * Copyright (C) 2014-2015 Taha BEN SALAH
 * <p>
 * This program is free software; you can redistribute it and/or modify it under
 * the terms of the GNU General Public License as published by the Free Software
 * Foundation; either version 2 of the License, or (at your option) any later
 * version.
 * <p>
 * This program is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
 * FOR A PARTICULAR PURPOSE. See the GNU General Public License for more
 * details.
 * <p>
 * You should have received a copy of the GNU General Public License along with
 * this program; if not, write to the Free Software Foundation, Inc., 51
 * Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
 * ====================================================================
 */
package net.vpc.upa.types;

import net.vpc.upa.exceptions.IllegalUPAArgumentException;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class StructType extends DefaultDataType implements Cloneable {
    public static final Object OLD_VALUE = new Object();
    private Map<String, DataType> elementsMap;
    private List<String> elementsList;

    public StructType(String name, Class clazz, String[] fieldNames, DataType[] datatypes, boolean nullable) {
        super(name, clazz, datatypes.length, 0, nullable);
        if (fieldNames.length != datatypes.length) {
            throw new IllegalUPAArgumentException();
        }
        elementsMap = new HashMap<String, DataType>(fieldNames.length);
        elementsList = new ArrayList<String>(fieldNames.length);
        for (int i = 0; i < fieldNames.length; i++) {
            if (elementsMap.containsKey(fieldNames[i])) {
                throw new IllegalUPAArgumentException();
            }
            elementsMap.put(fieldNames[i], datatypes[i]);
            elementsList.add(fieldNames[i]);
        }
    }

    public DataType getItemDataTypeAt(int index) {
        return elementsMap.get(elementsList.get(index));
    }

    public String getItemNameAt(int index) {
        return elementsList.get(index);
    }

    public int indexOf(String name) {
        return elementsList.indexOf(name);
    }

    public int getItemsCount() {
        return elementsList.size();
    }

    @Override
    public void check(Object value, String name, String description) throws ConstraintsException {
        super.check(value, name, description);
        Object[] val = getArrayForObject(value);
        int max = elementsList.size();
        if (value != null) {
            for (int i = 0; i < max; i++) {
                if (!OLD_VALUE.equals(val[i])) {
                    getItemDataTypeAt(i).check(val[i], null, null);
                }
            }
        } else {
//            for(int i=0;i<max;i++){
//                getItemDataTypeAt(i).check(null);
//            }
        }
    }

    public Object getItemValueAt(int index, Object value) {
        return value == null ? null : ((Object[]) value)[index];
    }

    public Map<String, Object> getItemValuesMap(Map<String, Object> map, Object value) {
        if (map == null) {
            map = new HashMap<String, Object>();
        }
        int max = getItemsCount();
        if (value != null) {
            for (int i = 0; i < max; i++) {
                map.put(getItemNameAt(i), getItemValueAt(i, value));
            }
        } else {
            for (int i = 0; i < max; i++) {
                map.put(getItemNameAt(i), null);
            }
        }
        return map;
    }

    public Object getItemValue(String fieldName, Object value) {
        return getItemValueAt(indexOf(fieldName), value);
    }

//    public DataTypeView getViewObject(Object modelValue) {
//        return new StructView(modelValue);
//    }
//
//    public class StructView extends DataTypeView{
//        public  StructView(Object value){
//            super(StructType.this,value,null,Resources.loadImageIcon("/images/net/vpc/swing/TypeObject.gif"),SwingConstants.LEFT);
//        }
//        public String getString(){
//            Object o=getObject();
//            return o==null ? "" :o.toString();
//        }
//    }

    public Object getObjectForArray(Object[] value) {
        return value;
    }

    public Object[] getArrayForObject(Object value) {
        return (Object[]) value;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        if (!super.equals(o)) return false;

        StructType that = (StructType) o;

        if (elementsMap != null ? !elementsMap.equals(that.elementsMap) : that.elementsMap != null) return false;
        return elementsList != null ? elementsList.equals(that.elementsList) : that.elementsList == null;
    }

    @Override
    public int hashCode() {
        int result = super.hashCode();
        result = 31 * result + (elementsMap != null ? elementsMap.hashCode() : 0);
        result = 31 * result + (elementsList != null ? elementsList.hashCode() : 0);
        return result;
    }
}
