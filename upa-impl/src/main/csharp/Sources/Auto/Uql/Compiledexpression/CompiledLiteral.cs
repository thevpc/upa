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



namespace Net.Vpc.Upa.Impl.Uql.Compiledexpression
{


    public sealed class CompiledLiteral : Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpressionImpl {

        public static readonly Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral IONE = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral(1);

        public static readonly Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral IZERO = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral(0);

        public static readonly Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral DZERO = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral(0.0);

        public static readonly Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral ZERO = DZERO;

        public static readonly Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral NULL = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral(0);

        public static readonly Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral EMPTY_STRING = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral("");



        private Net.Vpc.Upa.Types.DataTypeTransform type;

        private object @value;

        public CompiledLiteral(Net.Vpc.Upa.Types.Temporal date) {
            SetValue(date);
        }

        public CompiledLiteral(int @value) {
            SetValue(new int?(@value));
        }

        public CompiledLiteral(bool @value) {
            SetValue((@value) ? new System.Nullable<bool>(true) : new System.Nullable<bool>(false));
        }

        public CompiledLiteral(long @value) {
            SetValue(new long?(@value));
        }

        public CompiledLiteral(float @value) {
            SetValue(new float?(@value));
        }

        public CompiledLiteral(double @value) {
            SetValue(new double?(@value));
        }

        public CompiledLiteral(char @value) {
            SetValue(new char?(@value));
        }

        public CompiledLiteral(string @value) {
            SetValue(@value);
        }

        public CompiledLiteral(object @value, Net.Vpc.Upa.Types.DataTypeTransform type) {
            //        if (
            //                value != null
            //                && !(value instanceof String)
            //                && !(value instanceof Number)
            //                && !(value instanceof Date)
            //                && !(value instanceof Boolean)
            //        ) {
            //            throw new RuntimeException("bad sql value : " + value.getClass().getName() + " ==> " + value);
            //        } else {
            this.@value = @value;
            if (type == null) {
                if (@value == null) {
                    type = Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.OBJECT;
                } else {
                    type = Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.ForNativeType(@value.GetType());
                }
            }
            this.type = type;
        }


        public override string ToString() {
            if (@value is string) {
                return "'" + System.Convert.ToString(@value).Replace("'", "''") + "'";
            }
            if (@value is Net.Vpc.Upa.Types.Temporal) {
                return "'" + System.Convert.ToString(@value).Replace("'", "''") + "'";
            }
            return System.Convert.ToString(@value);
        }

        public static bool IsNull(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression e) {
            return e == null || ((e is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral) && (((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral) e).@value == null));
        }

        public object GetValue() {
            return @value;
        }

        private void SetValue(object o) {
            this.@value = o;
            if (o == null) {
                type = Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.OBJECT;
            }
            type = Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.ForNativeType(o.GetType());
        }


        public override Net.Vpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            return type;
        }


        public override Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral o = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral(@value, type);
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
            return o;
        }


        public override Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] GetSubExpressions() {
            return null;
        }


        public override void SetSubExpression(int index, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            throw new System.Exception("Not supported.");
        }


        public override Net.Vpc.Upa.Types.DataTypeTransform GetEffectiveDataType() {
            Net.Vpc.Upa.Types.DataTypeTransform d = GetTypeTransform();
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression p = GetParentExpression();
            if (p is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarVal) {
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarOrMethod v = ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarVal) p).GetVar();
                v = ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarOrMethod) v).GetFinest();
                object r = v.GetReferrer();
                if (r is Net.Vpc.Upa.Field) {
                    return Net.Vpc.Upa.Impl.Util.UPAUtils.GetTypeTransformOrIdentity(((Net.Vpc.Upa.Field) r));
                }
            } else if ((p is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEquals) || (p is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledDifferent)) {
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression o = ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledBinaryOperatorExpression) p).GetOther(this);
                if (o is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarOrMethod) {
                    o = ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarOrMethod) o).GetFinest();
                    object r = ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarOrMethod) o).GetReferrer();
                    if (r is Net.Vpc.Upa.Field) {
                        return Net.Vpc.Upa.Impl.Util.UPAUtils.GetTypeTransformOrIdentity((Net.Vpc.Upa.Field) r);
                    }
                }
            }
            return d;
        }
    }
}
