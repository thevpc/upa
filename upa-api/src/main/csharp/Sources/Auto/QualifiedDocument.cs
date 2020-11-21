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
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/3/12 1:19 AM
     */
    public interface QualifiedDocument : Net.TheVpc.Upa.Document {

         Net.TheVpc.Upa.Entity GetEntity();

         Net.TheVpc.Upa.Document GetDocument();

         string GetDocumentName();

         Net.TheVpc.Upa.Key GetKey();

         void SetKey(Net.TheVpc.Upa.Key key);

         object GetId();

         void SetIdentifier(object @value);

         object[] GetRawId();

         void SetRawId(params object [] ids);
    }
}
