package net.vpc.upa.impl.util;

import net.vpc.upa.Closeable;
import net.vpc.upa.*;
import net.vpc.upa.Package;
import net.vpc.upa.config.ScanSource;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.Cst;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.Literal;
import net.vpc.upa.impl.config.BaseScanSource;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.persistence.QueryExecutor;
import net.vpc.upa.impl.transform.DataTypeTransformList;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.impl.transform.PasswordDataTypeTransform;
import net.vpc.upa.impl.uql.compiledexpression.*;
import net.vpc.upa.impl.util.eq.ByteArrayEq;
import net.vpc.upa.impl.util.eq.EqualHelper;
import net.vpc.upa.impl.util.stringvalueparser.*;
import net.vpc.upa.persistence.ResultField;
import net.vpc.upa.types.*;

import java.io.*;
import java.math.BigDecimal;
import java.math.BigInteger;
import java.util.*;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/26/12 2:12 AM
 */
public class UPAUtils {
    public static boolean PRODUCTION_MODE=true;

    public static final Object[] UNDEFINED_ARRAY = new Object[0];
    protected static Logger log = Logger.getLogger(UPAUtils.class.getName());
    public static final HashSet<Class> simpleFieldTypes = new HashSet<Class>();
    public static final HashMap<Class, EqualHelper> equalsHelpers = new HashMap<Class, EqualHelper>();
    public static final HashMap<String, Class> namedTypes = new HashMap<String, Class>();
    public static final HashMap<Class, StringValueParser> typeToParser = new HashMap<Class, StringValueParser>();
    public static final String CONTENT_PROP_PRE_ADD = "before-add";
    public static final String CONTENT_PROP_POST_ADD = "add";
    public static final String CONTENT_PROP_PRE_REMOVE = "before-remove";
    public static final String CONTENT_PROP_POST_REMOVE = "remove";
    public static final String CONTENT_PROP_PRE_MOVE = "before-move";
    public static final String CONTENT_PROP_POST_MOVE = "move";
    public static final Set<String> CONTENT_PROPS_SET = new HashSet<String>(Arrays.asList(
            CONTENT_PROP_PRE_ADD, CONTENT_PROP_POST_ADD,
            CONTENT_PROP_PRE_MOVE, CONTENT_PROP_POST_MOVE,
            CONTENT_PROP_PRE_REMOVE, CONTENT_PROP_POST_REMOVE
    ));

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
    static {
        simpleFieldTypes.add(String.class);
        simpleFieldTypes.add(Integer.class);
        simpleFieldTypes.add(Integer.TYPE);
        simpleFieldTypes.add(Byte.class);
        simpleFieldTypes.add(Byte.TYPE);
        simpleFieldTypes.add(Short.class);
        simpleFieldTypes.add(Short.TYPE);
        simpleFieldTypes.add(Character.class);
        simpleFieldTypes.add(Character.TYPE);
        simpleFieldTypes.add(Long.class);
        simpleFieldTypes.add(Long.TYPE);
        simpleFieldTypes.add(Double.class);
        simpleFieldTypes.add(Double.TYPE);
        simpleFieldTypes.add(Float.class);
        simpleFieldTypes.add(Float.TYPE);
        simpleFieldTypes.add(BigInteger.class);
        simpleFieldTypes.add(BigDecimal.class);
        simpleFieldTypes.add(byte[].class);
        simpleFieldTypes.add(char[].class);
        simpleFieldTypes.add(Byte[].class);
        simpleFieldTypes.add(Character[].class);
        simpleFieldTypes.add(FileData.class);
        simpleFieldTypes.add(Character[].class);
        simpleFieldTypes.add(java.util.Date.class);
        simpleFieldTypes.add(java.sql.Date.class);
        simpleFieldTypes.add(java.sql.Time.class);
        simpleFieldTypes.add(java.sql.Timestamp.class);
        simpleFieldTypes.add(net.vpc.upa.types.Year.class);
        simpleFieldTypes.add(net.vpc.upa.types.Month.class);
        simpleFieldTypes.add(net.vpc.upa.types.Date.class);
        simpleFieldTypes.add(net.vpc.upa.types.DateTime.class);
        simpleFieldTypes.add(net.vpc.upa.types.Time.class);
        simpleFieldTypes.add(net.vpc.upa.types.Timestamp.class);
        simpleFieldTypes.add(net.vpc.upa.types.DatePeriod.class);

        addTypeParser(new StringValueParserBoolean(), Boolean.class, Boolean.TYPE);
        addTypeParser(new StringValueParserInt(), Integer.class, Integer.TYPE);
        addTypeParser(new StringValueParserLong(), Long.class, Long.TYPE);
        addTypeParser(new StringValueParserFloat(), Float.class, Float.TYPE);
        addTypeParser(new StringValueParserDouble(), Double.class, Double.TYPE);
        addTypeParser(new StringValueParserString(), String.class);
        addTypeParser(new StringValueParserUtilDate(), java.util.Date.class);
        addTypeParser(new StringValueParserVpcDate(), net.vpc.upa.types.Date.class);
        addTypeParser(new StringValueParserVpcDateTime(), net.vpc.upa.types.DateTime.class);
        addTypeParser(new StringValueParserVpcTimestamp(), net.vpc.upa.types.Timestamp.class);
        addTypeParser(new StringValueParserVpcTime(), net.vpc.upa.types.Time.class);
        addTypeParser(new StringValueParserVpcMonth(), net.vpc.upa.types.Month.class);
        addTypeParser(new StringValueParserVpcYear(), net.vpc.upa.types.Year.class);

        addNamedType(Boolean.class, "bool", "boolean");
        addNamedType(String.class, "", "string");
        addNamedType(Integer.class, "int", "integer");
        addNamedType(Long.class, "long");
        addNamedType(Double.class, "double");
        addNamedType(Float.class, "float");
        addNamedType(net.vpc.upa.types.Date.class, "date","dateOnly");
        addNamedType(net.vpc.upa.types.Time.class, "timeOnly","time");
        addNamedType(net.vpc.upa.types.Month.class, "monthOnly","month");
        addNamedType(net.vpc.upa.types.Year.class, "yearOnly","year");
        addNamedType(net.vpc.upa.types.DateTime.class, "dateTime");
        addNamedType(net.vpc.upa.types.Timestamp.class, "TimeStamp");

        //java only
        {
            addNamedType(java.util.Date.class, "utilDate");
            addNamedType(java.sql.Date.class, "sqlDate");
            addNamedType(java.sql.Time.class, "sqlTime");
            addNamedType(java.sql.Timestamp.class, "sqlTimestamp");
            addTypeParser(new StringValueParserSqlDate(), java.sql.Date.class);
            addTypeParser(new StringValueParserSqlTime(), java.sql.Time.class);
            addTypeParser(new StringValueParserSqlTimestamp(), java.sql.Timestamp.class);
        }


        equalsHelpers.put(byte[].class, ByteArrayEq.INSTANCE);
    }

