package net.vpc.upa.impl.util.regexp;

import net.vpc.upa.PortabilityHint;

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
         * return new Net.Vpc.Upa.Impl.Util.Regexp.PortablePatternMatcher(pattern.Matches(@value),@value);
         */
        return new PortablePatternMatcher(pattern.matcher(value));
    }

}
