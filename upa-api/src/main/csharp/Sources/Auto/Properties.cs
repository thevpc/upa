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


    public interface Properties {

         bool ContainsKey(string key);

          T GetObject<T>(string key);

          T GetObject<T>(string key, T defaultValue);

         void SetObject(string key, object @value);

          T GetSingleObject<T>();

         int GetInt(string key);

         int GetInt(string key, int @value);

         void SetInt(string key, int @value);

         int GetSingleInt();

         long GetLong(string key);

         long GetLong(string key, long @value);

         void SetLong(string key, long @value);

         long GetSingleLong();

         double GetDouble(string key);

         double GetDouble(string key, double @value);

         void SetDouble(string key, double @value);

         double GetSingleDouble();

         float GetFloat(string key);

         float GetFloat(string key, float @value);

         void SetFloat(string key, float @value);

         float GetSingleFloat();

         Net.TheVpc.Upa.Types.Temporal GetDate(string key);

         Net.TheVpc.Upa.Types.Temporal GetDate(string key, Net.TheVpc.Upa.Types.Temporal @value);

         void SetDate(string key, Net.TheVpc.Upa.Types.Temporal @value);

         Net.TheVpc.Upa.Types.Temporal GetSingleDate();

         string GetString(string key);

         string GetString(string key, string @value);

         void SetString(string key, string @value);

         string GetSingleString();

         bool GetBoolean(string key);

         bool GetBoolean(string key, bool @value);

         void SetBoolean(string key, bool @value);

         bool GetSingleBoolean();

















         void SetBigInteger(string key, System.Numerics.BigInteger? @value);

         System.Numerics.BigInteger? GetBigInteger(string key, System.Numerics.BigInteger? @value);

         System.Numerics.BigInteger? GetBigInteger(string key);

         System.Numerics.BigInteger? GetSingleBigInteger();

         System.Collections.Generic.ISet<string> KeySet();

         int Size();

         System.Collections.Generic.IDictionary<string , object> ToMap();

         void SetAll(System.Collections.Generic.IDictionary<string , object> other, params string [] keys);

         void SetAll(Net.TheVpc.Upa.Properties other, params string [] keys);

         bool IsSet(string key);

         void Remove(string key);

         void AddPropertyChangeListener(string key, Net.TheVpc.Upa.PropertyChangeListener listener);

         void RemovePropertyChangeListener(string key, Net.TheVpc.Upa.PropertyChangeListener listener);

         void AddPropertyChangeListener(Net.TheVpc.Upa.PropertyChangeListener listener);

         void RemovePropertyChangeListener(Net.TheVpc.Upa.PropertyChangeListener listener);
    }
}
