package net.vpc.upa.impl.persistence.connection;

import net.vpc.upa.Properties;
import net.vpc.upa.impl.util.StringUtils;
import net.vpc.upa.persistence.*;

import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import net.vpc.upa.impl.DefaultProperties;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/13/12 7:30 PM
 */
public class ConnectionProfileParser {

    private static String[] IGNORED_OPTIONS = new String[]{ConnectionOption.CONNECTION_DRIVER,
        ConnectionOption.CONNECTION_DRIVER_VERSION,
        ConnectionOption.DATABASE_PRODUCT,
        ConnectionOption.DATABASE_PRODUCT_VERSION,
        ConnectionOption.DATABASE_PRODUCT_VERSION};
    private static Set<String> IGNORED_OPTIONS_SET = new HashSet<String>(Arrays.asList(IGNORED_OPTIONS));

    public List<ConnectionProfile> parseEnabled(DefaultProperties p2, ConnectionConfig[] connectionConfigsArr, String prefix0) {
        List<ConnectionProfile> found = new ArrayList<ConnectionProfile>();
        for (int i = 0; i < connectionConfigsArr.length; i++) {
            ConnectionConfig connectionConfig = connectionConfigsArr[i];
            String prefix = prefix0 + "[" + i + "]";
            p2.setString(prefix, connectionConfig.getConnectionString());
            p2.setString(prefix + ".password", connectionConfig.getPassword());
            p2.setString(prefix + ".userName", connectionConfig.getUserName());
            p2.setString(prefix + ".enabled", connectionConfig.isEnabled() == null ? "true" : String.valueOf(connectionConfig.isEnabled()));
            p2.setString(prefix + ".structure", connectionConfig.getStructureStrategy() == null ? null : connectionConfig.getStructureStrategy().toString());
            for (Map.Entry<String, String> entry : connectionConfig.getProperties().entrySet()) {
                p2.setString(prefix + "." + entry.getKey(), entry.getValue());
            }
        }
        int i2 = 0;
        while (true) {
            String prefix = prefix0 + "[" + i2 + "]";
            if (p2.isSet(prefix)) {
                if (Boolean.parseBoolean(p2.getString(prefix + ".enabled", "true"))) {
                    ConnectionProfile a = parse(p2, prefix);
                    //if (isValidConnectionProfile(a)) {
                    found.add(a);
                    //}
                }
                i2++;
            } else {
                break;
            }
        }
        if (p2.isSet(prefix0)) {
            if (Boolean.parseBoolean(p2.getString(prefix0 + ".enabled", "true"))) {
                ConnectionProfile a = parse(p2, prefix0);
                //if (isValidConnectionProfile(a)) {
                found.add(a);
                //}
            }
        }
        return found;
    }

    public DefaultConnectionProfileData parseDefaultConnectionProfileData(String connectionString){
        //"derbyAsProduct#v12.5:defaultAsDriver#v8.699://helloAsServer:988AsPort/worldAsPath/anyThing?a=hello&b=titi;a=6;b=8"

        /**
         * @PortabilityHint(target="C#",name="replace")
         * var match = System.Text.RegularExpressions.Regex.Match(connectionString, "^([^:#;]+)(#([^:;]+))?(:([^:#;]+)(#([^:;]+))?)?://((([^/:;]+)(:([^/:;]+))?)/)?([^;]*)([;](.*))?$");
         * if (match!=null){
         *   DefaultConnectionProfileData d = new DefaultConnectionProfileData();
         *   d.databaseProductName = match.Groups[1].Value;
         *   d.databaseProductVersion = match.Groups[3].Value;
         *   d.connectionDriverName = match.Groups[5].Value;
         *   d.connectionDriverVersion = match.Groups[7].Value;
         *   d.server = match.Groups[10].Value;
         *   d.port = match.Groups[12].Value;
         *   d.pathAndName = match.Groups[13].Value;
         *   d.paramsString = match.Groups[15].Value;
         *   return d;
         * }
         */
        {
            Pattern pattern = Pattern.compile("^([^:#;]+)(#([^:;]+))?(:([^:#;]+)(#([^:;]+))?)?://((([^/:;]+)(:([^/:;]+))?)/)?([^;]*)([;](.*))?$");
            Matcher matcher = pattern.matcher(connectionString);
            boolean matchFound = matcher.find();
            if (matchFound) {
                DefaultConnectionProfileData d = new DefaultConnectionProfileData();
                d.databaseProductName = matcher.group(1);
                d.databaseProductVersion = matcher.group(3);
                d.connectionDriverName = matcher.group(5);
                d.connectionDriverVersion = matcher.group(7);
                d.server = matcher.group(10);
                d.port = matcher.group(12);
                d.pathAndName = matcher.group(13);
                d.paramsString = matcher.group(15);
                return d;
            }
        }
        return null;

    }

