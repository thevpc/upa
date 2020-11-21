/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.persistence;

import net.thevpc.upa.Properties;
import net.thevpc.upa.ObjectFactory;
import net.thevpc.upa.persistence.ConnectionProfile;
import net.thevpc.upa.persistence.TransactionManagerFactory;
import net.thevpc.upa.TransactionManager;

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
