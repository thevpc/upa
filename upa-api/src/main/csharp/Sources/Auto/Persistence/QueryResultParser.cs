/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE HAS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.Vpc.Upa.Persistence
{


    /**
     * Created with IntelliJ IDEA.
     * User: vpc
     * Date: 8/16/12
     * Time: 6:36 AM
     * To change this template use File | Settings | File Templates.
     */
    public interface QueryResultParser<T> {

         bool HasNext(Net.Vpc.Upa.Persistence.QueryResult result) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         T Parse(Net.Vpc.Upa.Persistence.QueryResult result) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;
    }
}
