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
     */

    [System.AttributeUsage(System.AttributeTargets.Class|System.AttributeTargets.Method|System.AttributeTargets.Field)]
    public class Property : System.Attribute {

        private string _Name;
        public  string Name{
            get {return _Name;}
            set {_Name=value;}
        }


        private string _Value;
        public  string Value{
            get {return _Value;}
            set {_Value=value;}
        }


        private string _ValueType = "";
        public  string ValueType{
            get {return _ValueType;}
            set {_ValueType=value;}
        }


        private string _Format = "";
        public  string Format{
            get {return _Format;}
            set {_Format=value;}
        }

    }
}
