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
     * @author taha.bensalah@gmail.com
     */
    public interface PlatformBeanType {

         System.Type GetPlatformType();

         System.Collections.Generic.ISet<string> GetPropertyNames();

         System.Collections.Generic.ISet<string> GetPropertyNames(object o, bool? includeDefaults);

         object NewInstance();

         System.Type GetPropertyType(string property);

         bool ContainsProperty(string property);

         object GetPropertyValue(object instance, string field);

         bool SetPropertyValue(object instance, string property, object @value);

        /**
             * sets value for the property, if the property exists
             *
             * @param instance instance to inject into
             * @param property property to inject into
             * @param value    new value
             */
         void Inject(object instance, string property, object @value);

         System.Reflection.MethodInfo GetMethod(System.Type type, string name, System.Type ret, params System.Type [] args);

         bool ResetToDefaultValue(object instance, string field);

         bool IsDefaultValue(object instance, string field);
    }
}
