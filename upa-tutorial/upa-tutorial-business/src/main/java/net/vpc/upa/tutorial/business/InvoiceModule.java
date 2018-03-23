/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.tutorial.business;

import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.RemoveOptions;
import net.vpc.upa.UPA;
import net.vpc.upa.expressions.*;
import net.vpc.upa.tutorial.model.*;

import java.util.Date;
import java.util.List;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class InvoiceModule {

    /**
     * find all
     * @return
     */
    public List<Invoice> findAllInvoices() {
        PersistenceUnit pu = UPA.getPersistenceUnit();
        return pu.findAll(Invoice.class);
    }

    /**
     * add proxying if Spring or other Frameworks is not used
     * @return
     */
    public static InvoiceModule createInvoiceModule() {
        return UPA.makeSessionAware(new InvoiceModule());
    }

    /**
     * find all
     * @return
     */
    public List<Customer> findAllCustomers() {
        return UPA.getPersistenceUnit().createQueryBuilder(Customer.class).getResultList();
    }

    /**
     * search by prototype
     * @param prototype
     * @return
     */
    public List<Customer> findCustomers(Customer prototype) {
        return UPA.getPersistenceUnit().createQueryBuilder(Customer.class).byPrototype(prototype).getResultList();
    }

    /**
     * Saving un object (insert or update)
     * @param customer
     */
    public void saveCustomer(Customer customer) {
        UPA.getPersistenceUnit().save(customer);
    }

    /**
     * Saving un object (insert or update)
     * @param product
     */
    public void saveProduct(Product product) {
        UPA.getPersistenceUnit().save(product);
    }

    /**
     * Removing by Id
     * @param customerId
     */
    public void deleteCustomer(int customerId) {
        UPA.getPersistenceUnit().remove(Customer.class, RemoveOptions.forId(customerId));
    }

    /**
     * inserting Invoices
     * @param invoice
     */
    public void addInvoice(Invoice invoice) {
        PersistenceUnit persistenceUnit = UPA.getPersistenceUnit();

        persistenceUnit.persist(invoice);

        for (InvoiceDetail d : invoice.getDetails()) {
            d.setInvoiceId(invoice.getInvoiceId());
            persistenceUnit.persist(d);
        }
    }

    /**
     * searching by expression
     * @param start
     * @param end
     * @return
     */
    public List<Invoice> findInvoiceListByDate(Date start, Date end) {
        Expression a = null;
        if (start != null) {
            a = new LessThan(new Var("date"), new Param("startDate", start));
        }
        if (end != null) {
            Expression b = new LessThan(new Var("date"), new Param("endDate", end));
            a = a == null ? b : new And(a, b);
        }
        return UPA.getPersistenceUnit().createQueryBuilder(Invoice.class).byExpression(a).getResultList();
    }

    /**
     * Retrieve Customer list
     * @param customerId
     * @return
     */
    public List<Invoice> findInvoiceListByCustomer(int customerId) {
        return UPA.getPersistenceUnit().createQueryBuilder(Invoice.class)
                .byExpression("customerId=:customerId")
                .setParameter("customerId", customerId)
                .getResultList();
    }

    /**
     * Retrieve Customer as a simple expression using the 'getValueList' method
     * @return
     */
    public List<String> findCustomerNames() {
        return UPA.getPersistenceUnit().createQuery("Select name from Customer order by name asc").getValueList(0);
    }

    /**
     * Retrieve Customer as a Header List using the 'getTypeList' method
     * @return
     */
    public List<Header> findCustomerHeader() {
        return UPA.getPersistenceUnit().createQuery("Select customerId id, name name from Customer order by name asc")
                .getResultList(Header.class);
    }

    public List<Invoice> findInvoicesByStatus(InvoiceStatus status){
        return UPA.getPersistenceUnit().createQuery("Select c from Invoice c where c.status='"+status+"'")
                .getResultList();
    }
}
