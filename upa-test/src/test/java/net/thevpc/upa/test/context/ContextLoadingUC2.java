package net.thevpc.upa.test.context;

import net.thevpc.upa.PersistenceUnit;
import net.thevpc.upa.UPA;
import net.thevpc.upa.test.model.SharedClient;
import net.thevpc.upa.test.util.PUUtils;
import org.junit.BeforeClass;
import org.junit.Test;

import java.util.logging.Logger;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/30/12 4:04 PM
 */
public class ContextLoadingUC2 {

    static Logger log = Logger.getLogger(ContextLoadingUC2.class.getName());

    private static Business bo;
    
    @BeforeClass
    public static void setup() {
        PUUtils.reset();
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(ContextLoadingUC2.class);
        pu.addEntity(SharedClient.class);
        pu.start();
        bo = UPA.makeSessionAware(new Business());
    }
    public static class Business {

        public void test1() {
            PersistenceUnit sm = UPA.getPersistenceUnit();
            sm.close();
        }
    }

    @Test
    public void test1() {
        bo.test1();
    }


}
