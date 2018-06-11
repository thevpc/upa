package net.vpc.upa.persistence;

import net.vpc.upa.config.PersistenceNameType;

/**
 * A PersistenceNameTransformer is a simple way to customize final names in the database.
 * This is handy for obfuscating database for instance by transforming all names with
 * non significative ones.
 */
public interface PersistenceNameTransformer {
    String transformName(String persistenceName, Object object, PersistenceNameType spec);

    /**
     * called once to initialize the transformer at the store startup or
     * at the transformer binding to the persistence store
     * @param persistenceStore current store
     */
    void start(PersistenceStore persistenceStore);

    /**
     * called once to free the transformer at the store closing
     */
    void close();
}
