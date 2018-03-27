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
public class RegexpStringFilter implements ObjectFilter<String> {

    private String patternString;
    private PortablePattern pattern;
    private boolean nullIsEmpty;
    private boolean ignoreCase;

    public RegexpStringFilter(String patternString, boolean nullIsEmpty, boolean ignoreCase) {
        this.patternString = (nullIsEmpty && patternString == null) ? "" : patternString;
        this.ignoreCase=ignoreCase;
        if(patternString!=null){
            if(ignoreCase){
                this.pattern = new PortablePattern(patternString.toLowerCase());
            }else {
                this.pattern = new PortablePattern(patternString);
            }
        }
        this.nullIsEmpty = nullIsEmpty;
        this.ignoreCase = ignoreCase;
    }

    public boolean accept(String s) {
        if (nullIsEmpty && s == null) {
            s = "";
        }
        return pattern.matcher(ignoreCase?s.toLowerCase():s).find();
    }

}
