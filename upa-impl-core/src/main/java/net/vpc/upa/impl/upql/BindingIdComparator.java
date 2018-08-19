package net.vpc.upa.impl.upql;

import java.util.Comparator;

/**
 * Created by vpc on 7/8/17.
 */
public class BindingIdComparator implements Comparator<BindingId>{
    public static final BindingIdComparator INSTANCE=new BindingIdComparator();
    @Override
    public int compare(BindingId o1, BindingId o2) {
        if(o1==null && o2==null){
            return 0;
        }
        if(o1==null){
            return -1;
        }
        if(o2==null){
            return 1;
        }
        return o1.toString().compareTo(o2.toString());
    }
}
