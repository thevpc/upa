package net.thevpc.upa.impl.persistence.result;

import net.thevpc.upa.persistence.ResultMetaData;


public class ValueByIndexListQueryResultItemBuilder implements QueryResultItemBuilder {
    private int index;
    public ValueByIndexListQueryResultItemBuilder(int index) {
        this.index = index;
    }

    @Override
    public Object createResult(ResultColumn[] row, ResultMetaData metadata) {
        return row[index].getValue();
    }
}
