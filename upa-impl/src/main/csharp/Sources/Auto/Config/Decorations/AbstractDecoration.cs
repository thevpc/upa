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



namespace Net.Vpc.Upa.Impl.Config.Decorations
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public abstract class AbstractDecoration : Net.Vpc.Upa.Impl.Config.Decorations.AbstractDecorationValue, Net.Vpc.Upa.Config.Decoration {

        private Net.Vpc.Upa.Config.ConfigInfo mergedConfigInfo = null;

        private System.Collections.Generic.IDictionary<string , Net.Vpc.Upa.Config.DecorationValue> mergedAttributes = null;

        public virtual Net.Vpc.Upa.Config.DecorationValue Get(string name) {
            System.Collections.Generic.IDictionary<string , Net.Vpc.Upa.Config.DecorationValue> a = GetAttributes();
            Net.Vpc.Upa.Config.DecorationValue v = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.Vpc.Upa.Config.DecorationValue>(a,name);
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
            return ((Net.Vpc.Upa.Impl.Config.Decorations.DecorationPrimitiveValue) Get(name)).GetValue();
        }

        protected internal virtual Net.Vpc.Upa.Config.DecorationValue Convert(object v, int pos) {
            if (v == null) {
                return new Net.Vpc.Upa.Impl.Config.Decorations.DecorationPrimitiveValue(null, Net.Vpc.Upa.Config.ConfigInfo.DEFAULT);
            }
            if (v is System.Attribute) {
                return new Net.Vpc.Upa.Impl.Config.Decorations.AnnotationDecoration((System.Attribute) v, Net.Vpc.Upa.Config.DecorationSourceType.TYPE, Net.Vpc.Upa.Impl.Util.PlatformUtils.GetUndefinedValue<Net.Vpc.Upa.Config.DecorationTarget>(typeof(Net.Vpc.Upa.Config.DecorationTarget)), null, null, pos);
            } else if ((v.GetType()).IsArray) {
                int len = ((System.Array)(v)).Length;
                Net.Vpc.Upa.Config.DecorationValue[] arr = new Net.Vpc.Upa.Config.DecorationValue[len];
                for (int i = 0; i < arr.Length; i++) {
                    arr[i] = Convert(((System.Array)(v)).GetValue(i), i);
                }
                return new Net.Vpc.Upa.Impl.Config.Decorations.DecorationArray(arr, GetConfig());
            } else if (v is Net.Vpc.Upa.Config.DecorationValue) {
                return (Net.Vpc.Upa.Config.DecorationValue) v;
            }
            return new Net.Vpc.Upa.Impl.Config.Decorations.DecorationPrimitiveValue(v, GetConfig());
        }

        public virtual Net.Vpc.Upa.Config.Decoration GetDecoration(string name) {
            return (Net.Vpc.Upa.Config.Decoration) Get(name);
        }

        public virtual Net.Vpc.Upa.Config.DecorationValue[] GetArray(string name) {
            Net.Vpc.Upa.Impl.Config.Decorations.DecorationArray t = (Net.Vpc.Upa.Impl.Config.Decorations.DecorationArray) Get(name);
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
            return Net.Vpc.Upa.Impl.Util.PlatformUtils.Convert<T>(GetPrimitive(name), type);
        }

        public virtual  T[] GetPrimitiveArray<T>(string name, System.Type type) {
            Net.Vpc.Upa.Impl.Config.Decorations.DecorationArray t = (Net.Vpc.Upa.Impl.Config.Decorations.DecorationArray) Get(name);
            if (t == null) {
                return default(T[]);
            }
            Net.Vpc.Upa.Config.DecorationValue[] arr = t.GetValues();
            T[] arr2 = (T[]) System.Array.CreateInstance(type,arr.Length);
            for (int i = 0; i < arr2.Length; i++) {
                arr2[i] = (T) ((Net.Vpc.Upa.Impl.Config.Decorations.DecorationPrimitiveValue) arr[i]).GetValue();
            }
            return arr2;
        }

        public virtual Net.Vpc.Upa.Config.Decoration CastName(string type) {
            if (GetName().Equals(type)) {
                throw new System.InvalidCastException("Expected " + type + " but got " + GetName());
            }
            return this;
        }

        public virtual Net.Vpc.Upa.Config.Decoration CastName(System.Type type) {
            return CastName((type).FullName);
        }

        public virtual void Merge() {
            System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Config.DecorationValue> att = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Config.DecorationValue>();
            Net.Vpc.Upa.Config.DecorationValue[] alternatives1 = GetAlternatives();
            Net.Vpc.Upa.Config.DecorationValue[] alternatives = Shrink(alternatives1);
            foreach (Net.Vpc.Upa.Config.DecorationValue alternative in alternatives) {
                Net.Vpc.Upa.Config.Decoration d = (Net.Vpc.Upa.Config.Decoration) alternative;
                foreach (System.Collections.Generic.KeyValuePair<string , Net.Vpc.Upa.Config.DecorationValue> e in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<string,Net.Vpc.Upa.Config.DecorationValue>>(d.GetAttributes())) {
                    Net.Vpc.Upa.Impl.Config.Decorations.AbstractDecorationValue v1 = (Net.Vpc.Upa.Impl.Config.Decorations.AbstractDecorationValue) Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.Vpc.Upa.Config.DecorationValue>(att,(e).Key);
                    Net.Vpc.Upa.Impl.Config.Decorations.AbstractDecorationValue v2 = (Net.Vpc.Upa.Impl.Config.Decorations.AbstractDecorationValue) (e).Value;
                    if (v1 == null) {
                        att[(e).Key]=v2;
                    } else {
                        v1.AddAlternative(v2);
                    }
                }
                break;
            }
            foreach (System.Collections.Generic.KeyValuePair<string , Net.Vpc.Upa.Config.DecorationValue> e in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<string,Net.Vpc.Upa.Config.DecorationValue>>(att)) {
                ((Net.Vpc.Upa.Impl.Config.Decorations.AbstractDecoration) (e).Value).Merge();
            }
            if (alternatives.Length == 0) {
                Net.Vpc.Upa.Config.DecorationValue last = alternatives1[alternatives1.Length - 1];
                mergedAttributes = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Config.DecorationValue>();
                mergedConfigInfo = new Net.Vpc.Upa.Config.ConfigInfo(last.GetConfig().GetOrder(), Net.Vpc.Upa.Config.ConfigAction.DELETE, last.GetConfig().GetPersistenceGroup(), last.GetConfig().GetPersistenceUnit());
            } else {
                Net.Vpc.Upa.Config.DecorationValue last = alternatives[alternatives.Length - 1];
                mergedAttributes = att;
                mergedConfigInfo = new Net.Vpc.Upa.Config.ConfigInfo(last.GetConfig().GetOrder(), Net.Vpc.Upa.Config.ConfigAction.MERGE, last.GetConfig().GetPersistenceGroup(), last.GetConfig().GetPersistenceUnit());
            }
        }

        public override Net.Vpc.Upa.Config.ConfigInfo GetConfig() {
            if (mergedConfigInfo != null) {
                return mergedConfigInfo;
            }
            return GetConfigInfo0();
        }

        protected internal abstract Net.Vpc.Upa.Config.ConfigInfo GetConfigInfo0();

        public virtual System.Collections.Generic.IDictionary<string , Net.Vpc.Upa.Config.DecorationValue> GetAttributes() {
            if (mergedAttributes != null) {
                return mergedAttributes;
            }
            return GetAttributes0();
        }

        protected internal abstract System.Collections.Generic.IDictionary<string , Net.Vpc.Upa.Config.DecorationValue> GetAttributes0();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract Net.Vpc.Upa.Config.DecorationTarget GetTarget();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract string GetLocation();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract int GetPosition();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract string GetName();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract string GetLocationType();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract Net.Vpc.Upa.Config.DecorationSourceType GetDecorationSourceType();
    }
}
