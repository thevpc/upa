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



namespace Net.TheVpc.Upa.Impl.Config.Decorations
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public abstract class AbstractDecoration : Net.TheVpc.Upa.Impl.Config.Decorations.AbstractDecorationValue, Net.TheVpc.Upa.Config.Decoration {

        private Net.TheVpc.Upa.Config.ConfigInfo mergedConfigInfo = null;

        private System.Collections.Generic.IDictionary<string , Net.TheVpc.Upa.Config.DecorationValue> mergedAttributes = null;

        public virtual Net.TheVpc.Upa.Config.DecorationValue Get(string name) {
            System.Collections.Generic.IDictionary<string , Net.TheVpc.Upa.Config.DecorationValue> a = GetAttributes();
            Net.TheVpc.Upa.Config.DecorationValue v = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.TheVpc.Upa.Config.DecorationValue>(a,name);
            if (v == null) {
                throw new System.ArgumentException ("Attribute not found " + GetName() + "." + name);
            }
            return v;
        }


        public virtual bool IsName(string name) {
            return GetName().Equals(name);
        }


        public virtual bool IsName(System.Type type) {
            return GetName().Equals((type).FullName);
        }

        public virtual System.Type GetType(string name) {
            return (System.Type) GetPrimitive(name);
        }

        public virtual object GetPrimitive(string name) {
            return ((Net.TheVpc.Upa.Impl.Config.Decorations.DecorationPrimitiveValue) Get(name)).GetValue();
        }

        protected internal virtual Net.TheVpc.Upa.Config.DecorationValue Convert(object v, int pos) {
            if (v == null) {
                return new Net.TheVpc.Upa.Impl.Config.Decorations.DecorationPrimitiveValue(null, Net.TheVpc.Upa.Config.ConfigInfo.DEFAULT);
            }
            if (v is System.Attribute) {
                return new Net.TheVpc.Upa.Impl.Config.Decorations.AnnotationDecoration((System.Attribute) v, Net.TheVpc.Upa.Config.DecorationSourceType.TYPE, Net.TheVpc.Upa.Impl.Util.PlatformUtils.GetUndefinedValue<Net.TheVpc.Upa.Config.DecorationTarget>(typeof(Net.TheVpc.Upa.Config.DecorationTarget)), null, null, pos);
            } else if ((v.GetType()).IsArray) {
                int len = ((System.Array)(v)).Length;
                Net.TheVpc.Upa.Config.DecorationValue[] arr = new Net.TheVpc.Upa.Config.DecorationValue[len];
                for (int i = 0; i < arr.Length; i++) {
                    arr[i] = Convert(((System.Array)(v)).GetValue(i), i);
                }
                return new Net.TheVpc.Upa.Impl.Config.Decorations.DecorationArray(arr, GetConfig());
            } else if (v is Net.TheVpc.Upa.Config.DecorationValue) {
                return (Net.TheVpc.Upa.Config.DecorationValue) v;
            }
            return new Net.TheVpc.Upa.Impl.Config.Decorations.DecorationPrimitiveValue(v, GetConfig());
        }

        public virtual Net.TheVpc.Upa.Config.Decoration GetDecoration(string name) {
            return (Net.TheVpc.Upa.Config.Decoration) Get(name);
        }

        public virtual Net.TheVpc.Upa.Config.DecorationValue[] GetArray(string name) {
            Net.TheVpc.Upa.Impl.Config.Decorations.DecorationArray t = (Net.TheVpc.Upa.Impl.Config.Decorations.DecorationArray) Get(name);
            if (t == null) {
                return null;
            }
            return t.GetValues();
        }

        public virtual bool GetBoolean(string name) {
            object primitive = GetPrimitive(name);
            if (primitive == null) {
                return false;
            }
            if (primitive is bool?) {
                return ((bool?) primitive).Value;
            }
            if (primitive is string) {
                return System.Convert.ToBoolean(primitive.ToString());
            }
            bool? b = (bool?) primitive;
            return (b).Value;
        }

        public virtual string GetString(string name) {
            object primitive = GetPrimitive(name);
            if (primitive == null) {
                return null;
            }
            return primitive.ToString();
        }

        public virtual int GetInt(string name) {
            object primitive = GetPrimitive(name);
            if (primitive == null) {
                return 0;
            }
            if (primitive is object) {
                return System.Convert.ToInt32(((object) primitive));
            }
            if (primitive is string) {
                return System.Convert.ToInt32(primitive.ToString());
            }
            return ((int?) GetPrimitive(name)).Value;
        }

        public virtual  T GetEnum<T>(string name, System.Type type) {
            return Net.TheVpc.Upa.Impl.Util.PlatformUtils.Convert<T>(GetPrimitive(name), type);
        }

        public virtual  T[] GetPrimitiveArray<T>(string name, System.Type type) {
            Net.TheVpc.Upa.Impl.Config.Decorations.DecorationArray t = (Net.TheVpc.Upa.Impl.Config.Decorations.DecorationArray) Get(name);
            if (t == null) {
                return default(T[]);
            }
            Net.TheVpc.Upa.Config.DecorationValue[] arr = t.GetValues();
            T[] arr2 = (T[]) System.Array.CreateInstance(type,arr.Length);
            for (int i = 0; i < arr2.Length; i++) {
                arr2[i] = (T) ((Net.TheVpc.Upa.Impl.Config.Decorations.DecorationPrimitiveValue) arr[i]).GetValue();
            }
            return arr2;
        }

        public virtual Net.TheVpc.Upa.Config.Decoration CastName(string type) {
            if (GetName().Equals(type)) {
                throw new System.InvalidCastException("Expected " + type + " but got " + GetName());
            }
            return this;
        }

        public virtual Net.TheVpc.Upa.Config.Decoration CastName(System.Type type) {
            return CastName((type).FullName);
        }

        public virtual void Merge() {
            System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Config.DecorationValue> att = new System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Config.DecorationValue>();
            Net.TheVpc.Upa.Config.DecorationValue[] alternatives1 = GetAlternatives();
            Net.TheVpc.Upa.Config.DecorationValue[] alternatives = Shrink(alternatives1);
            foreach (Net.TheVpc.Upa.Config.DecorationValue alternative in alternatives) {
                Net.TheVpc.Upa.Config.Decoration d = (Net.TheVpc.Upa.Config.Decoration) alternative;
                foreach (System.Collections.Generic.KeyValuePair<string , Net.TheVpc.Upa.Config.DecorationValue> e in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<string,Net.TheVpc.Upa.Config.DecorationValue>>(d.GetAttributes())) {
                    Net.TheVpc.Upa.Impl.Config.Decorations.AbstractDecorationValue v1 = (Net.TheVpc.Upa.Impl.Config.Decorations.AbstractDecorationValue) Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.TheVpc.Upa.Config.DecorationValue>(att,(e).Key);
                    Net.TheVpc.Upa.Impl.Config.Decorations.AbstractDecorationValue v2 = (Net.TheVpc.Upa.Impl.Config.Decorations.AbstractDecorationValue) (e).Value;
                    if (v1 == null) {
                        att[(e).Key]=v2;
                    } else {
                        v1.AddAlternative(v2);
                    }
                }
                break;
            }
            foreach (System.Collections.Generic.KeyValuePair<string , Net.TheVpc.Upa.Config.DecorationValue> e in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<string,Net.TheVpc.Upa.Config.DecorationValue>>(att)) {
                ((Net.TheVpc.Upa.Impl.Config.Decorations.AbstractDecoration) (e).Value).Merge();
            }
            if (alternatives.Length == 0) {
                Net.TheVpc.Upa.Config.DecorationValue last = alternatives1[alternatives1.Length - 1];
                mergedAttributes = new System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Config.DecorationValue>();
                mergedConfigInfo = new Net.TheVpc.Upa.Config.ConfigInfo(last.GetConfig().GetOrder(), Net.TheVpc.Upa.Config.ConfigAction.DELETE, last.GetConfig().GetPersistenceGroup(), last.GetConfig().GetPersistenceUnit());
            } else {
                Net.TheVpc.Upa.Config.DecorationValue last = alternatives[alternatives.Length - 1];
                mergedAttributes = att;
                mergedConfigInfo = new Net.TheVpc.Upa.Config.ConfigInfo(last.GetConfig().GetOrder(), Net.TheVpc.Upa.Config.ConfigAction.MERGE, last.GetConfig().GetPersistenceGroup(), last.GetConfig().GetPersistenceUnit());
            }
        }

        public override Net.TheVpc.Upa.Config.ConfigInfo GetConfig() {
            if (mergedConfigInfo != null) {
                return mergedConfigInfo;
            }
            return GetConfigInfo0();
        }

        protected internal abstract Net.TheVpc.Upa.Config.ConfigInfo GetConfigInfo0();

        public virtual System.Collections.Generic.IDictionary<string , Net.TheVpc.Upa.Config.DecorationValue> GetAttributes() {
            if (mergedAttributes != null) {
                return mergedAttributes;
            }
            return GetAttributes0();
        }

        protected internal abstract System.Collections.Generic.IDictionary<string , Net.TheVpc.Upa.Config.DecorationValue> GetAttributes0();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract Net.TheVpc.Upa.Config.DecorationTarget GetTarget();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract string GetLocation();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract int GetPosition();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract string GetName();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract string GetLocationType();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract Net.TheVpc.Upa.Config.DecorationSourceType GetDecorationSourceType();
    }
}
