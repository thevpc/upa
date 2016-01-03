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

        internal System.Text.RegularExpressions.Regex[] patterns;

        public PatternListPathFilter(string[] filter) {
            if (filter != null) {
                patterns = new System.Text.RegularExpressions.Regex[filter.Length];
                for (int i = 0; i < filter.Length; i++) {
                    string f = filter[i];
                    if (f != null) {
                        f = f.Trim();
                        if ((f).Length == 0) {
                            f = null;
                        }
                    }
                    if (f != null) {
                        patterns[i] = new System.Text.RegularExpressions.Regex(Convert(f));
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
            foreach (System.Text.RegularExpressions.Regex pattern in patterns) {
                if (pattern == null || (pattern.Match(cls)).Success) {
                    return true;
                }
            }
            return false;
        }
    }
}
