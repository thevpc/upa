package net.thevpc.upa.spring.test;

import net.thevpc.upa.config.Entity;
import net.thevpc.upa.config.Id;
import net.thevpc.upa.config.Sequence;

@Entity
public class Category {

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