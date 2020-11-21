package net.thevpc.upa.test.syntax;

import java.util.Date;
import java.util.List;
import java.util.logging.Logger;

import net.thevpc.upa.Document;
import net.thevpc.upa.PersistenceUnit;
import net.thevpc.upa.Query;
import net.thevpc.upa.UPA;
import net.thevpc.upa.config.Entity;
import net.thevpc.upa.config.Sequence;

import net.thevpc.upa.config.Id;
import net.thevpc.upa.config.Ignore;
import net.thevpc.upa.test.util.PUUtils;
import org.junit.BeforeClass;
import org.junit.Test;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class SyntaxReservedWordsUC {

    private static final Logger log = Logger.getLogger(SyntaxReservedWordsUC.class.getName());
    private static Business bo;

    @BeforeClass
    public static void setup() {
        PUUtils.reset();
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(SyntaxReservedWordsUC.class);
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
    @Entity
    public static class From {

        @Id
        @Sequence
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
