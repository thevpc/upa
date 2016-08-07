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



namespace Net.Vpc.Upa.Impl
{


    /**
     * Abstract Key is an abstract implementation of the <code>net.vpc.upa.Key</code> Interface.
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public abstract class AbstractKey : Net.Vpc.Upa.Key {



        public AbstractKey() {
        }

        private static bool __equals(object o1, object o2) {
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
                throw new System.ArgumentException ("could not compare primitive arrays");
            }
            //return false;
            object[] o1arr = (object[]) o1;
            object[] o2arr = (object[]) o2;
            if (o1arr.Length != o2arr.Length) {
                return false;
            } else {
                System.Collections.Generic.IList<object> o1coll = new System.Collections.Generic.List<object>(o1arr);
                System.Collections.Generic.IList<object> o2coll = new System.Collections.Generic.List<object>(o2arr);
                bool ret = o1coll.Equals(o2coll);
                return ret;
            }
        }

        /**
             * @param entity    entity to apply to this key
             * @param fieldName field name to retrieve
             * @return value of the given <code>fieldName</code> if it is a valid identifier portion
             * @throws UPAException if <code>fieldName</code> is not a valid identifier portion of the given Entity
             */
        public virtual object GetValue(Net.Vpc.Upa.Entity entity, string fieldName) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> f = entity.GetPrimaryFields();
            object[] @value = GetValue();
            for (int i = 0; i < (f).Count; i++) {
                if (f[i].GetName().Equals(fieldName)) {
                    return @value[i];
                }
            }
            throw new Net.Vpc.Upa.Exceptions.UPAException("Either key " + ToString() + " or fieldName " + fieldName + " does not refer to entity " + entity.GetName());
        }

        /**
             * Tests equality between the two instances (current and passed as param)
             *
             * @param object another AbstractKey instance to check
             * @return true if the two instances denote the same key portions
             */

        public override bool Equals(object @object) {
            if (!(@object is Net.Vpc.Upa.Impl.AbstractKey)) {
                return false;
            }
            object[] @value = GetValue();
            Net.Vpc.Upa.Impl.AbstractKey other = (Net.Vpc.Upa.Impl.AbstractKey) @object;
            object[] value1 = other == null ? null : other.GetValue();
            if (this == other || @value == value1) {
                return true;
            }
            if (@value == null || value1 == null) {
                return false;
            }
            if (@value.Length != value1.Length) {
                return false;
            }
            for (int i = 0; i < @value.Length; i++) {
                if (!__equals(@value[i], value1[i])) {
                    return false;
                }
            }
            return true;
        }

        /**
             * {@inheritDoc}
             */

        public override string ToString() {
            return "ID:" + (GetValue() == null ? "null" : (System.Convert.ToString(new System.Collections.Generic.List<object>(GetValue()))));
        }

        /**
             * {@inheritDoc}
             */

        public override int GetHashCode() {
            return ArrayHash(GetValue());
        }

        /**
             * Arrays.deepHashCode not used because java specific (UPA should be ported to C#)
             *
             * @param arr array
             * @return int hash value
             */
        private int ArrayHash(object[] arr) {
            int x = 0;
            if (arr != null) {
                foreach (object o in arr) {
                    if (o != null) {
                        x += 31 * o.GetHashCode();
                    }
                }
            }
            return x;
        }

        /**
             * {@inheritDoc}
             */
        public virtual string GetString() {
            object[] @value = GetValue();
            if (@value.Length == 0) {
                ThrowMultiDimensionalValue();
            }
            return (string) @value[0];
        }

        /**
             * {@inheritDoc}
             */
        public virtual object GetObject() {
            object[] @value = GetValue();
            if (@value.Length == 0) {
                ThrowMultiDimensionalValue();
            }
            return @value[0];
        }

        /**
             * {@inheritDoc}
             */
        public virtual int GetInt() {
            object[] @value = GetValue();
            if (@value.Length == 0) {
                ThrowMultiDimensionalValue();
            }
            return System.Convert.ToInt32(((object) @value[0]));
        }

        /**
             * {@inheritDoc}
             */
        public virtual long GetLong() {
            object[] @value = GetValue();
            if (@value.Length == 0) {
                ThrowMultiDimensionalValue();
            }
            return System.Convert.ToInt32(((object) @value[0]));
        }

        /**
             * {@inheritDoc}
             */
        public virtual Net.Vpc.Upa.Types.Temporal GetDate() {
            object[] @value = GetValue();
            if (@value.Length == 0) {
                ThrowMultiDimensionalValue();
            }
            return ((Net.Vpc.Upa.Types.Temporal) @value[0]);
        }

        private void ThrowMultiDimensionalValue() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            throw new Net.Vpc.Upa.Exceptions.UPAException("Not a single value key");
        }

        /**
             * {@inheritDoc}
             */
        public virtual string GetStringAt(int index) {
            object[] @value = GetValue();
            return (string) @value[index];
        }

        /**
             * {@inheritDoc}
             */
        public virtual object GetObjectAt(int index) {
            object[] @value = GetValue();
            return @value[index];
        }

        /**
             * {@inheritDoc}
             */
        public virtual int GetIntAt(int index) {
            object[] @value = GetValue();
            return System.Convert.ToInt32(((object) @value[index]));
        }

        /**
             * {@inheritDoc}
             */
        public virtual long GetLongAt(int index) {
            object[] @value = GetValue();
            return System.Convert.ToInt32(((object) @value[index]));
        }

        /**
             * {@inheritDoc}
             */
        public virtual Net.Vpc.Upa.Types.Temporal GetDateAt(int index) {
            object[] @value = GetValue();
            return ((Net.Vpc.Upa.Types.Temporal) @value[index]);
        }
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract object[] GetValue();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract void SetValue(object[] arg1);
    }
}
