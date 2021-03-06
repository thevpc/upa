package net.thevpc.upa.test.entitypatterns;

import net.thevpc.upa.Entity;
import net.thevpc.upa.Document;
import net.thevpc.upa.PersistenceUnit;
import net.thevpc.upa.UPA;
import net.thevpc.upa.config.Id;
import net.thevpc.upa.config.Main;
import net.thevpc.upa.config.Sequence;
import net.thevpc.upa.config.View;
import net.thevpc.upa.config.*;
import net.thevpc.upa.persistence.QueryResult;
import net.thevpc.upa.persistence.UConnection;
import net.thevpc.upa.test.util.PUUtils;
import org.junit.Assert;
import org.junit.BeforeClass;
import org.junit.Test;

import java.util.List;
import net.thevpc.upa.DefaultFieldBuilder;
import net.thevpc.upa.Session;
import net.thevpc.upa.ViewEntityExtensionDefinition;
import net.thevpc.upa.impl.config.DefaultViewEntityExtensionDefinition;
import net.thevpc.upa.types.DataTypeFactory;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class PatternAlterViewUC {

    private static final java.util.logging.Logger log = java.util.logging.Logger.getLogger(PatternAlterViewUC.class.getName());

    private static Business bo;

    @BeforeClass
    public static void setup() {
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(PatternAlterViewUC.class);
        pu.addEntity(Client.class);
        pu.addEntity(ClientView.class);
        pu.start();
        bo = UPA.makeSessionAware(new Business());
        bo.init();
    }

    @View(query = "Select a.id id, a.name name from Client a")
    public static class ClientView {

        @Id
        private int id;
        @Main
        private String name;

        public int getId() {
            return id;
        }

        public void setId(int id) {
            this.id = id;
        }

        public String getName() {
            return name;
        }

        public void setName(String name) {
            this.name = name;
        }

    }

    public static class Client {

        @Id
        @Sequence
        private int id;
        @Main
        private String name;

        public String getName() {
            return name;
        }

        public void setName(String name) {
            this.name = name;
        }

        public int getId() {
            return id;
        }

        public Client setId(int id) {
            this.id = id;
            return this;
        }
    }

    @Test
    public void testMe() {
        bo.testMe();
    }

    @Test
    public void testAlter() {
        PersistenceUnit pu = UPA.getPersistenceUnit();
        Session s = pu.openSession();
        pu.beginStructureModification();
        Entity entity = pu.getEntity("ClientView");
        entity.setExtensionDefinition(ViewEntityExtensionDefinition.class,
                new DefaultViewEntityExtensionDefinition("Select a.id id, a.name name , 'client' type from Client a")
        );
        entity.addField(new DefaultFieldBuilder().setName("type").setDataType(DataTypeFactory.STRING));
        pu.commitStructureModification();
        s.close();
        bo.nativeQuery();
        bo.testMe();
    }

    public static class Business {

        public void init() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            pu.clear(Client.class, null);
        }

        public void nativeQuery() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            UConnection c = pu.getConnection();
            QueryResult q = c.executeQuery("Select ID,NAME,TYPE from PatternAlterViewUC_CLIENT_VIEW a", null, null, false);
            for (int i = 0; i < q.getColumnsCount(); i++) {
                System.out.print("  "+q.getColumnName(i)+" : "+q.getColumnType(i).getSimpleName());
            }
            System.out.println(";");
            System.out.println("---------------------------------------------------------");
            while (q.hasNext()){
                for (int i = 0; i < q.getColumnsCount(); i++) {
                    System.out.print("  "+q.read(i));
                }
                System.out.println(";");
            }
        }
        public void testMe() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            Client ic = new Client();
            ic.setName("tozz");
            pu.persist(ic);
            Object uu = pu.findById(Client.class, ic.getId());
            System.out.println(uu.getClass());
            Assert.assertEquals(Client.class, uu.getClass());
            nativeQuery();
            List<Document> r = pu.createQuery("Select a from ClientView a").getDocumentList();
            r.size();
            System.out.println(r);

        }

    }
}
