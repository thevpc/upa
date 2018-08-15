/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.test.util;

import java.io.File;
import java.io.IOException;
import net.vpc.upa.PersistenceGroup;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.UPA;
//import net.vpc.upa.impl.util.StringUtils;
import net.vpc.upa.persistence.ConnectionConfig;
import net.vpc.upa.persistence.QueryResult;

import java.io.PrintStream;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class PUUtils {
    public static final String getVersion(){
        return "1.2.0.36";
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
        String puId = clz == null ? "test" : clz.getSimpleName();
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
            File embedded=new File("db-embedded/upatest"+v);
            try {
                System.out.println("Local Database at "+embedded.getCanonicalPath());
            } catch (IOException ex) {
                System.out.println("Local Database at "+embedded.getAbsolutePath());
            }
        }else{
            throw new IllegalArgumentException("Not Supported "+type);
        }
        pu.addConnectionConfig(cc);
        if (clz != null) {
            String namePrefix = clz.getSimpleName();
            pu.getPersistenceNameStrategy().setGlobalPersistenceNameFormat(namePrefix+"_{OBJECT_NAME}");
            pu.getPersistenceNameStrategy().setLocalPersistenceNameFormat("{OBJECT_NAME}");
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
    public static void println(QueryResult r){
        println(r,System.out);
    }

    public static void println(QueryResult r, PrintStream out){
        int count = r.getColumnsCount();
        int[] width = new int[count];
        StringTable strings = toStringTable(r);
        for (int i = 0; i < count; i++) {
            width[i]=Math.max(width[i],strings.header[i].length());
        }
        for (String[] row : strings.rows) {
            for (int i = 0; i < count; i++) {
                width[i]=Math.max(width[i],row[i].length());
            }
        }
        int allWidth=4+(width.length-1)*3;
        for (int i : width) {
            allWidth+=i;
        }
        char[] br=new char[allWidth];
        Arrays.fill(br,'-');


        out.println(br);
        out.print("| ");
        for (int i = 0; i < count; i++) {
            if(i>0){
                out.print(" | ");
            }
            out.print(formatLeft(strings.header[i],width[i]));
        }
        out.println(" |");
        out.println(br);
        for (String[] row : strings.rows) {
            out.print("| ");
            for (int i = 0; i < count; i++) {
                if(i>0){
                    out.print(" | ");
                }
                out.print(formatLeft(row[i],width[i]));
            }
            out.println(" |");
        }
        out.println(br);
    }

    private static String formatLeft(String str,int len){
        StringBuilder sb=new StringBuilder(str);
        while(sb.length()<len){
            sb.append(' ');
        }
        return sb.toString();
    }

    private static StringTable toStringTable(QueryResult r){
        int count = r.getColumnsCount();
        List<String[]> rows=new ArrayList<>();
        String[] header=new String[count];
        for (int i = 0; i < count; i++) {
            header[i]=String.valueOf(r.getColumnName(i));
        }
        while(r.hasNext()) {
            String[] row = new String[count];
            for (int i = 0; i < count; i++) {
                row[i]=String.valueOf(r.read(i));
            }
            rows.add(row);
        }
        return new StringTable(rows,header);
    }
    private static class StringTable{
        List<String[]> rows;
        String[] header;

        public StringTable(List<String[]> rows, String[] header) {
            this.rows = rows;
            this.header = header;
        }
    }
}
