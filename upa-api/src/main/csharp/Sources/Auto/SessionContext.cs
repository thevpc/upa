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



namespace Net.Vpc.Upa
{

    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public interface SessionContext {

         void SetParam(Net.Vpc.Upa.PersistenceUnit persistenceUnit, string name, object @value);

         bool ContainsParam(Net.Vpc.Upa.PersistenceUnit persistenceUnit, string name);

          T GetParam<T>(Net.Vpc.Upa.PersistenceUnit persistenceUnit, System.Type type, string name, T defaultValue);
    }
}
