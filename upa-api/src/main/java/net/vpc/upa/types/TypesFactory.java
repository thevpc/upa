/**
 * ==================================================================== 
 * UPA (Unstructured Persistence API)
 *    Yet another ORM Framework
 * ++++++++++++++++++++++++++++++++++
 * Unstructured Persistence API, referred to as UPA, is a genuine effort 
 * to raise programming language frameworks managing relational data in 
 * applications using Java Platform, Standard Edition and Java Platform, 
 * Enterprise Edition and Dot Net Framework equally to the next level of 
 * handling ORM for mutable data structures. UPA is intended to provide 
 * a solid reflection mechanisms to the mapped data structures while 
 * affording to make changes at runtime of those data structures. 
 * Besides, UPA has learned considerably of the leading ORM 
 * (JPA, Hibernate/NHibernate, MyBatis and Entity Framework to name a few) 
 * failures to satisfy very common even known to be trivial requirement in 
 * enterprise applications. 
 *
 * Copyright (C) 2014-2015 Taha BEN SALAH
 *
 * This program is free software; you can redistribute it and/or modify it under
 * the terms of the GNU General Public License as published by the Free Software
 * Foundation; either version 2 of the License, or (at your option) any later
 * version.
 *
 * This program is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
 * FOR A PARTICULAR PURPOSE. See the GNU General Public License for more
 * details.
 *
 * You should have received a copy of the GNU General Public License along with
 * this program; if not, write to the Free Software Foundation, Inc., 51
 * Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
 * ====================================================================
 */
package net.vpc.upa.types;

