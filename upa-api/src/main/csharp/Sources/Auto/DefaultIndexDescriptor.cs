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



namespace Net.Vpc.Upa
{

    /**
     * Created by vpc on 7/26/15.
     */
    public class DefaultIndexDescriptor : Net.Vpc.Upa.IndexDescriptor {

        private string name;

        private string[] fieldNames;

        private bool unique;


        public virtual string GetName() {
            return name;
        }

        public virtual Net.Vpc.Upa.DefaultIndexDescriptor SetName(string name) {
            this.name = name;
            return this;
        }


        public virtual string[] GetFieldNames() {
            return fieldNames;
        }

        public virtual Net.Vpc.Upa.DefaultIndexDescriptor SetFieldNames(params string [] fieldNames) {
            this.fieldNames = fieldNames;
            return this;
        }


        public virtual bool IsUnique() {
            return unique;
        }

        public virtual Net.Vpc.Upa.DefaultIndexDescriptor SetUnique(bool unique) {
            this.unique = unique;
            return this;
        }
    }
}
