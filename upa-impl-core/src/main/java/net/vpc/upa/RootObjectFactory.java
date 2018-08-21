package net.vpc.upa;

import net.vpc.upa.extensions.HierarchyExtension;

import net.vpc.upa.bulk.*;
import net.vpc.upa.impl.*;
import net.vpc.upa.impl.bulk.text.DefaultTextFixedWidthFormatter;
import net.vpc.upa.impl.bulk.text.DefaultTextFixedWidthParser;
import net.vpc.upa.impl.bulk.xml.DefaultXmlFormatter;
import net.vpc.upa.impl.config.DefaultUPAContext;
import net.vpc.upa.impl.context.*;
import net.vpc.upa.impl.extension.*;
import net.vpc.upa.impl.persistence.DefaultEntityOperationManager;
import net.vpc.upa.impl.persistence.DefaultExecutionContext;
import net.vpc.upa.impl.persistence.DefaultPersistenceStoreFactory;
import net.vpc.upa.impl.persistence.DefaultPersistenceNameStrategy;
import net.vpc.upa.impl.security.DefaultSecurityManager;
import net.vpc.upa.impl.transaction.DefaultTransactionManager;
import net.vpc.upa.impl.transaction.DefaultTransactionManagerFactory;
import net.vpc.upa.impl.util.ClassMap;
import net.vpc.upa.impl.util.xml.DefaultXmlFactory;
import net.vpc.upa.impl.util.xml.XmlFactory;
import net.vpc.upa.persistence.*;

import java.util.logging.Level;
import java.util.logging.Logger;

import net.vpc.upa.config.UPAContextConfigAnnotationParser;
import net.vpc.upa.impl.bulk.DefaultImportEntityFinder;
import net.vpc.upa.impl.bulk.DefaultImportDataManager;
import net.vpc.upa.impl.bulk.DefaultImportExportManager;
import net.vpc.upa.impl.bulk.DefaultParseFormatManager;
import net.vpc.upa.impl.bulk.text.DefaultTextCSVFormatter;
import net.vpc.upa.impl.bulk.text.DefaultTextCSVParser;
import net.vpc.upa.impl.bulk.xml.DefaultXmlParser;
import net.vpc.upa.impl.config.DefaultUPAContextConfigAnnotationParser;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.impl.transform.DefaultDataTypeTransformFactory;
import net.vpc.upa.impl.eval.DefaultQLEvaluator;
import net.vpc.upa.impl.persistence.specific.derby.DerbyPersistenceStore;
import net.vpc.upa.impl.persistence.specific.interbase.InterBasePersistenceStore;
import net.vpc.upa.impl.persistence.specific.mckoi.McKoiPersistenceStore;
import net.vpc.upa.impl.persistence.specific.mssqlserver.MSSQLServerPersistenceStore;
import net.vpc.upa.impl.persistence.specific.mysql.MySQLPersistenceStore;
import net.vpc.upa.impl.persistence.specific.oracle.OraclePersistenceStore;
import net.vpc.upa.impl.upql.DefaultQLExpressionParser;
import net.vpc.upa.impl.util.DefaultBeanAdapterFactory;
import net.vpc.upa.types.DataTypeTransformFactory;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/11/12 9:21 PM
 */
public class RootObjectFactory extends AbstractObjectFactory {

    final Logger log = Logger.getLogger(RootObjectFactory.class.getName());
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
        register(PersistenceStoreFactory.class, DefaultPersistenceStoreFactory.class);
        register(SessionContextProvider.class, DefaultSessionContextProvider.class);
//        register(PropertiesConnectionProfileManager.class,DefaultPropertiesConnectionProfileManager.class);
        register(EntityExecutionContext.class, DefaultExecutionContext.class);
        register(EntityShield.class, DefaultEntityShield.class);
        register(DefaultEntityExtensionManager.class, DefaultEntityExtensionManager.class);
        register(EntityOperationManager.class, DefaultEntityOperationManager.class);
        register(DataTypeTransformFactory.class, DefaultDataTypeTransformFactory.class);
        register(Index.class, DefaultIndex.class);
        register(Entity.class, DefaultEntity.class);
        register(Package.class, DefaultPackage.class);
        register(Section.class, DefaultSection.class);
        register(UPASecurityManager.class, DefaultSecurityManager.class);
        register(TransactionManagerFactory.class, DefaultTransactionManagerFactory.class);
        register(TransactionManager.class, DefaultTransactionManager.class);
        register(Session.class, DefaultSession.class);
//        register(Modifiers.class, DefaultModifiers.class);
        register(PersistenceNameStrategy.class, DefaultPersistenceNameStrategy.class);
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

        /**
         * @PortabilityHint(target = "C#",name = "todo")
         */
        {
            register(XmlFactory.class, DefaultXmlFactory.class);
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
                throw new net.vpc.upa.exceptions.NoSuchUPAElementException("NoSuchObject", type.getSimpleName());
            }
            best = type;
        }
        if (best == null) {
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
