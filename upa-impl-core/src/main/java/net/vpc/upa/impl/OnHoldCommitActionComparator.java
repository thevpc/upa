/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl;

import java.util.Comparator;

/**
 *
 * @author taha.bensalah@gmail.com
 */
class OnHoldCommitActionComparator implements Comparator<OnHoldCommitAction> {

    public OnHoldCommitActionComparator() {
    }

    @Override
    public int compare(OnHoldCommitAction o1, OnHoldCommitAction o2) {
        return o1.getOrder() - o2.getOrder();
    }
    
}
