package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.Entity;
import net.vpc.upa.Field;
import net.vpc.upa.impl.persistence.NativeField;

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
    public boolean update;
    public Set<Integer> indexesToUpdate=new HashSet<Integer>();
    public String name;
    public NativeField nativeField;
    public String setterMethodName;
    public Field field;
    public Entity referencedEntity;

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
