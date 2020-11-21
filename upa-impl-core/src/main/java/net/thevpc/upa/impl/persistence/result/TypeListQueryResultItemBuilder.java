package net.thevpc.upa.impl.persistence.result;

import net.thevpc.upa.PlatformBeanType;
import net.thevpc.upa.exceptions.IllegalUPAArgumentException;
import net.thevpc.upa.impl.util.PlatformUtils;
import net.thevpc.upa.persistence.ResultMetaData;

import java.util.Arrays;
import java.util.HashSet;
import java.util.Set;

public class TypeListQueryResultItemBuilder implements QueryResultItemBuilder {
    private final Class platformType;
    private final String[] fields;
    private final PlatformBeanType platformBeanType;
    private final Set<String> fields2;
    public TypeListQueryResultItemBuilder(Class type, String... fields) {
        this.platformType = type;
        this.fields = fields;
        platformBeanType = PlatformUtils.getBeanType(type);
        fields2=new HashSet<>();
        if(fields.length==0){
            fields2.addAll(platformBeanType.getPropertyNames());
        }else{
            fields2.addAll(Arrays.asList(fields));
        }
    }

    @Override
    public Object createResult(ResultColumn[] row, ResultMetaData metadata) {
        Object o = platformBeanType.newInstance();
        for (int i = 0; i < row.length; i++) {
            ResultColumn c = row[i];
            if(fields2.contains(c.getLabel())){
                platformBeanType.setPropertyValue(o,c.getLabel(),c.getValue());
            }else{
                throw new IllegalUPAArgumentException("Invalid property "+c.getLabel()+" in "+ platformType.getName());
            }
        }
        return o;
    }
}
