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



namespace Net.Vpc.Upa.Impl.Util
{


    /**
     * Created by vpc on 8/6/15.
     */
    public interface PlatformMethodProxyEvent<T> {

         T GetObject();

         object[] GetArguments();

         System.Reflection.MethodInfo GetMethod();

         string GetMethodName();

         object InvokeBase(T obj, object[] args) /* throws System.Exception */ ;
    }
}
