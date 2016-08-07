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
namespace Net.Vpc.Upa.Impl
{


    public class DefaultIndex : Net.Vpc.Upa.Impl.AbstractUPAObject, Net.Vpc.Upa.Index {

        private Net.Vpc.Upa.Entity entity;

        private string[] fieldNames;

        private Net.Vpc.Upa.Field[] fields;

        private bool unique;

        public DefaultIndex() {
        }


        public override string GetAbsoluteName() {
            return GetName();
        }

        public virtual bool IsUnique() {
            return unique;
        }

        public virtual Net.Vpc.Upa.Field[] GetFields() {
            if (fields == null) {
                throw new System.ArgumentException ("Model Changes are not yet committed");
            }
            return fields;
        }

        public virtual Net.Vpc.Upa.Entity GetEntity() {
            if (entity == null) {
                throw new System.ArgumentException ("Model Changes are not yet committed");
            }
            return entity;
        }

        public virtual string[] GetFieldNames() {
            return fieldNames;
        }


        public virtual void CommitModelChanges() {
            System.Collections.Generic.List<Net.Vpc.Upa.Field> fields = new System.Collections.Generic.List<Net.Vpc.Upa.Field>(entity.GetFields(Net.Vpc.Upa.Filters.Fields.ByName(fieldNames)));
            this.fields = fields.ToArray();
        }

        public virtual void SetEntity(Net.Vpc.Upa.Entity entity) {
            this.entity = entity;
        }

        public virtual void SetFieldNames(string[] fieldNames) {
            this.fieldNames = fieldNames;
        }

        protected internal virtual void SetUnique(bool unique) {
            this.unique = unique;
        }


        public override void Close() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
        }
    }
}
