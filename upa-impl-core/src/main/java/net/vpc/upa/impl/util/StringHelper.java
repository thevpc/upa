/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.util;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class StringHelper {
    public static final StringHelper EMPTY_STRING=new StringHelper("", "", "", true);

    
    private String undefinedValue="";
    private String emptyValue="";
    private String nullValue="";
    private boolean trim=true;
    public StringHelper(String undefinedValue,String emptyValue,String nullValue,boolean trim) {
        this.undefinedValue=undefinedValue;
        this.emptyValue=emptyValue;
        this.nullValue=nullValue;
        this.trim=trim;
    }
    public String format(String s){
        if(StringUtils.isUndefined(s)){
            return undefinedValue;
        }
        if(s==null){
            return nullValue;
        }
        if(trim){
            s=s.trim();
        }
        if(s.length()==0){
            return emptyValue;
        }
        return s;
    }
}
