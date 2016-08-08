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



namespace Net.Vpc.Upa.Impl.Uql.Compiledexpression
{


    public class CompiledKeyExpression : Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpressionImpl {



        private object key;

        private string entityName;

        private string entityAlias;

        private string desc;

        private Net.Vpc.Upa.Entity entity;

        public CompiledKeyExpression(Net.Vpc.Upa.Entity entity, object key, string alias) {
            if (key == null) {
                throw new System.ArgumentException ("Key could not be null");
            }
            //        entity.getIdType().cast(key);
            this.key = key;
            entityName = entity.GetName();
            this.entityAlias = alias;
            this.entity = entity;
        }


        public override Net.Vpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            return Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.BOOLEAN;
        }

        public virtual object GetKey() {
            return key;
        }


        public override string GetDescription() {
            if (desc == null) {
                try {
                    Net.Vpc.Upa.Entity _entity = GetEntity();
                    Net.Vpc.Upa.Key ukey = _entity.GetBuilder().IdToKey(key);
                    System.Collections.Generic.IList<Net.Vpc.Upa.Field> f = _entity.GetPrimaryFields();
                    System.Text.StringBuilder descsb = new System.Text.StringBuilder();
                    object[] values = ukey.GetValue();
                    for (int i = 0; i < (f).Count; i++) {
                        if (i > 0) {
                            descsb.Append(" ");
                            descsb.Append(" and ");
                            descsb.Append(" ");
                        }
                        if (values[i] == null) {
                            descsb.Append(f[i].GetI18NString()).Append(" undefined operator ");
                        } else {
                            descsb.Append(f[i].GetI18NString()).Append(" = ").Append(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral(values[i], Net.Vpc.Upa.Impl.Util.UPAUtils.GetTypeTransformOrIdentity(f[i])).ToString());
                        }
                    }
                    desc = descsb.ToString();
                } catch (Net.Vpc.Upa.Exceptions.UPAException ex) {
                    desc = "";
                }
            }
            return desc;
        }

        public virtual Net.Vpc.Upa.Entity GetEntity() {
            return entity;
        }

        public virtual string GetTableAlias() {
            return entityAlias;
        }

        public virtual string GetEntityName() {
            return entityName;
        }


        public override Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledKeyExpression o = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledKeyExpression(entity, key, entityAlias);
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
            return o;
        }


        public override Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] GetSubExpressions() {
            return null;
        }


        public override void SetSubExpression(int index, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            throw new System.Exception("Not supported.");
        }
    }
}
