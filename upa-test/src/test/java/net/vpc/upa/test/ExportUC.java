package net.vpc.upa.test;

import java.io.File;
import java.io.IOException;
import java.sql.Timestamp;
import java.util.Date;
import java.util.logging.Logger;
import net.vpc.upa.*;
import net.vpc.upa.bulk.DataWriter;
import net.vpc.upa.bulk.ImportExportManager;
import net.vpc.upa.bulk.TextCSVFormatter;
import net.vpc.upa.test.util.LogUtils;
import net.vpc.upa.config.Id;
import net.vpc.upa.test.model.ClientType;
import net.vpc.upa.test.util.PUUtils;
import net.vpc.upa.types.DateTime;
import net.vpc.upa.types.Month;
import org.junit.Test;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class ExportUC {

    static {
        LogUtils.prepare();
    }
    private static final Logger log = Logger.getLogger(ExportUC.class.getName());

    private Business getBusiness() {
        String puId = getClass().getName();
        log.fine("********************************************");
        log.fine(" " + puId);
        log.fine("********************************************");
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(getClass());
        pu.addEntity(Client.class);
        pu.start();
        return UPA.makeSessionAware(new Business());
    }

    @Test
    public void process() throws IOException {
        Business bo = getBusiness();
        bo.process();
    }

    public static class Business {

        public void process() throws IOException {
            PersistenceUnit pu = UPA.getPersistenceUnit();

            Entity entityManager = pu.getEntity("Client");
            Client c = entityManager.createEntity();
            c.setFirstName("Ahmed");
            c.setLastName("Gharbi");

            pu.persist(c);
            ImportExportManager iem = pu.getImportExportManager();
            TextCSVFormatter f = iem.createTextCSVFormatter(new File("/home/vpc/t.csv"));
            DataWriter w = f.createWriter();
            w.writeRow(new Object[]{"hello", "world"});
            w.close();
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
        private String lastName;
        private java.util.Date birthDate;
        private Timestamp timestampValue;
        private DateTime dateTimeValue;
        private Date dateOnlyValue;
        private Month monthValue;
        private Integer integerValue;
        private Long longValue;
        private ClientType clientType;

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

        public ClientType getClientType() {
            return clientType;
        }

        public void setClientType(ClientType clientType) {
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
