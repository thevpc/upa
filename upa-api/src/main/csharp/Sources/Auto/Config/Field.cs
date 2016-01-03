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


        private Net.Vpc.Upa.Config.BoolEnum _Nullable = Net.Vpc.Upa.Config.BoolEnum.UNDEFINED;
        public  Net.Vpc.Upa.Config.BoolEnum Nullable{
            get {return _Nullable;}
            set {_Nullable=value;}
        }


        private Net.Vpc.Upa.UserFieldModifier[] _Modifiers = {  };
        public  Net.Vpc.Upa.UserFieldModifier[] Modifiers{
            get {return _Modifiers;}
            set {_Modifiers=value;}
        }


        private Net.Vpc.Upa.UserFieldModifier[] _ExcludeModifiers = {  };
        public  Net.Vpc.Upa.UserFieldModifier[] ExcludeModifiers{
            get {return _ExcludeModifiers;}
            set {_ExcludeModifiers=value;}
        }


        private System.Type _Type = typeof(void);
        public  System.Type Type{
            get {return _Type;}
            set {_Type=value;}
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


        private Net.Vpc.Upa.AccessLevel _InsertAccessLevel = Net.Vpc.Upa.AccessLevel.DEFAULT;
        public  Net.Vpc.Upa.AccessLevel InsertAccessLevel{
            get {return _InsertAccessLevel;}
            set {_InsertAccessLevel=value;}
        }


        private Net.Vpc.Upa.AccessLevel _UpdateAccessLevel = Net.Vpc.Upa.AccessLevel.DEFAULT;
        public  Net.Vpc.Upa.AccessLevel UpdateAccessLevel{
            get {return _UpdateAccessLevel;}
            set {_UpdateAccessLevel=value;}
        }


        private Net.Vpc.Upa.AccessLevel _DeleteAccessLevel = Net.Vpc.Upa.AccessLevel.DEFAULT;
        public  Net.Vpc.Upa.AccessLevel DeleteAccessLevel{
            get {return _DeleteAccessLevel;}
            set {_DeleteAccessLevel=value;}
        }


        private Net.Vpc.Upa.AccessLevel _SelectAccessLevel = Net.Vpc.Upa.AccessLevel.DEFAULT;
        public  Net.Vpc.Upa.AccessLevel SelectAccessLevel{
            get {return _SelectAccessLevel;}
            set {_SelectAccessLevel=value;}
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
