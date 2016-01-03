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



using System.Linq;
namespace Net.Vpc.Upa.Impl.Util.Classpath
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 12/16/12 1:05 PM
     */
    public class PatternListClassNameFilter : Net.Vpc.Upa.Impl.Config.ClassNameFilter {

        private System.Text.RegularExpressions.Regex[] patterns;

        private string[] userPatterns;

        public PatternListClassNameFilter(string[] filter) {
            System.Collections.Generic.IList<System.Text.RegularExpressions.Regex> patternsList = new System.Collections.Generic.List<System.Text.RegularExpressions.Regex>();
            System.Collections.Generic.IList<string> userPatternsList = new System.Collections.Generic.List<string>();
            if (filter != null) {
                for (int i = 0; i < filter.Length; i++) {
                    string f = filter[i];
                    if (f != null) {
                        f = f.Trim();
                        if ((f).Length == 0) {
                            f = null;
                        }
                    }
                    if (f != null) {
                        patternsList.Add(new System.Text.RegularExpressions.Regex(Convert(f)));
                        userPatternsList.Add(f);
                    }
                }
            }
            patterns = patternsList.ToArray();
            userPatterns = userPatternsList.ToArray();
        }

        public static bool IsExpression(string s) {
            if (s == null) {
                return false;
            }
            int i = 0;
            char[] cc = s.ToCharArray();
            while (i < cc.Length) {
                char c = cc[i];
                switch(c) {
                    case '.':
                    case '!':
                    case '$':
                        {
                            //ignore
                            break;
                        }
                    case '*':
                        {
                            return true;
                        }
                }
                i++;
            }
            return false;
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
                        {
                            sb.Append('\\').Append(c);
                            break;
                        }
                    case '*':
                        {
                            if (i + 1 < cc.Length && cc[i + 1] == '*') {
                                i++;
                                sb.Append("[a-zA-Z_0-9$.]+");
                            } else {
                                sb.Append("[a-zA-Z_0-9$]+");
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

        public virtual System.Text.RegularExpressions.Regex[] GetPatterns() {
            return patterns;
        }

        public virtual string[] GetUserPatterns() {
            return userPatterns;
        }
    }
}
