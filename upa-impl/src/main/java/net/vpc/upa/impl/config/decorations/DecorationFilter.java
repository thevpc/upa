/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.config.decorations;

import net.vpc.upa.FlagSet;
import net.vpc.upa.config.DecorationTarget;

/**
 *
 * @author vpc
 */
public interface DecorationFilter {

    boolean acceptTypeDecoration(String name, String targetType, Object value);

    /**
     * when true acceptMethodDecoration and acceptFieldDecoration will not be
     * invoked if acceptTypeDecoration returns false
     *
     * @return
     */
    FlagSet<DecorationTarget> getDecorationTargets();

    boolean acceptMethodDecoration(String name, String targetMethod, String targetType, Object value);

    boolean acceptFieldDecoration(String name, String targetField, String targetType, Object value);
}
