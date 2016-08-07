package net.vpc.upa.tutorial.model;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 11/9/12 11:18 PM
 */
public class InvoiceInfo {
    private Integer customerId;
    private InvoiceDetail[] details;

    public InvoiceInfo(Integer customerId, InvoiceDetail[] details) {
        this.customerId = customerId;
        this.details = details;
    }

    public Integer getCustomerId() {
        return customerId;
    }

    public InvoiceDetail[] getDetails() {
        return details;
    }
}
