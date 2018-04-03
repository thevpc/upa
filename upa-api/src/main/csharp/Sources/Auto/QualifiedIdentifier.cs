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


    public class QualifiedIdentifier {

        private object id;

        private Net.Vpc.Upa.Entity entity;

        public QualifiedIdentifier(Net.Vpc.Upa.Entity entity, object id) {
            this.id = id;
            this.entity = entity;
        }

        public virtual Net.Vpc.Upa.Key GetKey() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entity.GetBuilder().IdToKey(id);
        }

        public virtual object GetId() {
            return id;
        }

        public virtual Net.Vpc.Upa.Entity GetEntity() {
            return entity;
        }

        public virtual object GetValue(string fieldName) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> f = entity.GetIdFields();
            Net.Vpc.Upa.Key uKey = GetKey();
            for (int i = 0; i < (f).Count; i++) {
                if (f[i].GetName().Equals(fieldName)) {
                    return uKey.GetObjectAt(i);
                }
            }
            throw new Net.Vpc.Upa.Exceptions.UPAIllegalArgumentException("Either key " + ToString() + " or fieldName " + fieldName + " does not refer to entity " + entity.GetName());
        }
    }
}
