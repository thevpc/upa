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



namespace Net.TheVpc.Upa.Impl
{


    public class DefaultSection : Net.TheVpc.Upa.Impl.AbstractUPAObject, Net.TheVpc.Upa.Section {

        private Net.TheVpc.Upa.Entity entity;

        private Net.TheVpc.Upa.EntityPart parent;

        private System.Collections.Generic.IList<Net.TheVpc.Upa.EntityPart> parts;

        private System.Collections.Generic.IDictionary<string , Net.TheVpc.Upa.EntityPart> childrenMap;

        private bool closed;

        public DefaultSection()  : base(){

            this.parent = null;
            this.parts = new System.Collections.Generic.List<Net.TheVpc.Upa.EntityPart>(3);
            childrenMap = new System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.EntityPart>();
        }


        public override string GetAbsoluteName() {
            Net.TheVpc.Upa.EntityPart parentSchemaItem = GetParent();
            if (parentSchemaItem == null) {
                return GetEntity().GetAbsoluteName() + "." + GetName();
            }
            return parentSchemaItem.GetAbsoluteName() + "/" + GetName();
        }

        public virtual void SetEntity(Net.TheVpc.Upa.Entity entity) {
            Net.TheVpc.Upa.Entity old = this.entity;
            this.entity = entity;
            propertyChangeSupport.FirePropertyChange("entity", old, entity);
        }

        public virtual void AddPart(Net.TheVpc.Upa.EntityPart child) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            AddPart(child, -1);
        }


