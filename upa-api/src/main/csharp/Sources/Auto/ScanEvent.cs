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



namespace Net.Vpc.Upa
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public class ScanEvent {

        private Net.Vpc.Upa.UPAContext context;

        private Net.Vpc.Upa.PersistenceGroup persistenceGroup;

        private Net.Vpc.Upa.PersistenceUnit persistenceUnit;

        private System.Type contract;

        private System.Type visitedType;

        private System.Reflection.MethodInfo visitedMethod;

        private Net.Vpc.Upa.Field visitedField;

        private Net.Vpc.Upa.Config.Decoration visitedDecoration;

        private object userObject;

        public ScanEvent(Net.Vpc.Upa.UPAContext context, Net.Vpc.Upa.PersistenceGroup persistenceGroup, Net.Vpc.Upa.PersistenceUnit persistenceUnit, System.Type contract, System.Type type, System.Reflection.MethodInfo method, Net.Vpc.Upa.Field field, Net.Vpc.Upa.Config.Decoration decoration, object instance) {
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

        public ScanEvent(Net.Vpc.Upa.UPAContext context, Net.Vpc.Upa.PersistenceGroup persistenceGroup, Net.Vpc.Upa.PersistenceUnit persistenceUnit, System.Type contract, System.Type type, object instance) {
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

        public virtual Net.Vpc.Upa.UPAContext GetContext() {
            return context;
        }

        public virtual Net.Vpc.Upa.PersistenceGroup GetPersistenceGroup() {
            return persistenceGroup;
        }

        public virtual Net.Vpc.Upa.PersistenceUnit GetPersistenceUnit() {
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

        public virtual Net.Vpc.Upa.Field GetVisitedField() {
            return visitedField;
        }

        public virtual Net.Vpc.Upa.Config.Decoration GetVisitedDecoration() {
            return visitedDecoration;
        }
    }
}
