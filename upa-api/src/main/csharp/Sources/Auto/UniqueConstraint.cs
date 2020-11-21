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



namespace Net.TheVpc.Upa
{


    public interface UniqueConstraint : Net.TheVpc.Upa.UPAObject {

         void CommitModelChanges();

         System.Collections.Generic.IList<Net.TheVpc.Upa.Field> GetFields();

         System.Collections.Generic.IList<string> GetFieldNames();

         Net.TheVpc.Upa.Entity GetEntity();

         string GetEntityName();

         bool IsUnique();
    }
}
