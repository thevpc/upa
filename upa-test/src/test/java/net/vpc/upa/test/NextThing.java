package net.vpc.upa.test;

import net.vpc.upa.*;
import net.vpc.upa.impl.UPAImplDefaults;
import net.vpc.upa.test.model.SharedClient;
import net.vpc.upa.test.util.PUUtils;
import org.junit.BeforeClass;
import org.junit.Test;


/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class NextThing {
    private static final java.util.logging.Logger log = java.util.logging.Logger.getLogger(NextThing.class.getName());

    private static Business bo;
    @BeforeClass
    public static void setup() {
        UPAImplDefaults.PRODUCTION_MODE=false;
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(NextThing.class);
        pu.addEntity(SharedClient.class);
        pu.start();
        bo = UPA.makeSessionAware(new Business());
        bo.init();
    }

    @Test
    public void nextThing() {
        bo.testQueryWithUnion();
    }

    public static class Business {

        public void init() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            pu.clear(SharedClient.class,null);
        }

        public void testQueryWithUnion() {
//            UPA.getPersistenceUnit()
//                    .createQuery("Select u from AcademicTeacher u where u.id in ("
//                            + " (Select t.id from AcademicTeacher t "
//                            + " inner join AcademicCourseAssignment a on a.teacherId=t.id "
//                            + " where a.coursePlan.period.id=:periodId) "
//                            + " union (Select t.id from AcademicTeacher t "
//                            + " inner join AcademicCourseAssignment a on a.teacherId=t.id "
//                            + " where a.coursePlan.period.id=:periodId) "
//                            + ") order by u.contact.fullName")
//                    .setParameter("periodId",periodId)
//                    .getResultList();
        }

    }
}
