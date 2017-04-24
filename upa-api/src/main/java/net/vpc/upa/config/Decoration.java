/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.config;

import java.util.Map;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public interface Decoration extends DecorationValue {

    String getLocation();

    DecorationSourceType getDecorationSourceType();

    DecorationTarget getTarget();

    String getLocationType();

    String getName();

    boolean isName(String name);

    boolean isName(Class type);

    int getPosition();

    String getString(String name);

    boolean getBoolean(String name);

    int getInt(String name);

    <T> T getEnum(String name, Class<T> type);

    DecorationValue get(String name);

    Class getType(String name);

    Decoration getDecoration(String name);

    <T> T[] getPrimitiveArray(String name, Class<T> type);

    DecorationValue[] getArray(String name);

    Map<String, DecorationValue> getAttributes();

    Decoration castName(String type);

    Decoration castName(Class type);
}
