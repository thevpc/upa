package net.vpc.upa.impl.util;

/**
* Created by vpc on 12/20/13.
*/
public class CaseSensitiveNamingStrategy implements NamingStrategy {
    public static final NamingStrategy INSTANCE=new CaseSensitiveNamingStrategy();
    public String getUniformValue(String name) {
        return name;
    }

    public boolean equals(String o1, String o2) {
        return o1.equals(o2);
    }
}
