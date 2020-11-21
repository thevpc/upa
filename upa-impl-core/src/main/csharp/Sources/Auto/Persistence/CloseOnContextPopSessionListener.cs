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



namespace Net.TheVpc.Upa.Impl.Persistence
{


    /**
    * @author Taha BEN SALAH <taha.bensalah@gmail.com>
    * @creationdate 1/10/13 11:30 PM*/
    public class CloseOnContextPopSessionListener : Net.TheVpc.Upa.Callbacks.SessionListenerAdapter {

        private readonly Net.TheVpc.Upa.Persistence.UConnection finalConnection;

        private Net.TheVpc.Upa.PersistenceUnit pu;

        public CloseOnContextPopSessionListener(Net.TheVpc.Upa.PersistenceUnit pu, Net.TheVpc.Upa.Persistence.UConnection finalConnection) {
            this.pu = pu;
            this.finalConnection = finalConnection;
        }


        public override void PopContext(Net.TheVpc.Upa.Session session) {
            Net.TheVpc.Upa.SessionContext currentContext = session.GetCurrentContext();
            Net.TheVpc.Upa.Persistence.UConnection sconnection = currentContext.GetParam<T>(pu, typeof(Net.TheVpc.Upa.Persistence.UConnection), Net.TheVpc.Upa.Impl.SessionParams.CONNECTION, null);
            if (sconnection != null && sconnection == finalConnection) {
                sconnection.Close();
                currentContext.SetParam(pu, Net.TheVpc.Upa.Impl.SessionParams.CONNECTION, null);
                session.RemoveSessionListener(this);
            }
        }
    }
}