    private static void addTypeParser(StringValueParser parser, Class... cls) {
        for (Class cl : cls) {
            typeToParser.put(cl, parser);
        }

    }

    private static void addNamedType(Class cls, String... names) {
        for (String name : names) {
            if (name == null) {
                name = "";
            }
            name = name.trim().toLowerCase();
            namedTypes.put(name, cls);
        }
        namedTypes.put(cls.getName().toLowerCase(), cls);
    }

    private static Class getNamedType(String name) {
        if (name == null) {
            name = "";
        }
        name = name.trim().toLowerCase();
        return namedTypes.get(name);
    }

    public static boolean isSimpleFieldType(Class clazz) {
        return simpleFieldTypes.contains(clazz);
    }

    public static String[] getPathArray(String s) {
        if (s == null) {
            s = "";
        }
        s = s.trim();
        List<String> path = new ArrayList<String>();
        String[] all = s.split("/");
        for (String s1 : all) {
            if (s1.length() > 0) {
                path.add(s1);
            }
        }
        if (path.size() == 0) {
            return null;
        }
        return path.toArray(new String[path.size()]);
    }

    public static String[] getCanonicalPathArray(String[] pathItem) {
        List<String> path = new ArrayList<String>();
        if (pathItem != null) {
            for (String v : pathItem) {
                String t = v.trim();
                if (t.equals(".")) {
                    //do nothing
                } else if (t.equals("..")) {
                    if (path.size() > 0) {
                        path.remove(path.size() - 1);
                    } else {
                        path.add(t);
                    }
                } else {
                    path.add(t);
                }
            }
        }
        return path.toArray(new String[path.size()]);
    }

