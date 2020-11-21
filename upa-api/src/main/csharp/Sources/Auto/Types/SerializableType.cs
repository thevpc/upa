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
     * User: taha Date: 16 juin 2003 Time: 15:47:42
     */
    public class SerializableType : Net.TheVpc.Upa.Types.LOBType {


        public static readonly Net.TheVpc.Upa.Types.SerializableType DEFAULT = new Net.TheVpc.Upa.Types.SerializableType("SERIALIZABLE", typeof(object), true);

        public SerializableType(string name, System.Type platformType, bool nullable)  : base(name, platformType, nullable){

        }


        public override string ToString() {
            return "SerializableType{" + GetPlatformType() + "}";
        }
    }
}
