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



namespace Net.Vpc.Upa.Bulk
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public interface ImportEntityFinder {

         object FindEntity(Net.Vpc.Upa.Entity entity, System.Collections.Generic.IDictionary<string , object> values);

         bool Accept(Net.Vpc.Upa.Entity entity);
    }
}
