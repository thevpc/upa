/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.config.decorations;

import net.vpc.upa.config.*;

import java.lang.annotation.Annotation;
import java.lang.reflect.Array;
import java.util.HashMap;
import java.util.Map;

import net.vpc.upa.impl.util.PlatformUtils;

/**
 *
 * @author vpc
 */
public abstract class AbstractDecoration extends AbstractDecorationValue implements Decoration {

    private ConfigInfo mergedConfigInfo = null;
    private Map<String, DecorationValue> mergedAttributes = null;

    public DecorationValue get(String name) {
        Map<String, DecorationValue> a = getAttributes();
        DecorationValue v = a.get(name);
        if (v == null) {
            throw new IllegalArgumentException("Attribute not found " + getName() + "." + name);
        }
        return v;
    }

    @Override
    public boolean isName(String name) {
        return getName().equals(name);
    }

    @Override
    public boolean isName(Class type) {
        return getName().equals(type.getName());
    }

    public Class getType(String name) {
        return (Class) getPrimitive(name);
    }

    public Object getPrimitive(String name) {
        return ((DecorationPrimitiveValue) get(name)).getValue();
    }

    protected DecorationValue convert(Object v, int pos) {
        if (v == null) {
            return new DecorationPrimitiveValue(null, ConfigInfo.DEFAULT);
        }
        if (v instanceof Annotation) {
            return new AnnotationDecoration((Annotation) v, DecorationSourceType.TYPE, PlatformUtils.getUndefinedValue(DecorationTarget.class), null, null, pos);
        } else if (v.getClass().isArray()) {
            int len = Array.getLength(v);
            DecorationValue[] arr = new DecorationValue[len];
            for (int i = 0; i < arr.length; i++) {
                arr[i] = convert(Array.get(v, i), i);
            }
            return new DecorationArray(arr, getConfig());
        } else if (v instanceof DecorationValue) {
            return (DecorationValue) v;
        }
        return new DecorationPrimitiveValue(v, getConfig());
    }

    public Decoration getDecoration(String name) {
        return (Decoration) get(name);
    }

    public DecorationValue[] getArray(String name) {
        DecorationArray t = (DecorationArray) get(name);
        if (t == null) {
            return null;
        }
        return t.getValues();
    }

    public boolean getBoolean(String name) {
        Object primitive = getPrimitive(name);
        if (primitive == null) {
            return false;
        }
        if (primitive instanceof Boolean) {
            return (Boolean) primitive;
        }
        if (primitive instanceof String) {
            return Boolean.parseBoolean(primitive.toString());
        }
        Boolean b = (Boolean) primitive;
        return b.booleanValue();
    }

    public String getString(String name) {
        Object primitive = getPrimitive(name);
        if (primitive == null) {
            return null;
        }
        return primitive.toString();
    }

    public int getInt(String name) {
        Object primitive = getPrimitive(name);
        if (primitive == null) {
            return 0;
        }
        if (primitive instanceof Number) {
            return ((Number) primitive).intValue();
        }
        if (primitive instanceof String) {
            return Integer.parseInt(primitive.toString());
        }
        return (Integer) getPrimitive(name);
    }

    public <T> T getEnum(String name, Class<T> type) {
        return PlatformUtils.convert(getPrimitive(name), type);
    }

    public <T> T[] getPrimitiveArray(String name, Class<T> type) {
        DecorationArray t = (DecorationArray) get(name);
        if (t == null) {
            return null;
        }
        DecorationValue[] arr = t.getValues();
        T[] arr2 = (T[]) Array.newInstance(type, arr.length);
        for (int i = 0; i < arr2.length; i++) {
            arr2[i] = (T) ((DecorationPrimitiveValue) arr[i]).getValue();
        }
        return arr2;
    }

    public Decoration castName(String type) {
        if (getName().equals(type)) {
            throw new ClassCastException("Expected " + type + " but got " + getName());
        }
        return this;
    }

    public Decoration castName(Class type) {
        return castName(type.getName());
    }

    public void merge() {
        HashMap<String, DecorationValue> att = new HashMap<String, DecorationValue>();
        DecorationValue[] alternatives1 = getAlternatives();
        DecorationValue[] alternatives = shrink(alternatives1);
        for (DecorationValue alternative : alternatives) {
            Decoration d = (Decoration) alternative;
            for (Map.Entry<String, DecorationValue> e : d.getAttributes().entrySet()) {
                AbstractDecorationValue v1 = (AbstractDecorationValue) att.get(e.getKey());
                AbstractDecorationValue v2 = (AbstractDecorationValue) e.getValue();
                if (v1 == null) {
                    att.put(e.getKey(), v2);
                } else {
                    v1.addAlternative(v2);
                }
            }
            break;
        }
        for (Map.Entry<String, DecorationValue> e : att.entrySet()) {
            ((AbstractDecoration) e.getValue()).merge();
        }
        if (alternatives.length == 0) {
            DecorationValue last = alternatives1[alternatives1.length - 1];
            mergedAttributes = new HashMap<String, DecorationValue>();
            mergedConfigInfo = new ConfigInfo(last.getConfig().getOrder(),
                    ConfigAction.DELETE, last.getConfig().getPersistenceGroup(), last.getConfig().getPersistenceUnit());
        } else {
            DecorationValue last = alternatives[alternatives.length - 1];
            mergedAttributes = att;
            mergedConfigInfo = new ConfigInfo(last.getConfig().getOrder(),
                    ConfigAction.MERGE, last.getConfig().getPersistenceGroup(), last.getConfig().getPersistenceUnit());
        }
    }

    public ConfigInfo getConfig() {
        if (mergedConfigInfo != null) {
            return mergedConfigInfo;
        }
        return getConfigInfo0();
    }

    protected abstract ConfigInfo getConfigInfo0();

    public Map<String, DecorationValue> getAttributes() {
        if (mergedAttributes != null) {
            return mergedAttributes;
        }
        return getAttributes0();
    }

    protected abstract Map<String, DecorationValue> getAttributes0();

}
