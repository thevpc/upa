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


    /**
     * Created with IntelliJ IDEA.
     * User: vpc
     * Date: 8/19/12
     * Time: 12:34 AM
     * To change this template use File | Settings | File Templates.
     */
    public class CompiledUnion : Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledEntityStatement, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement {

        private System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement> queryStatements = new System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement>();

        public virtual void Add(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement s) {
            queryStatements.Add(s);
            PrepareChildren(s);
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement> GetQueryStatements() {
            return new System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement>(queryStatements);
        }


        public override Net.TheVpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            if ((queryStatements.Count==0)) {
                return new Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform(Net.TheVpc.Upa.Types.TypesFactory.VOID);
            }
            return queryStatements[0].GetTypeTransform();
        }


        public virtual int CountFields() {
            return queryStatements[0].CountFields();
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField> GetFields() {
            return queryStatements[0].GetFields();
        }


        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField GetField(int i) {
            return queryStatements[0].GetField(i);
        }


        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] GetSubExpressions() {
            return queryStatements.ToArray();
        }


        public override bool IsValid() {
            if ((queryStatements.Count==0)) {
                return false;
            }
            foreach (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement queryStatement in queryStatements) {
                if (!queryStatement.IsValid()) {
                    return false;
                }
            }
            return true;
        }


        public override bool Equals(object o) {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledUnion union = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledUnion) o;
            if (queryStatements != null ? !queryStatements.Equals(union.queryStatements) : union.queryStatements != null) return false;
            return true;
        }


        public override int GetHashCode() {
            return queryStatements != null ? queryStatements.GetHashCode() : 0;
        }


        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledUnion o = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledUnion();
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
            foreach (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement queryStatement in queryStatements) {
                o.Add((Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement) queryStatement.Copy());
            }
            return o;
        }


        public override void SetSubExpression(int index, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            queryStatements[index]=(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement) expression;
        }


        protected internal override System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledNamedExpression> FindEntityDefinitions() {
            return Net.TheVpc.Upa.Impl.Util.PlatformUtils.EmptyList<T>();
        }
    }
}
