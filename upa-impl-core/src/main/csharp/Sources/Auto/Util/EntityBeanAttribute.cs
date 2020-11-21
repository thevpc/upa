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



namespace Net.TheVpc.Upa.Impl.Util
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 1/5/13 11:23 PM
     */
    public interface EntityBeanAttribute {

         string GetName();

         object GetValue(object o);

         void SetValue(object o, object @value);

         object GetDefaultValue() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsDefaultValue(object o) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;
    }
}
