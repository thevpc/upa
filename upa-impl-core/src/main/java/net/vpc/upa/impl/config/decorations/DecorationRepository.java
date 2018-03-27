/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.config.decorations;

import net.vpc.upa.config.Decoration;
import java.lang.reflect.Field;
import java.lang.reflect.Method;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public interface DecorationRepository {

    void visit(Decoration d);

    Decoration[] getTypeDecorations(String type);

    Decoration[] getMethodDecorations(String type, String method);

    Decoration[] getFieldDecorations(String type, String field);

    Decoration getFieldDecoration(Field field, Class annType);

    Decoration getFieldDecoration(Field field, String annType);

    Decoration getFieldDecoration(String type, String field, Class annType);

    Decoration getFieldDecoration(String type, String field, String annType);

    Decoration[] getFieldDecorations(Field field);

    Decoration getMethodDecoration(Method method, Class annType);

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
