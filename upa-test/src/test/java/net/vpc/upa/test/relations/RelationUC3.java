package net.vpc.upa.test.relations;

import net.vpc.upa.*;
import net.vpc.upa.config.Id;
import net.vpc.upa.test.util.PUUtils;
import org.junit.Assert;
import org.junit.BeforeClass;
import org.junit.Test;

import java.util.List;
import java.util.logging.Logger;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class RelationUC3 {

    private static final Logger log = Logger.getLogger(RelationUC3.class.getName());
    private static Business bo;

    @BeforeClass
    public static void setup() {
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(RelationUC3.class);
        pu.addEntity(Person.class);
        pu.addEntity(Phone.class);
        pu.start();
        bo = UPA.makeSessionAware(new Business());
        bo.init();
    }
    @Test
    public void testInit() {

    }

    @Test
    public void testCrud() {
        bo.testCrud();
    }

//    @Test
    public void testRemove() {
        bo.testRemove();
    }

    @Test
    public void testQuery() {
        bo.testQuery();
    }

    @Test
    public void testQueryEmpty() {
        bo.testQueryEmpty();
    }

    public static class Business {

        public void init() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            pu.clear();
        }

        public void testQueryEmpty() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            Person person =pu.findById(Person.class,-12456); //should return null
        }

        public void testCrud() {
            PersistenceUnit pu = UPA.getPersistenceUnit();

            Phone phone=new Phone();
            phone.setValue("111111");
            pu.persist(phone);

            Phone phone2=new Phone();
            phone2.setValue("222222");
            pu.persist(phone2);

            Person person=new Person();
            person.setName("Hammadi");
            person.setPhone(phone);
            pu.persist(person);

            Phone ephone=new Phone();
            ephone.setId(phone.getId());
            ephone.setValue("111111");

            Phone ephone2=new Phone();
            ephone2.setId(phone2.getId());
            ephone2.setValue("222222");

            Person eperson=new Person();
            eperson.setId(person.getId());
            eperson.setName("Hammadi");
            eperson.setPhone(ephone);
            System.out.println(person);
            Assert.assertEquals(eperson,person);

            person =pu.findById(Person.class,person.getId());
            Assert.assertEquals(eperson,person);

            phone =pu.findById(Phone.class,phone.getId());

            Assert.assertEquals(ephone,phone);

            phone.setValue("555555");
            ephone.setValue("555555");
            pu.merge(phone);

            person =pu.findById(Person.class,person.getId());
            phone =pu.findById(Phone.class,phone.getId());

            Assert.assertEquals(eperson,person);
            Assert.assertEquals(ephone,phone);

            person.setPhone(phone2);
            eperson.setPhone(ephone2);
            pu.merge(person);

            person =pu.findById(Person.class,person.getId());
            phone =pu.findById(Phone.class,phone.getId());

            System.out.println(person);
            System.out.println(phone);
            Assert.assertEquals(eperson,person);
            Assert.assertEquals(ephone,phone);
        }

        public void testRemove() {
            PersistenceUnit pu = UPA.getPersistenceUnit();

        }

        public void testQuery() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            Query q = pu.createQuery("Select a from Person a where a.phone.id >3");
            List<Document> r = q.getDocumentList();
            for (Document document : r) {
                System.out.println(r);
            }
        }


    }

    @net.vpc.upa.config.Entity(modifiers = EntityModifier.CLEAR)
    public static class Person {

        @Id
        @net.vpc.upa.config.Sequence
        private Integer id;

        private String name;

        private Phone phone;

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

        public Phone getPhone() {
            return phone;
        }

        public void setPhone(Phone phone) {
            this.phone = phone;
        }

        @Override
        public boolean equals(Object o) {
            if (this == o) return true;
            if (o == null || getClass() != o.getClass()) return false;

            Person person = (Person) o;

            if (id != null ? !id.equals(person.id) : person.id != null) return false;
            if (name != null ? !name.equals(person.name) : person.name != null) return false;
            return phone != null ? phone.equals(person.phone) : person.phone == null;
        }

        @Override
        public int hashCode() {
            int result = id != null ? id.hashCode() : 0;
            result = 31 * result + (name != null ? name.hashCode() : 0);
            result = 31 * result + (phone != null ? phone.hashCode() : 0);
            return result;
        }

        @Override
        public String toString() {
            return "Person{" +
                    "id=" + id +
                    ", name='" + name + '\'' +
                    ", phone=" + phone +
                    '}';
        }
    }

    @net.vpc.upa.config.Entity(modifiers = EntityModifier.CLEAR)
    public static class Phone {

        @Id
        @net.vpc.upa.config.Sequence
        private Integer id;
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

        @Override
        public boolean equals(Object o) {
            if (this == o) return true;
            if (o == null || getClass() != o.getClass()) return false;

            Phone phone = (Phone) o;

            if (id != null ? !id.equals(phone.id) : phone.id != null) return false;
            return value != null ? value.equals(phone.value) : phone.value == null;
        }

        @Override
        public int hashCode() {
            int result = id != null ? id.hashCode() : 0;
            result = 31 * result + (value != null ? value.hashCode() : 0);
            return result;
        }
    }
}
