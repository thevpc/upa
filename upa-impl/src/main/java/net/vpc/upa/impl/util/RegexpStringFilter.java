/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.util;

import java.util.regex.Pattern;

/**
 *
 * @author vpc
 */
public class RegexpStringFilter implements ObjectFilter<String> {

    private String patternString;
    private Pattern pattern;
    private boolean nullIsEmpty;
    private boolean ignoreCase;

    public RegexpStringFilter(String patternString, boolean nullIsEmpty, boolean ignoreCase) {
        this.patternString = (nullIsEmpty && patternString == null) ? "" : patternString;
        if(patternString!=null){
            if(ignoreCase){
                this.pattern = Pattern.compile(patternString,Pattern.CASE_INSENSITIVE);
            }else {
                this.pattern = Pattern.compile(patternString);
            }
        }
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
