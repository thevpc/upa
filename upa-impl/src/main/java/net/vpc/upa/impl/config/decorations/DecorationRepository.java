/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.config.decorations;

import net.vpc.upa.config.Decoration;
import java.lang.reflect.Field;
import java.lang.reflect.Method;

/**
 *
 * @author vpc
 */
public interface DecorationRepository {

    public void visit(Decoration d);

    public Decoration[] getTypeDecorations(String type);

    public Decoration[] getMethodDecorations(String type, String method);

    public Decoration[] getFieldDecorations(String type, String field);

    Decoration getFieldDecoration(Field field, Class annType);

    Decoration getFieldDecoration(Field field, String annType);

    Decoration getFieldDecoration(String type, String field, Class annType);

    Decoration getFieldDecoration(String type, String field, String annType);

    Decoration[] getFieldDecorations(Field field);

    public Decoration getMethodDecoration(Method method, Class annType);

    Decoration getMethodDecoration(Method method, String annType);

    Decoration getMethodDecoration(String type, String method, String annType);

    Decoration[] getMethodDecorations(Method method);

    Decoration getTypeDecoration(Class type, Class annType);

    Decoration getTypeDecoration(Class type, String annType);

    Decoration getTypeDecoration(String type, String annType);

    Decoration[] getTypeDecorations(Class type);

    Decoration[] getTypeDecorations(String type, String annType);

    Decoration[] getMethodDecorations(Method method, String annType);

    Decoration[] getMethodDecorations(String type, String method, String annType);

    String[] getTypesForDecoration(String decorationName);

    Decoration[] getDeclaredDecorations(String decorationName);
}
