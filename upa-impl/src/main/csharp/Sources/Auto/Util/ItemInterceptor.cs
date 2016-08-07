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



namespace Net.Vpc.Upa.Impl.Util
{

    /**
    * @author Taha BEN SALAH <taha.bensalah@gmail.com>
    * @creationdate 1/4/13 12:15 AM*/
    public interface ItemInterceptor<T> {

         void Before(T t, int index);

         void After(T t, int index);
    }
}
