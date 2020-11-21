package net.thevpc.upa.impl.util;

/**
 * Created by vpc on 8/6/16.
 */
public interface VarContext extends Converter<String,String> {
    boolean isDeclared(String name);
    void declare(String name, String value);
    String eval(String expression);
}