    public static String[] getCanonicalPathArray(String path) {
        return getCanonicalPathArray(getPathArray(path));
    }

    public static String getCanonicalPath(String[] pathItem, boolean absolute) {
        String[] path = getCanonicalPathArray(pathItem);
        if (path.length == 0) {
            if (absolute) {
                return "/";
            } else {
                return ".";
            }
        } else {
            StringBuilder b = new StringBuilder();
            boolean first = true;
            for (String s : path) {
                if (absolute || !first) {
                    b.append("/");
                }
                b.append(s);
                first = false;
            }
            return b.toString();
        }
    }

    public static String getCanonicalPath(String path, boolean absolute) {
        return getCanonicalPath(getCanonicalPathArray(getPathArray(path)), absolute);
    }

    public static boolean equals(Object o1, Object o2) {
        if (o1 == o2) {
            return true;
        }
        if (o1 == null || o2 == null) {
            return false;
        }
        if (!o1.getClass().isArray()) {
            return o1.equals(o2);
        }
        Class clz = o1.getClass().getComponentType();
        if (clz.isPrimitive()) {
            Class clz2 = o2.getClass().getComponentType();
            if (clz.equals(clz2)) {
                EqualHelper h = equalsHelpers.get(clz);
                if (h != null) {
                    return h.equals(o1, o2);
                }
            }
            throw new IllegalArgumentException("could not compare primitive arrays");
            //return false;
        }
        Object[] o1arr = (Object[]) o1;
        Object[] o2arr = (Object[]) o2;
        if (o1arr.length != o2arr.length) {
            return false;
        } else {
            Collection<Object> o1coll = Arrays.asList(o1arr);
            Collection<Object> o2coll = Arrays.asList(o2arr);
            return o1coll.equals(o2coll);
        }
    }

    @PortabilityHint(target = "C#", name = "suppress")
    public static String getStackTrace(Throwable t) {
        ByteArrayOutputStream b = new ByteArrayOutputStream();
        PrintStream ps = new PrintStream(b);
        t.printStackTrace(ps);
        return b.toString();
    }

    public static int[] maxIndexes(Object[][] values, boolean[] ascendent) {
        /**
         * if values = {{8,5,6},{3,6,9},{8,5,7},{8,4,9},{8,5,7}} and
         * ascendant={true,true,true} max={2,4} which are indexes 2 and 4
         */
        ArrayList<Integer> indexes = new ArrayList<Integer>(values.length);
        for (int i = 0; i < values.length; i++) {
            indexes.add(i);
        }

        Object[] max = UNDEFINED_ARRAY;
        int max_index = ascendent.length;
        if (max_index == 0) {
            return null;
        }
        for (int indexToTest = 0; indexToTest < max_index; indexToTest++) {
//            System.out.println("max = " + ((max==UNDEFINED_NEW)?"UNDEFINED_NEW" : Arrays.asList(max).toString()));
//            System.out.println("indexes = " + indexes);
            int max_indexes = indexes.size();
            ArrayList<Integer> newIndexes = new ArrayList<Integer>(max_indexes);
            for (Object idx : indexes) {
                int i = (Integer) idx;
                if (max == UNDEFINED_ARRAY) {
                    max = values[i];
                    newIndexes.clear();
                    newIndexes.add(i);
                } else {
                    if (values[i] != UNDEFINED_ARRAY) {
                        if (max == null) {
                            max = values[i];
                            newIndexes.clear();
                            newIndexes.add(i);
                        } else {
                            int comp = compare(values[i][indexToTest], max[indexToTest]);
                            if ((comp > 0 && ascendent[indexToTest]) || (comp < 0 && !ascendent[indexToTest])) {
                                max = values[i];
                                newIndexes.clear();
                                newIndexes.add(i);
                            } else if (comp == 0) {
                                newIndexes.add(i);
                            }
                        }
                    }
                }
            }
//            System.out.println("newIndexes = " + newIndexes);
            if (newIndexes.isEmpty()) {
                return null;
            } else if (newIndexes.size() == 1) {
                return new int[]{((Integer) newIndexes.get(0)).intValue()};
            } else if (indexToTest >= values.length - 1) {
                indexes = newIndexes;
                break;
            }
            indexes = newIndexes;
        }
        int[] ret = new int[indexes.size()];
        for (int i = 0; i < ret.length; i++) {
            ret[i] = ((Integer) indexes.get(i)).intValue();
        }
        return ret;
    }

