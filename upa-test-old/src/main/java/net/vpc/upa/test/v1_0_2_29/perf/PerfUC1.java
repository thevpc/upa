//package net.vpc.upa.test.v1_0_2_29.perf;
//
//import net.vpc.upa.Entity;
//import net.vpc.upa.PersistenceUnit;
//import net.vpc.upa.UPA;
//import net.vpc.upa.config.Id;
//import net.vpc.upa.test.v1_0_2_29.model.SharedClientType;
//import net.vpc.upa.test.v1_0_2_29.util.LogUtils;
//import net.vpc.upa.test.v1_0_2_29.util.PUUtils;
//import net.vpc.upa.types.DateTime;
//import net.vpc.upa.types.Month;
//
//import java.sql.Timestamp;
//import java.util.Date;
//
///**
// * @author Taha BEN SALAH <taha.bensalah@gmail.com>
// * @creationdate 9/16/12 10:02 PM
// */
//public class PerfUC1 {
//
//    static int expand = 1000;
//    static int stability = 200;
//
//    private static final java.util.logging.Logger log = java.util.logging.Logger.getLogger(PerfUC1.class.getName());
//
//    public static void main(String[] args) {
//        setup();
//        new PerfUC1().testPerf2();
//        stability = 5;
//        new PerfUC1().testPerf();
//    }
//    private static Business bo;
//
//    public static void setup() {
//        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(PerfUC1.class);
//        pu.addEntity(Client.class);
//        pu.start();
//        bo = UPA.makeSessionAware(new Business());
//    }
//
//    public void testPerf2() {
//        bo.testPerf2();
//    }
//
//    public void testPerf() {
//        LogUtils.silence();
//        bo.clear();
//        evalPerf(new Runnable() {
//                     @Override
//                     public void run() {
//                         bo.testPerf();
//                     }
//                 },
//                new Runnable() {
//                    @Override
//                    public void run() {
//                        bo.clear();
//                    }
//                }
//        );
//    }
//
//    /**
//     * 1.2.0.31.0 :: all-min/avg/max=1178/2130/5123 :: one-min/avg/max=11/21/51
//     * 1.2.0.33.0 :: all-min/avg/max=1245/2097/3334 :: one-min/avg/max=12/20/33
//                     all-min/avg/max=1252/2259/4572 :: one-min/avg/max=12/22/45
//     */
//
//    public static void evalPerf(Runnable r,Runnable c) {
//        long min=Long.MAX_VALUE;
//        long max=0;
//        long all=0;
//        for (int i = 0; i < stability; i++) {
//            long start = System.currentTimeMillis();
//            for (int j = 0; j < expand; j++) {
//                r.run();
//            }
//            c.run();
//            long end= System.currentTimeMillis();
//            long v=end-start;
//            if(v<min){
//                min=v;
//            }
//            if(v>max){
//                max=v;
//            }
//            all+=v;
//            System.out.println("\t\tall-curr/min/avg/max="+v+"/"+min+"/"+(all/(i+1))+"/"+max+" :: one-curr/min/avg/max="+(v/expand)+"/"+(min/expand)+"/"+(all/(i+1)/expand)+"/"+(max/expand));
//        }
//        System.out.println("all-min/avg/max="+min+"/"+(all/stability)+"/"+max+" :: one-min/avg/max="+(min/expand)+"/"+(all/stability/expand)+"/"+(max/expand));
//    }
//
//    public static class Business {
//
//        public void clear() {
//            PersistenceUnit pu = UPA.getPersistenceUnit();
//            pu.createQuery("Delete from Client").executeNonQuery();
//        }
//
//        public void testPerf2() {
//            LogUtils.silence();
//            clear();
//            evalPerf(new Runnable() {
//                @Override
//                public void run() {
//                    testPerf();
//                }
//            },
//                    new Runnable() {
//                @Override
//                public void run() {
//                    clear();
//                }
//            }
//            );
//        }
//
//        public void testPerf() {
//            PersistenceUnit pu = UPA.getPersistenceUnit();
//
//            Entity entity = pu.getEntity(Client.class);
//            Client c = entity.createObject();
//            c.setFirstName("Ahmed");
//            c.setLastName("Gharbi");
//
//            pu.persist(c);
//
////            c.setFirstName("Ahmed Marouane");
////
////            pu.update(c);
////            pu.findById(Client.class,c.getId());
////            pu.findAll(Client.class).size();
////            pu.remove(c);
//        }
//    }
//
//    @net.vpc.upa.config.Entity(path = "Test Modules/Model")
//    public static class Client {
//
//        @Id
//        @net.vpc.upa.config.Sequence
//        private Integer id;
//        //error if int should correct
////        private int id;
//        private String firstName;
//        private String lastName;
//        private Date birthDate;
//        private Timestamp timestampValue;
//        private DateTime dateTimeValue;
//        private Date dateOnlyValue;
//        private Month monthValue;
//        private Integer integerValue;
//        private Long longValue;
//        private SharedClientType clientType;
//
//        public Integer getId() {
//            return id;
//        }
//
//        public void setId(Integer id) {
//            this.id = id;
//        }
//
//        public Date getBirthDate() {
//            return birthDate;
//        }
//
//        public void setBirthDate(Date dateValue) {
//            this.birthDate = dateValue;
//        }
//
//        public Timestamp getTimestampValue() {
//            return timestampValue;
//        }
//
//        public void setTimestampValue(Timestamp timestampValue) {
//            this.timestampValue = timestampValue;
//        }
//
//        public DateTime getDateTimeValue() {
//            return dateTimeValue;
//        }
//
//        public void setDateTimeValue(DateTime dateTimeValue) {
//            this.dateTimeValue = dateTimeValue;
//        }
//
//        public Date getDateOnlyValue() {
//            return dateOnlyValue;
//        }
//
//        public void setDateOnlyValue(Date dateOnlyValue) {
//            this.dateOnlyValue = dateOnlyValue;
//        }
//
//        public Month getMonthValue() {
//            return monthValue;
//        }
//
//        public void setMonthValue(Month monthValue) {
//            this.monthValue = monthValue;
//        }
//
//        public Integer getIntegerValue() {
//            return integerValue;
//        }
//
//        public void setIntegerValue(Integer integerValue) {
//            this.integerValue = integerValue;
//        }
//
//        public Long getLongValue() {
//            return longValue;
//        }
//
//        public void setLongValue(Long longValue) {
//            this.longValue = longValue;
//        }
//
//        public SharedClientType getClientType() {
//            return clientType;
//        }
//
//        public void setClientType(SharedClientType clientType) {
//            this.clientType = clientType;
//        }
//
//        @Override
//        public String toString() {
//            return "Client{"
//                    + "id=" + id
//                    + ", firstName='" + firstName + '\''
//                    + ", lastName='" + lastName + '\''
//                    + '}';
//        }
//
//        public String getFirstName() {
//            return firstName;
//        }
//
//        public void setFirstName(String firstName) {
//            this.firstName = firstName;
//        }
//
//        public String getLastName() {
//            return lastName;
//        }
//
//        public void setLastName(String lastName) {
//            this.lastName = lastName;
//        }
//
//        /**
//         * This function is provided only for test purposes the compare expected
//         * and found values {@inheritDoc}
//         */
//        @Override
//        public boolean equals(Object o) {
//            if (this == o) {
//                return true;
//            }
//            if (o == null || getClass() != o.getClass()) {
//                return false;
//            }
//
//            Client client = (Client) o;
//
//            if (id != null ? !id.equals(client.id) : client.id != null) {
//                return false;
//            }
//            if (firstName != null ? !firstName.equals(client.firstName) : client.firstName != null) {
//                return false;
//            }
//            if (lastName != null ? !lastName.equals(client.lastName) : client.lastName != null) {
//                return false;
//            }
//
//            return true;
//        }
//
//        /**
//         * This function is provided only for test purposes the compare expected
//         * and found values {@inheritDoc}
//         */
//        @Override
//        public int hashCode() {
//            int result = id;
//            result = 31 * result + (firstName != null ? firstName.hashCode() : 0);
//            return result;
//        }
//    }
//}
