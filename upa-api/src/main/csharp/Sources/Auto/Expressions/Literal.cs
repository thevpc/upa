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



namespace Net.Vpc.Upa.Expressions
{


    public sealed class Literal : Net.Vpc.Upa.Expressions.DefaultExpression {

        public static readonly Net.Vpc.Upa.Expressions.Literal IONE = new Net.Vpc.Upa.Expressions.Literal(1);

        public static readonly Net.Vpc.Upa.Expressions.Literal IZERO = new Net.Vpc.Upa.Expressions.Literal(0);

        public static readonly Net.Vpc.Upa.Expressions.Literal DZERO = new Net.Vpc.Upa.Expressions.Literal(0.0);

        public static readonly Net.Vpc.Upa.Expressions.Literal ZERO = DZERO;

        public static readonly Net.Vpc.Upa.Expressions.Literal NULL = new Net.Vpc.Upa.Expressions.Literal(null, null);

        public static readonly Net.Vpc.Upa.Expressions.Literal TRUE = new Net.Vpc.Upa.Expressions.Literal(true);

        public static readonly Net.Vpc.Upa.Expressions.Literal FALSE = new Net.Vpc.Upa.Expressions.Literal(false);

        public static readonly Net.Vpc.Upa.Expressions.Literal EMPTY_STRING = new Net.Vpc.Upa.Expressions.Literal("");



        private Net.Vpc.Upa.Types.DataType type;

        private object @value;

        public Literal(Net.Vpc.Upa.Types.Temporal date) {
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

        public Literal(object @value, Net.Vpc.Upa.Types.DataType type) {
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
                    type = Net.Vpc.Upa.Types.TypesFactory.OBJECT;
                } else {
                    type = Net.Vpc.Upa.Types.TypesFactory.ForPlatformType(@value.GetType());
                }
            }
            this.type = type;
        }


        public override System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.TaggedExpression> GetChildren() {
            return new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.TaggedExpression>();
        }


        public override void SetChild(Net.Vpc.Upa.Expressions.Expression e, Net.Vpc.Upa.Expressions.ExpressionTag tag) {
            throw new System.Exception("Not supported yet.");
        }

        public static bool IsNull(Net.Vpc.Upa.Expressions.Expression e) {
            return e == null || ((e is Net.Vpc.Upa.Expressions.Literal) && (((Net.Vpc.Upa.Expressions.Literal) e).@value == null));
        }


        public override string ToString() {
            if (@value is string) {
                return Net.Vpc.Upa.Expressions.ExpressionHelper.EscapeSimpleQuoteStringLiteral((string) @value);
            }
            return System.Convert.ToString(@value);
        }

        public object GetValue() {
            return @value;
        }

        private void SetValue(object o) {
            this.@value = o;
            if (o == null) {
                type = Net.Vpc.Upa.Types.TypesFactory.OBJECT;
            } else {
                type = Net.Vpc.Upa.Types.TypesFactory.ForPlatformType(o.GetType());
            }
        }


        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            return new Net.Vpc.Upa.Expressions.Literal(@value, type);
        }

        public static Net.Vpc.Upa.Expressions.Literal ValueOf(bool @value) {
            return @value ? TRUE : FALSE;
        }
    }
}
