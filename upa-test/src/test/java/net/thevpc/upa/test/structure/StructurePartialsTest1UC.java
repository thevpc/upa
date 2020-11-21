package net.thevpc.upa.test.structure;

import java.util.List;

import net.thevpc.upa.Entity;
import net.thevpc.upa.Field;
import net.thevpc.upa.Document;
import net.thevpc.upa.PersistenceUnit;
import net.thevpc.upa.UPA;
import net.thevpc.upa.config.*;
import net.thevpc.upa.test.util.PUUtils;
import org.junit.Assert;
import org.junit.BeforeClass;
import org.junit.Test;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class StructurePartialsTest1UC {

    private static final java.util.logging.Logger log = java.util.logging.Logger.getLogger(StructurePartialsTest1UC.class.getName());

    private static Business bo;

    @BeforeClass
    public static void setup() {
//        PUUtils.deleteTestPersistenceUnits(StructurePartialsTest1UC.class);
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(StructurePartialsTest1UC.class);
        pu.scan(UPA.getContext().getFactory().createClassScanSource(new Class[]{
            A.class,
            B.class,
            C.class,
            D.class,
            E.class,
            F.class, //this is a plain class, will not be loaded as entity
            G.class,
            H.class,}), null, true);
        pu.start();
        bo = UPA.makeSessionAware(new Business());
        bo.init();
    }

    @net.thevpc.upa.config.Entity
//    @PropertyAccess(PropertyAccessType.FIELD)
    public static class A {

        int a;
    }

    @net.thevpc.upa.config.Entity(name = "A")
    public static class B {

        int b;
    }

    @net.thevpc.upa.config.Entity(name = "B", entityType = A.class)
    public static class C {

        int c;
    }

    @net.thevpc.upa.config.Entity(name = "A")
    public static class D {

        int d;
    }

    @net.thevpc.upa.config.Entity(entityType = A.class)
    public static class E {

        int e;
    }

    public static class F {

        int f;
    }

    @net.thevpc.upa.config.Entity(entityType = F.class)
    public static class G {

        int g;
    }

    @net.thevpc.upa.config.Entity(entityType = Document.class)
    public static class H {

        int h;
    }

    @Test
    public void testMe() {
        bo.testMe();
    }

    public static class Business {

        public void init() {
        }

        public void testMe() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            List<Entity> entities = pu.getEntities();
            for (Entity entity : entities) {
                System.out.println(entity.getName() + "[" + entity.getEntityType().getSimpleName() 
                        + "," + entity.getIdType().getSimpleName() 
                        + "," + entity.getEntityDescriptor() 
                        + "]");
                for (Field field : entity.getFields()) {
                    System.out.println("\t" + field.getName());
                }
            }

            Assert.assertEquals(4, entities.size());
            Assert.assertTrue(pu.containsEntity("A"));
            Assert.assertTrue(pu.containsEntity("B"));
            Assert.assertTrue(pu.containsEntity("H"));
            Assert.assertTrue(pu.containsEntity("G"));

            Entity aE = pu.getEntity("A");
            Assert.assertEquals(4, aE.getFields().size());
            Assert.assertTrue(aE.containsField("a"));
            Assert.assertTrue(aE.containsField("b"));
            Assert.assertTrue(aE.containsField("d"));
            Assert.assertTrue(aE.containsField("e"));

            Entity bE = pu.getEntity("B");
            Assert.assertEquals(2, bE.getFields().size());
            Assert.assertTrue(bE.containsField("a"));
            Assert.assertTrue(bE.containsField("c"));
            
            Entity gE = pu.getEntity("G");
            Assert.assertEquals(2, gE.getFields().size());
            Assert.assertTrue(gE.containsField("f"));
            Assert.assertTrue(gE.containsField("g"));
            
            Entity hE = pu.getEntity("H");
            Assert.assertEquals(1, hE.getFields().size());
            Assert.assertTrue(hE.containsField("h"));
        }

    }
}
