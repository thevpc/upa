//package net.vpc.upa.test;
//
//import java.util.List;
//
//import net.vpc.upa.*;
//import net.vpc.upa.exceptions.CurrentSessionNotFoundException;
//import net.vpc.upa.test.util.LogUtils;
//import org.junit.Assert;
//import org.junit.Test;
//import org.slf4j.Logger;
//import org.slf4j.LoggerFactory;
//
///**
// * @author Taha BEN SALAH <taha.bensalah@gmail.com>
// * @creationdate 9/30/12 4:04 PM
// */
//public class ContextLoadingUseCase {
//
//    static {
//        LogUtils.prepare();
//    }
//    static Logger log = LoggerFactory.getLogger(ContextLoadingUseCase.class);
//
//    //@Test
//    public void test1() {
//        PersistenceUnit sm = UPA.getPersistenceUnit();
//        sm.close();
//    }
//
//    //@Test
//    public void test2() {
//        PersistenceUnit sm = UPA.getPersistenceUnit();
//        Assert.assertFalse(sessionExists());
//        Session s = sm.openSession();
//        Assert.assertTrue(sessionExists());
//        s.close();
//        Assert.assertFalse(sessionExists());
//    }
//
//    @Test
//    public void test3() {
//        PersistenceUnit sm = UPA.getPersistenceUnit();
//        Session s = sm.openSession();
//        List list= sm.createQueryBuilder("Client").getEntityList();
//        log.info("Find : "+list);
////        UPAUtils.close(list);
//        s.close();
//    }
//
//    private boolean sessionExists() {
//        PersistenceUnit sm = UPA.getPersistenceUnit();
//        try {
//            sm.getPersistenceGroup().getCurrentSession();
//            return true;
//        } catch (CurrentSessionNotFoundException exc) {
//            return false;
//        }
//
//    }
//}
