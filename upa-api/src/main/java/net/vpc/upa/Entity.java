/**
 * ==================================================================== UPA
 * (Unstructured Persistence API) Yet another ORM Framework
 * ++++++++++++++++++++++++++++++++++ Unstructured Persistence API, referred to
 * as UPA, is a genuine effort to raise programming language frameworks managing
 * relational data in applications using Java Platform, Standard Edition and
 * Java Platform, Enterprise Edition and Dot Net Framework equally to the next
 * level of handling ORM for mutable data structures. UPA is intended to provide
 * a solid reflection mechanisms to the mapped data structures while affording
 * to make changes at runtime of those data structures. Besides, UPA has learned
 * considerably of the leading ORM (JPA, Hibernate/NHibernate, MyBatis and
 * Entity Framework to name a few) failures to satisfy very common even known to
 * be trivial requirement in enterprise applications.
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

import net.vpc.upa.callbacks.DefinitionListener;
import net.vpc.upa.callbacks.EntityInterceptor;
import net.vpc.upa.callbacks.Trigger;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.EntityStatement;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.Order;
import net.vpc.upa.extensions.EntityExtensionDefinition;
import net.vpc.upa.filters.FieldFilter;
import net.vpc.upa.persistence.EntityExecutionContext;
import net.vpc.upa.persistence.EntityExtension;
import net.vpc.upa.persistence.EntityOperationManager;
import net.vpc.upa.persistence.PersistenceStore;
import net.vpc.upa.types.DataType;

import java.util.List;
import java.util.Set;

public interface Entity extends /*Comparable<Entity>,*/ PersistenceUnitPart {

    public void setEntitySecurityManager(EntitySecurityManager securityManager) throws UPAException;

    public EntitySecurityManager getEntitySecurityManager() throws UPAException;

    public FlagSet<EntityModifier> getUserModifiers() throws UPAException;

    public void setUserModifiers(FlagSet<EntityModifier> modifiers) throws UPAException;

    public FlagSet<EntityModifier> getUserExcludeModifiers() throws UPAException;

    public void setUserExcludeModifiers(FlagSet<EntityModifier> modifiers) throws UPAException;

    public FlagSet<EntityModifier> getModifiers() throws UPAException;

    public boolean exists() throws UPAException;

    public Entity getParentEntity() throws UPAException;

    public EntityDescriptor getEntityDescriptor() throws UPAException;

    public Relationship getCompositionRelation() throws UPAException;

    public List<Relationship> getRelationships() throws UPAException;

    public String getParentSecurityAction() throws UPAException;

    public void setParentSecurityAction(String parentSecurityAction) throws UPAException;

    public Index addIndex(String name, boolean unique, String... fields) throws UPAException;

    public List<Index> getIndexes(Boolean unique) throws UPAException;

    public void removePart(int index) throws UPAException;

    public void movePart(int index, int newIndex) throws UPAException;

    public void movePart(String partName, int newIndex) throws UPAException;

    public List<EntityPart> getParts() throws UPAException;

    public int indexOfField(String field) throws UPAException;

    public int indexOfPart(EntityPart part) throws UPAException;

    public int indexOfPart(String partName) throws UPAException;

    public int indexOfPart(String partName, boolean countSections,
            boolean countCompoundFields, boolean countFieldsInCompoundFields,
            boolean countFieldsInSections) throws UPAException;

    public List<Section> getSections() throws UPAException;

    public Section getSection(String sectionPath) throws UPAException;

    public Section findSection(String path) throws UPAException;

    public Section getSection(String path, MissingStrategy missingStrategy) throws UPAException;

    public Section addSection(String name, String parentPath) throws UPAException;

    public Section addSection(String name, String parentPath, int index) throws UPAException;

    public Section addSection(String name, int index) throws UPAException;

    public Section addSection(String name) throws UPAException;

    public Class getEntityType() throws UPAException;

    public Class getIdType() throws UPAException;

    public boolean needsView() throws UPAException;

    public DataType getDataType() throws UPAException;

    public void setDataType(DataType newDataType) throws UPAException;

    public boolean isDependentOnEntity(String entityName);

    public Set<String> getDependencyEntities() throws UPAException;

    //    public void addSecuritySupport() throws UPAException;
//    public String getPersistenceName();
//
//    public void setPersistenceName(String persistenceName);
//    public Field addField(Field field, String sectionPath) throws UPAException;
//    public Field addField(Field field, String sectionPath, int index) throws UPAException;
    public Field addField(FieldDescriptor fieldDescriptor) throws UPAException;

