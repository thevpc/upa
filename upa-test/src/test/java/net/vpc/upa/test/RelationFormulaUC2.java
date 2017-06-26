package net.vpc.upa.test;

import net.vpc.upa.FormulaType;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.Query;
import net.vpc.upa.UPA;
import net.vpc.upa.config.Id;
import net.vpc.upa.config.Ignore;
import net.vpc.upa.expressions.Delete;
import net.vpc.upa.expressions.Equals;
import net.vpc.upa.expressions.Param;
import net.vpc.upa.expressions.Var;
import net.vpc.upa.test.util.PUUtils;
import org.junit.BeforeClass;
import org.junit.Test;

import java.util.List;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class RelationFormulaUC2 {

    private static Business bo;

    @BeforeClass
    public static void setup() {
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(RelationFormulaUC2.class);
//        pu.scan(null);
        pu.addEntity(Person.class);
        pu.addEntity(Person2.class);
        pu.addEntity(Person3.class);
        pu.addEntity(Phone.class);
        pu.addEntity(Phone2.class);
        pu.addEntity(Country.class);
        pu.start();
        bo = UPA.makeSessionAware(new Business());

    }

    @Test
    public void testQuery1() {

        bo.testQuery1();
    }

    @Test
    public void testQuery2() {

        bo.testQuery2();
    }

    @Test
    public void testQuery3() {

        bo.testQuery3();
    }

    @Test
    public void testQuery4() {

        bo.testQuery4();
    }
    @Test
    public void testQuery5() {

        bo.testQuery5();
    }
    @Test
    public void testQuery6() {

        bo.testQuery6();
    }
    @Test
    public void testQuery7() {

        bo.testQuery7();
    }

    public static class Business {

        public void testQuery1() {
            PersistenceUnit pu = UPA.getPersistenceGroup().getPersistenceUnit();
            Query q = pu.createQuery("Select concat(a.name,a.name) from Person2 a");
            List r = q.getResultList();
            System.out.println(r);
        }
        public void testQuery4() {
            PersistenceUnit pu = UPA.getPersistenceGroup().getPersistenceUnit();
            Query q = pu.createQuery("Select a.phone.number from Person2 a");
            List r = q.getResultList();
            System.out.println(r);
        }
        public void testQuery5() {
            PersistenceUnit pu = UPA.getPersistenceGroup().getPersistenceUnit();
            Query q = pu.createQuery("Select (a.phone.number+'!!') from Person2 a");
            List r = q.getResultList();
            System.out.println(r);
        }

        public void testQuery2() {
            PersistenceUnit pu = UPA.getPersistenceGroup().getPersistenceUnit();
            Query q = pu.createQuery("Select a from Person2 a");
            List<Person2> r = q.getResultList();
            if (r.size() == 0) {
                Person2 p = new Person2();
                p.setName("hello");
                p.setPhoneNumber("ignore me");
                Phone ph = new Phone();
                ph.setNumber("1234");
                pu.persist(ph);
                p.setPhone(ph);
                pu.persist(p);
                r = q.getResultList();
            }
            for (Person2 document : r) {
                System.out.println(">> " + document);
            }
        }

        public void testQuery3() {
            PersistenceUnit pu = UPA.getPersistenceGroup().getPersistenceUnit();
            Query q = pu.createQuery("Select a from Person3 a");
            List<Person3> r = q.getResultList();
            if (r.size() == 0) {
                Person3 person = new Person3();
                person.setName("hello");

                Country country = new Country();
                country.setName("Tunisia");
                pu.persist(country);

                Phone2 phone = new Phone2();
                phone.setNumber("1234");
                phone.setCountry(country);
                pu.persist(phone);

                person.setPhone(phone);

                pu.persist(person);
                r = q.getResultList();
            }
            for (Person3 doc : r) {
                System.out.println(">> " + doc);
            }
        }
        public void testQuery6() {
            PersistenceUnit pu = UPA.getPersistenceGroup().getPersistenceUnit();
            Query q = pu.createQuery("Delete from Person3 where id=:id")
                    .setParameter("id",12);
            int r = q.executeNonQuery();
            System.out.println(r);
        }
        public void testQuery7() {
            PersistenceUnit pu = UPA.getPersistenceGroup().getPersistenceUnit();
            Query q = pu.createQuery(new Delete().from("Person3","a").where(
                    new Equals(
                            new Var("id"),new Param("id")
                    )
            ))
                    .setParameter("id",12);
            int r = q.executeNonQuery();
            System.out.println(r);
        }

    }

    @Ignore
    @net.vpc.upa.config.Entity
    public static class Person {

        @Id
        @net.vpc.upa.config.Sequence
        private Integer id;

        private String name;

        @net.vpc.upa.config.Formula(type = FormulaType.LIVE, value = "concat(this.name,this.name)")
        private String goodName;

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

        public String getGoodName() {
            return goodName;
        }

        public void setGoodName(String goodName) {
            this.goodName = goodName;
        }

    }

    @Ignore
    @net.vpc.upa.config.Entity
    public static class Phone {

        @Id
        @net.vpc.upa.config.Sequence
        private Integer id;

        private String number;

        public Integer getId() {
            return id;
        }

        public void setId(Integer id) {
            this.id = id;
        }

        public String getNumber() {
            return number;
        }

        public void setNumber(String number) {
            this.number = number;
        }

        @Override
        public String toString() {
            return "Phone{" + "id=" + id + ", number=" + number + '}';
        }

    }

    @Ignore
    @net.vpc.upa.config.Entity
    public static class Person2 {

        @Id
        @net.vpc.upa.config.Sequence
        private Integer id;

        private String name;
        private Phone phone;

        @net.vpc.upa.config.Formula(type = FormulaType.LIVE, value = "(this.phone.number+'!!')")
        private String phoneNumber;

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

        public String getPhoneNumber() {
            return phoneNumber;
        }

        public void setPhoneNumber(String phoneNumber) {
            this.phoneNumber = phoneNumber;
        }

        @Override
        public String toString() {
            return "Person2{" + "id=" + id + ", name=" + name + ", phone=" + phone + ", phoneNumber=" + phoneNumber + '}';
        }

    }

    @Ignore
    @net.vpc.upa.config.Entity
    public static class Person3 {

        @Id
        @net.vpc.upa.config.Sequence
        private Integer id;

        private String name;
        private Phone2 phone;

        @net.vpc.upa.config.Formula(type = FormulaType.LIVE, value = "this.phone.country")
        private Country phoneCountry;

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

        public Phone2 getPhone() {
            return phone;
        }

        public void setPhone(Phone2 phone) {
            this.phone = phone;
        }

        public Country getPhoneCountry() {
            return phoneCountry;
        }

        public void setPhoneCountry(Country phoneCountry) {
            this.phoneCountry = phoneCountry;
        }

        @Override
        public String toString() {
            return "Person3{" + "id=" + id + ", name=" + name + ", phone=" + phone + ", phoneCountry=" + phoneCountry + '}';
        }

    }

    @Ignore
    @net.vpc.upa.config.Entity
    public static class Phone2 {

        @Id
        @net.vpc.upa.config.Sequence
        private Integer id;

        private String number;
        private Country country;

        public Integer getId() {
            return id;
        }

        public void setId(Integer id) {
            this.id = id;
        }

        public String getNumber() {
            return number;
        }

        public void setNumber(String number) {
            this.number = number;
        }

        public Country getCountry() {
            return country;
        }

        public void setCountry(Country country) {
            this.country = country;
        }

        @Override
        public String toString() {
            return "Phone2{" + "id=" + id + ", number=" + number + ", country=" + country + '}';
        }

    }

    @Ignore
    @net.vpc.upa.config.Entity
    public static class Country {

        @Id
        @net.vpc.upa.config.Sequence
        private Integer id;

        private String name;

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

    }
}
