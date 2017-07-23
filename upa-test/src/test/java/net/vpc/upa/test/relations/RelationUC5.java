package net.vpc.upa.test.relations;

import net.vpc.upa.EntityModifier;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.UPA;
import net.vpc.upa.config.Id;
import net.vpc.upa.impl.UPAImplDefaults;
import net.vpc.upa.test.util.PUUtils;
import org.junit.Assert;
import org.junit.BeforeClass;
import org.junit.Test;

import java.util.Arrays;
import java.util.HashSet;
import java.util.List;
import java.util.logging.Logger;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class RelationUC5 {

    private static final Logger log = Logger.getLogger(RelationUC5.class.getName());
    private static Business bo;

    @BeforeClass
    public static void setup() {
        UPAImplDefaults.PRODUCTION_MODE = false;
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(RelationUC5.class);
        pu.addEntity(A.class);
        pu.addEntity(B.class);
        pu.addEntity(C.class);
        pu.addEntity(D.class);
        pu.start();
        bo = UPA.makeSessionAware(new Business());
        bo.init();
    }

    @Test
    public void testInit() {

    }

    @Test
    public void testModel() {
        bo.testModel();
    }

    @Test
    public void testQuery() {
        bo.testQuery();
    }


    public static class Business {

        public void init() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            pu.clear();
            D d=new D("d");
            pu.persist(d);
            C c=new C("c");
            c.setD(d);
            pu.persist(c);
            B b=new B("b");
            b.setC(c);
            pu.persist(b);
            A a=new A("a");
            a.setB(b);
            pu.persist(a);
        }

        public void testModel() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            List<String> fieldNames = pu.getEntity(A.class).getFieldNames(null);
            System.out.println(fieldNames);
            Assert.assertEquals(new HashSet<String>(Arrays.asList("b", "name", "bId")),new HashSet<String>(fieldNames));
        }

        public void testQuery() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            List<Object> all = pu.findAll(A.class);
            Assert.assertEquals(1,all.size());
        }


    }

    @net.vpc.upa.config.Entity(modifiers = EntityModifier.CLEAR)
    public static class A {

        @Id
        private B b;
        private String name;

        public A() {
        }

        public A(String name) {
            this.name = name;
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
                    ", name='" + name + '\'' +
                    ", b=" + b +
                    '}';
        }
    }

    @net.vpc.upa.config.Entity(modifiers = EntityModifier.CLEAR)
    public static class B {

        @Id
        private C c;
        private String name;

        public B(String name) {
            this.name = name;
        }

        public B() {
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
                    ", name='" + name + '\'' +
                    ", c=" + c +
                    '}';
        }
    }

    @net.vpc.upa.config.Entity(modifiers = EntityModifier.CLEAR)
    public static class C {

        @Id
        private D d;
        private String name;

        public C(String name) {
            this.name = name;
        }

        public C() {
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

        public D(String name) {
            this.name = name;
        }

        public D() {
        }

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
            return "D{" +
                    "id=" + id +
                    ", name='" + name + '\'' +
                    '}';
        }
    }


}
