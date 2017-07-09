package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.*;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.persistence.NativeField;
import net.vpc.upa.impl.persistence.QueryExecutor;
import net.vpc.upa.impl.uql.BindingId;
import net.vpc.upa.impl.uql.NativeFieldByBindingIdComparator;
import net.vpc.upa.impl.util.*;
import net.vpc.upa.persistence.QueryResult;
import net.vpc.upa.persistence.ResultField;
import net.vpc.upa.persistence.ResultMetaData;
import net.vpc.upa.types.ManyToOneType;

import java.sql.SQLException;
import java.util.*;

/**
 * Created by vpc on 6/18/16.
 */
public class DefaultObjectQueryResultLazyList<T> extends QueryResultLazyList<T> {
    public static final CacheMap<NamedId, ResultObject> NO_RESULT_CACHE=new NoCacheMap<NamedId, ResultObject>();
    private boolean updatable;
    private ResultMetaData metaData;
    private CacheMap<NamedId, ResultObject> referencesCache;
    private Map<String, Object> hints;
    private ObjectFactory ofactory;
    private TypeInfo[] typeInfos;
    private QueryResultItemBuilder resultBuilder;
    private LoaderContext loaderContext;

    public DefaultObjectQueryResultLazyList(
            PersistenceUnit pu,
            QueryExecutor queryExecutor,
            boolean relationAsDocument,
            int supportCacheSize,
            boolean updatable,
            QueryResultItemBuilder resultBuilder
    ) throws SQLException {
        super(queryExecutor);
        this.resultBuilder = resultBuilder;
        metaData = queryExecutor.getMetaData();
        hints = queryExecutor.getHints();
        if (hints == null) {
            hints = new HashMap<String, Object>();
        } else {
            hints = new HashMap<String, Object>(hints);
        }
        if (supportCacheSize>0) {
            CacheMap<NamedId, ResultObject> sharedCache = (CacheMap<NamedId, ResultObject>) hints.get("queryCache");
            if (sharedCache == null) {
                sharedCache = new LRUCacheMap<NamedId, ResultObject>(supportCacheSize);
                hints.put("queryCache", sharedCache);
            }
            referencesCache = sharedCache;
        }else {
            referencesCache=NO_RESULT_CACHE;
        }
        loaderContext = new LoaderContext(referencesCache, hints);
        LinkedHashMap<BindingId, TypeInfo> bindingToTypeInfos0 = new LinkedHashMap<BindingId, TypeInfo>();
        ofactory = pu.getFactory();
        NativeField[] fields = queryExecutor.getFields();

        //reorder fields by binding so that parent bindings are always seen first!
        SortPreserveIndexIndexedItem[] indexed=UPAUtils.sortPreserveIndex0(fields, NativeFieldByBindingIdComparator.INSTANCE);

        for (int i = 0; i < indexed.length; i++) {
            NativeField nativeField = (NativeField) indexed[i].getItem();
            FieldInfo f = new FieldInfo();
            f.dbIndex = indexed[i].getIndex();
            f.nativeField = nativeField;
            f.name = nativeField.getName();
            f.binding = nativeField.getBindingId();
            f.field = nativeField.getField();
            f.parentBindingReferrer = nativeField.getParentBindingEntity();

            if(f.parentBindingReferrer==null && f.field!=null){
                //work around!
                f.parentBindingReferrer=f.field.getEntity();
            }

            BindingId parentBinding = f.binding.getParent();
            TypeInfo typeInfo = bindingToTypeInfos0.get(parentBinding);
            if (typeInfo == null) {
                TypeInfo ancestor = null;
                if((parentBinding==null || parentBinding.getParent()==null)){
                    //do nothing
                }else{
                    ancestor = bindingToTypeInfos0.get(parentBinding.getParent());
                    if(ancestor==null){
                        throw new IllegalArgumentException("Unexpected");
                    }
                }
                if(ancestor!=null){
                    if(ancestor.entity==null){
                        throw new IllegalArgumentException("Unsupported");
                    }else{
                        Field field = ancestor.entity.getField(parentBinding.getName());
                        if(field.getDataType() instanceof ManyToOneType){
                            typeInfo = new TypeInfo(parentBinding, ((ManyToOneType) field.getDataType()).getTargetEntity(),ofactory);
                            typeInfo.documentType = relationAsDocument;
                            bindingToTypeInfos0.put(parentBinding, typeInfo);
                        }else{
                            throw new IllegalArgumentException("Unsupported");
                        }
                    }
                }else {
                    if (f.parentBindingReferrer != null && parentBinding!=null) {
                        typeInfo = new TypeInfo(parentBinding, f.parentBindingReferrer,ofactory);
                        typeInfo.documentType = relationAsDocument;
                        bindingToTypeInfos0.put(parentBinding, typeInfo);
                    } else {
                        typeInfo = new TypeInfo(parentBinding,ofactory);
                        typeInfo.documentType = false;//n.contains(".") ? relationAsDocument : defaultsToDocument;
                        bindingToTypeInfos0.put(parentBinding, typeInfo);
                    }
                }
                typeInfo.partialObject=f.nativeField.isPartialObject();
            }
            f.typeInfo = typeInfo;
            if(f.field!=null && f.field.isId()){
                typeInfo.idFields.add(f);
            }else {
                typeInfo.nonIdFields.add(f);
            }
            typeInfo.fieldsMap.put(f.binding.getName(), f);
        }
        typeInfos = bindingToTypeInfos0.values().toArray(new TypeInfo[bindingToTypeInfos0.size()]);
        for (TypeInfo typeInfo : typeInfos) {
            if(typeInfo.entity!=null){
                Set<String> visitedIds=new HashSet<>();
                Set<String> expectedIds=new HashSet<>();
                List<Field> idFields = typeInfo.entity.getIdFields();
                for (Field field : idFields) {
                    expectedIds.add(field.getName());
                }
                for (Iterator<FieldInfo> iterator = typeInfo.idFields.iterator(); iterator.hasNext(); ) {
                    FieldInfo field = iterator.next();
                    //id field defined twice, not so reasonable, but may happen
                    //if user defines by him self columns
                    String fieldName = field.field.getName();
                    if(visitedIds.contains(fieldName)){
                       iterator.remove();
                       typeInfo.nonIdFields.add(field);
                    }else if(expectedIds.contains(fieldName)){
                        visitedIds.add(fieldName);
                        expectedIds.remove(fieldName);
                    }else{
                        //should never happen
                        throw new IllegalArgumentException("Should never Happen");
                    }
                }
                FieldInfo[] nonOrderedIdFields = typeInfo.idFields.toArray(new FieldInfo[typeInfo.idFields.size()]);

                //now re-order id fields
                for (int i = 0; i < idFields.size(); i++) {
                    for (int j = 0; j < nonOrderedIdFields.length; j++) {
                        if(typeInfo.idFields.get(j).field.getName().equals(idFields.get(i).getName())){
                            nonOrderedIdFields[i]=typeInfo.idFields.get(j);
                            break;
                        }
                    }
                }

                if(expectedIds.isEmpty() && !typeInfo.idFields.isEmpty()){
                    typeInfo.identifiable=true;
                }
            }
            if(typeInfo.binding==null){
                typeInfo.parser= SupParserNoBinding.INSTANCE;
            }else if(typeInfo.entity!=null && typeInfo.identifiable) {
                if(typeInfo.partialObject){
                    if (typeInfo.idFields.size() == 1) {
                        typeInfo.parser = SupParserSingleIdExternalLoadEntity.INSTANCE;
                    } else {
                        typeInfo.parser = SupParserMultiIdExternalLoadEntity.INSTANCE;
                    }
                }else {
                    if (typeInfo.idFields.size() == 1) {
                        typeInfo.parser = SupParserSingleIdEntity.INSTANCE;
                    } else {
                        typeInfo.parser = SupParserMultiIdEntity.INSTANCE;
                    }
                }
            }else if(typeInfo.entity!=null && !typeInfo.identifiable){
                typeInfo.parser= SupParserNoIdEntity.INSTANCE;
            }else {
                throw new IllegalArgumentException("Unsupported binding "+typeInfo.binding);
            }
        }
        for (TypeInfo typeInfo : typeInfos) {
            typeInfo.fieldsArray = typeInfo.nonIdFields.toArray(new FieldInfo[typeInfo.nonIdFields.size()]);
        }

        this.updatable = updatable;
    }

