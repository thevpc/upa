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



namespace Net.Vpc.Upa
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public interface UPAObject {

         string GetName();

         string GetAbsoluteName();

         void SetName(string name);

         string GetPersistenceName();

         void SetPersistenceName(string persistenceName);

         Net.Vpc.Upa.PersistenceUnit GetPersistenceUnit();

         Net.Vpc.Upa.Types.I18NString GetTitle();

         void SetTitle(Net.Vpc.Upa.Types.I18NString title);

         Net.Vpc.Upa.Types.I18NString GetDescription();

         void SetDescription(Net.Vpc.Upa.Types.I18NString description);

         Net.Vpc.Upa.Types.I18NString GetI18NString();

         void SetI18NString(Net.Vpc.Upa.Types.I18NString i18NString);

         Net.Vpc.Upa.Properties GetProperties();

         Net.Vpc.Upa.PersistenceState GetPersistenceState();

         void AddObjectListener(Net.Vpc.Upa.UPAObjectListener listener);

         void RemoveObjectListener(Net.Vpc.Upa.UPAObjectListener listener);

         Net.Vpc.Upa.UPAObjectListener[] GetObjectListeners();

         void AddPropertyChangeListener(string property, Net.Vpc.Upa.PropertyChangeListener listener);

         void RemovePropertyChangeListener(string property, Net.Vpc.Upa.PropertyChangeListener listener);

         void AddPropertyChangeListener(Net.Vpc.Upa.PropertyChangeListener listener);

         void RemovePropertyChangeListener(Net.Vpc.Upa.PropertyChangeListener listener);


         bool Equals(object other);


         int GetHashCode();

         void Close() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;
    }
}
