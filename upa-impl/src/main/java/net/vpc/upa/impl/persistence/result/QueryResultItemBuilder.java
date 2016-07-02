package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.persistence.ResultMetaData;

import java.util.Map;

/**
 * Created by vpc on 6/26/16.
 */
public interface QueryResultItemBuilder {
    public Object createResult(ResultColumn[] row,ResultMetaData metadata);
}
