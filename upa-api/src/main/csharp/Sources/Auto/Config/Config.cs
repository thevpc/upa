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



namespace Net.Vpc.Upa.Config
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/4/12 11:00 PM
     */


    public class Config : System.Attribute {

        private string _PackagePath = Net.Vpc.Upa.UPA.UNDEFINED_STRING;
        public  string PackagePath{
            get {return _PackagePath;}
            set {_PackagePath=value;}
        }


        private string _PersistenceUnit = Net.Vpc.Upa.UPA.UNDEFINED_STRING;
        public  string PersistenceUnit{
            get {return _PersistenceUnit;}
            set {_PersistenceUnit=value;}
        }


        private string _PersistenceGroup = Net.Vpc.Upa.UPA.UNDEFINED_STRING;
        public  string PersistenceGroup{
            get {return _PersistenceGroup;}
            set {_PersistenceGroup=value;}
        }


        /**
             * Config order defines the order according to which configuration process
             * is applied
             *
             * @return config order
             */
        private int _Order = 0;
        public  int Order{
            get {return _Order;}
            set {_Order=value;}
        }


        private Net.Vpc.Upa.Config.ConfigAction _Action = Net.Vpc.Upa.Config.ConfigAction.MERGE;
        public  Net.Vpc.Upa.Config.ConfigAction Action{
            get {return _Action;}
            set {_Action=value;}
        }

    }
}
