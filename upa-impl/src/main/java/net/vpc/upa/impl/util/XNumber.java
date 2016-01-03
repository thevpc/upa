/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.util;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.util.Objects;

/**
 *
 * @author vpc
 */
public class XNumber {

    private Class type;
    private Number number;

    public XNumber(Number number) {
        this.number = number;
        this.type = validateType(number.getClass());
    }

    public XNumber add(Number other) {
        return add(new XNumber(other));
    }

    public XNumber negate() {
        if (type == Byte.class) {
            return new XNumber(-byteValue());
        } else if (type == Short.class) {
            return new XNumber(-shortValue());
        } else if (type == Integer.class) {
            return new XNumber(-intValue());
        } else if (type == Float.class) {
            return new XNumber(-floatValue());
        } else if (type == Double.class) {
            return new XNumber(-doubleValue());
        } else if (type == BigInteger.class) {
            return new XNumber(bigIntegerValue().negate());
        } else if (type == BigDecimal.class) {
            return new XNumber(bigDecimalValue().negate());
        }
        throw new IllegalArgumentException("Invalid");
    }

    public XNumber complement() {
        if (type == Byte.class) {
            return new XNumber(~byteValue());
        } else if (type == Short.class) {
            return new XNumber(~shortValue());
        } else if (type == Integer.class) {
            return new XNumber(~intValue());
        } else if (type == Float.class) {

        } else if (type == Double.class) {

        } else if (type == BigInteger.class) {

        } else if (type == BigDecimal.class) {

        }
        throw new IllegalArgumentException("Unsupported");
    }

    public XNumber add(XNumber other) {
        Class c = bestFit(type, other.type);
        if (c == Byte.class) {
            return new XNumber(byteValue() + other.byteValue());
        } else if (c == Short.class) {
            return new XNumber(shortValue() + other.shortValue());
        } else if (c == Integer.class) {
            return new XNumber(intValue() + other.intValue());
        } else if (c == Float.class) {
            return new XNumber(floatValue() + other.floatValue());
        } else if (c == Double.class) {
            return new XNumber(doubleValue() + other.doubleValue());
        } else if (c == BigInteger.class) {
            return new XNumber(bigIntegerValue().add(other.bigIntegerValue()));
        } else if (c == BigDecimal.class) {
            return new XNumber(bigDecimalValue().add(other.bigDecimalValue()));
        }
        throw new IllegalArgumentException("Invalid");
    }

    public XNumber subtract(XNumber other) {
        Class c = bestFit(type, other.type);
        if (c == Byte.class) {
            return new XNumber(byteValue() - other.byteValue());
        } else if (c == Short.class) {
            return new XNumber(shortValue() - other.shortValue());
        } else if (c == Integer.class) {
            return new XNumber(intValue() - other.intValue());
        } else if (c == Float.class) {
            return new XNumber(floatValue() - other.floatValue());
        } else if (c == Double.class) {
            return new XNumber(doubleValue() - other.doubleValue());
        } else if (c == BigInteger.class) {
            return new XNumber(bigIntegerValue().subtract(other.bigIntegerValue()));
        } else if (c == BigDecimal.class) {
            return new XNumber(bigDecimalValue().subtract(other.bigDecimalValue()));
        }
        throw new IllegalArgumentException("Invalid");
    }

    public XNumber multiply(XNumber other) {
        Class c = bestFit(type, other.type);
        if (c == Byte.class) {
            return new XNumber(byteValue() * other.byteValue());
        } else if (c == Short.class) {
            return new XNumber(shortValue() * other.shortValue());
        } else if (c == Integer.class) {
            return new XNumber(intValue() * other.intValue());
        } else if (c == Float.class) {
            return new XNumber(floatValue() * other.floatValue());
        } else if (c == Double.class) {
            return new XNumber(doubleValue() * other.doubleValue());
        } else if (c == BigInteger.class) {
            return new XNumber(bigIntegerValue().multiply(other.bigIntegerValue()));
        } else if (c == BigDecimal.class) {
            return new XNumber(bigDecimalValue().multiply(other.bigDecimalValue()));
        }
        throw new IllegalArgumentException("Invalid");
    }

