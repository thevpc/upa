/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.util;

import net.vpc.upa.exceptions.UPAIllegalArgumentException;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.util.Objects;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class XNumber {
    private final Class platformType;
    private final Number number;

    public XNumber(Number number) {
        this.number = number;
        this.platformType = validateType(number.getClass());
    }

    public XNumber add(Number other) {
        return add(new XNumber(other));
    }

    public XNumber negate() {
        if (platformType == Byte.class) {
            return new XNumber(-byteValue());
        } else if (platformType == Short.class) {
            return new XNumber(-shortValue());
        } else if (platformType == Integer.class) {
            return new XNumber(-intValue());
        } else if (platformType == Float.class) {
            return new XNumber(-floatValue());
        } else if (platformType == Double.class) {
            return new XNumber(-doubleValue());
        } else if (platformType == BigInteger.class) {
            return new XNumber(bigIntegerValue().negate());
        } else if (platformType == BigDecimal.class) {
            return new XNumber(bigDecimalValue().negate());
        }
        throw new UPAIllegalArgumentException("Invalid");
    }

    public XNumber inv() {
        if (platformType == Byte.class) {
            return new XNumber(1.0/byteValue());
        } else if (platformType == Short.class) {
            return new XNumber(1.0/shortValue());
        } else if (platformType == Integer.class) {
            return new XNumber(1.0/intValue());
        } else if (platformType == Float.class) {
            return new XNumber(1.0f/floatValue());
        } else if (platformType == Double.class) {
            return new XNumber(1.0/doubleValue());
        } else if (platformType == BigInteger.class) {
            return new XNumber(new BigDecimal("1").divide(bigDecimalValue(), BigDecimal.ROUND_UP));
        } else if (platformType == BigDecimal.class) {
                return new XNumber(new BigDecimal("1").divide(bigDecimalValue(), BigDecimal.ROUND_UP));
        }
        throw new UPAIllegalArgumentException("Invalid");
    }

    public XNumber complement() {
        if (platformType == Byte.class) {
            return new XNumber(~byteValue());
        } else if (platformType == Short.class) {
            return new XNumber(~shortValue());
        } else if (platformType == Integer.class) {
            return new XNumber(~intValue());
        } else if (platformType == Float.class) {

        } else if (platformType == Double.class) {

        } else if (platformType == BigInteger.class) {

        } else if (platformType == BigDecimal.class) {

        }
        throw new UPAIllegalArgumentException("Unsupported");
    }

    public XNumber add(XNumber other) {
        Class c = bestFit(platformType, other.platformType);
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
        throw new UPAIllegalArgumentException("Invalid");
    }

    public XNumber subtract(XNumber other) {
        Class c = bestFit(platformType, other.platformType);
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
        throw new UPAIllegalArgumentException("Invalid");
    }

    public XNumber multiply(XNumber other) {
        Class c = bestFit(platformType, other.platformType);
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
        throw new UPAIllegalArgumentException("Invalid");
    }

    public XNumber divide(XNumber other) {
        Class c = bestFit(platformType, other.platformType);
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
        throw new UPAIllegalArgumentException("Invalid");
    }

    public Object toNumber() {
        if (platformType == Byte.class) {
            return byteValue();
        } else if (platformType == Short.class) {
            return shortValue();
        } else if (platformType == Integer.class) {
            return intValue();
        } else if (platformType == Float.class) {
            return floatValue();
        } else if (platformType == Double.class) {
            return doubleValue();
        } else if (platformType == BigInteger.class) {
            return bigIntegerValue();
        } else if (platformType == BigDecimal.class) {
            return bigDecimalValue();
        }
        throw new UPAIllegalArgumentException("Invalid");
    }

    @Override
    public int hashCode() {
        int hash = 7;
        hash = 67 * hash + Objects.hashCode(this.platformType);
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
        if (compareTo(other) != 0) {
            return false;
        }
        return true;
    }

    public boolean equals(XNumber other) {
        return compareTo(other) == 0;
    }

    public static int compare(XNumber a,XNumber b) {
        if(a!=null && b!=null){
            return a.compareTo(b);
        }
        if(a==null){
            a=new XNumber(Double.NaN);
        }
        if(b==null){
            b=new XNumber(Double.NaN);
        }
        return a.compareTo(b);
    }

    public int compareTo(XNumber other) {
        Class c = bestFit(platformType, other.platformType);
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
        throw new UPAIllegalArgumentException("Invalid");
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
            throw new UPAIllegalArgumentException("Invalid Type " + cls1);
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
        /**
         * @PortabilityHint(target="C#",name="replace")
         * return System.Convert.ToDecimal(number);
         */
        {
            if (isInteger()) {
                if (number instanceof BigInteger) {
                    return new BigDecimal((BigInteger) number);
                }
                return new BigDecimal(number.longValue());
            }
            if (isFloating()) {
                return new BigDecimal(number.doubleValue());
            }
            throw new UPAIllegalArgumentException("Invalid bigDecimaValue()");
        }
    }

    public BigInteger bigIntegerValue() {
        if (number instanceof BigDecimal) {
            /**
             * @PortabilityHint(target="C#",name="replace")
             * return (System.Numerics.BigInteger?)(number);
             */
            return ((BigDecimal) number).toBigInteger();
        }
        if (isInteger()) {
            if (number instanceof BigInteger) {
                return ((BigInteger) number);
            }
            return new BigInteger("" + number.longValue());
        }
        if (isFloating()) {
            return new BigInteger("" + number.longValue());
            //return new BigDecimal(number.doubleValue()).toBigInteger();
        }
        throw new UPAIllegalArgumentException("Invalid bigDecimaValue()");
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
            throw new UPAIllegalArgumentException("Unsupported");
        }
    }

}
