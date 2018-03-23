package net.vpc.upa.config;

import java.lang.annotation.ElementType;
import java.lang.annotation.Retention;
import java.lang.annotation.RetentionPolicy;
import java.lang.annotation.Target;

/**
 * Created by vpc on 7/25/15.
 */
@Target(value = ElementType.METHOD)
@Retention(value = RetentionPolicy.RUNTIME)
public @interface OnUpdateFormula {
    String name() default "";

    boolean trackSystemObjects() default false;

    ItemConfig config() default @ItemConfig();
}
