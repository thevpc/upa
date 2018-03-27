package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.persistence.ResultMetaData;

/**
 * Created by vpc on 6/26/16.
 */
public interface QueryResultItemBuilder {
    Object createResult(ResultColumn[] row,ResultMetaData metadata);
}
