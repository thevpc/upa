package net.thevpc.upa.impl.config.annotationparser;

import net.thevpc.upa.*;
import net.thevpc.upa.Formula;
import net.thevpc.upa.NamedFormula;
import net.thevpc.upa.Property;
import net.thevpc.upa.Sequence;
import net.thevpc.upa.config.*;
import net.thevpc.upa.config.Field;
import net.thevpc.upa.config.Index;
import net.thevpc.upa.config.Temporal;
import net.thevpc.upa.types.*;

import net.thevpc.upa.config.*;
import net.thevpc.upa.config.Properties;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.exceptions.IllegalUPAArgumentException;
import net.thevpc.upa.impl.SerializableOrManyToOneType;
import net.thevpc.upa.impl.config.decorations.DecorationRepository;
import net.thevpc.upa.impl.util.PlatformUtils;
import net.thevpc.upa.impl.util.StringUtils;
import net.thevpc.upa.impl.util.UPAUtils;
import net.thevpc.upa.types.*;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.text.ParseException;
import java.util.*;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 11/15/12 11:50 AM
 */
class DecorationFieldDescriptor implements FieldDescriptor {

    protected static Logger log = Logger.getLogger(DecorationFieldDescriptor.class.getName());
    private Comparator<java.lang.reflect.Field> FIELD_COMPARATOR;
    String name;
    List<java.lang.reflect.Field> fields = new ArrayList<java.lang.reflect.Field>();
    //    net.thevpc.upa.Field entityField;
    RelationshipInfo foreignInfo;
    DecorationEntityDescriptor entityInfo = null;
    String fieldPath = null;
    Integer fieldPathPosition = null;
    Object defaultObject = null;
    Object unspecifiedObject = null;
    AnyFormulaInfo anyFormula;
    DataType dataType;
    //    DataType targetType;
    //    Formula formula;
    Formula persistFormula;
    Formula updateFormula;
    Formula selectFormula;
    int persistFormulaOrder;
    int updateFormulaOrder;
    int selectFormulaOrder;
    FlagSet<UserFieldModifier> modifiers;
    FlagSet<UserFieldModifier> excludeModifiers;
    AccessLevel persistAccessLevel;
    AccessLevel updateAccessLevel;
    AccessLevel readAccessLevel;
    ProtectionLevel persistProtectionLevel;
    ProtectionLevel updateProtectionLevel;
    ProtectionLevel readProtectionLevel;
    boolean valid = true;
    boolean buildForeign = false;
    OverriddenValue<DataType> overriddenDataType = new OverriddenValue<DataType>();
    //    OverriddenValue<DataType> overriddenTargetType = new OverriddenValue<DataType>();
    OverriddenValue<DataTypeTransformConfig[]> overriddenTransform = new OverriddenValue<DataTypeTransformConfig[]>();
    OverriddenValue<SearchOperator> overriddenSearchOperator = new OverriddenValue<SearchOperator>();
    OverriddenValue<Object> overriddenDefaultValue = new OverriddenValue<Object>();
    OverriddenValue<String> overriddenDefaultValueStr = new OverriddenValue<String>();
    OverriddenValue<Object> overriddenUnspecifiedValue = new OverriddenValue<Object>();
    OverriddenValue<String> overriddenUnspecifiedValueStr = new OverriddenValue<String>();
    OverriddenValue<Formula> overriddenPersistFormula = new OverriddenValue<Formula>();
    OverriddenValue<Formula> overriddenUpdateFormula = new OverriddenValue<Formula>();
    OverriddenValue<Class> overriddenNativeType = new OverriddenValue<Class>();
    OverriddenValue<String> overriddenMinValue = new OverriddenValue<String>();
    OverriddenValue<String> overriddenMaxValue = new OverriddenValue<String>();
    OverriddenValue<String> overriddenLayout = new OverriddenValue<String>();
    OverriddenValue<Integer> overriddenScale = new OverriddenValue<Integer>();
    OverriddenValue<Integer> overriddenPrec = new OverriddenValue<Integer>();
    OverriddenValue<BoolEnum> overriddenNullable = new OverriddenValue<BoolEnum>();
    OverriddenValue<Integer> overriddenPosition = new OverriddenValue<Integer>();
    OverriddenValue<String> overriddenCharsAccepted = new OverriddenValue<String>();
    OverriddenValue<String> overriddenCharsRejected = new OverriddenValue<String>();
    OverriddenValue<String> overriddenFormat = new OverriddenValue<String>();
    OverriddenValue<String> overriddenPath = new OverriddenValue<String>();
    OverriddenValue<Integer> overriddenPathPosition = new OverriddenValue<Integer>();
    OverriddenValue<PropertyAccessType> overriddenPropertyAccessType = new OverriddenValue<PropertyAccessType>();
//    OverriddenValue<BoolEnum> overriddenEnd = new OverriddenValue<BoolEnum>();

    OverriddenValue<TemporalOption> overriddenTemporal = new OverriddenValue<TemporalOption>();
    OverriddenValue<AccessLevel> overriddenPersistAccessLevel = new OverriddenValue<AccessLevel>();
    OverriddenValue<AccessLevel> overriddenUpdateAccessLevel = new OverriddenValue<AccessLevel>();
    OverriddenValue<AccessLevel> overriddenReadAccessLevel = new OverriddenValue<AccessLevel>();
    OverriddenValue<ProtectionLevel> overriddenPersistProtectionLevel = new OverriddenValue<ProtectionLevel>();
    OverriddenValue<ProtectionLevel> overriddenUpdateProtectionLevel = new OverriddenValue<ProtectionLevel>();
    OverriddenValue<ProtectionLevel> overriddenReadProtectionLevel = new OverriddenValue<ProtectionLevel>();
    List<Property> parameterInfos = new ArrayList<Property>();
    private Class nativeClass;
    boolean nullableOk = true;
    DecorationRepository repo;
    private Map<String, Object> fieldParams = new LinkedHashMap<String, Object>();

    DecorationFieldDescriptor(String name, DecorationEntityDescriptor entityInfo, DecorationRepository repo) {
        this.name = name;
        this.entityInfo = entityInfo;
        this.repo = repo;
        foreignInfo = new RelationshipInfo(this, repo);
        anyFormula = new AnyFormulaInfo(repo);
        FIELD_COMPARATOR = new FieldComparator(repo);
    }

    public Map<String, Object> getFieldParams() {
        return fieldParams;
    }

