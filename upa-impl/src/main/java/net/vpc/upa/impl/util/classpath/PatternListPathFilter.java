package net.vpc.upa.impl.util.classpath;

import java.util.regex.Pattern;
import net.vpc.upa.impl.config.ClassNameFilter;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 12/16/12 1:05 PM
 */
public class PatternListPathFilter implements ClassNameFilter {
    Pattern[] patterns;

    public PatternListPathFilter(String[] filter) {
        if (filter != null) {
            patterns = new Pattern[filter.length];
            for (int i = 0; i < filter.length; i++) {
                String f = filter[i];
                if (f != null) {
                    f = f.trim();
                    if (f.length() == 0) {
                        f = null;
                    }
                }
                if (f != null) {
                    patterns[i] = Pattern.compile(convert(f));
                }
            }
        }
    }

    public static String convert(String s) {
        int i = 0;
        char[] cc = s.toCharArray();
        StringBuilder sb = new StringBuilder("^");
        while (i < cc.length) {
            char c = cc[i];
            switch (c) {
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
                    sb.append('\\').append(c);
                    break;
                }
                case '*': {
                    if (i + 1 < cc.length && cc[i + 1] == '*') {
                        i++;
                        sb.append("[^/]+");
                    } else {
                        sb.append(".+");
                    }
                    break;
                }
                default: {
                    sb.append(c);
                    break;
                }
            }
            i++;
        }
        sb.append('$');
        return sb.toString();
    }

    public boolean accept(String cls) {
        if (patterns == null || patterns.length == 0) {
            return true;
        }
        for (Pattern pattern : patterns) {
            if (pattern == null || pattern.matcher(cls).matches()) {
                return true;
            }
        }
        return false;
    }
}
