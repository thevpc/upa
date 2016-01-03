/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.transform;

import java.util.Set;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.vpc.upa.Field;
import net.vpc.upa.Record;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.Literal;
import net.vpc.upa.expressions.Param;
import net.vpc.upa.impl.FieldPersister;
import net.vpc.upa.impl.util.UPAUtils;
import net.vpc.upa.persistence.EntityExecutionContext;
import net.vpc.upa.types.BooleanType;
import net.vpc.upa.types.ByteArrayType;
import net.vpc.upa.types.CharArrayType;
import net.vpc.upa.types.DataType;
import net.vpc.upa.types.DataTypeTransform;
import net.vpc.upa.types.EnumType;
import net.vpc.upa.types.NumberType;
import net.vpc.upa.types.StringType;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class PasswordTypeFieldPersister implements FieldPersister {

    private static final Logger log = Logger.getLogger(PasswordTypeFieldPersister.class.getName());

    public void prepareFieldForPersist(Field field, Object value, Record userRecord, Record persistentRecord, EntityExecutionContext executionContext, Set<Field> insertNonNullable, Set<Field> insertWithDefaultValue) throws UPAException {
        Object userValue = null;
        boolean userValueFound = false;
        if (!(value instanceof Expression)) {
            userValueFound = true;
            userValue = value;
        } else if (value instanceof Param) {
            Object o = ((Param) value).getObject();
//            if (o instanceof String) {
            userValue = o;
            userValueFound = true;
//            }
        } else if (value instanceof Literal) {
            Object o = ((Literal) value).getValue();
//            if (o instanceof String) {
            userValue = o;
            userValueFound = true;
//            }
        }
        if (userValueFound) {
            DataTypeTransform typeTransform = UPAUtils.getTypeTransformOrIdentity(field);
            PasswordDataTypeTransform t = UPAUtils.findPasswordTransform(typeTransform);
            Object v = convertCypherValue(t.getCipherValue(), field.getDataType());
            if (UPAUtils.equals(userValue, v)) {
                return;//ignore insert
            }
            userRecord.setObject(field.getName(), v);
        } else {
            log.log(Level.SEVERE, "Inserting non user value to password, hashing will be ignored");
        }
        Expression valueExpression = (value instanceof Expression) ? (Expression) value : new Param(field.getName(), value);
        persistentRecord.setObject(field.getName(), valueExpression);
    }

    public static Object convertCypherValue(Object value, DataType type) {
        if (!type.isInstance(value)) {
            if (type instanceof ByteArrayType) {
                if (value instanceof String) {
                    value = ((String) value).getBytes();
                } else {
                    throw new IllegalArgumentException("Unvalid  Value " + value + " for type " + type);
                }
            } else if (type instanceof CharArrayType) {
                if (value instanceof String) {
                    value = ((String) value).toCharArray();
                } else {
                    throw new IllegalArgumentException("Unvalid  Value " + value + " for type " + type);
                }
            } else if (type instanceof NumberType) {
                if (value instanceof String) {
                    if ("****".equals(value)) {
                        value = type.getDefaultUnspecifiedValue();
                    } else {
                        value = ((NumberType) type).parse(((String) value));
                    }
                } else {
                    throw new IllegalArgumentException("Unvalid  Value " + value + " for type " + type);
                }
            } else if (type instanceof EnumType) {
                if (value instanceof String) {
                    if ("****".equals(value)) {
                        value = type.getDefaultUnspecifiedValue();
                    } else {
                        value = ((EnumType) type).parse(((String) value));
                    }
                } else {
                    throw new IllegalArgumentException("Unvalid Cipher  " + value + " for type " + type);
                }
            } else if (type instanceof BooleanType) {
                if (value instanceof String) {
                    if ("****".equals(value)) {
                        value = type.getDefaultUnspecifiedValue();
                    } else {
                        value = ((BooleanType) type).parse(((String) value));
                    }
                } else {
                    throw new IllegalArgumentException("Unvalid Cipher  " + value + " for type " + type);
                }
            } else if (type instanceof StringType) {
                if (value instanceof String) {
                    //okkay!
                } else {
                    throw new IllegalArgumentException("Unvalid Cipher  " + value + " for type " + type);
                }
            } else {
                throw new IllegalArgumentException("Unvalid Cipher  " + value + " for type " + type);
            }
        }
        return value;
    }

    public void prepareFieldForUpdate(Field field, Object value, Record userRecord, Record persistentRecord, EntityExecutionContext executionContext) throws UPAException {
        Object userValue = null;
        boolean userValueFound = false;
        if (!(value instanceof Expression)) {
            userValueFound = true;
            userValue = value;
        } else if (value instanceof Param) {
            Object o = ((Param) value).getObject();
//            if (o instanceof String) {
            userValue = o;
            userValueFound = true;
//            }
        } else if (value instanceof Literal) {
            Object o = ((Literal) value).getValue();
//            if (o instanceof String) {
            userValue = o;
            userValueFound = true;
//            }
        }
        if (userValueFound) {
            PasswordDataTypeTransform t = UPAUtils.findPasswordTransform(UPAUtils.getTypeTransformOrIdentity(field));
            Object v = t.getCipherValue();
            if (UPAUtils.equals(userValue, v)) {
                return;//ignore insert
            }
            userRecord.setObject(field.getName(), v);
        } else {
            log.log(Level.SEVERE, "Inserting non user value to password, hashing will be ignored");
        }
        Expression valueExpression = (value instanceof Expression) ? (Expression) value : new Param(field.getName(), value);
        persistentRecord.setObject(field.getName(), valueExpression);
    }
}
