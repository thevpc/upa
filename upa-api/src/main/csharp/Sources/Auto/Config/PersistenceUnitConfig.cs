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

    public class PersistenceUnitConfig : System.Attribute {

        private string _Name = "";
        public  string Name{
            get {return _Name;}
            set {_Name=value;}
        }


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


        private Net.TheVpc.Upa.Config.Property[] _Properties = {  };
        public  Net.TheVpc.Upa.Config.Property[] Properties{
            get {return _Properties;}
            set {_Properties=value;}
        }


        private Net.TheVpc.Upa.Config.ConnectionConfig[] _Connections = {  };
        public  Net.TheVpc.Upa.Config.ConnectionConfig[] Connections{
            get {return _Connections;}
            set {_Connections=value;}
        }


        private Net.TheVpc.Upa.Config.ConnectionConfig[] _RootConnections = {  };
        public  Net.TheVpc.Upa.Config.ConnectionConfig[] RootConnections{
            get {return _RootConnections;}
            set {_RootConnections=value;}
        }

    }
}
