/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.persistence;

/**
 *
 * @author vpc
 */
public class UPALockDetectedException extends RuntimeException{

    public UPALockDetectedException(String query) {
        super("UPALockDetected \n"+query);
    }
    
}
