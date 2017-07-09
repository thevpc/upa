package net.vpc.upa.test.perf;

import net.vpc.upa.*;
import net.vpc.upa.config.Id;
import net.vpc.upa.test.model.SharedClient;
import net.vpc.upa.test.model.SharedClientType;
import net.vpc.upa.test.util.LogUtils;
import net.vpc.upa.test.util.PUUtils;
import net.vpc.upa.types.DateTime;
import net.vpc.upa.types.Month;

import java.sql.Timestamp;
import java.util.Date;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class PerfUC2 {

    static int expand = 1;
    static int stability = 1;

    private static final java.util.logging.Logger log = java.util.logging.Logger.getLogger(PerfUC2.class.getName());

    public static void main(String[] args) {
        setup();
        new PerfUC2().testPerf2();
        stability = 5;
        new PerfUC2().testPerf();
    }
    private static Business bo;

    public static void setup() {
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(PerfUC2.class);
        pu.addEntity(Client.class);
        pu.addEntity(SharedClient.class);
        pu.start();
        bo = UPA.makeSessionAware(new Business());
    }

    public void testPerf2() {
        bo.testPerf2();
    }

    public void testPerf() {
        LogUtils.silence();
        bo.clear();
        evalPerf(new Runnable() {
                     @Override
                     public void run() {
                         bo.testPerf();
                     }
                 },
                new Runnable() {
                    @Override
                    public void run() {
                        bo.clear();
                    }
                }
        );
    }

    /**
     * 1.2.0.31.0 :: all-min/avg/max=1178/2130/5123 :: one-min/avg/max=11/21/51
     * 1.2.0.33.0 :: all-min/avg/max=1245/2097/3334 :: one-min/avg/max=12/20/33
                     all-min/avg/max=1252/2259/4572 :: one-min/avg/max=12/22/45
     */

    public static void evalPerf(Runnable r,Runnable c) {
        long min=Long.MAX_VALUE;
        long max=0;
        long all=0;
        for (int i = 0; i < stability; i++) {
            long start = System.currentTimeMillis();
            for (int j = 0; j < expand; j++) {
                r.run();
            }
            c.run();
            long end= System.currentTimeMillis();
            long v=end-start;
            if(v<min){
                min=v;
            }
            if(v>max){
                max=v;
            }
            all+=v;
            System.out.println("\t\tall-curr/min/avg/max="+v+"/"+min+"/"+(all/(i+1))+"/"+max+" :: one-curr/min/avg/max="+(v/expand)+"/"+(min/expand)+"/"+(all/(i+1)/expand)+"/"+(max/expand));
        }
        System.out.println("all-min/avg/max="+min+"/"+(all/stability)+"/"+max+" :: one-min/avg/max="+(min/expand)+"/"+(all/stability/expand)+"/"+(max/expand));
    }

    public static class Business {

        public void clear() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
//            pu.createQuery("Delete from Client").executeNonQuery();
//            pu.createQuery("Delete from SharedClient").executeNonQuery();
        }

        public void testPerf2() {
//            LogUtils.silence();
            clear();
            evalPerf(new Runnable() {
                @Override
                public void run() {
                    testPerf();
                }
            },
                    new Runnable() {
                @Override
                public void run() {
                    clear();
                }
            }
            );
        }

        public void testPerf() {
            PersistenceUnit pu = UPA.getPersistenceUnit();

            for (int i = 0; i < 100; i++) {
                Entity e = pu.getEntity(Client.class);
                Client c = e.createObject();
                c.setFirstName("Ahmed "+i);
                c.setLastName("Gharbi");

                pu.persist(c);

                Entity e2 = pu.getEntity(SharedClient.class);
                SharedClient c2 = e2.createObject();
                c2.setId(i+1);
                c2.setFirstName("Ahmed "+i);
                c2.setLastName("Gharbi");

                pu.persist(c2);

                c.setClient(c2);
                pu.persist(c);
            }
            int count=pu.createQueryBuilder(Client.class).setHint(QueryHints.FETCH_STRATEGY, QueryFetchStrategy.SELECT).getResultList().size();
            System.out.println("count="+count);
            count=pu.createQueryBuilder(Client.class).getResultList().size();
            System.out.println("count="+count);
//            c.setFirstName("Ahmed Marouane");
//
//            pu.update(c);
//            pu.findById(Client.class,c.getId());
//            pu.findAll(Client.class).size();
//            pu.remove(c);
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
        private Date birthDate;
        private Timestamp timestampValue;
        private DateTime dateTimeValue;
        private Date dateOnlyValue;
        private Month monthValue;
        private Integer integerValue;
        private Long longValue;
        private SharedClientType clientType;
        private SharedClient client;

        public Integer getId() {
            return id;
        }

        public void setId(Integer id) {
            this.id = id;
        }

        public Date getBirthDate() {
            return birthDate;
        }

        public void setBirthDate(Date dateValue) {
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

        public SharedClient getClient() {
            return client;
        }

        public void setClient(SharedClient client) {
            this.client = client;
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
