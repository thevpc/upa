package net.thevpc.upa.test.relations;

import java.util.List;
import java.util.logging.Logger;

import net.thevpc.upa.EntityModifier;
import net.thevpc.upa.PersistenceUnit;
import net.thevpc.upa.Query;
import net.thevpc.upa.UPA;
import net.thevpc.upa.config.Entity;
import net.thevpc.upa.config.Sequence;

import net.thevpc.upa.test.util.LogUtils;
import net.thevpc.upa.config.Id;
import net.thevpc.upa.config.Ignore;
import net.thevpc.upa.test.util.PUUtils;
import org.junit.Assert;
import org.junit.BeforeClass;
import org.junit.Test;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class RelationOneToOneUC {

    static {
        LogUtils.prepare();
    }
    private static final Logger log = Logger.getLogger(RelationOneToOneUC.class.getName());

    private static Business bo;
    @BeforeClass
    public static void setup() {
        PUUtils.reset();
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(RelationOneToOneUC.class);
        pu.addEntity(Client.class);
        pu.addEntity(ClientInfo.class);
        pu.start();
        bo = UPA.makeSessionAware(new Business());
        bo.init();
    }

    @Test
    public void testQueries() {
        bo.testQueries();
    }

    @Test
    public void process() {
        bo.process();
    }

    public static class Business {

        public void init() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            pu.clear();
        }
        public void process() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            Client val0 = new Client();
            val0.setName("hello0");
            pu.persist(val0);
            ClientInfo ci = new ClientInfo();
            ci.setClient(val0);
            ci.setAddress("Sousse");
            pu.persist(ci);

            List<Client> entityList = pu.createQuery("Select a from Client a").getResultList();
            Assert.assertEquals(1,entityList.size());
            Assert.assertEquals(1,pu.findAll("Client").size());
            Assert.assertEquals(1L,pu.getEntityCount("Client"));
        }
        public void testQueries() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            List<Client> entityList;
//            pu.createQuery("Select a from ClientInfo a where a.client=null").getEntityList();
            pu.createQuery("Select a from ClientInfo a where a.client=:cc").setParameter("cc", new Client()).getResultList();
            pu.createQuery("Select a from ClientInfo a where a.client=null").getResultList().size();
            pu.createQuery("Delete from ClientInfo").executeNonQuery();
            pu.createQuery("Delete from Client").executeNonQuery();
            final Query findAll = pu.createQuery("Select a from Client a");
            entityList = findAll.getResultList();
            Assert.assertTrue(entityList.size() == 0);
        }
    }

    @Ignore
    @Entity(modifiers = EntityModifier.CLEAR)
    public static class Client {

        @Id
        @Sequence
        private Integer id;
        private String name;

        public String getName() {
            return name;
        }

        public void setName(String name) {
            this.name = name;
        }

        public Integer getId() {
            return id;
        }

        public void setId(Integer id) {
            this.id = id;
        }

        @Override
        public String toString() {
            return "Client{" +
                    "id=" + id +
                    ", name='" + name + '\'' +
                    '}';
        }
    }

    @Entity(modifiers = EntityModifier.CLEAR)
    public static class ClientInfo {

        @Id
        private Client client;
        private String address;

        public Client getClient() {
            return client;
        }

        public void setClient(Client client) {
            this.client = client;
        }

        public String getAddress() {
            return address;
        }

        public void setAddress(String address) {
            this.address = address;
        }

        @Override
        public String toString() {
            return "ClientInfo{" +
                    "client=" + client +
                    ", address='" + address + '\'' +
                    '}';
        }
    }
}
