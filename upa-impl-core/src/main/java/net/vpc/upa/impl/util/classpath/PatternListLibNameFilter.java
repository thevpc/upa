package net.vpc.upa.impl.util.classpath;

import net.vpc.upa.impl.util.regexp.PortablePattern;

import java.net.URL;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 12/16/12 1:05 PM
 */
public class PatternListLibNameFilter  {
    private PortablePattern[] patterns;
    private String[] patternStrings;

    public PatternListLibNameFilter(String[] filter) {
        if (filter != null) {
            patternStrings = new String[filter.length];
            patterns = new PortablePattern[filter.length];
            for (int i = 0; i < filter.length; i++) {
                String f = filter[i];
                if (f != null) {
                    f = f.trim();
                    if (f.length() == 0) {
                        f = null;
                    }
                }
                patternStrings[i]=f;
                if (f != null) {
                    patterns[i] = new PortablePattern(convert(f));
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
                case '\\': 
                {
                    sb.append('\\').append(c);
                    break;
                }
                case '*': {
                    if (i + 1 < cc.length && cc[i + 1] == '*') {
                        i++;
                        sb.append(".+");
                    } else {
                        sb.append("[^\\/]+");
                    }
                    break;
                }
                default: {
                    sb.append(c);
                }
            }
            i++;
        }
        sb.append('$');
        return sb.toString();
    }

    public boolean accept(URL url) {
        String cls=null;
        if(url!=null){
            cls=url.toString();
        }
        if (patterns == null || patterns.length == 0) {
            return true;
        }
        int i=0;
        for (PortablePattern pattern : patterns) {
            if (pattern == null || pattern.matcher(cls).matches()) {
//                System.out.println("Lib : "+url+" :: GRANT "+pattern+" : "+patternStrings[i]);
                return true;
            }else{
//                System.out.println("Lib : "+url+" :: DENY "+pattern+" : "+patternStrings[i]);
            }
            i++;
        }
        return false;
    }
}
