package net.vpc.upa.impl.persistence;

import net.vpc.upa.Field;
import net.vpc.upa.impl.util.StringUtils;
import net.vpc.upa.types.DataTypeTransform;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 11/24/12 5:43 PM
 */
public class NativeField {
    private int index;
    private boolean expanded;
    private String groupName;
    private String fullBinding;
    private String exprString;
    private String name;
    private DataTypeTransform typeTransform;
    private Field field;

    public NativeField(String name, String groupName,String exprString,int index,boolean expanded,Field field,DataTypeTransform typeChain) {
        this.groupName = groupName;
        this.expanded = expanded;
        this.index = index;
        this.exprString = exprString;
        this.name = name;
        if(StringUtils.isNullOrEmpty(groupName)){
            fullBinding=name;
        }else{
            fullBinding=groupName+"."+name;
        }
        this.field = field;
        this.typeTransform = typeChain;
        //REMOVE ME
        if(typeChain==null){
            throw new IllegalArgumentException("Null DataType");
        }
    }

    public int getIndex() {
        return index;
    }

    public String getFullBinding() {
        return fullBinding;
    }

    public String getGroupName() {
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

    public String getExprString() {
        return exprString;
    }

    public boolean isExpanded() {
        return expanded;
    }
}
