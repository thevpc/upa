//package net.thevpc.upa.impl.persistence;
//
//import net.thevpc.upa.PortabilityHint;
//import net.thevpc.upa.persistence.QueryResult;
//import net.thevpc.upa.persistence.QueryResultParser;
//
//import java.util.Iterator;
//
///**
// * Created with IntelliJ IDEA.
// * User: vpc
// * Date: 8/16/12
// * Time: 6:34 AM
// * To change this template use File | Settings | File Templates.
// */
//@PortabilityHint(target = "C#",name = "partial")
//public class QueryResultReader<T> implements Iterator<T> {
//    private QueryResult queryResult;
//    private QueryResultParser<T> queryResultParser;
//
//    public QueryResultReader(QueryResult resultSet, QueryResultParser<T> queryResultParser) {
//        this.queryResult = resultSet;
//        this.queryResultParser = queryResultParser;
//    }
//
//    @PortabilityHint(target = "C#",name = "ignore")
//    @Override
//    public boolean hasNext() {
//        return queryResultParser.hasNext(queryResult);
//    }
//
//    @PortabilityHint(target = "C#",name = "ignore")
//    @Override
//    public T next() {
//        return queryResultParser.parse(queryResult);
//    }
//
//    @PortabilityHint(target = "C#",name = "ignore")
//    @Override
//    public void remove() {
//        throw new UPAIllegalArgumentException("Unsupported");
//    }
//}