    public ConnectionProfile parse(Properties parameters, String connectionStringPropertyName) {
        String connectionString = parameters.getString(connectionStringPropertyName);
//        System.out.println(connectionString);
        if (connectionString == null) {
            throw new IllegalArgumentException(connectionStringPropertyName + " not found in parameters");
        }
        DefaultConnectionProfileData matchFound = parseDefaultConnectionProfileData(connectionString);

        if (matchFound!=null) {
//            for (int i=0; i<=matcher.groupCount(); i++) {
//                String groupStr = matcher.group(i);
//                System.out.println("group "+i+" : <"+groupStr+">");
//            }
            DefaultConnectionProfile profile = new DefaultConnectionProfile();
            String databaseProductName = (String) parameters.eval(matchFound.databaseProductName);
            String databaseProductVersion = (String) parameters.eval(matchFound.databaseProductVersion);
            String connectionDriverName = (String) parameters.eval(matchFound.connectionDriverName);
            String connectionDriverVersion = (String) parameters.eval(matchFound.connectionDriverVersion);
            String server = (String) parameters.eval(matchFound.server);
            String port = (String) parameters.eval(matchFound.port);
            String pathAndName = (String) parameters.eval(matchFound.pathAndName);
            String params = (String) parameters.eval(matchFound.paramsString);
            profile.setProperties(new HashMap<String, String>());

            setParam(profile, ConnectionOption.DATABASE_PRODUCT, databaseProductName, parameters, connectionStringPropertyName);
            setParam(profile, ConnectionOption.DATABASE_PRODUCT_VERSION, databaseProductVersion, parameters, connectionStringPropertyName);
            setParam(profile, ConnectionOption.CONNECTION_DRIVER, connectionDriverName, parameters, connectionStringPropertyName);
            setParam(profile, ConnectionOption.CONNECTION_DRIVER_VERSION, connectionDriverVersion, parameters, connectionStringPropertyName);

            //pathAndName
            if (StringUtils.isNullOrEmpty(pathAndName)) {
                pathAndName = null;
            }
            pathAndName = replaceVars(pathAndName, parameters);
            if (pathAndName != null) {
                int i = pathAndName.lastIndexOf('/');
                if (i >= 0) {
                    setParam(profile, ConnectionOption.DATABASE_NAME, pathAndName.substring(i + 1), parameters, connectionStringPropertyName);
                    setParam(profile, ConnectionOption.DATABASE_PATH, pathAndName.substring(0, i), parameters, connectionStringPropertyName);
                } else {
                    setParam(profile, ConnectionOption.DATABASE_NAME, pathAndName, parameters, connectionStringPropertyName);
                }
            }

            setParam(profile, ConnectionOption.SERVER_ADDRESS, server, parameters, connectionStringPropertyName);

            setParam(profile, ConnectionOption.SERVER_PORT, port, parameters, connectionStringPropertyName);

            if (params != null) {
                if(!params.startsWith(";")){
                    params=";"+params;
                }
                char[] chars = params.toCharArray();
                int i = 0;
                while (i < chars.length) {
                    if (chars[i] != ';') {
                        throw new IllegalArgumentException("Expected ;");
                    }
                    i++;
                    int j = params.indexOf('=', i);
                    if (j < 0) {
                        setParam(profile, params.substring(i), "", parameters, connectionStringPropertyName);
                        i = chars.length + 1;
                    } else {
                        String n = params.substring(i, j);
                        i = j + 1;
                        if (i < chars.length) {
                            if (chars[i] == '\"') {
                                StringBuilder v = new StringBuilder();
                                int k = i + 1;
                                while (k < chars.length) {
                                    if (chars[k] == '\\') {
                                        k++;
                                        v.append(chars[k]);
                                    } else if (chars[k] == '\"') {
                                        break;
                                    } else {
                                        v.append(chars[k]);
                                    }
                                    k++;
                                }
                                setParam(profile, n, v.toString(), parameters, connectionStringPropertyName);
                                i = k;
                            }else if (chars[i] == '\'') {
                                StringBuilder v = new StringBuilder();
                                int k = i + 1;
                                while (k < chars.length) {
                                    if (chars[k] == '\\') {
                                        k++;
                                        v.append(chars[k]);
                                    } else if (chars[k] == '\'') {
                                        break;
                                    } else {
                                        v.append(chars[k]);
                                    }
                                    k++;
                                }
                                setParam(profile, n, v.toString(), parameters, connectionStringPropertyName);
                                i = k;
                            } else {
                                int e = params.indexOf(';', i);
                                if (e < 0) {
                                    setParam(profile, n, params.substring(i), parameters, connectionStringPropertyName);
                                    i = chars.length + 1;
                                } else {
                                    setParam(profile, n, params.substring(i, e), parameters, connectionStringPropertyName);
                                    i = e - 1;
                                }
                            }
                        }
                    }
                    i++;
                }
            }
            for (Map.Entry<String, Object> e : parameters.toMap().entrySet()) {
                String key = e.getKey();
                if (key.startsWith(connectionStringPropertyName + ".")) {
                    String k = key.substring(connectionStringPropertyName.length() + 1);
                    if (!IGNORED_OPTIONS_SET.contains(k) && !profile.getProperties().containsKey(k)) {
                        profile.getProperties().put(k, String.valueOf(e.getValue()));
                    }
                }
            }
            return profile;
        }
        throw new IllegalArgumentException("invalid connection string. Expected 'product:driver://info' Found : "+connectionString);
    }

