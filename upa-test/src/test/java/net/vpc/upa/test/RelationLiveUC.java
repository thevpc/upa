package net.vpc.upa.test;

import net.vpc.upa.*;
import net.vpc.upa.callbacks.EntityEvent;
import net.vpc.upa.config.Id;
import net.vpc.upa.config.Main;
import net.vpc.upa.filters.FieldFilters;
import net.vpc.upa.test.util.LogUtils;
import net.vpc.upa.test.util.PUUtils;
import net.vpc.upa.types.TypesFactory;
import org.junit.Test;

import java.util.List;
import java.util.logging.Logger;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class RelationLiveUC {

    private static final Logger log = Logger.getLogger(RelationLiveUC.class.getName());

    static {
        LogUtils.prepare();
    }

    @Test
    public void crudMixedDocumentsAndEntities() {
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(getClass());
        pu.addCallback(new AbstractCallback(CallbackType.ON_CREATE,EventPhase.BEFORE,ObjectType.ENTITY,null) {
            @Override
            public Object invoke(Object... arguments) {
                EntityEvent event=(EntityEvent) arguments[0];
                Entity entity = event.getEntity();
                if(entity.getEntityType().equals(Person.class)){
                    System.out.println("ADD contactEmail for "+entity+" as "+event.getPhase());
                    entity.addField(
                            new DefaultFieldBuilder()
                            .setName("contactEmail")
                            .addModifier(UserFieldModifier.SUMMARY)
                            .setLiveSelectFormula("this.contact.email")
                            .setDataType(TypesFactory.STRING)
                    );
                }
                return null;
            }
        });
//        pu.scan(null);
        pu.addEntity(Contact.class);
        pu.addEntity(Person.class);
        pu.start();

        Business bo = UPA.makeSessionAware(new Business());
//        bo.initializeData();
        bo.testQuery4();
//        bo.testQuery();
    }
    public static class Business {
        Contact a;
        public void create() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            pu.reset();

            a=new Contact("a");
            a.setEmail("a@a.com");
            Person pa=new Person("a",a);

            pu.persist(a);
            pu.persist(pa);
        }

        public void testQuery() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            create();
            //ancestorExpression, childExpression, entityName
            Query q = pu.createQuery("Select a.contactEmail from Person a");
            List<Document> t = q.getDocumentList();
            for (Document r : t) {
                System.out.println(r);
            }
        }

        public void testQuery2() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            create();
            //ancestorExpression, childExpression, entityName
            Query q = pu.createQuery("Select a from Person a");
            List<Document> t = q.getDocumentList();
            for (Document r : t) {
                System.out.println(r);
            }
        }

        public void testQuery3() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            create();
            //ancestorExpression, childExpression, entityName
            Query q = pu.createQueryBuilder("Person").setFieldFilter(FieldFilters.byModifiersAllOf(FieldModifier.SUMMARY));
            List<Document> t = q.getDocumentList();
            for (Document r : t) {
                System.out.println(r);
            }
        }
        public void testQuery4() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            create();
            List<Person> all = pu.findAll(Person.class);
            for (Person o : all) {
                Person byId = pu.findById(Person.class, o.id);
                System.out.println(byId);
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
