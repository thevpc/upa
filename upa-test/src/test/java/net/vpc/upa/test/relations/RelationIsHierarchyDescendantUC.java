package net.vpc.upa.test.relations;

import junit.framework.Assert;
import net.vpc.upa.*;
import net.vpc.upa.config.Hierarchy;
import net.vpc.upa.config.Id;
import net.vpc.upa.config.Main;
import net.vpc.upa.test.util.PUUtils;
import org.junit.BeforeClass;
import org.junit.Test;

import java.util.List;
import java.util.logging.Logger;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class RelationIsHierarchyDescendantUC {

    private static final Logger log = Logger.getLogger(RelationIsHierarchyDescendantUC.class.getName());

    private static Business bo;
    @BeforeClass
    public static void setup() {
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(RelationIsHierarchyDescendantUC.class);
//        pu.scan(null);
        pu.addEntity(Node.class);
        pu.addEntity(Person.class);
        pu.start();

        bo = UPA.makeSessionAware(new Business());
        bo.init();

    }
    @Test
    public void testQuery0() {
        bo.testQuery0();
    }
    @Test
    public void testQuery1() {
        bo.testQuery1();
    }
    public static class Business {
        Node a;
        Node b;
        Node c;
        Node d;
        public void init() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            pu.reset();

            a=new Node("a",null);
            b=new Node("b",a);
            c=new Node("c",a);
            d=new Node("d",b);

            Person pa=new Person("a",a);
            Person pb=new Person("b",b);
            Person pc=new Person("c",c);
            Person pd=new Person("d",d);

            pu.persist(a);
            pu.persist(b);
            pu.persist(c);
            pu.persist(d);

            pu.persist(pa);
            pu.persist(pb);
            pu.persist(pc);
            pu.persist(pd);


        }
        public void testQuery0() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            //ancestorExpression, childExpression, entityName
            Query q = pu.createQuery("Select a from Node a where IsHierarchyDescendant(:p,a,Node)").setParameter("p",a.getId());
            List<Document> t = q.getDocumentList();
            Assert.assertEquals(4,t.size()); //a,b,c,d
            for (Document r : t) {
                System.out.println(r);
            }

            q = pu.createQuery("Select a from Node a where IsHierarchyDescendant(:p,a,Node)").setParameter("p",b);
            t = q.getDocumentList();
            Assert.assertEquals(2,t.size()); //b,d
            for (Document r : t) {
                System.out.println(r);
            }
        }

        public void testQuery1() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            //ancestorExpression, childExpression, entityName
            Query q = pu.createQuery("Select a from Person a where IsHierarchyDescendant(:p,a.node,Node)").setParameter("p",a.getId());
            List<Document> t = q.getDocumentList();
            Assert.assertEquals(4,t.size()); //a,b,c,d
            for (Document r : t) {
                System.out.println(r);
            }

//            q = pu.createQuery("Select a from Node a where IsHierarchyDescendant(:p,a.node,Node)").setParameter("p",b);
//            t = q.getDocumentList();
//            Assert.assertEquals(2,t.size()); //b,d
//            for (Document r : t) {
//                System.out.println(r);
//            }
        }

    }


    @net.vpc.upa.config.Entity(modifiers = EntityModifier.CLEAR)
    public static class Person {

        @Id
        @net.vpc.upa.config.Sequence
        private Integer id;

        @Main
        private String name;

        private Node node;

        public Person() {
        }

        public Person(String name, Node node) {
            this.name = name;
            this.node = node;
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

        public Node getNode() {
            return node;
        }

        public void setNode(Node node) {
            this.node = node;
        }
    }

    @net.vpc.upa.config.Entity(modifiers = EntityModifier.CLEAR)
    public static class Node {

        @Id
        @net.vpc.upa.config.Sequence
        private Integer id;

        @Main
        private String name;

        @Hierarchy
        private Node parent;

        public Node() {
        }

        public Node(String name, Node parent) {
            this.name = name;
            this.parent = parent;
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

        public Node getParent() {
            return parent;
        }

        public void setParent(Node parent) {
            this.parent = parent;
        }

        @Override
        public String toString() {
            return "Node{" +
                    "id=" + id +
                    ", name='" + name + '\'' +
                    ", parent=" + parent +
                    '}';
        }
    }

}
