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



namespace Net.Vpc.Upa
{


    public sealed class NamedFormula : Net.Vpc.Upa.Formula {

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
            Net.Vpc.Upa.NamedFormula that = (Net.Vpc.Upa.NamedFormula) o;
            return Net.Vpc.Upa.FwkConvertUtils.ObjectEquals(name,that.name);
        }


        public override int GetHashCode() {
            return Java.Util.Objects.Hash(name);
        }
    }
}
