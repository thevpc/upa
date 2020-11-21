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



namespace Net.TheVpc.Upa.Impl.Persistence
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/17/12 3:15 PM
     */
    public class DefaultPersistenceNameStrategy : Net.TheVpc.Upa.Persistence.PersistenceNameStrategy {

        protected internal static System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.TheVpc.Upa.Impl.Persistence.DefaultPersistenceNameStrategy)).FullName);

        private string escapedNamePattern;

        private Net.TheVpc.Upa.Persistence.PersistenceStore persistenceStore;

        private Net.TheVpc.Upa.PersistenceUnit persistenceUnit;

        private Net.TheVpc.Upa.Persistence.PersistenceNameConfig model;

        private System.Collections.Generic.IDictionary<string , string> modelMap = new System.Collections.Generic.Dictionary<string , string>();

        public virtual void Init(Net.TheVpc.Upa.Persistence.PersistenceStore persistenceStore, Net.TheVpc.Upa.Persistence.PersistenceNameConfig model) {
            this.model = model;
            this.persistenceStore = persistenceStore;
            //        modelMapPatterns.put("GLOBAL_PERSISTENCE_NAME", "{OBJECT_NAME}");
            //        modelMapPatterns.put("LOCAL_PERSISTENCE_NAME", "{OBJECT_NAME}");
            //        modelMapPatterns.put("PERSISTENCE_NAME_ESCAPE", null);
            //        modelMapPatterns.put(PersistenceNameType.FK_CONSTRAINT.name(), "");
            if (model != null) {
                modelMap["GLOBAL_PERSISTENCE_NAME"]=model.GetGlobalPersistenceName();
                modelMap["LOCAL_PERSISTENCE_NAME"]=model.GetLocalPersistenceName();
                modelMap["PERSISTENCE_NAME_ESCAPE"]=model.GetPersistenceNameEscape();
                if (model.GetNames() != null) {
                    foreach (Net.TheVpc.Upa.Persistence.PersistenceName persistenceNameFormat in model.GetNames()) {
                        if (Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(persistenceNameFormat.GetObject())) {
                            modelMap[persistenceNameFormat.GetPersistenceNameType().Name()]=persistenceNameFormat.GetValue();
                        } else {
                            modelMap[persistenceNameFormat.GetPersistenceNameType().Name() + ":" + persistenceNameFormat.GetObject()]=persistenceNameFormat.GetValue();
                        }
                    }
                }
            }
        }

        public virtual void Close() {
        }

        public virtual string GetPersistenceName(object source, Net.TheVpc.Upa.Persistence.PersistenceNameType spec) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Persistence.PersistenceNameType> types = new System.Collections.Generic.List<Net.TheVpc.Upa.Persistence.PersistenceNameType>();
            Net.TheVpc.Upa.Impl.Persistence.UPAObjectAndSpec upaObjectAndSpec = new Net.TheVpc.Upa.Impl.Persistence.UPAObjectAndSpec(source, spec);
            if (source is Net.TheVpc.Upa.Entity) {
                Net.TheVpc.Upa.Entity v = (Net.TheVpc.Upa.Entity) source;
                if (spec == null) {
                    string p = v.GetPersistenceName();
                    if (p == null) {
                        p = v.GetName();
                    }
                    foreach (Net.TheVpc.Upa.Extensions.EntityExtensionDefinition extension in v.GetExtensionDefinitions()) {
                        if (extension is Net.TheVpc.Upa.Extensions.ViewEntityExtensionDefinition) {
                            types.Add(Net.TheVpc.Upa.Persistence.PersistenceNameType.VIEW);
                        }
                        if (extension is Net.TheVpc.Upa.Extensions.UnionEntityExtensionDefinition) {
                            types.Add(Net.TheVpc.Upa.Persistence.PersistenceNameType.UNION_TABLE);
                        }
                    }
                    types.Add(Net.TheVpc.Upa.Persistence.PersistenceNameType.TABLE);
                    return ValidatePersistenceName(p, Net.TheVpc.Upa.Persistence.PersistenceNameType.TABLE, v.GetName(), upaObjectAndSpec, types);
                }
                if (Net.TheVpc.Upa.Persistence.PersistenceNameType.PK_CONSTRAINT.Equals(spec)) {
                    string p = v.GetShortName();
                    if (p == null) {
                        p = v.GetPersistenceName();
                    }
                    if (p == null) {
                        p = v.GetName();
                    }
                    types.Add(Net.TheVpc.Upa.Persistence.PersistenceNameType.PK_CONSTRAINT);
                    return ValidatePersistenceName("PK_" + p, Net.TheVpc.Upa.Persistence.PersistenceNameType.PK_CONSTRAINT, v.GetName(), upaObjectAndSpec, types);
                }
                if (Net.TheVpc.Upa.Persistence.PersistenceNameType.IMPLICIT_VIEW.Equals(spec)) {
                    string p = v.GetPersistenceName();
                    if (p == null) {
                        p = v.GetName();
                    }
                    types.Add(Net.TheVpc.Upa.Persistence.PersistenceNameType.IMPLICIT_VIEW);
                    types.Add(Net.TheVpc.Upa.Persistence.PersistenceNameType.TABLE);
                    return ValidatePersistenceName(p + "_IV", Net.TheVpc.Upa.Persistence.PersistenceNameType.IMPLICIT_VIEW, v.GetName(), upaObjectAndSpec, types);
                }
            }
            if (source is Net.TheVpc.Upa.Index) {
                Net.TheVpc.Upa.Index v = (Net.TheVpc.Upa.Index) source;
                string p = v.GetPersistenceName();
                if (p == null) {
                    p = v.GetName();
                }
                if (p == null) {
                    string sn = v.GetEntity().GetShortName();
                    if (sn == null) {
                        sn = v.GetEntity().GetName();
                    }
                    System.Text.StringBuilder sb = new System.Text.StringBuilder("IX_").Append(sn);
                    foreach (string field in v.GetFieldNames()) {
                        sb.Append("_").Append(field);
                    }
                    p = sb.ToString();
                }
                types.Add(Net.TheVpc.Upa.Persistence.PersistenceNameType.INDEX);
                return ValidatePersistenceName(p, Net.TheVpc.Upa.Persistence.PersistenceNameType.INDEX, v.GetName(), upaObjectAndSpec, types);
            }
            if (source is Net.TheVpc.Upa.Relationship) {
                Net.TheVpc.Upa.Relationship v = (Net.TheVpc.Upa.Relationship) source;
                string p = v.GetPersistenceName();
                if (p == null) {
                    p = v.GetName();
                }
                types.Add(Net.TheVpc.Upa.Persistence.PersistenceNameType.FK_CONSTRAINT);
                return ValidatePersistenceName(p, Net.TheVpc.Upa.Persistence.PersistenceNameType.FK_CONSTRAINT, v.GetName(), upaObjectAndSpec, types);
            }
            if (source is Net.TheVpc.Upa.PrimitiveField) {
                Net.TheVpc.Upa.Field v = (Net.TheVpc.Upa.Field) source;
                string p = v.GetPersistenceName();
                if (p == null) {
                    p = v.GetName();
                }
                types.Add(Net.TheVpc.Upa.Persistence.PersistenceNameType.COLUMN);
                return ValidatePersistenceName(p, Net.TheVpc.Upa.Persistence.PersistenceNameType.COLUMN, v.GetEntity().GetName() + "." + v.GetName(), upaObjectAndSpec, types);
            }
            if (source is string) {
                if (Net.TheVpc.Upa.Persistence.PersistenceNameType.ALIAS.Equals(spec)) {
                    return ValidatePersistenceName((string) source, Net.TheVpc.Upa.Persistence.PersistenceNameType.ALIAS, "aliasName", upaObjectAndSpec, types);
                } else {
                    return ValidatePersistenceName((string) source, Net.TheVpc.Upa.Persistence.PersistenceNameType.ALIAS, null, upaObjectAndSpec, types);
                }
            }
            throw new System.ArgumentException ("No Supported");
        }

        private string GetParamValue(string confPrefix, Net.TheVpc.Upa.Persistence.PersistenceNameType type, string name, Net.TheVpc.Upa.Properties parameters) {
            string v = GetParamValue(confPrefix, type.Name() + ":" + name, parameters);
            if (v == null) {
                v = GetParamValue(confPrefix, type.Name(), parameters);
            }
            return v;
        }

        private string GetParamValue(string confPrefix, string name, Net.TheVpc.Upa.Properties parameters) {
            string v = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(modelMap,name);
            if (Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(v)) {
                v = parameters.GetString(confPrefix + name);
            }
            if (!Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(v)) {
                return v;
            }
            return null;
        }

        protected internal virtual string ValidatePersistenceName(string persistenceNameFormat, Net.TheVpc.Upa.Persistence.PersistenceNameType defaultType, string absoluteName, Net.TheVpc.Upa.Impl.Persistence.UPAObjectAndSpec e, System.Collections.Generic.IList<Net.TheVpc.Upa.Persistence.PersistenceNameType> types) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            //        String varName = "*";
            string confPrefix = "";
            //UPA.CONNECTION_STRING+".";
            string persistenceNamePattern = null;
            Net.TheVpc.Upa.Properties parameters = GetPersistenceUnit().GetProperties();
            if (absoluteName != null) {
                persistenceNamePattern = GetParamValue(confPrefix, defaultType, absoluteName, parameters);
            }
            if (persistenceNamePattern == null) {
                foreach (Net.TheVpc.Upa.Persistence.PersistenceNameType t in types) {
                    persistenceNamePattern = GetParamValue(confPrefix, t, absoluteName, parameters);
                    if (persistenceNamePattern != null) {
                        break;
                    }
                }
            }
            bool noPatternDefined = true;
            if (persistenceNamePattern == null) {
                persistenceNamePattern = GetParamValue(confPrefix, "PERSISTENCE_NAME", parameters);
            }
            if (persistenceNamePattern != null) {
                persistenceNamePattern = persistenceNamePattern.Trim();
                if ((persistenceNamePattern).Length > 0) {
                    noPatternDefined = false;
                    persistenceNameFormat = ReplacePersistenceName(persistenceNamePattern, persistenceNameFormat);
                }
            }
            if (defaultType.IsGlobal()) {
                persistenceNamePattern = GetParamValue(confPrefix, "GLOBAL_PERSISTENCE_NAME", parameters);
            } else {
                persistenceNamePattern = GetParamValue(confPrefix, "LOCAL_PERSISTENCE_NAME", parameters);
            }
            if (persistenceNamePattern != null) {
                persistenceNamePattern = persistenceNamePattern.Trim();
                if ((persistenceNamePattern).Length > 0) {
                    noPatternDefined = false;
                    persistenceNameFormat = ReplacePersistenceName(persistenceNamePattern, persistenceNameFormat);
                }
            }
            if (noPatternDefined) {
                //use default pattern...
                persistenceNameFormat = ReplacePersistenceName("*", persistenceNameFormat);
            }
            if (GetPersistenceStore().IsReservedKeyword(persistenceNameFormat)) {
                if (escapedNamePattern == null) {
                    escapedNamePattern = GetParamValue(confPrefix, "PERSISTENCE_NAME_ESCAPE", parameters);
                    if (escapedNamePattern == null) {
                        escapedNamePattern = "";
                    }
                    escapedNamePattern = escapedNamePattern.Trim();
                    if ((escapedNamePattern).Length > 0) {
                        if (!escapedNamePattern.Contains("*")) {
                            escapedNamePattern = escapedNamePattern + "*";
                        }
                    }
                }
                if ((escapedNamePattern).Length > 0) {
                    persistenceNameFormat = ReplacePersistenceName(escapedNamePattern, persistenceNameFormat);
                }
            }
            return persistenceNameFormat;
        }

        protected internal static string ReplacePersistenceName(string pattern, string objectName) {
            int i = pattern.IndexOf('*');
            if (i >= 0) {
                pattern = pattern.Replace("*", "{OBJECT_NAME}");
            }
            i = pattern.IndexOf('{');
            if (i >= 0) {
                int j = pattern.IndexOf('}', i + 1);
                if (j > 0) {
                    string t = pattern.Substring(i + 1, j);
                    if ("".Equals(t)) {
                        return pattern.Replace("{}", objectName);
                    } else if ("OBJECTNAME".Equals(t)) {
                        return pattern.Replace("{OBJECTNAME}", objectName.ToUpper());
                    } else if ("objectname".Equals(t)) {
                        return pattern.Replace("{objectname}", objectName.ToLower());
                    } else if ("objectName".Equals(t)) {
                        System.Text.StringBuilder s = new System.Text.StringBuilder();
                        bool wasSpace = false;
                        char[] chars = objectName.ToCharArray();
                        bool someLow = false;
                        bool someUp = false;
                        foreach (char c in chars) {
                            if (char.IsLetter(c)) {
                                if (char.IsLower(c)) {
                                    someLow = true;
                                }
                                if (char.IsUpper(c)) {
                                    someUp = true;
                                }
                            }
                        }
                        if (someLow && someUp) {
                            foreach (char c in chars) {
                                if ((s).Length == 0) {
                                    //first
                                    s.Append(char.ToLower(c));
                                } else {
                                    s.Append(c);
                                }
                            }
                        } else {
                            foreach (char c in chars) {
                                if ((s).Length == 0) {
                                    //first
                                    s.Append(char.ToLower(c));
                                } else if (wasSpace) {
                                    if (c == '_') {
                                        wasSpace = true;
                                        s.Append('_');
                                    } else {
                                        wasSpace = false;
                                        s.Append(char.ToUpper(c));
                                    }
                                } else {
                                    s.Append(char.ToLower(c));
                                }
                            }
                        }
                        return pattern.Replace("{objectName}", s.ToString());
                    } else if ("ObjectName".Equals(t)) {
                        System.Text.StringBuilder s = new System.Text.StringBuilder();
                        bool wasSpace = false;
                        char[] chars = objectName.ToCharArray();
                        bool someLow = false;
                        bool someUp = false;
                        foreach (char c in chars) {
                            if (char.IsLetter(c)) {
                                if (char.IsLower(c)) {
                                    someLow = true;
                                }
                                if (char.IsUpper(c)) {
                                    someUp = true;
                                }
                            }
                        }
                        if (someLow && someUp) {
                            foreach (char c in chars) {
                                if ((s).Length == 0) {
                                    //first
                                    s.Append(char.ToUpper(c));
                                } else {
                                    s.Append(c);
                                }
                            }
                        } else {
                            foreach (char c in chars) {
                                if ((s).Length == 0) {
                                    //first
                                    s.Append(char.ToUpper(c));
                                } else if (wasSpace) {
                                    if (c == '_') {
                                        wasSpace = true;
                                        s.Append('_');
                                    } else {
                                        wasSpace = false;
                                        s.Append(char.ToUpper(c));
                                    }
                                } else {
                                    s.Append(char.ToLower(c));
                                }
                            }
                        }
                        return pattern.Replace("{ObjectName}", s.ToString());
                    } else if ("object_name".Equals(t)) {
                        System.Text.StringBuilder s = new System.Text.StringBuilder();
                        char[] chars = objectName.ToCharArray();
                        bool someLow = false;
                        bool someUp = false;
                        foreach (char c in chars) {
                            if (char.IsLetter(c)) {
                                if (char.IsLower(c)) {
                                    someLow = true;
                                }
                                if (char.IsUpper(c)) {
                                    someUp = true;
                                }
                            }
                        }
                        if (!someLow || !someUp) {
                            foreach (char c in chars) {
                                s.Append(char.ToLower(c));
                            }
                        } else {
                            bool wasUpper = false;
                            foreach (char c in chars) {
                                if ((s).Length == 0) {
                                    //first
                                    s.Append(char.ToLower(c));
                                } else if (!wasUpper && char.IsUpper(c)) {
                                    s.Append('_');
                                    s.Append(char.ToLower(c));
                                } else {
                                    s.Append(char.ToLower(c));
                                }
                                wasUpper = char.IsLetter(c) && char.IsUpper(c);
                            }
                        }
                        return pattern.Replace("{object_name}", s.ToString());
                    } else if ("OBJECT_NAME".Equals(t)) {
                        System.Text.StringBuilder s = new System.Text.StringBuilder();
                        char[] chars = objectName.ToCharArray();
                        bool someLow = false;
                        bool someUp = false;
                        foreach (char c in chars) {
                            if (char.IsLetter(c)) {
                                if (char.IsLower(c)) {
                                    someLow = true;
                                }
                                if (char.IsUpper(c)) {
                                    someUp = true;
                                }
                            }
                        }
                        if (!someLow || !someUp) {
                            foreach (char c in chars) {
                                s.Append(char.ToUpper(c));
                            }
                        } else {
                            bool wasLower = false;
                            foreach (char c in chars) {
                                if ((s).Length == 0) {
                                    //first
                                    s.Append(char.ToUpper(c));
                                } else if (wasLower && char.IsUpper(c)) {
                                    s.Append('_');
                                    s.Append(char.ToUpper(c));
                                } else {
                                    s.Append(char.ToUpper(c));
                                }
                                wasLower = char.IsLetter(c) && char.IsLower(c);
                            }
                        }
                        return pattern.Replace("{OBJECT_NAME}", s.ToString());
                    } else {
                        throw new System.ArgumentException ("Unsupported format. User one of objectName,ObjectName,objectname,OBJECTNAME,object_name,OBJECT_NAME");
                    }
                }
            } else {
                throw new System.ArgumentException ("Unsupported format. User one of *,{},{objectName},{ObjectName},{objectname},{OBJECTNAME},{object_name},{OBJECT_NAME} patterns");
            }
            return objectName;
        }

        public virtual Net.TheVpc.Upa.Persistence.PersistenceStore GetPersistenceStore() {
            return persistenceStore;
        }

        public virtual void SetPersistenceStore(Net.TheVpc.Upa.Persistence.PersistenceStore persistenceStore) {
            this.persistenceStore = persistenceStore;
        }

        public virtual Net.TheVpc.Upa.PersistenceUnit GetPersistenceUnit() {
            return persistenceUnit;
        }

        public virtual void SetPersistenceUnit(Net.TheVpc.Upa.PersistenceUnit persistenceUnit) {
            this.persistenceUnit = persistenceUnit;
        }
    }
}
