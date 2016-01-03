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



using System.Linq;
namespace Net.Vpc.Upa.Impl.Util
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/26/12 2:12 AM
     */
    public class UPAUtils {

        public static readonly object[] UNDEFINED_ARRAY = new object[0];

        protected internal static System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.Vpc.Upa.Impl.Util.UPAUtils)).FullName);

        public static readonly System.Collections.Generic.HashSet<System.Type> simpleFieldTypes = new System.Collections.Generic.HashSet<System.Type>();

        public static readonly System.Collections.Generic.Dictionary<System.Type , Net.Vpc.Upa.Impl.Util.Eq.EqualHelper> equalsHelpers = new System.Collections.Generic.Dictionary<System.Type , Net.Vpc.Upa.Impl.Util.Eq.EqualHelper>();

        public static readonly System.Collections.Generic.Dictionary<string , System.Type> namedTypes = new System.Collections.Generic.Dictionary<string , System.Type>();

        public const string CONTENT_PROP_PRE_ADD = "before-add";

        public const string CONTENT_PROP_POST_ADD = "add";

        public const string CONTENT_PROP_PRE_REMOVE = "before-remove";

        public const string CONTENT_PROP_POST_REMOVE = "remove";

        public const string CONTENT_PROP_PRE_MOVE = "before-move";

        public const string CONTENT_PROP_POST_MOVE = "move";

        public static readonly System.Collections.Generic.ISet<string> CONTENT_PROPS_SET = new System.Collections.Generic.HashSet<string>(new System.Collections.Generic.List<string>(new[]{CONTENT_PROP_PRE_ADD, CONTENT_PROP_POST_ADD, CONTENT_PROP_PRE_MOVE, CONTENT_PROP_POST_MOVE, CONTENT_PROP_PRE_REMOVE, CONTENT_PROP_POST_REMOVE}));

        /**
             * object.addPropertyChangeListener(UPAUtils.CONTENT_PROP_PRE_ADD,
             * beforeAddHandler);
             * object.addPropertyChangeListener(UPAUtils.CONTENT_PROP_POST_ADD,
             * afterAddHandler); object.addPropertyChangeListener("before-remove",
             * beforeRemoveHandler); object.addPropertyChangeListener("remove",
             * afterRemoveHandler); object.addPropertyChangeListener("before-move",
             * beforeMoveHandler); object.addPropertyChangeListener("move",
             * afterMoveHandler);
             *
             */
        static UPAUtils(){
            simpleFieldTypes.Add(typeof(string));
            simpleFieldTypes.Add(typeof(int?));
            simpleFieldTypes.Add(typeof(int));
            simpleFieldTypes.Add(typeof(byte?));
            simpleFieldTypes.Add(typeof(byte));
            simpleFieldTypes.Add(typeof(short?));
            simpleFieldTypes.Add(typeof(short));
            simpleFieldTypes.Add(typeof(char?));
            simpleFieldTypes.Add(typeof(char));
            simpleFieldTypes.Add(typeof(long?));
            simpleFieldTypes.Add(typeof(long));
            simpleFieldTypes.Add(typeof(double?));
            simpleFieldTypes.Add(typeof(double));
            simpleFieldTypes.Add(typeof(float?));
            simpleFieldTypes.Add(typeof(float));
            simpleFieldTypes.Add(typeof(System.Numerics.BigInteger?));
            simpleFieldTypes.Add(typeof(System.Decimal));
            simpleFieldTypes.Add(typeof(byte[]));
            simpleFieldTypes.Add(typeof(char[]));
            simpleFieldTypes.Add(typeof(byte?[]));
            simpleFieldTypes.Add(typeof(char?[]));
            simpleFieldTypes.Add(typeof(Net.Vpc.Upa.Types.FileData));
            simpleFieldTypes.Add(typeof(char?[]));
            simpleFieldTypes.Add(typeof(Net.Vpc.Upa.Types.Temporal));
            simpleFieldTypes.Add(typeof(Net.Vpc.Upa.Types.Date));
            simpleFieldTypes.Add(typeof(Net.Vpc.Upa.Types.Time));
            simpleFieldTypes.Add(typeof(Net.Vpc.Upa.Types.Timestamp));
            simpleFieldTypes.Add(typeof(Net.Vpc.Upa.Types.Year));
            simpleFieldTypes.Add(typeof(Net.Vpc.Upa.Types.Month));
            simpleFieldTypes.Add(typeof(Net.Vpc.Upa.Types.Date));
            simpleFieldTypes.Add(typeof(Net.Vpc.Upa.Types.DateTime));
            simpleFieldTypes.Add(typeof(Net.Vpc.Upa.Types.Time));
            simpleFieldTypes.Add(typeof(Net.Vpc.Upa.Types.Timestamp));
            simpleFieldTypes.Add(typeof(Net.Vpc.Upa.Types.DatePeriod));
            namedTypes["bool"]=typeof(bool?);
            namedTypes["boolean"]=typeof(bool?);
            namedTypes["java.lang.Boolean"]=typeof(bool?);
            namedTypes["string"]=typeof(string);
            namedTypes["String"]=typeof(string);
            namedTypes["java.lang.String"]=typeof(string);
            namedTypes[""]=typeof(string);
            namedTypes[null]=typeof(string);
            namedTypes["int"]=typeof(int?);
            namedTypes["Integer"]=typeof(int?);
            namedTypes["java.lang.Integer"]=typeof(int?);
            namedTypes["long"]=typeof(long?);
            namedTypes["Long"]=typeof(long?);
            namedTypes["java.lang.Long"]=typeof(long?);
            namedTypes["double"]=typeof(double?);
            namedTypes["Double"]=typeof(double?);
            namedTypes["java.lang.Double"]=typeof(double?);
            namedTypes["date"]=typeof(Net.Vpc.Upa.Types.Temporal);
            namedTypes["Date"]=typeof(Net.Vpc.Upa.Types.Temporal);
            namedTypes["java.util.Date"]=typeof(Net.Vpc.Upa.Types.Temporal);
            equalsHelpers[typeof(byte[])]=Net.Vpc.Upa.Impl.Util.Eq.ByteArrayEq.INSTANCE;
        }

        public static bool IsSimpleFieldType(System.Type clazz) {
            return simpleFieldTypes.Contains(clazz);
        }

        public static string[] GetPathArray(string s) {
            if (s == null) {
                s = "";
            }
            s = s.Trim();
            System.Collections.Generic.IList<string> path = new System.Collections.Generic.List<string>();
            string[] all = System.Text.RegularExpressions.Regex.Split(s,"/");
            foreach (string s1 in all) {
                if ((s1).Length > 0) {
                    path.Add(s1);
                }
            }
            if ((path).Count == 0) {
                return null;
            }
            return path.ToArray();
        }

        public static string[] GetCanonicalPathArray(string[] pathItem) {
            System.Collections.Generic.IList<string> path = new System.Collections.Generic.List<string>();
            if (pathItem != null) {
                foreach (string v in pathItem) {
                    string t = v.Trim();
                    if (t.Equals(".")) {
                    } else if (t.Equals("..")) {
                        if ((path).Count > 0) {
                            path.RemoveAt((path).Count - 1);
                        } else {
                            path.Add(t);
                        }
                    } else {
                        path.Add(t);
                    }
                }
            }
            return path.ToArray();
        }

        public static string[] GetCanonicalPathArray(string path) {
            return GetCanonicalPathArray(GetPathArray(path));
        }

        public static string GetCanonicalPath(string[] pathItem, bool absolute) {
            string[] path = GetCanonicalPathArray(pathItem);
            if (path.Length == 0) {
                if (absolute) {
                    return "/";
                } else {
                    return ".";
                }
            } else {
                System.Text.StringBuilder b = new System.Text.StringBuilder();
                bool first = true;
                foreach (string s in path) {
                    if (absolute || !first) {
                        b.Append("/");
                    }
                    b.Append(s);
                    first = false;
                }
                return b.ToString();
            }
        }

        public static string GetCanonicalPath(string path, bool absolute) {
            return GetCanonicalPath(GetCanonicalPathArray(GetPathArray(path)), absolute);
        }

        public static bool Equals(object o1, object o2) {
            if (o1 == o2) {
                return true;
            }
            if (o1 == null || o2 == null) {
                return false;
            }
            if (!(o1.GetType()).IsArray) {
                return o1.Equals(o2);
            }
            System.Type clz = o1.GetType().GetElementType();
            if ((clz).IsPrimitive) {
                System.Type clz2 = o2.GetType().GetElementType();
                if (clz.Equals(clz2)) {
                    Net.Vpc.Upa.Impl.Util.Eq.EqualHelper h = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,Net.Vpc.Upa.Impl.Util.Eq.EqualHelper>(equalsHelpers,clz);
                    if (h != null) {
                        return h.Equals(o1, o2);
                    }
                }
                throw new System.ArgumentException ("could not compare primitive arrays");
            }
            //return false;
            object[] o1arr = (object[]) o1;
            object[] o2arr = (object[]) o2;
            if (o1arr.Length != o2arr.Length) {
                return false;
            } else {
                System.Collections.Generic.ICollection<object> o1coll = new System.Collections.Generic.List<object>(o1arr);
                System.Collections.Generic.ICollection<object> o2coll = new System.Collections.Generic.List<object>(o2arr);
                return o1coll.Equals(o2coll);
            }
        }



        public static int[] MaxIndexes(object[][] values, bool[] ascendent) {
            /**
                     * if values = {{8,5,6},{3,6,9},{8,5,7},{8,4,9},{8,5,7}} and
                     * ascendent={true,true,true} max={2,4} which are indexes 2 and 4
                     */
            System.Collections.Generic.List<int?> indexes = new System.Collections.Generic.List<int?>(values.Length);
            for (int i = 0; i < values.Length; i++) {
                indexes.Add(i);
            }
            object[] max = UNDEFINED_ARRAY;
            int max_index = ascendent.Length;
            if (max_index == 0) {
                return null;
            }
            for (int indexToTest = 0; indexToTest < max_index; indexToTest++) {
                //            System.out.println("max = " + ((max==UNDEFINED_NEW)?"UNDEFINED_NEW" : Arrays.asList(max).toString()));
                //            System.out.println("indexes = " + indexes);
                int max_indexes = (indexes).Count;
                System.Collections.Generic.List<int?> newIndexes = new System.Collections.Generic.List<int?>(max_indexes);
                foreach (object idx in indexes) {
                    int i = ((int?) idx).Value;
                    if (max == UNDEFINED_ARRAY) {
                        max = values[i];
                        newIndexes.Clear();
                        newIndexes.Add(i);
                    } else {
                        if (values[i] != UNDEFINED_ARRAY) {
                            if (max == null) {
                                max = values[i];
                                newIndexes.Clear();
                                newIndexes.Add(i);
                            } else {
                                int comp = Compare(values[i][indexToTest], max[indexToTest]);
                                if ((comp > 0 && ascendent[indexToTest]) || (comp < 0 && !ascendent[indexToTest])) {
                                    max = values[i];
                                    newIndexes.Clear();
                                    newIndexes.Add(i);
                                } else if (comp == 0) {
                                    newIndexes.Add(i);
                                }
                            }
                        }
                    }
                }
                //            System.out.println("newIndexes = " + newIndexes);
                if ((newIndexes.Count==0)) {
                    return null;
                } else if ((newIndexes).Count == 1) {
                    return new int[] { (((int?) newIndexes[0])).Value };
                } else if (indexToTest >= values.Length - 1) {
                    indexes = newIndexes;
                    break;
                }
                indexes = newIndexes;
            }
            int[] ret = new int[(indexes).Count];
            for (int i = 0; i < ret.Length; i++) {
                ret[i] = (((int?) indexes[i])).Value;
            }
            return ret;
        }

        public static int Compare(object o1, object o2) {
            if (o1 == o2) {
                return 0;
            }
            if (o1 == null) {
                return -1;
            }
            if (o2 == null) {
                return 1;
            }
            return ((System.IComparable<object>) o1).CompareTo(o2);
        }

        public static  System.Collections.Generic.IDictionary<K , V> Fill<K, V>(System.Collections.Generic.IDictionary<K , V> hash, params object [] ks) {
            for (int i = 0; i < ks.Length; i += 2) {
                hash[(K) ks[i]]=(V) ks[i + 1];
            }
            return hash;
        }

        public static void Close(object o) {
            if (o is Net.Vpc.Upa.Closeable) {
                try {
                    ((Net.Vpc.Upa.Closeable) o).Close();
                } catch (System.Exception ex) {
                    throw new Net.Vpc.Upa.Exceptions.UPAException(ex, new Net.Vpc.Upa.Types.I18NString("CloseFailedException"), o);
                }
            }
        }

        public static Net.Vpc.Upa.Impl.Util.DefaultBeanAdapter Prepare(Net.Vpc.Upa.PersistenceUnit persistenceUnit, Net.Vpc.Upa.UPAObject item, string name) {
            return Prepare(persistenceUnit, null, item, name);
        }

        public static Net.Vpc.Upa.Impl.Util.DefaultBeanAdapter Prepare(Net.Vpc.Upa.PersistenceUnit persistenceUnit, Net.Vpc.Upa.Entity entity, Net.Vpc.Upa.UPAObject item, string name) {
            Net.Vpc.Upa.Impl.Util.DefaultBeanAdapter adapter = PreparePreAdd(persistenceUnit, entity, item, name);
            PreparePostAdd(persistenceUnit, item);
            return adapter;
        }

        public static Net.Vpc.Upa.Impl.Util.DefaultBeanAdapter PreparePreAdd(Net.Vpc.Upa.PersistenceUnit persistenceUnit, Net.Vpc.Upa.Entity entity, Net.Vpc.Upa.UPAObject item, string name) {
            Net.Vpc.Upa.Impl.Util.DefaultBeanAdapter adapter = new Net.Vpc.Upa.Impl.Util.DefaultBeanAdapter(item);
            adapter.SetProperty("persistenceUnit", persistenceUnit);
            item.SetName(name);
            adapter.SetProperty("persistenceState", Net.Vpc.Upa.PersistenceState.DIRTY);
            if (item is Net.Vpc.Upa.EntityPart) {
                adapter.SetProperty("entity", entity);
            }
            return adapter;
        }

        public static void PreparePostAdd(Net.Vpc.Upa.PersistenceUnit persistenceUnit, Net.Vpc.Upa.UPAObject item) {
            //        DefaultBeanAdapter adapter = new DefaultBeanAdapter(item);
            Net.Vpc.Upa.I18NStringStrategy strategy = persistenceUnit.GetI18NStringStrategy();
            Net.Vpc.Upa.Types.I18NString s = null;
            Net.Vpc.Upa.Types.I18NString t = null;
            Net.Vpc.Upa.Types.I18NString d = null;
            if (item is Net.Vpc.Upa.Package) {
                s = strategy.GetPackageString(((Net.Vpc.Upa.Package) item));
                t = s.Append("title");
                d = s.Append("desc");
            } else if (item is Net.Vpc.Upa.Relationship) {
                s = strategy.GetRelationshipString((Net.Vpc.Upa.Relationship) item);
                t = s.Append("title");
                d = s.Append("desc");
            } else if (item is Net.Vpc.Upa.Entity) {
                s = strategy.GetEntityString((Net.Vpc.Upa.Entity) item);
                t = s.Append("title");
                d = s.Append("desc");
            } else if (item is Net.Vpc.Upa.Section) {
                s = strategy.GetSectionString(((Net.Vpc.Upa.Section) item).GetEntity(), item.GetName());
                t = s.Append("title");
                d = s.Append("desc");
            } else if (item is Net.Vpc.Upa.Field) {
                s = strategy.GetFieldString((Net.Vpc.Upa.Field) item);
                t = s.Append("title");
                d = s.Append("desc");
            } else if (item is Net.Vpc.Upa.RelationshipRole) {
                Net.Vpc.Upa.RelationshipRole r = (Net.Vpc.Upa.RelationshipRole) item;
                s = strategy.GetRelationshipRoleString(r);
                t = s.Append("title");
                d = (s.Append("desc").Union(r.GetEntity().GetDescription()));
            }
            item.SetI18NString(s);
            item.SetTitle(t);
            item.SetDescription(d);
        }

        public static System.IO.Stream LoadResourceAsStream(string resourcePath) /* throws System.IO.IOException */  {
             return
            System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(resourcePath);
        }

        public static System.Collections.Generic.ISet<string> LoadLinesSet(string name) {
            System.Collections.Generic.HashSet<string> set = new System.Collections.Generic.HashSet<string>();
            if (name != null) {
                System.IO.Stream inputStream = null;
                System.IO.StreamReader r = null;
                try {
                    try {
                        inputStream = Net.Vpc.Upa.Impl.Util.UPAUtils.LoadResourceAsStream(name);
                        r = new System.IO.StreamReader(new System.IO.StreamReader(inputStream));
                        string line = null;
                        while ((line = r.ReadLine()) != null) {
                            line = line.Trim();
                            if (line.StartsWith("#")) {
                                line = "";
                            }
                            if ((line).Length > 0) {
                                set.Add(line);
                            }
                        }
                    } finally {
                        if (r != null) {
                            r.Close();
                        } else if (inputStream != null) {
                            inputStream.Close();
                        }
                    }
                } catch (System.Exception e) {
                    log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Unable to load resource, ignore",e));
                }
            }
            return set;
        }

        public static bool IsSimpleDataType(Net.Vpc.Upa.Types.DataType dataType) {
            return !(dataType is Net.Vpc.Upa.Types.EntityType);
        }

        public static Net.Vpc.Upa.Types.DataTypeTransform ResolveDataTypeTransform(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression e) {
            return ResolveExprTypeInfo(e).GetTypeTransform();
        }

        public static Net.Vpc.Upa.Impl.Util.ExprTypeInfo ResolveExprTypeInfo(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression e) {
            if (e is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarOrMethod) {
                e = ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarOrMethod) e).GetFinest();
                object r = ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarOrMethod) e).GetReferrer();
                if (r is Net.Vpc.Upa.Field) {
                    Net.Vpc.Upa.Types.DataTypeTransform tr = GetTypeTransformOrIdentity(((Net.Vpc.Upa.Field) r));
                    Net.Vpc.Upa.Impl.Util.ExprTypeInfo i = new Net.Vpc.Upa.Impl.Util.ExprTypeInfo();
                    i.SetReferrer(r);
                    i.SetTransform(tr);
                    if (e is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) {
                        Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar cv = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) e;
                        i.SetOldReferrer(cv.GetOldReferrer());
                    }
                    return i;
                }
            }
            if (e is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarVal) {
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarOrMethod v = ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarVal) e).GetVar();
                return ResolveExprTypeInfo(v);
            }
            if (e is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral || e is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledParam) {
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression p = e.GetParentExpression();
                if (p is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarVal) {
                    return ResolveExprTypeInfo(p);
                } else if ((p is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEquals) || (p is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledDifferent)) {
                    Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression o = ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledBinaryOperatorExpression) p).GetOther(e);
                    return ResolveExprTypeInfo(o);
                }
            }
            Net.Vpc.Upa.Impl.Util.ExprTypeInfo ii = new Net.Vpc.Upa.Impl.Util.ExprTypeInfo();
            ii.SetTransform(e.GetTypeTransform());
            return ii;
        }

        public static object CreateValue(Net.Vpc.Upa.Property info) {
            string ptype = info.GetTypeName();
            string format = info.GetFormat();
            string @value = info.GetValue();
            return CreateValue(@value, ptype, format);
        }

        public static object CreateValue(string @value, string ptype, string format) {
            System.Type type = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,System.Type>(namedTypes,ptype);
            if (type == null) {
                throw new System.ArgumentException ("Insupported Parameter type " + ptype);
            }
            if (type.Equals(typeof(string))) {
                return @value;
            }
            if (type.Equals(typeof(bool?))) {
                return System.Convert.ToBoolean(@value);
            }
            if (type.Equals(typeof(int?))) {
                if ((@value.Trim()).Length == 0) {
                    return null;
                }
                return System.Convert.ToInt32(@value);
            }
            if (type.Equals(typeof(int))) {
                return System.Convert.ToInt32(@value);
            }
            if (type.Equals(typeof(double?))) {
                if ((@value.Trim()).Length == 0) {
                    return null;
                }
                return System.Convert.ToDouble(@value);
            }
            if (type.Equals(typeof(double))) {
                return System.Convert.ToDouble(@value);
            }
            if (type.Equals(typeof(long?))) {
                if ((@value.Trim()).Length == 0) {
                    return null;
                }
                return System.Convert.ToInt64(@value);
            }
            if (type.Equals(typeof(long))) {
                return System.Convert.ToInt64(@value);
            }
            if (type.Equals(typeof(Net.Vpc.Upa.Types.Temporal))) {
                if ((@value.Trim()).Length == 0) {
                    return null;
                }
                if ((format).Length > 0) {
                    try {
                        return new Java.Text.SimpleDateFormat(format).Parse(@value);
                    } catch (System.Exception ex) {
                        throw new System.ArgumentException ("Unable to parse date " + @value);
                    }
                }
                return Net.Vpc.Upa.Impl.Util.DateUtils.ParseUniversalDate(@value);
            }
            throw new System.ArgumentException ("Insupported Parameter type " + type);
        }

        public static Net.Vpc.Upa.Impl.Config.BaseScanSource ToConfigurationStrategy(Net.Vpc.Upa.Config.ScanSource source) {
            if (source == null) {
                throw new System.ArgumentException ("ScanSource could not be null; you may use UPAContext.getFactory().create*ScanSource(...) methods to get a valid instance.");
            }
            if (!(source is Net.Vpc.Upa.Impl.Config.BaseScanSource)) {
                throw new System.ArgumentException ("ScanSource (" + source.GetType() + ") is of invalid or unsupported type; you may use UPAContext.getFactory().create*ScanSource(...) methods to get a valid instance.");
            }
            return (Net.Vpc.Upa.Impl.Config.BaseScanSource) source;
        }

        public static Net.Vpc.Upa.Impl.Transform.PasswordDataTypeTransform FindPasswordTransform(Net.Vpc.Upa.Types.DataTypeTransform t) {
            if (t is Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform) {
                return null;
            }
            if (t is Net.Vpc.Upa.Impl.Transform.PasswordDataTypeTransform) {
                return (Net.Vpc.Upa.Impl.Transform.PasswordDataTypeTransform) t;
            }
            if (t is Net.Vpc.Upa.Impl.Transform.DataTypeTransformList) {
                foreach (Net.Vpc.Upa.Types.DataTypeTransform x in ((Net.Vpc.Upa.Impl.Transform.DataTypeTransformList) t)) {
                    Net.Vpc.Upa.Impl.Transform.PasswordDataTypeTransform v = FindPasswordTransform(x);
                    if (v != null) {
                        return v;
                    }
                }
            }
            return null;
        }

        public static bool IsPasswordTransform(Net.Vpc.Upa.Types.DataTypeTransform t) {
            if (t == null) {
                return false;
            }
            if (t is Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform) {
                return false;
            }
            if (t is Net.Vpc.Upa.Impl.Transform.PasswordDataTypeTransform) {
                return true;
            }
            if (t is Net.Vpc.Upa.Impl.Transform.DataTypeTransformList) {
                foreach (Net.Vpc.Upa.Types.DataTypeTransform x in ((Net.Vpc.Upa.Impl.Transform.DataTypeTransformList) t)) {
                    if (IsPasswordTransform(x)) {
                        return true;
                    }
                }
            }
            return false;
        }

        public static Net.Vpc.Upa.Types.DataTypeTransform GetTypeTransformOrIdentity(Net.Vpc.Upa.Field f) {
            Net.Vpc.Upa.Types.DataTypeTransform t = f.GetTypeTransform();
            if (t == null) {
                return new Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform(f.GetDataType());
            }
            return t;
        }
    }
}
