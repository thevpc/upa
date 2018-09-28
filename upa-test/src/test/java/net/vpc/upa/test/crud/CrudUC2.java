package net.vpc.upa.test.crud;

import java.sql.Timestamp;
import java.util.Date;
import net.vpc.upa.*;
import net.vpc.upa.config.Id;
import net.vpc.upa.config.Path;
import net.vpc.upa.test.model.SharedClientType;
import net.vpc.upa.test.util.PUUtils;
import net.vpc.upa.types.DateTime;
import net.vpc.upa.types.Month;
import org.junit.BeforeClass;
import org.junit.Test;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class CrudUC2 {
    private static final java.util.logging.Logger log = java.util.logging.Logger.getLogger(CrudUC2.class.getName());

    private static Business bo;
    @BeforeClass
    public static void setup() {
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(CrudUC2.class);
        pu.addEntity(Client.class);
        pu.start();
        bo = UPA.makeSessionAware(new Business());
    }


    @Test
    public void crud() {
        bo.crud();
    }

    public static class Business {

        public void crud() {
            PersistenceUnit pu = UPA.getPersistenceUnit();

            Entity entity = pu.getEntity(Client.class);
            Client c = entity.createObject();
            c.setFirstName("Ahmed");
            c.setLastName("Gharbi");

            pu.persist(c);

            c.setFirstName("Ahmed Marouane");

            pu.update(c);
            
            Long x=pu.createQuery("Select max(a.longValue) from Client a").getLong();
            System.out.println(x);
            x=pu.createQuery("Select min(a.longValue) from Client a").getLong();
            System.out.println(x);
            x=pu.createQuery("Select avg(a.longValue) from Client a").getLong();
            System.out.println(x);
        }
    }

    @net.vpc.upa.config.Entity(path = "Test Modules/Model")
    public static class Client {

        @Id
        @net.vpc.upa.config.Sequence
        private Integer id;
        //error if int should correct
//        private int id;
        private String firstName;
        @Path(value = "Section2",position = 15)
        private String lastName;
        private java.util.Date birthDate;
        private Timestamp timestampValue;
        private DateTime dateTimeValue;
        private Date dateOnlyValue;
        @Path(value = "Section1",position = 1)
        private Month monthValue;
        private Integer integerValue;
        private Long longValue;
        private SharedClientType clientType;

        public Integer getId() {
            return id;
        }

        public void setId(Integer id) {
            this.id = id;
        }

        public java.util.Date getBirthDate() {
            return birthDate;
        }

        public void setBirthDate(java.util.Date dateValue) {
            this.birthDate = dateValue;
        }

        public Timestamp getTimestampValue() {
            return timestampValue;
        }

        public void setTimestampValue(Timestamp timestampValue) {
            this.timestampValue = timestampValue;
        }

        public DateTime getDateTimeValue() {
            return dateTimeValue;
        }

        public void setDateTimeValue(DateTime dateTimeValue) {
            this.dateTimeValue = dateTimeValue;
        }

        public Date getDateOnlyValue() {
            return dateOnlyValue;
        }

        public void setDateOnlyValue(Date dateOnlyValue) {
            this.dateOnlyValue = dateOnlyValue;
        }

        public Month getMonthValue() {
            return monthValue;
        }

        public void setMonthValue(Month monthValue) {
            this.monthValue = monthValue;
        }

        public Integer getIntegerValue() {
            return integerValue;
        }

        public void setIntegerValue(Integer integerValue) {
            this.integerValue = integerValue;
        }

        public Long getLongValue() {
            return longValue;
        }

        public void setLongValue(Long longValue) {
            this.longValue = longValue;
        }

        public SharedClientType getClientType() {
            return clientType;
        }

        public void setClientType(SharedClientType clientType) {
            this.clientType = clientType;
        }

        @Override
        public String toString() {
            return "Client{"
                    + "id=" + id
                    + ", firstName='" + firstName + '\''
                    + ", lastName='" + lastName + '\''
                    + '}';
        }

        public String getFirstName() {
            return firstName;
        }

        public void setFirstName(String firstName) {
            this.firstName = firstName;
        }

        public String getLastName() {
            return lastName;
        }

        public void setLastName(String lastName) {
            this.lastName = lastName;
        }

        /**
         * This function is provided only for test purposes the compare expected
         * and found values {@inheritDoc}
         */
        @Override
        public boolean equals(Object o) {
            if (this == o) {
                return true;
            }
            if (o == null || getClass() != o.getClass()) {
                return false;
            }

            Client client = (Client) o;

            if (id != null ? !id.equals(client.id) : client.id != null) {
                return false;
            }
            if (firstName != null ? !firstName.equals(client.firstName) : client.firstName != null) {
                return false;
            }
            if (lastName != null ? !lastName.equals(client.lastName) : client.lastName != null) {
                return false;
            }

            return true;
        }

        /**
         * This function is provided only for test purposes the compare expected
         * and found values {@inheritDoc}
         */
        @Override
        public int hashCode() {
            int result = id;
            result = 31 * result + (firstName != null ? firstName.hashCode() : 0);
            return result;
        }
    }
}
