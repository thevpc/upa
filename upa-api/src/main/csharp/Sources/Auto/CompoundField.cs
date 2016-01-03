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


    /**
     * A compound field defines a simple way for embeddable structures in Entities.
     * A compound Field defines a "super" field that is composed of a set of primitive fields.
     * Compound fields can not include other compound fields.
     */
    public interface CompoundField : Net.Vpc.Upa.Field {

        /**
             * all inner fields
             *
             * @return all fields
             */
         System.Collections.Generic.IList<Net.Vpc.Upa.PrimitiveField> GetFields();

        /**
             * field by position
             * @param index position
             * @return Field at the given position
             */
         Net.Vpc.Upa.PrimitiveField GetFieldAt(int index);

        /**
             * field by name
             * @param name name of the field
             * @return Field with the given name
             */
         Net.Vpc.Upa.PrimitiveField GetField(string name);

        /**
             * return index of the given field or -1 if not found
             * @param child field to look for
             * @return index of the given field or -1 if not found
             */
         int IndexOfField(Net.Vpc.Upa.PrimitiveField child);

        /**
             * return index of the given field or -1 if not found
             * @param fieldName field to look for
             * @return index of the given field or -1 if not found
             */
         int IndexOfField(string fieldName);

        /**
             * leading (very first) field
             * @return leading (very first) field
             */
         Net.Vpc.Upa.PrimitiveField GetLeadingField();

        /**
             * number of primitive fields in the compound field
             * @return number of primitive fields in the compound field
             */
         int GetFieldsCount();

        /**
             * flatten an object value to resolve every primitive field value
             * @param object to flatten
             * @return array of primitive value (in the same order of the fields definition)
             */
         object[] GetPrimitiveValues(object @object);

        /**
             * composed single value equivalent to the given array
             * @param values flattened values to compose
             * @return composed single value equivalent to the given array
             */
         object GetCompoundValue(object[] values);
    }
}
