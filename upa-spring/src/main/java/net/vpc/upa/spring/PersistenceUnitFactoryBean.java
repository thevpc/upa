package net.vpc.upa.spring;

import net.vpc.upa.*;
import net.vpc.upa.persistence.ConnectionConfig;
import net.vpc.upa.persistence.UPAContextConfig;
import org.springframework.beans.factory.DisposableBean;
import org.springframework.beans.factory.FactoryBean;
import org.springframework.beans.factory.InitializingBean;
import org.springframework.context.ApplicationContext;
import org.springframework.context.ApplicationContextAware;

public class PersistenceUnitFactoryBean implements FactoryBean<PersistenceUnit>, InitializingBean, DisposableBean,ApplicationContextAware {
    private UPAContextProvider upaContextProvider;
    private PersistenceUnitProvider persistenceUnitProvider;
    private PersistenceGroupProvider persistenceGroupProvider;
    private SessionContextProvider sessionContextProvider;
    private UPAContextConfig config;
    private ApplicationContext applicationContext;

    public ApplicationContext getApplicationContext() {
        return applicationContext;
    }

    @Override
    public void setApplicationContext(ApplicationContext applicationContext) {
        this.applicationContext = applicationContext;
    }

    public PersistenceUnitProvider getPersistenceUnitProvider() {
        return persistenceUnitProvider;
    }

    public void setPersistenceUnitProvider(PersistenceUnitProvider persistenceUnitProvider) {
        this.persistenceUnitProvider = persistenceUnitProvider;
    }

    public PersistenceGroupProvider getPersistenceGroupProvider() {
        return persistenceGroupProvider;
    }

    public void setPersistenceGroupProvider(PersistenceGroupProvider persistenceGroupProvider) {
        this.persistenceGroupProvider = persistenceGroupProvider;
    }

    @Override
    public PersistenceUnit getObject() {
        return UPA.getPersistenceGroup().getPersistenceUnit();
    }

    @Override
    public Class<?> getObjectType() {
        return PersistenceUnit.class;
    }

    @Override
    public boolean isSingleton() {
        return false;
    }

    public SessionContextProvider getSessionContextProvider() {
        return sessionContextProvider;
    }

    public void setSessionContextProvider(SessionContextProvider sessionContextProvider) {
        this.sessionContextProvider = sessionContextProvider;
    }

    public UPAContextProvider getUpaContextProvider() {
        return upaContextProvider;
    }

    public void setUpaContextProvider(UPAContextProvider upaContextProvider) {
        this.upaContextProvider = upaContextProvider;
    }

    @Override
    public void afterPropertiesSet() throws Exception {
        ObjectFactory bootstrapFactory = UPA.getBootstrapFactory();
        bootstrapFactory.register(PlatformObjectFactory.class, new SpringPlatformObjectFactory(getApplicationContext()));
        if (upaContextProvider != null) {
            bootstrapFactory.register(UPAContextProvider.class, upaContextProvider);
        }
        if (persistenceGroupProvider != null) {
            bootstrapFactory.register(PersistenceGroupProvider.class, persistenceGroupProvider);
        }
        if (persistenceUnitProvider != null) {
            bootstrapFactory.register(PersistenceUnitProvider.class, persistenceUnitProvider);
        }
        if (sessionContextProvider != null) {
            bootstrapFactory.register(SessionContextProvider.class, sessionContextProvider);
        }
        UPA.configure(config);
    }

    @Override
    public void destroy() throws Exception {
        UPA.getContext().close();
    }

    public UPAContextConfig getConfig() {
        return config;
    }

    public void setConfig(UPAContextConfig config) {
        this.config = config;
    }
}
