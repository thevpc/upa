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

    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/29/12 1:45 AM
     */
    public class StringTypeCharValidator : Net.Vpc.Upa.Types.TypeValueValidator {

        protected internal string chars;

        protected internal bool positive;

        public StringTypeCharValidator(string chars, bool positive) {
            this.chars = chars;
            this.positive = positive;
        }

        public virtual string GetChars() {
            return chars;
        }

        public virtual bool IsPositive() {
            return positive;
        }


        public virtual void ValidateValue(object typeValue, string name, string description, Net.Vpc.Upa.Types.DataType type) /* throws Net.Vpc.Upa.Types.ConstraintsException */  {
            if (typeValue == null) {
                return;
            }
            string sval = (string) typeValue;
            if (positive) {
                for (int i = 0; i < (sval).Length; i++) {
                    if (chars.IndexOf(sval[i]) < 0) {
                        throw new Net.Vpc.Upa.Types.ConstraintsException("StringBadChars", name, description, typeValue, "" + sval[i]);
                    }
                }
            } else {
                for (int i = 0; i < (sval).Length; i++) {
                    if (chars.IndexOf(sval[i]) >= 0) {
                        throw new Net.Vpc.Upa.Types.ConstraintsException("StringBadChars", name, description, typeValue, "" + sval[i]);
                    }
                }
            }
        }
    }
}
