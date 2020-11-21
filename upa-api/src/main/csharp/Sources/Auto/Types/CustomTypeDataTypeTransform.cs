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
    public class CustomTypeDataTypeTransform : Net.TheVpc.Upa.Types.DataTypeTransformConfig {

        private string customType;

        public CustomTypeDataTypeTransform(string customType) {
            this.customType = customType;
        }

        public virtual string GetCustomType() {
            return customType;
        }
    }
}