    public void prepareFieldDesc(Map<String, Object> ctx, String entityName, java.lang.reflect.Field javaField) throws UPAException, ParseException, IllegalAccessException, InstantiationException {
        try {
            javaField.setAccessible(true);
            FieldDesc fieldDesc = null;
            if (PlatformUtils.isStatic(javaField)) {
                fieldDesc = (FieldDesc) javaField.get(null);
            } else {
                Object fieldDescContainerInstance = ctx.get("FieldDescContainerInstance." + javaField.getDeclaringClass().getName());
                if (fieldDescContainerInstance == null) {
                    try {
                        fieldDescContainerInstance = PlatformUtils.newInstance(javaField.getDeclaringClass());
                    } catch (Exception e) {
                        throw new IllegalUPAArgumentException(e);
                    }
                    ctx.put("FieldDescContainerInstance" + javaField.getDeclaringClass().getName(), fieldDescContainerInstance);
                }
                //pbm
                try {
                    fieldDesc = (FieldDesc) javaField.get(fieldDescContainerInstance);
                } catch (Exception e) {
                    throw new IllegalUPAArgumentException(e);
                }
            }
            if (fieldDesc != null) {
                int processOrder = fieldDesc.getConfigOrder();
                if (fieldDesc.isDefaultValueSet()) {
                    overriddenDefaultValue.setBetterValue(fieldDesc.getDefaultValue(), processOrder);
                }
                if (fieldDesc.isUnspecifiedValueSet()) {
                    overriddenUnspecifiedValue.setBetterValue(fieldDesc.getUnspecifiedValue(), processOrder);
                }

                //                                Object n = dd.getFieldUnitName();
//                                if (n != null) {
//                                    fieldUnitName = (n);
//                                }
                DataType type = fieldDesc.getDataType();
                if (type != null) {
                    overriddenDataType.setBetterValue(type, processOrder);
                }
                Formula _formula = fieldDesc.getPersistFormula();
                if (_formula != null) {
                    overriddenPersistFormula.setBetterValue(_formula, processOrder);
                }
                _formula = fieldDesc.getUpdateFormula();
                if (_formula != null) {
                    overriddenUpdateFormula.setBetterValue(_formula, processOrder);
                }
                if (fieldDesc.getModifiers() != null) {
                    modifiers.addAll(fieldDesc.getModifiers());
                }
                if (fieldDesc.getExcludeModifiers() != null) {
                    excludeModifiers.addAll(fieldDesc.getExcludeModifiers());
                }
                if (fieldDesc.isUnspecifiedValueSet()) {
                    overriddenUnspecifiedValue.setBetterValue(fieldDesc.getUnspecifiedValue(), processOrder);
                }
            }
        } catch (IllegalAccessException e) {
            throw new IllegalUPAArgumentException(e);
        }
    }

