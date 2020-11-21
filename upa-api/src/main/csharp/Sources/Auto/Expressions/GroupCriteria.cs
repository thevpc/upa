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



namespace Net.TheVpc.Upa.Expressions
{


    public class GroupCriteria : System.ICloneable {

        private System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.Expression> fields = new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.Expression>(1);

        public GroupCriteria() {
        }

        public virtual Net.TheVpc.Upa.Expressions.GroupCriteria AddGroup(Net.TheVpc.Upa.Expressions.GroupCriteria order) {
            Net.TheVpc.Upa.FwkConvertUtils.ListAddRange(fields, order.fields);
            return this;
        }

        public virtual Net.TheVpc.Upa.Expressions.GroupCriteria AddGroup(Net.TheVpc.Upa.Expressions.Expression field) {
            fields.Add(field);
            return this;
        }

        public virtual Net.TheVpc.Upa.Expressions.GroupCriteria RemoveGroup(Net.TheVpc.Upa.Expressions.Expression field) {
            int i = fields.IndexOf(field);
            if (i >= 0) {
                fields.RemoveAt(i);
            }
            return this;
        }

        public virtual Net.TheVpc.Upa.Expressions.GroupCriteria RemoveGroup(int index) {
            fields.RemoveAt(index);
            return this;
        }

        public virtual Net.TheVpc.Upa.Expressions.GroupCriteria InsertGroup(int index, Net.TheVpc.Upa.Expressions.Expression field) {
            fields.Insert(index, field);
            return this;
        }

        public virtual int IndexOf(Net.TheVpc.Upa.Expressions.Expression field) {
            return fields.IndexOf(field);
        }

        public virtual void SetGroupAt(int index, Net.TheVpc.Upa.Expressions.Expression expression) {
            fields[index]=expression;
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression GetGroupAt(int index) {
            return (Net.TheVpc.Upa.Expressions.Expression) fields[index];
        }

        public virtual int Size() {
            return (fields).Count;
        }

        public virtual Net.TheVpc.Upa.Expressions.GroupCriteria Clear() {
            fields.Clear();
            return this;
        }

        public virtual Net.TheVpc.Upa.Expressions.GroupCriteria NoGroup() {
            fields.Clear();
            return this;
        }

        public virtual Net.TheVpc.Upa.Expressions.GroupCriteria Copy() {
            Net.TheVpc.Upa.Expressions.GroupCriteria o = new Net.TheVpc.Upa.Expressions.GroupCriteria();
            foreach (Net.TheVpc.Upa.Expressions.Expression field in fields) {
                o.fields.Add(field.Copy());
            }
            return o;
        }
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        virtual public object Clone() { return base.MemberwiseClone();}
    }
}
