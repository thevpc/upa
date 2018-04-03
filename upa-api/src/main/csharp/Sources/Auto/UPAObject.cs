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



namespace Net.Vpc.Upa
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public interface UPAObject {

         string GetName();

         void SetName(string name);

         string GetAbsoluteName();

         string GetPersistenceName();

         void SetPersistenceName(string persistenceName);

         Net.Vpc.Upa.PersistenceUnit GetPersistenceUnit();

         Net.Vpc.Upa.PersistenceGroup GetPersistenceGroup();

        /**
             * localized title
             * @return localized title
             * @see #getI18NTitle()
             * @see net.vpc.upa.UPAI18n
             */
         string GetTitle();

        /**
             * localized description
             * @return localized description
             * @see #getI18NTitle()
             * @see net.vpc.upa.UPAI18n
             */
         string GetDescription();

         Net.Vpc.Upa.Types.I18NString GetI18NTitle();

         void SetI18NTitle(Net.Vpc.Upa.Types.I18NString title);

         Net.Vpc.Upa.Types.I18NString GetI18NDescription();

         void SetI18NDescription(Net.Vpc.Upa.Types.I18NString description);

         Net.Vpc.Upa.Properties GetProperties();

         Net.Vpc.Upa.PersistenceState GetPersistenceState();

         void AddObjectListener(Net.Vpc.Upa.UPAObjectListener listener);

         void RemoveObjectListener(Net.Vpc.Upa.UPAObjectListener listener);

         Net.Vpc.Upa.UPAObjectListener[] GetObjectListeners();

         void AddPropertyChangeListener(string property, Net.Vpc.Upa.EventPhase phase, Net.Vpc.Upa.PropertyChangeListener listener);

         void RemovePropertyChangeListener(string property, Net.Vpc.Upa.EventPhase phase, Net.Vpc.Upa.PropertyChangeListener listener);

         void AddPropertyChangeListener(Net.Vpc.Upa.EventPhase phase, Net.Vpc.Upa.PropertyChangeListener listener);

         void RemovePropertyChangeListener(Net.Vpc.Upa.EventPhase phase, Net.Vpc.Upa.PropertyChangeListener listener);


        override bool Equals(object other);


        override int GetHashCode();

         void Close() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;
    }
}
