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
    public sealed class AnnotationDecoration : Net.TheVpc.Upa.Impl.Config.Decorations.AbstractDecoration {

        private System.Attribute ann;

        private Net.TheVpc.Upa.Config.DecorationSourceType decorationSourceType;

        private Net.TheVpc.Upa.Config.DecorationTarget targetType;

        private string type;

        private string location;

        private Net.TheVpc.Upa.Config.ConfigInfo configInfo;

        private System.Collections.Generic.IDictionary<string , Net.TheVpc.Upa.Config.DecorationValue> values = null;

        private int position;

        public AnnotationDecoration(System.Attribute ann, Net.TheVpc.Upa.Config.DecorationSourceType locationType, Net.TheVpc.Upa.Config.DecorationTarget targetType, string type, string location, int position, Net.TheVpc.Upa.Config.ConfigInfo configInfo) {
            this.ann = ann;
            this.decorationSourceType = locationType;
            this.targetType = targetType;
            this.type = type;
            this.location = location;
            this.configInfo = configInfo;
            this.position = position;
        }

        public AnnotationDecoration(System.Attribute ann, Net.TheVpc.Upa.Config.DecorationSourceType locationType, Net.TheVpc.Upa.Config.DecorationTarget targetType, string type, string location, int position)  : this(ann, locationType, targetType, type, location, position, null){

        }

        public override string GetName() {
            return (ann.GetType()).FullName;
        }

        public override int GetPosition() {
            return position;
        }

        protected internal override Net.TheVpc.Upa.Config.ConfigInfo GetConfigInfo0() {
            if (configInfo == null) {
                Net.TheVpc.Upa.Config.Decoration config = GetDecoration("config");
                if (config != null) {
                    Net.TheVpc.Upa.Config.Decoration c = (Net.TheVpc.Upa.Config.Decoration) config;
                    if (c.GetName().Equals((typeof(Net.TheVpc.Upa.Config.Config)).FullName)) {
                        configInfo = new Net.TheVpc.Upa.Config.ConfigInfo(c.GetInt("order"), (Net.TheVpc.Upa.Config.ConfigAction)(System.Enum.Parse(typeof(Net.TheVpc.Upa.Config.ConfigAction),c.GetString("action"))), c.GetString("persistenceGroup"), c.GetString("persistenceUnit"));
                    }
                }
            }
            return configInfo;
        }

        public override string GetLocation() {
            return location;
        }

        public override Net.TheVpc.Upa.Config.DecorationSourceType GetDecorationSourceType() {
            return decorationSourceType;
        }

        public override Net.TheVpc.Upa.Config.DecorationTarget GetTarget() {
            return targetType;
        }

        public override string GetLocationType() {
            return type;
        }

        public override Net.TheVpc.Upa.Config.ConfigInfo GetConfig() {
            if (configInfo == null) {
                try {
                    System.Reflection.MethodInfo method = ann.GetType().GetMethod("config");
                    if (method != null && ((method).ReturnType).FullName.Equals((typeof(Net.TheVpc.Upa.Config.Config)).FullName)) {
                        object t = method.Invoke(ann, new object[0]);
                        Net.TheVpc.Upa.Impl.Config.Decorations.AnnotationDecoration c = new Net.TheVpc.Upa.Impl.Config.Decorations.AnnotationDecoration((System.Attribute) t, default(Net.TheVpc.Upa.Config.DecorationSourceType), default(Net.TheVpc.Upa.Config.DecorationTarget), null, null, 0);
                        configInfo = new Net.TheVpc.Upa.Config.ConfigInfo(c.GetInt("order"), (Net.TheVpc.Upa.Config.ConfigAction)(System.Enum.Parse(typeof(Net.TheVpc.Upa.Config.ConfigAction),c.GetString("action"))), c.GetString("persistenceGroup"), c.GetString("persistenceUnit"));
                    }
                } catch (System.Exception e) {
                }
            }
            //ignore
            //                e.printStackTrace();
            if (configInfo == null) {
                configInfo = new Net.TheVpc.Upa.Config.ConfigInfo(System.Int32.MinValue, Net.TheVpc.Upa.Config.ConfigAction.MERGE, null, null);
            }
            return configInfo;
        }

        protected internal override System.Collections.Generic.IDictionary<string , Net.TheVpc.Upa.Config.DecorationValue> GetAttributes0() {
            if (values == null) {
                System.Collections.Generic.IDictionary<string , Net.TheVpc.Upa.Config.DecorationValue> map = new System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Config.DecorationValue>();
                int pos = 0;
                foreach (System.Reflection.MethodInfo declaredMethod in ann.GetType().GetMethods()) {
                    string mname = (declaredMethod).Name;
                    if (declaredMethod.GetParameters().Length == 0 && !mname.Equals("equals") && !mname.Equals("hashCode") && !mname.Equals("toString")) {
                        //                    System.out.println(declaredMethod);
                        try {
                            object v = declaredMethod.Invoke(ann, new object[0]);
                            map[(declaredMethod).Name]=Convert(v, pos);
                        } catch (System.Exception ex) {
                            throw new System.ArgumentException ("IllegalArgumentException", ex);
                        }
                    }
                    pos++;
                }
                values = map;
            }
            return values;
        }


        public override string ToString() {
            System.Text.StringBuilder b = new System.Text.StringBuilder();
            b.Append("@").Append(GetName());
            b.Append("[");
            if (targetType == default(Net.TheVpc.Upa.Config.DecorationTarget)) {
                b.Append("EMBEDDED").Append(":");
            }
            b.Append(type);
            if (targetType == Net.TheVpc.Upa.Config.DecorationTarget.METHOD || targetType == Net.TheVpc.Upa.Config.DecorationTarget.FIELD) {
                b.Append(".").Append(location);
            }
            if (!GetConfig().Equals(Net.TheVpc.Upa.Config.ConfigInfo.DEFAULT)) {
                b.Append(";");
                b.Append(GetConfig());
            }
            b.Append("](");
            string s = GetAttributes().ToString();
            b.Append(s.Substring(1,((s).Length - 1)-(1)));
            b.Append(")");
            return b.ToString();
        }
    }
}
