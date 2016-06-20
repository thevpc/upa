/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.config.decorations;

import net.vpc.upa.config.DecorationTarget;
import net.vpc.upa.config.Decoration;
import java.lang.reflect.Field;
import java.lang.reflect.Method;
import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;
import java.util.logging.Level;
import java.util.logging.Logger;

import net.vpc.upa.impl.util.PlatformUtils;

/**
 *
 * @author vpc
 */
public class DefaultDecorationRepository implements DecorationRepository {

    private Map<String, DefaultDecorationRepositoryTypeInfo> decorationsByType = new HashMap<String, DefaultDecorationRepositoryTypeInfo>();
    private Map<String, Set<String>> typesByDecoration = new HashMap<String, Set<String>>();
    private static final Logger log = Logger.getLogger(DefaultDecorationRepository.class.getName());
    private String name;
    private boolean enableLog;


    public DefaultDecorationRepository(String name, boolean enableLog) {
        this.name = name;
        this.enableLog = enableLog;
    }


    public Decoration[] getMethodDecorations(Method method) {
        return getMethodDecorations(method.getDeclaringClass().getName(), PlatformUtils.getMethodSignature(method));
    }

    public Decoration[] getFieldDecorations(Field field) {
        return getFieldDecorations(field.getDeclaringClass().getName(), field.getName());
    }

    public Decoration[] getTypeDecorations(Class type) {
        return getTypeDecorations(type.getName());
    }

    public Decoration getTypeDecoration(Class type, String annType) {
        return getTypeDecoration(type.getName(), annType);
    }

    public Decoration getTypeDecoration(Class type, Class annType) {
        return getTypeDecoration(type.getName(), annType.getName());
    }

    public Decoration[] getTypeDecorations(Class type, String annType) {
        return getTypeDecorations(type.getName(), annType);
    }

    public Decoration[] getTypeDecorations(String type, String annType) {
        List<Decoration> found = new ArrayList<Decoration>();
        for (Decoration decoration : getTypeDecorations(type)) {
            if (decoration.getName().equals(annType)) {
                found.add(decoration);
            }
        }
        return found.toArray(new Decoration[found.size()]);
    }

    public Decoration getTypeDecoration(String type, String annType) {
        Decoration[] found = getTypeDecorations(type, annType);
        return found.length == 0 ? null : found[0];
    }

    public Decoration[] getMethodDecorations(Method method, String annType) {
        return getMethodDecorations(method.getDeclaringClass().getName(), PlatformUtils.getMethodSignature(method), annType);
    }

    public Decoration[] getMethodDecorations(String type, String method, String annType) {
        List<Decoration> found = new ArrayList<Decoration>();
        for (Decoration decoration : getMethodDecorations(type, method)) {
            if (decoration.getName().equals(annType)) {
                found.add(decoration);
            }
        }
        return found.toArray(new Decoration[found.size()]);
    }

    public Decoration getMethodDecoration(String type, String method, String annType) {
        Decoration[] found = getMethodDecorations(type, method, annType);
        return found.length == 0 ? null : found[0];
    }

    public Decoration getMethodDecoration(Method method, Class annType) {
        return getMethodDecoration(method, annType.getName());
    }

    public Decoration getMethodDecoration(Method method, String annType) {
        for (Decoration decoration : getMethodDecorations(method)) {
            if (decoration.getName().equals(annType)) {
                return decoration;
            }
        }
        return null;
    }

    public Decoration getFieldDecoration(String type, String field, Class annType) {
        return getFieldDecoration(type, field, annType.getName());
    }

    public Decoration getFieldDecoration(String type, String field, String annType) {
        for (Decoration decoration : getFieldDecorations(type, field)) {
            if (decoration.getName().equals(annType)) {
                return decoration;
            }
        }
        return null;
    }

    public Decoration getFieldDecoration(Field field, Class annType) {
        return getFieldDecoration(field, annType.getName());
    }

    public Decoration getFieldDecoration(Field field, String annType) {
        for (Decoration decoration : getFieldDecorations(field)) {
            if (decoration.getName().equals(annType)) {
                return decoration;
            }
        }
        return null;
    }

