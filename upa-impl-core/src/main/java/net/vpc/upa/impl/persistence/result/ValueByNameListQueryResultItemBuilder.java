package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.exceptions.IllegalUPAArgumentException;
import net.vpc.upa.persistence.ResultMetaData;

public class ValueByNameListQueryResultItemBuilder implements QueryResultItemBuilder {
    private int index=-1;
    private String name;
    public ValueByNameListQueryResultItemBuilder(String name) {
        this.name = name;
        if(name==null){
            throw new IllegalUPAArgumentException("Empty name");
        }
    }

    @Override
    public Object createResult(ResultColumn[] row, ResultMetaData metadata) {
        if(index<0){
            for (int i = 0; i < row.length; i++) {
                ResultColumn column = row[i];
                if (name.equalsIgnoreCase(column.getLabel())) {
                    index =i;
                    break;
                }
            }
        }
        return row[index].getValue();
    }
}
