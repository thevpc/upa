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



namespace Net.Vpc.Upa.Types
{

    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public interface DataTypeTransform {

         object TransformValue(object @value);

         object ReverseTransformValue(object @value);

         Net.Vpc.Upa.Types.DataType GetSourceType();

         Net.Vpc.Upa.Types.DataType GetTargetType();

         Net.Vpc.Upa.Types.DataTypeTransform Chain(Net.Vpc.Upa.Types.DataTypeTransform other);
    }
}
