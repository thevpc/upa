/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.config;

import java.util.Map;

/**
 *
 * @author vpc
 */
public interface Decoration extends DecorationValue {

    public String getLocation();

    public DecorationSourceType getDecorationSourceType();

    public DecorationTarget getTarget();

    public String getLocationType();

    public String getName();

    public boolean isName(String name);

    public boolean isName(Class type);

    public int getPosition();

    public String getString(String name);

    public boolean getBoolean(String name);

    public int getInt(String name);

    public <T> T getEnum(String name, Class<T> type);

    public DecorationValue get(String name);

    public Class getType(String name);

    public Decoration getDecoration(String name);

    public <T> T[] getPrimitiveArray(String name, Class<T> type);

    public DecorationValue[] getArray(String name);

    public Map<String, DecorationValue> getAttributes();

    public Decoration castName(String type);

    public Decoration castName(Class type);
}
