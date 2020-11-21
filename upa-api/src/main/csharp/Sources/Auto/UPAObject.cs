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



namespace Net.TheVpc.Upa
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public interface UPAObject {

         string GetName();

         void SetName(string name);

         string GetAbsoluteName();

         string GetPersistenceName();

         void SetPersistenceName(string persistenceNameFormat);

         Net.TheVpc.Upa.PersistenceUnit GetPersistenceUnit();

         Net.TheVpc.Upa.PersistenceGroup GetPersistenceGroup();

        /**
             * localized title
             * @return localized title
             * @see #getI18NTitle()
             * @see Net.TheVpc.Upa.UPAI18n
             */
         string GetTitle();

        /**
             * localized description
             * @return localized description
             * @see #getI18NTitle()
             * @see Net.TheVpc.Upa.UPAI18n
             */
         string GetDescription();

         Net.TheVpc.Upa.Types.I18NString GetI18NTitle();

         void SetI18NTitle(Net.TheVpc.Upa.Types.I18NString title);

         Net.TheVpc.Upa.Types.I18NString GetI18NDescription();

         void SetI18NDescription(Net.TheVpc.Upa.Types.I18NString description);

         Net.TheVpc.Upa.Properties GetProperties();

         Net.TheVpc.Upa.PersistenceState GetPersistenceState();

         void AddObjectListener(Net.TheVpc.Upa.UPAObjectListener listener);

         void RemoveObjectListener(Net.TheVpc.Upa.UPAObjectListener listener);

         Net.TheVpc.Upa.UPAObjectListener[] GetObjectListeners();

         void AddPropertyChangeListener(string property, Net.TheVpc.Upa.EventPhase phase, Net.TheVpc.Upa.PropertyChangeListener listener);

         void RemovePropertyChangeListener(string property, Net.TheVpc.Upa.EventPhase phase, Net.TheVpc.Upa.PropertyChangeListener listener);

         void AddPropertyChangeListener(Net.TheVpc.Upa.EventPhase phase, Net.TheVpc.Upa.PropertyChangeListener listener);

         void RemovePropertyChangeListener(Net.TheVpc.Upa.EventPhase phase, Net.TheVpc.Upa.PropertyChangeListener listener);


        override bool Equals(object other);


        override int GetHashCode();

         void Close() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;
    }
}
