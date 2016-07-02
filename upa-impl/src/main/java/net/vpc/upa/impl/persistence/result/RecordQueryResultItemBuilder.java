package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.Record;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.impl.DefaultRecord;
import net.vpc.upa.impl.persistence.DefaultResultMetaData;
import net.vpc.upa.impl.util.StringUtils;
import net.vpc.upa.persistence.ResultField;
import net.vpc.upa.persistence.ResultMetaData;

import java.util.List;
import java.util.Map;

/**
 * Created by vpc on 6/26/16.
 */
public class RecordQueryResultItemBuilder implements QueryResultItemBuilder {
    private static final String CACHE_KEY = "RecordQueryResultItemBuilder.preferredNameAndBinding";
    @Override
    public Object createResult(ResultColumn[] row, ResultMetaData metadata) {
        List<ResultField> fields = metadata.getFields();

        DefaultResultMetaData d=(DefaultResultMetaData) metadata;
        String[][] preferredNameAndBinding=(String[][]) d.getProperties().get(CACHE_KEY);
        if(preferredNameAndBinding==null){
            preferredNameAndBinding=new String[fields.size()][2];
            for (int i = 0; i < fields.size(); i++) {
                ResultField field = fields.get(i);
                Expression ss = field.getExpression();
                String binding = ss == null ? "null" : ss.toString();
                String preferredName = binding;
                if (preferredName.indexOf('.') >= 0) {
                    preferredName = preferredName.substring(preferredName.lastIndexOf('.') + 1);
                }
                String alias = field.getAlias();
                if (!StringUtils.isNullOrEmpty(alias)) {
                    preferredName = alias;
                }
                preferredNameAndBinding[i][0]=preferredName;
                preferredNameAndBinding[i][1]=binding;
            }
            d.getProperties().put(CACHE_KEY, preferredNameAndBinding);
        }
        if(fields.size()==1 && row[0].getValue() instanceof Record){
            return row[0].getValue();
        }
        Record r=new DefaultRecord();
        for (int i = 0; i < fields.size(); i++) {
            String preferredName = preferredNameAndBinding[i][0];
            r.setObject(preferredName, row[i].getValue());
        }
        return r;
    }
}
