package net.vpc.upa.test;

import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.UPA;
import net.vpc.upa.config.Formula;
import net.vpc.upa.config.Id;
import net.vpc.upa.config.Sequence;
import net.vpc.upa.impl.UPAImplDefaults;
import net.vpc.upa.test.util.PUUtils;
import org.junit.BeforeClass;
import org.junit.Test;


/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class StringConcatUC {
    private static final java.util.logging.Logger log = java.util.logging.Logger.getLogger(StringConcatUC.class.getName());

    private static Business bo;

    @BeforeClass
    public static void setup() {
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(StringConcatUC.class);
        pu.addEntity(Client.class);
        pu.start();
        bo = UPA.makeSessionAware(new Business());
        bo.init();
    }


    public static class Client {
        @Id
        @Sequence
        private int id;
        private String firstName;
        private String lastName;
        @Formula("this.firstName+this.lastName")
        private String fullName;

        public int getId() {
            return id;
        }

        public Client setId(int id) {
            this.id = id;
            return this;
        }

        public String getFirstName() {
            return firstName;
        }

        public Client setFirstName(String firstName) {
            this.firstName = firstName;
            return this;
        }

        public String getLastName() {
            return lastName;
        }

        public Client setLastName(String lastName) {
            this.lastName = lastName;
            return this;
        }

        public String getFullName() {
            return fullName;
        }

        public Client setFullName(String fullName) {
            this.fullName = fullName;
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
            ic.setFirstName("me");
            ic.setLastName("you");
            pu.persist(ic);
            Client uu = pu.findById(Client.class, ic.getId());
            System.out.println(uu.getClass());
            System.out.println(ic.getFullName());
            System.out.println(uu.getFullName());
//            Assert.assertEquals(Client.class,uu.getClass());
        }

    }
}
