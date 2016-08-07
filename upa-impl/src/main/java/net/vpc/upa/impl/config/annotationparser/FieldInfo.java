package net.vpc.upa.impl.config.annotationparser;

import net.vpc.upa.Property;
import net.vpc.upa.FieldDescriptor;
import net.vpc.upa.*;
import net.vpc.upa.config.BoolEnum;
import net.vpc.upa.config.FieldDesc;
import net.vpc.upa.FormulaType;
import net.vpc.upa.config.Id;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.SerializableOrManyToOneType;
import net.vpc.upa.types.*;

import java.lang.reflect.Field;
import java.math.BigDecimal;
import java.math.BigInteger;
import java.text.ParseException;
import java.util.*;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.vpc.upa.config.StringEncoderType;
import net.vpc.upa.SearchOperator;
import net.vpc.upa.config.ConfigInfo;
import net.vpc.upa.config.Decoration;
import net.vpc.upa.impl.config.decorations.DecorationRepository;
import net.vpc.upa.config.DecorationValue;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.impl.util.UPAUtils;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 11/15/12 11:50 AM
 */
class FieldInfo implements FieldDescriptor {

    protected static Logger log = Logger.getLogger(FieldInfo.class.getName());
    private Comparator<Field> FIELD_COMPARATOR;
    String name;
    List<Field> fields = new ArrayList<Field>();
    //    net.vpc.upa.Field entityField;
    RelationshipInfo foreignInfo;
    EntityInfo entityInfo = null;
    String fieldPath = null;
    Object defaultObject = null;
    Object unspecifiedObject = null;
    AnyFormulaInfo anyFormula;
    DataType type;
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
    OverriddenValue<PropertyAccessType> overriddenPropertyAccessType = new OverriddenValue<PropertyAccessType>();
//    OverriddenValue<BoolEnum> overriddenEnd = new OverriddenValue<BoolEnum>();

    OverriddenValue<TemporalOption> overriddenTemporal = new OverriddenValue<TemporalOption>();
    OverriddenValue<AccessLevel> overriddenPersistAccessLevel = new OverriddenValue<AccessLevel>();
    OverriddenValue<AccessLevel> overriddenUpdateAccessLevel = new OverriddenValue<AccessLevel>();
    OverriddenValue<AccessLevel> overriddenRemoveAccessLevel = new OverriddenValue<AccessLevel>();
    OverriddenValue<AccessLevel> overriddenReadAccessLevel = new OverriddenValue<AccessLevel>();
    List<Property> parameterInfos = new ArrayList<Property>();
    private Class nativeClass;
    boolean nullableOk = true;
    DecorationRepository repo;
    private Map<String, Object> fieldParams = new LinkedHashMap<String, Object>();

