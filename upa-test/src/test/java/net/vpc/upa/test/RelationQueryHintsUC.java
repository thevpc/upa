package net.vpc.upa.test;

import net.vpc.upa.*;
import net.vpc.upa.config.Id;
import net.vpc.upa.config.Ignore;
import net.vpc.upa.test.util.PUUtils;
import org.junit.Assert;
import org.junit.BeforeClass;
import org.junit.Test;

import java.util.Arrays;
import java.util.List;
import java.util.logging.Logger;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class RelationQueryHintsUC {
    private static final Logger log = Logger.getLogger(RelationQueryHintsUC.class.getName());
    private static Business bo;
    @BeforeClass
    public static void setup() {
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(RelationQueryHintsUC.class, "embedded");
        pu.addEntity(Person.class);
        pu.addEntity(Phone.class);
        pu.start();
        bo = UPA.makeSessionAware(new Business());
        bo.clear();
        bo.populate();
    }

    @Test
    public void crudMixedDocumentsAndEntities() {
        bo.testQuery();
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

    public static class Business {
        public void clear() {
            PersistenceUnit pu = UPA.getPersistenceGroup().getPersistenceUnit();
            for (Object p : pu.findAll(Person.class)) {
                pu.remove(p);
            }
            for (Object p : pu.findAll(Phone.class)) {
                pu.remove(p);
            }
        }
        public void populate() {
            PersistenceUnit pu = UPA.getPersistenceGroup().getPersistenceUnit();

            Phone[] phones = new Phone[10];
            for (int i = 0; i < phones.length; i++) {
                Phone phone = new Phone();
                String si = String.valueOf(i);
                phone.setValue(si + si + si + si + si + si + si);
                phones[i] = phone;
                pu.save(phones[i]);
            }

            Person person = new Person();
            person.setName("Hammadi");

            person.setPhone2(phones[2]);

            pu.save(person);

            person.setPhone2(phones[2]);
            pu.save(person);

            Person alia = new Person();
            alia.setName("Alia");
            alia.setPhone2(phones[3]);
            alia.setParent(person);
            pu.save(alia);
        }

        public void testQuery() {
            PersistenceUnit pu = UPA.getPersistenceGroup().getPersistenceUnit();
            Query q = pu.createQuery("Select a from Person a ")
                    .setHint(QueryHints.FETCH_STRATEGY, QueryFetchStrategy.SELECT);
            List<Person> r = q.getResultList();
            r.size();
            for (Person doc : r) {
                System.out.println(doc);
            }
        }

        public void testQuery2() {
            PersistenceUnit pu = UPA.getPersistenceGroup().getPersistenceUnit();
            Query q = pu.createQuery("Select a.phone2 from Person a ")
                    .setHint(QueryHints.FETCH_STRATEGY, QueryFetchStrategy.JOIN);
            List r = q.getResultList();
            r.size();
            for (Object doc : r) {
                System.out.println(doc);
            }
        }

        public void testQuery3() {
            PersistenceUnit pu = UPA.getPersistenceGroup().getPersistenceUnit();
            Query q = pu.createQuery("Select a.parent.phone2.value from Person a ");
            List r = q.getResultList();
            r.size();
            for (Object doc : r) {
                System.out.println(doc);
            }
        }

        public void testQuery4() {
            PersistenceUnit pu = UPA.getPersistenceGroup().getPersistenceUnit();
            Query q = pu.createQuery("Select a,a.parent.phone2.value from Person a ");
            List r = q.getResultList();
            r.size();
            for (Object doc : r) {
                Assert.assertEquals(Object[].class,doc.getClass());
                Object[] row = (Object[]) doc;
                Assert.assertEquals(Person.class,row[0].getClass());
                Assert.assertTrue(row[1]==null || String.class.isInstance(row[1]));

                System.out.println(Arrays.toString(row));
            }
        }

    }

    @Ignore
    @net.vpc.upa.config.Entity
    public static class Person {

        @Id
        @net.vpc.upa.config.Sequence
        private Integer id;

        private String name;

        private Phone phone2;
        private Person parent;

        public Person getParent() {
            return parent;
        }

        public void setParent(Person parent) {
            this.parent = parent;
        }

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

        @Override
        public String toString() {
            return "Person{" +
                    "id=" + id +
                    ", name='" + name + '\'' +
                    ", phone2=" + phone2 +
                    ", parent=" + parent +
                    '}';
        }
    }

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
    }
}
