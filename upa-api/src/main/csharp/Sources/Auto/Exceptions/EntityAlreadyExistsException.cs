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



namespace Net.Vpc.Upa.Exceptions
{

    /**
     * Created by IntelliJ IDEA. User: vpc Date: 25 juin 2006 Time: 15:03:00 To
     * change this template use File | Settings | File Templates.
     */
    public class EntityAlreadyExistsException : Net.Vpc.Upa.Exceptions.EntityException {

        /**
             * @param entityName       name of the cashing Entity
             * @param source           Source for the clashing Entity
             * @param registererSource Source for already registered Entity
             */
        public EntityAlreadyExistsException(string entityName, object source, object registererSource)  : base("EntityAlreadyExistsException", entityName, source, registererSource){

        }
    }
}