    public void prepareBaseDataType(Map<String, Object> ctx, String entityName) throws UPAException, ParseException, IllegalAccessException, InstantiationException {
        boolean fieldTypeProcessed = false;
        String absoluteName = name;
        if (nativeClass.isEnum()) {
            overriddenDataType.setValue(new EnumType(nativeClass, nullableOk));
            fieldTypeProcessed = true;
        } else if (nativeClass.equals(String.class)) {
            fieldTypeProcessed = true;
            int minInt = AnnotationParserUtils.parseInt(overriddenMinValue, 0);
            int maxInt = AnnotationParserUtils.parseInt(overriddenMaxValue, 255);
            String charsAcceptedOk = (overriddenCharsAccepted.specified && overriddenCharsAccepted.value != null && overriddenCharsAccepted.value.length() > 0) ? overriddenCharsAccepted.value : null;
            String charsRejectedOk = (overriddenCharsRejected.specified && overriddenCharsRejected.value != null && overriddenCharsRejected.value.length() > 0) ? overriddenCharsRejected.value : null;
            StringType s = new StringType(name, minInt, maxInt, nullableOk);
            if (charsAcceptedOk != null) {
                s.addValueValidator(new StringTypeCharValidator(charsAcceptedOk, true));
            }
            if (charsRejectedOk != null) {
                s.addValueValidator(new StringTypeCharValidator(charsRejectedOk, false));
            }
            overriddenDataType.setValue(s);

        } else if (PlatformUtils.isInt32(nativeClass)) {
            fieldTypeProcessed = true;
            Integer min = AnnotationParserUtils.parseInt(overriddenMinValue, null);
            Integer max = AnnotationParserUtils.parseInt(overriddenMaxValue, null);
            overriddenDataType.setValue(new IntType(absoluteName, min, max, nullableOk, PlatformUtils.isPrimitiveType(nativeClass)));
        } else if (PlatformUtils.isInt8(nativeClass)) {
            fieldTypeProcessed = true;
            Byte min = AnnotationParserUtils.parseByte(overriddenMinValue, null);
            Byte max = AnnotationParserUtils.parseByte(overriddenMaxValue, null);
            overriddenDataType.setValue(new ByteType(absoluteName, min, max, nullableOk, PlatformUtils.isPrimitiveType(nativeClass)));
        } else if (PlatformUtils.isInt16(nativeClass)) {
            fieldTypeProcessed = true;
            Short min = AnnotationParserUtils.parseShort(overriddenMinValue, null);
            Short max = AnnotationParserUtils.parseShort(overriddenMaxValue, null);
            overriddenDataType.setValue(new ShortType(absoluteName, min, max, nullableOk, PlatformUtils.isPrimitiveType(nativeClass)));
        } else if (PlatformUtils.isInt64(nativeClass)) {
            fieldTypeProcessed = true;
            Long min = AnnotationParserUtils.parseLong(overriddenMinValue, null);
            Long max = AnnotationParserUtils.parseLong(overriddenMaxValue, null);
            overriddenDataType.setValue(new LongType(absoluteName, min, max, nullableOk, PlatformUtils.isPrimitiveType(nativeClass)));
        } else if (PlatformUtils.isFloat32(nativeClass)) {
            fieldTypeProcessed = true;
            Float min = AnnotationParserUtils.parseFloat(overriddenMinValue, null);
            Float max = AnnotationParserUtils.parseFloat(overriddenMaxValue, null);

            int precOk = Integer.MAX_VALUE;
            if (overriddenPrec.specified && overriddenPrec.value > 0) {
                precOk = overriddenPrec.value.intValue();
            }

            int scaleOk = Integer.MAX_VALUE;
            if (overriddenScale.specified && overriddenScale.value > 0) {
                scaleOk = overriddenScale.value.intValue();
            }
            overriddenDataType.setValue(new FloatType(absoluteName, min, max, scaleOk, precOk, nullableOk, PlatformUtils.isPrimitiveType(nativeClass)));
        } else if (PlatformUtils.isFloat64(nativeClass)) {
            fieldTypeProcessed = true;
            Double min = AnnotationParserUtils.parseDouble(overriddenMinValue, null);
            Double max = AnnotationParserUtils.parseDouble(overriddenMaxValue, null);
            int precOk = Integer.MAX_VALUE;
            if (overriddenPrec.specified && overriddenPrec.value > 0) {
                precOk = overriddenPrec.value;
            }
            int scaleOk = Integer.MAX_VALUE;
            if (overriddenScale.specified && overriddenScale.value > 0) {
                scaleOk = overriddenScale.value.intValue();
            }
            overriddenDataType.setValue(new DoubleType(absoluteName, min, max, scaleOk, precOk, nullableOk, PlatformUtils.isPrimitiveType(nativeClass)));
        } else if (PlatformUtils.isAnyDate(nativeClass)) {
            fieldTypeProcessed = true;
            Class asType = nativeClass;
            if (overriddenTemporal.specified) {
                asType = PlatformUtils.toTemporalType(overriddenTemporal.value, asType);
            }
            if (Year.class.isAssignableFrom(asType)) {
                try {
                    overriddenDataType.setValue(new YearType(absoluteName,
                            nativeClass,
                            (Year) AnnotationParserUtils.parseDate(Year.class, overriddenMinValue, overriddenFormat),
                            (Year) AnnotationParserUtils.parseDate(Year.class, overriddenMaxValue, overriddenFormat),
                            nullableOk));
                } catch (ParseException e) {
                    throw new IllegalUPAArgumentException(e);
                }
            } else if (Month.class.isAssignableFrom(asType)) {
                try {
                    overriddenDataType.setValue(new MonthType(absoluteName,
                            nativeClass,
                            (Month) AnnotationParserUtils.parseDate(Month.class, overriddenMinValue, overriddenFormat),
                            (Month) AnnotationParserUtils.parseDate(Month.class, overriddenMaxValue, overriddenFormat),
                            nullableOk));
                } catch (ParseException e) {
                    throw new IllegalUPAArgumentException(e);
                }
            } else if (net.thevpc.upa.types.Date.class.isAssignableFrom(asType)) {
                try {
                    overriddenDataType.setValue(new DateType(absoluteName,
                            nativeClass,
                            (net.thevpc.upa.types.Date) AnnotationParserUtils.parseDate(net.thevpc.upa.types.Date.class, overriddenMinValue, overriddenFormat),
                            (net.thevpc.upa.types.Date) AnnotationParserUtils.parseDate(net.thevpc.upa.types.Date.class, overriddenMaxValue, overriddenFormat),
                            nullableOk));
                } catch (ParseException e) {
                    throw new IllegalUPAArgumentException(e);
                }
            } else if (DateTime.class.isAssignableFrom(asType)) {
                try {
                    overriddenDataType.setValue(new DateTimeType(absoluteName,
                            nativeClass,
                            (DateTime) AnnotationParserUtils.parseDate(DateTime.class, overriddenMinValue, overriddenFormat),
                            (DateTime) AnnotationParserUtils.parseDate(DateTime.class, overriddenMaxValue, overriddenFormat),
                            nullableOk));
                } catch (ParseException e) {
                    throw new IllegalUPAArgumentException(e);
                }
            } else if (Timestamp.class.isAssignableFrom(asType) || java.sql.Timestamp.class.isAssignableFrom(asType)) {
                try {
                    overriddenDataType.setValue(new TimestampType(absoluteName,
                            nativeClass,
                            (Timestamp) AnnotationParserUtils.parseDate(Timestamp.class, overriddenMinValue, overriddenFormat),
                            (Timestamp) AnnotationParserUtils.parseDate(Timestamp.class, overriddenMaxValue, overriddenFormat),
                            nullableOk));
                } catch (ParseException e) {
                    throw new IllegalUPAArgumentException(e);
                }
            } else if (Time.class.isAssignableFrom(asType)) {
                try {
                    overriddenDataType.setValue(new TimeType(absoluteName,
                            nativeClass,
                            (Time) AnnotationParserUtils.parseDate(Time.class, overriddenMinValue, overriddenFormat),
                            (Time) AnnotationParserUtils.parseDate(Time.class, overriddenMaxValue, overriddenFormat),
                            nullableOk));
                } catch (ParseException e) {
                    throw new IllegalUPAArgumentException(e);
                }
            } else if (java.sql.Date.class.isAssignableFrom(asType)) {
                try {
                    overriddenDataType.setValue(new DateType(absoluteName,
                            nativeClass,
                            (net.thevpc.upa.types.Date) AnnotationParserUtils.parseDate(net.thevpc.upa.types.Date.class, overriddenMinValue, overriddenFormat),
                            (net.thevpc.upa.types.Date) AnnotationParserUtils.parseDate(net.thevpc.upa.types.Date.class, overriddenMaxValue, overriddenFormat),
                            nullableOk));
                } catch (ParseException e) {
                    throw new IllegalUPAArgumentException(e);
                }
            } else if (java.sql.Time.class.isAssignableFrom(asType)) {
                try {
                    overriddenDataType.setValue(new TimeType(absoluteName,
                            nativeClass,
                            (Time) AnnotationParserUtils.parseDate(Time.class, overriddenMinValue, overriddenFormat),
                            (Time) AnnotationParserUtils.parseDate(Time.class, overriddenMaxValue, overriddenFormat),
                            nullableOk));
                } catch (ParseException e) {
                    throw new IllegalUPAArgumentException(e);
                }
            } else {
                try {
                    overriddenDataType.setValue(new DateTimeType(absoluteName,
                            nativeClass,
                            (DateTime) AnnotationParserUtils.parseDate(DateTime.class, overriddenMinValue, overriddenFormat),
                            (DateTime) AnnotationParserUtils.parseDate(DateTime.class, overriddenMaxValue, overriddenFormat),
                            nullableOk));
                } catch (ParseException e) {
                    throw new IllegalUPAArgumentException(e);
                }
            }
        } else if (Boolean.TYPE.equals(nativeClass)) {
            fieldTypeProcessed = true;
            overriddenDataType.setValue(new BooleanType(absoluteName, nullableOk, true));
        } else if (Boolean.class.equals(nativeClass)) {
            fieldTypeProcessed = true;
            overriddenDataType.setValue(new BooleanType(absoluteName, nullableOk, false));
        } else if (FileData.class.equals(nativeClass)) {
            fieldTypeProcessed = true;
            ArrayList<String> extensions = new ArrayList<String>();
            if (overriddenFormat.specified && overriddenFormat.value != null && overriddenFormat.value.length() > 0) {
                for (String ext : overriddenFormat.value.split(";")) {
                    extensions.add(ext.trim());
                }
            }
            overriddenDataType.setValue(new FileType(absoluteName, AnnotationParserUtils.parseInt(overriddenMaxValue, Integer.MAX_VALUE), extensions.isEmpty() ? null : extensions.toArray(new String[extensions.size()]), nullableOk));
        } else if (byte[].class.equals(nativeClass)) {
            fieldTypeProcessed = true;
            overriddenDataType.setValue(new ByteArrayType(absoluteName, false, AnnotationParserUtils.parseInt(overriddenMaxValue, Integer.MAX_VALUE), nullableOk));
        } else if (Byte[].class.equals(nativeClass)) {
            fieldTypeProcessed = true;
            overriddenDataType.setValue(new ByteArrayType(absoluteName, true, AnnotationParserUtils.parseInt(overriddenMaxValue, Integer.MAX_VALUE), nullableOk));
        } else if (char[].class.equals(nativeClass)) {
            fieldTypeProcessed = true;
            overriddenDataType.setValue(new CharArrayType(absoluteName, false, AnnotationParserUtils.parseInt(overriddenMaxValue, Integer.MAX_VALUE), nullableOk));
        } else if (Character[].class.equals(nativeClass)) {
            fieldTypeProcessed = true;
            overriddenDataType.setValue(new CharArrayType(absoluteName, true, AnnotationParserUtils.parseInt(overriddenMaxValue, Integer.MAX_VALUE), nullableOk));
//            } else if (ImageData.class.equals(nativeClass)) {
//                int width = -1;
//                int height = -1;
//                if (format.specified && format.value != null && format.value.length() > 0) {
//                    String[] wh = format.value.split("x");
//                    width = AnnotationParserUtils.parseInt(wh[0], 0);
//                    if (width < 0) {
//                        width = -1;
//                    }
//                    height = AnnotationParserUtils.parseInt(wh[0], 0);
//                    if (height < 0) {
//                        height = -1;
//                    }
//                }
//                dataType.setValue(new ImageType(absoluteName, width, height, AnnotationParserUtils.parseInt(maxValue, -1), nullableOk));
        } else {
            // BigDecimal is ignored because not supported in C#
            /**
             * @PortabilityHint(target = "C#",name = "suppress")
             */
            if (nativeClass.equals(BigDecimal.class)) {
                fieldTypeProcessed = true;
                BigDecimal min = AnnotationParserUtils.parseBigDecimal(overriddenMinValue, null);
                BigDecimal max = AnnotationParserUtils.parseBigDecimal(overriddenMaxValue, null);

                int scaleOk = Integer.MAX_VALUE;
                if (overriddenScale.specified && overriddenScale.value > 0) {
                    scaleOk = overriddenScale.value.intValue();
                }
                int precOk = Integer.MAX_VALUE;
                if (overriddenPrec.specified && overriddenPrec.value > 0) {
                    precOk = overriddenPrec.value.intValue();
                }
                overriddenDataType.setValue(new BigDecimalType(absoluteName, min, max, scaleOk, precOk, nullableOk));
            }
            if (!fieldTypeProcessed && PlatformUtils.isBigInt(nativeClass)) {
                fieldTypeProcessed = true;
                BigInteger minBigInteger = AnnotationParserUtils.parseBigInteger(overriddenMinValue, null);
                BigInteger maxBigInteger = AnnotationParserUtils.parseBigInteger(overriddenMaxValue, null);
                overriddenDataType.setValue(new BigIntType(absoluteName, minBigInteger, maxBigInteger, nullableOk));
            }
        }
        if (foreignInfo.isSpecified()) {
            buildForeign = true;
            if (!fieldTypeProcessed) {
                fieldTypeProcessed = true;
            }
            if (foreignInfo.getPreferredDataType() != null) {
                overriddenDataType.setValue(foreignInfo.getPreferredDataType());
            }
        }

        if (!fieldTypeProcessed) {
            fieldTypeProcessed = true;
            if (nativeClass.isArray() || Collection.class.isAssignableFrom(nativeClass)) {
                SerializableType ttype = new SerializableType(name, nativeClass, nullableOk);
                overriddenDataType.setValue(ttype);
            } else {
                SerializableOrManyToOneType ttype = new SerializableOrManyToOneType(name, nativeClass, nullableOk);
                overriddenDataType.setValue(ttype);
            }
        }
    }

