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
     * User: taha Date: 16 juin 2003 Time: 15:47:42
     */
    public class SerializableType : Net.Vpc.Upa.Types.LOBType {


        public static readonly Net.Vpc.Upa.Types.SerializableType DEFAULT = new Net.Vpc.Upa.Types.SerializableType("SERIALIZABLE", typeof(object), true);

        public SerializableType(string name, System.Type platformType, bool nullable)  : base(name, platformType, nullable){

        }


        public override string ToString() {
            return "SerializableType{" + GetPlatformType() + "}";
        }
    }
}
