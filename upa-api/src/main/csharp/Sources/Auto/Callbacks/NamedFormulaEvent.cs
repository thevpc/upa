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
    public class NamedFormulaEvent : Net.TheVpc.Upa.Callbacks.UPAEvent {

        private Net.TheVpc.Upa.NamedFormulaDefinition namedFormulaDefinition;

        public NamedFormulaEvent(Net.TheVpc.Upa.NamedFormulaDefinition namedFormulaDefinition) {
            this.namedFormulaDefinition = namedFormulaDefinition;
        }

        public virtual Net.TheVpc.Upa.NamedFormulaDefinition GetNamedFormulaDefinition() {
            return namedFormulaDefinition;
        }
    }
}
