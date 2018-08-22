package net.vpc.upa.test.types;

import java.util.List;
import java.util.logging.Logger;
import net.vpc.upa.*;
import net.vpc.upa.config.ToString;
import net.vpc.upa.config.Id;
import net.vpc.upa.config.Ignore;
import net.vpc.upa.config.Password;
import net.vpc.upa.config.Secret;
import net.vpc.upa.config.ToByteArray;
import net.vpc.upa.config.StringEncoderType;
import net.vpc.upa.test.util.PUUtils;
import org.junit.Assert;
import org.junit.BeforeClass;
import org.junit.Test;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class TypesSecretUC {

    private static final Logger log = Logger.getLogger(TypesSecretUC.class.getName());

    private static Business bo;
    @BeforeClass
    public static void setup() {
        PUUtils.reset();
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(TypesSecretUC.class);
        pu.addEntity(Data.class);
        pu.start();
        bo = UPA.makeSessionAware(new Business());
    }


    @Test
    public void run() {

        bo = UPA.makeSessionAware(new Business());
        bo.process();
    }

    public static class Business {

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
            val0.setPassword("hello");
            val0.setName("hello0");
            val0.setSomeIntStoredAsBizarreHash(152);
            val0.setSomeLongStoredAsHex(255);
            pu.persist(val0);

//            Data val1 = new Data();
//            val1.setPassword("hello");
//            val1.setName("hello1");
//            pu.insert(val1);
//
//            Data val2 = new Data();
//            val2.setPassword("hello");
//            val2.setName("hello2");
//            pu.insert(val2);
//
//            Data val3 = new Data();
//            val3.setPassword("new password");
//            val3.setName("hello3");
//            pu.insert(val3);
//            entityList = findAll.getEntityList();
//            Assert.assertTrue(entityList.size() == 4);
//            for (Data c : entityList) {
//                Assert.assertEquals(c.getPassword(), "****");
//            }
//            val1.setPassword("new password");
//            pu.update(val1);
//            Query findByPassword = pu.createQuery("Select a from Data a where a.password=:p");
//
//            entityList = findByPassword
//                    .setParameter("p", "hello")
//                    .getEntityList();
//            Assert.assertTrue(entityList.size() == 2);
//
//            entityList = findByPassword
//                    .setParameter("p", "new password")
//                    .getEntityList();
//            Assert.assertTrue(entityList.size() == 2);
        }
    }

    @Ignore
    @net.vpc.upa.config.Entity
    public static class Data {

        @Id
        @net.vpc.upa.config.Sequence
        private Integer id;
//        @Secret
        private String password;
        private String name;

        @ToString(StringEncoderType.BASE64)
        @ToByteArray
        @Secret
        @Password
        private int someLongStoredAsHex;

        @ToString(StringEncoderType.HEXADECIMAL)
        @ToByteArray
        @Secret
        @Password
        private int someIntStoredAsBizarreHash;

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

        public int getSomeIntStoredAsBizarreHash() {
            return someIntStoredAsBizarreHash;
        }

        public void setSomeIntStoredAsBizarreHash(int someIntStoredAsBizarreHash) {
            this.someIntStoredAsBizarreHash = someIntStoredAsBizarreHash;
        }

        public int getSomeLongStoredAsHex() {
            return someLongStoredAsHex;
        }

        public void setSomeLongStoredAsHex(int someLongStoredAsHex) {
            this.someLongStoredAsHex = someLongStoredAsHex;
        }

        @Override
        public String toString() {
            return "Data{" + "id=" + id + ", name=" + name + ", password=" + password + '}';
        }

    }
}
