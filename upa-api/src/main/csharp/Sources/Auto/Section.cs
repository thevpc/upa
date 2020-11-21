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


    public interface Section : Net.TheVpc.Upa.EntityPart {

         Net.TheVpc.Upa.Field AddField(Net.TheVpc.Upa.FieldBuilder fieldBuilder) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Field AddField(Net.TheVpc.Upa.FieldDescriptor fieldDescriptor) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void AddPart(Net.TheVpc.Upa.EntityPart child) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void AddPart(Net.TheVpc.Upa.EntityPart child, int index) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.EntityPart RemovePartAt(int index) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.EntityPart RemovePart(string name) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void MovePart(int index, int newIndex) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void MovePart(string itemName, int newIndex) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

        /**
             * @return this section (and it subsequent sub sections) fields
             * @throws UPAException
             */
         System.Collections.Generic.IList<Net.TheVpc.Upa.Field> GetFields() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.TheVpc.Upa.Field> GetFields(Net.TheVpc.Upa.Filters.FieldFilter fieldFilter) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

        /**
             * @return
             */
         System.Collections.Generic.IList<Net.TheVpc.Upa.Field> GetImmediateFields();

         System.Collections.Generic.IList<Net.TheVpc.Upa.Field> GetImmediateFields(Net.TheVpc.Upa.Filters.FieldFilter fieldFilter);

         System.Collections.Generic.IList<Net.TheVpc.Upa.Section> GetSections() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.TheVpc.Upa.EntityPart> GetParts() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.EntityPart GetPart(string name) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.EntityPart GetPartAt(int index) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Section GetSection(string name) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         int IndexOfPart(Net.TheVpc.Upa.EntityPart part) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         int IndexOfPart(string partName) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         int GetPartsCount() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Section FindSection(string path) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Section GetSection(string path, Net.TheVpc.Upa.MissingStrategy missingStrategy) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Section AddSection(string path, int index) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Section AddSection(string path) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.SectionInfo GetInfo();
    }
}
