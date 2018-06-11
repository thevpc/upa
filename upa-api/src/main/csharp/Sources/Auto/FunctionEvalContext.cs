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



namespace Net.Vpc.Upa
{

    /**
     * @author taha.bensalah@gmail.com
     */
    public class FunctionEvalContext {

        private string functionName;

        private object[] arguments;

        private Net.Vpc.Upa.PersistenceUnit persistenceUnit;

        private object compilerContext;

        public FunctionEvalContext(string functionName, object[] arguments, Net.Vpc.Upa.PersistenceUnit persistenceUnit, object compilerContext) {
            this.functionName = functionName;
            this.arguments = arguments;
            this.persistenceUnit = persistenceUnit;
            this.compilerContext = compilerContext;
        }

        public virtual object GetCompilerContext() {
            return compilerContext;
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
