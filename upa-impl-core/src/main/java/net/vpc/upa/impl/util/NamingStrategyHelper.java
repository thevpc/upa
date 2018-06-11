package net.vpc.upa.impl.util;

public class NamingStrategyHelper {
    public static NamingStrategy getNamingStrategy(boolean caseSensitive){
        return caseSensitive?
                CaseSensitiveNamingStrategy.INSTANCE
                :
                CaseInsensitiveNamingStrategy.INSTANCE
                ;
    }
    public static String getUniformValue(boolean caseSensitive,String name){
        return caseSensitive?
                CaseSensitiveNamingStrategy.INSTANCE.getUniformValue(name)
                :
                CaseInsensitiveNamingStrategy.INSTANCE.getUniformValue(name)
                ;
    }

    public static boolean equals(boolean caseSensitive,String o1, String o2){
        return caseSensitive?
                CaseSensitiveNamingStrategy.INSTANCE.equals(o1,o2)
                :
                CaseInsensitiveNamingStrategy.INSTANCE.equals(o1,o2)
                ;
    }
}
