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


    public class QualifiedIdentifier {

        private object id;

        private Net.TheVpc.Upa.Entity entity;

        public QualifiedIdentifier(Net.TheVpc.Upa.Entity entity, object id) {
            this.id = id;
            this.entity = entity;
        }

        public virtual Net.TheVpc.Upa.Key GetKey() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return entity.GetBuilder().IdToKey(id);
        }

        public virtual object GetId() {
            return id;
        }

        public virtual Net.TheVpc.Upa.Entity GetEntity() {
            return entity;
        }

        public virtual object GetValue(string fieldName) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> f = entity.GetIdFields();
            Net.TheVpc.Upa.Key uKey = GetKey();
            for (int i = 0; i < (f).Count; i++) {
                if (f[i].GetName().Equals(fieldName)) {
                    return uKey.GetObjectAt(i);
                }
            }
            throw new Net.TheVpc.Upa.Exceptions.UPAIllegalArgumentException("Either key " + ToString() + " or fieldName " + fieldName + " does not refer to entity " + entity.GetName());
        }
    }
}
