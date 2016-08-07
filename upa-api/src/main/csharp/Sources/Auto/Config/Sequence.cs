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
    [System.AttributeUsage(System.AttributeTargets.Field|System.AttributeTargets.Method)]

    public class Sequence : System.Attribute {

        private Net.Vpc.Upa.SequenceStrategy _Strategy = Net.Vpc.Upa.SequenceStrategy.AUTO;
        public  Net.Vpc.Upa.SequenceStrategy Strategy{
            get {return _Strategy;}
            set {_Strategy=value;}
        }


        private Net.Vpc.Upa.SequenceType _Type = Net.Vpc.Upa.SequenceType.PERSIST;
        public  Net.Vpc.Upa.SequenceType Type{
            get {return _Type;}
            set {_Type=value;}
        }


        private int _InitialValue = System.Int32.MinValue;
        public  int InitialValue{
            get {return _InitialValue;}
            set {_InitialValue=value;}
        }


        private int _AllocationSize = System.Int32.MinValue;
        public  int AllocationSize{
            get {return _AllocationSize;}
            set {_AllocationSize=value;}
        }


        private string _Name = "";
        public  string Name{
            get {return _Name;}
            set {_Name=value;}
        }


        private string _Group = "";
        public  string Group{
            get {return _Group;}
            set {_Group=value;}
        }


        private string _Format = "";
        public  string Format{
            get {return _Format;}
            set {_Format=value;}
        }


        private int _FormulaOrder = System.Int32.MinValue;
        public  int FormulaOrder{
            get {return _FormulaOrder;}
            set {_FormulaOrder=value;}
        }


        /**
             * annotation config defines how this annotation must be handled
             *
             * @return annotation configuration
             */
        private Net.Vpc.Upa.Config.Config _Config = new Net.Vpc.Upa.Config.Config();
        public  Net.Vpc.Upa.Config.Config Config{
            get {return _Config;}
            set {_Config=value;}
        }

    }
}
