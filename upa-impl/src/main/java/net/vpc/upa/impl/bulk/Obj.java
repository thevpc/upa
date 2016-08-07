package net.vpc.upa.impl.bulk;

import net.vpc.upa.PortabilityHint;

/**
 * @author taha.bensalah@gmail.com on 7/6/16.
 */
@PortabilityHint(target = "C#",name = "suppress")
class Obj {

    String name;
    Object value;

    public Obj(String name, Object value) {
        this.name = name;
        this.value = value;
    }

}
