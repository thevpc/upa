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



namespace Net.Vpc.Upa.Exceptions
{


    public class PersistRecordNotAllowedException : Net.Vpc.Upa.Exceptions.EntityException {

        public PersistRecordNotAllowedException(Net.Vpc.Upa.Entity entity)  : base(entity, "insert.NotAllowed"){

        }

        public PersistRecordNotAllowedException(Net.Vpc.Upa.Entity entity, string operationName)  : base(entity, operationName){

        }
    }
}
