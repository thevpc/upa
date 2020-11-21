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
     * @creationdate 1/5/13 11:18 PM
     */
    public interface PlatformBeanProperty {

         string GetName();

         System.Type GetPlatformType();

         object GetValue(object o);

         object GetDefaultValue();

         void SetValue(object o, object @value);

         bool IsDefaultValue(object o);

         bool IsWriteSupported();

         bool IsReadSupported();
    }
}
