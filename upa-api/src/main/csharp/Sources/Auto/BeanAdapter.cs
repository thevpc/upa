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
     *
     * @author taha.bensalah@gmail.com
     */
    public interface BeanAdapter {

         Net.Vpc.Upa.BeanType GetBeanType();

         object GetProperty(string field);

         void SetProperty(string property, object @value);

         void Inject(string property, object @value);
    }
}
