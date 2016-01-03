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
    public class RegexpStringFilter : Net.Vpc.Upa.Impl.Util.ObjectFilter<string> {

        private string patternString;

        private System.Text.RegularExpressions.Regex pattern;

        private bool nullIsEmpty;

        private bool ignoreCase;

        public RegexpStringFilter(string patternString, bool nullIsEmpty, bool ignoreCase) {
            this.patternString = (nullIsEmpty && patternString == null) ? "" : patternString;
            if (patternString != null) {
                if (ignoreCase) {
                    this.pattern = new System.Text.RegularExpressions.Regex(patternString, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                } else {
                    this.pattern = new System.Text.RegularExpressions.Regex(patternString);
                }
            }
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
