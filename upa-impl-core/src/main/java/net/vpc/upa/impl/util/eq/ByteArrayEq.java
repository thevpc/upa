/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.util.eq;

import java.util.Arrays;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class ByteArrayEq implements EqualHelper {

    public static final EqualHelper INSTANCE = new ByteArrayEq();

    public boolean equals(Object o1, Object o2) {
        byte[] a = (byte[]) o1;
        byte[] b = (byte[]) o2;
        if(a==b){
            return true;
        }
        if(a==null || b==null){
            return false;
        }
        if(a.length!=b.length){
            return false;
        }
        for (int i = 0; i < a.length; i++) {
            if(a[i]!=b[i]){
                return false;
            }
        }
        return true;
    }

}
