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



namespace Net.TheVpc.Upa.Impl
{


    public class DefaultCompoundField : Net.TheVpc.Upa.Impl.AbstractField, Net.TheVpc.Upa.CompoundField {

        private System.Collections.Generic.IList<Net.TheVpc.Upa.PrimitiveField> fields;

        private System.Collections.Generic.IDictionary<string , Net.TheVpc.Upa.PrimitiveField> fieldsMap;

        public DefaultCompoundField()  : base(){

            fields = new System.Collections.Generic.List<Net.TheVpc.Upa.PrimitiveField>();
            fieldsMap = new System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.PrimitiveField>();
        }

        public virtual void AddField(Net.TheVpc.Upa.PrimitiveField child) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            AddField(child, -1);
        }

        public virtual void AddField(Net.TheVpc.Upa.PrimitiveField child, int index) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Impl.Util.ListUtils.Add<Net.TheVpc.Upa.PrimitiveField>(fields, child, index, this, this, new Net.TheVpc.Upa.Impl.Event.AddPrimitiveFieldItemInterceptor(this));
            fieldsMap[child.GetName()]=child;
        }

        public virtual Net.TheVpc.Upa.PrimitiveField DropFieldAt(int index) {
            Net.TheVpc.Upa.PrimitiveField child = Net.TheVpc.Upa.Impl.Util.ListUtils.Remove<Net.TheVpc.Upa.PrimitiveField>(fields, index, this, new Net.TheVpc.Upa.Impl.DropPrimitiveFieldItemInterceptor());
            fieldsMap[child.GetName()]=child;
            return child;
        }

        public virtual Net.TheVpc.Upa.PrimitiveField DropField(string name) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return DropFieldAt(IndexOfField(name));
        }

        public virtual void MoveField(int index, int newIndex) {
            Net.TheVpc.Upa.Impl.Util.ListUtils.MoveTo<T>(fields, index, newIndex, this, null);
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.PrimitiveField> GetFields() {
            return new System.Collections.Generic.List<Net.TheVpc.Upa.PrimitiveField>(fields);
        }

        public virtual int IndexOfField(Net.TheVpc.Upa.PrimitiveField child) {
            return fields.IndexOf(child);
        }

        public virtual Net.TheVpc.Upa.PrimitiveField GetField(string name) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            int index = IndexOfField(name);
            if (index < 0) {
                throw new Net.TheVpc.Upa.Exceptions.NoSuchEntityItemException(name);
            }
            return fields[index];
        }

        public virtual int IndexOfField(string fieldName) {
            int i = 0;
            foreach (Net.TheVpc.Upa.PrimitiveField field in fields) {
                if (fieldName.Equals(field.GetName())) {
                    return i;
                }
                i++;
            }
            return -1;
        }

        public virtual Net.TheVpc.Upa.PrimitiveField GetLeadingField() {
            return fields[0];
        }


        public override void SetUserModifiers(Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> modifiers) {
            base.SetUserModifiers(modifiers);
            foreach (Net.TheVpc.Upa.PrimitiveField field in fields) {
                field.SetUserModifiers(modifiers);
            }
        }


        public override void SetEffectiveModifiers(Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.FieldModifier> modifiers) {
            base.SetEffectiveModifiers(modifiers);
            foreach (Net.TheVpc.Upa.PrimitiveField field in fields) {
                ((Net.TheVpc.Upa.Impl.AbstractField) field).SetEffectiveModifiers(modifiers);
            }
        }

        public virtual int GetFieldsCount() {
            return (fields).Count;
        }


        public virtual Net.TheVpc.Upa.PrimitiveField GetFieldAt(int index) {
            return fields[index];
        }


        public override void Close() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            foreach (Net.TheVpc.Upa.PrimitiveField field in fields) {
                field.Close();
            }
            base.Close();
        }


        public virtual object[] GetPrimitiveValues(object @object) {
            return ((Net.TheVpc.Upa.CompoundDataType) GetDataType()).GetPrimitiveValues(@object);
        }


        public virtual object GetCompoundValue(object[] values) {
            return ((Net.TheVpc.Upa.CompoundDataType) GetDataType()).GetCompoundValue(values);
        }
    }
}
