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



namespace Net.TheVpc.Upa.Config
{


    /**
     * @author taha.bensalah@gmail.com
     */
    public interface Decoration : Net.TheVpc.Upa.Config.DecorationValue {

         string GetLocation();

         Net.TheVpc.Upa.Config.DecorationSourceType GetDecorationSourceType();

         Net.TheVpc.Upa.Config.DecorationTarget GetTarget();

         string GetLocationType();

         string GetName();

         bool IsName(string name);

         bool IsName(System.Type type);

         int GetPosition();

         string GetString(string name);

         bool GetBoolean(string name);

         int GetInt(string name);

          T GetEnum<T>(string name, System.Type type);

         Net.TheVpc.Upa.Config.DecorationValue Get(string name);

         System.Type GetType(string name);

         Net.TheVpc.Upa.Config.Decoration GetDecoration(string name);

          T[] GetPrimitiveArray<T>(string name, System.Type type);

         Net.TheVpc.Upa.Config.DecorationValue[] GetArray(string name);

         System.Collections.Generic.IDictionary<string , Net.TheVpc.Upa.Config.DecorationValue> GetAttributes();

         Net.TheVpc.Upa.Config.Decoration CastName(string type);

         Net.TheVpc.Upa.Config.Decoration CastName(System.Type type);
    }
}
