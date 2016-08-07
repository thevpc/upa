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



namespace Net.Vpc.Upa.Impl.Config.Annotationparser
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/15/12 11:46 AM
     */
    internal class RelationshipInfo : Net.Vpc.Upa.RelationshipDescriptor {

        private Net.Vpc.Upa.Impl.Config.Annotationparser.FieldInfo baseFieldInfo;

        private string name;

        private string entityField;

        private string[] mappedTo = new string[0];

        private Net.Vpc.Upa.RelationshipType relationType;

        private string targetEntity;

        private string filter;

        private System.Type targetEntityType;

        private int manyToOneConfigOrder;

        private int hierarchyConfigOrder;

        private string hierarchyPathSeparator;

        private bool hierarchy;

        private bool manyToOne;

        private bool nullable = true;

        private string hierarchyPathField;

        private bool specified = false;

        private bool producesRelation = true;

        private System.Collections.Generic.IList<System.Reflection.FieldInfo> fieldsList;

        private Net.Vpc.Upa.Impl.Config.Decorations.DecorationRepository repo;

        private Net.Vpc.Upa.Types.DataType preferredDataType;

        public RelationshipInfo(Net.Vpc.Upa.Impl.Config.Annotationparser.FieldInfo baseFieldInfo, Net.Vpc.Upa.Impl.Config.Decorations.DecorationRepository repo) {
            this.baseFieldInfo = baseFieldInfo;
            this.repo = repo;
        }

        public virtual void Parse(System.Collections.Generic.IList<System.Reflection.FieldInfo> fields, bool nullable) {
            fieldsList = fields;
            System.Collections.Generic.IList<Net.Vpc.Upa.Config.Decoration> manyToOneDecorations = new System.Collections.Generic.List<Net.Vpc.Upa.Config.Decoration>();
            System.Collections.Generic.IList<Net.Vpc.Upa.Config.Decoration> hierarchyDecorations = new System.Collections.Generic.List<Net.Vpc.Upa.Config.Decoration>();
            foreach (System.Reflection.FieldInfo javaField in fields) {
                Net.Vpc.Upa.Config.Decoration gid = repo.GetFieldDecoration(javaField, typeof(Net.Vpc.Upa.Config.ManyToOne));
                Net.Vpc.Upa.Config.Decoration gid2 = repo.GetFieldDecoration(javaField, typeof(Net.Vpc.Upa.Config.Hierarchy));
                if (gid != null) {
                    //                ConfigInfo config = gid.getConfig();
                    manyToOneDecorations.Add(gid);
                }
                if (gid2 != null) {
                    //                ConfigInfo config = gid.getConfig();
                    hierarchyDecorations.Add(gid2);
                }
            }
            if ((manyToOneDecorations).Count > 1) {
                Net.Vpc.Upa.Impl.FwkConvertUtils.ListSort(manyToOneDecorations, Net.Vpc.Upa.Impl.Config.Annotationparser.DecorationComparator.INSTANCE);
            }
            if ((hierarchyDecorations).Count > 1) {
                Net.Vpc.Upa.Impl.FwkConvertUtils.ListSort(hierarchyDecorations, Net.Vpc.Upa.Impl.Config.Annotationparser.DecorationComparator.INSTANCE);
            }
            foreach (Net.Vpc.Upa.Config.Decoration gid in manyToOneDecorations) {
                MergeManyToOne(gid);
            }
            foreach (Net.Vpc.Upa.Config.Decoration gid in hierarchyDecorations) {
                MergeHierarchy(gid);
            }
            if (GetTargetEntityType() == null || GetTargetEntityType().Equals(typeof(void))) {
                SetTargetEntityType(GetFieldType());
            }
            if (IsManyToOne()) {
                System.Type nativeClass = GetFieldType();
                if (!Net.Vpc.Upa.Impl.Util.UPAUtils.IsSimpleFieldType(nativeClass)) {
                    Net.Vpc.Upa.Types.ManyToOneType manyToOneType = new Net.Vpc.Upa.Types.ManyToOneType(name, nativeClass, null, true, nullable);
                    preferredDataType = (manyToOneType);
                }
            }
        }

        public virtual Net.Vpc.Upa.Types.DataType GetPreferredDataType() {
            return preferredDataType;
        }

        private System.Type GetFieldType() {
            foreach (System.Reflection.FieldInfo f in fieldsList) {
                return f.GetType();
            }
            return null;
        }

        public virtual void MergeHierarchy(Net.Vpc.Upa.Config.Decoration gid) {
            if (gid.GetConfig().GetOrder() >= hierarchyConfigOrder) {
                specified = true;
                hierarchy = true;
                manyToOne = true;
                targetEntity = baseFieldInfo.GetEntityInfo().GetName();
                System.Type entityType = baseFieldInfo.GetEntityInfo().GetEntityType();
                targetEntityType = entityType;
                if (Net.Vpc.Upa.Impl.Util.PlatformUtils.IsUndefinedValue<Net.Vpc.Upa.RelationshipType>(typeof(Net.Vpc.Upa.RelationshipType), relationType)) {
                    relationType = Net.Vpc.Upa.RelationshipType.COMPOSITION;
                }
                System.Type nativeClass = GetFieldType();
                if (!nativeClass.Equals(entityType)) {
                    throw new System.ArgumentException ("Tree Relationship invalid as " + nativeClass + " <> " + entityType);
                }
                if ((gid.GetString("path")).Length > 0) {
                    hierarchyPathField = gid.GetString("path");
                }
                if ((gid.GetString("separator")).Length > 0) {
                    hierarchyPathSeparator = gid.GetString("separator");
                }
                if (gid.GetConfig().GetOrder() > hierarchyConfigOrder) {
                    hierarchyConfigOrder = gid.GetConfig().GetOrder();
                }
            }
        }

        public virtual void MergeManyToOne(Net.Vpc.Upa.Config.Decoration gid) {
            if (gid.GetConfig().GetOrder() >= manyToOneConfigOrder) {
                specified = true;
                manyToOne = true;
                System.Type nativeClass = GetFieldType();
                if ((nativeClass).IsArray) {
                    throw new System.ArgumentException ("Invalid Array type " + nativeClass + " for ManyToOne");
                }
                if (typeof(System.Type).IsAssignableFrom(nativeClass)) {
                    throw new System.ArgumentException ("Invalid Collection type " + nativeClass + " for ManyToOne");
                }
                if ((nativeClass).IsEnum) {
                    throw new System.ArgumentException ("Enumerations are not supported in Relations");
                }
                if ((gid.GetString("name")).Length > 0) {
                    name = gid.GetString("name");
                }
                string[] _mappedTo = gid.GetPrimitiveArray<string>("mappedTo", typeof(string));
                if (_mappedTo.Length != 0) {
                    mappedTo = _mappedTo;
                }
                if (!System.Collections.Generic.EqualityComparer<Net.Vpc.Upa.RelationshipType>.Default.Equals(gid.GetEnum<Net.Vpc.Upa.RelationshipType>("type", typeof(Net.Vpc.Upa.RelationshipType)),Net.Vpc.Upa.RelationshipType.DEFAULT)) {
                    relationType = gid.GetEnum<Net.Vpc.Upa.RelationshipType>("type", typeof(Net.Vpc.Upa.RelationshipType));
                }
                if ((gid.GetString("filter")).Length > 0) {
                    filter = gid.GetString("filter");
                }
                entityField = (fieldsList[0]).Name;
                string _targetEntity = gid.GetString("targetEntity");
                System.Type _targetEntityType = gid.GetType("targetEntityType");
                if ((_targetEntity).Length > 0 && !_targetEntityType.Equals(typeof(void))) {
                    //problem
                    throw new System.ArgumentException ("Could not support both targetEntity and targetEntityType");
                } else if ((_targetEntity).Length > 0) {
                    targetEntity = _targetEntity;
                    targetEntityType = null;
                } else if (!_targetEntityType.Equals(typeof(void))) {
                    targetEntity = null;
                    targetEntityType = _targetEntityType;
                }
                if (Net.Vpc.Upa.Impl.Util.UPAUtils.IsSimpleFieldType(nativeClass)) {
                    if ((targetEntityType == null || targetEntityType.Equals(typeof(void))) && targetEntity == null) {
                        throw new System.ArgumentException ("Missing targetEntityType in field " + baseFieldInfo.GetEntityInfo().GetName() + "." + name);
                    }
                }
                if (gid.GetConfig().GetOrder() > manyToOneConfigOrder) {
                    manyToOneConfigOrder = gid.GetConfig().GetOrder();
                }
            }
        }

        public virtual int GetHierarchyConfigOrder() {
            return hierarchyConfigOrder;
        }

        public virtual string GetHierarchyPathSeparator() {
            return hierarchyPathSeparator;
        }

        public virtual bool IsHierarchy() {
            return hierarchy;
        }

        public virtual string GetHierarchyPathField() {
            return hierarchyPathField;
        }

        public virtual string GetSourceEntity() {
            return baseFieldInfo.GetEntityInfo().GetName();
        }

        public virtual System.Type GetSourceEntityType() {
            return null;
        }

        public virtual string GetName() {
            return name;
        }

        public virtual string GetEntityField() {
            return entityField;
        }

        public virtual string[] GetMappedTo() {
            return mappedTo;
        }

        public virtual Net.Vpc.Upa.RelationshipType GetRelationshipType() {
            return relationType;
        }

        public virtual string GetTargetEntity() {
            return targetEntity;
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetFilter() {
            return filter == null ? null : new Net.Vpc.Upa.Expressions.UserExpression(filter);
        }

        public virtual System.Type GetTargetEntityType() {
            return targetEntityType;
        }

        public virtual int GetConfigOrder() {
            return manyToOneConfigOrder;
        }

        public virtual bool IsSpecified() {
            return specified;
        }

        public virtual bool IsProducesRelation() {
            return producesRelation;
        }

        public virtual string GetBaseField() {
            return baseFieldInfo.name;
        }

        public virtual void SetBaseFieldInfo(Net.Vpc.Upa.Impl.Config.Annotationparser.FieldInfo baseFieldInfo) {
            this.baseFieldInfo = baseFieldInfo;
        }

        public virtual void SetName(string name) {
            this.name = name;
        }

        public virtual void SetEntityField(string entityField) {
            this.entityField = entityField;
        }

        public virtual void SetMappedTo(string[] mappedTo) {
            this.mappedTo = mappedTo;
        }

        public virtual void SetRelationshipType(Net.Vpc.Upa.RelationshipType relationType) {
            this.relationType = relationType;
        }

        public virtual void SetTargetEntity(string targetEntity) {
            this.targetEntity = targetEntity;
        }

        public virtual void SetFilter(string filter) {
            this.filter = filter;
        }

        public virtual void SetTargetEntityType(System.Type targetEntityType) {
            this.targetEntityType = targetEntityType;
        }

        public virtual void SetConfigOrder(int configOrder) {
            this.manyToOneConfigOrder = configOrder;
        }

        public virtual void SetSpecified(bool specified) {
            this.specified = specified;
        }

        public virtual void SetProducesRelation(bool producesRelation) {
            this.producesRelation = producesRelation;
        }

        public virtual void SetFieldsList(System.Collections.Generic.IList<System.Reflection.FieldInfo> fieldsList) {
            this.fieldsList = fieldsList;
        }

        public virtual bool IsManyToOne() {
            return manyToOne;
        }


        public virtual bool IsNullable() {
            return nullable;
        }

        public virtual Net.Vpc.Upa.Impl.Config.Annotationparser.RelationshipInfo SetNullable(bool nullable) {
            this.nullable = nullable;
            return this;
        }

        /**
             * not used!
             * @return 
             */
        public virtual string[] GetSourceFields() {
            return null;
        }


        public override string ToString() {
            return "RelationInfo{" + "baseFieldInfo=" + baseFieldInfo + ", name=" + name + ", entityField=" + entityField + ", mappedTo=" + (mappedTo == null ? "" : System.Convert.ToString(mappedTo)) + ", relationType=" + relationType + ", targetEntity=" + targetEntity + ", filter=" + filter + ", targetEntityType=" + targetEntityType + ", configOrder=" + manyToOneConfigOrder + ", specified=" + specified + ", producesRelation=" + producesRelation + ", fieldsList=" + fieldsList + '}';
        }
    }
}
