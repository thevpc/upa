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



namespace Net.Vpc.Upa.Persistence
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public interface QueryResult : Net.Vpc.Upa.Closeable {

         int GetFieldsCount();

          T Read<T>(int index);

          void Write<T>(int index, T @value);

         bool HasNext();

         void UpdateCurrent();
    }
}
