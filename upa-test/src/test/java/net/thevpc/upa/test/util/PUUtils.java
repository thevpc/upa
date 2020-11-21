/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.test.util;

import java.io.File;
import java.io.IOException;

import net.thevpc.upa.PersistenceUnit;
import net.thevpc.upa.PersistenceGroup;
import net.thevpc.upa.UPA;
//import net.thevpc.upa.impl.util.StringUtils;
import net.thevpc.upa.persistence.ConnectionConfig;
import net.thevpc.upa.persistence.QueryResult;

import java.io.PrintStream;
import java.sql.Connection;
import java.sql.DriverManager;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.thevpc.upa.impl.UPAImplDefaults;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class PUUtils {

    public static Store DEFAULT_STORE = Store.EMBEDDED;
    //Should move this to external file
    public static String mySqlAdminLogin = "root";
    public static String mySqlAdminPassword = "";

    public static final String getVersion() {
        return "1.2.0.48";
    }

    static {
        UPAImplDefaults.DEBUG_MODE = true;
        System.out.println("*************************************");
        System.out.println("" + getVersion());
        System.out.println("*************************************");
        LogUtils.prepare();
        reset();
    }
    private static final Logger log = Logger.getLogger(PUUtils.class.getName());

    public static void reset() {
        //reset UPA context!
        UPA.close();
    }

    public static String getFullPath(File file) {
        try {
            return (file.getCanonicalPath());
        } catch (IOException ex) {
            return (file.getAbsolutePath());
        }
    }

    public static PersistenceUnit createTestPersistenceUnit(Class clz, String desc) {
        return createTestPersistenceUnit(clz, null, desc);
    }

    public static PersistenceUnit createTestPersistenceUnit(Class clz) {
        return createTestPersistenceUnit(clz, null, null);
    }

    public static void drawBox(CharSequence str) {
        String[] lines = str.toString().split("\n");
        int max = 0;
        for (String line : lines) {
            if (line.length() > max) {
                max = line.length();
            }
        }
        char[] row = new char[max + 4];
        Arrays.fill(row, '*');
        log.fine(new String(row));
        for (String line : lines) {
            log.log(Level.FINE, "* {0} *", line);
        }
        log.fine(new String(row));
    }

    public static void runJdbcScript(Store type, String... script) {
        String driverName = null;
        String url = null;
        switch (getStoreType(type)) {
            case MYSQL: {
                driverName = "com.mysql.jdbc.Driver";
                url = "jdbc:mysql://localhost/mysql?user=" + mySqlAdminLogin + "&password=" + mySqlAdminPassword;
                break;
            }
            default: {
                throw new IllegalArgumentException("Unsupported");
            }
        }

        Connection c = null;
        try {
            Class.forName(driverName).newInstance();
            try {
                c = DriverManager.getConnection(url);
                for (String sql : script) {
                    log.log(Level.CONFIG,"[SQL]["+type+"] "+sql);
                    try {
                        c.createStatement().executeUpdate(sql);
                    } catch (Exception any) {
                        log.log(Level.SEVERE,"[SQL]["+type+"] Failed : "+any.toString()+" . Query = "+sql,any);
                    }
                }
            } finally {
                if (c != null) {
                    c.close();
                }
            }
        } catch (Exception ex) {
            throw new RuntimeException(ex);
        }
    }

    public static void deleteTestPersistenceUnits() {
        deleteTestPersistenceUnits(null);
    }
    
    public static void deleteTestPersistenceUnits(Store type) {
        type = getStoreType(type);
        switch (type) {
            case MYSQL: {
                runJdbcScript(Store.MYSQL,
                        "DROP DATABASE IF EXISTS " + getDBName() ,
                        "CREATE DATABASE " + getDBName() + " DEFAULT CHARACTER SET utf8 DEFAULT COLLATE utf8_general_ci",
                        "CREATE USER IF NOT EXISTS 'upatest'@'localhost' IDENTIFIED BY 'upatest'",
                        "GRANT ALL PRIVILEGES ON " + getDBName() + " . * TO 'upatest'@'localhost'",
                        "FLUSH PRIVILEGES"
                );
                break;
            }
            case DERBY:
                //cc.setConnectionString("derby:default://localhost/upatest"+v+";structure=create;userName=upatest;password=upatest");
                throw new IllegalArgumentException("Not Supported Delete " + type);
            case EMBEDDED:
                File folder = new File("db-embedded/" + getDBName());
                log.log(Level.WARNING, "Delete Local Database at {0}", getFullPath(folder));
                deleteFile(folder);
                break;
            default:
                throw new IllegalArgumentException("Not Supported " + type);
        }
    }

    private static Store getStoreType(Store type) {
        if (type == null) {
            type = DEFAULT_STORE;
        }
        if (type == null) {
            type = Store.EMBEDDED;
        }
        return type;
    }

    public static String getDBName() {
        String v = getVersion().replace(".", "_");
        return "UPA_TEST" + v;
    }

    public static PersistenceUnit createTestPersistenceUnit(Class clz, Store type, String desc) {
//        String v = getVersion().replace(".", "_");
        String puId = clz == null ? "test" : clz.getSimpleName();
        type = getStoreType(type);
        StringBuilder header = new StringBuilder();
        header.append("Create Persistence Unit ").append(puId);
        if (desc != null && desc.trim().length() > 0) {
            header.append(desc);
        }
        drawBox(header);
        System.setProperty("derby.locks.deadlockTrace", "true");
        System.setProperty("derby.locks.monitor", "true");
        PersistenceGroup grp = UPA.getPersistenceGroup();
        if (grp.containsPersistenceUnit(puId)) {
            grp.setPersistenceUnit(puId);
            return grp.getPersistenceUnit(puId);
        }
        PersistenceUnit pu = grp.addPersistenceUnit(puId);
//        pu.scan(null);
        final ConnectionConfig cc = new ConnectionConfig();
        if (Store.MYSQL.equals(type)) {
            /*
                CREATE DATABASE UPA_TEST DEFAULT CHARACTER SET utf8 DEFAULT COLLATE utf8_general_ci;
                CREATE USER 'upatest'@'localhost' IDENTIFIED BY 'upatest';
                GRANT ALL PRIVILEGES ON enisoinfodb . * TO 'upatest'@'localhost';
                FLUSH PRIVILEGES;
             */
            cc.setConnectionString("mysql:default://localhost/" + getDBName() + ";structure=create;userName=upatest;password='upatest'");
        } else if (Store.DERBY.equals(type)) {
            cc.setConnectionString("derby:default://localhost/" + getDBName() + ";structure=create;userName=upatest;password=upatest");
        } else if (Store.EMBEDDED.equals(type)) {
            cc.setConnectionString("derby:embedded://db-embedded/" + getDBName() + ";structure=create;userName=upatest;password=upatest");
            File embedded = new File("db-embedded/" + getDBName());
            System.out.println("Local Database at " + getFullPath(embedded));
        } else {
            throw new IllegalArgumentException("Not Supported " + type);
        }
        pu.addConnectionConfig(cc);
        if (clz != null) {
            String namePrefix = clz.getSimpleName();
            pu.getPersistenceNameStrategy().setGlobalPersistenceNameFormat(namePrefix + "_{OBJECT_NAME}");
            pu.getPersistenceNameStrategy().setLocalPersistenceNameFormat("{OBJECT_NAME}");
//        pu.getParameters().setString(UPA.CONNECTION_STRING, "derby:embedded://upatest;structure=create;userName=upatest;password=upatest");
//        pu.getParameters().setString(UPA.CONNECTION_STRING+"."+ ConnectionOption.USER_NAME, "upatest");
        }
        grp.setPersistenceUnit(puId);
        return pu;
    }

    private static void deleteFile(File file) {
        if (file.exists()) {
            if (file.isFile()) {
                if (!file.delete()) {
                    throw new IllegalArgumentException("Unable to delete " + file.getPath());
                }
            } else if (file.isDirectory()) {
                for (File ch : file.listFiles()) {
                    deleteFile(ch);
                }
                if (!file.delete()) {
                    throw new IllegalArgumentException("Unable to delete " + file.getPath());
                }
            } else {
                if (!file.delete()) {
                    throw new IllegalArgumentException("Unable to delete " + file.getPath());
                }
            }
        }
    }

    public enum Store {
        MYSQL,
        DERBY,
        EMBEDDED
    }

    public static void println(QueryResult r) {
        println(r, System.out);
    }

    public static void println(QueryResult r, PrintStream out) {
        int count = r.getColumnsCount();
        int[] width = new int[count];
        StringTable strings = toStringTable(r);
        for (int i = 0; i < count; i++) {
            width[i] = Math.max(width[i], strings.header[i].length());
        }
        for (String[] row : strings.rows) {
            for (int i = 0; i < count; i++) {
                width[i] = Math.max(width[i], row[i].length());
            }
        }
        int allWidth = 4 + (width.length - 1) * 3;
        for (int i : width) {
            allWidth += i;
        }
        char[] br = new char[allWidth];
        Arrays.fill(br, '-');

        out.println(br);
        out.print("| ");
        for (int i = 0; i < count; i++) {
            if (i > 0) {
                out.print(" | ");
            }
            out.print(formatLeft(strings.header[i], width[i]));
        }
        out.println(" |");
        out.println(br);
        for (String[] row : strings.rows) {
            out.print("| ");
            for (int i = 0; i < count; i++) {
                if (i > 0) {
                    out.print(" | ");
                }
                out.print(formatLeft(row[i], width[i]));
            }
            out.println(" |");
        }
        out.println(br);
        r.close();
    }

    public static String formatLeft(Object str, int len) {
        StringBuilder sb = new StringBuilder(len);
        sb.append(str);
        while (sb.length() < len) {
            sb.append(' ');
        }
        return sb.toString();
    }

    private static StringTable toStringTable(QueryResult r) {
        int count = r.getColumnsCount();
        List<String[]> rows = new ArrayList<>();
        String[] header = new String[count];
        for (int i = 0; i < count; i++) {
            header[i] = String.valueOf(r.getColumnName(i));
        }
        while (r.hasNext()) {
            String[] row = new String[count];
            for (int i = 0; i < count; i++) {
                row[i] = String.valueOf(r.read(i));
            }
            rows.add(row);
        }
        return new StringTable(rows, header);
    }

    private static class StringTable {

        List<String[]> rows;
        String[] header;

        public StringTable(List<String[]> rows, String[] header) {
            this.rows = rows;
            this.header = header;
        }
    }
}
