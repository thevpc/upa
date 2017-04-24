package net.vpc.upa;


/**
 * Created by vpc on 7/18/15.
 */
public interface CompoundDataType {

    FieldDescriptor[] getComposingFields(FieldDescriptor fieldDescriptor);

    /**
     * flatten an object value to resolve every primitive field value
     *
     * @param object to flatten
     * @return array of primitive value (in the same order of the fields definition)
     */
    Object[] getPrimitiveValues(Object object);

    /**
     * composed single value equivalent to the given array
     *
     * @param values flattened values to compose
     * @return composed single value equivalent to the given array
     */
    Object getCompoundValue(Object[] values);
}
