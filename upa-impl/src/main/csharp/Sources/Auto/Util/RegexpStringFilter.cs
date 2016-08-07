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
    public class RegexpStringFilter : Net.Vpc.Upa.Filters.ObjectFilter<string> {

        private string patternString;

        private Net.Vpc.Upa.Impl.Util.Regexp.PortablePattern pattern;

        private bool nullIsEmpty;

        private bool ignoreCase;

        public RegexpStringFilter(string patternString, bool nullIsEmpty, bool ignoreCase) {
            this.patternString = (nullIsEmpty && patternString == null) ? "" : patternString;
            this.ignoreCase = ignoreCase;
            if (patternString != null) {
                if (ignoreCase) {
                    this.pattern = new Net.Vpc.Upa.Impl.Util.Regexp.PortablePattern(patternString.ToLower());
                } else {
                    this.pattern = new Net.Vpc.Upa.Impl.Util.Regexp.PortablePattern(patternString);
                }
            }
            this.nullIsEmpty = nullIsEmpty;
            this.ignoreCase = ignoreCase;
        }

        public virtual bool Accept(string s) {
            if (nullIsEmpty && s == null) {
                s = "";
            }
            return pattern.Matcher(ignoreCase ? s.ToLower() : s).Find();
        }
    }
}
