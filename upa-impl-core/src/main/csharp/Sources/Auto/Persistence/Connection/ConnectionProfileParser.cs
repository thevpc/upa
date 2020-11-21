/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE AS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.TheVpc.Upa.Impl.Persistence.Connection
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/13/12 7:30 PM
     */
    public class ConnectionProfileParser {

        private static string[] IGNORED_OPTIONS = new string[] { Net.TheVpc.Upa.Persistence.ConnectionOption.CONNECTION_DRIVER, Net.TheVpc.Upa.Persistence.ConnectionOption.CONNECTION_DRIVER_VERSION, Net.TheVpc.Upa.Persistence.ConnectionOption.DATABASE_PRODUCT, Net.TheVpc.Upa.Persistence.ConnectionOption.DATABASE_PRODUCT_VERSION, Net.TheVpc.Upa.Persistence.ConnectionOption.DATABASE_PRODUCT_VERSION };

        private static System.Collections.Generic.ISet<string> IGNORED_OPTIONS_SET = new System.Collections.Generic.HashSet<string>(new System.Collections.Generic.List<string>(IGNORED_OPTIONS));

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Persistence.ConnectionProfile> ParseEnabled(Net.TheVpc.Upa.Impl.DefaultProperties p2, Net.TheVpc.Upa.Persistence.ConnectionConfig[] connectionConfigsArr, string prefix0) {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Persistence.ConnectionProfile> found = new System.Collections.Generic.List<Net.TheVpc.Upa.Persistence.ConnectionProfile>();
            for (int i = 0; i < connectionConfigsArr.Length; i++) {
                Net.TheVpc.Upa.Persistence.ConnectionConfig connectionConfig = connectionConfigsArr[i];
                string prefix = prefix0 + "[" + i + "]";
                p2.SetString(prefix, connectionConfig.GetConnectionString());
                p2.SetString(prefix + ".password", connectionConfig.GetPassword());
                p2.SetString(prefix + ".userName", connectionConfig.GetUserName());
                p2.SetString(prefix + ".enabled", connectionConfig.IsEnabled() == null ? "true" : System.Convert.ToString(connectionConfig.IsEnabled()));
                p2.SetString(prefix + ".structure", connectionConfig.GetStructureStrategy() == default(Net.TheVpc.Upa.Persistence.StructureStrategy) ? null : connectionConfig.GetStructureStrategy().ToString());
                foreach (System.Collections.Generic.KeyValuePair<string , string> entry in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<string,string>>(connectionConfig.GetProperties())) {
                    p2.SetString(prefix + "." + (entry).Key, (entry).Value);
                }
            }
            int i2 = 0;
            while (true) {
                string prefix = prefix0 + "[" + i2 + "]";
                if (p2.IsSet(prefix)) {
                    if (System.Convert.ToBoolean(p2.GetString(prefix + ".enabled", "true"))) {
                        Net.TheVpc.Upa.Persistence.ConnectionProfile a = Parse(p2, prefix);
                        //if (isValidConnectionProfile(a)) {
                        found.Add(a);
                    }
                    //}
                    i2++;
                } else {
                    break;
                }
            }
            if (p2.IsSet(prefix0)) {
                if (System.Convert.ToBoolean(p2.GetString(prefix0 + ".enabled", "true"))) {
                    Net.TheVpc.Upa.Persistence.ConnectionProfile a = Parse(p2, prefix0);
                    //if (isValidConnectionProfile(a)) {
                    found.Add(a);
                }
            }
            //}
            return found;
        }

        public virtual Net.TheVpc.Upa.Impl.Persistence.Connection.DefaultConnectionProfileData ParseDefaultConnectionProfileData(string connectionString) {
            //"derbyAsProduct#v12.5:defaultAsDriver#v8.699://helloAsServer:988AsPort/worldAsPath/anyThing?a=hello&b=titi;a=6;b=8"
            Net.TheVpc.Upa.Impl.Util.Regexp.PortablePattern pattern = new Net.TheVpc.Upa.Impl.Util.Regexp.PortablePattern("^([^:#;]+)(#([^:;]+))?(:([^:#;]+)(#([^:;]+))?)?://((([^/:;]+)(:([^/:;]+))?)/)?([^;]*)([;](.*))?$");
            Net.TheVpc.Upa.Impl.Util.Regexp.PortablePatternMatcher matcher = pattern.Matcher(connectionString);
            bool matchFound = matcher.Find();
            if (matchFound) {
                Net.TheVpc.Upa.Impl.Persistence.Connection.DefaultConnectionProfileData d = new Net.TheVpc.Upa.Impl.Persistence.Connection.DefaultConnectionProfileData();
                d.databaseProductName = matcher.Group(1);
                d.databaseProductVersion = matcher.Group(3);
                d.connectionDriverName = matcher.Group(5);
                d.connectionDriverVersion = matcher.Group(7);
                d.server = matcher.Group(10);
                d.port = matcher.Group(12);
                d.pathAndName = matcher.Group(13);
                d.paramsString = matcher.Group(15);
                return d;
            }
            return null;
        }

        public virtual Net.TheVpc.Upa.Persistence.ConnectionProfile Parse(Net.TheVpc.Upa.Properties parameters, string connectionStringPropertyName) {
            string connectionString = parameters.GetString(connectionStringPropertyName);
            //        System.out.println(connectionString);
            if (connectionString == null) {
                throw new System.ArgumentException (connectionStringPropertyName + " not found in parameters");
            }
            Net.TheVpc.Upa.Impl.Persistence.Connection.DefaultConnectionProfileData matchFound = ParseDefaultConnectionProfileData(connectionString);
            if (matchFound != null) {
                //            for (int i=0; i<=matcher.groupCount(); i++) {
                //                String groupStr = matcher.group(i);
                //                System.out.println("group "+i+" : <"+groupStr+">");
                //            }
                Net.TheVpc.Upa.Impl.Persistence.Connection.DefaultConnectionProfile profile = new Net.TheVpc.Upa.Impl.Persistence.Connection.DefaultConnectionProfile();
                string databaseProductName = (string) parameters.Eval(matchFound.databaseProductName);
                string databaseProductVersion = (string) parameters.Eval(matchFound.databaseProductVersion);
                string connectionDriverName = (string) parameters.Eval(matchFound.connectionDriverName);
                string connectionDriverVersion = (string) parameters.Eval(matchFound.connectionDriverVersion);
                string server = (string) parameters.Eval(matchFound.server);
                string port = (string) parameters.Eval(matchFound.port);
                string pathAndName = (string) parameters.Eval(matchFound.pathAndName);
                string @params = (string) parameters.Eval(matchFound.paramsString);
                profile.SetProperties(new System.Collections.Generic.Dictionary<string , string>());
                SetParam(profile, Net.TheVpc.Upa.Persistence.ConnectionOption.DATABASE_PRODUCT, databaseProductName, parameters, connectionStringPropertyName);
                SetParam(profile, Net.TheVpc.Upa.Persistence.ConnectionOption.DATABASE_PRODUCT_VERSION, databaseProductVersion, parameters, connectionStringPropertyName);
                SetParam(profile, Net.TheVpc.Upa.Persistence.ConnectionOption.CONNECTION_DRIVER, connectionDriverName, parameters, connectionStringPropertyName);
                SetParam(profile, Net.TheVpc.Upa.Persistence.ConnectionOption.CONNECTION_DRIVER_VERSION, connectionDriverVersion, parameters, connectionStringPropertyName);
                //pathAndName
                if (Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(pathAndName)) {
                    pathAndName = null;
                }
                pathAndName = ReplaceVars(pathAndName, parameters);
                if (pathAndName != null) {
                    int i = pathAndName.LastIndexOf('/');
                    if (i >= 0) {
                        SetParam(profile, Net.TheVpc.Upa.Persistence.ConnectionOption.DATABASE_NAME, pathAndName.Substring(i + 1), parameters, connectionStringPropertyName);
                        SetParam(profile, Net.TheVpc.Upa.Persistence.ConnectionOption.DATABASE_PATH, pathAndName.Substring(0, i), parameters, connectionStringPropertyName);
                    } else {
                        SetParam(profile, Net.TheVpc.Upa.Persistence.ConnectionOption.DATABASE_NAME, pathAndName, parameters, connectionStringPropertyName);
                    }
                }
                SetParam(profile, Net.TheVpc.Upa.Persistence.ConnectionOption.SERVER_ADDRESS, server, parameters, connectionStringPropertyName);
                SetParam(profile, Net.TheVpc.Upa.Persistence.ConnectionOption.SERVER_PORT, port, parameters, connectionStringPropertyName);
                if (@params != null) {
                    if (!@params.StartsWith(";")) {
                        @params = ";" + @params;
                    }
                    char[] chars = @params.ToCharArray();
                    int i = 0;
                    while (i < chars.Length) {
                        if (chars[i] != ';') {
                            throw new System.ArgumentException ("Expected ;");
                        }
                        i++;
                        int j = @params.IndexOf('=', i);
                        if (j < 0) {
                            SetParam(profile, @params.Substring(i), "", parameters, connectionStringPropertyName);
                            i = chars.Length + 1;
                        } else {
                            string n = @params.Substring(i, j);
                            i = j + 1;
                            if (i < chars.Length) {
                                if (chars[i] == '\"') {
                                    System.Text.StringBuilder v = new System.Text.StringBuilder();
                                    int k = i + 1;
                                    while (k < chars.Length) {
                                        if (chars[k] == '\\') {
                                            k++;
                                            v.Append(chars[k]);
                                        } else if (chars[k] == '\"') {
                                            break;
                                        } else {
                                            v.Append(chars[k]);
                                        }
                                        k++;
                                    }
                                    SetParam(profile, n, v.ToString(), parameters, connectionStringPropertyName);
                                    i = k;
                                } else if (chars[i] == '\'') {
                                    System.Text.StringBuilder v = new System.Text.StringBuilder();
                                    int k = i + 1;
                                    while (k < chars.Length) {
                                        if (chars[k] == '\\') {
                                            k++;
                                            v.Append(chars[k]);
                                        } else if (chars[k] == '\'') {
                                            break;
                                        } else {
                                            v.Append(chars[k]);
                                        }
                                        k++;
                                    }
                                    SetParam(profile, n, v.ToString(), parameters, connectionStringPropertyName);
                                    i = k;
                                } else {
                                    int e = @params.IndexOf(';', i);
                                    if (e < 0) {
                                        SetParam(profile, n, @params.Substring(i), parameters, connectionStringPropertyName);
                                        i = chars.Length + 1;
                                    } else {
                                        SetParam(profile, n, @params.Substring(i, e), parameters, connectionStringPropertyName);
                                        i = e - 1;
                                    }
                                }
                            }
                        }
                        i++;
                    }
                }
                foreach (System.Collections.Generic.KeyValuePair<string , object> e in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<string,object>>(parameters.ToMap())) {
                    string key = (e).Key;
                    if (key.StartsWith(connectionStringPropertyName + ".")) {
                        string k = key.Substring((connectionStringPropertyName).Length + 1);
                        if (!IGNORED_OPTIONS_SET.Contains(k) && !profile.GetProperties().ContainsKey(k)) {
                            profile.GetProperties()[k]=System.Convert.ToString((e).Value);
                        }
                    }
                }
                return profile;
            }
            throw new System.ArgumentException ("invalid connection string. Expected 'product:driver://info' Found : " + connectionString);
        }

        protected internal virtual void SetParam(Net.TheVpc.Upa.Impl.Persistence.Connection.DefaultConnectionProfile d, string propertyName, string propertyValue, Net.TheVpc.Upa.Properties parameters, string connectionStringPropertyName) {
            if (propertyValue == null) {
                propertyValue = parameters.GetString(connectionStringPropertyName + "." + propertyName);
            }
            propertyValue = ReplaceVars(propertyValue, parameters);
            if (propertyValue != null) {
                if (Net.TheVpc.Upa.Persistence.ConnectionOption.STRUCTURE.Equals(propertyName)) {
                    d.SetStructureStrategy((Net.TheVpc.Upa.Persistence.StructureStrategy)(System.Enum.Parse(typeof(Net.TheVpc.Upa.Persistence.StructureStrategy),propertyValue.ToUpper())));
                } else if (Net.TheVpc.Upa.Persistence.ConnectionOption.CONNECTION_DRIVER.Equals(propertyName)) {
                    d.SetConnectionDriver((propertyValue.ToUpper()));
                } else if (Net.TheVpc.Upa.Persistence.ConnectionOption.CONNECTION_DRIVER_VERSION.Equals(propertyName)) {
                    d.SetConnectionDriverVersion(propertyValue);
                } else if (Net.TheVpc.Upa.Persistence.ConnectionOption.DATABASE_PRODUCT.Equals(propertyName)) {
                    d.SetDatabaseProduct((Net.TheVpc.Upa.Persistence.DatabaseProduct)(System.Enum.Parse(typeof(Net.TheVpc.Upa.Persistence.DatabaseProduct),propertyValue.ToUpper())));
                } else if (Net.TheVpc.Upa.Persistence.ConnectionOption.DATABASE_PRODUCT_VERSION.Equals(propertyName)) {
                    d.SetDatabaseProductVersion(propertyValue);
                } else {
                    d.GetProperties()[propertyName]=propertyValue;
                }
            }
        }

        protected internal virtual string ReplaceVars(string v, Net.TheVpc.Upa.Properties parameters) {
            return v;
        }
    }
}
