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


    public interface Package : Net.TheVpc.Upa.PersistenceUnitPart {

         Net.TheVpc.Upa.PackageInfo GetInfo();

         string GetPath();

         void AddPart(Net.TheVpc.Upa.PersistenceUnitPart child);

         void AddPart(Net.TheVpc.Upa.PersistenceUnitPart child, int index);

         void RemovePartAt(int index);

         void MovePart(string itemName, int newIndex);

         void MovePart(int index, int newIndex);

         int GetPartsCount();

         System.Collections.Generic.IList<Net.TheVpc.Upa.PersistenceUnitPart> GetParts();

         System.Collections.Generic.IList<Net.TheVpc.Upa.Entity> GetEntities();

         System.Collections.Generic.IList<Net.TheVpc.Upa.Entity> GetEntities(bool includeSubPackages);

         System.Collections.Generic.IList<Net.TheVpc.Upa.Package> GetPackages();

         Net.TheVpc.Upa.Package GetPart(string name);

         int IndexOfPart(Net.TheVpc.Upa.PersistenceUnitPart child);

         int IndexOfPart(string childName);
    }
}
