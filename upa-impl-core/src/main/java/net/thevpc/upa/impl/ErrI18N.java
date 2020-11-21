package net.thevpc.upa.impl;

import java.util.Map;
import net.thevpc.upa.UPAI18n;
import net.thevpc.upa.UPAObject;
import net.thevpc.upa.types.I18NString;

public class ErrI18N implements UPAI18n{
    public static final UPAI18n INSTANCE=new ErrI18N();
    private ErrI18N(){

    }
    @Override
    public String get(UPAObject s, Map<String,Object> params) {
        return get(s.getI18NTitle(),params);
    }

    @Override
    public String get(I18NString s, Map<String,Object> params) {
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
