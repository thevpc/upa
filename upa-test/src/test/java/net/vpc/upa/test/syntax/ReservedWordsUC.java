package net.vpc.upa.test.syntax;

import java.util.Date;
import java.util.List;
import java.util.logging.Logger;
import net.vpc.upa.*;
import net.vpc.upa.test.util.LogUtils;
import net.vpc.upa.config.Id;
import net.vpc.upa.config.Ignore;
import net.vpc.upa.test.util.PUUtils;
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
            List<Document> r = q.getDocumentList();
            for (Document document : r) {
                System.out.println(document);
            }
        }
    }

    @Ignore
    @net.vpc.upa.config.Entity
    public static class From {

        @Id
        @net.vpc.upa.config.Sequence
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
