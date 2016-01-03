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



namespace Net.Vpc.Upa.Config
{


    /**
     *
     * @author vpc
     */
    public interface Decoration : Net.Vpc.Upa.Config.DecorationValue {

         string GetLocation();

         Net.Vpc.Upa.Config.DecorationSourceType GetDecorationSourceType();

         Net.Vpc.Upa.Config.DecorationTarget GetTarget();

         string GetLocationType();

         string GetName();

         bool IsName(string name);

         bool IsName(System.Type type);

         int GetPosition();

         string GetString(string name);

         bool GetBoolean(string name);

         int GetInt(string name);

          T GetEnum<T>(string name, System.Type type);

         Net.Vpc.Upa.Config.DecorationValue Get(string name);

         System.Type GetType(string name);

         Net.Vpc.Upa.Config.Decoration GetDecoration(string name);

          T[] GetPrimitiveArray<T>(string name, System.Type type);

         Net.Vpc.Upa.Config.DecorationValue[] GetArray(string name);

         System.Collections.Generic.IDictionary<string , Net.Vpc.Upa.Config.DecorationValue> GetAttributes();

         Net.Vpc.Upa.Config.Decoration CastName(string type);

         Net.Vpc.Upa.Config.Decoration CastName(System.Type type);
    }
}
