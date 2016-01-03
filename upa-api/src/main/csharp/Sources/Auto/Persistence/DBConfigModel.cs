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

    /**
     * Created by IntelliJ IDEA.
     * User: root
     * Date: 9 mai 2003
     * Time: 11:34:42
     * To change this template use Options | File Templates.
     */

    public interface DBConfigModel {

         string[] GetConnectionStringArray();

         void SetConnectionStringArray(string[] adapters);

         string GetConnectionString();

         void SetConnectionString(string adapter);
    }
}
