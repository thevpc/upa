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



namespace Net.Vpc.Upa
{


    public interface UniqueConstraint : Net.Vpc.Upa.UPAObject {

         void CommitModelChanges();

         System.Collections.Generic.IList<Net.Vpc.Upa.Field> GetFields();

         System.Collections.Generic.IList<string> GetFieldNames();

         Net.Vpc.Upa.Entity GetEntity();

         string GetEntityName();

         bool IsUnique();
    }
}
