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



namespace Net.TheVpc.Upa
{

    /**
     * Password Strategy define a simple way to have a hashed field value handled
     * transparently by the framework
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public interface SecretStrategy {

         void Init(Net.TheVpc.Upa.PersistenceUnit persistenceUnit, string encodingKey, string decodingKey);

         byte[] Encode(byte[] @value);

         byte[] Decode(byte[] @value);
    }
}
