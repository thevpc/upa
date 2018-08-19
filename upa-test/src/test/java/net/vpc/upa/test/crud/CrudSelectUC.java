package net.vpc.upa.test.crud;

import junit.framework.Assert;
import net.vpc.upa.*;
import net.vpc.upa.test.model.SharedClient;
import net.vpc.upa.test.util.PUUtils;
import org.junit.BeforeClass;
import org.junit.Test;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class CrudSelectUC {

    private static final java.util.logging.Logger log = java.util.logging.Logger.getLogger(CrudSelectUC.class.getName());
    private static Business bo;

    @BeforeClass
    public static void setup() {
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(CrudSelectUC.class);
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

    @Test
    public void testQuery6() {
        bo.testQuery6();
    }

    @Test
    public void testQuery7() {
        bo.testQuery7();
    }

    public static class Business {

        public void init() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            pu.clear();
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
            List<Document> found = q.getDocumentList();
            EntityBuilder b = pu.getEntity(SharedClient.class).getBuilder();
            List<Document> expected=new ArrayList<>();

            Document d = b.createDocument();
            d.setString("right", "left");
            expected.add(d);

            d = b.createDocument();
            d.setString("right", "up");
            expected.add(d);

            Assert.assertEquals(expected, found);
        }


        public void testQuery4() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
//            Query q = pu.createQuery("Select a from Client a where a.firstName like :v").setParameter("v", "%mm%");
            Query q = pu.createQuery("Select a from SharedClient a where a.firstName like :v or a.firstName like :v  or a.firstName like :v")
                    .setParameter("v", "%mm%");
            List<Document> r = q.getDocumentList();
            List<Document> expected = Arrays.asList(pu.getEntity(SharedClient.class).getBuilder().objectToDocument(getRefClient1()));
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
        public void testQuery6() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
//            Query q = pu.createQuery("Select a from Client a where a.firstName like :v").setParameter("v", "%mm%");
            Query q = pu.createQuery("Select a. `right` from SharedClient a where exists (Select 1 from SharedClient b) order by a.id desc");
            List<Object> r = q.getValueList(0);
            r.size();
            List<String> expected = new ArrayList<>();
            expected.add("up");
            expected.add("left");
            Assert.assertEquals(expected, r);
        }
        public void testQuery7() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
//            Query q = pu.createQuery("Select a from Client a where a.firstName like :v").setParameter("v", "%mm%");
            Query q = pu.createQuery("Select a.id id, a.firstName name from SharedClient a order by Id");
            List<NamedId> r = q.getResultList(NamedId.class);
            r.size();
            Assert.assertEquals(2, r.size());
            System.out.println(r);
            List<NamedId> expected = new ArrayList<>();
            expected.add(new NamedId(1,"emma"));
            expected.add(new NamedId(2,"thomson"));
            Assert.assertEquals(expected, r);
        }
    }


}
