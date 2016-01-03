/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.util;

/**
 *
 * @author vpc
 */
public class EqualsStringFilter implements ObjectFilter<String>{
    private String base;
    private boolean nullIsEmpty;
    private boolean ignoreCase;

    public EqualsStringFilter(String base, boolean nullIsEmpty, boolean ignoreCase) {
        this.base = base;
        this.nullIsEmpty = nullIsEmpty;
        this.ignoreCase = ignoreCase;
    }

    

    public boolean accept(String s) {
        String base0=base;
        if(nullIsEmpty){
            if(base0==null){
                base0="";
            }
            if(s==null){
                s="";
            }
        }
        if(ignoreCase){
            if(base0!=null){
                base0=base0.toLowerCase();
            }
            if(s!=null){
                s=s.toLowerCase();
            }
        }
        return (base0==null && s==null) || (base0!=null && base0.equals(s));
    }
    
}
