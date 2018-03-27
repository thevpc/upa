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



namespace Net.Vpc.Upa.Impl.Persistence
{


    /**
    * @author Taha BEN SALAH <taha.bensalah@gmail.com>
    * @creationdate 1/10/13 11:30 PM*/
    public class CloseOnContextPopSessionListener : Net.Vpc.Upa.Callbacks.SessionListenerAdapter {

        private readonly Net.Vpc.Upa.Persistence.UConnection finalConnection;

        private Net.Vpc.Upa.PersistenceUnit pu;

        public CloseOnContextPopSessionListener(Net.Vpc.Upa.PersistenceUnit pu, Net.Vpc.Upa.Persistence.UConnection finalConnection) {
            this.pu = pu;
            this.finalConnection = finalConnection;
        }


        public override void PopContext(Net.Vpc.Upa.Session session) {
            Net.Vpc.Upa.SessionContext currentContext = session.GetCurrentContext();
            Net.Vpc.Upa.Persistence.UConnection sconnection = currentContext.GetParam<T>(pu, typeof(Net.Vpc.Upa.Persistence.UConnection), Net.Vpc.Upa.Impl.SessionParams.CONNECTION, null);
            if (sconnection != null && sconnection == finalConnection) {
                sconnection.Close();
                currentContext.SetParam(pu, Net.Vpc.Upa.Impl.SessionParams.CONNECTION, null);
                session.RemoveSessionListener(this);
            }
        }
    }
}
