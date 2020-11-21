/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE HAS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.TheVpc.Upa.Expressions
{


    public sealed class Literal : Net.TheVpc.Upa.Expressions.DefaultExpression {

        public static readonly Net.TheVpc.Upa.Expressions.Literal IONE = new Net.TheVpc.Upa.Expressions.Literal(1);

        public static readonly Net.TheVpc.Upa.Expressions.Literal IZERO = new Net.TheVpc.Upa.Expressions.Literal(0);

        public static readonly Net.TheVpc.Upa.Expressions.Literal DZERO = new Net.TheVpc.Upa.Expressions.Literal(0.0);

        public static readonly Net.TheVpc.Upa.Expressions.Literal ZERO = DZERO;

        public static readonly Net.TheVpc.Upa.Expressions.Literal NULL = new Net.TheVpc.Upa.Expressions.Literal(null, null);

        public static readonly Net.TheVpc.Upa.Expressions.Literal TRUE = new Net.TheVpc.Upa.Expressions.Literal(true);

        public static readonly Net.TheVpc.Upa.Expressions.Literal FALSE = new Net.TheVpc.Upa.Expressions.Literal(false);

        public static readonly Net.TheVpc.Upa.Expressions.Literal EMPTY_STRING = new Net.TheVpc.Upa.Expressions.Literal("");



        private Net.TheVpc.Upa.Types.DataType type;

        private object @value;

        public Literal(Net.TheVpc.Upa.Types.Temporal date) {
            SetValue(date);
        }

        public Literal(int @value) {
            SetValue(@value);
        }

        public Literal(bool @value) {
            SetValue((@value) ? new System.Nullable<bool>(true) : new System.Nullable<bool>(false));
        }

        public Literal(long @value) {
            SetValue(@value);
        }

        public Literal(float @value) {
            SetValue(@value);
        }

        public Literal(double @value) {
            SetValue(@value);
        }

        public Literal(char @value) {
            SetValue(@value);
        }

        public Literal(string @value) {
            SetValue(@value);
        }

        public Literal(object @value, Net.TheVpc.Upa.Types.DataType type) {
            //        if (
            //                value != null
            //                && !(value instanceof String)
            //                && !(value instanceof Number)
            //                && !(value instanceof Date)
            //                && !(value instanceof Boolean)
            //        ) {
            //            throw new UPAIllegalArgumentException("bad sql value : " + value.getClass().getName() + " ==> " + value);
            //        } else {
            this.@value = @value;
            if (type == null) {
                if (@value == null) {
                    type = Net.TheVpc.Upa.Types.TypesFactory.OBJECT;
                } else {
                    type = Net.TheVpc.Upa.Types.TypesFactory.ForPlatformType(@value.GetType());
                }
            }
            this.type = type;
        }


        public override System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.TaggedExpression> GetChildren() {
            return new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.TaggedExpression>();
        }


        public override void SetChild(Net.TheVpc.Upa.Expressions.Expression e, Net.TheVpc.Upa.Expressions.ExpressionTag tag) {
            throw new System.Exception("Not supported yet.");
        }

        public static bool IsNull(Net.TheVpc.Upa.Expressions.Expression e) {
            return e == null || ((e is Net.TheVpc.Upa.Expressions.Literal) && (((Net.TheVpc.Upa.Expressions.Literal) e).@value == null));
        }


        public override string ToString() {
            if (@value is string) {
                return Net.TheVpc.Upa.Expressions.ExpressionHelper.EscapeSimpleQuoteStringLiteral((string) @value);
            }
            return System.Convert.ToString(@value);
        }

        public object GetValue() {
            return @value;
        }

        private void SetValue(object o) {
            this.@value = o;
            if (o == null) {
                type = Net.TheVpc.Upa.Types.TypesFactory.OBJECT;
            } else {
                type = Net.TheVpc.Upa.Types.TypesFactory.ForPlatformType(o.GetType());
            }
        }


        public override Net.TheVpc.Upa.Expressions.Expression Copy() {
            return new Net.TheVpc.Upa.Expressions.Literal(@value, type);
        }

        public static Net.TheVpc.Upa.Expressions.Literal ValueOf(bool @value) {
            return @value ? TRUE : FALSE;
        }
    }
}
