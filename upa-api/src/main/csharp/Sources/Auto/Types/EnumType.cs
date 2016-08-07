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



    public partial class EnumType : Net.Vpc.Upa.Types.SeriesType {

        private System.Type enumClass;

        public EnumType(System.Type enumClass, bool nullable)  : base((enumClass).FullName, enumClass, nullable){

            this.enumClass = enumClass;
            SetDefaultNonNullValue(GetValues()[0]);
        }


        public override void Check(object @value, string name, string description) /* throws Net.Vpc.Upa.Types.ConstraintsException */  {
            base.Check(@value, name, description);
            if (@value != null && !enumClass.IsInstanceOfType(@value)) {
                throw new Net.Vpc.Upa.Types.ConstraintsException("InvalidCast", name, description, @value);
            }
        }




        public override string ToString() {
            return "EnumType{" + enumClass + '}';
        }

        public virtual object Parse(string @value) {
            if (@value == null || @value.Trim().Length==0) {
                return null;
            }
            return System.Enum.Parse(enumClass,@value);
        }
    }
}
