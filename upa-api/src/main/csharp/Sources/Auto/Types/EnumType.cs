/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE HAS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.TheVpc.Upa.Types
{



    public partial class EnumType : Net.TheVpc.Upa.Types.SeriesType {

        public EnumType(System.Type enumClass, bool nullable)  : base((enumClass).FullName, enumClass, nullable){

        }


        protected internal override void ReevaluateCachedValues() {
            base.ReevaluateCachedValues();
            if (!defaultValueUserDefined && !IsNullable()) {
                defaultValue = (GetValues()[0]);
            }
        }


        public override void Check(object @value, string name, string description) /* throws Net.TheVpc.Upa.Types.ConstraintsException */  {
            base.Check(@value, name, description);
            if (@value != null && !GetPlatformType().IsInstanceOfType(@value)) {
                throw new Net.TheVpc.Upa.Types.ConstraintsException("InvalidCast", name, description, @value);
            }
        }




        public override string ToString() {
            return "EnumType{" + GetPlatformType() + '}';
        }

        public virtual object Parse(string @value) {
            if (@value == null || (@value.Trim().Length==0)) {
                return null;
            }
            return System.Enum.Parse(GetPlatformType(),@value);
        }


        public override bool Equals(object o) {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;
            if (!base.Equals(o)) return false;
            return true;
        }


        public override int GetHashCode() {
            int result = base.GetHashCode();
            return result;
        }


        public override Net.TheVpc.Upa.DataTypeInfo GetInfo() {
            Net.TheVpc.Upa.DataTypeInfo d = base.GetInfo();
            System.Text.StringBuilder v = new System.Text.StringBuilder();
            foreach (object o in GetPlatformType().GetEnumConstants()) {
                if ((v).Length > 0) {
                    v.Append(",");
                }
                v.Append(o.ToString());
            }
            d.GetProperties()["values"]=System.Convert.ToString(v);
            return d;
        }
    }
}
