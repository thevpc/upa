/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.test.v1_0_2_29.util;

import net.thevpc.upa.PersistenceGroup;
import net.thevpc.upa.PersistenceUnit;
import net.thevpc.upa.UPA;
//import net.thevpc.upa.impl.util.StringUtils;
import net.thevpc.upa.persistence.ConnectionConfig;

import java.util.Arrays;
import java.util.logging.Logger;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class PUUtils {
    public static final String getVersion(){
        return "1.2.0.29";
    }
    static{
        System.out.println("*************************************");
        System.out.println(""+getVersion());
        System.out.println("*************************************");
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
        String v = getVersion().replace(".","_");
        String puId = clz == null ? "test" : clz.getName();
        if(type==null){
            type=Store.EMBEDDED;
        }
        StringBuilder header=new StringBuilder();
        header.append("Create Persistence Unit ").append(puId);
        if(desc!=null && desc.trim().length()>0){
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
            cc.setConnectionString("mysql:default://localhost/UPA_TEST"+v+";structure=create;userName=root;password=''");
        }else if(Store.DERBY.equals(type)){
            cc.setConnectionString("derby:default://localhost/upatest"+v+";structure=create;userName=upatest;password=upatest");
        }else if(Store.EMBEDDED.equals(type)){
            cc.setConnectionString("derby:embedded://db-embedded/upatest"+v+";structure=create;userName=upatest;password=upatest");
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
