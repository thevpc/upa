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
    public sealed class AnnotationDecoration : Net.Vpc.Upa.Impl.Config.Decorations.AbstractDecoration {

        private System.Attribute ann;

        private Net.Vpc.Upa.Config.DecorationSourceType decorationSourceType;

        private Net.Vpc.Upa.Config.DecorationTarget targetType;

        private string type;

        private string location;

        private Net.Vpc.Upa.Config.ConfigInfo configInfo;

        private System.Collections.Generic.IDictionary<string , Net.Vpc.Upa.Config.DecorationValue> values = null;

        private int position;

        public AnnotationDecoration(System.Attribute ann, Net.Vpc.Upa.Config.DecorationSourceType locationType, Net.Vpc.Upa.Config.DecorationTarget targetType, string type, string location, int position, Net.Vpc.Upa.Config.ConfigInfo configInfo) {
            this.ann = ann;
            this.decorationSourceType = locationType;
            this.targetType = targetType;
            this.type = type;
            this.location = location;
            this.configInfo = configInfo;
            this.position = position;
        }

        public AnnotationDecoration(System.Attribute ann, Net.Vpc.Upa.Config.DecorationSourceType locationType, Net.Vpc.Upa.Config.DecorationTarget targetType, string type, string location, int position)  : this(ann, locationType, targetType, type, location, position, null){

        }

        public override string GetName() {
            return (ann.GetType()).FullName;
        }

        public override int GetPosition() {
            return position;
        }

        protected internal override Net.Vpc.Upa.Config.ConfigInfo GetConfigInfo0() {
            if (configInfo == null) {
                Net.Vpc.Upa.Config.Decoration config = GetDecoration("config");
                if (config != null) {
                    Net.Vpc.Upa.Config.Decoration c = (Net.Vpc.Upa.Config.Decoration) config;
                    if (c.GetName().Equals((typeof(Net.Vpc.Upa.Config.Config)).FullName)) {
                        configInfo = new Net.Vpc.Upa.Config.ConfigInfo(c.GetInt("order"), (Net.Vpc.Upa.Config.ConfigAction)(System.Enum.Parse(typeof(Net.Vpc.Upa.Config.ConfigAction),c.GetString("action"))), c.GetString("persistenceGroup"), c.GetString("persistenceUnit"));
                    }
                }
            }
            return configInfo;
        }

        public override string GetLocation() {
            return location;
        }

        public override Net.Vpc.Upa.Config.DecorationSourceType GetDecorationSourceType() {
            return decorationSourceType;
        }

        public override Net.Vpc.Upa.Config.DecorationTarget GetTarget() {
            return targetType;
        }

        public override string GetLocationType() {
            return type;
        }

        public override Net.Vpc.Upa.Config.ConfigInfo GetConfig() {
            if (configInfo == null) {
                try {
                    System.Reflection.MethodInfo method = ann.GetType().GetMethod("config");
                    if (method != null && ((method).ReturnType).FullName.Equals((typeof(Net.Vpc.Upa.Config.Config)).FullName)) {
                        object t = method.Invoke(ann, new object[0]);
                        Net.Vpc.Upa.Impl.Config.Decorations.AnnotationDecoration c = new Net.Vpc.Upa.Impl.Config.Decorations.AnnotationDecoration((System.Attribute) t, default(Net.Vpc.Upa.Config.DecorationSourceType), default(Net.Vpc.Upa.Config.DecorationTarget), null, null, 0);
                        configInfo = new Net.Vpc.Upa.Config.ConfigInfo(c.GetInt("order"), (Net.Vpc.Upa.Config.ConfigAction)(System.Enum.Parse(typeof(Net.Vpc.Upa.Config.ConfigAction),c.GetString("action"))), c.GetString("persistenceGroup"), c.GetString("persistenceUnit"));
                    }
                } catch (System.Exception e) {
                }
            }
            //ignore
            //                e.printStackTrace();
            if (configInfo == null) {
                configInfo = new Net.Vpc.Upa.Config.ConfigInfo(System.Int32.MinValue, Net.Vpc.Upa.Config.ConfigAction.MERGE, null, null);
            }
            return configInfo;
        }

        protected internal override System.Collections.Generic.IDictionary<string , Net.Vpc.Upa.Config.DecorationValue> GetAttributes0() {
            if (values == null) {
                System.Collections.Generic.IDictionary<string , Net.Vpc.Upa.Config.DecorationValue> map = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Config.DecorationValue>();
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
            if (targetType == default(Net.Vpc.Upa.Config.DecorationTarget)) {
                b.Append("EMBEDDED").Append(":");
            }
            b.Append(type);
            if (targetType == Net.Vpc.Upa.Config.DecorationTarget.METHOD || targetType == Net.Vpc.Upa.Config.DecorationTarget.FIELD) {
                b.Append(".").Append(location);
            }
            if (!GetConfig().Equals(Net.Vpc.Upa.Config.ConfigInfo.DEFAULT)) {
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
