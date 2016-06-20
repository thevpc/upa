package net.vpc.upa.impl.persistence;

import net.vpc.upa.Entity;
import net.vpc.upa.Field;

/**
* Created by vpc on 1/4/14.
*/
class FieldInfo {

    public TypeInfo typeInfo;
    public int index;
    public String name;
    public NativeField nativeField;
    public String setterMethodName;
    public Field field;
    public Entity referencedEntity;
}
