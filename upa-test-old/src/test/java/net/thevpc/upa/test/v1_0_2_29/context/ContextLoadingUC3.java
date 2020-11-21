package net.thevpc.upa.test.v1_0_2_29.context;

import net.thevpc.upa.PersistenceUnit;
import net.thevpc.upa.Session;
import net.thevpc.upa.exceptions.CurrentSessionNotFoundException;
import net.thevpc.upa.test.v1_0_2_29.model.SharedClient;
import net.thevpc.upa.test.v1_0_2_29.util.PUUtils;
import org.junit.Assert;
import org.junit.BeforeClass;
import org.junit.Test;

import java.util.logging.Logger;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/30/12 4:04 PM
 */
public class ContextLoadingUC3 {

    static Logger log = Logger.getLogger(ContextLoadingUC3.class.getName());

    @BeforeClass
    public static void setup() {
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(ContextLoadingUC3.class);
        pu.addEntity(SharedClient.class);
        pu.start();
    }

    @Test
    public void test2() {
        PersistenceUnit sm = PUUtils.createTestPersistenceUnit(ContextLoadingUC3.class);
        Assert.assertFalse(sessionExists());
        Session s = sm.openSession();
        Assert.assertTrue(sessionExists());
        s.close();
        Assert.assertFalse(sessionExists());
    }



    private boolean sessionExists() {
        PersistenceUnit sm = PUUtils.createTestPersistenceUnit(ContextLoadingUC3.class);
        try {
            sm.getPersistenceGroup().getCurrentSession();
            return true;
        } catch (CurrentSessionNotFoundException exc) {
            return false;
        }

    }
}