    public void visit(Decoration d) {
        String typeName = d.getLocationType();
        try {
            if (enableLog && typeName.toLowerCase().contains("upalock")) {
                log.log(Level.SEVERE, "\t[{0}] unexpected registration of {1}", new Object[]{name, typeName});
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
        String methodOrFieldName = d.getLocation();
        DecorationTarget targetType = d.getTarget();
        if (enableLog && log.isLoggable(Level.FINE)) {
            log.log(Level.FINEST, "\t[{0}] register Decoration {1}", new Object[]{name, d});
        }

        DefaultDecorationRepositoryTypeInfo typeInfo = decorationsByType.get(typeName);
        if (typeInfo == null) {
            typeInfo = new DefaultDecorationRepositoryTypeInfo();
            typeInfo.typeName = typeName;
            decorationsByType.put(typeName, typeInfo);
        }
        if (targetType != null) {
            switch (targetType) {
                case TYPE: {
                    if (typeInfo.decorations == null) {
                        typeInfo.decorations = new ArrayList<Decoration>(3);
                    }
                    List<Decoration> m = typeInfo.decorations;
                    int found = -1;
                    for (int i = 0; i < m.size(); i++) {
                        Decoration m1 = m.get(i);
                        if (m1.getName().equals(d.getName()) && m1.getPosition() == d.getPosition()) {
                            found = i;
                            break;
                        }
                    }
                    if (found < 0) {
                        m.add(d);
                    }
                    break;
                }
                case METHOD: {
                    if (typeInfo.methods == null) {
                        typeInfo.methods = new HashMap<String, List<Decoration>>();
                        List<Decoration> m = new ArrayList<Decoration>();
                        typeInfo.methods.put(methodOrFieldName, m);
                        m.add(d);
                    } else {
                        List<Decoration> m = typeInfo.methods.get(methodOrFieldName);
                        if (m == null) {
                            m = new ArrayList<Decoration>();
                            typeInfo.methods.put(methodOrFieldName, m);
                        }
                        int found = -1;
                        for (int i = 0; i < m.size(); i++) {
                            Decoration m1 = m.get(i);
                            if (m1.getName().equals(d.getName()) && m1.getPosition() == d.getPosition()) {
                                found = i;
                                break;
                            }
                        }
                        if (found < 0) {
                            m.add(d);
                        }
                    }
                    break;
                }
                case FIELD: {
                    if (typeInfo.fields == null) {
                        typeInfo.fields = new HashMap<String, List<Decoration>>();
                        List<Decoration> m = new ArrayList<Decoration>();
                        typeInfo.fields.put(methodOrFieldName, m);
                        m.add(d);
                    } else {
                        List<Decoration> m = typeInfo.fields.get(methodOrFieldName);
                        if (m == null) {
                            m = new ArrayList<Decoration>();
                            typeInfo.fields.put(methodOrFieldName, m);
                        }
                        int found = -1;
                        for (int i = 0; i < m.size(); i++) {
                            Decoration m1 = m.get(i);
                            if (m1.getName().equals(d.getName()) && m1.getPosition() == d.getPosition()) {
                                found = i;
                                break;
                            }
                        }
                        if (found < 0) {
                            m.add(d);
                        }
                    }
                    break;
                }
            }
        }
        Set<String> tt = typesByDecoration.get(d.getName());
        if (tt == null) {
            tt = new HashSet<String>();
            typesByDecoration.put(d.getName(), tt);
        }
        tt.add(typeName);
    }

    public String[] getTypesForDecoration(String decorationName) {
        Set<String> found = typesByDecoration.get(decorationName);
        return found == null ? new String[0] : found.toArray(new String[found.size()]);
    }

    public Decoration[] getDeclaredDecorations(String decorationName) {
        List<Decoration> all = new ArrayList<Decoration>();
        Set<String> found = typesByDecoration.get(decorationName);
        if (found != null) {
            for (String t : found) {
                DefaultDecorationRepositoryTypeInfo dd = decorationsByType.get(t);
                if (dd != null) {
                    for (Decoration d : dd.decorations) {
                        if (d.getName().equals(decorationName)) {
                            all.add(d);
                        }
                    }
                }
            }
        }
        Collections.sort(all);
        return all.toArray(new Decoration[0]);
    }

    public Decoration[] getTypeDecorations(String type) {
        DefaultDecorationRepositoryTypeInfo typeInf = decorationsByType.get(type);
        if (typeInf != null && typeInf.decorations != null) {
            return typeInf.decorations.toArray(new Decoration[typeInf.decorations.size()]);
        }
        return new Decoration[0];
    }

    public Decoration[] getMethodDecorations(String type, String method) {
        DefaultDecorationRepositoryTypeInfo typeInf = decorationsByType.get(type);
        if (typeInf != null && typeInf.methods != null) {
            List<Decoration> _deco = typeInf.methods.get(method);
            if (_deco != null) {
                return _deco.toArray(new Decoration[_deco.size()]);
            }
        }
        return new Decoration[0];
    }

    public Decoration[] getFieldDecorations(String type, String field) {
        DefaultDecorationRepositoryTypeInfo typeInf = decorationsByType.get(type);
        if (typeInf != null && typeInf.fields != null) {
            List<Decoration> _deco = typeInf.fields.get(field);
            if (_deco != null) {
                return _deco.toArray(new Decoration[_deco.size()]);
            }
        }
        return new Decoration[0];
    }

}
