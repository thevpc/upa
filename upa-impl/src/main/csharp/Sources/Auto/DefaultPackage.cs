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


    public class DefaultPackage : Net.Vpc.Upa.Impl.AbstractUPAObject, Net.Vpc.Upa.Package {

        private Net.Vpc.Upa.Package parent;

        private System.Collections.Generic.IList<Net.Vpc.Upa.PersistenceUnitPart> parts;

        private bool closed;

        public DefaultPackage() {
            this.parent = null;
            this.parts = new System.Collections.Generic.List<Net.Vpc.Upa.PersistenceUnitPart>(3);
        }


        public override string GetAbsoluteName() {
            Net.Vpc.Upa.PersistenceUnitPart parentPersistenceUnitItem = GetParent();
            if (parentPersistenceUnitItem == null) {
                return GetName();
            }
            return parentPersistenceUnitItem.GetAbsoluteName() + "/" + GetName();
        }

        public virtual void AddPart(Net.Vpc.Upa.PersistenceUnitPart child) {
            AddPart(child, GetPartsCount());
        }

        public virtual void AddPart(Net.Vpc.Upa.PersistenceUnitPart part, int index) {
            if (index < 0) {
                index = GetPartsCount() + index + 1;
            }
            if (index < 0) {
                throw new System.IndexOutOfRangeException("Invalid Index "+(index));
            }
            if (index > (parts).Count) {
                throw new System.IndexOutOfRangeException("Invalid Index "+(index));
            }
            Net.Vpc.Upa.Impl.Util.ListUtils.Add<Net.Vpc.Upa.PersistenceUnitPart>(parts, part, index, this, this, new Net.Vpc.Upa.Impl.DefaultPackagePrivateAddPartInterceptor(this));
        }

        public virtual void RemovePartAt(int index) {
            Net.Vpc.Upa.Impl.Util.ListUtils.Remove<Net.Vpc.Upa.PersistenceUnitPart>(parts, index, this, new Net.Vpc.Upa.Impl.DefaultPackagePrivateRemovePartInterceptor());
        }

        public virtual void MovePart(string itemName, int newIndex) {
            MovePart(IndexOfPart(itemName), newIndex);
        }

        public virtual void MovePart(int index, int newIndex) {
            Net.Vpc.Upa.Impl.Util.ListUtils.MoveTo<Net.Vpc.Upa.PersistenceUnitPart>(parts, index, newIndex, this, null);
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.PersistenceUnitPart> GetParts() {
            return new System.Collections.Generic.List<Net.Vpc.Upa.PersistenceUnitPart>(parts);
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Entity> GetEntities() {
            System.Collections.Generic.IList<Net.Vpc.Upa.Entity> all = new System.Collections.Generic.List<Net.Vpc.Upa.Entity>();
            foreach (Net.Vpc.Upa.PersistenceUnitPart item in parts) {
                if (item is Net.Vpc.Upa.Entity) {
                    all.Add((Net.Vpc.Upa.Entity) item);
                }
            }
            return all;
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Package> GetPackages() {
            System.Collections.Generic.IList<Net.Vpc.Upa.Package> all = new System.Collections.Generic.List<Net.Vpc.Upa.Package>();
            foreach (Net.Vpc.Upa.PersistenceUnitPart item in parts) {
                if (item is Net.Vpc.Upa.Package) {
                    all.Add((Net.Vpc.Upa.Package) item);
                }
            }
            return all;
        }

        public virtual int IndexOfPart(Net.Vpc.Upa.PersistenceUnitPart child) {
            return parts.IndexOf(child);
        }

        public virtual int IndexOfPart(string childName) {
            int index = 0;
            foreach (Net.Vpc.Upa.PersistenceUnitPart child in parts) {
                if (childName.Equals(child.GetName())) {
                    return index;
                }
                index++;
            }
            return -1;
        }

        public virtual Net.Vpc.Upa.Package GetParent() {
            return parent;
        }

        public virtual void SetParent(Net.Vpc.Upa.Package parent) {
            this.parent = parent;
        }

        public virtual string GetPath() {
            string p = parent == null ? "/" : parent.GetPath();
            if (!p.EndsWith("/")) {
                p = p + "/";
            }
            return p + GetName();
        }

        public virtual Net.Vpc.Upa.Package GetPart(string name) {
            foreach (Net.Vpc.Upa.PersistenceUnitPart persistenceUnitItem in parts) {
                if (persistenceUnitItem is Net.Vpc.Upa.Package) {
                    Net.Vpc.Upa.Package m = (Net.Vpc.Upa.Package) persistenceUnitItem;
                    if (m.GetName().Equals(name)) {
                        return m;
                    }
                }
            }
            throw new Net.Vpc.Upa.Exceptions.NoSuchPackageException(name, null);
        }


        public virtual int GetPartsCount() {
            return (parts).Count;
        }


        public override void Close() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            foreach (Net.Vpc.Upa.PersistenceUnitPart child in parts) {
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
