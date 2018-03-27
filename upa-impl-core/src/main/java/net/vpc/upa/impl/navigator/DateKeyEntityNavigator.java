package net.vpc.upa.impl.navigator;

import net.vpc.upa.Entity;
import net.vpc.upa.exceptions.UPAException;

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
