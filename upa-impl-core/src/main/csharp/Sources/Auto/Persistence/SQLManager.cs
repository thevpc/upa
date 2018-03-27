/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE AS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.Vpc.Upa.Impl.Persistence
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/6/12 12:29 AM
     */
    public interface SQLManager {

         void Register(Net.Vpc.Upa.Impl.Persistence.SQLProvider provider);

         Net.Vpc.Upa.Impl.Persistence.MarshallManager GetMarshallManager();

         string GetSQL(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression, Net.Vpc.Upa.Persistence.EntityExecutionContext context, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;
    }
}
