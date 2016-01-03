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



namespace Net.Vpc.Upa.Impl.Util
{

    /**
     *
     * @author vpc
     */
    public class StringHelper {

        public static readonly Net.Vpc.Upa.Impl.Util.StringHelper EMPTY_STRING = new Net.Vpc.Upa.Impl.Util.StringHelper("", "", "", true);

        private string undefinedValue = "";

        private string emptyValue = "";

        private string nullValue = "";

        private bool trim = true;

        public StringHelper(string undefinedValue, string emptyValue, string nullValue, bool trim) {
            this.undefinedValue = undefinedValue;
            this.emptyValue = emptyValue;
            this.nullValue = nullValue;
            this.trim = trim;
        }

        public virtual string Format(string s) {
            if (Net.Vpc.Upa.Impl.Util.Strings.IsUndefined(s)) {
                return undefinedValue;
            }
            if (s == null) {
                return nullValue;
            }
            if (trim) {
                s = s.Trim();
            }
            if ((s).Length == 0) {
                return emptyValue;
            }
            return s;
        }
    }
}
