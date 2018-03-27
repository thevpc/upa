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
    * @creationdate 1/8/13 2:26 PM*/
    internal class CloseSessionListener : Net.Vpc.Upa.Callbacks.SessionListenerAdapter {

        private Net.Vpc.Upa.Impl.DefaultPersistenceGroup defaultPersistenceGroup;

        public CloseSessionListener(Net.Vpc.Upa.Impl.DefaultPersistenceGroup defaultPersistenceGroup) {
            this.defaultPersistenceGroup = defaultPersistenceGroup;
        }


        public override void CloseSession(Net.Vpc.Upa.Session session) {
            defaultPersistenceGroup.OnSessionClosed(session);
        }
    }
}
