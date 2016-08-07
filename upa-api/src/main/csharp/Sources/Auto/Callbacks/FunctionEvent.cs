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



namespace Net.Vpc.Upa.Callbacks
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/27/12 9:52 PM
     */
    public class FunctionEvent : Net.Vpc.Upa.Callbacks.UPAEvent {

        private Net.Vpc.Upa.FunctionDefinition functionDefinition;

        public FunctionEvent(Net.Vpc.Upa.FunctionDefinition functionDefinition) {
            this.functionDefinition = functionDefinition;
        }

        public virtual Net.Vpc.Upa.FunctionDefinition GetFunctionDefinition() {
            return functionDefinition;
        }
    }
}
