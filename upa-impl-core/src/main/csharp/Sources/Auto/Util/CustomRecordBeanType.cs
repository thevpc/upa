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



namespace Net.TheVpc.Upa.Impl.Util
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/27/12 12:16 AM
     */
    public class CustomRecordBeanType : Net.TheVpc.Upa.Impl.Util.RecordBeanType {

        private Net.TheVpc.Upa.BeanType customType;

        public CustomRecordBeanType(Net.TheVpc.Upa.Entity entity, System.Type customType)  : base(entity){

            this.customType = Net.TheVpc.Upa.Impl.Util.PlatformBeanTypeRepository.GetInstance().GetBeanType(customType);
        }


        public override System.Type GetPlatformType() {
            return customType.GetPlatformType();
        }

        public override object NewInstance() {
            return customType.NewInstance();
        }
    }
}
