/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.test.util;

import net.vpc.upa.PersistenceGroup;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.UPA;
import net.vpc.upa.persistence.ConnectionConfig;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class PUUtils {
    private static final String TYPE="mysql";
    public static PersistenceUnit createTestPersistenceUnit(Class clz) {
        return createTestPersistenceUnit(clz,TYPE);
    }

    public static PersistenceUnit createTestPersistenceUnit(Class clz,String type) {
        String puId = clz == null ? "test" : clz.getName();
        PersistenceGroup grp = UPA.getPersistenceGroup();
        PersistenceUnit pu = grp.addPersistenceUnit(puId);
//        pu.scan(null);
        final ConnectionConfig cc = new ConnectionConfig();
        if("mysql".equals(type)){
            cc.setConnectionString("mysql:default://localhost/UPA_TEST;structure=create;userName=root;password=''");
        }else if("derby".equals(type)){
            cc.setConnectionString("derby:default://localhost/upatest;structure=create;userName=upatest;password=upatest");
        }else if("embedded".equals(type)){
            cc.setConnectionString("derby:embedded://db-embedded/upatest;structure=create;userName=upatest;password=upatest");
        }
        pu.addConnectionConfig(cc);
        if (clz != null) {
            String namePrefix = clz.getSimpleName();
            pu.getPersistenceNameConfig().setGlobalPersistenceName(namePrefix+"_{OBJECT_NAME}");
            pu.getPersistenceNameConfig().setLocalPersistenceName("{OBJECT_NAME}");
//        pu.getParameters().setString(UPA.CONNECTION_STRING, "derby:embedded://upatest;structure=create;userName=upatest;password=upatest");
//        pu.getParameters().setString(UPA.CONNECTION_STRING+"."+ ConnectionOption.USER_NAME, "upatest");
        }
        grp.setPersistenceUnit(puId);
        return pu;
    }
}
