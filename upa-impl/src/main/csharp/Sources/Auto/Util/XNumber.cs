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



namespace Net.Vpc.Upa.Impl.Util
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public class XNumber {

        private System.Type type;

        private object number;

        public XNumber(object number) {
            this.number = number;
            this.type = ValidateType(number.GetType());
        }

        public virtual Net.Vpc.Upa.Impl.Util.XNumber Add(object other) {
            return Add(new Net.Vpc.Upa.Impl.Util.XNumber(other));
        }

        public virtual Net.Vpc.Upa.Impl.Util.XNumber Negate() {
            if (type == typeof(byte?)) {
                return new Net.Vpc.Upa.Impl.Util.XNumber(-ByteValue());
            } else if (type == typeof(short?)) {
                return new Net.Vpc.Upa.Impl.Util.XNumber(-ShortValue());
            } else if (type == typeof(int?)) {
                return new Net.Vpc.Upa.Impl.Util.XNumber(-IntValue());
            } else if (type == typeof(float?)) {
                return new Net.Vpc.Upa.Impl.Util.XNumber(-FloatValue());
            } else if (type == typeof(double?)) {
                return new Net.Vpc.Upa.Impl.Util.XNumber(-DoubleValue());
            } else if (type == typeof(System.Numerics.BigInteger?)) {
                return new Net.Vpc.Upa.Impl.Util.XNumber((-(BigIntegerValue())));
            } else if (type == typeof(System.Decimal?)) {
                return new Net.Vpc.Upa.Impl.Util.XNumber((-(BigDecimalValue())));
            }
            throw new System.ArgumentException ("Invalid");
        }

        public virtual Net.Vpc.Upa.Impl.Util.XNumber Inv() {
            if (type == typeof(byte?)) {
                return new Net.Vpc.Upa.Impl.Util.XNumber(1.0 / ByteValue());
            } else if (type == typeof(short?)) {
                return new Net.Vpc.Upa.Impl.Util.XNumber(1.0 / ShortValue());
            } else if (type == typeof(int?)) {
                return new Net.Vpc.Upa.Impl.Util.XNumber(1.0 / IntValue());
            } else if (type == typeof(float?)) {
                return new Net.Vpc.Upa.Impl.Util.XNumber(1.0f / FloatValue());
            } else if (type == typeof(double?)) {
                return new Net.Vpc.Upa.Impl.Util.XNumber(1.0 / DoubleValue());
            } else if (type == typeof(System.Numerics.BigInteger?)) {
                return new Net.Vpc.Upa.Impl.Util.XNumber(((System.Convert.ToDecimal("1"))/(BigDecimalValue())));
            } else if (type == typeof(System.Decimal?)) {
                return new Net.Vpc.Upa.Impl.Util.XNumber(((System.Convert.ToDecimal("1"))/(BigDecimalValue())));
            }
            throw new System.ArgumentException ("Invalid");
        }

        public virtual Net.Vpc.Upa.Impl.Util.XNumber Complement() {
            if (type == typeof(byte?)) {
                return new Net.Vpc.Upa.Impl.Util.XNumber(~ByteValue());
            } else if (type == typeof(short?)) {
                return new Net.Vpc.Upa.Impl.Util.XNumber(~ShortValue());
            } else if (type == typeof(int?)) {
                return new Net.Vpc.Upa.Impl.Util.XNumber(~IntValue());
            } else if (type == typeof(float?)) {
            } else if (type == typeof(double?)) {
            } else if (type == typeof(System.Numerics.BigInteger?)) {
            } else if (type == typeof(System.Decimal?)) {
            }
            throw new System.ArgumentException ("Unsupported");
        }

        public virtual Net.Vpc.Upa.Impl.Util.XNumber Add(Net.Vpc.Upa.Impl.Util.XNumber other) {
            System.Type c = BestFit(type, other.type);
            if (c == typeof(byte?)) {
                return new Net.Vpc.Upa.Impl.Util.XNumber(ByteValue() + other.ByteValue());
            } else if (c == typeof(short?)) {
                return new Net.Vpc.Upa.Impl.Util.XNumber(ShortValue() + other.ShortValue());
            } else if (c == typeof(int?)) {
                return new Net.Vpc.Upa.Impl.Util.XNumber(IntValue() + other.IntValue());
            } else if (c == typeof(float?)) {
                return new Net.Vpc.Upa.Impl.Util.XNumber(FloatValue() + other.FloatValue());
            } else if (c == typeof(double?)) {
                return new Net.Vpc.Upa.Impl.Util.XNumber(DoubleValue() + other.DoubleValue());
            } else if (c == typeof(System.Numerics.BigInteger?)) {
                return new Net.Vpc.Upa.Impl.Util.XNumber(((BigIntegerValue())+(other.BigIntegerValue())));
            } else if (c == typeof(System.Decimal?)) {
                return new Net.Vpc.Upa.Impl.Util.XNumber(((BigDecimalValue())+(other.BigDecimalValue())));
            }
            throw new System.ArgumentException ("Invalid");
        }

        public virtual Net.Vpc.Upa.Impl.Util.XNumber Subtract(Net.Vpc.Upa.Impl.Util.XNumber other) {
            System.Type c = BestFit(type, other.type);
            if (c == typeof(byte?)) {
                return new Net.Vpc.Upa.Impl.Util.XNumber(ByteValue() - other.ByteValue());
            } else if (c == typeof(short?)) {
                return new Net.Vpc.Upa.Impl.Util.XNumber(ShortValue() - other.ShortValue());
            } else if (c == typeof(int?)) {
                return new Net.Vpc.Upa.Impl.Util.XNumber(IntValue() - other.IntValue());
            } else if (c == typeof(float?)) {
                return new Net.Vpc.Upa.Impl.Util.XNumber(FloatValue() - other.FloatValue());
            } else if (c == typeof(double?)) {
                return new Net.Vpc.Upa.Impl.Util.XNumber(DoubleValue() - other.DoubleValue());
            } else if (c == typeof(System.Numerics.BigInteger?)) {
                return new Net.Vpc.Upa.Impl.Util.XNumber(((BigIntegerValue())-(other.BigIntegerValue())));
            } else if (c == typeof(System.Decimal?)) {
                return new Net.Vpc.Upa.Impl.Util.XNumber(((BigDecimalValue())-(other.BigDecimalValue())));
            }
            throw new System.ArgumentException ("Invalid");
        }

        public virtual Net.Vpc.Upa.Impl.Util.XNumber Multiply(Net.Vpc.Upa.Impl.Util.XNumber other) {
            System.Type c = BestFit(type, other.type);
            if (c == typeof(byte?)) {
                return new Net.Vpc.Upa.Impl.Util.XNumber(ByteValue() * other.ByteValue());
            } else if (c == typeof(short?)) {
                return new Net.Vpc.Upa.Impl.Util.XNumber(ShortValue() * other.ShortValue());
            } else if (c == typeof(int?)) {
                return new Net.Vpc.Upa.Impl.Util.XNumber(IntValue() * other.IntValue());
            } else if (c == typeof(float?)) {
                return new Net.Vpc.Upa.Impl.Util.XNumber(FloatValue() * other.FloatValue());
            } else if (c == typeof(double?)) {
                return new Net.Vpc.Upa.Impl.Util.XNumber(DoubleValue() * other.DoubleValue());
            } else if (c == typeof(System.Numerics.BigInteger?)) {
                return new Net.Vpc.Upa.Impl.Util.XNumber(((BigIntegerValue())*(other.BigIntegerValue())));
            } else if (c == typeof(System.Decimal?)) {
                return new Net.Vpc.Upa.Impl.Util.XNumber(((BigDecimalValue())*(other.BigDecimalValue())));
            }
            throw new System.ArgumentException ("Invalid");
        }

        public virtual Net.Vpc.Upa.Impl.Util.XNumber Divide(Net.Vpc.Upa.Impl.Util.XNumber other) {
            System.Type c = BestFit(type, other.type);
            if (c == typeof(byte?)) {
                return new Net.Vpc.Upa.Impl.Util.XNumber(ByteValue() / other.ByteValue());
            } else if (c == typeof(short?)) {
                return new Net.Vpc.Upa.Impl.Util.XNumber(ShortValue() / other.ShortValue());
            } else if (c == typeof(int?)) {
                return new Net.Vpc.Upa.Impl.Util.XNumber(IntValue() / other.IntValue());
            } else if (c == typeof(float?)) {
                return new Net.Vpc.Upa.Impl.Util.XNumber(FloatValue() / other.FloatValue());
            } else if (c == typeof(double?)) {
                return new Net.Vpc.Upa.Impl.Util.XNumber(DoubleValue() / other.DoubleValue());
            } else if (c == typeof(System.Numerics.BigInteger?)) {
                return new Net.Vpc.Upa.Impl.Util.XNumber(((BigIntegerValue())/(other.BigIntegerValue())));
            } else if (c == typeof(System.Decimal?)) {
                return new Net.Vpc.Upa.Impl.Util.XNumber(((BigDecimalValue())/(other.BigDecimalValue())));
            }
            throw new System.ArgumentException ("Invalid");
        }

        public virtual object ToNumber() {
            if (type == typeof(byte?)) {
                return ByteValue();
            } else if (type == typeof(short?)) {
                return ShortValue();
            } else if (type == typeof(int?)) {
                return IntValue();
            } else if (type == typeof(float?)) {
                return FloatValue();
            } else if (type == typeof(double?)) {
                return DoubleValue();
            } else if (type == typeof(System.Numerics.BigInteger?)) {
                return BigIntegerValue();
            } else if (type == typeof(System.Decimal?)) {
                return BigDecimalValue();
            }
            throw new System.ArgumentException ("Invalid");
        }


        public override int GetHashCode() {
            int hash = 7;
            hash = 67 * hash + Net.Vpc.Upa.Impl.FwkConvertUtils.ObjectHashCode(this.type);
            hash = 67 * hash + Net.Vpc.Upa.Impl.FwkConvertUtils.ObjectHashCode(this.number);
            return hash;
        }


        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (GetType() != obj.GetType()) {
                return false;
            }
            Net.Vpc.Upa.Impl.Util.XNumber other = (Net.Vpc.Upa.Impl.Util.XNumber) obj;
            if (CompareTo(other) != 0) {
                return false;
            }
            return true;
        }

        public virtual bool Equals(Net.Vpc.Upa.Impl.Util.XNumber other) {
            return CompareTo(other) == 0;
        }

        public static int Compare(Net.Vpc.Upa.Impl.Util.XNumber a, Net.Vpc.Upa.Impl.Util.XNumber b) {
            if (a != null && b != null) {
                return a.CompareTo(b);
            }
            if (a == null) {
                a = new Net.Vpc.Upa.Impl.Util.XNumber(System.Double.NaN);
            }
            if (b == null) {
                b = new Net.Vpc.Upa.Impl.Util.XNumber(System.Double.NaN);
            }
            return a.CompareTo(b);
        }

        public virtual int CompareTo(Net.Vpc.Upa.Impl.Util.XNumber other) {
            System.Type c = BestFit(type, other.type);
            if (c == typeof(byte?)) {
                return ByteValue().CompareTo(other.ByteValue());
            } else if (c == typeof(short?)) {
                return ShortValue().CompareTo(other.ShortValue());
            } else if (c == typeof(int?)) {
                return IntValue().CompareTo(other.IntValue());
            } else if (c == typeof(float?)) {
                return FloatValue().CompareTo(other.FloatValue());
            } else if (c == typeof(double?)) {
                return DoubleValue().CompareTo(other.DoubleValue());
            } else if (c == typeof(System.Numerics.BigInteger?)) {
                return (BigIntegerValue().Value.CompareTo(other.BigIntegerValue()));
            } else if (c == typeof(System.Decimal?)) {
                return (BigDecimalValue().Value.CompareTo(other.BigDecimalValue()));
            }
            throw new System.ArgumentException ("Invalid");
        }

        public static System.Type ValidateType(System.Type cls1) {
            if (cls1.Equals(typeof(byte)) || cls1.Equals(typeof(byte))) {
                return typeof(byte?);
            } else if (cls1.Equals(typeof(int?)) || cls1.Equals(typeof(int))) {
                return typeof(int?);
            } else if (cls1.Equals(typeof(double?)) || cls1.Equals(typeof(double))) {
                return typeof(double?);
            } else if (cls1.Equals(typeof(float?)) || cls1.Equals(typeof(float))) {
                return typeof(float?);
            } else if (cls1.Equals(typeof(double?)) || cls1.Equals(typeof(double))) {
                return typeof(double?);
            } else if (cls1.Equals(typeof(long?)) || cls1.Equals(typeof(long))) {
                return typeof(long?);
            } else if (cls1.Equals(typeof(short?)) || cls1.Equals(typeof(short))) {
                return typeof(short?);
            } else if (cls1.Equals(typeof(System.Decimal?))) {
                return typeof(System.Decimal?);
            } else if (cls1.Equals(typeof(System.Numerics.BigInteger?))) {
                return typeof(System.Numerics.BigInteger?);
            } else {
                throw new System.ArgumentException ("Invalid Type " + cls1);
            }
        }

        public virtual byte ByteValue() {
            return System.Convert.ToByte(number);
        }

        public virtual short ShortValue() {
            return System.Convert.ToInt16(number);
        }

        public virtual int IntValue() {
            return System.Convert.ToInt32(number);
        }

        public virtual long LongValue() {
            return System.Convert.ToInt32(number);
        }

        public virtual float FloatValue() {
            return System.Convert.ToSingle(number);
        }

        public virtual double DoubleValue() {
            return System.Convert.ToDouble(number);
        }

        public virtual bool IsInteger() {
            return (number is byte?) || (number is int?) || (number is short?) || (number is long?) || (number is System.Numerics.BigInteger?);
        }

        public virtual bool IsFloating() {
            return (number is float?) || (number is double?);
        }

        public virtual bool IsDecimal() {
            return (number is System.Decimal?);
        }

        public virtual System.Decimal? BigDecimalValue() {
            if (number is System.Decimal?) {
                return (System.Decimal?) number;
            }
            return System.Convert.ToDecimal(number);
        }

        public virtual System.Numerics.BigInteger? BigIntegerValue() {
            if (number is System.Decimal?) {
                return (System.Numerics.BigInteger?)(number);
            }
            if (IsInteger()) {
                if (number is System.Numerics.BigInteger?) {
                    return ((System.Numerics.BigInteger?) number);
                }
                return Net.Vpc.Upa.Impl.FwkConvertUtils.CreateBigInteger("" + System.Convert.ToInt32(number));
            }
            if (IsFloating()) {
                return Net.Vpc.Upa.Impl.FwkConvertUtils.CreateBigInteger("" + System.Convert.ToInt32(number));
            }
            //return new BigDecimal(number.doubleValue()).toBigInteger();
            throw new System.ArgumentException ("Invalid bigDecimaValue()");
        }

        public static System.Type BestFit(System.Type cls1, System.Type cls2) {
            cls1 = ValidateType(cls1);
            cls2 = ValidateType(cls2);
            if (cls1.Equals(cls2)) {
                return cls1;
            }
            if (cls1.Equals(typeof(byte?))) {
                return cls2;
            } else if (cls1.Equals(typeof(short?))) {
                if (cls2.Equals(typeof(byte?))) {
                    return cls2;
                } else {
                    return cls2;
                }
            } else if (cls1.Equals(typeof(int?))) {
                if (cls2.Equals(typeof(byte?)) || cls2.Equals(typeof(short?))) {
                    return cls1;
                } else {
                    return cls2;
                }
            } else if (cls1.Equals(typeof(long?))) {
                if (cls2.Equals(typeof(byte?)) || cls2.Equals(typeof(short?)) || cls2.Equals(typeof(int?))) {
                    return cls1;
                } else if (cls2.Equals(typeof(short?))) {
                    return typeof(double?);
                } else {
                    return cls2;
                }
            } else if (cls1.Equals(typeof(float?))) {
                if (cls2.Equals(typeof(byte?)) || cls2.Equals(typeof(short?)) || cls2.Equals(typeof(int?))) {
                    return cls1;
                } else if (cls2.Equals(typeof(long?))) {
                    return typeof(double?);
                } else if (cls2.Equals(typeof(System.Numerics.BigInteger?))) {
                    return typeof(System.Decimal?);
                } else {
                    return cls2;
                }
            } else if (cls1.Equals(typeof(double?))) {
                if (cls2.Equals(typeof(byte?)) || cls2.Equals(typeof(short?)) || cls2.Equals(typeof(int?)) || cls2.Equals(typeof(long?)) || cls2.Equals(typeof(float?))) {
                    return cls1;
                } else if (cls2.Equals(typeof(System.Numerics.BigInteger?))) {
                    return typeof(System.Decimal?);
                } else {
                    return cls2;
                }
            } else if (cls1.Equals(typeof(System.Numerics.BigInteger?))) {
                if (cls2.Equals(typeof(byte?)) || cls2.Equals(typeof(short?)) || cls2.Equals(typeof(int?)) || cls2.Equals(typeof(long?))) {
                    return typeof(System.Decimal?);
                } else {
                    return cls2;
                }
            } else if (cls1.Equals(typeof(System.Decimal?))) {
                return cls1;
            } else {
                throw new System.ArgumentException ("Unsupported");
            }
        }
    }
}