        public virtual void AddPart(Net.TheVpc.Upa.EntityPart child, int index) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Impl.Util.ListUtils.Add<Net.TheVpc.Upa.EntityPart>(parts, child, index, this, this, new Net.TheVpc.Upa.Impl.DefaultSectionPrivateAddItemInterceptor(this));
        }

        public virtual Net.TheVpc.Upa.EntityPart RemovePart(string name) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            int i = IndexOfPart(name);
            if (i >= 0) {
                return RemovePartAt(i);
            }
            throw new Net.TheVpc.Upa.Exceptions.NoSuchEntityItemException(name);
        }

        public virtual Net.TheVpc.Upa.EntityPart GetPartAt(int index) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return parts[index];
        }

        public virtual Net.TheVpc.Upa.EntityPart GetPart(string name) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            int i = IndexOfPart(name);
            if (i >= 0) {
                return GetPartAt(i);
            }
            throw new Net.TheVpc.Upa.Exceptions.NoSuchEntityItemException(name);
        }

        public virtual Net.TheVpc.Upa.EntityPart RemovePartAt(int index) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.EntityPart child = Net.TheVpc.Upa.Impl.Util.ListUtils.Remove<Net.TheVpc.Upa.EntityPart>(parts, index, this, new Net.TheVpc.Upa.Impl.DefaultSectionPrivateRemoveItemInterceptor());
            return child;
        }

        public virtual void MovePart(string itemName, int newIndex) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            MovePart(IndexOfPart(itemName), newIndex);
        }

        public virtual void MovePart(int index, int newIndex) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Impl.Util.ListUtils.MoveTo<T>(parts, index, newIndex, this, null);
        }

        public virtual Net.TheVpc.Upa.Section GetSection(string path, Net.TheVpc.Upa.MissingStrategy missingStrategy) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (path == null) {
                throw new System.NullReferenceException();
            }
            string[] canonicalPathArray = Net.TheVpc.Upa.Impl.Util.UPAUtils.GetCanonicalPathArray(path);
            if (canonicalPathArray.Length == 0) {
                throw new System.ArgumentException ("invalid module path " + path);
            }
            Net.TheVpc.Upa.Section module = null;
            foreach (string n in canonicalPathArray) {
                Net.TheVpc.Upa.Section next = null;
                if (module == null) {
                    foreach (Net.TheVpc.Upa.EntityPart schemaItem in parts) {
                        if (schemaItem is Net.TheVpc.Upa.Section) {
                            if (schemaItem.GetName().Equals(n)) {
                                next = (Net.TheVpc.Upa.Section) schemaItem;
                                break;
                            }
                        }
                    }
                    if (next == null) {
                        switch(missingStrategy) {
                            case Net.TheVpc.Upa.MissingStrategy.ERROR:
                                {
                                    throw new Net.TheVpc.Upa.Exceptions.NoSuchSectionException(path);
                                }
                            case Net.TheVpc.Upa.MissingStrategy.CREATE:
                                {
                                    next = AddSection(n, null);
                                    break;
                                }
                            case Net.TheVpc.Upa.MissingStrategy.NULL:
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
                    } catch (Net.TheVpc.Upa.Exceptions.NoSuchSectionException e) {
                        switch(missingStrategy) {
                            case Net.TheVpc.Upa.MissingStrategy.ERROR:
                                {
                                    throw new Net.TheVpc.Upa.Exceptions.NoSuchSectionException(path);
                                }
                            case Net.TheVpc.Upa.MissingStrategy.CREATE:
                                {
                                    next = AddSection(n, module.GetPath());
                                    break;
                                }
                            case Net.TheVpc.Upa.MissingStrategy.NULL:
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

        public virtual Net.TheVpc.Upa.Section GetSection(string name) {
            return GetSection(name, Net.TheVpc.Upa.MissingStrategy.ERROR);
        }

        public virtual Net.TheVpc.Upa.Section FindSection(string name) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetSection(name, Net.TheVpc.Upa.MissingStrategy.NULL);
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.EntityPart> GetParts() {
            return Net.TheVpc.Upa.Impl.Util.PlatformUtils.UnmodifiableList<Net.TheVpc.Upa.EntityPart>(parts);
        }

        public virtual int IndexOfPart(Net.TheVpc.Upa.EntityPart child) {
            return parts.IndexOf(child);
        }

        public virtual int IndexOfPart(string childName) {
            int index = 0;
            foreach (Net.TheVpc.Upa.EntityPart child in parts) {
                if (childName.Equals(child.GetName())) {
                    return index;
                }
                index++;
            }
            return -1;
        }

        public virtual Net.TheVpc.Upa.Entity GetEntity() {
            return entity;
        }

        public virtual Net.TheVpc.Upa.EntityPart GetParent() {
            return parent;
        }

        public virtual void SetParent(Net.TheVpc.Upa.EntityPart item) {
            Net.TheVpc.Upa.EntityPart old = this.parent;
            this.parent = item;
            propertyChangeSupport.FirePropertyChange("parent", old, parent);
        }

        public virtual string GetPath() {
            Net.TheVpc.Upa.EntityPart parent = GetParent();
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
            Net.TheVpc.Upa.Impl.DefaultSection that = (Net.TheVpc.Upa.Impl.DefaultSection) o;
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


        public override void Close() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            bool old = this.closed;
            if (!old) {
                foreach (Net.TheVpc.Upa.EntityPart child in parts) {
                    child.Close();
                }
                this.closed = true;
                propertyChangeSupport.FirePropertyChange("closed", old, closed);
            }
        }

        public virtual bool IsClosed() {
            return closed;
        }


        public virtual Net.TheVpc.Upa.Field AddField(string name, Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> modifiers, object defaultValue, Net.TheVpc.Upa.Types.DataType type) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetEntity().AddField(name, GetPath(), modifiers, defaultValue, type);
        }


        public virtual Net.TheVpc.Upa.Field AddField(string name, Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> modifiers, object defaultValue, Net.TheVpc.Upa.Types.DataType type, int index) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetEntity().AddField(name, GetPath(), modifiers, null, defaultValue, type, index);
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Field> GetFields() {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> fields = new System.Collections.Generic.List<Net.TheVpc.Upa.Field>();
            foreach (Net.TheVpc.Upa.EntityPart part in GetParts()) {
                if (part is Net.TheVpc.Upa.Field) {
                    fields.Add((Net.TheVpc.Upa.Field) part);
                }
            }
            return fields;
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Section> GetSections() {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Section> sections = new System.Collections.Generic.List<Net.TheVpc.Upa.Section>();
            foreach (Net.TheVpc.Upa.EntityPart part in GetParts()) {
                if (part is Net.TheVpc.Upa.Section) {
                    sections.Add((Net.TheVpc.Upa.Section) part);
                }
            }
            return sections;
        }


        public virtual Net.TheVpc.Upa.Section AddSection(string name, string parentPath, int index) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (name == null) {
                throw new System.NullReferenceException();
            }
            if (name.Contains("/")) {
                throw new System.ArgumentException ("Name cannot contain '/'");
            }
            string[] canonicalPathArray = Net.TheVpc.Upa.Impl.Util.UPAUtils.GetCanonicalPathArray(parentPath);
            Net.TheVpc.Upa.Section parentModule = null;
            foreach (string n in canonicalPathArray) {
                Net.TheVpc.Upa.Section next = null;
                if (parentModule == null) {
                    next = GetSection(n);
                } else {
                    next = parentModule.GetSection(n);
                }
                parentModule = next;
            }
            Net.TheVpc.Upa.Section currentModule = GetPersistenceUnit().GetFactory().CreateObject<Net.TheVpc.Upa.Section>(typeof(Net.TheVpc.Upa.Section));
            Net.TheVpc.Upa.Impl.Util.DefaultBeanAdapter a = Net.TheVpc.Upa.Impl.Util.UPAUtils.Prepare(GetPersistenceUnit(), currentModule, name);
            if (parentModule == null) {
                AddPart(currentModule, index);
            } else {
                parentModule.AddPart(currentModule, index);
            }
            //invalidateStructureCache();
            return currentModule;
        }


        public virtual Net.TheVpc.Upa.Section AddSection(string name, string parentPath) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return AddSection(name, parentPath, -1);
        }

        public virtual Net.TheVpc.Upa.Section AddSection(string name) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return AddSection(name, null, -1);
        }

        public virtual Net.TheVpc.Upa.Section AddSection(string name, int index) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return AddSection(name, null, index);
        }
    }
}
