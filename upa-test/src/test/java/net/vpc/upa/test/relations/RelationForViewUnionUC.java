package net.vpc.upa.test.relations;

import java.util.Date;
import java.util.List;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.UPA;
import net.vpc.upa.config.*;
import net.vpc.upa.test.util.PUUtils;
import org.junit.Assert;
import org.junit.BeforeClass;
import org.junit.Test;


/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class RelationForViewUnionUC {

    private static final java.util.logging.Logger log = java.util.logging.Logger.getLogger(RelationForViewUnionUC.class.getName());

    private static Business bo;

    @BeforeClass
    public static void setup() {
//        PUUtils.deleteTestPersistenceUnit(RelationForViewUnionUC.class);
        PUUtils.configure();
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(RelationForViewUnionUC.class);
        pu.scan(UPA.getContext().getFactory().createClassScanSource(new Class[]{
            Client.class,
            Company.class,
            ClientOrCompanyView.class,
            ClientOrder.class
        }), null, true);
        pu.start();
        bo = UPA.makeSessionAware(new Business());
        bo.init();
    }

    @View(query = ""
            + "Select ('client-'+a.id) id, a.name name from Client a "
            + " union "
            + "Select concat('company-',c.id) id, c.code name from Company c"
            + "")
    public static class ClientOrCompanyView {

        @Id
        private String id;
        @Main
        private String name;

        public ClientOrCompanyView() {
        }

        public ClientOrCompanyView(String id, String name) {
            this.id = id;
            this.name = name;
        }

        public String getId() {
            return id;
        }

        public void setId(String id) {
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
        private ClientOrCompanyView clientView;

        public ClientOrder() {
        }

        public ClientOrder(Date date, ClientOrCompanyView clientView) {
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

        public ClientOrCompanyView getClientView() {
            return clientView;
        }

        public void setClientView(ClientOrCompanyView clientView) {
            this.clientView = clientView;
        }

    }

    @Entity
    public static class Client {

        @Id @Sequence
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

        public void setId(int id) {
            this.id = id;
        }
    }

    @Entity
    public static class Company {

        @Id
        @Sequence
        private int id;
        @Main
        private String code;

        public Company() {
        }

        public Company(String code) {
            this.code = code;
        }

        public String getCode() {
            return code;
        }

        public void setCode(String code) {
            this.code = code;
        }
        
        public int getId() {
            return id;
        }

        public void setId(int id) {
            this.id = id;
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
            pu.clear(Company.class, null);
        }

        public void testMe() {
            PersistenceUnit pu = UPA.getPersistenceUnit();

            Client client = new Client("sample client");
            pu.persist(client);
            
            Company company = new Company("sample company");
            pu.persist(company);
            
            
            List<ClientOrCompanyView> allClientsOrCompanies = pu.findAll(ClientOrCompanyView.class);
            for (ClientOrCompanyView allClientsOrCompany : allClientsOrCompanies) {
                System.out.println(allClientsOrCompany.getId()+"  :  "+allClientsOrCompany.getName());
            }
            Assert.assertEquals(2, allClientsOrCompanies.size());
            
            ClientOrder clientOrder = new ClientOrder(new Date(),allClientsOrCompanies.get(0));
            pu.persist(clientOrder);

            ClientOrder clientOrder2=pu.reloadObject(clientOrder);
            
            Assert.assertEquals(allClientsOrCompanies.get(0).getId(), clientOrder2.getClientView().getId());

        }

    }
}