    public XNumber divide(XNumber other) {
        Class c = bestFit(type, other.type);
        if (c == Byte.class) {
            return new XNumber(byteValue() / other.byteValue());
        } else if (c == Short.class) {
            return new XNumber(shortValue() / other.shortValue());
        } else if (c == Integer.class) {
            return new XNumber(intValue() / other.intValue());
        } else if (c == Float.class) {
            return new XNumber(floatValue() / other.floatValue());
        } else if (c == Double.class) {
            return new XNumber(doubleValue() / other.doubleValue());
        } else if (c == BigInteger.class) {
            return new XNumber(bigIntegerValue().divide(other.bigIntegerValue()));
        } else if (c == BigDecimal.class) {
            return new XNumber(bigDecimalValue().divide(other.bigDecimalValue()));
        }
        throw new IllegalArgumentException("Invalid");
    }

    public Object toNumber() {
        if (type == Byte.class) {
            return byteValue();
        } else if (type == Short.class) {
            return shortValue();
        } else if (type == Integer.class) {
            return intValue();
        } else if (type == Float.class) {
            return floatValue();
        } else if (type == Double.class) {
            return doubleValue();
        } else if (type == BigInteger.class) {
            return bigIntegerValue();
        } else if (type == BigDecimal.class) {
            return bigDecimalValue();
        }
        throw new IllegalArgumentException("Invalid");
    }

    @Override
    public int hashCode() {
        int hash = 7;
        hash = 67 * hash + Objects.hashCode(this.type);
        hash = 67 * hash + Objects.hashCode(this.number);
        return hash;
    }

    @Override
    public boolean equals(Object obj) {
        if (obj == null) {
            return false;
        }
        if (getClass() != obj.getClass()) {
            return false;
        }
        final XNumber other = (XNumber) obj;
        if (comparetTo(other) != 0) {
            return false;
        }
        return true;
    }

    public boolean equals(XNumber other) {
        return comparetTo(other) == 0;
    }

    public int comparetTo(XNumber other) {
        Class c = bestFit(type, other.type);
        if (c == Byte.class) {
            return Byte.compare(byteValue(), other.byteValue());
        } else if (c == Short.class) {
            return Short.compare(shortValue(), other.shortValue());
        } else if (c == Integer.class) {
            return Integer.compare(intValue(), other.intValue());
        } else if (c == Float.class) {
            return Float.compare(floatValue(), other.floatValue());
        } else if (c == Double.class) {
            return Double.compare(doubleValue(), other.doubleValue());
        } else if (c == BigInteger.class) {
            return (bigIntegerValue().compareTo(other.bigIntegerValue()));
        } else if (c == BigDecimal.class) {
            return (bigDecimalValue().compareTo(other.bigDecimalValue()));
        }
        throw new IllegalArgumentException("Invalid");
    }

    public static Class validateType(Class cls1) {
        if (cls1.equals(Byte.TYPE) || cls1.equals(Byte.TYPE)) {
            return Byte.class;
        } else if (cls1.equals(Integer.class) || cls1.equals(Integer.TYPE)) {
            return Integer.class;
        } else if (cls1.equals(Double.class) || cls1.equals(Double.TYPE)) {
            return Double.class;
        } else if (cls1.equals(Float.class) || cls1.equals(Float.TYPE)) {
            return Float.class;
        } else if (cls1.equals(Double.class) || cls1.equals(Double.TYPE)) {
            return Double.class;
        } else if (cls1.equals(Long.class) || cls1.equals(Long.TYPE)) {
            return Long.class;
        } else if (cls1.equals(Short.class) || cls1.equals(Short.TYPE)) {
            return Short.class;
        } else if (cls1.equals(BigDecimal.class)) {
            return BigDecimal.class;
        } else if (cls1.equals(BigInteger.class)) {
            return BigInteger.class;
        } else {
            throw new IllegalArgumentException("Invalid Type " + cls1);
        }
    }

