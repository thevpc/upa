package net.thevpc.upa.test.v1_0_2_29.relations;

import junit.framework.Assert;
import net.thevpc.upa.PersistenceUnit;
import net.thevpc.upa.config.Formula;
import net.thevpc.upa.test.v1_0_2_29.util.PUUtils;
import org.junit.BeforeClass;
import org.junit.Test;

import java.util.List;
import java.util.logging.Logger;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class RelationFormulaUC {

    private static final Logger log = Logger.getLogger(RelationFormulaUC.class.getName());
    private static Business bo;
    @BeforeClass
    public static void setup() {
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(RelationFormulaUC.class);
        pu.addEntity(Person.class);
        pu.addEntity(Phone.class);
        pu.start();
        bo = UPA.makeSessionAware(new Business());
        bo.init();
    }
    @Test
    public void testQuery0() {
        bo.testQuery0();
    }

    @Test
    public void testQuery() {
        bo.testQuery();
    }

    public static class Business {

        public void testQuery0() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
//            Query q = pu.createQuery("Select a.phoneWithPrefix1 from Person a ");
//            List<Phone> t = q.getEntityList();
//            for (Phone r : t) {
//                System.out.println(r);
//            }
//            Query q = pu.createQuery("Select a.phoneWithPrefix1 from Person a ");
//            List<Record> t = q.getRecordList();
//            for (Document r : t) {
//                System.out.println(r);
//            }
            Query q = pu.createQuery("Select a.id,a.name,a.phoneWithPrefix1,a.phoneWithPrefix1 toto,58 titi from Person a ");
            List<Record> t = q.getRecordList();
            Assert.assertEquals(t.size(), 1);
            for (Record r : t) {
                System.out.println(r);
                Assert.assertEquals(r.size(), 5);
                Assert.assertEquals("Hammadi", r.getObject("name"));
                Assert.assertEquals(58, r.getObject("titi"));
                Assert.assertNotNull(r.getObject("phoneWithPrefix1"));
                Assert.assertEquals(r.getObject("phoneWithPrefix1"), r.getObject("toto"));
            }
        }

        public void testQuery() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            Query q = pu.createQuery("Select a from Person a ") //where a.phone2.id >3
                    .setHint(QueryHints.FETCH_STRATEGY, QueryFetchStrategy.JOIN);
            for (Record r : q.getRecordList()) {
                System.out.println("Document : " + r);
            }
            for (Person r : q.<Person>getResultList()) {
                System.out.println("person : " + r);
            }
        }
        public void init() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            for (Object p : pu.findAll(Person.class)) {
                pu.remove(p);
            }
            for (Object p : pu.findAll(Phone.class)) {
                pu.remove(p);
            }
            if (pu.isEmpty(Phone.class)) {
                Phone[] phones = new Phone[10];
                for (int i = 0; i < phones.length; i++) {
                    Phone phone = new Phone();
                    String si = String.valueOf(i);
                    phone.setValue(si + si + si + si + si + si + si);
                    phones[i] = phone;
                    pu.save(phones[i]);
                }
            }

            if (pu.isEmpty(Person.class)) {
                Person person = new Person();
                person.setName("Hammadi");
                person.setPhone2((Phone) pu.findByMainField(Phone.class, "3333333"));
                pu.save(person);
            }
        }
    }

    @Ignore
    @net.thevpc.upa.config.Entity
    public static class Person {

        @Id
        @net.thevpc.upa.config.Sequence
        private Integer id;

        @Main
        private String name;

        /**
         * create relation phone2 a new system field "phone2Id" will be created
         */
        @ManyToOne
        private Phone phone2;

        @Formula(
                value = "Select x from Phone x where x.value like '1%'"
        )
        @ManyToOne
        @Summary
        private Phone phoneWithPrefix1;

        public Integer getId() {
            return id;
        }

        public void setId(Integer id) {
            this.id = id;
        }

        public String getName() {
            return name;
        }

        public void setName(String name) {
            this.name = name;
        }

        public Phone getPhone2() {
            return phone2;
        }

        public void setPhone2(Phone phone2) {
            this.phone2 = phone2;
        }

        public Phone getPhoneWithPrefix1() {
            return phoneWithPrefix1;
        }

        public void setPhoneWithPrefix1(Phone phoneWithPrefix1) {
            this.phoneWithPrefix1 = phoneWithPrefix1;
        }
    }

    public static class Phone {

        @Id
        @net.thevpc.upa.config.Sequence
        private Integer id;
        @Main
        private String value;

        public Integer getId() {
            return id;
        }

        public void setId(Integer id) {
            this.id = id;
        }

        public String getValue() {
            return value;
        }

        public void setValue(String value) {
            this.value = value;
        }

        @Override
        public String toString() {
            return "Phone{" + "id=" + id + ", value=" + value + '}';
        }
    }
}
