package net.vpc.upa.test.temp;

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
public class PartialsTest1UC {

    private static final java.util.logging.Logger log = java.util.logging.Logger.getLogger(PartialsTest1UC.class.getName());

    private static Business bo;

    @BeforeClass
    public static void setup() {
//        PUUtils.deleteTestPersistenceUnit(PartialsTest1UC.class);
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(PartialsTest1UC.class);
        pu.scan(UPA.getContext().getFactory().createClassScanSource(new Class[]{
            A.class,
            B.class,
            C.class,
            D.class
        }), null, true);
        pu.start();
        bo = UPA.makeSessionAware(new Business());
        bo.init();
    }

    @Entity
//    @PropertyAccess(PropertyAccessType.FIELD)
    public static class A {
        int x;
    }

    @Entity(name = "A")
    public static class B {

        int y;
    }

    @Entity(name = "B", entityType = A.class)
    public static class C {

        int z;
    }

    @Entity(name = "A")
    public static class D {

        int y;
    }

    @Test
    public void testMe() {
        bo.testMe();
    }

    public static class Business {

        public void init() {
        }

        public void testMe() {
//            PersistenceUnit pu = UPA.getPersistenceUnit();
//
//            Client client = new Client("sample client");
//            pu.persist(client);
//
//            ClientOrCompanyView clientView = pu.findById(ClientOrCompanyView.class, "client-" + client.getId());
//
//            ClientOrder clientOrder = new ClientOrder(new Date(), clientView);
//            clientOrder.setClientView(clientView);
//            pu.persist(clientOrder);
//
////            Assert.assertEquals(Client.class, uu.getClass());
        }

    }
}
