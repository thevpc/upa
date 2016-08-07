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
     * Created by vpc on 7/18/15.
     */
    public interface CompoundDataType {

         Net.Vpc.Upa.FieldDescriptor[] GetComposingFields(Net.Vpc.Upa.FieldDescriptor fieldDescriptor);

        /**
             * flatten an object value to resolve every primitive field value
             *
             * @param object to flatten
             * @return array of primitive value (in the same order of the fields definition)
             */
         object[] GetPrimitiveValues(object @object);

        /**
             * composed single value equivalent to the given array
             *
             * @param values flattened values to compose
             * @return composed single value equivalent to the given array
             */
         object GetCompoundValue(object[] values);
    }
}
