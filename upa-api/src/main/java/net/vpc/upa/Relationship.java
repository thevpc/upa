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
package net.vpc.upa;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.extensions.HierarchyExtension;
import net.vpc.upa.types.DataType;

import java.util.Map;

public interface Relationship extends UPAObject {

    void commitModelChanged() throws UPAException;

    void setRelationshipType(RelationshipType dataType) throws UPAException;

    void setDataType(DataType dataType) throws UPAException;

    void setNullable(boolean nullable) throws UPAException;

    RelationshipType getRelationshipType() throws UPAException;

    int size() throws UPAException;

    DataType getDataType() throws UPAException;

    Map<String, String> getSourceToTargetFieldNamesMap(boolean absolute) throws UPAException;

    Map<String, String> getTargetToSourceFieldNamesMap(boolean absolute) throws UPAException;

    Map<String, String> getSourceToTargetFieldsMap() throws UPAException;

    Map<String, String> getTargetToSourceFieldsMap() throws UPAException;

    Expression getTargetCondition(Expression sourceCondition, String sourceAlias, String targetAlias) throws UPAException;

    Expression getSourceCondition(Expression targetCondition, String sourceAlias, String targetAlias) throws UPAException;

    Expression getFilter() throws UPAException;

    void setFilter(Expression filter) throws UPAException;

    boolean isTransient() throws UPAException;

    Entity getTargetEntity() throws UPAException;

    Entity getSourceEntity() throws UPAException;

    RelationshipRole getTargetRole() throws UPAException;

    RelationshipRole getSourceRole() throws UPAException;

    boolean isFollowLinks();

    boolean isAskForConfirm();

    Key extractKey(Document sourceDocument);

    Object extractId(Document sourceDocument);

    Object extractIdByEntityField(Document sourceDocument);

    Object extractIdByForeignFields(Document sourceDocument);

    HierarchyExtension getHierarchyExtension();

    void setHierarchyExtension(HierarchyExtension extension);

    Expression createTargetListExpression(Object currentInstance, String alias);

    RelationshipInfo getInfo();
}
