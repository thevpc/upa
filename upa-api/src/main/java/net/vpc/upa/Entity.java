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

import java.util.*;

public interface Entity extends /*Comparable<Entity>,*/ PersistenceUnitPart {

    public void setEntitySecurityManager(EntitySecurityManager securityManager) ;

    public EntitySecurityManager getEntitySecurityManager() ;

    public FlagSet<EntityModifier> getUserModifiers() ;

    public void setUserModifiers(FlagSet<EntityModifier> modifiers) ;

    public FlagSet<EntityModifier> getUserExcludeModifiers() ;

    public void setUserExcludeModifiers(FlagSet<EntityModifier> modifiers) ;

    public FlagSet<EntityModifier> getModifiers() ;

    public boolean exists() ;

    public Entity getParentEntity() ;

    public EntityDescriptor getEntityDescriptor() ;

    public Relationship getCompositionRelation() ;

    public List<Relationship> getRelationships() ;

    public String getParentSecurityAction() ;

    public void setParentSecurityAction(String parentSecurityAction) ;

    public Index addIndex(String name, boolean unique, String... fields) ;

    public List<Index> getIndexes(Boolean unique) ;

    public void removePart(int index) ;

    public void movePart(int index, int newIndex) ;

    public void movePart(String partName, int newIndex) ;

    public List<EntityPart> getParts() ;

    public int indexOfField(String field) ;

    public int indexOfPart(EntityPart part) ;

    public int indexOfPart(String partName) ;

    public int indexOfPart(String partName, boolean countSections,
            boolean countCompoundFields, boolean countFieldsInCompoundFields,
            boolean countFieldsInSections) ;

    public List<Section> getSections() ;

    public Section getSection(String sectionPath) ;

    public Section findSection(String path) ;

    public Section getSection(String path, MissingStrategy missingStrategy) ;

    public Section addSection(String name, String parentPath) ;

    public Section addSection(String name, String parentPath, int index) ;

    public Section addSection(String name, int index) ;

    public Section addSection(String name) ;

    public Class getEntityType() ;

    public Class getIdType() ;

    public boolean needsView() ;

    public DataType getDataType() ;

    public void setDataType(DataType newDataType) ;

    public boolean isDependentOnEntity(String entityName);

    public Set<String> getDependencyEntities() ;

    //    public void addSecuritySupport() ;
//    public String getPersistenceName();
//
//    public void setPersistenceName(String persistenceName);
//    public Field addField(Field field, String sectionPath) ;
//    public Field addField(Field field, String sectionPath, int index) ;
    public Field addField(FieldDescriptor fieldDescriptor) ;

    public Field addField(String name, String sectionPath, FlagSet<UserFieldModifier> modifiers, Object defaultValue, DataType type) ;

    public Field addField(String name, String sectionPath, FlagSet<UserFieldModifier> modifiers, FlagSet<UserFieldModifier> excludeModifiers, Object defaultValue, DataType type, int index) ;

    public Field getMainField() ;

    public String getMainFieldValue(Object o) ;

    public EntityNavigator getNavigator() ;

    public void setNavigator(EntityNavigator newNavigator);

    // ------------------------------------------------------------------------------
    public int getFieldsCount() ;

    public boolean containsField(String key) ;

    public List<DynamicField> getDynamicFields() ;

    public Field getField(int position) ;

    public Field getField(String fieldName) ;

    public Field findField(String fieldName) ;

    public List<Field> getPrimaryFields() ;

    public List<String> getFieldNames(FieldFilter fieldFilter) ;

    //    public int indexOfField(String key) ;
    public Object cloneDocument(Object oldId, Object newId) ;

    public Object rename(Object oldId, Object newId) ;

    public Object rename(Object oldId, Object newId,Map<String,Object> hints);

    public Object getNextId(Object id) ;

    public Object getFirstId() ;

    public Object getLastId() ;

    public Object getPreviousId(Object id) ;

    public boolean hasNext(Object id) ;

