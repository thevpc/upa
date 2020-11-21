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



namespace Net.TheVpc.Upa.Impl.Uql
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 12/14/12 12:19 AM
     */
    public class DefaultFunction : Net.TheVpc.Upa.FunctionDefinition {

        private string name;

        private Net.TheVpc.Upa.Types.DataType type;

        private Net.TheVpc.Upa.Function handler;

        public DefaultFunction(string name, Net.TheVpc.Upa.Types.DataType type, Net.TheVpc.Upa.Function handler) {
            this.name = name;
            this.type = type;
            this.handler = handler;
        }

        public virtual string GetName() {
            return name;
        }

        public virtual Net.TheVpc.Upa.Types.DataType GetDataType() {
            return type;
        }

        public virtual Net.TheVpc.Upa.Function GetFunction() {
            return handler;
        }
    }
}
