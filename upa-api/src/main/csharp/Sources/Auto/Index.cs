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



namespace Net.Vpc.Upa
{

    public interface Index : Net.Vpc.Upa.UPAObject {

         void CommitModelChanges();

         Net.Vpc.Upa.Field[] GetFields();

         string[] GetFieldNames();

         Net.Vpc.Upa.Entity GetEntity();

         bool IsUnique();

         Net.Vpc.Upa.IndexInfo GetInfo();
    }
}
