package net.vpc.upa.test.relations;

import net.vpc.upa.*;
import net.vpc.upa.callbacks.EntityEvent;
import net.vpc.upa.config.Id;
import net.vpc.upa.config.Main;
import net.vpc.upa.filters.FieldFilters;
import net.vpc.upa.test.util.PUUtils;
import net.vpc.upa.types.DataTypeFactory;
import org.junit.BeforeClass;
import org.junit.Test;

import java.util.List;
import java.util.logging.Logger;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class RelationFormulaUC3 {

    private static final Logger log = Logger.getLogger(RelationFormulaUC3.class.getName());
    private static Business bo;
    @BeforeClass
    public static void setup() {
        PUUtils.reset();
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(RelationFormulaUC3.class);
        pu.addCallback(new AbstractCallback(CallbackType.ON_CREATE,EventPhase.BEFORE,ObjectType.ENTITY,null) {
            @Override
            public Object invoke(Object... arguments) {
                EntityEvent event=(EntityEvent) arguments[0];
                Entity entity = event.getEntity();
                if(entity.getEntityType().equals(Person.class)){
                    log.info("ADD contactEmail for "+entity);
                    entity.addField(new DefaultFieldBuilder()
                                    .setName("contactEmail")
                                    .addModifier(UserFieldModifier.SUMMARY)
                                    .setLiveSelectFormula("this.contact.email")
                                    .setDataType(DataTypeFactory.STRING)
                    );
                }
                return null;
            }
        });
//        pu.scan(null);
        pu.addEntity(Contact.class);
        pu.addEntity(Person.class);
        pu.start();
        bo = UPA.makeSessionAware(new Business());
        bo.init();
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
    public void testQuery3() {
        bo.testQuery3();
    }

    @Test
    public void testQuery4() {
        bo.testQuery4();
    }

    public static class Business {
        Contact a;
        public void init() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            pu.reset();

            a=new Contact("a");
            a.setEmail("a@a.com");
            Person pa=new Person("a",a);

            pu.persist(a);
            pu.persist(pa);
            log.info("** END PREPARE ******************************************");

        }

        public void testQuery() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            //ancestorExpression, childExpression, entityName
            Query q = pu.createQuery("Select a.contactEmail from Person a");
            List<Document> t = q.getDocumentList();
            for (Document r : t) {
                System.out.println(r);
            }
        }

        public void testQuery2() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            //ancestorExpression, childExpression, entityName
            Query q = pu.createQuery("Select a from Person a");
            List<Document> t = q.getDocumentList();
            for (Document r : t) {
                System.out.println(r);
            }
        }

        public void testQuery3() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            //ancestorExpression, childExpression, entityName
            QueryBuilder q = pu.createQueryBuilder("Person").setFieldFilter(FieldFilters.byModifiersAllOf(FieldModifier.SUMMARY));
            List<Document> t = q.getDocumentList();
            for (Document r : t) {
                System.out.println(r);
            }
        }
        public void testQuery4() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            List<Document> all = pu.findAllDocuments(Person.class);
            for (Document o : all) {
                System.out.println(o);
            }
        }
    }

    @net.vpc.upa.config.Entity(modifiers = EntityModifier.CLEAR)
    public static class Person {

        @Id
        @net.vpc.upa.config.Sequence
        private Integer id;

        @Main
        private String name;

        private Contact contact;

        public Person() {
        }

        public Person(String name, Contact contact) {
            this.name = name;
            this.contact = contact;
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

        public Contact getContact() {
            return contact;
        }

        public void setContact(Contact contact) {
            this.contact = contact;
        }
    }

    @net.vpc.upa.config.Entity(modifiers = EntityModifier.CLEAR)
    public static class Contact {

        @Id
        @net.vpc.upa.config.Sequence
        private Integer id;

        @Main
        private String name;
        private String email;

        public Contact() {
        }

        public Contact(String name) {
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


        public String getEmail() {
            return email;
        }

        public void setEmail(String email) {
            this.email = email;
        }

        @Override
        public String toString() {
            return "Node{" +
                    "id=" + id +
                    ", name='" + name + '\'' +
                    '}';
        }
    }


}
