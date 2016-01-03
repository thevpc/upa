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

    /**
    * @author Taha BEN SALAH <taha.bensalah@gmail.com>
    * @creationdate 1/8/13 12:27 AM*/
    internal class ReplacementPosition {

        private Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression parent;

        private Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression child;

        private int pos;

        internal ReplacementPosition(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression parent, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression child, int pos) {
            this.SetParent(parent);
            this.SetChild(child);
            this.SetPos(pos);
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetParent() {
            return parent;
        }

        public virtual void SetParent(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression parent) {
            this.parent = parent;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetChild() {
            return child;
        }

        public virtual void SetChild(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression child) {
            this.child = child;
        }

        public virtual int GetPos() {
            return pos;
        }

        public virtual void SetPos(int pos) {
            this.pos = pos;
        }
    }
}
