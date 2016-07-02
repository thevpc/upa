/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.util;

import net.vpc.upa.filters.ObjectFilter;

import java.util.regex.Pattern;

/**
 *
 * @author vpc
 */
public class SimpexpStringFilter implements ObjectFilter<String> {

    private String patternString;
    private Pattern pattern;
    private boolean nullIsEmpty;
    private boolean ignoreCase;

    public SimpexpStringFilter(String patternString, boolean nullIsEmpty, boolean ignoreCase) {
        this.patternString = (nullIsEmpty && patternString == null) ? "" : patternString;
        this.pattern = this.patternString == null ? null : Pattern.compile(StringUtils.simpexpToRegexp(patternString), (ignoreCase ? Pattern.CASE_INSENSITIVE : 0));
        this.nullIsEmpty = nullIsEmpty;
        this.ignoreCase = ignoreCase;
    }

    public boolean accept(String s) {
        if (nullIsEmpty && s == null) {
            s = "";
        }
        return pattern.matcher(s).matches();
    }

}
