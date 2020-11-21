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



namespace Net.TheVpc.Upa.Impl.Persistence
{

    /**
     *
     * @author taha.bensalah@gmail.com
     */
    internal class IdentifierStoreTranslatorUPPER : Net.TheVpc.Upa.Impl.Persistence.IdentifierStoreTranslator {

        public IdentifierStoreTranslatorUPPER() {
        }

        public virtual string TranslateIdentifier(string identifier) {
            return identifier.ToUpper();
        }
    }
}
