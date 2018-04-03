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
     * @creationdate 9/11/12 9:19 PM
     */
    public interface ObjectFactory {

         int GetContextSupportLevel();

         void SetParentFactory(Net.Vpc.Upa.ObjectFactory factory);

          T CreateObject<T>(System.Type type, string name);

          T CreateObject<T>(string typeName, string name);

          T CreateObject<T>(System.Type type);

          T CreateObject<T>(string typeName);

          T GetSingleton<T>(System.Type type);

          T GetSingleton<T>(string typeName);

          System.Type[] GetAlternatives<T>(System.Type type);

          void AddAlternative<T>(System.Type type, System.Type impl);

         void Register(System.Type contract, System.Type impl);
    }
}