import net.vpc.upa.PortabilityHint;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public final class TypesFactory {

    public static final DataType OBJECT = new DataType("OBJECT", Object.class, true);
    public static final BooleanType BOOLEAN = BooleanType.BOOLEAN_REF;
    public static final DataType VOID = new DataType("VOID", Void.TYPE, true);
    public static final BigIntType BIGINT = BigIntType.DEFAULT;
    public static final IntType INT = IntType.DEFAULT;
    public static final LongType LONG = LongType.DEFAULT;
    public static final ByteType BYTE = ByteType.DEFAULT;
    public static final DoubleType DOUBLE = DoubleType.DEFAULT;
    public static final FloatType FLOAT = FloatType.DEFAULT;
    public static final ShortType SHORT = ShortType.DEFAULT;

    public static final DateType DATE = DateType.DEFAULT;
    public static final TimeType TIME = TimeType.DEFAULT;
    public static final DateTimeType DATETIME = DateTimeType.DEFAULT;
    public static final TimestampType TIMESTAMP = TimestampType.DEFAULT;
    public static final StringType STRING = StringType.DEFAULT;
    public static final MonthType MONTH = MonthType.DEFAULT;
    public static final YearType YEAR = YearType.DEFAULT;

    @PortabilityHint(target = "C#", name = "suppress") //no supported
    public static final TimeType JAVA_SQL_TIME = TimeType.JAVA_SQL;
    @PortabilityHint(target = "C#", name = "suppress") //no supported
    public static final TimeType JAVA_UTIL_TIME = TimeType.JAVA_UTIL;
    @PortabilityHint(target = "C#", name = "suppress") //no supported
    public static final DateType JAVA_SQL_DATE = DateType.JAVA_SQL;
    @PortabilityHint(target = "C#", name = "suppress") //no supported
    public static final DateTimeType JAVA_UTIL_DATETIME = DateTimeType.JAVA_UTIL;
    @PortabilityHint(target = "C#", name = "suppress") //no supported
    public static final TimestampType JAVA_SQL_TIMESTAMP = TimestampType.JAVA_SQL;

    @PortabilityHint(target = "C#", name = "suppress") //no supported
    public static final BigDecimalType BIGDECIMAL = BigDecimalType.DEFAULT;
    @PortabilityHint(target = "C#", name = "suppress") //no supported
    public static final DecimalType DECIMAL = DecimalType.DEFAULT;

    public static final FileType FILE = FileType.DEFAULT;
    public static final FileType IMAGE = ImageType.DEFAULT;
    public static final ByteArrayType BYTES = ByteArrayType.BYTES;
    public static final ByteArrayType BYTE_REFS = ByteArrayType.BYTE_REFS;
    public static final CharArrayType CHARS = CharArrayType.CHARS;
    public static final CharArrayType CHAR_REFS = CharArrayType.CHAR_REFS;

    private static Map<Class, DataType> defaultMapping = new HashMap<Class, DataType>();

    private static final Map<Class, String> typeNames = new HashMap<Class, String>();

    static {
        Map<Class, String> typeNames0 = typeNames;
        typeNames0.put(String.class, "string");
        typeNames0.put(Integer.class, "int");
        typeNames0.put(Integer.TYPE, "int");
        typeNames0.put(Short.class, "short");
        typeNames0.put(Short.TYPE, "short");
        typeNames0.put(Byte.class, "byte");
        typeNames0.put(Byte.TYPE, "byte");
        typeNames0.put(Long.class, "long");
        typeNames0.put(Long.TYPE, "long");
        typeNames0.put(Float.class, "float");
        typeNames0.put(Float.TYPE, "float");
        typeNames0.put(Double.class, "double");
        typeNames0.put(Double.TYPE, "double");
        typeNames0.put(Boolean.class, "boolean");
        typeNames0.put(Boolean.TYPE, "boolean");
        typeNames0.put(java.util.Date.class, "datetime");
        typeNames0.put(java.sql.Date.class, "date");
        typeNames0.put(java.sql.Time.class, "time");
        typeNames0.put(java.sql.Timestamp.class, "timestamp");
        typeNames0.put(DateTime.class, "datetime");
        typeNames0.put(Date.class, "date");
        typeNames0.put(Time.class, "time");
        typeNames0.put(Timestamp.class, "timestamp");
        typeNames0.put(Year.class, "year");
        typeNames0.put(Month.class, "month");
        typeNames0.put(BigInteger.class, "bigint");
        /**@PortabilityHint(target="C#",name="suppress")*/
        typeNames0.put(BigDecimal.class, "bigdecimal");
        typeNames0.put(Object.class, "object");
        typeNames0.put(byte[].class, "blob");
        typeNames0.put(Byte[].class, "rblob");
        typeNames0.put(char[].class, "clob");
        typeNames0.put(Character[].class, "rclob");

        register(Integer.class, INT);
        register(Integer.TYPE, INT);
        register(Double.class, DOUBLE);
        register(Double.TYPE, DOUBLE);
        register(BigInteger.class, BIGINT);
        register(Byte.class, BYTE);
        register(Byte.TYPE, BYTE);
        register(Float.class, FLOAT);
        register(Float.TYPE, FLOAT);
        register(Long.class, LONG);
        register(Long.TYPE, LONG);
        register(Short.class, SHORT);
        register(Short.TYPE, SHORT);
        register(String.class, StringType.DEFAULT);
        register(Date.class, DATE);
        register(Month.class, MONTH);
        register(Year.class, YEAR);
        register(Time.class, TIME);
        register(Boolean.class, BooleanType.BOOLEAN_REF);
        register(Boolean.TYPE, BooleanType.BOOLEAN);
        register(FileData.class, FILE);
        register(byte[].class, BYTES);
        register(char[].class, CHARS);
        register(Byte[].class, BYTE_REFS);
        register(Character[].class, CHAR_REFS);

        /**@PortabilityHint(target="C#",name="suppress")*/
        //All the of the following types are not supported in C#
        {
            register(java.util.Date.class, JAVA_UTIL_DATETIME);
            register(BigDecimal.class, BIGDECIMAL);
            register(java.sql.Time.class, JAVA_SQL_TIME);
            register(java.sql.Timestamp.class, TIMESTAMP);
            register(java.sql.Date.class, JAVA_SQL_DATE);
        }
    }

    private TypesFactory() {
    }
    
    

    public static void register(Class clazz, DataType dataType) {
        defaultMapping.put(clazz, dataType);
    }

    public static DataType forPlatformType(Class clazz) {
        DataType o = defaultMapping.get(clazz);
        if (o != null) {
            return o;
        }
        if(clazz.isEnum()){
            return new EnumType(clazz, true);
        }
        return OBJECT;
    }


    public static ListType forList(String name, List<Object> v, DataType eltClass, boolean nullable) {
        return new ListType(name, v, eltClass, nullable);
    }

    public static String getTypeName(Class clazz) {
        return typeNames.get(clazz);
    }
}
