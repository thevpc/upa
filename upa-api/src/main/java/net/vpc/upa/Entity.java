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

import java.util.List;
import java.util.Map;
import java.util.Set;

public interface Entity extends /*Comparable<Entity>,*/ PersistenceUnitPart {

    EntitySecurityManager getEntitySecurityManager();

    void setEntitySecurityManager(EntitySecurityManager securityManager);

    FlagSet<EntityModifier> getUserModifiers();

    void setUserModifiers(FlagSet<EntityModifier> modifiers);

    FlagSet<EntityModifier> getUserExcludeModifiers();

    void setUserExcludeModifiers(FlagSet<EntityModifier> modifiers);

    FlagSet<EntityModifier> getModifiers();

    // Framework Friend Methods
    void setModifiers(FlagSet<EntityModifier> modifiers);

    boolean exists();

    Entity getParentEntity();

    EntityDescriptor getEntityDescriptor();

    Relationship getCompositionRelation();

    List<Relationship> getRelationships();

    List<Relationship> getRelationshipsBySource();

    List<Relationship> getRelationshipsByTarget();

    /**
     * @return true if this entity is its own parent
     */
    boolean isHierarchical();

    String getParentSecurityAction();

    void setParentSecurityAction(String parentSecurityAction);

    Index addIndex(String name, boolean unique, String... fields);

    List<Index> getIndexes(Boolean unique);

    void removePart(int index);

    void movePart(int index, int newIndex);

    void movePart(String partName, int newIndex);

    List<EntityPart> getParts();

    int indexOfField(String field);

    int indexOfPart(EntityPart part);

    int indexOfPart(String partName);

    int indexOfPart(String partName, boolean countSections,
                    boolean countCompoundFields, boolean countFieldsInCompoundFields,
                    boolean countFieldsInSections);

    List<Section> getSections();

    Section getSection(String sectionPath);

    Section findSection(String path);

    Section getSection(String path, MissingStrategy missingStrategy);

    Section addSection(String name, String parentPath);

    Section addSection(String name, String parentPath, int index);

    Section addSection(String name, int index);

    Section addSection(String name);

    Class getEntityType();

    Class getIdType();

    boolean needsView();

    DataType getDataType();

    void setDataType(DataType newDataType);

    boolean isDependentOnEntity(String entityName);

    Set<String> getDependencyEntities();

    //    void addSecuritySupport() ;
//    String getPersistenceName();
//
//    void setPersistenceName(String persistenceName);
//    Field addField(Field field, String sectionPath) ;
//    Field addField(Field field, String sectionPath, int index) ;
    Field addField(FieldDescriptor fieldDescriptor);

    Field addField(FieldBuilder fieldBuilder);

    Field getMainField();

    String getMainFieldValue(Object o);

    EntityNavigator getNavigator();

    void setNavigator(EntityNavigator navigator);

    // ------------------------------------------------------------------------------
    int getFieldsCount();

    boolean containsField(String fieldName);

    List<DynamicField> getDynamicFields();

    Field getField(int position);

    Field getField(String fieldName);

    Field findField(String fieldName);

    List<Field> getPrimaryFields();

    List<String> getFieldNames(FieldFilter fieldFilter);

    //    int indexOfField(String key) ;
    Object cloneDocument(Object oldId, Object newId);

    Object rename(Object oldId, Object newId);

    Object rename(Object oldId, Object newId, Map<String, Object> hints);

    Object getNextId(Object id);

    Object getFirstId();

    Object getLastId();

    Object getPreviousId(Object id);

    boolean hasNext(Object id);

    boolean hasPrevious(Object id);

    boolean isEmpty();

    long getEntityCount();

    long getEntityCount(Expression booleanExpression);

    <K> K nextId();

    void persist(Object objectOrDocument);

    boolean save(Object objectOrDocument);

    void persist(Object objectOrDocument, Map<String, Object> hints);

    boolean save(Object objectOrDocument, Map<String, Object> hints);

    void clear();

    void clear(Map<String, Object> hints);

    Expression getUnicityExpressionForPersist(Object entity);

    RemoveTrace remove(Object entity);

    RemoveTrace remove(RemoveOptions options);

    Field[] toFieldArray(String[] s);

    boolean contains(Object id);

    UpdateQuery createUpdateQuery();

    void update(Object objectOrDocument);

//    void update(Object objectOrDocument,Map<String,Object> hints) ;
//
//    void merge(Object objectOrDocument,Map<String,Object> hints) ;
//
//    void updatePartial(Object objectOrDocument,String... fields)  ;
//
//    void updatePartial(Object entity, Set<String> fields, boolean ignoreUnspecified)  ;
//
//    void updatePartial(Object objectOrDocument) ;
//
//    void updatePartial(Object objectOrDocument, Object id) ;
//
//    void updatePartial(Object objectOrDocument,Map<String,Object> hints,String... fields)  ;
//
//    void updatePartial(Object entity, Set<String> fields, boolean ignoreUnspecified,Map<String,Object> hints)  ;
//
//    void updatePartial(Object objectOrDocument,Map<String,Object> hints) ;
//
//    void updatePartial(Object objectOrDocument, Object id,Map<String,Object> hints) ;
//
//    void updateDocument(Document document, Key key) ;
//    void updateDocument(Document document, Key key,Map<String,Object> hints) ;
//
//    int updateDocuments(Document document, Expression condition,Map<String,Object> hints) ;
//
//    int updateDocuments(Document document, Expression condition) ;

//    void updateFormulas(FieldFilter filter, Expression expr) ;
//    void updateFormulas(FieldFilter filter, Expression expr,Map<String,Object> hints) ;
//
//    void updateFormulasById(FieldFilter filter, Object key) ;
//    void updateFormulasById(FieldFilter filter, Object key,Map<String,Object> hints) ;

