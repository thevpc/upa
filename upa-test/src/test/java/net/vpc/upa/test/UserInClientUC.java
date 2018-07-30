package net.vpc.upa.test;

import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.UPA;
import net.vpc.upa.config.*;
import net.vpc.upa.impl.UPAImplDefaults;
import net.vpc.upa.test.util.PUUtils;
import org.junit.Assert;
import org.junit.BeforeClass;
import org.junit.Test;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class UserInClientUC {
    private static final java.util.logging.Logger log = java.util.logging.Logger.getLogger(UserInClientUC.class.getName());

    private static Business bo;

    @BeforeClass
    public static void setup() {
        UPAImplDefaults.PRODUCTION_MODE = false;
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(UserInClientUC.class);
        pu.addEntity(AppUser.class);
        pu.addEntity(Client.class);
        pu.start();
        bo = UPA.makeSessionAware(new Business());
        bo.init();
    }


    public static class Client {
        @Id
        @Sequence
        private int id;
        private AppUser client;

        public int getId() {
            return id;
        }

        public Client setId(int id) {
            this.id = id;
            return this;
        }

        public AppUser getClient() {
            return client;
        }

        public void setClient(AppUser client) {
            this.client = client;
        }
    }

    public static class AppUser {
        @Id
        @Sequence
        private int id;
        private String name;

        public int getId() {
            return id;
        }

        public AppUser setId(int id) {
            this.id = id;
            return this;
        }

        public String getName() {
            return name;
        }

        public AppUser setName(String name) {
            this.name = name;
            return this;
        }
    }

    @Test
    public void testMe() {
        bo.testMe();
    }

    public static class Business {

        public void init() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            pu.clear(AppUser.class, null);
            pu.clear(Client.class, null);
        }

        public void testMe() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            AppUser iu = new AppUser();
            iu.setName("tozz");
            pu.persist(iu);
            Client ic = new Client();
            ic.setClient(iu);
            pu.persist(ic);
            Object uu = pu.findById(Client.class, ic.getId());
            System.out.println(uu.getClass());
            Assert.assertEquals(Client.class,uu.getClass());
        }

    }
}
