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



using System.Linq;
namespace Net.TheVpc.Upa.Impl.Transform
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public class DataTypeTransformList : Net.TheVpc.Upa.Types.DataTypeTransform, System.Collections.Generic.IEnumerable<Net.TheVpc.Upa.Types.DataTypeTransform> {

        private Net.TheVpc.Upa.Types.DataTypeTransform[] items;

        public DataTypeTransformList(Net.TheVpc.Upa.Types.DataTypeTransform[] others) {
            System.Collections.Generic.List<Net.TheVpc.Upa.Types.DataTypeTransform> all = new System.Collections.Generic.List<Net.TheVpc.Upa.Types.DataTypeTransform>();
            Net.TheVpc.Upa.Types.DataType src = null;
            foreach (Net.TheVpc.Upa.Types.DataTypeTransform i in others) {
                if (i != null) {
                    if (src != null) {
                        if (!i.GetSourceType().IsAssignableFrom(src)) {
                            throw new System.ArgumentException ("Invalid " + src + " expected " + i.GetSourceType());
                        }
                    }
                    src = i.GetTargetType();
                    if (i is Net.TheVpc.Upa.Impl.Transform.DataTypeTransformList) {
                        Net.TheVpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(all, new System.Collections.Generic.List<Net.TheVpc.Upa.Types.DataTypeTransform>(((Net.TheVpc.Upa.Impl.Transform.DataTypeTransformList) i).items));
                    } else {
                        all.Add(i);
                    }
                }
            }
            this.items = all.ToArray();
        }

        public virtual Net.TheVpc.Upa.Types.DataTypeTransform Get(int i) {
            return items[i];
        }

        public virtual int Size() {
            return items.Length;
        }

        public virtual object TransformValue(object @value) {
            object v = @value;
            foreach (Net.TheVpc.Upa.Types.DataTypeTransform n in items) {
                v = n.TransformValue(v);
            }
            return v;
        }

        public virtual object ReverseTransformValue(object @value) {
            object v = @value;
            for (int i = items.Length - 1; i >= 0; i--) {
                Net.TheVpc.Upa.Types.DataTypeTransform n = items[i];
                v = n.ReverseTransformValue(v);
            }
            return v;
        }

        public virtual Net.TheVpc.Upa.Types.DataType GetSourceType() {
            return items[0].GetSourceType();
        }

        public virtual Net.TheVpc.Upa.Types.DataType GetTargetType() {
            return items[items.Length - 1].GetTargetType();
        }

        public virtual Net.TheVpc.Upa.Types.DataTypeTransform Chain(Net.TheVpc.Upa.Types.DataTypeTransform other) {
            if (other == null) {
                return this;
            }
            return new Net.TheVpc.Upa.Impl.Transform.DataTypeTransformList(new Net.TheVpc.Upa.Types.DataTypeTransform[] { this, other });
        }

        public static Net.TheVpc.Upa.Types.DataTypeTransform Chain(Net.TheVpc.Upa.Types.DataTypeTransform a, Net.TheVpc.Upa.Types.DataTypeTransform b) {
            if (a == null) {
                if (b == null) {
                    return null;
                } else {
                    return b;
                }
            } else if (b == null) {
                return a;
            } else {
                return new Net.TheVpc.Upa.Impl.Transform.DataTypeTransformList(new Net.TheVpc.Upa.Types.DataTypeTransform[] { a, b });
            }
        }

        public virtual System.Collections.Generic.IEnumerator<Net.TheVpc.Upa.Types.DataTypeTransform> Iterator() {
            return new System.Collections.Generic.List<Net.TheVpc.Upa.Types.DataTypeTransform>(items).GetEnumerator();
        }
    }
}
