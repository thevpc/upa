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

    public interface EntityPart : Net.Vpc.Upa.UPAObject {

         Net.Vpc.Upa.Entity GetEntity();

         Net.Vpc.Upa.EntityPart GetParent();

         string GetPath();

         void CommitModelChanges();
    }
}
