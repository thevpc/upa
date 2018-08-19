package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.Entity;
import net.vpc.upa.Field;
import net.vpc.upa.impl.persistence.NativeField;
import net.vpc.upa.impl.upql.BindingId;

/**
* Created by vpc on 1/4/14.
*/
class ResultFieldParseData {

    public ResultFieldFamily columnFamily;
    public int dbIndex;
    public BindingId binding;
    public boolean read;
    public String name;
    public NativeField nativeField;
    public Field field;
    public Entity parentBindingReferrer;
//    public ResultFieldParseDataSetter setter;

    @Override
    public String toString() {
        StringBuilder sb=new StringBuilder();
        if(nativeField!=null){
            sb.append(nativeField.getBindingId());
        }else{
            sb.append(name);
        }
        sb.append(" @").append(dbIndex);
        return sb.toString();
    }
}
