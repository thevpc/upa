package net.vpc.upa.impl.upql;

import net.vpc.upa.impl.persistence.NativeField;

import java.util.Comparator;

/**
 * Created by vpc on 7/8/17.
 */
public class NativeFieldByBindingIdComparator implements Comparator<NativeField>{
    public static final NativeFieldByBindingIdComparator INSTANCE=new NativeFieldByBindingIdComparator();
    @Override
    public int compare(NativeField o1, NativeField o2) {
        if(o1==null && o2==null){
            return 0;
        }
        if(o1==null){
            return -1;
        }
        if(o2==null){
            return 1;
        }
        int x=Integer.compare(depth(o1.getBindingId()),depth(o2.getBindingId()));
        if(x!=0){
            return x;
        }
        return o1.getBindingId().toString().compareTo(o2.getBindingId().toString());
    }

    private int depth(BindingId z){
        if(z==null){
            return 0;
        }
        if(z.getParent()==null){
            return 1;
        }
        return 1+depth(z.getParent());
    }
}
