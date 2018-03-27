/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE AS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



using System.Linq;
namespace Net.Vpc.Upa.Impl.Persistence.Result
{


    /**
     * Created by vpc on 6/18/16.
     */
    public class DefaultObjectQueryResultLazyList<T> : Net.Vpc.Upa.Impl.Persistence.QueryResultLazyList<T> {

        protected internal bool updatable;

        protected internal bool loadManyToOneRelations;

        internal Net.Vpc.Upa.Impl.Persistence.Result.TypeInfo[] typeInfos;

        protected internal Net.Vpc.Upa.Persistence.ResultMetaData metaData;

        internal System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Impl.Persistence.Result.TypeInfo> bindingToTypeInfos;

        protected internal Net.Vpc.Upa.Impl.Util.CacheMap<Net.Vpc.Upa.NamedId , object> referencesCache;

        protected internal System.Collections.Generic.IDictionary<string , object> hints;

        protected internal Net.Vpc.Upa.ObjectFactory ofactory;

        protected internal bool defaultsToRecord;

        protected internal bool relationAsRecord;

        private Net.Vpc.Upa.Impl.Persistence.Result.QueryResultItemBuilder resultBuilder;

        private Net.Vpc.Upa.Impl.Persistence.Result.QueryResultRelationLoader loader;

        private Net.Vpc.Upa.Impl.Persistence.Result.LoaderContext loaderContext;

