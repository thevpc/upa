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



namespace Net.Vpc.Upa.Impl.Uql
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 12/14/12 12:19 AM
     */
    public class DefaultFunction : Net.Vpc.Upa.FunctionDefinition {

        private string name;

        private Net.Vpc.Upa.Types.DataType type;

        private Net.Vpc.Upa.Function handler;

        public DefaultFunction(string name, Net.Vpc.Upa.Types.DataType type, Net.Vpc.Upa.Function handler) {
            this.name = name;
            this.type = type;
            this.handler = handler;
        }

        public virtual string GetName() {
            return name;
        }

        public virtual Net.Vpc.Upa.Types.DataType GetDataType() {
            return type;
        }

        public virtual Net.Vpc.Upa.Function GetFunction() {
            return handler;
        }
    }
}
