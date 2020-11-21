//package net.thevpc.upa.test;
//
//import net.thevpc.upa.*;
//import net.thevpc.upa.config.Entity;
//import net.thevpc.upa.config.*;
//import net.thevpc.upa.config.Field;
//import net.thevpc.upa.config.Sequence;
//import net.thevpc.upa.exceptions.UPAException;
//import net.thevpc.upa.test.model.Client;
//import net.thevpc.upa.test.v1_0_2_29.util.LogUtils;
//import net.thevpc.upa.TransactionType;
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
//        @net.thevpc.upa.config.Formula(value="concat(firstName,' ',lastName)")
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
//        net.thevpc.upa.Entity entity = persistenceUnit.getEntity("GeneratedPerson");
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
