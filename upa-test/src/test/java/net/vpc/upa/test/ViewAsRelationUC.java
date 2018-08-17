package net.vpc.upa.test;

import java.util.Date;
import net.vpc.upa.Document;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.UPA;
import net.vpc.upa.config.*;
import net.vpc.upa.test.util.PUUtils;
import org.junit.Assert;
import org.junit.BeforeClass;
import org.junit.Test;

import java.util.List;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class ViewAsRelationUC {

    private static final java.util.logging.Logger log = java.util.logging.Logger.getLogger(ViewAsRelationUC.class.getName());

    private static Business bo;

    @BeforeClass
    public static void setup() {
        PUUtils.deleteTestPersistenceUnit(ViewAsRelationUC.class);
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(ViewAsRelationUC.class);
        pu.addEntity(Client.class);
        pu.addEntity(ClientView.class);
        pu.addEntity(ClientOrder.class);
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
            
            ClientView clientView = pu.findById(ClientView.class, client.getId());

            ClientOrder clientOrder = new ClientOrder(new Date(),clientView);
            pu.persist(clientOrder);

//            Assert.assertEquals(Client.class, uu.getClass());


        }

    }
}
