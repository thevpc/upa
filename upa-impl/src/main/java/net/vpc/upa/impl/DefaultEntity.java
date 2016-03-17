package net.vpc.upa.impl;

import net.vpc.upa.callbacks.UpdateRelationshipTargetFormulaInterceptor;
import net.vpc.upa.callbacks.EntityInterceptor;
import net.vpc.upa.callbacks.Trigger;
import net.vpc.upa.callbacks.DefinitionListener;
import net.vpc.upa.callbacks.UpdateRelationshipSourceFormulaInterceptor;
import net.vpc.upa.callbacks.UpdateFormulaInterceptor;
import net.vpc.upa.callbacks.EntityListener;
import net.vpc.upa.callbacks.SingleEntityListener;
import net.vpc.upa.*;
import net.vpc.upa.Package;
import net.vpc.upa.exceptions.NoSuchSectionException;
import net.vpc.upa.exceptions.ObjectAlreadyExistsException;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.exceptions.UpdateRecordKeyNotFoundException;
import net.vpc.upa.expressions.*;
import net.vpc.upa.extensions.EntityExtensionDefinition;
import net.vpc.upa.filters.FieldFilter;
import net.vpc.upa.filters.Fields;
import net.vpc.upa.impl.config.decorations.DecorationRepository;
import net.vpc.upa.impl.event.FormulaUpdaterInterceptorSupport;
import net.vpc.upa.impl.event.RelationshipSourceFormulaUpdaterInterceptorSupport;
import net.vpc.upa.impl.event.RelationshipTargetFormulaUpdaterInterceptorSupport;
import net.vpc.upa.impl.event.SingleDataInterceptorSupport;
import net.vpc.upa.impl.navigator.EntityNavigatorFactory;
import net.vpc.upa.impl.persistence.DefaultEntityOperationManager;
import net.vpc.upa.impl.persistence.DefaultQueryBuilder;
import net.vpc.upa.impl.persistence.FieldListPersistenceInfo;
import net.vpc.upa.impl.persistence.FieldPersistenceInfo;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.impl.uql.CompiledExpressionHelper;
import net.vpc.upa.impl.uql.compiledexpression.CompiledSelect;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;
import net.vpc.upa.expressions.IdCollectionExpression;
import net.vpc.upa.expressions.IdEnumerationExpression;
import net.vpc.upa.expressions.IdExpression;
import net.vpc.upa.impl.util.*;
import net.vpc.upa.persistence.*;
import net.vpc.upa.types.DataType;
import net.vpc.upa.types.DataTypeTransform;
import net.vpc.upa.types.EntityType;
import net.vpc.upa.types.I18NString;

import java.util.*;
import java.util.logging.Level;
import java.util.logging.Logger;

