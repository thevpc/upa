package net.vpc.upa.impl.persistence;

import net.vpc.upa.Field;
import net.vpc.upa.impl.uql.BindingId;
import net.vpc.upa.types.DataTypeTransform;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 11/24/12 5:43 PM
 */
public class NativeField {
    private int index;
    private boolean expanded;
    private BindingId groupName;
//    private String fullBinding;
//    private String exprString;
    private String name;
    private DataTypeTransform typeTransform;
    private Field field;
    private Field bindingField;

    public NativeField(String name, BindingId groupName, int index, boolean expanded, Field field, Field bindingField, DataTypeTransform typeChain) {
        this.groupName = groupName;
        this.expanded = expanded;
        this.index = index;
//        this.exprString = exprString;
        this.name = name;
//        if(StringUtils.isNullOrEmpty(groupName)){
//            fullBinding=name;
//        }else{
//            fullBinding=groupName+"."+name;
//        }
        this.field = field;
        this.bindingField = bindingField;
        this.typeTransform = typeChain;
        //REMOVE ME
        if(typeChain==null){
            throw new IllegalArgumentException("Null DataType");
        }
    }

    public Field getBindingField() {
        return bindingField;
    }

    public int getIndex() {
        return index;
    }

//    public String getFullBinding() {
//        return fullBinding;
//    }

    public BindingId getGroupName() {
        return groupName;
    }

    public Field getField() {
        return field;
    }

    public String getName() {
        return name;
    }

    public DataTypeTransform getTypeTransform() {
        return typeTransform;
    }

    @Override
    public String toString() {
        return "NativeField{" + "groupName=" + groupName + ", name=" + name + ", typeChain=" + typeTransform + ", field=" + field + '}';
    }

//    public String getExprString() {
//        return exprString;
//    }

    public boolean isExpanded() {
        return expanded;
    }
}
