package net.thevpc.upa;

import net.thevpc.upa.bulk.*;
import net.thevpc.upa.config.UPAContextConfigAnnotationParser;
import net.thevpc.upa.exceptions.NoSuchUPAElementException;
import net.thevpc.upa.impl.*;
import net.thevpc.upa.impl.bulk.DefaultImportDataManager;
import net.thevpc.upa.impl.bulk.DefaultImportEntityFinder;
import net.thevpc.upa.impl.bulk.DefaultImportExportManager;
import net.thevpc.upa.impl.bulk.DefaultParseFormatManager;
import net.thevpc.upa.impl.bulk.text.DefaultTextCSVFormatter;
import net.thevpc.upa.impl.bulk.text.DefaultTextCSVParser;
import net.thevpc.upa.impl.bulk.text.DefaultTextFixedWidthFormatter;
import net.thevpc.upa.impl.bulk.text.DefaultTextFixedWidthParser;
import net.thevpc.upa.impl.bulk.xml.DefaultXmlFormatter;
import net.thevpc.upa.impl.bulk.xml.DefaultXmlParser;
import net.thevpc.upa.impl.config.DefaultUPAContext;
import net.thevpc.upa.impl.config.DefaultUPAContextConfigAnnotationParser;
import net.thevpc.upa.impl.context.*;
import net.thevpc.upa.impl.eval.DefaultQLEvaluator;
import net.thevpc.upa.impl.extension.*;
import net.thevpc.upa.impl.persistence.*;
import net.thevpc.upa.impl.persistence.specific.derby.DerbyPersistenceStore;
import net.thevpc.upa.impl.persistence.specific.interbase.InterBasePersistenceStore;
import net.thevpc.upa.impl.persistence.specific.mckoi.McKoiPersistenceStore;
import net.thevpc.upa.impl.persistence.specific.mssqlserver.MSSQLServerPersistenceStore;
import net.thevpc.upa.impl.persistence.specific.mysql.MySQLPersistenceStore;
import net.thevpc.upa.impl.persistence.specific.oracle.OraclePersistenceStore;
import net.thevpc.upa.impl.security.DefaultSecurityManager;
import net.thevpc.upa.impl.transform.DefaultDataTypeTransformFactory;
import net.thevpc.upa.impl.upql.DefaultQLExpressionParser;
import net.thevpc.upa.impl.util.ClassMap;
import net.thevpc.upa.impl.util.PlatformUtils;
import net.thevpc.upa.persistence.*;

import java.util.logging.Level;
import java.util.logging.Logger;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/11/12 9:21 PM
 */
public class RootObjectFactory extends AbstractObjectFactory {

    public static final Logger log = Logger.getLogger(RootObjectFactory.class.getName());
    private ObjectFactory parentFactory;
    private ClassMap<Class> map = new ClassMap<Class>();
    private PlatformObjectFactory platformObjectFactory;

