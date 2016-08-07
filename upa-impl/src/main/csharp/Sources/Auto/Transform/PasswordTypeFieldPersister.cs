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



namespace Net.Vpc.Upa.Impl.Transform
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class PasswordTypeFieldPersister : Net.Vpc.Upa.Impl.FieldPersister {

        private static readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.Vpc.Upa.Impl.Transform.PasswordTypeFieldPersister)).FullName);

        public virtual void PrepareFieldForPersist(Net.Vpc.Upa.Field field, object @value, Net.Vpc.Upa.Record userRecord, Net.Vpc.Upa.Record persistentRecord, Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext, System.Collections.Generic.ISet<Net.Vpc.Upa.Field> insertNonNullable, System.Collections.Generic.ISet<Net.Vpc.Upa.Field> insertWithDefaultValue) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            object userValue = null;
            bool userValueFound = false;
            if (!(@value is Net.Vpc.Upa.Expressions.Expression)) {
                userValueFound = true;
                userValue = @value;
            } else if (@value is Net.Vpc.Upa.Expressions.Param) {
                object o = ((Net.Vpc.Upa.Expressions.Param) @value).GetValue();
                //            if (o instanceof String) {
                userValue = o;
                userValueFound = true;
            } else if (@value is Net.Vpc.Upa.Expressions.Literal) {
                object o = ((Net.Vpc.Upa.Expressions.Literal) @value).GetValue();
                //            if (o instanceof String) {
                userValue = o;
                userValueFound = true;
            }
            //            }
            if (userValueFound) {
                Net.Vpc.Upa.Types.DataTypeTransform typeTransform = Net.Vpc.Upa.Impl.Util.UPAUtils.GetTypeTransformOrIdentity(field);
                Net.Vpc.Upa.Impl.Transform.PasswordDataTypeTransform t = Net.Vpc.Upa.Impl.Util.UPAUtils.FindPasswordTransform(typeTransform);
                object v = ConvertCypherValue(t.GetCipherValue(), field.GetDataType());
                if (Net.Vpc.Upa.Impl.Util.UPAUtils.Equals(userValue, v)) {
                    return;
                }
                //ignore insert
                userRecord.SetObject(field.GetName(), v);
            } else {
                log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Inserting non user value to password, hashing will be ignored",null));
            }
            Net.Vpc.Upa.Expressions.Expression valueExpression = (@value is Net.Vpc.Upa.Expressions.Expression) ? ((Net.Vpc.Upa.Expressions.Expression)((Net.Vpc.Upa.Expressions.Expression) @value)) : new Net.Vpc.Upa.Expressions.Param(field.GetName(), @value);
            persistentRecord.SetObject(field.GetName(), valueExpression);
        }

        public static object ConvertCypherValue(object @value, Net.Vpc.Upa.Types.DataType type) {
            if (!type.IsInstance(@value)) {
                if (type is Net.Vpc.Upa.Types.ByteArrayType) {
                    if (@value is string) {
                        @value = System.Text.Encoding.UTF8.GetBytes(((string) @value));
                    } else {
                        throw new System.ArgumentException ("Unvalid  Value " + @value + " for type " + type);
                    }
                } else if (type is Net.Vpc.Upa.Types.CharArrayType) {
                    if (@value is string) {
                        @value = ((string) @value).ToCharArray();
                    } else {
                        throw new System.ArgumentException ("Unvalid  Value " + @value + " for type " + type);
                    }
                } else if (type is Net.Vpc.Upa.Types.NumberType) {
                    if (@value is string) {
                        if ("****".Equals(@value)) {
                            @value = type.GetDefaultUnspecifiedValue();
                        } else {
                            @value = ((Net.Vpc.Upa.Types.NumberType) type).Parse(((string) @value));
                        }
                    } else {
                        throw new System.ArgumentException ("Unvalid  Value " + @value + " for type " + type);
                    }
                } else if (type is Net.Vpc.Upa.Types.EnumType) {
                    if (@value is string) {
                        if ("****".Equals(@value)) {
                            @value = type.GetDefaultUnspecifiedValue();
                        } else {
                            @value = ((Net.Vpc.Upa.Types.EnumType) type).Parse(((string) @value));
                        }
                    } else {
                        throw new System.ArgumentException ("Unvalid Cipher  " + @value + " for type " + type);
                    }
                } else if (type is Net.Vpc.Upa.Types.BooleanType) {
                    if (@value is string) {
                        if ("****".Equals(@value)) {
                            @value = type.GetDefaultUnspecifiedValue();
                        } else {
                            @value = ((Net.Vpc.Upa.Types.BooleanType) type).Parse(((string) @value));
                        }
                    } else {
                        throw new System.ArgumentException ("Unvalid Cipher  " + @value + " for type " + type);
                    }
                } else if (type is Net.Vpc.Upa.Types.StringType) {
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

        public virtual void PrepareFieldForUpdate(Net.Vpc.Upa.Field field, object @value, Net.Vpc.Upa.Record userRecord, Net.Vpc.Upa.Record persistentRecord, Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            object userValue = null;
            bool userValueFound = false;
            if (!(@value is Net.Vpc.Upa.Expressions.Expression)) {
                userValueFound = true;
                userValue = @value;
            } else if (@value is Net.Vpc.Upa.Expressions.Param) {
                object o = ((Net.Vpc.Upa.Expressions.Param) @value).GetValue();
                //            if (o instanceof String) {
                userValue = o;
                userValueFound = true;
            } else if (@value is Net.Vpc.Upa.Expressions.Literal) {
                object o = ((Net.Vpc.Upa.Expressions.Literal) @value).GetValue();
                //            if (o instanceof String) {
                userValue = o;
                userValueFound = true;
            }
            //            }
            if (userValueFound) {
                Net.Vpc.Upa.Impl.Transform.PasswordDataTypeTransform t = Net.Vpc.Upa.Impl.Util.UPAUtils.FindPasswordTransform(Net.Vpc.Upa.Impl.Util.UPAUtils.GetTypeTransformOrIdentity(field));
                object v = t.GetCipherValue();
                if (Net.Vpc.Upa.Impl.Util.UPAUtils.Equals(userValue, v)) {
                    return;
                }
                //ignore insert
                userRecord.SetObject(field.GetName(), v);
            } else {
                log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Inserting non user value to password, hashing will be ignored",null));
            }
            Net.Vpc.Upa.Expressions.Expression valueExpression = (@value is Net.Vpc.Upa.Expressions.Expression) ? ((Net.Vpc.Upa.Expressions.Expression)((Net.Vpc.Upa.Expressions.Expression) @value)) : new Net.Vpc.Upa.Expressions.Param(field.GetName(), @value);
            persistentRecord.SetObject(field.GetName(), valueExpression);
        }
    }
}
