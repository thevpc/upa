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



namespace Net.Vpc.Upa
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/11/12 11:53 PM
     */
    public interface Session : Net.Vpc.Upa.Closeable {

         void Init(Net.Vpc.Upa.PersistenceGroup manager);

         Net.Vpc.Upa.SessionContext GetCurrentContext();

         void PushContext();

         void PopContext();

         void SetParam(Net.Vpc.Upa.PersistenceUnit persistenceUnit, string name, object @value);

          T GetParam<T>(Net.Vpc.Upa.PersistenceUnit persistenceUnit, System.Type type, string name, T defaultValue);

          T GetImmediateParam<T>(Net.Vpc.Upa.PersistenceUnit persistenceUnit, System.Type type, string name, T defaultValue);

         void AddSessionListener(Net.Vpc.Upa.Callbacks.SessionListener sessionListener);

         void RemoveSessionListener(Net.Vpc.Upa.Callbacks.SessionListener sessionListener);
    }
}
