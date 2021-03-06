package net.thevpc.upa.test.entitypatterns;

import net.thevpc.upa.Document;
import net.thevpc.upa.PersistenceUnit;
import net.thevpc.upa.UPA;
import net.thevpc.upa.config.Id;
import net.thevpc.upa.config.Main;
import net.thevpc.upa.config.Sequence;
import net.thevpc.upa.config.View;
import net.thevpc.upa.config.*;
import net.thevpc.upa.test.util.PUUtils;
import org.junit.Assert;
import org.junit.BeforeClass;
import org.junit.Test;

import java.util.List;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class PatternViewUC {

    private static final java.util.logging.Logger log = java.util.logging.Logger.getLogger(PatternViewUC.class.getName());

    private static Business bo;

    @BeforeClass
    public static void setup() {
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(PatternViewUC.class);
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
