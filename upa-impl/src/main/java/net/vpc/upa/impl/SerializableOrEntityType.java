package net.vpc.upa.impl;

import net.vpc.upa.types.DataType;

/**
 * type to be resolved as Entity (with relation) otherwise will be resolved as
 * Serializable
 *
 * @author vpc
 */
public class SerializableOrEntityType extends DataType implements Cloneable {

//    public EntityType(String name, Class platformType, boolean updatable) {
//        super(name, platformType);
//        this.updatable = updatable;
//    }
    public SerializableOrEntityType(String name, Class platformType, boolean nullable) {
        super(name, platformType, nullable);
    }
    
    public Class getEntityType(){
        return getPlatformType();
    }

    @Override
    public Class getPlatformType() {
        return super.getPlatformType();
    }
    

    @Override
    public Object clone() {
        return super.clone();
    }

    @Override
    public String toString() {
        return "SerializableOrEntityType{" + getPlatformType() + '}';
    }

}
