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

    public class IndexInfo : Net.TheVpc.Upa.UPAObjectInfo {

        private bool unique;

        private string entity;

        private string[] fields;

        public IndexInfo()  : base("index"){

        }

        public virtual bool IsUnique() {
            return unique;
        }

        public virtual void SetUnique(bool unique) {
            this.unique = unique;
        }

        public virtual string GetEntity() {
            return entity;
        }

        public virtual void SetEntity(string entity) {
            this.entity = entity;
        }

        public virtual string[] GetFields() {
            return fields;
        }

        public virtual void SetFields(string[] fields) {
            this.fields = fields;
        }
    }
}
