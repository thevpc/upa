/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.config.decorations;

import java.lang.annotation.Annotation;
import java.lang.annotation.ElementType;
import java.lang.annotation.Target;
import java.util.HashSet;
import java.util.Set;
import net.vpc.upa.FlagSet;
import net.vpc.upa.FlagSets;
import net.vpc.upa.config.DecorationTarget;

/**
 *
 * @author vpc
 */
public class DefaultDecorationFilter implements DecorationFilter {

    private Set<String> typeAnnotations = new HashSet<String>();
    private Set<String> methodsAnnotations = new HashSet<String>();
    private Set<String> fieldsAnnotations = new HashSet<String>();

    public boolean acceptTypeDecoration(String name, String targetType, Object value) {
        return typeAnnotations.contains(name);
    }

    public FlagSet<DecorationTarget> getDecorationTargets() {
        FlagSet<DecorationTarget> i = FlagSets.noneOf(DecorationTarget.class);
        if (typeAnnotations.size() > 0) {
            i=i.add(DecorationTarget.TYPE);
        }
        if (methodsAnnotations.size() > 0) {
            i=i.add(DecorationTarget.METHOD);
        }
        if (fieldsAnnotations.size() > 0) {
            i=i.add(DecorationTarget.FIELD);
        }
//        i += HIERARCHICAL;
        return i;
    }

    public boolean acceptMethodDecoration(String name, String targetMethod, String targetType, Object value) {
        return methodsAnnotations.contains(name);
    }

    public boolean acceptFieldDecoration(String name, String targetField, String targetType, Object value) {
        return fieldsAnnotations.contains(name);
    }

    public DefaultDecorationFilter addDecorations(Class... all) {
        for (Class c : all) {
            java.lang.annotation.Target t = (java.lang.annotation.Target) c.getAnnotation(java.lang.annotation.Target.class);
            if (t == null) {
                throw new IllegalArgumentException(c + " seems not to be an annotation");
            }
            for (ElementType et : t.value()) {
                switch (et) {
                    case TYPE: {
                        typeAnnotations.add(c.getName());
                        break;
                    }
                    case FIELD: {
                        fieldsAnnotations.add(c.getName());
                        break;
                    }
                    case METHOD: {
                        fieldsAnnotations.add(c.getName());
                        break;
                    }
                }
            }
        }
        return this;
    }

    public DefaultDecorationFilter addTypeDecorations(String... all) {
        for (String a : all) {
            typeAnnotations.add(a);
        }
        return this;
    }
}
