/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.util;

import net.thevpc.upa.Entity;
import net.thevpc.upa.EntityModifier;
import net.thevpc.upa.filters.EntityFilter;
import net.thevpc.upa.filters.ObjectFilter;

/**
 *
 * @author taha.bensalah@gmail.com
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
