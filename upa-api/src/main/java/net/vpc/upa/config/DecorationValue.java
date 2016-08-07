/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.config;


/**
 *
 * @author taha.bensalah@gmail.com
 */
public interface DecorationValue extends Comparable<DecorationValue> {

//    void merge();
//
//    DecorationValue[] getAlternatives();
//
//    void addAlternative(DecorationValue other);

    ConfigInfo getConfig();
}
