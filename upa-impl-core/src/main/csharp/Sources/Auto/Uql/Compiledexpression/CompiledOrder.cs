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



namespace Net.TheVpc.Upa.Impl.Uql.Compiledexpression
{


    public class CompiledOrder : System.ICloneable {

        private System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledOrderItem> items = new System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledOrderItem>(1);

        public CompiledOrder() {
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledOrder Ascendent(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression field) {
            return AddOrder(field, true);
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledOrder Descendent(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression field) {
            return AddOrder(field, false);
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledOrder AddOrder(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledOrder order) {
            foreach (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledOrderItem field in order.items) {
                items.Add(new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledOrderItem(field.GetExpression(), field.IsAsc()));
            }
            return this;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledOrder AddOrder(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression field, bool is_asc) {
            items.Add(new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledOrderItem(field, is_asc));
            return this;
        }

        public virtual int IndexOf(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression field) {
            for (int i = 0; i < (items).Count; i++) {
                if (items[i].GetExpression().Equals(field)) {
                    return i;
                }
            }
            return -1;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledOrder RemoveOrder(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression field) {
            int i = IndexOf(field);
            if (i >= 0) {
                items.RemoveAt(i);
            }
            return this;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledOrder RemoveOrder(int index) {
            items.RemoveAt(index);
            return this;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledOrder InsertOrder(int index, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression field, bool is_asc) {
            items.Insert(index, new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledOrderItem(field, is_asc));
            return this;
        }

        public virtual void SetOrderAt(int index, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            items[index].SetExpression(expression);
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetOrderAt(int index) {
            return items[index].GetExpression();
        }

        public virtual bool IsAscendentAt(int index) {
            return items[index].IsAsc();
        }

        public virtual System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledOrderItem> GetItems() {
            return items;
        }

        public virtual int Size() {
            return (items).Count;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledOrder Clear() {
            items.Clear();
            return this;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledOrder NoOrder() {
            items.Clear();
            return this;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledOrder Copy() {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledOrder o = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledOrder();
            foreach (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledOrderItem i in items) {
                o.items.Add(new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledOrderItem(i.GetExpression().Copy(), i.IsAsc()));
            }
            return o;
        }
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        virtual public object Clone() { return base.MemberwiseClone();}
    }
}
