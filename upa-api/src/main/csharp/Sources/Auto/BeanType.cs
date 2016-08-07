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
    public interface BeanType {

         System.Type GetPlatformType();

         System.Collections.Generic.ISet<string> GetPropertyNames();

         System.Collections.Generic.ISet<string> GetPropertyNames(object o, bool? includeDefaults);

         object NewInstance();

         bool ContainsProperty(string property);

         object GetProperty(object instance, string field);

         bool SetProperty(object instance, string property, object @value);

        /**
             * sets value for the property, if the property exists
             * @param instance instance to inject into
             * @param property property to inject into
             * @param value new value
             */
         void Inject(object instance, string property, object @value);

         System.Reflection.MethodInfo GetMethod(System.Type type, string name, System.Type ret, params System.Type [] args);

         System.Reflection.FieldInfo FindField(string name, Net.Vpc.Upa.Filters.ObjectFilter<System.Reflection.FieldInfo> filter);

         bool ResetToDefaultValue(object instance, string field);

         bool IsDefaultValue(object instance, string field);

         System.Collections.Generic.IDictionary<string , object> ToMap(object o, bool? includeDefaults);
    }
}