    public static int compare(Object o1, Object o2) {
        if (o1 == o2) {
            return 0;
        }
        if (o1 == null) {
            return -1;
        }
        if (o2 == null) {
            return 1;
        }
        return ((Comparable<Object>) o1).compareTo(o2);
    }

    public static <K, V> Map<K, V> fill(Map<K, V> hash, Object... ks) {
        for (int i = 0; i < ks.length; i += 2) {
            hash.put((K) ks[i], (V) ks[i + 1]);
        }
        return hash;
    }

    public static <V> Map<String, V> extractMap(Map<String, V> base, Set<String> keys) {
        Map<String, V> ret = new HashMap<String, V>();
        for (Map.Entry<String, V> entry : base.entrySet()) {
            String k = entry.getKey();
            if (keys.contains(k)) {
                ret.put(k, entry.getValue());
            }
        }
        return ret;
    }

    public static <V> Map<String, V> extractMap(Map<String, V> base, String prefix, boolean trimPrefix) {
        Map<String, V> ret = new HashMap<String, V>();
        String prefix1 = prefix + ".";
        for (Map.Entry<String, V> entry : base.entrySet()) {
            String k = entry.getKey();
            if (k.equals(prefix)) {
                if (trimPrefix) {
                    ret.put("", entry.getValue());
                } else {
                    ret.put(k, entry.getValue());
                }
            } else {
                if (k.startsWith(prefix1)) {
                    if (trimPrefix) {
                        ret.put(k.substring(prefix1.length()), entry.getValue());
                    } else {
                        ret.put(k, entry.getValue());
                    }
                }
            }
        }
        return ret;
    }

    public static void close(Object o) {
        if (o instanceof Closeable) {
            try {
                ((net.vpc.upa.Closeable) o).close();
            } catch (Exception ex) {
                throw new UPAException(ex, new I18NString("CloseFailedException"), o);
            }
        }
    }

    public static DefaultBeanAdapter prepare(PersistenceUnit persistenceUnit, UPAObject item, String name) {
        return prepare(persistenceUnit, null, item, name);
    }

    public static DefaultBeanAdapter prepare(PersistenceUnit persistenceUnit, Entity entity, UPAObject item, String name) {
        DefaultBeanAdapter adapter = preparePreAdd(persistenceUnit, entity, item, name);
        preparePostAdd(persistenceUnit, item);
        return adapter;
    }

    public static DefaultBeanAdapter preparePreAdd(PersistenceUnit persistenceUnit, Entity entity, UPAObject item, String name) {
        DefaultBeanAdapter adapter = new DefaultBeanAdapter(item);
        adapter.setProperty("persistenceUnit", persistenceUnit);
        item.setName(name);
        adapter.setProperty("persistenceState", PersistenceState.DIRTY);

        if (item instanceof EntityPart) {
            adapter.setProperty("entity", entity);
        }

        return adapter;
    }

