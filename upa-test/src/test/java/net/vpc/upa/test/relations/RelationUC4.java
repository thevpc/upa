package net.vpc.upa.test.relations;

import net.vpc.upa.*;
import net.vpc.upa.config.Id;
import net.vpc.upa.impl.UPAImplDefaults;
import net.vpc.upa.impl.UPAImplKeys;
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
        UPAImplDefaults.PRODUCTION_MODE=false;
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
    public void testQuery2() {
        bo.testQuery2();
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

        public void reset() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            pu.clear();
            int count = 100;
            A[] a=new A[count];
            B[] b=new B[count];
            C[] c=new C[count];
            D[] d=new D[count];
            E[] e=new E[count];
            for (int i = 0; i < count; i++) {
                a[i]=new A("a"+i);
                b[i]=new B("b"+i);
                c[i]=new C("c"+i);
                d[i]=new D("d"+i);
                e[i]=new E("e"+i);
            }
            for (int i = 0; i < count; i++) {
                a[i].setB(b[i%4]);
                b[i].setC(c[i%8]);
                c[i].setD(d[i%16]);
                d[i].setE(e[i%32]);
            }
            for (int i = 0; i < count; i++) {
                pu.persist(e[i]);
            }
            for (int i = 0; i < count; i++) {
                pu.persist(d[i]);
            }
            for (int i = 0; i < count; i++) {
                pu.persist(d[i]);
            }
            for (int i = 0; i < count; i++) {
                pu.persist(c[i]);
            }
            for (int i = 0; i < count; i++) {
                pu.persist(b[i]);
            }
            for (int i = 0; i < count; i++) {
                pu.persist(a[i]);
            }
        }

        public void testQuery2() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            reset();
            long beforeConnectionQuery=pu.getProperties().getLong(UPAImplKeys.System_Perf_Connection_Query,0);
            long beforeConnectionNonQuery=pu.getProperties().getLong(UPAImplKeys.System_Perf_Connection_NonQuery,0);
            long beforeConnectionStatement=pu.getProperties().getLong(UPAImplKeys.System_Perf_Connection_Statement,0);
            long beforeResultListMaxReduceSize=pu.getProperties().getLong(UPAImplKeys.System_Perf_ResultList_MaxReduceSize,0);

            System.out.println("before ConnectionQuery        : "+beforeConnectionQuery);
            System.out.println("before ConnectionNonQuery     : "+beforeConnectionNonQuery);
            System.out.println("before ConnectionStatement    : "+beforeConnectionStatement);
            System.out.println("before ResultListMaxReduceSize: "+beforeResultListMaxReduceSize);

            /// CHECK QueryFetchStrategy.JOIN with Navigation 5
            String PREFIX="JOIN5  ";
            pu.createQueryBuilder("A").setHint(QueryHints.FETCH_STRATEGY,QueryFetchStrategy.JOIN).setHint(QueryHints.MAX_NAVIGATION_DEPTH,5).getResultList().size();

            long afterConnectionQuery=pu.getProperties().getLong(UPAImplKeys.System_Perf_Connection_Query,0);
            long afterConnectionNonQuery=pu.getProperties().getLong(UPAImplKeys.System_Perf_Connection_NonQuery,0);
            long afterConnectionStatement=pu.getProperties().getLong(UPAImplKeys.System_Perf_Connection_Statement,0);
            long afterResultListMaxReduceSize=pu.getProperties().getLong(UPAImplKeys.System_Perf_ResultList_MaxReduceSize,0);

            System.out.println(PREFIX+"after  ConnectionQuery        : "+(afterConnectionQuery-beforeConnectionQuery)+" / "+afterConnectionQuery+" <- "+beforeConnectionQuery);
            System.out.println(PREFIX+"after  ConnectionNonQuery     : "+(afterConnectionNonQuery-beforeConnectionNonQuery)+" / "+afterConnectionNonQuery+" <- "+beforeConnectionNonQuery);
            System.out.println(PREFIX+"after  ConnectionStatement    : "+(afterConnectionStatement-beforeConnectionStatement)+" / "+afterConnectionStatement+" <- "+beforeConnectionStatement);
            System.out.println(PREFIX+"after  ResultListMaxReduceSize: "+(afterResultListMaxReduceSize-beforeResultListMaxReduceSize)+" / "+afterResultListMaxReduceSize+" <- "+beforeResultListMaxReduceSize);
            Assert.assertEquals(1, afterConnectionQuery-beforeConnectionQuery);
            Assert.assertEquals(0, afterResultListMaxReduceSize-beforeResultListMaxReduceSize);

            /// CHECK QueryFetchStrategy.JOIN with Navigation 1
            PREFIX="JOIN4  ";
            beforeConnectionQuery=afterConnectionQuery;
            beforeConnectionNonQuery=afterConnectionNonQuery;
            beforeConnectionStatement=afterConnectionStatement;
            beforeResultListMaxReduceSize=afterResultListMaxReduceSize;
            pu.createQueryBuilder("A").setHint(QueryHints.FETCH_STRATEGY,QueryFetchStrategy.JOIN).setHint(QueryHints.MAX_NAVIGATION_DEPTH,4).getResultList().size();
            afterConnectionQuery=pu.getProperties().getLong(UPAImplKeys.System_Perf_Connection_Query,0);
            afterConnectionNonQuery=pu.getProperties().getLong(UPAImplKeys.System_Perf_Connection_NonQuery,0);
            afterConnectionStatement=pu.getProperties().getLong(UPAImplKeys.System_Perf_Connection_Statement,0);
            afterResultListMaxReduceSize=pu.getProperties().getLong(UPAImplKeys.System_Perf_ResultList_MaxReduceSize,0);
            System.out.println(PREFIX+"after  ConnectionQuery        : "+(afterConnectionQuery-beforeConnectionQuery)+" / "+afterConnectionQuery+" <- "+beforeConnectionQuery);
            System.out.println(PREFIX+"after  ConnectionNonQuery     : "+(afterConnectionNonQuery-beforeConnectionNonQuery)+" / "+afterConnectionNonQuery+" <- "+beforeConnectionNonQuery);
            System.out.println(PREFIX+"after  ConnectionStatement    : "+(afterConnectionStatement-beforeConnectionStatement)+" / "+afterConnectionStatement+" <- "+beforeConnectionStatement);
            System.out.println(PREFIX+"after  ResultListMaxReduceSize: "+(afterResultListMaxReduceSize-beforeResultListMaxReduceSize)+" / "+afterResultListMaxReduceSize+" <- "+beforeResultListMaxReduceSize);
            Assert.assertEquals(1, afterConnectionQuery-beforeConnectionQuery);

            /// CHECK QueryFetchStrategy.JOIN with Navigation 1
            PREFIX="JOIN3  ";
            beforeConnectionQuery=afterConnectionQuery;
            beforeConnectionNonQuery=afterConnectionNonQuery;
            beforeConnectionStatement=afterConnectionStatement;
            beforeResultListMaxReduceSize=afterResultListMaxReduceSize;
            pu.createQueryBuilder("A").setHint(QueryHints.FETCH_STRATEGY,QueryFetchStrategy.JOIN).setHint(QueryHints.MAX_NAVIGATION_DEPTH,3).getResultList().size();
            afterConnectionQuery=pu.getProperties().getLong(UPAImplKeys.System_Perf_Connection_Query,0);
            afterConnectionNonQuery=pu.getProperties().getLong(UPAImplKeys.System_Perf_Connection_NonQuery,0);
            afterConnectionStatement=pu.getProperties().getLong(UPAImplKeys.System_Perf_Connection_Statement,0);
            afterResultListMaxReduceSize=pu.getProperties().getLong(UPAImplKeys.System_Perf_ResultList_MaxReduceSize,0);
            System.out.println(PREFIX+"after  ConnectionQuery        : "+(afterConnectionQuery-beforeConnectionQuery)+" / "+afterConnectionQuery+" <- "+beforeConnectionQuery);
            System.out.println(PREFIX+"after  ConnectionNonQuery     : "+(afterConnectionNonQuery-beforeConnectionNonQuery)+" / "+afterConnectionNonQuery+" <- "+beforeConnectionNonQuery);
            System.out.println(PREFIX+"after  ConnectionStatement    : "+(afterConnectionStatement-beforeConnectionStatement)+" / "+afterConnectionStatement+" <- "+beforeConnectionStatement);
            System.out.println(PREFIX+"after  ResultListMaxReduceSize: "+(afterResultListMaxReduceSize-beforeResultListMaxReduceSize)+" / "+afterResultListMaxReduceSize+" <- "+beforeResultListMaxReduceSize);
            Assert.assertEquals(2, afterConnectionQuery-beforeConnectionQuery);

            /// CHECK QueryFetchStrategy.JOIN with Navigation 1
            PREFIX="JOIN2  ";
            beforeConnectionQuery=afterConnectionQuery;
            beforeConnectionNonQuery=afterConnectionNonQuery;
            beforeConnectionStatement=afterConnectionStatement;
            beforeResultListMaxReduceSize=afterResultListMaxReduceSize;
            pu.createQueryBuilder("A").setHint(QueryHints.FETCH_STRATEGY,QueryFetchStrategy.JOIN).setHint(QueryHints.MAX_NAVIGATION_DEPTH,2).getResultList().size();
            afterConnectionQuery=pu.getProperties().getLong(UPAImplKeys.System_Perf_Connection_Query,0);
            afterConnectionNonQuery=pu.getProperties().getLong(UPAImplKeys.System_Perf_Connection_NonQuery,0);
            afterConnectionStatement=pu.getProperties().getLong(UPAImplKeys.System_Perf_Connection_Statement,0);
            afterResultListMaxReduceSize=pu.getProperties().getLong(UPAImplKeys.System_Perf_ResultList_MaxReduceSize,0);
            System.out.println(PREFIX+"after  ConnectionQuery        : "+(afterConnectionQuery-beforeConnectionQuery)+" / "+afterConnectionQuery+" <- "+beforeConnectionQuery);
            System.out.println(PREFIX+"after  ConnectionNonQuery     : "+(afterConnectionNonQuery-beforeConnectionNonQuery)+" / "+afterConnectionNonQuery+" <- "+beforeConnectionNonQuery);
            System.out.println(PREFIX+"after  ConnectionStatement    : "+(afterConnectionStatement-beforeConnectionStatement)+" / "+afterConnectionStatement+" <- "+beforeConnectionStatement);
            System.out.println(PREFIX+"after  ResultListMaxReduceSize: "+(afterResultListMaxReduceSize-beforeResultListMaxReduceSize)+" / "+afterResultListMaxReduceSize+" <- "+beforeResultListMaxReduceSize);
            Assert.assertEquals(2, afterConnectionQuery-beforeConnectionQuery);

            /// CHECK QueryFetchStrategy.JOIN with Navigation 1
            PREFIX="JOIN1  ";
            beforeConnectionQuery=afterConnectionQuery;
            beforeConnectionNonQuery=afterConnectionNonQuery;
            beforeConnectionStatement=afterConnectionStatement;
            beforeResultListMaxReduceSize=afterResultListMaxReduceSize;
            pu.createQueryBuilder("A").setHint(QueryHints.FETCH_STRATEGY,QueryFetchStrategy.JOIN).setHint(QueryHints.MAX_NAVIGATION_DEPTH,1).getResultList().size();
            afterConnectionQuery=pu.getProperties().getLong(UPAImplKeys.System_Perf_Connection_Query,0);
            afterConnectionNonQuery=pu.getProperties().getLong(UPAImplKeys.System_Perf_Connection_NonQuery,0);
            afterConnectionStatement=pu.getProperties().getLong(UPAImplKeys.System_Perf_Connection_Statement,0);
            afterResultListMaxReduceSize=pu.getProperties().getLong(UPAImplKeys.System_Perf_ResultList_MaxReduceSize,0);
            System.out.println(PREFIX+"after  ConnectionQuery        : "+(afterConnectionQuery-beforeConnectionQuery)+" / "+afterConnectionQuery+" <- "+beforeConnectionQuery);
            System.out.println(PREFIX+"after  ConnectionNonQuery     : "+(afterConnectionNonQuery-beforeConnectionNonQuery)+" / "+afterConnectionNonQuery+" <- "+beforeConnectionNonQuery);
            System.out.println(PREFIX+"after  ConnectionStatement    : "+(afterConnectionStatement-beforeConnectionStatement)+" / "+afterConnectionStatement+" <- "+beforeConnectionStatement);
            System.out.println(PREFIX+"after  ResultListMaxReduceSize: "+(afterResultListMaxReduceSize-beforeResultListMaxReduceSize)+" / "+afterResultListMaxReduceSize+" <- "+beforeResultListMaxReduceSize);
            Assert.assertEquals(3, afterConnectionQuery-beforeConnectionQuery);


            /// CHECK QueryFetchStrategy.JOIN with Navigation 1
            PREFIX="JOIN0  ";
            beforeConnectionQuery=afterConnectionQuery;
            beforeConnectionNonQuery=afterConnectionNonQuery;
            beforeConnectionStatement=afterConnectionStatement;
            beforeResultListMaxReduceSize=afterResultListMaxReduceSize;
            pu.createQueryBuilder("A").setHint(QueryHints.FETCH_STRATEGY,QueryFetchStrategy.JOIN).setHint(QueryHints.MAX_NAVIGATION_DEPTH,0).getResultList().size();
            afterConnectionQuery=pu.getProperties().getLong(UPAImplKeys.System_Perf_Connection_Query,0);
            afterConnectionNonQuery=pu.getProperties().getLong(UPAImplKeys.System_Perf_Connection_NonQuery,0);
            afterConnectionStatement=pu.getProperties().getLong(UPAImplKeys.System_Perf_Connection_Statement,0);
            afterResultListMaxReduceSize=pu.getProperties().getLong(UPAImplKeys.System_Perf_ResultList_MaxReduceSize,0);
            System.out.println(PREFIX+"after  ConnectionQuery        : "+(afterConnectionQuery-beforeConnectionQuery)+" / "+afterConnectionQuery+" <- "+beforeConnectionQuery);
            System.out.println(PREFIX+"after  ConnectionNonQuery     : "+(afterConnectionNonQuery-beforeConnectionNonQuery)+" / "+afterConnectionNonQuery+" <- "+beforeConnectionNonQuery);
            System.out.println(PREFIX+"after  ConnectionStatement    : "+(afterConnectionStatement-beforeConnectionStatement)+" / "+afterConnectionStatement+" <- "+beforeConnectionStatement);
            System.out.println(PREFIX+"after  ResultListMaxReduceSize: "+(afterResultListMaxReduceSize-beforeResultListMaxReduceSize)+" / "+afterResultListMaxReduceSize+" <- "+beforeResultListMaxReduceSize);
            Assert.assertEquals(5, afterConnectionQuery-beforeConnectionQuery);


            /// CHECK QueryFetchStrategy.SELECT
            PREFIX="SELECT1 ";
            beforeConnectionQuery=afterConnectionQuery;
            beforeConnectionNonQuery=afterConnectionNonQuery;
            beforeConnectionStatement=afterConnectionStatement;
            beforeResultListMaxReduceSize=afterResultListMaxReduceSize;
            pu.createQueryBuilder("A").setHint(QueryHints.FETCH_STRATEGY,QueryFetchStrategy.SELECT).getResultList().size();
            afterConnectionQuery=pu.getProperties().getLong(UPAImplKeys.System_Perf_Connection_Query,0);
            afterConnectionNonQuery=pu.getProperties().getLong(UPAImplKeys.System_Perf_Connection_NonQuery,0);
            afterConnectionStatement=pu.getProperties().getLong(UPAImplKeys.System_Perf_Connection_Statement,0);
            afterResultListMaxReduceSize=pu.getProperties().getLong(UPAImplKeys.System_Perf_ResultList_MaxReduceSize,0);
            System.out.println(PREFIX+"after  ConnectionQuery        : "+(afterConnectionQuery-beforeConnectionQuery)+" / "+afterConnectionQuery+" <- "+beforeConnectionQuery);
            System.out.println(PREFIX+"after  ConnectionNonQuery     : "+(afterConnectionNonQuery-beforeConnectionNonQuery)+" / "+afterConnectionNonQuery+" <- "+beforeConnectionNonQuery);
            System.out.println(PREFIX+"after  ConnectionStatement    : "+(afterConnectionStatement-beforeConnectionStatement)+" / "+afterConnectionStatement+" <- "+beforeConnectionStatement);
            System.out.println(PREFIX+"after  ResultListMaxReduceSize: "+(afterResultListMaxReduceSize-beforeResultListMaxReduceSize)+" / "+afterResultListMaxReduceSize+" <- "+beforeResultListMaxReduceSize);
            Assert.assertEquals(5, afterConnectionQuery-beforeConnectionQuery);

        }
        public void testQueryEmpty() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            A person = pu.findById(A.class, -12456); //should return null
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

        public A() {
        }

        public A(String name) {
            this.name = name;
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

        public B(String name) {
            this.name = name;
        }

        public B() {
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

        public C(String name) {
            this.name = name;
        }

        public C() {
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

        public E(String name) {
            this.name = name;
        }

        public E() {
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
