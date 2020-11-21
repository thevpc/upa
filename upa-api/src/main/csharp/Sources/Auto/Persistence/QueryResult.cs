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



namespace Net.TheVpc.Upa.Persistence
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public interface QueryResult : Net.TheVpc.Upa.Closeable {

         string GetColumnName(int index);

         System.Type GetColumnType(int index);

         int GetColumnsCount();

          T Read<T>(int index);

          void Write<T>(int index, T @value);

         bool HasNext();

         void UpdateCurrent();
    }
}
