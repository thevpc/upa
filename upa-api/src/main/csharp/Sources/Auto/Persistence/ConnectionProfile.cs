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



namespace Net.TheVpc.Upa.Persistence
{


    public interface ConnectionProfile {

         Net.TheVpc.Upa.Persistence.DatabaseProduct GetDatabaseProduct();

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

         Net.TheVpc.Upa.Persistence.StructureStrategy GetStructureStrategy();

        /**
             *
             * @return unmodifiable map
             */
         System.Collections.Generic.IDictionary<string , string> GetProperties();

         void SetProperty(string name, string @value);

         string GetProperty(string name);

         string GetProperty(string name, string defaultValue);

         Net.TheVpc.Upa.Persistence.ConnectionProfile Copy();
    }
}
