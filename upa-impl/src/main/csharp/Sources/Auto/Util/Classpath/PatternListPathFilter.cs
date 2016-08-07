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



namespace Net.Vpc.Upa.Impl.Util.Classpath
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 12/16/12 1:05 PM
     */
    public class PatternListPathFilter : Net.Vpc.Upa.Impl.Config.ClassNameFilter {

        internal Net.Vpc.Upa.Impl.Util.Regexp.PortablePattern[] patterns;

        public PatternListPathFilter(string[] filter) {
            if (filter != null) {
                patterns = new Net.Vpc.Upa.Impl.Util.Regexp.PortablePattern[filter.Length];
                for (int i = 0; i < filter.Length; i++) {
                    string f = filter[i];
                    if (f != null) {
                        f = f.Trim();
                        if ((f).Length == 0) {
                            f = null;
                        }
                    }
                    if (f != null) {
                        patterns[i] = new Net.Vpc.Upa.Impl.Util.Regexp.PortablePattern(Convert(f));
                    }
                }
            }
        }

        public static string Convert(string s) {
            int i = 0;
            char[] cc = s.ToCharArray();
            System.Text.StringBuilder sb = new System.Text.StringBuilder("^");
            while (i < cc.Length) {
                char c = cc[i];
                switch(c) {
                    case '.':
                    case '!':
                    case '$':
                    case '?':
                    case '+':
                    case '[':
                    case ']':
                    case '(':
                    case ')':
                        {
                            sb.Append('\\').Append(c);
                            break;
                        }
                    case '*':
                        {
                            if (i + 1 < cc.Length && cc[i + 1] == '*') {
                                i++;
                                sb.Append("[^/]+");
                            } else {
                                sb.Append(".+");
                            }
                            break;
                        }
                    default:
                        {
                            sb.Append(c);
                            break;
                        }
                }
                i++;
            }
            sb.Append('$');
            return sb.ToString();
        }

        public virtual bool Accept(string cls) {
            if (patterns == null || patterns.Length == 0) {
                return true;
            }
            foreach (Net.Vpc.Upa.Impl.Util.Regexp.PortablePattern pattern in patterns) {
                if (pattern == null || pattern.Matcher(cls).Matches()) {
                    return true;
                }
            }
            return false;
        }
    }
}