public class DefaultEntity extends AbstractUPAObject implements // for simple
        // use
        Entity {

    public static final FieldFilter VIEW = Fields.byModifiersAnyOf(FieldModifier.SELECT_COMPILED);
    public static final String EXPRESSION_SURELY_EXISTS = "EXPRESSION_SURELY_EXISTS";
    public static final String PERSIST_USED_FIELDS = "PERSIST_USED_FIELDS";
    public static final String PERSIST_DEPENDENT_FIELDS = "PERSIST_DEPENDENT_FIELDS";
    public static final String UPDATE_USED_FIELDS = "UPDATE_USED_FIELDS";
    public static final String UPDATE_DEPENDENT_FIELDS = "UPDATE_DEPENDENT_FIELDS";
    private static final Logger log = Logger.getLogger(DefaultEntity.class.getName());
    private static final FieldFilter PERSIST_FORMULA = Fields
            .byModifiersAnyOf(FieldModifier.PERSIST_FORMULA)
            .and(Fields.byModifiersNotAllOf(FieldModifier.PERSIST_SEQUENCE));
    private static final FieldFilter UPDATE_FORMULA = Fields.regular().and(Fields.byModifiersAnyOf(FieldModifier.UPDATE_FORMULA)).and(Fields.byModifiersNoneOf(FieldModifier.UPDATE_SEQUENCE));
    public static final FieldFilter ID = Fields.regular().and(Fields.byModifiersAnyOf(FieldModifier.ID));
    private static final FieldFilter COPY_ON_CLONE = Fields.regular().and(Fields.byModifiersNoneOf(FieldModifier.PERSIST_FORMULA, FieldModifier.UPDATE_FORMULA, FieldModifier.TRANSIENT));
    private static final FieldFilter COPY_ON_RENAME = Fields.regular().and(Fields.byModifiersNoneOf(FieldModifier.PERSIST_FORMULA, FieldModifier.UPDATE_FORMULA, FieldModifier.TRANSIENT));
    private static final FieldFilter FIELD_FILTER_PERSIST = Fields.byModifiersAllOf(FieldModifier.PERSIST);
    private static final FieldFilter FIELD_FILTER_PERSIST_NON_NULLABLE = new PersistNonNullableFieldFilter();
    private static final FieldFilter FIELD_FILTER_PERSIST_WITH_DEFAULT_VALUE = new PersistWithDefaultValueFieldFilter();
    public static boolean VALIDATE_IF_CHANGED = false;
    public static int MAX_CACHE_SIZE = 20;
    DefaultEntityPrivateListener objListener;
    //    PropertyChangeListener beforeAddListener;
//    PropertyChangeListener afterAddListener;
    //    private String name;
    private String shortName;
    private RecordListenerSupport recordListenerSupport;
    private Class idType;
    private Class entityType;
    private DefaultEntityBuilder entityFactory;
    private List<EntityPart> items = new ArrayList<EntityPart>();
    private Map<String, EntityPart> itemsByName = new HashMap<String, EntityPart>();
    private Map<String, Trigger> triggers = new HashMap<String, Trigger>();
    Map<String, Field> fieldsMap = new LinkedHashMap<String, Field>();
    //    private List<Field> fieldsList = new ArrayList<Field>();
    //    private HashList mappedCompoundFields;
    private Field mainRendererField;
    private boolean closed;
    //    private String cache_loadRecordName_query;
//    private Section currentSection;
//    private CompoundField currentCompoundField;
    //private Hashtable cached_fields;
    private CacheMap<FieldFilter, List<Field>> fieldsByFilter = new CacheMap<FieldFilter, List<Field>>(MAX_CACHE_SIZE);
    private Set<String> dependsOnTables = new TreeSet<String>();
    private String parentSecurityAction;
    private Relationship compositionRelation;
    private Package parent;
    private EntityDescriptor entityDescriptor;
    //    private String description;
//    private LocalizedEntity localizedTable = new DefaultLocalizedTable();
    private FlagSet<EntityModifier> userIncludeModifiers;
    private FlagSet<EntityModifier> userExcludeModifiers;
    private FlagSet<EntityModifier> effectiveModifiers;
    /**
     * name in the rdbms
     */
    private Order listOrder;
    private EntityNavigator navigator;
    private ArrayList<Index> indexes;
    private DataType dataType;
    private int tuningMaxInline = -1;
    private DefaultEntityExtensionManager extensionManager;
    private EntityOperationManager entityOperationManager;
    private boolean needsRevalidateCache = false;
    private int triggerAnonymousNameIndex = 1;
    private EntityShield shield;
    private net.vpc.upa.impl.persistence.FieldListPersistenceInfo fieldListPersistenceInfo = new FieldListPersistenceInfo();
    private LinkedHashMap<String, Expression> objectfilters = new LinkedHashMap<String, Expression>();
    //    private static final Index[] EMPTY_INDEX_ARRAY = new Index[0];
    private DefaultEntityPrivateCacheEmptyListener cache_isEmpty_Listener = new DefaultEntityPrivateCacheEmptyListener();
    private EntitySecurityManager entitySecurityManager;

    public DefaultEntity() {
        super();
        objListener = new DefaultEntityPrivateListener(this);
        userIncludeModifiers = FlagSets.noneOf(EntityModifier.class);
        userExcludeModifiers = FlagSets.noneOf(EntityModifier.class);
        effectiveModifiers = FlagSets.noneOf(EntityModifier.class);
        recordListenerSupport = new RecordListenerSupport(this);
        entityFactory = new DefaultEntityBuilder(this);
        entityFactory.setEntityConverter(new DefaultEntityConverter(this));
        indexes = new ArrayList<Index>();
//        addEntityListener(cache_isEmpty_Listener);
    }

    private static Expression getFieldExpression(Field field, boolean forPersist) {
        if (forPersist) {
            return (field.getPersistFormula() instanceof ExpressionFormula) ? ((ExpressionFormula) field.getPersistFormula()).getExpression() : null;
        } else {
            return (field.getUpdateFormula() instanceof ExpressionFormula) ? ((ExpressionFormula) field.getUpdateFormula()).getExpression() : null;
        }
    }

    //    public LocalizedEntity getLocalizedEntity() {
//        return localizedTable;
//    }
//
//    public class DefaultLocalizedTable implements LocalizedEntity {
//
//        public Field getExtendedField(String fieldName, boolean check) {
//            for (Iterator i = fieldsMap.entrySet().iterator(); i.hasNext(); ) {
//                Map.Entry e = (Map.Entry) i.next();
//                PrimitiveField t = (PrimitiveField) e.getValue();
//                if (t.getName().equalsIgnoreCase(fieldName)
//                        || t.getTitle().equalsIgnoreCase(fieldName)) {
//                    return t;
//                }
//            }
//            if (check) {
////                Log.dev_warning(getName() + " : Field " + fieldName + " not found in Table " + name);
//                throw new NoSuchElementException("Field " + fieldName
//                        + " was not found in " + getName());
//            } else {
//                return null;
//            }
//        }
//
//        public String getName() {
//            return DefaultEntity.this.getTitle();
//        }
//
//        public String toString() {
//            return DefaultEntity.this.getTitle();
//        }
//
//        public DefaultEntity getEntity() {
//            return DefaultEntity.this;
//        }
//    }
//
    public static String[] getTableNames(DefaultEntity[] tables) {
        String[] names = new String[tables.length];
        for (int i = 0; i < tables.length; i++) {
            names[i] = tables[i].getName();
        }
        return names;
    }

    public FlagSet<EntityModifier> getUserModifiers() {
        return userIncludeModifiers;
    }

    public void setUserModifiers(FlagSet<EntityModifier> modifiers) {
        this.userIncludeModifiers = modifiers;
    }

    public FlagSet<EntityModifier> getUserExcludeModifiers() {
        return userExcludeModifiers;
    }

    public void setUserExcludeModifiers(FlagSet<EntityModifier> modifiers) {
        this.userExcludeModifiers = modifiers;
    }

    public FlagSet<EntityModifier> getModifiers() {
        return effectiveModifiers;
    }

    public void setModifiers(FlagSet<EntityModifier> effectiveModifiers) {
        this.effectiveModifiers = effectiveModifiers;
    }

    @Override
    public String getAbsoluteName() {
        return getName();
    }

    @Override
    public void setPersistenceUnit(PersistenceUnit persistenceUnit) {
        super.setPersistenceUnit(persistenceUnit);
        ObjectFactory factory = getPersistenceUnit().getFactory();
        setShield(factory.createObject(EntityShield.class, null));
        extensionManager = factory.createObject(DefaultEntityExtensionManager.class);
        tuningMaxInline = getPersistenceUnit().getProperties().getInt(Relationship.class.getName() + ".maxInline", 10);
        entityOperationManager = factory.createObject(EntityOperationManager.class);
        addTrigger(null, cache_isEmpty_Listener);
    }

    public void commitStructureModification(PersistenceStore persistenceStore) throws UPAException {
        ObjectFactory factory = getPersistenceUnit().getFactory();
        ((DefaultEntityOperationManager) entityOperationManager).init(this, persistenceStore);
        fieldListPersistenceInfo.entity = this;
        fieldListPersistenceInfo.persistenceStore = persistenceStore;

        for (Field field : getFields()) {
            validateField(field);
        }
        fieldListPersistenceInfo.update();

//        FlagSet<EntityModifier> effectiveModifiers = getShield().getModifiers();
//        if (effectiveModifiers.contains(EntityModifier.GENERATED_ID)) {
//            idGenerator = persistenceStore.createPersistSequenceGenerator(this);
//        }
    }

    //    public ImageIcon getIcon() {
//        return getRenderer().getIcon();
//    }
//
    public boolean exists() throws UPAException {
        try {
            getEntityCount();
            return true;
        } catch (UPAException e) {
            return false;
        }
    }

    public Entity getParentEntity() throws UPAException {
        return compositionRelation == null ? null : compositionRelation.getTargetRole().getEntity();
    }

    public Relationship getCompositionRelation() {
        return this.compositionRelation;
    }

    /**
     * called by PersistenceUnitFilter
     */
    public void setCompositionRelationship(Relationship compositionRelation) throws UPAException {
        if (compositionRelation == null) {
            this.compositionRelation = null;
        } else {
            if (compositionRelation.getRelationshipType() != RelationshipType.COMPOSITION) {
                throw new IllegalArgumentException("Invalid Relationship type " + compositionRelation);
            }
//            if (this.compositionRelation != null) {
//                throw new IllegalArgumentException("Entity " + getName()
//                        + " is already composing " + getParentEntity() + " via "
//                        + this.compositionRelation
//                        + ". It could not accept new Composition via "
//                        + compositionRelation);
//            }
            this.compositionRelation = compositionRelation;
        }
    }

    public String getParentSecurityAction() {
        return parentSecurityAction == null ? getParentEntity() == null ? null : getParentEntity().getName() : parentSecurityAction;
    }

    public void setParentSecurityAction(String parentSecurityAction) {
        this.parentSecurityAction = parentSecurityAction;
    }

    public Index addIndex(String indexName, boolean unique, String... fields) throws UPAException {
        if (fields == null || fields.length == 0) {
            throw new IllegalArgumentException("Index Fields Count == 0");
        }
        List<String> fieldList = new ArrayList<String>(new LinkedHashSet<String>(Arrays.asList(fields)));
        Index index = getPersistenceUnit().getFactory().createObject(Index.class);
        if (Strings.isNullOrEmpty(indexName)) {
            StringBuilder b = new StringBuilder("IX").append(getName());
            for (String f : fieldList) {
                b.append("_").append(f);
            }
            indexName = b.toString();
        }
        index.setName(indexName);
        DefaultBeanAdapter adapter = UPAUtils.prepare(getPersistenceUnit(), index, indexName);
        adapter.inject(index, "unique", unique);
        adapter.inject(index, "entity", this);
        adapter.inject(index, "fieldNames", fieldList.toArray(new String[fieldList.size()]));

        //List<T> items, T child, int index, UPAObject newParent, UPAObject propertyChangeSupport, ItemInterceptor<T> interceptor
        ListUtils.add(indexes, index, -1, this, this, null);
        invalidateStructureCache();
        return index;
    }

    public List<Index> getIndexes(Boolean unique) {
        List<Index> allIndexes = getPersistenceUnit().getIndexes(getName());
        if (unique == null) {
            return allIndexes;
        } else {
            boolean x = unique.booleanValue();
            List<Index> uniqueIndexes = new ArrayList<Index>();
            for (Index index : allIndexes) {
                if (index.isUnique() == x) {
                    uniqueIndexes.add(index);
                }
            }
            return uniqueIndexes;
        }
    }

    public <T extends EntityPart> List<PrimitiveField> toPrimitiveFields(List<T> parts) throws UPAException {
        ArrayList<PrimitiveField> v = new ArrayList<PrimitiveField>(parts.size());
        fillPrimitiveFields(parts, v);
        return v;
    }

    @Override
    public List<Field> getFields(List<EntityPart> parts) throws UPAException {
        ArrayList<Field> v = new ArrayList<Field>(parts.size());
        fillFields(parts, v);
        return v;
    }

    private void fillFields(List<EntityPart> parts, List<Field> c) throws UPAException {
        for (EntityPart part : parts) {
            if (part instanceof Field) {
                c.add((Field) part);
            } else if (part instanceof Section) {
                fillFields(((Section) part).getParts(), c);
            }
        }
    }

    private <T extends EntityPart> void fillPrimitiveFields(List<T> parts, List<PrimitiveField> c) throws UPAException {
        for (EntityPart part : parts) {
            if (part instanceof PrimitiveField) {
                c.add((PrimitiveField) part);
            } else if (part instanceof CompoundField) {
                List<PrimitiveField> primitiveFields = ((CompoundField) part).getFields();
                for (PrimitiveField f : primitiveFields) {
                    c.add(f);
                }
            } else if (part instanceof Section) {
                fillPrimitiveFields(((Section) part).getParts(), c);
            }
        }
    }

    private void addPart(EntityPart item, int index) throws UPAException {
        ListUtils.add(items, item, index, this, this, new DefaultEntityPrivateAddItemInterceptor(this));
        itemsByName.put(item.getName(), item);
        invalidateStructureCache();
    }

    public void removePart(int index) {
        EntityPart item = ListUtils.remove(items, index, this, new DefaultEntityPrivateRemoveItemInterceptor());
        itemsByName.remove(item.getName());
    }

    public void movePart(int index, int newIndex) {
        ListUtils.moveTo(items, index, newIndex, this, null);
        invalidateStructureCache();
    }

    public void movePart(String partName, int newIndex) {
        movePart(indexOfPart(partName), newIndex);
    }

    public List<EntityPart> getParts() {
        return items;
    }

    @Override
    public int indexOfField(String field) throws UPAException {
        List<String> strings = new ArrayList<String>(fieldsMap.keySet());
        return strings.indexOf(field);
    }

    public int indexOfPart(EntityPart child) {
        return items.indexOf(child);
    }

    public int indexOfPart(String childName) {
        int index = 0;
        for (EntityPart part : items) {
            if (childName.equals(part.getName())) {
                return index;
            }
            index++;
        }
        return -1;
    }

    public int indexOfPart(String childName, boolean countSections,
            boolean countCompoundFields, boolean countFieldsInCompoundFields,
            boolean countFieldsInSections) throws UPAException {
        int index = 0;
        Stack<EntityPart> stack = new Stack<EntityPart>();
        int partSize = items.size();
        for (int i = partSize - 1; i >= 0; i--) {
            stack.push(items.get(i));
        }
        while (!stack.isEmpty()) {
            EntityPart entityPart = stack.pop();
            if (childName.equals(entityPart.getName())) {
                return index;
            } else if (entityPart instanceof Section) {
                List<EntityPart> p = ((Section) entityPart).getParts();
                for (int i = 0; i < p.size(); i++) {
                    stack.push(p.get(p.size() - 1 - i));
                }
                if (countSections) {
                    index++;
                }
            } else if (entityPart instanceof CompoundField) {
                List<PrimitiveField> p = ((CompoundField) entityPart).getFields();
                for (int i = 0; i < p.size(); i++) {
                    stack.push(p.get(p.size() - 1 - i));
                }
                if (countCompoundFields) {
                    index++;
                }
            } else // field
            {
                if (!countFieldsInCompoundFields
                        && entityPart.getParent() instanceof CompoundField) {
                    //
                } else if (!countFieldsInSections
                        && entityPart.getParent() instanceof Section) {
                    //
                } else {
                    index++;
                }
            }
        }
        return -1;
    }

    public List<Trigger> getTriggers() throws UPAException {
        return new ArrayList<Trigger>(triggers.values());
//        List<Trigger> triggers = getPersistenceUnit().getTriggers(getName());
//        List<Trigger> r = new ArrayList<Trigger>();
//        for (Trigger trigger : triggers) {
//            r.add(trigger);
//        }
//        return r;
    }

    public List<Trigger> getSoftTriggers() throws UPAException {
        return new ArrayList<Trigger>(triggers.values());
//        List<Trigger> triggers = getPersistenceUnit().getTriggers(getName());
//        List<Trigger> r = new ArrayList<Trigger>();
//        for (Trigger trigger : triggers) {
//            if (trigger.getListener() != null) {
//                r.add(trigger);
//            }
//        }
//        return r;
    }

    @Override
    public Section addSection(String name, String parentPath, int index) throws UPAException {
        if (name == null) {
            throw new NullPointerException();
        }
        if (name.contains("/")) {
            throw new IllegalArgumentException("Name cannot contain '/'");
        }
        String[] canonicalPathArray = UPAUtils.getCanonicalPathArray(parentPath);
        Section parentModule = null;
        for (String n : canonicalPathArray) {
            Section next = null;
            if (parentModule == null) {
                next = getSection(n);
            } else {
                next = parentModule.getSection(n);
            }
            parentModule = next;
        }

        Section currentModule = getPersistenceUnit().getFactory().createObject(Section.class);
        DefaultBeanAdapter a = UPAUtils.prepare(getPersistenceUnit(), currentModule, name);

        if (parentModule == null) {
            addPart(currentModule, index);
        } else {
            parentModule.addPart(currentModule, index);
        }
        invalidateStructureCache();
        return currentModule;
    }

    public Section getSection(String path) {
        return getSection(path, MissingStrategy.ERROR);
    }

    //    public void setSystem(boolean value) {
//        setModifiers(EntityModifier.SYSTEM, value);
//    }
//
//
//    public void setTransient(boolean value) {
//        setModifiers(EntityModifier.defineTransient, value);
//    }
    // public void reorderField(String fieldName, int newPosition) {
    // Field f = getField(fieldName);
    // int oldPosition = f.getIndex();
    // if (newPosition == oldPosition) {
    // return;
    // } else if (newPosition > oldPosition) {
    // if (newPosition > fields.size()) {
    // newPosition = fields.size();
    // }
    // for (int i = oldPosition + 1; i < newPosition + 1 && i < fields.size();
    // i++) {
    // Field of = (Field) fields.get(i);
    // of.setIndex(i - 1);
    // }
    // fields.remove(oldPosition);
    // fields.insertElementAt(f, newPosition);
    // FieldSection fg = getGroupForIndex(oldPosition);
    // if (fg != null) {
    // fg.setIntervall(fg.getStartIndex(), fg.getEndIndex() - 1);
    // }
    // fg = getGroupForIndex(newPosition - 1);
    // if (fg != null) {
    // fg.setIntervall(fg.getStartIndex() - 1, fg.getEndIndex());
    // }
    // } else {
    // if (newPosition < 0) {
    // newPosition = 0;
    // }
    // fields.remove(oldPosition);
    // fields.insertElementAt(f, newPosition);
    // for (int i = newPosition; i <= oldPosition; i++) {
    // Field of = (Field) fields.get(i);
    // of.setIndex(i);
    // }
    // FieldSection ofg = getGroupForIndex(oldPosition);
    // FieldSection nfg = getGroupForIndex(newPosition);
    // if (ofg != nfg) {
    // if (ofg != null) {
    // ofg.setIntervall(ofg.getStartIndex() + 1, ofg.getEndIndex());
    // }
    // if (nfg != null) {
    // nfg.setIntervall(nfg.getStartIndex(), nfg.getEndIndex() + 1);
    // }
    // } else if (ofg != null) {
    // ofg.revalidateStructure();
    // }
    // }
    // invalidateStructureCache();
    // }
    // public FieldSection getGroupForIndex(int index) {
    // for (int i = 0; i < groups.size(); i++) {
    // FieldSection fg = (FieldSection) groups.getValue(i);
    // if (index >= fg.getStartIndex() && index < fg.getEndIndex()) {
    // return fg;
    // }
    // }
    // return null;
    // }
//    public CompoundField startCompoundField(CompoundField compoundField) throws UPAException {
//        checkUnCompleteCompoundFieldDefinition();
//        currentCompoundField = compoundField;
//        if (currentSection != null) {
//            currentSection.add(currentCompoundField);
//        } else {
//            addPart(currentCompoundField, getItemsCount());
//        }
//        currentCompoundField.init();
//        return currentCompoundField;
//    }
//
//    public CompoundField endCompoundField() throws UPAException {
//        if (currentCompoundField == null) {
//            throw new NullPointerException("No compound field is being defined");
//        }
//        currentCompoundField.checkDefinition();
//        CompoundField oldCompoundField = currentCompoundField;
//        currentCompoundField = null;
//        return oldCompoundField;
//    }
    public Section findSection(String path) throws UPAException {
        return getSection(path, MissingStrategy.NULL);
    }

    public Section getSection(String path, MissingStrategy missingStrategy) {
        if (path == null) {
            throw new NullPointerException();
        }

        String[] canonicalPathArray = UPAUtils.getCanonicalPathArray(path);
        if (canonicalPathArray.length == 0) {
            throw new IllegalArgumentException("invalid module path " + path);
        }
        Section module = null;
        for (String n : canonicalPathArray) {
            Section next = null;
            if (module == null) {
                for (EntityPart schemaItem : items) {
                    if (schemaItem instanceof Section) {
                        if (schemaItem.getName().equals(n)) {
                            next = (Section) schemaItem;
                            break;
                        }
                    }
                }
                if (next == null) {
                    switch (missingStrategy) {
                        case ERROR: {
                            throw new NoSuchSectionException(path);
                        }
                        case CREATE: {
                            next = addSection(n, null);
                            break;
                        }
                        case NULL: {
                            return null;
                        }
                        default: {
                            throw new UnsupportedOperationException();
                        }
                    }
                }
            } else {
                try {
                    next = module.getSection(n);
                } catch (NoSuchSectionException e) {
                    switch (missingStrategy) {
                        case ERROR: {
                            throw new NoSuchSectionException(path);
                        }
                        case CREATE: {
                            next = addSection(n, module.getPath());
                            break;
                        }
                        case NULL: {
                            return null;
                        }
                        default: {
                            throw new UnsupportedOperationException();
                        }
                    }
                }
            }
            module = next;
        }
        return module;
    }

    @Override
    public Section addSection(String name, String parentPath) throws UPAException {
        return addSection(name, parentPath, -1);
    }

    public Section addSection(String name) throws UPAException {
        return addSection(name, null, -1);
    }

    public Section addSection(String name, int index) throws UPAException {
        return addSection(name, null, index);
    }

    public void invalidateStructureCache() {
        needsRevalidateCache = true;
        if (fieldsByFilter != null) {
            fieldsByFilter.clear();
        }
//        cache_loadRecordName_query = null;
    }

    //    private void revalidateStructure_addPart(EntityPart part) throws UPAException {
////        NamingStrategy namesComparator = getPersistenceUnit().getNamingStrategy();
//        if (part instanceof Section) {
//            List<EntityPart> children = ((Section) part).getChildren();
//            for (EntityPart aChildren : children) {
//                revalidateStructure_addPart(aChildren);
//            }
//        } else if (part instanceof PrimitiveField) {
//            PrimitiveField f = (PrimitiveField) part;
//            addFieldToCache(f);
//        } else if (part instanceof CompoundField) {
//            CompoundField cf = (CompoundField) part;
//            List<PrimitiveField> fs = cf.getPrimitiveFields();
//            for (PrimitiveField f : fs) {
//                addFieldToCache(f);
//            }
//            addFieldToCache(cf);
//        } else {
//            throw new RuntimeException("WouldNeverBeThrownException");
//        }
//    }
    public synchronized void revalidateStructure() throws UPAException {
        if (needsRevalidateCache) {
            needsRevalidateCache = false;
        }
    }

    public boolean needsView() throws UPAException {
        return !getFields(VIEW).isEmpty();
    }

    public DataType getDataType() throws UPAException {
        if (dataType == null) {
            dataType = new KeyType(this, (Expression) null, true);
        }
        return dataType;
    }

    public void setDataType(DataType newDataType) throws UPAException {
        if (dataType != newDataType) {
            dataType = newDataType;
        }
    }

    protected void validateField(Field field) {
//        final Formula formula = field.getFormula();
        FlagSet<FieldModifier> _effectiveModifiers = field.getModifiers();
        EntityOperationManager epm = getEntityOperationManager();
        if (epm != null) {
            PersistenceStore store = epm.getPersistenceStore();
            if (store != null) {
                if (!store.isViewSupported() && (_effectiveModifiers.contains(FieldModifier.SELECT_COMPILED))) {
                    _effectiveModifiers = _effectiveModifiers.remove(FieldModifier.SELECT_COMPILED);
                    _effectiveModifiers = _effectiveModifiers.add(FieldModifier.SELECT_DEFAULT);
                    log.log(Level.WARNING, "View is not supported, View Field forced to be persisted {0}", field);
                    //effectiveModifiers = effectiveModifiers.add(UserFieldModifier.STORED_FORMULA);
                }
                if (!store.isComplexSelectSupported() && (_effectiveModifiers.contains(FieldModifier.SELECT_LIVE) || _effectiveModifiers.contains(FieldModifier.SELECT_COMPILED))) {
                    //check if complex formula
                    boolean complexFormula = false;
                    Formula selectFormula = field.getSelectFormula();
                    if (selectFormula instanceof ExpressionFormula) {
                        ExpressionFormula ef = (ExpressionFormula) selectFormula;
                        DefaultCompiledExpression compiledExpression = (DefaultCompiledExpression) compile(ef.getExpression());
                        List<DefaultCompiledExpression> expressionsList = compiledExpression.findExpressionsList(CompiledExpressionHelper.SELECT_FILTER);
                        complexFormula = expressionsList.size() > 0;
                    } else {
                        complexFormula = true;
                    }
                    if (complexFormula) {
                        _effectiveModifiers = _effectiveModifiers.remove(FieldModifier.SELECT_LIVE);
                        _effectiveModifiers = _effectiveModifiers.remove(FieldModifier.SELECT_COMPILED);
                        _effectiveModifiers = _effectiveModifiers.add(FieldModifier.PERSIST_FORMULA);
                        _effectiveModifiers = _effectiveModifiers.add(FieldModifier.UPDATE_FORMULA);
                        if (field.getUpdateFormula() == null) {
                            field.setUpdateFormula(field.getSelectFormula());
                        }
                        if (field.getPersistFormula() == null) {
                            field.setPersistFormula(field.getSelectFormula());
                        }
                        log.log(Level.WARNING, "Complex fields in SelectFormula are not supported, Field forced to be persisted {0}", field);
                    }
                    //effectiveModifiers = effectiveModifiers.add(UserFieldModifier.STORED_FORMULA);
                }
            }
        }
        ((AbstractField) field).setEffectiveModifiers(_effectiveModifiers);
//        if (field.getTypeTransform() == null) {
//            field.setTypeTransform(new IdentityDataTypeTransform(field.getDataType()));
//        }
    }

    private void commitFieldModelChanges(Field f) {
        FieldModifierHelper fmc = new FieldModifierHelper(f.getUserModifiers(), f.getUserExcludeModifiers());
        if (!fmc.contains(UserFieldModifier.TRANSIENT)) {
            Formula persistFormula = f.getPersistFormula();
            Formula updateFormula = f.getUpdateFormula();
            Formula selectFormula = f.getSelectFormula();

            if (fmc.contains(UserFieldModifier.ID)) {
                fmc.add(FieldModifier.ID);
            }
//system flags
            if (fmc.contains(UserFieldModifier.SYSTEM)) {
                fmc.add(FieldModifier.SYSTEM);
            }
            if (fmc.contains(UserFieldModifier.MAIN)) {
                fmc.add(FieldModifier.MAIN);
            }
            if (fmc.contains(UserFieldModifier.SUMMARY)) {
                fmc.add(FieldModifier.SUMMARY);
            }

            if (!fmc.rejects(UserFieldModifier.SELECT)) {
                fmc.add(FieldModifier.SELECT);
                if (selectFormula == null) {
                    fmc.add(FieldModifier.SELECT_DEFAULT);
                } else if (selectFormula instanceof ExpressionFormula) {
                    if (fmc.contains(UserFieldModifier.LIVE)) {
                        fmc.add(FieldModifier.SELECT_LIVE);
                    } else if (fmc.contains(UserFieldModifier.COMPILED)) {
                        fmc.add(FieldModifier.SELECT_COMPILED);
                    } else {
                        fmc.add(FieldModifier.SELECT_DEFAULT);
                    }
                } else if (selectFormula instanceof Sequence) {
                    if (fmc.contains(UserFieldModifier.LIVE) || fmc.contains(UserFieldModifier.COMPILED)) {
                        throw new IllegalArgumentException("LIVE and COMPILED elector are supported solely for ExpressionFormula");
                    }
                    fmc.add(FieldModifier.SELECT_DEFAULT);
                } else {
                    if (fmc.contains(UserFieldModifier.LIVE) || fmc.contains(UserFieldModifier.COMPILED)) {
                        throw new IllegalArgumentException("LIVE and COMPILED elector are supported solely for ExpressionFormula");
                    }
                    if (f.getDataType() instanceof EntityType) {
                        fmc.add(FieldModifier.SELECT_DEFAULT);
                    } else {
                        fmc.add(FieldModifier.SELECT_CUSTOM);
                    }
                }
            }

            if (!fmc.rejects(UserFieldModifier.PERSIST)
                    && !fmc.getEffective().contains(FieldModifier.SELECT_LIVE)
                    && !fmc.getEffective().contains(FieldModifier.SELECT_COMPILED)) {

                if (persistFormula == null) {
                    fmc.add(FieldModifier.PERSIST);
                    fmc.add(FieldModifier.PERSIST_DEFAULT);
                } else {
                    fmc.add(FieldModifier.PERSIST);
                    fmc.add(FieldModifier.PERSIST_FORMULA);
                    if (persistFormula instanceof Sequence) {
                        fmc.add(FieldModifier.PERSIST_SEQUENCE);
                    }
                }
            }

            if (!fmc.rejects(UserFieldModifier.UPDATE)
                    && !fmc.getEffective().contains(FieldModifier.ID)
                    && !fmc.getEffective().contains(FieldModifier.SELECT_LIVE)
                    && !fmc.getEffective().contains(FieldModifier.SELECT_COMPILED)) {
                if (updateFormula == null) {
                    fmc.add(FieldModifier.UPDATE);
                    fmc.add(FieldModifier.UPDATE_DEFAULT);
                } else {
                    fmc.add(FieldModifier.UPDATE);
                    fmc.add(FieldModifier.UPDATE_FORMULA);
                    if (updateFormula instanceof Sequence) {
                        fmc.add(FieldModifier.UPDATE_SEQUENCE);
                    }
                }
            }

            // check constraints
            if (selectFormula instanceof Sequence) {
                throw new IllegalArgumentException("Select Formula could not be a sequence");
            }
            if (((f.getPersistAccessLevel() == AccessLevel.PRIVATE)
                    || (f.getPersistAccessLevel() == AccessLevel.PRIVATE)
                    || (f.getPersistAccessLevel() == AccessLevel.PRIVATE)) && fmc.getEffective().contains(FieldModifier.MAIN)) {
                throw new IllegalArgumentException("Field " + getAbsoluteName() + " could not be define Main and PRIVATE");
            }

            //
            if (fmc.contains(UserFieldModifier.INDEX)) {
                boolean found = false;
                for (Index index : getIndexes(null)) {
                    String[] fields = index.getFieldNames();
                    if (fields.length == 1 && fields[0].equals(f.getName())) {
                        found = true;
                        break;
                    }
                }
                if (!found) {
                    addIndex(null, false, (f.getName()));
                }
            }
            if (fmc.contains(UserFieldModifier.UNIQUE)) {
                boolean found = false;
                for (Index index : getIndexes(true)) {
                    String[] fields = index.getFieldNames();
                    if (index.isUnique() && fields.length == 1 && fields[0].equals(f.getName())) {
                        found = true;
                        break;
                    }
                }
                if (!found) {
                    addIndex(null, true, (f.getName()));
                }
            }
        } else {
            fmc.add(FieldModifier.TRANSIENT);
        }
        ((AbstractField) f).setEffectiveModifiers(fmc.getEffective());

        if (f.getModifiers().contains(FieldModifier.PERSIST) && !f.getModifiers().contains(FieldModifier.ID)) {
            DataType dt = f.getDataType();
            if (!dt.isNullable()) {
                Object defaultValue = f.getDefaultObject();
                if (defaultValue == null) {
                    Object defaultNonNullValue = dt.getDefaultNonNullValue();
                    if (defaultNonNullValue == null) {
                        throw new IllegalArgumentException("Field " + f + " is not nullable but could not resolve a valid default value to use");
                    }
                }
            }
        }
    }

    private void commitFieldExpressionModelChanges(Field f) {
        FieldModifierHelper fmc = new FieldModifierHelper(f.getUserModifiers(), f.getUserExcludeModifiers());
        if (!fmc.contains(UserFieldModifier.TRANSIENT)) {
            Formula persistFormula = f.getPersistFormula();
            Formula updateFormula = f.getUpdateFormula();
//            Formula selectFormula = f.getSelectFormula();

            if (persistFormula != null) {
                final Set<Field> usedFields = findUsedFields(persistFormula);
                for (Field field : usedFields) {
                    Set<Field> c = (Set<Field>) field.getProperties().getObject(PERSIST_DEPENDENT_FIELDS);
                    if (c == null) {
                        c = new HashSet<Field>();
                        field.getProperties().setObject(PERSIST_DEPENDENT_FIELDS, c);
                    }
                    c.add(f);
                }
                f.getProperties().setObject(PERSIST_USED_FIELDS, usedFields);
            }
            if (updateFormula != null) {
                final Set<Field> usedFields = findUsedFields(updateFormula);
                for (Field field : usedFields) {
                    Set<Field> c = (Set<Field>) field.getProperties().getObject(UPDATE_DEPENDENT_FIELDS);
                    if (c == null) {
                        c = new HashSet<Field>();
                        field.getProperties().setObject(UPDATE_DEPENDENT_FIELDS, c);
                    }
                    c.add(f);
                }
                f.getProperties().setObject(PERSIST_USED_FIELDS, usedFields);
            }
        }
    }

    public void commitExpressionModelChanges() throws UPAException {
        List<Field> fs = getFields();
        for (Field f : fs) {
            commitFieldExpressionModelChanges(f);
        }
        //should do the same with filters
    }

    public void commitModelChanges() throws UPAException {
        invalidateStructureCache();
        revalidateStructure();
        FlagSet<EntityModifier> includedModifiers = getUserModifiers();
        FlagSet<EntityModifier> excludedModifiers = getUserExcludeModifiers();

        FlagSet<EntityModifier> _effectiveModifiers = FlagSets.noneOf(EntityModifier.class);

        List<Field> fs = getFields();

        for (Field f : fs) {
            commitFieldModelChanges(f);
            FlagSet<FieldModifier> fm = f.getModifiers();
            if (fm.contains(FieldModifier.PERSIST_FORMULA) && !fm.contains(FieldModifier.TRANSIENT) && !fm.contains(FieldModifier.PERSIST_SEQUENCE)) {
                _effectiveModifiers = _effectiveModifiers.add(EntityModifier.VALIDATE_PERSIST);
            }
            if (fm.contains(FieldModifier.UPDATE_FORMULA) && !fm.contains(FieldModifier.TRANSIENT) && !fm.contains(FieldModifier.UPDATE_SEQUENCE)) {
                _effectiveModifiers = _effectiveModifiers.add(EntityModifier.VALIDATE_UPDATE);
            }
        }
        if (includedModifiers.contains(EntityModifier.TRANSIENT)) {
            _effectiveModifiers = _effectiveModifiers.add(EntityModifier.TRANSIENT);
        }

//        if (m.contains(EntityModifier.GENERATED_ID) && !m.contains(EntityModifier.NO_GENERATED_ID)) {
//            effectiveModifiers = effectiveModifiers.add(EntityModifier.GENERATED_ID);
//        }
        if (includedModifiers.contains(EntityModifier.LOCK)) {
            _effectiveModifiers = _effectiveModifiers.add(EntityModifier.LOCK);
        }

        if (includedModifiers.contains(EntityModifier.PRIVATE)) {
            _effectiveModifiers = _effectiveModifiers.add(EntityModifier.PRIVATE);
        }

//        if (includedModifiers.contains(EntityModifier.RESET)) {
//            _effectiveModifiers = _effectiveModifiers.add(EntityModifier.RESET);
//        }
        if (includedModifiers.contains(EntityModifier.SYSTEM)) {
            _effectiveModifiers = _effectiveModifiers.add(EntityModifier.SYSTEM);
        }

        if (includedModifiers.contains(EntityModifier.PERSIST) || !excludedModifiers.contains(EntityModifier.PERSIST)) {
            _effectiveModifiers = _effectiveModifiers.add(EntityModifier.PERSIST);
        }

        if (includedModifiers.contains(EntityModifier.UPDATE) || !excludedModifiers.contains(EntityModifier.UPDATE)) {
            _effectiveModifiers = _effectiveModifiers.add(EntityModifier.UPDATE);
        }

        if (includedModifiers.contains(EntityModifier.REMOVE) || !excludedModifiers.contains(EntityModifier.REMOVE)) {
            _effectiveModifiers = _effectiveModifiers.add(EntityModifier.REMOVE);
        }

        if (includedModifiers.contains(EntityModifier.CLONE) || !excludedModifiers.contains(EntityModifier.CLONE)) {
            _effectiveModifiers = _effectiveModifiers.add(EntityModifier.CLONE);
        }

        if (includedModifiers.contains(EntityModifier.RENAME) || !excludedModifiers.contains(EntityModifier.RENAME)) {
            _effectiveModifiers = _effectiveModifiers.add(EntityModifier.RENAME);
        }

        List<Field> primaries = getPrimaryFields();
        if (includedModifiers.contains(EntityModifier.NAVIGATE) || (!excludedModifiers.contains(EntityModifier.NAVIGATE) && primaries.size() > 0)) {
            _effectiveModifiers = _effectiveModifiers.add(EntityModifier.NAVIGATE);
        }

        if (mainRendererField == null) {
            List<Field> test = new ArrayList<Field>();
            //test primaries first
            test.addAll(primaries);
            test.addAll(fs);
            for (Field field : test) {
                FlagSet<FieldModifier> efm = field.getModifiers();
                if (efm.contains(FieldModifier.MAIN)
                        && field.getPersistAccessLevel() != AccessLevel.PRIVATE
                        && field.getUpdateAccessLevel() != AccessLevel.PRIVATE
                        && field.getReadAccessLevel() != AccessLevel.PRIVATE
                        && !efm.contains(FieldModifier.SYSTEM)) {
                    mainRendererField = field;
                    break;
                }
            }
            if (mainRendererField == null) {
                for (Field field : test) {
                    FlagSet<FieldModifier> efm = field.getModifiers();
                    if (field.getPersistAccessLevel() != AccessLevel.PRIVATE
                            && field.getUpdateAccessLevel() != AccessLevel.PRIVATE
                            && field.getReadAccessLevel() != AccessLevel.PRIVATE
                            && !efm.contains(FieldModifier.SYSTEM)) {
                        efm.add(FieldModifier.MAIN);
                        mainRendererField = field;
                        break;
                    }
                }
            }
        }

        boolean _KeyEditionSupported = false;
        List<Field> primaryFields = getPrimaryFields();
        for (Field f : primaryFields) {
            FlagSet<FieldModifier> fm = f.getModifiers();
            if (!fm.contains(FieldModifier.PERSIST_FORMULA)) {
                _KeyEditionSupported = true;
                break;
            }
        }

        if (includedModifiers.contains(EntityModifier.USER_ID) || (!excludedModifiers.contains(EntityModifier.USER_ID) && _KeyEditionSupported)) {
            _effectiveModifiers = _effectiveModifiers.add(EntityModifier.USER_ID);
        }

        setModifiers(_effectiveModifiers);
//
//        EnumSet<EntityModifier> remain = m.clone();
//        remain.remove(EntityModifier.PERSIST);
//        remain.remove(EntityModifier.NO_PERSIST);
//        remain.remove(EntityModifier.UPDATE);
//        remain.remove(EntityModifier.NO_UPDATE);
//        remain.remove(EntityModifier.DELETE);
//        remain.remove(EntityModifier.NO_DELETE);
//        remain.remove(EntityModifier.CLONE);
//        remain.remove(EntityModifier.NO_CLONE);
//        remain.remove(EntityModifier.RENAME);
//        remain.remove(EntityModifier.NO_RENAME);
//        remain.remove(EntityModifier.NAVIGATE);
//        remain.remove(EntityModifier.NO_NAVIGATE);
//        remain.remove(EntityModifier.VALIDATE_INSERT);
//        remain.remove(EntityModifier.NO_VALIDATE_INSERT);
//        remain.remove(EntityModifier.VALIDATE_UPDATE);
//        remain.remove(EntityModifier.NO_VALIDATE_UPDATE);
//        remain.remove(EntityModifier.USER_ID);
//        remain.remove(EntityModifier.NO_USER_ID);
//        remain.remove(EntityModifier.GENERATED_ID);
//        remain.remove(EntityModifier.NO_GENERATED_ID);

        //if (!Utils.getBoolean(PersistenceUnitFilter.class, "productionMode", false)) {
        checkIntegrity();
        //}
    }

    protected void checkIntegrity() throws UPAException {
        // check for fields
        DefaultEntityPrivateChecker checker = new DefaultEntityPrivateChecker(this);

        List<Field> fs = getFields();
        if (fs.isEmpty()) {
            checker.addError("Entity " + getName() + " does not declare any field");
        }

        // check for primary fields
        List<Field> primaries = getPrimaryFields();
        if (primaries.isEmpty()) {
            checker.addWarning("Entity " + getName() + " has no primary fields");
        }

        // check for duplicate field declaration
        Set<String> hashSet = new HashSet<String>(fs.size());
        for (Field f : fs) {
            if (hashSet.contains(f.getName())) {
                checker.addError("Field " + f.getAbsoluteName()
                        + " is declared twice");
            }
            hashSet.add(f.getName());
        }

        // check for incorrect formula pass usage
//        for (Field f : fs) {
//            Formula formula = f.getFormula();
//            int formulaOrder = f.getFormulaOrder();
//            if (formula != null && formula instanceof ExpressionFormula) {
//                ExpressionFormula expressionFormula = (ExpressionFormula) formula;
//                CompiledExpression compiledExpression = (CompiledExpression) compile(expressionFormula.getExpression());
//                final Set<Field> usedFields = new HashSet<Field>();
//                compiledExpression.visit(new CompiledExpressionVisitor() {
//                    @Override
//                    public boolean visit(CompiledExpression e) {
//                        if (e instanceof CompiledVar) {
//                            CompiledVar v = (CompiledVar) e;
//                            if (v.getReferrer() instanceof Field) {
//                                usedFields.add((Field) v.getReferrer());
//                            }
//                        }
//                        return true;
//                    }
//                });
//                for (Field v : usedFields) {
//                    int p2 = -1;
//                    try {
//                        p2 = hashSet.get(v.getName());
//                    } catch (NullPointerException e) {
//                        checker.addError("Formula Error : Field "
//                                + f.getName() + " (" + pass1
//                                + " pass) in Table " + getName()
//                                + " uses un unknown field named " + v);
//                    }
//                    String pass2 = (p2 < 0) ? "initial" : p2 == 0 ? "1st"
//                            : p2 == 1 ? "2nd" : p2 == 2 ? "3rd" : (p2 + 1)
//                            + "th";
//                    if (p2 >= p1) {
//                        if (f.equals(v)) {
//                            checker.addWarning("Formula Warning : Cross reference reached for Field "
//                                    + f.getName()
//                                    + "("
//                                    + pass1
//                                    + " pass) in Table " + getName());
//                        } else {
//                            checker.addError("Formula Error : Field "
//                                    + f.getName() + " (" + pass1
//                                    + " pass) in Table " + getName()
//                                    + " uses Field " + v + " (" + pass2
//                                    + " pass)");
//                        }
//                    }
//                }
//                if (formula == null) {
//                    hashSet.put(f.getName(), -1);
//                } else {
//                    int p = formulaOrder;
//                    hashSet.put(f.getName(), p);
//                }
//            }
//        }
        checker.check();
    }

    public Trigger addTrigger(EntityInterceptor trigger) throws UPAException {
        return addTrigger(null, trigger);
    }

    public Trigger addTrigger(String triggerName, EntityInterceptor trigger) throws UPAException {
        DefaultPersistenceUnit pu = (DefaultPersistenceUnit) getPersistenceUnit();
        if (Strings.isNullOrEmpty(triggerName)) {
            while (true) {
                String n = "anonymous" + triggerAnonymousNameIndex;
                if (!triggers.containsKey(n) //only hard triggers should by schema wise unique!!
                        //                        && !pu.getAllTriggers().containsKey(n)
                        ) {
                    triggerName = n;
                    break;
                }
                triggerAnonymousNameIndex++;
            }
        } else if (triggers.containsKey(triggerName)) {
            throw new ObjectAlreadyExistsException(null, "Entity Trigger " + triggerName);
        } //            if (pu.getAllTriggers().containsKey(triggerName)) {
        //                throw new ObjectAlreadyExistsException(null, "Entity Trigger " + triggerName);
        //            }

        final DefaultTrigger triggerObject = new DefaultTrigger();
        triggerObject.setEntity(this);
        triggerObject.setName(triggerName);
        EntityListener listener = convertInterceptorToListener(trigger);
        triggerObject.setInterceptor(trigger);
        triggerObject.setListener(listener);
        triggerObject.setPersistenceState(PersistenceState.DIRTY);

        pu.getPersistenceUnitListenerManager().fireOnCreateTrigger(triggerObject, EventPhase.BEFORE);
        triggers.put(triggerName, triggerObject);
//        pu.getAllTriggers().put(triggerName, triggerObject);
        pu.getPersistenceUnitListenerManager().fireOnCreateTrigger(triggerObject, EventPhase.AFTER);
        return triggerObject;
    }

    protected EntityListener convertInterceptorToListener(EntityInterceptor trigger) {
        if (trigger instanceof EntityListener) {
            return (EntityListener) trigger;
        } else if (trigger instanceof SingleEntityListener) {
            return (new SingleDataInterceptorSupport((SingleEntityListener) trigger));
        } else if (trigger instanceof UpdateRelationshipTargetFormulaInterceptor) {
            return (new RelationshipTargetFormulaUpdaterInterceptorSupport((UpdateRelationshipTargetFormulaInterceptor) trigger));
        } else if (trigger instanceof UpdateRelationshipSourceFormulaInterceptor) {
            return (new RelationshipSourceFormulaUpdaterInterceptorSupport((UpdateRelationshipSourceFormulaInterceptor) trigger));
        } else if (trigger instanceof UpdateFormulaInterceptor) {
            return (new FormulaUpdaterInterceptorSupport((UpdateFormulaInterceptor) trigger));
        } else {
            throw new IllegalArgumentException("Unsupported Entity Trigger Type " + trigger.getClass());
        }
    }

    public void removeTrigger(String triggerName) throws UPAException {
        DefaultPersistenceUnit pu = (DefaultPersistenceUnit) getPersistenceUnit();
        Trigger tr = triggers.get(triggerName);
        if (tr == null) {
            throw new IllegalArgumentException("Trigger Not found " + triggerName);
        }
        pu.getPersistenceUnitListenerManager().fireOnDropTrigger(tr, EventPhase.BEFORE);
        triggers.remove(triggerName);
//        pu.getAllTriggers().remove(triggerName);
        pu.getPersistenceUnitListenerManager().fireOnDropTrigger(tr, EventPhase.AFTER);

    }

    //    public void addEntityListener(EntityListener listener) {
//        recordListenerSupport.addEntityListener(listener);
//    }
//
//    public void removeEntityListener(EntityListener listener) {
//        recordListenerSupport.removeEntityListener(listener);
//    }
    public void addDependencyOnEntity(String entityName) {
        dependsOnTables.add(entityName);
    }

    public boolean isDependentOnEntity(String entityName) {
        return dependsOnTables.contains(entityName);
    }

    public Set<String> getDependencyEntities() {
        return dependsOnTables;
    }

    //    public void addSecuritySupport() throws UPAException {
//        UPASecurityManager appSecurityManager = getPersistenceUnit().getSecurityManager();
//        appSecurityManager.addDefaultSecurityPattern(
//                "*.insert");
//        appSecurityManager.addDefaultSecurityPattern(
//                "*.update");
//        appSecurityManager.addDefaultSecurityPattern(
//                "*.printRecord");
//        appSecurityManager.addDefaultSecurityPattern(
//                "*.loadRecord");
//        appSecurityManager.addDefaultSecurityPattern(
//                "*.rename");
//
//        appSecurityManager.addDefaultSecurityPattern(
//                "*.cloneRecord");
//        appSecurityManager.addDefaultSecurityPattern(
//                "*.remove");
//        appSecurityManager.addDefaultSecurityPattern(
//                "*.open");
//        appSecurityManager.addDefaultSecurityPattern(
//                "*.navigate");
//
//        appSecurityManager.addDefaultSecurityPattern(
//                "*.provider.list");
//        appSecurityManager.addDefaultSecurityPattern(
//                "*.provider.search");
//        appSecurityManager.addDefaultSecurityPattern(
//                "*.provider.manual");
//
//        appSecurityManager.addDefaultSecurityPattern(
//                "*.fields.*.readField");
//        appSecurityManager.addDefaultSecurityPattern(
//                "*.fields.*.updateField");
//    }
    //    public String getSecurityActionIdForInsertRecord() {
//        return getName() + ".insert";
//    }
//
//    public String getSecurityActionIdForUpdateRecord() {
//        return getName() + ".update";
//    }
//
//    public String getSecurityActionIdForValidateRecord() {
//        return getName() + ".updateFormulasById";
//    }
//
//    public String getSecurityActionIdForPrintRecord() {
//        return getName() + ".printRecord";
//    }
//
//    public String getSecurityActionIdForLoadRecord() {
//        return getName() + ".loadRecord";
//    }
//
//    public String getSecurityActionIdForRenameRecord() {
//        return getName() + ".rename";
//    }
//
//    public String getSecurityActionIdForCloneRecord() {
//        return getName() + ".cloneRecord";
//    }
//
//    public String getSecurityActionIdForFields() {
//        return getName() + ".fields";
//    }
//
//    public String getSecurityActionIdForField(Field f) {
//        return getName() + ".fields." + f.getName();
//    }
//
//    public String getSecurityActionIdForReadField(Field f) {
//        return getName() + ".fields." + f.getName() + ".readField";
//    }
//
//    public String getSecurityActionIdForUpdateField(Field f) {
//        return getName() + ".fields." + f.getName() + ".updateField";
//    }
//
//    public String getSecurityActionIdForDeleteRecord() {
//        return getName() + ".remove";
//    }
//
//    public String getSecurityActionIdForOpenEditor() {
//        return getName() + ".open";
//    }
//
//    public String getSecurityActionIdForNavigate() {
//        return getName() + ".navigate";
//    }
//
//    public String getSecurityActionIdForNavigateByList() {
//        return getName() + ".provider.list";
//    }
//
//    public String getSecurityActionIdForNavigateBySearch() {
//        return getName() + ".provider.search";
//    }
//
//    public String getSecurityActionIdForNavigateByManual() {
//        return getName() + ".provider.manual";
//    }
    public void updateFormulas() throws UPAException {
        updateFormulas(null);
    }

    public final void updateFormulasById(Object id) throws UPAException {
        updateFormulasById(UPDATE_FORMULA, id);
    }

    public final void updateFormulas(Expression condition) throws UPAException {
        updateFormulas(UPDATE_FORMULA, condition);
    }

    //    public List<Field> addFields(Field[] model) throws UPAException {
//        List<Field> added = new ArrayList<Field>();
//        for (Field aModel : model) {
//            added.add(addField(aModel));
//        }
//        return added;
//    }
//
    public Field addField(Field field, String sectionPath) throws UPAException {
        return addField(field, sectionPath, -1);
    }

    public Field addField(Field field, String sectionPath, int index) throws UPAException {

        if (Strings.isNullOrEmpty(field.getName())) {
            throw new IllegalArgumentException("Field name is Null or Empty");
        }
        if (field.getDataType() == null) {
            //may be a foreign reference,
            //data typecould not be resolved at creation time
            //throw new IllegalArgumentException("Field " + getName()+"."+field.getName() + " has null DataType");
        } else if (field.getUserModifiers().contains(UserFieldModifier.ID) && field.getDataType().isNullable()) {
            log.log(Level.WARNING, "Field {0}.{1} is ID but has nullable Type. Forced to non nullable (type reference changed).", new Object[]{getName(), field.getName()});
            DataType t = (DataType) field.getDataType().clone();
            t.setNullable(false);
            field.setDataType(t);
        }

        if (field.getPersistFormula() != null
                && !(field.getPersistFormula() instanceof Sequence)
                && field.getDataType() != null
                && !field.getDataType().isNullable()) {
            throw new IllegalArgumentException("Field " + getName() + "."
                    + field.getName() + " is a FORMULA field. Thus it must be nullable");
        }
        FlagSet<UserFieldModifier> modifiersCopy = copy(field.getUserModifiers());
        FlagSet<UserFieldModifier> excludedModifiersCopy = copy(field.getUserExcludeModifiers());
        modifiersCopy.removeAll(excludedModifiersCopy);
        field.setUserModifiers(modifiersCopy);
        field.setUserExcludeModifiers(excludedModifiersCopy);
        //Workaround
        FlagSet<FieldModifier> tt = FlagSets.noneOf(FieldModifier.class);
        if (modifiersCopy.contains(UserFieldModifier.ID)) {
            tt = tt.add(FieldModifier.ID);
        }
        if (modifiersCopy.contains(UserFieldModifier.TRANSIENT)) {
            tt = tt.add(FieldModifier.TRANSIENT);
        }
        if (modifiersCopy.contains(UserFieldModifier.SYSTEM)) {
            tt = tt.add(FieldModifier.SYSTEM);
        }
        ((AbstractField) field).setEffectiveModifiers(tt);

        if (sectionPath == null || sectionPath.length() == 0) {
            DefaultBeanAdapter adapter = UPAUtils.prepare(getPersistenceUnit(), this, field, field.getName());
            addPart(field, index);
        } else {
            DefaultBeanAdapter adapter = UPAUtils.prepare(getPersistenceUnit(), this, field, field.getName());
            getSection(sectionPath, MissingStrategy.CREATE).addPart(field, index);
        }
        invalidateStructureCache();
        return field;
    }

    protected void beforePartAdded(EntityPart parent, EntityPart part, int index) throws UPAException {
        if (part instanceof Field) {
            if (part.getName() == null || part.getName().length() == 0) {
                throw new UPAException(new I18NString("InvalidNameException"), "Field with no name for " + getName());
            }
            Field field = (Field) part;
            if (field.getPersistFormula() != null
                    && !(field.getPersistFormula() instanceof Sequence)
                    && (field.getDefaultObject() == null || field.getDefaultObject() instanceof CustomDefaultObject)
                    && !field.getUserModifiers().contains(UserFieldModifier.TRANSIENT)
                    && !(field.getUserModifiers().contains(UserFieldModifier.ID))
                    && field.getDataType() != null
                    && !field.getDataType().isNullable()) {
                //change type
                DataType t = (DataType) field.getDataType().clone();
                t.setNullable(true);
                field.setDataType(t);
                log.log(Level.WARNING, getName() + "." + field.getName() + " is a formula but is not nullable. Forced to nullable (type reference changed)");
                //throw new UPAException(new I18NString("NoNullableFormulaException", field.getName(), getName()));
            }
            if (fieldsMap.containsKey(getPersistenceUnit().getNamingStrategy().getUniformValue(field.getName()))) {
                throw new ObjectAlreadyExistsException("EntityItemAlreadyExists", field.getName());
            }
        } else if (part instanceof Section) {
            if (part.getName() == null || part.getName().length() == 0) {
                throw new UPAException(new I18NString("InvalidNameException"), "Section for " + getName());
            }
        }
        if (parent == null) {
            EntityPart found = itemsByName.get(part.getName());
            if (found != null) {
                throw new ObjectAlreadyExistsException("EntityItemAlreadyExists", part.getName());
            }
        } else if (parent instanceof Section) {
            Section s = (Section) parent;
            boolean found = false;
            try {
                s.getPart(part.getName());
                found = true;
            } catch (Exception e) {
                //
            }
            if (found) {
                throw new ObjectAlreadyExistsException("EntityItemAlreadyExists", parent.getName());
            }
        } else if (parent instanceof CompoundField) {
            CompoundField s = (CompoundField) parent;
            boolean found = false;
            try {
                s.getField(part.getName());
                found = true;
            } catch (Exception e) {
                //
            }
            if (found) {
                throw new ObjectAlreadyExistsException("EntityItemAlreadyExists", parent.getName());
            }
        }
    }

    public void afterPartAdded(EntityPart parent, EntityPart item, int index) throws UPAException {
        if (item instanceof Field) {
            Field field = (Field) item;
            field.addObjectListener(objListener);

        } else if (item instanceof Section) {
            Section section = (Section) item;
            section.addObjectListener(objListener);
        }
        //reset fieldsByFilter
        fieldsByFilter.clear();
    }

    //    public PrimitiveField addField(String name, FlagSet<UserFieldModifier> modifiers, Formula alias, Object defaultValue,
//                                   DataType type) throws UPAException {
//        PrimitiveField f = createField(name, modifiers, alias, defaultValue, type);
//        addField(f);
//        return f;
//    }
//
//    public PrimitiveField addField(String name, FlagSet<UserFieldModifier> modifiers, String alias, Object defaultValue,
//                                   DataType type) throws UPAException {
//        PrimitiveField f = createField(name, modifiers, alias, defaultValue, type);
//        addField(f);
//        return f;
//    }
//    public PrimitiveField createField(String name, FlagSet<UserFieldModifier> modifiers, String formula, Object defaultValue, DataType type) throws UPAException {
//        return createField(name, modifiers, formula == null ? null : new ExpressionFormula(formula), defaultValue, type);
//    }
    @Override
    public Field getMainField() throws UPAException {
        return mainRendererField;
    }

    @Override
    public String getMainFieldValue(Object o) throws UPAException {
        Field mf = getMainField();
        if (mf == null) {
            return null;
        }
        Object v = getBuilder().entityToRecord(o, false).getObject(mf.getName());
        if (v == null) {
            return null;
        }
        return String.valueOf(v);
    }

    @Override
    public EntityNavigator getNavigator() throws UPAException {
        if (navigator == null) {
            navigator = createNavigator();
        }
        return navigator;
    }

    public void setNavigator(EntityNavigator newNavigator) {
        this.navigator = newNavigator;
    }

    protected EntityNavigator createNavigator() throws UPAException {
        List<Field> pf = getPrimaryFields();
        if (pf.size() == 1) {
            Field field = pf.get(0);
            Class idClass = field.getDataType().getPlatformType();
            if (String.class.equals(idClass)) {
                String sn = this.getShortName();
                if (sn == null) {
                    sn = getName();
                }
                if (field.getPersistFormula() instanceof Sequence) {
                    Sequence a = (Sequence) field.getPersistFormula();
                    String format = a.getFormat();
                    if (format == null) {
                        format = sn + "{#}";
                    }
                    String name = a.getName();
                    if (name == null) {
                        name = field.getEntity().getName() + "." + field.getName();
                    }
                    return EntityNavigatorFactory.createStringSequenceNavigator(this, name, format, a.getGroup(), a.getInitialValue(), a.getAllocationSize());
                } else {
                    String format = sn + "{#}";
                    return EntityNavigatorFactory.createStringSequenceNavigator(this, this.getName(), format, null, 1, 1);
                }
                //return DefaultEntityNavigator.STRING;
            } else if (PlatformUtils.isInt32(idClass)) {
                return EntityNavigatorFactory.createIntegerNavigator(this);
            } else if (PlatformUtils.isInt64(idClass)) {
                return EntityNavigatorFactory.createLongNavigator(this);
            } else {
                return EntityNavigatorFactory.createDefaultNavigator(this);
            }
        } else {
            return EntityNavigatorFactory.createDefaultNavigator(this);
        }
    }

    private Field createField(FieldDescriptor fieldDescriptor) {
        Field f = null;
        if (fieldDescriptor.getDataType() instanceof CompoundDataType) {
            f = new DefaultCompoundField();
        } else {
            f = new DefaultPrimitiveField();
        }
        f.setName(fieldDescriptor.getName());
        f.setDefaultObject(fieldDescriptor.getDefaultObject());
        f.setDataType(fieldDescriptor.getDataType());
        f.setUserModifiers(fieldDescriptor.getUserFieldModifiers());
        f.setUserExcludeModifiers(fieldDescriptor.getUserExcludeModifiers());

        PropertyAccessType propertyAccessType = fieldDescriptor.getPropertyAccessType();
        if (PlatformUtils.isUndefinedValue(PropertyAccessType.class, propertyAccessType)) {
            propertyAccessType = PropertyAccessType.PROPERTY;
        }
        f.setPropertyAccessType(propertyAccessType);
        if (fieldDescriptor.getFieldParams() != null) {
            for (Map.Entry<String, Object> e : fieldDescriptor.getFieldParams().entrySet()) {
                f.getProperties().setObject(e.getKey(), e.getValue());
            }
        }
        DataTypeTransform t = getPersistenceUnit().getTypeTransformFactory().createTypeTransform(getPersistenceUnit(), fieldDescriptor.getDataType(), fieldDescriptor.getTypeTransform());
//        if (t == null) {
//            t = new IdentityDataTypeTransform(fieldDescriptor.getDataType());
//        }
        f.setTypeTransform(t);
        f.setPersistFormula(fieldDescriptor.getPersistFormula());
        f.setPersistFormulaOrder(fieldDescriptor.getPersistFormulaOrder());
        f.setUpdateFormula(fieldDescriptor.getUpdateFormula());
        f.setUpdateFormulaOrder(fieldDescriptor.getUpdateFormulaOrder());
        f.setSelectFormula(fieldDescriptor.getSelectFormula());
        f.setPersistAccessLevel(fieldDescriptor.getPersistAccessLevel());
        f.setUpdateAccessLevel(fieldDescriptor.getUpdateAccessLevel());
        f.setReadAccessLevel(fieldDescriptor.getReadAccessLevel());
        if (f instanceof DefaultCompoundField) {
            DefaultCompoundField cf = (DefaultCompoundField) f;

            CompoundDataType d = (CompoundDataType) getDataType();
            FieldDescriptor[] composingFields = d.getComposingFields(fieldDescriptor);
            for (FieldDescriptor composingField : composingFields) {
                Field field = createField(composingField);
                cf.addField((PrimitiveField) field);
            }
        }
        return f;
    }

    public Field addField(FieldDescriptor fieldDescriptor) throws UPAException {
        Field f = createField(fieldDescriptor);
        addField(f, fieldDescriptor.getFieldPath(),
                fieldDescriptor.getPosition() == 0 ? -1 : fieldDescriptor.getPosition());
        return f;
    }

    // public Field[] getRendererOrPrimaryFields() {
    // if (rendererOrPrimaryFields == null)
    // rendererOrPrimaryFields = getFields(Field.MAIN_OR_ID);
    // return rendererOrPrimaryFields;
    // }
    // --------------------------------------------------------------------------------------------
    // fields definition
    // --------------------------------------------------------------------------------------------
    // SIMPLE addField
    // -----------------
    public Field addField(String name, String sectionPath, FlagSet<UserFieldModifier> modifiers, Object defaultValue, DataType type) throws UPAException {
        return addField(
                new DefaultFieldDescriptor()
                .setName(name)
                .setFieldPath(sectionPath)
                .setUserFieldModifiers(modifiers)
                .setDefaultObject(defaultValue)
                .setDataType(type)
        );
    }

    public Field addField(String name, String sectionPath, FlagSet<UserFieldModifier> modifiers, FlagSet<UserFieldModifier> excludeModifiers, Object defaultValue, DataType type, int index) throws UPAException {
        return addField(
                new DefaultFieldDescriptor()
                .setName(name)
                .setFieldPath(sectionPath)
                .setUserFieldModifiers(modifiers)
                .setUserExcludeModifiers(excludeModifiers)
                .setDefaultObject(defaultValue)
                .setDataType(type)
                .setPosition(index)
        );
    }

    // ------------------------------------------------------------------------------
    public int getItemsCount() {
        return items.size();
    }

    public int getFieldsCount() {
        return fieldsMap.size();
    }

    @Override
    public String toString() {
        return getName();
    }

    @Override
    public boolean equals(Object other) {
        if (other == null || !(other instanceof DefaultEntity)) {
            return false;
        } else {
            DefaultEntity o = (DefaultEntity) other;
            return getPersistenceUnit().getNamingStrategy().equals(getName(), o.getName());
        }
    }

    public boolean containsField(String key) throws UPAException {
        return fieldsMap.containsKey(getPersistenceUnit().getNamingStrategy().getUniformValue(key));
    }

    public List<DynamicField> getDynamicFields() throws UPAException {
        return PlatformUtils.emptyList();
    }

    //    public Field getField(int i) throws UPAException {
//        return fieldsList.get(i);
//    }
    public PrimitiveField getPrimitiveField(String fieldName) throws UPAException {
        return (PrimitiveField) getField(fieldName);
    }

    public PrimitiveField findPrimitiveField(String fieldName) throws UPAException {
        return (PrimitiveField) findField(fieldName);
    }

    public Field getField(int index) throws UPAException {
        int i = 0;
        for (Field value : fieldsMap.values()) {
            if (i == index) {
                return value;
            }
            i++;
        }
        throw new ArrayIndexOutOfBoundsException(index);
    }

    public Field getField(String fieldName) throws UPAException {
        revalidateStructure();
        Field f = fieldsMap.get(getPersistenceUnit().getNamingStrategy().getUniformValue(fieldName));
        if (f != null) {
            return f;
        }
//            ExtendedField p = (ExtendedField) mappedCompoundFields.get(getPersistenceUnit().getNamesComparator().getUniformValue(fieldName));
//            if (p == null) {
//            Log.dev_warning(getName() + " : ExtendedField : " + "Neither Field nor compound field " + fieldName + " was found in Entity " + getName());
        throw new NoSuchElementException("Neither Field nor compound field " + fieldName + " was found in Entity " + getName());
//            }
//            return p;
    }

    public Field findField(String fieldName) throws UPAException {
        revalidateStructure();
        return fieldsMap.get(getPersistenceUnit().getNamingStrategy().getUniformValue(fieldName));
    }

    public List<Field> getPrimaryFields() throws UPAException {
        return getFields(ID);
    }

    // public Field[] getViewFields() {
    // return getFields(Field.VIEW);
    // }
    //
    // public Field[] getForeignFields() {
    // return getFields(Field.defineForeign);
    // }
    //
    // public Field[] getDBReadableFields() {
    // if (dbReadableFields == null)
    // dbReadableFields = getFields(Field.READABLE);
    // return dbReadableFields;
    // }
    //
    // public Field[] getPersistentNonFormulaFields() {
    // if (cache_persistentNonFormulaFields == null)
    // cache_persistentNonFormulaFields =
    // getFields(Field.PERSISTENT_NON_FORMULA);
    // return cache_persistentNonFormulaFields;
    // }
    //
    // public Field[] getPersistentFields() {
    // if (cache_persistentFields == null)
    // cache_persistentFields = getFields(Field.PERSISTENT);
    // return cache_persistentFields;
    // }
    public List<String> getFieldNames(FieldFilter fieldFilter) throws UPAException {
        List<Field> f = getFields(fieldFilter);
        List<String> s = new ArrayList<String>(f.size());
        for (Field field : f) {
            s.add(field.getName());
        }
        return s;
    }

    //    public List<Field> getExtendedFields(FieldFilter fieldFilter) {
//        List<PrimitiveField> f = getPrimitiveFields(fieldFilter);
//        List<Field> v = new ArrayList<Field>(f.size());
//        for (PrimitiveField fi : f) {
//            if (fi.getParent() instanceof CompoundField) {
//                CompoundField c = (CompoundField) fi.getParent();
//                if (c.getLeadingField().equals(fi)) {
//                    v.add(c);
//                }
//            } else {
//                v.add(fi);
//            }
//        }
//        return v;
//    }
//    public ExtendedField[] getExtendedFields(FieldFilter fieldFilter) {
//        return getExtendedField(fieldFilter,false);
//    }
    public List<Field> getFields(FieldFilter fieldFilter) throws UPAException {
        revalidateStructure();
        if (fieldFilter == null) {
            return getFields();
        }
        List<Field> c = fieldsByFilter.get(fieldFilter);
        List<Field> e = new ArrayList<Field>(fieldsMap.size());
        if (c == null) {
            for (Field field : fieldsMap.values()) {
                if (fieldFilter.accept(field)) {
                    e.add(field);
                }
            }
            c = new ArrayList<Field>(e);
            fieldsByFilter.put(fieldFilter, c);
            if (fieldFilter.acceptDynamic()) {
                for (DynamicField df : getDynamicFields()) {
                    if (fieldFilter.accept(df)) {
                        e.add(df);
                    }
                }
                c = e;
            }
        } else if (fieldFilter.acceptDynamic()) {
            e = new ArrayList<Field>(c);
            for (DynamicField df : getDynamicFields()) {
                if (fieldFilter.accept(df)) {
                    e.add(df);
                }
            }
            c = e;
        }
        return c;
    }

    public List<PrimitiveField> getPrimitiveFields(FieldFilter fieldFilter) throws UPAException {
        ArrayList<PrimitiveField> primitiveFields = new ArrayList<PrimitiveField>();
        for (Field f : getFields(Fields.primitive().and(fieldFilter))) {
            primitiveFields.add((PrimitiveField) f);
        }
        return primitiveFields;
    }

    //    public int indexOfField(String key) throws UPAException {
//        NamingStrategy comp = getPersistenceUnit().getNamingStrategy();
//        String k = comp.getUniformValue(key);
//        for (int i = 0; i < fieldsList.size(); i++) {
//            if (comp.getUniformValue(fieldsList.get(i).getName()).equals(k)) {
//                return i;
//            }
//        }
//        return -1;
//    }
    // public Table setModifiers(String pfields, int criteria) {
    // String pk[] = Arrays2.toStringArray(pfields, ",; /:");
    // for (int i = 0; i < pk.length; i++) {
    // Field f = getField(pk[i]);
    // if (f != null)
    // f.setModifiers(criteria);
    // else
    // throw new NoSuchElementException("field " + pk[i] + " not found in entity " +
    // name);
    // }
    //
    // return this;
    // }
//    public void printRecord(K key, PrintRecordPreferences preferences)
//            throws UPAException, PrintException {
//
//        //new HtmlRecordReporter(getPersistenceUnit().getApplication()).showReport(this, key);
//        // throw new UnsupportedOperationException(
//        // getResources().getGeneric("RecordEditor.*.printRecord.unsupported",getName())
//        // );
//    }
    public Object cloneRecord(Object oldId, Object newId) throws UPAException {
        if (isCheckSecurity()) {
            getShield().checkClone(oldId, newId);
        }
        Object o = createQueryBuilder().setId(oldId).setFieldFilter(COPY_ON_CLONE).getEntity();
        getBuilder().setEntityId(o, newId);
        persist(o);
        return o;
    }

    protected boolean isCheckSecurity() throws UPAException {
        Session currentSession = getPersistenceUnit().getPersistenceGroup().getCurrentSession();
        return (currentSession == null) || !getPersistenceUnit().isSystemSession(currentSession);
    }

    public Object rename(Object oldId, Object newId) throws UPAException {
        if (isCheckSecurity()) {
            getShield().checkRename(oldId, newId);
        }
        EntityExecutionContext context = createContext(ContextOperation.RENAME);
//        Object tranasction = getPersistenceUnit().getPersistenceStore().getConnection().tryBeginTransaction();
//        boolean transactionSucceeded = false;
//        try {
        Object o = createQueryBuilder().setId(oldId).setFieldFilter(COPY_ON_RENAME).getEntity();
        Record ur = getBuilder().entityToRecord(o, false);
        getBuilder().setRecordId(ur, newId);
        // insert(o, false);
        Object[] newIdValues = getBuilder().idToKey(newId).getValue();
        Object[] oldIdValues = getBuilder().idToKey(oldId).getValue();
        persistCore(ur, context);
        for (Relationship r : getPersistenceUnit().getRelationshipsForTarget(this)) {
            if (!r.getSourceRole().getEntity().equals(r.getTargetRole().getEntity()) && !r.isTransient()) {
                Record updates = r.getSourceRole().getEntity().getBuilder().createRecord();
                Expression condition = null;
                List<Field> lfields = r.getSourceRole().getFields();
                for (int j = 0; j < lfields.size(); j++) {
                    Field lf = lfields.get(j);
                    updates.setObject(lf.getName(), newIdValues[j]);
                    Expression e = new Equals(new Var(lf.getName()),
                            new Literal(oldIdValues[j], lf.getDataType()));
                    condition = condition == null ? e : new And(condition, e);
                }

                try {
                    // r.getDetailsTable().updateAllRecords(updates,
                    // condition, check);
                    r.getSourceRole().getEntity().updateCore(updates, condition, context);
                } catch (UpdateRecordKeyNotFoundException e) {
                    // if no updates no matter
                }
            }
        }

        // remove(toExpression(oldId, null),
        // getPersistenceUnit().isRecurseDelete(), false, new RemoveTrace());
        removeCore(getBuilder().idToExpression(oldId, null), getPersistenceUnit().isRecurseDelete(), new DefaultRemoveTrace(), context);
//        transactionSucceeded = true;
//        return o;
//    }
//
//    finally
//
//    {
//        getPersistenceUnit().getPersistenceStore().getConnection().tryFinalizeTransaction(
//                transactionSucceeded, tranasction);
//    }
        return o;
    }

    public Object getNextId(Object id) throws UPAException {
        return (Object) getNavigator().getNextKey(id);
    }

    public Object getFirstId() throws UPAException {
        return (Object) getNavigator().getFirstKey();
    }

    public Object getLastId() throws UPAException {
        return (Object) getNavigator().getLastKey();
    }

    public Object getPreviousId(Object id) throws UPAException {
        return (Object) getNavigator().getPreviousKey(id);
    }

    public boolean hasNext(Object id) throws UPAException {
        return getNextId(id) != null;
    }

    public boolean hasPrevious(Object id) throws UPAException {
        return getPreviousId(id) != null;
    }

    public boolean isEmpty() throws UPAException {
        return (getFirstId() == null);
    }

    public long getEntityCount() throws UPAException {
        Record record = createQuery(new Select().field(new Count(Literal.IONE))).getRecord();
        return record.getLong();
//        return find(new Select().field(new Count(Literal.IONE))).getNumber().longValue();
    }

    public long getEntityCount(Expression booleanExpression)
            throws UPAException {
        Number n = createQuery((new Select()).from(getName()).field(new Count(new Literal(1))).where(booleanExpression)).getNumber();
        return n == null ? -1L : n.longValue();
    }

    public <K> K nextId() throws UPAException {
        return (K) getNavigator().getNewKey();
    }

    public Expression parentToChildExpression(Expression parentExpression) throws UPAException {
        if (parentExpression == null) {
            return null;
        }
        Relationship r = getCompositionRelation();
        Select s = new Select().from(r.getTargetRole().getEntity().getName()).where(parentExpression);
        List<Field> df = r.getSourceRole().getFields();
        List<Field> mf = r.getTargetRole().getFields();
        if (df.size() == 1) {
            s.field(new Var(mf.get(0).getName()));
            return new InSelection(new Var(df.get(0).getName()), s);
        } else {
            Var[] mv = new Var[mf.size()];
            for (int i = 0; i < mf.size(); i++) {
                mv[i] = new Var(mf.get(i).getName());
            }

            Var[] dv = new Var[df.size()];
            for (int i = 0; i < df.size(); i++) {
                dv[i] = new Var(df.get(i).getName());
            }

            s.field(new Uplet(dv));
            return new InSelection(new Uplet(mv), s);
        }
    }

    public Expression childToParentExpression(Expression childExpression) throws UPAException {
        if (childExpression == null) {
            return null;
        }
        Select s = new Select().from(getName()).where(childExpression);
        Relationship r = getCompositionRelation();
        List<Field> df = r.getSourceRole().getFields();
        List<Field> mf = r.getTargetRole().getFields();
        if (df.size() == 1) {
            s.field(new Var(df.get(0).getName()));
            return new InSelection(new Var(mf.get(0).getName()), s);
        } else {
            Var[] dv = new Var[df.size()];
            for (int i = 0; i < df.size(); i++) {
                dv[i] = new Var(df.get(i).getName());
            }

            Var[] mv = new Var[mf.size()];
            for (int i = 0; i < mf.size(); i++) {
                mv[i] = new Var(mf.get(i).getName());
            }

            s.field(new Uplet(mv));
            return new InSelection(new Uplet(dv), s);
        }
    }

    public Expression childToParentExpression(Record child) throws UPAException {
        Relationship r = getCompositionRelation();
        final Field sf = r.getSourceRole().getEntityField();
        List<Field> df = r.getSourceRole().getFields();
        List<Field> mf = r.getTargetRole().getFields();
        if (sf != null) {
            EntityBuilder tb = r.getTargetEntity().getBuilder();
            return tb.idToExpression(tb.entityToId(child.getObject(sf.getName())), null);
        } else if (df.size() == 1) {
            return new Equals(new Var(mf.get(0).getName()), child.getObject(df.get(0).getName()));
        } else {
            Expression a = null;
            for (int i = 0; i < df.size(); i++) {
                Expression e = new Equals(new Var(mf.get(i).getName()), child.getObject(df.get(i).getName()));
                a = a == null ? e : new And(a, e);
            }
            return a;
        }
    }

    @Override
    public RemoveTrace remove(RemoveOptions options)
            throws UPAException {
        Expression expression = objToExpression(options);
        boolean recurse = options.isFollowLinks();
        boolean simulate = options.isSimulate();
        RemoveTrace removeInfo = options.getRemoveTrace();
        if (removeInfo == null) {
            removeInfo = new DefaultRemoveTrace();
            options.setRemoveTrace(removeInfo);
        }
        Relationship relation = options.getFollowRelationship();

        expression = simplifyExpression(expression);
        if (isCheckSecurity()) {
            getShield().checkRemove(expression, recurse);
        }
        EntityExecutionContext removeExecContext = createContext(simulate ? ContextOperation.REMOVE_SIMULATION : ContextOperation.REMOVE);
//        Object tranasction = null;
//        boolean transactionSucceeded = false;
        if (!simulate) {
//            tranasction = getPersistenceUnit().getPersistenceStore().getConnection().tryBeginTransaction();
            recordListenerSupport.fireBeforeRemove(expression, removeExecContext);
        }
        try {
            String trace = "remove(" + getName() + "," + expression
                    + "), simulate=" + simulate + ",recurse=" + recurse
                    + ",relation=" + relation;
            // System.out.println(trace);
            removeInfo.addTrace(trace);
            long actualReturnCount = getEntityCount(expression);
            CacheFile cache = new CacheFile();
            if (recurse && actualReturnCount > 0) {
                for (Relationship r : getPersistenceUnit().getRelationshipsForTarget(this)) {
                    if (r.isTransient()) {
                        continue;
                    }
                    Field masterField = r.getTargetRole().getField(0);
                    if (r.getRelationshipType() == RelationshipType.SHADOW_ASSOCIATION) {
                        if (!simulate) {
                            Record updates = getBuilder().createRecord();
                            List<Field> fls = r.getSourceRole().getFields();
                            for (Field fl : fls) {
                                updates.setObject(fl.getName(), fl.getDefaultValue());
                            }
                            Expression rightCondition = null;
                            if (r.size() == 1) {
                                Field ff = r.getSourceRole().getField(0);
                                rightCondition = new InSelection(new Var(ff.getName()),
                                        (new Select()).from(r.getTargetRole().getEntity().getName())
                                        .field(new Var(masterField.getName())).where(expression));
                            } else {
                                Var[] lvars = new Var[r.size()];
                                Var[] rvars = new Var[r.size()];
                                for (int x = 0; x < lvars.length; x++) {
                                    lvars[x] = new Var(r.getSourceRole().getField(x).getName());
                                    lvars[x] = new Var(r.getTargetRole().getField(x).getName());
                                }
                                rightCondition = new InSelection(lvars,
                                        (new Select()).from(
                                                r.getTargetRole().getEntity().getName()).uplet(rvars).where(expression));
                            }
                            int updatedRecords = r.getSourceRole().getEntity().updateRecords(updates, rightCondition);// no check !!
                            if (updatedRecords > 0) {
                                List<Object> loadedKeys = r.getSourceRole().getEntity().createQueryBuilder().setExpression(rightCondition).setOrder(getUpdateFormulasOrder()).getIdList();
                                if (r.getSourceRole().getField(0).getUpdateFormula() != null && loadedKeys.size() > 0) {
                                    cache.write(r.getName());
                                    cache.write(loadedKeys);
                                }
                            }
                        }
                    } else {
                        trace = "To remove " + getName()
                                + " use first relation " + r;
                        // System.out.println(trace);
                        removeInfo.addTrace(trace);
                        r.getSourceRole().getEntity().remove(
                                RemoveOptions.forExpression(((new InSelection(new Var(r.getSourceRole().getField(0).getName()),
                                        (new Select()).from(r.getTargetRole().getEntity().getName())
                                        .field(new Var(masterField.getName())).where(expression)))))
                                .setFollowLinks(true)
                                .setSimulate(simulate)
                                .setRemoveTrace(removeInfo)
                                .setFollowRelationship(r));
                    }
                }

            }
            cache.close();
            if (!simulate) {
                actualReturnCount = removeCore(expression, recurse, removeInfo, removeExecContext);
            }
            removeInfo.add(relation != null ? relation.getRelationshipType() : RelationshipType.SHADOW_ASSOCIATION, this, actualReturnCount);
            while (cache.hasNext()) {
                Relationship rel = getPersistenceUnit().getRelationship((String) cache.read());
                Object[] keys = (Object[]) cache.read();
                Var[] lvars = new Var[rel.size()];
                for (int x = 0; x < lvars.length; x++) {
                    lvars[x] = new Var(rel.getSourceRole().getField(x).getName());
                }
                IdCollectionExpression inCollection = new IdCollectionExpression(lvars);
                for (Object key : keys) {

                    inCollection.add(((Object) (getBuilder().idToKey(key).getValue())));
                }

                if (rel.size() == 1) {
                    InCollection inColl = new InCollection(new Param(null, rel.getSourceRole().getField(0)));
                    for (Object key : keys) {
                        inColl.add(new Literal(getBuilder().idToKey(key).getObjectAt(0), rel.getSourceRole().getField(0).getDataType()));
                    }
                    rel.getSourceRole().getEntity().updateFormulasCore(Fields.regular().and(Fields.byList(rel.getSourceRole().getFields())), inColl, removeExecContext);
                } else {
                    Expression[] fuplet = new Expression[rel.size()];
                    for (int y = 0; y < rel.size(); y++) {
                        Field f = rel.getSourceRole().getField(y);
                        fuplet[y] = new Var(f.getName());
                    }

                    InCollection inColl = new InCollection(new Uplet(fuplet));
                    for (int x = 0; x < keys.length; x++) {
                        Expression[] vuplet = new Expression[rel.size()];
                        for (int y = 0; y < rel.size(); y++) {
                            Object key = keys[x];
                            vuplet[x] = ((new Literal(getBuilder().idToKey(key).getValue()[y], rel.getSourceRole().getField(y).getDataType())));
                        }
                        inColl.add(new Uplet(vuplet));
                    }

                    rel.getSourceRole().getEntity().updateFormulasCore(Fields.regular().and(Fields.byList(rel.getSourceRole().getFields())), inColl, removeExecContext);
                }
            }
            cache.close();
            if (!simulate) {
                recordListenerSupport.fireAfterRemove(expression, removeExecContext);
            }
            cache = null;
//            transactionSucceeded = true;
            return removeInfo;
        } finally {
            if (!simulate) {
//                getPersistenceUnit().getPersistenceStore().getConnection().tryFinalizeTransaction(transactionSucceeded, tranasction);
            }
        }
    }

    public int removeCore(Expression condition, boolean recurse, RemoveTrace removeInfo, EntityExecutionContext executionContext) throws UPAException {
        EntityRemoveOperation a = getEntityOperationManager().getRemoveOperation();
        if (a != null) {
            return a.delete(this, createContext(ContextOperation.REMOVE), condition, recurse, removeInfo);
        }
        return 0;
    }

    public boolean save(Object objectOrRecord)
            throws UPAException {
        EntityBuilder builder = getBuilder();
        Record rec = builder.getRecord(objectOrRecord);
        Object entityToId = builder.recordToId(rec);
        if (entityToId == null || getEntityCount(builder.idToExpression(entityToId, null)) == 0) {
            persist(objectOrRecord);
            return true;
        } else {
            update(objectOrRecord);
            return false;
        }
    }

    public void persist(Object objectOrRecord) throws UPAException {
        Record record = getBuilder().getRecord(objectOrRecord, true);
        if (isCheckSecurity()) {
            getShield().checkPersist(record);
        }
        EntityExecutionContext context = createContext(ContextOperation.PERSIST);
        Object prePersistId = getBuilder().recordToId(record);
        recordListenerSupport.fireBeforePersist(prePersistId, record, context);

        persistCore(record, context);
        Object postPersistId = getBuilder().recordToId(record);
        if (getShield().isUpdateFormulaOnPersistSupported()) {
            Expression expr = getBuilder().idToExpression(postPersistId, null);
//            expr.setClientProperty(EXPRESSION_SURELY_EXISTS, true);
            updateFormulasCore(PERSIST_FORMULA, expr, context);
            final Record formulaValues = createQueryBuilder().setExpression(expr).setFieldFilter(PERSIST_FORMULA).getRecord();
            record.setAll(formulaValues);
        }
        recordListenerSupport.fireAfterPersist(postPersistId, record, context);
//                transactionSucceeded = true;
//            } finally {
//                getPersistenceUnit().getPersistenceStore().getConnection().tryFinalizeTransaction(transactionSucceeded,
//                        transaction);
//            }
    }

    @Override
    public void initialize() throws UPAException {
        if (isCheckSecurity()) {
            getShield().checkInitialize();
        }
        EntityExecutionContext context = createContext(ContextOperation.INITIALIZE);
        recordListenerSupport.fireBeforeInitialize(context);
        initializeCore(context);
        recordListenerSupport.fireAfterInitialize(context);
    }

    @Override
    public void clear() throws UPAException {
        if (isCheckSecurity()) {
            getShield().checkClear();
        }
        EntityExecutionContext context = createContext(ContextOperation.CLEAR);
        recordListenerSupport.fireBeforeClear(context);
        clearCore(context);
        recordListenerSupport.fireAfterClear(context);
    }

//    @Override
//    public void reset() throws UPAException {
//        if (isCheckSecurity()) {
//            getShield().checkReset();
//        }
//        EntityExecutionContext context = createContext(ContextOperation.RESET);
//        recordListenerSupport.fireBeforeReset(context);
//        resetCore(context);
//        recordListenerSupport.fireAfterReset(context);
//    }
    public Expression getUnicityExpressionForPersist(Object entity) throws UPAException {
        Object key = getBuilder().entityToId(entity);
        Record urecord = getBuilder().entityToRecord(entity, false);
        List<Index> uniqueIndexes = getIndexes(true);
        if (uniqueIndexes.isEmpty()) {
            return getBuilder().idToExpression(key, null);
        }
        Expression or = getBuilder().idToExpression(key, null);
        for (Index index : uniqueIndexes) {
            Field[] f = index.getFields();
            Expression e1 = null;
            if (f.length == 1) {
                e1 = new Equals(new Var(f[0].getName()), ExpressionFactory.toLiteral(urecord.getObject(f[0].getName())));
            } else {
                Expression a = null;
                for (Field aF : f) {
                    Expression e = (new Equals(new Var(aF.getName()), ExpressionFactory.toLiteral(urecord.getObject(aF.getName()))));
                    a = a == null ? e : new And(a, e);
                }
                e1 = a;
            }
            or = or == null ? e1 : new Or(or, e1);
        }
        return or;
    }

    //    protected void preInsertRecord(K key1, Record record1,
//                                   ExecutionContext executioncontext) throws UPAException {
//    }
    public boolean containsCompoundFields() {
        for (Field extendedField : fieldsMap.values()) {
            if (extendedField instanceof CompoundField) {
                return true;
            }
        }
        return false;
    }

    //    public R getPrimitiveRecord(R values) {
//        if (containsCompoundFields()) {
//            R newRecord = createEntity();
//            for (Map.Entry entry : values.entrySet()) {
//                String fieldName = (String) entry.getKey();
//                Object fieldValue = entry.getValue();
//                Field ef = getField(fieldName);
//                if (ef instanceof CompoundField) {
//                    CompoundField cf = (CompoundField) ef;
//                    PrimitiveField[] cfs = cf.getPrimitiveFields();
//                    Object[] cfs_values = cf.getPrimitiveValues(fieldValue);
//                    for (int j = 0; j < cfs.length; j++) {
//                        newRecord.put(cfs[j].getName(),
//                                cfs_values == null ? null : cfs_values[j]);
//                    }
//                } else {
//                    newRecord.put(fieldName, ef.getDataType().convert(fieldValue));
//                }
//            }
//            return newRecord;
//        } else {
//            R newRecord = createEntity();
//            Set<Map.Entry> entrySet = values.entrySet();
//            for (Map.Entry entry : entrySet) {
//                String fieldName = (String) entry.getKey();
//                Object fieldValue = entry.getValue();
//                newRecord.put(fieldName, getPrimitiveField(fieldName).getDataType().convert(fieldValue));
//            }
//            return newRecord;
//        }
//    }
//
//    public R getNonPrimitiveRecord(R values) {
//        if (containsCompoundFields()) {
//            R newRecord = createEntity();
//            for (Iterator i = values.entrySet().iterator(); i.hasNext(); ) {
//                Map.Entry entry = (Map.Entry) i.next();
//                String fieldName = (String) entry.getKey();
//                Object fieldValue = entry.getValue();
//                Field ef = getField(fieldName);
//                if (ef instanceof CompoundField) {
//                    newRecord.put(fieldName, fieldValue);
//                } else {
//                    EntityPart entityPart = ef.getParent();
//                    if (entityPart == null || entityPart instanceof Section) {
//                        newRecord.put(fieldName, fieldValue);
//                    } else {
//                        CompoundField cf = (CompoundField) entityPart;
//                        if (!newRecord.containsKey(cf.getName())) {
//                            PrimitiveField[] cfs = cf.getPrimitiveFields();
//                            if (fieldValue == null) {
//                                newRecord.put(cf.getName(), null);
//                            } else {
//                                Object[] cfs_values = new Object[cfs.length];
//                                for (int j = 0; j < cfs.length; j++) {
//                                    cfs_values[j] = values.get(cfs[j].getName());
//                                }
//                                newRecord.put(cf.getName(), cf.getCompoundObject(cfs_values));
//                            }
//                        }
//                    }
//                }
//            }
//            return newRecord;
//        } else {
//            return values;
//        }
//    }
    public void persistCore(Record record, EntityExecutionContext executionContext) throws UPAException {

        for (FieldPersistenceInfo gen : fieldListPersistenceInfo.persistSequenceGeneratorFields) {
            gen.persistFieldPersister.beforePersist(record, executionContext);
        }

        LinkedHashSet<Field> persistNonNullable = new LinkedHashSet<Field>(getFields(FIELD_FILTER_PERSIST_NON_NULLABLE));
        LinkedHashSet<Field> persistWithDefaultValue = new LinkedHashSet<Field>(getFields(FIELD_FILTER_PERSIST_WITH_DEFAULT_VALUE));
        LinkedHashSet<Field> emptySet = new LinkedHashSet<Field>();
        DefaultRecord persistentRecord = new DefaultRecord();
        for (Map.Entry<String, Object> entry : record.toMap().entrySet()) {
            Object value = entry.getValue();
            String key = entry.getKey();

            //check if the field exists in the entity
            Field field = findField(key);
            if (field != null) {
                //make handled
                persistNonNullable.remove(field);
                persistWithDefaultValue.remove(field);
                boolean accepted = FIELD_FILTER_PERSIST.accept(field);
                if (accepted) {
                    ((AbstractField) field).getFieldPersister().prepareFieldForPersist(field, value, record, persistentRecord, executionContext, persistNonNullable, persistWithDefaultValue);
                }
            }
        }

        //add default values
        for (Field field : persistWithDefaultValue) {
            Object value = field.getDefaultValue();
            if (value == null) {
                if (!field.getDataType().isNullable()) {
                    value = field.getDataType().getDefaultNonNullValue();
                }
            }
            record.setObject(field.getName(), value);
            ((AbstractField) field).getFieldPersister().prepareFieldForPersist(field, value, record, persistentRecord, executionContext, persistNonNullable, emptySet);
        }

        getEntityOperationManager().getPersistOperation().insert(this, record, persistentRecord, executionContext);
        for (FieldPersistenceInfo gen : fieldListPersistenceInfo.persistSequenceGeneratorFields) {
            gen.persistFieldPersister.afterPersist(record, executionContext);
        }
    }

    //    protected void postInsertRecord(K key, Record record,
//                                    ExecutionContext executioncontext) throws UPAException {
//    }
    public void updateRecord(Record updates, Key key) throws UPAException {
        updateRecords(updates, getBuilder().idToExpression(getBuilder().keyToId(key), null));
    }

    public void update(Object objectOrRecord) throws UPAException {
        EntityBuilder builder = getBuilder();
        Record record = builder.getRecord(objectOrRecord, false);
        Object k = builder.recordToId(record);
        if (k == null) {
            throw new UPAException("IdNotFoundException", this.getName());
        }
        updateRecords(record, builder.idToExpression(k, getName()));
        if (getShield().isUpdateFormulaOnUpdateSupported()) {
            //need reload formua fields
            List<Field> fields = getFields(UPDATE_FORMULA);
            if (fields != null && fields.size() > 0) {
                final Record generatedFormulas = createQueryBuilder().setFieldFilter(Fields.regular().and(Fields.byList(fields))).getRecord();
                if (generatedFormulas != null) {
                    record.setAll(generatedFormulas);
                }
            }
        }
    }

    public void merge(Object objectOrRecord) throws UPAException {
        update(objectOrRecord);
    }

    public void updatePartial(Object objectOrRecord) throws UPAException {
        update(getBuilder().getRecord(objectOrRecord, true));
    }

    public void updatePartial(Object objectOrRecord, Object id) throws UPAException {
//        Object transaction = getPersistenceUnit().getPersistenceStore().getConnection().tryBeginTransaction();
//        boolean transactionSucceeded = false;
//        try {
        updateRecords(getBuilder().getRecord(objectOrRecord, true), getBuilder().idToExpression(id, null));
//            // if (isValidateOnUpdateSupported())
//            // updateFormulas(VALIDATABLE_ON_UPDATE_STORED_FORMULA,
//            // key);
//            transactionSucceeded = true;
//        } finally {
//            getPersistenceUnit().getPersistenceStore().getConnection().tryFinalizeTransaction(
//                    transactionSucceeded, transaction);
//        }
    }

    private Expression objToExpression(RemoveOptions idOrExpression) {
        if (idOrExpression == null) {
            throw new UPAException("MissingIdException");
        }
        Expression expr = null;
        EntityBuilder builder = getBuilder();
        switch (idOrExpression.getRemoveType()) {
            case EXPRESSION: {
                expr = ((Expression) idOrExpression.getRemoveCondition());
                break;
            }
            case EXPRESSION_LIST: {

                Expression ll = null;
                for (Expression t : ((List<Expression>) idOrExpression.getRemoveCondition())) {
                    if (ll == null) {
                        ll = t;
                    } else {
                        ll = new Or(ll, t);
                    }
                }
                expr = ll;
                break;
            }
            case ID: {
                expr = builder.idToExpression(idOrExpression.getRemoveCondition(), null);
                break;
            }
            case KEY: {
                expr = builder.keyToExpression((Key) idOrExpression.getRemoveCondition(), null);
                break;
            }
            case OBJECT: {
                expr = builder.idToExpression(builder.entityToId(idOrExpression.getRemoveCondition()), null);
                break;
            }
            case RECORD: {
                Record r = (Record) idOrExpression.getRemoveCondition();
                expr = builder.idToExpression(builder.recordToId(r), null);
                break;
            }
            case PROTOTYPE: {
                expr = builder.entityToExpression(idOrExpression.getRemoveCondition(), true, null);
                break;
            }
            case RECORD_PROTOTYPE: {
                expr = builder.recordToExpression((Record) idOrExpression.getRemoveCondition(), null);
                break;
            }
            case ID_LIST: {
                List<Object> objectList = PlatformUtils.anyObjectToObjectList(idOrExpression.getRemoveCondition());
                expr = builder.idListToExpression(objectList, null);
                break;
            }
            case KEY_LIST: {
                List<Key> anyList = (List<Key>) idOrExpression.getRemoveCondition();
                expr = builder.keyListToExpression(anyList, null);
                break;
            }
        }
        return expr;
    }

    @Override
    public RemoveTrace remove(Object object) throws UPAException {
        if (object == null) {
            throw new UPAException("ObjectNotFoundException");
        } else if (object instanceof RemoveOptions) {
            return remove((RemoveOptions) object);
        } else {
            return remove(RemoveOptions.forObject(object));
        }
    }

    //
    @Override
    public Field[] toFieldArray(String[] s) throws UPAException {
        Field[] f = new Field[s.length];
        for (int i = 0; i < s.length; i++) {
            f[i] = getField(s[i]);
            if (f[i] == null) {
                log.log(Level.WARNING, "field " + s[i] + " not found in " + getName()
                        + "; all fields are : " + fieldsMap.values());
            }
        }

        return f;
    }

    @Override
    public boolean contains(Object key) throws UPAException {
        return key != null && getEntityCount(getBuilder().idToExpression(key, getName())) > 0;
    }

    public int updateRecords(Record updates, Expression condition) throws UPAException {
        List<Field> fields = (getShield().isUpdateFormulaOnUpdateSupported()) ? getFields(UPDATE_FORMULA)
                : null;
        return updateRecords(updates, fields, condition);
    }

    public int updateCore(Record updates, Expression condition, EntityExecutionContext executionContext) throws UPAException {
        return getEntityOperationManager().getUpdateOperation().update(this, createContext(ContextOperation.UPDATE), updates, condition);
    }

    @Override
    public String getIdName(Object id) throws UPAException {
        if (id == null) {
            return null;
        }
        Object[] ukey = getBuilder().idToKey(id).getValue();
        Field f = getMainField();
        if (ukey.length == 1 && f.isId()) {
            return String.valueOf(ukey[0]);
        }

        Object n = createQueryBuilder().setId(id).setFieldFilter(Fields.regular().and(Fields.byList(f))).getSingleValue();
        if (n != null) {
            for (Relationship r : f.getRelationships()) {
                if (r.size() == 1) {
                    Entity entity = r.getTargetRole().getEntity();
                    return entity.getIdName(entity.createId(n));
                }
            }
            return String.valueOf(n);
        }
        return null;
    }

    public EntityExecutionContext createContext(ContextOperation contextOperation) {
        EntityExecutionContext context = getEntityOperationManager().getPersistenceStore().createContext(contextOperation);
        context.initEntity(this, entityOperationManager);
        return context;
    }

    public QueryBuilder createQueryBuilder() throws UPAException {
        DefaultQueryBuilder q = new DefaultQueryBuilder(this);
        boolean lazyListLoadingEnabled = getPersistenceUnit().getProperties().getBoolean("Query.LazyListLoadingEnabled", true);
        q.setLazyListLoadingEnabled(lazyListLoadingEnabled);
        return q;
    }

    @Override
    public Query createQuery(EntityStatement query) throws UPAException {
        if (query instanceof Select) {
            Select s = (Select) query;
            NameOrSelect entityName = s.getEntity();
            if (entityName == null) {
                s.from(getName());
            }
        }
        if (query instanceof QueryStatement) {
            return getEntityOperationManager().getFindOperation().createQuery(this, (QueryStatement) query, createContext(ContextOperation.FIND));
        }
        if (query instanceof Insert) {
            return getEntityOperationManager().getPersistOperation().createQuery(this, (Insert) query, createContext(ContextOperation.PERSIST));
        }
        if (query instanceof Update) {
            return getEntityOperationManager().getUpdateOperation().createQuery(this, (Update) query, createContext(ContextOperation.UPDATE));
        }
        if (query instanceof Delete) {
            return getEntityOperationManager().getRemoveOperation().createQuery(this, (Delete) query, createContext(ContextOperation.REMOVE));
        }
        throw new UnsupportedOperationException("Not supported statement type " + query);
    }

    @Override
    public Query createQuery(String query) throws UPAException {
        Expression e = getPersistenceUnit().getExpressionManager().parseExpression(query);
        if (!(e instanceof QueryStatement)) {
            Select s = new Select();
            s.setWhere(e);
            e = s;
        }
        return createQuery((QueryStatement) e);
    }

    public List<PrimitiveField> getPrimitiveFields(String... fieldNames) throws UPAException {
        if (fieldNames == null) {
            return null;
        }
        if (fieldNames.length == 0) {
            return toPrimitiveFields(getParts());
        }
        if (containsCompoundFields()) {
            List<PrimitiveField> v = new ArrayList<PrimitiveField>(fieldNames.length);
            for (String fieldName : fieldNames) {
                EntityPart entityPart = getField(fieldName);
                if (entityPart instanceof PrimitiveField) {
                    v.add((PrimitiveField) entityPart);
                } else {
                    CompoundField compoundField = (CompoundField) entityPart;
                    List<PrimitiveField> fds = compoundField.getFields();
                    for (PrimitiveField fd : fds) {
                        v.add(fd);
                    }
                }
            }
            return v;
        } else {
            List<PrimitiveField> v = new ArrayList<PrimitiveField>(fieldNames.length);
            for (String fieldName : fieldNames) {
                v.add(getPrimitiveField(fieldName));
            }
            return v;
        }
    }

    @Override
    public List<Field> getValidFields(String... fieldNames) throws UPAException {
        ArrayList<Field> found = new ArrayList<Field>();
        for (String field : fieldNames) {
            Field f = findField(field);
            if (f != null) {
                found.add(f);
            }
        }
        return found;
    }

    public List<Field> getFields(String... fieldNames) throws UPAException {
        if (fieldNames == null) {
            return null;
        }
        if (fieldNames.length == 0) {
            return getFields(getParts());
        }
        List<Field> flds = new ArrayList<Field>(fieldNames.length);
        for (String fieldName : fieldNames) {
            flds.add(getField(fieldName));
        }
        return flds;
    }

    //    public final void updateFormulas(Field[] fieldsToUpdate,
//                                                  K key) throws UPAException {
//        // if (key.getValue().length != getPrimaryFields().length)
//        // throw new UPAException(key + " does not denote a valid key for " +
//        // getName());
//        updateFormulas(fieldsToUpdate, toExpression(key, null));
//    }
//
//    public final void updateFormulas(String[] fieldsToUpdate,
//                                                  Expression expr) throws UPAException {
//        updateFormulas(getPrimitiveFields(fieldsToUpdate), expr);
//    }
//    public void updateFormulas(Field[] fieldsToUpdate,
//                                            Expression expr) throws UPAException {
//        updateFormulas(fieldsToUpdate, expr, null);
//    }
//    public void updateFormulas(FieldFilter fieldFilter,
//                                            Expression expr) throws UPAException {
//        updateFormulas(getFields(fieldFilter), expr, monitor);
//    }
    protected int updateRecords(Record updates,
            List<Field> storedFieldsToValidate, Expression condition)
            throws UPAException {

        //if updates contain primary fields add them to condition
        //because primary fields are not updatable
        //one may use rename instead
        List<Field> extraConditions = new ArrayList<Field>();
        List<Field> primaryFields = getPrimaryFields();
        Set<String> primaryFieldNames = new HashSet<String>();
        for (Field field : primaryFields) {
            if (updates.isSet(field.getName())) {
                extraConditions.add(field);
            }
            primaryFieldNames.add(field.getName());
        }
        if (extraConditions.size() == primaryFields.size()) {
            //all primary are defined
            Expression expression = getBuilder().idToExpression(getBuilder().recordToId(updates), getName());
            if (condition == null || !condition.isValid()) {
                condition = expression;
            } else if (!expression.equals(condition)) {
                condition = new And(condition, expression);
            }
        }

        condition = simplifyExpression(condition);
        if (isCheckSecurity()) {
            getShield().checkUpdate(updates, condition);
        }
//        Object transaction = getPersistenceUnit().getPersistenceStore().getConnection().tryBeginTransaction();
//        boolean transactionSucceeded = false;
//        try {
        EntityExecutionContext executionContext = createContext(ContextOperation.UPDATE);
        int r = -1;
        if (storedFieldsToValidate != null) {
            Record fieldNamesToUpdateMap = getBuilder().createRecord();
            Set<String> cancelUpdates = new HashSet<String>();
            //copy all but primary fields
            for (Map.Entry<String, Object> ee : updates.toMap().entrySet()) {
                String fieldName = ee.getKey();
                if (!primaryFieldNames.contains(fieldName)) {
                    Object value = ee.getValue();
                    Field field = getField(fieldName);
                    ((AbstractField) field).getFieldPersister().prepareFieldForUpdate(field, value, updates, fieldNamesToUpdateMap, executionContext);
                }
            }
            for (String f : cancelUpdates) {
                fieldNamesToUpdateMap.remove(f);
            }
            for (Field field : storedFieldsToValidate) {
                Expression expression = getFieldExpression(field, false);
                fieldNamesToUpdateMap.setObject(field.getName(), expression);
            }
            if (!fieldNamesToUpdateMap.isEmpty()) {
                recordListenerSupport.fireBeforeUpdate(fieldNamesToUpdateMap, condition, executionContext);
                r = updateCore(fieldNamesToUpdateMap, condition, executionContext);
                if (r > 0) {
                    FormulaUpdateProcessor p = new FormulaUpdateProcessor(false, storedFieldsToValidate, condition, executionContext, this, getEntityOperationManager());
                    p.updateFormulasCore();
                }
                recordListenerSupport.fireAfterUpdate(fieldNamesToUpdateMap, condition, executionContext);
            }
        } else {
            Record fieldNamesToUpdateMap = getBuilder().createRecord();
            for (Map.Entry<String, Object> ee : updates.toMap().entrySet()) {
                String fieldName = ee.getKey();
                if (!primaryFieldNames.contains(fieldName)) {
                    Object value = ee.getValue();
                    Field field = getField(fieldName);
                    ((AbstractField) field).getFieldPersister().prepareFieldForUpdate(field, value, updates, fieldNamesToUpdateMap, executionContext);
                }
            }
            if (!fieldNamesToUpdateMap.isEmpty()) {
                recordListenerSupport.fireBeforeUpdate(fieldNamesToUpdateMap, condition, executionContext);
                r = updateCore(fieldNamesToUpdateMap, condition, executionContext);
                recordListenerSupport.fireAfterUpdate(fieldNamesToUpdateMap, condition, executionContext);
            }
        }

//            transactionSucceeded = true;
        return r;
//        } finally {
//            getPersistenceUnit().getPersistenceStore().getConnection().tryFinalizeTransaction(
//                    transactionSucceeded, transaction);
//        }
    }

    @Override
    public void updateFormulasById(FieldFilter filter, Object id) throws UPAException {
        updateFormulas(filter, getBuilder().idToExpression(id, getName()));
    }

    public void updateFormulas(FieldFilter fieldFilter, Expression expr) throws UPAException {
        EntityExecutionContext context = createContext(ContextOperation.VALIDATE);
        updateFormulasCore(fieldFilter, expr, context);
    }

    public void updateFormulasCore(FieldFilter fieldFilter, Expression expr, EntityExecutionContext context) throws UPAException {
        List<Field> noFields = PlatformUtils.emptyList();
        List<Field> fieldsToUpdate = fieldFilter != null
                ? (List<Field>) getFields(fieldFilter)
                : noFields;
        boolean persistContext = ContextOperation.PERSIST.equals(context.getOperation());
        //TODO this is a work around, those fields must be removed
        List<Field> fieldsToUpdate2 = new ArrayList<Field>();
        for (Field f : fieldsToUpdate) {
            //TODO why should i remove postInsertFormula and postUpdateFormula formulas?
            //please be more specific
//            FieldPersistenceInfo nfo = fieldListPersistenceInfo.fields.get(f.getName());
//            if ((insertContext && nfo.postInsertFormula) || (!insertContext && nfo.postUpdateFormula)) {
            fieldsToUpdate2.add(f);
//            }
        }
        if (fieldsToUpdate2.isEmpty()) {
            return;
        }
        fieldsToUpdate = fieldsToUpdate2;

//        Object methodExecId = new Double(Math.random());
//        final String exprSQL = expr == null ? null : expr.toSQL(getPersistenceUnit());
//        Log.log(EditorConstants.Logs.VALIDATE, getName() + " validating " + Arrays2.arrayToString(fieldsToUpdate) + " For expression " + exprSQL);
//        Log.method_enter(methodExecId, getName(), fieldsToUpdate, exprSQL);
        expr = simplifyExpression(expr);
        if (fieldsToUpdate == null || fieldsToUpdate.isEmpty()) {
            fieldsToUpdate = getFields(UPDATE_FORMULA);
        }
        if (fieldsToUpdate.size() > 0) {
            // System.out.println(getName()+".updateFormulas("+Arrays.asList(fieldsToUpdate)+","+expr+"){");
            // check ???
            boolean doValidation = true;

            if (VALIDATE_IF_CHANGED) {
                doValidation = false;
                Expression newFieldsValuesExpression = null;
                for (int i = 0; !doValidation && i < fieldsToUpdate.size(); i++) {
                    Field field = fieldsToUpdate.get(i);
                    Formula f = persistContext ? field.getPersistFormula() : field.getUpdateFormula();
                    if ((f instanceof CustomUpdaterFormula)
                            || (f instanceof CustomUpdaterFormula)) {
                        doValidation = true;
                        break;
                    }
                    Expression formExpr = getFieldExpression(field, persistContext);
                    if (formExpr != null) {
                        // newFieldsValuesExpression.or(new
                        // Different(fieldsToUpdate.get(i).getName(),new
                        // UserExpression(fieldsToUpdate.get(i).getExpression())));
                        Expression e = new Not(
                                new Or(
                                        new And(new Equals(new Var(field.getName()), null), new Equals(formExpr, null)),
                                        new And(
                                                new Different(new Var(field.getName()), null), new And(new Different(formExpr, null), new Equals(new Var(field.getName()), formExpr)))));
                        newFieldsValuesExpression = newFieldsValuesExpression == null ? e : new Or(newFieldsValuesExpression, e);
                    }
                }
                if (!doValidation) {
                    Expression exp2 = new And(expr, newFieldsValuesExpression);
                    long recordsCount = getEntityCount(exp2.isValid() ? exp2 : null);
                    doValidation = recordsCount > 0;
                } else {
                    long recordsCount = getEntityCount(expr);
                    doValidation = recordsCount > 0;
                }
            } else {// if KeyExpression dont call getEntityCount(expr)
                //Boolean b = expr == null ? Boolean.valueOf((!isEmpty())) : (Boolean) expr.getClientProperty(EXPRESSION_SURELY_EXISTS);
                Boolean b = Boolean.valueOf((!isEmpty()));
                // doValidation = b != null ? b.booleanValue() : (expr
                // instanceof KeyExpression || (expr instanceof
                // KeyCollectionExpression &&
                // ((KeyCollectionExpression)expr).size()>0) ||
                // (getEntityCount(expr) > 0)) ;
                doValidation = b != null ? b : ((getEntityCount(expr) > 0));
            }

            if (doValidation) {
                Record fieldNamesToUpdateMap = getBuilder().createRecord();
                for (Field aFieldsToUpdate : fieldsToUpdate) {
                    Formula formula = persistContext ? aFieldsToUpdate.getPersistFormula() : aFieldsToUpdate.getUpdateFormula();
                    Expression ee = null;
                    if (formula instanceof ExpressionFormula) {
                        ee = ((ExpressionFormula) formula).getExpression();
                    }
                    fieldNamesToUpdateMap.setObject(aFieldsToUpdate.getName(), ee);
                }
                // System.out.println(">>");
                recordListenerSupport.fireBeforeFormulasUpdate(fieldNamesToUpdateMap, expr, context);
                if (!persistContext) {
                    recordListenerSupport.fireBeforeUpdate(fieldNamesToUpdateMap, expr, context);
                }
                FormulaUpdateProcessor p = new FormulaUpdateProcessor(persistContext, fieldsToUpdate, expr, context, this, getEntityOperationManager());
                p.updateFormulasCore();
                if (!persistContext) {
                    recordListenerSupport.fireAfterUpdate(fieldNamesToUpdateMap, expr, context);
                }
                recordListenerSupport.fireAfterFormulasUpdate(fieldNamesToUpdateMap, expr, context);
            }
            // System.out.println("}");
        }
//        Log.method_exit(methodExecId, getName(), fieldsToUpdate, exprSQL);
    }

    public Order getUpdateFormulasOrder() {
        return null;
    }

    public Order getArchivingOrder() {
        //TODO fix me
        return null;
    }

    public void setArchivingOrder(Order order) {
        //TODO fix me
    }

    //    public int compareTo(Entity other) {
//        if (other == this) {
//            return 0;
//        }
//        if (other == null) {
//            return 1;
//        } else {
//            Entity t = other;
//            return getName().compareTo(t.getName());
//        }
//    }
    //    public void setPersistenceName(String persistenceName) {
//        this.persistenceName = persistenceName;
//    }
    public Field getLeadingPrimaryField() throws UPAException {
        return getPrimaryFields().get(0);
    }

    public List<String> getOrderedFields(String[] fields) {
        Comparator<String> c = new EntityChildComparator(this);
        ArrayList<String> ts = new ArrayList<String>();
        ts.addAll(Arrays.asList(fields));
        Collections.sort(ts, c);
        return ts;
    }

    public Package getParent() {
        return parent;
    }

    public void setParent(Package parent) {
        this.parent = parent;
    }

    public Expression simplifyExpression(Expression e) throws UPAException {
        if (tuningMaxInline <= 0 || e == null || (e instanceof IdExpression)
                || (e instanceof IdCollectionExpression)
                || (e instanceof IdEnumerationExpression)) {
            return e;
        } else {
            List<Object> keys = createQueryBuilder().setExpression(e).getIdList();
            if (keys.size() > tuningMaxInline) {
                return e;
            }
            return getBuilder().idListToExpression(keys, null);
        }
    }

    public String getShortName() {
        return shortName;
    }

    public void setShortName(String shortName) {
        this.shortName = shortName;
    }

    public String getShortNameOrName() {
        return shortName == null ? getName() : shortName;
    }

    public Order getListOrder() {
        return listOrder;
    }

    public void setListOrder(Order listDefaultOrder) {
        this.listOrder = listDefaultOrder;
    }

    //    public K mapToKey(Map<String, Object> mappedValues) {
//        if (mappedValues == null) {
//            return createId();
//        } else {
//            List<Field> fs = getPrimaryFields();
//            Object[] value = new Object[fs.size()];
//            for (int i = 0; i < fs.size(); i++) {
//                Object o = mappedValues.get(fs.get(i).getName());
//                if (o == null) {
//                    o = mappedValues.get(fs.get(i).getAbsoluteName());
//                }
//                value[i] = o;
//            }
//            return createId(value);
//        }
//    }
//
//    public Map<String, Object> keyToMap(Key key) {
//        Map<String, Object> map = new HashMap<String, Object>();
////        if (!isNull()) {
//        List<Field> fs = getPrimaryFields();
//        for (int i = 0; i < fs.size(); i++) {
//            if (key.getValue()[i] != null) {
//                map.put(fs.get(i).getAbsoluteName(), key.getValue()[i]);
//            }
//        }
//
////        }
//        return map;
//    }
//    public String getDefaultRowLabel(String rowId) {
//        return getResources().get(
//                getPersistenceUnit().getI18NStringStrategy().getEntityString(this) + ".Rows"
//                        + rowId);
//    }
//    public void setRecordProperties(Object rec, Record ur2) throws UPAException {
//        Record r = getBuilder().entityToPartialRecord(rec);
//        r.setAll(ur2);
//    }
    ////////////////////////////////////////////////
    public Class getEntityType() {
        return entityType;
    }

    public void setEntityType(Class entityType) {
        this.entityType = entityType;
        if (Record.class.isAssignableFrom(entityType)) {
            entityFactory.setEntityFactory(new EntitySubclassUnstructuredFactory(entityType, getPersistenceUnit().getFactory()));
        } else {
            EntityBeanAdapter recordTypeBeanAdapter = new EntityBeanAdapter(entityType, this);
            entityFactory.setEntityFactory(new EntityBeanFactory(recordTypeBeanAdapter, entityType, getPersistenceUnit().getFactory()));
        }
    }

    public DecorationRepository getDecorationRepository() {
        DefaultPersistenceUnit persistenceUnit = (DefaultPersistenceUnit) getPersistenceUnit();
        return persistenceUnit.getDecorationRepository();
    }

    public Class getIdType() {
        return idType;
    }

    public void setIdType(Class idType) {
        this.idType = idType;
        if (Key.class.equals(idType)) {
            entityFactory.setKeyFactory((KeyFactory) new KeyUnstructuredFactory(this));
        } else if (Key.class.isAssignableFrom(idType)) {
            EntityBeanAdapter keyTypeBeanAdapter = new EntityBeanAdapter(idType, this);
            entityFactory.setKeyFactory(new KeySubclassUnstructuredFactory(idType, keyTypeBeanAdapter));
        } else if ((KeyTypeFactory.ACCEPTED_TYPES.contains(idType))) {
            entityFactory.setKeyFactory(new KeyTypeFactory(idType));
        } else {
            entityFactory.setKeyFactory(new KeyBeanFactory(idType, this));
        }
    }

    @Override
    public EntityBuilder getBuilder() {
        return entityFactory;
    }

    @Override
    public void addExtensionDefinition(Class extensionType, EntityExtensionDefinition extensionObject) throws UPAException {
        Class<? extends EntityExtension> entityExtensionSupportType = getPersistenceUnit().getEntityExtensionSupportType(extensionType);
        EntityExtension ess = (EntityExtension) getPersistenceUnit().getFactory().createObject(entityExtensionSupportType);
        ess.install(this, entityOperationManager, extensionObject);
        extensionManager.addEntityExtension(extensionType, entityExtensionSupportType, extensionObject, ess);
    }

    @Override
    public void removeExtensionDefinition(Class extensionType, EntityExtensionDefinition extensionObject) {
        extensionManager.removeEntityExtension(extensionType, extensionObject);
    }

    @Override
    public List<EntityExtensionDefinition> getExtensionDefinitions() {
        return extensionManager.getEntityExtensions();
    }

    @Override
    public <S extends EntityExtensionDefinition> List<S> getExtensionDefinitions(Class<S> type) {
        return extensionManager.getEntityExtensions(type);
    }

    public List<EntityExtension> getExtensions() {
        return extensionManager.getEntityExtensionSupports();
    }

    public <S extends EntityExtension> List<S> getExtensions(Class<S> type) {
        return extensionManager.getEntityExtensionSupports(type);
    }

    public <S extends EntityExtension> S getExtension(Class<S> type) throws UPAException {
        List<S> list = getExtensions(type);
        if (list.isEmpty()) {
            throw new UPAException("No such EntityExtensionSupport found " + type);
        }
        if (list.size() != 1) {
            throw new UPAException("Too Many EntitySpecSupports found " + type);
        }
        return list.get(0);
    }

    //    public void resetModifiers() {
//        modifiers = 0;
//    }
//
//    public void setModifiers(long modifiers) {
//        this.modifiers = modifiers;
//    }
//
//    public void addModifiers(long modifiers) {
//        setModifiers(getModifiers() | modifiers);
//    }
//
//    public void setModifiers(long v, boolean enable) {
//        if (enable) {
//            addModifiers(v);
//        } else {
//            removeModifiers(v);
//        }
//    }
//
//    public void removeModifiers(long modifiers) {
//        setModifiers(getModifiers() & ~modifiers);
//    }
//
//    public boolean is(long modifier) {
//        return modifier == (modifiers & modifier);
//    }
//
//    @Override
//    public long getModifiers() {
//        return modifiers;
//    }
    public EntityOperationManager getEntityOperationManager() {
        return entityOperationManager;
    }

    public EntityShield getShield() {
        return shield;
    }

    public void setShield(EntityShield shield) throws UPAException {
        this.shield = shield;
        shield.init(this);
    }

    @Override
    public Key createKey(Object... keyValues) {
        return getBuilder().createKey(keyValues);
    }

    @Override
    public Object createId(Object... keyValues) {
        return getBuilder().createId(keyValues);
    }

    @Override
    public Record createRecord() {
        return getBuilder().createRecord();
    }

    @Override
    public <R> R createEntity() {
        return getBuilder().createObject();
    }

    @Override
    public void addDefinitionListener(DefinitionListener interceptor) throws UPAException {
        getPersistenceUnit().addDefinitionListener(getName(), interceptor);
    }

    @Override
    public void removeDefinitionListener(DefinitionListener interceptor) throws UPAException {
        getPersistenceUnit().removeDefinitionListener(getName(), interceptor);
    }

    //    protected void addFieldToCache(Field f) throws UPAException {
//        NamingStrategy namesComparator = getPersistenceUnit().getNamingStrategy();
//        String uniformValue = namesComparator.getUniformValue(f.getName());
//        if (!fieldsMap.containsKey(uniformValue)) {
//            fieldsMap.put(uniformValue, f);
//            fieldsList.add(f);
//        } else {
//            throw new IllegalArgumentException(getName()
//                    + " : field '" + f.getName()
//                    + "' already exists");
//        }
//    }
    @Override
    public EntityDescriptor getEntityDescriptor() {
        return entityDescriptor;
    }

    //@Override
    public void setEntityDescriptor(EntityDescriptor entityDescriptor) {
        this.entityDescriptor = entityDescriptor;
    }

//    public int resetCore(EntityExecutionContext executionContext) throws UPAException {
//        EntityOperationManager pm = getEntityOperationManager();
//        EntityResetOperation a = pm.getResetOperation();
//        if (a != null) {
//            return a.reset(this, executionContext);
//        }
//        return 0;
//    }
    public int clearCore(EntityExecutionContext executionContext) throws UPAException {
        EntityOperationManager pm = getEntityOperationManager();
        EntityClearOperation a = pm.getClearOperation();
        if (a != null) {
            return a.clear(this, executionContext);
        }
        return 0;
    }

    @Override
    public int initializeCore(EntityExecutionContext executionContext) throws UPAException {
        EntityOperationManager pm = getEntityOperationManager();
        EntityInitializeOperation a = pm.getInitializeOperation();
        if (a != null) {
            return a.initialize(this, executionContext);
        }
        return 0;
    }

    @Override
    public void close() throws UPAException {
        for (EntityPart item : items) {
            item.close();
        }
        this.closed = true;
    }

    public boolean isClosed() {
        return closed;
    }

    private FlagSet<UserFieldModifier> copy(FlagSet<UserFieldModifier> e, UserFieldModifier... others) {
        if (e == null) {
            e = FlagSets.noneOf(UserFieldModifier.class);
        }
        e = e.addAll(Arrays.asList(others));
        return e;
    }

    public Object compile(Expression expression) throws UPAException {
        ExpressionCompilerConfig config = new ExpressionCompilerConfig();
        config.setThisAlias("upathis");
        config.setExpandEntityFilter(false);
        CompiledSelect compiledSelect = (CompiledSelect) getPersistenceUnit().getExpressionManager().compileExpression(new Select().from(getName(), "upathis").field(expression), config);
        return compiledSelect.getField(0).getExpression();
    }

    private Set<Field> findUsedFields(Formula f) {
        Set<Field> usedFields = new HashSet<Field>();
        if (f instanceof ExpressionFormula) {
            ExpressionFormula expressionFormula = (ExpressionFormula) f;
            DefaultCompiledExpression compiledExpression = (DefaultCompiledExpression) compile(expressionFormula.getExpression());
            compiledExpression.visit(new FieldCollectorCompiledExpressionVisitor(usedFields));
        }
        return usedFields;
    }

    public List<Relationship> getRelationships() {
        LinkedHashSet<Relationship> relations = new LinkedHashSet<Relationship>();
        for (Relationship r : getPersistenceUnit().getRelationshipsForSource(this)) {
            relations.add(r);
        }
        for (Relationship r : getPersistenceUnit().getRelationshipsForTarget(this)) {
            relations.add(r);
        }
        return new ArrayList<Relationship>(relations);
    }

    @Override
    public void addFilter(String name, Expression expression) {
        if (name == null || expression == null) {
            throw new NullPointerException("Object Filter Null");
        }
        if (objectfilters.containsKey(name)) {
            throw new IllegalArgumentException("Object Filter Already Exists " + name);
        }
        objectfilters.put(name, expression);
    }

    @Override
    public void removeFilter(String name) {
        if (name == null) {
            throw new NullPointerException("Object Filter Null");
        }
        objectfilters.remove(name);
    }

    @Override
    public Set<String> getFilterNames() {
        return new LinkedHashSet<String>(objectfilters.keySet());
    }

    @Override
    public Expression getFilter(String name) {
        Expression expression = objectfilters.get(name);
        if (expression == null) {
            throw new IllegalArgumentException("Object Filter Not Found " + name);
        }
        return expression;
    }

    @Override
    public void addFilter(String name, String expression) {
        addFilter(name, expression == null ? null : getPersistenceUnit().getExpressionManager().parseExpression(expression));
    }

    public List<Section> getSections() {
        List<Section> sections = new ArrayList<Section>();
        for (EntityPart part : getParts()) {
            if (part instanceof Section) {
                sections.add((Section) part);
            }
        }
        return sections;
    }

    public boolean isSystem() throws UPAException {
        return getModifiers().contains(EntityModifier.SYSTEM);
    }

    public <T> T findById(Object id) throws UPAException {
        return getPersistenceUnit().findById(getName(), id);
    }

    public <T> List<T> findAll() throws UPAException {
        return getPersistenceUnit().findAll(getName());
    }

    public List<Record> findAllRecords(Object id) throws UPAException {
        return getPersistenceUnit().findAllRecords(getName());
    }

    public <T> T findByMainField(Object mainFieldValue) throws UPAException {
        return getPersistenceUnit().findByMainField(getName(), mainFieldValue);
    }

    public <T> T findByField(String fieldName, Object mainFieldValue) throws UPAException {
        return getPersistenceUnit().findByField(getName(), fieldName, mainFieldValue);
    }

    public List<Record> findAllRecords() throws UPAException {
        return getPersistenceUnit().findAllRecords(getName());
    }

    public EntitySecurityManager getEntitySecurityManager() {
        return entitySecurityManager;
    }

    public void setEntitySecurityManager(EntitySecurityManager entitySecurityManager) {
        this.entitySecurityManager = entitySecurityManager;
    }

}
