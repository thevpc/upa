package net.thevpc.upa.test.context;

import java.util.List;
import java.util.logging.Logger;

import net.thevpc.upa.PersistenceUnit;
import net.thevpc.upa.Session;
import net.thevpc.upa.UPA;
import net.thevpc.upa.test.model.SharedClient;
import net.thevpc.upa.test.util.PUUtils;
import org.junit.BeforeClass;
import org.junit.Test;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/30/12 4:04 PM
 */
public class ContextLoadingUC {

    static Logger log = Logger.getLogger(ContextLoadingUC.class.getName());

    @BeforeClass
    public static void setup() {
        PUUtils.reset();
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(ContextLoadingUC.class);
        pu.addEntity(SharedClient.class);
        pu.start();
    }
    @Test
    public void test3() {
        PersistenceUnit sm = UPA.getPersistenceUnit();
        Session s = sm.openSession();
        List list= sm.createQueryBuilder("SharedClient").getResultList();
        log.info("Find : "+list);
        s.close();
    }
}
