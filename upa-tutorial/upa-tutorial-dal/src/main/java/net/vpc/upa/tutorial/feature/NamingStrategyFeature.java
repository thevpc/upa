/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.tutorial.feature;

import net.vpc.upa.config.PersistenceNameFormat;
import net.vpc.upa.config.PersistenceNameStrategy;
import net.vpc.upa.config.PersistenceNameType;

/**
 * This is a simple class for defining naming strategies
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@PersistenceNameStrategy(
        //all names are capitalized
        persistenceName = "{OBJECT_NAME}",
        persistenceNameFormats = {
                //tables will start with 'T_' and will be capitalized
            @PersistenceNameFormat(
                    persistenceNameType = PersistenceNameType.TABLE,
                    value = "T_{OBJECT_NAME}"
            ),
                //foreign constraints will start with 'FK_' and will be capitalized
            @PersistenceNameFormat(
                    persistenceNameType = PersistenceNameType.FK_CONSTRAINT,
                    value = "FK_{OBJECT_NAME}"
            )
        }
)
public class NamingStrategyFeature {
}
