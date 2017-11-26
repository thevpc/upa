package net.vpc.upa.impl;

import net.vpc.upa.UPAI18n;
import net.vpc.upa.UPAObject;
import net.vpc.upa.types.I18NString;

public class ErrI18N implements UPAI18n{
    public static final UPAI18n INSTANCE=new ErrI18N();
    private ErrI18N(){

    }
    @Override
    public String get(UPAObject s, Object... params) {
        return get(s.getI18NString());
    }

    @Override
    public String get(I18NString s, Object... params) {
        if(s==null){
            return "null!!";
        }
        String d = s.getDefaultValue();
        if (d == null) {
            return s.toString() + "!!";
        }
        return d;
    }

    @Override
    public String getEnum(Object obj) {
        if (obj == null) {
            return "";
        }
        String t = obj.getClass().getName();
        String r = ("Enum." + t + "[" + obj + "]!!");
        return obj.toString();
    }
}
