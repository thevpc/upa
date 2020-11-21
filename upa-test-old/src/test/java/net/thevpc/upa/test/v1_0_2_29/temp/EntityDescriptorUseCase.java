//package net.thevpc.upa.test;
//
//import net.thevpc.upa.types.I18NString;
//import net.thevpc.upa.*;
//import net.thevpc.upa.config.Entity;
//import net.thevpc.upa.config.Field;
//import net.thevpc.upa.config.FieldDesc;
//import net.thevpc.upa.config.NoAutoConfig;
//import net.thevpc.upa.exceptions.UPAException;
//import net.thevpc.upa.test.model.Client;
//import net.thevpc.upa.test.util.LogUtils;
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
//public class EntityDescriptorUseCase {
//    static{
//        LogUtils.prepare();
//    }
//    static Logger log= LoggerFactory.getLogger(EntityDescriptorUseCase.class);
//
//    @Entity(entityType = Client.class,name = "Person")
//    @NoAutoConfig
//    public static final class Person{
//        //redefine name field to add constraints on length
//        @Field(max = "255")
//        private FieldDesc firstName;
//        //add new field desc
//        @Field(type = String.class)
//        private FieldDesc desc=new FieldDesc().setDefaultValue("SomeDefaultValue");
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
//        PersistenceUnit sm = UPA.getPersistenceUnit("partial");
//        sm.addEntity(Person.class);
//        sm.start();
//
//        Session s=sm.openSession();
//        sm.beginTransaction(TransactionType.REQUIRED);
//        Client c=new Client();
//        try{
//            sm.getEntity(Client.class);
//            Assert.fail();
//        }catch(UPAException e){
//            Assert.assertEquals(e.getMessageId(),new I18NString("MultipleEntityMatchForType"));
//        }
//        int key = (Integer) sm.getEntity("Person").nextId();
//        log.info("Next Id is " + key);
//        c.setId(key);
//        c.setFirstName("Hammadi");
//
//        sm.insert("Person",c);
//
//        Client found0= (Client) sm.createQueryBuilder("Person").setId(key).getEntity();
//        log.info("Found " + found0);
//        c.setFirstName("Alia");
//
//        sm.update("Person",c);
//
//        Client found= (Client) sm.createQueryBuilder("Person").setId(key).getEntity();
//
//        Assert.assertNotNull(found);
//        assertEquals(found.getFirstName(),c.getFirstName());
//        assertEquals(found.getId(), c.getId());
//
//        sm.delete("Person",key);
//
//        found= (Client) sm.createQueryBuilder("Person").setId(key).getEntity();
//
//        Assert.assertNull(found);
//        sm.commitTransaction();
//        s.close();
//    }
//}
