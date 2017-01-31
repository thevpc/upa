package net.vpc.upa.test;

import java.util.Arrays;
import java.util.List;

import junit.framework.Assert;
import net.vpc.upa.*;
import net.vpc.upa.filters.EntityFilters;
import net.vpc.upa.test.model.Client;
import net.vpc.upa.test.util.LogUtils;
import net.vpc.upa.Query;
import net.vpc.upa.test.util.PUUtils;
import org.junit.Test;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class SelectUC {

    static {
        LogUtils.prepare();
    }
    private static final java.util.logging.Logger log = java.util.logging.Logger.getLogger(SelectUC.class.getName());

    @Test
    public void testSelect() {
        String puId = getClass().getName();
        log.fine("********************************************");
        log.fine(" " + puId);
        log.fine("********************************************");
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(getClass());
        pu.addEntity(Client.class);
        pu.start();

        Business bo = UPA.makeSessionAware(new Business());
        bo.init();
        bo.testQuery2();
    }

    public static class Business {

        public void init() {
            PersistenceUnit pu = UPA.getPersistenceGroup().getPersistenceUnit();
//            Query q = pu.createQuery("Select a from Client a where a.firstName like :v").setParameter("v", "%mm%");
            pu.clear(EntityFilters.all(),null);
            Client c = getRefClient();
            pu.persist(c);
        }

        private Client getRefClient() {
            Client c=new Client();
            c.setId(1);
            c.setFirstName("emma");
            c.setLastName("community");
            c.setRight("left");
            return c;
        }

        public void testQuery() {
            PersistenceUnit pu = UPA.getPersistenceGroup().getPersistenceUnit();
//            Query q = pu.createQuery("Select a from Client a where a.firstName like :v").setParameter("v", "%mm%");
            Query q = pu.createQuery("Select a from Client a where a.firstName like :v or a.firstName like :v  or a.firstName like :v")
                    .setParameter("v", "%mm%")
                    ;
            List<Document> r = q.getDocumentList();
            Assert.assertEquals(r, Arrays.asList(pu.getEntity(Client.class).getBuilder().objectToDocument(getRefClient())));
        }
        public void testQuery2() {
            PersistenceUnit pu = UPA.getPersistenceGroup().getPersistenceUnit();
//            Query q = pu.createQuery("Select a from Client a where a.firstName like :v").setParameter("v", "%mm%");
            Query q = pu.createQuery("Select a. `right` from Client a");
            List<Document> r = q.getDocumentList();
            Document er = pu.getEntity(Client.class).getBuilder().createDocument();
            er.setString("right","left");
            Assert.assertEquals(r, Arrays.asList(er));
        }
    }

    //@Test
//    public void crudMixedDocumentsAndEntities() {
//        log.fine("********************************************");
//        log.fine("test select Entities");
//        log.fine("");
//        log.fine("insert,update, find, delete");
//        log.fine("********************************************");
//        PersistenceUnit sm = UPA.getPersistenceUnit();
//
//        Session s = sm.openSession();
//
//        sm.beginStructureModification();
//        Entity entityManager = sm.getEntity("Client");
//
//        Client client = entityManager.createEntity();
//        int key = entityManager.nextId();
//        log.info("Next Id is " + key);
//        client.setId(key);
//        client.setFirstName("Hammadi");
//        sm.beginTransaction(TransactionType.REQUIRED);
//        sm.insert(client);
//        final Query q = sm.createQuery("Select u from Client u where u.firstName like :v");
//        q.setParameter("v", "%mm%");
//        final List<Client> found = q.getEntityList();
//        assertEquals(found.size(), 1);
//
//        sm.delete(found.get(0).getId());
//        sm.commitTransaction();
//        s.close();
//
//    }
}
