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



namespace Net.TheVpc.Upa.Config
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/4/12 11:00 PM
     */
    [System.AttributeUsage(System.AttributeTargets.Class)]

    public class Config : System.Attribute {

        private Net.TheVpc.Upa.Config.BoolEnum _AutoScan = Net.TheVpc.Upa.Config.BoolEnum.UNDEFINED;
        public  Net.TheVpc.Upa.Config.BoolEnum AutoScan{
            get {return _AutoScan;}
            set {_AutoScan=value;}
        }


        private Net.TheVpc.Upa.Config.ScanConfig[] _Scan = {  };
        public  Net.TheVpc.Upa.Config.ScanConfig[] Scan{
            get {return _Scan;}
            set {_Scan=value;}
        }


        private Net.TheVpc.Upa.Config.PersistenceGroupConfig[] _PersistenceGroups = {  };
        public  Net.TheVpc.Upa.Config.PersistenceGroupConfig[] PersistenceGroups{
            get {return _PersistenceGroups;}
            set {_PersistenceGroups=value;}
        }


        private Net.TheVpc.Upa.Config.PersistenceUnitConfig[] _PersistenceUnits = {  };
        public  Net.TheVpc.Upa.Config.PersistenceUnitConfig[] PersistenceUnits{
            get {return _PersistenceUnits;}
            set {_PersistenceUnits=value;}
        }


        private Net.TheVpc.Upa.Config.ConnectionConfig[] _Connection = {  };
        public  Net.TheVpc.Upa.Config.ConnectionConfig[] Connection{
            get {return _Connection;}
            set {_Connection=value;}
        }


        private Net.TheVpc.Upa.Config.ConnectionConfig[] _RootConnection = {  };
        public  Net.TheVpc.Upa.Config.ConnectionConfig[] RootConnection{
            get {return _RootConnection;}
            set {_RootConnection=value;}
        }


        private Net.TheVpc.Upa.Config.Property[] _Properties = {  };
        public  Net.TheVpc.Upa.Config.Property[] Properties{
            get {return _Properties;}
            set {_Properties=value;}
        }

    }
}