    public static void preparePostAdd(PersistenceUnit persistenceUnit, UPAObject item) {
//        DefaultBeanAdapter adapter = new DefaultBeanAdapter(item);
        I18NStringStrategy strategy = persistenceUnit.getI18NStringStrategy();
        I18NString s = null;
        I18NString t = null;
        I18NString d = null;
        if (item instanceof Package) {
            s = strategy.getPackageString(((Package) item));
            t = s.append("title");
            d = s.append("desc");
        } else if (item instanceof Relationship) {
            s = strategy.getRelationshipString((Relationship) item);
            t = s.append("title");
            d = s.append("desc");
        } else if (item instanceof Entity) {
            s = strategy.getEntityString((Entity) item);
            t = s.append("title");
            d = s.append("desc");
        } else if (item instanceof Section) {
            s = strategy.getSectionString(((Section) item).getEntity(), item.getName());
            t = s.append("title");
            d = s.append("desc");
        } else if (item instanceof Field) {
            s = strategy.getFieldString((Field) item);
            t = s.append("title");
            d = s.append("desc");
        } else if (item instanceof RelationshipRole) {
            RelationshipRole r = (RelationshipRole) item;
            s = strategy.getRelationshipRoleString(r);
            t = s.append("title");
            d = (s.append("desc").union(r.getEntity().getDescription()));
        }
        item.setI18NString(s);
        item.setTitle(t);
        item.setDescription(d);
    }

    public static Set<String> loadLinesSet(String name) {
        HashSet<String> set = new HashSet<String>();
        if (name != null) {
            InputStream inputStream = null;
            BufferedReader r = null;
            try {
                try {
                    inputStream = PlatformUtils.loadResourceAsStream(name);
                    r = new BufferedReader(new InputStreamReader(inputStream));
                    String line = null;
                    while ((line = r.readLine()) != null) {
                        line = line.trim();
                        if (line.startsWith("#")) {
                            line = "";
                        }
                        if (line.length() > 0) {
                            set.add(line);
                        }
                    }
                } finally {
                    if (r != null) {
                        r.close();
                    } else if (inputStream != null) {
                        inputStream.close();
                    }
                }
            } catch (Exception e) {
                log.log(Level.SEVERE, "Unable to load resource, ignore", e);
            }
        }
        return set;
    }

    public static boolean isSimpleDataType(DataType dataType) {
        return !(dataType instanceof ManyToOneType);
    }

    public static DataTypeTransform resolveDataTypeTransform(CompiledExpressionExt e) {
        return resolveExprTypeInfo(e).getTypeTransform();
    }

    public static ExprTypeInfo resolveExprTypeInfo(CompiledExpressionExt e) {
        return resolveExprTypeInfo(e, true);
    }

    public static ExprTypeInfo resolveExprTypeInfo(CompiledExpressionExt e, boolean byBrother) {
        if (e instanceof CompiledVarOrMethod) {
            e = ((CompiledVarOrMethod) e).getDeepest();
            final Object r = ((CompiledVarOrMethod) e).getReferrer();
            if (r instanceof Field) {
                DataTypeTransform tr = getTypeTransformOrIdentity(((Field) r));
                ExprTypeInfo i = new ExprTypeInfo();
                i.setReferrer(r);
                i.setTransform(tr);
                return i;
            }
        }
        if (e instanceof CompiledVarVal) {
            CompiledVarOrMethod v = ((CompiledVarVal) e).getVar();
            return resolveExprTypeInfo(v);
        }
        DataTypeTransform typeTransform = e.getTypeTransform();
        if(typeTransform==null){
            throw new NullPointerException("Unexpected Null typeTransform for "+e);
        }
        if (e instanceof CompiledParam || e instanceof CompiledLiteral) {
            CompiledExpressionExt p = e.getParentExpression();
            if (p instanceof CompiledVarVal) {
                return resolveExprTypeInfo(p);
            } else {
                Object object = (e instanceof CompiledParam) ? ((CompiledParam) e).getValue() : ((CompiledLiteral) e).getValue();
                DataType sourceType = typeTransform.getSourceType();
                DataTypeTransform bestType = typeTransform;
                if (
                        (p instanceof CompiledBinaryOperatorExpression)
                                && (((CompiledBinaryOperatorExpression) p).isSameOperandsType())
                        ) {
                    CompiledExpressionExt o = ((CompiledBinaryOperatorExpression) p).getOther(e);
                    if (byBrother) {
                        return resolveExprTypeInfo(o, false);
                    }
                }
                if (object != null
                        //too generic
                        && (
                        typeTransform.equals(IdentityDataTypeTransform.OBJECT)
                                //or specified type is not accurate
                                || !sourceType.isInstance(object))
                        ) {

                    bestType = IdentityDataTypeTransform.ofType(object.getClass());
                }
                ExprTypeInfo typeInfo1 = new ExprTypeInfo();
                typeInfo1.setTransform(bestType);
                return typeInfo1;
            }
        }
        ExprTypeInfo typeInfo2 = new ExprTypeInfo();
        typeInfo2.setTransform(typeTransform);
        return typeInfo2;

    }

