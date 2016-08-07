package net.vpc.upa.test;

import java.lang.reflect.Field;
import java.util.ArrayList;

/**
 * @author taha.bensalah@gmail.com on 7/24/16.
 */
public class AA {
    public static void main(String[] args) {
        ArrayList a0 = new ArrayList();
        ArrayList a = new ArrayList(5);
        try {
            Field elementData = a.getClass().getDeclaredField("elementData");
            elementData.setAccessible(true);
            Object[] o = (Object[]) elementData.get(a);
            System.out.println(a.size()+":"+o.length);
            for (int i = 0; i < 200; i++) {
                a.add("a "+i);
                Object[] oo = (Object[]) elementData.get(a);
                int s = a.size();
                int m = oo.length;
                System.out.println(s +":"+ m +" "+((double)m/(double)s - 1.0)*100);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
