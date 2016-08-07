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



namespace Net.Vpc.Upa.Impl.Persistence
{

    /**
     *
     * @author taha.bensalah@gmail.com
     */
    internal class IdentifierStoreTranslatorUPPER : Net.Vpc.Upa.Impl.Persistence.IdentifierStoreTranslator {

        public IdentifierStoreTranslatorUPPER() {
        }

        public virtual string TranslateIdentifier(string identifier) {
            return identifier.ToUpper();
        }
    }
}
