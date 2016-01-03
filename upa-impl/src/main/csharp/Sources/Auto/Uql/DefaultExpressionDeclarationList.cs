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



namespace Net.Vpc.Upa.Impl.Uql
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/19/12 7:22 PM
     */
    public class DefaultExpressionDeclarationList : Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList {

        private Net.Vpc.Upa.Impl.Uql.DefaultExpressionDeclarationList parentDeclaration;

        private System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration> exportedDeclarations;

        public DefaultExpressionDeclarationList(Net.Vpc.Upa.Impl.Uql.DefaultExpressionDeclarationList parentDeclaration) {
            exportedDeclarations = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration>();
            this.parentDeclaration = parentDeclaration;
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration> GetExportedDeclarations() {
            System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration> emptyList = Net.Vpc.Upa.Impl.Util.PlatformUtils.EmptyList<Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration>();
            return exportedDeclarations == null ? emptyList : exportedDeclarations;
        }

        public virtual void ExportDeclaration(string name, Net.Vpc.Upa.Impl.Uql.DecObjectType type, object referrerName, object referrerParentId) {
            if (exportedDeclarations == null) {
                exportedDeclarations = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration>(3);
            }
            exportedDeclarations.Add(new Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration(name, type, referrerName, referrerParentId));
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration> GetDeclarations(string alias) {
            if (alias == null) {
                //check all
                System.Collections.Generic.List<Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration> objects = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration>();
                if (exportedDeclarations != null) {
                    for (int i = (exportedDeclarations).Count - 1; i >= 0; i--) {
                        Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration d = exportedDeclarations[i];
                        objects.Add(d);
                    }
                }
                if (parentDeclaration != null) {
                    Net.Vpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(objects, parentDeclaration.GetDeclarations(alias));
                }
                return objects;
            } else {
                System.Collections.Generic.List<Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration> objects = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration>();
                for (int i = (exportedDeclarations).Count - 1; i >= 0; i--) {
                    Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration d = exportedDeclarations[i];
                    if (alias.Equals(d.GetValidName())) {
                        objects.Add(d);
                    }
                }
                if (parentDeclaration != null) {
                    Net.Vpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(objects, parentDeclaration.GetDeclarations(alias));
                }
                return objects;
            }
        }


        public override string ToString() {
            return "{" + parentDeclaration + ", " + exportedDeclarations + '}';
        }

        public virtual Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration GetDeclaration(string name) {
            System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration> values = GetDeclarations(name);
            if ((values.Count==0)) {
                return null;
            }
            return values[0];
        }

        public virtual Net.Vpc.Upa.Impl.Uql.DefaultExpressionDeclarationList GetParentDeclaration() {
            return parentDeclaration;
        }

        public virtual void SetParentDeclaration(Net.Vpc.Upa.Impl.Uql.DefaultExpressionDeclarationList parentDeclaration) {
            this.parentDeclaration = parentDeclaration;
        }
    }
}
