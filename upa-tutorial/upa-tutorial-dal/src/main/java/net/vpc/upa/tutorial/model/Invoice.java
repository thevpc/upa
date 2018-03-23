package net.vpc.upa.tutorial.model;

import java.util.List;
import net.vpc.upa.types.Date;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 11/9/12 10:30 PM
 */
public class Invoice {

    private String invoiceId;
    private Date date;
    private Integer customerId;
    private Customer customer;
    private double totalTaxFree;
    private double totalIncludingTax;
    private double totalIncludingTaxExp;
    private double totalIncludingTaxCustom;
    private double totalIncludingTaxCustomMulti1;
    private double totalIncludingTaxCustomMulti2;
    private InvoiceStatus status;
    private List<InvoiceDetail> details;

    public InvoiceStatus getStatus() {
        return status;
    }

    public void setStatus(InvoiceStatus status) {
        this.status = status;
    }

    public String getInvoiceId() {
        return invoiceId;
    }

    public void setInvoiceId(String invoiceId) {
        this.invoiceId = invoiceId;
    }

    public Date getDate() {
        return date;
    }

    public void setDate(Date date) {
        this.date = date;
    }

    public Integer getCustomerId() {
        return customerId;
    }

    public void setCustomerId(Integer customerId) {
        this.customerId = customerId;
    }

    public double getTotalTaxFree() {
        return totalTaxFree;
    }

    public void setTotalTaxFree(double totalTaxFree) {
        this.totalTaxFree = totalTaxFree;
    }

    public double getTotalIncludingTax() {
        return totalIncludingTax;
    }

    public void setTotalIncludingTax(double totalIncludingTax) {
        this.totalIncludingTax = totalIncludingTax;
    }

    public Customer getCustomer() {
        return customer;
    }

    public void setCustomer(Customer customer) {
        this.customer = customer;
    }

    public List<InvoiceDetail> getDetails() {
        return details;
    }

    public void setDetails(List<InvoiceDetail> details) {
        this.details = details;
    }

    public double getTotalIncludingTaxExp() {
        return totalIncludingTaxExp;
    }

    public void setTotalIncludingTaxExp(double totalIncludingTaxExp) {
        this.totalIncludingTaxExp = totalIncludingTaxExp;
    }

    public double getTotalIncludingTaxCustom() {
        return totalIncludingTaxCustom;
    }

    public void setTotalIncludingTaxCustom(double totalIncludingTaxCustom) {
        this.totalIncludingTaxCustom = totalIncludingTaxCustom;
    }

    public double getTotalIncludingTaxCustomMulti1() {
        return totalIncludingTaxCustomMulti1;
    }

    public void setTotalIncludingTaxCustomMulti1(double totalIncludingTaxCustomMulti1) {
        this.totalIncludingTaxCustomMulti1 = totalIncludingTaxCustomMulti1;
    }

    public double getTotalIncludingTaxCustomMulti2() {
        return totalIncludingTaxCustomMulti2;
    }

    public void setTotalIncludingTaxCustomMulti2(double totalIncludingTaxCustomMulti2) {
        this.totalIncludingTaxCustomMulti2 = totalIncludingTaxCustomMulti2;
    }

    @Override
    public String toString() {
        return "Invoice{" + "invoiceId=" + invoiceId + ", date=" + date + ", customerId=" + customerId + ", customer=" + customer + ", totalTaxFree=" + totalTaxFree + ", totalIncludingTax=" + totalIncludingTax + '}';
    }
}
