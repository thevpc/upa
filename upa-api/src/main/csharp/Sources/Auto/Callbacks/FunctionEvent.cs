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



namespace Net.TheVpc.Upa.Callbacks
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/27/12 9:52 PM
     */
    public class FunctionEvent : Net.TheVpc.Upa.Callbacks.UPAEvent {

        private Net.TheVpc.Upa.FunctionDefinition functionDefinition;

        public FunctionEvent(Net.TheVpc.Upa.FunctionDefinition functionDefinition) {
            this.functionDefinition = functionDefinition;
        }

        public virtual Net.TheVpc.Upa.FunctionDefinition GetFunctionDefinition() {
            return functionDefinition;
        }
    }
}
