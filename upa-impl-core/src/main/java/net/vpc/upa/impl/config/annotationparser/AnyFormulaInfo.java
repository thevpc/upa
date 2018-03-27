package net.vpc.upa.impl.config.annotationparser;

import net.vpc.upa.FormulaType;
import net.vpc.upa.SequenceType;

import java.lang.reflect.Field;
import java.util.*;
import net.vpc.upa.config.Decoration;
import net.vpc.upa.impl.config.decorations.DecorationRepository;
import net.vpc.upa.config.DecorationValue;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 11/15/12 6:33 PM
 */
public class AnyFormulaInfo {

    Map<FormulaType, Object> all = new HashMap<FormulaType, Object>();
    DecorationRepository repo;

    public AnyFormulaInfo(DecorationRepository repo) {
        this.repo = repo;
    }

    public void parse(List<Field> fields) {
        List<Decoration> formulas = new ArrayList<Decoration>();
        for (java.lang.reflect.Field javaField : fields) {
            Decoration gid = repo.getFieldDecoration(javaField,net.vpc.upa.config.Formula.class);
            if (gid != null) {
                formulas.add(gid);
            }
            Decoration flist = repo.getFieldDecoration(javaField,net.vpc.upa.config.Formulas.class);
            if (flist != null) {
                for (DecorationValue ff : flist.getArray("value")) {
                    //net.vpc.upa.config.Formula formula
                    formulas.add((Decoration)ff);
                }
            }
        }
        if (formulas.size() > 1) {
            Collections.sort(formulas, DecorationComparator.INSTANCE);
        }
        for (Decoration gid : formulas) {
            mergeFormula(gid);
        }

        List<Decoration> sequences = new ArrayList<Decoration>();
        for (Field javaField : fields) {
            Decoration gid = repo.getFieldDecoration(javaField, net.vpc.upa.config.Sequence.class);
            if (gid != null) {
                sequences.add(gid);
            }
        }
        if (sequences.size() > 1) {
            Collections.sort(sequences, DecorationComparator.INSTANCE);
        }
        for (Decoration gid : sequences) {
            mergeSequence(gid);
        }
    }

    public void mergeFormula(Decoration formulaInfo) {
        FormulaType[] types = formulaInfo.getPrimitiveArray("formulaType", FormulaType.class);
        if (types.length == 0) {
            types = new FormulaType[]{FormulaType.PERSIST, FormulaType.UPDATE};
        }
        for (FormulaType type : types) {
            Object o = all.get(type);
            FormulaInfo old = (o instanceof FormulaInfo) ? (FormulaInfo) o : null;
            if (old == null) {
                old = new FormulaInfo();
                old.configOrder = Integer.MIN_VALUE;
                old.formulaType = type;
                all.put(type, old);
            }
            old.mergeFormula(formulaInfo);
        }
    }

    public void mergeSequence(Decoration formulaInfo) {
        SequenceType stype = formulaInfo.getEnum("sequenceType", SequenceType.class);
        FormulaType[] types = null;
        switch (stype) {
            case DEFAULT:
            case PERSIST: {
                types = new FormulaType[]{FormulaType.PERSIST};
                break;
            }
            case UPDATE: {
                types = new FormulaType[]{FormulaType.UPDATE};
                break;
            }
            case BOTH: {
                types = new FormulaType[]{FormulaType.PERSIST, FormulaType.UPDATE};
                break;
            }
        }
        if (types.length == 0) {
            types = new FormulaType[]{FormulaType.PERSIST, FormulaType.UPDATE};
        }
        for (FormulaType type : types) {
            Object o = all.get(type);
            SequenceInfo old = (o instanceof SequenceInfo) ? (SequenceInfo) o : null;
            if (old == null) {
                old = new SequenceInfo(repo);
                old.configOrder = Integer.MIN_VALUE;
                all.put(type, old);
            }
            old.mergeSequence(formulaInfo);
        }
    }

}
