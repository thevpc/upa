package net.vpc.upa.test;

import java.util.List;
import net.vpc.upa.*;
import net.vpc.upa.test.util.LogUtils;
import net.vpc.upa.config.Id;
import net.vpc.upa.config.Ignore;
import net.vpc.upa.config.Hierarchy;
import net.vpc.upa.test.util.PUUtils;
import org.junit.Assert;
import org.junit.Test;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class TreeUC {

    static {
        LogUtils.prepare();
    }
    private static final java.util.logging.Logger log = java.util.logging.Logger.getLogger(TreeUC.class.getName());

    @Test
    public void crudMixedDocumentsAndEntities() {
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(getClass());
        pu.addEntity(Category.class);
        pu.addEntity(Item.class);
        pu.start();

        Business bo = UPA.makeSessionAware(new Business());
        bo.process();
    }

    public static class Business {

        public void process() {
            List<Category> entityList;
            PersistenceUnit pu = UPA.getPersistenceGroup().getPersistenceUnit();
            pu.reset();
            entityList = pu.createQuery("Select a from Category a").getResultList();

            Assert.assertSame(entityList.size(), 0);

            Category c1 = new Category("1", null);
            pu.persist(c1);

            Item a = new Item("a", c1);
            pu.persist(a);
            Item b = new Item("b", c1);
            pu.persist(b);

            Category c11 = new Category("1.1", c1);
            pu.persist(c11);
            Item c = new Item("c", c11);
            pu.persist(c);

            Category c12 = new Category("1.2", c1);
            pu.persist(c12);
            Item d = new Item("d", c12);
            pu.persist(d);

            Category c121 = new Category("1.2.1", c12);
            pu.persist(c121);
            Item e = new Item("e", c12);
            pu.persist(e);
            
            Category c122 = new Category("1.2.2", c12);
            pu.persist(c122);

            entityList = pu.createQuery("Select a from Category a").getResultList();
            Assert.assertSame(entityList.size(), 5);

            c121.setParent(c11);
            pu.update(c121);

            entityList = pu.createQuery("Select a from Category a").getResultList();
//            for (Category c : entityList) {
//                System.out.println(c);
//            }
//            Assert.assertSame(entityList.size(), 4);

            entityList = pu.createQuery("Select a from Category a where isHierarchyDescendant(a,"+c1.getId()+",null)").getResultList();
            entityList = pu.createQuery("Select a from Category a where treeAncestor("+c1.getId()+",a)").getResultList();
            entityList = pu.createQuery("Select a from Category a where treeAncestor(:c1,a)").setParameter("c1", c1).getResultList();
//            entityList = pu.createQuery("Select a from Category a where treeAncestor(a,:c1,Category)").setParameter("c1", c1).getEntityList();
//            entityList = pu.createQuery("Select a from Category a where treeAncestor(a,:c1)").getEntityList();
//            entityList = pu.createQuery("Select a from Category a where treeAncestor(:c1,:c12,Category)").getEntityList();
//            entityList = pu.createQuery("Select a from Item a where treeAncestor(:c1,a.parent)").getEntityList();
//            entityList = pu.createQuery("Select a from Item i inner join Category c where treeAncestor(c,i.parent)").getEntityList();

//            pu.delete(Category.class, c1.id);
//            entityList = pu.createQuery("Select a from Category a").getEntityList();
//            Assert.assertSame(entityList.size(), 0);
        }
    }

    @Ignore
    @net.vpc.upa.config.Entity(modifiers = EntityModifier.CLEAR)
    public static class Item {

        @Id
        @net.vpc.upa.config.Sequence
        private Integer id;
        private String name;
        private Category parent;

        public Item() {
        }

        public Item(String name, Category parent) {
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

        public Category getParent() {
            return parent;
        }

        public void setParent(Category parent) {
            this.parent = parent;
        }

    }

    @Ignore
    @net.vpc.upa.config.Entity(modifiers = EntityModifier.CLEAR)
    public static class Category {

        @Id
        @net.vpc.upa.config.Sequence
        private Integer id;
        private String name;
        @Hierarchy
        private Category parent;

        public Category() {
        }

        public Category(String name, Category parent) {
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

        public Category getParent() {
            return parent;
        }

        public void setParent(Category parent) {
            this.parent = parent;
        }

        @Override
        public String toString() {
            return "Category{" + "id=" + id + ", name=" + name + ", parent=" + parent + '}';
        }

    }
}
