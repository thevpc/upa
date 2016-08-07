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
namespace Net.Vpc.Upa.Impl.Transform
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public class DataTypeTransformList : Net.Vpc.Upa.Types.DataTypeTransform, System.Collections.Generic.IEnumerable<Net.Vpc.Upa.Types.DataTypeTransform> {

        private Net.Vpc.Upa.Types.DataTypeTransform[] items;

        public DataTypeTransformList(Net.Vpc.Upa.Types.DataTypeTransform[] others) {
            System.Collections.Generic.List<Net.Vpc.Upa.Types.DataTypeTransform> all = new System.Collections.Generic.List<Net.Vpc.Upa.Types.DataTypeTransform>();
            Net.Vpc.Upa.Types.DataType src = null;
            foreach (Net.Vpc.Upa.Types.DataTypeTransform i in others) {
                if (i != null) {
                    if (src != null) {
                        if (!i.GetSourceType().IsAssignableFrom(src)) {
                            throw new System.ArgumentException ("Invalid " + src + " expected " + i.GetSourceType());
                        }
                    }
                    src = i.GetTargetType();
                    if (i is Net.Vpc.Upa.Impl.Transform.DataTypeTransformList) {
                        Net.Vpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(all, new System.Collections.Generic.List<Net.Vpc.Upa.Types.DataTypeTransform>(((Net.Vpc.Upa.Impl.Transform.DataTypeTransformList) i).items));
                    } else {
                        all.Add(i);
                    }
                }
            }
            this.items = all.ToArray();
        }

        public virtual Net.Vpc.Upa.Types.DataTypeTransform Get(int i) {
            return items[i];
        }

        public virtual int Size() {
            return items.Length;
        }

        public virtual object TransformValue(object @value) {
            object v = @value;
            foreach (Net.Vpc.Upa.Types.DataTypeTransform n in items) {
                v = n.TransformValue(v);
            }
            return v;
        }

        public virtual object ReverseTransformValue(object @value) {
            object v = @value;
            for (int i = items.Length - 1; i >= 0; i--) {
                Net.Vpc.Upa.Types.DataTypeTransform n = items[i];
                v = n.ReverseTransformValue(v);
            }
            return v;
        }

        public virtual Net.Vpc.Upa.Types.DataType GetSourceType() {
            return items[0].GetSourceType();
        }

        public virtual Net.Vpc.Upa.Types.DataType GetTargetType() {
            return items[items.Length - 1].GetTargetType();
        }

        public virtual Net.Vpc.Upa.Types.DataTypeTransform Chain(Net.Vpc.Upa.Types.DataTypeTransform other) {
            if (other == null) {
                return this;
            }
            return new Net.Vpc.Upa.Impl.Transform.DataTypeTransformList(new Net.Vpc.Upa.Types.DataTypeTransform[] { this, other });
        }

        public static Net.Vpc.Upa.Types.DataTypeTransform Chain(Net.Vpc.Upa.Types.DataTypeTransform a, Net.Vpc.Upa.Types.DataTypeTransform b) {
            if (a == null) {
                if (b == null) {
                    return null;
                } else {
                    return b;
                }
            } else if (b == null) {
                return a;
            } else {
                return new Net.Vpc.Upa.Impl.Transform.DataTypeTransformList(new Net.Vpc.Upa.Types.DataTypeTransform[] { a, b });
            }
        }

        public virtual System.Collections.Generic.IEnumerator<Net.Vpc.Upa.Types.DataTypeTransform> Iterator() {
            return new System.Collections.Generic.List<Net.Vpc.Upa.Types.DataTypeTransform>(items).GetEnumerator();
        }
    }
}
