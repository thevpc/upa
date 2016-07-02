/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.tutorial.model;

import net.vpc.upa.UserFieldModifier;

import net.vpc.upa.config.*;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@Entity(path = "Tutorial/CustomerManagement")
public class Customer {

    @Id @Sequence
    private int customerId;
    @Field(max = "50", nullable = BoolEnum.TRUE,modifiers = UserFieldModifier.MAIN)
    private String name;
    @Summary
    private java.sql.Date birthDate;

    public int getCustomerId() {
        return customerId;
    }

    public void setCustomerId(int customerId) {
        this.customerId = customerId;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public java.sql.Date getBirthDate() {
        return birthDate;
    }

    public void setBirthDate(java.sql.Date birthDate) {
        this.birthDate = birthDate;
    }

    @Override
    public String toString() {
        return "Customer{" + "customerId=" + customerId + ", name=" + name + ", birthDate=" + birthDate + '}';
    }

    
}
