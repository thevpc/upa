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



namespace Net.TheVpc.Upa.Impl.Config.Annotationparser
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/15/12 6:33 PM
     */
    public class AnyFormulaInfo {

        internal System.Collections.Generic.IDictionary<Net.TheVpc.Upa.FormulaType , object> all = new System.Collections.Generic.Dictionary<Net.TheVpc.Upa.FormulaType , object>();

        internal Net.TheVpc.Upa.Impl.Config.Decorations.DecorationRepository repo;

        public AnyFormulaInfo(Net.TheVpc.Upa.Impl.Config.Decorations.DecorationRepository repo) {
            this.repo = repo;
        }

        public virtual void Parse(System.Collections.Generic.IList<System.Reflection.FieldInfo> fields) {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Config.Decoration> formulas = new System.Collections.Generic.List<Net.TheVpc.Upa.Config.Decoration>();
            foreach (System.Reflection.FieldInfo javaField in fields) {
                Net.TheVpc.Upa.Config.Decoration gid = repo.GetFieldDecoration(javaField, typeof(Net.TheVpc.Upa.Config.Formula));
                if (gid != null) {
                    formulas.Add(gid);
                }
                Net.TheVpc.Upa.Config.Decoration flist = repo.GetFieldDecoration(javaField, typeof(Net.TheVpc.Upa.Config.Formulas));
                if (flist != null) {
                    foreach (Net.TheVpc.Upa.Config.DecorationValue ff in flist.GetArray("value")) {
                        //Net.TheVpc.Upa.config.Formula formula
                        formulas.Add((Net.TheVpc.Upa.Config.Decoration) ff);
                    }
                }
            }
            if ((formulas).Count > 1) {
                Net.TheVpc.Upa.Impl.FwkConvertUtils.ListSort(formulas, Net.TheVpc.Upa.Impl.Config.Annotationparser.DecorationComparator.INSTANCE);
            }
            foreach (Net.TheVpc.Upa.Config.Decoration gid in formulas) {
                MergeFormula(gid);
            }
            System.Collections.Generic.IList<Net.TheVpc.Upa.Config.Decoration> sequences = new System.Collections.Generic.List<Net.TheVpc.Upa.Config.Decoration>();
            foreach (System.Reflection.FieldInfo javaField in fields) {
                Net.TheVpc.Upa.Config.Decoration gid = repo.GetFieldDecoration(javaField, typeof(Net.TheVpc.Upa.Config.Sequence));
                if (gid != null) {
                    sequences.Add(gid);
                }
            }
            if ((sequences).Count > 1) {
                Net.TheVpc.Upa.Impl.FwkConvertUtils.ListSort(sequences, Net.TheVpc.Upa.Impl.Config.Annotationparser.DecorationComparator.INSTANCE);
            }
            foreach (Net.TheVpc.Upa.Config.Decoration gid in sequences) {
                MergeSequence(gid);
            }
        }

        public virtual void MergeFormula(Net.TheVpc.Upa.Config.Decoration formulaInfo) {
            Net.TheVpc.Upa.FormulaType[] types = formulaInfo.GetPrimitiveArray<Net.TheVpc.Upa.FormulaType>("type", typeof(Net.TheVpc.Upa.FormulaType));
            if (types.Length == 0) {
                types = new Net.TheVpc.Upa.FormulaType[] { Net.TheVpc.Upa.FormulaType.PERSIST, Net.TheVpc.Upa.FormulaType.UPDATE };
            }
            foreach (Net.TheVpc.Upa.FormulaType type in types) {
                object o = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<Net.TheVpc.Upa.FormulaType,object>(all,type);
                Net.TheVpc.Upa.Impl.Config.Annotationparser.FormulaInfo old = (o is Net.TheVpc.Upa.Impl.Config.Annotationparser.FormulaInfo) ? (Net.TheVpc.Upa.Impl.Config.Annotationparser.FormulaInfo) o : null;
                if (old == null) {
                    old = new Net.TheVpc.Upa.Impl.Config.Annotationparser.FormulaInfo();
                    old.configOrder = System.Int32.MinValue;
                    old.formulaType = type;
                    all[type]=old;
                }
                old.MergeFormula(formulaInfo);
            }
        }

        public virtual void MergeSequence(Net.TheVpc.Upa.Config.Decoration formulaInfo) {
            Net.TheVpc.Upa.SequenceType stype = formulaInfo.GetEnum<Net.TheVpc.Upa.SequenceType>("type", typeof(Net.TheVpc.Upa.SequenceType));
            Net.TheVpc.Upa.FormulaType[] types = null;
            switch(stype) {
                case Net.TheVpc.Upa.SequenceType.DEFAULT:
                case Net.TheVpc.Upa.SequenceType.PERSIST:
                    {
                        types = new Net.TheVpc.Upa.FormulaType[] { Net.TheVpc.Upa.FormulaType.PERSIST };
                        break;
                    }
                case Net.TheVpc.Upa.SequenceType.UPDATE:
                    {
                        types = new Net.TheVpc.Upa.FormulaType[] { Net.TheVpc.Upa.FormulaType.UPDATE };
                        break;
                    }
                case Net.TheVpc.Upa.SequenceType.BOTH:
                    {
                        types = new Net.TheVpc.Upa.FormulaType[] { Net.TheVpc.Upa.FormulaType.PERSIST, Net.TheVpc.Upa.FormulaType.UPDATE };
                        break;
                    }
            }
            if (types.Length == 0) {
                types = new Net.TheVpc.Upa.FormulaType[] { Net.TheVpc.Upa.FormulaType.PERSIST, Net.TheVpc.Upa.FormulaType.UPDATE };
            }
            foreach (Net.TheVpc.Upa.FormulaType type in types) {
                object o = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<Net.TheVpc.Upa.FormulaType,object>(all,type);
                Net.TheVpc.Upa.Impl.Config.Annotationparser.SequenceInfo old = (o is Net.TheVpc.Upa.Impl.Config.Annotationparser.SequenceInfo) ? (Net.TheVpc.Upa.Impl.Config.Annotationparser.SequenceInfo) o : null;
                if (old == null) {
                    old = new Net.TheVpc.Upa.Impl.Config.Annotationparser.SequenceInfo(repo);
                    old.configOrder = System.Int32.MinValue;
                    all[type]=old;
                }
                old.MergeSequence(formulaInfo);
            }
        }
    }
}
