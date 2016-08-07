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



namespace Net.Vpc.Upa.Persistence
{


    public interface ConnectionProfile {

         Net.Vpc.Upa.Persistence.DatabaseProduct GetDatabaseProduct();

         string GetDatabaseProductVersion();

        /**
             * can be one of the following
             * DRIVER_TYPE_EMBEDDED = "EMBEDDED";
             * DRIVER_TYPE_DEFAULT = "DEFAULT";
             * DRIVER_TYPE_DATASOURCE = "DATASOURCE";
             * DRIVER_TYPE_GENERIC = "GENERIC";
             * String DRIVER_TYPE_ODBC = "ODBC";
             * @return 
             */
         string GetConnectionDriver();

         string GetConnectionDriverVersion();

         Net.Vpc.Upa.Persistence.StructureStrategy GetStructureStrategy();

         System.Collections.Generic.IDictionary<string , string> GetProperties();
    }
}
