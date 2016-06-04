//package net.vpc.upa.test;
//
//import net.vpc.upa.types.IntType;
//import net.vpc.upa.*;
//import net.vpc.upa.filters.FieldNameFilter;
//import net.vpc.upa.test.model.Client;
//import net.vpc.upa.test.util.LogUtils;
//import net.vpc.upa.TransactionType;
//import org.junit.Assert;
//import org.junit.Test;
//import org.slf4j.Logger;
//import org.slf4j.LoggerFactory;
//
//import static org.junit.Assert.assertEquals;
//
///**
// * @author Taha BEN SALAH <taha.bensalah@gmail.com>
// * @creationdate 9/16/12 10:02 PM
// */
//public class UnstructuredCrudUseCase {
//    static{
//        LogUtils.prepare();
//    }
//    static Logger log= LoggerFactory.getLogger(UnstructuredCrudUseCase.class);
//
//    @Test
//    public void crudMixedRecordsAndEntities() {
//        log.fine("********************************************");
//        log.fine("test crud using Mixed Records And Entities");
//        log.fine("");
//        log.fine("insert,update, find, delete");
//        log.fine("********************************************");
//        PersistenceUnit sm = UPA.getPersistenceUnit("noconfig");
//        sm.getParameters().setString(UPA.CONNECTION_STRING, "derby:embedded://testdb/other;structure=create");
//        sm.addEntity(Client.class);
//        Entity e=sm.addEntity(Client.class);
//        e.setName("Titi");
//        e.addField("toto", null, null, 2, new IntType(5,10,true));
//
//        sm.start();
//
//        Session s=sm.openSession();
//        sm.beginTransaction(TransactionType.REQUIRED);
//        Entity entityManager = sm.getEntity("Client");
//        Client c=entityManager.createEntity();
//        int key = entityManager.nextId();
//        log.info("Next Id is " + key);
//        c.setId(key);
//        c.setFirstName("Hammadi");
//
//        sm.insert(c);
//
//        FieldNameFilter fieldFilter = new FieldNameFilter("id", "firstName");
//        Record found0=sm.createQueryBuilder(Client.class).setId(key).setFieldFilter(fieldFilter).getRecord();
//        log.info("Found " + found0);
//        found0.setString("firstName","Alia");
//
//        Client c2 = entityManager.getConverter().recordToObject(found0);
//
//        assertEquals(c2.getFirstName(),"Alia");
//
//        sm.update(c2);
//
//        Record found=sm.createQueryBuilder(Client.class).setId(key).setFieldFilter(fieldFilter).getRecord();
//
//        Assert.assertNotNull(found);
//        Assert.assertEquals(found, entityManager.getConverter().objectToRecord(c2));
//
//        sm.delete(key);
//
//        found=sm.createQueryBuilder(Client.class).setId(key).setFieldFilter(fieldFilter).getRecord();
//
//        Assert.assertNull(found);
//        sm.commitTransaction();
//        s.close();
//    }
//
//    @Test
//    public void crudRecords() {
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
//        Entity entityManager = sm.getEntity("Client");
//        Record record=entityManager.createRecord();
//        int key = entityManager.nextId();
//        log.info("Next Id is " + key);
//        record.setInt("id", key);
//        record.setString("firstName", "Hammadi");
//
//        sm.insertRecord("Client", record);
//
//        FieldNameFilter fieldFilter = new FieldNameFilter("id", "firstName");
//        Record foundRecord=sm.createQueryBuilder(Client.class).setId(key).setFieldFilter(fieldFilter).getRecord();
//        log.info("Found " + foundRecord);
//        record.setString("firstName", "Alia");
//
//        sm.updateRecord("Client", record);
//
//        Record found=sm.createQueryBuilder(Client.class).setId(key).setFieldFilter(fieldFilter).getRecord();
//
//        Assert.assertNotNull(found);
//        Assert.assertEquals(found, record);
//
//        sm.delete(key);
//
//        found=sm.createQueryBuilder(Client.class).setId(key).setFieldFilter(fieldFilter).getRecord();
//
//        Assert.assertNull(found);
//        sm.commitTransaction();
//        s.close();
//
//    }
//
//}
