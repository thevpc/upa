/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE HAS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.Vpc.Upa.Filters
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class DefaultEntityFilter : Net.Vpc.Upa.Filters.AbstractRichEntityFilter {

        private int acceptCloneable = 0;

        private int acceptValidatable = 0;

        private int acceptUpdatable = 0;

        private int acceptTransient = 0;

        private int acceptSystem = 0;

        private int acceptPrivate = 0;

        private int acceptDeletable = 0;

        private int acceptEmpty = 0;

        private int acceptPersistable = 0;

        private int acceptNavigatable = 0;

        private int acceptKeyGeneratable = 0;

        private int acceptKeyEditable = 0;

        private int acceptRenamable = 0;

        private int acceptClear = 0;

        private System.Type rootClass;

        private System.Collections.Generic.ISet<string> acceptedNames;

        private System.Collections.Generic.ISet<string> rejectedNames;

        public DefaultEntityFilter() {
        }

        public virtual Net.Vpc.Upa.Filters.DefaultEntityFilter SetAcceptName(string name) {
            if (acceptedNames == null) {
                acceptedNames = new System.Collections.Generic.HashSet<string>();
            }
            acceptedNames.Add(name);
            return this;
        }

        public virtual Net.Vpc.Upa.Filters.DefaultEntityFilter UnsetAcceptName(string name) {
            if (acceptedNames != null) {
                acceptedNames.Remove(name);
            }
            return this;
        }

        public virtual Net.Vpc.Upa.Filters.DefaultEntityFilter SetRejectName(string name) {
            if (rejectedNames == null) {
                rejectedNames = new System.Collections.Generic.HashSet<string>();
            }
            rejectedNames.Add(name);
            return this;
        }

        public virtual Net.Vpc.Upa.Filters.DefaultEntityFilter UnsetRejectName(string name) {
            if (rejectedNames != null) {
                rejectedNames.Remove(name);
            }
            return this;
        }

        public virtual System.Type GetRootTableClass() {
            return rootClass;
        }

        public virtual Net.Vpc.Upa.Filters.DefaultEntityFilter SetAcceptRootEntityClass(System.Type entity) {
            rootClass = entity;
            return this;
        }

        public virtual bool IsAcceptCloneable() {
            return acceptCloneable == 1;
        }

        public virtual Net.Vpc.Upa.Filters.DefaultEntityFilter SetAcceptCloneable(bool acceptCloneable) {
            this.acceptCloneable = acceptCloneable ? 1 : -1;
            return this;
        }

        public virtual bool IsRejectCloneable() {
            return acceptCloneable == -1;
        }

        public virtual bool IsAcceptValidatable() {
            return acceptValidatable == 1;
        }

        public virtual Net.Vpc.Upa.Filters.DefaultEntityFilter SetAcceptValidatable(bool acceptValidatable) {
            this.acceptValidatable = acceptValidatable ? 1 : -1;
            return this;
        }

        public virtual bool IsRejectValidatable() {
            return acceptValidatable == -1;
        }

        public virtual bool IsAcceptUpdatable() {
            return acceptUpdatable == 1;
        }

        public virtual Net.Vpc.Upa.Filters.DefaultEntityFilter SetAcceptUpdatable(bool acceptUpdatable) {
            this.acceptUpdatable = acceptUpdatable ? 1 : -1;
            return this;
        }

        public virtual bool IsRejectUpdatable() {
            return acceptUpdatable == -1;
        }

        public virtual bool IsAcceptTransient() {
            return acceptTransient == 1;
        }

        public virtual Net.Vpc.Upa.Filters.DefaultEntityFilter SetAcceptTransient(bool acceptTransient) {
            this.acceptTransient = acceptTransient ? 1 : -1;
            return this;
        }

        public virtual bool IsRejectTransient() {
            return acceptTransient == -1;
        }

        public virtual bool IsAcceptSystem() {
            return acceptSystem == 1;
        }

        public virtual Net.Vpc.Upa.Filters.DefaultEntityFilter SetAcceptSystem(bool acceptSystem) {
            this.acceptSystem = acceptSystem ? 1 : -1;
            return this;
        }

        public virtual bool IsRejectSystem() {
            return acceptSystem == -1;
        }

        public virtual bool IsAcceptPrivate() {
            return acceptPrivate == 1;
        }

        public virtual Net.Vpc.Upa.Filters.DefaultEntityFilter SetAcceptPrivate(bool acceptPrivate) {
            this.acceptPrivate = acceptPrivate ? 1 : -1;
            return this;
        }

        public virtual bool IsRejectPrivate() {
            return acceptPrivate == -1;
        }

        public virtual bool IsAcceptDeletable() {
            return acceptDeletable == 1;
        }

        public virtual Net.Vpc.Upa.Filters.DefaultEntityFilter SetAcceptDeletable(bool acceptDeletable) {
            this.acceptDeletable = acceptDeletable ? 1 : -1;
            return this;
        }

        public virtual bool IsRejectDeletable() {
            return acceptDeletable == -1;
        }

        public virtual bool IsAcceptEmpty() {
            return acceptEmpty == 1;
        }

        public virtual Net.Vpc.Upa.Filters.DefaultEntityFilter SetAcceptEmpty(bool acceptEmpty) {
            this.acceptEmpty = acceptEmpty ? 1 : -1;
            return this;
        }

        public virtual bool IsRejectEmpty() {
            return acceptEmpty == -1;
        }

        public virtual bool IsAcceptPersistable() {
            return acceptPersistable == 1;
        }

        public virtual Net.Vpc.Upa.Filters.DefaultEntityFilter SetAcceptPersistable(bool acceptPersistable) {
            this.acceptPersistable = acceptPersistable ? 1 : -1;
            return this;
        }

        public virtual bool IsRejectPersistable() {
            return acceptPersistable == -1;
        }

        public virtual bool IsAcceptNavigatable() {
            return acceptNavigatable == 1;
        }

        public virtual Net.Vpc.Upa.Filters.DefaultEntityFilter SetAcceptNavigatable(bool acceptNavigatable) {
            this.acceptNavigatable = acceptNavigatable ? 1 : -1;
            return this;
        }

        public virtual bool IsRejectNavigatable() {
            return acceptNavigatable == -1;
        }

        public virtual bool IsAcceptKeyGeneratable() {
            return acceptKeyGeneratable == 1;
        }

        public virtual Net.Vpc.Upa.Filters.DefaultEntityFilter SetAcceptKeyGeneratable(bool acceptKeyGeneratable) {
            this.acceptKeyGeneratable = acceptKeyGeneratable ? 1 : -1;
            return this;
        }

        public virtual bool IsRejectKeyGeneratable() {
            return acceptKeyGeneratable == -1;
        }

        public virtual bool IsAcceptKeyEditable() {
            return acceptKeyEditable == 1;
        }

        public virtual Net.Vpc.Upa.Filters.DefaultEntityFilter SetAcceptKeyEditable(bool acceptKeyEditable) {
            this.acceptKeyEditable = acceptKeyEditable ? 1 : -1;
            return this;
        }

        public virtual bool IsRejectKeyEditable() {
            return acceptKeyEditable == -1;
        }

        public virtual bool IsAcceptRenamable() {
            return acceptRenamable == 1;
        }

        public virtual Net.Vpc.Upa.Filters.DefaultEntityFilter SetAcceptRenamable(bool acceptRenamable) {
            this.acceptRenamable = acceptRenamable ? 1 : -1;
            return this;
        }

        public virtual bool IsRejectRenamable() {
            return acceptRenamable == -1;
        }

        public virtual bool IsAcceptClear() {
            return acceptClear == 1;
        }

        public virtual Net.Vpc.Upa.Filters.DefaultEntityFilter SetAcceptClear(bool acceptClear) {
            this.acceptClear = acceptClear ? 1 : -1;
            return this;
        }

        public virtual bool IsRejectClear() {
            return acceptClear == -1;
        }

        public override bool Accept(Net.Vpc.Upa.Entity entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            object source = entity.GetEntityDescriptor().GetSource();
            if (rootClass != null && (source == null || !rootClass.IsAssignableFrom(source.GetType()))) {
                return false;
            }
            if (acceptedNames != null && (acceptedNames).Count > 0 && !acceptedNames.Contains(entity.GetName())) {
                return false;
            }
            if (rejectedNames != null && (rejectedNames).Count > 0 && rejectedNames.Contains(entity.GetName())) {
                return false;
            }
            Net.Vpc.Upa.EntityShield v = entity.GetShield();
            if (IsAcceptCloneable() && !v.IsCloneSupported()) {
                return false;
            }
            if (IsRejectCloneable() && v.IsCloneSupported()) {
                return false;
            }
            if (IsAcceptKeyEditable() && !v.IsKeyEditionSupported()) {
                return false;
            }
            if (IsRejectKeyEditable() && v.IsKeyEditionSupported()) {
                return false;
            }
            if (IsAcceptRenamable() && !v.IsRenameSupported()) {
                return false;
            }
            if (IsRejectRenamable() && v.IsRenameSupported()) {
                return false;
            }
            if (IsAcceptClear() && !v.IsClearSupported()) {
                return false;
            }
            if (IsRejectClear() && v.IsClearSupported()) {
                return false;
            }
            if (IsAcceptDeletable() && !v.IsDeleteSupported()) {
                return false;
            }
            if (IsRejectDeletable() && v.IsDeleteSupported()) {
                return false;
            }
            try {
                if (IsAcceptEmpty() && !entity.IsEmpty()) {
                    return false;
                }
            } catch (Net.Vpc.Upa.Exceptions.UPAException e) {
                return false;
            }
            try {
                if (IsRejectEmpty() && entity.IsEmpty()) {
                    return false;
                }
            } catch (Net.Vpc.Upa.Exceptions.UPAException e) {
                return false;
            }
            if (IsAcceptPersistable() && !v.IsPersistSupported()) {
                return false;
            }
            if (IsRejectPersistable() && v.IsPersistSupported()) {
                return false;
            }
            if (IsAcceptNavigatable() && !v.IsNavigateSupported()) {
                return false;
            }
            if (IsRejectNavigatable() && v.IsNavigateSupported()) {
                return false;
            }
            //        if(isAcceptPrintable() && !v.isPrintSupported()){
            //            return false;
            //        }
            //        if(isRejectPrintable() && v.isPrintSupported()){
            //            return false;
            //        }
            if (IsAcceptKeyGeneratable() && !v.IsGeneratedId()) {
                return false;
            }
            if (IsRejectKeyGeneratable() && v.IsGeneratedId()) {
                return false;
            }
            if (IsAcceptSystem() && !v.IsSystem()) {
                return false;
            }
            if (IsRejectSystem() && v.IsSystem()) {
                return false;
            }
            if (IsAcceptPrivate() && !v.IsPrivate()) {
                return false;
            }
            if (IsRejectPrivate() && v.IsPrivate()) {
                return false;
            }
            if (IsAcceptTransient() && !v.IsTransient()) {
                return false;
            }
            if (IsRejectTransient() && v.IsTransient()) {
                return false;
            }
            if (IsAcceptUpdatable() && !v.IsUpdateSupported()) {
                return false;
            }
            if (IsRejectUpdatable() && v.IsUpdateSupported()) {
                return false;
            }
            if (IsAcceptValidatable() && !v.IsUpdateFormulaSupported()) {
                return false;
            }
            if (IsRejectValidatable() && v.IsUpdateFormulaSupported()) {
                return false;
            }
            return true;
        }
    }
}
