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



namespace Net.TheVpc.Upa.Types
{

    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public interface DataTypeTransform {

         object TransformValue(object @value);

         object ReverseTransformValue(object @value);

         Net.TheVpc.Upa.Types.DataType GetSourceType();

         Net.TheVpc.Upa.Types.DataType GetTargetType();

         Net.TheVpc.Upa.Types.DataTypeTransform Chain(Net.TheVpc.Upa.Types.DataTypeTransform other);
    }
}
