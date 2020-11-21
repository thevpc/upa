package net.thevpc.upa.test.v1_0_2_29.syntax;

import java.util.Date;
import java.util.List;
import java.util.logging.Logger;

import net.thevpc.upa.config.Id;
import net.thevpc.upa.config.Ignore;
import net.thevpc.upa.test.v1_0_2_29.util.PUUtils;
import org.junit.BeforeClass;
import org.junit.Test;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class ReservedWordsUC {

    private static final Logger log = Logger.getLogger(ReservedWordsUC.class.getName());
    private static Business bo;

    @BeforeClass
    public static void setup() {
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(ReservedWordsUC.class);
        pu.addEntity(From.class);
        pu.start();
        bo = UPA.makeSessionAware(new Business());
        bo.init();
    }

    @Test
    public void testQuery() {
        bo.testQuery();
    }

    public static class Business {

        public void init() {

        }
        public void testQuery() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            Query q = pu.createQuery("Select a from `From` a");
            List<Record> r = q.getRecordList();
            for (Record document : r) {
                System.out.println(document);
            }
        }
    }

    @Ignore
    @net.thevpc.upa.config.Entity
    public static class From {

        @Id
        @net.thevpc.upa.config.Sequence
        private Integer id;
        private String select;
        private Integer update;
        private String primary;
        private Date order;

        public Integer getId() {
            return id;
        }

        public void setId(Integer id) {
            this.id = id;
        }

        public String getSelect() {
            return select;
        }

        public void setSelect(String select) {
            this.select = select;
        }

        public Integer getUpdate() {
            return update;
        }

        public void setUpdate(Integer update) {
            this.update = update;
        }

        public String getPrimary() {
            return primary;
        }

        public void setPrimary(String primary) {
            this.primary = primary;
        }

        public Date getOrder() {
            return order;
        }

        public void setOrder(Date order) {
            this.order = order;
        }
    }


}
