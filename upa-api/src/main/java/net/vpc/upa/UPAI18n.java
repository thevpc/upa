package net.vpc.upa;

import java.util.Map;
import net.vpc.upa.types.I18NString;

public interface UPAI18n {
    String get(UPAObject s, Map<String,Object> params);

    String get(I18NString s, Map<String,Object> params);

    String getEnum(Object obj);
}
