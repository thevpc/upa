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



namespace Net.Vpc.Upa.Persistence
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/29/12 12:27 AM
     */
    public interface UnionEntityExtension : Net.Vpc.Upa.Persistence.EntityExtension {

         System.Collections.Generic.IList<Net.Vpc.Upa.Entity> GetEntities() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         string GetUpdatedField(string viewFieldName, Net.Vpc.Upa.Entity entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         string GetDiscriminator() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         int IndexOf(Net.Vpc.Upa.Entity entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.QualifiedIdentifier GetViewElementKey(Net.Vpc.Upa.QualifiedIdentifier viewKey) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Expressions.QueryStatement GetQuery() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;
    }
}
