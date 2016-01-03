/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.config;


/**
 *
 * @author vpc
 */
public interface DecorationValue extends Comparable<DecorationValue> {

//    void merge();
//
//    DecorationValue[] getAlternatives();
//
//    void addAlternative(DecorationValue other);

    ConfigInfo getConfig();
}
