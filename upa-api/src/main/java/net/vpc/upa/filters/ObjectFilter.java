/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.filters;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public interface ObjectFilter<T> {
    boolean accept(T value);
}
