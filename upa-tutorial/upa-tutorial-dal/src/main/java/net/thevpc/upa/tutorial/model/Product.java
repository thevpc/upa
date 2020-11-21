package net.thevpc.upa.tutorial.model;

import net.thevpc.upa.config.Entity;
import net.thevpc.upa.config.Id;
import net.thevpc.upa.config.Sequence;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 11/9/12 10:31 PM
 */
@Entity(path = "Tutorial/Inventory")
public class Product {
    @Id  @Sequence
    private int productId;
    private String name;
    private double priceTaxFree;
    private double vat;
    private double quantity;

    public int getProductId() {
        return productId;
    }

    public void setProductId(int productId) {
        this.productId = productId;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public double getPriceTaxFree() {
        return priceTaxFree;
    }

    public void setPriceTaxFree(double priceTaxFree) {
        this.priceTaxFree = priceTaxFree;
    }

    public double getQuantity() {
        return quantity;
    }

    public void setQuantity(double quantity) {
        this.quantity = quantity;
    }

    public double getVat() {
        return vat;
    }

    public void setVat(double vat) {
        this.vat = vat;
    }
}
