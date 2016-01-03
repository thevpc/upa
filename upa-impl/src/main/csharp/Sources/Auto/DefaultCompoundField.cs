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



namespace Net.Vpc.Upa.Impl
{


    public class DefaultCompoundField : Net.Vpc.Upa.Impl.AbstractField, Net.Vpc.Upa.CompoundField {

        private System.Collections.Generic.IList<Net.Vpc.Upa.PrimitiveField> fields;

        private System.Collections.Generic.IDictionary<string , Net.Vpc.Upa.PrimitiveField> fieldsMap;

        public DefaultCompoundField()  : base(){

            fields = new System.Collections.Generic.List<Net.Vpc.Upa.PrimitiveField>();
            fieldsMap = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.PrimitiveField>();
        }

        public virtual void AddField(Net.Vpc.Upa.PrimitiveField child) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            AddField(child, -1);
        }

        public virtual void AddField(Net.Vpc.Upa.PrimitiveField child, int index) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Impl.Util.ListUtils.Add<Net.Vpc.Upa.PrimitiveField>(fields, child, index, this, this, new Net.Vpc.Upa.Impl.Event.AddPrimitiveFieldItemInterceptor(this));
            fieldsMap[child.GetName()]=child;
        }

        public virtual Net.Vpc.Upa.PrimitiveField DropFieldAt(int index) {
            Net.Vpc.Upa.PrimitiveField child = Net.Vpc.Upa.Impl.Util.ListUtils.Remove<Net.Vpc.Upa.PrimitiveField>(fields, index, this, new Net.Vpc.Upa.Impl.DropPrimitiveFieldItemInterceptor());
            fieldsMap[child.GetName()]=child;
            return child;
        }

        public virtual Net.Vpc.Upa.PrimitiveField DropField(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return DropFieldAt(IndexOfField(name));
        }

        public virtual void MoveField(int index, int newIndex) {
            Net.Vpc.Upa.Impl.Util.ListUtils.MoveTo<Net.Vpc.Upa.PrimitiveField>(fields, index, newIndex, this, null);
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.PrimitiveField> GetFields() {
            return new System.Collections.Generic.List<Net.Vpc.Upa.PrimitiveField>(fields);
        }

        public virtual int IndexOfField(Net.Vpc.Upa.PrimitiveField child) {
            return fields.IndexOf(child);
        }

        public virtual Net.Vpc.Upa.PrimitiveField GetField(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            int index = IndexOfField(name);
            if (index < 0) {
                throw new Net.Vpc.Upa.Exceptions.NoSuchEntityItemException(name);
            }
            return fields[index];
        }

        public virtual int IndexOfField(string fieldName) {
            int i = 0;
            foreach (Net.Vpc.Upa.PrimitiveField field in fields) {
                if (fieldName.Equals(field.GetName())) {
                    return i;
                }
                i++;
            }
            return -1;
        }

        public virtual Net.Vpc.Upa.PrimitiveField GetLeadingField() {
            return fields[0];
        }


        public override void SetUserModifiers(Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> modifiers) {
            base.SetUserModifiers(modifiers);
            foreach (Net.Vpc.Upa.PrimitiveField field in fields) {
                field.SetUserModifiers(modifiers);
            }
        }


        public override void SetEffectiveModifiers(Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.FieldModifier> modifiers) {
            base.SetEffectiveModifiers(modifiers);
            foreach (Net.Vpc.Upa.PrimitiveField field in fields) {
                ((Net.Vpc.Upa.Impl.AbstractField) field).SetEffectiveModifiers(modifiers);
            }
        }

        public virtual int GetFieldsCount() {
            return (fields).Count;
        }


        public virtual Net.Vpc.Upa.PrimitiveField GetFieldAt(int index) {
            return fields[index];
        }


        public override void Close() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            foreach (Net.Vpc.Upa.PrimitiveField field in fields) {
                field.Close();
            }
            base.Close();
        }


        public virtual object[] GetPrimitiveValues(object @object) {
            return ((Net.Vpc.Upa.CompoundDataType) GetDataType()).GetPrimitiveValues(@object);
        }


        public virtual object GetCompoundValue(object[] values) {
            return ((Net.Vpc.Upa.CompoundDataType) GetDataType()).GetCompoundValue(values);
        }
    }
}
