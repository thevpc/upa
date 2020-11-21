package net.thevpc.upa.spring.test;

import net.thevpc.upa.PersistenceUnit;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;

@Repository
public class Repo {
    private PersistenceUnit pu;

    public  List<Category> findAll() {
        List<Category> all = pu.findAll(Category.class);
        return all;
    }
    @Autowired

    public void setPu(PersistenceUnit pu) {
        this.pu = pu;
    }

    @Transactional
    public void save(Category c){
        pu.save(c);
    }
}