    public RootObjectFactory() {
        register(PlatformObjectFactory.class, DefaultPlatformObjectFactory.class);
        register(UPAContext.class, DefaultUPAContext.class);
        register(UPAContextProvider.class, DefaultUPAContextProvider.class);
        register(ObjectFactory.class, DefaultTypedFactory.class);
        register(PersistenceUnitProvider.class, DefaultPersistenceUnitProvider.class);
        register(PersistenceGroupProvider.class, DefaultPersistenceGroupProvider.class);
        register(PersistenceGroup.class, DefaultPersistenceGroup.class);
        register(PersistenceUnit.class, DefaultPersistenceUnit.class);
        register(I18NStringStrategy.class, DefaultI18NStringStrategy.class);
        register(Key.class, DefaultKey.class);
        register(Document.class, DefaultDocument.class);
        register(SessionContextProvider.class, DefaultSessionContextProvider.class);
        register(EntityShield.class, DefaultEntityShield.class);
        register(DataTypeTransformFactory.class, DefaultDataTypeTransformFactory.class);
        register(Index.class, DefaultIndex.class);
        register(Entity.class, DefaultEntity.class);
        register(Package.class, DefaultPackage.class);
        register(Section.class, DefaultSection.class);
        register(UPASecurityManager.class, DefaultSecurityManager.class);
        register(TransactionManager.class, DefaultTransactionManager.class);
        register(Session.class, DefaultSession.class);
        register(HierarchyExtension.class, HierarchicalRelationshipSupport.class);
        register(UnionEntityExtension.class, DefaultUnionEntityExtension.class);
        register(SingletonExtension.class, DefaultSingletonExtension.class);
        register(ViewEntityExtension.class, DefaultViewEntityExtension.class);
        register(FilterEntityExtension.class, DefaultFilterEntityExtension.class);
        register(QLExpressionParser.class, DefaultQLExpressionParser.class);
        register(BeanAdapterFactory.class, DefaultBeanAdapterFactory.class);
        register(QLEvaluator.class, DefaultQLEvaluator.class);
        register(Properties.class, DefaultProperties.class);
        register(UPAContextConfigAnnotationParser.class, DefaultUPAContextConfigAnnotationParser.class);
        register(PersistenceStoreFactory.class, DefaultPersistenceStoreFactory.class);
        register(EntityExecutionContext.class, DefaultExecutionContext.class);
        register(EntityOperationManager.class, DefaultEntityOperationManager.class);
        register(TransactionManagerFactory.class, DefaultTransactionManagerFactory.class);
        register(PersistenceNameStrategy.class, DefaultPersistenceNameStrategy.class);


        addAlternative(PersistenceStore.class, MSSQLServerPersistenceStore.class);

        /**
         * @PortabilityHint(target = "C#", name = "todo")
         */
        addAlternative(PersistenceStore.class, OraclePersistenceStore.class);
        /**
         * @PortabilityHint(target = "C#", name = "todo")
         */
        addAlternative(PersistenceStore.class, MySQLPersistenceStore.class);

        /**
         * @PortabilityHint(target = "C#", name = "suppress")
         */
        addAlternative(PersistenceStore.class, DerbyPersistenceStore.class);
        /**
         * @PortabilityHint(target = "C#", name = "suppress")
         */
        addAlternative(PersistenceStore.class, McKoiPersistenceStore.class);
        /**
         * @PortabilityHint(target = "C#", name = "suppress")
         */
        addAlternative(PersistenceStore.class, InterBasePersistenceStore.class);

        
        /**
         * @PortabilityHint(target = "C#",name = "todo")
         */
        {
            register(TextFixedWidthParser.class, DefaultTextFixedWidthParser.class);
            register(TextCSVParser.class, DefaultTextCSVParser.class);
            register(XmlParser.class, DefaultXmlParser.class);
            register(TextCSVFormatter.class, DefaultTextCSVFormatter.class);
            register(TextFixedWidthFormatter.class, DefaultTextFixedWidthFormatter.class);
            register(XmlFormatter.class, DefaultXmlFormatter.class);
            register(ImportDataManager.class, DefaultImportDataManager.class);
            register(ParseFormatManager.class, DefaultParseFormatManager.class);
            register(ImportExportManager.class, DefaultImportExportManager.class);
            register(ImportEntityFinder.class, DefaultImportEntityFinder.class);
            register(ImportEntityMapper.class, DefaultImportEntityFinder.class);
        }


        register(DefaultEntityExtensionManager.class, DefaultEntityExtensionManager.class);
        /**
         * @PortabilityHint(target = "C#",name = "todo")
         */
        register(XmlFactory.class, DefaultXmlFactory.class);
        
    }

    public final void register(Class contract, Class impl) {
        map.put(contract, impl);
    }

    @Override
    public void setParentFactory(ObjectFactory factory) {
        this.parentFactory = factory;
    }

    @Override
    public <T> T createObject(Class<T> type, String name) {
        return createObject(type, name, null);
    }

    protected <T> T createObject(Class<T> type, String name, PlatformObjectFactory platformObjectFactory) {
        T s = (T) singletons.get(type.getName());
        if (s != null) {
            return s;
        }
        Class best = map.get(type);
        if (best == null || !type.isAssignableFrom(best)) {
            if (parentFactory != null) {
                return parentFactory.createObject(type, name);
            }
            if (PlatformUtils.isAbstract(type) || PlatformUtils.isInterface(type)) {
                throw new NoSuchUPAElementException("NoSuchObject", type.getSimpleName());
            }
            best = type;
        }
        if (platformObjectFactory != null) {
            return (T) platformObjectFactory.createObject(best, name);
        }
        try {
            return (T) createPlatformInstance(best, name);
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    @Override
    public <T> T createObject(String typeName, String name) {
        Class<T> c;
        try {
            c = PlatformUtils.forName(typeName);
        } catch (ClassNotFoundException ex) {
            log.log(Level.SEVERE, null, ex);
            throw new RuntimeException(typeName);
        }
        return (T) createObject(c, name);
    }

    @Override
    public int getContextSupportLevel() {
        return 0;
    }

    @Override
    public <T> T createObject(Class<T> type) {
        return createObject(type, null);
    }

    @Override
    public <T> T createObject(String typeName) {
        try {
            Class<T> c = (Class<T>) PlatformUtils.forName(typeName);
            return (T) createObject(c);
        } catch (ClassNotFoundException ex) {
            log.log(Level.SEVERE, null, ex);
            throw new RuntimeException(ex);
        }
    }

    protected Object createPlatformInstance(Class cls, String name) {
        if (platformObjectFactory == null) {
            if (cls.equals(PlatformObjectFactory.class) || cls.equals(DefaultPlatformObjectFactory.class)) {
                platformObjectFactory = DefaultPlatformObjectFactory.INSTANCE;
            } else {
                platformObjectFactory = createObject(PlatformObjectFactory.class, null, DefaultPlatformObjectFactory.INSTANCE);
            }
        }
        return platformObjectFactory.createObject(cls, name);
    }

}
