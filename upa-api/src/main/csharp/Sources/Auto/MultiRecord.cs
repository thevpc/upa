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



namespace Net.Vpc.Upa
{

    /**
     * Created with IntelliJ IDEA.
     * User: vpc
     * Date: 8/17/12
     * Time: 2:57 PM
     * To change this template use File | Settings | File Templates.
     */
    public interface MultiRecord {

         int EntitySize();

         int FieldSize();

         Net.Vpc.Upa.Record GetPlainRecord();

         Net.Vpc.Upa.Record GetPlainRecord(bool create);

         Net.Vpc.Upa.Record GetRecord(string entityName);

         void SetRecord(string entityName, Net.Vpc.Upa.Record record);

         Net.Vpc.Upa.Record GetSingleRecord();

         Net.Vpc.Upa.Record Merge();
    }
}
