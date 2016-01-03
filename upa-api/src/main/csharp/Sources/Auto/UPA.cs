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



namespace Net.Vpc.Upa
{


    /**
     * UPA (Unstructured Persistence API) is a simple yet powerful ORM aiming to
     * replace JPA. This class is the Entry Point for using UPA.
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/9/12 12:42 PM
     */
    public sealed class UPA {

        public const string UNDEFINED_STRING = "<<Undefined>>";

        public const string CONNECTION_STRING = "upa.connection";

        public const string ROOT_CONNECTION_STRING = "upa.root-connection";

        internal static bool contextProviderCreated = false;

        private UPA() {
        }

        /**
             * Current PersistenceGroup of the current context. Equivalent to
             * <pre>
             *     UPA.getContext().getPersistenceGroup()
             * </pre>
             *
             * @return current PersistenceGroup of the current context
             * @throws UPAException
             */
        public static Net.Vpc.Upa.PersistenceGroup GetPersistenceGroup() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetContext().GetPersistenceGroup();
        }

        /**
             * Current PersistenceUnit of the current PersistenceGroup of the current
             * context. Equivalent to
             * <pre>
             *     UPA.getContext().getPersistenceGroup().getPersistenceUnit()
             * </pre>
             *
             * @return Current PersistenceUnit of teh current PersistenceGroup of the
             * current context
             * @throws UPAException
             */
        public static Net.Vpc.Upa.PersistenceUnit GetPersistenceUnit() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetContext().GetPersistenceGroup().GetPersistenceUnit();
        }

        /**
             * PersistenceUnit named {@code name} in the current PersistenceGroup of the
             * current context. Equivalent to
             * <pre>
             *     UPA.getContext().getPersistenceGroup().getPersistenceUnit(name)
             * </pre>
             *
             * @param name PersistenceUnit name
             * @return PersistenceUnit named {@code name} in the current
             * PersistenceGroup of the current context
             * @throws UPAException
             */
        public static Net.Vpc.Upa.PersistenceUnit GetPersistenceUnit(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetContext().GetPersistenceGroup().GetPersistenceUnit(name);
        }

        /**
             * PersistenceUnit named {@code persistenceUnit} in the PersistenceGroup
             * named {@code persistenceGroup} of the current context. Equivalent to
             * <pre>
             *     UPA.getContext().getPersistenceGroup(persistenceGroup).getPersistenceUnit(persistenceUnit)
             * </pre>
             *
             * @param persistenceGroup PersistenceGroup name. Should not be null
             * @param persistenceUnit PersistenceUnit name. Should not be null
             * @return PersistenceUnit named {@code persistenceUnit} in the current
             * PersistenceGroup of the current context
             * @throws UPAException
             */
        public static Net.Vpc.Upa.PersistenceUnit GetPersistenceUnit(string persistenceGroup, string persistenceUnit) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetContext().GetPersistenceGroup(persistenceGroup).GetPersistenceUnit(persistenceUnit);
        }

        public static  T MakeSessionAware<T>(T instance) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return MakeSessionAware<T>(instance, (Net.Vpc.Upa.MethodFilter) null);
        }

        public static  T MakeSessionAware<T>(T instance, System.Type sessionAwareMethodAnnotation) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetContext().MakeSessionAware<T>(instance, sessionAwareMethodAnnotation);
        }

        public static  T MakeSessionAware<T>(T instance, Net.Vpc.Upa.MethodFilter methodFilter) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetContext().MakeSessionAware<T>(instance, methodFilter);
        }

        /**
             * Thread Safe retrieval of UPAContext
             *
             * @return current UPAContext
             */
        public static Net.Vpc.Upa.UPAContext GetContext() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.UPAContextProvider contextProvider = null;
            Net.Vpc.Upa.UPAContext context = contextProvider.GetContext();
            //Double Checking Lock will/should work here because we are not about to instantiate the object,
            //this is the responsibility of the contextProvider
            if (context == null) {
                lock (typeof(Net.Vpc.Upa.UPAContext)) {
                    context = contextProvider.GetContext();
                    if (context == null) {
                        Net.Vpc.Upa.ObjectFactory bootstrapFactory = GetBootstrapFactory();
                        context = bootstrapFactory.CreateObject<Net.Vpc.Upa.UPAContext>(typeof(Net.Vpc.Upa.UPAContext));
                        context.Start(bootstrapFactory);
                        contextProvider.SetContext(context);
                    }
                }
            }
            return context;
        }

        public static Net.Vpc.Upa.ObjectFactory GetBootstrapFactory() {
            try {
                return Net.Vpc.Upa.BootstrapObjectFactoryLazyHolder.INSTANCE;
            } catch (System.Exception e) {
                if (e is Net.Vpc.Upa.Exceptions.UPAException) {
                    throw (Net.Vpc.Upa.Exceptions.UPAException) e;
                }
                throw new Net.Vpc.Upa.Exceptions.UPAException(e, new Net.Vpc.Upa.Types.I18NString("UnableToLoadBootstrapFactory"));
            }
        }

        public static void Close() {
            if (contextProviderCreated) {
                Net.Vpc.Upa.UPAContext context = Net.Vpc.Upa.UPAContextProviderLazyHolder.INSTANCE.GetContext();
                if (context != null) {
                    context.Close();
                }
            }
        }
    }
}
