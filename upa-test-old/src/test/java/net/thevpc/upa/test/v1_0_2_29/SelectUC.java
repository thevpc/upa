package net.thevpc.upa.test.v1_0_2_29;

import junit.framework.Assert;
import net.thevpc.upa.test.v1_0_2_29.model.SharedClient;
import net.thevpc.upa.test.v1_0_2_29.util.PUUtils;
import org.junit.BeforeClass;
import org.junit.Test;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class SelectUC {

    private static final java.util.logging.Logger log = java.util.logging.Logger.getLogger(SelectUC.class.getName());
    private static Business bo;

    @BeforeClass
    public static void setup() {
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(SelectUC.class);
        pu.addEntity(SharedClient.class);
        pu.start();
        bo = UPA.makeSessionAware(new Business());
        bo.init();
    }

    @Test
    public void testQuery1() {
        bo.testQuery1();
    }

    @Test
    public void testQuery2() {
        bo.testQuery2();
    }

    @Test
    public void testQuery3() {
        bo.testQuery3();
    }

    @Test
    public void testQuery4() {
        bo.testQuery4();
    }

    @Test
    public void testQuery5() {
        bo.testQuery5();
    }

    public static class Business {

        public void init() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            pu.clear(null, null);
            pu.persist(getRefClient1());
            pu.persist(getRefClient2());
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
            Query q = pu.createQuery("Select a from SharedClient a order by a.firstName");
            List<Record> r = q.getRecordList();
            EntityBuilder b = pu.getEntity(SharedClient.class).getBuilder();
            List<Record> expected = Arrays.asList(
                    b.objectToRecord(getRefClient1()),
                    b.objectToRecord(getRefClient2())
            );
            Assert.assertEquals(expected, r);

        }

        public void testQuery2() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            Query q = pu.createQuery("Select a from SharedClient a order by a.firstName");
            List<SharedClient> r = q.getResultList();
            List<SharedClient> expected = Arrays.asList(
                    (getRefClient1()),
                    (getRefClient2())
            );
            Assert.assertEquals(expected, r);

        }

        public void testQuery3() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
//            Query q = pu.createQuery("Select a from Client a where a.firstName like :v").setParameter("v", "%mm%");
            Query q = pu.createQuery("Select a. `right` from SharedClient a order by a. `right`");
            List<Record> found = q.getRecordList();
            EntityBuilder b = pu.getEntity(SharedClient.class).getBuilder();
            List<Record> expected=new ArrayList<>();

            Record d = b.createRecord();
            d.setString("right", "left");
            expected.add(d);

            d = b.createRecord();
            d.setString("right", "up");
            expected.add(d);

            Assert.assertEquals(expected, found);
        }


        public void testQuery4() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
//            Query q = pu.createQuery("Select a from Client a where a.firstName like :v").setParameter("v", "%mm%");
            Query q = pu.createQuery("Select a from SharedClient a where a.firstName like :v or a.firstName like :v  or a.firstName like :v")
                    .setParameter("v", "%mm%");
            List<Record> r = q.getRecordList();
            List<Record> expected = Arrays.asList(pu.getEntity(SharedClient.class).getBuilder().objectToRecord(getRefClient1()));
            Assert.assertEquals(expected, r);

        }

        public void testQuery5() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
//            Query q = pu.createQuery("Select a from Client a where a.firstName like :v").setParameter("v", "%mm%");
            Query q = pu.createQuery("Select a. `right` from SharedClient a order by a.id desc");
            List<Object> r = q.getValueList(0);
            List<String> expected = new ArrayList<>();
            expected.add("up");
            expected.add("left");
            Assert.assertEquals(expected, r);
        }
    }


}
