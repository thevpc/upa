/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.tutorial.model;

import net.vpc.upa.UserFieldModifier;

import net.vpc.upa.config.*;

/**
 * This is a simple Entity Class
 * path in the @Entity anotation defines the Entity Package
 * to which belongs the entoty (defined as a package path)
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@Entity(path = "Tutorial/CustomerManagement")
public class Customer {

    /**
     * @Id defines a 'primary key' field
     * @Sequence defines an 'autoincrement' field.
     * Sequences are sort of a GeneratedValue in JPA
     * But as there are other Generated values (Formulas)
     * The name 'Sequence' is more appropriate
     */
    @Id @Sequence
    private int customerId;

    /**
     * Main field is the 'toString' like field. The one
     * most important to consider by humans.
     * If Many fields are defined as @Main only one is considered.
     * Usually a Main field field is the one you would show  instead of
     * the Id for a Human
     */
    @Main
    /**
     * Field annotation defines field constraints (this is
     * comparable to the @Column entity for JPA
     * When using 'Partital' Entities, such annotations are 'merged'
     */
    @Field(max = "50", nullable = BoolEnum.TRUE)
    private String name;

    /**
     * a summary field is a human important information
     * but not as important as the 'Main' field.
     * Usually a summary fields are the one you would show on
     * a standard list of the Entity
     */
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
