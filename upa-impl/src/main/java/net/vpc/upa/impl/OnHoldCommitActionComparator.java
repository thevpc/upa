/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl;

import java.util.Comparator;

/**
 *
 * @author vpc
 */
class OnHoldCommitActionComparator implements Comparator<OnHoldCommitAction> {

    public OnHoldCommitActionComparator() {
    }

    @Override
    public int compare(OnHoldCommitAction o1, OnHoldCommitAction o2) {
        return o1.getOrder() - o2.getOrder();
    }
    
}
