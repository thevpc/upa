package net.vpc.upa.tutorial.feature;

import net.vpc.upa.*;
import net.vpc.upa.config.NamedFormula;
import net.vpc.upa.persistence.ContextOperation;
import net.vpc.upa.tutorial.model.Invoice;

import java.util.List;

@net.vpc.upa.config.Callback
public class FormulasFeature {
    @NamedFormula
    public double totalIncludingTaxCustomNamedFormula(CustomFormulaContext context){
        Object objectId = context.getObjectId();
        if(context.isPersist()){
            return context.getUpdateDocument().getDouble("totalTaxFree",0) * 3;
        }else {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            Invoice i = pu.findById(Invoice.class, objectId);
            return i.getTotalTaxFree() * 3;
        }
    }

    @NamedFormula
    public void totalIncludingTaxCustomNamedMultiFormulas(CustomMultiFormulaContext context){
        Object objectId = context.getFilter();
        PersistenceUnit pu = UPA.getPersistenceUnit();

        QueryBuilder queryBuilder = pu.createQueryBuilder(Invoice.class).byExpression(context.getFilter()).setUpdatable(true);
        List<Invoice> invoiceList = queryBuilder.getResultList();
        for (Invoice o : invoiceList) {
            o.setTotalIncludingTax(o.getTotalIncludingTax()*2);
            o.setTotalTaxFree(o.getTotalTaxFree()/2);
            queryBuilder.updateCurrent();
        }

        QueryBuilder queryBuilder2 = pu.createQueryBuilder(Invoice.class).byExpression(context.getFilter());
        List<Invoice> invoiceList2 = queryBuilder2.getResultList();
        for (Invoice o : invoiceList2) {
            o.setTotalIncludingTax(o.getTotalIncludingTax()*2);
            o.setTotalTaxFree(o.getTotalTaxFree()/2);
            pu.merge(o);
        }

    }
}
