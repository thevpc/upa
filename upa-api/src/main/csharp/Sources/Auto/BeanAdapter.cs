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
     *
     * @author taha.bensalah@gmail.com
     */
    public interface BeanAdapter {

         Net.TheVpc.Upa.PlatformBeanType GetPlatformBeanType();

         object GetProperty(string field);

         void SetProperty(string property, object @value);

         void Inject(string property, object @value);
    }
}
