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



namespace Net.Vpc.Upa.Impl
{


    public class DefaultSection : Net.Vpc.Upa.Impl.AbstractUPAObject, Net.Vpc.Upa.Section {

        private Net.Vpc.Upa.Entity entity;

        private Net.Vpc.Upa.EntityPart parent;

        private System.Collections.Generic.IList<Net.Vpc.Upa.EntityPart> parts;

        private System.Collections.Generic.IDictionary<string , Net.Vpc.Upa.EntityPart> childrenMap;

        private bool closed;

        public DefaultSection()  : base(){

            this.parent = null;
            this.parts = new System.Collections.Generic.List<Net.Vpc.Upa.EntityPart>(3);
            childrenMap = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.EntityPart>();
        }


        public override string GetAbsoluteName() {
            Net.Vpc.Upa.EntityPart parentSchemaItem = GetParent();
            if (parentSchemaItem == null) {
                return GetEntity().GetAbsoluteName() + "." + GetName();
            }
            return parentSchemaItem.GetAbsoluteName() + "/" + GetName();
        }

        public virtual void SetEntity(Net.Vpc.Upa.Entity entity) {
            Net.Vpc.Upa.Entity old = this.entity;
            this.entity = entity;
            propertyChangeSupport.FirePropertyChange("entity", old, entity);
        }

        public virtual void AddPart(Net.Vpc.Upa.EntityPart child) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            AddPart(child, -1);
        }


