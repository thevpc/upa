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
namespace Net.Vpc.Upa.Impl
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/25/12 12:01 AM
     */
    public abstract class AbstractUPAObject : Net.Vpc.Upa.UPAObject {

        private string name;

        private string persistenceNameFormat;

        private Net.Vpc.Upa.Types.I18NString title;

        private Net.Vpc.Upa.Types.I18NString description;

        private Net.Vpc.Upa.Types.I18NString i18NString;

        private Net.Vpc.Upa.PersistenceUnit persistenceUnit;

        private readonly Net.Vpc.Upa.Properties parameters = new Net.Vpc.Upa.Impl.DefaultProperties();

        private Net.Vpc.Upa.PersistenceState persistenceState = Net.Vpc.Upa.PersistenceState.UNKNOWN;

        protected internal Net.Vpc.Upa.PropertyChangeSupport propertyChangeSupport;

        protected internal System.Collections.Generic.IList<Net.Vpc.Upa.UPAObjectListener> objectListeners;

        protected internal AbstractUPAObject() {
            propertyChangeSupport = new Net.Vpc.Upa.PropertyChangeSupport(this);
        }

        public virtual string GetName() {
            return name;
        }

        public virtual void SetName(string name) {
            CheckValidIdentifier(name);
            string old = this.name;
            this.name = name;
            propertyChangeSupport.FirePropertyChange("name", old, name);
        }

        public virtual string GetPersistenceName() {
            return persistenceNameFormat;
        }

        public virtual void SetPersistenceName(string persistenceNameFormat) {
            string old = this.persistenceNameFormat;
            this.persistenceNameFormat = persistenceNameFormat;
            propertyChangeSupport.FirePropertyChange("persistenceNameFormat", old, persistenceNameFormat);
        }

        public virtual Net.Vpc.Upa.Types.I18NString GetTitle() {
            return title;
        }

        public virtual void SetTitle(Net.Vpc.Upa.Types.I18NString title) {
            Net.Vpc.Upa.Types.I18NString old = this.title;
            this.title = title;
            propertyChangeSupport.FirePropertyChange("title", old, title);
        }

        public virtual Net.Vpc.Upa.Types.I18NString GetDescription() {
            return description;
        }

        public virtual void SetDescription(Net.Vpc.Upa.Types.I18NString description) {
            Net.Vpc.Upa.Types.I18NString old = this.description;
            this.description = description;
            propertyChangeSupport.FirePropertyChange("description", old, description);
        }

        public virtual Net.Vpc.Upa.Types.I18NString GetI18NString() {
            return i18NString;
        }

        public virtual void SetI18NString(Net.Vpc.Upa.Types.I18NString i18NString) {
            Net.Vpc.Upa.Types.I18NString old = this.i18NString;
            this.i18NString = i18NString;
            propertyChangeSupport.FirePropertyChange("i18NString", old, i18NString);
        }

        public virtual Net.Vpc.Upa.PersistenceUnit GetPersistenceUnit() {
            return persistenceUnit;
        }

        public virtual void SetPersistenceUnit(Net.Vpc.Upa.PersistenceUnit persistenceUnit) {
            Net.Vpc.Upa.PersistenceUnit old = this.persistenceUnit;
            this.persistenceUnit = persistenceUnit;
            propertyChangeSupport.FirePropertyChange("persistenceUnit", old, persistenceUnit);
        }

        public virtual Net.Vpc.Upa.Properties GetProperties() {
            return parameters;
        }

        public virtual void SetPersistenceState(Net.Vpc.Upa.PersistenceState persistenceState) {
            Net.Vpc.Upa.PersistenceState old = this.persistenceState;
            this.persistenceState = Net.Vpc.Upa.Impl.Util.PlatformUtils.IsUndefinedValue<Net.Vpc.Upa.PersistenceState>(typeof(Net.Vpc.Upa.PersistenceState), persistenceState) ? Net.Vpc.Upa.PersistenceState.UNKNOWN : persistenceState;
            propertyChangeSupport.FirePropertyChange("persistenceState", old, this.persistenceState);
        }


        public virtual Net.Vpc.Upa.PersistenceState GetPersistenceState() {
            return persistenceState;
        }


        public override int GetHashCode() {
            string n = GetAbsoluteName();
            int result = n != null ? n.GetHashCode() : 0;
            result = 31 * result + GetType().GetHashCode();
            return result;
        }


        public override bool Equals(object o) {
            if (this == o) {
                return true;
            }
            if (o == null || GetType() != o.GetType()) {
                return false;
            }
            Net.Vpc.Upa.Impl.AbstractUPAObject that = (Net.Vpc.Upa.Impl.AbstractUPAObject) o;
            string thatAbsoluteName = that.GetAbsoluteName();
            string absoluteName = GetAbsoluteName();
            if (absoluteName != null ? !absoluteName.Equals(thatAbsoluteName) : thatAbsoluteName != null) {
                return false;
            }
            return true;
        }


        public override string ToString() {
            return (GetType()).Name + " " + GetAbsoluteName();
        }

        public virtual void AddObjectListener(Net.Vpc.Upa.UPAObjectListener listener) {
            if (listener != null) {
                if (objectListeners == null) {
                    objectListeners = new System.Collections.Generic.List<Net.Vpc.Upa.UPAObjectListener>();
                }
                objectListeners.Add(listener);
            }
        }

        public virtual void RemoveObjectListener(Net.Vpc.Upa.UPAObjectListener listener) {
            if (listener != null) {
                if (objectListeners != null) {
                    objectListeners.Remove(listener);
                }
            }
        }

        public virtual Net.Vpc.Upa.UPAObjectListener[] GetObjectListeners() {
            return objectListeners == null ? ((Net.Vpc.Upa.UPAObjectListener[])(new Net.Vpc.Upa.UPAObjectListener[0])) : objectListeners.ToArray();
        }

        public virtual void AddPropertyChangeListener(string property, Net.Vpc.Upa.PropertyChangeListener listener) {
            propertyChangeSupport.AddPropertyChangeListener(property, listener);
        }

        public virtual void RemovePropertyChangeListener(string property, Net.Vpc.Upa.PropertyChangeListener listener) {
            propertyChangeSupport.RemovePropertyChangeListener(property, listener);
        }

        public virtual void AddPropertyChangeListener(Net.Vpc.Upa.PropertyChangeListener listener) {
            propertyChangeSupport.AddPropertyChangeListener(listener);
        }

        public virtual void RemovePropertyChangeListener(Net.Vpc.Upa.PropertyChangeListener listener) {
            propertyChangeSupport.RemovePropertyChangeListener(listener);
        }


        public virtual void Close() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
        }

        public virtual void CheckValidIdentifier(string s) {
            // an empty or null string cannot be a valid identifier
            if (s == null || (s).Length == 0) {
                throw new System.ArgumentException ("Empty name");
            }
            if (!s.Trim().Equals(s)) {
                throw new System.ArgumentException (s);
            }
            char[] c = s.ToCharArray();
            if (!Net.Vpc.Upa.Expressions.ExpressionHelper.IsIdentifierStart(c[0])) {
                throw new System.ArgumentException ("Invalid name start " + s);
            }
            for (int i = 1; i < c.Length; i++) {
                if (!Net.Vpc.Upa.Expressions.ExpressionHelper.IsIdentifierPart(c[i])) {
                    throw new System.ArgumentException ("Invalid name char '" + c[i] + "' in name " + s);
                }
            }
        }
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract string GetAbsoluteName();
    }
}
