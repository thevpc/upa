package net.vpc.upa.test;

import net.vpc.upa.Document;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.UPA;
import net.vpc.upa.config.*;
import net.vpc.upa.impl.UPAImplDefaults;
import net.vpc.upa.test.util.PUUtils;
import org.junit.Assert;
import org.junit.BeforeClass;
import org.junit.Test;

import java.util.List;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class ViewUC {

    private static final java.util.logging.Logger log = java.util.logging.Logger.getLogger(ViewUC.class.getName());

    private static Business bo;

    @BeforeClass
    public static void setup() {
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(ViewUC.class);
        pu.addEntity(Client.class);
        pu.addEntity(ClientView.class);
        pu.start();
        bo = UPA.makeSessionAware(new Business());
        bo.init();
    }

    @View(query = "Select a.id id, a.name name from Client a")
    public static class ClientView {

        @Id
        private int id;
        @Main
        private String name;

        public int getId() {
            return id;
        }

        public void setId(int id) {
            this.id = id;
        }

        public String getName() {
            return name;
        }

        public void setName(String name) {
            this.name = name;
        }

    }

    public static class Client {

        @Id
        @Sequence
        private int id;
        @Main
        private String name;

        public String getName() {
            return name;
        }

        public void setName(String name) {
            this.name = name;
        }

        public int getId() {
            return id;
        }

        public Client setId(int id) {
            this.id = id;
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
            pu.clear(Client.class, null);
        }

        public void testMe() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            Client ic = new Client();
            ic.setName("tozz");
            pu.persist(ic);
            Object uu = pu.findById(Client.class, ic.getId());
            System.out.println(uu.getClass());
            Assert.assertEquals(Client.class, uu.getClass());

            List<Document> r = pu.createQuery("Select a from ClientView a").getDocumentList();
            r.size();
            System.out.println(r);

        }

    }
}
