///*
// * To change this template, choose Tools | Templates
// * and open the template in the editor.
// */
//package net.vpc.upa.web;
//
//import java.util.logging.Level;
//import java.util.logging.Logger;
//import javax.servlet.ServletContextEvent;
//import javax.servlet.ServletContextListener;
//import javax.servlet.ServletRequestEvent;
//import javax.servlet.ServletRequestListener;
//import javax.servlet.annotation.WebListener;
//import javax.servlet.http.HttpServletRequest;
//import net.vpc.upa.PersistenceUnit;
//import net.vpc.upa.UPA;
//import net.vpc.upa.TransactionType;
//
///**
// *
// * @author Taha BEN SALAH <taha.bensalah@gmail.com>
// */
//@WebListener
//public class UPAServletRequestListener implements ServletRequestListener, ServletContextListener {
//
//    private static final Logger log = Logger.getLogger(UPAServletRequestListener.class.getName());
//
//    public void contextInitialized(ServletContextEvent sce) {
//        WebUPAContext.fallBackContext.setServletContext(sce.getServletContext());
//    }
//
//    public void contextDestroyed(ServletContextEvent sce) {
//        WebUPAContext.fallBackContext.setServletContext(null);
//        UPA.close();
//    }
//
//    public void requestDestroyed(ServletRequestEvent sre) {
////        try {
////            PersistenceUnit persistenceUnit = UPA.getPersistenceUnit();
////            persistenceUnit.commitTransaction();
////            persistenceUnit.getCurrentSession().close();
////        } catch (Exception e) {
////            log.log(Level.SEVERE, "Error destroying Request", e);
////        }
//        WebUPAContext.Current.set(null);
//    }
//
//    public void requestInitialized(ServletRequestEvent sre) {
//        WebUPAContext nfo = new WebUPAContext();
//        nfo.setServletContext(sre.getServletContext());
//        nfo.setRequest((HttpServletRequest) sre.getServletRequest());
//        WebUPAContext.Current.set(nfo);
////        PersistenceUnit persistenceUnit = UPA.getPersistenceUnit();
////        persistenceUnit.openSession();
////        persistenceUnit.beginTransaction(TransactionType.REQUIRED);
//    }
//}