    public static Object createValue(Property info) {
        String ptype = info.getTypeName();
        String format = info.getFormat();
        String value = info.getValue();
        return createValue(value, ptype, format);
    }

    public static Object createValue(String value, Class type, String format) {
        if (value == null) {
            return null;
        }
        if (type == null) {
            throw new IllegalArgumentException("Null Parameter type ");
        }

        StringValueParser p = typeToParser.get(type);
        if (p == null) {
            throw new IllegalArgumentException("Unsupported Parameter type " + type);
        }
        return p.parse(value, format);
    }

    public static Object createValue(String value, String ptype, String format) {
        if (value == null) {
            return null;
        }
        if (StringUtils.isNullOrEmpty(ptype)) {
            ptype = "string";
        }

        Class type = getNamedType(ptype);
        if (type == null) {
            throw new IllegalArgumentException("Unsupported Parameter type " + ptype);
        }
        return createValue(value, type, format);
    }

    public static BaseScanSource toConfigurationStrategy(ScanSource source) {
        if (source == null) {
            throw new IllegalArgumentException("ScanSource could not be null; you may use UPAContext.getFactory().create*ScanSource(...) methods to get a valid instance.");
        }
        if (!(source instanceof BaseScanSource)) {
            throw new IllegalArgumentException("ScanSource (" + source.getClass() + ") is of invalid or unsupported type; you may use UPAContext.getFactory().create*ScanSource(...) methods to get a valid instance.");
        }
        return (BaseScanSource) source;
    }

    public static PasswordDataTypeTransform findPasswordTransform(DataTypeTransform t) {
        if (t instanceof IdentityDataTypeTransform) {
            return null;
        }
        if (t instanceof PasswordDataTypeTransform) {
            return (PasswordDataTypeTransform) t;
        }
        if (t instanceof DataTypeTransformList) {
            for (DataTypeTransform x : ((DataTypeTransformList) t)) {
                PasswordDataTypeTransform v = findPasswordTransform(x);
                if (v != null) {
                    return v;
                }
            }
        }
        return null;
    }

    public static boolean isPasswordTransform(DataTypeTransform t) {
        if (t == null) {
            return false;
        }
        if (t instanceof IdentityDataTypeTransform) {
            return false;
        }
        if (t instanceof PasswordDataTypeTransform) {
            return true;
        }
        if (t instanceof DataTypeTransformList) {
            for (DataTypeTransform x : ((DataTypeTransformList) t)) {
                if (isPasswordTransform(x)) {
                    return true;
                }
            }
        }
        return false;
    }

    public static DataTypeTransform getTypeTransformOrIdentity(net.vpc.upa.Field f) {
        DataTypeTransform t = f.getTypeTransform();
        if (t == null) {
            return IdentityDataTypeTransform.ofType(f.getDataType());
        }
        return t;
    }

    public static String dotConcat(String... all) {
        StringBuilder sb = new StringBuilder();
        for (String s : all) {
            if (!StringUtils.isNullOrEmpty(s)) {
                if (sb.length() > 0) {
                    sb.append(".");
                }
                sb.append(s);
            }
        }
        return sb.toString();
    }