    public Field addField(String name, String sectionPath, FlagSet<UserFieldModifier> modifiers, Object defaultValue, DataType type) throws UPAException;

    public Field addField(String name, String sectionPath, FlagSet<UserFieldModifier> modifiers, FlagSet<UserFieldModifier> excludeModifiers, Object defaultValue, DataType type, int index) throws UPAException;

    public Field getMainField() throws UPAException;

    public String getMainFieldValue(Object o) throws UPAException;

    public EntityNavigator getNavigator() throws UPAException;

    public void setNavigator(EntityNavigator newNavigator);

    // ------------------------------------------------------------------------------
    public int getFieldsCount() throws UPAException;

    public boolean containsField(String key) throws UPAException;

    public List<DynamicField> getDynamicFields() throws UPAException;

    public Field getField(int position) throws UPAException;

    public Field getField(String fieldName) throws UPAException;

    public Field findField(String fieldName) throws UPAException;

    public List<Field> getPrimaryFields() throws UPAException;

    public List<String> getFieldNames(FieldFilter fieldFilter) throws UPAException;

    //    public int indexOfField(String key) throws UPAException;
    public Object cloneRecord(Object oldId, Object newId) throws UPAException;

    public Object rename(Object oldId, Object newId) throws UPAException;

    public Object getNextId(Object id) throws UPAException;

    public Object getFirstId() throws UPAException;

    public Object getLastId() throws UPAException;

    public Object getPreviousId(Object id) throws UPAException;

    public boolean hasNext(Object id) throws UPAException;

    public boolean hasPrevious(Object id) throws UPAException;

    public boolean isEmpty() throws UPAException;

    public long getEntityCount() throws UPAException;

    public long getEntityCount(Expression booleanExpression) throws UPAException;

    public <K> K nextId() throws UPAException;

    public void persist(Object objectOrRecord) throws UPAException;

    public boolean save(Object objectOrRecord) throws UPAException;

    public void clear() throws UPAException;

    public Expression getUnicityExpressionForPersist(Object entity) throws UPAException;

    public RemoveTrace remove(Object entity) throws UPAException;

    public RemoveTrace remove(RemoveOptions options) throws UPAException;

    public Field[] toFieldArray(String[] s) throws UPAException;

    public boolean contains(Object id) throws UPAException;

    public void update(Object objectOrRecord) throws UPAException;

    public void merge(Object objectOrRecord) throws UPAException;

    public void updatePartial(Object objectOrRecord) throws UPAException;

    public void updatePartial(Object objectOrRecord, Object id) throws UPAException;

    public void updateRecord(Record record, Key key) throws UPAException;

    public int updateRecords(Record record, Expression condition) throws UPAException;

    public void updateFormulas(FieldFilter filter, Expression expr) throws UPAException;

    public void updateFormulasById(FieldFilter filter, Object key) throws UPAException;

    public void updateFormulas() throws UPAException;

    public void updateFormulasById(Object id) throws UPAException;

    public void updateFormulas(Expression condition) throws UPAException;

    public Order getUpdateFormulasOrder();

    public String getIdName(Object id) throws UPAException;

    public List<Field> getValidFields(String... fieldNames) throws UPAException;

    public List<Field> getFields(String... fieldNames) throws UPAException;

    public List<Field> getFields(FieldFilter filter) throws UPAException;

    public Order getArchivingOrder();

    public Field getLeadingPrimaryField() throws UPAException;

    public List<String> getOrderedFields(String[] fields) throws UPAException;

    public Expression simplifyExpression(Expression e) throws UPAException;

    public String getShortName() throws UPAException;

    public void setShortName(String shortName) throws UPAException;

    public String getShortNameOrName() throws UPAException;

    public Order getListOrder() throws UPAException;

    public void setListOrder(Order listOrder) throws UPAException;

    public void setArchivingOrder(Order archivingOrder) throws UPAException;

    public List<PrimitiveField> getPrimitiveFields(FieldFilter fieldFilter) throws UPAException;

    public PrimitiveField getPrimitiveField(String fieldName) throws UPAException;

    public PrimitiveField findPrimitiveField(String fieldName) throws UPAException;

    public <T extends EntityPart> List<PrimitiveField> toPrimitiveFields(List<T> parts) throws UPAException;

