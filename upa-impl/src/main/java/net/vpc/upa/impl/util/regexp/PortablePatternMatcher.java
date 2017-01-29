package net.vpc.upa.impl.util.regexp;

import net.vpc.upa.PortabilityHint;

import java.util.regex.Matcher;

/**
 * @author taha.bensalah@gmail.com on 7/8/16.
 */
public class PortablePatternMatcher {
    /**
     * @PortabilityHint(target = "C#", name = "replace")
     * private System.Text.RegularExpressions.MatchCollection matcher;
     * private int matchIndex=-1;
     * private int lastReplace=0;
     * private string value;
     * <p>
     * public PortablePatternMatcher(System.Text.RegularExpressions.MatchCollection matcher,string value) {
     * this.matcher = matcher;
     * this.value = value;
     * }
     */
    private Matcher matcher;


    @PortabilityHint(target = "C#", name = "ignore")
    public PortablePatternMatcher(Matcher matcher) {
        this.matcher = matcher;
    }

    public boolean find() {
        /**
         *  @PortabilityHint(target = "C#", name = "replace")
         * matchIndex++;
         * return matchIndex<matcher.Count;
         */
        return matcher.find();
    }

    public int start() {
        /**
         *  @PortabilityHint(target = "C#", name = "replace")
         *         return matcher[matchIndex].Index;
         */
        return matcher.start();
    }

    public int end() {
        /**
         *  @PortabilityHint(target = "C#", name = "replace")
         *         return  matcher[matchIndex].Index + matcher [matchIndex].Length;
         */
        return matcher.start();
    }

    public String group(int pos) {
        /**
         *  @PortabilityHint(target = "C#", name = "replace")
         *         return matcher[matchIndex].Groups[pos].Value;
         */
        return matcher.group(pos);
    }

    public String replace(String replacement) {
        /**
         *  @PortabilityHint(target = "C#", name = "replace")
         *         System.Text.StringBuilder sb = new System.Text.StringBuilder();
         *         sb.Append(value.Substring(lastReplace,Start()-lastReplace));
         *         sb.Append(replacement);
         *         lastReplace=End()+1;
         *         return sb.ToString();
         */
        {
            StringBuffer sb = new StringBuffer();
            StringBuilder rep = new StringBuilder();
            for (char c : replacement.toCharArray()) {
                switch (c) {
                    case '$':
                    case '\\': {
                        rep.append('\\').append(c);
                        break;
                    }
                    default: {
                        rep.append(c);
                        break;
                    }
                }
            }
            matcher.appendReplacement(sb, rep.toString());
            return sb.toString();
        }
    }

    public String tail() {
        /**
         *  @PortabilityHint(target = "C#", name = "replace")
         *         System.Text.StringBuilder sb = new System.Text.StringBuilder();
         *         sb.Append(value.Substring(lastReplace));
         *         lastReplace=value.Length+1;
         *         return sb.ToString();
         */
        {
            StringBuffer sb = new StringBuffer();
            matcher.appendTail(sb);
            return sb.toString();
        }
    }

    public boolean matches() {
        return find();
    }

}
