package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.Entity;
import net.vpc.upa.Field;
import net.vpc.upa.impl.persistence.NativeField;
import net.vpc.upa.impl.uql.BindingId;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

/**
* Created by vpc on 1/4/14.
*/
class FieldInfo {

    public TypeInfo typeInfo;
    public int dbIndex;
    public BindingId binding;
    public boolean read;
    public String name;
    public NativeField nativeField;
    public Field field;
//    public FieldInfoSetter setter;

    @Override
    public String toString() {
        StringBuilder sb=new StringBuilder();
        if(nativeField!=null){
            sb.append(nativeField.toString());
        }else{
            sb.append(name);
        }
        sb.append("@").append(dbIndex);
        return sb.toString();
    }
}