        public DefaultObjectQueryResultLazyList(Net.Vpc.Upa.Impl.Persistence.QueryExecutor queryExecutor, bool loadManyToOneRelations, bool defaultsToRecord, bool relationAsRecord, bool supportCache, bool updatable, Net.Vpc.Upa.Impl.Persistence.Result.QueryResultRelationLoader loader, Net.Vpc.Upa.Impl.Persistence.Result.QueryResultItemBuilder resultBuilder)  : base(queryExecutor){

            this.resultBuilder = resultBuilder;
            this.loader = loader;
            this.defaultsToRecord = defaultsToRecord;
            this.relationAsRecord = relationAsRecord;
            this.loadManyToOneRelations = loadManyToOneRelations;
            metaData = queryExecutor.GetMetaData();
            hints = queryExecutor.GetHints();
            if (hints == null) {
                hints = new System.Collections.Generic.Dictionary<string , object>();
            } else {
                hints = new System.Collections.Generic.Dictionary<string , object>(hints);
            }
            if (supportCache) {
                Net.Vpc.Upa.Impl.Util.CacheMap<Net.Vpc.Upa.NamedId , object> sharedCache = (Net.Vpc.Upa.Impl.Util.CacheMap<Net.Vpc.Upa.NamedId , object>) Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(hints,"queryCache");
                if (sharedCache == null) {
                    sharedCache = new Net.Vpc.Upa.Impl.Util.CacheMap<Net.Vpc.Upa.NamedId , object>(1000);
                    hints["queryCache"]=sharedCache;
                }
                referencesCache = sharedCache;
            }
            loaderContext = new Net.Vpc.Upa.Impl.Persistence.Result.LoaderContext(referencesCache, hints);
            System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Impl.Persistence.Result.TypeInfo> bindingToTypeInfos0 = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Impl.Persistence.Result.TypeInfo>();
            ofactory = Net.Vpc.Upa.UPA.GetPersistenceUnit().GetFactory();
            Net.Vpc.Upa.Impl.Persistence.NativeField[] fields = queryExecutor.GetFields();
            for (int i = 0; i < fields.Length; i++) {
                Net.Vpc.Upa.Impl.Persistence.NativeField nativeField = fields[i];
                Net.Vpc.Upa.Impl.Persistence.Result.FieldInfo f = new Net.Vpc.Upa.Impl.Persistence.Result.FieldInfo();
                f.dbIndex = i;
                f.nativeField = nativeField;
                f.name = nativeField.GetName();
                string gn = nativeField.GetGroupName();
                if (gn == null) {
                    gn = nativeField.GetExprString();
                }
                Net.Vpc.Upa.Impl.Persistence.Result.TypeInfo t = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.Vpc.Upa.Impl.Persistence.Result.TypeInfo>(bindingToTypeInfos0,gn);
                if (t == null) {
                    if (nativeField.GetField() != null) {
                        t = new Net.Vpc.Upa.Impl.Persistence.Result.TypeInfo(gn, nativeField.GetField().GetEntity());
                        t.record = gn.Contains(".") ? relationAsRecord : defaultsToRecord;
                        bindingToTypeInfos0[gn]=t;
                    } else {
                        t = new Net.Vpc.Upa.Impl.Persistence.Result.TypeInfo(gn, null);
                        t.record = false;
                        //n.contains(".") ? relationAsRecord : defaultsToRecord;
                        bindingToTypeInfos0[gn]=t;
                    }
                }
                //                if(!bindingToTypeInfos0.containsKey(nativeField.getExprString())) {
                //                    bindingToTypeInfos0.put(nativeField.getExprString(), t);
                //                }else{
                //                    System.out.println("why");
                //                }
                f.field = nativeField.GetField();
                if (loadManyToOneRelations) {
                    if (f.field != null) {
                        if (f.field.GetDataType() is Net.Vpc.Upa.Types.ManyToOneType) {
                            Net.Vpc.Upa.Entity r = ((Net.Vpc.Upa.Types.ManyToOneType) f.field.GetDataType()).GetTargetEntity();
                            f.referencedEntity = r;
                        }
                        foreach (Net.Vpc.Upa.Relationship relationship in f.field.GetManyToOneRelationships()) {
                            if (relationship.GetSourceRole().GetEntityField() != null) {
                                t.manyToOneRelations.Add(relationship);
                            }
                        }
                    }
                }
                f.typeInfo = t;
                t.allFields.Add(f);
                if (t.leadPrimaryField == null && f.nativeField.GetField() != null && f.nativeField.GetField().IsId()) {
                    t.leadPrimaryField = f;
                }
                if (t.leadField == null) {
                    t.leadField = f;
                }
                f.setterMethodName = Net.Vpc.Upa.Impl.Util.PlatformUtils.SetterName(nativeField.GetName());
                t.fields[f.setterMethodName]=f;
            }
            bindingToTypeInfos = bindingToTypeInfos0;
            typeInfos = (bindingToTypeInfos0).Values.ToArray();
            // all indexes to fill with values from the query
            System.Collections.Generic.ISet<int?> allIndexes = new System.Collections.Generic.HashSet<int?>();
            for (int i = 0; i < (metaData.GetFields()).Count; i++) {
                allIndexes.Add(i);
            }
            // map expression to relative TypeInfo/FieldInfo
            System.Collections.Generic.IDictionary<string , object> visitedIndexes = new System.Collections.Generic.Dictionary<string , object>();
            for (int i = 0; i < typeInfos.Length; i++) {
                Net.Vpc.Upa.Impl.Persistence.Result.TypeInfo typeInfo = typeInfos[i];
                //            if (aliasName.equals(typeInfo.binding)) {
                //                entityIndex = i;
                //            }
                typeInfo.infosArray = typeInfo.allFields.ToArray();
                typeInfo.update = false;
                foreach (Net.Vpc.Upa.Impl.Persistence.Result.FieldInfo field in typeInfo.infosArray) {
                    if (!field.nativeField.IsExpanded() && field.nativeField.GetIndex() >= 0) {
                        field.update = true;
                        field.indexesToUpdate.Add(field.nativeField.GetIndex());
                        allIndexes.Remove(field.nativeField.GetIndex());
                        visitedIndexes[field.nativeField.GetExprString()]=field;
                    }
                }
                if (typeInfo.entity == null) {
                    typeInfo.update = true;
                } else {
                    System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.ResultField> fields1 = metaData.GetFields();
                    for (int i1 = 0; i1 < (fields1).Count; i1++) {
                        Net.Vpc.Upa.Persistence.ResultField resultField = fields1[i1];
                        if (resultField.GetExpression().ToString().Equals(typeInfo.binding)) {
                            typeInfo.update = true;
                            typeInfo.indexesToUpdate.Add(i1);
                            allIndexes.Remove(i1);
                            visitedIndexes[typeInfo.binding]=typeInfo;
                            break;
                        }
                    }
                }
            }
            //when an expression is to be expanded twice, implementation ignores second expansion
            // so we must find the equivalent expression index to handle
            foreach (int? remaining in allIndexes) {
                string k = metaData.GetFields()[(remaining).Value].GetExpression().ToString();
                object o = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(visitedIndexes,k);
                if (o is Net.Vpc.Upa.Impl.Persistence.Result.TypeInfo) {
                    ((Net.Vpc.Upa.Impl.Persistence.Result.TypeInfo) o).indexesToUpdate.Add(remaining);
                } else if (o is Net.Vpc.Upa.Impl.Persistence.Result.FieldInfo) {
                    ((Net.Vpc.Upa.Impl.Persistence.Result.FieldInfo) o).indexesToUpdate.Add(remaining);
                } else {
                    throw new Net.Vpc.Upa.Exceptions.UPAException("Unsupported");
                }
            }
            this.updatable = updatable;
        }

