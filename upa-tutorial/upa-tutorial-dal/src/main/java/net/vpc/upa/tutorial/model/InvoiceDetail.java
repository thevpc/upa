package net.vpc.upa.tutorial.model;

import net.vpc.upa.config.Entity;
import net.vpc.upa.config.Id;
import net.vpc.upa.config.Sequence;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 11/9/12 10:30 PM
 */
@Entity(path = "Tutorial/Sell")
public class InvoiceDetail {

    @Id
    private String invoiceId;
//    private Invoice invoice;
    @Id
    /**
     * This is an example of a sequence of a non ordinal type.
     * This will create a sequence that will reset every time the
     * invoiceId changes.
     * The sequence will start with 1 and increment by 1
     */
    @Sequence(group = "{invoiceId}" ,initialValue=1,allocationSize=1)
    private int position;
    private int productId;
    private double priceTaxFree;
    private double vat;
    private double quantity;

    public InvoiceDetail() {
    }

    public InvoiceDetail(int productId, double priceTaxFree, double vat, double quantity) {
        this.productId = productId;
        this.priceTaxFree = priceTaxFree;
        this.vat = vat;
        this.quantity = quantity;
    }

    public String getInvoiceId() {
        return invoiceId;
    }

    public void setInvoiceId(String invoiceId) {
        this.invoiceId = invoiceId;
    }

    public int getPosition() {
        return position;
    }

    public void setPosition(int position) {
        this.position = position;
    }

    public int getProductId() {
        return productId;
    }

    public void setProductId(int productId) {
        this.productId = productId;
    }

    public double getPriceTaxFree() {
        return priceTaxFree;
    }

    public void setPriceTaxFree(double priceTaxFree) {
        this.priceTaxFree = priceTaxFree;
    }

    public double getVat() {
        return vat;
    }

    public void setVat(double vat) {
        this.vat = vat;
    }

    public double getQuantity() {
        return quantity;
    }

    public void setQuantity(double quantity) {
        this.quantity = quantity;
    }
}
