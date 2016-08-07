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
    [System.AttributeUsage(System.AttributeTargets.Class)]

    public class Callback : System.Attribute {

        private string _Name = "";
        public  string Name{
            get {return _Name;}
            set {_Name=value;}
        }


        private string _Filter = "";
        public  string Filter{
            get {return _Filter;}
            set {_Filter=value;}
        }


        private bool _TrackSystemObjects = false;
        public  bool TrackSystemObjects{
            get {return _TrackSystemObjects;}
            set {_TrackSystemObjects=value;}
        }


        private Net.Vpc.Upa.Config.Config _Config = new Net.Vpc.Upa.Config.Config();
        public  Net.Vpc.Upa.Config.Config Config{
            get {return _Config;}
            set {_Config=value;}
        }

    }
}
