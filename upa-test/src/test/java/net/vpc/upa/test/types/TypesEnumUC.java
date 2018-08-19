package net.vpc.upa.test.types;

import java.util.List;
import java.util.logging.Logger;
import net.vpc.upa.*;
import net.vpc.upa.config.Id;
import net.vpc.upa.config.Ignore;
import net.vpc.upa.test.util.PUUtils;
import org.junit.Assert;
import org.junit.BeforeClass;
import org.junit.Test;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class TypesEnumUC {

    static Logger log = Logger.getLogger(TypesEnumUC.class.getName());

    private static Business bo;
    @BeforeClass
    public static void setup() {
        PUUtils.configure();
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(TypesEnumUC.class);
        pu.addEntity(Data.class);
        pu.start();
        bo = UPA.makeSessionAware(new Business());
    }

    @Test
    public void process() {
        bo.process();
    }

    public static class Business {

        public void process() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            Assert.assertEquals(TypesEnumUC.class.getSimpleName(),pu.getName());
            List<Data> entityList = pu.createQuery("Select a from Data a").getResultList();
            for (Data data : entityList) {
                pu.remove(data);
            }
            entityList = pu.createQuery("Select a from Data a").getResultList();
            Assert.assertEquals(0,entityList.size());
            Data val = new Data();
            val.setStatus(Status.INVALID);
            pu.persist(val);

            entityList = pu.createQuery("Select a from Data a").getResultList();
            for (Data c : entityList) {
                System.out.println(c);
            }
            Assert.assertEquals(1,entityList.size());
        }
    }

    public enum Status {

        VALID,
        INVALID
    }

    @Ignore
    @net.vpc.upa.config.Entity
    public static class Data {

        @Id
        @net.vpc.upa.config.Sequence
        private Integer id;
        private Status status;

        public Integer getId() {
            return id;
        }

        public void setId(Integer id) {
            this.id = id;
        }

        public Status getStatus() {
            return status;
        }

        public void setStatus(Status status) {
            this.status = status;
        }

        @Override
        public String toString() {
            return "Data{" + "id=" + id + ", status=" + status + '}';
        }
    }
}