    public void prepare(Map<String, Object> ctx, String entityName) throws UPAException, ParseException, IllegalAccessException, InstantiationException {

        modifiers = FlagSets.noneOf(UserFieldModifier.class);
        excludeModifiers = FlagSets.noneOf(UserFieldModifier.class);

        //////////////////////////////////////////////////////
        // Process all fields
        if (fields.size() > 1) {
            Collections.sort(fields, FIELD_COMPARATOR);
        }
        Decoration lastPathDeco = (Decoration) ctx.get("Entity.lastPathDeco");
        for (java.lang.reflect.Field someField : fields) {
            Decoration searchDeco = repo.getFieldDecoration(someField, Search.class);
            if (searchDeco != null) {
                overriddenSearchOperator.setBetterValue(searchDeco.getEnum("op", SearchOperator.class)
                        == SearchOperator.DEFAULT ? PlatformUtils.getUndefinedValue(SearchOperator.class)
                                : searchDeco.getEnum("op", SearchOperator.class), searchDeco.getConfig().getOrder());
            }
            for (Index indexAnn : findIndexAnnotation(someField)) {
                List<String> rr = new ArrayList<String>();
                rr.add(someField.getName());
                rr.addAll(Arrays.asList(indexAnn.fields()));
                entityInfo.addIndex(indexAnn.name(), rr, indexAnn.unique(), indexAnn.config().order());
            }
            Decoration temporalAnn = repo.getFieldDecoration(someField, Temporal.class);
            if (temporalAnn != null && temporalAnn.getConfig().getOrder() != Integer.MIN_VALUE) {
                overriddenTemporal.setBetterValue(temporalAnn.getEnum("value", TemporalOption.class), temporalAnn.getConfig().getOrder());
            }

            for (Decoration decoration : repo.getFieldRepeatableDecorations(someField, net.thevpc.upa.config.Property.class, net.thevpc.upa.config.Properties.class)) {
                parameterInfos.add(UPAUtils.createProperty(decoration));
            }

            Decoration pathDeco = repo.getFieldDecoration(someField, Path.class);
            if (pathDeco != null) {
                AnnotationParserUtils.validStr(pathDeco.getString("value"), overriddenPath, pathDeco.getConfig().getOrder());
                AnnotationParserUtils.validInt(pathDeco.getInt("position"), overriddenPathPosition, Integer.MIN_VALUE, pathDeco.getConfig().getOrder());
                lastPathDeco = pathDeco;
                ctx.put("Entity.lastPathDeco", lastPathDeco);
            } else if (lastPathDeco != null) { // path is transitive on successive fields in the same class!
                AnnotationParserUtils.validStr(lastPathDeco.getString("value"), overriddenPath, lastPathDeco.getConfig().getOrder());
                AnnotationParserUtils.validInt(lastPathDeco.getInt("position"), overriddenPathPosition, Integer.MIN_VALUE, lastPathDeco.getConfig().getOrder());
            }
            if (someField.getType().equals(FieldDesc.class)) {
                prepareFieldDesc(ctx, entityName, someField);
            } else {
                //default configOrder for DAL is 100
                overriddenNativeType.setBetterValue(someField.getType(), 100);
            }
            Decoration fieldDeco = repo.getFieldDecoration(someField, net.thevpc.upa.config.Field.class);
            if (fieldDeco != null) {
                modifiers = modifiers.addAll(Arrays.asList(fieldDeco.getPrimitiveArray("modifiers", UserFieldModifier.class)));
                excludeModifiers = excludeModifiers.addAll(Arrays.asList(fieldDeco.getPrimitiveArray("excludeModifiers", UserFieldModifier.class)));
                int processOrder = fieldDeco.getConfig().getOrder();
                AnnotationParserUtils.validClass(fieldDeco.getType("valueType"), overriddenNativeType, Object.class, processOrder);
                AnnotationParserUtils.validStr(fieldDeco.getString("min"), overriddenMinValue, processOrder);
                AnnotationParserUtils.validStr(fieldDeco.getString("max"), overriddenMaxValue, processOrder);
                AnnotationParserUtils.validStr(fieldDeco.getString("layout"), overriddenLayout, processOrder);
                AnnotationParserUtils.validInt(fieldDeco.getInt("scale"), overriddenScale, -1, processOrder);
                AnnotationParserUtils.validInt(fieldDeco.getInt("precision"), overriddenPrec, -1, processOrder);
                if (fieldDeco.getEnum("nullable", BoolEnum.class) != BoolEnum.DEFAULT) {
                    overriddenNullable.setBetterValue(fieldDeco.getEnum("nullable", BoolEnum.class), processOrder);
                }
                if (fieldDeco.getInt("position") != Integer.MIN_VALUE) {
                    overriddenPosition.setBetterValue(fieldDeco.getInt("position"), processOrder);
                }
//                if (fieldDeco.getEnum("end", BoolEnum.class) != BoolEnum.DEFAULT) {
//                    overriddenEnd.setBetterValue(fieldDeco.getEnum("nullable", BoolEnum.class), processOrder);
//                }
                if (!PlatformUtils.isUndefinedEnumValue(AccessLevel.class, fieldDeco.getEnum("accessLevel", AccessLevel.class))) {
                    AccessLevel accessLevel = fieldDeco.getEnum("accessLevel", AccessLevel.class);
                    overriddenPersistAccessLevel.setBetterValue(accessLevel, processOrder);
                    overriddenUpdateAccessLevel.setBetterValue(accessLevel, processOrder);
                    overriddenReadAccessLevel.setBetterValue(accessLevel, processOrder);
                }
                if (!PlatformUtils.isUndefinedEnumValue(AccessLevel.class, fieldDeco.getEnum("persistAccessLevel", AccessLevel.class))) {
                    overriddenPersistAccessLevel.setBetterValue(fieldDeco.getEnum("persistAccessLevel", AccessLevel.class), processOrder);
                }
                if (!PlatformUtils.isUndefinedEnumValue(AccessLevel.class, fieldDeco.getEnum("updateAccessLevel", AccessLevel.class))) {
                    overriddenUpdateAccessLevel.setBetterValue(fieldDeco.getEnum("updateAccessLevel", AccessLevel.class), processOrder);
                }
                if (!PlatformUtils.isUndefinedEnumValue(AccessLevel.class, fieldDeco.getEnum("readAccessLevel", AccessLevel.class))) {
                    overriddenReadAccessLevel.setBetterValue(fieldDeco.getEnum("readAccessLevel", AccessLevel.class), processOrder);
                }
                if (!PlatformUtils.isUndefinedEnumValue(ProtectionLevel.class, fieldDeco.getEnum("protectionLevel", ProtectionLevel.class))) {
                    ProtectionLevel protectionLevel = fieldDeco.getEnum("protectionLevel", ProtectionLevel.class);
                    overriddenReadProtectionLevel.setBetterValue(protectionLevel, processOrder);
                    overriddenPersistProtectionLevel.setBetterValue(protectionLevel, processOrder);
                    overriddenUpdateProtectionLevel.setBetterValue(protectionLevel, processOrder);
                }
                if (!PlatformUtils.isUndefinedEnumValue(ProtectionLevel.class, fieldDeco.getEnum("persistProtectionLevel", ProtectionLevel.class))) {
                    overriddenPersistProtectionLevel.setBetterValue(fieldDeco.getEnum("persistProtectionLevel", ProtectionLevel.class), processOrder);
                }
                if (!PlatformUtils.isUndefinedEnumValue(ProtectionLevel.class, fieldDeco.getEnum("updateProtectionLevel", ProtectionLevel.class))) {
                    overriddenUpdateProtectionLevel.setBetterValue(fieldDeco.getEnum("updateProtectionLevel", ProtectionLevel.class), processOrder);
                }
                if (!PlatformUtils.isUndefinedEnumValue(ProtectionLevel.class, fieldDeco.getEnum("readProtectionLevel", ProtectionLevel.class))) {
                    overriddenReadProtectionLevel.setBetterValue(fieldDeco.getEnum("readProtectionLevel", ProtectionLevel.class), processOrder);
                }
                AnnotationParserUtils.validStr(fieldDeco.getString("charsAccepted"), overriddenCharsAccepted, processOrder);
                AnnotationParserUtils.validStr(fieldDeco.getString("charsRejected"), overriddenCharsRejected, processOrder);
                AnnotationParserUtils.validStr(fieldDeco.getString("format"), overriddenFormat, processOrder);
                AnnotationParserUtils.validStr(fieldDeco.getString("path"), overriddenPath, processOrder);
                AnnotationParserUtils.validInt(fieldDeco.getInt("position"), overriddenPathPosition, Integer.MIN_VALUE, processOrder);
                AnnotationParserUtils.validStr(fieldDeco.getString("defaultValue"), overriddenDefaultValueStr, processOrder);
                AnnotationParserUtils.validStr(fieldDeco.getString("unspecifiedValue"), overriddenUnspecifiedValueStr, processOrder);
            }
            Decoration mainDeco = repo.getFieldDecoration(someField, Main.class);
            if (mainDeco != null) {
                modifiers = modifiers.add(UserFieldModifier.MAIN);
            }
            Decoration summaryDeco = repo.getFieldDecoration(someField, Summary.class);
            if (summaryDeco != null) {
                modifiers = modifiers.add(UserFieldModifier.SUMMARY);
            }
            Decoration uniqueDeco = repo.getFieldDecoration(someField, Unique.class);
            if (uniqueDeco != null) {
                modifiers = modifiers.add(UserFieldModifier.UNIQUE);
            }
            Decoration annID = repo.getFieldDecoration(someField, Id.class);
            if (annID != null) {
                modifiers = modifiers.add(UserFieldModifier.ID);
            }
            Decoration propertyAccess = repo.getFieldDecoration(someField, PropertyAccess.class);
            if (propertyAccess != null) {
                overriddenPropertyAccessType.setBetterValue(propertyAccess.getEnum("value", PropertyAccessType.class), propertyAccess.getConfig().getOrder());
            } else {
                //check if defined on class
                propertyAccess = repo.getTypeDecoration(someField.getDeclaringClass(), PropertyAccess.class);
                if (propertyAccess != null) {
                    overriddenPropertyAccessType.setBetterValue(propertyAccess.getEnum("value", PropertyAccessType.class), propertyAccess.getConfig().getOrder());
                }
            }
        }
        nativeClass = overriddenNativeType.getValue(fields.get(0).getType());
        for (Property parameterInfo : parameterInfos) {
            fieldParams.put(parameterInfo.getName(), UPAUtils.createValue(parameterInfo));
        }
        if (overriddenNullable.specified && (overriddenNullable.value != BoolEnum.DEFAULT)) {
            nullableOk = overriddenNullable.value.equals(BoolEnum.TRUE);
            if (nullableOk && (!PlatformUtils.isNullableType(nativeClass) || modifiers.contains(UserFieldModifier.ID))) {
                throw new UPAException("NonNullableTypeForcedToNull", entityName + "." + name);
            }
            if (nullableOk && (modifiers.contains(UserFieldModifier.ID))) {
                throw new UPAException("NullableId", entityName + "." + name);
            }
        }
        if (!PlatformUtils.isNullableType(nativeClass) || modifiers.contains(UserFieldModifier.ID)) {
            nullableOk = false;
        }

        anyFormula.parse(fields);

        foreignInfo.parse(fields, nullableOk);

//        boolean endOk = false;
//        if (overriddenEnd.specified && (overriddenEnd.value != BoolEnum.DEFAULT)) {
//            endOk = overriddenEnd.value.equals(BoolEnum.TRUE);
//        }
        if (overriddenNativeType.specified && !overriddenNativeType.value.equals(Object.class)
                && (!overriddenDataType.specified || (overriddenDataType.specified && overriddenNativeType.order > overriddenDataType.order))) {
            prepareBaseDataType(ctx, entityName);
        }
        preparePersistentDataType(ctx, entityName);
        for (Map.Entry<FormulaType, Object> ee : anyFormula.all.entrySet()) {
            prepareFormula(ctx, entityName, ee.getKey(), ee.getValue());
        }
        if (foreignInfo.isSpecified()) {
            if (foreignInfo.getTargetEntity() == null && foreignInfo.getTargetEntityType() == null) {
                throw new UPAException("MissingManyToOneTargetEntity", entityInfo.name + "." + name);
            }
            if (foreignInfo.isProducesRelation()) {
                entityInfo.relations.add(foreignInfo);
            }
        }
        if (overriddenUnspecifiedValue.specified) {
            this.unspecifiedObject = (overriddenUnspecifiedValue.value);
        }
        if (overriddenPath.specified) {
            this.fieldPath = overriddenPath.value;
        }
        if (overriddenPathPosition.specified) {
            this.fieldPathPosition = overriddenPathPosition.value;
        }
//        if (insertFormula.specified) {
//            this.formulaupaField.setFormula(insertFormula.value);
//        }
        if (overriddenDataType.specified) {
            this.dataType = (overriddenDataType.value);
        }
//        if (overriddenTargetType.specified) {
//            this.targetType = (overriddenTargetType.value);
//        }
        if (overriddenPersistAccessLevel.specified && !PlatformUtils.isUndefinedEnumValue(AccessLevel.class, overriddenPersistAccessLevel.value)) {
            this.persistAccessLevel = overriddenPersistAccessLevel.value;
        }
        if (overriddenUpdateAccessLevel.specified && !PlatformUtils.isUndefinedEnumValue(AccessLevel.class, overriddenUpdateAccessLevel.value)) {
            this.updateAccessLevel = overriddenUpdateAccessLevel.value;
        }
        if (overriddenReadAccessLevel.specified && !PlatformUtils.isUndefinedEnumValue(AccessLevel.class, overriddenReadAccessLevel.value)) {
            this.readAccessLevel = overriddenReadAccessLevel.value;
        }
        if (overriddenPersistProtectionLevel.specified && !PlatformUtils.isUndefinedEnumValue(ProtectionLevel.class, overriddenPersistProtectionLevel.value)) {
            this.persistProtectionLevel = overriddenPersistProtectionLevel.value;
        }
        if (overriddenUpdateProtectionLevel.specified && !PlatformUtils.isUndefinedEnumValue(ProtectionLevel.class, overriddenUpdateProtectionLevel.value)) {
            this.updateProtectionLevel = overriddenUpdateProtectionLevel.value;
        }
        if (overriddenReadProtectionLevel.specified && !PlatformUtils.isUndefinedEnumValue(ProtectionLevel.class, overriddenReadProtectionLevel.value)) {
            this.readProtectionLevel = overriddenReadProtectionLevel.value;
        }
//        this.entityField = upaField;
    }

