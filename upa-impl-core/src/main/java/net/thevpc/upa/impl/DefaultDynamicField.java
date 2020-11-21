package net.thevpc.upa.impl;

import net.thevpc.upa.DynamicField;
import net.thevpc.upa.DynamicFieldInfo;
import net.thevpc.upa.FieldInfo;

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
