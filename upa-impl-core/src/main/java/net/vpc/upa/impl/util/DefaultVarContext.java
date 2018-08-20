package net.vpc.upa.impl.util;

import java.util.HashMap;
import java.util.Map;

/**
 * Created by vpc on 8/6/16.
 */
public class DefaultVarContext implements VarContext {
    private Map<String, String> properties = new HashMap<String, String>();
    private VarContext parent;

    public DefaultVarContext() {

    }

    public DefaultVarContext(net.vpc.upa.Properties properties) {
        declareAll(properties);
    }

    public DefaultVarContext(java.util.Properties properties) {
        declareAll(properties);
    }

    public DefaultVarContext(VarContext parent) {
        this.parent = parent;
    }

    @Override
    public boolean isDeclared(String name) {
        if (properties.containsKey(name)) {
            return true;
        }
        if (parent != null) {
            return parent.isDeclared(name);
        }
        return false;
    }

    public void declareAll(net.vpc.upa.Properties properties) {
        if (properties != null) {
            for (String name : properties.keySet()) {
                Object v = properties.getObject(name);
                declare(name, v == null ? null : String.valueOf(v));
            }
        }
    }

    public void declareAll(java.util.Properties properties) {
        if (properties != null) {
            for (Map.Entry<Object, Object> p : System.getProperties().entrySet()) {
                declare((String) p.getKey(),(String) p.getValue());
            }
        }
    }

    @Override
    public void declare(String name, String value) {
        if (value == null) {
            properties.remove(name);
        } else {
            properties.put(name, value);
        }
    }

    @Override
    public String eval(String expression) {
        return StringUtils.replaceDollarVars(expression, this);
    }

    @Override
    public String convert(String name) {
        String ss = properties.get(name);
        if (ss == null) {
            if (parent != null && parent.isDeclared(name)) {
                ss = parent.convert(name);
            }
            if (ss == null) {
                return "${" + name + "}";
            }
        }
        return ss;
    }
}