    void merge(Object objectOrDocument);
//    void updateFormulas(Map<String,Object> hints) ;

//    void updateFormulasById(Object id) ;
//
//    void updateFormulasById(Object id,Map<String,Object> hints) ;
//
//    void updateFormulas(Expression condition) ;
//    void updateFormulas(Expression condition,Map<String,Object> hints) ;

    void updateFormulas();

    Order getUpdateFormulasOrder();

    String getIdName(Object id);

    List<Field> getValidFields(String... fieldNames);

    List<Field> getFields();

    List<Field> getFields(String... fieldNames);

    List<Field> getFields(FieldFilter filter);

    List<Field> getImmediateFields();

    List<Field> getImmediateFields(FieldFilter filter);

    Order getArchivingOrder();

    void setArchivingOrder(Order archivingOrder);

    Field getLeadingPrimaryField();

    List<String> getOrderedFields(String[] fields);

    Expression toIdListExpression(Expression e);

    String getShortName();

    void setShortName(String shortName);

    String getShortNameOrName();

    Order getListOrder();

    void setListOrder(Order listOrder);

    List<PrimitiveField> getPrimitiveFields(FieldFilter fieldFilter);

    PrimitiveField getPrimitiveField(String fieldName);

    PrimitiveField findPrimitiveField(String fieldName);

    <T extends EntityPart> List<PrimitiveField> toPrimitiveFields(List<T> parts);

    List<Field> getFields(List<EntityPart> parts);

    List<PrimitiveField> getPrimitiveFields(String... fieldNames);

    EntityBuilder getBuilder();

    QueryBuilder createQueryBuilder();

    Query createQuery(EntityStatement query);

    Query createQuery(String query);

    List<Trigger> getTriggers();

    /**
     * Triggers with VM support (having listener!=null)
     *
     * @return
     * @
     */
    List<Trigger> getSoftTriggers();

    void addExtensionDefinition(Class extensionType, EntityExtensionDefinition extensionObject);

    void removeExtensionDefinition(Class extensionType, EntityExtensionDefinition extensionObject);

    List<EntityExtensionDefinition> getExtensionDefinitions();

    <S extends EntityExtensionDefinition> List<S> getExtensionDefinitions(Class<S> type);

    List<EntityExtension> getExtensions();

    <S extends EntityExtension> List<S> getExtensions(Class<S> type);

    <S extends EntityExtension> S getExtension(Class<S> type);

    EntityOperationManager getEntityOperationManager();

    EntityShield getShield();

    void setShield(EntityShield shield);

    Expression childToParentExpression(Document child);

    Expression childToParentExpression(Expression childExpression);

    Expression parentToChildExpression(Expression parentExpression);

    Key createKey(Object... keyValues);

    Object createId(Object... keyValues);

    Document createDocument();

    <R> R createObject();

    /**
     * adds anonymous trigger
     *
     * @param trigger
     * @return
     * @
     */
    Trigger addTrigger(EntityInterceptor trigger);

    Trigger addTrigger(String name, EntityInterceptor trigger);

    void removeTrigger(String triggerName);

    //    void addEntityListener(EntityListener listener) ;
//
//    void removeEntityListener(EntityListener listener) ;
    void addDefinitionListener(DefinitionListener definitionListener);

    void removeDefinitionListener(DefinitionListener definitionListener);

    //////////////////////////////////////////////////////////
    //
    //    CORE
    //
    //////////////////////////////////////////////////////////
    int updateCore(Document updates, Expression condition, EntityExecutionContext executionContext);

    void persistCore(Document values, EntityExecutionContext executionContext);

    int removeCore(Expression condition, boolean recurse, RemoveTrace deleteInfo, EntityExecutionContext executionContext);

    int clearCore(EntityExecutionContext executionContext);

//    long updateFormulasCore(FieldFilter filter, Expression expr, EntityExecutionContext context) ;

    int initializeCore(EntityExecutionContext executionContext);

    Object compile(Expression expression,String alias);

    void addFilter(String name, String expression);

    void addFilter(String name, Expression expression);

    Expression getFilter(String name);

    void removeFilter(String name);

    Set<String> getFilterNames();

    boolean isSystem();

    void initialize();

    void initialize(Map<String, Object> hints);

    void commitModelChanges();

    void commitStructureModification(PersistenceStore persistenceUnitManager);

    void addDependencyOnEntity(String entityName);

    //    /**
//     * called by PersistenceUnit
//     */
//    void setCompositionRelationship(Relationship compositionRelation) ;
    <T> T findById(Object id);

    boolean existsById(Object id);

    <T> T findByMainField(Object mainFieldValue);

    <T> T findByField(String fieldName, Object mainFieldValue);

    <T> List<T> findAll();

    <T> List<T> findAllIds();

    List<Document> findAllDocuments();

    PlatformBeanType getPlatformBeanType();
}
