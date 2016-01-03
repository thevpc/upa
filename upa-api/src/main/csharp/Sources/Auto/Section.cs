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


    public interface Section : Net.Vpc.Upa.EntityPart {

         Net.Vpc.Upa.Field AddField(string name, Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> modifiers, object defaultValue, Net.Vpc.Upa.Types.DataType type) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Field AddField(string name, Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> modifiers, object defaultValue, Net.Vpc.Upa.Types.DataType type, int index) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void AddPart(Net.Vpc.Upa.EntityPart child) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void AddPart(Net.Vpc.Upa.EntityPart child, int index) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.EntityPart RemovePartAt(int index) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.EntityPart RemovePart(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void MovePart(int index, int newIndex) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void MovePart(string itemName, int newIndex) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.Vpc.Upa.Field> GetFields() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.Vpc.Upa.Section> GetSections() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.Vpc.Upa.EntityPart> GetParts() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.EntityPart GetPart(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.EntityPart GetPartAt(int index) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Section GetSection(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         int IndexOfPart(Net.Vpc.Upa.EntityPart part) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         int IndexOfPart(string partName) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         int GetPartsCount() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Section FindSection(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Section GetSection(string path, Net.Vpc.Upa.MissingStrategy missingStrategy) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Section AddSection(string name, string parentPath) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Section AddSection(string name, string parentPath, int index) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Section AddSection(string name, int index) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Section AddSection(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;
    }
}
