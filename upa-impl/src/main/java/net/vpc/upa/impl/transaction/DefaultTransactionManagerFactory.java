/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.transaction;

import net.vpc.upa.ObjectFactory;
import net.vpc.upa.Properties;
import net.vpc.upa.persistence.ConnectionProfile;
import net.vpc.upa.persistence.TransactionManagerFactory;
import net.vpc.upa.TransactionManager;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class DefaultTransactionManagerFactory implements TransactionManagerFactory {

    @Override
    public TransactionManager createTransactionManager(ConnectionProfile connectionProfile, ObjectFactory factory, Properties parameters) {
//        ConnectionDriver connectionDriver = connectionProfile.getConnectionDriver();
//        if(connectionDriver==ConnectionDriver.datasource){
//            throw new UPAException("Not yet supported");
//        }
        return new DefaultTransactionManager();
    }


}
