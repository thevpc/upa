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
public class EnumUC {

    static {
        LogUtils.prepare();
    }
    static Logger log = Logger.getLogger(EnumUC.class.getName());

    @Test
    public void crudMixedRecordsAndEntities() {
        String puId = getClass().getName();
        log.fine("********************************************");
        log.fine(" " + puId);
        log.fine("********************************************");
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(getClass());
        pu.addEntity(Data.class);
        pu.start();
        Business bo = UPA.makeSessionAware(new Business());
        bo.process();
    }

    public static class Business {

        public void process() {
            PersistenceUnit pu = UPA.getPersistenceGroup().getPersistenceUnit();


            Data val = new Data();
            val.setStatus(Status.INVALID);
            pu.persist(val);

            List<Data> entityList = pu.createQuery("Select a from Data a").getResultList();
            for (Data c : entityList) {
                System.out.println(c);
            }
        }
    }

    public static enum Status {

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
