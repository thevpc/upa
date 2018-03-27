package net.vpc.upa.impl;

import net.vpc.upa.DynamicField;
import net.vpc.upa.DynamicFieldInfo;
import net.vpc.upa.FieldInfo;
import net.vpc.upa.impl.util.UPAUtils;

public class DefaultDynamicField extends AbstractField implements DynamicField {
    public DefaultDynamicField() {
        super();
    }

    @Override
    public FieldInfo getInfo() {
        DynamicFieldInfo i = new DynamicFieldInfo();
        fillFieldInfo(i);
        return i;
    }

}
