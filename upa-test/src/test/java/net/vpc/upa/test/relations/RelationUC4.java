package net.vpc.upa.test.relations;

import net.vpc.upa.*;
import net.vpc.upa.config.Id;
import net.vpc.upa.test.util.PUUtils;
import org.junit.Assert;
import org.junit.BeforeClass;
import org.junit.Test;

import java.util.List;
import java.util.logging.Logger;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class RelationUC4 {

    private static final Logger log = Logger.getLogger(RelationUC4.class.getName());
    private static Business bo;

    @BeforeClass
    public static void setup() {
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(RelationUC4.class);
        pu.addEntity(A.class);
        pu.addEntity(B.class);
        pu.addEntity(C.class);
        pu.addEntity(D.class);
        pu.addEntity(E.class);
        pu.addEntity(F.class);
        pu.addEntity(G.class);
        pu.addEntity(H.class);
        pu.start();
        bo = UPA.makeSessionAware(new Business());
        bo.init();
    }

    @Test
    public void testInit() {

    }

    @Test
    public void testQuery() {
        bo.testQuery();
    }

    @Test
    public void testQueryEmpty() {
        bo.testQueryEmpty();
    }

    public static class Business {

        public void init() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            pu.clear();
        }

        public void testQueryEmpty() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            A person =pu.findById(A.class,-12456); //should return null
        }

        public void testQuery() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            Query q = pu.createQuery("Select a.b.c.d.e.f.g.h from A");
            List<Document> r = q.getDocumentList();
            for (Document document : r) {
                System.out.println(r);
            }
        }


    }

    @net.vpc.upa.config.Entity(modifiers = EntityModifier.CLEAR)
    public static class A {

        @Id
        @net.vpc.upa.config.Sequence
        private Integer id;
        private String name;
        private B b;

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

        public B getB() {
            return b;
        }

        public void setB(B b) {
            this.b = b;
        }

        @Override
        public String toString() {
            return "A{" +
                    "id=" + id +
                    ", name='" + name + '\'' +
                    ", b=" + b +
                    '}';
        }
    }

    @net.vpc.upa.config.Entity(modifiers = EntityModifier.CLEAR)
    public static class B {

        @Id
        @net.vpc.upa.config.Sequence
        private Integer id;
        private String name;
        private C c;

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

        public C getC() {
            return c;
        }

        public void setC(C c) {
            this.c = c;
        }

        @Override
        public String toString() {
            return "B{" +
                    "id=" + id +
                    ", name='" + name + '\'' +
                    ", c=" + c +
                    '}';
        }
    }

    @net.vpc.upa.config.Entity(modifiers = EntityModifier.CLEAR)
    public static class C {

        @Id
        @net.vpc.upa.config.Sequence
        private Integer id;
        private String name;
        private D d;

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

        public D getD() {
            return d;
        }

        public void setD(D d) {
            this.d = d;
        }

        @Override
        public String toString() {
            return "C{" +
                    "id=" + id +
                    ", name='" + name + '\'' +
                    ", d=" + d +
                    '}';
        }
    }

    @net.vpc.upa.config.Entity(modifiers = EntityModifier.CLEAR)
    public static class D {

        @Id
        @net.vpc.upa.config.Sequence
        private Integer id;
        private String name;
        private E e;

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

        public E getE() {
            return e;
        }

        public void setE(E e) {
            this.e = e;
        }

        @Override
        public String toString() {
            return "D{" +
                    "id=" + id +
                    ", name='" + name + '\'' +
                    ", e=" + e +
                    '}';
        }
    }

    @net.vpc.upa.config.Entity(modifiers = EntityModifier.CLEAR)
    public static class E {

        @Id
        @net.vpc.upa.config.Sequence
        private Integer id;
        private String name;
        private F f;

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

        public F getF() {
            return f;
        }

        public void setF(F f) {
            this.f = f;
        }

        @Override
        public String toString() {
            return "E{" +
                    "id=" + id +
                    ", name='" + name + '\'' +
                    ", f=" + f +
                    '}';
        }
    }

    @net.vpc.upa.config.Entity(modifiers = EntityModifier.CLEAR)
    public static class F {

        @Id
        @net.vpc.upa.config.Sequence
        private Integer id;
        private String name;
        private G g;

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

        public G getG() {
            return g;
        }

        public void setG(G g) {
            this.g = g;
        }

        @Override
        public String toString() {
            return "F{" +
                    "id=" + id +
                    ", name='" + name + '\'' +
                    ", g=" + g +
                    '}';
        }
    }

    @net.vpc.upa.config.Entity(modifiers = EntityModifier.CLEAR)
    public static class G {

        @Id
        @net.vpc.upa.config.Sequence
        private Integer id;
        private String name;
        private H h;

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

        public H getH() {
            return h;
        }

        public void setH(H h) {
            this.h = h;
        }

        @Override
        public String toString() {
            return "G{" +
                    "id=" + id +
                    ", name='" + name + '\'' +
                    ", h=" + h +
                    '}';
        }
    }

    @net.vpc.upa.config.Entity(modifiers = EntityModifier.CLEAR)
    public static class H {

        @Id
        @net.vpc.upa.config.Sequence
        private Integer id;
        private String name;

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

        @Override
        public String toString() {
            return "H{" +
                    "id=" + id +
                    ", name='" + name + '\'' +
                    '}';
        }
    }

}
