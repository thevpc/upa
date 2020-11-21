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



using System.Linq;
namespace Net.TheVpc.Upa.Impl
{


    public class DefaultIndex : Net.TheVpc.Upa.Impl.AbstractUPAObject, Net.TheVpc.Upa.Index {

        private Net.TheVpc.Upa.Entity entity;

        private string[] fieldNames;

        private Net.TheVpc.Upa.Field[] fields;

        private bool unique;

        public DefaultIndex() {
        }


        public override string GetAbsoluteName() {
            return GetName();
        }

        public virtual bool IsUnique() {
            return unique;
        }

        public virtual Net.TheVpc.Upa.Field[] GetFields() {
            if (fields == null) {
                throw new System.ArgumentException ("Model Changes are not yet committed");
            }
            return fields;
        }

        public virtual Net.TheVpc.Upa.Entity GetEntity() {
            if (entity == null) {
                throw new System.ArgumentException ("Model Changes are not yet committed");
            }
            return entity;
        }

        public virtual string[] GetFieldNames() {
            return fieldNames;
        }


        public virtual void CommitModelChanges() {
            System.Collections.Generic.List<Net.TheVpc.Upa.Field> fields = new System.Collections.Generic.List<Net.TheVpc.Upa.Field>(entity.GetFields(Net.TheVpc.Upa.Filters.Fields.ByName(fieldNames)));
            this.fields = fields.ToArray();
        }

        public virtual void SetEntity(Net.TheVpc.Upa.Entity entity) {
            this.entity = entity;
        }

        public virtual void SetFieldNames(string[] fieldNames) {
            this.fieldNames = fieldNames;
        }

        protected internal virtual void SetUnique(bool unique) {
            this.unique = unique;
        }


        public override void Close() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
        }
    }
}
