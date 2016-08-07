package net.vpc.upa.impl.config;

import java.util.LinkedHashMap;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/7/13 2:24 AM
*/
public class ConnectionElement {

    String connectionString;
    String userName;
    String password;
    String structure;
    LinkedHashMap<String, String> properties = new LinkedHashMap<String, String>();
}
