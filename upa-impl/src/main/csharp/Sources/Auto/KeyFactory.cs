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
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/27/12 1:51 AM
     */
    public interface KeyFactory {

         Net.Vpc.Upa.Key CreateKey(params object [] keyValues);

         object CreateId(params object [] keyValues);

         object GetId(Net.Vpc.Upa.Key unstructuredKey);

         Net.Vpc.Upa.Key GetKey(object key);
    }
}
