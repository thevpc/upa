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
     * Callback Annotation is used for all Callback definitions
     * A Callback is a Pojo class that is called when appropriate event happens.
     * Callback class can define one or more "event" methods which are decorated
     * with the following annotations
     * <ul>
     * <li>@OnCreate</li>
     * <li>@OnPreCreate</li>
     * <li>@OnAlter</li>
     * <li>@OnPreAlter</li>
     * <li>@OnDrop</li>
     * <li>@OnPreDrop</li>
     * <li>@OnInit</li>
     * <li>@OnPreInit</li>
     * <li>@OnPersist</li>
     * <li>@OnPrePersist</li>
     * <li>@OnRemove</li>
     * <li>@OnPreRemove</li>
     * <li>@OnReset</li>
     * <li>@OnPreReset</li>
     * <li>@OnUpdate</li>
     * <li>@OnPreUpdate</li>
     * <li>@OnUpdateFormula</li>
     * <li>@OnPreUpdateFormula</li>
     * </ul>
     * Callback are also called if implementing one of the following interfaces
     * <ul>
     * <li>PackageDefinitionListener</li>
     * <li>SectionDefinitionListener</li>
     * <li>EntityDefinitionListener</li>
     * <li>FieldDefinitionListener</li>
     * <li>IndexDefinitionListener</li>
     * <li>TriggerDefinitionListener</li>
     * <li>RelationshipDefinitionListener</li>
     * <li>PersistenceUnitListener</li>
     * <li>EntityInterceptor</li>
     * </ul>
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/4/12 11:00 PM
     */
    [System.AttributeUsage(System.AttributeTargets.Class)]

    public class Callback : System.Attribute {

        /**
             * callback name, not mandatory
             *
             * @return
             */
        private string _Name = "";
        public  string Name{
            get {return _Name;}
            set {_Name=value;}
        }


        /**
             * if applicable, the Callback will be bound to entities
             * (depending of the Callback type) which name matches the filter
             * (shell wildcards are allowed)
             *
             * @return
             */
        private string _Filter = "";
        public  string Filter{
            get {return _Filter;}
            set {_Filter=value;}
        }


        /**
             * true all entities,including Systems Entities should be tracked
             *
             * @return true all entities,including Systems Entities should be tracked
             */
        private bool _TrackSystemObjects = false;
        public  bool TrackSystemObjects{
            get {return _TrackSystemObjects;}
            set {_TrackSystemObjects=value;}
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
