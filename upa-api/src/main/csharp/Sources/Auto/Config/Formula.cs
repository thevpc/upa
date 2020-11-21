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
    [System.AttributeUsage(System.AttributeTargets.Method|System.AttributeTargets.Field)]

    public class Formula : System.Attribute {

        private string _Value = "";
        public  string Value{
            get {return _Value;}
            set {_Value=value;}
        }


        private System.Type _CustomType = typeof(Net.TheVpc.Upa.Formula);
        public  System.Type CustomType{
            get {return _CustomType;}
            set {_CustomType=value;}
        }


        /**
             * if defined will consider named Custom formula registered in PersistenceUnit
             */
        private string _Name = "";
        public  string Name{
            get {return _Name;}
            set {_Name=value;}
        }


        private int _FormulaOrder = System.Int32.MinValue;
        public  int FormulaOrder{
            get {return _FormulaOrder;}
            set {_FormulaOrder=value;}
        }


        private Net.TheVpc.Upa.FormulaType[] _FormulaType = {  };
        public  Net.TheVpc.Upa.FormulaType[] FormulaType{
            get {return _FormulaType;}
            set {_FormulaType=value;}
        }


        /**
             * annotation config defines how this annotation must be handled
             *
             * @return annotation configuration
             */
        private Net.TheVpc.Upa.Config.ItemConfig _Config = new Net.TheVpc.Upa.Config.ItemConfig();
        public  Net.TheVpc.Upa.Config.ItemConfig Config{
            get {return _Config;}
            set {_Config=value;}
        }

    }
}
