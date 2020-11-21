///*
// * Created by IntelliJ IDEA.
// * User: Administrateur
// * Date: 16 aout 02
// * Time: 20:28:35
// * To change template for new class use
// * Code Style | Class Templates options (Tools | IDE Options).
// */
//package net.thevpc.upa.impl.persistence.mckoi;
//
//
//import net.thevpc.upa.impl.persistence.connection.DefaultPropertiesConnectionProfile;
//import net.thevpc.upa.persistence.connection.ConnectionProfile;
//import net.thevpc.upa.impl.util.UPAUtils;
//
//import java.util.HashMap;
//
//public class McKoiPropertiesConnectionProfile extends DefaultPropertiesConnectionProfile {
//    public McKoiPropertiesConnectionProfile() {
//        super(McKoiPersistenceUnitManager.DB_NAME, "mkoi,com.mckoi.JDBCDriver", "{serverAddress}{serverPort}{local}{create}{" + ConnectionProfile.LOGIN + "}{password}{" + ConnectionProfile.DATABASE_NAME + "}",
//                UPAUtils.fill(new HashMap<String, String>(), "serverAddress", "", "serverPort", "", ConnectionProfile.LOGIN, "root", "password", "",
//                        "local", "true",
//                        ConnectionProfile.CREATE_OPTION_NAME, "false",
//                        ConnectionProfile.DATABASE_NAME, "c:/myMckoiDB.config"));
//    }
//
//    public String getUrl() {
//        HashMap props = new HashMap();
//        props.put("application.home", ".");
//        props.putAll(System.getProperties());
//        props.putAll(getProperties());
//        String local = (String) props.get("local");
//        String create = (String) props.get("create");
//        String databaseName = (String) props.get(DATABASE_NAME);
//        String serverPort = (String) props.get("serverPort");
//        String serverAddress = (String) props.get("serverAddress");
//        if (local != null && local.equals("true")) {
//            serverPort = (serverPort == null || serverPort.length() == 0) ? "" : (":" + serverPort);
//            databaseName = (databaseName == null || databaseName.length() == 0) ? "" : ("/" + databaseName);
//            create = (create == null || !create.equals("true")) ? "" : ("?create=true");
//            return "jdbc:mckoi://" + serverAddress + serverPort + databaseName + "/" + create;
//        } else {
//            create = (create == null || !create.equals("true")) ? "" : ("?create=true");
//            return "jdbc:mckoi:local://" + databaseName + "/" + create;
//        }
//    }
//}
