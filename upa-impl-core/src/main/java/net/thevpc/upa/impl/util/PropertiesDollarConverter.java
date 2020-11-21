package net.thevpc.upa.impl.util;

import net.thevpc.upa.Properties;

public class PropertiesDollarConverter implements Converter<String, String> {
    Properties p;

    public PropertiesDollarConverter(Properties p) {
        this.p = p;
    }

    @Override
    public String convert(String s) {
        Object object = p.getObject(s,null);
        if(object==null){
            object=System.getProperty(s);
            if(object==null) {
                return "${" + s + "}";
            }
        }
        return String.valueOf(object);
    }
}
