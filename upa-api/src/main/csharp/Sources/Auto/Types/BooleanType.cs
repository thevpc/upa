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



namespace Net.Vpc.Upa.Types
{


    public class BooleanType : Net.Vpc.Upa.Types.SeriesType {

        public static readonly Net.Vpc.Upa.Types.BooleanType BOOLEAN = new Net.Vpc.Upa.Types.BooleanType("BOOLEAN", false, true);

        public static readonly Net.Vpc.Upa.Types.BooleanType BOOLEAN_REF = new Net.Vpc.Upa.Types.BooleanType("BOOLEAN", true, false);

        public BooleanType(string name, bool nullable, bool primitiveType)  : base(name, primitiveType ? typeof(bool) : typeof(bool?), nullable){

            SetDefaultNonNullValue(false);
        }


        public override void Check(object @value, string name, string description) /* throws Net.Vpc.Upa.Types.ConstraintsException */  {
            base.Check(@value, name, description);
            if (!(@value is bool?)) {
                throw new Net.Vpc.Upa.Types.ConstraintsException("InvalidCast", name, description, @value);
            }
        }


        public override System.Collections.Generic.IList<object> GetValues() {
            System.Collections.Generic.IList<object> list = new System.Collections.Generic.List<object>();
            list.Add(true);
            list.Add(false);
            return list;
        }


        public override string ToString() {
            return "Boolean{null=" + IsNullable() + '}';
        }

        public virtual bool? Parse(string @value) {
            if (@value == null || @value.Trim().Length==0) {
                return null;
            }
            return System.Convert.ToBoolean(@value);
        }
    }
}
