package net.thevpc.upa.test.v1_0_2_29.context;

import net.thevpc.upa.Entity;
import net.thevpc.upa.Package;
import net.thevpc.upa.PersistenceUnit;
import net.thevpc.upa.UPA;
import net.thevpc.upa.test.v1_0_2_29.util.PUUtils;
import org.junit.BeforeClass;
import org.junit.Test;

import java.util.logging.Logger;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class PathUC {

    private static final Logger log = Logger.getLogger(PathUC.class.getName());

    private static Business bo;

    @BeforeClass
    public static void setup() {
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(PathUC.class);
        //pu.addEntity(Data.class);
        pu.start();
        bo = UPA.makeSessionAware(new Business());
    }

    @Test
    public void process() {
        bo.process();

    }

    public static class Business {

        public void process() {
            PersistenceUnit sm = PUUtils.createTestPersistenceUnit(getClass());
            for (Entity entity : sm.getEntities()) {
                System.out.print(entity + " : " + entity.getParent());
            }
            for (Package pck : sm.getPackages()) {
                System.out.print(pck + " : " + pck.getName() + " : " + pck.getPath());
            }
        }
    }
}
