package net.vpc.upa.test;

import java.util.Arrays;
import java.util.List;
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
public class LobUC {

    static {
        LogUtils.prepare();
    }
    private static final java.util.logging.Logger log = java.util.logging.Logger.getLogger(LobUC.class.getName());

    @Test
    public void crudMixedDocumentsAndEntities() {
        String puId = getClass().getName();
        log.fine("********************************************");
        log.fine(" " + puId);
        log.fine("********************************************");
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(getClass());
        pu.addEntity(DBFile.class);
        pu.start();
        Business bo = UPA.makeSessionAware(new Business());
        bo.process();
    }

    public static class Business {

        public void process() {
            PersistenceUnit pu = UPA.getPersistenceGroup().getPersistenceUnit();


            DBFile root = new DBFile();
            root.setName("root");
            root.setContent("hello".getBytes());
            pu.persist(root);

            List<DBFile> entityList = pu.createQuery("Select a from DBFile a").getResultList();
            for (DBFile c : entityList) {
                System.out.println(c);
            }
        }
    }

    @Ignore
    @net.vpc.upa.config.Entity
    public static class DBFile {

        @Id
        @net.vpc.upa.config.Sequence
        private Integer id;
        private String name;
        private byte[] content;

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

        public byte[] getContent() {
            return content;
        }

        public void setContent(byte[] content) {
            this.content = content;
        }

        @Override
        public String toString() {
            return "DBFile{" + "id=" + id + ", name=" + name + ", content=" + Arrays.toString(content) + '}';
        }
        
    }
}
