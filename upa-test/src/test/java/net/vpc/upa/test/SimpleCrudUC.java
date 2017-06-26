package net.vpc.upa.test;

import net.vpc.upa.*;
import net.vpc.upa.expressions.UserExpression;
import net.vpc.upa.test.model.Client;
import net.vpc.upa.test.util.LogUtils;
import net.vpc.upa.test.util.PUUtils;
import org.junit.Assert;
import org.junit.BeforeClass;
import org.junit.Test;

import static org.junit.Assert.assertEquals;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class SimpleCrudUC {
    private static final java.util.logging.Logger log = java.util.logging.Logger.getLogger(SimpleCrudUC.class.getName());
    private static Business bo;

    @BeforeClass
    public static void setup() {
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(SimpleCrudUC.class);
        pu.addEntity(Client.class);
        pu.start();
        bo = UPA.makeSessionAware(new Business());

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

    public static class Business {

        public void process() {
            PersistenceUnit sm = UPA.getPersistenceUnit();

            Entity entityManager = sm.getEntity("Client");
            Client c = entityManager.createObject();
            int key = entityManager.nextId();
            log.info("Next Id is " + key);
            c.setId(key);
            c.setFirstName("Hammadi");

            sm.persist(c);

            Document found0 = sm.createQueryBuilder(Client.class).byId(key).getDocument();
            log.info("Found " + found0);
            found0.setString("firstName", "Alia");

            Client c2 = entityManager.getBuilder().documentToObject(found0);

            assertEquals(c2.getFirstName(), "Alia");

            sm.update(c2);

            Client found = sm.createQueryBuilder(Client.class).byId(key).getFirstResultOrNull();

            Assert.assertNotNull(found);
            Assert.assertEquals(found, c2);

            sm.remove(Client.class,RemoveOptions.forId(key));

            Document foundDocument = sm.createQueryBuilder(Client.class).byId(key).getDocument();

            Assert.assertNull(foundDocument);
        }

        public void crudDocuments() {
            PersistenceUnit sm = UPA.getPersistenceUnit();
            if(!sm.containsEntity(Client.class)) {
                sm.addEntity(Client.class);
            }
            if(!sm.isStarted()) {
                sm.start();
            }

            Entity entityManager = sm.getEntity("Client");
            Document c = entityManager.createDocument();
            int key = entityManager.nextId();
            log.info("Next Id is " + key);
            c.setInt("id", key);
            c.setString("firstName", "Hammadi");

            sm.persist("Client",c);

            Document found0 = sm.createQueryBuilder(Client.class).byId(key).getDocument();
            log.info("Found " + found0);
            c.setString("firstName", "Alia");

            sm.update(Client.class,c);

            Document found = sm.createQueryBuilder(Client.class).byId(key).getDocument();

            Assert.assertNotNull(found);
            Assert.assertEquals(found, c);

            sm.remove(Client.class,RemoveOptions.forId(key));

            found = sm.createQueryBuilder(Client.class).byId(key).getDocument();

            Assert.assertNull(found);

        }

        public void testInc() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            Entity entity = pu.getEntity(Client.class);
            Client c = new Client();
            int id = pu.getEntity(Client.class).nextId();
            c.setId(id);
            log.info("Next Id is " + id);
            c.setId(id);
            c.setIntegerValue(15);
            c.setFirstName("Hammadi");
            pu.persist(c);
            for (Client cli : entity.<Client>findAll()) {
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
            if(!sm.containsEntity(Client.class)) {
                sm.addEntity(Client.class);
            }
            if(!sm.isStarted()) {
                sm.start();
            }

            Client c = new Client();
            int id = (Integer) sm.getEntity(Client.class).nextId();
            log.info("Next Id is " + id);
            c.setId(id);
            c.setFirstName("Hammadi");

            sm.persist(c);

            Client found0 = sm.createQueryBuilder(Client.class).byId(id).getFirstResultOrNull();
            log.info("Found " + found0);
            c.setFirstName("Alia");

            sm.update(c);

            Client found = sm.createQueryBuilder(Client.class).byId(id).getFirstResultOrNull();

            Assert.assertNotNull(found);
            assertEquals(found.getFirstName(), c.getFirstName());
            assertEquals(found.getId(), c.getId());

            sm.remove(Client.class,RemoveOptions.forId(id));

            found = sm.createQueryBuilder(Client.class).byId(id).getFirstResultOrNull();

            Assert.assertNull(found);
        }
    }
}