    public void build(Map<String, Object> ctx, String entityName) {
        if (buildForeign) {
            if (UPAUtils.isSimpleFieldType(nativeClass)) {
                int length = foreignInfo.getMappedTo() == null ? 0 : foreignInfo.getMappedTo().length;
                if (length == 1) {
                    DecorationFieldDescriptor f = entityInfo.fieldsMap.get(foreignInfo.getMappedTo()[0]);
                    if (f == null) {
                        throw new IllegalUPAArgumentException("Field " + foreignInfo.getMappedTo()[0] + " not found");
                    }
                    if (!f.foreignInfo.isSpecified()) {
                        if (f.foreignInfo.isManyToOne()) {
                            ManyToOneType manyToOneType = new ManyToOneType(f.name, f.nativeClass, foreignInfo.getTargetEntity(), false, f.nullableOk);
                            f.overriddenDataType.setValue(manyToOneType);
                        } else if (f.foreignInfo.isOneToOne()) {
                            OneToOneType manyToOneType = new OneToOneType(f.name, f.nativeClass, foreignInfo.getTargetEntity(), false, f.nullableOk);
                            f.overriddenDataType.setValue(manyToOneType);
                        } else {
                            throw new IllegalUPAArgumentException(f.name + " has invalid foreign reference");
                        }
                    } else {
                        throw new IllegalUPAArgumentException(f.name + " already mapped by " + name + ". Should not define relations on its own.");
                    }
                } else if (length > 1) {
                    throw new IllegalUPAArgumentException("Illegal mapping for " + name);
                }
            }
        }

        if (!overriddenDataType.specified || overriddenDataType.value == null) {
            StringBuilder err = new StringBuilder();
            err.append("Field Type could not be resolved for field ").append(name).append("(entity ").append(entityName).append(")\n");
            err.append("Scope Fields are ").append(fields).append("\n");
            log.log(Level.WARNING, err.toString());
            valid = false;
            return;
        }

        if (overriddenDefaultValueStr.specified && (!overriddenDefaultValue.specified || overriddenDefaultValueStr.order > overriddenDefaultValue.order)) {
            try {
                overriddenDefaultValue.setBetterValue(AnnotationParserUtils.parseStringValue(overriddenDefaultValueStr.value, overriddenDataType.value, null), overriddenDefaultValue.order);
            } catch (ParseException e) {
                throw new RuntimeException("Unable to parse default value for " + entityName + "." + name, e);
            }
        }
        if (overriddenDefaultValue.specified) {
            this.defaultObject = (overriddenDefaultValue.value);
        }

        if (overriddenUnspecifiedValueStr.specified && (!overriddenUnspecifiedValue.specified || overriddenUnspecifiedValueStr.order > overriddenUnspecifiedValue.order)) {
            try {
                overriddenUnspecifiedValue.setBetterValue(AnnotationParserUtils.parseStringValue(overriddenUnspecifiedValueStr.value, overriddenDataType.value, UnspecifiedValue.DEFAULT), overriddenUnspecifiedValue.order);
            } catch (ParseException e) {
                throw new RuntimeException("Unable to parse unspecified value for " + entityName + "." + name, e);
            }
        }
        if (overriddenDataType.specified) {
            this.dataType = (overriddenDataType.value);
        }
    }

