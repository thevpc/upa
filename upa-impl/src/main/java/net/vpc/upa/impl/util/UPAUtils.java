package net.vpc.upa.impl.util;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.types.I18NString;
import net.vpc.upa.*;
import net.vpc.upa.Closeable;
import net.vpc.upa.Field;
import net.vpc.upa.Package;
import net.vpc.upa.exceptions.UPAException;

import java.io.*;
import java.math.BigDecimal;
import java.math.BigInteger;
import java.net.URL;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.*;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.vpc.upa.Property;
import net.vpc.upa.config.ScanSource;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.impl.config.BaseScanSource;
import net.vpc.upa.impl.persistence.DefaultPersistenceStore;
import net.vpc.upa.impl.transform.DataTypeTransformList;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.impl.transform.PasswordDataTypeTransform;
import net.vpc.upa.impl.uql.compiledexpression.CompiledBinaryOperatorExpression;
import net.vpc.upa.impl.uql.compiledexpression.CompiledDifferent;
import net.vpc.upa.impl.uql.compiledexpression.CompiledEquals;
import net.vpc.upa.impl.uql.compiledexpression.CompiledLiteral;
import net.vpc.upa.impl.uql.compiledexpression.CompiledParam;
import net.vpc.upa.impl.uql.compiledexpression.CompiledVar;
import net.vpc.upa.impl.uql.compiledexpression.CompiledVarOrMethod;
import net.vpc.upa.impl.uql.compiledexpression.CompiledVarVal;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;
import net.vpc.upa.impl.util.eq.ByteArrayEq;
import net.vpc.upa.impl.util.eq.EqualHelper;
import net.vpc.upa.types.DataType;
import net.vpc.upa.types.DataTypeTransform;
import net.vpc.upa.types.EntityType;
import net.vpc.upa.types.FileData;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/26/12 2:12 AM
 */
public class UPAUtils {

    public static final Object[] UNDEFINED_ARRAY = new Object[0];
    protected static Logger log = Logger.getLogger(UPAUtils.class.getName());
    public static final HashSet<Class> simpleFieldTypes = new HashSet<Class>();
    public static final HashMap<Class, EqualHelper> equalsHelpers = new HashMap<Class, EqualHelper>();
    public static final HashMap<String, Class> namedTypes = new HashMap<String, Class>();
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

        namedTypes.put("bool", Boolean.class);
        namedTypes.put("boolean", Boolean.class);
        namedTypes.put("java.lang.Boolean", Boolean.class);
        namedTypes.put("string", String.class);
        namedTypes.put("String", String.class);
        namedTypes.put("java.lang.String", String.class);
        namedTypes.put("", String.class);
        namedTypes.put(null, String.class);

        namedTypes.put("int", Integer.class);
        namedTypes.put("Integer", Integer.class);
        namedTypes.put("java.lang.Integer", Integer.class);

        namedTypes.put("long", Long.class);
        namedTypes.put("Long", Long.class);
        namedTypes.put("java.lang.Long", Long.class);

        namedTypes.put("double", Double.class);
        namedTypes.put("Double", Double.class);
        namedTypes.put("java.lang.Double", Double.class);

        namedTypes.put("date", java.util.Date.class);
        namedTypes.put("Date", java.util.Date.class);
        namedTypes.put("java.util.Date", java.util.Date.class);

        equalsHelpers.put(byte[].class, ByteArrayEq.INSTANCE);
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
         * ascendent={true,true,true} max={2,4} which are indexes 2 and 4
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

    public static InputStream loadResourceAsStream(String resourcePath) throws IOException {
        /**
         * @PortabilityHint(target="C#",name="replace") return
         * System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(resourcePath);
         */
        {
            ClassLoader contextClassLoader = Thread.currentThread().getContextClassLoader();
            URL resource = contextClassLoader.getResource(resourcePath);
            if (resource == null) {
                resource = UPAUtils.class.getResource(resourcePath);
            }
            return resource.openStream();
        }
    }

