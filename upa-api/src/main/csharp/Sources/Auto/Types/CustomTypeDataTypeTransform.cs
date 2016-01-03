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
     * @author vpc
     */
    public class CustomTypeDataTypeTransform : Net.Vpc.Upa.Types.DataTypeTransformConfig {

        private string customType;

        public CustomTypeDataTypeTransform(string customType) {
            this.customType = customType;
        }

        public virtual string GetCustomType() {
            return customType;
        }
    }
}
