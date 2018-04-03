package net.vpc.upa.spring.test;

import net.vpc.upa.PersistenceUnit;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;

@Repository
@Transactional
public class Repo {
    @Autowired
    private PersistenceUnit pu;

    public  List<Category> findAll() {
        List<Category> all = pu.findAll(Category.class);
        return all;
    }

    public void save(Category c){
        pu.save(c);
    }
}
