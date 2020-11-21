package net.thevpc.upa.impl.util.regexp;

import java.util.regex.Pattern;

/**
 * @author taha.bensalah@gmail.com on 7/8/16.
 */
public class PortablePattern {
    private Pattern pattern;

    public PortablePattern(String pattern) {
        this.pattern = Pattern.compile(pattern);
    }

    public PortablePatternMatcher matcher(String value){
        /**
         * @PortabilityHint(target = "C#", name = "replace")
         * return new net.thevpc.upa.Impl.Util.Regexp.PortablePatternMatcher(pattern.Matches(@value),@value);
         */
        return new PortablePatternMatcher(pattern.matcher(value));
    }

}