    public boolean hasPrevious(Object id) ;

    public boolean isEmpty() ;

    public long getEntityCount() ;

    public long getEntityCount(Expression booleanExpression) ;

    public <K> K nextId() ;

    public void persist(Object objectOrDocument) ;

    public boolean save(Object objectOrDocument) ;

    public void persist(Object objectOrDocument,Map<String,Object> hints) ;

    public boolean save(Object objectOrDocument,Map<String,Object> hints) ;

    public void clear();

    public void clear(Map<String,Object> hints);

    public Expression getUnicityExpressionForPersist(Object entity) ;

    public RemoveTrace remove(Object entity) ;

    public RemoveTrace remove(RemoveOptions options) ;

    public Field[] toFieldArray(String[] s) ;

    public boolean contains(Object id) ;

    public UpdateQuery createUpdateQuery() ;

    public void update(Object objectOrDocument) ;

    public void merge(Object objectOrDocument) ;

//    public void update(Object objectOrDocument,Map<String,Object> hints) ;
//
//    public void merge(Object objectOrDocument,Map<String,Object> hints) ;
//
//    public void updatePartial(Object objectOrDocument,String... fields)  ;
//
//    public void updatePartial(Object entity, Set<String> fields, boolean ignoreUnspecified)  ;
//
//    public void updatePartial(Object objectOrDocument) ;
//
//    public void updatePartial(Object objectOrDocument, Object id) ;
//
//    public void updatePartial(Object objectOrDocument,Map<String,Object> hints,String... fields)  ;
//
//    public void updatePartial(Object entity, Set<String> fields, boolean ignoreUnspecified,Map<String,Object> hints)  ;
//
//    public void updatePartial(Object objectOrDocument,Map<String,Object> hints) ;
//
//    public void updatePartial(Object objectOrDocument, Object id,Map<String,Object> hints) ;
//
//    public void updateDocument(Document document, Key key) ;
//    public void updateDocument(Document document, Key key,Map<String,Object> hints) ;
//
//    public int updateDocuments(Document document, Expression condition,Map<String,Object> hints) ;
//
//    public int updateDocuments(Document document, Expression condition) ;

//    public void updateFormulas(FieldFilter filter, Expression expr) ;
//    public void updateFormulas(FieldFilter filter, Expression expr,Map<String,Object> hints) ;
//
//    public void updateFormulasById(FieldFilter filter, Object key) ;
//    public void updateFormulasById(FieldFilter filter, Object key,Map<String,Object> hints) ;

    public void updateFormulas() ;
//    public void updateFormulas(Map<String,Object> hints) ;

//    public void updateFormulasById(Object id) ;
//
//    public void updateFormulasById(Object id,Map<String,Object> hints) ;
//
//    public void updateFormulas(Expression condition) ;
//    public void updateFormulas(Expression condition,Map<String,Object> hints) ;

    public Order getUpdateFormulasOrder();

    public String getIdName(Object id) ;

    public List<Field> getValidFields(String... fieldNames) ;

    public List<Field> getFields() ;

    public List<Field> getFields(String... fieldNames) ;

    public List<Field> getFields(FieldFilter filter) ;

    public Order getArchivingOrder();

    public Field getLeadingPrimaryField() ;

    public List<String> getOrderedFields(String[] fields) ;

    public Expression toIdListExpression(Expression e) ;

    public String getShortName() ;

    public void setShortName(String shortName) ;

    public String getShortNameOrName() ;

    public Order getListOrder() ;

    public void setListOrder(Order listOrder) ;

    public void setArchivingOrder(Order archivingOrder) ;

    public List<PrimitiveField> getPrimitiveFields(FieldFilter fieldFilter) ;

    public PrimitiveField getPrimitiveField(String fieldName) ;

    public PrimitiveField findPrimitiveField(String fieldName) ;

    public <T extends EntityPart> List<PrimitiveField> toPrimitiveFields(List<T> parts) ;

