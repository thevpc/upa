package net.vpc.upa.test;

import java.util.List;
import java.util.logging.Logger;
import net.vpc.upa.*;
import net.vpc.upa.test.util.LogUtils;
import net.vpc.upa.config.Id;
import net.vpc.upa.config.Ignore;
import net.vpc.upa.test.util.PUUtils;
import org.junit.Test;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class FormulaUC {

    static {
        LogUtils.prepare();
    }
    private static final Logger log = Logger.getLogger(FormulaUC.class.getName());

    @Test
    public void crudMixedDocumentsAndEntities() {
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(getClass());
        pu.addEntity(Person.class);
        pu.start();

        Business bo = UPA.makeSessionAware(new Business());
        bo.testQuery2();
    }

    public static class Business {

        public void testQuery2() {
            PersistenceUnit pu = UPA.getPersistenceGroup().getPersistenceUnit();
            for (Object o : pu.findAll(Person.class)) {
                pu.remove(o);
            }
            Person pp = new Person();
            pp.setName("Hammadi");
            pu.persist(pp);

            Query q = pu.createQuery("Select a from Person a");
            List<Person> r = q.getResultList();
            for (Person person : r) {
                System.out.println(person);
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

        @net.vpc.upa.config.Formula(type = FormulaType.LIVE, value = "concat(this.name,this.name)")
        private String goodName;

        @net.vpc.upa.config.Formula(type = FormulaType.LIVE, value = "concat(this.name,i2v(this.id))")
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
    }




}
