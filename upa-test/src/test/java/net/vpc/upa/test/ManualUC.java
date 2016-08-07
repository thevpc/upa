package net.vpc.upa.test;

import net.vpc.upa.types.IntType;
import net.vpc.upa.*;
import net.vpc.upa.test.model.Client;
import net.vpc.upa.test.util.LogUtils;
import net.vpc.upa.TransactionType;
import org.junit.Assert;
import org.junit.Test;

import java.util.Arrays;
import java.util.HashSet;

import static org.junit.Assert.assertEquals;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class ManualUC {

    static {
        LogUtils.prepare();
    }
    private static final java.util.logging.Logger log = java.util.logging.Logger.getLogger(ManualUC.class.getName());

    @Test
    public void crudMixedRecordsAndEntities() {
        log.fine("********************************************");
        log.fine("test ManualCreatePersistenceGroupUseCase");
        log.fine("");
        log.fine("********************************************");
        PersistenceGroup cat = UPA.getContext().addPersistenceGroup("mycat");
        PersistenceUnit sm = cat.addPersistenceUnit("manual");
//        sm.getProperties().setString(UPA.CONNECTION_STRING, "derby:embedded://testdb/manual1;structure=create");
        sm.getProperties().setString(UPA.CONNECTION_STRING, "mysql:default://localhost/upatest;structure=create;userName=root;password=password");
        sm.addEntity(Client.class);
        sm.start();

        Session s = sm.openSession();

        sm.beginStructureModification();
        Entity entityManager = sm.getEntity("Client");
        entityManager.addField("extra", null, null, null, null,IntType.DEFAULT,-1);
        sm.commitStructureModification();

        Client c = entityManager.createObject();
        int key = entityManager.nextId();
        log.info("Next Id is " + key);
        c.setId(key);
        c.setFirstName("Hammadi");
        sm.beginTransaction(TransactionType.REQUIRED);
        sm.persist(c);

        Record found0 = sm.createQueryBuilder(Client.class).byId(key).getRecord();
        log.info("Found " + found0);
        found0.setString("firstName", "Alia");

        Client c2 = entityManager.getBuilder().recordToObject(found0);

        assertEquals(c2.getFirstName(), "Alia");

        sm.update(c2);

        Record found = sm.createQueryBuilder(Client.class).byId(key).getRecord();

        Assert.assertNotNull(found);
        assertEquals(entityManager.getBuilder().recordToObject(found), c2);

        sm.remove(key);

        found = sm.createQueryBuilder(Client.class).byId(key).getRecord();

        Assert.assertNull(found);
        sm.commitTransaction();
        s.close();

    }

//    @Test
    public void crudRecords() {
        log.fine("********************************************");
        log.fine("test crud using only Records");
        log.fine("");
        log.fine("insert,update, find, delete");
        log.fine("********************************************");
        PersistenceGroup cat = UPA.getContext().addPersistenceGroup("mycat2");
        UPA.getContext().setPersistenceGroup("mycat2");
        PersistenceUnit sm = cat.addPersistenceUnit("myschema");
        sm.getProperties().setString(UPA.CONNECTION_STRING, "derby:embedded://testdb/manual2;structure=create");
        sm.addEntity(Client.class);
        sm.start();

        Session s = sm.openSession();
        sm.beginTransaction(TransactionType.REQUIRED);
        Entity entityManager = sm.getEntity("Client");
        Record record = entityManager.createRecord();
        int id = entityManager.nextId();
        log.info("Next Id is " + id);
        record.setInt("id", id);
        record.setString("firstName", "Hammadi");

        sm.persist("Client", record);

        Record found0 = sm.createQueryBuilder("Client").byId(id).getRecord();
        log.info("Found " + found0);
        record.setString("firstName", "Alia");

        sm.update("Client", record);

        Record found = sm.createQueryBuilder("Client").byId(id).getRecord();
        found.retainAll(new HashSet<String>(Arrays.asList("id", "firstName")));
        Assert.assertNotNull(found);
        Assert.assertEquals(found.getString("firstName"), record.getString("firstName"));

        sm.remove("Client", RemoveOptions.forId(id));

        found = sm.createQueryBuilder("Client").byId(id).getRecord();

        Assert.assertNull(found);
        sm.commitTransaction();
        s.close();

    }
}
