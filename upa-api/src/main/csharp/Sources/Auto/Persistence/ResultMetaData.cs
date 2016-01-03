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
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/1/12 12:40 AM
     */
    public interface ResultMetaData {

         int GetFieldsCount() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         string GetFieldName(int index) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Types.DataType GetFieldType(int index) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Types.DataTypeTransform GetFieldTransform(int index) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Field GetField(int index) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Entity GetEntity(int index) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;
    }
}
