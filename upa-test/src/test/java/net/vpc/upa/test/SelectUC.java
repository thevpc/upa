package net.vpc.upa.test;

import java.util.List;
import net.vpc.upa.*;
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
        bo.testQuery();
//        bo.testPrimitiveReferences();
    }

    public static class Business {

        public void testQuery() {
            PersistenceUnit pu = UPA.getPersistenceGroup().getPersistenceUnit();
//            Query q = pu.createQuery("Select a from Client a where a.firstName like :v").setParameter("v", "%mm%");
            Query q = pu.createQuery("Select a from Client a where a.firstName like :v or a.firstName like :v  or a.firstName like :v")
                    .setParameter("v", "%mm%")
                    ;
            List<Record> r = q.getRecordList();
            for (Record record : r) {
                System.out.println(r);
            }
        }
    }

    //@Test
//    public void crudMixedRecordsAndEntities() {
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
