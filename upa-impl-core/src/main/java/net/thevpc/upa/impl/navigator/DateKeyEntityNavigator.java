package net.thevpc.upa.impl.navigator;

import net.thevpc.upa.Entity;
import net.thevpc.upa.exceptions.UPAException;

import java.util.Date;

public class DateKeyEntityNavigator extends DefaultEntityNavigator {

    public DateKeyEntityNavigator(Entity entity) {
        super(entity);
    }

    public Object  getNewKey()
            throws UPAException {
        return entity.createId(new Date());
    }
}
