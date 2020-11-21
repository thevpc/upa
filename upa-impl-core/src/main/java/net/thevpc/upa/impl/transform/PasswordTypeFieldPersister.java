/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.transform;

import java.util.Set;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.thevpc.upa.Field;
import net.thevpc.upa.Document;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.exceptions.IllegalUPAArgumentException;
import net.thevpc.upa.expressions.Expression;
import net.thevpc.upa.expressions.Literal;
import net.thevpc.upa.expressions.Param;
import net.thevpc.upa.impl.FieldPersister;
import net.thevpc.upa.impl.util.UPAUtils;
import net.thevpc.upa.persistence.EntityExecutionContext;
import net.thevpc.upa.types.*;
import net.thevpc.upa.types.*;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class PasswordTypeFieldPersister implements FieldPersister {

    private static final Logger log = Logger.getLogger(PasswordTypeFieldPersister.class.getName());

    public void prepareFieldForPersist(Field field, Object value, Document userDocument, Document persistentDocument, EntityExecutionContext executionContext, Set<Field> insertNonNullable, Set<Field> insertWithDefaultValue) throws UPAException {
        Object userValue = null;
        boolean userValueFound = false;
        if (!(value instanceof Expression)) {
            userValueFound = true;
            userValue = value;
        } else if (value instanceof Param) {
            Object o = ((Param) value).getValue();
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
            DataTypeTransform typeTransform = field.getEffectiveTypeTransform();
            PasswordDataTypeTransform t = UPAUtils.findPasswordTransform(typeTransform);
            Object v = convertCypherValue(t.getCipherValue(), field.getDataType());
            if (UPAUtils.equals(userValue, v)) {
                return;//ignore insert
            }
            userDocument.setObject(field.getName(), v);
        } else {
            log.log(Level.SEVERE, "Inserting non user value to password, hashing will be ignored");
        }
        Expression valueExpression = (value instanceof Expression) ? (Expression) value : new Param(field.getName(), value);
        persistentDocument.setObject(field.getName(), valueExpression);
    }

    public static Object convertCypherValue(Object value, DataType type) {
        if (!type.isInstance(value)) {
            if (type instanceof ByteArrayType) {
                if (value instanceof String) {
                    value = ((String) value).getBytes();
                } else {
                    throw new IllegalUPAArgumentException("Unvalid  Value " + value + " for type " + type);
                }
            } else if (type instanceof CharArrayType) {
                if (value instanceof String) {
                    value = ((String) value).toCharArray();
                } else {
                    throw new IllegalUPAArgumentException("Unvalid  Value " + value + " for type " + type);
                }
            } else if (type instanceof NumberType) {
                if (value instanceof String) {
                    if ("****".equals(value)) {
                        value = type.getDefaultUnspecifiedValue();
                    } else {
                        value = ((NumberType) type).parse(((String) value));
                    }
                } else {
                    throw new IllegalUPAArgumentException("Unvalid  Value " + value + " for type " + type);
                }
            } else if (type instanceof EnumType) {
                if (value instanceof String) {
                    if ("****".equals(value)) {
                        value = type.getDefaultUnspecifiedValue();
                    } else {
                        value = ((EnumType) type).parse(((String) value));
                    }
                } else {
                    throw new IllegalUPAArgumentException("Unvalid Cipher  " + value + " for type " + type);
                }
            } else if (type instanceof BooleanType) {
                if (value instanceof String) {
                    if ("****".equals(value)) {
                        value = type.getDefaultUnspecifiedValue();
                    } else {
                        value = ((BooleanType) type).parse(((String) value));
                    }
                } else {
                    throw new IllegalUPAArgumentException("Unvalid Cipher  " + value + " for type " + type);
                }
            } else if (type instanceof StringType) {
                if (value instanceof String) {
                    //okkay!
                } else {
                    throw new IllegalUPAArgumentException("Unvalid Cipher  " + value + " for type " + type);
                }
            } else {
                throw new IllegalUPAArgumentException("Unvalid Cipher  " + value + " for type " + type);
            }
        }
        return value;
    }

    public void prepareFieldForUpdate(Field field, Object value, Document userDocument, Document persistentDocument, EntityExecutionContext executionContext) throws UPAException {
        Object userValue = null;
        boolean userValueFound = false;
        if (!(value instanceof Expression)) {
            userValueFound = true;
            userValue = value;
        } else if (value instanceof Param) {
            Object o = ((Param) value).getValue();
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
            PasswordDataTypeTransform t = UPAUtils.findPasswordTransform(field.getEffectiveTypeTransform());
            Object v = t.getCipherValue();
            if (UPAUtils.equals(userValue, v)) {
                return;//ignore insert
            }
            userDocument.setObject(field.getName(), v);
        } else {
            log.log(Level.SEVERE, "Inserting non user value to password, hashing will be ignored");
        }
        Expression valueExpression = (value instanceof Expression) ? (Expression) value : new Param(field.getName(), value);
        persistentDocument.setObject(field.getName(), valueExpression);
    }
}
