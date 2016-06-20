/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.util;

import net.vpc.upa.Entity;
import net.vpc.upa.EntityModifier;
import net.vpc.upa.filters.EntityFilter;
import net.vpc.upa.filters.ObjectFilter;

/**
 *
 * @author vpc
 */
public class SimpleEntityFilter implements EntityFilter{
    private ObjectFilter<String> name;
    private boolean includeSystem;

    public SimpleEntityFilter(ObjectFilter<String> name, boolean includeSystem) {
        this.name = name;
        this.includeSystem = includeSystem;
    }

    public boolean accept(Entity s) {
        if(s.getModifiers().contains(EntityModifier.SYSTEM)){
            if(!includeSystem){
                return false;
            }
        }
        if(name!=null){
            if(!name.accept(s.getName())){
                return false;
            }
        }
        return true;
    }
    
}
