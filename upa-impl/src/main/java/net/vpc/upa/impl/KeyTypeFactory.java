package net.vpc.upa.impl;

import net.vpc.upa.types.Date;
import net.vpc.upa.types.DateTime;
import net.vpc.upa.types.Month;
import net.vpc.upa.types.Year;
import net.vpc.upa.Key;
import net.vpc.upa.types.Time;

import java.sql.Timestamp;
import java.util.Arrays;
import java.util.HashSet;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/27/12 1:51 AM
 */
public class KeyTypeFactory implements KeyFactory {
    public static final HashSet<Class> ACCEPTED_TYPES = new HashSet<Class>(
            Arrays.asList(
                    String.class,
                    java.util.Date.class,
                    java.sql.Date.class,
                    Timestamp.class,
                    java.sql.Time.class,
                    DateTime.class,
                    Date.class,
                    Month.class,
                    Time.class,
                    Year.class,
                    Integer.class,
                    Integer.TYPE,
                    Short.class,
                    Short.TYPE,
                    Long.class,
                    Long.TYPE,
                    Double.class,
                    Double.TYPE,
                    Float.class,
                    Float.TYPE
            )
    );
    private Class keyType;
    public KeyTypeFactory(Class keyType) {
        if(!ACCEPTED_TYPES.contains(keyType)){
            throw new IllegalArgumentException("No Supported");
        }
        this.keyType = keyType;
    }

    public Class getIdType() {
        return keyType;
    }

    @Override
    public Key createKey(Object... idValues) {
        if(idValues==null){
            return null;
        }
        return new DefaultKey(idValues);
    }

    @Override
    public Object createId(Object... idValues) {
        if(idValues==null){
            return null;
        }
        return idValues[0];
    }

    @Override
    public Object getId(Key unstructuredKey) {
        if(unstructuredKey==null){
            return null;
        }
        return createId(unstructuredKey.getValue());
    }

    @Override
    public Key getKey(Object id) {
        if(id==null){
            return null;
        }
        return createKey(id);
    }
}
