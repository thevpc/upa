package net.vpc.upa.test;

import junit.framework.Assert;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.*;
import net.vpc.upa.config.Formula;
import net.vpc.upa.config.*;
import net.vpc.upa.test.util.LogUtils;
import net.vpc.upa.test.util.PUUtils;
import org.junit.Test;

import java.util.List;
import java.util.logging.Logger;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class RelationFormulaUC {

    static {
        LogUtils.prepare();
    }

    private static final Logger log = Logger.getLogger(RelationFormulaUC.class.getName());

    @Test
    public void crudMixedDocumentsAndEntities() {
        String puId = getClass().getName();
        log.fine("********************************************");
        log.fine(" " + puId);
        log.fine("********************************************");
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(getClass(), "embedded");
//        pu.scan(null);
        pu.addEntity(Person.class);
        pu.addEntity(Phone.class);
        pu.start();

        Business bo = UPA.makeSessionAware(new Business());
//        bo.initializeData();
        bo.testQuery0();
//        bo.testQuery();
    }

    public static class Business {

        public void testQuery0() {
            PersistenceUnit pu = UPA.getPersistenceGroup().getPersistenceUnit();
//            Query q = pu.createQuery("Select a.phoneWithPrefix1 from Person a ");
//            List<Phone> t = q.getEntityList();
//            for (Phone r : t) {
//                System.out.println(r);
//            }
//            Query q = pu.createQuery("Select a.phoneWithPrefix1 from Person a ");
//            List<Document> t = q.getDocumentList();
//            for (Document r : t) {
//                System.out.println(r);
//            }
            Query q = pu.createQuery("Select a.id,a.name,a.phoneWithPrefix1,a.phoneWithPrefix1 toto,58 titi from Person a ");
            List<Document> t = q.getDocumentList();
            Assert.assertEquals(t.size(), 1);
            for (Document r : t) {
                System.out.println(r);
                Assert.assertEquals(r.size(), 5);
                Assert.assertEquals("Hammadi", r.getObject("name"));
                Assert.assertEquals(58, r.getObject("titi"));
                Assert.assertNotNull(r.getObject("phoneWithPrefix1"));
                Assert.assertEquals(r.getObject("phoneWithPrefix1"), r.getObject("toto"));
            }
        }

        public void testQuery() {
            PersistenceUnit pu = UPA.getPersistenceGroup().getPersistenceUnit();
            Query q = pu.createQuery("Select a from Person a ") //where a.phone2.id >3
                    .setHint(QueryHints.FETCH_STRATEGY, QueryFetchStrategy.JOIN);
            for (Document r : q.getDocumentList()) {
                System.out.println("Document : " + r);
            }
            for (Person r : q.<Person>getResultList()) {
                System.out.println("person : " + r);
            }
        }

        public void initializeData() {
            PersistenceUnit pu = UPA.getPersistenceGroup().getPersistenceUnit();
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
    @net.vpc.upa.config.Entity
    public static class Person {

        @Id
        @net.vpc.upa.config.Sequence
        private Integer id;

        @Main
        private String name;

        /**
         * create relation phone2 a new field "phone2Id" will be created
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

//        public Phone getPhone5() {
//            return phone5;
//        }
//
//        public void setPhone5(Phone phone5) {
//            this.phone5 = phone5;
//        }
//
//        public Integer getIdPhone1() {
//            return idPhone1;
//        }
//
//        public void setIdPhone1(Integer idPhone1) {
//            this.idPhone1 = idPhone1;
//        }
//
//        public Integer getIdPhone3() {
//            return idPhone3;
//        }
//
//        public void setIdPhone3(Integer idPhone3) {
//            this.idPhone3 = idPhone3;
//        }
//
//        public Phone getPhone3() {
//            return phone3;
//        }
//
//        public void setPhone3(Phone phone3) {
//            this.phone3 = phone3;
//        }
//
//        public Integer getIdPhone4() {
//            return idPhone4;
//        }
//
//        public void setIdPhone4(Integer idPhone4) {
//            this.idPhone4 = idPhone4;
//        }
//
//        public Phone getPhone4() {
//            return phone4;
//        }
//
//        public void setPhone4(Phone phone4) {
//            this.phone4 = phone4;
//        }

//        @Override
//        public String toString() {
//            return "Person{" + "id=" + id + ", name=" + name + ", idPhone1=" + idPhone1 + ", phone2=" + phone2 + ", idPhone3=" + idPhone3 + ", phone3=" + phone3 + ", idPhone4=" + idPhone4 + ", phone4=" + phone4 + '}';
//        }

        public Phone getPhoneWithPrefix1() {
            return phoneWithPrefix1;
        }

        public void setPhoneWithPrefix1(Phone phoneWithPrefix1) {
            this.phoneWithPrefix1 = phoneWithPrefix1;
        }
    }

    public static class Phone {

        @Id
        @net.vpc.upa.config.Sequence
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