    public static Set<String> loadLinesSet(String name) {
        HashSet<String> set = new HashSet<String>();
        if (name != null) {
            InputStream inputStream = null;
            BufferedReader r = null;
            try {
                try {
                    inputStream = UPAUtils.loadResourceAsStream(name);
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
        return !(dataType instanceof EntityType);
    }

    public static DataTypeTransform resolveDataTypeTransform(DefaultCompiledExpression e) {
        return resolveExprTypeInfo(e).getTypeTransform();
    }

    public static ExprTypeInfo resolveExprTypeInfo(DefaultCompiledExpression e) {
        return resolveExprTypeInfo(e, true);
    }

    public static ExprTypeInfo resolveExprTypeInfo(DefaultCompiledExpression e, boolean byBrother) {
        if (e instanceof CompiledVarOrMethod) {
            e = ((CompiledVarOrMethod) e).getFinest();
            final Object r = ((CompiledVarOrMethod) e).getReferrer();
            if (r instanceof Field) {
                DataTypeTransform tr = getTypeTransformOrIdentity(((Field) r));
                ExprTypeInfo i = new ExprTypeInfo();
                i.setReferrer(r);
                i.setTransform(tr);
                if (e instanceof CompiledVar) {
                    CompiledVar cv = (CompiledVar) e;
                    i.setOldReferrer(cv.getOldReferrer());
                }
                return i;
            }
        }
        if (e instanceof CompiledVarVal) {
            CompiledVarOrMethod v = ((CompiledVarVal) e).getVar();
            return resolveExprTypeInfo(v);
        }
        if (e instanceof CompiledLiteral) {
            if (byBrother) {
                DefaultCompiledExpression p = e.getParentExpression();
                if ((p instanceof CompiledEquals) || (p instanceof CompiledDifferent)) {
                    DefaultCompiledExpression o = ((CompiledBinaryOperatorExpression) p).getOther(e);
                    return resolveExprTypeInfo(o, false);
                }
            } else {
                ExprTypeInfo ii = new ExprTypeInfo();
                ii.setTransform(e.getTypeTransform());
                return ii;
            }
        }
        if (e instanceof CompiledParam) {
            DefaultCompiledExpression p = e.getParentExpression();
            if (p instanceof CompiledVarVal) {
                return resolveExprTypeInfo(p);
            } else if ((p instanceof CompiledEquals) || (p instanceof CompiledDifferent)) {
                DefaultCompiledExpression o = ((CompiledBinaryOperatorExpression) p).getOther(e);
                if (byBrother) {
                    return resolveExprTypeInfo(o, false);
                } else {
                    ExprTypeInfo ii = new ExprTypeInfo();
                    ii.setTransform(e.getTypeTransform());
                    return ii;
                }
            }
        }
        ExprTypeInfo ii = new ExprTypeInfo();
        ii.setTransform(e.getTypeTransform());
        return ii;

    }

    public static Object createValue(Property info) {
        String ptype = info.getTypeName();
        String format = info.getFormat();
        String value = info.getValue();
        return createValue(value, ptype, format);
    }

    public static Object createValue(String value, String ptype, String format) {
        Class type = namedTypes.get(ptype);
        if (type == null) {
            throw new IllegalArgumentException("Insupported Parameter type " + ptype);
        }
        if (type.equals(String.class)) {
            return value;
        }
        if (type.equals(Boolean.class)) {
            return Boolean.parseBoolean(value);
        }
        if (type.equals(Integer.class)) {
            if (value.trim().length() == 0) {
                return null;
            }
            return Integer.parseInt(value);
        }
        if (type.equals(Integer.TYPE)) {
            return Integer.parseInt(value);
        }
        if (type.equals(Double.class)) {
            if (value.trim().length() == 0) {
                return null;
            }
            return Double.parseDouble(value);
        }
        if (type.equals(Double.TYPE)) {
            return Double.parseDouble(value);
        }
        if (type.equals(Long.class)) {
            if (value.trim().length() == 0) {
                return null;
            }
            return Long.parseLong(value);
        }
        if (type.equals(Long.TYPE)) {
            return Long.parseLong(value);
        }
        if (type.equals(java.util.Date.class)) {
            if (value.trim().length() == 0) {
                return null;
            }
            if (format.length() > 0) {
                try {
                    return new SimpleDateFormat(format).parse(value);
                } catch (ParseException ex) {
                    throw new IllegalArgumentException("Unable to parse date " + value);
                }
            }
            return DateUtils.parseUniversalDate(value);
        }
        throw new IllegalArgumentException("Insupported Parameter type " + type);
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
            return new IdentityDataTypeTransform(f.getDataType());
        }
        return t;
    }

}
