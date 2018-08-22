package net.vpc.upa.test.crud;

import net.vpc.upa.*;
import net.vpc.upa.filters.FieldNameFilter;
import net.vpc.upa.test.model.SharedClient;
import net.vpc.upa.test.util.PUUtils;
import net.vpc.upa.types.IntType;
import org.junit.Assert;
import org.junit.BeforeClass;
import org.junit.Test;

import java.util.logging.Logger;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class CrudUnstructuredUC {
    static Logger log = Logger.getLogger(CrudUnstructuredUC.class.getName());
    private static Business bo;

    @BeforeClass
    public static void setup() {
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(CrudUnstructuredUC.class);
//        pu.addEntity(SharedClient.class);
        Entity e = pu.addEntity(SharedClient.class);
        e.setName("Titi");
        e.addField(new DefaultFieldBuilder().setName("toto").setDefaultObject(2).setDataType(new IntType(5, 10, true, false)));
        pu.start();
        bo = UPA.makeSessionAware(new Business());
    }

    @Test
    public void process() {
        bo.process();
    }

    @Test
    public void crudDocuments() {
        bo.crudDocuments();
    }

    public static class Business {

        public void process() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            Entity entity = pu.getEntity("Titi");
            SharedClient c = entity.getBuilder().createObject();
            int id = entity.nextId();
            log.info("Next Id is " + id);
            c.setId(id);
            c.setFirstName("Hammadi");

            pu.persist(c);

            FieldNameFilter fieldFilter = new FieldNameFilter("id", "firstName");
            Document foundDoc = pu.createQueryBuilder(SharedClient.class).byId(id).setFieldFilter(fieldFilter).getDocument();
            log.info("Found " + foundDoc);
            foundDoc.setString("firstName", "Alia");

            SharedClient c2 = entity.getBuilder().documentToObject(foundDoc);

            Assert.assertEquals(c2.getFirstName(), "Alia");

            pu.update(c2);

            Document found = pu.createQueryBuilder(SharedClient.class).byId(id).setFieldFilter(fieldFilter).getDocument();

            Assert.assertNotNull(found);
            Assert.assertEquals(2,found.keySet().size());
            Assert.assertEquals(found.get("id"),c2.getId());
            Assert.assertEquals(found.get("firstName"),c2.getFirstName());

            pu.remove("Titi",RemoveOptions.forId(id));

            found = pu.createQueryBuilder(SharedClient.class).byId(id).setFieldFilter(fieldFilter).getDocument();

            Assert.assertNull(found);
        }

        public void crudDocuments() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            Entity entity = pu.getEntity("Titi");
            Document record = entity.createDocument();
            int id = entity.nextId();
            log.info("Next Id is " + id);
            record.setInt("id", id);
            record.setString("firstName", "Hammadi");

            pu.persist("Titi", record);

            FieldNameFilter fieldFilter = new FieldNameFilter("id", "firstName");
            Document foundDoc = pu.createQueryBuilder(SharedClient.class).byId(id).setFieldFilter(fieldFilter).getDocument();
            log.info("Found " + foundDoc);
            record.setString("firstName", "Alia");

            pu.update("Titi", record);

            Document found = pu.createQueryBuilder(SharedClient.class).byId(id).setFieldFilter(fieldFilter).getDocument();

            Assert.assertNotNull(found);
            Assert.assertEquals(2,found.keySet().size());
            Assert.assertEquals(found.get("id"),record.get("id"));
            Assert.assertEquals(found.get("firstName"),record.get("firstName"));

            pu.remove("Titi", RemoveOptions.forId(id));

            found = pu.createQueryBuilder(SharedClient.class).byId(id).setFieldFilter(fieldFilter).getDocument();

            Assert.assertNull(found);
        }

    }


}
