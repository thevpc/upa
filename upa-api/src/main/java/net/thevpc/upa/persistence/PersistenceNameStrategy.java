/**
 * ====================================================================
 * UPA (Unstructured Persistence API)
 * Yet another ORM Framework
 * ++++++++++++++++++++++++++++++++++
 * Unstructured Persistence API, referred to as UPA, is a genuine effort
 * to raise programming language frameworks managing relational data in
 * applications using Java Platform, Standard Edition and Java Platform,
 * Enterprise Edition and Dot Net Framework equally to the next level of
 * handling ORM for mutable data structures. UPA is intended to provide
 * a solid reflection mechanisms to the mapped data structures while
 * affording to make changes at runtime of those data structures.
 * Besides, UPA has learned considerably of the leading ORM
 * (JPA, Hibernate/NHibernate, MyBatis and Entity Framework to name a few)
 * failures to satisfy very common even known to be trivial requirement in
 * enterprise applications.
 * <p>
 * Copyright (C) 2014-2015 Taha BEN SALAH
 * <p>
 * This program is free software; you can redistribute it and/or modify it under
 * the terms of the GNU General Public License as published by the Free Software
 * Foundation; either version 2 of the License, or (at your option) any later
 * version.
 * <p>
 * This program is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
 * FOR A PARTICULAR PURPOSE. See the GNU General Public License for more
 * details.
 * <p>
 * You should have received a copy of the GNU General Public License along with
 * this program; if not, write to the Free Software Foundation, Inc., 51
 * Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
 * ====================================================================
 */
package net.thevpc.upa.persistence;

import net.thevpc.upa.*;
import net.thevpc.upa.config.PersistenceNameType;

import net.thevpc.upa.exceptions.UPAException;

/**
 * Hello Example of Annotation config
 * <pre>
 * &amp;@PersistenceUnit(
 *      persistenceNameStrategy = @PersistenceNameStrategy(
 *              persistenceName = "{OBJECT_NAME}",
 *              suffix = "_TBL",
 *              prefix = "T_",
 *              escape = "UPA_*",
 *              names = {@PersistenceName(
 *                      type = PersistenceNameType.INDEX,
 *                      prefix = "NDX_"
 *              )}
 *      )
 * )
 * </pre>
 * <pre>
 *  &lt;upa>
 *      &lt;persistenceGroup>
 *          &lt;persistenceUnit>
 *              &lt;connexion>
 *                  &lt;persistenceNameStrategy persistenceName="" prefix=""  suffix="" escape="">
 *                      &lt;name value="" prefix="" suffix=""/>
 *                  &lt;/persistenceNameStrategy>
 *              &lt;/connexion>
 *          &lt;/persistenceUnit>
 *      &lt;/persistenceGroup>
 *  &lt;/upa>
 * </pre>
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/17/12 3:14 PM
 */
public interface PersistenceNameStrategy {

    void init(PersistenceStore persistenceStore, Properties properties);

    void close();

    /**
     * @param source    may be as String or an UPAObject
     * @param spec      a valid string from PersistenceNameStrategyNames, or an
     *                  implementor custom spec Id
     * @param condition
     * @return a valid SQL Identifier
     */
    String getTablePersistenceName(Entity source, PersistenceNameType spec, PersistenceNameStrategyCondition condition) throws UPAException;

    /**
     * @param source    may be as String or an UPAObject
     * @param spec      a valid string from PersistenceNameStrategyNames, or an
     *                  implementor custom spec Id
     * @param condition
     * @return a valid SQL Identifier
     */
    String getTablePKPersistenceName(Entity source, PersistenceNameType spec, PersistenceNameStrategyCondition condition) throws UPAException;

    /**
     * @param source    may be as String or an UPAObject
     * @param spec      a valid string from PersistenceNameStrategyNames, or an
     *                  implementor custom spec Id
     * @param condition
     * @return a valid SQL Identifier
     */
    String getImplicitViewPersistenceName(Entity source, PersistenceNameType spec, PersistenceNameStrategyCondition condition) throws UPAException;

    /**
     * @param source    may be as String or an UPAObject
     * @param spec      a valid string from PersistenceNameStrategyNames, or an
     *                  implementor custom spec Id
     * @param condition
     * @return a valid SQL Identifier
     */
    String getIndexPersistenceName(Index source, PersistenceNameType spec, PersistenceNameStrategyCondition condition) throws UPAException;

    /**
     * @param source    may be as String or an UPAObject
     * @param spec      a valid string from PersistenceNameStrategyNames, or an
     *                  implementor custom spec Id
     * @param condition
     * @return a valid SQL Identifier
     */
    String getRelationshipPersistenceName(Relationship source, PersistenceNameType spec, PersistenceNameStrategyCondition condition) throws UPAException;

    /**
     * @param source    may be as String or an UPAObject
     * @param spec      a valid string from PersistenceNameStrategyNames, or an
     *                  implementor custom spec Id
     * @param condition
     * @return a valid SQL Identifier
     */
    String getIdentifierPersistenceName(String source, PersistenceNameType spec, PersistenceNameStrategyCondition condition) throws UPAException;

    /**
     * @param source    may be as String or an UPAObject
     * @param spec      a valid string from PersistenceNameStrategyNames, or an
     *                  implementor custom spec Id
     * @param condition
     * @return a valid SQL Identifier
     */
    String getFieldPersistenceName(Field source, PersistenceNameType spec, PersistenceNameStrategyCondition condition) throws UPAException;

    PersistenceNameRule[] getPersistenceNameRules();

    void addPersistenceNameRule(PersistenceNameRule rule);

    void removePersistenceNameRule(PersistenceNameRule rule);


    String getGlobalPersistenceNameFormat();

    void setGlobalPersistenceNameFormat(String globalPersistenceNameFormat);

    String getPersistenceNameEscape();

    void setPersistenceNameEscape(String persistenceNameEscape);

    void addNameFormat(PersistenceNameFormat nameFormat);

    void removeNameFormat(PersistenceNameFormat nameFormat);

    PersistenceNameFormat[] getNameFormats();

    String getLocalPersistenceNameFormat();

    void setLocalPersistenceNameFormat(String localPersistenceNameFormat);

    void setPersistenceNameTransformer(PersistenceNameTransformer obfuscator);

    PersistenceNameTransformer getPersistenceNameTransformer();
}
