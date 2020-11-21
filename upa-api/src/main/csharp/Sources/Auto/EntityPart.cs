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

    public interface EntityPart : Net.TheVpc.Upa.UPAObject {

         Net.TheVpc.Upa.Entity GetEntity();

         Net.TheVpc.Upa.EntityPart GetParent();

         string GetPath();

         void CommitModelChanges();
    }
}
