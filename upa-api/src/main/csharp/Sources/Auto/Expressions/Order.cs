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



namespace Net.Vpc.Upa.Expressions
{


    public class Order : System.ICloneable {

        private System.Collections.Generic.List<Net.Vpc.Upa.Expressions.OrderItem> fields = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.OrderItem>(1);

        public Order() {
        }

        public virtual Net.Vpc.Upa.Expressions.Order Ascendent(Net.Vpc.Upa.Expressions.Expression field) {
            return AddOrder(field, true);
        }

        public virtual Net.Vpc.Upa.Expressions.Order Descendent(Net.Vpc.Upa.Expressions.Expression field) {
            return AddOrder(field, false);
        }

        public virtual Net.Vpc.Upa.Expressions.Order AddOrder(Net.Vpc.Upa.Expressions.Order order) {
            foreach (Net.Vpc.Upa.Expressions.OrderItem field in order.fields) {
                fields.Add(new Net.Vpc.Upa.Expressions.OrderItem(field.GetExpression(), field.IsAsc()));
            }
            return this;
        }

        public virtual Net.Vpc.Upa.Expressions.Order AddOrder(Net.Vpc.Upa.Expressions.Expression field, bool is_asc) {
            fields.Add(new Net.Vpc.Upa.Expressions.OrderItem(field, is_asc));
            return this;
        }

        public virtual int IndexOf(Net.Vpc.Upa.Expressions.Expression field) {
            for (int i = 0; i < (fields).Count; i++) {
                if (fields[i].GetExpression().Equals(field)) {
                    return i;
                }
            }
            return -1;
        }

        public virtual Net.Vpc.Upa.Expressions.Order RemoveOrder(Net.Vpc.Upa.Expressions.Expression field) {
            int i = IndexOf(field);
            if (i >= 0) {
                fields.RemoveAt(i);
            }
            return this;
        }

        public virtual Net.Vpc.Upa.Expressions.Order RemoveOrder(int index) {
            fields.RemoveAt(index);
            return this;
        }

        public virtual Net.Vpc.Upa.Expressions.Order InsertOrder(int index, Net.Vpc.Upa.Expressions.Expression field, bool is_asc) {
            fields.Insert(index, new Net.Vpc.Upa.Expressions.OrderItem(field, is_asc));
            return this;
        }

        public virtual Net.Vpc.Upa.Expressions.Order SetOrderAt(int index, bool asc) {
            Net.Vpc.Upa.Expressions.OrderItem o = fields[index];
            fields[index]=new Net.Vpc.Upa.Expressions.OrderItem(o.GetExpression(), asc);
            return this;
        }

        public virtual Net.Vpc.Upa.Expressions.Order SetOrderAt(int index, Net.Vpc.Upa.Expressions.Expression e, bool asc) {
            Net.Vpc.Upa.Expressions.OrderItem o = fields[index];
            fields[index]=new Net.Vpc.Upa.Expressions.OrderItem(e, asc);
            return this;
        }

        public virtual Net.Vpc.Upa.Expressions.Order SetOrderAt(int index, Net.Vpc.Upa.Expressions.Expression e) {
            Net.Vpc.Upa.Expressions.OrderItem o = fields[index];
            fields[index]=new Net.Vpc.Upa.Expressions.OrderItem(e, o.IsAsc());
            return this;
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetOrderAt(int index) {
            return fields[index].GetExpression();
        }

        public virtual bool IsAscendentAt(int index) {
            return fields[index].IsAsc();
        }

        public virtual int Size() {
            return (fields).Count;
        }

        public virtual Net.Vpc.Upa.Expressions.Order Clear() {
            fields.Clear();
            return this;
        }

        public virtual Net.Vpc.Upa.Expressions.Order NoOrder() {
            fields.Clear();
            return this;
        }

        public virtual Net.Vpc.Upa.Expressions.Order Copy() {
            Net.Vpc.Upa.Expressions.Order o = new Net.Vpc.Upa.Expressions.Order();
            foreach (Net.Vpc.Upa.Expressions.OrderItem i in fields) {
                o.fields.Add(new Net.Vpc.Upa.Expressions.OrderItem(i.GetExpression().Copy(), i.IsAsc()));
            }
            return o;
        }
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        virtual public object Clone() { return base.MemberwiseClone();}
    }
}
