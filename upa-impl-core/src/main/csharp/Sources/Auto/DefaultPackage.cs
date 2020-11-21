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


    public class DefaultPackage : Net.TheVpc.Upa.Impl.AbstractUPAObject, Net.TheVpc.Upa.Package {

        private Net.TheVpc.Upa.Package parent;

        private System.Collections.Generic.IList<Net.TheVpc.Upa.PersistenceUnitPart> parts;

        private bool closed;

        public DefaultPackage() {
            this.parent = null;
            this.parts = new System.Collections.Generic.List<Net.TheVpc.Upa.PersistenceUnitPart>(3);
        }


        public override string GetAbsoluteName() {
            Net.TheVpc.Upa.PersistenceUnitPart parentPersistenceUnitItem = GetParent();
            if (parentPersistenceUnitItem == null) {
                return GetName();
            }
            return parentPersistenceUnitItem.GetAbsoluteName() + "/" + GetName();
        }

        public virtual void AddPart(Net.TheVpc.Upa.PersistenceUnitPart child) {
            AddPart(child, GetPartsCount());
        }

        public virtual void AddPart(Net.TheVpc.Upa.PersistenceUnitPart part, int index) {
            if (index < 0) {
                index = GetPartsCount() + index + 1;
            }
            if (index < 0) {
                throw new System.IndexOutOfRangeException("Invalid Index "+(index));
            }
            if (index > (parts).Count) {
                throw new System.IndexOutOfRangeException("Invalid Index "+(index));
            }
            Net.TheVpc.Upa.Impl.Util.ListUtils.Add<Net.TheVpc.Upa.PersistenceUnitPart>(parts, part, index, this, this, new Net.TheVpc.Upa.Impl.DefaultPackagePrivateAddPartInterceptor(this));
        }

        public virtual void RemovePartAt(int index) {
            Net.TheVpc.Upa.Impl.Util.ListUtils.Remove<Net.TheVpc.Upa.PersistenceUnitPart>(parts, index, this, new Net.TheVpc.Upa.Impl.DefaultPackagePrivateRemovePartInterceptor());
        }

        public virtual void MovePart(string itemName, int newIndex) {
            MovePart(IndexOfPart(itemName), newIndex);
        }

        public virtual void MovePart(int index, int newIndex) {
            Net.TheVpc.Upa.Impl.Util.ListUtils.MoveTo<T>(parts, index, newIndex, this, null);
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.PersistenceUnitPart> GetParts() {
            return new System.Collections.Generic.List<Net.TheVpc.Upa.PersistenceUnitPart>(parts);
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Entity> GetEntities() {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Entity> all = new System.Collections.Generic.List<Net.TheVpc.Upa.Entity>();
            foreach (Net.TheVpc.Upa.PersistenceUnitPart item in parts) {
                if (item is Net.TheVpc.Upa.Entity) {
                    all.Add((Net.TheVpc.Upa.Entity) item);
                }
            }
            return all;
        }


        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Entity> GetEntities(bool includeSubPackages) {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Entity> all = new System.Collections.Generic.List<Net.TheVpc.Upa.Entity>();
            foreach (Net.TheVpc.Upa.PersistenceUnitPart item in parts) {
                if (item is Net.TheVpc.Upa.Entity) {
                    all.Add((Net.TheVpc.Upa.Entity) item);
                } else if (includeSubPackages) {
                    if (item is Net.TheVpc.Upa.Package) {
                        Net.TheVpc.Upa.Impl.FwkConvertUtils.ListAddRange(all, ((Net.TheVpc.Upa.Package) item).GetEntities(includeSubPackages));
                    }
                }
            }
            return all;
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Package> GetPackages() {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Package> all = new System.Collections.Generic.List<Net.TheVpc.Upa.Package>();
            foreach (Net.TheVpc.Upa.PersistenceUnitPart item in parts) {
                if (item is Net.TheVpc.Upa.Package) {
                    all.Add((Net.TheVpc.Upa.Package) item);
                }
            }
            return all;
        }

        public virtual int IndexOfPart(Net.TheVpc.Upa.PersistenceUnitPart child) {
            return parts.IndexOf(child);
        }

        public virtual int IndexOfPart(string childName) {
            int index = 0;
            foreach (Net.TheVpc.Upa.PersistenceUnitPart child in parts) {
                if (childName.Equals(child.GetName())) {
                    return index;
                }
                index++;
            }
            return -1;
        }

        public virtual Net.TheVpc.Upa.Package GetParent() {
            return parent;
        }

        public virtual void SetParent(Net.TheVpc.Upa.Package parent) {
            this.parent = parent;
        }

        public virtual string GetPath() {
            string p = parent == null ? "/" : parent.GetPath();
            if (!p.EndsWith("/")) {
                p = p + "/";
            }
            return p + GetName();
        }

        public virtual Net.TheVpc.Upa.Package GetPart(string name) {
            foreach (Net.TheVpc.Upa.PersistenceUnitPart persistenceUnitItem in parts) {
                if (persistenceUnitItem is Net.TheVpc.Upa.Package) {
                    Net.TheVpc.Upa.Package m = (Net.TheVpc.Upa.Package) persistenceUnitItem;
                    if (m.GetName().Equals(name)) {
                        return m;
                    }
                }
            }
            throw new Net.TheVpc.Upa.Exceptions.NoSuchPackageException(name, null);
        }


        public virtual int GetPartsCount() {
            return (parts).Count;
        }


        public override void Close() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            foreach (Net.TheVpc.Upa.PersistenceUnitPart child in parts) {
                child.Close();
            }
            this.closed = true;
        }

        public virtual bool IsClosed() {
            return closed;
        }


        public override string ToString() {
            return GetPath();
        }


        public override void CheckValidIdentifier(string s) {
            // an empty or null string cannot be a valid identifier
            if (s == null) {
                throw new System.ArgumentException ("Empty name");
            }
            //s=="" is accepted for default package
            if (!s.Trim().Equals(s)) {
                throw new System.ArgumentException (s);
            }
            // Select lf from LigneFacture lf where lf.facture.date=:dte
            char[] c = s.ToCharArray();
            for (int i = 1; i < c.Length; i++) {
                if (c[i] == '/') {
                    throw new System.ArgumentException ("Invalid name char '" + c[i] + "' in name " + s);
                }
            }
        }
    }
}
