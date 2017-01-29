/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.util.classpath;

import java.net.URL;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.vpc.upa.PortabilityHint;
import net.vpc.upa.config.ScanFilter;
//import net.vpc.upa.impl.config.ClassNameFilter;
import net.vpc.upa.impl.config.DefaultConfigFilterItem;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class DefaultConfigFilter implements ClassPathFilter {

    private static final Logger log = Logger.getLogger(DefaultConfigFilter.class.getName());

    private boolean emptyResult = false;
    private List<DefaultConfigFilterItem> items = new ArrayList<DefaultConfigFilterItem>();
    private Map<URL, List<DefaultConfigFilterItem>> cache = new HashMap<URL, List<DefaultConfigFilterItem>>();

//    public static void main(String[] args) {
//        try {
//            ScanFilter r = new ScanFilter("**/*.jar", "net.vpc?.d", true);
//            DefaultConfigFilter t = new DefaultConfigFilter(new ScanFilter[]{r});
//            URL url = new File("/home/vpc/.m2/repository/net/vpc/jperf/1.3/jperf-1.3.jar").toURI().toURL();
////            for (ClassPathResource rr : new ClassPathRoot(url)) {
////                System.out.println(rr);
////            }
//            for (ClassPathResource rr : new ClassPathRoot(new File("/home/wassim"))) {
//                System.out.println(rr);
//            }
//            boolean j = t.acceptLibrary(url);
//            System.out.println(j);
//        } catch (MalformedURLException ex) {
//            Logger.getLogger(DefaultConfigFilter.class.getName()).log(Level.SEVERE, null, ex);
//        }
//    }
    public DefaultConfigFilter(ScanFilter[] filterList) {
        //always add upa classes
        add(new ScanFilter("", "net.vpc.upa.**", true, Integer.MIN_VALUE));
        for (ScanFilter filter : filterList) {
            add(filter);
        }
    }

    public List<DefaultConfigFilterItem> getDefaultConfigFilterItem(URL url) {
        List<DefaultConfigFilterItem> found = cache.get(url);
        if (found == null) {
            found = new ArrayList<DefaultConfigFilterItem>();
            for (DefaultConfigFilterItem defaultConfigFilterItem : items) {
                if (defaultConfigFilterItem.getLibFilter().accept(url)) {
                    PatternListClassNameFilter p = defaultConfigFilterItem.getTypeFilter();
                    if (p.getUserPatterns().length == 0) {
                        found.add(defaultConfigFilterItem);
                    } else {
                        for (String pattern : p.getUserPatterns()) {
                            StringBuilder prefix = new StringBuilder();
                            char[] patternCharArray = pattern.toCharArray();
                            int x = 0;
                            boolean exitWhile = false;
                            while (!exitWhile && x < patternCharArray.length) {
                                char c = patternCharArray[x];
                                switch (c) {
                                    case '*':
                                    case '?': {
                                        if (prefix.length() > 0 && prefix.toString().endsWith(".")) {
                                            //okkay
                                        } else {
                                            while (prefix.length() > 0 && !prefix.toString().endsWith(".")) {
                                                prefix.deleteCharAt(prefix.length() - 1);
                                            }
                                        }
                                        exitWhile = true;
                                        break;
                                    }
                                    default: {
                                        prefix.append(patternCharArray[x]);
                                        break;
                                    }
                                }
                                x++;
                            }
                            if (prefix.length() > 0) {
                                String rr = prefix.toString().replace('.', '/');
                                ClassPathRoot cr = new ClassPathRoot(url);
                                try {
                                    if (cr.contains(rr)) {
                                        found.add(defaultConfigFilterItem);
                                        break;
                                    }
                                } catch (Exception e) {
                                    log.log(Level.SEVERE, null, e);
                                }
                            } else {
                                found.add(defaultConfigFilterItem);
                                break;
                            }
                        }
                    }

                }
            }
            cache.put(url, found);
        }
        return found;
    }

    public boolean acceptLibrary(URL url) {
        List<DefaultConfigFilterItem> found = getDefaultConfigFilterItem(url);
        if (found.size() == 0) {
            if (items.size() == 0) {
                return emptyResult;
            }
            return false;
        }
        return true;
    }

    public boolean acceptClassName(URL url, String className) {
        List<DefaultConfigFilterItem> item = getDefaultConfigFilterItem(url);
        for (DefaultConfigFilterItem y : item) {
            if (y.getTypeFilter().accept(className)) {
                return true;
            }
        }
        if (items.size() == 0) {
            return emptyResult;
        }
        return false;
    }

    public boolean acceptClass(URL url, String className, Class type) {
        return true;
    }

    private void add(ScanFilter filter) {
        DefaultConfigFilterItem defaultConfigFilterItem = new DefaultConfigFilterItem(new PatternListLibNameFilter(new String[]{filter.getLibs()}), new PatternListClassNameFilter(new String[]{filter.getTypes()}));
        items.add(defaultConfigFilterItem);
    }

//    public ClassNameFilter getClassNameFilter(URL url) {
//        for (DefaultConfigFilterItem defaultConfigFilterItem : items) {
//            switch (defaultConfigFilterItem.getLibFilter().accept(url)) {
//                case GRANT: {
//                    return defaultConfigFilterItem.getTypeFilter();
//                }
//                case DENY: {
//                    return null;
//                }
//            }
//        }
//        return null;//new PatternListClassNameFilter(null);
//    }
}
