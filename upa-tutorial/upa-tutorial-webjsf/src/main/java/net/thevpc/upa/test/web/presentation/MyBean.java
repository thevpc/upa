/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.test.web.presentation;

import net.thevpc.upa.tutorial.model.Customer;
import net.thevpc.upa.UPA;
import net.thevpc.upa.tutorial.business.InvoiceModule;

import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;
import java.util.List;

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
