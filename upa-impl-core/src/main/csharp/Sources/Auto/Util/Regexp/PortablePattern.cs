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



namespace Net.TheVpc.Upa.Impl.Util.Regexp
{


    /**
     * @author taha.bensalah@gmail.com on 7/8/16.
     */
    public class PortablePattern {

        private System.Text.RegularExpressions.Regex pattern;

        public PortablePattern(string pattern) {
            this.pattern = new System.Text.RegularExpressions.Regex(pattern);
        }

        public virtual Net.TheVpc.Upa.Impl.Util.Regexp.PortablePatternMatcher Matcher(string @value) {
            return new Net.TheVpc.Upa.Impl.Util.Regexp.PortablePatternMatcher(pattern.Matches(@value),@value);
        }
    }
}
