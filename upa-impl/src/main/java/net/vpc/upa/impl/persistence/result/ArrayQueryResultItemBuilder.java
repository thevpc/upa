package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.expressions.Expression;
import net.vpc.upa.impl.persistence.DefaultResultMetaData;
import net.vpc.upa.impl.util.UPAUtils;
import net.vpc.upa.persistence.ResultField;
import net.vpc.upa.persistence.ResultMetaData;

import java.util.List;
import java.util.Map;

/**
 * Created by vpc on 6/26/16.
 */
public class ArrayQueryResultItemBuilder implements QueryResultItemBuilder {
    private static String CACHE_KEY = "ArrayQueryResultItemBuilder.binding";
    @Override
    public Object createResult(ResultColumn[] row, ResultMetaData metadata) {
        List<ResultField> fields = metadata.getFields();
        DefaultResultMetaData d=(DefaultResultMetaData) metadata;
        String[] bindings=(String[]) d.getProperties().get(CACHE_KEY);
        if(bindings==null){
            bindings=new String[fields.size()];
            for (int i = 0; i < fields.size(); i++) {
                ResultField field = fields.get(i);
                Expression ss = field.getExpression();
                String binding = ss == null ? "null" : ss.toString();
                bindings[i]=binding;
            }
            d.getProperties().put(CACHE_KEY, bindings);
        }

        Object[] allRet=new Object[fields.size()];
        for (int i = 0; i < allRet.length; i++) {
            allRet[i]=row[i].getValue();
        }
        return allRet;
    }
}
