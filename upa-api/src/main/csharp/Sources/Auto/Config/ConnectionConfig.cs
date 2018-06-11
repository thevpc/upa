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

    public class ConnectionConfig : System.Attribute {

        private string _ConnexionString = "";
        public  string ConnexionString{
            get {return _ConnexionString;}
            set {_ConnexionString=value;}
        }


        private string _UserName = "";
        public  string UserName{
            get {return _UserName;}
            set {_UserName=value;}
        }


        private string _Password = "";
        public  string Password{
            get {return _Password;}
            set {_Password=value;}
        }


        private Net.Vpc.Upa.Persistence.StructureStrategy _StructureStrategy = Net.Vpc.Upa.Persistence.StructureStrategy.CREATE;
        public  Net.Vpc.Upa.Persistence.StructureStrategy StructureStrategy{
            get {return _StructureStrategy;}
            set {_StructureStrategy=value;}
        }


        private Net.Vpc.Upa.Config.Property[] _Properties = {  };
        public  Net.Vpc.Upa.Config.Property[] Properties{
            get {return _Properties;}
            set {_Properties=value;}
        }

    }
}
