/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.config.decorations;

import net.thevpc.upa.config.Decoration;
import net.thevpc.upa.config.DecorationTarget;

import java.lang.reflect.Field;
import java.lang.reflect.Method;
import java.util.*;
import java.util.logging.Level;
import java.util.logging.Logger;

import net.thevpc.upa.config.DecorationValue;
import net.thevpc.upa.impl.util.PlatformUtils;

/**
 * @author taha.bensalah@gmail.com
 */
public class DefaultDecorationRepository implements DecorationRepository {

    private static final Logger log = Logger.getLogger(DefaultDecorationRepository.class.getName());
    private final Map<String, DefaultDecorationRepositoryTypeInfo> decorationsByType = new HashMap<String, DefaultDecorationRepositoryTypeInfo>();
    private final Map<String, Set<String>> typesByDecoration = new HashMap<String, Set<String>>();
    private final String name;
    private final boolean enableLog;

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

    public Decoration getTypeDecoration(Class type, String decorationType) {
        return getTypeDecoration(type.getName(), decorationType);
    }

    public Decoration getTypeDecoration(Class type, Class decorationType) {
        return getTypeDecoration(type.getName(), decorationType.getName());
    }

    public Decoration[] getTypeDecorations(Class type, String annType) {
        return getTypeDecorations(type.getName(), annType);
    }

    public Decoration[] getTypeDecorations(String type, String decorationType) {
        List<Decoration> found = new ArrayList<Decoration>();
        for (Decoration decoration : getTypeDecorations(type)) {
            if (decoration.getName().equals(decorationType)) {
                found.add(decoration);
            }
        }
        return found.toArray(new Decoration[found.size()]);
    }

    @Override
    public Decoration[] getTypeRepeatableDecorations(Class type, Class decorationType, Class arrayDecorationType) {
        return getTypeRepeatableDecorations(type.getName(), decorationType.getName(), arrayDecorationType == null ? null : arrayDecorationType.getName());
    }

    @Override
    public Decoration[] getTypeRepeatableDecorations(String type, String decorationType, String arrayDecorationType) {
        List<Decoration> found = new ArrayList<Decoration>();
        for (Decoration decoration : getTypeDecorations(type)) {
            if (decoration.getName().equals(decorationType)) {
                found.add(decoration);
            } else if (arrayDecorationType != null && decoration.getName().equals(arrayDecorationType)) {
                found.addAll(Arrays.asList(expandRepeatableDecorations(decoration)));
            }
        }
        return found.toArray(new Decoration[found.size()]);
    }

    public Decoration getTypeDecoration(String type, String decorationType) {
        Decoration[] found = getTypeDecorations(type, decorationType);
        return found.length == 0 ? null : found[0];
    }

    public Decoration[] getMethodDecorations(Method method, String decorationType) {
        return getMethodDecorations(method.getDeclaringClass().getName(), PlatformUtils.getMethodSignature(method), decorationType);
    }

    public Decoration[] getMethodDecorations(String type, String method, String decorationType) {
        List<Decoration> found = new ArrayList<Decoration>();
        for (Decoration decoration : getMethodDecorations(type, method)) {
            if (decoration.getName().equals(decorationType)) {
                found.add(decoration);
            }
        }
        return found.toArray(new Decoration[found.size()]);
    }

    public Decoration[] getMethodRepeatableDecorations(Method method, Class decorationType, Class arrayDecorationType) {
        return getMethodRepeatableDecorations(method.getDeclaringClass().getName(), PlatformUtils.getMethodSignature(method), decorationType.getName(), arrayDecorationType == null ? null : arrayDecorationType.getName());
    }

    public Decoration[] getMethodRepeatableDecorations(String type, String method, String decorationType, String arrayDecorationType) {
        List<Decoration> found = new ArrayList<Decoration>();
        for (Decoration decoration : getMethodDecorations(type, method)) {
            if (decoration.getName().equals(decorationType)) {
                found.add(decoration);
            } else if (arrayDecorationType != null && arrayDecorationType.equals(decoration.getName())) {
                found.addAll(Arrays.asList(expandRepeatableDecorations(decoration)));
            }
        }
        return found.toArray(new Decoration[found.size()]);
    }

