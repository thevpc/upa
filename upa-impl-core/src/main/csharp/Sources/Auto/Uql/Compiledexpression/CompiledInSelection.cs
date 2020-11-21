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


    public sealed class CompiledInSelection : Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpressionImpl {



        private Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] left;

        private Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect query;

        public CompiledInSelection(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression left, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect query)  : this(new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] { left }, query){

        }

        public override Net.TheVpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            return Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform.BOOLEAN;
        }

        public CompiledInSelection(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] left, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect query) {
            this.left = left;
            this.query = query;
            PrepareChildren(left);
            PrepareChildren(query);
        }

        public int Size() {
            return 2;
        }

        public Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] GetLeft() {
            return left;
        }

        public Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect GetSelection() {
            return query;
        }

        public override bool IsValid() {
            return query.IsValid();
        }


        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] left2 = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[left.Length];
            for (int i = 0; i < left2.Length; i++) {
                left2[i] = left[i].Copy();
            }
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledInSelection o = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledInSelection(left2, (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect) query.Copy());
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
            return o;
        }


        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] GetSubExpressions() {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression> all = new System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression>();
            Net.TheVpc.Upa.Impl.Util.PlatformUtils.AddAll<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression>(all, left);
            all.Add(query);
            return all.ToArray();
        }


        public override void SetSubExpression(int index, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            if (index < left.Length) {
                left[index] = expression;
            } else {
                query = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect) expression;
            }
        }
    }
}