    public void registerField(java.lang.reflect.Field field) {
        fields.add(field);
    }

    public String getName() {
        return name;
    }

    public List<java.lang.reflect.Field> getFields() {
        return fields;
    }

    public RelationshipInfo getForeignInfo() {
        return foreignInfo;
    }

    public DecorationEntityDescriptor getEntityInfo() {
        return entityInfo;
    }

    public String getPath() {
        return fieldPath;
    }

    public Object getDefaultObject() {
        return defaultObject;
    }

    public Object getUnspecifiedObject() {
        return unspecifiedObject;
    }

    public AnyFormulaInfo getAnyFormula() {
        return anyFormula;
    }

    public DataType getDataType() {
        return dataType;
    }

    public Formula getPersistFormula() {
        return persistFormula;
    }

    public Formula getUpdateFormula() {
        return updateFormula;
    }

    public Formula getSelectFormula() {
        return selectFormula;
    }

    public int getPersistFormulaOrder() {
        return persistFormulaOrder;
    }

    public int getUpdateFormulaOrder() {
        return updateFormulaOrder;
    }

    public int getPosition() {
        return overriddenPosition.getValue(0);
    }

    public int getSelectFormulaOrder() {
        return selectFormulaOrder;
    }

    public FlagSet<UserFieldModifier> getModifiers() {
        return modifiers;
    }

