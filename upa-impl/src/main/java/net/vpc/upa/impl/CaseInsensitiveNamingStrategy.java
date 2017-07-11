package net.vpc.upa.impl;

import net.vpc.upa.NamingStrategy;

/**
* Created by vpc on 12/20/13.
*/
class CaseInsensitiveNamingStrategy implements NamingStrategy {
    public String getUniformValue(String name) {
//        if (name == null) {
//            throw new UPAIllegalArgumentException("name should not be null");
//        }
        return name.toUpperCase();
    }

    public boolean equals(String o1, String o2) {
        return o1.equalsIgnoreCase(o2);
    }
}
