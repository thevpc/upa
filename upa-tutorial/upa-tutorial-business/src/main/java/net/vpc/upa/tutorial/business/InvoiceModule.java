/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.tutorial.business;

import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.UPA;
import net.vpc.upa.expressions.*;
import net.vpc.upa.tutorial.model.*;

import java.util.Date;
import java.util.List;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class InvoiceModule {

    public List<Invoice> findAllInvoices() {
        PersistenceUnit pu = UPA.getPersistenceUnit();
        return pu.findAll(Invoice.class);
    }

    public static InvoiceModule createInvoiceModule() {
        return UPA.makeSessionAware(new InvoiceModule());
    }

    public List<Customer> findAllCustomers() {
        return UPA.getPersistenceUnit().createQueryBuilder(Customer.class).getEntityList();
    }

    public List<Customer> findCustomers(Customer prototype) {
        return UPA.getPersistenceUnit().createQueryBuilder(Customer.class).byPrototype(prototype).getEntityList();
    }

    public void saveCustomer(Customer customer) {
        UPA.getPersistenceUnit().save(customer);
    }

    public void saveProduct(Product product) {
        UPA.getPersistenceUnit().save(product);
    }

    public void deleteCustomer(int customerId) {
        UPA.getPersistenceUnit().remove(Customer.class, customerId);
    }

    public void addInvoice(Invoice invoice) {
        PersistenceUnit persistenceUnit = UPA.getPersistenceUnit();

        persistenceUnit.persist(invoice);

        for (InvoiceDetail d : invoice.getDetails()) {
            d.setInvoiceId(invoice.getInvoiceId());
            persistenceUnit.persist(d);
        }
    }

    public List<Invoice> findInvoiceListByDate(Date start, Date end) {
        Expression a = null;
        if (start != null) {
            a = new LessThan(new Var("date"), new Param("startDate", start));
        }
        if (end != null) {
            Expression b = new LessThan(new Var("date"), new Param("endDate", end));
            a = a == null ? b : new And(a, b);
        }
        return UPA.getPersistenceUnit().createQueryBuilder(Invoice.class).byExpression(a).getEntityList();
    }

    public List<Invoice> findInvoiceListByCustomer(int customerId) {
        return UPA.getPersistenceUnit().createQueryBuilder(Invoice.class)
                .byExpression("customerId=:customerId")
                .setParameter("customerId", customerId)
                .getEntityList();
    }

    public List<String> findCustomerNames() {
        return UPA.getPersistenceUnit().createQuery("Select name from Customer order by name asc").getValueList(0);
    }

    public List<Header> findCustomerHeader() {
        return UPA.getPersistenceUnit().createQuery("Select customerId id, name name from Customer order by name asc").getTypeList(Header.class);
    }
}
