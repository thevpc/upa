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



namespace Net.Vpc.Upa.Impl.Config.Annotationparser
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/15/12 6:33 PM
     */
    public class AnyFormulaInfo {

        internal System.Collections.Generic.IDictionary<Net.Vpc.Upa.FormulaType , object> all = new System.Collections.Generic.Dictionary<Net.Vpc.Upa.FormulaType , object>();

        internal Net.Vpc.Upa.Impl.Config.Decorations.DecorationRepository repo;

        public AnyFormulaInfo(Net.Vpc.Upa.Impl.Config.Decorations.DecorationRepository repo) {
            this.repo = repo;
        }

        public virtual void Parse(System.Collections.Generic.IList<System.Reflection.FieldInfo> fields) {
            System.Collections.Generic.IList<Net.Vpc.Upa.Config.Decoration> formulas = new System.Collections.Generic.List<Net.Vpc.Upa.Config.Decoration>();
            foreach (System.Reflection.FieldInfo javaField in fields) {
                Net.Vpc.Upa.Config.Decoration gid = repo.GetFieldDecoration(javaField, typeof(Net.Vpc.Upa.Config.Formula));
                if (gid != null) {
                    formulas.Add(gid);
                }
                Net.Vpc.Upa.Config.Decoration flist = repo.GetFieldDecoration(javaField, typeof(Net.Vpc.Upa.Config.Formulas));
                if (flist != null) {
                    foreach (Net.Vpc.Upa.Config.DecorationValue ff in flist.GetArray("value")) {
                        //net.vpc.upa.config.Formula formula
                        formulas.Add((Net.Vpc.Upa.Config.Decoration) ff);
                    }
                }
            }
            if ((formulas).Count > 1) {
                Net.Vpc.Upa.Impl.FwkConvertUtils.ListSort(formulas, Net.Vpc.Upa.Impl.Config.Annotationparser.DecorationComparator.INSTANCE);
            }
            foreach (Net.Vpc.Upa.Config.Decoration gid in formulas) {
                MergeFormula(gid);
            }
            System.Collections.Generic.IList<Net.Vpc.Upa.Config.Decoration> sequences = new System.Collections.Generic.List<Net.Vpc.Upa.Config.Decoration>();
            foreach (System.Reflection.FieldInfo javaField in fields) {
                Net.Vpc.Upa.Config.Decoration gid = repo.GetFieldDecoration(javaField, typeof(Net.Vpc.Upa.Config.Sequence));
                if (gid != null) {
                    sequences.Add(gid);
                }
            }
            if ((sequences).Count > 1) {
                Net.Vpc.Upa.Impl.FwkConvertUtils.ListSort(sequences, Net.Vpc.Upa.Impl.Config.Annotationparser.DecorationComparator.INSTANCE);
            }
            foreach (Net.Vpc.Upa.Config.Decoration gid in sequences) {
                MergeSequence(gid);
            }
        }

        public virtual void MergeFormula(Net.Vpc.Upa.Config.Decoration formulaInfo) {
            Net.Vpc.Upa.FormulaType[] types = formulaInfo.GetPrimitiveArray<Net.Vpc.Upa.FormulaType>("type", typeof(Net.Vpc.Upa.FormulaType));
            if (types.Length == 0) {
                types = new Net.Vpc.Upa.FormulaType[] { Net.Vpc.Upa.FormulaType.PERSIST, Net.Vpc.Upa.FormulaType.UPDATE };
            }
            foreach (Net.Vpc.Upa.FormulaType type in types) {
                object o = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<Net.Vpc.Upa.FormulaType,object>(all,type);
                Net.Vpc.Upa.Impl.Config.Annotationparser.FormulaInfo old = (o is Net.Vpc.Upa.Impl.Config.Annotationparser.FormulaInfo) ? (Net.Vpc.Upa.Impl.Config.Annotationparser.FormulaInfo) o : null;
                if (old == null) {
                    old = new Net.Vpc.Upa.Impl.Config.Annotationparser.FormulaInfo();
                    old.configOrder = System.Int32.MinValue;
                    old.formulaType = type;
                    all[type]=old;
                }
                old.MergeFormula(formulaInfo);
            }
        }

        public virtual void MergeSequence(Net.Vpc.Upa.Config.Decoration formulaInfo) {
            Net.Vpc.Upa.SequenceType stype = formulaInfo.GetEnum<Net.Vpc.Upa.SequenceType>("type", typeof(Net.Vpc.Upa.SequenceType));
            Net.Vpc.Upa.FormulaType[] types = null;
            switch(stype) {
                case Net.Vpc.Upa.SequenceType.DEFAULT:
                case Net.Vpc.Upa.SequenceType.PERSIST:
                    {
                        types = new Net.Vpc.Upa.FormulaType[] { Net.Vpc.Upa.FormulaType.PERSIST };
                        break;
                    }
                case Net.Vpc.Upa.SequenceType.UPDATE:
                    {
                        types = new Net.Vpc.Upa.FormulaType[] { Net.Vpc.Upa.FormulaType.UPDATE };
                        break;
                    }
                case Net.Vpc.Upa.SequenceType.BOTH:
                    {
                        types = new Net.Vpc.Upa.FormulaType[] { Net.Vpc.Upa.FormulaType.PERSIST, Net.Vpc.Upa.FormulaType.UPDATE };
                        break;
                    }
            }
            if (types.Length == 0) {
                types = new Net.Vpc.Upa.FormulaType[] { Net.Vpc.Upa.FormulaType.PERSIST, Net.Vpc.Upa.FormulaType.UPDATE };
            }
            foreach (Net.Vpc.Upa.FormulaType type in types) {
                object o = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<Net.Vpc.Upa.FormulaType,object>(all,type);
                Net.Vpc.Upa.Impl.Config.Annotationparser.SequenceInfo old = (o is Net.Vpc.Upa.Impl.Config.Annotationparser.SequenceInfo) ? (Net.Vpc.Upa.Impl.Config.Annotationparser.SequenceInfo) o : null;
                if (old == null) {
                    old = new Net.Vpc.Upa.Impl.Config.Annotationparser.SequenceInfo(repo);
                    old.configOrder = System.Int32.MinValue;
                    all[type]=old;
                }
                old.MergeSequence(formulaInfo);
            }
        }
    }
}
