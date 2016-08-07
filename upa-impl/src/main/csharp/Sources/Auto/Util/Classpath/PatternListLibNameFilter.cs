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
    public class PatternListLibNameFilter {

        private Net.Vpc.Upa.Impl.Util.Regexp.PortablePattern[] patterns;

        private string[] patternStrings;

        public PatternListLibNameFilter(string[] filter) {
            if (filter != null) {
                patternStrings = new string[filter.Length];
                patterns = new Net.Vpc.Upa.Impl.Util.Regexp.PortablePattern[filter.Length];
                for (int i = 0; i < filter.Length; i++) {
                    string f = filter[i];
                    if (f != null) {
                        f = f.Trim();
                        if ((f).Length == 0) {
                            f = null;
                        }
                    }
                    patternStrings[i] = f;
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
                    case '\\':
                        {
                            sb.Append('\\').Append(c);
                            break;
                        }
                    case '*':
                        {
                            if (i + 1 < cc.Length && cc[i + 1] == '*') {
                                i++;
                                sb.Append(".+");
                            } else {
                                sb.Append("[^\\/]+");
                            }
                            break;
                        }
                    default:
                        {
                            sb.Append(c);
                        }
                        break;
                }
                i++;
            }
            sb.Append('$');
            return sb.ToString();
        }

        public virtual bool Accept(string url) {
            string cls = null;
            if (url != null) {
                cls = url.ToString();
            }
            if (patterns == null || patterns.Length == 0) {
                return true;
            }
            int i = 0;
            foreach (Net.Vpc.Upa.Impl.Util.Regexp.PortablePattern pattern in patterns) {
                if (pattern == null || pattern.Matcher(cls).Matches()) {
                    //                System.out.println("Lib : "+url+" :: GRANT "+pattern+" : "+patternStrings[i]);
                    return true;
                } else {
                }
                //                System.out.println("Lib : "+url+" :: DENY "+pattern+" : "+patternStrings[i]);
                i++;
            }
            return false;
        }
    }
}
