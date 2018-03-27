/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.persistence;

import java.lang.annotation.Annotation;
import net.vpc.upa.ObjectFactory;
import net.vpc.upa.Properties;
import net.vpc.upa.exceptions.UPAIllegalArgumentException;
import net.vpc.upa.impl.ext.persistence.PersistenceStoreExt;
import net.vpc.upa.persistence.ConnectionProfile;
import net.vpc.upa.persistence.DatabaseProduct;
import net.vpc.upa.impl.persistence.specific.derby.DerbyPersistenceStore;
import net.vpc.upa.impl.persistence.specific.interbase.InterBasePersistenceStore;
import net.vpc.upa.impl.persistence.specific.mckoi.McKoiPersistenceStore;
import net.vpc.upa.impl.persistence.specific.mssqlserver.MSSQLServerPersistenceStore;
import net.vpc.upa.impl.persistence.specific.mysql.MySQLPersistenceStore;
import net.vpc.upa.impl.persistence.specific.oracle.OraclePersistenceStore;
import net.vpc.upa.persistence.PersistenceStoreFactory;
import net.vpc.upa.persistence.PersistenceStore;

import java.util.HashMap;
import java.util.Map;
import java.util.NoSuchElementException;
import net.vpc.upa.Property;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class DefaultPersistenceStoreFactory implements PersistenceStoreFactory {
//    private Hashtable static_adapterAliases = new Hashtable();

    static {
//        installDefaultLitteralConverters();
//        Log.addMessageType(PersistenceUnitManager.DB_CON_LOG, Log.DEV_PROCESS_MSG_GROUP);
//        Log.addMessageType(PersistenceUnitManager.DB_QUERY_LOG, Log.DEV_PROCESS_MSG_GROUP);
//        Log.addMessageType(PersistenceUnitManager.DB_UPDATE_LOG, Log.DEV_PROCESS_MSG_GROUP);
//        Log.addMessageType(PersistenceUnitManager.DB_EXEC_LOG, Log.DEV_PROCESS_MSG_GROUP);
//        Log.addMessageType(PersistenceUnitManager.DB_NATIVE_QUERY_LOG, Log.DEV_PROCESS_MSG_GROUP);
//        Log.addMessageType(PersistenceUnitManager.DB_PRE_NATIVE_QUERY_LOG, Log.DEV_PROCESS_MSG_GROUP);
//        Log.addMessageType(PersistenceUnitManager.DB_PRE_NATIVE_UPDATE_LOG, Log.DEV_PROCESS_MSG_GROUP);
//        Log.addMessageType(PersistenceUnitManager.DB_NATIVE_UPDATE_LOG, Log.DEV_PROCESS_MSG_GROUP);
//        Log.addMessageType(PersistenceUnitManager.DB_ERROR_LOG, Log.DEV_DEPLOY_MSG_GROUP);
//        Runtime.getRuntime().addShutdownHook(new Thread(new Runnable() {
//
//            public void run() {
//                try {
//                    Log.log(PersistenceUnitManager.DB_CON_LOG, "-----CLOSING-DEFAULT-CONNECTION-----");
//                    PersistenceUnitFilter d = DatabaseManager.getInstance().getPersistenceUnit();
//                    if (d != null) {
//                        PersistenceUnitManager a = d.getPersistenceManager();
//                        if (a != null) {
//                            ConnectionDelegate cc = a.getConnection();
//                            if (cc != null) {
//                                cc.commit();
//                            }
//                            a.close();
//                        }
//                    }
//                } catch (Exception e) {
//                    Log.log(PersistenceUnitManager.DB_ERROR_LOG, "Could not close default connection : " + e);
//                    Log.log(PersistenceUnitManager.DB_ERROR_LOG, e);
//                }
//            }
//        }, "DatabaseAdapterConnectionCloserShutdownHook"));
    }

    //    private ConnectionManagerFactory connectionManagerFactory;

    public DefaultPersistenceStoreFactory() {
    }

    @Override
    public void configure(ObjectFactory factory) {
    }

    @Override
    public PersistenceStore createPersistenceStore(ConnectionProfile connectionProfile, ObjectFactory factory, Properties parameters) {
        int bestLvl=-1;
        PersistenceStoreExt best=null;
        Class[] alternatives = factory.getAlternatives(PersistenceStore.class);
        for (Class alternative : alternatives) {
            PersistenceStoreExt object = (PersistenceStoreExt) factory.createObject(alternative);
            int lvl = object.getSupportLevel(connectionProfile, parameters);
            if(best==null || (lvl>0 && lvl>bestLvl)){
                bestLvl=lvl;
                best=object;
            }
        }
        if(best==null){
            throw new UPAIllegalArgumentException("Unsupported profile. Unable to create Store for "+connectionProfile);
        }
        return best;
    }
}
