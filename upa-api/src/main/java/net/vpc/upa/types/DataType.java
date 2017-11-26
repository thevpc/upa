package net.vpc.upa.types;

import net.vpc.upa.DataTypeInfo;
import net.vpc.upa.Properties;

import java.util.List;

/**
 * Created by vpc on 6/17/16.
 */
public interface DataType extends Cloneable {
    Object getDefaultUnspecifiedValue();

    void setDefaultUnspecifiedValue(Object defaultUnspecifiedValue);

    Object getDefaultValue();

    void setDefaultValue(Object defaultValue);

    boolean isNullable();

    void setNullable(boolean enable);

    Class getPlatformType();

    int getScale();

    int getPrecision();

    Object rewrite(Object value, String name, String description) throws ConstraintsException;

    void check(Object value, String name, String description) throws ConstraintsException;

    Object copy();

    List<TypeValueValidator> getValueValidators();

    DataType addValueValidator(TypeValueValidator validator);

    DataType removeValueValidator(TypeValueValidator validator);

    DataType addValueRewriter(TypeValueRewriter rewriter);

    DataType removeValueReWriter(TypeValueRewriter rewriter);

    List<TypeValueRewriter> getValueRewriters();

    String getUnitName();

    DataType setUnitName(String unitName);

    boolean isAssignableFrom(DataType type);

    boolean isInstance(Object object);

    void cast(DataType type);

    Object convert(Object value);

    String getName();

    void setName(String name);

    Properties getProperties();

    void setProperties(Properties properties);

    DataTypeInfo getInfo();
}
