package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.persistence.QueryResult;

/**
 * Created by vpc on 7/2/17.
 */
class ColumnFamilyParserSingleIdExternalLoadEntity implements ColumnFamilyParser {
    public static final ColumnFamilyParser INSTANCE = new ColumnFamilyParserSingleIdExternalLoadEntity();

    private ColumnFamilyParserSingleIdExternalLoadEntity() {

    }

    @Override
    public void parse(QueryResult result, ColumnFamily columnFamily, LazyResult lazyResult, QueryResultParserHelper parser) throws UPAException {
        FieldInfo idField = columnFamily.idFields.get(0);
        Object id = result.read(idField.dbIndex);
        TypeInfoSupParserHelper.loadExternalObject(id, columnFamily, lazyResult, parser);
    }

}
