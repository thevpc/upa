package net.vpc.upa;

import net.vpc.upa.persistence.DatabaseProduct;

public interface PersistenceNameRule {
    DatabaseProduct getDatabaseProduct();

    String getDatabaseVersion();

    String getStrategyName();
}
