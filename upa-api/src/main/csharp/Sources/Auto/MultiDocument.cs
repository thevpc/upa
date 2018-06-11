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



namespace Net.Vpc.Upa
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

         Net.Vpc.Upa.Document GetPlainDocument();

         Net.Vpc.Upa.Document GetPlainDocument(bool create);

         Net.Vpc.Upa.Document GetDocument(string entityName);

         void SetDocument(string entityName, Net.Vpc.Upa.Document document);

         Net.Vpc.Upa.Document GetSingleDocument();

         Net.Vpc.Upa.Document Merge();
    }
}
