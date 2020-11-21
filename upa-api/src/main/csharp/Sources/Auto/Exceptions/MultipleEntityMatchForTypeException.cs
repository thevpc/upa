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



namespace Net.TheVpc.Upa.Exceptions
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class MultipleEntityMatchForTypeException : Net.TheVpc.Upa.Exceptions.EntityException {

        private string[] names;

        public MultipleEntityMatchForTypeException(System.Type entityType, string[] names)  : base((System.Exception) null, new Net.TheVpc.Upa.Types.I18NString("MultipleEntityMatchForType"), entityType, new System.Collections.Generic.List<string>(names)){

            this.names = names;
        }

        public virtual string[] GetNames() {
            return names;
        }
    }
}
