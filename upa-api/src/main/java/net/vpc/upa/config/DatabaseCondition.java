package net.vpc.upa.config;

import net.vpc.upa.persistence.DatabaseProduct;

import java.lang.annotation.Retention;
import java.lang.annotation.RetentionPolicy;

@Retention(value = RetentionPolicy.RUNTIME)
public @interface DatabaseCondition {
    /**
     * DatabaseProduct filter. This naming is applied only if
     * the dbtype matches this value.
     *
     * @return dbtype
     */
    DatabaseProduct databaseProduct() default DatabaseProduct.UNDEFINED;

    String databaseVersion() default "";

    String strategyName() default "";
}
