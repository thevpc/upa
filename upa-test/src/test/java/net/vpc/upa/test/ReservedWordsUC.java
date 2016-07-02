package net.vpc.upa.test;

import java.util.List;
import java.util.logging.Logger;
import net.vpc.upa.*;
import net.vpc.upa.test.util.LogUtils;
import net.vpc.upa.config.Id;
import net.vpc.upa.config.Ignore;
import net.vpc.upa.config.ManyToOne;
import net.vpc.upa.test.util.PUUtils;
import org.junit.Test;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class ReservedWordsUC {

    static {
        LogUtils.prepare();
    }
    private static final Logger log = Logger.getLogger(ReservedWordsUC.class.getName());

    @Test
    public void crudMixedRecordsAndEntities() {
        String puId = getClass().getName();
        log.fine("********************************************");
        log.fine(" " + puId);
        log.fine("********************************************");
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(null);//getClass()
        pu.addEntity(Allocate.class);
        pu.addEntity(User.class);
        pu.start();

        Business bo = UPA.makeSessionAware(new Business());
        bo.testQuery();
//        bo.initializeData();
    }

    public static class Business {

        public void testQuery() {
            PersistenceUnit pu = UPA.getPersistenceGroup().getPersistenceUnit();
            Query q = pu.createQuery("Select a from Allocate a");
            List<Record> r = q.getRecordList();
            for (Record record : r) {
                System.out.println(r);
            }
        }

        public void testPrimitiveReferences() {
            PersistenceUnit pu = UPA.getPersistenceGroup().getPersistenceUnit();

            User phone1 = new User();
            phone1.setValue("11111111");
            pu.save(phone1);

            User phone2 = new User();
            phone2.setValue("22222222");
            pu.save(phone2);

            Allocate person = new Allocate();
            person.setName("Hammadi");

            person.setIdPhone1(phone1.getId());
            person.setIdPhone3(phone1.getId());
            person.setUser(phone2);
            person.setPhone4(phone2);

            pu.save(person);

            person.setIdPhone1(phone2.getId());
            person.setIdPhone3(phone2.getId());
            person.setUser(phone1);
            person.setPhone4(phone1);

            pu.save(person);

            //"Select p.id,p.phone3[id,value,lastPhone[id,value]] from Person"
        }
    }

    @Ignore
    @net.vpc.upa.config.Entity
    public static class Allocate {

        @Id
        @net.vpc.upa.config.Sequence
        private Integer id;
        private String name;
        @ManyToOne(targetEntityType = User.class)
        private Integer idPhone1;
        @ManyToOne
        private User user;
        @ManyToOne(targetEntityType = User.class, mappedTo = "phone3")
        private Integer idPhone3;
        private User phone3;
        private Integer idPhone4;
        @ManyToOne(mappedTo = "idPhone4")
        private User phone4;

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

        public Integer getIdPhone1() {
            return idPhone1;
        }

        public void setIdPhone1(Integer idPhone1) {
            this.idPhone1 = idPhone1;
        }

        public User getUser() {
            return user;
        }

        public void setUser(User phone2) {
            this.user = phone2;
        }

        public Integer getIdPhone3() {
            return idPhone3;
        }

        public void setIdPhone3(Integer idPhone3) {
            this.idPhone3 = idPhone3;
        }

        public User getPhone3() {
            return phone3;
        }

        public void setPhone3(User phone3) {
            this.phone3 = phone3;
        }

        public Integer getIdPhone4() {
            return idPhone4;
        }

        public void setIdPhone4(Integer idPhone4) {
            this.idPhone4 = idPhone4;
        }

        public User getPhone4() {
            return phone4;
        }

        public void setPhone4(User phone4) {
            this.phone4 = phone4;
        }

        @Override
        public String toString() {
            return "Person{" + "id=" + id + ", name=" + name + ", idPhone1=" + idPhone1 + ", phone2=" + user + ", idPhone3=" + idPhone3 + ", phone3=" + phone3 + ", idPhone4=" + idPhone4 + ", phone4=" + phone4 + '}';
        }
    }

    public static class User {

        @Id
        @net.vpc.upa.config.Sequence
        private Integer id;
        private String value;
        private String profile;

        public Integer getId() {
            return id;
        }

        public void setId(Integer id) {
            this.id = id;
        }

        public String getValue() {
            return value;
        }

        public void setValue(String value) {
            this.value = value;
        }

        public String getProfile() {
            return profile;
        }

        public void setProfile(String profile) {
            this.profile = profile;
        }

        @Override
        public String toString() {
            return "User{" + "id=" + id + ", value=" + value + '}';
        }
    }
}
