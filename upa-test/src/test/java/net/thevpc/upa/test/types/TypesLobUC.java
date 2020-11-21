package net.thevpc.upa.test.types;

import java.util.Arrays;
import java.util.List;

import net.thevpc.upa.PersistenceUnit;
import net.thevpc.upa.UPA;
import net.thevpc.upa.config.Entity;
import net.thevpc.upa.config.Sequence;
import net.thevpc.upa.test.util.PUUtils;

import net.thevpc.upa.config.Id;
import net.thevpc.upa.config.Ignore;
import org.junit.Assert;
import org.junit.BeforeClass;
import org.junit.Test;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class TypesLobUC {

    private static final java.util.logging.Logger log = java.util.logging.Logger.getLogger(TypesLobUC.class.getName());

    private static Business bo;

    @BeforeClass
    public static void setup() {
        PUUtils.reset();
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(TypesLobUC.class);
        pu.addEntity(DBFile.class);
        pu.start();
        bo = UPA.makeSessionAware(new Business());
        bo.init();
    }

    @Test
    public void process() {
        bo.process();
    }

    public static class Business {

        public void process() {
            PersistenceUnit pu = UPA.getPersistenceUnit();

            DBFile root = new DBFile();
            root.setName("root");
            byte[] bytes = "hello".getBytes();
            root.setContent(bytes);
            pu.persist(root);

            List<DBFile> entityList = pu.createQuery("Select a from DBFile a").getResultList();
            for (DBFile c : entityList) {
                System.out.println(c);
                Assert.assertArrayEquals(c.getContent(), bytes);
            }
        }

        public void init() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            pu.clear(DBFile.class, null);
        }
    }

    @Ignore
    @Entity
    public static class DBFile {

        @Id
        @Sequence
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
