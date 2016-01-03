package net.vpc.upa.test;

import net.vpc.upa.*;
import net.vpc.upa.test.model.Client;
import net.vpc.upa.test.util.LogUtils;
import net.vpc.upa.TransactionType;
import org.junit.Assert;
import static org.junit.Assert.assertEquals;
import org.junit.Test;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class SimpleCrudUC {
    static{
        LogUtils.prepare();
    }
    private static final java.util.logging.Logger log = java.util.logging.Logger.getLogger(SimpleCrudUC.class.getName());

    @Test
    public void crudMixedRecordsAndEntities() {
        System.setProperty("derby.locks.deadlockTrace","true");
        System.setProperty("derby.locks.monitor", "true");
        log.fine("********************************************");
        log.fine("test crud using Mixed Records And Entities");
        log.fine("");
        log.fine("insert,update, find, delete");
        log.fine("********************************************");
        PersistenceUnit sm = UPA.getPersistenceUnit();

        Session s=sm.openSession();
        sm.beginTransaction(TransactionType.REQUIRED);
        Entity entityManager = sm.getEntity("Client");
        Client c=entityManager.createEntity();
        int key = entityManager.nextId();
        log.info("Next Id is " + key);
        c.setId(key);
        c.setFirstName("Hammadi");

        sm.persist(c);

        Record found0=sm.createQueryBuilder(Client.class).setId(key).getRecord();
        log.info("Found " + found0);
        found0.setString("firstName","Alia");

        Client c2 = entityManager.getBuilder().recordToEntity(found0);

        assertEquals(c2.getFirstName(),"Alia");

        sm.update(c2);

        Client found=sm.createQueryBuilder(Client.class).setId(key).getEntity();

        Assert.assertNotNull(found);
        Assert.assertEquals(found, c2);

        sm.remove(key);

        Record foundRecord=sm.createQueryBuilder(Client.class).setId(key).getRecord();

        Assert.assertNull(foundRecord);
        sm.commitTransaction();
        s.close();

    }

    //@Test
    public void crudRecords() {
        log.fine("********************************************");
        log.fine("test crud using only Records");
        log.fine("");
        log.fine("insert,update, find, delete");
        log.fine("********************************************");
        PersistenceGroup cat = UPA.getPersistenceGroup();
        PersistenceUnit sm = cat.addPersistenceUnit("myschema");
        sm.getProperties().setString(UPA.CONNECTION_STRING, "derby:embedded://testdb;structure=create");
        sm.addEntity(Client.class);
        sm.start();

        Session s=sm.openSession();
        sm.beginTransaction(TransactionType.REQUIRED);
        Entity entityManager = sm.getEntity("Client");
        Record c=entityManager.createRecord();
        int key = entityManager.nextId();
        log.info("Next Id is " + key);
        c.setInt("id", key);
        c.setString("firstName", "Hammadi");

        sm.persist(c);

        Record found0=sm.createQueryBuilder(Client.class).setId(key).getRecord();
        log.info("Found " + found0);
        c.setString("firstName", "Alia");

        sm.update(c);

        Record found=sm.createQueryBuilder(Client.class).setId(key).getRecord();

        Assert.assertNotNull(found);
        Assert.assertEquals(found, c);

        sm.remove(key);

        found=sm.createQueryBuilder(Client.class).setId(key).getRecord();

        Assert.assertNull(found);
        sm.commitTransaction();
        s.close();

    }

//    @Test
    public void crudSimple() {

        log.fine("********************************************");
        log.fine("test crudSimple");
        log.fine("");
        log.fine("insert,update, find, delete");
        log.fine("********************************************");
        PersistenceGroup cat = UPA.getPersistenceGroup();
        PersistenceUnit sm = cat.addPersistenceUnit("myschema");
        sm.getProperties().setString(UPA.CONNECTION_STRING, "derby:embedded://testdb;structure=create");
        sm.addEntity(Client.class);
        sm.start();

        Session s=sm.openSession();
        sm.beginTransaction(TransactionType.REQUIRED);
        Client c=new Client();
        int key = (Integer) sm.getEntity(Client.class).nextId();
        log.info("Next Id is " + key);
        c.setId(key);
        c.setFirstName("Hammadi");

        sm.persist(c);

        Client found0= sm.createQueryBuilder(Client.class).setId(key).getEntity();
        log.info("Found " + found0);
        c.setFirstName("Alia");

        sm.update(c);

        Client found= sm.createQueryBuilder(Client.class).setId(key).getEntity();

        Assert.assertNotNull(found);
        assertEquals(found.getFirstName(),c.getFirstName());
        assertEquals(found.getId(), c.getId());

        sm.remove(key);

        found= sm.createQueryBuilder(Client.class).setId(key).getEntity();

        Assert.assertNull(found);
        sm.commitTransaction();
        s.close();
    }
}
