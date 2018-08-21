package net.vpc.upa.test.runtime;

import net.vpc.upa.test.types.*;
import java.util.List;
import java.util.logging.Logger;
import net.vpc.upa.*;
import net.vpc.upa.config.Id;
import net.vpc.upa.config.Ignore;
import net.vpc.upa.impl.util.UPADeadLock;
import net.vpc.upa.test.util.PUUtils;
import org.junit.Assert;
import org.junit.BeforeClass;
import org.junit.Test;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class RuntimeClosingResultSetsUC {

    private static final Logger log = Logger.getLogger(RuntimeClosingResultSetsUC.class.getName());

    private static Business bo;
    @BeforeClass
    public static void setup() {
        PUUtils.configure();
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(RuntimeClosingResultSetsUC.class);
        pu.addEntity(Data.class);
        pu.start();
        bo = UPA.makeSessionAware(new Business());
        bo.init();
    }

    @Test
    public void process() {
        bo.process();
        System.out.println(UPADeadLock.getCurrentMonitorsCount());
        UPADeadLock.checkDeadLocks();
        Assert.assertEquals(0, UPADeadLock.getCurrentMonitorsCount());
    }

    public static class Business {

        public void init() {

        }
        public void process() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            List<Data> entityList;
            pu.createQuery("Delete from Data").executeNonQuery();
            final Query findAll = pu.createQuery("Select a from Data a");
            entityList = findAll.getResultList();
            Assert.assertTrue(entityList.size() == 0);
//            if(true){
//                return;
//            }
            Data val0 = new Data();
            val0.setName("hello0");
            val0.setPassword("hello");
            pu.persist(val0);

            Data val1 = new Data();
            val1.setName("hello1");
            val1.setPassword("hello");
            pu.persist(val1);

            Data val2 = new Data();
            val2.setName("hello2");
            val2.setPassword("hello");
            pu.persist(val2);

            Data val3 = new Data();
            val3.setName("hello3");
            val3.setPassword("new password");
            pu.persist(val3);


            entityList = findAll.getResultList();
            Assert.assertTrue(entityList.size() == 4);
            for (Data c : entityList) {
                Assert.assertEquals(c.getPassword(), "****");
            }
            val1.setPassword("new password");
            pu.update(val1);

            // SQL Query
            PUUtils.println(pu.getConnection().executeQuery("Select * from TypesPasswordUC_DATA", null, null, false));

            Query findByPassword = pu.createQuery("Select a from Data a where a.password=:p");

            entityList = findByPassword
                    .setParameter("p", "hello")
                    .getResultList();
            Assert.assertEquals(2,entityList.size());

            entityList = findByPassword
                    .setParameter("p", "new password")
                    .getResultList();
            Assert.assertTrue(entityList.size() == 2);
        }
    }

    @Ignore
    @net.vpc.upa.config.Entity
    public static class Data {

        @Id
        @net.vpc.upa.config.Sequence
        private Integer id;
        @net.vpc.upa.config.Password
        private String password;
        private String name;

        public String getName() {
            return name;
        }

        public void setName(String name) {
            this.name = name;
        }

        public Integer getId() {
            return id;
        }

        public void setId(Integer id) {
            this.id = id;
        }

        public String getPassword() {
            return password;
        }

        public void setPassword(String password) {
            this.password = password;
        }

        @Override
        public String toString() {
            return "Data{" + "id=" + id + ", password=" + password + '}';
        }

    }
}
