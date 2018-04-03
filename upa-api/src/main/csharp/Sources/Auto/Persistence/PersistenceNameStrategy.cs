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



namespace Net.Vpc.Upa.Persistence
{


    /**
     * Hello Example of Annotation config
     * <pre>
     * &amp;@PersistenceUnit(
     *      persistenceNameStrategy = @PersistenceNameStrategy(
     *              persistenceName = "{OBJECT_NAME}",
     *              suffix = "_TBL",
     *              prefix = "T_",
     *              escape = "UPA_*",
     *              names = {@PersistenceName(
     *                      type = PersistenceNameType.INDEX,
     *                      prefix = "NDX_"
     *              )}
     *      )
     * )
     * </pre>
     * <pre>
     *  &lt;upa>
     *      &lt;persistenceGroup>
     *          &lt;persistenceUnit>
     *              &lt;connexion>
     *                  &lt;persistenceNameStrategy persistenceName="" prefix=""  suffix="" escape="">
     *                      &lt;name value="" prefix="" suffix=""/>
     *                  &lt;/persistenceNameStrategy>
     *              &lt;/connexion>
     *          &lt;/persistenceUnit>
     *      &lt;/persistenceGroup>
     *  &lt;/upa>
     * </pre>
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/17/12 3:14 PM
     */
    public interface PersistenceNameStrategy {

         void Init(Net.Vpc.Upa.Persistence.PersistenceStore persistenceStore, Net.Vpc.Upa.Persistence.PersistenceNameConfig model, Net.Vpc.Upa.Properties properties);

         void Close();

        /**
             * @param source may be as String or an UPAObject
             * @param spec a valid string from PersistenceNameStrategyNames, or an
             * implementor custom spec Id
             * @return a valid SQL Identifier
             * @throws UPAException
             */
         string GetPersistenceName(object source, Net.Vpc.Upa.Persistence.PersistenceNameType spec) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;
    }
}
