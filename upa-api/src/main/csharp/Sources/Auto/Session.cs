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
     * @creationdate 9/11/12 11:53 PM
     */
    public interface Session : Net.TheVpc.Upa.Closeable {

         void Init(Net.TheVpc.Upa.PersistenceGroup manager);

         Net.TheVpc.Upa.SessionContext GetCurrentContext();

         void PushContext();

         void PopContext();

         void SetParam(Net.TheVpc.Upa.PersistenceUnit persistenceUnit, string name, object @value);

          T GetParam<T>(Net.TheVpc.Upa.PersistenceUnit persistenceUnit, System.Type type, string name, T defaultValue);

          T GetImmediateParam<T>(Net.TheVpc.Upa.PersistenceUnit persistenceUnit, System.Type type, string name, T defaultValue);

         void AddSessionListener(Net.TheVpc.Upa.Callbacks.SessionListener sessionListener);

         void RemoveSessionListener(Net.TheVpc.Upa.Callbacks.SessionListener sessionListener);
    }
}