    protected void setParam(DefaultConnectionProfile d, String propertyName, String propertyValue, Properties parameters, String connectionStringPropertyName) {
        if (propertyValue == null) {
            propertyValue = parameters.getString(connectionStringPropertyName + "." + propertyName);
        }
        propertyValue = replaceVars(propertyValue, parameters);
        if (propertyValue != null) {
            if (ConnectionOption.STRUCTURE.equals(propertyName)) {
                d.setStructureStrategy(StructureStrategy.valueOf(propertyValue.toUpperCase()));
            } else if (ConnectionOption.CONNECTION_DRIVER.equals(propertyName)) {
                d.setConnectionDriver((propertyValue.toUpperCase()));
            } else if (ConnectionOption.CONNECTION_DRIVER_VERSION.equals(propertyName)) {
                d.setConnectionDriverVersion(propertyValue);
            } else if (ConnectionOption.DATABASE_PRODUCT.equals(propertyName)) {
                d.setDatabaseProduct(DatabaseProduct.valueOf(propertyValue.toUpperCase()));
            } else if (ConnectionOption.DATABASE_PRODUCT_VERSION.equals(propertyName)) {
                d.setDatabaseProductVersion(propertyValue);
            } else {
                d.getProperties().put(propertyName, propertyValue);
            }
        }
    }

    protected String replaceVars(String v, Properties parameters) {
        return v;
    }
}
