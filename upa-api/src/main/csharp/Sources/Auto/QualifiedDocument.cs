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
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/3/12 1:19 AM
     */
    public interface QualifiedDocument : Net.Vpc.Upa.Document {

         Net.Vpc.Upa.Entity GetEntity();

         Net.Vpc.Upa.Document GetDocument();

         string GetDocumentName();

         Net.Vpc.Upa.Key GetKey();

         void SetKey(Net.Vpc.Upa.Key key);

         object GetId();

         void SetIdentifier(object @value);

         object[] GetRawId();

         void SetRawId(params object [] ids);
    }
}
