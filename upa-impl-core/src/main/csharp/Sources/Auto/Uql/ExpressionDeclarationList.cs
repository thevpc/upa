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
    public interface ExpressionDeclarationList {

         System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration> GetExportedDeclarations();

         void ExportDeclaration(string name, Net.Vpc.Upa.Impl.Uql.DecObjectType type, object referrerName, object referrerParentId);

         System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration> GetDeclarations(string alias);

         Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration GetDeclaration(string name);
    }
}
