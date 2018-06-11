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



namespace Net.Vpc.Upa.Callbacks
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/27/12 9:52 PM
     */
    public class NamedFormulaEvent : Net.Vpc.Upa.Callbacks.UPAEvent {

        private Net.Vpc.Upa.NamedFormulaDefinition namedFormulaDefinition;

        public NamedFormulaEvent(Net.Vpc.Upa.NamedFormulaDefinition namedFormulaDefinition) {
            this.namedFormulaDefinition = namedFormulaDefinition;
        }

        public virtual Net.Vpc.Upa.NamedFormulaDefinition GetNamedFormulaDefinition() {
            return namedFormulaDefinition;
        }
    }
}
