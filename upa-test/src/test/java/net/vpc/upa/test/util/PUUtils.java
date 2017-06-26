/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.test.util;

import net.vpc.upa.PersistenceGroup;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.UPA;
import net.vpc.upa.impl.util.StringUtils;
import net.vpc.upa.persistence.ConnectionConfig;

import java.util.Arrays;
import java.util.List;
import java.util.logging.Logger;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class PUUtils {
    static{
        LogUtils.prepare();
    }
    private static final Logger log = Logger.getLogger(PUUtils.class.getName());
    public static PersistenceUnit createTestPersistenceUnit(Class clz,String desc) {
        return createTestPersistenceUnit(clz,null,desc);
    }
    public static PersistenceUnit createTestPersistenceUnit(Class clz) {
        return createTestPersistenceUnit(clz,null,null);
    }

    public static void drawBox(CharSequence str) {
        String[] lines=str.toString().split("\n");
        int max=0;
        for (String line : lines) {
            if(line.length()>max){
                max=line.length();
            }
        }
        char[] row=new char[max+4];
        Arrays.fill(row,'*');
        log.fine(new String(row));
        for (String line : lines) {
            log.fine("* " + line+" *");
        }
        log.fine(new String(row));
    }

    public static PersistenceUnit createTestPersistenceUnit(Class clz,Store type,String desc) {
        String puId = clz == null ? "test" : clz.getName();
        if(type==null){
            type=Store.EMBEDDED;
        }
        StringBuilder header=new StringBuilder();
        header.append("Create Persistence Unit ").append(puId);
        if(!StringUtils.isNullOrEmpty(desc)){
            header.append(desc);
        }
        drawBox(header);
        System.setProperty("derby.locks.deadlockTrace","true");
        System.setProperty("derby.locks.monitor", "true");
        PersistenceGroup grp = UPA.getPersistenceGroup();
        if(grp.containsPersistenceUnit(puId)){
            grp.setPersistenceUnit(puId);
            return grp.getPersistenceUnit(puId);
        }
        PersistenceUnit pu = grp.addPersistenceUnit(puId);
//        pu.scan(null);
        final ConnectionConfig cc = new ConnectionConfig();
        if(Store.MYSQL.equals(type)){
            cc.setConnectionString("mysql:default://localhost/UPA_TEST;structure=create;userName=root;password=''");
        }else if(Store.DERBY.equals(type)){
            cc.setConnectionString("derby:default://localhost/upatest;structure=create;userName=upatest;password=upatest");
        }else if(Store.EMBEDDED.equals(type)){
            cc.setConnectionString("derby:embedded://db-embedded/upatest;structure=create;userName=upatest;password=upatest");
        }else{
            throw new IllegalArgumentException("Not Supported "+type);
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

    public enum Store{
        MYSQL,
        DERBY,
        EMBEDDED
    }
}
