/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.tutorial.model;


import net.thevpc.upa.config.Id;
import net.thevpc.upa.config.Sequence;
import net.thevpc.upa.config.View;
import net.thevpc.upa.config.*;

/**
 * This is a View Entity described as Class and a UPQL query
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@View(
    query = "Select o from Product o where o.country='TN'"
)
public class TunisianProducts {
    @Id
    @Sequence
    private int id;
    private String name;

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
    
}
