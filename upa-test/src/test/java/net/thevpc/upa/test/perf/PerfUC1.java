package net.thevpc.upa.test.perf;

import net.thevpc.upa.PersistenceUnit;
import net.thevpc.upa.config.Entity;
import net.thevpc.upa.config.Sequence;
import net.thevpc.upa.test.model.SharedClientType;
import net.thevpc.upa.test.util.LogUtils;
import net.thevpc.upa.test.util.PUUtils;
import net.thevpc.upa.UPA;
import net.thevpc.upa.config.Id;
import net.thevpc.upa.types.DateTime;
import net.thevpc.upa.types.Month;

import java.sql.Timestamp;
import java.util.Date;
import net.thevpc.upa.VoidAction;
import net.thevpc.upa.impl.UPAImplDefaults;
import org.junit.BeforeClass;
import org.junit.Test;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class PerfUC1 {

    static int count = 1000;
    static int stability = 3;

    private static final java.util.logging.Logger log = java.util.logging.Logger.getLogger(PerfUC1.class.getName());

    private static Business bo;
    
    //added main to profile perfs
    public static void main(String[] args) {
        setup();
        PerfUC1 v = new PerfUC1();
        v.testPerfPersistSingleEntry();
        v.testPerfMultiEntryInitialized();
        v.testPerfMultiEntryNop();
        v.testPerfMultiEntryPersist();
    }
    
    @BeforeClass
    public static void setup() {
        PUUtils.reset();
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(PerfUC1.class);
        pu.addEntity(Client.class);
        pu.start();
        bo = UPA.makeSessionAware(new Business());
        bo.init();
        UPAImplDefaults.DEBUG_MODE = false;
    }

    @Test
    public void testPerfPersistSingleEntry() {
//        stability = 20;
        bo.persistMany();
    }

    @Test
    public void testPerfMultiEntryPersist() {
//        stability = 5;
        LogUtils.silence();
        bo.clear();
        evalPerf("MultiEntryPersist", new Runnable() {
            @Override
            public void run() {
                bo.persistOne();
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
    @Test
    public void testPerfMultiEntryNop() {
//        stability = 5;
        LogUtils.silence();
        bo.clear();
        evalPerf("MultiEntryNop", new Runnable() {
            @Override
            public void run() {
                bo.nop();
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

    @Test
    public void testPerfMultiEntryInitialized() {
        UPA.getPersistenceUnit().invoke(new VoidAction() {
            @Override
            public void run() {
//        stability = 5;
                LogUtils.silence();
                bo.clear();
                evalPerf("MultiEntryInitializedPersist", new Runnable() {
                    @Override
                    public void run() {
                        bo.persistOne();
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
        });
    }

    /**
     * 1.2.0.31.0 :: all-min/avg/max=1178/2130/5123 :: one-min/avg/max=11/21/51
     * 1.2.0.33.0 :: all-min/avg/max=1245/2097/3334 :: one-min/avg/max=12/20/33
     * all-min/avg/max=1252/2259/4572 :: one-min/avg/max=12/22/45
     */
    public static void evalPerf(String name, Runnable r, Runnable c) {
        long min = Long.MAX_VALUE;
        long max = 0;
        long all = 0;
        int w = 6;
        for (int i = 0; i < stability; i++) {
            long start = System.currentTimeMillis();
            for (int j = 0; j < count; j++) {
                r.run();
            }
            c.run();
            long end = System.currentTimeMillis();
            long v = end - start;
            if (v < min) {
                min = v;
            }
            if (v > max) {
                max = v;
            }
            all += v;
            System.out.println("\t\t["+PUUtils.getVersion()+"][" + PUUtils.formatLeft(name,30) + "][stability=" + stability + " ; count=" + count + "] all-curr/min/avg/max="
                    + " | " + PUUtils.formatLeft(v, w)
                    + " | " + PUUtils.formatLeft(min, w)
                    + " | " + PUUtils.formatLeft((all / (i + 1)), w)
                    + " | " + PUUtils.formatLeft(max, w)
                    + " :: one-curr/min/avg/max="
                    + " | " + PUUtils.formatLeft((v / count), w)
                    + " | " + PUUtils.formatLeft((min / count), w)
                    + " | " + PUUtils.formatLeft((all / (i + 1) / count), w)
                    + " | " + PUUtils.formatLeft((max / count), w)
                    + " | "
            );
        }
        System.out.println("["+PUUtils.getVersion()+"][" + PUUtils.formatLeft(name,30) + "][stability=" + stability + " ; count=" + count + "] all-min/avg/max="
                + " | " + PUUtils.formatLeft(min, w)
                + " | " + PUUtils.formatLeft((all / stability), w)
                + " | " + PUUtils.formatLeft(max, w)
                + " :: one-min/avg/max="
                + " | " + PUUtils.formatLeft((min / count), w)
                + " | " + PUUtils.formatLeft((all / stability / count), w)
                + " | " + PUUtils.formatLeft((max / count), w)
                + " | "
        );
    }

    public static class Business {

        public void init() {
        }

        public void clear() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            pu.createQuery("Delete from Client").executeNonQuery();
        }

        public void nop() {
            
        }
        public void persistMany() {
            LogUtils.silence();
            clear();
            evalPerf("PersistMany", new Runnable() {
                @Override
                public void run() {
                    persistOne();
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

        public void persistOne() {
            PersistenceUnit pu = UPA.getPersistenceUnit();

            net.thevpc.upa.Entity entity = pu.getEntity(Client.class);
            Client c = entity.createObject();
            c.setFirstName("Ahmed");
            c.setLastName("Gharbi");

            pu.persist(c);

//            c.setFirstName("Ahmed Marouane");
//
//            pu.update(c);
//            pu.findById(Client.class,c.getId());
//            pu.findAll(Client.class).size();
//            pu.remove(c);
        }
    }

    @Entity(path = "Test Modules/Model")
    public static class Client {

        @Id
        @Sequence
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
