/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.util;

/**
 *
 * @author vpc
 */
public interface ObjectFilter<T> {
    public boolean accept(T value);
}
