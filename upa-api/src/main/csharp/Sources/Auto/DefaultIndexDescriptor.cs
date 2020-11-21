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



namespace Net.TheVpc.Upa
{

    /**
     * Created by vpc on 7/26/15.
     */
    public class DefaultIndexDescriptor : Net.TheVpc.Upa.IndexDescriptor {

        private string name;

        private string[] fieldNames;

        private bool unique;


        public virtual string GetName() {
            return name;
        }

        public virtual Net.TheVpc.Upa.DefaultIndexDescriptor SetName(string name) {
            this.name = name;
            return this;
        }


        public virtual string[] GetFieldNames() {
            return fieldNames;
        }

        public virtual Net.TheVpc.Upa.DefaultIndexDescriptor SetFieldNames(params string [] fieldNames) {
            this.fieldNames = fieldNames;
            return this;
        }


        public virtual bool IsUnique() {
            return unique;
        }

        public virtual Net.TheVpc.Upa.DefaultIndexDescriptor SetUnique(bool unique) {
            this.unique = unique;
            return this;
        }
    }
}
