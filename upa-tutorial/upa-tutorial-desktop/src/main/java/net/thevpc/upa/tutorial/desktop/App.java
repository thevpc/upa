package net.thevpc.upa.tutorial.desktop;

import java.util.Arrays;
import java.util.Calendar;
import java.util.List;
import net.thevpc.upa.UPA;
import net.thevpc.upa.tutorial.business.InvoiceModule;
import net.thevpc.upa.tutorial.model.*;
import net.thevpc.upa.tutorial.model.*;

/**
 * Hello world!
 *
 */
public class App {

    static {
        LogUtils.prepare();
    }

    public static void main(String[] args) {
        UPA.makeSessionAware(new App()).run();
    }
    
    public void run() {
//        Entity<Integer, Customer> e = UPA.getPersistenceUnit().getEntity(Customer.class);
//        for (Field field : e.getFields()) {
//            System.out.println(field + " : " + field.getEffectiveModifiers());
//        }
//        System.exit(0);
        LogUtils.logEnabled = true;
        InvoiceModule invoiceModule = InvoiceModule.createInvoiceModule();
        Integer customerId = null;
        List<InvoiceDetail> details = Arrays.asList(
                new InvoiceDetail(12, 10.0, 1.2, 3), new InvoiceDetail(13, 5.0, 1.2, 5), new InvoiceDetail(14, 6.0, 1.3, 6));
        for (Customer customer : invoiceModule.findAllCustomers()) {
            System.out.println(customer);
        }
        Calendar calendar = Calendar.getInstance();
        Customer c = new Customer();
        c.setName("BFI");
        calendar.set(1985, Calendar.FEBRUARY, 2, 0, 0, 0);
        c.setBirthDate(new java.sql.Date(calendar.getTime().getTime()));
        invoiceModule.saveCustomer(c);

        Product product = new Product();
        product.setName("simple product");
        product.setQuantity(15);
        product.setVat(0.12);
        invoiceModule.saveProduct(product);
        customerId = c.getCustomerId();


        Invoice invoice = new Invoice();
        invoice.setCustomerId(customerId);
        invoice.setDetails(details);
        invoiceModule.addInvoice(invoice);
        for (Customer customer : invoiceModule.findAllCustomers()) {
            System.out.println(customer);
        }
        for (Invoice i : invoiceModule.findAllInvoices()) {
            System.out.println(i);
        }
        List<Invoice> allPaid = invoiceModule.findInvoicesByStatus(InvoiceStatus.PAID);
        System.out.println("Count of paied is "+allPaid);
        System.out.println("End");
        System.exit(0);
    }
}
