/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.test.web.presentation;

import java.util.List;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;

import net.vpc.upa.UPA;
import net.vpc.upa.tutorial.business.InvoiceModule;
import net.vpc.upa.tutorial.model.Customer;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@ManagedBean
@SessionScoped
public class MyBean {

    InvoiceModule module = new InvoiceModule();
    private Customer selectedCustomer = new Customer();

    /**
     * Creates a new instance of MyBean
     */
    public MyBean() {
    }

    public String getValue() {
        return module.findCustomerNames().toString();
    }

    public List<Customer> getCustomerList() {
        return module.findAllCustomers();
    }

    public Customer getSelectedCustomer() {
        return selectedCustomer;
    }

    public void setSelectedCustomer(Customer selectedCustomer) {
        this.selectedCustomer = selectedCustomer;
    }

    public void addCustomer() {
        UPA.getPersistenceUnit().persist(getSelectedCustomer());
        setSelectedCustomer(new Customer());
    }
}