    public byte byteValue() {
        return number.byteValue();
    }

    public short shortValue() {
        return number.shortValue();
    }

    public int intValue() {
        return number.intValue();
    }

    public long longValue() {
        return number.longValue();
    }

    public float floatValue() {
        return number.floatValue();
    }

    public double doubleValue() {
        return number.doubleValue();
    }

    public boolean isInteger() {
        return (number instanceof Byte)
                || (number instanceof Integer)
                || (number instanceof Short)
                || (number instanceof Long)
                || (number instanceof BigInteger);
    }

    public boolean isFloating() {
        return (number instanceof Float)
                || (number instanceof Double);
    }

    public boolean isDecimal() {
        return (number instanceof BigDecimal);
    }

    public BigDecimal bigDecimalValue() {
        if (number instanceof BigDecimal) {
            return (BigDecimal) number;
        }
        if (isInteger()) {
            if (number instanceof BigInteger) {
                return new BigDecimal((BigInteger) number);
            }
            return new BigDecimal(number.longValue());
        }
        if (isFloating()) {
            return new BigDecimal(number.doubleValue());
        }
        throw new IllegalArgumentException("Invalid bigDecimaValue()");
    }

    public BigInteger bigIntegerValue() {
        if (number instanceof BigDecimal) {
            return ((BigDecimal) number).toBigInteger();
        }
        if (isInteger()) {
            if (number instanceof BigInteger) {
                return ((BigInteger) number);
            }
            return new BigInteger("" + number.longValue());
        }
        if (isFloating()) {
            return new BigDecimal(number.doubleValue()).toBigInteger();
        }
        throw new IllegalArgumentException("Invalid bigDecimaValue()");
    }

    public static Class bestFit(Class cls1, Class cls2) {
        cls1 = validateType(cls1);
        cls2 = validateType(cls2);
        if (cls1.equals(cls2)) {
            return cls1;
        }
        if (cls1.equals(Byte.class)) {
            return cls2;
        } else if (cls1.equals(Short.class)) {
            if (cls2.equals(Byte.class)) {
                return cls2;
            } else {
                return cls2;
            }
        } else if (cls1.equals(Integer.class)) {
            if (cls2.equals(Byte.class) || cls2.equals(Short.class)) {
                return cls1;
            } else {
                return cls2;
            }
        } else if (cls1.equals(Long.class)) {
            if (cls2.equals(Byte.class) || cls2.equals(Short.class) || cls2.equals(Integer.class)) {
                return cls1;
            } else if (cls2.equals(Short.class)) {
                return Double.class;
            } else {
                return cls2;
            }
        } else if (cls1.equals(Float.class)) {
            if (cls2.equals(Byte.class) || cls2.equals(Short.class) || cls2.equals(Integer.class)) {
                return cls1;
            } else if (cls2.equals(Long.class)) {
                return Double.class;
            } else if (cls2.equals(BigInteger.class)) {
                return BigDecimal.class;
            } else {
                return cls2;
            }
        } else if (cls1.equals(Double.class)) {
            if (cls2.equals(Byte.class) || cls2.equals(Short.class) || cls2.equals(Integer.class) || cls2.equals(Long.class) || cls2.equals(Float.class)) {
                return cls1;
            } else if (cls2.equals(BigInteger.class)) {
                return BigDecimal.class;
            } else {
                return cls2;
            }
        } else if (cls1.equals(BigInteger.class)) {
            if (cls2.equals(Byte.class) || cls2.equals(Short.class) || cls2.equals(Integer.class) || cls2.equals(Long.class)) {
                return BigDecimal.class;
            } else {
                return cls2;
            }
        } else if (cls1.equals(BigDecimal.class)) {
            return cls1;
        } else {
            throw new IllegalArgumentException("Unsupported");
        }
    }

}
