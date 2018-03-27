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



namespace Net.Vpc.Upa.Impl
{


    /**
     * type to be resolved as Entity (with relation) otherwise will be resolved as
     * Serializable
     *
     * @author taha.bensalah@gmail.com
     */
    public class SerializableOrManyToOneType : Net.Vpc.Upa.Types.DefaultDataType {

        public SerializableOrManyToOneType(string name, System.Type platformType, bool nullable)  : base(name, platformType, nullable){

        }

        public virtual System.Type GetEntityType() {
            return GetPlatformType();
        }


        public override System.Type GetPlatformType() {
            return base.GetPlatformType();
        }


        public override string ToString() {
            return "SerializableOrManyToOneType{" + GetPlatformType() + '}';
        }
    }
}
