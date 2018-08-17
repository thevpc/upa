package net.vpc.upa.impl.util;

import net.vpc.upa.Field;
import net.vpc.upa.PrimitiveId;
import net.vpc.upa.types.DataType;

import java.util.List;

public class PrimitiveIdImpl implements PrimitiveId{
    public static final int KIND_DEFAULT=1;
    public static final int KIND_PKFK=2;
    public Object value;
    public DataType[] types;
    public Field[] fields;
    public int kind;

//    public PrimitiveIdImpl(Object value, Field[] fields, DataType[] types) {
//        this.value = value;
//        this.fields= fields;
//        this.types = types;
//    }
//    public PrimitiveIdImpl(Object value, Field[] fields) {
//        this.value = value;
//        this.fields= fields;
//        this.types = new DataType[fields.length];
//        for (int i = 0; i < fields.length; i++) {
//            this.types[i]= fields[i].getDataType();
//        }
//    }
    public PrimitiveIdImpl(Object value, List<Field> fields, int kind) {
        this.kind = kind;
        this.value = value;
        this.fields= fields.toArray(new Field[fields.size()]);
        this.types = new DataType[this.fields.length];
        for (int i = 0; i < this.fields.length; i++) {
            this.types[i]= this.fields[i].getDataType();
        }
    }
//    public PrimitiveIdImpl(Object value, List<PrimitiveField> fields, int kind) {
//        this.kind = kind;
//        this.value = value;
//        this.fields= fields.toArray(new Field[fields.size()]);
//        this.types = new DataType[this.fields.length];
//        for (int i = 0; i < this.fields.length; i++) {
//            this.types[i]= this.fields[i].getDataType();
//        }
//    }

    @Override
    public Object getValue(int index) {
        if(index==0){
            if(value instanceof Object[]){
                return ((Object[])value)[index];
            }
            return value;
        }
        return ((Object[])value)[index];
    }

    @Override
    public Object getValue() {
        return value;
    }

    @Override
    public Field getField(int index) {
        return fields[index];
    }

    @Override
    public int size() {
        return fields.length;
    }
}
