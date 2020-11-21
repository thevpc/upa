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



namespace Net.TheVpc.Upa.Impl
{


    public class DefaultKey : Net.TheVpc.Upa.Impl.AbstractKey {



        private object[] @value;

        public DefaultKey() {
        }

        public DefaultKey(params object [] values) {
            SetValue(values);
        }

        public override void SetValue(params object [] values) {
            this.@value = values;
            foreach (object aValue in this.@value) {
                if (aValue == null) {
                    throw new System.Exception("key cannot contain a null value");
                }
                if (aValue is Net.TheVpc.Upa.Key) {
                    throw new System.Exception("bad key : Key");
                }
                if ((aValue.GetType()).IsArray) {
                    throw new System.Exception("bad key");
                }
            }
            if ((@value.GetType()).IsArray && !(@value.GetType().GetElementType()).IsPrimitive) {
            } else {
                this.@value = (new object[] { @value });
            }
        }


        public override object GetValue(Net.TheVpc.Upa.Entity entity, string fieldName) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> f = entity.GetPrimaryFields();
            for (int i = 0; i < (f).Count; i++) {
                if (f[i].GetName().Equals(fieldName)) {
                    return @value[i];
                }
            }
            throw new System.ArgumentException ("Either key " + ToString() + " or fieldName " + fieldName + " does not refer to entity " + entity.GetName());
        }

        public override object[] GetValue() {
            return @value;
        }


        public override bool Equals(object @object) {
            if (!(@object is Net.TheVpc.Upa.Impl.DefaultKey)) {
                return false;
            }
            return base.Equals(@object);
        }


        public override int GetHashCode() {
            int hash = 3;
            hash = 59 * hash;
            if (this.@value != null) {
                foreach (object o in @value) {
                    hash = hash * 31 + ((o == null) ? 0 : o.GetHashCode());
                }
            }
            return hash;
        }


        public override string ToString() {
            return "ID" + (@value == null ? "null" : (System.Convert.ToString(new System.Collections.Generic.List<object>(@value))));
        }
    }
}
