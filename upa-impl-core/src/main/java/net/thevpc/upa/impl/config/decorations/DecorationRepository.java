/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.config.decorations;

import net.thevpc.upa.config.Decoration;

import java.lang.reflect.Field;
import java.lang.reflect.Method;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public interface DecorationRepository {

    void visit(Decoration d);

    Decoration[] getTypeDecorations(Class type);

    Decoration[] getTypeDecorations(String type);

    Decoration getTypeDecoration(Class type, Class decorationType);

    Decoration getTypeDecoration(Class type, String decorationType);

    Decoration getTypeDecoration(String type, String decorationType);

    Decoration[] getTypeDecorations(String type, String decorationType);

    Decoration[] getTypeRepeatableDecorations(Class type, Class decorationType, Class arrayDecorationType);

    Decoration[] getTypeRepeatableDecorations(String type, String decorationType, String arrayDecorationType);

    Decoration[] getFieldDecorations(Field field);

    Decoration[] getFieldDecorations(String type, String field);

    Decoration getFieldDecoration(Field field, Class decorationType);

    Decoration getFieldDecoration(String type, String field, String decorationType);

    Decoration[] getFieldRepeatableDecorations(Field field, Class decorationType, Class arrayDecorationType);

    Decoration[] getFieldRepeatableDecorations(String type, String field, String decorationType, String arrayDecorationType);

    Decoration[] getMethodDecorations(String type, String method);

    Decoration getMethodDecoration(Method method, Class decorationType);

    Decoration getMethodDecoration(Method method, String decorationType);

    Decoration getMethodDecoration(String type, String method, String decorationType);

    Decoration[] getMethodDecorations(Method method);

    Decoration[] getMethodDecorations(Method method, String decorationType);

    Decoration[] getMethodDecorations(String type, String method, String decorationType);

    Decoration[] getMethodRepeatableDecorations(Method method, Class decorationType, Class arrayDecorationType) ;

    Decoration[] getMethodRepeatableDecorations(String type, String method, String decorationType, String arrayDecorationType) ;


    String[] getTypesForDecoration(String decorationName);

    Decoration[] getDeclaredDecorations(String decorationName);

    /**
     * returns all decorations of type decorationName or found as value of arrayDecorationName.
     * This is valuable method to enable repeatable annotations/decorations on an item
     * @param decorationName
     * @param arrayDecorationName
     * @return
     */
    Decoration[] getDeclaredRepeatableDecorations(String decorationName,String arrayDecorationName);
    Decoration[] getDeclaredRepeatableDecorations(Class decorationName,Class arrayDecorationName);
}
