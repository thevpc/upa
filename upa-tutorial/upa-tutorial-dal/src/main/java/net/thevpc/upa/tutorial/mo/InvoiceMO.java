package net.thevpc.upa.tutorial.mo;

import net.thevpc.upa.FormulaType;
import net.thevpc.upa.config.*;
import net.thevpc.upa.config.*;
import net.thevpc.upa.tutorial.feature.TotalIncludingTaxExpFormula;
import net.thevpc.upa.tutorial.model.Invoice;

/**
 * Mapping Object defines DAL constraints for a given Entity
 * This one is describing Invoice Class
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 12/15/12 9:43 PM
 */
@Entity(entityType = Invoice.class,path = "Tutorial/Sell")
@Table("TBL_INVOICE")
public class InvoiceMO {
    @Id
    @Sequence(format = "{datepart(year,currentDate())}/{#}"
            ,initialValue=1,
            allocationSize=1)
    private FieldDesc invoiceId;

    private FieldDesc date;

    //@ManyToOne no explicit need to add this annotation!
    private FieldDesc customer;

    /**
     * totalTaxFree is calculated as a sum.
     * Note the usage of the this prefix to
     * target the 'current instance' of Invoice
     */
    @Formula(value="Coalesce((Select Sum(x.priceTaxFree) "
            + "From InvoiceDetail x "
            + "Where "
            + "x.invoiceId=this.invoiceId),0)"
            ,formulaType = FormulaType.UPDATE
    )
    private FieldDesc totalTaxFree;
    
    
    @Formula("Coalesce((Select Sum(x.priceTaxFree*(1+x.vat)) From InvoiceDetail x Where x.invoiceId=this.invoiceId),0)")
    private FieldDesc totalIncludingTax;

    /**
     * totalIncludingTaxExp will be calculated using TotalIncludingTaxExpFormula class
     */
    @Formula(customType = TotalIncludingTaxExpFormula.class)
    private FieldDesc totalIncludingTaxExp;

    /**
     * totalIncludingTaxCustom will be calculated using TotalIncludingTaxExpFormula class
     */
    @Formula(name = "totalIncludingTaxCustomNamedFormula")
    private FieldDesc totalIncludingTaxCustom;

    @Formula(name = "totalIncludingTaxCustomNamedMultiFormulas")
    private FieldDesc totalIncludingTaxCustomMulti1;
    @Formula(name = "totalIncludingTaxCustomNamedMultiFormulas")
    private FieldDesc totalIncludingTaxCustomMulti2;


    //this field is ignored!
    @Ignore
    private FieldDesc details;
}
