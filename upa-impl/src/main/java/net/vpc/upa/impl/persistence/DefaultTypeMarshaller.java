package net.vpc.upa.impl.persistence;

/**
 * Created with IntelliJ IDEA.
 * User: vpc
 * Date: 8/17/12
 * Time: 5:38 PM
 * To change this template use File | Settings | File Templates.
 */
public abstract class DefaultTypeMarshaller implements TypeMarshaller {
    private MarshallManager marshallManager;

    public void setMarshallManager(MarshallManager marshallManager) {
        this.marshallManager =marshallManager;
    }

    public MarshallManager getMarshallManager() {
        return marshallManager;
    }
}