    public Decoration getMethodDecoration(String type, String method, String decorationType) {
        Decoration[] found = getMethodDecorations(type, method, decorationType);
        return found.length == 0 ? null : found[0];
    }

    public Decoration getMethodDecoration(Method method, Class decorationType) {
        return getMethodDecoration(method, decorationType.getName());
    }

    public Decoration getMethodDecoration(Method method, String decorationType) {
        for (Decoration decoration : getMethodDecorations(method)) {
            if (decoration.getName().equals(decorationType)) {
                return decoration;
            }
        }
        return null;
    }

    public Decoration getFieldDecoration(String type, String field, String decorationType) {
        for (Decoration decoration : getFieldDecorations(type, field)) {
            if (decoration.getName().equals(decorationType)) {
                return decoration;
            }
        }
        return null;
    }

    @Override
    public Decoration[] getFieldRepeatableDecorations(String type, String field, String decorationType, String arrayDecorationType) {
        List<Decoration> found = new ArrayList<>();
        for (Decoration decoration : getFieldDecorations(type, field)) {
            if (decoration.getName().equals(decorationType)) {
                found.add(decoration);
            } else if (arrayDecorationType != null && decoration.getName().equals(arrayDecorationType)) {
                found.addAll(Arrays.asList(expandRepeatableDecorations(decoration)));
            }
        }
        return found.toArray(new Decoration[found.size()]);
    }

    @Override
    public Decoration[] getFieldRepeatableDecorations(Field field, Class decorationType, Class arrayDecorationType) {
        return getFieldRepeatableDecorations(field.getDeclaringClass().getName(), field.getName(), decorationType.getName(), arrayDecorationType == null ? null : arrayDecorationType.getName());
    }

    public Decoration getFieldDecoration(Field field, Class decorationType) {
        return getFieldDecoration(field.getDeclaringClass().getName(), field.getName(), decorationType.getName());
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
            String dName = d.getName();
            String dLoc = d.getLocationType();
            if(d.getLocation()!=null){
                dLoc+="#"+d.getLocation();
            }
            String simpleName = dName;
            if (simpleName.startsWith("net.thevpc.upa.config.")) {
                simpleName = "@" + simpleName.substring("net.thevpc.upa.config.".length());
            }
            log.log(Level.FINE, "\t[{0}] Register Decoration {1}[{2}]", new Object[]{name, simpleName,dLoc});
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

    @Override
    public Decoration[] getDeclaredRepeatableDecorations(String decorationName, String arrayDecorationName) {
        List<Decoration> found = new ArrayList<>();
        found.addAll(Arrays.asList(getDeclaredDecorations(decorationName)));
        if (arrayDecorationName != null) {
            found.addAll(Arrays.asList(expandRepeatableDecorations(getDeclaredDecorations(arrayDecorationName))));
        }
        return found.toArray(new Decoration[found.size()]);
    }

    private Decoration[] expandRepeatableDecorations(Decoration[] decorations) {
        List<Decoration> found = new ArrayList<>();
        for (Decoration decoration : decorations) {
            found.addAll(Arrays.asList(expandRepeatableDecorations(decoration)));
        }
        return found.toArray(new Decoration[found.size()]);
    }

    private Decoration[] expandRepeatableDecorations(Decoration decoration) {
        List<Decoration> found = new ArrayList<>();
        DecorationValue[] value = decoration.getArray("value");
        if (value != null) {
            for (DecorationValue decorationValue : value) {
                found.add((Decoration) decorationValue);
            }
        }
        return found.toArray(new Decoration[found.size()]);
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

    @Override
    public Decoration[] getDeclaredRepeatableDecorations(Class decorationName, Class arrayDecorationName) {
        return getDeclaredRepeatableDecorations(decorationName.getName(), arrayDecorationName.getName());
    }

}
