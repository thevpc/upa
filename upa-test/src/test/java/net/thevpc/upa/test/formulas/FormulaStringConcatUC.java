package net.thevpc.upa.test.formulas;

import net.thevpc.upa.PersistenceUnit;
import net.thevpc.upa.UPA;
import net.thevpc.upa.config.Formula;
import net.thevpc.upa.config.Id;
import net.thevpc.upa.config.Sequence;
import net.thevpc.upa.test.util.PUUtils;
import org.junit.BeforeClass;
import org.junit.Test;


/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class FormulaStringConcatUC {
    private static final java.util.logging.Logger log = java.util.logging.Logger.getLogger(FormulaStringConcatUC.class.getName());

    private static Business bo;

    @BeforeClass
    public static void setup() {
        PUUtils.reset();
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(FormulaStringConcatUC.class);
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
