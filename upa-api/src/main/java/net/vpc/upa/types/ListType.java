/**
 * ==================================================================== 
 * UPA (Unstructured Persistence API)
 *    Yet another ORM Framework
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
 *
 * Copyright (C) 2014-2015 Taha BEN SALAH
 *
 * This program is free software; you can redistribute it and/or modify it under
 * the terms of the GNU General Public License as published by the Free Software
 * Foundation; either version 2 of the License, or (at your option) any later
 * version.
 *
 * This program is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
 * FOR A PARTICULAR PURPOSE. See the GNU General Public License for more
 * details.
 *
 * You should have received a copy of the GNU General Public License along with
 * this program; if not, write to the Free Software Foundation, Inc., 51
 * Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
 * ====================================================================
 */
package net.vpc.upa.types;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class ListType extends SeriesType implements Cloneable {

    protected DataType elementType;
    protected List<Object> elements;

    public ListType(String name, List<Object> collection, DataType modelClass, boolean nullable) {
        this(name, collection, modelClass, 0, 0, nullable);
    }

    public ListType(String name, List<Object> collection, DataType modelClass) {
        this(name, collection, modelClass, 0, 0, false);
    }

    public ListType(String name, Object[] collection, DataType modelClass) {
        this(name, Arrays.asList(collection), modelClass, 0, 0, false);
    }

    public ListType(String name, List<Object> collection, DataType elementType, int length, int precision, boolean nullable) {
        super(name, elementType.getPlatformType(), length, precision, nullable);
        this.elementType = elementType;
        setData(collection);
        setDefaultNonNullValue(getValues().size() > 0 ? getValues().get(0) : null);
    }

    public ListType(String name, List<Object> collection, DataType modelClass, int length, int precision) {
        this(name, collection, modelClass, length, precision, false);
    }

    public DataType getElementType() {
        return elementType;
    }

    @Override
    public List<Object> getValues() {
        return elements;
    }

    private void setData(List<Object> collection) {
        elements = new ArrayList<Object>();
        if (collection != null) {
            for (Object s : collection) {
                if (s != null && !getPlatformType().isInstance(s)) {
                    throw new ClassCastException("Expected " + getPlatformType() + " but got " + s.getClass().getName());
                }
                if (s != null && (String.class).equals(getPlatformType())) {
                    int x = ((String) s).length();
                    if (scale < x) {
                        scale = x;
                    }
                }
                elements.add(s);
            }

        }
    }

    @Override
    public void check(Object value, String name, String description)
            throws ConstraintsException {
        super.check(value,name,description);
        elementType.check(value,name,description);
//        if (!elements.containsKey(value))
//            throw new ConstraintsException(MessageFormat.format(DataType.MSG_ILLEGAL_VALUE, new Object[]{
//                value
//            }));
//        else
//            return;
    }

//    public DataTypeView getViewObject(Object modelValue) {
//        return new ListView(modelValue);
//    }
//
//    public class ListView extends DataTypeView{
//        public  ListView(Object value){
//            super(ListType.this,value,null,
//                    (value!=null && icons.get(value)!=null) ? (Icon) icons.get(value) :
//                    Resources.loadImageIcon("/images/net/vpc/swing/TypeList.gif"),
//                    SwingConstants.LEFT
//            );
//        }
//        public String getString(){
//            return (String) ListType.this.elements.get(getObject());
//        }
//        public int compareTo(Object o) {
//            if(o==this) return 0;
//            if(o==null) return 1;
//            if(ListView.class.isAssignableFrom(o.getClass())) return 1;
//            String value=(String) ListType.this.elements.get(getObject());
//            String value2=(String) ((ListType)o).elements.get(getObject());
//            return value.compareTo(value2);
//        }
//
//        public Object getRenderedObject() {
//            return (String) ListType.this.elements.get(getObject());
//        }
//    }
    public Object getValueAt(int index) {
        return elements.get(index);
    }

    public int indexOf(Object key) {
        return elements.indexOf(key);
    }

    public void add(Object value) {
        elements.add(value);
    }

    public void insert(int index, Object value) {
        elements.add(index, value);
    }

    public void removeAll() {
        elements.clear();
    }

    public void remove(Object key) {
        elements.remove(key);
    }

    public void remove(int index) {
        elements.remove(index);
    }

    public int size() {
        return elements.size();
    }

    @Override
    public Object clone() {
        ListType l = (ListType) super.clone();
        l.elements = new ArrayList<Object>(l.elements);
        return l;
    }

}
