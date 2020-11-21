package net.thevpc.upa.test.crud;

import junit.framework.Assert;
import net.thevpc.upa.*;
import net.thevpc.upa.test.model.SharedClient;
import net.thevpc.upa.test.util.PUUtils;
import org.junit.BeforeClass;
import org.junit.Test;

import java.util.Arrays;
import java.util.List;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class CrudSelectDistinctUC {

    private static final java.util.logging.Logger log = java.util.logging.Logger.getLogger(CrudSelectDistinctUC.class.getName());
    private static Business bo;

    @BeforeClass
    public static void setup() {
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(CrudSelectDistinctUC.class);
        pu.addEntity(SharedClient.class);
        pu.start();
        bo = UPA.makeSessionAware(new Business());
        bo.init();
    }

    @Test
    public void testQuery1() {
        bo.testQuery2();
    }

    public static class Business {

        public void init() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            //pu.clear();
            //pu.persist(getRefClient1());
            //pu.persist(getRefClient2());
        }

        private SharedClient getRefClient1() {
            SharedClient c = new SharedClient();
            c.setId(1);
            c.setFirstName("emma");
            c.setLastName("community");
            c.setRight("left");
            return c;
        }

        private SharedClient getRefClient2() {
            SharedClient c = new SharedClient();
            c.setId(2);
            c.setFirstName("thomson");
            c.setLastName("community");
            c.setRight("up");
            return c;
        }

        public void testQuery1() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            Query q = pu.createQuery("Select distinct(a) from SharedClient a");
            List<Document> r = q.getDocumentList();
            EntityBuilder b = pu.getEntity(SharedClient.class).getBuilder();
            List<Document> expected = Arrays.asList(
                    b.objectToDocument(getRefClient1()),
                    b.objectToDocument(getRefClient2())
            );
            Assert.assertEquals(expected, r);

        }
        public void testQuery2() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            Query q = pu.createQuery("Select count(distinct(a)) from SharedClient a");
            int r = q.getInteger();
            Assert.assertEquals(2, r);

        }

    }


}
