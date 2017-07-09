package net.vpc.upa.impl.uql;


import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.uql.compiledexpression.CompiledLiteral;
import net.vpc.upa.impl.uql.compiledexpression.CompiledUplet;
import net.vpc.upa.impl.uql.compiledexpression.CompiledVar;

import java.lang.reflect.Array;
import java.lang.reflect.Constructor;

/**
 * Created with IntelliJ IDEA.
 * User: vpc
 * Date: 8/17/12
 * Time: 2:56 AM
 * To change this template use File | Settings | File Templates.
 */
public class CompiledExpressionFactory {
    public static CompiledExpressionExt toExpression(Object e, Class defaultInstance) {
        if (e == null) {
            return new CompiledLiteral(null, null);
        } else if (e instanceof CompiledExpressionExt) {
            return (CompiledExpressionExt) e;
        } else if (e.getClass().isArray()) {
            int l = Array.getLength(e);
            CompiledExpressionExt[] eitems = new CompiledExpressionExt[l];
            for (int i = 0; i < eitems.length; i++) {
                eitems[i] = toExpression(Array.get(e, i), defaultInstance);
            }
            return eitems.length==1?eitems[0]: new CompiledUplet(eitems);
        } else {
            Constructor c = null;
            try {
                c = defaultInstance.getConstructor(new Class[]{e.getClass()});
            } catch (NoSuchMethodException e1) {
                try {
                    c = defaultInstance.getConstructor(new Class[]{Object.class});
                } catch (NoSuchMethodException e2) {
                    throw new IllegalArgumentException("Could not cast " + e + " as Expression");
                }
            }
            try {
                return (CompiledExpressionExt) c.newInstance(new Object[]{e});
            } catch (Throwable e1) {
                throw new IllegalArgumentException(e1.toString());
            }
        }
    }

    //    public static String sqlForLitteral(Object value) {
    //        if(value == null){
    //            return "NULL";
    //        }else if (value instanceof ConvertableToPrimitiveType){
    //            value=((ConvertableToPrimitiveType)value).toPrimitiveType();
    //        }
    //        return
    //                (value instanceof Boolean) ? (((Boolean) value).booleanValue() ? "1" : "0")
    //                : (value instanceof Number) ? value.toString()
    //                : (value instanceof String) ? "'" + Utils.replaceString(value.toString(), "'", "''") + "'"
    //                : (value instanceof java.sql.Date) ? "'" + Utils.UNIVERSAL_DATE_FORMAT.format(value) + "'"
    //                : (value instanceof java.sql.Time) ? "'" + Utils.UNIVERSAL_TIME_FORMAT.format(value) + "'"
    //                : (value instanceof java.sql.Timestamp) ? "'" + Utils.UNIVERSAL_DATE_TIME_FORMAT.format(value) + "'"
    //                : (value instanceof java.util.Date) ? "'" + Utils.UNIVERSAL_DATE_TIME_FORMAT.format(value) + "'"
    //                : (value instanceof Blob) ? "'java.sql.Blob!" + Utils.replaceString(DBUtils.BlobToString((Blob) value), "'", "''") + "'"
    //                : (value instanceof byte[]) ? "'byte[]!" + Utils.replaceString(DBUtils.bytesToString((byte[]) value), "'", "''") + "'"
    //                : (value instanceof Key) ?
    //                (
    //                ((Key) value).getValue().length == 1 ?
    //                    ("'" + Utils.replaceString(String.valueOf(((Key) value).getValue()[0]), "'", "''") + "'")
    //                    :value.toString()
    //                )
    //                : (value instanceof Serializable) ? ("'java.io.Serializable!" + Utils.replaceString(DBUtils.bytesToString(Utils.getSerializedFormOf(value)), "'", "''") + "'")
    //                : null;
    //    }
    public static CompiledExpressionExt toLiteral(Object value) {
        return ((CompiledExpressionExt) (value == null || !(value instanceof CompiledExpressionExt) ? new CompiledLiteral(value, null) : (CompiledExpressionExt) value));
    }

    public static CompiledExpressionExt toVar(Object value) {
        return ((CompiledExpressionExt) (value == null || !(value instanceof CompiledExpressionExt) ? new CompiledVar((String) (value)) : (CompiledExpressionExt) value));
    }
}
