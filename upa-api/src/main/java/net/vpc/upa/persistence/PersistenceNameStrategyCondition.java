package net.vpc.upa.persistence;

import net.vpc.upa.PersistenceNameRule;

public interface PersistenceNameStrategyCondition {
    boolean accept(DatabaseProduct databaseProduct, String databaseVersion, String strategyName);
}
