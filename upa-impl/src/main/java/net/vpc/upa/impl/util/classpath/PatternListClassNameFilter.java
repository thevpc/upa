package net.vpc.upa.impl.util.classpath;

import java.util.ArrayList;
import java.util.List;
import java.util.regex.Pattern;
import net.vpc.upa.impl.config.ClassNameFilter;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 12/16/12 1:05 PM
 */
public class PatternListClassNameFilter implements ClassNameFilter {

    private Pattern[] patterns;
    private String[] userPatterns;

    public PatternListClassNameFilter(String[] filter) {
        List<Pattern> patternsList = new ArrayList<Pattern>();
        List<String> userPatternsList = new ArrayList<String>();
        if (filter != null) {
            for (int i = 0; i < filter.length; i++) {
                String f = filter[i];
                if (f != null) {
                    f = f.trim();
                    if (f.length() == 0) {
                        f = null;
                    }
                }
                if (f != null) {
                    patternsList.add(Pattern.compile(convert(f)));
                    userPatternsList.add(f);
                }
            }
        }
        patterns = patternsList.toArray(new Pattern[patternsList.size()]);
        userPatterns = userPatternsList.toArray(new String[userPatternsList.size()]);
    }

    public static boolean isExpression(String s) {
        if (s == null) {
            return false;
        }
        int i = 0;
        char[] cc = s.toCharArray();
        while (i < cc.length) {
            char c = cc[i];
            switch (c) {
                case '.':
                case '!':
                case '$': {
                    //ignore
                    break;
                }
                case '*': {
                    return true;
                }
            }
            i++;
        }
        return false;
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
                case '$': {
                    sb.append('\\').append(c);
                    break;
                }
                case '*': {
                    if (i + 1 < cc.length && cc[i + 1] == '*') {
                        i++;
                        sb.append("[a-zA-Z_0-9$.]+");
                    } else {
                        sb.append("[a-zA-Z_0-9$]+");
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

    public Pattern[] getPatterns() {
        return patterns;
    }

    public String[] getUserPatterns() {
        return userPatterns;
    }
    

}