    public T parse(final QueryResult result) throws UPAException {
        Map<BindingId, Object> groupValues = new HashMap<BindingId, Object>();
        Map<BindingId, TypeInfo> groupTypes = new HashMap<BindingId, TypeInfo>();
        List<ResultField> resultFields = metaData.getResultFields();
        ResultColumn[] values = new ResultColumn[resultFields.size()];
        for (TypeInfo typeInfo : typeInfos) {
            groupTypes.put(typeInfo.binding,typeInfo);
            typeInfo.parser.parse(result,typeInfo,groupValues, loaderContext);
            if (updatable) {
                ResultObject currentResult = typeInfo.currentResult;
                if (typeInfo.documentType) {
                    QueryResultUpdaterPropertyChangeListener li = new QueryResultUpdaterPropertyChangeListener(typeInfo, result);
                    currentResult.entityDocument.addPropertyChangeListener(li);
                } else {
                    currentResult.entityUpdatable = PlatformUtils.createObjectInterceptor(
                            typeInfo.resultType,
                            new UpdatableObjectInterceptor(typeInfo, currentResult.entityObject, result));
                    groupValues.put(typeInfo.binding, currentResult.entityUpdatable);
                    int index = typeInfo.nonIdFields.get(0).nativeField.getIndex();
                    if (values[index].getValue() == typeInfo.resultType) {
                        values[index].setValue(currentResult.entityUpdatable);
                    }
                }
            }
        }
        for (Map.Entry<BindingId, Object> e : groupValues.entrySet()) {
            BindingId currBinding = e.getKey();
            Object currValue = e.getValue();
            BindingId parentBinding = currBinding.getParent();
            if(parentBinding !=null){
                TypeInfo parentType=groupTypes.get(parentBinding);
                Object parent = groupValues.get(parentBinding);
                if(parent!=null){
                    parentType.setterFor(currBinding.getName()).set(parent,currValue);
                }
            }
        }
        for (int i = 0; i < values.length; i++) {
            ResultColumn c=values[i] = new ResultColumn();
            c.setLabel(resultFields.get(i).getAlias());
            c.setValue(groupValues.get(BindingId.create(String.valueOf(i))));
        }
        return (T) this.resultBuilder.createResult(values, metaData);
    }

}
