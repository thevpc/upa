/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.tutorial.feature;

import net.vpc.upa.config.PersistenceName;
import net.vpc.upa.config.PersistenceNameStrategy;
import net.vpc.upa.config.PersistenceNameType;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@PersistenceNameStrategy(
        persistenceName = "{OBJECT_NAME}",
        names = {
            @PersistenceName(
                    persistenceNameType = PersistenceNameType.TABLE,
                    value = "T_{OBJECT_NAME}"
            ),
            @PersistenceName(
                    persistenceNameType = PersistenceNameType.FK_CONSTRAINT,
                    value = "FK_{OBJECT_NAME}"
            )
        }
)
public class NamingStrategyFeature {
}
