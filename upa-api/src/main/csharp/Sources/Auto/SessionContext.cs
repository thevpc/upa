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
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public interface SessionContext {

         void SetParam(Net.TheVpc.Upa.PersistenceUnit persistenceUnit, string name, object @value);

         bool ContainsParam(Net.TheVpc.Upa.PersistenceUnit persistenceUnit, string name);

          T GetParam<T>(Net.TheVpc.Upa.PersistenceUnit persistenceUnit, System.Type type, string name, T defaultValue);
    }
}
