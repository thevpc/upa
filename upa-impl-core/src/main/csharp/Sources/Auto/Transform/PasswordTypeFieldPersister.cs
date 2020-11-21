/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE AS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.TheVpc.Upa.Impl.Transform
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class PasswordTypeFieldPersister : Net.TheVpc.Upa.Impl.FieldPersister {

        private static readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.TheVpc.Upa.Impl.Transform.PasswordTypeFieldPersister)).FullName);

        public virtual void PrepareFieldForPersist(Net.TheVpc.Upa.Field field, object @value, Net.TheVpc.Upa.Record userRecord, Net.TheVpc.Upa.Record persistentRecord, Net.TheVpc.Upa.Persistence.EntityExecutionContext executionContext, System.Collections.Generic.ISet<Net.TheVpc.Upa.Field> insertNonNullable, System.Collections.Generic.ISet<Net.TheVpc.Upa.Field> insertWithDefaultValue) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            object userValue = null;
            bool userValueFound = false;
            if (!(@value is Net.TheVpc.Upa.Expressions.Expression)) {
                userValueFound = true;
                userValue = @value;
            } else if (@value is Net.TheVpc.Upa.Expressions.Param) {
                object o = ((Net.TheVpc.Upa.Expressions.Param) @value).GetValue();
                //            if (o instanceof String) {
                userValue = o;
                userValueFound = true;
            } else if (@value is Net.TheVpc.Upa.Expressions.Literal) {
                object o = ((Net.TheVpc.Upa.Expressions.Literal) @value).GetValue();
                //            if (o instanceof String) {
                userValue = o;
                userValueFound = true;
            }
            //            }
            if (userValueFound) {
                Net.TheVpc.Upa.Types.DataTypeTransform typeTransform = Net.TheVpc.Upa.Impl.Util.UPAUtils.GetTypeTransformOrIdentity(field);
                Net.TheVpc.Upa.Impl.Transform.PasswordDataTypeTransform t = Net.TheVpc.Upa.Impl.Util.UPAUtils.FindPasswordTransform(typeTransform);
                object v = ConvertCypherValue(t.GetCipherValue(), field.GetDataType());
                if (Net.TheVpc.Upa.Impl.Util.UPAUtils.Equals(userValue, v)) {
                    return;
                }
                //ignore insert
                userRecord.SetObject(field.GetName(), v);
            } else {
                log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Inserting non user value to password, hashing will be ignored",null));
            }
            Net.TheVpc.Upa.Expressions.Expression valueExpression = (@value is Net.TheVpc.Upa.Expressions.Expression) ? ((Net.TheVpc.Upa.Expressions.Expression)((Net.TheVpc.Upa.Expressions.Expression) @value)) : new Net.TheVpc.Upa.Expressions.Param(field.GetName(), @value);
            persistentRecord.SetObject(field.GetName(), valueExpression);
        }

        public static object ConvertCypherValue(object @value, Net.TheVpc.Upa.Types.DataType type) {
            if (!type.IsInstance(@value)) {
                if (type is Net.TheVpc.Upa.Types.ByteArrayType) {
                    if (@value is string) {
                        @value = System.Text.Encoding.UTF8.GetBytes(((string) @value));
                    } else {
                        throw new System.ArgumentException ("Unvalid  Value " + @value + " for type " + type);
                    }
                } else if (type is Net.TheVpc.Upa.Types.CharArrayType) {
                    if (@value is string) {
                        @value = ((string) @value).ToCharArray();
                    } else {
                        throw new System.ArgumentException ("Unvalid  Value " + @value + " for type " + type);
                    }
                } else if (type is Net.TheVpc.Upa.Types.NumberType) {
                    if (@value is string) {
                        if ("****".Equals(@value)) {
                            @value = type.GetDefaultUnspecifiedValue();
                        } else {
                            @value = ((Net.TheVpc.Upa.Types.NumberType) type).Parse(((string) @value));
                        }
                    } else {
                        throw new System.ArgumentException ("Unvalid  Value " + @value + " for type " + type);
                    }
                } else if (type is Net.TheVpc.Upa.Types.EnumType) {
                    if (@value is string) {
                        if ("****".Equals(@value)) {
                            @value = type.GetDefaultUnspecifiedValue();
                        } else {
                            @value = ((Net.TheVpc.Upa.Types.EnumType) type).Parse(((string) @value));
                        }
                    } else {
                        throw new System.ArgumentException ("Unvalid Cipher  " + @value + " for type " + type);
                    }
                } else if (type is Net.TheVpc.Upa.Types.BooleanType) {
                    if (@value is string) {
                        if ("****".Equals(@value)) {
                            @value = type.GetDefaultUnspecifiedValue();
                        } else {
                            @value = ((Net.TheVpc.Upa.Types.BooleanType) type).Parse(((string) @value));
                        }
                    } else {
                        throw new System.ArgumentException ("Unvalid Cipher  " + @value + " for type " + type);
                    }
                } else if (type is Net.TheVpc.Upa.Types.StringType) {
                    if (@value is string) {
                    } else {
                        throw new System.ArgumentException ("Unvalid Cipher  " + @value + " for type " + type);
                    }
                } else {
                    throw new System.ArgumentException ("Unvalid Cipher  " + @value + " for type " + type);
                }
            }
            return @value;
        }

        public virtual void PrepareFieldForUpdate(Net.TheVpc.Upa.Field field, object @value, Net.TheVpc.Upa.Record userRecord, Net.TheVpc.Upa.Record persistentRecord, Net.TheVpc.Upa.Persistence.EntityExecutionContext executionContext) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            object userValue = null;
            bool userValueFound = false;
            if (!(@value is Net.TheVpc.Upa.Expressions.Expression)) {
                userValueFound = true;
                userValue = @value;
            } else if (@value is Net.TheVpc.Upa.Expressions.Param) {
                object o = ((Net.TheVpc.Upa.Expressions.Param) @value).GetValue();
                //            if (o instanceof String) {
                userValue = o;
                userValueFound = true;
            } else if (@value is Net.TheVpc.Upa.Expressions.Literal) {
                object o = ((Net.TheVpc.Upa.Expressions.Literal) @value).GetValue();
                //            if (o instanceof String) {
                userValue = o;
                userValueFound = true;
            }
            //            }
            if (userValueFound) {
                Net.TheVpc.Upa.Impl.Transform.PasswordDataTypeTransform t = Net.TheVpc.Upa.Impl.Util.UPAUtils.FindPasswordTransform(Net.TheVpc.Upa.Impl.Util.UPAUtils.GetTypeTransformOrIdentity(field));
                object v = t.GetCipherValue();
                if (Net.TheVpc.Upa.Impl.Util.UPAUtils.Equals(userValue, v)) {
                    return;
                }
                //ignore insert
                userRecord.SetObject(field.GetName(), v);
            } else {
                log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Inserting non user value to password, hashing will be ignored",null));
            }
            Net.TheVpc.Upa.Expressions.Expression valueExpression = (@value is Net.TheVpc.Upa.Expressions.Expression) ? ((Net.TheVpc.Upa.Expressions.Expression)((Net.TheVpc.Upa.Expressions.Expression) @value)) : new Net.TheVpc.Upa.Expressions.Param(field.GetName(), @value);
            persistentRecord.SetObject(field.GetName(), valueExpression);
        }
    }
}
