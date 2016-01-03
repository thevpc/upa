package net.vpc.upa.impl;

import net.vpc.upa.Record;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/28/12 12:45 AM
 */
public abstract class AbstractEntityFactory implements EntityFactory {
    @Override
    public <R> Record getRecord(R entity) {
        return getRecord(entity,false);
    }
}
