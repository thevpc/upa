package net.vpc.upa.test.types;

import net.vpc.upa.*;
import net.vpc.upa.config.Id;
import net.vpc.upa.config.Temporal;
import net.vpc.upa.test.util.PUUtils;
import net.vpc.upa.types.*;
import org.junit.Assert;
import org.junit.BeforeClass;
import org.junit.Test;

import java.util.Date;


/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class TypesTemporalUC {
    private static final java.util.logging.Logger log = java.util.logging.Logger.getLogger(TypesTemporalUC.class.getName());

    private static Business bo;
    @BeforeClass
    public static void setup() {
        PUUtils.reset();
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(TypesTemporalUC.class);
        pu.addEntity(TemporalData.class);
        pu.start();
        bo = UPA.makeSessionAware(new Business());
        bo.init();
    }

    @Test
    public void process() {
        bo.process();
    }
    @Test
    public void testQueryEmpty() {
        bo.testQueryEmpty();
    }

    public static class Business {

        public void init() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            pu.clear(TemporalData.class,null);
            for (Field field : pu.getEntity(TemporalData.class).getFields()) {
                System.out.println(field.getName()+" : "+field.getDataType().getClass().getSimpleName()+" : "+field.getDataType());
            }
        }

        public void testQueryEmpty() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            TemporalData c=pu.findById(TemporalData.class,-123456);
            Assert.assertNull(c);
        }

        public void process() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            TemporalData d=new TemporalData();
            d.setJavaDate(new Date());
            d.setJavaDateTime(new Date());
            d.setJavaDefault(new Date());
            d.setJavaMonth(new Date());
            d.setJavaTs(new Date());
            d.setJavaYear(new Date());
            d.setVdate(new net.vpc.upa.types.Date());
            d.setVdatetime(new net.vpc.upa.types.DateTime());
            d.setVmonth(new Month());
            d.setVyear(new Year());
            d.setSimpeDate(new Date());
            d.setSqlDate(new java.sql.Date(System.currentTimeMillis()));
            d.setSqlTime(new java.sql.Time(System.currentTimeMillis()));
            d.setSqlTs(new java.sql.Timestamp(System.currentTimeMillis()));
            d.setSqlTsToDateTime(new java.sql.Timestamp(System.currentTimeMillis()));
            System.out.println("BEFORE : "+d);
            pu.persist(d);
            System.out.println("AFTER  : "+d);
            for (TemporalData temporalData : pu.<TemporalData>findAll(TemporalData.class)) {
                System.out.println("READ   : "+temporalData);
            }
        }

    }

    public static class TemporalData{
        @Id
        @net.vpc.upa.config.Sequence
        private int id;
        private Date simpeDate;
        @Temporal(TemporalOption.DATETIME)
        private Date javaDateTime;
        @Temporal(TemporalOption.DATE)
        private Date javaDate;
        @Temporal(TemporalOption.DEFAULT)
        private Date javaDefault;
        @Temporal(TemporalOption.MONTH)
        private Date javaMonth;
        @Temporal(TemporalOption.YEAR)
        private Date javaYear;
        @Temporal(TemporalOption.TIMESTAMP)
        private Date javaTs;
        private net.vpc.upa.types.Date vdate;
        private net.vpc.upa.types.DateTime vdatetime;
        private net.vpc.upa.types.Time vtime;
        private net.vpc.upa.types.Month vmonth;
        private net.vpc.upa.types.Year vyear;
        private net.vpc.upa.types.Timestamp vts;
        private java.sql.Timestamp sqlTs;
        private java.sql.Date sqlDate;
        private java.sql.Time sqlTime;
        @Temporal(TemporalOption.DATETIME)
        private java.sql.Timestamp sqlTsToDateTime;

        public int getId() {
            return id;
        }

        public void setId(int id) {
            this.id = id;
        }

        public Year getVyear() {
            return vyear;
        }

        public void setVyear(Year vyear) {
            this.vyear = vyear;
        }

        public Date getSimpeDate() {
            return simpeDate;
        }

        public void setSimpeDate(Date simpeDate) {
            this.simpeDate = simpeDate;
        }

        public Date getJavaDateTime() {
            return javaDateTime;
        }

        public void setJavaDateTime(Date javaDateTime) {
            this.javaDateTime = javaDateTime;
        }

        public Date getJavaDate() {
            return javaDate;
        }

        public void setJavaDate(Date javaDate) {
            this.javaDate = javaDate;
        }

        public Date getJavaDefault() {
            return javaDefault;
        }

        public void setJavaDefault(Date javaDefault) {
            this.javaDefault = javaDefault;
        }

        public Date getJavaMonth() {
            return javaMonth;
        }

        public void setJavaMonth(Date javaMonth) {
            this.javaMonth = javaMonth;
        }

        public Date getJavaYear() {
            return javaYear;
        }

        public void setJavaYear(Date javaYear) {
            this.javaYear = javaYear;
        }

        public Date getJavaTs() {
            return javaTs;
        }

        public void setJavaTs(Date javaTs) {
            this.javaTs = javaTs;
        }

        public net.vpc.upa.types.Date getVdate() {
            return vdate;
        }

        public void setVdate(net.vpc.upa.types.Date vdate) {
            this.vdate = vdate;
        }

        public DateTime getVdatetime() {
            return vdatetime;
        }

        public void setVdatetime(DateTime vdatetime) {
            this.vdatetime = vdatetime;
        }

        public Time getVtime() {
            return vtime;
        }

        public void setVtime(Time vtime) {
            this.vtime = vtime;
        }

        public Month getVmonth() {
            return vmonth;
        }

        public void setVmonth(Month vmonth) {
            this.vmonth = vmonth;
        }


        public Timestamp getVts() {
            return vts;
        }

        public void setVts(Timestamp vts) {
            this.vts = vts;
        }

        public java.sql.Timestamp getSqlTs() {
            return sqlTs;
        }

        public void setSqlTs(java.sql.Timestamp sqlTs) {
            this.sqlTs = sqlTs;
        }

        public java.sql.Date getSqlDate() {
            return sqlDate;
        }

        public void setSqlDate(java.sql.Date sqlDate) {
            this.sqlDate = sqlDate;
        }

        public java.sql.Time getSqlTime() {
            return sqlTime;
        }

        public void setSqlTime(java.sql.Time sqlTime) {
            this.sqlTime = sqlTime;
        }

        public java.sql.Timestamp getSqlTsToDateTime() {
            return sqlTsToDateTime;
        }

        public void setSqlTsToDateTime(java.sql.Timestamp sqlTsToDateTime) {
            this.sqlTsToDateTime = sqlTsToDateTime;
        }

        @Override
        public String toString() {
            return "TemporalData{" +
                    "id=" + id +
                    ", simpeDate=" + simpeDate +
                    ", javaDateTime=" + javaDateTime +
                    ", javaDate=" + javaDate +
                    ", javaDefault=" + javaDefault +
                    ", javaMonth=" + javaMonth +
                    ", javaYear=" + javaYear +
                    ", javaTs=" + javaTs +
                    ", vdate=" + vdate +
                    ", vdatetime=" + vdatetime +
                    ", vtime=" + vtime +
                    ", vmonth=" + vmonth +
                    ", vyear=" + vyear +
                    ", vts=" + vts +
                    ", sqlTs=" + sqlTs +
                    ", sqlDate=" + sqlDate +
                    ", sqlTime=" + sqlTime +
                    ", sqlTsToDateTime=" + sqlTsToDateTime +
                    '}';
        }
    }
}
