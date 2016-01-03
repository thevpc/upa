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
namespace Net.Vpc.Upa.Impl.Persistence
{


    /**
     * User: vpc Date: 8/16/12 Time: 6:41 AM To change this template use File |
     * Settings | File Templates.
     */
    public class SingleEntityQueryResult<R> : Net.Vpc.Upa.Impl.Persistence.QueryResultIteratorList<R> {

        private bool updatable;

        private Net.Vpc.Upa.Impl.Persistence.TypeInfo[] typeInfos;

        private int entityIndex = 0;

        private System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Impl.Persistence.TypeInfo> bindingToTypeInfos;

        public SingleEntityQueryResult(Net.Vpc.Upa.Impl.Persistence.NativeSQL nativeSQL, string aliasName)  : base(nativeSQL){

            System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Impl.Persistence.TypeInfo> bindingToTypeInfos0 = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Impl.Persistence.TypeInfo>();
            //        List<FieldInfo> fieldInfos0 = new ArrayList<FieldInfo>();
            int index = 0;
            foreach (Net.Vpc.Upa.Impl.Persistence.NativeField nativeField in nativeSQL.GetFields()) {
                Net.Vpc.Upa.Impl.Persistence.FieldInfo f = new Net.Vpc.Upa.Impl.Persistence.FieldInfo();
                f.index = index;
                f.nativeField = nativeField;
                f.name = nativeField.GetName();
                string gn = nativeField.GetGroupName();
                Net.Vpc.Upa.Impl.Persistence.TypeInfo t = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.Vpc.Upa.Impl.Persistence.TypeInfo>(bindingToTypeInfos0,gn);
                if (t == null) {
                    t = new Net.Vpc.Upa.Impl.Persistence.TypeInfo(gn, nativeField.GetField().GetEntity());
                    bindingToTypeInfos0[gn]=t;
                }
                f.typeInfo = t;
                t.infos.Add(f);
                if (t.leadPrimaryField == null && f.nativeField.GetField().IsId()) {
                    t.leadPrimaryField = f;
                }
                if (t.leadField == null) {
                    t.leadField = f;
                }
                f.setterMethodName = Net.Vpc.Upa.Impl.Util.PlatformUtils.SetterName(nativeField.GetName());
                t.setterToProp[f.setterMethodName]=f;
                //            fieldInfos0.add(f);
                index++;
            }
            bindingToTypeInfos = bindingToTypeInfos0;
            //        fieldInfos = fieldInfos0.toArray(new FieldInfo[fieldInfos0.size()]);
            typeInfos = (bindingToTypeInfos0).Values.ToArray();
            for (int i = 0; i < typeInfos.Length; i++) {
                Net.Vpc.Upa.Impl.Persistence.TypeInfo typeInfo = typeInfos[i];
                if (aliasName.Equals(typeInfo.binding)) {
                    entityIndex = i;
                }
                typeInfo.infosArray = typeInfo.infos.ToArray();
            }
            //typeInfo.infos=null;
            //        columns = fieldInfos.length;
            updatable = nativeSQL.IsUpdatable();
        }


        public override R Parse(Net.Vpc.Upa.Persistence.QueryResult result) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            foreach (Net.Vpc.Upa.Impl.Persistence.TypeInfo typeInfo in typeInfos) {
                if (typeInfo.leadPrimaryField == null) {
                    //                Object leadVal = result.read(typeInfo.leadField.index);
                    object entityObject = typeInfo.entityFactory.CreateObject<object>();
                    Net.Vpc.Upa.Record entityRecord = typeInfo.entityConverter.EntityToRecord(entityObject, true);
                    typeInfo.entityObject = entityObject;
                    typeInfo.entityRecord = entityRecord;
                    foreach (Net.Vpc.Upa.Impl.Persistence.FieldInfo f in typeInfo.infos) {
                        entityRecord.SetObject(f.name, result.Read<object>(f.index));
                    }
                } else {
                    object leadPK = result.Read<object>(typeInfo.leadPrimaryField.index);
                    if (leadPK != null) {
                        //create new instances
                        object entityObject = typeInfo.entityFactory.CreateObject<object>();
                        Net.Vpc.Upa.Record entityRecord = typeInfo.entityConverter.EntityToRecord(entityObject, true);
                        typeInfo.entityObject = entityObject;
                        typeInfo.entityRecord = entityRecord;
                        foreach (Net.Vpc.Upa.Impl.Persistence.FieldInfo f in typeInfo.infos) {
                            entityRecord.SetObject(f.name, result.Read<object>(f.index));
                        }
                    } else {
                        typeInfo.entityObject = null;
                        typeInfo.entityRecord = null;
                    }
                }
            }
            //        for (int i = 0; i < columns; i++) {
            //            FieldInfo f = fieldInfos[i];
            //            System.out.println(i + " : " + f.nativeField.getField());
            //            f.typeInfo.entityRecord.setObject(f.name, result.read(i));
            //        }
            foreach (Net.Vpc.Upa.Impl.Persistence.TypeInfo typeInfo in typeInfos) {
                if (typeInfo.parentBinding != null) {
                    Net.Vpc.Upa.Impl.Persistence.TypeInfo pp = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.Vpc.Upa.Impl.Persistence.TypeInfo>(bindingToTypeInfos,typeInfo.parentBinding);
                    if (pp == null) {
                        throw new System.ArgumentException ("Invalid binding " + typeInfo.binding);
                    }
                    if (pp.entityRecord != null) {
                        pp.entityRecord.SetObject(typeInfo.bindingName, typeInfo.entityObject);
                    }
                }
            }
            if (updatable) {
                foreach (Net.Vpc.Upa.Impl.Persistence.TypeInfo typeInfo in typeInfos) {
                    typeInfo.entityUpdatable = Net.Vpc.Upa.Impl.Util.PlatformUtils.CreateObjectInterceptor<object>(typeInfo.entityType, new Net.Vpc.Upa.Impl.Persistence.SingleEntityQueryResultParseMethodInterceptor(typeInfo, typeInfo.entityObject, result));
                }
                return (R) typeInfos[entityIndex].entityUpdatable;
            } else {
                return (R) typeInfos[entityIndex].entityObject;
            }
        }
    }
}
