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



namespace Net.Vpc.Upa.Impl
{


    /**
    * @author Taha BEN SALAH <taha.bensalah@gmail.com>
    * @creationdate 1/7/13 11:37 PM*/
    internal class FieldCollectorCompiledExpressionVisitor : Net.Vpc.Upa.Impl.Uql.CompiledExpressionVisitor {

        private readonly System.Collections.Generic.ISet<Net.Vpc.Upa.Field> usedFields;

        public FieldCollectorCompiledExpressionVisitor(System.Collections.Generic.ISet<Net.Vpc.Upa.Field> usedFields) {
            this.usedFields = usedFields;
        }

        public virtual bool Visit(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression e) {
            if (e is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) {
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar v = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) e;
                if (v.GetReferrer() is Net.Vpc.Upa.Field) {
                    usedFields.Add((Net.Vpc.Upa.Field) v.GetReferrer());
                }
            }
            return true;
        }
    }
}
