package net.thevpc.upa.impl;

import net.thevpc.upa.Entity;
import net.thevpc.upa.exceptions.UPAException;

import java.util.ArrayList;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/4/13 12:14 AM
 */
class DefaultEntityPrivateChecker {

    private List<String> errors = new ArrayList<String>();
    private List<String> warnings = new ArrayList<String>();
    private Entity defaultEntity;
    protected final Logger log = Logger.getLogger(DefaultEntityPrivateChecker.class.getName());

    public DefaultEntityPrivateChecker(Entity defaultEntity) {
        this.defaultEntity = defaultEntity;
    }

    public void addError(String error) throws UPAException {
        errors.add(error);
        log.log(Level.SEVERE, "[ERROR in Entity {0}.{1}] {2}", new Object[]{defaultEntity.getPersistenceUnit().getName(), defaultEntity.getName(), error});
    }

    public void addWarning(String error) throws UPAException {
        warnings.add(error);
        log.log(Level.WARNING, "[WARNING in Table {0}.{1}] {2}", new Object[]{defaultEntity.getPersistenceUnit().getName(), defaultEntity.getName(), error});
    }

    public void check() throws UPAException {
        if (errors.size() > 0 || warnings.size() > 0) {
            log.log(Level.SEVERE, "Found {0} error(s) and {1} warning(s) when checking {2}.{3} integrity", new Object[]{errors.size(), warnings.size(), defaultEntity.getPersistenceUnit().getName(), defaultEntity.getName()});
            if (errors.size() > 0) {
                throw new UPAException(errors.get(0));
            }
        }
    }
}