    public List<Field> getFields(List<EntityPart> parts) throws UPAException;

    public List<PrimitiveField> getPrimitiveFields(String... fieldNames) throws UPAException;

    public EntityBuilder getBuilder() throws UPAException;

    public QueryBuilder createQueryBuilder() throws UPAException;

    public Query createQuery(EntityStatement query) throws UPAException;

    public Query createQuery(String query) throws UPAException;

    public List<Trigger> getTriggers() throws UPAException;

    /**
     * Triggers with VM support (having listener!=null)
     *
     * @return
     * @throws UPAException
     */
    public List<Trigger> getSoftTriggers() throws UPAException;

    public void addExtensionDefinition(Class extensionType, EntityExtensionDefinition extensionObject) throws UPAException;

    public void removeExtensionDefinition(Class extensionType, EntityExtensionDefinition extensionObject);

    public List<EntityExtensionDefinition> getExtensionDefinitions();

    public <S extends EntityExtensionDefinition> List<S> getExtensionDefinitions(Class<S> type);

    public List<EntityExtension> getExtensions();

    public <S extends EntityExtension> List<S> getExtensions(Class<S> type);

    public <S extends EntityExtension> S getExtension(Class<S> type) throws UPAException;

    public EntityOperationManager getEntityOperationManager();

    public EntityShield getShield();

    public void setShield(EntityShield shield) throws UPAException;

    public Expression childToParentExpression(Record child) throws UPAException;

    public Expression childToParentExpression(Expression childExpression) throws UPAException;

    public Expression parentToChildExpression(Expression parentExpression) throws UPAException;

    public Key createKey(Object... keyValues) throws UPAException;

    public Object createId(Object... keyValues) throws UPAException;

    public Record createRecord() throws UPAException;

    public <R> R createObject() throws UPAException;

    /**
     * adds anonymous trigger
     *
     * @param trigger
     * @return
     * @throws UPAException
     */
    public Trigger addTrigger(EntityInterceptor trigger) throws UPAException;

    public Trigger addTrigger(String name, EntityInterceptor trigger) throws UPAException;

    public void removeTrigger(String triggerName) throws UPAException;

    //    public void addEntityListener(EntityListener listener) throws UPAException;
//
//    public void removeEntityListener(EntityListener listener) throws UPAException;
    void addDefinitionListener(DefinitionListener definitionListener) throws UPAException;

    void removeDefinitionListener(DefinitionListener definitionListener) throws UPAException;

    //////////////////////////////////////////////////////////
    //
    //    CORE
    //
    //////////////////////////////////////////////////////////
    public int updateCore(Record updates, Expression condition, EntityExecutionContext executionContext) throws UPAException;

    public void persistCore(Record values, EntityExecutionContext executionContext) throws UPAException;

    public int removeCore(Expression condition, boolean recurse, RemoveTrace deleteInfo, EntityExecutionContext executionContext) throws UPAException;

    public int clearCore(EntityExecutionContext executionContext) throws UPAException;

    public int initializeCore(EntityExecutionContext executionContext) throws UPAException;

    public void updateFormulasCore(FieldFilter filter, Expression expr, EntityExecutionContext context) throws UPAException;

    public Object compile(Expression expression) throws UPAException;

    public void addFilter(String name, String expression) throws UPAException;

    public void addFilter(String name, Expression expression) throws UPAException;

    public Expression getFilter(String name) throws UPAException;

    public void removeFilter(String name) throws UPAException;

    public Set<String> getFilterNames() throws UPAException;

    public boolean isSystem() throws UPAException;

    // Framework Friend Methods
    public void setModifiers(FlagSet<EntityModifier> modifiers) throws UPAException;

    public void initialize() throws UPAException;

    public void commitModelChanges() throws UPAException;

    public void commitStructureModification(PersistenceStore persistenceUnitManager) throws UPAException;

    public void addDependencyOnEntity(String entityName);

    //    /**
//     * called by PersistenceUnit
//     */
//    void setCompositionRelationship(Relationship compositionRelation) throws UPAException;
    public <T> T findById(Object id) throws UPAException;

    public <T> T findByMainField(Object mainFieldValue) throws UPAException;

    public <T> T findByField(String fieldName, Object mainFieldValue) throws UPAException;

    public <T> List<T> findAll() throws UPAException;

    public List<Record> findAllRecords() throws UPAException;

}
