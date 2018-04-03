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


    public interface Package : Net.Vpc.Upa.PersistenceUnitPart {

         Net.Vpc.Upa.PackageInfo GetInfo();

         string GetPath();

         void AddPart(Net.Vpc.Upa.PersistenceUnitPart child);

         void AddPart(Net.Vpc.Upa.PersistenceUnitPart child, int index);

         void RemovePartAt(int index);

         void MovePart(string itemName, int newIndex);

         void MovePart(int index, int newIndex);

         int GetPartsCount();

         System.Collections.Generic.IList<Net.Vpc.Upa.PersistenceUnitPart> GetParts();

         System.Collections.Generic.IList<Net.Vpc.Upa.Entity> GetEntities();

         System.Collections.Generic.IList<Net.Vpc.Upa.Entity> GetEntities(bool includeSubPackages);

         System.Collections.Generic.IList<Net.Vpc.Upa.Package> GetPackages();

         Net.Vpc.Upa.Package GetPart(string name);

         int IndexOfPart(Net.Vpc.Upa.PersistenceUnitPart child);

         int IndexOfPart(string childName);
    }
}
