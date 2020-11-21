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


    public class ScanConfig : System.Attribute {

        private string _Types = "";
        public  string Types{
            get {return _Types;}
            set {_Types=value;}
        }


        private string _Libs = "";
        public  string Libs{
            get {return _Libs;}
            set {_Libs=value;}
        }


        private Net.TheVpc.Upa.Config.BoolEnum _Propagate = Net.TheVpc.Upa.Config.BoolEnum.UNDEFINED;
        public  Net.TheVpc.Upa.Config.BoolEnum Propagate{
            get {return _Propagate;}
            set {_Propagate=value;}
        }

    }
}
