package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.PlatformBeanType;
import net.vpc.upa.exceptions.UPAIllegalArgumentException;
import net.vpc.upa.impl.util.PlatformBeanTypeRepository;
import net.vpc.upa.persistence.ResultMetaData;

import java.util.Arrays;
import java.util.HashSet;
import java.util.Set;

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
