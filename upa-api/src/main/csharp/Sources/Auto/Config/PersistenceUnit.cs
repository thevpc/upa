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

    public class PersistenceUnit : System.Attribute {

        private string _Name = Net.TheVpc.Upa.UPA.UNDEFINED_STRING;
        public  string Name{
            get {return _Name;}
            set {_Name=value;}
        }


        private string _PersistenceGroup = Net.TheVpc.Upa.UPA.UNDEFINED_STRING;
        public  string PersistenceGroup{
            get {return _PersistenceGroup;}
            set {_PersistenceGroup=value;}
        }


        private int _ConfigOrder = 0;
        public  int ConfigOrder{
            get {return _ConfigOrder;}
            set {_ConfigOrder=value;}
        }


        private Net.TheVpc.Upa.Config.Property[] _Properties = {  };
        public  Net.TheVpc.Upa.Config.Property[] Properties{
            get {return _Properties;}
            set {_Properties=value;}
        }

    }
}
