//package net.vpc.upa.test;
//
//import net.vpc.upa.*;
//import net.vpc.upa.config.Entity;
//import net.vpc.upa.config.*;
//import net.vpc.upa.config.Field;
//import net.vpc.upa.config.Sequence;
//import net.vpc.upa.exceptions.UPAException;
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
//public class GeneratedValueUseCase {
//
//    static {
//        LogUtils.prepare();
//    }
//    static Logger log = LoggerFactory.getLogger(GeneratedValueUseCase.class);
//
//    @Entity(entityType = Client.class, name = "GeneratedPerson")
//    @NoAutoConfig
//    public static final class Person {
//        //redefine name field to add constraints on length
//
//        @Sequence
//        private int id;
//        
//        @Field(max = "255")
//        private String firstName;
//        
//        @Field(type=String.class)
//        @net.vpc.upa.config.Formula(value="concat(firstName,' ',lastName)")
//        private FieldDesc fullName;
//        
//        //add new field desc
//        @Field(type = String.class)
//        private FieldDesc desc = new FieldDesc().setDefaultValue("SomeDefaultValue");
//    }
//
//    @Test
//    public void crudSimple() {
//
//        log.fine("********************************************");
//        log.fine("test EntityDescriptorUseCase");
//        log.fine("");
//        log.fine("insert,update, find, delete");
//        log.fine("********************************************");
//        PersistenceUnit persistenceUnit = UPA.getPersistenceUnit("partial");
//        persistenceUnit.addEntity(Person.class);
//        persistenceUnit.start();
//        Session session = persistenceUnit.openSession();
//        persistenceUnit.beginTransaction(TransactionType.REQUIRED);
//        try {
//            persistenceUnit.getEntity(Client.class);
////            Assert.fail();
//        } catch (UPAException e) {
////            Assert.assertEquals(e.getMessageId(), new I18NString("MultipleEntityMatchForType"));
//        }
//        net.vpc.upa.Entity entity = persistenceUnit.getEntity("GeneratedPerson");
//
//        
//        Client client = new Client();
//        client.setFirstName("Hammadi");
//        client.setLastName("Hammadi");
//
//        entity.insert(client);
//        int key = client.getId();
//
//        Client foundById = entity.createQueryBuilder().setId(key).getEntity();
//        Document foundByIdDocument = entity.createQueryBuilder().setId(key).objectToDocument();
//        log.info("Found Entity" + foundById);
//        log.info("Found Document" + foundByIdDocument);
//        log.info("fullName = " + foundByIdDocument.getString("fullName"));
//        client.setFirstName("Alia");
//
//        entity.update(client);
//        log.info("fullName = " + foundByIdDocument.getString("fullName"));
//
//        Client foundByIdAfterUpdate = entity.createQueryBuilder().setId(key).getEntity();
//
//        Assert.assertNotNull(foundByIdAfterUpdate);
//        assertEquals(foundByIdAfterUpdate.getFirstName(), client.getFirstName());
//        assertEquals(foundByIdAfterUpdate.getId(), client.getId());
//
////        sm.delete("GeneratedPerson",key);
//
////        found= sm.find("GeneratedPerson",keyCondition).getEntity();
//
////        Assert.assertNull(found);
//        persistenceUnit.commitTransaction();
//        session.close();
//    }
//}
