package net.vpc.upa.impl.persistence;

import java.util.HashMap;
import java.util.Map;

/**
 * @author taha.bensalah@gmail.com on 7/20/16.
 */
public class DefaultEmbeddedDatasourceFactoryComparator implements EmbeddedDatasourceFactoryComparator {
    public static final DefaultEmbeddedDatasourceFactoryComparator INSTANCE= new DefaultEmbeddedDatasourceFactoryComparator();
    private static Map<String,Integer> defaultOrders=new HashMap<String, Integer>();
    static{
        defaultOrders.put(DBCPv2EmbeddedDatasourceFactory.class.getName(),1);
        defaultOrders.put(DBCPv1EmbeddedDatasourceFactory.class.getName(),2);
    }
    public DefaultEmbeddedDatasourceFactoryComparator() {
    }

    @Override
    public int compare(EmbeddedDatasourceFactory o1, EmbeddedDatasourceFactory o2) {
        String cls1 = o1 == null ? "" : o1.getClass().getName();
        Integer a=defaultOrders.get(cls1);
        String cls2 = o2 == null ? "" : o2.getClass().getName();
        Integer b=defaultOrders.get(cls2);
        if(a ==null && b ==null){
            return cls1.compareTo(cls2);
        }else if(a!=null && b!=null){
            return a.compareTo(b);
        }else if(a==null){
            return -1;
        }else{
            return 1;
        }
    }
}
