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



namespace Net.Vpc.Upa.Extensions
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/28/12 2:44 AM
     */
    public class UnionQueryInfo {

        private System.Collections.Generic.IList<string> entities;

        private System.Collections.Generic.IList<string> fields;

        private string discriminator;

        private string[][] mapping;

        public UnionQueryInfo(System.Collections.Generic.IList<string> entities, System.Collections.Generic.IList<string> fields, string discriminator, string[][] mapping) {
            this.entities = entities;
            this.fields = fields;
            this.discriminator = discriminator;
            this.mapping = mapping;
        }

        public virtual System.Collections.Generic.IList<string> GetEntities() {
            return new System.Collections.Generic.List<string>(entities);
        }

        public virtual System.Collections.Generic.IList<string> GetFields() {
            return new System.Collections.Generic.List<string>(fields);
        }

        public virtual string GetDiscriminator() {
            return discriminator;
        }

        public virtual string GetFieldName(string entityName, string fieldName, int entityIndex, int fieldIndex) {
            return mapping[entityIndex][fieldIndex];
        }
    }
}
