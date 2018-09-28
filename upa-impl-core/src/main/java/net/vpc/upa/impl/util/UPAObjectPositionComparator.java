/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.util;

import java.util.Comparator;
import net.vpc.upa.UPAObject;

/**
 *
 * @author vpc
 */
public class UPAObjectPositionComparator implements Comparator<UPAObject>{
    public static final UPAObjectPositionComparator INSTANCE=new UPAObjectPositionComparator();

    private UPAObjectPositionComparator() {
    }
    
    @Override
    public int compare(UPAObject o1, UPAObject o2) {
        return Integer.compare(o1.getPreferredPosition(), o2.getPreferredPosition());
    }
    
}
