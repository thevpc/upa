package net.thevpc.upa.test.crud;

import java.util.logging.Level;

import net.thevpc.upa.*;
import net.thevpc.upa.test.model.SharedClient;
import net.thevpc.upa.test.util.PUUtils;

import net.thevpc.upa.expressions.UserExpression;
import org.junit.Assert;
import org.junit.BeforeClass;
import org.junit.Test;

import static org.junit.Assert.assertEquals;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class CrudUC {

    private static final java.util.logging.Logger log = java.util.logging.Logger.getLogger(CrudUC.class.getName());

    private static Business bo;

    @BeforeClass
    public static void setup() {
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(CrudUC.class);
        pu.addEntity(SharedClient.class);
        pu.start();
        bo = UPA.makeSessionAware(new Business());
        bo.init();
    }

    @Test
    public void process() {
        bo.process();
    }

    @Test
    public void crudSimple() {
        bo.crudSimple();
    }

    @Test
    public void testInc() {
        bo.testInc();
    }

    @Test
    public void crudDocuments() {
        bo.crudDocuments();
    }

    @Test
    public void testQueryEmpty() {
        bo.testQueryEmpty();
    }

    public static class Business {

        public void init() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            pu.clear(SharedClient.class, null);
        }

        public void testQueryEmpty() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            SharedClient c = pu.findById(SharedClient.class, -123456);
            Assert.assertNull(c);
        }

        public void process() {
            PersistenceUnit pu = UPA.getPersistenceUnit();

            Entity entity = pu.getEntity("SharedClient");
            SharedClient c = entity.createObject();
            int key = entity.nextId();
            log.log(Level.INFO, "Next Id is {0}", key);
            c.setId(key);
            c.setFirstName("Hammadi");

            pu.persist(c);

            Document found0 = pu.createQueryBuilder(SharedClient.class).byId(key).getDocument();
            Assert.assertNotNull(found0);
            log.log(Level.INFO, "Found {0}", found0);
            found0.setString("firstName", "Alia");

            SharedClient c2 = entity.getBuilder().documentToObject(found0);

            Assert.assertEquals("Alia",c2.getFirstName());

            pu.update(c2);

            SharedClient found = pu.createQueryBuilder(SharedClient.class).byId(key).getFirstResultOrNull();

            Assert.assertNotNull(found);
            Assert.assertEquals(c2,found);

            found = pu.createQuery("Select a from SharedClient a where a.integerValue=null").getFirstResultOrNull();

            Assert.assertNotNull(found);
            Assert.assertEquals(c2,found);

            found = pu.createQuery("Select a from SharedClient a where a.integerValue=:param").setParameter("param", null).getFirstResultOrNull();

            Assert.assertNotNull(found);
            Assert.assertEquals(c2,found);

            pu.remove(SharedClient.class, RemoveOptions.forId(key));

            Document foundDocument = pu.createQueryBuilder(SharedClient.class).byId(key).getDocument();

            Assert.assertNull(foundDocument);
        }

        public void crudDocuments() {
            PersistenceUnit sm = UPA.getPersistenceUnit();
            if (!sm.containsEntity(SharedClient.class)) {
                sm.addEntity(SharedClient.class);
            }
            if (!sm.isStarted()) {
                sm.start();
            }

            Entity entity = sm.getEntity("SharedClient");
            Document c = entity.createDocument();
            int key = entity.nextId();
            log.info("Next Id is " + key);
            c.setInt("id", key);
            c.setString("firstName", "Hammadi Aguerbi");

            sm.persist("SharedClient", c);

            Document found0 = sm.createQueryBuilder(SharedClient.class).byId(key).getDocument();
            System.out.println("Expected [01] : "+c);
            System.out.println("Found    [01] : "+found0);
            Assert.assertEquals(c,found0);

            log.info("Found " + found0);
            c.setString("firstName", "Alia");

            sm.update(SharedClient.class, c);

            Document found = sm.createQueryBuilder(SharedClient.class).byId(key).getDocument();

            Assert.assertNotNull(found);
            Assert.assertEquals(found, c);

            sm.remove(SharedClient.class, RemoveOptions.forId(key));

            found = sm.createQueryBuilder(SharedClient.class).byId(key).getDocument();

            Assert.assertNull(found);

        }

        public void testInc() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            Entity entity = pu.getEntity(SharedClient.class);
            SharedClient c = new SharedClient();
            int id = pu.getEntity(SharedClient.class).nextId();
            c.setId(id);
            log.info("Next Id is " + id);
            c.setId(id);
            c.setIntegerValue(15);
            c.setFirstName("Hammadi");
            pu.persist(c);
            for (SharedClient cli : entity.<SharedClient>findAll()) {
                Document document = entity.createDocument();
                document.setObject("integerValue", new UserExpression("integerValue+1"));
                entity.createUpdateQuery()
                        .setValues(document)
                        .byId(cli.getId())
                        .execute();
            }
        }

        public void crudSimple() {

            PersistenceUnit sm = UPA.getPersistenceUnit();
            if (!sm.containsEntity(SharedClient.class)) {
                sm.addEntity(SharedClient.class);
            }
            if (!sm.isStarted()) {
                sm.start();
            }

            SharedClient c = new SharedClient();
            int id = (Integer) sm.getEntity(SharedClient.class).nextId();
            log.info("Next Id is " + id);
            c.setId(id);
            c.setFirstName("Hammadi");

            sm.persist(c);

            SharedClient found0 = sm.createQueryBuilder(SharedClient.class).byId(id).getFirstResultOrNull();
            log.info("Found " + found0);
            c.setFirstName("Alia");

            sm.update(c);

            SharedClient found = sm.createQueryBuilder(SharedClient.class).byId(id).getFirstResultOrNull();

            Assert.assertNotNull(found);
            assertEquals(found.getFirstName(), c.getFirstName());
            assertEquals(found.getId(), c.getId());

            sm.remove(SharedClient.class, RemoveOptions.forId(id));

            found = sm.createQueryBuilder(SharedClient.class).byId(id).getFirstResultOrNull();

            Assert.assertNull(found);
        }
    }
}
