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



namespace Net.TheVpc.Upa.Persistence
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/29/12 12:27 AM
     */
    public interface UnionEntityExtension : Net.TheVpc.Upa.Persistence.EntityExtension {

         System.Collections.Generic.IList<Net.TheVpc.Upa.Entity> GetEntities() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         string GetUpdatedField(string viewFieldName, Net.TheVpc.Upa.Entity entity) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         string GetDiscriminator() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         int IndexOf(Net.TheVpc.Upa.Entity entity) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.QualifiedIdentifier GetViewElementKey(Net.TheVpc.Upa.QualifiedIdentifier viewKey) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Expressions.QueryStatement GetQuery() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;
    }
}