        public virtual void AddPart(Net.Vpc.Upa.EntityPart child, int index) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Impl.Util.ListUtils.Add<Net.Vpc.Upa.EntityPart>(parts, child, index, this, this, new Net.Vpc.Upa.Impl.DefaultSectionPrivateAddItemInterceptor(this));
        }

        public virtual Net.Vpc.Upa.EntityPart RemovePart(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            int i = IndexOfPart(name);
            if (i >= 0) {
                return RemovePartAt(i);
            }
            throw new Net.Vpc.Upa.Exceptions.NoSuchEntityItemException(name);
        }

        public virtual Net.Vpc.Upa.EntityPart GetPartAt(int index) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return parts[index];
        }

        public virtual Net.Vpc.Upa.EntityPart GetPart(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            int i = IndexOfPart(name);
            if (i >= 0) {
                return GetPartAt(i);
            }
            throw new Net.Vpc.Upa.Exceptions.NoSuchEntityItemException(name);
        }

        public virtual Net.Vpc.Upa.EntityPart RemovePartAt(int index) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.EntityPart child = Net.Vpc.Upa.Impl.Util.ListUtils.Remove<Net.Vpc.Upa.EntityPart>(parts, index, this, new Net.Vpc.Upa.Impl.DefaultSectionPrivateRemoveItemInterceptor());
            return child;
        }

        public virtual void MovePart(string itemName, int newIndex) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            MovePart(IndexOfPart(itemName), newIndex);
        }

        public virtual void MovePart(int index, int newIndex) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Impl.Util.ListUtils.MoveTo<Net.Vpc.Upa.EntityPart>(parts, index, newIndex, this, null);
        }

        public virtual Net.Vpc.Upa.Section GetSection(string path, Net.Vpc.Upa.MissingStrategy missingStrategy) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (path == null) {
                throw new System.NullReferenceException();
            }
            string[] canonicalPathArray = Net.Vpc.Upa.Impl.Util.UPAUtils.GetCanonicalPathArray(path);
            if (canonicalPathArray.Length == 0) {
                throw new System.ArgumentException ("invalid module path " + path);
            }
            Net.Vpc.Upa.Section module = null;
            foreach (string n in canonicalPathArray) {
                Net.Vpc.Upa.Section next = null;
                if (module == null) {
                    foreach (Net.Vpc.Upa.EntityPart schemaItem in parts) {
                        if (schemaItem is Net.Vpc.Upa.Section) {
                            if (schemaItem.GetName().Equals(n)) {
                                next = (Net.Vpc.Upa.Section) schemaItem;
                                break;
                            }
                        }
                    }
                    if (next == null) {
                        switch(missingStrategy) {
                            case Net.Vpc.Upa.MissingStrategy.ERROR:
                                {
                                    throw new Net.Vpc.Upa.Exceptions.NoSuchSectionException(path);
                                }
                            case Net.Vpc.Upa.MissingStrategy.CREATE:
                                {
                                    next = AddSection(n, null);
                                    break;
                                }
                            case Net.Vpc.Upa.MissingStrategy.NULL:
                                {
                                    return null;
                                }
                            default:
                                {
                                    throw new System.Exception();
                                }
                        }
                    }
                } else {
                    try {
                        next = module.GetSection(n);
                    } catch (Net.Vpc.Upa.Exceptions.NoSuchSectionException e) {
                        switch(missingStrategy) {
                            case Net.Vpc.Upa.MissingStrategy.ERROR:
                                {
                                    throw new Net.Vpc.Upa.Exceptions.NoSuchSectionException(path);
                                }
                            case Net.Vpc.Upa.MissingStrategy.CREATE:
                                {
                                    next = AddSection(n, module.GetPath());
                                    break;
                                }
                            case Net.Vpc.Upa.MissingStrategy.NULL:
                                {
                                    return null;
                                }
                            default:
                                {
                                    throw new System.Exception();
                                }
                        }
                    }
                }
                module = next;
            }
            return module;
        }

        public virtual Net.Vpc.Upa.Section GetSection(string name) {
            return GetSection(name, Net.Vpc.Upa.MissingStrategy.ERROR);
        }

        public virtual Net.Vpc.Upa.Section FindSection(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetSection(name, Net.Vpc.Upa.MissingStrategy.NULL);
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.EntityPart> GetParts() {
            return Net.Vpc.Upa.Impl.Util.PlatformUtils.UnmodifiableList<Net.Vpc.Upa.EntityPart>(parts);
        }

        public virtual int IndexOfPart(Net.Vpc.Upa.EntityPart child) {
            return parts.IndexOf(child);
        }

        public virtual int IndexOfPart(string childName) {
            int index = 0;
            foreach (Net.Vpc.Upa.EntityPart child in parts) {
                if (childName.Equals(child.GetName())) {
                    return index;
                }
                index++;
            }
            return -1;
        }

        public virtual Net.Vpc.Upa.Entity GetEntity() {
            return entity;
        }

        public virtual Net.Vpc.Upa.EntityPart GetParent() {
            return parent;
        }

        public virtual void SetParent(Net.Vpc.Upa.EntityPart item) {
            Net.Vpc.Upa.EntityPart old = this.parent;
            this.parent = item;
            propertyChangeSupport.FirePropertyChange("parent", old, parent);
        }

        public virtual string GetPath() {
            Net.Vpc.Upa.EntityPart parent = GetParent();
            return parent == null ? ("/" + GetName()) : (parent.GetPath() + "/" + GetName());
        }


        public virtual int GetPartsCount() {
            return (parts).Count;
        }


        public override bool Equals(object o) {
            if (this == o) {
                return true;
            }
            if (o == null || GetType() != o.GetType()) {
                return false;
            }
            Net.Vpc.Upa.Impl.DefaultSection that = (Net.Vpc.Upa.Impl.DefaultSection) o;
            if (GetName() != null ? !GetName().Equals(that.GetName()) : that.GetName() != null) {
                return false;
            }
            if (parent != null ? !parent.Equals(that.parent) : that.parent != null) {
                return false;
            }
            if (entity != null ? !entity.Equals(that.entity) : that.entity != null) {
                return false;
            }
            return true;
        }


        public override int GetHashCode() {
            int result = base.GetHashCode();
            result = 31 * result + (parent != null ? parent.GetHashCode() : 0);
            return result;
        }


        public override void Close() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            bool old = this.closed;
            if (!old) {
                foreach (Net.Vpc.Upa.EntityPart child in parts) {
                    child.Close();
                }
                this.closed = true;
                propertyChangeSupport.FirePropertyChange("closed", old, closed);
            }
        }

        public virtual bool IsClosed() {
            return closed;
        }


        public virtual Net.Vpc.Upa.Field AddField(string name, Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> modifiers, object defaultValue, Net.Vpc.Upa.Types.DataType type) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetEntity().AddField(name, GetPath(), modifiers, defaultValue, type);
        }


        public virtual Net.Vpc.Upa.Field AddField(string name, Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> modifiers, object defaultValue, Net.Vpc.Upa.Types.DataType type, int index) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetEntity().AddField(name, GetPath(), modifiers, null, defaultValue, type, index);
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Field> GetFields() {
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> fields = new System.Collections.Generic.List<Net.Vpc.Upa.Field>();
            foreach (Net.Vpc.Upa.EntityPart part in GetParts()) {
                if (part is Net.Vpc.Upa.Field) {
                    fields.Add((Net.Vpc.Upa.Field) part);
                }
            }
            return fields;
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Section> GetSections() {
            System.Collections.Generic.IList<Net.Vpc.Upa.Section> sections = new System.Collections.Generic.List<Net.Vpc.Upa.Section>();
            foreach (Net.Vpc.Upa.EntityPart part in GetParts()) {
                if (part is Net.Vpc.Upa.Section) {
                    sections.Add((Net.Vpc.Upa.Section) part);
                }
            }
            return sections;
        }


        public virtual Net.Vpc.Upa.Section AddSection(string name, string parentPath, int index) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (name == null) {
                throw new System.NullReferenceException();
            }
            if (name.Contains("/")) {
                throw new System.ArgumentException ("Name cannot contain '/'");
            }
            string[] canonicalPathArray = Net.Vpc.Upa.Impl.Util.UPAUtils.GetCanonicalPathArray(parentPath);
            Net.Vpc.Upa.Section parentModule = null;
            foreach (string n in canonicalPathArray) {
                Net.Vpc.Upa.Section next = null;
                if (parentModule == null) {
                    next = GetSection(n);
                } else {
                    next = parentModule.GetSection(n);
                }
                parentModule = next;
            }
            Net.Vpc.Upa.Section currentModule = GetPersistenceUnit().GetFactory().CreateObject<Net.Vpc.Upa.Section>(typeof(Net.Vpc.Upa.Section));
            Net.Vpc.Upa.Impl.Util.DefaultBeanAdapter a = Net.Vpc.Upa.Impl.Util.UPAUtils.Prepare(GetPersistenceUnit(), currentModule, name);
            if (parentModule == null) {
                AddPart(currentModule, index);
            } else {
                parentModule.AddPart(currentModule, index);
            }
            //invalidateStructureCache();
            return currentModule;
        }


        public virtual Net.Vpc.Upa.Section AddSection(string name, string parentPath) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return AddSection(name, parentPath, -1);
        }

        public virtual Net.Vpc.Upa.Section AddSection(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return AddSection(name, null, -1);
        }

        public virtual Net.Vpc.Upa.Section AddSection(string name, int index) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return AddSection(name, null, index);
        }
    }
}
