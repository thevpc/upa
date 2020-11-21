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
    public class PortablePatternMatcher {

        private System.Text.RegularExpressions.MatchCollection matcher;
        private int matchIndex=-1;
        private int lastReplace=0;
        private string value;
        
        public PortablePatternMatcher(System.Text.RegularExpressions.MatchCollection matcher,string value) {
        this.matcher = matcher;
        this.value = value;
        }




        public virtual bool Find() {
            matchIndex++;
            return matchIndex<matcher.Count;
        }

        public virtual int Start() {
            return matcher[matchIndex].Index;
        }

        public virtual int End() {
            return  matcher[matchIndex].Index + matcher [matchIndex].Length;
        }

        public virtual string Group(int pos) {
            return matcher[matchIndex].Groups[pos].Value;
        }

        public virtual string Replace(string replacement) {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(value.Substring(lastReplace,Start()-lastReplace));
            sb.Append(replacement);
            lastReplace=End()+1;
            return sb.ToString();
        }

        public virtual string Tail() {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(value.Substring(lastReplace));
            lastReplace=value.Length+1;
            return sb.ToString();
        }

        public virtual bool Matches() {
            return Find();
        }
    }
}
