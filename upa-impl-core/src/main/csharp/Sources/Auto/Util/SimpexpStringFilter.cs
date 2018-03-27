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
     * @author taha.bensalah@gmail.com
     */
    public class SimpexpStringFilter : Net.Vpc.Upa.Filters.ObjectFilter<string> {

        private string patternString;

        private Net.Vpc.Upa.Impl.Util.Regexp.PortablePattern pattern;

        private bool nullIsEmpty;

        private bool ignoreCase;

        public SimpexpStringFilter(string patternString, bool nullIsEmpty, bool ignoreCase) {
            this.patternString = (nullIsEmpty && patternString == null) ? "" : patternString;
            string pattern = Net.Vpc.Upa.Impl.Util.StringUtils.SimpexpToRegexp(patternString, Net.Vpc.Upa.Impl.Util.PatternType.DOT_PATH);
            this.pattern = this.patternString == null ? null : new Net.Vpc.Upa.Impl.Util.Regexp.PortablePattern(ignoreCase ? pattern.ToLower() : pattern);
            this.nullIsEmpty = nullIsEmpty;
            this.ignoreCase = ignoreCase;
        }

        public virtual bool Accept(string s) {
            if (nullIsEmpty && s == null) {
                s = "";
            }
            return pattern.Matcher(ignoreCase ? s.ToLower() : s).Matches();
        }
    }
}
