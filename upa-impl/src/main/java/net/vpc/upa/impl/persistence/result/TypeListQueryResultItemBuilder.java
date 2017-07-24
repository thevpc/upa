package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.PlatformBeanType;
import net.vpc.upa.exceptions.UPAIllegalArgumentException;
import net.vpc.upa.impl.persistence.result.QueryResultItemBuilder;
import net.vpc.upa.impl.persistence.result.ResultColumn;
import net.vpc.upa.impl.util.PlatformBeanTypeRepository;
import net.vpc.upa.persistence.ResultMetaData;

import java.util.Arrays;
import java.util.HashSet;
import java.util.Set;

public class TypeListQueryResultItemBuilder implements QueryResultItemBuilder {
    private final Class type;
    private final String[] fields;
    private PlatformBeanType platformBeanType;
    private Set<String> fields2;
    public TypeListQueryResultItemBuilder(Class type, String... fields) {
        this.type = type;
        this.fields = fields;
        platformBeanType = PlatformBeanTypeRepository.getInstance().getBeanType(type);
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
                platformBeanType.setProperty(o,c.getLabel(),c.getValue());
            }else{
                throw new UPAIllegalArgumentException("Invalid property "+c.getLabel()+" in "+ type.getName());
            }
        }
        return o;
    }
}
