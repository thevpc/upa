package net.vpc.upa.test.structure;

import net.vpc.upa.Entity;
import net.vpc.upa.Package;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.UPA;
import net.vpc.upa.test.util.PUUtils;
import org.junit.BeforeClass;
import org.junit.Test;

import java.util.logging.Logger;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class StructurePathUC {

    private static final Logger log = Logger.getLogger(StructurePathUC.class.getName());

    private static Business bo;

    @BeforeClass
    public static void setup() {
        PUUtils.reset();
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(StructurePathUC.class);
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
