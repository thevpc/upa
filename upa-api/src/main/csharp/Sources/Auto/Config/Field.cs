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
     * corresponds to the JPA
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @Id
     * @creationdate 8/28/12 10:17 PM
     */
    [System.AttributeUsage(System.AttributeTargets.Method|System.AttributeTargets.Field)]

    public class Field : System.Attribute {

        private string _Path = "";
        public  string Path{
            get {return _Path;}
            set {_Path=value;}
        }


        private int _Position = System.Int32.MinValue;
        public  int Position{
            get {return _Position;}
            set {_Position=value;}
        }


        private string _Name = "";
        public  string Name{
            get {return _Name;}
            set {_Name=value;}
        }


        private string _Max = "";
        public  string Max{
            get {return _Max;}
            set {_Max=value;}
        }


        private string _Min = "";
        public  string Min{
            get {return _Min;}
            set {_Min=value;}
        }


        private string _CharsAccepted = "";
        public  string CharsAccepted{
            get {return _CharsAccepted;}
            set {_CharsAccepted=value;}
        }


        private string _CharsRejected = "";
        public  string CharsRejected{
            get {return _CharsRejected;}
            set {_CharsRejected=value;}
        }


        /**
             * String ==> regexpr number ==> decimal format date ==> date format
             *
             * @return
             */
        private string _Format = "";
        public  string Format{
            get {return _Format;}
            set {_Format=value;}
        }


        private string _Layout = "";
        public  string Layout{
            get {return _Layout;}
            set {_Layout=value;}
        }


        private int _Precision = -1;
        public  int Precision{
            get {return _Precision;}
            set {_Precision=value;}
        }


        private int _Scale = -1;
        public  int Scale{
            get {return _Scale;}
            set {_Scale=value;}
        }


        private Net.TheVpc.Upa.Config.BoolEnum _Nullable = Net.TheVpc.Upa.Config.BoolEnum.UNDEFINED;
        public  Net.TheVpc.Upa.Config.BoolEnum Nullable{
            get {return _Nullable;}
            set {_Nullable=value;}
        }


        private Net.TheVpc.Upa.UserFieldModifier[] _Modifiers = {  };
        public  Net.TheVpc.Upa.UserFieldModifier[] Modifiers{
            get {return _Modifiers;}
            set {_Modifiers=value;}
        }


        private Net.TheVpc.Upa.UserFieldModifier[] _ExcludeModifiers = {  };
        public  Net.TheVpc.Upa.UserFieldModifier[] ExcludeModifiers{
            get {return _ExcludeModifiers;}
            set {_ExcludeModifiers=value;}
        }


        private System.Type _ValueType = typeof(void);
        public  System.Type ValueType{
            get {return _ValueType;}
            set {_ValueType=value;}
        }


        private string _NamedType = "";
        public  string NamedType{
            get {return _NamedType;}
            set {_NamedType=value;}
        }


        private string _DefaultValue = "";
        public  string DefaultValue{
            get {return _DefaultValue;}
            set {_DefaultValue=value;}
        }


        private string _UnspecifiedValue = "";
        public  string UnspecifiedValue{
            get {return _UnspecifiedValue;}
            set {_UnspecifiedValue=value;}
        }


        private Net.TheVpc.Upa.AccessLevel _AccessLevel = Net.TheVpc.Upa.AccessLevel.DEFAULT;
        public  Net.TheVpc.Upa.AccessLevel AccessLevel{
            get {return _AccessLevel;}
            set {_AccessLevel=value;}
        }


        private Net.TheVpc.Upa.AccessLevel _PersistAccessLevel = Net.TheVpc.Upa.AccessLevel.DEFAULT;
        public  Net.TheVpc.Upa.AccessLevel PersistAccessLevel{
            get {return _PersistAccessLevel;}
            set {_PersistAccessLevel=value;}
        }


        private Net.TheVpc.Upa.AccessLevel _UpdateAccessLevel = Net.TheVpc.Upa.AccessLevel.DEFAULT;
        public  Net.TheVpc.Upa.AccessLevel UpdateAccessLevel{
            get {return _UpdateAccessLevel;}
            set {_UpdateAccessLevel=value;}
        }


        private Net.TheVpc.Upa.AccessLevel _ReadAccessLevel = Net.TheVpc.Upa.AccessLevel.DEFAULT;
        public  Net.TheVpc.Upa.AccessLevel ReadAccessLevel{
            get {return _ReadAccessLevel;}
            set {_ReadAccessLevel=value;}
        }


        private Net.TheVpc.Upa.ProtectionLevel _ProtectionLevel = Net.TheVpc.Upa.ProtectionLevel.DEFAULT;
        public  Net.TheVpc.Upa.ProtectionLevel ProtectionLevel{
            get {return _ProtectionLevel;}
            set {_ProtectionLevel=value;}
        }


        private Net.TheVpc.Upa.ProtectionLevel _PersistProtectionLevel = Net.TheVpc.Upa.ProtectionLevel.DEFAULT;
        public  Net.TheVpc.Upa.ProtectionLevel PersistProtectionLevel{
            get {return _PersistProtectionLevel;}
            set {_PersistProtectionLevel=value;}
        }


        private Net.TheVpc.Upa.ProtectionLevel _UpdateProtectionLevel = Net.TheVpc.Upa.ProtectionLevel.DEFAULT;
        public  Net.TheVpc.Upa.ProtectionLevel UpdateProtectionLevel{
            get {return _UpdateProtectionLevel;}
            set {_UpdateProtectionLevel=value;}
        }


        private Net.TheVpc.Upa.ProtectionLevel _ReadProtectionLevel = Net.TheVpc.Upa.ProtectionLevel.DEFAULT;
        public  Net.TheVpc.Upa.ProtectionLevel ReadProtectionLevel{
            get {return _ReadProtectionLevel;}
            set {_ReadProtectionLevel=value;}
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
