/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.filters;

/**
 *
 * @author vpc
 */
public interface ObjectFilter<T> {
    public boolean accept(T value);
}