    public List<Field> getFields(List<EntityPart> parts) ;

    public List<PrimitiveField> getPrimitiveFields(String... fieldNames) ;

    public EntityBuilder getBuilder() ;

    public QueryBuilder createQueryBuilder() ;

    public Query createQuery(EntityStatement query) ;

    public Query createQuery(String query) ;

    public List<Trigger> getTriggers() ;

    /**
     * Triggers with VM support (having listener!=null)
     *
     * @return
     * @
     */
    public List<Trigger> getSoftTriggers() ;

    public void addExtensionDefinition(Class extensionType, EntityExtensionDefinition extensionObject) ;

    public void removeExtensionDefinition(Class extensionType, EntityExtensionDefinition extensionObject);

    public List<EntityExtensionDefinition> getExtensionDefinitions();

    public <S extends EntityExtensionDefinition> List<S> getExtensionDefinitions(Class<S> type);

    public List<EntityExtension> getExtensions();

    public <S extends EntityExtension> List<S> getExtensions(Class<S> type);

    public <S extends EntityExtension> S getExtension(Class<S> type) ;

    public EntityOperationManager getEntityOperationManager();

    public EntityShield getShield();

    public void setShield(EntityShield shield) ;

    public Expression childToParentExpression(Document child) ;

    public Expression childToParentExpression(Expression childExpression) ;

    public Expression parentToChildExpression(Expression parentExpression) ;

    public Key createKey(Object... keyValues) ;

    public Object createId(Object... keyValues) ;

    public Document createDocument() ;

    public <R> R createObject() ;

    /**
     * adds anonymous trigger
     *
     * @param trigger
     * @return
     * @
     */
    public Trigger addTrigger(EntityInterceptor trigger) ;

    public Trigger addTrigger(String name, EntityInterceptor trigger) ;

    public void removeTrigger(String triggerName) ;

    //    public void addEntityListener(EntityListener listener) ;
//
//    public void removeEntityListener(EntityListener listener) ;
    void addDefinitionListener(DefinitionListener definitionListener) ;

    void removeDefinitionListener(DefinitionListener definitionListener) ;

    //////////////////////////////////////////////////////////
    //
    //    CORE
    //
    //////////////////////////////////////////////////////////
    public int updateCore(Document updates, Expression condition, EntityExecutionContext executionContext) ;

    public void persistCore(Document values, EntityExecutionContext executionContext) ;

    public int removeCore(Expression condition, boolean recurse, RemoveTrace deleteInfo, EntityExecutionContext executionContext) ;

    public int clearCore(EntityExecutionContext executionContext) ;

    public int initializeCore(EntityExecutionContext executionContext) ;

//    public long updateFormulasCore(FieldFilter filter, Expression expr, EntityExecutionContext context) ;

    public Object compile(Expression expression) ;

    public void addFilter(String name, String expression) ;

    public void addFilter(String name, Expression expression) ;

    public Expression getFilter(String name) ;

    public void removeFilter(String name) ;

    public Set<String> getFilterNames() ;

    public boolean isSystem() ;

    // Framework Friend Methods
    public void setModifiers(FlagSet<EntityModifier> modifiers) ;

    public void initialize() ;
    public void initialize(Map<String,Object> hints);

    public void commitModelChanges() ;

    public void commitStructureModification(PersistenceStore persistenceUnitManager) ;

    public void addDependencyOnEntity(String entityName);

    //    /**
//     * called by PersistenceUnit
//     */
//    void setCompositionRelationship(Relationship compositionRelation) ;
    public <T> T findById(Object id) ;

    public boolean existsById(Object id) ;

    public <T> T findByMainField(Object mainFieldValue) ;

    public <T> T findByField(String fieldName, Object mainFieldValue) ;

    public <T> List<T> findAll() ;
    
    public <T> List<T> findAllIds() ;

    public List<Document> findAllDocuments() ;

    public PlatformBeanType getPlatformBeanType();
}
