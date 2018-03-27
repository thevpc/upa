/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */

package net.vpc.upa.impl.util;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class OrderedIem<T> implements Comparable<OrderedIem<T>>{
    public int order;
    public T value;

    public OrderedIem(int order, T value) {
        this.order = order;
        this.value = value;
    }

    public int compareTo(OrderedIem<T> o) {
        if(o ==null){
            return 1;
        }
        if(order<o.order){
            return -1;
        }else if(order>o.order){
            return 1;
        }else{
            return 0;
        }
    }
    
}
