/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.config.decorations;

import net.vpc.upa.config.DecorationTarget;
import net.vpc.upa.config.DecorationSourceType;
import net.vpc.upa.config.Decoration;
import net.vpc.upa.config.DecorationValue;
import java.lang.annotation.Annotation;
import java.lang.reflect.Method;
import java.util.HashMap;
import java.util.Map;
import net.vpc.upa.config.Config;
import net.vpc.upa.config.ConfigAction;
import net.vpc.upa.config.ConfigInfo;
import net.vpc.upa.impl.util.UPAUtils;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public final class AnnotationDecoration extends AbstractDecoration {

    private Annotation ann;
    private DecorationSourceType decorationSourceType;
    private DecorationTarget targetType;
    private String type;
    private String location;
    private ConfigInfo configInfo;
    private Map<String, DecorationValue> values = null;
    private int position;

    public AnnotationDecoration(Annotation ann, DecorationSourceType locationType, DecorationTarget targetType, String type, String location, int position, ConfigInfo configInfo) {
        this.ann = ann;
        this.decorationSourceType = locationType;
        this.targetType = targetType;
        this.type = type;
        this.location = location;
        this.configInfo = configInfo;
        this.position = position;
    }

    public AnnotationDecoration(Annotation ann, DecorationSourceType locationType, DecorationTarget targetType, String type, String location, int position) {
        this(ann, locationType, targetType, type, location, position, null);
    }

    public String getName() {
        return ann.annotationType().getName();
    }

    public int getPosition() {
        return position;
    }

    protected ConfigInfo getConfigInfo0() {
        if (configInfo == null) {
            Decoration config = getDecoration("config");
            if (config != null) {
                Decoration c = (Decoration) config;
                if (c.getName().equals(Config.class.getName())) {
                    configInfo = new ConfigInfo(c.getInt("order"),
                            ConfigAction.valueOf(c.getString("action")),
                            c.getString("persistenceGroup"),
                            c.getString("persistenceUnit")
                    );
                }
            }

        }
        return configInfo;
    }

    public String getLocation() {
        return location;
    }

    public DecorationSourceType getDecorationSourceType() {
        return decorationSourceType;
    }

    public DecorationTarget getTarget() {
        return targetType;
    }

    public String getLocationType() {
        return type;
    }

    public ConfigInfo getConfig() {
        if (configInfo == null) {
            try {
                Method method = ann.annotationType().getMethod("config");
                if (method != null && method.getReturnType().getName().equals(Config.class.getName())) {
                    Object t = method.invoke(ann, UPAUtils.UNDEFINED_ARRAY);
                    AnnotationDecoration c = new AnnotationDecoration((Annotation) t, null, null, null, null,0);
                    configInfo = new ConfigInfo(c.getInt("order"),
                            ConfigAction.valueOf(c.getString("action")),
                            c.getString("persistenceGroup"),
                            c.getString("persistenceUnit")
                    );
                }
            } catch (Exception e) {
                //ignore
//                e.printStackTrace();
            }
        }
        if (configInfo == null) {
            configInfo = new ConfigInfo(Integer.MIN_VALUE, ConfigAction.MERGE, null, null);
        }
        return configInfo;
    }

    protected Map<String, DecorationValue> getAttributes0() {
        if (values == null) {

            Map<String, DecorationValue> map = new HashMap<String, DecorationValue>();
            int pos=0;
            for (Method declaredMethod : ann.annotationType().getMethods()) {
                String mname = declaredMethod.getName();
                if (declaredMethod.getParameterCount() == 0 && !mname.equals("equals") && !mname.equals("hashCode") && !mname.equals("toString")) {
//                    System.out.println(declaredMethod);
                    try {
                        Object v = declaredMethod.invoke(ann,new Object[0]);
                        map.put(declaredMethod.getName(), convert(v,pos));
                    } catch (Exception ex) {
                        throw new IllegalArgumentException(ex);
                    }
                }
                pos++;
            }
            values = map;
        }
        return values;
    }

    @Override
    public String toString() {
        StringBuilder b = new StringBuilder();
        b.append("@").append(getName());
        b.append("[");
        if (targetType == null) {
            b.append("EMBEDDED").append(":");
        }
        b.append(type);
        if (targetType == DecorationTarget.METHOD || targetType == DecorationTarget.FIELD) {
            b.append(".").append(location);
        }
        if (!getConfig().equals(ConfigInfo.DEFAULT)) {
            b.append(";");
            b.append(getConfig());
        }
        b.append("](");
        String s = getAttributes().toString();
        b.append(s.subSequence(1, s.length() - 1));
        b.append(")");
        return b.toString();
    }

}
