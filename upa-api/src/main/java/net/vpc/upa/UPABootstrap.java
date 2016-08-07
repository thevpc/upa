package net.vpc.upa;

import net.vpc.upa.exceptions.BootstrapException;
import net.vpc.upa.exceptions.UPAException;

import java.util.Map;

/**
 * Created by vpc on 8/6/16.
 */
public class UPABootstrap {
    private boolean contextProviderCreated = false;
    private Properties properties = new BootstrapProperties();

    UPABootstrap(){
        for (Map.Entry<Object, Object> ee : System.getProperties().entrySet()) {
            properties.setString((String) ee.getKey(),(String) ee.getValue());
        }
    }

    public boolean isContextInitialized() {
        return contextProviderCreated;
    }

    void setContextInitialized() {
        contextProviderCreated=true;
    }

    public ObjectFactory getFactory() {
        try {
            return BootstrapObjectFactoryLazyHolder.INSTANCE;
        } catch (Throwable e) {
            /**
             * @PortabilityHint(target = "C#",name = "suppress")
             */
            if (e instanceof java.lang.ExceptionInInitializerError) {
                java.lang.ExceptionInInitializerError ee = (java.lang.ExceptionInInitializerError) e;
                if (ee.getCause() instanceof UPAException) {
                    throw (UPAException) ee.getCause();
                }
                throw new BootstrapException("LoadBootstrapFactoryException",ee.getCause());
            }
            if (e instanceof UPAException) {
                throw (UPAException) e;
            }
            /**
             * @PortabilityHint(target = "C#",name = "suppress")
             */
            if (e instanceof RuntimeException) {
                throw (RuntimeException) e;
            }
            throw new BootstrapException("LoadBootstrapFactoryException",e);
        }
    }

    public Properties getProperties() {
        return properties;
    }
}
