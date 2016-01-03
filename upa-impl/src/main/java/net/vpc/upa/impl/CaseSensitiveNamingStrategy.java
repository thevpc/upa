package net.vpc.upa.impl;

import net.vpc.upa.NamingStrategy;

/**
* Created by vpc on 12/20/13.
*/
class CaseSensitiveNamingStrategy implements NamingStrategy {
    public String getUniformValue(String name) {
        return name;
    }

    public boolean equals(String o1, String o2) {
        return o1.equals(o2);
    }
}
