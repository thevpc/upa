package net.thevpc.upa.test.crud;

import net.thevpc.upa.PersistenceUnit;
import net.thevpc.upa.config.Id;
import net.thevpc.upa.config.Sequence;
import net.thevpc.upa.test.util.PUUtils;
import net.thevpc.upa.Document;
import net.thevpc.upa.UPA;
import net.thevpc.upa.config.*;
import org.junit.Assert;
import org.junit.BeforeClass;
import org.junit.Test;

import java.util.Date;
import java.util.List;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class CrudUserInClientUC {
    private static final java.util.logging.Logger log = java.util.logging.Logger.getLogger(CrudUserInClientUC.class.getName());

    private static Business bo;

    @BeforeClass
    public static void setup() {
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(CrudUserInClientUC.class);
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
        private Date date;

        public Date getDate() {
            return date;
        }

        public Client setDate(Date date) {
            this.date = date;
            return this;
        }

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

            List<Document> r = pu.createQuery("Select year(currentDate()) from AppUser a").getDocumentList();
            r.size();
            System.out.println(r);

        }

    }
}
