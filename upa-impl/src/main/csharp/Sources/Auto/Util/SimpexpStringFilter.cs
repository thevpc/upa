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
    public class SimpexpStringFilter : Net.Vpc.Upa.Impl.Util.ObjectFilter<string> {

        private string patternString;

        private System.Text.RegularExpressions.Regex pattern;

        private bool nullIsEmpty;

        private bool ignoreCase;

        public SimpexpStringFilter(string patternString, bool nullIsEmpty, bool ignoreCase) {
            this.patternString = (nullIsEmpty && patternString == null) ? "" : patternString;
            this.pattern = this.patternString == null ? null : new System.Text.RegularExpressions.Regex(Net.Vpc.Upa.Impl.Util.Strings.SimpexpToRegexp(patternString), (ignoreCase ? System.Text.RegularExpressions.RegexOptions.IgnoreCase : 0));
            this.nullIsEmpty = nullIsEmpty;
            this.ignoreCase = ignoreCase;
        }

        public virtual bool Accept(string s) {
            if (nullIsEmpty && s == null) {
                s = "";
            }
            return (pattern.Match(s)).Success;
        }
    }
}
