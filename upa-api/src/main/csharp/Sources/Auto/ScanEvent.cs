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



namespace Net.TheVpc.Upa
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public class ScanEvent {

        private Net.TheVpc.Upa.UPAContext context;

        private Net.TheVpc.Upa.PersistenceGroup persistenceGroup;

        private Net.TheVpc.Upa.PersistenceUnit persistenceUnit;

        private System.Type contract;

        private System.Type visitedType;

        private System.Reflection.MethodInfo visitedMethod;

        private Net.TheVpc.Upa.Field visitedField;

        private Net.TheVpc.Upa.Config.Decoration visitedDecoration;

        private object userObject;

        public ScanEvent(Net.TheVpc.Upa.UPAContext context, Net.TheVpc.Upa.PersistenceGroup persistenceGroup, Net.TheVpc.Upa.PersistenceUnit persistenceUnit, System.Type contract, System.Type type, System.Reflection.MethodInfo method, Net.TheVpc.Upa.Field field, Net.TheVpc.Upa.Config.Decoration decoration, object instance) {
            this.context = context;
            this.persistenceGroup = persistenceGroup;
            this.persistenceUnit = persistenceUnit;
            this.contract = contract;
            this.visitedType = type;
            this.visitedMethod = method;
            this.visitedField = field;
            this.visitedDecoration = decoration;
            this.userObject = instance;
        }

        public ScanEvent(Net.TheVpc.Upa.UPAContext context, Net.TheVpc.Upa.PersistenceGroup persistenceGroup, Net.TheVpc.Upa.PersistenceUnit persistenceUnit, System.Type contract, System.Type type, object instance) {
            this.context = context;
            this.persistenceGroup = persistenceGroup;
            this.persistenceUnit = persistenceUnit;
            this.contract = contract;
            this.visitedType = type;
            this.userObject = instance;
        }

        public virtual object GetUserObject() {
            return userObject;
        }

        public virtual Net.TheVpc.Upa.UPAContext GetContext() {
            return context;
        }

        public virtual Net.TheVpc.Upa.PersistenceGroup GetPersistenceGroup() {
            return persistenceGroup;
        }

        public virtual Net.TheVpc.Upa.PersistenceUnit GetPersistenceUnit() {
            return persistenceUnit;
        }

        public virtual System.Type GetContract() {
            return contract;
        }

        public virtual System.Type GetVisitedType() {
            return visitedType;
        }

        public virtual System.Reflection.MethodInfo GetVisitedMethod() {
            return visitedMethod;
        }

        public virtual Net.TheVpc.Upa.Field GetVisitedField() {
            return visitedField;
        }

        public virtual Net.TheVpc.Upa.Config.Decoration GetVisitedDecoration() {
            return visitedDecoration;
        }
    }
}
