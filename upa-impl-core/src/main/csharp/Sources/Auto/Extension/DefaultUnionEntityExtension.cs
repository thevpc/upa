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



namespace Net.TheVpc.Upa.Impl.Extension
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/30/12 12:48 AM
     */
    public class DefaultUnionEntityExtension : Net.TheVpc.Upa.Impl.Extension.AbstractEntityExtension, Net.TheVpc.Upa.Persistence.UnionEntityExtension {

        internal Net.TheVpc.Upa.Expressions.QueryStatement viewQuery;

        private System.Collections.Generic.IList<Net.TheVpc.Upa.Entity> updatableTables;

        private string discriminator;

        private System.Collections.Generic.IList<string> viewFields;

        private string[][] fieldsMapping;


        public override void Install(Net.TheVpc.Upa.Entity entity, Net.TheVpc.Upa.Persistence.EntityOperationManager entityOperationManager, Net.TheVpc.Upa.Extensions.EntityExtensionDefinition extension) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            base.Install(entity, entityOperationManager, extension);
            Net.TheVpc.Upa.Extensions.UnionEntityExtensionDefinition e = (Net.TheVpc.Upa.Extensions.UnionEntityExtensionDefinition) extension;
            System.Collections.Generic.IList<object> list = new System.Collections.Generic.List<object>();
            foreach (Net.TheVpc.Upa.Entity updatableTable in updatableTables) {
                list.Add(updatableTable.GetName());
            }
            if (discriminator != null) {
                Net.TheVpc.Upa.Field field = GetEntity().AddField(new Net.TheVpc.Upa.DefaultFieldDescriptor().SetName(discriminator).SetUserFieldModifiers(Net.TheVpc.Upa.FlagSets.Of<E>(Net.TheVpc.Upa.UserFieldModifier.SUMMARY)).SetDefaultObject(updatableTables[0].GetName()).SetDataType(Net.TheVpc.Upa.Types.TypesFactory.ForList(entity.GetName() + "." + discriminator, list, Net.TheVpc.Upa.Types.TypesFactory.STRING, false)));
                field.SetPersistFormula(new Net.TheVpc.Upa.Sequence(Net.TheVpc.Upa.SequenceStrategy.AUTO));
            }
            GetPersistenceUnit().AddPersistenceUnitListener(new Net.TheVpc.Upa.Impl.Extension.UnionPersistenceUnitInterceptorAdapter(this));
            entityOperationManager.SetRemoveOperation(new Net.TheVpc.Upa.Impl.Extension.EntityRemoveOperationHelper(this, updatableTables));
        }


        public override void CommitModelChanges() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Entity entity = GetEntity();
            Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.EntityModifier> modifiers = entity.GetUserModifiers();
            Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.EntityModifier> excluded = entity.GetUserExcludeModifiers();
            Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.EntityModifier> effectiveModifiers = entity.GetModifiers();
            if (!excluded.Contains(Net.TheVpc.Upa.EntityModifier.TRANSIENT)) {
                effectiveModifiers = effectiveModifiers.Add(Net.TheVpc.Upa.EntityModifier.TRANSIENT);
            }
            if (!excluded.Contains(Net.TheVpc.Upa.EntityModifier.UPDATE)) {
                effectiveModifiers = effectiveModifiers.Add(Net.TheVpc.Upa.EntityModifier.UPDATE);
            }
            if (!excluded.Contains(Net.TheVpc.Upa.EntityModifier.REMOVE)) {
                effectiveModifiers = effectiveModifiers.Add(Net.TheVpc.Upa.EntityModifier.REMOVE);
            }
            if (!modifiers.Contains(Net.TheVpc.Upa.EntityModifier.USER_ID)) {
                effectiveModifiers = effectiveModifiers.Remove(Net.TheVpc.Upa.EntityModifier.USER_ID);
            }
            //        if (!modifiers.contains(EntityModifier.GENERATED_ID)) {
            //            effectiveModifiers=effectiveModifiers.remove(EntityModifier.GENERATED_ID);
            //        }
            ((Net.TheVpc.Upa.Impl.DefaultEntity) entity).SetModifiers(effectiveModifiers);
        }

        protected internal virtual Net.TheVpc.Upa.Expressions.QueryStatement CreateViewQuery() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Extensions.UnionEntityExtensionDefinition entityExtension = (Net.TheVpc.Upa.Extensions.UnionEntityExtensionDefinition) GetDefinition();
            Net.TheVpc.Upa.Extensions.UnionQueryInfo queryInfo = entityExtension.GetQueryInfo(GetEntity());
            updatableTables = new System.Collections.Generic.List<Net.TheVpc.Upa.Entity>((queryInfo.GetEntities()).Count);
            foreach (string table in queryInfo.GetEntities()) {
                updatableTables.Add(GetPersistenceUnit().GetEntity(table));
            }
            this.discriminator = queryInfo.GetDiscriminator();
            string[] tabNames = new string[(updatableTables).Count];
            for (int i = 0; i < tabNames.Length; i++) {
                tabNames[i] = updatableTables[i].GetName();
            }
            viewFields = GetEntity().GetFieldNames(Net.TheVpc.Upa.Impl.Util.Filters.Fields2.READ);
            viewFields.Remove(discriminator);
            fieldsMapping = (string[][])Net.TheVpc.Upa.Impl.FwkConvertUtils.CreateMultiArray(typeof(string),(queryInfo.GetEntities()).Count,(viewFields).Count);
            for (int i = 0; i < tabNames.Length; i++) {
                for (int j = 0; j < (viewFields).Count; j++) {
                    fieldsMapping[i][i] = queryInfo.GetFieldName(tabNames[i], viewFields[j], i, j);
                }
            }
            return CreateViewQuery(GetEntity().GetName(), tabNames, discriminator, viewFields, fieldsMapping);
        }

        private static Net.TheVpc.Upa.Expressions.QueryStatement CreateViewQuery(string name, string[] tables, string updatableTableFieldName, System.Collections.Generic.IList<string> viewFields, string[][] fieldsMapping) {
            //        StringBuilder sb=new StringBuilder("");
            if (tables.Length < 2) {
                if (tables.Length == 0) {
                    throw new System.ArgumentException ("UnionTableUpdatableView must be over at least a couple of entities");
                }
                System.Console.Error.WriteLine("[WARNING] UnionTableUpdatableView must be over at least a couple of tables");
            }
            if (fieldsMapping != null && tables.Length != fieldsMapping.Length) {
                throw new System.ArgumentException ("tables.length!=fieldsMapping.length");
            }
            Net.TheVpc.Upa.Expressions.Union u = new Net.TheVpc.Upa.Expressions.Union();
            for (int i = 0; i < tables.Length; i++) {
                if (fieldsMapping != null && (viewFields).Count != fieldsMapping[i].Length) {
                    throw new System.ArgumentException ("UnionTableUpdatableView " + name + " requires " + (viewFields).Count + " fields but got " + fieldsMapping[i].Length + " for " + tables[i]);
                }
                Net.TheVpc.Upa.Expressions.Select s = new Net.TheVpc.Upa.Expressions.Select();
                s.Field(new Net.TheVpc.Upa.Expressions.Literal(tables[i]), updatableTableFieldName);
                for (int j = 0; j < (viewFields).Count; j++) {
                    string viewField = viewFields[j];
                    string varName = fieldsMapping == null ? viewField : fieldsMapping[i][j];
                    s.Field(new Net.TheVpc.Upa.Expressions.Var(varName), viewField);
                }
                s.From(tables[i]);
                u.Add(s);
            }
            return u;
        }

        public virtual Net.TheVpc.Upa.QualifiedIdentifier GetViewElementKey(Net.TheVpc.Upa.QualifiedIdentifier viewKey) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Entity viewElementTable = GetPersistenceUnit().GetEntity(viewKey.GetKey().GetStringAt(0));
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> fields = viewElementTable.GetPrimaryFields();
            object[] elemKeyVals = new object[(fields).Count];
            object[] viewKeyVals = viewKey.GetKey().GetValue();
            System.Array.Copy(viewKeyVals, 1, elemKeyVals, 0, elemKeyVals.Length);
            return new Net.TheVpc.Upa.QualifiedIdentifier(viewElementTable, viewElementTable.CreateId(elemKeyVals));
        }

        public virtual Net.TheVpc.Upa.QualifiedIdentifier GetViewKey(Net.TheVpc.Upa.Entity wiewElementTable, Net.TheVpc.Upa.QualifiedIdentifier viewElementKey) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> fields = GetEntity().GetPrimaryFields();
            object[] viewKeyVals = new object[(fields).Count];
            object[] elemKeyVals = viewElementKey.GetKey().GetValue();
            System.Array.Copy(elemKeyVals, 0, viewKeyVals, 0, elemKeyVals.Length);
            viewKeyVals[0] = wiewElementTable.GetName();
            return new Net.TheVpc.Upa.QualifiedIdentifier(GetEntity(), GetEntity().CreateId(viewKeyVals));
        }

        public virtual string ViewFieldToViewElementField(Net.TheVpc.Upa.Entity viewElementTable, string viewField) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> pf = GetEntity().GetPrimaryFields();
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> primaryFields = viewElementTable.GetPrimaryFields();
            for (int i = 1; i < (pf).Count; i++) {
                if (viewField.Equals(pf[i].GetName())) {
                    return primaryFields[i - 1].GetName();
                }
            }
            return null;
        }

        public virtual string ViewElementFieldToViewField(Net.TheVpc.Upa.Entity viewElementTable, string viewElementField) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> pf = viewElementTable.GetPrimaryFields();
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> primaryFields = GetEntity().GetPrimaryFields();
            for (int i = 0; i < (pf).Count; i++) {
                if (viewElementField.Equals(pf[i].GetName())) {
                    return primaryFields[i + 1].GetName();
                }
            }
            return null;
        }

        public virtual string GetUpdatedField(string viewFieldName, Net.TheVpc.Upa.Entity entity) {
            int ti = updatableTables.IndexOf(entity);
            int fi = viewFields.IndexOf(viewFieldName);
            return fieldsMapping[ti][fi];
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Entity> GetEntities() {
            return updatableTables;
        }

        public virtual string GetDiscriminator() {
            return discriminator;
        }

        public virtual int IndexOf(Net.TheVpc.Upa.Entity entity) {
            return updatableTables.IndexOf(entity);
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression GetViewElementExpressionAt(int updatableTableIndex, Net.TheVpc.Upa.Expressions.Expression expression) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> pf = GetEntity().GetPrimaryFields();
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> pft = updatableTables[updatableTableIndex].GetPrimaryFields();
            Net.TheVpc.Upa.Expressions.Expression[] pfte = new Net.TheVpc.Upa.Expressions.Expression[(pft).Count];
            for (int i = 0; i < pfte.Length; i++) {
                Net.TheVpc.Upa.Field f = pft[i];
                pfte[i] = new Net.TheVpc.Upa.Expressions.Var(f.GetName());
            }
            Net.TheVpc.Upa.Expressions.Uplet ut = new Net.TheVpc.Upa.Expressions.Uplet(pfte);
            Net.TheVpc.Upa.Expressions.Expression[] pfe = new Net.TheVpc.Upa.Expressions.Expression[(pf).Count - 1];
            for (int i = 0; i < pfe.Length; i++) {
                Net.TheVpc.Upa.Field f = pf[i + 1];
                pfe[i] = new Net.TheVpc.Upa.Expressions.Var(f.GetName());
            }
            Net.TheVpc.Upa.Expressions.Expression w = new Net.TheVpc.Upa.Expressions.Equals(new Net.TheVpc.Upa.Expressions.Var(pf[0].GetName()), new Net.TheVpc.Upa.Expressions.Literal(updatableTables[updatableTableIndex].GetName()));
            if (expression != null) {
                w = new Net.TheVpc.Upa.Expressions.And(w, expression);
            }
            Net.TheVpc.Upa.Expressions.Select q = new Net.TheVpc.Upa.Expressions.Select().From(GetEntity().GetName()).Uplet(pfe).Where(w);
            return new Net.TheVpc.Upa.Expressions.InSelection(ut, q);
        }

        public virtual Net.TheVpc.Upa.Expressions.QueryStatement GetQuery() {
            return viewQuery;
        }
    }
}
