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



namespace Net.TheVpc.Upa.Impl.Config
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/30/12 3:03 AM
     */
    public class DefaultUPAContextLoader {

        protected internal static readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.TheVpc.Upa.Impl.Config.DefaultUPAContextLoader)).FullName);

        private static Net.TheVpc.Upa.Impl.Util.XmlAttrListFilter includeElementFilter = new Net.TheVpc.Upa.Impl.Util.DefaultXmlAttrListFilter("url", "file", "resource");

        private static Net.TheVpc.Upa.Impl.Util.XmlAttrListFilter scanElementFilter = new Net.TheVpc.Upa.Impl.Util.DefaultXmlAttrListFilter("types", "libs");

        private static Net.TheVpc.Upa.Impl.Util.XmlAttrListFilter persistenceUnitElementFilter = new Net.TheVpc.Upa.Impl.Util.DefaultXmlAttrListFilter("name", "start", "autoscan");

        private static Net.TheVpc.Upa.Impl.Util.XmlAttrListFilter propertyElementFilter = new Net.TheVpc.Upa.Impl.Util.DefaultXmlAttrListFilter("type", "name", "value", "format");

        private static Net.TheVpc.Upa.Impl.Util.XmlAttrListFilter persistenceGroupElementFilter = new Net.TheVpc.Upa.Impl.Util.DefaultXmlAttrListFilter("name", "autoscan");

        private static Net.TheVpc.Upa.Impl.Util.XmlAttrListFilter connectionElementFilter = new Net.TheVpc.Upa.Impl.Util.DefaultXmlAttrListFilter("connectionstring", "username", "password", "structure", "enabled");

        public virtual Net.TheVpc.Upa.Persistence.UPAContextConfig Parse() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Loading UPAContext",null));
            Net.TheVpc.Upa.Impl.Config.ContextElement contextElement = new Net.TheVpc.Upa.Impl.Config.ContextElement();
            try {
                ParseResource("META-INF/upa.xml", contextElement);
                return ParseContextConfig(contextElement);
            } catch (Net.TheVpc.Upa.Exceptions.UPAException e) {
                throw e;
            } catch (System.Exception e) {
                throw new Net.TheVpc.Upa.Exceptions.UPAException(e, new Net.TheVpc.Upa.Types.I18NString("UPAContextLoaderFailed"));
            }
        }

        public virtual Net.TheVpc.Upa.Persistence.UPAContextConfig ParseContextConfig(Net.TheVpc.Upa.Impl.Config.ContextElement contextElement) {
            Net.TheVpc.Upa.Persistence.UPAContextConfig c = new Net.TheVpc.Upa.Persistence.UPAContextConfig();
            System.Collections.Generic.HashSet<Net.TheVpc.Upa.Config.ScanFilter> filters = new System.Collections.Generic.HashSet<Net.TheVpc.Upa.Config.ScanFilter>();
            foreach (Net.TheVpc.Upa.Impl.Config.ScanElement scanElement in contextElement.GetScanElements()) {
                filters.Add(new Net.TheVpc.Upa.Config.ScanFilter(scanElement.libs, scanElement.types, scanElement.propagate, Net.TheVpc.Upa.Persistence.UPAContextConfig.XML_ORDER));
            }
            if ((filters.Count==0) && contextElement.autoScan) {
                filters.Add(new Net.TheVpc.Upa.Config.ScanFilter(null, null, true, Net.TheVpc.Upa.Persistence.UPAContextConfig.XML_ORDER));
            }
            c.SetAutoScan(contextElement.autoScan);
            c.SetFilters(new System.Collections.Generic.List<Net.TheVpc.Upa.Config.ScanFilter>(filters));
            c.SetPersistenceGroups(new System.Collections.Generic.List<Net.TheVpc.Upa.Persistence.PersistenceGroupConfig>());
            foreach (Net.TheVpc.Upa.Impl.Config.PersistenceGroupElement e in contextElement.GetPersistenceGroupElements()) {
                Net.TheVpc.Upa.Persistence.PersistenceGroupConfig gc = new Net.TheVpc.Upa.Persistence.PersistenceGroupConfig(Net.TheVpc.Upa.Persistence.UPAContextConfig.XML_ORDER);
                gc.SetName(e.name);
                gc.SetAutoScan(e.autoScan);
                filters = new System.Collections.Generic.HashSet<Net.TheVpc.Upa.Config.ScanFilter>();
                foreach (Net.TheVpc.Upa.Impl.Config.ScanElement scanElement in e.GetScanElements()) {
                    filters.Add(new Net.TheVpc.Upa.Config.ScanFilter(scanElement.libs, scanElement.types, scanElement.propagate, Net.TheVpc.Upa.Persistence.UPAContextConfig.XML_ORDER));
                }
                gc.SetContextAnnotationStrategyFilters(new System.Collections.Generic.List<Net.TheVpc.Upa.Config.ScanFilter>(filters));
                System.Collections.Generic.IDictionary<string , object> parameters = gc.GetProperties();
                if (parameters == null) {
                    parameters = new System.Collections.Generic.Dictionary<string , object>();
                }
                foreach (Net.TheVpc.Upa.Property property in e.properties) {
                    parameters[property.GetName()]=Net.TheVpc.Upa.Impl.Util.UPAUtils.CreateValue(property);
                }
                c.GetPersistenceGroups().Add(gc);
                foreach (Net.TheVpc.Upa.Impl.Config.PersistenceUnitElement pue in e.GetPersistenceUnitElements()) {
                    Net.TheVpc.Upa.Persistence.PersistenceUnitConfig pu = new Net.TheVpc.Upa.Persistence.PersistenceUnitConfig();
                    pu.SetName(pue.name);
                    pu.SetAutoStart(pue.start);
                    pu.SetAutoScan(pue.autoScan);
                    filters = new System.Collections.Generic.HashSet<Net.TheVpc.Upa.Config.ScanFilter>();
                    foreach (Net.TheVpc.Upa.Impl.Config.ScanElement scanElement in pue.GetScanElements()) {
                        filters.Add(new Net.TheVpc.Upa.Config.ScanFilter(scanElement.libs, scanElement.types, scanElement.propagate, Net.TheVpc.Upa.Persistence.UPAContextConfig.XML_ORDER));
                    }
                    pu.SetContextAnnotationStrategyFilters(new System.Collections.Generic.List<Net.TheVpc.Upa.Config.ScanFilter>(filters));
                    //pu.setModel(null);
                    parameters = pu.GetProperties();
                    if (parameters == null) {
                        parameters = new System.Collections.Generic.Dictionary<string , object>();
                    }
                    foreach (Net.TheVpc.Upa.Property property in pue.properties) {
                        parameters[property.GetName()]=Net.TheVpc.Upa.Impl.Util.UPAUtils.CreateValue(property);
                    }
                    pu.SetPersistenceGroup(e.name);
                    pu.SetProperties(parameters);
                    foreach (Net.TheVpc.Upa.Impl.Config.ConnectionElement ce in pue.connectionElements) {
                        Net.TheVpc.Upa.Persistence.ConnectionConfig cc = new Net.TheVpc.Upa.Persistence.ConnectionConfig();
                        cc.SetConnectionString(ce.connectionString);
                        cc.SetUserName(ce.userName);
                        cc.SetPassword(ce.password);
                        cc.SetStructureStrategy(Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(ce.structure) ? ((Net.TheVpc.Upa.Persistence.StructureStrategy)(Net.TheVpc.Upa.Impl.Util.PlatformUtils.GetUndefinedValue<Net.TheVpc.Upa.Persistence.StructureStrategy>(typeof(Net.TheVpc.Upa.Persistence.StructureStrategy)))) : (Net.TheVpc.Upa.Persistence.StructureStrategy)(System.Enum.Parse(typeof(Net.TheVpc.Upa.Persistence.StructureStrategy),ce.structure.ToUpper())));
                        cc.SetProperties(new System.Collections.Generic.Dictionary<string , string>());
                        foreach (System.Collections.Generic.KeyValuePair<string , string> x in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<string,string>>(ce.properties)) {
                            cc.GetProperties()[(x).Key]=(x).Value;
                        }
                        pu.GetConnections().Add(cc);
                    }
                    foreach (Net.TheVpc.Upa.Impl.Config.ConnectionElement ce in pue.rootConnectionElements) {
                        Net.TheVpc.Upa.Persistence.ConnectionConfig cc = new Net.TheVpc.Upa.Persistence.ConnectionConfig();
                        cc.SetConnectionString(ce.connectionString);
                        cc.SetUserName(ce.userName);
                        cc.SetPassword(ce.password);
                        cc.SetStructureStrategy(Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(ce.structure) ? ((Net.TheVpc.Upa.Persistence.StructureStrategy)(Net.TheVpc.Upa.Impl.Util.PlatformUtils.GetUndefinedValue<Net.TheVpc.Upa.Persistence.StructureStrategy>(typeof(Net.TheVpc.Upa.Persistence.StructureStrategy)))) : (Net.TheVpc.Upa.Persistence.StructureStrategy)(System.Enum.Parse(typeof(Net.TheVpc.Upa.Persistence.StructureStrategy),ce.structure.ToUpper())));
                        cc.SetProperties(new System.Collections.Generic.Dictionary<string , string>());
                        foreach (System.Collections.Generic.KeyValuePair<string , string> x in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<string,string>>(ce.properties)) {
                            cc.GetProperties()[(x).Key]=(x).Value;
                        }
                        pu.GetRootConnections().Add(cc);
                    }
                    gc.GetPersistenceUnits().Add(pu);
                }
            }
            return c;
        }

        private void ParseResource(string resource, Net.TheVpc.Upa.Impl.Config.ContextElement context) /* throws Net.TheVpc.Upa.Exceptions.UPAException, Org.Xml.Sax.SAXException, System.IO.IOException, Javax.Xml.Parsers.ParserConfigurationException */  {
        }

        private void ParseURL(string url, Net.TheVpc.Upa.Impl.Config.ContextElement contextElement) /* throws Net.TheVpc.Upa.Exceptions.UPAException, Org.Xml.Sax.SAXException, System.IO.IOException, Javax.Xml.Parsers.ParserConfigurationException */  {
            log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Loading Context URL {0}",null,url));
        }

        private string Nullify(string s) {
            if (s == null) {
                return s;
            }
            s = s.Trim();
            if ((s).Length == 0) {
                return null;
            }
            return s;
        }

        private void ParseInclude(System.Xml.XmlElement e, Net.TheVpc.Upa.Impl.Config.ContextElement contextElement, string url) /* throws Net.TheVpc.Upa.Exceptions.UPAException, Org.Xml.Sax.SAXException, System.IO.IOException, Javax.Xml.Parsers.ParserConfigurationException */  {
            System.Collections.Generic.IDictionary<string , string> attrs = Net.TheVpc.Upa.Impl.Util.XMLUtils.GetAttributes(e, includeElementFilter);
            string urlString = Nullify(Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(attrs,"url"));
            if (urlString != null) {
                ParseURL(url, contextElement);
            }
            string file = Nullify(Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(attrs,"file"));
            if (file != null) {
                ParseURL((((file))), contextElement);
            }
            string resource = Nullify(Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(attrs,"resource"));
            if (resource != null) {
                ParseResource(resource, contextElement);
            }
        }

        private Net.TheVpc.Upa.Impl.Config.PersistenceGroupElement ParsePersistenceGroup(System.Xml.XmlElement e, Net.TheVpc.Upa.Impl.Config.ContextElement context) {
            System.Collections.Generic.IDictionary<string , string> attrs = Net.TheVpc.Upa.Impl.Util.XMLUtils.GetAttributes(e, persistenceGroupElementFilter);
            string name = Nullify(Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(attrs,"name"));
            Net.TheVpc.Upa.Impl.Config.PersistenceGroupElement c = context.GetOrAddPersistenceGroupElement(name);
            c.autoScan = ParseBoolean(Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(attrs,"autoscan"), c.autoScan);
            System.Xml.XmlNodeList nl = (e).ChildNodes;
            if (nl != null && (nl).Count > 0) {
                for (int i = 0; i < (nl).Count; i++) {
                    System.Xml.XmlNode item = nl.Item(i);
                    if (item is System.Xml.XmlElement) {
                        System.Xml.XmlElement el = (System.Xml.XmlElement) item;
                        string tagName = (el).Name;
                        if (Net.TheVpc.Upa.Impl.Util.XMLUtils.EqualsUniform(tagName, "persistenceUnit")) {
                            ParsePersistenceUnit(el, c);
                        } else if (Net.TheVpc.Upa.Impl.Util.XMLUtils.EqualsUniform(tagName, "scan")) {
                            c.AddScanElement(ParseScan(el));
                        } else if (Net.TheVpc.Upa.Impl.Util.XMLUtils.EqualsUniform(tagName, "property")) {
                            c.properties.Add(ParseProperty(el));
                        } else {
                            throw new System.ArgumentException ("Unsupported tag " + tagName + " for PersistenceGroup. " + "valid tags are persistenceUnit, scan, property");
                        }
                    }
                }
            }
            return c;
        }

        private bool ParseBoolean(string v, bool defaultValue) {
            v = Nullify(v);
            if (v != null) {
                return System.Convert.ToBoolean(v);
            }
            return defaultValue;
        }

        private Net.TheVpc.Upa.Impl.Config.ScanElement ParseScan(System.Xml.XmlElement e) {
            Net.TheVpc.Upa.Impl.Config.ScanElement c = new Net.TheVpc.Upa.Impl.Config.ScanElement();
            System.Collections.Generic.IDictionary<string , string> attrs = Net.TheVpc.Upa.Impl.Util.XMLUtils.GetAttributes(e, scanElementFilter);
            c.types = Nullify(Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(attrs,"types"));
            c.libs = Nullify(Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(attrs,"libs"));
            c.propagate = ParseBoolean(Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(attrs,"propagate"), true);
            return c;
        }

        private Net.TheVpc.Upa.Impl.Config.PersistenceUnitElement ParsePersistenceUnit(System.Xml.XmlElement e, Net.TheVpc.Upa.Impl.Config.PersistenceGroupElement persistenceGroupElement) {
            System.Collections.Generic.IDictionary<string , string> attrs = Net.TheVpc.Upa.Impl.Util.XMLUtils.GetAttributes(e, persistenceUnitElementFilter);
            string name = Nullify(Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(attrs,"name"));
            Net.TheVpc.Upa.Impl.Config.PersistenceUnitElement s = persistenceGroupElement.GetOrAddPersistenceUnitElement(name);
            s.start = ParseBoolean(Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(attrs,"start"), s.start);
            s.autoScan = ParseBoolean(Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(attrs,"autoScan"), s.autoScan);
            System.Xml.XmlNodeList nl = (e).ChildNodes;
            if (nl != null && (nl).Count > 0) {
                for (int i = 0; i < (nl).Count; i++) {
                    System.Xml.XmlNode item = nl.Item(i);
                    if (item is System.Xml.XmlElement) {
                        System.Xml.XmlElement el = (System.Xml.XmlElement) item;
                        //add it to list
                        string tagName = (el).Name;
                        if (Net.TheVpc.Upa.Impl.Util.XMLUtils.EqualsUniform(tagName, "connection")) {
                            s.connectionElements.Add(ParseConnection(el));
                        } else if (Net.TheVpc.Upa.Impl.Util.XMLUtils.EqualsUniform(tagName, "rootConnection")) {
                            s.rootConnectionElements.Add(ParseConnection(el));
                        } else if (Net.TheVpc.Upa.Impl.Util.XMLUtils.EqualsUniform(tagName, "property")) {
                            s.properties.Add(ParseProperty(el));
                        } else if (Net.TheVpc.Upa.Impl.Util.XMLUtils.EqualsUniform(tagName, "scan")) {
                            s.scanElements.Add(ParseScan(el));
                        } else {
                            throw new System.ArgumentException ("Unsupported tag " + tagName + " for PersistenceUnit. " + "valid tags are connection, rootConnection, property, scan");
                        }
                    } else {
                    }
                }
            }
            //                    System.out.println(item);
            return s;
        }

        private Net.TheVpc.Upa.Property ParseProperty(System.Xml.XmlElement e) {
            System.Collections.Generic.IDictionary<string , string> attrs = Net.TheVpc.Upa.Impl.Util.XMLUtils.GetAttributes(e, propertyElementFilter);
            string name = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(attrs,"name");
            string className = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(attrs,"type");
            string format = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(attrs,"format");
            string @value = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(attrs,"value");
            string value2 = (e).FirstChild != null ? ((e).FirstChild).Value : null;
            if (@value == null) {
                @value = value2;
            }
            return (new Net.TheVpc.Upa.Property(name, @value, className, format));
        }

        private Net.TheVpc.Upa.Impl.Config.ConnectionElement ParseConnection(System.Xml.XmlElement e) {
            Net.TheVpc.Upa.Impl.Config.ConnectionElement s = new Net.TheVpc.Upa.Impl.Config.ConnectionElement();
            System.Collections.Generic.IDictionary<string , string> attrs = Net.TheVpc.Upa.Impl.Util.XMLUtils.GetAttributes(e, connectionElementFilter);
            s.connectionString = TrimToNull(Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(attrs,"connectionstring"));
            s.userName = TrimToNull(Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(attrs,"username"));
            s.password = TrimToNull(Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(attrs,"password"));
            s.structure = TrimToNull(Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(attrs,"structure"));
            if (attrs.ContainsKey("enabled")) {
                s.properties["enabled"]=TrimToNull(Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(attrs,"enabled"));
            }
            System.Xml.XmlNodeList nl = (e).ChildNodes;
            if (nl != null && (nl).Count > 0) {
                for (int i = 0; i < (nl).Count; i++) {
                    System.Xml.XmlNode item = nl.Item(i);
                    if (item is System.Xml.XmlElement) {
                        System.Xml.XmlElement el = (System.Xml.XmlElement) item;
                        //add it to list
                        string tagName = (el).Name;
                        if (Net.TheVpc.Upa.Impl.Util.XMLUtils.EqualsUniform(tagName, "connectionString")) {
                            s.connectionString = TrimToNull(((el).FirstChild).Value);
                        } else if (Net.TheVpc.Upa.Impl.Util.XMLUtils.EqualsUniform(tagName, "userName")) {
                            s.userName = TrimToNull(((el).FirstChild).Value);
                        } else if (Net.TheVpc.Upa.Impl.Util.XMLUtils.EqualsUniform(tagName, "password")) {
                            s.password = TrimToNull(((el).FirstChild).Value);
                        } else if (Net.TheVpc.Upa.Impl.Util.XMLUtils.EqualsUniform(tagName, "structure")) {
                            s.structure = TrimToNull(((el).FirstChild).Value);
                        } else if (Net.TheVpc.Upa.Impl.Util.XMLUtils.EqualsUniform(tagName, "enabled")) {
                            s.properties[tagName]=TrimToNull(((el).FirstChild).Value);
                        } else if (Net.TheVpc.Upa.Impl.Util.XMLUtils.EqualsUniform(tagName, "property")) {
                            Net.TheVpc.Upa.Property p = ParseProperty(el);
                            object t = Net.TheVpc.Upa.Impl.Util.UPAUtils.CreateValue(p);
                            s.properties[p.GetName()]=t == null ? null : System.Convert.ToString(t);
                        } else {
                            throw new System.ArgumentException ("Unsupported tag " + tagName + " for Connection and RootConnection. " + "valid tags are connectionString, userName, password, " + "structure, enabled, property");
                        }
                    } else {
                    }
                }
            }
            //                    System.out.println(item);
            return s;
        }

        private string TrimToNull(string s) {
            if (s != null) {
                s = s.Trim();
                if ((s.Length==0)) {
                    return null;
                }
            }
            return s;
        }
    }
}