    public static String getValidBinding(ResultField s) {
        if (StringUtils.isNullOrEmpty(s.getAlias())) {
            Expression ss = s.getExpression();
            return ss == null ? "" : ss.toString();
        }
        return s.getAlias();
    }

    public static Object unwrapLiteral(Object o) {
        if (o instanceof Literal) {
            return ((Literal) o).getValue();
        }
        if (o instanceof Cst) {
            return ((Cst) o).getValue();
        }
        return o;
    }

    public static XNumber toNumberOrError(Object o) {
        if (o == null) {
            return null;
        }
        if (o instanceof String) {
            return new XNumber(Double.valueOf((String) o));
        }
        if (o instanceof Number) {
            return new XNumber((Number) o);
        }
        throw new RuntimeException("Not a number " + o);
    }

    public static XNumber toNumber(Object o) {
        if (o == null) {
            return new XNumber(0);
        }
        if (o instanceof String) {
            return new XNumber(Double.valueOf((String) o));
        }
        if (o instanceof Number) {
            return new XNumber((Number) o);
        }
        return null;
    }

    public static void setQueryExecutorParams(QueryExecutor lastQueryExecutor,Map<Integer, Object> parametersByIndex,Map<String, Object> parametersByName){
        if(parametersByIndex!=null) {
            for (Map.Entry<Integer, Object> ee : parametersByIndex.entrySet()) {
                lastQueryExecutor.setParam(ee.getKey(), ee.getValue());
            }
        }
        if(parametersByName!=null) {
            for (Map.Entry<String, Object> ee : parametersByName.entrySet()) {
                lastQueryExecutor.setParam(ee.getKey(), ee.getValue());
            }
        }

    }

    public static <T> List<T> sortPreserveIndex(List<T> list, final Comparator<T> comp) {
        SortPreserveIndexIndexedItem<T>[] items = new SortPreserveIndexIndexedItem[list.size()];
        for (int i = 0; i < items.length; i++) {
            items[i] = new SortPreserveIndexIndexedItem<>(list.get(i), i,comp);
        }
        Arrays.sort(items);
        for (int i = 0; i < items.length; i++) {
            list.set(i, items[i].item);
        }
        return list;
    }
    public static <T> T[] sortPreserveIndex(T[] list, final Comparator<T> comp) {
        SortPreserveIndexIndexedItem<T>[] items = new SortPreserveIndexIndexedItem[list.length];
        for (int i = 0; i < items.length; i++) {
            items[i] = new SortPreserveIndexIndexedItem<>(list[i], i,comp);
        }
        Arrays.sort(items);
        for (int i = 0; i < items.length; i++) {
            list[i]=items[i].item;
        }
        return list;
    }
    public static <T> SortPreserveIndexIndexedItem<T>[] sortPreserveIndex0(T[] list, final Comparator<T> comp) {
        SortPreserveIndexIndexedItem<T>[] items = new SortPreserveIndexIndexedItem[list.length];
        for (int i = 0; i < items.length; i++) {
            items[i] = new SortPreserveIndexIndexedItem<>(list[i], i,comp);
        }
        Arrays.sort(items);
        return items;
    }

    public static String formatLeft(String number,int size){
        StringBuilder sb=new StringBuilder();
        sb.append(number);
        while (sb.length()<size){
            sb.append(' ');
        }
        return sb.toString();
    }

    public static int convertToInt(Object value,int nullValue){
        if(value==null){
            value=nullValue;
        }else if(value instanceof Number && !(value instanceof Integer)){
            value=((Number) value).intValue();
        }else if(value instanceof String){
            value=Integer.parseInt((String) value);
        }
        return ((Integer)value).intValue();
    }

    public static long convertToLong(Object value,long nullValue){
        if(value==null){
            value=nullValue;
        }else if(value instanceof Number && !(value instanceof Long)){
            value=((Long) value).longValue();
        }else if(value instanceof String){
            value=Long.parseLong((String) value);
        }
        return ((Long)value).longValue();
    }
}
