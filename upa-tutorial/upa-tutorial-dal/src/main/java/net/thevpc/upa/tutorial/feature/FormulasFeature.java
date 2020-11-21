package net.thevpc.upa.tutorial.feature;

import net.thevpc.upa.*;
import net.thevpc.upa.config.Callback;

import net.thevpc.upa.config.NamedFormula;
import net.thevpc.upa.tutorial.model.Invoice;

import java.util.List;
import java.util.logging.Logger;

@Callback
public class FormulasFeature {
    static Logger log=Logger.getLogger(FormulasFeature.class.getName());
    @NamedFormula
    public double totalIncludingTaxCustomNamedFormula(CustomFormulaContext context){
        log.info("==BEGIN eval totalIncludingTaxCustomNamedFormula("+context.getObjectId()+")");
        try {
            Object objectId = context.getObjectId();
            if (context.isPersist()) {
                return context.getUpdateDocument().getDouble("totalTaxFree", 0) * 3;
            } else {
                PersistenceUnit pu = UPA.getPersistenceUnit();
                Invoice i = pu.findById(Invoice.class, objectId);
                return i.getTotalTaxFree() * 3;
            }
        }finally {
            log.info("==END   eval totalIncludingTaxCustomNamedFormula("+context.getObjectId()+")");
        }
    }

    @NamedFormula
    public void totalIncludingTaxCustomNamedMultiFormulas(CustomMultiFormulaContext context){
        Object objectId = context.getFilter();
        log.info("==BEGIN eval totalIncludingTaxCustomNamedMultiFormulas("+objectId+")");
        PersistenceUnit pu = UPA.getPersistenceUnit();

        QueryBuilder queryBuilder = pu.createQueryBuilder(Invoice.class).byExpression(context.getFilter()).setUpdatable(true);
        List<Invoice> invoiceList = queryBuilder.getResultList();
        for (Invoice o : invoiceList) {
            o.setTotalIncludingTax(o.getTotalIncludingTax()*2);
            o.setTotalTaxFree(o.getTotalTaxFree()/2);
            queryBuilder.updateCurrent();
        }

//        QueryBuilder queryBuilder2 = pu.createQueryBuilder(Invoice.class).byExpression(context.getFilter());
//        List<Invoice> invoiceList2 = queryBuilder2.getResultList();
//        for (Invoice o : invoiceList2) {
//            o.setTotalIncludingTax(o.getTotalIncludingTax()*2);
//            o.setTotalTaxFree(o.getTotalTaxFree()/2);
//            pu.merge(o);
//        }
        log.info("==END   eval totalIncludingTaxCustomNamedMultiFormulas("+objectId+")");

    }
}
