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



namespace Net.Vpc.Upa.Impl.Extension
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/30/12 12:48 AM
     */
    public class DefaultUnionEntityExtension : Net.Vpc.Upa.Impl.Extension.AbstractEntityExtension, Net.Vpc.Upa.Persistence.UnionEntityExtension {

        internal Net.Vpc.Upa.Expressions.QueryStatement viewQuery;

        private System.Collections.Generic.IList<Net.Vpc.Upa.Entity> updatableTables;

        private string discriminator;

        private System.Collections.Generic.IList<string> viewFields;

        private string[][] fieldsMapping;


        public override void Install(Net.Vpc.Upa.Entity entity, Net.Vpc.Upa.Persistence.EntityOperationManager entityOperationManager, Net.Vpc.Upa.Extensions.EntityExtensionDefinition extension) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            base.Install(entity, entityOperationManager, extension);
            Net.Vpc.Upa.Extensions.UnionEntityExtensionDefinition e = (Net.Vpc.Upa.Extensions.UnionEntityExtensionDefinition) extension;
            System.Collections.Generic.IList<object> list = new System.Collections.Generic.List<object>();
            foreach (Net.Vpc.Upa.Entity updatableTable in updatableTables) {
                list.Add(updatableTable.GetName());
            }
            if (discriminator != null) {
                Net.Vpc.Upa.Field field = GetEntity().AddField(new Net.Vpc.Upa.DefaultFieldDescriptor().SetName(discriminator).SetUserFieldModifiers(Net.Vpc.Upa.FlagSets.Of<E>(Net.Vpc.Upa.UserFieldModifier.SUMMARY)).SetDefaultObject(updatableTables[0].GetName()).SetDataType(Net.Vpc.Upa.Types.TypesFactory.ForList(entity.GetName() + "." + discriminator, list, Net.Vpc.Upa.Types.TypesFactory.STRING, false)));
                field.SetPersistFormula(new Net.Vpc.Upa.Sequence(Net.Vpc.Upa.SequenceStrategy.AUTO));
            }
            GetPersistenceUnit().AddPersistenceUnitListener(new Net.Vpc.Upa.Impl.Extension.UnionPersistenceUnitInterceptorAdapter(this));
            entityOperationManager.SetRemoveOperation(new Net.Vpc.Upa.Impl.Extension.EntityRemoveOperationHelper(this, updatableTables));
        }


        public override void CommitModelChanges() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Entity entity = GetEntity();
            Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.EntityModifier> modifiers = entity.GetUserModifiers();
            Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.EntityModifier> excluded = entity.GetUserExcludeModifiers();
            Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.EntityModifier> effectiveModifiers = entity.GetModifiers();
            if (!excluded.Contains(Net.Vpc.Upa.EntityModifier.TRANSIENT)) {
                effectiveModifiers = effectiveModifiers.Add(Net.Vpc.Upa.EntityModifier.TRANSIENT);
            }
            if (!excluded.Contains(Net.Vpc.Upa.EntityModifier.UPDATE)) {
                effectiveModifiers = effectiveModifiers.Add(Net.Vpc.Upa.EntityModifier.UPDATE);
            }
            if (!excluded.Contains(Net.Vpc.Upa.EntityModifier.REMOVE)) {
                effectiveModifiers = effectiveModifiers.Add(Net.Vpc.Upa.EntityModifier.REMOVE);
            }
            if (!modifiers.Contains(Net.Vpc.Upa.EntityModifier.USER_ID)) {
                effectiveModifiers = effectiveModifiers.Remove(Net.Vpc.Upa.EntityModifier.USER_ID);
            }
            //        if (!modifiers.contains(EntityModifier.GENERATED_ID)) {
            //            effectiveModifiers=effectiveModifiers.remove(EntityModifier.GENERATED_ID);
            //        }
            ((Net.Vpc.Upa.Impl.DefaultEntity) entity).SetModifiers(effectiveModifiers);
        }

        protected internal virtual Net.Vpc.Upa.Expressions.QueryStatement CreateViewQuery() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Extensions.UnionEntityExtensionDefinition entityExtension = (Net.Vpc.Upa.Extensions.UnionEntityExtensionDefinition) GetDefinition();
            Net.Vpc.Upa.Extensions.UnionQueryInfo queryInfo = entityExtension.GetQueryInfo(GetEntity());
            updatableTables = new System.Collections.Generic.List<Net.Vpc.Upa.Entity>((queryInfo.GetEntities()).Count);
            foreach (string table in queryInfo.GetEntities()) {
                updatableTables.Add(GetPersistenceUnit().GetEntity(table));
            }
            this.discriminator = queryInfo.GetDiscriminator();
            string[] tabNames = new string[(updatableTables).Count];
            for (int i = 0; i < tabNames.Length; i++) {
                tabNames[i] = updatableTables[i].GetName();
            }
            viewFields = GetEntity().GetFieldNames(Net.Vpc.Upa.Impl.Util.Filters.Fields2.READ);
            viewFields.Remove(discriminator);
            fieldsMapping = (string[][])Net.Vpc.Upa.Impl.FwkConvertUtils.CreateMultiArray(typeof(string),(queryInfo.GetEntities()).Count,(viewFields).Count);
            for (int i = 0; i < tabNames.Length; i++) {
                for (int j = 0; j < (viewFields).Count; j++) {
                    fieldsMapping[i][i] = queryInfo.GetFieldName(tabNames[i], viewFields[j], i, j);
                }
            }
            return CreateViewQuery(GetEntity().GetName(), tabNames, discriminator, viewFields, fieldsMapping);
        }

        private static Net.Vpc.Upa.Expressions.QueryStatement CreateViewQuery(string name, string[] tables, string updatableTableFieldName, System.Collections.Generic.IList<string> viewFields, string[][] fieldsMapping) {
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
            Net.Vpc.Upa.Expressions.Union u = new Net.Vpc.Upa.Expressions.Union();
            for (int i = 0; i < tables.Length; i++) {
                if (fieldsMapping != null && (viewFields).Count != fieldsMapping[i].Length) {
                    throw new System.ArgumentException ("UnionTableUpdatableView " + name + " requires " + (viewFields).Count + " fields but got " + fieldsMapping[i].Length + " for " + tables[i]);
                }
                Net.Vpc.Upa.Expressions.Select s = new Net.Vpc.Upa.Expressions.Select();
                s.Field(new Net.Vpc.Upa.Expressions.Literal(tables[i]), updatableTableFieldName);
                for (int j = 0; j < (viewFields).Count; j++) {
                    string viewField = viewFields[j];
                    string varName = fieldsMapping == null ? viewField : fieldsMapping[i][j];
                    s.Field(new Net.Vpc.Upa.Expressions.Var(varName), viewField);
                }
                s.From(tables[i]);
                u.Add(s);
            }
            return u;
        }

        public virtual Net.Vpc.Upa.QualifiedIdentifier GetViewElementKey(Net.Vpc.Upa.QualifiedIdentifier viewKey) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Entity viewElementTable = GetPersistenceUnit().GetEntity(viewKey.GetKey().GetStringAt(0));
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> fields = viewElementTable.GetPrimaryFields();
            object[] elemKeyVals = new object[(fields).Count];
            object[] viewKeyVals = viewKey.GetKey().GetValue();
            System.Array.Copy(viewKeyVals, 1, elemKeyVals, 0, elemKeyVals.Length);
            return new Net.Vpc.Upa.QualifiedIdentifier(viewElementTable, viewElementTable.CreateId(elemKeyVals));
        }

        public virtual Net.Vpc.Upa.QualifiedIdentifier GetViewKey(Net.Vpc.Upa.Entity wiewElementTable, Net.Vpc.Upa.QualifiedIdentifier viewElementKey) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> fields = GetEntity().GetPrimaryFields();
            object[] viewKeyVals = new object[(fields).Count];
            object[] elemKeyVals = viewElementKey.GetKey().GetValue();
            System.Array.Copy(elemKeyVals, 0, viewKeyVals, 0, elemKeyVals.Length);
            viewKeyVals[0] = wiewElementTable.GetName();
            return new Net.Vpc.Upa.QualifiedIdentifier(GetEntity(), GetEntity().CreateId(viewKeyVals));
        }

        public virtual string ViewFieldToViewElementField(Net.Vpc.Upa.Entity viewElementTable, string viewField) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> pf = GetEntity().GetPrimaryFields();
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> primaryFields = viewElementTable.GetPrimaryFields();
            for (int i = 1; i < (pf).Count; i++) {
                if (viewField.Equals(pf[i].GetName())) {
                    return primaryFields[i - 1].GetName();
                }
            }
            return null;
        }

        public virtual string ViewElementFieldToViewField(Net.Vpc.Upa.Entity viewElementTable, string viewElementField) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> pf = viewElementTable.GetPrimaryFields();
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> primaryFields = GetEntity().GetPrimaryFields();
            for (int i = 0; i < (pf).Count; i++) {
                if (viewElementField.Equals(pf[i].GetName())) {
                    return primaryFields[i + 1].GetName();
                }
            }
            return null;
        }

        public virtual string GetUpdatedField(string viewFieldName, Net.Vpc.Upa.Entity entity) {
            int ti = updatableTables.IndexOf(entity);
            int fi = viewFields.IndexOf(viewFieldName);
            return fieldsMapping[ti][fi];
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Entity> GetEntities() {
            return updatableTables;
        }

        public virtual string GetDiscriminator() {
            return discriminator;
        }

        public virtual int IndexOf(Net.Vpc.Upa.Entity entity) {
            return updatableTables.IndexOf(entity);
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetViewElementExpressionAt(int updatableTableIndex, Net.Vpc.Upa.Expressions.Expression expression) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> pf = GetEntity().GetPrimaryFields();
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> pft = updatableTables[updatableTableIndex].GetPrimaryFields();
            Net.Vpc.Upa.Expressions.Expression[] pfte = new Net.Vpc.Upa.Expressions.Expression[(pft).Count];
            for (int i = 0; i < pfte.Length; i++) {
                Net.Vpc.Upa.Field f = pft[i];
                pfte[i] = new Net.Vpc.Upa.Expressions.Var(f.GetName());
            }
            Net.Vpc.Upa.Expressions.Uplet ut = new Net.Vpc.Upa.Expressions.Uplet(pfte);
            Net.Vpc.Upa.Expressions.Expression[] pfe = new Net.Vpc.Upa.Expressions.Expression[(pf).Count - 1];
            for (int i = 0; i < pfe.Length; i++) {
                Net.Vpc.Upa.Field f = pf[i + 1];
                pfe[i] = new Net.Vpc.Upa.Expressions.Var(f.GetName());
            }
            Net.Vpc.Upa.Expressions.Expression w = new Net.Vpc.Upa.Expressions.Equals(new Net.Vpc.Upa.Expressions.Var(pf[0].GetName()), new Net.Vpc.Upa.Expressions.Literal(updatableTables[updatableTableIndex].GetName()));
            if (expression != null) {
                w = new Net.Vpc.Upa.Expressions.And(w, expression);
            }
            Net.Vpc.Upa.Expressions.Select q = new Net.Vpc.Upa.Expressions.Select().From(GetEntity().GetName()).Uplet(pfe).Where(w);
            return new Net.Vpc.Upa.Expressions.InSelection(ut, q);
        }

        public virtual Net.Vpc.Upa.Expressions.QueryStatement GetQuery() {
            return viewQuery;
        }
    }
}
