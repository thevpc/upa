package net.vpc.upa;

import net.vpc.upa.types.I18NString;

public interface UPAI18n {
    String get(UPAObject s, Object... params);

    String get(I18NString s, Object... params);

    String getEnum(Object obj);
}
