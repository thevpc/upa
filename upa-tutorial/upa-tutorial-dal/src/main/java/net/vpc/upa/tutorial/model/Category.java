/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.tutorial.model;


import net.vpc.upa.config.*;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@Singleton
public class Category {

    @Id @Sequence
    private int id;
    private String name;
    @Hierarchy
    private Category parent;

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public Category getParent() {
        return parent;
    }

    public void setParent(Category parent) {
        this.parent = parent;
    }

    
}
