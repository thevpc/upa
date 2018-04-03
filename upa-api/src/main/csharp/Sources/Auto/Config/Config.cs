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



namespace Net.Vpc.Upa.Config
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/4/12 11:00 PM
     */
    [System.AttributeUsage(System.AttributeTargets.Class)]

    public class Config : System.Attribute {

        private Net.Vpc.Upa.Config.BoolEnum _AutoScan = Net.Vpc.Upa.Config.BoolEnum.UNDEFINED;
        public  Net.Vpc.Upa.Config.BoolEnum AutoScan{
            get {return _AutoScan;}
            set {_AutoScan=value;}
        }


        private Net.Vpc.Upa.Config.ScanConfig[] _Scan = {  };
        public  Net.Vpc.Upa.Config.ScanConfig[] Scan{
            get {return _Scan;}
            set {_Scan=value;}
        }


        private Net.Vpc.Upa.Config.PersistenceGroupConfig[] _PersistenceGroups = {  };
        public  Net.Vpc.Upa.Config.PersistenceGroupConfig[] PersistenceGroups{
            get {return _PersistenceGroups;}
            set {_PersistenceGroups=value;}
        }


        private Net.Vpc.Upa.Config.PersistenceUnitConfig[] _PersistenceUnits = {  };
        public  Net.Vpc.Upa.Config.PersistenceUnitConfig[] PersistenceUnits{
            get {return _PersistenceUnits;}
            set {_PersistenceUnits=value;}
        }


        private Net.Vpc.Upa.Config.ConnectionConfig[] _Connection = {  };
        public  Net.Vpc.Upa.Config.ConnectionConfig[] Connection{
            get {return _Connection;}
            set {_Connection=value;}
        }


        private Net.Vpc.Upa.Config.ConnectionConfig[] _RootConnection = {  };
        public  Net.Vpc.Upa.Config.ConnectionConfig[] RootConnection{
            get {return _RootConnection;}
            set {_RootConnection=value;}
        }


        private Net.Vpc.Upa.Config.Property[] _Properties = {  };
        public  Net.Vpc.Upa.Config.Property[] Properties{
            get {return _Properties;}
            set {_Properties=value;}
        }

    }
}
