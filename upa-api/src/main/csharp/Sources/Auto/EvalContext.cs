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
     * @author vpc
     */
    public class EvalContext {

        private string functionName;

        private object[] arguments;

        private Net.Vpc.Upa.PersistenceUnit persistenceUnit;

        public EvalContext(string functionName, object[] arguments, Net.Vpc.Upa.PersistenceUnit persistenceUnit) {
            this.functionName = functionName;
            this.arguments = arguments;
            this.persistenceUnit = persistenceUnit;
        }

        public virtual string GetFunctionName() {
            return functionName;
        }

        public virtual object[] GetArguments() {
            return arguments;
        }

        public virtual Net.Vpc.Upa.PersistenceUnit GetPersistenceUnit() {
            return persistenceUnit;
        }
    }
}
