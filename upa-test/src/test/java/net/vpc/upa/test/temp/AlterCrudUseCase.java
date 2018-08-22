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
//    public void crudMixedDocumentsAndEntities() {
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
//        Entity entity = sm.getEntity("SharedClient");
//        entity.addField("extra", null,null, null, new IntType(null,null,true));
//        sm.commitStructureModification();
//
//        Client client=entity.createEntity();
//        int key = entity.nextId();
//        log.info("Next Id is " + key);
//        client.setId(key);
//        client.setFirstName("Hammadi");
//        sm.beginTransaction(TransactionType.REQUIRED);
//        sm.insert(client);
//
//        Document clientByKeyRecord=sm.createQueryBuilder("SharedClient").setId(key).objectToDocument();
//
//        log.info("Found " + clientByKeyRecord);
//        clientByKeyRecord.setString("firstName", "Alia");
//
//        Client clientByKey = entity.getConverter().documentToObject(clientByKeyRecord);
//
//        assertEquals(clientByKey.getFirstName(),"Alia");
//
//        sm.update(clientByKey);
//
//        Document clientUpdatedRecord=sm.createQueryBuilder("SharedClient").setId(key).objectToDocument();
//
//        Assert.assertNotNull(clientUpdatedRecord);
//        Client clientUpdated = entity.getConverter().documentToObject(clientUpdatedRecord);
//        assertEquals(clientUpdated,clientByKey);
//
//        sm.delete(key);
//
//        clientUpdatedRecord=sm.createQueryBuilder("SharedClient").setId(key).objectToDocument();
//
//        Assert.assertNull(clientUpdatedRecord);
//        sm.commitTransaction();
//        s.close();
//
//    }
//
//    @Test
//    public void crudDocuments() {
//        log.fine("********************************************");
//        log.fine("test crud using only Records");
//        log.fine("");
//        log.fine("insert,update, find, delete");
//        log.fine("********************************************");
//        PersistenceUnit sm = UPA.getPersistenceUnit();
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
//        sm.insertRecord("SharedClient", record);
//        Document found0=sm.createQueryBuilder("SharedClient").setId(key).objectToDocument();
//        log.info("Found " + found0);
//        record.setString("firstName", "Alia");
//
//        sm.updateRecord("SharedClient",record);
//
//        Document found=sm.createQueryBuilder("SharedClient").setId(key).objectToDocument();
//
//        Assert.assertNotNull(found);
//        Client foundEntity = entity.getConverter().documentToObject(found);
//        Client recordEntity = entity.getConverter().documentToObject(record);
//        Assert.assertEquals(foundEntity, recordEntity);
//
//        sm.delete(key);
//
//        found=sm.createQueryBuilder("SharedClient").setId(key).objectToDocument();
//
//        Assert.assertNull(found);
//        sm.commitTransaction();
//        s.close();
//
//    }
//
//}
