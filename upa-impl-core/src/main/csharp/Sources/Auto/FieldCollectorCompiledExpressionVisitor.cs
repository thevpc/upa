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



namespace Net.TheVpc.Upa.Impl
{


    /**
    * @author Taha BEN SALAH <taha.bensalah@gmail.com>
    * @creationdate 1/7/13 11:37 PM*/
    internal class FieldCollectorCompiledExpressionVisitor : Net.TheVpc.Upa.Impl.Uql.CompiledExpressionVisitor {

        private readonly System.Collections.Generic.ISet<Net.TheVpc.Upa.Field> usedFields;

        public FieldCollectorCompiledExpressionVisitor(System.Collections.Generic.ISet<Net.TheVpc.Upa.Field> usedFields) {
            this.usedFields = usedFields;
        }

        public virtual bool Visit(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression e) {
            if (e is Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) {
                Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar v = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) e;
                if (v.GetReferrer() is Net.TheVpc.Upa.Field) {
                    usedFields.Add((Net.TheVpc.Upa.Field) v.GetReferrer());
                }
            }
            return true;
        }
    }
}
