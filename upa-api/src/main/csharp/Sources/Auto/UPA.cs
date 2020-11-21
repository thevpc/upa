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



using System.Linq;
namespace Net.TheVpc.Upa
{


    /**
     * UPA (Unstructured Persistence API) is a simple yet powerful ORM aiming to
     * replace JPA. This class is the Entry Point for using UPA.
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/9/12 12:42 PM
     */
    public sealed class UPA {

        /**
             * string to use if string value is undefined.
             */
        public const string UNDEFINED_STRING = "<<Undefined>>";

        /**
             * Connection string parameter name
             */
        public const string CONNECTION_STRING = "upa.connection";

        /**
             * Root connection string parameter name
             */
        public const string ROOT_CONNECTION_STRING = "upa.root-connection";

        protected internal static readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.TheVpc.Upa.UPA)).FullName);

        private static readonly Net.TheVpc.Upa.UPABootstrap BOOTSTRAP = new Net.TheVpc.Upa.UPABootstrap();

        private const int CONTEXT_NOT_INITIALIZED = 0;

        private const int CONTEXT_INITIALIZING = 1;

        private const int CONTEXT_INITIALIZED = 2;

        private static int bootstrapStatus = CONTEXT_NOT_INITIALIZED;

        private static readonly System.Collections.Generic.IList<Net.TheVpc.Upa.Persistence.UPAContextConfig> configInstances = new System.Collections.Generic.List<Net.TheVpc.Upa.Persistence.UPAContextConfig>();

        private static readonly System.Collections.Generic.IList<System.Type> configClasses = new System.Collections.Generic.List<System.Type>();

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
        public static Net.TheVpc.Upa.PersistenceGroup GetPersistenceGroup() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetContext().GetPersistenceGroup();
        }

        /**
             * PersistenceGroup by name {@code name}. Equivalent to
             * <pre>
             *     UPA.getContext().getPersistenceGroup(name)
             * </pre>
             *
             * @return current PersistenceGroup of the current context
             * @throws UPAException
             */
        public static Net.TheVpc.Upa.PersistenceGroup GetPersistenceGroup(string name) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetContext().GetPersistenceGroup(name);
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
        public static Net.TheVpc.Upa.PersistenceUnit GetPersistenceUnit() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
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
        public static Net.TheVpc.Upa.PersistenceUnit GetPersistenceUnit(string name) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
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
        public static Net.TheVpc.Upa.PersistenceUnit GetPersistenceUnit(string persistenceGroup, string persistenceUnit) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetContext().GetPersistenceGroup(persistenceGroup).GetPersistenceUnit(persistenceUnit);
        }

        public static  T MakeSessionAware<T>(T instance) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return MakeSessionAware<>(instance, (Net.TheVpc.Upa.MethodFilter) null);
        }

        public static  T MakeSessionAware<T>(T instance, System.Type sessionAwareMethodAnnotation) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetContext().MakeSessionAware<>(instance, sessionAwareMethodAnnotation);
        }

        public static  T MakeSessionAware<T>(T instance, Net.TheVpc.Upa.MethodFilter methodFilter) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetContext().MakeSessionAware<>(instance, methodFilter);
        }

        /**
             * Thread Safe retrieval of UPAContext
             *
             * @return current UPAContext
             */
        public static Net.TheVpc.Upa.UPAContext GetContext() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (bootstrapStatus == CONTEXT_INITIALIZING) {
                throw new Net.TheVpc.Upa.Exceptions.UPAException("UPAAlreadyInitializing");
            }
            Net.TheVpc.Upa.UPAContextProvider contextProvider = null;
            BOOTSTRAP.SetContextInitialized();
            Net.TheVpc.Upa.UPAContext context = contextProvider.GetContext();
            //Double Checking Lock will/should work here because we are not about to instantiate the object,
            //this is the responsibility of the contextProvider
            if (context == null) {
                lock (BOOTSTRAP) {
                    context = contextProvider.GetContext();
                    if (context == null) {
                        bootstrapStatus = CONTEXT_INITIALIZING;
                        long start = System.DateTime.Now.Ticks;
                        Net.TheVpc.Upa.ObjectFactory bootstrapFactory = BOOTSTRAP.GetFactory();
                        context = bootstrapFactory.CreateObject<>(typeof(Net.TheVpc.Upa.UPAContext));
                        context.Start(bootstrapFactory, configInstances.ToArray(), configClasses.ToArray());
                        contextProvider.SetContext(context);
                        long end = System.DateTime.Now.Ticks;
                        log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.TheVpc.Upa.FwkConvertUtils.LogMessageExceptionFormatter("UPA Context Loaded in {0} ms",null,end - start));
                        bootstrapStatus = CONTEXT_INITIALIZED;
                    }
                }
            } else {
                if (bootstrapStatus != CONTEXT_INITIALIZED) {
                    throw new Net.TheVpc.Upa.Exceptions.BootstrapException("UPAContextStatusInvalid");
                }
            }
            return context;
        }

        public static Net.TheVpc.Upa.ObjectFactory GetBootstrapFactory() {
            return BOOTSTRAP.GetFactory();
        }

        public static Net.TheVpc.Upa.UPABootstrap GetBootstrap() {
            return BOOTSTRAP;
        }

        public static void Close() {
            if (BOOTSTRAP.IsContextInitialized()) {
                Net.TheVpc.Upa.UPAContext context = Net.TheVpc.Upa.UPAContextProviderLazyHolder.INSTANCE.GetContext();
                if (context != null) {
                    context.Close();
                }
            }
        }

        public static void Configure(Net.TheVpc.Upa.Persistence.UPAContextConfig config) {
            if (bootstrapStatus != CONTEXT_NOT_INITIALIZED) {
                throw new Net.TheVpc.Upa.Exceptions.UPAException("UPAAlreadyInitializing");
            }
            if (config != null) {
                configInstances.Add(config);
            }
        }

        public static void Configure(System.Type config) {
            if (bootstrapStatus != CONTEXT_NOT_INITIALIZED) {
                throw new Net.TheVpc.Upa.Exceptions.UPAException("UPAAlreadyInitializing");
            }
            if (config != null) {
                configClasses.Add(config);
            }
        }
    }
}
