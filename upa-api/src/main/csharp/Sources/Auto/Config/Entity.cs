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
     * Specifies that the class is an entity or is an Entity Descriptor. To Its
     * simplest form, this annotation is similar to JPA @Entity Annotation.
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @Entity
     * @creationdate 8/28/12 10:14 PM
     */
    [System.AttributeUsage(System.AttributeTargets.Class)]

    public class Entity : System.Attribute {

        /**
             * Entity Name
             *
             * @return Entity Name
             */
        private string _Name = "";
        public  string Name{
            get {return _Name;}
            set {_Name=value;}
        }


        private string _ShortName = "";
        public  string ShortName{
            get {return _ShortName;}
            set {_ShortName=value;}
        }


        /**
             * Entity Instances Type. When Not specified (or when it is set to
             * java.lang.Object), the current class is considered to be Entity Instances
             * Type (as does JPA). When Specified, the current class is an Entity
             * Descriptor rather than an Entity it self. In that case, the Entity Type
             * is given by the value of this property.
             *
             * @return entity Type
             */
        private System.Type _EntityType = typeof(void);
        public  System.Type EntityType{
            get {return _EntityType;}
            set {_EntityType=value;}
        }


        /**
             * Entity ID Class Type. When Not Specified will be guessed by the
             * framework. Composite Types are resolved as Net.TheVpc.Upa.Key Type
             *
             * @return Entity ID Class Type
             */
        private System.Type _IdType = typeof(void);
        public  System.Type IdType{
            get {return _IdType;}
            set {_IdType=value;}
        }


        /**
             * Entity Modifiers
             *
             * @return Entity Modifiers
             */
        private Net.TheVpc.Upa.EntityModifier[] _Modifiers = {  };
        public  Net.TheVpc.Upa.EntityModifier[] Modifiers{
            get {return _Modifiers;}
            set {_Modifiers=value;}
        }


        /**
             * Entity Modifiers
             *
             * @return Entity Modifiers
             */
        private Net.TheVpc.Upa.EntityModifier[] _ExcludeModifiers = {  };
        public  Net.TheVpc.Upa.EntityModifier[] ExcludeModifiers{
            get {return _ExcludeModifiers;}
            set {_ExcludeModifiers=value;}
        }


        /**
             * '/' Separated Entity Path as sequence of parent Package names
             *
             * @return Entity Path
             */
        private string _Path = "";
        public  string Path{
            get {return _Path;}
            set {_Path=value;}
        }


        /**
             * When true (default) the Entity Class is parsed for fields. This is
             * helpful when defining an Entity Descriptor (entityType value specified)
             * while ignoring all already defined fields in the target entityType.
             *
             * @return true if the Entity Class is parsed for fields
             */
        private bool _UseEntityTypeFields = true;
        public  bool UseEntityTypeFields{
            get {return _UseEntityTypeFields;}
            set {_UseEntityTypeFields=value;}
        }


        /**
             * When true (default) the Entity Class is parsed for modifiers. This is
             * helpful when defining an Entity Descriptor (entityType value specified)
             * while ignoring all already defined modifiers in the target entityType.
             *
             * @return true if the Entity Class is parsed for modifiers
             */
        private bool _UseEntityTypeModifiers = true;
        public  bool UseEntityTypeModifiers{
            get {return _UseEntityTypeModifiers;}
            set {_UseEntityTypeModifiers=value;}
        }


        /**
             * When true (default) the Entity Class is parsed for modifiers. This is
             * helpful when defining an Entity Descriptor (entityType value specified)
             * while ignoring all already defined modifiers in the target entityType.
             *
             * @return true if the Entity Class is parsed for modifiers
             */
        private bool _UseEntityTypeExtensions = true;
        public  bool UseEntityTypeExtensions{
            get {return _UseEntityTypeExtensions;}
            set {_UseEntityTypeExtensions=value;}
        }


        /**
             * list order is the default order used if no order is specified.
             * This can be useful for natural ordering (names, dates,...)
             * @return order expression with no UPAQL prefixes
             */
        private string _ListOrder = "";
        public  string ListOrder{
            get {return _ListOrder;}
            set {_ListOrder=value;}
        }


        /**
             * archiving order is the default order used when importing/exporting items.
             * @return order expression with no UPAQL prefixes
             */
        private string _ArchivingOrder = "";
        public  string ArchivingOrder{
            get {return _ArchivingOrder;}
            set {_ArchivingOrder=value;}
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