    public FlagSet<UserFieldModifier> getExcludeModifiers() {
        return excludeModifiers;
    }

    public AccessLevel getPersistAccessLevel() {
        return persistAccessLevel;
    }

    public AccessLevel getUpdateAccessLevel() {
        return updateAccessLevel;
    }

    public AccessLevel getReadAccessLevel() {
        return readAccessLevel;
    }

    public ProtectionLevel getPersistProtectionLevel() {
        return persistProtectionLevel;
    }

    public ProtectionLevel getUpdateProtectionLevel() {
        return updateProtectionLevel;
    }

    public ProtectionLevel getReadProtectionLevel() {
        return readProtectionLevel;
    }

    public boolean isValid() {
        return valid;
    }

    public boolean isBuildForeign() {
        return buildForeign;
    }

    public Class getNativeClass() {
        return nativeClass;
    }

    public boolean isNullableOk() {
        return nullableOk;
    }

    //    public DataType getTargetType() {
//        return targetType;
//    }
    private List<Index> findIndexAnnotation(java.lang.reflect.Field javaField) {
        List<Index> list = new ArrayList<Index>();
        Index indexAnn = (Index) repo.getFieldDecoration(javaField, Index.class);
        if (indexAnn != null) {
            list.add(indexAnn);
        }
        Indexes indexAnnAll = (Indexes) repo.getFieldDecoration(javaField, Indexes.class);
        if (indexAnnAll != null) {
            for (Index index : indexAnnAll.value()) {
                if (indexAnn != null) {
                    list.add(index);
                }
            }
        }
        return list;
    }

    //    public CipherStrategyType getCipherStrategyType() {
//        if (passwordStrategy.specified) {
//            return passwordStrategy.value.cipherStrategyType();
//        }
//        return null;
//    }
//
//    public String getCipherStrategyImpl() {
//        if (passwordStrategy.specified) {
//            return passwordStrategy.value.customCipherStrategy();
//        }
//        return null;
//    }
//
//    public String getCipherStrategyValue() {
//        if (passwordStrategy.specified) {
//            return (passwordStrategy.value.cipherValue());
//        }
//        return null;
//    }
    public DataTypeTransformConfig[] getTypeTransform() {
        if (overriddenTransform.specified) {
            return overriddenTransform.value;
        }
        return null;
    }

    @Override
    public String toString() {
        return "DecorationFieldDescriptor{" + "name=" + name + ", fields=" + fields + ", type=" + dataType + '}';
    }

