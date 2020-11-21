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



namespace Net.TheVpc.Upa.Impl.Persistence
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/6/12 12:29 AM
     */
    public interface SQLManager {

         void Register(Net.TheVpc.Upa.Impl.Persistence.SQLProvider provider);

         Net.TheVpc.Upa.Impl.Persistence.MarshallManager GetMarshallManager();

         string GetSQL(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression, Net.TheVpc.Upa.Persistence.EntityExecutionContext context, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;
    }
}
