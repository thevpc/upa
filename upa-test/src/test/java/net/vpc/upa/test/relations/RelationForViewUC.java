package net.vpc.upa.test.relations;

import java.util.Date;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.UPA;
import net.vpc.upa.config.*;
import net.vpc.upa.test.util.PUUtils;
import org.junit.BeforeClass;
import org.junit.Test;


/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class RelationForViewUC {

    private static final java.util.logging.Logger log = java.util.logging.Logger.getLogger(RelationForViewUC.class.getName());

    private static Business bo;

    @BeforeClass
    public static void setup() {
//        PUUtils.deleteTestPersistenceUnit(RelationForViewUC.class);
        PUUtils.configure();
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(RelationForViewUC.class);
        pu.scan(UPA.getContext().getFactory().createClassScanSource(new Class[]{
            Client.class,
            ClientView.class,
            ClientOrder.class
        }), null, true);
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

        public ClientView() {
        }

        public ClientView(int id, String name) {
            this.id = id;
            this.name = name;
        }

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

    @Entity
    public static class ClientOrder {

        @Id
        @Sequence
        private int id;
        private Date date;
        private ClientView clientView;

        public ClientOrder() {
        }

        public ClientOrder(Date date, ClientView clientView) {
            this.clientView = clientView;
            this.date = date;
        }

        public Date getDate() {
            return date;
        }

        public void setDate(Date date) {
            this.date = date;
        }

        public int getId() {
            return id;
        }

        public void setId(int id) {
            this.id = id;
        }

        public ClientView getClientView() {
            return clientView;
        }

        public void setClientView(ClientView clientView) {
            this.clientView = clientView;
        }

    }

    @Entity
    public static class Client {

        @Id
        @Sequence
        private int id;
        @Main
        private String name;

        public Client() {
        }

        public Client(String name) {
            this.name = name;
        }

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

    public static class Business {

        public void init() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            pu.clear(Client.class, null);
        }

        public void testMe() {
            PersistenceUnit pu = UPA.getPersistenceUnit();

            Client client = new Client("sample client");
            pu.persist(client);
            
//            ClientView clientView0=new ClientView(5,"Hello");
//            pu.persist(clientView0);
            
            ClientView clientView = pu.findById(ClientView.class, client.getId());

            ClientOrder clientOrder = new ClientOrder(new Date(),clientView);
            clientOrder.setClientView(clientView);
            pu.persist(clientOrder);

//            Assert.assertEquals(Client.class, uu.getClass());


        }

    }
}
