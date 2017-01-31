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
    public void crudMixedDocumentsAndEntities() {
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

        Document found0 = sm.createQueryBuilder(Client.class).byId(key).getDocument();
        log.info("Found " + found0);
        found0.setString("firstName", "Alia");

        Client c2 = entityManager.getBuilder().documentToObject(found0);

        assertEquals(c2.getFirstName(), "Alia");

        sm.update(c2);

        Document found = sm.createQueryBuilder(Client.class).byId(key).getDocument();

        Assert.assertNotNull(found);
        assertEquals(entityManager.getBuilder().documentToObject(found), c2);

        sm.remove(key);

        found = sm.createQueryBuilder(Client.class).byId(key).getDocument();

        Assert.assertNull(found);
        sm.commitTransaction();
        s.close();

    }

//    @Test
    public void crudDocuments() {
        log.fine("********************************************");
        log.fine("test crud using only Documents");
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
        Document document = entityManager.createDocument();
        int id = entityManager.nextId();
        log.info("Next Id is " + id);
        document.setInt("id", id);
        document.setString("firstName", "Hammadi");

        sm.persist("Client", document);

        Document found0 = sm.createQueryBuilder("Client").byId(id).getDocument();
        log.info("Found " + found0);
        document.setString("firstName", "Alia");

        sm.update("Client", document);

        Document found = sm.createQueryBuilder("Client").byId(id).getDocument();
        found.retainAll(new HashSet<String>(Arrays.asList("id", "firstName")));
        Assert.assertNotNull(found);
        Assert.assertEquals(found.getString("firstName"), document.getString("firstName"));

        sm.remove("Client", RemoveOptions.forId(id));

        found = sm.createQueryBuilder("Client").byId(id).getDocument();

        Assert.assertNull(found);
        sm.commitTransaction();
        s.close();

    }
}