    private void prepareFormula(Map<String, Object> ctx, String entityName, FormulaType t, Object o) {

        Formula ff = null;
        int order = 0;
        if (o instanceof FormulaInfo) {
            FormulaInfo formulaInfo = (FormulaInfo) o;
            if (formulaInfo.specified) {
                if (formulaInfo.platformType != null) {
                    try {
                        ff = (Formula) PlatformUtils.newInstance(formulaInfo.platformType);
                    } catch (Exception e) {
                        throw new RuntimeException(e);
                    }
                } else if (formulaInfo.expression != null) {
                    ff = (new ExpressionFormula(formulaInfo.expression));
                } else if (formulaInfo.name != null) {
                    ff = new NamedFormula(formulaInfo.name);
                }
                if (formulaInfo.order != null) {
                    order = formulaInfo.order;
                }
            }
        } else if (o instanceof SequenceInfo) {
            SequenceInfo formulaInfo = (SequenceInfo) o;
            if (formulaInfo.specified) {
                ff = new Sequence(
                        formulaInfo.strategy == null ? SequenceStrategy.AUTO : formulaInfo.strategy,
                        formulaInfo.initialValue == null ? 1 : formulaInfo.initialValue,
                        formulaInfo.allocationSize == null ? 50 : formulaInfo.allocationSize,
                        formulaInfo.name,
                        formulaInfo.group,
                        formulaInfo.format);
            }
        }
        switch (t) {
            case PERSIST: {
                this.persistFormula = ff;
                this.persistFormulaOrder = order;
                break;
            }
            case UPDATE: {
                this.updateFormula = ff;
                this.updateFormulaOrder = order;
                break;
            }
            case LIVE: {
                this.selectFormula = ff;
                this.selectFormulaOrder = order;
                modifiers = modifiers.add(UserFieldModifier.LIVE);
                break;
            }
            case COMPILED: {
                modifiers = modifiers.add(UserFieldModifier.COMPILED);
                this.selectFormula = ff;
                this.selectFormulaOrder = order;
                break;
            }
        }
    }

    private void preparePersistentDataType(Map<String, Object> ctx, String entityName) {
        for (java.lang.reflect.Field javaField : fields) {
            List<DataTypeTransformConfig> transforms = new ArrayList<DataTypeTransformConfig>();
            ConfigInfo ci = null;
            for (Decoration fieldDecoration : repo.getFieldDecorations(javaField)) {
                if (fieldDecoration.getName().equals(Password.class.getName())) {
                    if (ci == null) {
                        ci = fieldDecoration.getConfig();
                    }
                    PasswordTransformConfig p = new PasswordTransformConfig();
                    if (fieldDecoration.getEnum("strategyType", PasswordStrategyType.class) == PasswordStrategyType.CUSTOM) {
                        p.setCipherStrategy(fieldDecoration.getString("customStrategy"));
                    } else {
                        p.setCipherStrategy(fieldDecoration.getEnum("strategyType", PasswordStrategyType.class));
                    }
                    String cipherValue = fieldDecoration.getString("cipherValue");
                    String cipherValueType = fieldDecoration.getString("cipherValueType");
                    String cipherValueFormat = fieldDecoration.getString("cipherValueFormat");
                    Object cypherValueObj = UPAUtils.createValue(cipherValue, cipherValueType, cipherValueFormat);
                    p.setCipherValue(cypherValueObj);
                    transforms.add(p);
                } else if (fieldDecoration.getName().equals(Secret.class.getName())) {
                    if (ci == null) {
                        ci = fieldDecoration.getConfig();
                    }
                    SecretTransformConfig s2 = new SecretTransformConfig();
                    s2.setSecretStrategy(fieldDecoration.getString("algorithm"));
                    s2.setSize(fieldDecoration.getInt("max"));
                    s2.setEncodeKey(fieldDecoration.getString("key"));
                    s2.setDecodeKey(fieldDecoration.getString("reverseKey"));
                    transforms.add(s2);

                } else if (fieldDecoration.getName().equals(ToString.class.getName())) {
                    if (ci == null) {
                        ci = fieldDecoration.getConfig();
                    }
                    StringEncoderTransformConfig s2 = new StringEncoderTransformConfig();
                    StringEncoderType stringStrategyType = fieldDecoration.getEnum("value", StringEncoderType.class);
                    if (stringStrategyType == StringEncoderType.CUSTOM) {
                        s2.setEncoder(fieldDecoration.getString("customTypeName"));
                    } else {
                        if (StringUtils.isNullOrEmpty(fieldDecoration.getString("customTypeName"))) {
                            s2.setEncoder(stringStrategyType);
                        } else if (stringStrategyType == StringEncoderType.DEFAULT) {
                            s2.setEncoder(fieldDecoration.getString("customTypeName"));
                        } else {
                            throw new IllegalUPAArgumentException("Invalid Converter definition : converter defined as custom and " + stringStrategyType);
                        }
                    }
                    transforms.add(s2);
                } else if (fieldDecoration.getName().equals(ToByteArray.class.getName())) {
                    if (ci == null) {
                        ci = fieldDecoration.getConfig();
                    }
                    ByteArrayEncoderTransformConfig s2 = new ByteArrayEncoderTransformConfig();
                    s2.setEncoder(fieldDecoration.getString("value"));
                    transforms.add(s2);
                } else if (fieldDecoration.getName().equals(ToCharArray.class.getName())) {
                    if (ci == null) {
                        ci = fieldDecoration.getConfig();
                    }
                    CharArrayEncoderTransformConfig s2 = new CharArrayEncoderTransformConfig();
                    s2.setEncoder(fieldDecoration.getString("value"));
                    transforms.add(s2);
                } else if (fieldDecoration.getName().equals(Converter.class.getName())) {
                    if (ci == null) {
                        ci = fieldDecoration.getConfig();
                    }
                    String type = fieldDecoration.getString("valueType");
                    String expression = fieldDecoration.getString("expression");
                    if (type.length() > 0 && expression.length() > 0) {
                        throw new IllegalUPAArgumentException("Invalid Converter definition : both type and expression are mentioned");
                    } else if (type.length() == 0 && expression.length() == 0) {
                        throw new IllegalUPAArgumentException("Invalid Converter definition : none of type and expression are mentioned");
                    } else if (type.length() > 0) {
                        CustomTypeDataTypeTransform s2 = new CustomTypeDataTypeTransform(type);
                        transforms.add(s2);
                    } else {
                        CustomExpressionDataTypeTransform s2 = new CustomExpressionDataTypeTransform(type);
                        transforms.add(s2);
                    }
                }
            }
            if (ci != null) {
                overriddenTransform.setBetterValue(transforms.toArray(new DataTypeTransformConfig[transforms.size()]), ci.getOrder());
            }
        }
    }

    public PropertyAccessType getPropertyAccessType() {
        return overriddenPropertyAccessType.getValue(null);
    }

    @Override
    public int getPathPosition() {
        return this.fieldPathPosition==null?Integer.MIN_VALUE:fieldPathPosition.intValue();
    }

    @Override
    public boolean isIgnoreExisting() {
        return false;
    }

    
}
