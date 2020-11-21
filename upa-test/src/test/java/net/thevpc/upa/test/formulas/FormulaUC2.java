package net.thevpc.upa.test.formulas;

import net.thevpc.upa.EntityModifier;
import net.thevpc.upa.FormulaType;
import net.thevpc.upa.Query;
import net.thevpc.upa.UPA;
import net.thevpc.upa.config.*;

import net.thevpc.upa.test.util.PUUtils;
import org.junit.Assert;
import org.junit.BeforeClass;
import org.junit.Test;

import java.util.List;
import java.util.logging.Logger;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class FormulaUC2 {

    private static final Logger log = Logger.getLogger(FormulaUC2.class.getName());
    private static Business bo;
    @BeforeClass
    public static void setup() {
        PUUtils.reset();
        net.thevpc.upa.PersistenceUnit pu = PUUtils.createTestPersistenceUnit(FormulaUC2.class);
        pu.addEntity(Person.class);
        pu.start();
        bo = UPA.makeSessionAware(new Business());
        bo.init();
    }

    @Test
    public void testQuery2() {
        bo.testQuery2();
    }

    public static class Business {

        public void init() {
            net.thevpc.upa.PersistenceUnit pu = UPA.getPersistenceUnit();
            pu.clear();
        }

        public void testQuery2() {
            net.thevpc.upa.PersistenceUnit pu = UPA.getPersistenceUnit();
            Query q = pu.createQuery("Select a from Person a");
            List<Person> r = q.getResultList();
            Assert.assertEquals(0,r.size());

            Person persisted = new Person();
            persisted.setName("Hammadi");
            Assert.assertEquals(null,persisted.getId());
            pu.persist(persisted);
            Assert.assertTrue(persisted.getId()!=null && persisted.getId().intValue()>0);

            Person expected = new Person();
            expected.setId(persisted.getId());
            expected.setName("Hammadi");
            expected.setGoodName("HammadiHammadi");
            expected.setGoodName2("Hammadi"+persisted.getId());


            q = pu.createQuery("Select a from Person a");
            r = q.getResultList();
            Assert.assertEquals(1,r.size());
            for (Person person : r) {
                System.out.println(person);
            }
            Assert.assertEquals(expected,r.get(0));
        }


    }

    @Ignore
    @Entity(modifiers = EntityModifier.CLEAR)
    public static class Person {

        @Id
        @Sequence
        private Integer id;

        private String name;

        @Formula(formulaType = FormulaType.LIVE, value = "concat(this.name,this.name)")
        private String goodName;

        @Formula(formulaType = FormulaType.LIVE, value = "concat(this.name,this.id)")
        private String goodName2;

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

        public String getGoodName2() {
            return goodName2;
        }

        public void setGoodName2(String goodName2) {
            this.goodName2 = goodName2;
        }

        @Override
        public String toString() {
            return "Person{" +
                    "id=" + id +
                    ", name='" + name + '\'' +
                    ", goodName='" + goodName + '\'' +
                    ", goodName2='" + goodName2 + '\'' +
                    '}';
        }

        @Override
        public boolean equals(Object o) {
            if (this == o) return true;
            if (o == null || getClass() != o.getClass()) return false;

            Person person = (Person) o;

            if (id != null ? !id.equals(person.id) : person.id != null) return false;
            if (name != null ? !name.equals(person.name) : person.name != null) return false;
            if (goodName != null ? !goodName.equals(person.goodName) : person.goodName != null) return false;
            return goodName2 != null ? goodName2.equals(person.goodName2) : person.goodName2 == null;
        }

        @Override
        public int hashCode() {
            int result = id != null ? id.hashCode() : 0;
            result = 31 * result + (name != null ? name.hashCode() : 0);
            result = 31 * result + (goodName != null ? goodName.hashCode() : 0);
            result = 31 * result + (goodName2 != null ? goodName2.hashCode() : 0);
            return result;
        }
    }




}
