package net.thevpc.upa.test.v1_0_2_29;

import net.thevpc.upa.PersistenceUnit;
import net.thevpc.upa.UPA;
import net.thevpc.upa.test.v1_0_2_29.model.SharedClient;
import net.thevpc.upa.test.v1_0_2_29.util.PUUtils;
import org.junit.BeforeClass;
import org.junit.Test;

import java.util.logging.Logger;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class UnstructuredCrudUseCase {
    static Logger log = Logger.getLogger(UnstructuredCrudUseCase.class.getName());
    private static Business bo;

    @BeforeClass
    public static void setup() {
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(UnstructuredCrudUseCase.class);
        pu.addEntity(SharedClient.class);
        pu.start();
        bo = UPA.makeSessionAware(new Business());
    }

    @Test
    public void process() {
        bo.process();
    }

    public static class Business {

        public void process() {

        }
    }

//    @Test
//    public void crudMixedDocumentsAndEntities() {
//        PersistenceUnit sm = PUUtils.createTestPersistenceUnit(getClass(),"insert,update, find, delete");
//        sm.addEntity(Client.class);
//        Entity e=sm.addEntity(Client.class);
//        e.setName("Titi");
//        e.addField(new DefaultFieldBuilder().setName("toto").setDefaultObject(2).setDataType(new IntType(5,10,true,false)));
//
//        sm.start();
//
//        Session s=sm.openSession();
//        sm.beginTransaction(TransactionType.REQUIRED);
//        Entity entity = sm.getEntity("SharedClient");
//        Client c=entity.getBuilder().createObject();
//        int key = entity.nextId();
//        log.info("Next Id is " + key);
//        c.setId(key);
//        c.setFirstName("Hammadi");
//
//        sm.persist(c);
//
//        FieldNameFilter fieldFilter = new FieldNameFilter("id", "firstName");
//        Document found0=sm.createQueryBuilder(Client.class).setId(key).setFieldFilter(fieldFilter).objectToDocument();
//        log.info("Found " + found0);
//        found0.setString("firstName","Alia");
//
//        Client c2 = entity.getConverter().documentToObject(found0);
//
//        assertEquals(c2.getFirstName(),"Alia");
//
//        sm.update(c2);
//
//        Document found=sm.createQueryBuilder(Client.class).setId(key).setFieldFilter(fieldFilter).objectToDocument();
//
//        Assert.assertNotNull(found);
//        Assert.assertEquals(found, entity.getConverter().objectToDocument(c2));
//
//        sm.delete(key);
//
//        found=sm.createQueryBuilder(Client.class).setId(key).setFieldFilter(fieldFilter).objectToDocument();
//
//        Assert.assertNull(found);
//        sm.commitTransaction();
//        s.close();
//    }
//
//    @Test
//    public void crudDocuments() {
//        log.fine("********************************************");
//        log.fine("test crud using only Records");
//        log.fine("");
//        log.fine("insert,update, find, delete");
//        log.fine("********************************************");
//        PersistenceGroup cat = UPA.getPersistenceGroup();
//        PersistenceUnit sm = cat.addPersistenceUnit("newschema");
//        sm.getParameters().setString(UPA.CONNECTION_STRING, "derby:embedded://testdb/other;structure=create");
//        sm.addEntity(Client.class);
//        sm.start();
//
//        Session s=sm.openSession();
//        sm.beginTransaction(TransactionType.REQUIRED);
//        Entity entity = sm.getEntity("SharedClient");
//        Document record=entity.createDocument();
//        int key = entity.nextId();
//        log.info("Next Id is " + key);
//        record.setInt("id", key);
//        record.setString("firstName", "Hammadi");
//
//        sm.persist("SharedClient", record);
//
//        FieldNameFilter fieldFilter = new FieldNameFilter("id", "firstName");
//        Document foundRecord=sm.createQueryBuilder(Client.class).byId(key).setFieldFilter(fieldFilter).getRecord();
//        log.info("Found " + foundRecord);
//        record.setString("firstName", "Alia");
//
//        sm.update("SharedClient", record);
//
//        Document found=sm.createQueryBuilder(Client.class).byId(key).setFieldFilter(fieldFilter).getRecord();
//
//        Assert.assertNotNull(found);
//        Assert.assertEquals(found, record);
//
//        sm.remove("SharedClient",RemoveOptions.forId(key));
//
//        found=sm.createQueryBuilder(Client.class).byId(key).setFieldFilter(fieldFilter).getRecord();
//
//        Assert.assertNull(found);
//        sm.commitTransaction();
//        s.close();
//
//    }

}
