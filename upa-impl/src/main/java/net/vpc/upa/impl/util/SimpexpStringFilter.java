/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.util;

import net.vpc.upa.filters.ObjectFilter;
import net.vpc.upa.impl.util.regexp.PortablePattern;


/**
 *
 * @author taha.bensalah@gmail.com
 */
public class SimpexpStringFilter implements ObjectFilter<String> {

    private String patternString;
    private PortablePattern pattern;
    private boolean nullIsEmpty;
    private boolean ignoreCase;

    public SimpexpStringFilter(String patternString, boolean nullIsEmpty, boolean ignoreCase) {
        this.patternString = (nullIsEmpty && patternString == null) ? "" : patternString;
        String pattern = StringUtils.simpexpToRegexp(patternString, PatternType.DOT_PATH);
        this.pattern = this.patternString == null ? null : new PortablePattern(ignoreCase?pattern.toLowerCase():pattern);
        this.nullIsEmpty = nullIsEmpty;
        this.ignoreCase = ignoreCase;
    }

    public boolean accept(String s) {
        if (nullIsEmpty && s == null) {
            s = "";
        }
        return pattern.matcher(ignoreCase?s.toLowerCase():s).matches();
    }

}
