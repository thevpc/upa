//package net.vpc.upa.test;
//
//import net.vpc.upa.types.IntType;
//import net.vpc.upa.*;
//import net.vpc.upa.test.model.Client;
//import net.vpc.upa.test.util.LogUtils;
//import net.vpc.upa.TransactionType;
//import org.junit.Assert;
//import static org.junit.Assert.*;
//import org.junit.Test;
//import org.slf4j.Logger;
//import org.slf4j.LoggerFactory;
//
///**
// * @author Taha BEN SALAH <taha.bensalah@gmail.com>
// * @creationdate 9/16/12 10:02 PM
// */
//public class AlterCrudUseCase {
//    static{
//        LogUtils.prepare();
//    }
//    static Logger log= LoggerFactory.getLogger(AlterCrudUseCase.class);
//
//    @Test
//    public void crudMixedRecordsAndEntities() {
//        log.fine("********************************************");
//        log.fine("test crud using Mixed Records And Entities");
//        log.fine("");
//        log.fine("insert,update, find, delete");
//        log.fine("********************************************");
//        PersistenceUnit sm = UPA.getPersistenceUnit();
//
//        Session s=sm.openSession();
//
//        sm.beginStructureModification();
//        Entity entityManager = sm.getEntity("Client");
//        entityManager.addField("extra", null,null, null, new IntType(null,null,true));
//        sm.commitStructureModification();
//
//        Client client=entityManager.createEntity();
//        int key = entityManager.nextId();
//        log.info("Next Id is " + key);
//        client.setId(key);
//        client.setFirstName("Hammadi");
//        sm.beginTransaction(TransactionType.REQUIRED);
//        sm.insert(client);
//
//        Record clientByKeyRecord=sm.createQueryBuilder("Client").setId(key).getRecord();
//
//        log.info("Found " + clientByKeyRecord);
//        clientByKeyRecord.setString("firstName", "Alia");
//
//        Client clientByKey = entityManager.getConverter().recordToEntity(clientByKeyRecord);
//
//        assertEquals(clientByKey.getFirstName(),"Alia");
//
//        sm.update(clientByKey);
//
//        Record clientUpdatedRecord=sm.createQueryBuilder("Client").setId(key).getRecord();
//
//        Assert.assertNotNull(clientUpdatedRecord);
//        Client clientUpdated = entityManager.getConverter().recordToEntity(clientUpdatedRecord);
//        assertEquals(clientUpdated,clientByKey);
//
//        sm.delete(key);
//
//        clientUpdatedRecord=sm.createQueryBuilder("Client").setId(key).getRecord();
//
//        Assert.assertNull(clientUpdatedRecord);
//        sm.commitTransaction();
//        s.close();
//
//    }
//
//    @Test
//    public void crudRecords() {
//        log.fine("********************************************");
//        log.fine("test crud using only Records");
//        log.fine("");
//        log.fine("insert,update, find, delete");
//        log.fine("********************************************");
//        PersistenceUnit sm = UPA.getPersistenceUnit();
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
//        Record found0=sm.createQueryBuilder("Client").setId(key).getRecord();
//        log.info("Found " + found0);
//        record.setString("firstName", "Alia");
//
//        sm.updateRecord("Client",record);
//
//        Record found=sm.createQueryBuilder("Client").setId(key).getRecord();
//
//        Assert.assertNotNull(found);
//        Client foundEntity = entityManager.getConverter().recordToEntity(found);
//        Client recordEntity = entityManager.getConverter().recordToEntity(record);
//        Assert.assertEquals(foundEntity, recordEntity);
//
//        sm.delete(key);
//
//        found=sm.createQueryBuilder("Client").setId(key).getRecord();
//
//        Assert.assertNull(found);
//        sm.commitTransaction();
//        s.close();
//
//    }
//
//}
