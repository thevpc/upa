package net.vpc.upa.test;

import net.vpc.upa.test.util.PUUtils;
import net.vpc.upa.types.IntType;
import net.vpc.upa.*;
import net.vpc.upa.filters.FieldNameFilter;
import net.vpc.upa.test.model.Client;
import net.vpc.upa.test.util.LogUtils;
import net.vpc.upa.TransactionType;
import org.junit.Assert;
import org.junit.Test;

import java.util.logging.Logger;

import static org.junit.Assert.assertEquals;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class UnstructuredCrudUseCase {
    static Logger log= Logger.getLogger(UnstructuredCrudUseCase.class.getName());

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
//        Entity entityManager = sm.getEntity("Client");
//        Client c=entityManager.getBuilder().createObject();
//        int key = entityManager.nextId();
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
//        Client c2 = entityManager.getConverter().documentToObject(found0);
//
//        assertEquals(c2.getFirstName(),"Alia");
//
//        sm.update(c2);
//
//        Document found=sm.createQueryBuilder(Client.class).setId(key).setFieldFilter(fieldFilter).objectToDocument();
//
//        Assert.assertNotNull(found);
//        Assert.assertEquals(found, entityManager.getConverter().objectToDocument(c2));
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
//        Entity entityManager = sm.getEntity("Client");
//        Document record=entityManager.createDocument();
//        int key = entityManager.nextId();
//        log.info("Next Id is " + key);
//        record.setInt("id", key);
//        record.setString("firstName", "Hammadi");
//
//        sm.persist("Client", record);
//
//        FieldNameFilter fieldFilter = new FieldNameFilter("id", "firstName");
//        Document foundRecord=sm.createQueryBuilder(Client.class).byId(key).setFieldFilter(fieldFilter).getDocument();
//        log.info("Found " + foundRecord);
//        record.setString("firstName", "Alia");
//
//        sm.update("Client", record);
//
//        Document found=sm.createQueryBuilder(Client.class).byId(key).setFieldFilter(fieldFilter).getDocument();
//
//        Assert.assertNotNull(found);
//        Assert.assertEquals(found, record);
//
//        sm.remove("Client",RemoveOptions.forId(key));
//
//        found=sm.createQueryBuilder(Client.class).byId(key).setFieldFilter(fieldFilter).getDocument();
//
//        Assert.assertNull(found);
//        sm.commitTransaction();
//        s.close();
//
//    }

}
