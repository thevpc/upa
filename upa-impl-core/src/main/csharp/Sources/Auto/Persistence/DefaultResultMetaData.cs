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
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/1/12 12:42 AM
     */
    public class DefaultResultMetaData : Net.TheVpc.Upa.Persistence.ResultMetaData {

        private System.Collections.Generic.IDictionary<string , object> properties = new System.Collections.Generic.Dictionary<string , object>();

        private System.Collections.Generic.IList<Net.TheVpc.Upa.Persistence.ResultField> fields = new System.Collections.Generic.List<Net.TheVpc.Upa.Persistence.ResultField>();

        private Net.TheVpc.Upa.Expressions.EntityStatement statement;

        public virtual Net.TheVpc.Upa.Expressions.EntityStatement GetStatement() {
            return statement;
        }

        public virtual void SetStatement(Net.TheVpc.Upa.Expressions.EntityStatement statement) {
            this.statement = statement;
        }

        public virtual void AddField(Net.TheVpc.Upa.Persistence.ResultField field) {
            fields.Add(field);
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Persistence.ResultField> GetFields() {
            return new System.Collections.Generic.List<Net.TheVpc.Upa.Persistence.ResultField>(fields);
        }

        public virtual System.Collections.Generic.IDictionary<string , object> GetProperties() {
            return properties;
        }
    }
}