    FieldInfo(String name, EntityInfo entityInfo, DecorationRepository repo) {
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

    public void prepareFieldDesc(Map<String, Object> ctx, String entityName, Field javaField) throws UPAException, ParseException, IllegalAccessException, InstantiationException {
        try {
            javaField.setAccessible(true);
            FieldDesc fieldDesc = null;
            if (PlatformUtils.isStatic(javaField)) {
                fieldDesc = (FieldDesc) javaField.get(null);
            } else {
                Object fieldDescContainerInstance = ctx.get("FieldDescContainerInstance." + javaField.getDeclaringClass().getName());
                if (fieldDescContainerInstance == null) {
                    try {
                        fieldDescContainerInstance = (javaField.getDeclaringClass()).newInstance();
                    } catch (Exception e) {
                        throw new IllegalArgumentException(e);
                    }
                    ctx.put("FieldDescContainerInstance" + javaField.getDeclaringClass().getName(), fieldDescContainerInstance);
                }
                //pbm
                try {
                    fieldDesc = (FieldDesc) javaField.get(fieldDescContainerInstance);
                } catch (Exception e) {
                    throw new IllegalArgumentException(e);
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
            throw new IllegalArgumentException(e);
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
                    throw new IllegalArgumentException(e);
                }
            } else if (Month.class.isAssignableFrom(asType)) {
                try {
                    overriddenDataType.setValue(new MonthType(absoluteName,
                            nativeClass,
                            (Month) AnnotationParserUtils.parseDate(Month.class, overriddenMinValue, overriddenFormat),
                            (Month) AnnotationParserUtils.parseDate(Month.class, overriddenMaxValue, overriddenFormat),
                            nullableOk));
                } catch (ParseException e) {
                    throw new IllegalArgumentException(e);
                }
            } else if (net.vpc.upa.types.Date.class.isAssignableFrom(asType)) {
                try {
                    overriddenDataType.setValue(new DateType(absoluteName,
                            nativeClass,
                            (net.vpc.upa.types.Date) AnnotationParserUtils.parseDate(net.vpc.upa.types.Date.class, overriddenMinValue, overriddenFormat),
                            (net.vpc.upa.types.Date) AnnotationParserUtils.parseDate(net.vpc.upa.types.Date.class, overriddenMaxValue, overriddenFormat),
                            nullableOk));
                } catch (ParseException e) {
                    throw new IllegalArgumentException(e);
                }
            } else if (DateTime.class.isAssignableFrom(asType)) {
                try {
                    overriddenDataType.setValue(new DateTimeType(absoluteName,
                            nativeClass,
                            (DateTime) AnnotationParserUtils.parseDate(DateTime.class, overriddenMinValue, overriddenFormat),
                            (DateTime) AnnotationParserUtils.parseDate(DateTime.class, overriddenMaxValue, overriddenFormat),
                            nullableOk));
                } catch (ParseException e) {
                    throw new IllegalArgumentException(e);
                }
            } else if (net.vpc.upa.types.Timestamp.class.isAssignableFrom(asType) || java.sql.Timestamp.class.isAssignableFrom(asType)) {
                try {
                    overriddenDataType.setValue(new TimestampType(absoluteName,
                            nativeClass,
                            (Timestamp) AnnotationParserUtils.parseDate(Timestamp.class, overriddenMinValue, overriddenFormat),
                            (Timestamp) AnnotationParserUtils.parseDate(Timestamp.class, overriddenMaxValue, overriddenFormat),
                            nullableOk));
                } catch (ParseException e) {
                    throw new IllegalArgumentException(e);
                }
            } else if (net.vpc.upa.types.Time.class.isAssignableFrom(asType)) {
                try {
                    overriddenDataType.setValue(new TimeType(absoluteName,
                            nativeClass,
                            (Time) AnnotationParserUtils.parseDate(Time.class, overriddenMinValue, overriddenFormat),
                            (Time) AnnotationParserUtils.parseDate(Time.class, overriddenMaxValue, overriddenFormat),
                            nullableOk));
                } catch (ParseException e) {
                    throw new IllegalArgumentException(e);
                }
            } else if (java.sql.Date.class.isAssignableFrom(asType)) {
                try {
                    overriddenDataType.setValue(new DateType(absoluteName,
                            nativeClass,
                            (net.vpc.upa.types.Date) AnnotationParserUtils.parseDate(net.vpc.upa.types.Date.class, overriddenMinValue, overriddenFormat),
                            (net.vpc.upa.types.Date) AnnotationParserUtils.parseDate(net.vpc.upa.types.Date.class, overriddenMaxValue, overriddenFormat),
                            nullableOk));
                } catch (ParseException e) {
                    throw new IllegalArgumentException(e);
                }
            } else {
                try {
                    overriddenDataType.setValue(new DateTimeType(absoluteName,
                            nativeClass,
                            (DateTime) AnnotationParserUtils.parseDate(DateTime.class, overriddenMinValue, overriddenFormat),
                            (DateTime) AnnotationParserUtils.parseDate(DateTime.class, overriddenMaxValue, overriddenFormat),
                            nullableOk));
                } catch (ParseException e) {
                    throw new IllegalArgumentException(e);
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
        for (Field someField : fields) {
            Decoration searchDeco = repo.getFieldDecoration(someField, net.vpc.upa.config.Search.class);
            if (searchDeco != null) {
                overriddenSearchOperator.setBetterValue(searchDeco.getEnum("op", SearchOperator.class)
                        == SearchOperator.DEFAULT ? PlatformUtils.getUndefinedValue(SearchOperator.class)
                                : searchDeco.getEnum("op", SearchOperator.class), searchDeco.getConfig().getOrder());
            }
            for (net.vpc.upa.config.Index indexAnn : findIndexAnnotation(someField)) {
                List<String> rr = new ArrayList<String>();
                rr.add(someField.getName());
                rr.addAll(Arrays.asList(indexAnn.fields()));
                entityInfo.addIndex(indexAnn.name(), rr, indexAnn.unique(), indexAnn.config().order());
            }
            Decoration temporalAnn = repo.getFieldDecoration(someField, net.vpc.upa.config.Temporal.class);
            if (temporalAnn != null && temporalAnn.getConfig().getOrder() != Integer.MIN_VALUE) {
                overriddenTemporal.setBetterValue(temporalAnn.getEnum("value", TemporalOption.class), temporalAnn.getConfig().getOrder());
            }

            Decoration propertyDeco = repo.getFieldDecoration(someField, net.vpc.upa.config.Property.class);
            if (propertyDeco != null) {
                parameterInfos.add(new Property(propertyDeco.getString("name"), propertyDeco.getString("value"), propertyDeco.getString("type"), propertyDeco.getString("format")));
            }

            Decoration propertiesDeco = repo.getFieldDecoration(someField, net.vpc.upa.config.Properties.class);
            if (propertiesDeco != null) {
                for (DecorationValue p : propertiesDeco.getArray("value")) {
                    //p of type net.vpc.upa.config.Property
                    Decoration pp = (Decoration) p;
                    parameterInfos.add(new Property(pp.getString("name"), pp.getString("value"), pp.getString("type"), pp.getString("format")));
                }
            }

            Decoration pathDeco = repo.getFieldDecoration(someField, net.vpc.upa.config.Path.class);
            if (pathDeco != null) {
                AnnotationParserUtils.validStr(pathDeco.getString("value"), overriddenPath, pathDeco.getConfig().getOrder());
            }
            if (someField.getType().equals(FieldDesc.class)) {
                prepareFieldDesc(ctx, entityName, someField);
            } else {
                //default configOrder for DAL is 100
                overriddenNativeType.setBetterValue(someField.getType(), 100);
            }
            Decoration fieldDeco = repo.getFieldDecoration(someField, net.vpc.upa.config.Field.class);
            if (fieldDeco != null) {
                modifiers = modifiers.addAll(Arrays.asList(fieldDeco.getPrimitiveArray("modifiers", UserFieldModifier.class)));
                excludeModifiers = excludeModifiers.addAll(Arrays.asList(fieldDeco.getPrimitiveArray("excludeModifiers", UserFieldModifier.class)));
                int processOrder = fieldDeco.getConfig().getOrder();
                AnnotationParserUtils.validClass(fieldDeco.getType("type"), overriddenNativeType, Object.class, processOrder);
                AnnotationParserUtils.validStr(fieldDeco.getString("min"), overriddenMinValue, processOrder);
                AnnotationParserUtils.validStr(fieldDeco.getString("max"), overriddenMaxValue, processOrder);
                AnnotationParserUtils.validStr(fieldDeco.getString("layout"), overriddenLayout, processOrder);
                AnnotationParserUtils.validInt(fieldDeco.getInt("scale"), overriddenScale, -1, processOrder);
                AnnotationParserUtils.validInt(fieldDeco.getInt("precision"), overriddenPrec, -1, processOrder);
                if (fieldDeco.getEnum("nullable", BoolEnum.class) != BoolEnum.UNDEFINED) {
                    overriddenNullable.setBetterValue(fieldDeco.getEnum("nullable", BoolEnum.class), processOrder);
                }
                if (fieldDeco.getInt("position") != Integer.MIN_VALUE) {
                    overriddenPosition.setBetterValue(fieldDeco.getInt("position"), processOrder);
                }
//                if (fieldDeco.getEnum("end", BoolEnum.class) != BoolEnum.UNDEFINED) {
//                    overriddenEnd.setBetterValue(fieldDeco.getEnum("nullable", BoolEnum.class), processOrder);
//                }
                if (!PlatformUtils.isUndefinedValue(AccessLevel.class, fieldDeco.getEnum("persistAccessLevel", AccessLevel.class))) {
                    overriddenPersistAccessLevel.setBetterValue(fieldDeco.getEnum("persistAccessLevel", AccessLevel.class), processOrder);
                }
                if (!PlatformUtils.isUndefinedValue(AccessLevel.class, fieldDeco.getEnum("updateAccessLevel", AccessLevel.class))) {
                    overriddenUpdateAccessLevel.setBetterValue(fieldDeco.getEnum("updateAccessLevel", AccessLevel.class), processOrder);
                }
                if (!PlatformUtils.isUndefinedValue(AccessLevel.class, fieldDeco.getEnum("removeAccessLevel", AccessLevel.class))) {
                    overriddenRemoveAccessLevel.setBetterValue(fieldDeco.getEnum("removeAccessLevel", AccessLevel.class), processOrder);
                }
                if (!PlatformUtils.isUndefinedValue(AccessLevel.class, fieldDeco.getEnum("readAccessLevel", AccessLevel.class))) {
                    overriddenReadAccessLevel.setBetterValue(fieldDeco.getEnum("readAccessLevel", AccessLevel.class), processOrder);
                }
                AnnotationParserUtils.validStr(fieldDeco.getString("charsAccepted"), overriddenCharsAccepted, processOrder);
                AnnotationParserUtils.validStr(fieldDeco.getString("charsRejected"), overriddenCharsRejected, processOrder);
                AnnotationParserUtils.validStr(fieldDeco.getString("format"), overriddenFormat, processOrder);
                AnnotationParserUtils.validStr(fieldDeco.getString("path"), overriddenPath, processOrder);
                AnnotationParserUtils.validStr(fieldDeco.getString("defaultValue"), overriddenDefaultValueStr, processOrder);
                AnnotationParserUtils.validStr(fieldDeco.getString("unspecifiedValue"), overriddenUnspecifiedValueStr, processOrder);
            }
            Decoration mainDeco = repo.getFieldDecoration(someField, net.vpc.upa.config.Main.class);
            if(mainDeco!=null){
                modifiers=modifiers.add(UserFieldModifier.MAIN);
            }
            Decoration summaryDeco = repo.getFieldDecoration(someField, net.vpc.upa.config.Summary.class);
            if(summaryDeco!=null){
                modifiers=modifiers.add(UserFieldModifier.SUMMARY);
            }
            Decoration uniqueDeco = repo.getFieldDecoration(someField, net.vpc.upa.config.Unique.class);
            if(uniqueDeco!=null){
                modifiers=modifiers.add(UserFieldModifier.UNIQUE);
            }
            Decoration annID = repo.getFieldDecoration(someField, Id.class);
            if (annID != null) {
                modifiers = modifiers.add(UserFieldModifier.ID);
            }
            Decoration propertyAccess = repo.getFieldDecoration(someField, PropertyAccess.class);
            if (propertyAccess != null) {
                overriddenPropertyAccessType.setBetterValue(propertyAccess.getEnum("value", PropertyAccessType.class), propertyAccess.getConfig().getOrder());
            }
        }
        nativeClass = overriddenNativeType.getValue(fields.get(0).getType());
        for (Property parameterInfo : parameterInfos) {
            fieldParams.put(parameterInfo.getName(), UPAUtils.createValue(parameterInfo));
        }
        if (overriddenNullable.specified && (overriddenNullable.value != BoolEnum.UNDEFINED)) {
            nullableOk = overriddenNullable.value.equals(BoolEnum.TRUE);
        }
        if (!PlatformUtils.isNullableType(nativeClass) || modifiers.contains(UserFieldModifier.ID)) {
            nullableOk = false;
        }

        anyFormula.parse(fields);

        foreignInfo.parse(fields, nullableOk);

//        boolean endOk = false;
//        if (overriddenEnd.specified && (overriddenEnd.value != BoolEnum.UNDEFINED)) {
//            endOk = overriddenEnd.value.equals(BoolEnum.TRUE);
//        }
        if (overriddenNativeType.specified && !overriddenNativeType.value.equals(Object.class)
                && (!overriddenDataType.specified || (overriddenDataType.specified && overriddenNativeType.order > overriddenDataType.order))) {
            prepareBaseDataType(ctx, entityName);
        }
        preparePeristentDataType(ctx, entityName);
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
//        if (insertFormula.specified) {
//            this.formulaupaField.setFormula(insertFormula.value);
//        }
        if (overriddenDataType.specified) {
            this.type = (overriddenDataType.value);
        }
//        if (overriddenTargetType.specified) {
//            this.targetType = (overriddenTargetType.value);
//        }
        if (overriddenPersistAccessLevel.specified && !PlatformUtils.isUndefinedValue(AccessLevel.class, overriddenPersistAccessLevel.value)) {
            this.persistAccessLevel = overriddenPersistAccessLevel.value;
        }
        if (overriddenUpdateAccessLevel.specified && !PlatformUtils.isUndefinedValue(AccessLevel.class, overriddenUpdateAccessLevel.value)) {
            this.updateAccessLevel = overriddenUpdateAccessLevel.value;
        }
        if (overriddenReadAccessLevel.specified && !PlatformUtils.isUndefinedValue(AccessLevel.class, overriddenReadAccessLevel.value)) {
            this.readAccessLevel = overriddenReadAccessLevel.value;
        }
//        this.entityField = upaField;
    }

    public void build(Map<String, Object> ctx, String entityName) {
        if (buildForeign) {
            if (UPAUtils.isSimpleFieldType(nativeClass)) {
                int length = foreignInfo.getMappedTo() == null ? 0 : foreignInfo.getMappedTo().length;
                if (length == 1) {
                    FieldInfo f = entityInfo.fieldsMap.get(foreignInfo.getMappedTo()[0]);
                    if (f == null) {
                        throw new IllegalArgumentException("Field " + foreignInfo.getMappedTo()[0] + " not found");
                    }
                    if (!f.foreignInfo.isSpecified()) {
                        ManyToOneType manyToOneType = new ManyToOneType(f.name, f.nativeClass, foreignInfo.getTargetEntity(), false, f.nullableOk);
                        f.overriddenDataType.setValue(manyToOneType);
                    } else {
                        throw new IllegalArgumentException(f.name + " already mapped by " + name + ". Should not define relations on its own.");
                    }
                } else if (length > 1) {
                    throw new IllegalArgumentException("Illegal mapping for " + name);
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
                throw new RuntimeException("Unable to parse default value for " + entityName + "." + name,e);
            }
        }
        if (overriddenDefaultValue.specified) {
            this.defaultObject = (overriddenDefaultValue.value);
        }

        if (overriddenUnspecifiedValueStr.specified && (!overriddenUnspecifiedValue.specified || overriddenUnspecifiedValueStr.order > overriddenUnspecifiedValue.order)) {
            try {
                overriddenUnspecifiedValue.setBetterValue(AnnotationParserUtils.parseStringValue(overriddenUnspecifiedValueStr.value, overriddenDataType.value, UnspecifiedValue.DEFAULT), overriddenUnspecifiedValue.order);
            } catch (ParseException e) {
                throw new RuntimeException("Unable to parse unspecified value for " + entityName + "." + name,e);
            }
        }
        if (overriddenDataType.specified) {
            this.type = (overriddenDataType.value);
        }
    }

    public void registerField(Field field) {
        fields.add(field);
    }

    public String getName() {
        return name;
    }

    public List<Field> getFields() {
        return fields;
    }

    public RelationshipInfo getForeignInfo() {
        return foreignInfo;
    }

    public EntityInfo getEntityInfo() {
        return entityInfo;
    }

    public String getFieldPath() {
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
        return type;
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
        Integer value = overriddenPosition.value;
        if (value == null) {
            return 0;
        }
        return value.intValue();
    }

    public int getSelectFormulaOrder() {
        return selectFormulaOrder;
    }

    public FlagSet<UserFieldModifier> getUserFieldModifiers() {
        return modifiers;
    }

    public FlagSet<UserFieldModifier> getUserExcludeModifiers() {
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
    private List<net.vpc.upa.config.Index> findIndexAnnotation(Field javaField) {
        List<net.vpc.upa.config.Index> list = new ArrayList<net.vpc.upa.config.Index>();
        net.vpc.upa.config.Index indexAnn = (net.vpc.upa.config.Index) repo.getFieldDecoration(javaField, net.vpc.upa.config.Index.class);
        if (indexAnn != null) {
            list.add(indexAnn);
        }
        net.vpc.upa.config.Indexes indexAnnAll = (net.vpc.upa.config.Indexes) repo.getFieldDecoration(javaField, net.vpc.upa.config.Indexes.class);
        if (indexAnnAll != null) {
            for (net.vpc.upa.config.Index index : indexAnnAll.value()) {
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
        return "FieldInfo{" + "name=" + name + ", fields=" + fields + ", type=" + type + '}';
    }

    private void prepareFormula(Map<String, Object> ctx, String entityName, FormulaType t, Object o) {

        net.vpc.upa.Formula ff = null;
        int order = 0;
        if (o instanceof FormulaInfo) {
            FormulaInfo formulaInfo = (FormulaInfo) o;
            if (formulaInfo.specified) {
                if (formulaInfo.type != null) {
                    try {
                        ff = (formulaInfo.type.newInstance());
                    } catch (Exception e) {
                        throw new RuntimeException(e);
                    }
                } else if (formulaInfo.expression != null) {
                    ff = (new ExpressionFormula(formulaInfo.expression));
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

    private void preparePeristentDataType(Map<String, Object> ctx, String entityName) {
        for (Field javaField : fields) {
            List<DataTypeTransformConfig> transforms = new ArrayList<DataTypeTransformConfig>();
            ConfigInfo ci = null;
            for (Decoration fieldDecoration : repo.getFieldDecorations(javaField)) {
                if (fieldDecoration.getName().equals(net.vpc.upa.config.Password.class.getName())) {
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
                } else if (fieldDecoration.getName().equals(net.vpc.upa.config.Secret.class.getName())) {
                    if (ci == null) {
                        ci = fieldDecoration.getConfig();
                    }
                    SecretTransformConfig s2 = new SecretTransformConfig();
                    s2.setSecretStrategy(fieldDecoration.getString("algorithm"));
                    s2.setSize(fieldDecoration.getInt("max"));
                    s2.setEncodeKey(fieldDecoration.getString("key"));
                    s2.setDecodeKey(fieldDecoration.getString("reverseKey"));
                    transforms.add(s2);

                } else if (fieldDecoration.getName().equals(net.vpc.upa.config.ToString.class.getName())) {
                    if (ci == null) {
                        ci = fieldDecoration.getConfig();
                    }
                    StringEncoderTransformConfig s2 = new StringEncoderTransformConfig();
                    StringEncoderType stringStrategyType = fieldDecoration.getEnum("value", StringEncoderType.class);
                    if (stringStrategyType == StringEncoderType.CUSTOM) {
                        s2.setEncoder(fieldDecoration.getEnum("custom", StringEncoderType.class));
                    } else {
                        s2.setEncoder(stringStrategyType);
                    }
                    transforms.add(s2);
                } else if (fieldDecoration.getName().equals(net.vpc.upa.config.ToByteArray.class.getName())) {
                    if (ci == null) {
                        ci = fieldDecoration.getConfig();
                    }
                    ByteArrayEncoderTransformConfig s2 = new ByteArrayEncoderTransformConfig();
                    s2.setEncoder(fieldDecoration.getString("value"));
                    transforms.add(s2);
                } else if (fieldDecoration.getName().equals(net.vpc.upa.config.ToCharArray.class.getName())) {
                    if (ci == null) {
                        ci = fieldDecoration.getConfig();
                    }
                    CharArrayEncoderTransformConfig s2 = new CharArrayEncoderTransformConfig();
                    s2.setEncoder(fieldDecoration.getString("value"));
                    transforms.add(s2);
                } else if (fieldDecoration.getName().equals(net.vpc.upa.config.Converter.class.getName())) {
                    if (ci == null) {
                        ci = fieldDecoration.getConfig();
                    }
                    String type = fieldDecoration.getString("type");
                    String expression = fieldDecoration.getString("expression");
                    if (type.length() > 0 && expression.length() > 0) {
                        throw new IllegalArgumentException("Invalid Converter definition : both type and expression are mentioned");
                    } else if (type.length() == 0 && expression.length() == 0) {
                        throw new IllegalArgumentException("Invalid Converter definition : none of type and expression are mentioned");
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

}
