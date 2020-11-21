package net.thevpc.upa.impl.bulk;

import net.thevpc.upa.PortabilityHint;

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
