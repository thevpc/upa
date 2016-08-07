package net.vpc.upa.impl.util;

/**
 * Created by vpc on 8/6/16.
 */
public interface VarContext extends Converter<String,String> {
    public boolean isDeclared(String name);
    public void declare(String name,String value);
    public String eval(String expression);
}
