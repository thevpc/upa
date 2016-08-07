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
    public interface StringEncoder {

         string Encode(byte[] bytes);

         byte[] Decode(string @value);
    }
}
