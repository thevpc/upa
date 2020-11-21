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



namespace Net.TheVpc.Upa
{

    /**
     * Created with IntelliJ IDEA.
     * User: vpc
     * Date: 8/17/12
     * Time: 2:57 PM
     * To change this template use File | Settings | File Templates.
     */
    public interface MultiDocument {

         int EntitySize();

         int FieldSize();

         Net.TheVpc.Upa.Document GetPlainDocument();

         Net.TheVpc.Upa.Document GetPlainDocument(bool create);

         Net.TheVpc.Upa.Document GetDocument(string entityName);

         void SetDocument(string entityName, Net.TheVpc.Upa.Document document);

         Net.TheVpc.Upa.Document GetSingleDocument();

         Net.TheVpc.Upa.Document Merge();
    }
}