        private void UpdateRow(Net.Vpc.Upa.Impl.Persistence.Result.ResultColumn[] columns, Net.Vpc.Upa.Impl.Persistence.Result.FieldInfo fi, string label, object @value) {
            if (fi.update) {
                foreach (int? index in fi.indexesToUpdate) {
                    Net.Vpc.Upa.Impl.Persistence.Result.ResultColumn c = columns[index];
                    c.SetLabel(label);
                    c.SetValue(@value);
                }
            }
        }

        private void UpdateRow(Net.Vpc.Upa.Impl.Persistence.Result.ResultColumn[] columns, Net.Vpc.Upa.Impl.Persistence.Result.TypeInfo fi, string label, object @value) {
            if (fi.update) {
                foreach (int? index in fi.indexesToUpdate) {
                    Net.Vpc.Upa.Impl.Persistence.Result.ResultColumn c = columns[index];
                    c.SetLabel(label);
                    c.SetValue(@value);
                }
            }
        }

        public override T Parse(Net.Vpc.Upa.Persistence.QueryResult result) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IDictionary<string , object> groupValues = new System.Collections.Generic.Dictionary<string , object>();
            Net.Vpc.Upa.Impl.Persistence.Result.ResultColumn[] values = new Net.Vpc.Upa.Impl.Persistence.Result.ResultColumn[(metaData.GetFields()).Count];
            for (int i = 0; i < values.Length; i++) {
                values[i] = new Net.Vpc.Upa.Impl.Persistence.Result.ResultColumn();
            }
            foreach (Net.Vpc.Upa.Impl.Persistence.Result.TypeInfo typeInfo in typeInfos) {
                typeInfo.entityObject = null;
                typeInfo.entityRecord = null;
                typeInfo.entityResult = null;
            }
            foreach (Net.Vpc.Upa.Impl.Persistence.Result.TypeInfo typeInfo in typeInfos) {
                if (typeInfo.entity == null) {
                    foreach (Net.Vpc.Upa.Impl.Persistence.Result.FieldInfo f in typeInfo.allFields) {
                        object fieldValue = result.Read<T>(f.dbIndex);
                        groupValues[f.nativeField.GetFullBinding()]=fieldValue;
                        groupValues[f.nativeField.GetExprString()]=fieldValue;
                        UpdateRow(values, f, f.nativeField.GetExprString(), fieldValue);
                    }
                } else if (typeInfo.leadPrimaryField == null) {
                    if (typeInfo.record) {
                        object entityObject = null;
                        Net.Vpc.Upa.Record entityRecord = typeInfo.entityFactory == null ? ((Net.Vpc.Upa.Record)(ofactory.CreateObject<Net.Vpc.Upa.Record>(typeof(Net.Vpc.Upa.Record)))) : typeInfo.entityFactory.CreateRecord();
                        typeInfo.entityObject = entityObject;
                        typeInfo.entityRecord = entityRecord;
                        typeInfo.entityResult = entityRecord;
                    } else {
                        object entityObject = typeInfo.entityFactory.CreateObject<R>();
                        Net.Vpc.Upa.Record entityRecord = typeInfo.entityConverter.ObjectToRecord(entityObject, true);
                        typeInfo.entityObject = entityObject;
                        typeInfo.entityRecord = entityRecord;
                        typeInfo.entityResult = entityObject;
                    }
                    groupValues[typeInfo.binding]=typeInfo.entityResult;
                    UpdateRow(values, typeInfo, typeInfo.binding, typeInfo.entityResult);
                    foreach (Net.Vpc.Upa.Impl.Persistence.Result.FieldInfo f in typeInfo.allFields) {
                        object fieldValue = result.Read<T>(f.dbIndex);
                        groupValues[f.nativeField.GetFullBinding()]=fieldValue;
                        typeInfo.entityRecord.SetObject(f.name, fieldValue);
                        UpdateRow(values, f, f.nativeField.GetExprString(), fieldValue);
                    }
                } else {
                    object leadPK = result.Read<T>(typeInfo.leadPrimaryField.dbIndex);
                    if (leadPK != null) {
                        //create new instances
                        if (typeInfo.record) {
                            typeInfo.entityRecord = typeInfo.entityFactory == null ? ((Net.Vpc.Upa.Record)(ofactory.CreateObject<Net.Vpc.Upa.Record>(typeof(Net.Vpc.Upa.Record)))) : typeInfo.entityFactory.CreateRecord();
                            typeInfo.entityResult = typeInfo.entityRecord;
                        } else {
                            object entityObject = typeInfo.entityFactory.CreateObject<R>();
                            Net.Vpc.Upa.Record entityRecord = typeInfo.entityConverter.ObjectToRecord(entityObject, true);
                            typeInfo.entityObject = entityObject;
                            typeInfo.entityRecord = entityRecord;
                            typeInfo.entityResult = entityObject;
                        }
                        groupValues[typeInfo.binding]=typeInfo.entityResult;
                        UpdateRow(values, typeInfo, typeInfo.binding, typeInfo.entityResult);
                        foreach (Net.Vpc.Upa.Impl.Persistence.Result.FieldInfo f in typeInfo.allFields) {
                            object fieldValue = result.Read<T>(f.dbIndex);
                            groupValues[f.nativeField.GetFullBinding()]=fieldValue;
                            UpdateRow(values, f, f.nativeField.GetExprString(), fieldValue);
                            typeInfo.entityRecord.SetObject(f.name, fieldValue);
                        }
                        if (loadManyToOneRelations) {
                            foreach (Net.Vpc.Upa.Relationship relationship in typeInfo.manyToOneRelations) {
                                object extractedId = relationship.ExtractIdByForeignFields(typeInfo.entityRecord);
                                if (extractedId != null) {
                                    object @value = loader.LoadObject(relationship.GetTargetEntity(), extractedId, relationAsRecord, loaderContext);
                                    typeInfo.entityRecord.SetObject(relationship.GetSourceRole().GetEntityField().GetName(), @value);
                                    groupValues[typeInfo.binding + "." + relationship.GetSourceRole().GetEntityField().GetName()]=@value;
                                }
                            }
                        }
                    } else {
                        typeInfo.entityObject = null;
                        typeInfo.entityRecord = null;
                    }
                }
            }
            foreach (Net.Vpc.Upa.Impl.Persistence.Result.TypeInfo typeInfo in typeInfos) {
                if (typeInfo.parentBinding != null) {
                    Net.Vpc.Upa.Impl.Persistence.Result.TypeInfo pp = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.Vpc.Upa.Impl.Persistence.Result.TypeInfo>(bindingToTypeInfos,typeInfo.parentBinding);
                    if (pp == null) {
                    } else if (pp.entityRecord != null) {
                        pp.entityRecord.SetObject(typeInfo.bindingName, typeInfo.entityResult);
                    }
                }
            }
            if (updatable) {
                foreach (Net.Vpc.Upa.Impl.Persistence.Result.TypeInfo typeInfo in typeInfos) {
                    if (typeInfo.record) {
                        Net.Vpc.Upa.Impl.Persistence.Result.QueryResultUpdaterPropertyChangeListener li = new Net.Vpc.Upa.Impl.Persistence.Result.QueryResultUpdaterPropertyChangeListener(typeInfo, result);
                        typeInfo.entityRecord.AddPropertyChangeListener(li);
                    } else {
                        typeInfo.entityUpdatable = Net.Vpc.Upa.Impl.Util.PlatformUtils.CreateObjectInterceptor<object>(typeInfo.entityType, new Net.Vpc.Upa.Impl.Persistence.Result.UpdatableObjectInterceptor(typeInfo, typeInfo.entityObject, result));
                        groupValues[typeInfo.binding]=typeInfo.entityUpdatable;
                        int index = typeInfo.allFields[0].nativeField.GetIndex();
                        if (values[index].GetValue() == typeInfo.entityType) {
                            values[index].SetValue(typeInfo.entityUpdatable);
                        }
                    }
                }
            }
            return (T) this.resultBuilder.CreateResult(values, metaData);
        }
    }
}
