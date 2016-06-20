package net.vpc.upa.impl;

import net.vpc.upa.types.DefaultDataType;

/**
 * type to be resolved as Entity (with relation) otherwise will be resolved as
 * Serializable
 *
 * @author vpc
 */
public class SerializableOrManyToOneType extends DefaultDataType implements Cloneable {

    public SerializableOrManyToOneType(String name, Class platformType, boolean nullable) {
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
        return "SerializableOrManyToOneType{" + getPlatformType() + '}';
    }

}
