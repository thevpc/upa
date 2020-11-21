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



namespace Net.TheVpc.Upa.Impl
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/27/12 1:51 AM
     */
    public interface KeyFactory {

         Net.TheVpc.Upa.Key CreateKey(params object [] idValues);

         object CreateId(params object [] idValues);

         object GetId(Net.TheVpc.Upa.Key unstructuredKey);

         Net.TheVpc.Upa.Key GetKey(object id);
    }
}
