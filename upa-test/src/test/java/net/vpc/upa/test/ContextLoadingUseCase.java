package net.vpc.upa.test;

import java.util.List;
import java.util.logging.Logger;

import net.vpc.upa.*;
import net.vpc.upa.exceptions.CurrentSessionNotFoundException;
import net.vpc.upa.impl.util.UPAUtils;
import net.vpc.upa.test.model.Client;
import net.vpc.upa.test.util.LogUtils;
import net.vpc.upa.test.util.PUUtils;
import org.junit.Assert;
import org.junit.Test;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/30/12 4:04 PM
 */
public class ContextLoadingUseCase {

    static {
        LogUtils.prepare();
    }
    static Logger log = Logger.getLogger(ContextLoadingUseCase.class.getName());

    @Test
    public void test1() {
        PersistenceUnit sm = PUUtils.createTestPersistenceUnit(ContextLoadingUseCase.class);
        sm.close();
    }

    @Test
    public void test2() {
        PersistenceUnit sm = PUUtils.createTestPersistenceUnit(ContextLoadingUseCase.class);
        Assert.assertFalse(sessionExists());
        Session s = sm.openSession();
        Assert.assertTrue(sessionExists());
        s.close();
        Assert.assertFalse(sessionExists());
    }

    @Test
    public void test3() {
        PersistenceUnit sm = PUUtils.createTestPersistenceUnit(ContextLoadingUseCase.class);
        sm.addEntity(Client.class);
        sm.start();
        Session s = sm.openSession();
        List list= sm.createQueryBuilder("Client").getResultList();
        log.info("Find : "+list);
        s.close();
    }

    private boolean sessionExists() {
        PersistenceUnit sm = PUUtils.createTestPersistenceUnit(ContextLoadingUseCase.class);
        try {
            sm.getPersistenceGroup().getCurrentSession();
            return true;
        } catch (CurrentSessionNotFoundException exc) {
            return false;
        }

    }
}
