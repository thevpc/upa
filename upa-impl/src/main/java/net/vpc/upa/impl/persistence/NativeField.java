package net.vpc.upa.impl.persistence;

import net.vpc.upa.Field;
import net.vpc.upa.types.DataTypeTransform;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 11/24/12 5:43 PM
 */
public class NativeField {
    private String groupName;
    private String name;
    private DataTypeTransform typeTransform;
    private Field field;

    public NativeField(String name, String groupName,Field field,DataTypeTransform typeChain) {
        this.groupName = groupName;
        this.name = name;
        this.field = field;
        this.typeTransform = typeChain;
        //REMOVE ME
        if(typeChain==null){
            throw new IllegalArgumentException("Null DataType");
        }
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
    
}
