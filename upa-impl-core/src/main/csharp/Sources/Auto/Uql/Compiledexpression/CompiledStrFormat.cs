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



using System.Linq;
namespace Net.TheVpc.Upa.Impl.Uql.Compiledexpression
{


    public sealed class CompiledStrFormat : Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpressionImpl, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledExpandableExpression {



        private Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] expressions;

        private Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledCst pattern;

        public CompiledStrFormat(string pattern, params Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression [] expressions) {
            this.pattern = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledCst(pattern);
            PrepareChildren(this.pattern);
            this.expressions = expressions;
            PrepareChildren(expressions);
        }


        public override Net.TheVpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            return Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform.STRING;
        }


        public override bool IsValid() {
            return true;
        }


        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] expressions1 = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[expressions.Length];
            for (int i = 0; i < expressions.Length; i++) {
                expressions1[i] = expressions[i].Copy();
            }
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledStrFormat o = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledStrFormat((string) pattern.GetValue(), expressions1);
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
            return o;
        }


        public Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Expand(Net.TheVpc.Upa.PersistenceUnit PersistenceUnit) {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledConcat c = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledConcat();
            int i = 0;
            int varPos = 0;
            string str = (string) pattern.GetValue();
            while (i >= 0 && i < (str).Length) {
                int j = str.IndexOf("{", i);
                if (j < 0) {
                    c.Add(new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral(str.Substring(i)));
                    i = -1;
                } else {
                    c.Add(new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral(str.Substring(i, j)));
                    int k = str.IndexOf("}", j + 1);
                    string varName = null;
                    if (k < 0) {
                        varName = str.Substring(j + 1);
                        i = -1;
                    } else {
                        varName = (str.Substring(j + 1, k));
                        i = k + 1;
                    }
                    if (varName.Equals("?")) {
                        c.Add(expressions[varPos]);
                    } else if (Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsInt32(varName)) {
                        c.Add(expressions[System.Convert.ToInt32(varName)]);
                    } else {
                        throw new System.ArgumentException ("Unsupported");
                    }
                    varPos++;
                }
            }
            return c;
        }


        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] GetSubExpressions() {
            System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression> all = new System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression>();
            all.Add(pattern);
            Net.TheVpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(all, new System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression>(expressions));
            return all.ToArray();
        }


        public override void SetSubExpression(int index, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            if (index == 0) {
                pattern = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledCst) expression;
                PrepareChildren(pattern);
            } else {
                expressions[index - 1] = expression;
                PrepareChildren(expressions[index - 1]);
            }
        }
    }
}
