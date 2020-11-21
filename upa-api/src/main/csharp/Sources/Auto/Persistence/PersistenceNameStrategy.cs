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



namespace Net.TheVpc.Upa.Persistence
{


    /**
     * Hello Example of Annotation config
     * <pre>
     * &amp;@PersistenceUnit(
     *      persistenceNameStrategy = @PersistenceNameStrategy(
     *              persistenceNameFormat = "{OBJECT_NAME}",
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
     *                  &lt;persistenceNameStrategy persistenceNameFormat="" prefix=""  suffix="" escape="">
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

         void Init(Net.TheVpc.Upa.Persistence.PersistenceStore persistenceStore, Net.TheVpc.Upa.Persistence.PersistenceNameConfig model, Net.TheVpc.Upa.Properties properties);

         void Close();

        /**
             * @param source may be as String or an UPAObject
             * @param spec a valid string from PersistenceNameStrategyNames, or an
             * implementor custom spec Id
             * @return a valid SQL Identifier
             * @throws UPAException
             */
         string GetPersistenceName(object source, Net.TheVpc.Upa.Persistence.PersistenceNameType spec) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;
    }
}
