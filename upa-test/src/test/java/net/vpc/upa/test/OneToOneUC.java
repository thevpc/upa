package net.vpc.upa.test;

import java.util.List;
import java.util.logging.Logger;
import net.vpc.upa.*;
import net.vpc.upa.test.util.LogUtils;
import net.vpc.upa.config.Id;
import net.vpc.upa.config.Ignore;
import net.vpc.upa.test.util.PUUtils;
import org.junit.Test;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class OneToOneUC {

    static {
        LogUtils.prepare();
    }
    private static final Logger log = Logger.getLogger(OneToOneUC.class.getName());

    public static void main(String[] args) {
        new OneToOneUC().run();
    }

    @Test
    public void run() {
        String puId = getClass().getName();
        log.fine("********************************************");
        log.fine(" " + puId);
        log.fine("********************************************");
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(getClass());
        pu.addEntity(Client.class);
        pu.addEntity(ClientInfo.class);
        pu.start();
        Business bo = UPA.makeSessionAware(new Business());
        bo.process();
    }

    public static class Business {

        public void process() {
            PersistenceUnit pu = UPA.getPersistenceGroup().getPersistenceUnit();
            List<Client> entityList;
//            pu.createQuery("Select a from ClientInfo a where a.client=null").getEntityList();
            pu.createQuery("Select a from ClientInfo a where a.client=:cc").setParameter("cc", new Client()).getEntityList();
//            pu.createQuery("Select a from ClientInfo a where a.client=null").executeNonQuery();
//            pu.createQuery("Delete from ClientInfo").executeNonQuery();
//            pu.createQuery("Delete from Client").executeNonQuery();
//            final Query findAll = pu.createQuery("Select a from Client a");
//            entityList = findAll.getEntityList();
//            Assert.assertTrue(entityList.size() == 0);
////            if(true){
////                return;
////            }
//            Client val0 = new Client();
//            val0.setName("hello0");
//            pu.insert(val0);
//            ClientInfo ci = new ClientInfo();
//            ci.setClient(val0);
//            ci.setAddress("Sousse");
//            pu.insert(ci);
//
//            entityList = findAll.getEntityList();
//            Assert.assertTrue(entityList.size() == 1);
        }
    }

    @Ignore
    @net.vpc.upa.config.Entity
    public static class Client {

        @Id
        @net.vpc.upa.config.Sequence
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
            return "Data{" + "id=" + id + +'}';
        }
    }

    @net.vpc.upa.config.Entity
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

    }
}
