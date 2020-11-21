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



namespace Net.TheVpc.Upa
{


    public sealed class NamedFormula : Net.TheVpc.Upa.Formula {

        private string name;

        public NamedFormula(string name) {
            this.name = name;
        }

        public string GetName() {
            return name;
        }


        public override bool Equals(object o) {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;
            Net.TheVpc.Upa.NamedFormula that = (Net.TheVpc.Upa.NamedFormula) o;
            return Net.TheVpc.Upa.FwkConvertUtils.ObjectEquals(name,that.name);
        }


        public override int GetHashCode() {
            return Java.Util.Objects.Hash(name);
        }
    }
}
