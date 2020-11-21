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



namespace Net.TheVpc.Upa.Impl.Config.Annotationparser
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/15/12 12:03 PM
     */
    public class DecorationEntityDescriptorResolver {

        protected internal static System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.TheVpc.Upa.Impl.Config.Annotationparser.DecorationEntityDescriptorResolver)).FullName);

        private Net.TheVpc.Upa.Impl.Config.Decorations.DecorationRepository repo;

        private Net.TheVpc.Upa.ObjectFactory factory;

        public DecorationEntityDescriptorResolver(Net.TheVpc.Upa.Impl.Config.Decorations.DecorationRepository decorationRepository, Net.TheVpc.Upa.ObjectFactory factory) {
            this.repo = decorationRepository;
            this.factory = factory;
        }

        public virtual Net.TheVpc.Upa.EntityDescriptor Resolve(System.Type[] classes) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (classes.Length == 0) {
                throw new System.ArgumentException ("Empty Class Array");
            } else {
                if (classes.Length > 1) {
                    Net.TheVpc.Upa.Impl.Util.CompareUtils.Sort<System.Type>(classes, new Net.TheVpc.Upa.Impl.Config.Annotationparser.ClassIndexedComparator(repo));
                }
                Net.TheVpc.Upa.Impl.Config.Annotationparser.EntityInfo entityInfo = new Net.TheVpc.Upa.Impl.Config.Annotationparser.EntityInfo(repo, factory);
                entityInfo.source = classes;
                System.Collections.Generic.IList<Net.TheVpc.Upa.Property> parameterInfos = new System.Collections.Generic.List<Net.TheVpc.Upa.Property>();
                foreach (System.Type descriptorType in classes) {
                    Net.TheVpc.Upa.Config.Decoration ue = (Net.TheVpc.Upa.Config.Decoration) repo.GetTypeDecoration(descriptorType, typeof(Net.TheVpc.Upa.Config.Entity));
                    int configOrder = 0;
                    bool isEntityClass = true;
                    if (ue != null) {
                        configOrder = ue.GetConfig().GetOrder();
                        isEntityClass = ue.GetType("entityType").Equals(typeof(void));
                    }
                    if (!isEntityClass) {
                        //ue.entityType() is never null
                        entityInfo.entityType.SetBetterValue(ue.GetType("entityType"), configOrder);
                        if (entityInfo.entityType.specified && !typeof(Net.TheVpc.Upa.Record).Equals(entityInfo.entityType.@value)) {
                            ParseEntityType(entityInfo, entityInfo.entityType.@value, ue.GetBoolean("useEntityTypeFields"), ue.GetBoolean("useEntityTypeModifiers"), ue.GetBoolean("useEntityTypeExtensions"), factory);
                        }
                        ParseEntityType(entityInfo, descriptorType, true, true, true, factory);
                    } else {
                        Net.TheVpc.Upa.Config.Decoration p = repo.GetTypeDecoration(descriptorType, typeof(Net.TheVpc.Upa.Config.Partial));
                        if (p == null) {
                            entityInfo.entityType.SetBetterValue(descriptorType, configOrder);
                        }
                        ParseEntityType(entityInfo, descriptorType, true, true, true, factory);
                    }
                    Net.TheVpc.Upa.Config.Decoration paramAnn = repo.GetTypeDecoration(descriptorType, typeof(Net.TheVpc.Upa.Config.Property));
                    if (paramAnn != null) {
                        parameterInfos.Add(new Net.TheVpc.Upa.Property(paramAnn.GetString("name"), paramAnn.GetString("value"), paramAnn.GetString("type"), paramAnn.GetString("format")));
                    }
                    Net.TheVpc.Upa.Config.Decoration paramsAnn = repo.GetTypeDecoration(descriptorType, typeof(Net.TheVpc.Upa.Config.Properties));
                    if (paramsAnn != null) {
                        foreach (Net.TheVpc.Upa.Config.DecorationValue p in paramsAnn.GetArray("value")) {
                            //p of type Net.TheVpc.Upa.config.Property
                            Net.TheVpc.Upa.Config.Decoration pp = (Net.TheVpc.Upa.Config.Decoration) p;
                            parameterInfos.Add(new Net.TheVpc.Upa.Property(pp.GetString("name"), pp.GetString("value"), pp.GetString("type"), pp.GetString("format")));
                        }
                    }
                    Net.TheVpc.Upa.Config.Decoration pathDeco = repo.GetTypeDecoration(descriptorType, typeof(Net.TheVpc.Upa.Config.Path));
                    if (pathDeco != null) {
                        Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ValidStr(pathDeco.GetString("value"), entityInfo.path, pathDeco.GetConfig().GetOrder());
                    }
                }
                foreach (Net.TheVpc.Upa.Property parameterInfo in parameterInfos) {
                    entityInfo.GetProperties()[parameterInfo.GetName()]=Net.TheVpc.Upa.Impl.Util.UPAUtils.CreateValue(parameterInfo);
                }
                return Build(entityInfo);
            }
        }

        private Net.TheVpc.Upa.EntityDescriptor Build(Net.TheVpc.Upa.Impl.Config.Annotationparser.EntityInfo entityInfo) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            try {
                System.Collections.Generic.Dictionary<string , object> ctx = new System.Collections.Generic.Dictionary<string , object>();
                foreach (Net.TheVpc.Upa.Impl.Config.Annotationparser.FieldInfo fieldInfo in new System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Config.Annotationparser.FieldInfo>((entityInfo.fieldsMap).Values)) {
                    if (fieldInfo.valid) {
                        fieldInfo.Prepare(ctx, entityInfo.name);
                    }
                }
                //build after all fields has been prepared
                foreach (Net.TheVpc.Upa.Impl.Config.Annotationparser.FieldInfo fieldInfo in new System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Config.Annotationparser.FieldInfo>((entityInfo.fieldsMap).Values)) {
                    if (fieldInfo.valid) {
                        fieldInfo.Build(ctx, entityInfo.name);
                    }
                }
                //remove invalid
                foreach (Net.TheVpc.Upa.Impl.Config.Annotationparser.FieldInfo fieldInfo in new System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Config.Annotationparser.FieldInfo>((entityInfo.fieldsMap).Values)) {
                    if (!fieldInfo.valid) {
                        entityInfo.fieldsMap.Remove(fieldInfo.name);
                    }
                }
                //handle cross depende
                if (entityInfo.idType == null) {
                    Net.TheVpc.Upa.Impl.Config.Annotationparser.FieldInfo pk = null;
                    int pkCount = 0;
                    foreach (Net.TheVpc.Upa.Impl.Config.Annotationparser.FieldInfo fieldInfo in (entityInfo.fieldsMap).Values) {
                        if (fieldInfo.modifiers.Contains(Net.TheVpc.Upa.UserFieldModifier.ID)) {
                            if (pk == null) {
                                pk = fieldInfo;
                            }
                            pkCount++;
                        }
                    }
                    if (pkCount == 1) {
                        entityInfo.idType = pk.type.GetPlatformType();
                    } else {
                        entityInfo.idType = typeof(Net.TheVpc.Upa.Key);
                    }
                }
                entityInfo.fieldsList = new System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Config.Annotationparser.FieldInfo>();
                foreach (Net.TheVpc.Upa.Impl.Config.Annotationparser.FieldInfo allField in (entityInfo.fieldsMap).Values) {
                    entityInfo.fieldsList.Add(allField);
                }
                //            SequenceInfo generatedId = entityInfo.generatedIdInfo;
                //            if (generatedId != null) {
                //                entityInfo.generatedId = new Sequence(
                //                        (generatedId.strategy == null || generatedId.strategy == SequenceStrategy.UNSPECIFIED) ? SequenceStrategy.AUTO : generatedId.strategy,
                //                        generatedId.initialValue == null ? 1 : generatedId.initialValue,
                //                        generatedId.allocationSize == null ? 50 : generatedId.allocationSize,
                //                        generatedId.name,
                //                        generatedId.format);
                //            }
                return entityInfo;
            } catch (System.Exception e) {
                throw new System.ArgumentException ("IllegalArgumentException", e);
            }
        }

        private System.Collections.Generic.IList<Net.TheVpc.Upa.Config.Decoration> FindIndexAnnotation(System.Type type) {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Config.Decoration> list = new System.Collections.Generic.List<Net.TheVpc.Upa.Config.Decoration>();
            Net.TheVpc.Upa.Config.Decoration indexAnn = repo.GetTypeDecoration(type, typeof(Net.TheVpc.Upa.Config.Index));
            if (indexAnn != null) {
                list.Add(indexAnn);
            }
            Net.TheVpc.Upa.Config.Decoration indexAnnAll = repo.GetTypeDecoration(type, typeof(Net.TheVpc.Upa.Config.Indexes));
            if (indexAnnAll != null) {
                foreach (Net.TheVpc.Upa.Config.DecorationValue index in indexAnnAll.GetArray("value")) {
                    if (indexAnn != null) {
                        list.Add((Net.TheVpc.Upa.Config.Decoration) index);
                    }
                }
            }
            return list;
        }

        internal virtual void ParseEntityType(Net.TheVpc.Upa.Impl.Config.Annotationparser.EntityInfo entityInfo, System.Type type, bool parseFields, bool parseModifiers, bool parseExtensions, Net.TheVpc.Upa.ObjectFactory factory) {
            Net.TheVpc.Upa.Config.Decoration ue = repo.GetTypeDecoration(type, typeof(Net.TheVpc.Upa.Config.Entity));
            entityInfo.idType = Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ValidClass(ue == null ? null : ue.GetType("idType"), entityInfo.idType, typeof(object));
            if (ue != null && !ue.GetType("entityType").Equals(typeof(void))) {
                entityInfo.entityType.SetBetterValue(ue.GetType("entityType"), ue.GetConfig().GetOrder());
            }
            entityInfo.name = Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ValidStr(Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ValidStr(ue == null ? null : ue.GetString("name"), entityInfo.name), (type).Name);
            entityInfo.shortName = Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ValidStr(ue == null ? null : ue.GetString("shortName"), entityInfo.shortName);
            if (parseModifiers && ue != null) {
                System.Collections.Generic.List<Net.TheVpc.Upa.EntityModifier> all = new System.Collections.Generic.List<Net.TheVpc.Upa.EntityModifier>();
                foreach (Net.TheVpc.Upa.Config.DecorationValue v in ue.GetArray("modifiers")) {
                    Net.TheVpc.Upa.Impl.Config.Decorations.DecorationPrimitiveValue pv = (Net.TheVpc.Upa.Impl.Config.Decorations.DecorationPrimitiveValue) v;
                    all.Add(Net.TheVpc.Upa.Impl.Util.PlatformUtils.Convert<Net.TheVpc.Upa.EntityModifier>(pv.GetValue(), typeof(Net.TheVpc.Upa.EntityModifier)));
                }
                entityInfo.AddModifiers(all);
                all = new System.Collections.Generic.List<Net.TheVpc.Upa.EntityModifier>();
                foreach (Net.TheVpc.Upa.Config.DecorationValue v in ue.GetArray("excludeModifiers")) {
                    Net.TheVpc.Upa.Impl.Config.Decorations.DecorationPrimitiveValue pv = (Net.TheVpc.Upa.Impl.Config.Decorations.DecorationPrimitiveValue) v;
                    all.Add(Net.TheVpc.Upa.Impl.Util.PlatformUtils.Convert<Net.TheVpc.Upa.EntityModifier>(pv.GetValue(), typeof(Net.TheVpc.Upa.EntityModifier)));
                }
                entityInfo.AddExcludeModifiers(all);
            }
            if (ue != null && ue.GetString("path") != null && (ue.GetString("path")).Length > 0) {
                entityInfo.path.SetBetterValue(ue.GetString("path"), ue.GetConfig().GetOrder());
            }
            if (ue != null && ue.GetString("listOrder") != null && (ue.GetString("listOrder")).Length > 0) {
                entityInfo.listOrder.SetBetterValue(ue.GetString("listOrder"), ue.GetConfig().GetOrder());
            }
            if (ue != null && ue.GetString("archivingOrder") != null && (ue.GetString("archivingOrder")).Length > 0) {
                entityInfo.archivingOrder.SetBetterValue(ue.GetString("archivingOrder"), ue.GetConfig().GetOrder());
            }
            Net.TheVpc.Upa.Config.Decoration path = (Net.TheVpc.Upa.Config.Decoration) repo.GetTypeDecoration(type, typeof(Net.TheVpc.Upa.Config.Path));
            if (path != null) {
                if ((path.GetString("value")).Length > 0) {
                    entityInfo.path.SetBetterValue(path.GetString("value"), path.GetConfig().GetOrder());
                }
                if (path.GetInt("position") != System.Int32.MinValue) {
                    entityInfo.pathPosition.SetBetterValue(path.GetInt("position"), path.GetConfig().GetOrder());
                }
            }
            foreach (Net.TheVpc.Upa.Config.Decoration indexAnn in FindIndexAnnotation(type)) {
                //Net.TheVpc.Upa.config.Index
                System.Collections.Generic.IList<string> rr = new System.Collections.Generic.List<string>();
                Net.TheVpc.Upa.Impl.FwkConvertUtils.ListAddRange(rr, new System.Collections.Generic.List<string>(indexAnn.GetPrimitiveArray<string>("fields", typeof(string))));
                entityInfo.AddIndex(indexAnn.GetString("name"), rr, indexAnn.GetBoolean("unique"), indexAnn.GetConfig().GetOrder());
            }
            //        Net.TheVpc.Upa.config.Sequence gue = (Net.TheVpc.Upa.config.Sequence) type.getAnnotation(Sequence.class);
            //        if (gue != null) {
            //            if (privateInfo.generatedIdInfo == null) {
            //                privateInfo.generatedIdInfo = new SequenceInfo();
            //            }
            //            privateInfo.generatedIdInfo.merge(gue);
            //        }
            if (parseFields) {
                System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Config.Annotationparser.FieldInfo> fieldInfos = new System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Config.Annotationparser.FieldInfo>();
                if (!typeof(Net.TheVpc.Upa.Record).IsAssignableFrom(type)) {
                    System.Type c = type;
                    while (c != null) {
                        System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Config.Annotationparser.FieldInfo> cfields = new System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Config.Annotationparser.FieldInfo>();
                        foreach (System.Reflection.FieldInfo field in c.GetFields(System.Reflection.BindingFlags.Default)) {
                            if (AcceptField(field)) {
                                string fieldName = GetFieldName(field);
                                Net.TheVpc.Upa.Config.Decoration ignored = repo.GetFieldDecoration(field, typeof(Net.TheVpc.Upa.Config.Ignore));
                                if (ignored != null) {
                                    Net.TheVpc.Upa.Impl.Config.Annotationparser.FieldInfo oldValue = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.TheVpc.Upa.Impl.Config.Annotationparser.FieldInfo>(entityInfo.fieldsMap,fieldName);
                                    if (oldValue != null) {
                                        oldValue.valid = false;
                                    }
                                } else {
                                    Net.TheVpc.Upa.Impl.Config.Annotationparser.FieldInfo oldValue = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.TheVpc.Upa.Impl.Config.Annotationparser.FieldInfo>(entityInfo.fieldsMap,fieldName);
                                    if (oldValue == null) {
                                        oldValue = new Net.TheVpc.Upa.Impl.Config.Annotationparser.FieldInfo(fieldName, entityInfo, repo);
                                        cfields.Add(oldValue);
                                    }
                                    oldValue.RegisterField(field);
                                }
                            }
                        }
                        Net.TheVpc.Upa.Impl.FwkConvertUtils.ListInsertRange(fieldInfos, 0, cfields);
                        c = (c).BaseType;
                    }
                }
                foreach (Net.TheVpc.Upa.Impl.Config.Annotationparser.FieldInfo fieldInfo in fieldInfos) {
                    string name = fieldInfo.name;
                    Net.TheVpc.Upa.Impl.Config.Annotationparser.FieldInfo old = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.TheVpc.Upa.Impl.Config.Annotationparser.FieldInfo>(entityInfo.fieldsMap,name);
                    if (old != null) {
                        throw new System.ArgumentException ("Should never happen");
                    }
                    entityInfo.fieldsMap[name]=fieldInfo;
                }
            }
            if (parseExtensions) {
                Net.TheVpc.Upa.Config.Decoration unionEntity = repo.GetTypeDecoration(type, typeof(Net.TheVpc.Upa.Config.UnionEntity));
                if (unionEntity != null) {
                    if (unionEntity.GetType("spec").Equals(typeof(Net.TheVpc.Upa.Extensions.UnionEntityExtensionDefinition))) {
                        string discriminator = unionEntity.GetString("discriminator");
                        //                    String[] fields = unionEntity.fields();
                        //                    UnionEntityEntry[] entities = unionEntity.entities();
                        Net.TheVpc.Upa.Config.DecorationValue[] entities = unionEntity.GetArray("entities");
                        System.Collections.Generic.IList<string> _entities = new System.Collections.Generic.List<string>();
                        System.Collections.Generic.IList<string> _fields = new System.Collections.Generic.List<string>();
                        Net.TheVpc.Upa.Impl.FwkConvertUtils.ListAddRange(_fields, new System.Collections.Generic.List<string>(unionEntity.GetPrimitiveArray<string>("fields", typeof(string))));
                        string _entityFieldName = discriminator;
                        string[][] _mapping = (string[][])Net.TheVpc.Upa.Impl.FwkConvertUtils.CreateMultiArray(typeof(string),entities.Length,(_fields).Count);
                        int ientity = 0;
                        foreach (Net.TheVpc.Upa.Config.DecorationValue entity0 in entities) {
                            Net.TheVpc.Upa.Config.Decoration entity = (Net.TheVpc.Upa.Config.Decoration) entity0;
                            //UnionEntityEntry
                            _entities.Add(entity.GetString("entity"));
                            int ifield = 0;
                            foreach (string field in _fields) {
                                string f = null;
                                string[] efields = entity.GetPrimitiveArray<string>("fields", typeof(string));
                                if (ifield < efields.Length) {
                                    f = efields[ifield];
                                }
                                if (f == null) {
                                    f = field;
                                }
                                _mapping[ientity][ifield] = f;
                                ifield++;
                            }
                            ientity++;
                        }
                        entityInfo.specs.Add(new Net.TheVpc.Upa.Extensions.DefaultUnionEntityExtensionDefinition(new Net.TheVpc.Upa.Extensions.UnionQueryInfo(_entities, _fields, _entityFieldName, _mapping)));
                    } else {
                        entityInfo.specs.Add((Net.TheVpc.Upa.Extensions.EntityExtensionDefinition) factory.CreateObject<T>(unionEntity.GetType("spec")));
                    }
                }
                Net.TheVpc.Upa.Config.Decoration view = (Net.TheVpc.Upa.Config.Decoration) repo.GetTypeDecoration(type, typeof(Net.TheVpc.Upa.Config.View));
                if (view != null) {
                    System.Type spec = view.GetType("spec");
                    if (spec.Equals(typeof(Net.TheVpc.Upa.Extensions.ViewEntityExtensionDefinition))) {
                        throw new System.ArgumentException ("Unsupported");
                    } else {
                        entityInfo.specs.Add(factory.CreateObject<Net.TheVpc.Upa.Extensions.ViewEntityExtensionDefinition>(spec));
                    }
                }
            }
        }

        public virtual string GetFieldName(System.Reflection.FieldInfo javaField) {
            string name = null;
            if (AcceptField(javaField)) {
                Net.TheVpc.Upa.Config.Decoration anno = repo.GetFieldDecoration(javaField, typeof(Net.TheVpc.Upa.Config.Field));
                if (anno != null) {
                    name = anno.GetString("name");
                }
                if (name == null || (name).Length == 0) {
                    name = (javaField).Name;
                }
            }
            return name;
        }

        public virtual bool AcceptField(System.Reflection.FieldInfo field) {
            if (field.GetType().Equals(typeof(Net.TheVpc.Upa.Config.FieldDesc))) {
                return true;
            }
            return !Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsStatic(field) && !Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsTransient(field) && repo.GetFieldDecoration(field, typeof(System.NonSerializedAttribute)) == null;
        }
    }
}
